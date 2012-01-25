// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;

namespace NovusCraft.Web.ViewModels
{
	public class EditBlogPostModel : CreateBlogPostModel
	{
		public int Id { get; set; }
		public DateTimeOffset PublishedOn { get; set; }
	}
}