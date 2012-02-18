// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using NovusCraft.Infrastructure.Commands;
using NovusCraft.Infrastructure.Indexes;
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

		[OutputCache(CacheProfile = "DynamicContent")]
		public ActionResult ViewBlogPost(string slug)
		{
			var model = _documentSession.Query<BlogPost>(BlogPosts_BySlug.Name).AsProjection<ViewBlogPostModel>().SingleOrDefault(bp => bp.Slug == slug);

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
			var model = new CreateBlogPostModel
			{
				PublishedOn = DateTimeOffset.Now,
				ExistingCategories = GetExistingCategories()
			};

			return View(model);
		}

		[HttpPost, Authorize, ValidateAntiForgeryToken]
		public ActionResult CreateBlogPost(CreateBlogPostModel blogPost)
		{
			if (ModelState.IsValid)
			{
				_commandDispatcher.Dispatch(new CreateBlogPostCommand(blogPost));
				return RedirectToAction("Home", "Dashboard");
			}

			return View();
		}

		[Authorize]
		public ActionResult EditBlogPost(int id)
		{
			var blogPost = _documentSession.Load<BlogPost>(id);
			var model = Mapper.Map<BlogPost, UpdateBlogPostModel>(blogPost);
			model.ExistingCategories = GetExistingCategories();

			return View(model);
		}

		[HttpPost, Authorize, ValidateAntiForgeryToken]
		public ActionResult EditBlogPost(UpdateBlogPostModel blogPost)
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

		List<string> GetExistingCategories()
		{
			return (from result in _documentSession.Query<BlogPostCategories.ReduceResult>(BlogPostCategories.Name)
			        orderby result.Category
			        select result.Category).ToList();
		}
	}
}