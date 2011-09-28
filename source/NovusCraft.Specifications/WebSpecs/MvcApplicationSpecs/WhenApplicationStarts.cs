using System.Web.Mvc;
using Machine.Specifications;
using NovusCraft.Specifications.Utils;
using NovusCraft.Web;
using NovusCraft.Web.Controllers;

namespace NovusCraft.Specifications.WebSpecs.MvcApplicationSpecs
{
	[Subject(typeof (MvcApplication))]
	public class when_application_starts : MvcApplicationSpec
	{
		Because of = () => Application.Application_Start();

		It should_add_handle_error_filter_to_global_filters =
			() => GlobalFilters.Filters.ShouldContain(f => f.Instance.GetType().Name == typeof (HandleErrorAttribute).Name);

		It should_register_about_route =
			() => "~/about".ShouldMapTo<HomeController>(controller => controller.About());

		It should_register_axd_ignore_route =
			() => "resource.axd".ShouldBeIgnored();

		It should_register_contact_route =
			() => "~/contact".ShouldMapTo<HomeController>(controller => controller.Contact());

		It should_register_home_route =
			() => "~/".ShouldMapTo<HomeController>(controller => controller.Index());
	}
}