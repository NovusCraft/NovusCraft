// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using Machine.Specifications;
using NovusCraft.Infrastructure;
using NovusCraft.Infrastructure.Commands;
using NovusCraft.Security;
using NovusCraft.Specifications.SpecUtils;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Embedded;
using StructureMap;

namespace NovusCraft.Specifications.InfrastructureSpecs.StructureMapConfigurationRegistrySpecs
{
	[Subject(typeof(StructureMapConfigurationRegistry))]
	public class when_instantiated : structuremap_configuration_registry_spec
	{
		Because of = () => container = new Container(registry);

		// RavenDB
		It should_register_singleton_ravendb_document_store =
			() => container.ShouldContainSingletonPluginFor<IDocumentStore, EmbeddableDocumentStore>();

		It should_register_hybrid_ravendb_document_session =
			() => container.ShouldContainHybridPluginFor<IDocumentSession, DocumentSession>();

		// Blog
		It should_register_hybrid_add_blog_post_handler =
			() => container.ShouldContainHybridPluginFor<CommandHandler<CreateBlogPostCommand>, CreateBlogPostHandler>();

		It should_register_hybrid_update_blog_post_handler =
			() => container.ShouldContainHybridPluginFor<CommandHandler<UpdateBlogPostCommand>, UpdateBlogPostHandler>();

		It should_register_hybrid_delete_blog_post_handler =
			() => container.ShouldContainHybridPluginFor<CommandHandler<DeleteBlogPostCommand>, DeleteBlogPostHandler>();

		// Security
		It should_register_hybrid_forms_authentication_wrapper =
			() => container.ShouldContainHybridPluginFor<IFormsAuthenticationWrapper, FormsAuthenticationWrapper>();
	}
}