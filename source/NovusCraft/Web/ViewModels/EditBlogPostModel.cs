﻿// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;

namespace NovusCraft.Web.ViewModels
{
	public sealed class EditBlogPostModel
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Slug { get; set; }
		public string Content { get; set; }
		public string CategoryTitle { get; set; }
		public DateTimeOffset PublishedOn { get; set; }
	}
}