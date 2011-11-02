// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Machine.Specifications;
using Moq;
using It = Moq.It;

namespace NovusCraft.Specifications.WebSpecs.HelperSpecs
{
	public abstract class html_helper_spec
	{
		protected static HtmlHelper<dynamic> helper;
		protected static RouteData route_data;

		Cleanup cleanup = () => RouteTable.Routes.Clear();

		Establish context = () =>
			{
				var httpRequestBase = new Mock<HttpRequestBase>();
				httpRequestBase.SetupGet(hrb => hrb.ApplicationPath).Returns("");

				var httpResponseBase = new Mock<HttpResponseBase>();
				httpResponseBase.Setup(hrb => hrb.ApplyAppPathModifier(It.IsAny<string>())).Returns((string s) => s);

				var httpContextBase = new Mock<HttpContextBase>();
				httpContextBase.SetupGet(hcb => hcb.Request).Returns(httpRequestBase.Object);
				httpContextBase.SetupGet(hcb => hcb.Response).Returns(httpResponseBase.Object);

				route_data = new RouteData();
				var requestContext = new RequestContext(httpContextBase.Object, route_data);
				var viewContext = new ViewContext {RequestContext = requestContext};
				var viewDataContainer = new Mock<IViewDataContainer>();

				helper = new HtmlHelper<dynamic>(viewContext, viewDataContainer.Object);

				RouteTable.Routes.MapRoute("Route A", "route-a", new {controller = "Home", action = "RouteA"});
				RouteTable.Routes.MapRoute("Route B", "route-b", new {controller = "Home", action = "RouteB"});
			};
	}
}