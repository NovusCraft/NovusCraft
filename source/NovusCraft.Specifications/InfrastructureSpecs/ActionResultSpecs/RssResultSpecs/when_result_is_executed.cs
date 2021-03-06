﻿// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using System;
using System.IO;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Mvc;
using Machine.Specifications;
using Moq;
using NovusCraft.Infrastructure.ActionResults;
using It = Machine.Specifications.It;

namespace NovusCraft.Specifications.InfrastructureSpecs.ActionResultSpecs.RssResultSpecs
{
	[Subject(typeof(RssResult))]
	public class when_result_is_executed
	{
		static RssResult rss_result;
		static Mock<HttpResponseBase> http_response;
		static StringWriter output_writer;

		Because of = () =>
		{
			http_response = new Mock<HttpResponseBase>();
			output_writer = new StringWriter();
			http_response.SetupGet(hr => hr.Output).Returns(output_writer);

			var controllerContext = new Mock<ControllerContext>();
			controllerContext.SetupGet(cc => cc.HttpContext.Response).Returns(http_response.Object);

			var feed = new SyndicationFeed();
			feed.Id = "novus_craft";
			feed.Title = new TextSyndicationContent("Novus Craft");
			feed.Authors.Add(new SyndicationPerson("arnold.zokas@novuscraft.com"));
			feed.Copyright = new TextSyndicationContent("Copyright © 2011 Novus Craft");
			feed.Language = "en-GB";
			feed.LastUpdatedTime = new DateTimeOffset(2011, 11, 12, 13, 14, 15, TimeSpan.Zero);

			rss_result = new RssResult(feed);
			rss_result.ExecuteResult(controllerContext.Object);
		};

		It should_set_content_type =
			() => http_response.VerifySet(hr => hr.ContentType = "application/rss+xml");

		It should_set_feed_id =
			() => output_writer.ToString().ShouldContain("<a10:id>novus_craft</a10:id>");

		It should_set_feed_title =
			() => output_writer.ToString().ShouldContain("<title>Novus Craft</title>");

		It should_set_feed_author_email_address =
			() => output_writer.ToString().ShouldContain("<managingEditor>arnold.zokas@novuscraft.com</managingEditor>");

		It should_set_feed_copyright =
			() => output_writer.ToString().ShouldContain("<copyright>Copyright © 2011 Novus Craft</copyright>");

		It should_set_feed_language =
			() => output_writer.ToString().ShouldContain("<language>en-GB</language>");

		It should_set_feed_last_updated_time =
			() => output_writer.ToString().ShouldContain("<lastBuildDate>Sat, 12 Nov 2011 13:14:15 Z</lastBuildDate>");
	}
} ;