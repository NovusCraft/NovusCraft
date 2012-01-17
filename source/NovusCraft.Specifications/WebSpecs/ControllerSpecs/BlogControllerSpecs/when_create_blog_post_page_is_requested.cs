// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Web.Mvc;
using Machine.Specifications;
using Machine.Specifications.Mvc;
using NovusCraft.Specifications.Utils;
using NovusCraft.Web.Controllers;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.BlogControllerSpecs
{
	[Subject(typeof(BlogController))]
	public class when_create_blog_post_page_is_requested : blog_controller_spec
	{
		static ActionResult result;
		Because of = () => result = controller.CreateBlogPost();

		It should_display_post_for_editing =
			() => result.ShouldBeAView().And().ShouldUseDefaultView();

		It requires_authentication =
			() => This.Action<BlogController>(controller => controller.CreateBlogPost()).ShouldBeDecoratedWith<AuthorizeAttribute>();
	}
}