﻿// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using Raven.Client.Embedded;

namespace NovusCraft.Data
{
	public static class DocumentStoreFactory
	{
		const string ConnectionStringName = "Raven";

		public static EmbeddableDocumentStore CreateEmbeddableDocumentStore()
		{
			var documentStore = new EmbeddableDocumentStore { ConnectionStringName = ConnectionStringName };
			documentStore.Initialize();

			return documentStore;
		}
	}
}