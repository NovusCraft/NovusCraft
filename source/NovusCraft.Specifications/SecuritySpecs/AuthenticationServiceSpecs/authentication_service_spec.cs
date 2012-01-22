// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using Machine.Specifications;
using Moq;
using NovusCraft.Security;

namespace NovusCraft.Specifications.SecuritySpecs.AuthenticationServiceSpecs
{
	public abstract class authentication_service_spec
	{
		protected static AuthenticationService service;
		protected static Mock<IFormsAuthenticationWrapper> forms_authentication_wrapper;

		Establish context = () =>
			{
				forms_authentication_wrapper = new Mock<IFormsAuthenticationWrapper>();

				service = new AuthenticationService(forms_authentication_wrapper.Object);
			};
	}
}