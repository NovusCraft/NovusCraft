// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using System.Web.Mvc;
using System.Web.Routing;

namespace NovusCraft.Infrastructure
{
	public static class RouteConfigurator
	{
		public static void Initialise()
		{
			var routes = RouteTable.Routes;

			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			// 404 page
			routes.MapRoute("404", "{*url}", new { controller = "Home", action = "PageNotFound" });
		}
	}
}