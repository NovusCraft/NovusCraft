using System.Web.Mvc;
using Machine.Specifications;
using NovusCraft.Specifications.Utils;
using NovusCraft.Web;

namespace NovusCraft.Specifications.WebSpecs.MvcApplicationSpecs
{
	[Subject(typeof (MvcApplication))]
	public class when_application_starts : MvcApplicationSpec
	{
		Because of = () => Application.Application_Start();

		It should_add_handle_error_filter_to_global_filters =
			() => GlobalFilters.Filters.ShouldContain(f => f.Instance.GetType().Name == typeof (HandleErrorAttribute).Name);

		It should_registed_axd_ignore_route =
			() => "resource.axd".ShouldBeIgnored();
	}
}