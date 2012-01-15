// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Web.Mvc;
using Machine.Specifications;
using Machine.Specifications.Mvc;
using NovusCraft.Specifications.Utils;
using NovusCraft.Web.Controllers;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.DashboardControllerSpecs
{
	[Subject(typeof(DashboardController))]
	public class when_home_page_is_requested : dashboard_controller_spec
	{
		static ActionResult result;
		Because of = () => result = controller.Home();

		It should_display_home_page =
			() => result.ShouldBeAView().And().ShouldUseDefaultView();

		It can_only_view_if_logged_in =
			() => This.Action<DashboardController>(controller => controller.Home()).ShouldBeDecoratedWith<AuthorizeAttribute>();
	}
}