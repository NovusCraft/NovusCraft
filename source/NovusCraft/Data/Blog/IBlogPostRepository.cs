// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Collections.Generic;

namespace NovusCraft.Data.Blog
{
	public interface IBlogPostRepository
	{
		IList<BlogPost> GetRecentBlogPosts();
		BlogPost GetBlogPost(string slug);
		void UpdateBlogPost(string id, string title, string content, string categoryTitle);
	}
}