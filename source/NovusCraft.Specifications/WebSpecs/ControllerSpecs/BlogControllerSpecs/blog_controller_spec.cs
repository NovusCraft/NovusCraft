// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using System.Web.Routing;
using Machine.Specifications;
using NovusCraft.Infrastructure;
using NovusCraft.Web.Controllers;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Embedded;
using Raven.Client.Indexes;
using StructureMap;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.BlogControllerSpecs
{
	public abstract class blog_controller_spec
	{
		protected static BlogController controller;
		protected static EmbeddableDocumentStore document_store;
		protected static IDocumentSession session;

		[CLSCompliant(false)]
		protected static IContainer container;

		Establish context = () =>
		{
			document_store = new EmbeddableDocumentStore { RunInMemory = true, Conventions = new DocumentConvention { DefaultQueryingConsistency = ConsistencyOptions.QueryYourWrites } };
			document_store.Initialize();
			session = document_store.OpenSession();

			IndexCreation.CreateIndexes(typeof(DocumentStoreFactory).Assembly, document_store);

			container = new Container();
			container.Configure(ce => ce.For<IDocumentSession>().Singleton().Use(document_store.OpenSession));
			var dispatcher = new CommandDispatcher(container);

			controller = new BlogController(session, dispatcher) { };
		};

		Cleanup after = () => RouteTable.Routes.Clear();
	}
}