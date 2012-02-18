// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using System.Reflection;
using Raven.Client.Embedded;
using Raven.Client.Indexes;

namespace NovusCraft.Infrastructure
{
	public static class DocumentStoreFactory
	{
		public static EmbeddableDocumentStore CreateEmbeddableDocumentStore()
		{
			var documentStore = new EmbeddableDocumentStore { ConnectionStringName = "Raven" };
			documentStore.Initialize();

			IndexCreation.CreateIndexes(Assembly.GetExecutingAssembly(), documentStore);

			return documentStore;
		}
	}
}