﻿using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NovusCraft.Web
{
	public sealed class MvcApplication : HttpApplication
	{
		public void Application_Start()
		{
			RegisterGlobalFilters(GlobalFilters.Filters);
			RegisterRoutes(RouteTable.Routes);
		}

		private static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}

		private static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
		}
	}
}