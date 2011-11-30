// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Machine.Specifications;
using Moq;
using NovusCraft.Data.Blog;
using NovusCraft.Web;
using NovusCraft.Web.Controllers;
using It = Moq.It;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.BlogControllerSpecs
{
	public abstract class blog_controller_spec
	{
		protected static BlogController controller;
		protected static Mock<HttpResponseBase> http_response;

		Establish context = () =>
			{
				var httpRequest = new Mock<HttpRequestBase>();
				httpRequest.SetupGet(hr => hr.ApplicationPath).Returns(string.Empty);
				httpRequest.SetupGet(hr => hr.Url).Returns(new Uri("http://novuscraft.com/blog/test-slug-1"));

				http_response = new Mock<HttpResponseBase>();
				http_response.Setup(hrb => hrb.ApplyAppPathModifier(It.IsAny<string>())).Returns((string s) => s);

				var controllerContext = new Mock<ControllerContext>();
				controllerContext.SetupGet(cc => cc.HttpContext.Request).Returns(httpRequest.Object);
				controllerContext.SetupGet(cc => cc.HttpContext.Response).Returns(http_response.Object);

				var httpContext = new Mock<HttpContextBase>();
				httpContext.SetupGet(hc => hc.Request).Returns(httpRequest.Object);
				httpContext.SetupGet(hc => hc.Response).Returns(http_response.Object);
				var urlHelper = new UrlHelper(new RequestContext(httpContext.Object, new RouteData()));

				RouteConfigurator.Initialise(); // this requires cleanup

				var repository = new Mock<IBlogPostRepository>();
				repository.Setup(r => r.GetBlogPost("test-slug-1")).Returns(new BlogPost
				                                                            	{
				                                                            		Id = "blogposts/1",
				                                                            		Title = "Test Post Title 1",
				                                                            		Slug = "test-slug-1",
				                                                            		Content = "Test Post Content 1",
				                                                            		Category = new BlogPostCategory
				                                                            		           	{
				                                                            		           		Title = "Category 1"
				                                                            		           	},
				                                                            		PublishedOn = new DateTimeOffset(2011, 11, 10, 09, 08, 07, TimeSpan.Zero)
				                                                            	});

				controller = new BlogController(repository.Object) { ControllerContext = controllerContext.Object, Url = urlHelper };
			};

		Cleanup after = () => RouteTable.Routes.Clear();
	}
}