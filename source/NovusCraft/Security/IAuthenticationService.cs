// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using NovusCraft.Web.ViewModels;

namespace NovusCraft.Security
{
	public interface IAuthenticationService
	{
		bool LogIn(LogInModel logInModel);
		void LogOut();
	}
}