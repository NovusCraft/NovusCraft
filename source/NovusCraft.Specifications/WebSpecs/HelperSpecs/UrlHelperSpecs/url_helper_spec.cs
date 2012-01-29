// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Machine.Specifications;
using Moq;
using It = Moq.It;

namespace NovusCraft.Specifications.WebSpecs.HelperSpecs.UrlHelperSpecs
{
	public abstract class url_helper_spec
	{
		protected static UrlHelper helper;
		protected static RouteData route_data;

		Establish context = () =>
		{
			var httpRequest = new Mock<HttpRequestBase>();
			httpRequest.SetupGet(hr => hr.ApplicationPath).Returns(string.Empty);
			httpRequest.SetupGet(hr => hr.Url).Returns(new Uri("http://www.novuscraft.com/"));

			var httpResponse = new Mock<HttpResponseBase>();
			httpResponse.Setup(hr => hr.ApplyAppPathModifier(It.IsAny<string>())).Returns((string s) => s);

			var httpContext = new Mock<HttpContextBase>();
			httpContext.SetupGet(hc => hc.Request).Returns(httpRequest.Object);
			httpContext.SetupGet(hc => hc.Response).Returns(httpResponse.Object);

			route_data = new RouteData();
			var requestContext = new RequestContext(httpContext.Object, route_data);

			helper = new UrlHelper(requestContext);

			RouteTable.Routes.MapRoute("Route A", "route-a/{param1}", new { controller = "Home", action = "RouteA" });
		};

		Cleanup after = () => RouteTable.Routes.Clear();
	}
}