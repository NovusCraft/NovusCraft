// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace NovusCraft.Web.ViewModels
{
	public class CreateBlogPostModel
	{
		[Required]
		public string Title { get; set; }

		[Required]
		public string Slug { get; set; }

		[Required, AllowHtml]
		public string Content { get; set; }

		[Required, Display(Name = "Category")]
		public string CategoryTitle { get; set; }

		[Required, Display(Name = "Publish date")]
		public DateTimeOffset PublishedOn { get; set; }
	}
}