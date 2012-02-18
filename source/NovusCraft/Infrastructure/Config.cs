// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using System.Configuration;

namespace NovusCraft.Infrastructure
{
	public static class Config
	{
		public static string Get(string key)
		{
			return ConfigurationManager.AppSettings[key];
		}
	}
}