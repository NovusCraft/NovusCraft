// # Copyright © 2011, Novus Craft
// # All rights reserved. 

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
			() => container.GetInstance<IBlogPostRepository>().ShouldBeOfType<InMemoryBlogPostRepository>();
	}
}