// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using Machine.Specifications;
using NovusCraft.Data.Blog;
using Raven.Client;
using Raven.Client.Embedded;

namespace NovusCraft.Specifications.DataSpecs.BlogSpecs.BlogPostRepositorySpecs
{
	public abstract class blog_post_repository_spec
	{
		protected static BlogPostRepository repository;
		protected static EmbeddableDocumentStore document_store;
		protected static IDocumentSession document_session;

		Establish context = () =>
			{
				document_store = new EmbeddableDocumentStore { RunInMemory = true };
				document_store.Initialize();

				using (var session = document_store.OpenSession())
				{
					session.Store(new BlogPost
					              	{
					              		Title = "Blog Post #1",
					              		Slug = "blog-post-1",
					              		Category = new BlogPostCategory { Title = "Category 1" },
					              		PublishedOn = new DateTimeOffset(2011, 11, 12, 13, 14, 15, TimeSpan.Zero)
					              	});

					session.Store(new BlogPost
					              	{
					              		Title = "Blog Post #2",
					              		Slug = "blog-post-2",
					              		Category = new BlogPostCategory { Title = "Category 2" },
					              		PublishedOn = new DateTimeOffset(2011, 12, 13, 14, 15, 16, TimeSpan.Zero)
					              	});

					session.SaveChanges();
				}

				document_session = document_store.OpenSession();
				repository = new BlogPostRepository(document_session);
			};
	}
}