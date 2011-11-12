// # Copyright © 2011, Novus Craft
// # All rights reserved. 

namespace NovusCraft.Data.Blog
{
	public interface IBlogPostRepository
	{
		BlogPost GetBlogPost(string slug);
	}
}