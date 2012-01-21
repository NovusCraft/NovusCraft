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
			var model = (from blogPost in _documentSession.Query<BlogPost>().ToArray() // TODO: remove temporary workaround
			             select new ViewBlogPostModel
			                    	{
			                    		Id = blogPost.Id,
			                    		Title = blogPost.Title,
			                    		Content = blogPost.Content,
			                    		CategoryTitle = blogPost.Category.Title,
			                    		PublishedOn = blogPost.PublishedOn
			                    	}).ToList();

			return View(model);
		}
	}
}