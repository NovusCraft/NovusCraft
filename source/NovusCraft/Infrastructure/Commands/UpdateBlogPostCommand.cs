// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using System.Diagnostics;
using AutoMapper;
using NovusCraft.Model;
using NovusCraft.Web.ViewModels;
using Raven.Client;

namespace NovusCraft.Infrastructure.Commands
{
	[DebuggerStepThrough]
	public sealed class UpdateBlogPostCommand : Command<UpdateBlogPostModel>
	{
		public UpdateBlogPostCommand(UpdateBlogPostModel model) : base(model)
		{
		}
	}

	public sealed class UpdateBlogPostHandler : CommandHandler<UpdateBlogPostCommand>
	{
		public UpdateBlogPostHandler(IDocumentSession session) : base(session)
		{
		}

		public override void Execute(UpdateBlogPostCommand command)
		{
			var blogPost = Session.Load<BlogPost>(command.Model.Id);

			Mapper.Map(command.Model, blogPost);
			Session.Store(blogPost);
		}
	}
}