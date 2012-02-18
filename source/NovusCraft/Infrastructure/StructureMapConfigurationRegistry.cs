// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using System;
using NovusCraft.Security;
using Raven.Client;
using StructureMap.Configuration.DSL;

namespace NovusCraft.Infrastructure
{
	[CLSCompliant(false)]
	public sealed class StructureMapConfigurationRegistry : Registry
	{
		public StructureMapConfigurationRegistry()
		{
			// RavenDB
			ForSingletonOf<IDocumentStore>().Use(DocumentStoreFactory.CreateEmbeddableDocumentStore());
			For<IDocumentSession>().HybridHttpOrThreadLocalScoped().Use(context => context.GetInstance<IDocumentStore>().OpenSession());

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
	}
}