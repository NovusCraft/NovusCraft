// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Linq;
using Machine.Specifications;
using NovusCraft.Data.Blog;

namespace NovusCraft.Specifications.DataSpecs.BlogSpecs.BlogPostRepositorySpecs
{
	[Subject(typeof(BlogPostRepository))]
	public class when_blog_post_is_created : blog_post_repository_spec
	{
		static BlogPost blog_post;

		Because of = () =>
			{
				int id;

				repository.CreateBlogPost("Title", "Content", "Category Title");
				document_session.SaveChanges(); // normally handled by HttpApplication.End_Request()

				using (var session = document_store.OpenSession())
					blog_post = session.Query<BlogPost>().Single(bp => bp.Title == "Title");
			};

		It should_create_blogpost_with_title =
			() => blog_post.Title.ShouldEqual("Title");

		It should_create_blogpost_with_content =
			() => blog_post.Content.ShouldEqual("Content");

		It should_create_blogpost_with_category_title =
			() => blog_post.Category.Title.ShouldEqual("Category Title");
	}
}