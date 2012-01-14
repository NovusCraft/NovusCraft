// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Web.Mvc;
using Machine.Specifications;
using Machine.Specifications.Mvc;
using Moq;
using NovusCraft.Web.Controllers;
using NovusCraft.Web.ViewModels;
using It = Machine.Specifications.It;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.UserAccountControllerSpecs
{
	[Subject(typeof(UserAccountController))]
	public class when_user_tries_to_log_in_with_invalid_credentials : account_controller_spec
	{
		static ActionResult result;

		Because of = () =>
			{
				controller.ModelState.AddModelError(string.Empty, "error");
				result = controller.LogIn(new LogInModel());
				authentication_service.Verify(ams => ams.LogIn(Moq.It.IsAny<LogInModel>()), Times.Never());
			};

		It should_redisplay_login_page =
			() => result.ShouldBeAView().And().ShouldUseDefaultView();

		It should_display_invalid_login_error =
			() => controller.ModelState[string.Empty].Errors[0].ErrorMessage.ShouldEqual("error");
	}
}