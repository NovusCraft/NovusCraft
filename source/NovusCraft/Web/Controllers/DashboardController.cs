// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Web.Mvc;

namespace NovusCraft.Web.Controllers
{
	public sealed class DashboardController : Controller
	{
		[Authorize]
		public ActionResult Home()
		{
			return View();
		}
	}
}