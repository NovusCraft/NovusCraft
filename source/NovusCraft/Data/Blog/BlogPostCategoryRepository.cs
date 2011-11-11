// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;

namespace NovusCraft.Data.Blog
{
	public sealed class BlogPostCategoryRepository : IBlogCategoryRepository
	{
		#region IBlogCategoryRepository Members

		public BlogPost GetBlogPost(string slug)
		{
			return new BlogPost
			       	{
			       		Title = "Welcome to my blog",
			       		Content = "<p>I have been wanting to set one up for a while, but for various reasons kept postponing.</p>" +
			       		          "<p>One of the things that prompted me to start a blog is my desire to learn ASP.NET MVC. I could not think of a better way to learn than building a blogging engine.</p><p>My other reason for starting a blog is I <del>want</del> need a place where I can share my discoveries and ideas. It bugs me that every time I have solved a rare challenge (rare in a sense that Google had no answer to it) I have not shared the solution.</p>" +
			       		          "<p>Currently, the blog engine is just a skeleton implementation constructed with ASP.NET MVC 3 (C# 4 + Razor views) and HTML5 + CSS3 + jQuery. Source code is available publicly on <a href=\"https://github.com/NovusCraft/NovusCraft\" title=\"novuscraft.com public Git repository\">Github</a>.</p>" +
			       		          "<p>I have lots of things on my <a href=\"https://github.com/NovusCraft/NovusCraft/issues?sort=created&direction=desc&state=open&page=1&milestone=2\" title=\"Open issues in Github backlog\">backlog</a> (<a href=\"http://ravendb.net/\" title=\"RavenDB - an Open Source document database for the .NET/Windows platform\">RavenDB</a>, <a href=\"https://github.com/jetheredge/SquishIt\" title=\"SquishIt lets you squish some JavaScript and CSS\">SquishIt</a>, and more), so this should keep me busy for a while.</p>",
			       		Category = new BlogPostCategory
			       		           	{
			       		           		Title = "Meta"
			       		           	},
			       		PublishedOn = new DateTimeOffset(2011, 10, 23, 23, 35, 00, TimeSpan.Zero)
			       	};
		}

		#endregion
	}
}