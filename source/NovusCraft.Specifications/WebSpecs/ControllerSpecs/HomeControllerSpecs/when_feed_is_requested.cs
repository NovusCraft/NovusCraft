// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web.Mvc;
using Machine.Specifications;
using NovusCraft.Data.Blog;
using NovusCraft.Web.ActionResults;
using NovusCraft.Web.Controllers;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.HomeControllerSpecs
{
	[Subject(typeof(HomeController))]
	public class when_feed_is_requested : home_controller_spec
	{
		static ActionResult result;

		Because of = () =>
			{
				using (var session = document_store.OpenSession())
				{
					session.Store(new BlogPost
					              	{
					              		Id = 1,
					              		Title = "Blog Post #1",
					              		Slug = "blog-post-1",
					              		Content = "Content #1",
					              		Category = new BlogPostCategory { Title = "Category A" },
					              		PublishedOn = new DateTimeOffset(2011, 11, 12, 13, 14, 15, TimeSpan.Zero)
					              	});
					session.Store(new BlogPost
					              	{
					              		Id = 2,
					              		Title = "Blog Post #1",
					              		Slug = "blog-post-2",
					              		Content = "Content #2",
					              		Category = new BlogPostCategory { Title = "Category B" },
					              		PublishedOn = new DateTimeOffset(2011, 12, 13, 14, 15, 16, TimeSpan.Zero)
					              	});

					session.SaveChanges();
				}

				http_request.SetupGet(hr => hr.Url).Returns(new Uri("http://novuscraft.com/"));

				result = controller.Feed();
			};

		It should_return_rss_feed =
			() => result.ShouldBeOfType<RssResult>();

		It should_set_feed_id_to_novus_craft =
			() => ((RssResult)result).Feed.Id.ShouldEqual("novus_craft");

		It should_set_feed_title_to_novus_craft =
			() => ((RssResult)result).Feed.Title.Text.ShouldEqual("Novus Craft");

		It should_set_feed_author_email_address_to_arnold_zokas_at_novuscraft_com =
			() => ((RssResult)result).Feed.Authors.First().Email.ShouldEqual("arnold.zokas@novuscraft.com");

		It should_set_feed_copyright_to_novus_craft =
			() => ((RssResult)result).Feed.Copyright.Text.ShouldEqual("Copyright © 2011 Novus Craft");

		It should_set_feed_language_to_en_gb =
			() => ((RssResult)result).Feed.Language.ShouldEqual("en-GB");

		It should_set_feed_last_updated_time_to_last_updated_date_of_most_recent_feed_item =
			() => ((RssResult)result).Feed.LastUpdatedTime.ShouldEqual(((RssResult)result).Feed.Items.Max(item => item.LastUpdatedTime));

		It should_set_feed_contains_at_least_one_item =
			() => ((RssResult)result).Feed.Items.Count().ShouldBeGreaterThan(0);

		It should_set_feed_item_id =
			() => ((RssResult)result).Feed.Items.First().Id.ShouldEqual("http://novuscraft.com/blog/blog-post-2");

		It should_set_feed_item_title =
			() => ((RssResult)result).Feed.Items.First().Title.Text.ShouldEqual("Blog Post #1");

		It should_set_feed_item_category =
			() => ((RssResult)result).Feed.Items.First().Categories.First().Name.ShouldEqual("Category B");

		It should_set_feed_item_content =
			() => ((TextSyndicationContent)((RssResult)result).Feed.Items.First().Content).Text.ShouldEqual("Content #2");

		It should_set_feed_item_content_type_to_html =
			() => ((RssResult)result).Feed.Items.First().Content.Type.ShouldEqual("html");

		It should_set_feed_item_last_updated_time =
			() => ((RssResult)result).Feed.Items.First().LastUpdatedTime.ShouldEqual(new DateTimeOffset(2011, 12, 13, 14, 15, 16, TimeSpan.Zero));

		It should_set_feed_item_last_publish_date =
			() => ((RssResult)result).Feed.Items.First().LastUpdatedTime.ShouldEqual(new DateTimeOffset(2011, 12, 13, 14, 15, 16, TimeSpan.Zero));

		It should_set_feed_item_permalink =
			() => ((RssResult)result).Feed.Items.First().Links.Single(l => l.RelationshipType == "alternate").Uri.ShouldEqual(new Uri("http://novuscraft.com/blog/blog-post-2"));
	}
}