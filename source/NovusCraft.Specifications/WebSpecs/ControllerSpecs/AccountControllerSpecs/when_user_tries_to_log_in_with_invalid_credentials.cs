// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Web.Mvc;
using Machine.Specifications;
using Machine.Specifications.Mvc;
using NovusCraft.Web.Controllers;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.AccountControllerSpecs
{
	[Subject(typeof(AccountController))]
	public class when_user_tries_to_log_in_with_invalid_credentials : account_controller_spec
	{
		static ActionResult result;

		Because of = () =>
			{
				account_management_service.Setup(ams => ams.AuthenticateUser(Moq.It.IsAny<string>(), Moq.It.IsAny<string>())).Returns(false);
				result = controller.LogIn(email: "invalid_email@company.com", password: "invalid_password");
			};

		It should_redisplay_login_page =
			() => result.ShouldBeAView().And().ShouldUseDefaultView();

		It should_display_invalid_login_error =
			() => controller.ModelState[string.Empty].Errors[0].ErrorMessage.ShouldEqual("The username or password you have entered is incorrect.");
	}
}