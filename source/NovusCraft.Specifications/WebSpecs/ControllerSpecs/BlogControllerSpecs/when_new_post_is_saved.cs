// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Web.Mvc;
using Machine.Specifications;
using NovusCraft.Specifications.Utils;
using NovusCraft.Web.Controllers;
using NovusCraft.Web.ViewModels;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.BlogControllerSpecs
{
	[Subject(typeof(BlogController))]
	public class when_new_post_is_saved : blog_controller_spec
	{
		Because of = () =>
			{
				var createPostModel = new CreatePostModel
				                      	{
				                      		Title = "Title",
				                      		Content = "Content",
				                      		CategoryTitle = "Category Title"
				                      	};

				controller.CreatePost(createPostModel);
			};

		// TODO: spec for :after behaviour

		It should_save_post_data =
			() => repository.Verify(r => r.CreateBlogPost("Title", "Content", "Category Title"));

		It should_only_allow_post_requests =
			() => This.Action<BlogController>(bc => bc.CreatePost(null)).ShouldBeDecoratedWith<HttpPostAttribute>();
	}
}