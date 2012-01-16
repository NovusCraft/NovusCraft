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
			var model = new ViewPostModel // TODO: Use AutoMapper?
			            	{
			            		Id = blogPost.Id,
			            		Title = blogPost.Title,
			            		Content = new MvcHtmlString(blogPost.Content),
			            		Permalink = permalink.ToString(),
			            		CategoryTitle = blogPost.Category.Title,
			            		PublishedOn = blogPost.PublishedOn
			            	};

			return View(model);
		}

		public ActionResult CreatePost()
		{
			return View();
		}

		[HttpPost]
		public void CreatePost(CreatePostModel model)
		{
			_blogPostRepository.CreateBlogPost(model.Title, model.Content, model.CategoryTitle);
		}

		public ActionResult EditPost(int id)
		{
			var blogPost = _blogPostRepository.GetBlogPost(id);

			var model = new EditPostModel // TODO: Use AutoMapper?
			            	{
			            		Id = blogPost.Id,
			            		Title = blogPost.Title,
			            		Content = blogPost.Content,
			            		CategoryTitle = blogPost.Category.Title,
			            		PublishedOn = blogPost.PublishedOn,
			            	};

			return View(model);
		}

		[HttpPost]
		public void EditPost(EditPostModel model)
		{
			_blogPostRepository.UpdateBlogPost(model.Id, model.Title, model.Content, model.CategoryTitle);
		}
	}
}