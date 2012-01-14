// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Web.Security;

namespace NovusCraft.Security
{
	public sealed class FormsAuthenticationWrapper : IFormsAuthenticationWrapper
	{
		#region IFormsAuthenticationWrapper Members

		public void SetAuthCookie(string email)
		{
			FormsAuthentication.SetAuthCookie(email, createPersistentCookie: false);
		}

		public void RemoveAuthCookie()
		{
			FormsAuthentication.SignOut();
		}

		#endregion
	}
}