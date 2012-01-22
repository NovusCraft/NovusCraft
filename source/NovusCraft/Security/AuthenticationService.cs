// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Web.Security;

namespace NovusCraft.Security
{
	/// <summary>
	/// 	Wrapper for <see cref="FormsAuthentication" /> .
	/// </summary>
	public sealed class AuthenticationService : IAuthenticationService
	{
		readonly IFormsAuthenticationWrapper _formsAuthenticationWrapper;

		public AuthenticationService(IFormsAuthenticationWrapper formsAuthenticationWrapper)
		{
			_formsAuthenticationWrapper = formsAuthenticationWrapper;
		}

		#region IAuthenticationService Members

		public void LogOut()
		{
			_formsAuthenticationWrapper.RemoveAuthCookie();
		}

		#endregion
	}
}