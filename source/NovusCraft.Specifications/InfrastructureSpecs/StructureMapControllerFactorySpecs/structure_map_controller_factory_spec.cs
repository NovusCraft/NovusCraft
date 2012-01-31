// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using System.Web.Mvc;
using Machine.Specifications;
using NovusCraft.Infrastructure;

namespace NovusCraft.Specifications.InfrastructureSpecs.StructureMapControllerFactorySpecs
{
	public abstract class structure_map_controller_factory_spec
	{
		protected static StructureMapControllerFactoryProxy factory;

		Establish context = () => factory = new StructureMapControllerFactoryProxy();

		#region Nested type: StructureMapControllerFactoryProxy

		protected class StructureMapControllerFactoryProxy : StructureMapControllerFactory
		{
			public IController GetControllerInstance(Type controllerType)
			{
				return base.GetControllerInstance(null, controllerType);
			}
		}

		#endregion
	}
}