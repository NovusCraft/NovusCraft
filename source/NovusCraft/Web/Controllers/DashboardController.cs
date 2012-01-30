// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Linq;
using System.Web.Mvc;
using NovusCraft.Model;
using Raven.Client;
using Raven.Client.Linq;

namespace NovusCraft.Web.Controllers
{
	public sealed class DashboardController : Controller
	{
		readonly IDocumentSession _documentSession;

		public DashboardController(IDocumentSession documentSession)
		{
			_documentSession = documentSession;
		}

		[Authorize]
		public ActionResult Home()
		{
			var model = _documentSession.Query<BlogPost>().OrderByDescending(bp => bp.PublishedOn).ToList();

			return View(model);
		}
	}
}