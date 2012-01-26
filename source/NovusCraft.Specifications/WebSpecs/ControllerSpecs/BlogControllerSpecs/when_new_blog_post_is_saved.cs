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
				                                   		CategoryTitle = "Category A"
				                                   	});

				container.GetInstance<IDocumentSession>().SaveChanges(); // normally called by StructureMapControllerFactory.ReleaseController(IController)
			};

		It should_save_blog_post_with_title =
			() => document_store.OpenSession().Query<BlogPost>().Count(bp => bp.Title == "Test Title").ShouldEqual(1);

		It should_save_blog_post_with_slug =
			() => document_store.OpenSession().Query<BlogPost>().Count(bp => bp.Slug == "test-title").ShouldEqual(1);

		It should_save_blog_post_with_content =
			() => document_store.OpenSession().Query<BlogPost>().Count(bp => bp.Content == "Blog Content").ShouldEqual(1);

		It should_save_blog_post_with_category_title =
			() => document_store.OpenSession().Query<BlogPost>().Count(bp => bp.Category.Title == "Category A").ShouldEqual(1);

		It should_save_blog_blog_post_publish_date =
			() => document_store.OpenSession().Query<BlogPost>().Single(bp => bp.Id == 1).PublishedOn.ShouldBeGreaterThan(DateTimeOffset.Now.AddMinutes(-1));

		It should_display_dashboard_page =
			() => result.ShouldRedirectToAction<DashboardController>(c => c.Home());

		It should_only_allow_http_post =
			() => This.Action<BlogController>(bc => bc.CreateBlogPost(null)).ShouldBeDecoratedWith<HttpPostAttribute>();
	}
}