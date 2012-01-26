﻿// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using System.Linq;
using System.Web.Mvc;
using Machine.Specifications;
using Machine.Specifications.Mvc;
using NovusCraft.Data;
using NovusCraft.Data.Blog;
using NovusCraft.Specifications.Utils;
using NovusCraft.Web.Controllers;
using NovusCraft.Web.ViewModels;
using Raven.Client;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.BlogControllerSpecs
{
	[Subject(typeof(BlogController))]
	public class when_edited_blog_post_is_saved : blog_controller_spec
	{
		static ActionResult result;

		Because of = () =>
			{
				container.Configure(ce => ce.For<CommandHandler<UpdateBlogPostCommand>>().Use<UpdateBlogPostHandler>());

				using (var session = document_store.OpenSession())
				{
					session.Store(new BlogPost
					              	{
					              		Id = 1,
					              		Title = "Test Title",
					              		Slug = "test-title",
					              		Content = "Test Content",
					              		Category = new BlogPostCategory { Title = "Category A" },
					              		PublishedOn = new DateTimeOffset(2011, 11, 10, 09, 08, 07, TimeSpan.Zero)
					              	});

					session.SaveChanges();
				}

				var editPostModel = new EditBlogPostModel
				                    	{
				                    		Id = 1,
				                    		Title = "New Test Title",
				                    		Slug = "new-test-title",
				                    		Content = "New Test Content",
				                    		CategoryTitle = "Category B"
				                    	};

				result = controller.EditBlogPost(editPostModel);

				container.GetInstance<IDocumentSession>().SaveChanges(); // normally called by RavenSessionAttribute.OnActionExecuted(ActionExecutedContext)
			};

		It should_update_blog_post_title =
			() => document_store.OpenSession().Query<BlogPost>().Single(bp => bp.Id == 1).Title.ShouldEqual("New Test Title");

		It should_update_blog_post_slug =
			() => document_store.OpenSession().Query<BlogPost>().Single(bp => bp.Id == 1).Slug.ShouldEqual("new-test-title");

		It should_update_blog_post_content =
			() => document_store.OpenSession().Query<BlogPost>().Single(bp => bp.Id == 1).Content.ShouldEqual("New Test Content");

		It should_update_blog_post_category =
			() => document_store.OpenSession().Query<BlogPost>().Single(bp => bp.Id == 1).Category.Title.ShouldEqual("Category B");

		It should_update_blog_post_publish_date =
			() => document_store.OpenSession().Query<BlogPost>().Single(bp => bp.Id == 1).PublishedOn.ShouldBeGreaterThan(DateTimeOffset.Now.AddMinutes(-1));

		It should_display_dashboard_page =
			() => result.ShouldRedirectToAction<DashboardController>(c => c.Home());

		It should_validate_anti_forgery_token =
			() => This.Action<BlogController>(bc => bc.EditBlogPost(null)).ShouldBeDecoratedWith<ValidateAntiForgeryTokenAttribute>();

		It should_only_allow_http_post =
			() => This.Action<BlogController>(bc => bc.EditBlogPost(null)).ShouldBeDecoratedWith<HttpPostAttribute>();
	}
}