// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Collections.Generic;
using System.Linq;
using Raven.Client;
using Raven.Client.Linq;

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

		public IList<BlogPost> GetBlogPosts()
		{
			return _documentSession.Query<BlogPost>().ToList();
		}

		public IList<BlogPost> GetRecentBlogPosts()
		{
			return _documentSession.Query<BlogPost>().OrderByDescending(bp => bp.PublishedOn).ToList();
		}

		public BlogPost GetBlogPost(int id)
		{
			return _documentSession.Query<BlogPost>().SingleOrDefault(bp => bp.Id == id);
		}

		public BlogPost GetBlogPost(string slug)
		{
			return _documentSession.Query<BlogPost>().SingleOrDefault(bp => bp.Slug == slug);
		}

		public void CreateBlogPost(string title, string content, string categoryTitle)
		{
			var blogPost = new BlogPost
			               	{
			               		Title = title,
			               		Content = content,
			               		Category = new BlogPostCategory
			               		           	{
			               		           		Title = categoryTitle
			               		           	}
			               	};

			_documentSession.Store(blogPost);
		}

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