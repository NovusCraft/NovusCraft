// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using Machine.Specifications;
using Moq;
using NovusCraft.Security;
using NovusCraft.Web.Controllers;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.AccountControllerSpecs
{
	public abstract class account_controller_spec
	{
		protected static AccountController controller;
		protected static Mock<IAuthenticationService> authentication_service;

		Establish context = () =>
			{
				authentication_service = new Mock<IAuthenticationService>();

				controller = new AccountController(authentication_service.Object);
			};
	}
}