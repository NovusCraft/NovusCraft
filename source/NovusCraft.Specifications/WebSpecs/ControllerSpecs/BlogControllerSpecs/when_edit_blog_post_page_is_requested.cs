// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using System.Web.Mvc;
using Machine.Specifications;
using Machine.Specifications.Mvc;
using NovusCraft.Data.Blog;
using NovusCraft.Specifications.Utils;
using NovusCraft.Web.Controllers;
using NovusCraft.Web.ViewModels;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.BlogControllerSpecs
{
	[Subject(typeof(BlogController))]
	public class when_edit_blog_post_page_is_requested : blog_controller_spec
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
					              		Category = new BlogPostCategory { Title = "Category A" },
					              		PublishedOn = new DateTimeOffset(2011, 11, 10, 09, 08, 07, TimeSpan.Zero)
					              	});

					session.SaveChanges();
				}

				result = controller.EditBlogPost(1);
			};

		It should_display_post_for_editing =
			() => result.ShouldBeAView().And().ShouldUseDefaultView();

		It should_return_post_with_id_1 =
			() => result.Model<EditBlogPostModel>().Id.ShouldEqual(1);

		It should_return_post_with_title_hello_world =
			() => result.Model<EditBlogPostModel>().Title.ShouldEqual("Test Title");

		It should_return_post_with_content_test =
			() => result.Model<EditBlogPostModel>().Content.ShouldEqual("Test Content");

		It should_return_post_with_category_title_meta =
			() => result.Model<EditBlogPostModel>().CategoryTitle.ShouldEqual("Category A");

		It should_return_post_with_publish_date_of_10_november_2011_09_hours_08_minutes_07_seconds =
			() => result.Model<EditBlogPostModel>().PublishedOn.ShouldEqual(new DateTimeOffset(2011, 11, 10, 09, 08, 07, TimeSpan.Zero));

		It requires_authentication =
			() => This.Action<BlogController>(controller => controller.EditBlogPost(0)).ShouldBeDecoratedWith<AuthorizeAttribute>();
	}
}