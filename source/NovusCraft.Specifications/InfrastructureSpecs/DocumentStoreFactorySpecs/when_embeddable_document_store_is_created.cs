// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using Machine.Specifications;
using NovusCraft.Infrastructure;
using Raven.Client.Embedded;

namespace NovusCraft.Specifications.InfrastructureSpecs.DocumentStoreFactorySpecs
{
	[Subject(typeof(DocumentStoreFactory))]
	public class when_embeddable_document_store_is_created
	{
		static EmbeddableDocumentStore document_store;

		Because of = () =>
		{
			using (var documentStore = new EmbeddableDocumentStore { ConnectionStringName = "Raven" })
			{
				documentStore.Initialize();

				// remove any existing indexes
				foreach (var indexStat in documentStore.DocumentDatabase.Statistics.Indexes)
					documentStore.DocumentDatabase.DeleteIndex(indexStat.Name);
			}

			document_store = DocumentStoreFactory.CreateEmbeddableDocumentStore();
		};

		Cleanup after = () => document_store.Dispose();

		It should_return_initialised_ravendb_document_store =
			() => document_store.DocumentDatabase.ShouldNotBeNull();

		It should_set_connection_string_to_raven =
			() => document_store.ConnectionStringName.ShouldEqual("Raven");

		It should_create_static_indexes =
			() => document_store.DocumentDatabase.Statistics.CountOfIndexes.ShouldBeGreaterThan(0);
	}
}