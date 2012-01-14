// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Web.Mvc;
using Machine.Specifications;
using Machine.Specifications.Mvc;
using Moq;
using NovusCraft.Specifications.Utils;
using NovusCraft.Web.Controllers;
using NovusCraft.Web.ViewModels;
using It = Machine.Specifications.It;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.UserAccountControllerSpecs
{
	[Subject(typeof(UserAccountController))]
	public class when_user_logs_in : account_controller_spec
	{
		static ActionResult result;
		static readonly LogInModel log_in_model = new LogInModel { Email = "example@company.com", Password = "password" };

		Because of = () =>
			{
				authentication_service.Setup(ams => ams.LogIn(Moq.It.IsAny<LogInModel>())).Returns(true);
				result = controller.LogIn(log_in_model);
			};

		It should_log_user_in =
			() => authentication_service.Verify(ams => ams.LogIn(log_in_model), Times.Exactly(1));

		It should_display_dashboard_page =
			() => result.ShouldBeARedirectToRoute().And().ActionName().ShouldEqual("Dashboard");

		It can_only_post_page =
			() => This.Action<UserAccountController>(controller => controller.LogIn(Moq.It.IsAny<LogInModel>())).ShouldBeDecoratedWith<HttpPostAttribute>();
	}
}