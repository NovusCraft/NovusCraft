using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NovusCraft.Site
{
	public class MvcApplication : HttpApplication
	{
		// ReSharper disable InconsistentNaming
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			RegisterGlobalFilters(GlobalFilters.Filters);
			RegisterRoutes(RouteTable.Routes);
		}

		// ReSharper restore InconsistentNaming

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