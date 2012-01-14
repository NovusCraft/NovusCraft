// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Web.Mvc;
using NovusCraft.Resources;
using NovusCraft.Security;
using NovusCraft.Web.ViewModels;

namespace NovusCraft.Web.Controllers
{
	public sealed class UserAccountController : Controller
	{
		readonly IAuthenticationService _authenticationService;

		public UserAccountController(IAuthenticationService authenticationService)
		{
			_authenticationService = authenticationService;
		}

		public ActionResult LogIn()
		{
			return View();
		}

		[HttpPost, ValidateAntiForgeryToken]
		public ActionResult LogIn(LogInModel logInModel)
		{
			if (ModelState.IsValid)
			{
				var isAuthenticated = _authenticationService.LogIn(logInModel);
				if (isAuthenticated) // valid credentials
					return RedirectToAction("Dashboard", "Home");

				// authentication failed
				ModelState.AddModelError(string.Empty, ErrorMessages.InvalidLoginDetails);
			}

			return View(); // invalid credentials
		}

		public ActionResult LogOut()
		{
			_authenticationService.LogOut();

			return RedirectToAction("Home", "Home");
		}
	}
}