// # Copyright © 2011, Novus Craft
// # All rights reserved. 

namespace NovusCraft.Data.Blog
{
	public interface IBlogPostRepository
	{
		void CreateBlogPost(string title, string content, string categoryTitle);
		void UpdateBlogPost(int id, string title, string content, string categoryTitle);
	}
}