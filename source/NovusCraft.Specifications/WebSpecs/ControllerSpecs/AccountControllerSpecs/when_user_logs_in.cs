// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Reflection;
using System.Web.Mvc;
using Machine.Specifications;
using Machine.Specifications.Mvc;
using Moq;
using NovusCraft.Specifications.Utils;
using NovusCraft.Web.Controllers;
using NovusCraft.Web.ViewModels;
using It = Machine.Specifications.It;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.AccountControllerSpecs
{
	[Subject(typeof(AccountController))]
	public class when_user_logs_in : account_controller_spec
	{
		static ActionResult result;
		static readonly LogInDetails log_in_details = new LogInDetails { Email = "example@company.com", Password = "password" };

		Because of = () =>
			{
				account_management_service.Setup(ams => ams.LogIn(Moq.It.IsAny<LogInDetails>())).Returns(true);
				result = controller.LogIn(log_in_details);
			};

		It should_log_user_in =
			() => account_management_service.Verify(ams => ams.LogIn(log_in_details), Times.Exactly(1));

		It should_display_dashboard_page =
			() => result.ShouldBeARedirectToRoute().And().ActionName().ShouldEqual("Dashboard");

		It only_http_post_is_allowed =
			() => controller.GetType().GetMethod("LogIn", new[] { typeof(LogInDetails) }).ShouldBeDecoratedWith<HttpPostAttribute>();
	}
}