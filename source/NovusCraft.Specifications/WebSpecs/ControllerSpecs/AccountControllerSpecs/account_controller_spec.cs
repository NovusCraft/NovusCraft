// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using Machine.Specifications;
using Moq;
using NovusCraft.Data.Security;
using NovusCraft.Web.Controllers;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.AccountControllerSpecs
{
	public abstract class account_controller_spec
	{
		protected static AccountController controller;
		protected static Mock<IAccountManagementService> account_management_service;

		Establish context = () =>
			{
				account_management_service = new Mock<IAccountManagementService>();

				controller = new AccountController(account_management_service.Object);
			};
	}
}