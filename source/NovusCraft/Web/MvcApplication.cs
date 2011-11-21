// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NovusCraft.Data;
using Raven.Client;
using Raven.Client.Embedded;
using StructureMap;

namespace NovusCraft.Web
{
	public class MvcApplication : HttpApplication
	{
		const string RavenDbSession = "RavenDB.Session";

		public MvcApplication()
		{
			// NOTE: Don't have a way of testing this. Yet.
			BeginRequest += (sender, e) => HttpContext.Current.Items[RavenDbSession] = DocumentStore.OpenSession();
			EndRequest += (sender, e) => ((IDisposable)HttpContext.Current.Items[RavenDbSession]).Dispose();
		}

		public static EmbeddableDocumentStore DocumentStore { get; set; }

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
			DocumentStore = new EmbeddableDocumentStore {DataDirectory = "App_Data/NovusCraft.RavenDb"};
			DocumentStore.Initialize();
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
			ObjectFactory.Configure(c =>
				{
					c.AddRegistry<StructureMapConfigurationRegistry>();

					// NOTE: Don't have a way of testing this. Yet.
					c.For<IDocumentSession>().HybridHttpOrThreadLocalScoped().Use(ce => (IDocumentSession)HttpContext.Current.Items[RavenDbSession]);
				});
		}

		static void RegisterStructureMapControllerFactory()
		{
			ControllerBuilder.Current.SetControllerFactory(typeof(StructureMapControllerFactory));
		}
	}
}