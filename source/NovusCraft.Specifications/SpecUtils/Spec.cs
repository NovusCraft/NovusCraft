// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using NovusCraft.Infrastructure;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Embedded;
using Raven.Client.Indexes;
using StructureMap;

namespace NovusCraft.Specifications.SpecUtils
{
	public static class Spec
	{
		public static IDocumentSession ContextDocumentSession
		{
			get { return ObjectFactory.Container.GetInstance<IDocumentSession>(); }
		}

		public static void RequiresAutoMapperConfiguration()
		{
			AutoMapperConfigurator.Initialise();
		}

		public static IDocumentSession RequiresRavenDBDocumentSession()
		{
			var documentStore = RequiresRavenDBDocumentStore();
			return documentStore.OpenSession();
		}

		public static EmbeddableDocumentStore RequiresRavenDBDocumentStore()
		{
			var documentStore = new EmbeddableDocumentStore { RunInMemory = true, Conventions = new DocumentConvention { DefaultQueryingConsistency = ConsistencyOptions.QueryYourWrites } };
			documentStore.Initialize();

			IndexCreation.CreateIndexes(typeof(DocumentStoreFactory).Assembly, documentStore);

			return documentStore;
		}
	}
}