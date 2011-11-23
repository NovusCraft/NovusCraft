// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NovusCraft.Data;
using Raven.Client.Embedded;
using StructureMap;

namespace NovusCraft.Web
{
	public class MvcApplication : HttpApplication
	{
		const string RavenDbConnectionStringName = "Raven";

		public static EmbeddableDocumentStore RavenDbDocumentStore { get; private set; }

		public void Application_Start()
		{
			InitialiseRavenDb();
			RegisterGlobalFilters(GlobalFilters.Filters);
			RegisterRoutes(RouteTable.Routes);
			InitialiseStructureMap();
			RegisterStructureMapControllerFactory();
		}

		static void InitialiseRavenDb()
		{
			RavenDbDocumentStore = new EmbeddableDocumentStore {ConnectionStringName = RavenDbConnectionStringName};
			RavenDbDocumentStore.Initialize();
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
			routes.MapRoute("Blog Post", "blog/{slug}", new {controller = "Blog", action = "ViewPost"});

			routes.MapRoute("404", "{*url}", new {controller = "Home", action = "PageNotFound"});
		}

		static void InitialiseStructureMap()
		{
			ObjectFactory.Initialize(c => c.AddRegistry<StructureMapConfigurationRegistry>());
		}

		static void RegisterStructureMapControllerFactory()
		{
			ControllerBuilder.Current.SetControllerFactory(typeof(StructureMapControllerFactory));
		}
	}
}