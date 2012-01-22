// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Linq;
using System.Web.Mvc;
using Machine.Specifications;
using NovusCraft.Data.Blog;
using NovusCraft.Specifications.Utils;
using NovusCraft.Web.Controllers;
using NovusCraft.Web.ViewModels;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.BlogControllerSpecs
{
	[Subject(typeof(BlogController))]
	public class when_new_blog_post_is_saved : blog_controller_spec
	{
		Because of = () => controller.CreateBlogPost(new CreateBlogPostModel
		                                             	{
		                                             		Title = "Test blog post",
		                                             		Slug = "test-blog-post",
		                                             		Content = "Blog post content.",
		                                             		CategoryTitle = "Category A"
		                                             	});

		// TODO: spec for :after behaviour

		It should_save_post_with_title_test_blog_post =
			() => document_store.OpenSession().Query<BlogPost>().Count(bp => bp.Title == "Test blog post").ShouldEqual(1);

		It should_save_post_with_slug_test_blog_post =
			() => document_store.OpenSession().Query<BlogPost>().Count(bp => bp.Slug == "test-blog-post").ShouldEqual(1);

		It should_save_post_with_content_blog_post_content =
			() => document_store.OpenSession().Query<BlogPost>().Count(bp => bp.Content == "Blog post content.").ShouldEqual(1);

		It should_save_post_with_category_title_category_a =
			() => document_store.OpenSession().Query<BlogPost>().Count(bp => bp.Category.Title == "Category A").ShouldEqual(1);

		It should_only_allow_http_post =
			() => This.Action<BlogController>(bc => bc.CreateBlogPost(null)).ShouldBeDecoratedWith<HttpPostAttribute>();
	}
}