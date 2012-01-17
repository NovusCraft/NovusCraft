﻿// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Collections.Generic;

namespace NovusCraft.Data.Blog
{
	public interface IBlogPostRepository
	{
		IList<BlogPost> GetBlogPosts();
		IList<BlogPost> GetRecentBlogPosts();
		BlogPost GetBlogPost(int id);
		BlogPost GetBlogPost(string slug);
		void CreateBlogPost(string title, string content, string categoryTitle);
		void UpdateBlogPost(int id, string title, string content, string categoryTitle);
	}
}