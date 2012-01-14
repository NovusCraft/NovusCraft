// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using Machine.Specifications;
using Moq;
using NovusCraft.Security;
using It = Machine.Specifications.It;

namespace NovusCraft.Specifications.SecuritySpecs.AuthenticationServiceSpecs
{
	[Subject(typeof(AuthenticationService))]
	public class when_user_logs_out : authentication_service_spec
	{
		Because of = () => service.LogOut();

		It should_remove_authentication_cookie =
			() => forms_authentication_wrapper.Verify(faw => faw.RemoveAuthCookie(), Times.Exactly(1));
	}
}