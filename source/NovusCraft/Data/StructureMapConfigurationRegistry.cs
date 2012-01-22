// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
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

			// Security
			For<IFormsAuthenticationWrapper>().HybridHttpOrThreadLocalScoped().Use<FormsAuthenticationWrapper>();
		}

		void RegisterRavenDb()
		{
			ForSingletonOf<IDocumentStore>().Use(DocumentStoreFactory.CreateEmbeddableDocumentStore());
			For<IDocumentSession>().HybridHttpOrThreadLocalScoped().Use(context => context.GetInstance<IDocumentStore>().OpenSession());
		}
	}
}