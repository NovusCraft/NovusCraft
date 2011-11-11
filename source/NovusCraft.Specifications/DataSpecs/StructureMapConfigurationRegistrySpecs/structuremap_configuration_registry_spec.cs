// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using Machine.Specifications;
using NovusCraft.Data;
using StructureMap.Configuration.DSL;

namespace NovusCraft.Specifications.DataSpecs.StructureMapConfigurationRegistrySpecs
{
	public abstract class structuremap_configuration_registry_spec
	{
		protected static Registry registry;

		Establish context = () => { registry = new StructureMapConfigurationRegistry(); };
	}
}