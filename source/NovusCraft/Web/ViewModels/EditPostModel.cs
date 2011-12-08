// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;

namespace NovusCraft.Web.ViewModels
{
	public sealed class EditPostModel
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public string CategoryTitle { get; set; }
		public DateTimeOffset PublishedOn { get; set; }
	}
}