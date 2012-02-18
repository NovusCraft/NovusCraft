// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using System;
using Machine.Specifications;
using NovusCraft.Infrastructure;
using Raven.Client;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace NovusCraft.Specifications.InfrastructureSpecs.StructureMapConfigurationRegistrySpecs
{
	public abstract class structuremap_configuration_registry_spec
	{
		[CLSCompliant(false)]
		protected static Registry registry;

		[CLSCompliant(false)]
		protected static Container container;

		Establish context = () => { registry = new StructureMapConfigurationRegistry(); };

		Cleanup after = () => container.GetInstance<IDocumentStore>().Dispose();
	}
}