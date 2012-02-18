// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using System.Web.Routing;
using Machine.Specifications;
using NovusCraft.Infrastructure;
using NovusCraft.Specifications.SpecUtils;
using NovusCraft.Web.Controllers;

namespace NovusCraft.Specifications.InfrastructureSpecs.RouteConfiguratorSpecs
{
	[Subject(typeof(RouteConfigurator))]
	public class when_initialised
	{
		Because of = () => RouteConfigurator.Initialise();

		Cleanup after = () => RouteTable.Routes.Clear();

		It should_register_axd_ignore_route =
			() => "resource.axd".ShouldBeIgnored();

		It should_register_home_route =
			() => "~/".ShouldMapTo<HomeController>(controller => controller.Home());

		It should_register_blog_post_route =
			() => "~/blog/blog-post-slug".ShouldMapTo<BlogController>(controller => controller.ViewBlogPost("blog-post-slug"));

		It should_register_about_route =
			() => "~/about".ShouldMapTo<HomeController>(controller => controller.About());

		It should_register_contact_route =
			() => "~/contact".ShouldMapTo<HomeController>(controller => controller.Contact());

		It should_register_404_route =
			() => "~/this-page-does-not-exist".ShouldMapTo<HomeController>(controller => controller.PageNotFound());

		It should_register_feed_route =
			() => "~/feed".ShouldMapTo<HomeController>(controller => controller.Feed());

		It should_register_login_route =
			() => "~/dashboard/login".ShouldMapTo<UserAccountController>(controller => controller.LogIn());

		It should_register_logout_route =
			() => "~/dashboard/logout".ShouldMapTo<UserAccountController>(controller => controller.LogOut());

		It should_register_dashboard_home_route =
			() => "~/dashboard".ShouldMapTo<DashboardController>(controller => controller.Home());

		It should_register_create_blogpost_route =
			() => "~/dashboard/blogpost/create".ShouldMapTo<BlogController>(controller => controller.CreateBlogPost());

		It should_register_edit_blogpost_route =
			() => "~/dashboard/blogpost/edit/1".ShouldMapTo<BlogController>(controller => controller.EditBlogPost(1));

		It should_register_delete_blogpost_route =
			() => "~/dashboard/blogpost/delete/1".ShouldMapTo<BlogController>(controller => controller.DeleteBlogPost(1));
	}
}