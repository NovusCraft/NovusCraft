// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Linq;
using NovusCraft.Model;
using Raven.Client;

namespace NovusCraft.Infrastructure.Commands
{
	public sealed class DeleteBlogPostHandler : CommandHandler<DeleteBlogPostCommand>
	{
		public DeleteBlogPostHandler(IDocumentSession session) : base(session)
		{
		}

		public override void Execute(DeleteBlogPostCommand command)
		{
			var blogPost = Session.Query<BlogPost>().Single(bp => bp.Id == command.Model);

			Session.Delete(blogPost);
		}
	}
}