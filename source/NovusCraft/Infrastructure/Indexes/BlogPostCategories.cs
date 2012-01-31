// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Linq;
using NovusCraft.Model;
using Raven.Client.Indexes;

namespace NovusCraft.Infrastructure.Indexes
{
	public sealed class BlogPostCategories : AbstractIndexCreationTask<BlogPost, BlogPostCategories.ReduceResult>
	{
		public BlogPostCategories()
		{
			Map = blogPosts => from blogPost in blogPosts
			                   select new { blogPost.Category };

			Reduce = results => from result in results
			                    group result by result.Category
			                    into grouping
			                    select new { Category = grouping.Key };
		}

		public static string Name
		{
			get { return "BlogPostCategories"; }
		}

		#region Nested type: ReduceResult

		public sealed class ReduceResult
		{
			public string Category { get; set; }
		}

		#endregion
	}
}