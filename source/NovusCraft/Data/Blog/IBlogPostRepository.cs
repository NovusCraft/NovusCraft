// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Collections.Generic;

namespace NovusCraft.Data.Blog
{
	public interface IBlogPostRepository
	{
		BlogPost GetBlogPost(string slug);
		IList<BlogPost> GetRecentBlogPosts();
	}
}