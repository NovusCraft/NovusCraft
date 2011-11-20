// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using Machine.Specifications;
using NovusCraft.Data.Blog;

namespace NovusCraft.Specifications.DataSpecs.BlogSpecs.BlogPostRepositorySpecs
{
	[Subject(typeof(BlogPostRepository))]
	public class when_blog_post_is_retrieved_using_invalid_slug : blog_post_repository_spec
	{
		static BlogPost blog_post;
		Because of = () => blog_post = repository.GetBlogPost(slug: "invalid_slug");

		It should_return_null =
			() => blog_post.ShouldBeNull();
	}
}