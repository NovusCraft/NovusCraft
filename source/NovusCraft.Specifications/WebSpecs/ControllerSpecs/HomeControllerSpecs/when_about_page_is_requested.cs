// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Web.Mvc;
using Machine.Specifications;
using Machine.Specifications.Mvc;
using NovusCraft.Web.Controllers;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.HomeControllerSpecs
{
	[Subject(typeof(HomeController))]
	public class when_about_page_is_requested : home_controller_spec
	{
		static ActionResult result;
		Because of = () => result = controller.About();

		It should_display_about_page =
			() => result.ShouldBeAView().And().ShouldUseDefaultView();
	}
}