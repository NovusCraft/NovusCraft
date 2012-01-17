﻿// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Web.Mvc;
using Machine.Specifications;
using Machine.Specifications.Mvc;
using NovusCraft.Web.Controllers;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.BlogControllerSpecs
{
	[Subject(typeof(BlogController))]
	public class when_blog_post_page_is_requested_with_invalid_slug : blog_controller_spec
	{
		static ActionResult result;
		Because of = () => result = controller.ViewBlogPost(slug: "test-slug-?");

		It should_display_page =
			() => result.ShouldBeAView().And().ViewName.ShouldEqual("PageNotFound");

		It should_set_status_code_to_404 =
			() => http_response.VerifySet(hr => hr.StatusCode = 404);
	}
}