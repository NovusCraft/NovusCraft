using System.Web.Mvc;
using Machine.Specifications;
using Machine.Specifications.Mvc;
using NovusCraft.Web.Controllers;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.HomeControllerSpecs
{
	[Subject(typeof (HomeController))]
	public class when_home_page_is_requested : HomeControllerSpec
	{
		static ActionResult result;
		Because of = () => result = Controller.Home();

		It should_return_the_home_page =
			() => result.ShouldBeAView().And().ShouldUseDefaultView();
	}
}