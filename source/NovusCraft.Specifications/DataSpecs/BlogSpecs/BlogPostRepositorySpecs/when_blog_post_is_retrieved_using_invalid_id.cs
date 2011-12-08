// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using Machine.Specifications;
using NovusCraft.Data.Blog;

namespace NovusCraft.Specifications.DataSpecs.BlogSpecs.BlogPostRepositorySpecs
{
	[Subject(typeof(BlogPostRepository))]
	public class when_blog_post_is_retrieved_using_invalid_id : blog_post_repository_spec
	{
		static BlogPost blog_post;
		Because of = () => blog_post = repository.GetBlogPost(id: 0);

		It should_return_null =
			() => blog_post.ShouldBeNull();
	}
}