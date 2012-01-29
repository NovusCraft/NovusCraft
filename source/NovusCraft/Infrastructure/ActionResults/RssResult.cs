// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace NovusCraft.Infrastructure.ActionResults
{
	public sealed class RssResult : FileResult
	{
		public RssResult(SyndicationFeed feed) : base("application/rss+xml")
		{
			Feed = feed;
		}

		public SyndicationFeed Feed { get; private set; }

		protected override void WriteFile(HttpResponseBase response)
		{
			var rssFormatter = new Rss20FeedFormatter(Feed);

			using (var writer = XmlWriter.Create(response.Output))
				rssFormatter.WriteTo(writer);

			response.End();
		}
	}
}