// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using System.Web.Mvc;

namespace NovusCraft.Infrastructure.AreaRegistrations
{
	public sealed class DashboardAreaRegistration : AreaRegistration
	{
		public const string Name = "Dashboard";

		public override string AreaName
		{
			get { return Name; }
		}

		public override void RegisterArea(AreaRegistrationContext context)
		{
			var @namespace = new[] { "NovusCraft.Web.Controllers" };

			// dashboard section
			context.MapRoute("Log In", "dashboard/login", new { controller = "UserAccount", action = "LogIn" }, @namespace);
			context.MapRoute("Log Out", "dashboard/logout", new { controller = "UserAccount", action = "LogOut" }, @namespace);
			context.MapRoute("Dashboard Home", "dashboard", new { controller = "Dashboard", action = "Home" }, @namespace);
			context.MapRoute("Create Blog Post", "dashboard/blogpost/create", new { controller = "Blog", action = "CreateBlogPost" }, @namespace);
			context.MapRoute("Edit Blog Post", "dashboard/blogpost/edit/{id}", new { controller = "Blog", action = "EditBlogPost" }, @namespace);
			context.MapRoute("Delete Blog Post", "dashboard/blogpost/delete/{id}", new { controller = "Blog", action = "DeleteBlogPost" }, @namespace);
		}
	}
}