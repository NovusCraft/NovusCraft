// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Web;
using System.Web.Mvc;
using Machine.Specifications;
using Moq;
using NovusCraft.Data.Blog;
using NovusCraft.Web.Controllers;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.HomeControllerSpecs
{
	public abstract class home_controller_spec
	{
		protected static Mock<IBlogPostRepository> blog_post_repository;
		protected static HomeController controller;
		protected static Mock<HttpResponseBase> http_response;

		Establish context = () =>
			{
				blog_post_repository = new Mock<IBlogPostRepository>();
				http_response = new Mock<HttpResponseBase>();

				var controllerContext = new Mock<ControllerContext>();
				controllerContext.SetupGet(cc => cc.HttpContext.Response).Returns(http_response.Object);

				controller = new HomeController(blog_post_repository.Object) { ControllerContext = controllerContext.Object };
			};
	}
}