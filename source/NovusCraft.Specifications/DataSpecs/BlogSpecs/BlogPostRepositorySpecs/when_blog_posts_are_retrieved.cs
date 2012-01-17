// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Collections.Generic;
using Machine.Specifications;
using NovusCraft.Data.Blog;

namespace NovusCraft.Specifications.DataSpecs.BlogSpecs.BlogPostRepositorySpecs
{
	[Subject(typeof(BlogPostRepository))]
	public class when_blog_posts_are_retrieved : blog_post_repository_spec
	{
		static IList<BlogPost> blog_posts;
		Because of = () => blog_posts = repository.GetBlogPosts();

		It should_return_at_least_one_blog_post =
			() => blog_posts.Count.ShouldBeGreaterThan(0);
	}
}