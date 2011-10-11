// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NovusCraft.Web
{
	public class MvcApplication : HttpApplication
	{
		public void Application_Start()
		{
			RegisterGlobalFilters(GlobalFilters.Filters);
			RegisterRoutes(RouteTable.Routes);
		}

		static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}

		static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute("Home", string.Empty, new {controller = "Home", action = "Home"});
			routes.MapRoute("About", "about", new {controller = "Home", action = "About"});
			routes.MapRoute("Contact", "contact", new {controller = "Home", action = "Contact"});

			routes.MapRoute("404", "{*url}", new {controller = "Home", action = "PageNotFound"});
		}
	}
}