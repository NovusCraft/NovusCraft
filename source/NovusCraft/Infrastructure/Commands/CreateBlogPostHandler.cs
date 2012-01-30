// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using AutoMapper;
using NovusCraft.Model;
using NovusCraft.Web.ViewModels;
using Raven.Client;

namespace NovusCraft.Infrastructure.Commands
{
	public sealed class CreateBlogPostHandler : CommandHandler<CreateBlogPostCommand>
	{
		public CreateBlogPostHandler(IDocumentSession session) : base(session)
		{
		}

		public override void Execute(CreateBlogPostCommand command)
		{
			var blogPost = Mapper.Map<CreateBlogPostModel, BlogPost>(command.Model);
			Session.Store(blogPost);
		}
	}
}