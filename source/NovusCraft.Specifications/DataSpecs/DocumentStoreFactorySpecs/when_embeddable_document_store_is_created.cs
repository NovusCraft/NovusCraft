// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using Machine.Specifications;
using NovusCraft.Data;
using Raven.Client.Embedded;

namespace NovusCraft.Specifications.DataSpecs.DocumentStoreFactorySpecs
{
	[Subject(typeof(DocumentStoreFactory))]
	public class when_embeddable_document_store_is_created
	{
		static EmbeddableDocumentStore document_store;
		Because of = () => document_store = DocumentStoreFactory.CreateEmbeddableDocumentStore();

		Cleanup after = () => document_store.Dispose();

		It should_return_initialised_ravendb_document_store =
			() => document_store.DocumentDatabase.ShouldNotBeNull();

		It should_return_ravendb_document_store_connection_string_raven =
			() => document_store.ConnectionStringName.ShouldEqual("Raven");
	}
}