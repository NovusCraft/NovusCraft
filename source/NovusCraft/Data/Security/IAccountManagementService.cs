// # Copyright © 2011, Novus Craft
// # All rights reserved. 

namespace NovusCraft.Data.Security
{
	public interface IAccountManagementService
	{
		bool AuthenticateUser(string email, string password);
	}
}