// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using System.Web.Routing;
using Machine.Specifications;
using NovusCraft.Data;
using NovusCraft.Web.Controllers;
using Raven.Client;
using Raven.Client.Embedded;
using StructureMap;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.BlogControllerSpecs
{
	public abstract class blog_controller_spec
	{
		protected static BlogController controller;
		protected static IDocumentStore document_store;

		[CLSCompliant(false)]
		protected static IContainer container;

		Establish context = () =>
			{
				document_store = new EmbeddableDocumentStore { RunInMemory = true };
				document_store.Initialize();

				container = new Container();
				container.Configure(ce => ce.For<IDocumentStore>().Use(document_store));
				var dispatcher = new CommandDispatcher(container);

				var session = document_store.OpenSession();

				controller = new BlogController(session, dispatcher) { };
			};

		Cleanup after = () => RouteTable.Routes.Clear();
	}
}