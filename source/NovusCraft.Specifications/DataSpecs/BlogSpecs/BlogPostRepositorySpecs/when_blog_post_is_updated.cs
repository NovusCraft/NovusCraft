// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Linq;
using Machine.Specifications;
using NovusCraft.Data.Blog;

namespace NovusCraft.Specifications.DataSpecs.BlogSpecs.BlogPostRepositorySpecs
{
	[Subject(typeof(BlogPostRepository))]
	public class when_blog_post_is_updated : blog_post_repository_spec
	{
		static BlogPost blog_post;

		Because of = () =>
			{
				int id;
				using (var session = document_store.OpenSession())
					id = session.Query<BlogPost>().First().Id;

				repository.UpdateBlogPost(id, "New Title", "New content.", "New Category Title");
				document_session.SaveChanges(); // normally handled by HttpApplication.End_Request()

				using (var session = document_store.OpenSession())
					blog_post = session.Query<BlogPost>().Single(bp => bp.Id == id);
			};

		It should_update_blogpost_title_to_new_title =
			() => blog_post.Title.ShouldEqual("New Title");

		It should_update_blogpost_content_to_new_content =
			() => blog_post.Content.ShouldEqual("New content.");

		It should_update_blogpost_category_title_to_new_category_title =
			() => blog_post.Category.Title.ShouldEqual("New Category Title");
	}
}