﻿// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Linq;
using Machine.Specifications;
using NovusCraft.Data;
using NovusCraft.Data.Blog;
using Raven.Client;
using StructureMap;

namespace NovusCraft.Specifications.DataSpecs.StructureMapConfigurationRegistrySpecs
{
	[Subject(typeof(StructureMapConfigurationRegistry))]
	public class when_instantiated : structuremap_configuration_registry_spec
	{
		static Container container;
		Because of = () => container = new Container(registry);

		It should_register_blog_category_repository =
			() => container.Model.PluginTypes.Single(pt => pt.PluginType == typeof(IBlogPostRepository) && pt.Default.ConcreteType == typeof(BlogPostRepository));

		It should_set_blog_category_repository_lifecycle_as_hybrid =
			() => container.Model.PluginTypes.Single(pt => pt.PluginType == typeof(IBlogPostRepository) && pt.Default.ConcreteType == typeof(BlogPostRepository)).Lifecycle.ShouldEqual(InstanceScope.Hybrid.ToString());

		It should_register_ravendb_document_store =
			() => container.Model.PluginTypes.Single(pt => pt.PluginType == typeof(IDocumentSession) && pt.Default.Description == "Instance is created by Func<object> function:  System.Func`2[StructureMap.IContext,Raven.Client.IDocumentSession]");

		It should_set_ravendb_document_store_lifecycle_as_singleton =
			() => container.Model.PluginTypes.Single(pt => pt.PluginType == typeof(IDocumentSession) && pt.Default.Description == "Instance is created by Func<object> function:  System.Func`2[StructureMap.IContext,Raven.Client.IDocumentSession]").Lifecycle.ShouldEqual(InstanceScope.Hybrid.ToString());
	}
}