// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Linq;
using Raven.Client;

namespace NovusCraft.Data.Blog
{
	public sealed class BlogPostRepository : IBlogPostRepository
	{
		readonly IDocumentSession _documentSession;

		public BlogPostRepository(IDocumentSession documentSession)
		{
			_documentSession = documentSession;
		}

		#region IBlogPostRepository Members

		public void UpdateBlogPost(int id, string title, string content, string categoryTitle)
		{
			var blogPost = _documentSession.Query<BlogPost>().Single(bp => bp.Id == id);

			blogPost.Title = title;
			blogPost.Content = content;
			blogPost.Category.Title = categoryTitle;

			_documentSession.Store(blogPost);
		}

		#endregion
	}
}