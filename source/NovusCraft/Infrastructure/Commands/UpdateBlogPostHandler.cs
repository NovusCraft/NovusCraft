// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using AutoMapper;
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

			Mapper.Map(command.Model, blogPost);
			Session.Store(blogPost);
		}
	}
}