// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using System.Web.Mvc;
using Machine.Specifications;
using Machine.Specifications.Mvc;
using NovusCraft.Web.Controllers;
using NovusCraft.Web.ViewModels;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.BlogControllerSpecs
{
	[Subject(typeof(BlogController))]
	public class when_post_is_requested : blog_controller_spec
	{
		static ActionResult result;
		Because of = () => result = controller.ViewPost(slug: "test-slug-1");

		It should_display_post =
			() => result.ShouldBeAView().And().ShouldUseDefaultView();

		It should_return_post_with_title_hello_world =
			() => result.Model<ViewPostModel>().Title.ShouldEqual("Test Post Title 1");

		It should_return_post_with_content_test =
			() => result.Model<ViewPostModel>().Content.ToHtmlString().ShouldEqual("Test Post Content 1");

		It should_return_post_with_permalink =
			() => result.Model<ViewPostModel>().Permalink.ShouldEqual("http://novuscraft.com/blog/test-slug-1");

		It should_return_post_with_category_title_meta =
			() => result.Model<ViewPostModel>().CategoryTitle.ShouldEqual("Category 1");

		It should_return_post_with_publish_date_of_10_november_2011_09_hours_08_minutes_07_seconds =
			() => result.Model<ViewPostModel>().PublishedOn.ShouldEqual(new DateTimeOffset(2011, 11, 10, 09, 08, 07, TimeSpan.Zero));

		It should_return_post_with_disqus_id_1 =
			() => result.Model<ViewPostModel>().DisqusId.ShouldEqual("1");
	}
}