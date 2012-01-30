// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Linq;
using NovusCraft.Model;
using Raven.Client.Indexes;

namespace NovusCraft.Infrastructure.Indexes
{
	public sealed class BlogPosts_ByPublishDate : AbstractIndexCreationTask<BlogPost>
	{
		public BlogPosts_ByPublishDate()
		{
			Map = blogPosts => from blogPost in blogPosts
			                   select new
			                   {
			                   	blogPost.PublishedOn
			                   };
		}

		public static string Name
		{
			get { return "BlogPosts/ByPublishDate"; }
		}
	}
}