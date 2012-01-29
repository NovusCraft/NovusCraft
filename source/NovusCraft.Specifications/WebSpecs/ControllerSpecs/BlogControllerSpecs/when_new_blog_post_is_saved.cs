// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using System.Linq;
using System.Web.Mvc;
using Machine.Specifications;
using Machine.Specifications.Mvc;
using NovusCraft.Infrastructure;
using NovusCraft.Infrastructure.Commands;
using NovusCraft.Model;
using NovusCraft.Specifications.SpecUtils;
using NovusCraft.Web.Controllers;
using NovusCraft.Web.ViewModels;
using Raven.Client;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.BlogControllerSpecs
{
	[Subject(typeof(BlogController))]
	public class when_new_blog_post_is_saved : blog_controller_spec
	{
		static ActionResult result;

		Because of = () =>
		{
			container.Configure(ce => ce.For<CommandHandler<AddBlogPostCommand>>().Use<AddBlogPostHandler>());

			result = controller.CreateBlogPost(new CreateBlogPostModel
			{
				Title = "Test Title",
				Slug = "test-title",
				Content = "Blog Content",
				Category = "Category A",
				PublishedOn = new DateTimeOffset(2012, 11, 10, 9, 8, 7, TimeSpan.Zero)
			});

			container.GetInstance<IDocumentSession>().SaveChanges(); // normally called by RavenSessionAttribute.OnActionExecuted(ActionExecutedContext)
		};

		It should_save_blog_post_with_title =
			() => document_store.OpenSession().Query<BlogPost>().Count(bp => bp.Title == "Test Title").ShouldEqual(1);

		It should_save_blog_post_with_slug =
			() => document_store.OpenSession().Query<BlogPost>().Count(bp => bp.Slug == "test-title").ShouldEqual(1);

		It should_save_blog_post_with_content =
			() => document_store.OpenSession().Query<BlogPost>().Count(bp => bp.Content == "Blog Content").ShouldEqual(1);

		It should_save_blog_post_with_category_title =
			() => document_store.OpenSession().Query<BlogPost>().Count(bp => bp.Category == "Category A").ShouldEqual(1);

		It should_save_blog_post_with_publish_date =
			() => document_store.OpenSession().Query<BlogPost>().Count(bp => bp.PublishedOn == new DateTimeOffset(2012, 11, 10, 9, 8, 7, TimeSpan.Zero)).ShouldEqual(1);

		It should_display_dashboard_page =
			() => result.ShouldRedirectToAction<DashboardController>(c => c.Home());

		It should_validate_anti_forgery_token =
			() => This.Action<BlogController>(bc => bc.CreateBlogPost(null)).ShouldBeDecoratedWith<ValidateAntiForgeryTokenAttribute>();

		It should_only_allow_http_post =
			() => This.Action<BlogController>(bc => bc.CreateBlogPost(null)).ShouldBeDecoratedWith<HttpPostAttribute>();
	}
}