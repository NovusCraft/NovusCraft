// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using System;
using System.Linq;
using System.Web.Mvc;
using Machine.Specifications;
using Machine.Specifications.Mvc;
using NovusCraft.Model;
using NovusCraft.Specifications.SpecUtils;
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
			session.Store(new BlogPost
			{
				Id = 1,
				Title = "Test Title",
				Slug = "test-title",
				Content = "Test Content",
				Category = "Category A",
				PublishedOn = new DateTimeOffset(2011, 11, 10, 09, 08, 07, TimeSpan.Zero)
			});
			session.Store(new BlogPost { Id = 2, Category = "Category B" });
			session.SaveChanges();

			Spec.RequiresAutoMapperConfiguration();

			result = controller.EditBlogPost(1);
		};

		It should_display_blog_post_for_editing =
			() => result.ShouldBeAView().And().ShouldUseDefaultView();

		It should_return_blog_post_with_id =
			() => result.Model<UpdateBlogPostModel>().Id.ShouldEqual(1);

		It should_return_blog_post_with_title =
			() => result.Model<UpdateBlogPostModel>().Title.ShouldEqual("Test Title");

		It should_return_blog_post_with_slug =
			() => result.Model<UpdateBlogPostModel>().Slug.ShouldEqual("test-title");

		It should_return_blog_post_with_content =
			() => result.Model<UpdateBlogPostModel>().Content.ShouldEqual("Test Content");

		It should_return_blog_post_with_category_title =
			() => result.Model<UpdateBlogPostModel>().Category.ShouldEqual("Category A");

		It should_return_blog_post_with_publish_date =
			() => result.Model<UpdateBlogPostModel>().PublishedOn.ShouldEqual(new DateTimeOffset(2011, 11, 10, 09, 08, 07, TimeSpan.Zero));

		It should_return_model_with_existing_categories =
			() => result.Model<UpdateBlogPostModel>().ExistingCategories.First().ShouldEqual("Category A");

		It requires_authentication =
			() => This.Action<BlogController>(controller => controller.EditBlogPost(0)).ShouldBeDecoratedWith<AuthorizeAttribute>();
	}
}