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
	public class when_edited_blog_post_is_saved : blog_controller_spec
	{
		Because of = () =>
			{
				var editPostModel = new EditPostModel
				                    	{
				                    		Id = 1,
				                    		Title = "New Title",
				                    		Content = "New content.",
				                    		CategoryTitle = "New Category Title"
				                    	};

				controller.EditBlogPost(editPostModel);
			};

		// TODO: spec for :after behaviour

		It should_save_post_data =
			() => repository.Verify(r => r.UpdateBlogPost(1, "New Title", "New content.", "New Category Title"));

		It should_only_allow_http_post =
			() => This.Action<BlogController>(bc => bc.EditBlogPost(null)).ShouldBeDecoratedWith<HttpPostAttribute>();
	}
}