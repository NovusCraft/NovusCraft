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

		public BlogPost GetBlogPost(string slug)
		{
			return _documentSession.Query<BlogPost>().Where(bp => bp.Slug == slug).SingleOrDefault();
		}

		public IList<BlogPost> GetRecentBlogPosts()
		{
			return _documentSession.Query<BlogPost>().OrderByDescending(bp => bp.PublishedOn).ToList();
		}

		#endregion
	}
}