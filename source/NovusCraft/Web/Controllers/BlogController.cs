// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Net;
using System.Web.Mvc;
using NovusCraft.Data.Blog;
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

			var requestUrl = Request.Url;
			var permalink = string.Format("{0}://{1}{2}", requestUrl.Scheme, requestUrl.Host, requestUrl.AbsolutePath);
			var disqusId = blogPost.Id.Substring(blogPost.Id.LastIndexOf("/") + 1);
			var model = new ViewPostModel
			            	{
			            		Title = blogPost.Title,
			            		Content = new MvcHtmlString(blogPost.Content),
			            		Permalink = permalink,
			            		CategoryTitle = blogPost.Category.Title,
			            		PublishedOn = blogPost.PublishedOn,
			            		DisqusId = disqusId
			            	};

			return View(model);
		}
	}
}