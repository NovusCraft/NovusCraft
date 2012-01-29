// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using Machine.Specifications;
using NovusCraft.Web.Controllers;
using Raven.Client.Embedded;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.DashboardControllerSpecs
{
	public abstract class dashboard_controller_spec
	{
		protected static DashboardController controller;
		protected static EmbeddableDocumentStore document_store;

		Establish context = () =>
		{
			document_store = new EmbeddableDocumentStore { RunInMemory = true };
			document_store.Initialize();
			var session = document_store.OpenSession();

			controller = new DashboardController(session);
		};
	}
}