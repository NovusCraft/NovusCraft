// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Linq;
using NovusCraft.Model;
using Raven.Client.Indexes;

namespace NovusCraft.Infrastructure.Indexes
{
	public sealed class UserAccounts_ByEmailAndPasswordHash : AbstractIndexCreationTask<UserAccount>
	{
		public UserAccounts_ByEmailAndPasswordHash()
		{
			Map = userAccounts => from userAccount in userAccounts
			                      select new
			                      {
			                      	userAccount.Email,
			                      	userAccount.PasswordHash
			                      };
		}

		public static string Name
		{
			get { return "UserAccounts/ByEmailAndPasswordHash"; }
		}
	}
}