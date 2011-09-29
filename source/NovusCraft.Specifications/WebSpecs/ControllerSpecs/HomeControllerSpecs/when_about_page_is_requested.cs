using System.Web.Mvc;
using Machine.Specifications;
using Machine.Specifications.Mvc;
using NovusCraft.Web.Controllers;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.HomeControllerSpecs
{
	[Subject(typeof(HomeController))]
	public class when_about_page_is_requested : HomeControllerSpec
	{
		static ActionResult result;
		Because of = () => result = Controller.About();

		It should_return_the_about_page =
			() => result.ShouldBeAView().And().ShouldUseDefaultView();
	}
}