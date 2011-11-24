// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Net;
using System.Web.Mvc;

namespace NovusCraft.Web.Controllers
{
	public sealed class HomeController : Controller
	{
		public ActionResult Home()
		{
			return View();
		}

		public ActionResult About()
		{
			return View();
		}

		public ActionResult Contact()
		{
			return View();
		}

		public ActionResult PageNotFound()
		{
			Response.StatusCode = (int)HttpStatusCode.NotFound;

			return View();
		}
	}
}