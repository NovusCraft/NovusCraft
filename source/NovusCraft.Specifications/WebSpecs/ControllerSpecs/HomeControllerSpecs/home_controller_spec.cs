// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Machine.Specifications;
using Moq;
using NovusCraft.Data.Blog;
using NovusCraft.Web;
using NovusCraft.Web.Controllers;
using It = Moq.It;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.HomeControllerSpecs
{
	public abstract class home_controller_spec
	{
		protected static Mock<IBlogPostRepository> blog_post_repository;
		protected static Mock<HttpRequestBase> http_request;
		protected static Mock<HttpResponseBase> http_response;
		protected static HomeController controller;

		Establish context = () =>
			{
				blog_post_repository = new Mock<IBlogPostRepository>();

				http_request = new Mock<HttpRequestBase>();
				http_response = new Mock<HttpResponseBase>();
				http_response.Setup(hrb => hrb.ApplyAppPathModifier(It.IsAny<string>())).Returns((string s) => s);

				var controllerContext = new Mock<ControllerContext>();
				controllerContext.SetupGet(cc => cc.HttpContext.Request).Returns(http_request.Object);
				controllerContext.SetupGet(cc => cc.HttpContext.Response).Returns(http_response.Object);

				var httpContext = new Mock<HttpContextBase>();
				httpContext.SetupGet(hc => hc.Request).Returns(http_request.Object);
				httpContext.SetupGet(hc => hc.Response).Returns(http_response.Object);
				var urlHelper = new UrlHelper(new RequestContext(httpContext.Object, new RouteData()));

				RouteConfigurator.Initialise(); // this requires cleanup

				controller = new HomeController(blog_post_repository.Object) { ControllerContext = controllerContext.Object, Url = urlHelper };
			};

		Cleanup after = () => RouteTable.Routes.Clear();
	}
}