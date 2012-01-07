// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Reflection;
using System.Web.Mvc;
using Machine.Specifications;
using Machine.Specifications.Mvc;
using NovusCraft.Specifications.Utils;
using NovusCraft.Web.Controllers;
using NovusCraft.Web.ViewModels;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.AccountControllerSpecs
{
	[Subject(typeof(AccountController))]
	public class when_user_logs_in : account_controller_spec
	{
		static ActionResult result;

		Because of = () =>
			{
				account_management_service.Setup(ams => ams.LogIn(Moq.It.IsAny<LogInDetails>())).Returns(true);
				result = controller.LogIn(new LogInDetails { Email = "example@company.com", Password = "password" });
			};

		It should_display_dashboard_page =
			() => result.ShouldBeARedirectToRoute().And().ActionName().ShouldEqual("Dashboard");

		It only_http_post_is_allowed =
			() => controller.GetType().GetMethod("LogIn", new[] { typeof(LogInDetails) }).ShouldBeDecoratedWith<HttpPostAttribute>();
	}
}