// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Web.Mvc;
using Machine.Specifications;
using NovusCraft.Web;
using Raven.Client;
using Raven.Client.Embedded;
using StructureMap;

namespace NovusCraft.Specifications.WebSpecs.StructureMapControllerFactorySpecs
{
	[Subject(typeof(MvcApplication))]
	public class when_controller_instance_is_released : structure_map_controller_factory_spec
	{
		Because of = () =>
			{
				ObjectFactory.Container.Configure(c =>
					{
						c.For<IDocumentSession>().Singleton().Use(() =>
							{
								var document_store = new EmbeddableDocumentStore { RunInMemory = true };
								document_store.Initialize();
								var session = document_store.OpenSession();

								session.Store(new { });

								return session;
							});
					});

				factory.ReleaseController(null);
			};

		It should_commit_changes_in_ravendb_session =
			() => ObjectFactory.Container.GetInstance<IDocumentSession>().Advanced.HasChanges.ShouldBeFalse();

		#region Nested type: TestController

		internal class TestController : Controller
		{
		}

		#endregion
	}
}