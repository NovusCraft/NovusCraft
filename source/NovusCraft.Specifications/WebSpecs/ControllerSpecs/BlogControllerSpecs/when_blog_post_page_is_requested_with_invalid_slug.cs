// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using System.Web;
using System.Web.Mvc;
using Machine.Specifications;
using Machine.Specifications.Mvc;
using Moq;
using NovusCraft.Web.Controllers;
using It = Machine.Specifications.It;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.BlogControllerSpecs
{
	[Subject(typeof(BlogController))]
	public class when_blog_post_page_is_requested_with_invalid_slug : blog_controller_spec
	{
		static Mock<HttpResponseBase> http_response;
		static ActionResult result;

		Because of = () =>
		{
			http_response = new Mock<HttpResponseBase>();

			var controllerContext = new Mock<ControllerContext>();
			controllerContext.SetupGet(cc => cc.HttpContext.Request).Returns(new Mock<HttpRequestBase>().Object);
			controllerContext.SetupGet(cc => cc.HttpContext.Response).Returns(http_response.Object);
			controller.ControllerContext = controllerContext.Object;

			result = controller.ViewBlogPost(slug: "test-slug-?");
		};

		It should_display_page =
			() => result.ShouldBeAView().And().ViewName.ShouldEqual("PageNotFound");

		It should_set_status_code_to_404 =
			() => http_response.VerifySet(hr => hr.StatusCode = 404);
	}
}