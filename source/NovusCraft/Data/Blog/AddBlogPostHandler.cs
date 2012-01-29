// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using Raven.Client;

namespace NovusCraft.Data.Blog
{
	public sealed class AddBlogPostHandler : CommandHandler<AddBlogPostCommand>
	{
		public AddBlogPostHandler(IDocumentSession session) : base(session)
		{
		}

		public override void Execute(AddBlogPostCommand command)
		{
			Session.Store(new BlogPost
			{
				Title = command.Model.Title,
				Slug = command.Model.Slug,
				Content = command.Model.Content,
				Category = command.Model.Category,
				PublishedOn = command.Model.PublishedOn
			});
		}
	}
}