// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace NovusCraft.Web.Helpers
{
	public static class UrlHelpers
	{
		public static Uri Permalink(this UrlHelper url)
		{
			var protocol = GetContextRequestProtocol(url.RequestContext);
			return new Uri(url.Action(null, null, null, protocol));
		}

		public static Uri Permalink(this UrlHelper url, string actionName, string controllerName, object routeValues = null)
		{
			var protocol = GetContextRequestProtocol(url.RequestContext);
			return new Uri(url.Action(actionName, controllerName, routeValues, protocol));
		}

		static string GetContextRequestProtocol(RequestContext requestContext)
		{
			return requestContext.HttpContext.Request.Url.Scheme;
		}
	}
}