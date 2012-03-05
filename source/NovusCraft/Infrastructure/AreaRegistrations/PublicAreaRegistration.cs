// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using System.Web.Mvc;

namespace NovusCraft.Infrastructure.AreaRegistrations
{
	public sealed class PublicAreaRegistration : AreaRegistration
	{
		public const string Name = "Public";

		public override string AreaName
		{
			get { return Name; }
		}

		public override void RegisterArea(AreaRegistrationContext context)
		{
			var @namespace = new[] { "NovusCraft.Web.Controllers" };

			// top-level pages
			context.MapRoute("Home", "", new { controller = "Home", action = "Home" }, @namespace);
			context.MapRoute("About", "about", new { controller = "Home", action = "About" }, @namespace);
			context.MapRoute("Contact", "contact", new { controller = "Home", action = "Contact" }, @namespace);
			context.MapRoute("Feed", "feed", new { controller = "Home", action = "Feed" }, @namespace);

			// blog section
			context.MapRoute("View Blog Post", "blog/{slug}", new { controller = "Blog", action = "ViewBlogPost" }, @namespace);
		}
	}
}