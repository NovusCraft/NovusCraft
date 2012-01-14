// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Web.Security;
using NovusCraft.Data.Security;
using NovusCraft.Web.ViewModels;

namespace NovusCraft.Security
{
	/// <summary>
	/// 	Wrapper for <see cref="FormsAuthentication" /> .
	/// </summary>
	public sealed class AuthenticationService : IAuthenticationService
	{
		readonly IFormsAuthenticationWrapper _formsAuthenticationWrapper;
		readonly IUserAccountRepository _userAccountRepository;

		public AuthenticationService(IUserAccountRepository userAccountRepository, IFormsAuthenticationWrapper formsAuthenticationWrapper)
		{
			_userAccountRepository = userAccountRepository;
			_formsAuthenticationWrapper = formsAuthenticationWrapper;
		}

		#region IAuthenticationService Members

		public bool LogIn(LogInModel logInModel)
		{
			var userAccount = _userAccountRepository.GetUserByEmailAndPassword(logInModel.Email, logInModel.Password);
			if (userAccount == null)
				return false;

			_formsAuthenticationWrapper.SetAuthCookie(logInModel.Email);
			return true;
		}

		public void LogOut()
		{
			_formsAuthenticationWrapper.RemoveAuthCookie();
		}

		#endregion
	}
}