using System;
using System.Web.Mvc;

namespace NovusCraft.Web.Controllers
{
	public sealed class HomeController : Controller
	{
		public void Index()
		{
			throw new NotImplementedException();
		}

		public ActionResult About()
		{
			return View();
		}

		public void Contact()
		{
			throw new NotImplementedException();
		}
	}
}