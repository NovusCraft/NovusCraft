// # Copyright © 2011, Novus Craft
// # All rights reserved. 

namespace NovusCraft.Data.Blog
{
	public sealed class DeleteBlogPostCommand : Command<int>
	{
		public DeleteBlogPostCommand(int model) : base(model)
		{
		}
	}
}