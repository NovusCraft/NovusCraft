// # Copyright © 2011, Novus Craft
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
	public class when_create_blog_post_page_is_requested : blog_controller_spec
	{
		static ActionResult result;

		Because of = () =>
		{
			session.Store(new BlogPost { Category = "Category B" });
			session.Store(new BlogPost { Category = "Category A" });
			session.SaveChanges();

			result = controller.CreateBlogPost();
		};

		It should_display_blog_post_for_editing =
			() => result.ShouldBeAView().And().ShouldUseDefaultView();

		It should_return_model_with_current_date_and_time_as_publish_date =
			() => result.Model<CreateBlogPostModel>().PublishedOn.ShouldBeGreaterThan(DateTimeOffset.Now.AddMinutes(-1));

		It should_return_model_with_existing_categories =
			() => result.Model<CreateBlogPostModel>().ExistingCategories.First().ShouldEqual("Category A");

		It requires_authentication =
			() => This.Action<BlogController>(controller => controller.CreateBlogPost()).ShouldBeDecoratedWith<AuthorizeAttribute>();
	}
}