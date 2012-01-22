// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using System.Security.Cryptography;
using System.Text;

namespace NovusCraft.Security
{
	public static class HashUtility
	{
		public static string GenerateHash(string password)
		{
			var key = new Guid("ee9935ff-a9d5-44c3-ac00-c923783e9265").ToByteArray(); // TODO: Move to config

			using (var hmac = new HMACSHA256(key))
			{
				var passwordBytes = Encoding.Unicode.GetBytes(password);
				var hashBytes = hmac.ComputeHash(passwordBytes);

				return Encoding.Unicode.GetString(hashBytes);
			}
		}
	}
}