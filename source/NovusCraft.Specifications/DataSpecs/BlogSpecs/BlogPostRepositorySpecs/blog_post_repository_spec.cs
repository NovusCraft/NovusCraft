// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
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
				var documentStore = new EmbeddableDocumentStore { RunInMemory = true };
				documentStore.Initialize();

				using (var session = documentStore.OpenSession())
				{
					session.Store(new BlogPost
					              	{
					              		Title = "Blog Post #1",
					              		Slug = "blog-post-1",
					              		PublishedOn = new DateTimeOffset(2011, 11, 12, 13, 14, 15, TimeSpan.Zero)
					              	});

					session.Store(new BlogPost
					              	{
					              		Title = "Blog Post #2",
					              		Slug = "blog-post-2",
					              		PublishedOn = new DateTimeOffset(2011, 12, 13, 14, 15, 16, TimeSpan.Zero)
					              	});

					session.SaveChanges();
				}

				repository = new BlogPostRepository(documentStore.OpenSession());
			};
	}
}