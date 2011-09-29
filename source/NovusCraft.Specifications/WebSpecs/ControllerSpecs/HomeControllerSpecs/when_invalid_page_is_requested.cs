using System.Web.Mvc;
using Machine.Specifications;
using Machine.Specifications.Mvc;
using NovusCraft.Web.Controllers;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.HomeControllerSpecs
{
	[Subject(typeof(HomeController))]
	public class when_invalid_page_is_requested : home_controller_spec
	{
		static ActionResult result;
		Because of = () => result = controller.PageNotFound();

		It should_return_the_404_page =
			() => result.ShouldBeAView().And().ViewName.ShouldEqual("404");

		It should_set_status_code_to_404 =
			() => http_response.VerifySet(hr => hr.StatusCode = 404);
	}
}