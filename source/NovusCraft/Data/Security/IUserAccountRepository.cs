// # Copyright © 2011, Novus Craft
// # All rights reserved. 

namespace NovusCraft.Data.Security
{
	public interface IUserAccountRepository
	{
		UserAccount GetUserByEmailAndPassword(string email, string passwordHash);
	}
}