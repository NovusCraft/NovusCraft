// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Machine.Specifications;
using Machine.Specifications.Mvc;
using NovusCraft.Model;
using NovusCraft.Specifications.SpecUtils;
using NovusCraft.Web.Controllers;
using NovusCraft.Web.ViewModels;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.DashboardControllerSpecs
{
	[Subject(typeof(DashboardController))]
	public class when_home_page_is_requested : dashboard_controller_spec
	{
		static ActionResult result;

		Because of = () =>
		{
			using (var session = document_store.OpenSession())
			{
				session.Store(new BlogPost
				{
					Id = 1,
					Title = "Test Title",
					Content = "Test Content",
					Category = "Category A",
					PublishedOn = new DateTimeOffset(2012, 11, 10, 09, 08, 07, TimeSpan.Zero)
				});

				session.Store(new BlogPost
				{
					Id = 2,
					Title = "Test Title 2",
					Content = "Test Content 2",
					Category = "Category B",
					PublishedOn = new DateTimeOffset(2012, 11, 10, 09, 08, 08, TimeSpan.Zero)
				});

				session.SaveChanges();
			}

			result = controller.Home();
		};

		It should_display_home_page =
			() => result.ShouldBeAView().And().ShouldUseDefaultView();

		It should_return_list_of_blog_posts_sorted_by_publish_date_most_recent_first =
			() => result.Model<List<ViewBlogPostModel>>().First().PublishedOn.ShouldBeGreaterThan(result.Model<List<ViewBlogPostModel>>()[1].PublishedOn);

		It should_return_list_of_blog_posts_with_blog_post_having_id =
			() => result.Model<List<ViewBlogPostModel>>().First().Id.ShouldEqual(2);

		It should_return_list_of_blog_posts_with_blog_post_having_title =
			() => result.Model<List<ViewBlogPostModel>>().First().Title.ShouldEqual("Test Title 2");

		It should_return_list_of_blog_posts_with_blog_post_having_content =
			() => result.Model<List<ViewBlogPostModel>>().First().Content.ShouldEqual("Test Content 2");

		It should_return_list_of_blog_posts_with_blog_post_having_category_title =
			() => result.Model<List<ViewBlogPostModel>>().First().Category.ShouldEqual("Category B");

		It should_return_list_of_blog_posts_with_blog_post_having_publish_date =
			() => result.Model<List<ViewBlogPostModel>>().First().PublishedOn.ShouldEqual(new DateTimeOffset(2012, 11, 10, 09, 08, 08, TimeSpan.Zero));

		It requires_authentication =
			() => This.Action<DashboardController>(controller => controller.Home()).ShouldBeDecoratedWith<AuthorizeAttribute>();
	}
}