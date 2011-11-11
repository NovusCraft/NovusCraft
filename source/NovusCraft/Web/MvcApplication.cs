// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NovusCraft.Data;
using StructureMap;

namespace NovusCraft.Web
{
	public class MvcApplication : HttpApplication
	{
		public void Application_Start()
		{
			RegisterGlobalFilters(GlobalFilters.Filters);
			RegisterRoutes(RouteTable.Routes);
			InitialiseStructureMap();
			RegisterStructureMapControllerFactory();
		}

		static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}

		static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			// top-level pages
			routes.MapRoute("Home", string.Empty, new {controller = "Home", action = "Home"});
			routes.MapRoute("About", "about", new {controller = "Home", action = "About"});
			routes.MapRoute("Contact", "contact", new {controller = "Home", action = "Contact"});

			// blog section
			routes.MapRoute("Blog Post", "blog/{year}/{month}/{slug}", new {controller = "Blog", action = "ViewPost"}, new {year = @"\d{4,4}", month = @"\d{2,2}"});

			routes.MapRoute("404", "{*url}", new {controller = "Home", action = "PageNotFound"});
		}

		static void InitialiseStructureMap()
		{
			ObjectFactory.Configure(c => c.AddRegistry<StructureMapConfigurationRegistry>());
		}

		static void RegisterStructureMapControllerFactory()
		{
			ControllerBuilder.Current.SetControllerFactory(typeof(StructureMapControllerFactory));
		}
	}
}