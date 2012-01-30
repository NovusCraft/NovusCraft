// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web.Mvc;
using Machine.Specifications;
using NovusCraft.Infrastructure.ActionResults;
using NovusCraft.Model;
using NovusCraft.Web.Controllers;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.HomeControllerSpecs
{
	[Subject(typeof(HomeController))]
	public class when_feed_is_requested : home_controller_spec
	{
		static ActionResult result;

		Because of = () =>
		{
			session.Store(new BlogPost
			{
				Id = 1,
				Title = "Test Title 1",
				Slug = "test-title-1",
				Content = "Test Content 1",
				Category = "Category A",
				PublishedOn = new DateTimeOffset(2011, 11, 12, 13, 14, 15, TimeSpan.Zero)
			});
			session.Store(new BlogPost
			{
				Id = 2,
				Title = "Test Title 2",
				Slug = "test-title-2",
				Content = "Test Content 2",
				Category = "Category B",
				PublishedOn = new DateTimeOffset(2011, 12, 13, 14, 15, 16, TimeSpan.Zero)
			});
			session.SaveChanges();

			http_request.SetupGet(hr => hr.Url).Returns(new Uri("http://novuscraft.com/"));

			result = controller.Feed();
		};

		It should_return_rss_feed =
			() => result.ShouldBeOfType<RssResult>();

		It should_set_feed_id =
			() => ((RssResult)result).Feed.Id.ShouldEqual("novus_craft");

		It should_set_feed_title =
			() => ((RssResult)result).Feed.Title.Text.ShouldEqual("Novus Craft");

		It should_set_feed_author_email_address =
			() => ((RssResult)result).Feed.Authors.First().Email.ShouldEqual("arnold.zokas@novuscraft.com");

		It should_set_feed_copyright =
			() => ((RssResult)result).Feed.Copyright.Text.ShouldEqual("Copyright © 2011 Novus Craft");

		It should_set_feed_language =
			() => ((RssResult)result).Feed.Language.ShouldEqual("en-GB");

		It should_set_feed_last_updated_time =
			() => ((RssResult)result).Feed.LastUpdatedTime.ShouldEqual(((RssResult)result).Feed.Items.Max(item => item.LastUpdatedTime));

		It should_set_feed_contains_at_least_one_item =
			() => ((RssResult)result).Feed.Items.Count().ShouldBeGreaterThan(0);

		It should_set_feed_item_id =
			() => ((RssResult)result).Feed.Items.First().Id.ShouldEqual("http://novuscraft.com/blog/test-title-2");

		It should_set_feed_item_title =
			() => ((RssResult)result).Feed.Items.First().Title.Text.ShouldEqual("Test Title 2");

		It should_set_feed_item_category =
			() => ((RssResult)result).Feed.Items.First().Categories.First().Name.ShouldEqual("Category B");

		It should_set_feed_item_content =
			() => ((TextSyndicationContent)((RssResult)result).Feed.Items.First().Content).Text.ShouldEqual("Test Content 2");

		It should_set_feed_item_content_type_to_html =
			() => ((RssResult)result).Feed.Items.First().Content.Type.ShouldEqual("html");

		It should_set_feed_item_last_updated_time =
			() => ((RssResult)result).Feed.Items.First().LastUpdatedTime.ShouldEqual(new DateTimeOffset(2011, 12, 13, 14, 15, 16, TimeSpan.Zero));

		It should_set_feed_item_last_publish_date =
			() => ((RssResult)result).Feed.Items.First().LastUpdatedTime.ShouldEqual(new DateTimeOffset(2011, 12, 13, 14, 15, 16, TimeSpan.Zero));

		It should_set_feed_item_permalink =
			() => ((RssResult)result).Feed.Items.First().Links.Single(l => l.RelationshipType == "alternate").Uri.ShouldEqual(new Uri("http://novuscraft.com/blog/test-title-2"));
	}
}