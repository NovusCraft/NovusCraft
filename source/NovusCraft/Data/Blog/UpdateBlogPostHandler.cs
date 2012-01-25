// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using System.Linq;
using Raven.Client;

namespace NovusCraft.Data.Blog
{
	public sealed class UpdateBlogPostHandler : CommandHandler<UpdateBlogPostCommand>
	{
		public UpdateBlogPostHandler(IDocumentSession session) : base(session)
		{
		}

		public override void Execute(UpdateBlogPostCommand command)
		{
			var blogPost = Session.Query<BlogPost>().Single(bp => bp.Id == command.Model.Id);

			blogPost.Title = command.Model.Title;
			blogPost.Slug = command.Model.Slug;
			blogPost.Content = command.Model.Content;
			blogPost.Category.Title = command.Model.CategoryTitle;
			blogPost.PublishedOn = DateTimeOffset.Now;

			Session.Store(blogPost);
		}
	}
}