// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using System.Web.Mvc;
using System.Web.Routing;
using Machine.Specifications;
using NovusCraft.Infrastructure.AreaRegistrations;
using NovusCraft.Specifications.SpecUtils;
using NovusCraft.Web.Controllers;

namespace NovusCraft.Specifications.InfrastructureSpecs.AreaRegistrationSpecs.DashboardAreaRegistrationSpecs
{
	[Subject(typeof(DashboardAreaRegistration))]
	public class when_area_is_registered
	{
		static RouteCollection route_collection;

		Because of = () =>
		{
			var registration = new DashboardAreaRegistration();
			route_collection = new RouteCollection();
			registration.RegisterArea(new AreaRegistrationContext(registration.AreaName, RouteTable.Routes));
		};

		Cleanup after = () => RouteTable.Routes.Clear();

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