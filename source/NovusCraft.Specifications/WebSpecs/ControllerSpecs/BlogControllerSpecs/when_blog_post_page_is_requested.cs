// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Machine.Specifications;
using Machine.Specifications.Mvc;
using Moq;
using NovusCraft.Data.Blog;
using NovusCraft.Web;
using NovusCraft.Web.Controllers;
using NovusCraft.Web.ViewModels;
using It = Machine.Specifications.It;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.BlogControllerSpecs
{
	[Subject(typeof(BlogController))]
	public class when_blog_post_page_is_requested : blog_controller_spec
	{
		static ActionResult result;

		Because of = () =>
		{
			var httpRequest = new Mock<HttpRequestBase>();
			httpRequest.SetupGet(hr => hr.Url).Returns(new Uri("http://novuscraft.com/blog/test-slug-1"));

			var httpResponse = new Mock<HttpResponseBase>();
			httpResponse.Setup(hrb => hrb.ApplyAppPathModifier(Moq.It.IsAny<string>())).Returns((string s) => s);

			var httpContext = new Mock<HttpContextBase>();
			httpContext.SetupGet(hc => hc.Request).Returns(httpRequest.Object);
			httpContext.SetupGet(hc => hc.Response).Returns(httpResponse.Object);
			var urlHelper = new UrlHelper(new RequestContext(httpContext.Object, new RouteData()));

			RouteConfigurator.Initialise(); // this populates route table, so ensure RouteTable.Routes.Clear() is called during cleanup

			controller.Url = urlHelper;

			using (var session = document_store.OpenSession())
			{
				session.Store(new BlogPost
				{
					Id = 1,
					Title = "Test Title",
					Slug = "test-title",
					Content = "Test Content",
					Category = "Category A",
					PublishedOn = new DateTimeOffset(2011, 11, 10, 09, 08, 07, TimeSpan.Zero)
				});

				session.SaveChanges();
			}

			result = controller.ViewBlogPost(slug: "test-title");
		};

		It should_display_blog_post =
			() => result.ShouldBeAView().And().ShouldUseDefaultView();

		It should_return_blog_post_with_id =
			() => result.Model<ViewBlogPostModel>().Id.ShouldEqual(1);

		It should_return_blog_post_with_title =
			() => result.Model<ViewBlogPostModel>().Title.ShouldEqual("Test Title");

		It should_return_blog_post_with_content =
			() => result.Model<ViewBlogPostModel>().Content.ShouldEqual("Test Content");

		It should_return_blog_post_with_permalink =
			() => result.Model<ViewBlogPostModel>().Permalink.ShouldEqual("http://novuscraft.com/blog/test-title");

		It should_return_blog_post_with_category_title =
			() => result.Model<ViewBlogPostModel>().Category.ShouldEqual("Category A");

		It should_return_blog_post_with_publish_date =
			() => result.Model<ViewBlogPostModel>().PublishedOn.ShouldEqual(new DateTimeOffset(2011, 11, 10, 09, 08, 07, TimeSpan.Zero));
	}
}