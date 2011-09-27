using Machine.Specifications;
using NovusCraft.Web.Controllers;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.HomeControllerSpecs
{
	public abstract class HomeControllerSpec
	{
		protected static HomeController Controller;

		Establish context = () => { Controller = new HomeController(); };
	}
}