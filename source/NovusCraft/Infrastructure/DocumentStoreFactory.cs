// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Reflection;
using Raven.Client.Embedded;
using Raven.Client.Indexes;

namespace NovusCraft.Infrastructure
{
	public static class DocumentStoreFactory
	{
		const string ConnectionStringName = "Raven";

		public static EmbeddableDocumentStore CreateEmbeddableDocumentStore()
		{
			var documentStore = new EmbeddableDocumentStore { ConnectionStringName = ConnectionStringName };
			documentStore.Initialize();

			IndexCreation.CreateIndexes(Assembly.GetExecutingAssembly(), documentStore);

			return documentStore;
		}
	}
}