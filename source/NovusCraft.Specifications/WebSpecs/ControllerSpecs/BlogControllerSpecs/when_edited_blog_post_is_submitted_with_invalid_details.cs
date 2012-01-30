// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Web.Mvc;
using Machine.Specifications;
using Machine.Specifications.Mvc;
using NovusCraft.Web.Controllers;
using NovusCraft.Web.ViewModels;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.BlogControllerSpecs
{
	[Subject(typeof(BlogController))]
	public class when_edited_blog_post_is_submitted_with_invalid_details : blog_controller_spec
	{
		static ActionResult result;

		Because of = () =>
		{
			controller.ModelState.AddModelError(string.Empty, "error");

			result = controller.EditBlogPost(new UpdateBlogPostModel());
		};

		It should_redisplay_page =
			() => result.ShouldBeAView().And().ShouldUseDefaultView();
	}
}