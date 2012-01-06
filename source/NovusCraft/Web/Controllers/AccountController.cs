// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using System.Web.Mvc;
using NovusCraft.Data.Security;
using NovusCraft.Resources;

namespace NovusCraft.Web.Controllers
{
	public sealed class AccountController : Controller
	{
		readonly IAccountManagementService _accountManagementService;

		public AccountController(IAccountManagementService accountManagementService)
		{
			_accountManagementService = accountManagementService;
		}

		public ActionResult LogIn()
		{
			return View();
		}

		public ActionResult LogIn(string email, string password)
		{
			var isAuthenticated = _accountManagementService.AuthenticateUser(email, password);

			if (isAuthenticated) // valid credentials
				return RedirectToAction("Dashboard", "Dashboard");

			ModelState.AddModelError(string.Empty, ErrorMessages.InvalidLoginDetails);
			return View(); // invalid credentials
		}

		public void LogOut()
		{
			throw new NotImplementedException();
		}
	}
}