// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using Machine.Specifications;
using Moq;
using NovusCraft.Security;
using NovusCraft.Web.ViewModels;
using It = Machine.Specifications.It;

namespace NovusCraft.Specifications.SecuritySpecs.AuthenticationServiceSpecs
{
	[Subject(typeof(AuthenticationService))]
	public class when_user_tries_to_log_in_with_false_credentials : authentication_service_spec
	{
		static bool result;
		Because of = () => result = service.LogIn(new LogInModel { Email = "invalid_email@company.com", Password = "invalid_password" });

		It should_not_log_user_in =
			() => result.ShouldBeFalse();

		It should_not_set_authentication_cookie =
			() => forms_authentication_wrapper.Verify(faw => faw.SetAuthCookie("example@company.com"), Times.Never());

		It should_verify_user =
			() => user_account_repository.Verify(uar => uar.GetUserByEmailAndPassword(Moq.It.IsAny<string>(), Moq.It.IsAny<string>()), Times.Exactly(1));
	}
}