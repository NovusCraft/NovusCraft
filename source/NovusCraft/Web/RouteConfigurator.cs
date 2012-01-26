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
			routes.MapRoute("View Blog Post", "blog/{slug}", new { controller = "Blog", action = "ViewBlogPost" });

			// dashboard section
			routes.MapRoute("Log In", "dashboard/login", new { controller = "UserAccount", action = "LogIn" });
			routes.MapRoute("Log Out", "dashboard/logout", new { controller = "UserAccount", action = "LogOut" });
			routes.MapRoute("Dashboard Home", "dashboard", new { controller = "Dashboard", action = "Home" });
			routes.MapRoute("Create Blog Post", "dashboard/blogpost/create", new { controller = "Blog", action = "CreateBlogPost" });
			routes.MapRoute("Edit Blog Post", "dashboard/blogpost/edit/{id}", new { controller = "Blog", action = "EditBlogPost" });
			routes.MapRoute("Delete Blog Post", "dashboard/blogpost/delete/{id}", new { controller = "Blog", action = "DeleteBlogPost" });

			// 404 page
			routes.MapRoute("404", "{*url}", new { controller = "Home", action = "PageNotFound" });
		}
	}
}