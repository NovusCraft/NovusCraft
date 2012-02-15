// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Web.Mvc;
using NovusCraft.Infrastructure.ActionResults;
using NovusCraft.Infrastructure.Indexes;
using NovusCraft.Model;
using NovusCraft.Web.Helpers;
using Raven.Client;

namespace NovusCraft.Web.Controllers
{
	public sealed class HomeController : Controller
	{
		readonly IDocumentSession _documentSession;

		public HomeController(IDocumentSession documentSession)
		{
			_documentSession = documentSession;
		}

		[OutputCache(CacheProfile = "DynamicContent")]
		public ActionResult Home()
		{
			var recentBlogPosts = _documentSession.Query<BlogPost>(BlogPosts_ByPublishDate.Name).OrderByDescending(bp => bp.PublishedOn).ToList();

			return View(recentBlogPosts);
		}

		[OutputCache(CacheProfile = "StaticContent")]
		public ActionResult About()
		{
			return View();
		}

		[OutputCache(CacheProfile = "StaticContent")]
		public ActionResult Contact()
		{
			return View();
		}

		[OutputCache(CacheProfile = "StaticContent")]
		public ActionResult PageNotFound()
		{
			Response.StatusCode = (int)HttpStatusCode.NotFound;

			return View();
		}

		[OutputCache(CacheProfile = "DynamicContent")]
		public RssResult Feed()
		{
			var recentBlogPosts = _documentSession.Query<BlogPost>(BlogPosts_ByPublishDate.Name).OrderByDescending(bp => bp.PublishedOn).ToList();

			var feed = new SyndicationFeed();
			feed.Id = "novus_craft"; // TODO: Move to config
			feed.Title = new TextSyndicationContent("Novus Craft"); // TODO: Move to config
			feed.Authors.Add(new SyndicationPerson("arnold.zokas@novuscraft.com")); // TODO: Move to config
			feed.Copyright = new TextSyndicationContent("Copyright © 2011 Novus Craft"); // TODO: Move to config
			feed.Language = "en-GB"; // TODO: Move to config
			feed.LastUpdatedTime = recentBlogPosts.Max(bp => bp.PublishedOn);

			var syndicationItems = new List<SyndicationItem>();
			foreach (var blogPost in recentBlogPosts)
			{
				var syndicationItem = new SyndicationItem();
				syndicationItem.Title = new TextSyndicationContent(blogPost.Title);
				syndicationItem.Categories.Add(new SyndicationCategory(blogPost.Category));
				syndicationItem.Content = new TextSyndicationContent(blogPost.Content, TextSyndicationContentKind.Html);
				syndicationItem.LastUpdatedTime = blogPost.PublishedOn;
				syndicationItem.PublishDate = blogPost.PublishedOn;

				syndicationItem.AddPermalink(Url.Permalink("ViewBlogPost", "Blog", new { slug = blogPost.Slug }));

				syndicationItems.Add(syndicationItem);
			}
			feed.Items = syndicationItems;

			return new RssResult(feed);
		}
	}
}