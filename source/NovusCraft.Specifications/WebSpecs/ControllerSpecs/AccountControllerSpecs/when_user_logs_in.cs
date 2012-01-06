// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Web.Mvc;
using Machine.Specifications;
using Machine.Specifications.Mvc;
using NovusCraft.Web.Controllers;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.AccountControllerSpecs
{
	[Subject(typeof(AccountController))]
	public class when_user_logs_in : account_controller_spec
	{
		static ActionResult result;

		Because of = () =>
			{
				account_management_service.Setup(ams => ams.AuthenticateUser(Moq.It.IsAny<string>(), Moq.It.IsAny<string>())).Returns(true);
				result = controller.LogIn(email: "example@company.com", password: "password");
			};

		It should_display_dashboard_page =
			() => result.ShouldBeARedirectToRoute().And().ActionName().ShouldEqual("Dashboard");
	}
}