// # Copyright © 2011, Novus Craft
// # All rights reserved. 

namespace NovusCraft.Model
{
	public sealed class UserAccount
	{
		public string Email { get; set; }
		public string PasswordHash { get; set; }
	}
}