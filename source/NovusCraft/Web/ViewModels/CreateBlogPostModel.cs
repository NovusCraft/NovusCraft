// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.ComponentModel.DataAnnotations;

namespace NovusCraft.Web.ViewModels
{
	public sealed class CreateBlogPostModel
	{
		[Required]
		public string Title { get; set; }

		[Required]
		public string Slug { get; set; }

		[Required]
		public string Content { get; set; }

		[Required]
		[Display(Name = "Category title")]
		public string CategoryTitle { get; set; }
	}
}