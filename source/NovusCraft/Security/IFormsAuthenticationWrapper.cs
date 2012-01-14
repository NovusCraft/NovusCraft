// # Copyright © 2011, Novus Craft
// # All rights reserved. 

namespace NovusCraft.Security
{
	public interface IFormsAuthenticationWrapper
	{
		void SetAuthCookie(string email);
		void RemoveAuthCookie();
	}
}