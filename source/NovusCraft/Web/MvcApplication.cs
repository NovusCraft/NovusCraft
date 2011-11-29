// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NovusCraft.Data;
using Raven.Client;
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

		public void Application_EndRequest()
		{
			var documentSessionRef = ObjectFactory.Container.Model.InstancesOf<IDocumentSession>().Single();

			if (documentSessionRef.ObjectHasBeenCreated() == false)
				return;

			using (var documentSession = ObjectFactory.GetInstance<IDocumentSession>())
				documentSession.SaveChanges();
		}

		static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}

		static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			// top-level pages
			routes.MapRoute("Home", string.Empty, new { controller = "Home", action = "Home" });
			routes.MapRoute("About", "about", new { controller = "Home", action = "About" });
			routes.MapRoute("Contact", "contact", new { controller = "Home", action = "Contact" });
			routes.MapRoute("Feed", "feed", new { controller = "Home", action = "Feed" });

			// blog section
			routes.MapRoute("Blog Post", "blog/{slug}", new { controller = "Blog", action = "ViewPost" });

			routes.MapRoute("404", "{*url}", new { controller = "Home", action = "PageNotFound" });
		}

		static void InitialiseStructureMap()
		{
			ObjectFactory.Initialize(ie => ie.AddRegistry<StructureMapConfigurationRegistry>());
		}

		static void RegisterStructureMapControllerFactory()
		{
			ControllerBuilder.Current.SetControllerFactory(typeof(StructureMapControllerFactory));
		}
	}
}