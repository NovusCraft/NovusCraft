// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

namespace NovusCraft.Model
{
	public sealed class UserAccount
	{
		public string Email { get; set; }
		public string PasswordHash { get; set; }
	}
}