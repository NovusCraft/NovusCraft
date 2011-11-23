// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using NovusCraft.Data.Blog;
using NovusCraft.Web;
using Raven.Client;
using StructureMap.Configuration.DSL;

namespace NovusCraft.Data
{
	[CLSCompliant(false)]
	public sealed class StructureMapConfigurationRegistry : Registry
	{
		public StructureMapConfigurationRegistry()
		{
			RegisterDocumentSession();

			For<IBlogPostRepository>().HybridHttpOrThreadLocalScoped().Use<BlogPostRepository>();
		}

		void RegisterDocumentSession()
		{
			For<IDocumentSession>().HybridHttpOrThreadLocalScoped().Use(() => MvcApplication.RavenDbDocumentStore.OpenSession());
		}
	}
}