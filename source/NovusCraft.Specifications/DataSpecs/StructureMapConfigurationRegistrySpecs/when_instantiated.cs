// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Linq;
using Machine.Specifications;
using NovusCraft.Data;
using NovusCraft.Data.Blog;
using StructureMap;

namespace NovusCraft.Specifications.DataSpecs.StructureMapConfigurationRegistrySpecs
{
	[Subject(typeof(StructureMapConfigurationRegistry))]
	public class when_instantiated : structuremap_configuration_registry_spec
	{
		static Container container;
		Because of = () => container = new Container(registry);

		It should_register_blog_category_repository =
			() => container.Model.PluginTypes.Any(pt => pt.PluginType == typeof(IBlogPostRepository) && pt.Default.ConcreteType == typeof(BlogPostRepository)).ShouldBeTrue();

		It should_set_blog_category_repository_lifecycle_as_hybrid =
			() => container.Model.PluginTypes.Single(pt => pt.PluginType == typeof(IBlogPostRepository) && pt.Default.ConcreteType == typeof(BlogPostRepository)).Lifecycle.ShouldEqual("Hybrid");
	}
}