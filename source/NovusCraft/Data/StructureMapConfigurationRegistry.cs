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
			// RavenDB
			RegisterRavenDB();

			// Blog
			Scan(scanner =>
				{
					scanner.AssemblyContainingType<ICommand>();
					scanner.IncludeNamespaceContainingType<ICommand>();
					scanner.AddAllTypesOf(typeof(CommandHandler<>));
					scanner.With(new SingletonConvention(typeof(CommandHandler<>)));
				});

			// Security
			For<IFormsAuthenticationWrapper>().HybridHttpOrThreadLocalScoped().Use<FormsAuthenticationWrapper>();
		}

		void RegisterRavenDB()
		{
			ForSingletonOf<IDocumentStore>().Use(DocumentStoreFactory.CreateEmbeddableDocumentStore());
			For<IDocumentSession>().HybridHttpOrThreadLocalScoped().Use(context => context.GetInstance<IDocumentStore>().OpenSession());
		}
	}
}