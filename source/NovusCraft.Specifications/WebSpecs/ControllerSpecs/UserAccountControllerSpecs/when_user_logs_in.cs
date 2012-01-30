// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Web.Mvc;
using Machine.Specifications;
using Machine.Specifications.Mvc;
using Moq;
using NovusCraft.Model;
using NovusCraft.Specifications.SpecUtils;
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
			session.Store(new UserAccount
			{
				Email = "example@company.com",
				PasswordHash = "虜ꘕ‷倯॰៘倂쭮猱◡參齙甇⽯䅖"
			});
			session.SaveChanges();

			result = controller.LogIn(log_in_model);
		};

		It should_set_authentication_cookie =
			() => forms_authentication_wrapper.Verify(faw => faw.SetAuthCookie("example@company.com"), Times.Exactly(1));

		It should_display_dashboard_page =
			() => result.ShouldBeARedirectToRoute().And().ActionName().ShouldEqual("Home");

		It is_protected_against_xsrf =
			() => This.Action<UserAccountController>(controller => controller.LogIn(Moq.It.IsAny<LogInModel>())).ShouldBeDecoratedWith<ValidateAntiForgeryTokenAttribute>();

		It can_only_post_page =
			() => This.Action<UserAccountController>(controller => controller.LogIn(Moq.It.IsAny<LogInModel>())).ShouldBeDecoratedWith<HttpPostAttribute>();
	}
}