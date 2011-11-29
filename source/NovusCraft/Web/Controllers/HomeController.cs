// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Web.Mvc;
using NovusCraft.Data.Blog;
using NovusCraft.Web.ActionResults;

namespace NovusCraft.Web.Controllers
{
	public sealed class HomeController : Controller
	{
		readonly IBlogPostRepository _blogPostRepository;

		public HomeController(IBlogPostRepository blogPostRepository)
		{
			_blogPostRepository = blogPostRepository;
		}

		public ActionResult Home()
		{
			return View();
		}

		public ActionResult About()
		{
			return View();
		}

		public ActionResult Contact()
		{
			return View();
		}

		public ActionResult PageNotFound()
		{
			Response.StatusCode = (int)HttpStatusCode.NotFound;

			return View();
		}

		public RssResult Feed()
		{
			var recentBlogPosts = _blogPostRepository.GetRecentBlogPosts();

			var feed = new SyndicationFeed();
			feed.Id = "novus_craft";
			feed.Title = new TextSyndicationContent("Novus Craft");
			feed.Authors.Add(new SyndicationPerson("arnold.zokas@novuscraft.com"));
			feed.Copyright = new TextSyndicationContent("Copyright © 2011 Novus Craft");
			feed.Language = "en-GB";
			feed.LastUpdatedTime = recentBlogPosts.Max(bp => bp.PublishedOn);

			var syndicationItems = new List<SyndicationItem>();
			foreach (var blogPost in recentBlogPosts)
			{
				var syndicationItem = new SyndicationItem();
				syndicationItem.Title = new TextSyndicationContent(blogPost.Title);
				syndicationItem.Categories.Add(new SyndicationCategory(blogPost.Category.Title));
				syndicationItem.Content = new TextSyndicationContent(blogPost.Content, TextSyndicationContentKind.Html);
				syndicationItem.LastUpdatedTime = blogPost.PublishedOn;
				syndicationItem.PublishDate = blogPost.PublishedOn;

				syndicationItem.AddPermalink(new Uri("http://novuscraft.com/blog/" + blogPost.Slug)); // TODO: IPermalinkGenerator

				syndicationItems.Add(syndicationItem);
			}
			feed.Items = syndicationItems;

			return new RssResult(feed);
		}
	}
}