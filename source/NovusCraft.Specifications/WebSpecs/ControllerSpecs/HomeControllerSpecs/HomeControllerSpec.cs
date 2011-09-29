using System.Web;
using System.Web.Mvc;
using Machine.Specifications;
using Moq;
using NovusCraft.Web.Controllers;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.HomeControllerSpecs
{
	public abstract class HomeControllerSpec
	{
		protected static HomeController Controller;
		protected static Mock<ControllerContext> ControllerContext;
		protected static Mock<HttpResponseBase> HttpResponse;

		Establish context = () =>
		                    	{
		                    		ControllerContext = new Mock<ControllerContext>();
		                    		HttpResponse = new Mock<HttpResponseBase>();
		                    		ControllerContext.SetupGet(cc => cc.HttpContext.Response).Returns(HttpResponse.Object);

		                    		Controller = new HomeController {ControllerContext = ControllerContext.Object};
		                    	};
	}
}