// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Web;
using System.Web.Mvc;
using Machine.Specifications;
using Moq;
using NovusCraft.Web.Controllers;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.HomeControllerSpecs
{
	public abstract class home_controller_spec
	{
		protected static HomeController controller;
		protected static Mock<HttpResponseBase> http_response;

		Establish context = () =>
			{
				http_response = new Mock<HttpResponseBase>();

				var controllerContext = new Mock<ControllerContext>();
				controllerContext.SetupGet(cc => cc.HttpContext.Response).Returns(http_response.Object);

				controller = new HomeController { ControllerContext = controllerContext.Object };
			};
	}
}