// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Linq;
using Raven.Client;

namespace NovusCraft.Data.Security
{
	public sealed class UserAccountRepository : IUserAccountRepository
	{
		readonly IDocumentSession _documentSession;

		public UserAccountRepository(IDocumentSession documentSession)
		{
			_documentSession = documentSession;
		}

		#region IUserAccountRepository Members

		public UserAccount GetUserAccountByEmailAndPasswordHash(string email, string passwordHash)
		{
			return _documentSession.Query<UserAccount>().SingleOrDefault(ua => ua.Email == email && ua.PasswordHash == passwordHash);
		}

		#endregion
	}
}