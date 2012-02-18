// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using System.Linq;
using System.Web.Mvc;
using NovusCraft.Infrastructure.Indexes;
using NovusCraft.Model;
using NovusCraft.Resources;
using NovusCraft.Security;
using NovusCraft.Web.ViewModels;
using Raven.Client;

namespace NovusCraft.Web.Controllers
{
	public sealed class UserAccountController : Controller
	{
		readonly IDocumentSession _documentSession;
		readonly IFormsAuthenticationWrapper _formsAuthentication;

		public UserAccountController(IDocumentSession documentSession, IFormsAuthenticationWrapper formsAuthentication)
		{
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
				var userAccountExists = _documentSession.Query<UserAccount>(UserAccounts_ByEmailAndPasswordHash.Name).Any(ua => ua.Email == logInModel.Email && ua.PasswordHash == passwordHash);

				if (userAccountExists)
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
			_formsAuthentication.RemoveAuthCookie();

			return RedirectToAction("Home", "Home");
		}
	}
}