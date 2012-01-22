// # Copyright © 2011, Novus Craft
// # All rights reserved. 

namespace NovusCraft.Web.ViewModels
{
	public sealed class CreateBlogPostModel
	{
		public string Title { get; set; }
		public string Slug { get; set; }
		public string Content { get; set; }
		public string CategoryTitle { get; set; }
	}
}