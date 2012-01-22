// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Web.Mvc;
using Machine.Specifications;
using Machine.Specifications.Mvc;
using NovusCraft.Web.Controllers;
using NovusCraft.Web.ViewModels;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.UserAccountControllerSpecs
{
	[Subject(typeof(UserAccountController))]
	public class when_user_tries_to_log_in_with_false_credentials : account_controller_spec
	{
		static ActionResult result;

		Because of = () => result = controller.LogIn(new LogInModel { Email = "invalid_email@company.com", Password = "invalid_password" });

		It should_redisplay_login_page =
			() => result.ShouldBeAView().And().ShouldUseDefaultView();

		It should_display_invalid_login_error =
			() => controller.ModelState[string.Empty].Errors[0].ErrorMessage.ShouldEqual("The username or password you have entered is incorrect.");
	}
}