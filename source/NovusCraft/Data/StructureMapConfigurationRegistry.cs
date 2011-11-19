// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using NovusCraft.Data.Blog;
using StructureMap.Configuration.DSL;

namespace NovusCraft.Data
{
	[CLSCompliant(false)]
	public sealed class StructureMapConfigurationRegistry : Registry
	{
		public StructureMapConfigurationRegistry()
		{
			For<IBlogPostRepository>().Singleton().Use<InMemoryBlogPostRepository>();
		}
	}
}