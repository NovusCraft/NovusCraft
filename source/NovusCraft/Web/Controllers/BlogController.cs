// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Linq;
using System.Net;
using System.Web.Mvc;
using NovusCraft.Data;
using NovusCraft.Data.Blog;
using NovusCraft.Web.Helpers;
using NovusCraft.Web.ViewModels;
using Raven.Client;

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
			var blogPost = _documentSession.Query<BlogPost>().SingleOrDefault(bp => bp.Slug == slug);

			if (blogPost == null)
			{
				Response.StatusCode = (int)HttpStatusCode.NotFound;
				return View("PageNotFound");
			}

			var permalink = Url.Permalink("ViewBlogPost", "Blog", new { slug });
			var model = new ViewBlogPostModel // TODO: Consider using AutoMapper?
			            	{
			            		Id = blogPost.Id,
			            		Title = blogPost.Title,
			            		Content = blogPost.Content,
			            		CategoryTitle = blogPost.Category.Title,
			            		PublishedOn = blogPost.PublishedOn,
			            		Permalink = permalink.ToString()
			            	};

			return View(model);
		}

		[Authorize]
		public ActionResult CreateBlogPost()
		{
			return View();
		}

		[HttpPost, Authorize]
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
			var blogPost = _documentSession.Query<BlogPost>().SingleOrDefault(bp => bp.Id == id);

			var model = new EditBlogPostModel // TODO: Use AutoMapper?
			            	{
			            		Id = blogPost.Id,
			            		Title = blogPost.Title,
			            		Slug = blogPost.Slug,
			            		Content = blogPost.Content,
			            		CategoryTitle = blogPost.Category.Title,
			            		PublishedOn = blogPost.PublishedOn,
			            	};

			return View(model);
		}

		[HttpPost, Authorize]
		public ActionResult EditBlogPost(EditBlogPostModel blogPost)
		{
			if (ModelState.IsValid)
			{
				_commandDispatcher.Dispatch(new UpdateBlogPostCommand(blogPost));
				return RedirectToAction("Home", "Dashboard");
			}

			return View();
		}

		[HttpDelete, Authorize]
		public ActionResult DeleteBlogPost(int id)
		{
			_commandDispatcher.Dispatch(new DeleteBlogPostCommand(id));

			var dashboardUrl = Url.Permalink("Home", "Dashboard");
			return Json(new { redirectTo = dashboardUrl.ToString() });
		}
	}
}