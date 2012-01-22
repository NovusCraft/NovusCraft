// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Linq;
using Machine.Specifications;
using NovusCraft.Data;
using NovusCraft.Security;
using Raven.Client;
using Raven.Client.Embedded;
using StructureMap;

namespace NovusCraft.Specifications.DataSpecs.StructureMapConfigurationRegistrySpecs
{
	[Subject(typeof(StructureMapConfigurationRegistry))]
	public class when_instantiated : structuremap_configuration_registry_spec
	{
		Because of = () => container = new Container(registry);

		// Raven DB
		It should_register_singleton_ravendb_document_store =
			() => container.Model.PluginTypes.Single(pt => pt.PluginType == typeof(IDocumentStore) && pt.Default.ConcreteType == typeof(EmbeddableDocumentStore)).Lifecycle.ShouldEqual(InstanceScope.Singleton.ToString());

		It should_register_hybrid_ravendb_document_session =
			() => container.Model.PluginTypes.Single(pt => pt.PluginType == typeof(IDocumentSession) && pt.Default.Description == "Instance is created by Func<object> function:  System.Func`2[StructureMap.IContext,Raven.Client.IDocumentSession]").Lifecycle.ShouldEqual(InstanceScope.Hybrid.ToString());

		// Security
		It should_register_hybrind_forms_authentication_wrapper =
			() => container.Model.PluginTypes.Single(pt => pt.PluginType == typeof(IFormsAuthenticationWrapper) && pt.Default.ConcreteType == typeof(FormsAuthenticationWrapper)).Lifecycle.ShouldEqual(InstanceScope.Hybrid.ToString());
	}
}