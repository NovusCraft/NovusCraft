// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using Machine.Specifications;
using NovusCraft.Data.Blog;

namespace NovusCraft.Specifications.DataSpecs.BlogSpecs.BlogPostRepositorySpecs
{
	[Subject(typeof(BlogPostRepository))]
	public class when_blog_post_is_retrieved : blog_post_repository_spec
	{
		static BlogPost blog_post;
		Because of = () => blog_post = repository.GetBlogPost(slug: "test");

		It should_return_blog_post_with_title_test =
			() => blog_post.Title.ShouldEqual("Test");
	}
}