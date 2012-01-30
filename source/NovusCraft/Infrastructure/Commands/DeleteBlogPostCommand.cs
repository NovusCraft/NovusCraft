// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Diagnostics;
using NovusCraft.Model;
using Raven.Client;

namespace NovusCraft.Infrastructure.Commands
{
	[DebuggerStepThrough]
	public sealed class DeleteBlogPostCommand : Command<int>
	{
		public DeleteBlogPostCommand(int model) : base(model)
		{
		}
	}

	public sealed class DeleteBlogPostHandler : CommandHandler<DeleteBlogPostCommand>
	{
		public DeleteBlogPostHandler(IDocumentSession session) : base(session)
		{
		}

		public override void Execute(DeleteBlogPostCommand command)
		{
			var blogPost = Session.Load<BlogPost>(command.Model);

			Session.Delete(blogPost);
		}
	}
}