// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using System.Web.Mvc;
using System.Web.Routing;
using Machine.Specifications;
using NovusCraft.Infrastructure.AreaRegistrations;
using NovusCraft.Specifications.SpecUtils;
using NovusCraft.Web.Controllers;

namespace NovusCraft.Specifications.InfrastructureSpecs.AreaRegistrationSpecs.PublicAreaRegistrationSpecs
{
	[Subject(typeof(PublicAreaRegistration))]
	public class when_area_is_registered
	{
		static RouteCollection route_collection;

		Because of = () =>
		{
			var registration = new PublicAreaRegistration();
			route_collection = new RouteCollection();
			registration.RegisterArea(new AreaRegistrationContext(registration.AreaName, RouteTable.Routes));
		};

		Cleanup after = () => RouteTable.Routes.Clear();

		It should_register_home_route =
			() => "~/".ShouldMapTo<HomeController>(controller => controller.Home());

		It should_register_blog_post_route =
			() => "~/blog/blog-post-slug".ShouldMapTo<BlogController>(controller => controller.ViewBlogPost("blog-post-slug"));

		It should_register_about_route =
			() => "~/about".ShouldMapTo<HomeController>(controller => controller.About());

		It should_register_contact_route =
			() => "~/contact".ShouldMapTo<HomeController>(controller => controller.Contact());

		It should_register_feed_route =
			() => "~/feed".ShouldMapTo<HomeController>(controller => controller.Feed());
	}
}