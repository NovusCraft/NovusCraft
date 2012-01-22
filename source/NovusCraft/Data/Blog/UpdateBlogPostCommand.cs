// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using NovusCraft.Web.ViewModels;

namespace NovusCraft.Data.Blog
{
	public sealed class UpdateBlogPostCommand : Command<EditBlogPostModel>
	{
		public UpdateBlogPostCommand(EditBlogPostModel model) : base(model)
		{
		}
	}
}