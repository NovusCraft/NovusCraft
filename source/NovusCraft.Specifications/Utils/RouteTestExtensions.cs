using System;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
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

		public static void ShouldMapTo<TController>(this string requestUrl, Expression<Action<TController>> action) where TController : Controller
		{
			var httpContext = new Mock<HttpContextBase>();
			httpContext.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath).Returns(requestUrl);

			var routeData = RouteTable.Routes.GetRouteData(httpContext.Object);
			routeData.ShouldNotBeNull();

			var controllerName = typeof (TController).Name.Replace("Controller", string.Empty);
			routeData.Values["controller"].ShouldEqual(controllerName);

			var actionName = ((MethodCallExpression)action.Body).Method.Name;
			routeData.Values["action"].ShouldEqual(actionName);
		}
	}
}