// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Linq;
using System.Web.Mvc;
using NovusCraft.Infrastructure.Indexes;
using NovusCraft.Model;
using Raven.Client;

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
			var model = _documentSession
				.Query<BlogPost>(BlogPosts_ByPublishDate.Name)
				.Customize(c => c.WaitForNonStaleResults())
				.OrderByDescending(bp => bp.PublishedOn)
				.ToList();

			return View(model);
		}
	}
}