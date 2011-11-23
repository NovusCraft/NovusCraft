// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Linq;
using System.Web.Mvc;
using Machine.Specifications;
using NovusCraft.Specifications.Utils;
using NovusCraft.Web;
using NovusCraft.Web.Controllers;
using Raven.Client;
using StructureMap;

namespace NovusCraft.Specifications.WebSpecs.MvcApplicationSpecs
{
	[Subject(typeof(MvcApplication))]
	public class when_application_starts : mvc_application_spec
	{
		Because of = () => application.Application_Start();

		Cleanup after = () =>
			{
				var documentStore = ObjectFactory.GetInstance<IDocumentStore>();
				if (documentStore != null) documentStore.Dispose();
			};

		It should_add_handle_error_filter_to_global_filters =
			() => GlobalFilters.Filters.ShouldContain(f => f.Instance.GetType().Name == typeof(HandleErrorAttribute).Name);

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

		// if current plugin instance count is greater than default plugin instance count, then StructureMap is initialised
		It should_initialise_structuremap_container =
			() => ObjectFactory.Model.AllInstances.Count().ShouldBeGreaterThan(new Container().Model.AllInstances.Count());

		It should_register_structuremap_controller_factory =
			() => ControllerBuilder.Current.GetControllerFactory().ShouldBeOfType<StructureMapControllerFactory>();
	}
}