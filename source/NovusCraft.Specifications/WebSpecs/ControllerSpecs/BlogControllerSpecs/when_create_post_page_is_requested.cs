// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Web.Mvc;
using Machine.Specifications;
using Machine.Specifications.Mvc;
using NovusCraft.Web.Controllers;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.BlogControllerSpecs
{
	[Subject(typeof(BlogController))]
	public class when_create_post_page_is_requested : blog_controller_spec
	{
		static ActionResult result;
		Because of = () => result = controller.CreatePost();

		It should_display_post_for_editing =
			() => result.ShouldBeAView().And().ShouldUseDefaultView();
	}
}