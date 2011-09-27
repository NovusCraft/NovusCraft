using System.Web.Mvc;
using Machine.Specifications;
using NovusCraft.Web;

namespace NovusCraft.Specifications.Web.MvcApplicationSpecs
{
	[Subject(typeof (MvcApplication))]
	public class when_application_starts : MvcApplicationSpec
	{
		Because of =
			() => Application.Application_Start();

		It should_add_handle_error_filter_to_global_filters =
			() => GlobalFilters.Filters.ShouldContain(f => f.Instance.GetType().Name == typeof (HandleErrorAttribute).Name);
	}
}