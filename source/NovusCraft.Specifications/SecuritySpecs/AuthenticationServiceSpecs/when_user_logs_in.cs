// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using Machine.Specifications;
using Moq;
using NovusCraft.Data.Security;
using NovusCraft.Security;
using NovusCraft.Web.ViewModels;
using It = Machine.Specifications.It;

namespace NovusCraft.Specifications.SecuritySpecs.AuthenticationServiceSpecs
{
	[Subject(typeof(AuthenticationService))]
	public class when_user_logs_in : authentication_service_spec
	{
		static bool result;

		Because of = () =>
			{
				user_account_repository.Setup(uar => uar.GetUserAccountByEmailAndPasswordHash("example@company.com", "虜ꘕ‷倯॰៘倂쭮猱◡參齙甇⽯䅖")).Returns(new UserAccount());
				result = service.LogIn(new LogInModel { Email = "example@company.com", Password = "password" });
			};

		It should_log_user_in =
			() => result.ShouldBeTrue();

		It should_set_authentication_cookie =
			() => forms_authentication_wrapper.Verify(faw => faw.SetAuthCookie("example@company.com"), Times.Exactly(1));

		It should_verify_user =
			() => user_account_repository.Verify(uar => uar.GetUserAccountByEmailAndPasswordHash("example@company.com", "虜ꘕ‷倯॰៘倂쭮猱◡參齙甇⽯䅖"), Times.Exactly(1));
	}
}