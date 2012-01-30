// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using Machine.Specifications;
using NovusCraft.Infrastructure;
using NovusCraft.Web.Controllers;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Embedded;
using Raven.Client.Indexes;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.DashboardControllerSpecs
{
	public abstract class dashboard_controller_spec
	{
		protected static DashboardController controller;
		protected static EmbeddableDocumentStore document_store;
		protected static IDocumentSession session;

		Establish context = () =>
		{
			document_store = new EmbeddableDocumentStore { RunInMemory = true, Conventions = new DocumentConvention { DefaultQueryingConsistency = ConsistencyOptions.QueryYourWrites } };
			document_store.Initialize();
			session = document_store.OpenSession();

			IndexCreation.CreateIndexes(typeof(DocumentStoreFactory).Assembly, document_store);

			controller = new DashboardController(session);
		};
	}
}