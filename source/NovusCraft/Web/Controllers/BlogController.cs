// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Net;
using System.Web.Mvc;
using NovusCraft.Data.Blog;
using NovusCraft.Web.Helpers;
using NovusCraft.Web.ViewModels;

namespace NovusCraft.Web.Controllers
{
	public sealed class BlogController : Controller
	{
		readonly IBlogPostRepository _blogPostRepository;

		public BlogController(IBlogPostRepository blogPostRepository)
		{
			_blogPostRepository = blogPostRepository;
		}

		public ActionResult ViewPost(string slug)
		{
			var blogPost = _blogPostRepository.GetBlogPost(slug);

			if (blogPost == null)
			{
				Response.StatusCode = (int)HttpStatusCode.NotFound;
				return View("PageNotFound");
			}

			var permalink = Url.Permalink("ViewPost", "Blog", new { slug });
			var disqusId = blogPost.Id.Substring(blogPost.Id.LastIndexOf("/") + 1);
			var model = new ViewPostModel
			            	{
			            		Title = blogPost.Title,
			            		Content = new MvcHtmlString(blogPost.Content),
			            		Permalink = permalink.ToString(),
			            		CategoryTitle = blogPost.Category.Title,
			            		PublishedOn = blogPost.PublishedOn,
			            		DisqusId = disqusId
			            	};

			return View(model);
		}

		public ActionResult EditPost(string slug)
		{
			var blogPost = _blogPostRepository.GetBlogPost(slug);

			var permalink = Url.Permalink("ViewPost", "Blog", new { slug });
			var disqusId = blogPost.Id.Substring(blogPost.Id.LastIndexOf("/") + 1);
			var model = new ViewPostModel
			{
				Title = blogPost.Title,
				Content = new MvcHtmlString(blogPost.Content),
				Permalink = permalink.ToString(),
				CategoryTitle = blogPost.Category.Title,
				PublishedOn = blogPost.PublishedOn,
				DisqusId = disqusId
			};

			return View(model);
		}
	}
}