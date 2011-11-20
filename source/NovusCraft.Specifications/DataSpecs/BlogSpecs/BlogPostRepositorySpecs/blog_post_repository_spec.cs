// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using Machine.Specifications;
using NovusCraft.Data.Blog;
using Raven.Client.Embedded;

namespace NovusCraft.Specifications.DataSpecs.BlogSpecs.BlogPostRepositorySpecs
{
	public abstract class blog_post_repository_spec
	{
		protected static IBlogPostRepository repository;

		Establish context = () =>
			{
				var documentStore = new EmbeddableDocumentStore {RunInMemory = true};
				documentStore.Initialize();

				using (var session = documentStore.OpenSession())
				{
					var testBlogPost = new BlogPost
					                   	{
					                   		Title = "Test",
					                   		Slug = "test"
					                   	};
					session.Store(testBlogPost);
					session.SaveChanges();
				}

				repository = new BlogPostRepository(documentStore.OpenSession());
			};
	}
}