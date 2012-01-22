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
		readonly IDocumentSession _documentSession;
		readonly CommandDispatcher _commandDispatcher;

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
		public void CreateBlogPost(CreateBlogPostModel newBlogPost)
		{
			_commandDispatcher.Dispatch(new AddBlogPostCommand(newBlogPost));
		}

		[Authorize]
		public ActionResult EditBlogPost(int id)
		{
			var blogPost = _documentSession.Query<BlogPost>().SingleOrDefault(bp => bp.Id == id);

			var model = new EditBlogPostModel // TODO: Use AutoMapper?
			            	{
			            		Id = blogPost.Id,
			            		Title = blogPost.Title,
			            		Content = blogPost.Content,
			            		CategoryTitle = blogPost.Category.Title,
			            		PublishedOn = blogPost.PublishedOn,
			            	};

			return View(model);
		}

		[HttpPost, Authorize]
		public void EditBlogPost(EditBlogPostModel model)
		{
			_commandDispatcher.Dispatch(new UpdateBlogPostCommand(model));
		}
	}
}