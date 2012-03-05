// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Machine.Specifications;
using Moq;
using NovusCraft.Specifications.SpecUtils;
using NovusCraft.Web.Controllers;
using Raven.Client;
using It = Moq.It;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.HomeControllerSpecs
{
	public abstract class home_controller_spec
	{
		protected static HomeController controller;
		protected static Mock<HttpRequestBase> http_request;
		protected static Mock<HttpResponseBase> http_response;
		protected static IDocumentSession session;

		Establish context = () =>
		{
			Spec.RequiresRoutes();

			http_request = new Mock<HttpRequestBase>();
			http_response = new Mock<HttpResponseBase>();
			http_response.Setup(hrb => hrb.ApplyAppPathModifier(It.IsAny<string>())).Returns((string s) => s);

			var controllerContext = new Mock<ControllerContext>();
			controllerContext.SetupGet(cc => cc.HttpContext.Request).Returns(http_request.Object);
			controllerContext.SetupGet(cc => cc.HttpContext.Response).Returns(http_response.Object);

			var httpContext = new Mock<HttpContextBase>();
			httpContext.SetupGet(hc => hc.Request).Returns(http_request.Object);
			httpContext.SetupGet(hc => hc.Response).Returns(http_response.Object);
			var urlHelper = new UrlHelper(new RequestContext(httpContext.Object, new RouteData()));

			session = Spec.RequiresRavenDBDocumentSession();

			controller = new HomeController(session) { ControllerContext = controllerContext.Object, Url = urlHelper };
		};

		Cleanup after = () => RouteTable.Routes.Clear();
	}
}