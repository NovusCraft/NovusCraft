// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Diagnostics;
using NovusCraft.Web.ViewModels;

namespace NovusCraft.Infrastructure.Commands
{
	[DebuggerStepThrough]
	public sealed class AddBlogPostCommand : Command<CreateBlogPostModel>
	{
		public AddBlogPostCommand(CreateBlogPostModel model) : base(model)
		{
		}
	}
}