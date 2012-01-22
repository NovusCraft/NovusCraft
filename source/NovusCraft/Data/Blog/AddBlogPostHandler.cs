﻿// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using Raven.Client;

namespace NovusCraft.Data.Blog
{
	public sealed class AddBlogPostHandler : CommandHandler<AddBlogPostCommand>
	{
		public AddBlogPostHandler(IDocumentStore documentStore) : base(documentStore)
		{
		}

		public override void Execute(AddBlogPostCommand command)
		{
			using (var session = DocumentStore.OpenSession())
			{
				session.Store(new BlogPost
				              	{
				              		Title = command.Model.Title,
				              		Slug = command.Model.Slug,
				              		Content = command.Model.Content,
				              		Category = new BlogPostCategory { Title = command.Model.CategoryTitle },
				              		PublishedOn = DateTimeOffset.Now
				              	});

				session.SaveChanges();
			}
		}
	}
}