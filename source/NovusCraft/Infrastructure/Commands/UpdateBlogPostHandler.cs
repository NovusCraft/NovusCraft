// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using NovusCraft.Model;
using Raven.Client;

namespace NovusCraft.Infrastructure.Commands
{
	public sealed class UpdateBlogPostHandler : CommandHandler<UpdateBlogPostCommand>
	{
		public UpdateBlogPostHandler(IDocumentSession session) : base(session)
		{
		}

		public override void Execute(UpdateBlogPostCommand command)
		{
			var blogPost = Session.Load<BlogPost>(command.Model.Id);

			blogPost.Title = command.Model.Title;
			blogPost.Slug = command.Model.Slug;
			blogPost.Content = command.Model.Content;
			blogPost.Category = command.Model.Category;
			blogPost.PublishedOn = command.Model.PublishedOn;

			Session.Store(blogPost);
		}
	}
}