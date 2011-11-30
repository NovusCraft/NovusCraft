// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Web.Routing;
using Machine.Specifications;
using NovusCraft.Specifications.Utils;
using NovusCraft.Specifications.WebSpecs.MvcApplicationSpecs;
using NovusCraft.Web;
using NovusCraft.Web.Controllers;

namespace NovusCraft.Specifications.WebSpecs.RouteConfiguratorSpecs
{
	[Subject(typeof(MvcApplication))]
	public class when_initialised : mvc_application_spec
	{
		Because of = () => RouteConfigurator.Initialise();

		Cleanup after = () => RouteTable.Routes.Clear();

		It should_register_axd_ignore_route =
			() => "resource.axd".ShouldBeIgnored();

		It should_register_home_route =
			() => "~/".ShouldMapTo<HomeController>(controller => controller.Home());

		It should_register_blog_post_route =
			() => "~/blog/post-slug".ShouldMapTo<BlogController>(controller => controller.ViewPost("post-slug"));

		It should_register_about_route =
			() => "~/about".ShouldMapTo<HomeController>(controller => controller.About());

		It should_register_contact_route =
			() => "~/contact".ShouldMapTo<HomeController>(controller => controller.Contact());

		It should_register_404_route =
			() => "~/this-page-does-not-exist".ShouldMapTo<HomeController>(controller => controller.PageNotFound());

		It should_register_feed_route =
			() => "~/feed".ShouldMapTo<HomeController>(controller => controller.Feed());
	}
}