// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using System.Web.Mvc;
using NovusCraft.Data.Security;
using NovusCraft.Resources;
using NovusCraft.Web.ViewModels;

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

		[HttpPost]
		public ActionResult LogIn(LogInDetails logInDetails)
		{
			if (ModelState.IsValid)
			{
				var isAuthenticated = _accountManagementService.LogIn(logInDetails);

				if (isAuthenticated) // valid credentials
					return RedirectToAction("Dashboard", "Dashboard");
			}

			ModelState.AddModelError(string.Empty, ErrorMessages.InvalidLoginDetails);
			return View(); // invalid credentials
		}

		public void LogOut()
		{
			throw new NotImplementedException();
		}
	}
}