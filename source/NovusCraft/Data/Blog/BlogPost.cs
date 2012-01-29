// # Copyright � 2011, Novus Craft
// # All rights reserved. 

using System;

namespace NovusCraft.Data.Blog
{
	public sealed class BlogPost
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Slug { get; set; }
		public string Content { get; set; }
		public string Category { get; set; }
		public DateTimeOffset PublishedOn { get; set; }
	}
}