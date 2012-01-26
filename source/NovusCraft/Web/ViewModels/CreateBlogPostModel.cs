// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using System.ComponentModel.DataAnnotations;

namespace NovusCraft.Web.ViewModels
{
	public class CreateBlogPostModel
	{
		[Required]
		public string Title { get; set; }

		[Required]
		public string Slug { get; set; }

		[Required]
		public string Content { get; set; }

		[Required]
		[Display(Name = "Category")]
		public string CategoryTitle { get; set; }

		[Required]
		[Display(Name = "Publish date")]
		public DateTimeOffset PublishedOn { get; set; }
	}
}