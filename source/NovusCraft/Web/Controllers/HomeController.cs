using System.Web.Mvc;

namespace NovusCraft.Web.Controllers
{
	public sealed class HomeController : Controller
	{
		public ActionResult About()
		{
			ViewBag.Title = "About";

			return View();
		}
	}
}