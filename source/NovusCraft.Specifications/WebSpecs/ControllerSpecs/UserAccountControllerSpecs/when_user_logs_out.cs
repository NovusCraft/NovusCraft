// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using System.Web.Mvc;
using Machine.Specifications;
using Machine.Specifications.Mvc;
using Moq;
using NovusCraft.Web.Controllers;
using It = Machine.Specifications.It;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.UserAccountControllerSpecs
{
	[Subject(typeof(UserAccountController))]
	public class when_user_logs_out : account_controller_spec
	{
		static ActionResult result;
		Because of = () => result = controller.LogOut();

		It should_remove_authentication_cookie =
			() => forms_authentication_wrapper.Verify(faw => faw.RemoveAuthCookie(), Times.Exactly(1));

		It should_display_home_page =
			() => result.ShouldBeARedirectToRoute().And().ActionName().ShouldEqual("Home");
	}
}