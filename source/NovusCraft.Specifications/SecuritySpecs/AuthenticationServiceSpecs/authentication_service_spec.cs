// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using Machine.Specifications;
using Moq;
using NovusCraft.Data.Security;
using NovusCraft.Security;

namespace NovusCraft.Specifications.SecuritySpecs.AuthenticationServiceSpecs
{
	public abstract class authentication_service_spec
	{
		protected static AuthenticationService service;
		protected static Mock<IUserAccountRepository> user_account_repository;
		protected static Mock<IFormsAuthenticationWrapper> forms_authentication_wrapper;

		Establish context = () =>
			{
				user_account_repository = new Mock<IUserAccountRepository>();
				forms_authentication_wrapper = new Mock<IFormsAuthenticationWrapper>();

				service = new AuthenticationService(user_account_repository.Object, forms_authentication_wrapper.Object);
			};
	}
}