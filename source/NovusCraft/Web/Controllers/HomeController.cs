using System.Web.Mvc;

namespace NovusCraft.Web.Controllers
{
	public sealed class HomeController : Controller
	{
		public void Index()
		{
			throw new System.NotImplementedException();
		}

		public ActionResult About()
		{
			return View();
		}
	}
}