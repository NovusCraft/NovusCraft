using System.Web;
using System.Web.Routing;
using Machine.Specifications;
using Moq;

namespace NovusCraft.Specifications.Utils
{
	public static class RouteTestExtensions
	{
		public static void ShouldBeIgnored(this string requestUrl)
		{
			var httpContext = new Mock<HttpContextBase>();
			httpContext.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath).Returns(requestUrl);

			var routeData = RouteTable.Routes.GetRouteData(httpContext.Object);
			routeData.ShouldNotBeNull();
			routeData.RouteHandler.ShouldBeOfType<StopRoutingHandler>();
		}
	}
}