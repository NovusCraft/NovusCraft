// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using System.Web.Mvc;
using Machine.Specifications;
using NovusCraft.Infrastructure;
using NovusCraft.Specifications.SpecUtils;
using Raven.Client;
using StructureMap;

namespace NovusCraft.Specifications.InfrastructureSpecs.StructureMapControllerFactorySpecs
{
	[Subject(typeof(StructureMapControllerFactory))]
	public class when_controller_instance_is_requested : structure_map_controller_factory_spec
	{
		static IController controller;

		Because of = () =>
		{
			ObjectFactory.Container.Configure(c => c.For<IDocumentStore>().Use(Spec.RequiresRavenDBDocumentStore));

			controller = factory.GetControllerInstance(typeof(TestController));
		};

		It should_return_controller_instance =
			() => controller.ShouldBeOfType<TestController>();

		#region Nested type: TestController

		internal class TestController : Controller
		{
		}

		#endregion
	}
}