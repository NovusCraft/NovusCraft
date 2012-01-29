// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Linq;
using System.Web.Mvc;
using Machine.Specifications;
using NovusCraft.Web;
using Raven.Client;
using Raven.Client.Embedded;
using StructureMap;

namespace NovusCraft.Specifications.WebSpecs.StructureMapControllerFactorySpecs
{
	[Subject(typeof(StructureMapControllerFactory))]
	public class when_controller_instance_is_requested : structure_map_controller_factory_spec
	{
		static IController controller;

		Because of = () =>
		{
			ObjectFactory.Container.Configure(c => c.For<IDocumentStore>().Use(() =>
			{
				var documentStore = new EmbeddableDocumentStore { RunInMemory = true };
				documentStore.Initialize();
				return documentStore;
			}));

			controller = factory.GetControllerInstance(typeof(TestController));
		};

		It should_return_controller_instance =
			() => controller.ShouldBeOfType<TestController>();

		It should_register_hybrin_forms_authentication_wrapper =
			() => ObjectFactory.Container.Model.PluginTypes.Single(pt => pt.PluginType == typeof(IDocumentSession)).Lifecycle.ShouldEqual(InstanceScope.Hybrid.ToString());

		#region Nested type: TestController

		internal class TestController : Controller
		{
		}

		#endregion
	}
}