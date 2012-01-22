// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Linq;
using System.Web.Mvc;
using NovusCraft.Data.Security;
using NovusCraft.Resources;
using NovusCraft.Security;
using NovusCraft.Web.ViewModels;
using Raven.Client;

namespace NovusCraft.Web.Controllers
{
	public sealed class UserAccountController : Controller
	{
		readonly IAuthenticationService _authenticationService;
		readonly IDocumentSession _documentSession;
		readonly IFormsAuthenticationWrapper _formsAuthentication;

		public UserAccountController(IAuthenticationService authenticationService, IDocumentSession documentSession, IFormsAuthenticationWrapper formsAuthentication)
		{
			_authenticationService = authenticationService;
			_documentSession = documentSession;
			_formsAuthentication = formsAuthentication;
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
				var passwordHash = HashUtility.GenerateHash(logInModel.Password);
				var userAccount = _documentSession.Query<UserAccount>().SingleOrDefault(ua => ua.Email == logInModel.Email && ua.PasswordHash == passwordHash);

				if (userAccount != null)
				{
					// authentication successful
					_formsAuthentication.SetAuthCookie(logInModel.Email);
					return RedirectToAction("Home", "Dashboard");
				}

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