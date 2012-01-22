// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using NovusCraft.Data.Blog;
using NovusCraft.Security;
using Raven.Client;
using StructureMap.Configuration.DSL;

namespace NovusCraft.Data
{
	[CLSCompliant(false)]
	public sealed class StructureMapConfigurationRegistry : Registry
	{
		public StructureMapConfigurationRegistry()
		{
			// Raven DB
			RegisterRavenDb();

			// Blog
			For<IBlogPostRepository>().HybridHttpOrThreadLocalScoped().Use<BlogPostRepository>();

			// Security
			For<IFormsAuthenticationWrapper>().HybridHttpOrThreadLocalScoped().Use<FormsAuthenticationWrapper>();
			For<IAuthenticationService>().HybridHttpOrThreadLocalScoped().Use<AuthenticationService>();
		}

		void RegisterRavenDb()
		{
			ForSingletonOf<IDocumentStore>().Use(DocumentStoreFactory.CreateEmbeddableDocumentStore());
			For<IDocumentSession>().HybridHttpOrThreadLocalScoped().Use(context => context.GetInstance<IDocumentStore>().OpenSession());
		}
	}
}