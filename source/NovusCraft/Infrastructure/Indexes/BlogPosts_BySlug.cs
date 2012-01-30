// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Linq;
using NovusCraft.Model;
using Raven.Client.Indexes;

namespace NovusCraft.Infrastructure.Indexes
{
	public sealed class BlogPosts_BySlug : AbstractIndexCreationTask<BlogPost>
	{
		public BlogPosts_BySlug()
		{
			Map = blogPosts => from blogPost in blogPosts
			                   select new
			                   {
			                   	blogPost.Slug
			                   };
		}

		public static string Name
		{
			get { return "BlogPosts/BySlug"; }
		}
	}
}