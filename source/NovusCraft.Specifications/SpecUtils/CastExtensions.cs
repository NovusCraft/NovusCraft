// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

namespace NovusCraft.Specifications.SpecUtils
{
	public static class CastExtensions
	{
		public static T As<T>(this object @object) where T : class
		{
			return (T)@object;
		}
	}
}