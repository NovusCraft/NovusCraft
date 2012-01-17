// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Linq;
using System.Web.Mvc;
using NovusCraft.Data.Blog;
using NovusCraft.Web.ViewModels;

namespace NovusCraft.Web.Controllers
{
	public sealed class DashboardController : Controller
	{
		readonly IBlogPostRepository _blogPostRepository;

		public DashboardController(IBlogPostRepository blogPostRepository)
		{
			_blogPostRepository = blogPostRepository;
		}

		[Authorize]
		public ActionResult Home()
		{
			var model = (from blogPost in _blogPostRepository.GetBlogPosts()
			             select new ViewBlogPostModel
			                    	{
			                    		Id = blogPost.Id,
			                    		Title = blogPost.Title,
			                    		Content = new MvcHtmlString(blogPost.Content),
			                    		CategoryTitle = blogPost.Category.Title,
			                    		PublishedOn = blogPost.PublishedOn
			                    	}).ToList();


			return View(model);
		}
	}
}