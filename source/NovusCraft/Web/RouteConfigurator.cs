﻿// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Web.Mvc;
using System.Web.Routing;

namespace NovusCraft.Web
{
	public static class RouteConfigurator
	{
		public static void Initialise()
		{
			var routes = RouteTable.Routes;

			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			// top-level pages
			routes.MapRoute("Home", string.Empty, new { controller = "Home", action = "Home" });
			routes.MapRoute("About", "about", new { controller = "Home", action = "About" });
			routes.MapRoute("Contact", "contact", new { controller = "Home", action = "Contact" });
			routes.MapRoute("Feed", "feed", new { controller = "Home", action = "Feed" });

			// blog section
			routes.MapRoute("Blog Post", "blog/{slug}", new { controller = "Blog", action = "ViewPost" });

			// 404 page
			routes.MapRoute("404", "{*url}", new { controller = "Home", action = "PageNotFound" });
		}
	}
}