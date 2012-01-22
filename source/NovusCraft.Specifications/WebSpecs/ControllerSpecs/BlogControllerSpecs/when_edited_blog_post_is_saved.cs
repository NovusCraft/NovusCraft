// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using System.Linq;
using System.Web.Mvc;
using Machine.Specifications;
using NovusCraft.Data;
using NovusCraft.Data.Blog;
using NovusCraft.Specifications.Utils;
using NovusCraft.Web.Controllers;
using NovusCraft.Web.ViewModels;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.BlogControllerSpecs
{
	[Subject(typeof(BlogController))]
	public class when_edited_blog_post_is_saved : blog_controller_spec
	{
		Because of = () =>
			{
				container.Configure(ce => ce.For<CommandHandler<UpdateBlogPostCommand>>().Use<UpdateBlogPostHandler>());

				using (var session = document_store.OpenSession())
				{
					session.Store(new BlogPost
					              	{
					              		Id = 1,
					              		Title = "Test blog post",
					              		Slug = "test-blog-post",
					              		Content = "Blog post content.",
					              		Category = new BlogPostCategory { Title = "Category A" },
					              		PublishedOn = new DateTimeOffset(2011, 11, 10, 09, 08, 07, TimeSpan.Zero)
					              	});

					session.SaveChanges();
				}

				var editPostModel = new EditBlogPostModel
				                    	{
				                    		Id = 1,
				                    		Title = "New test blog post",
				                    		Slug = "new-test-blog-post",
				                    		Content = "New blog post content.",
				                    		CategoryTitle = "Category B"
				                    	};

				controller.EditBlogPost(editPostModel);
			};

		// TODO: spec for :after behaviour

		It should_update_blog_post_title =
			() => document_store.OpenSession().Query<BlogPost>().Single(bp => bp.Id == 1).Title.ShouldEqual("New test blog post");

		It should_update_blog_post_slug =
			() => document_store.OpenSession().Query<BlogPost>().Single(bp => bp.Id == 1).Slug.ShouldEqual("new-test-blog-post");

		It should_update_blog_post_content =
			() => document_store.OpenSession().Query<BlogPost>().Single(bp => bp.Id == 1).Content.ShouldEqual("New blog post content.");

		It should_update_blog_post_category =
			() => document_store.OpenSession().Query<BlogPost>().Single(bp => bp.Id == 1).Category.Title.ShouldEqual("Category B");

		It should_update_blog_post_publish_date =
			() => document_store.OpenSession().Query<BlogPost>().Single(bp => bp.Id == 1).PublishedOn.ShouldBeGreaterThan(DateTimeOffset.Now.AddMinutes(-1));

		It should_only_allow_http_post =
			() => This.Action<BlogController>(bc => bc.EditBlogPost(null)).ShouldBeDecoratedWith<HttpPostAttribute>();
	}
}