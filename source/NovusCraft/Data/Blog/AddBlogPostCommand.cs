// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using NovusCraft.Web.ViewModels;

namespace NovusCraft.Data.Blog
{
	public sealed class AddBlogPostCommand : Command<CreateBlogPostModel>
	{
		public AddBlogPostCommand(CreateBlogPostModel model) : base(model)
		{
		}
	}
}