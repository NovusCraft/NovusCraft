// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Web.Mvc;
using Machine.Specifications;
using Machine.Specifications.Mvc;
using Moq;
using NovusCraft.Web.Controllers;
using NovusCraft.Web.ViewModels;
using It = Machine.Specifications.It;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.AccountControllerSpecs
{
	[Subject(typeof(AccountController))]
	public class when_user_logs_out : account_controller_spec
	{
		static ActionResult result;
		static readonly LogInModel log_in_model = new LogInModel { Email = "example@company.com", Password = "password" };

		Because of = () => result = controller.LogOut();

		It should_log_user_in =
			() => authentication_service.Verify(ams => ams.LogOut(), Times.Exactly(1));

		It should_display_home_page =
			() => result.ShouldBeARedirectToRoute().And().ActionName().ShouldEqual("Home");
	}
}