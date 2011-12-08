// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using System.Web;

namespace NovusCraft.Web.ViewModels
{
	public sealed class ViewPostModel
	{
		public string Title { get; set; }
		public IHtmlString Content { get; set; }
		public string Permalink { get; set; }
		public string CategoryTitle { get; set; }
		public DateTimeOffset PublishedOn { get; set; }
		public string DisqusId { get; set; }
	}
}