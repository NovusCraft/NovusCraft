// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;

namespace NovusCraft.Data.Blog
{
	public sealed class BlogPost
	{
		public string Title { get; set; }
		public string Content { get; set; }
		public BlogPostCategory Category { get; set; }
		public DateTimeOffset PublishedOn { get; set; }
	}
}