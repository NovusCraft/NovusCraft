// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Linq;
using System.Web.Mvc;
using NovusCraft.Data.Blog;
using NovusCraft.Web.ViewModels;
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
			var blogPosts = _documentSession
				.Query<BlogPost>()
				.Customize(c => c.WaitForNonStaleResults())
				.OrderByDescending(bp => bp.PublishedOn)
				.ToArray(); // TODO: .ToArray() is a temporary workaround to handle failing projections

			var model = (from blogPost in blogPosts
			             select new ViewBlogPostModel
			             {
			             	Id = blogPost.Id,
			             	Title = blogPost.Title,
			             	Content = blogPost.Content,
			             	Category = blogPost.Category,
			             	PublishedOn = blogPost.PublishedOn
			             }).ToList();

			return View(model);
		}
	}
}