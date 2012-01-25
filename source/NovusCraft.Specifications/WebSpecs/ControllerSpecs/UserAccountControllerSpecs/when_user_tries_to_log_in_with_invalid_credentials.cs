// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Linq;
using System.Web.Mvc;
using Machine.Specifications;
using Machine.Specifications.Mvc;
using NovusCraft.Web.Controllers;
using NovusCraft.Web.ViewModels;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.UserAccountControllerSpecs
{
	[Subject(typeof(UserAccountController))]
	public class when_user_tries_to_log_in_with_invalid_credentials : account_controller_spec
	{
		static ActionResult result;

		Because of = () =>
			{
				controller.ModelState.AddModelError(string.Empty, "invalid credentials");

				result = controller.LogIn(new LogInModel());
			};

		It should_redisplay_login_page =
			() => result.ShouldBeAView().And().ShouldUseDefaultView();

		It should_not_display_invalid_login_error =
			() => controller.ModelState[string.Empty].Errors.Any(e => e.ErrorMessage == "The username or password you have entered is incorrect.").ShouldBeFalse();
	}
}