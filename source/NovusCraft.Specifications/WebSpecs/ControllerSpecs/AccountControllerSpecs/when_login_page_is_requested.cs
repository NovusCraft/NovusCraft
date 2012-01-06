// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Web.Mvc;
using Machine.Specifications;
using Machine.Specifications.Mvc;
using NovusCraft.Web.Controllers;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.AccountControllerSpecs
{
	[Subject(typeof(AccountController))]
	public class when_login_page_is_requested : account_controller_spec
	{
		static ActionResult result;
		Because of = () => result = controller.LogIn();

		It should_display_page =
			() => result.ShouldBeAView().And().ShouldUseDefaultView();
	}
}