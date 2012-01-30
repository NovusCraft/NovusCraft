// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using NovusCraft.Infrastructure;
using NovusCraft.Infrastructure.Commands;
using NovusCraft.Model;
using NovusCraft.Web.Helpers;
using NovusCraft.Web.ViewModels;
using Raven.Client;
using Raven.Client.Linq;

namespace NovusCraft.Web.Controllers
{
	public sealed class BlogController : Controller
	{
		readonly CommandDispatcher _commandDispatcher;
		readonly IDocumentSession _documentSession;

		public BlogController(IDocumentSession documentSession, CommandDispatcher commandDispatcher)
		{
			_documentSession = documentSession;
			_commandDispatcher = commandDispatcher;
		}

		public ActionResult ViewBlogPost(string slug)
		{
			var model = _documentSession.Query<BlogPost>().AsProjection<ViewBlogPostModel>().SingleOrDefault(bp => bp.Slug == slug);

			if (model == null)
			{
				Response.StatusCode = (int)HttpStatusCode.NotFound;
				return View("PageNotFound");
			}

			model.Permalink = Url.Permalink("ViewBlogPost", "Blog", new { slug }).ToString();

			return View(model);
		}

		[Authorize]
		public ActionResult CreateBlogPost()
		{
			var model = new BlogPost { PublishedOn = DateTimeOffset.Now };

			return View(model);
		}

		[HttpPost, Authorize, ValidateAntiForgeryToken]
		public ActionResult CreateBlogPost(CreateBlogPostModel blogPost)
		{
			if (ModelState.IsValid)
			{
				_commandDispatcher.Dispatch(new AddBlogPostCommand(blogPost));
				return RedirectToAction("Home", "Dashboard");
			}

			return View();
		}

		[Authorize]
		public ActionResult EditBlogPost(int id)
		{
			var model = _documentSession.Query<BlogPost>().Single(bp => bp.Id == id);

			return View(model);
		}

		[HttpPost, Authorize, ValidateAntiForgeryToken]
		public ActionResult EditBlogPost(EditBlogPostModel blogPost)
		{
			if (ModelState.IsValid)
			{
				_commandDispatcher.Dispatch(new UpdateBlogPostCommand(blogPost));
				return RedirectToAction("Home", "Dashboard");
			}

			return View();
		}

		[HttpDelete, Authorize, ValidateAntiForgeryToken]
		public ActionResult DeleteBlogPost(int id)
		{
			_commandDispatcher.Dispatch(new DeleteBlogPostCommand(id));

			var dashboardUrl = Url.Permalink("Home", "Dashboard");
			return Json(new { redirectTo = dashboardUrl.ToString() });
		}
	}
}