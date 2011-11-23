// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using Machine.Specifications;
using NovusCraft.Data;
using Raven.Client;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace NovusCraft.Specifications.DataSpecs.StructureMapConfigurationRegistrySpecs
{
	public abstract class structuremap_configuration_registry_spec
	{
		[CLSCompliant(false)]
		protected static Registry registry;

		protected static Container container;

		Establish context = () => { registry = new StructureMapConfigurationRegistry(); };

		Cleanup after = () => container.GetInstance<IDocumentStore>().Dispose();
	}
}