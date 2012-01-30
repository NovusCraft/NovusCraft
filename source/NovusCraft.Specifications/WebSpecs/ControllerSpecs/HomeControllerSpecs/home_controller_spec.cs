// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Machine.Specifications;
using Moq;
using NovusCraft.Infrastructure;
using NovusCraft.Web.Controllers;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Embedded;
using Raven.Client.Indexes;
using It = Moq.It;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.HomeControllerSpecs
{
	public abstract class home_controller_spec
	{
		protected static HomeController controller;
		protected static Mock<HttpRequestBase> http_request;
		protected static Mock<HttpResponseBase> http_response;
		protected static EmbeddableDocumentStore document_store;
		protected static IDocumentSession session;

		Establish context = () =>
		{
			http_request = new Mock<HttpRequestBase>();
			http_response = new Mock<HttpResponseBase>();
			http_response.Setup(hrb => hrb.ApplyAppPathModifier(It.IsAny<string>())).Returns((string s) => s);

			var controllerContext = new Mock<ControllerContext>();
			controllerContext.SetupGet(cc => cc.HttpContext.Request).Returns(http_request.Object);
			controllerContext.SetupGet(cc => cc.HttpContext.Response).Returns(http_response.Object);

			var httpContext = new Mock<HttpContextBase>();
			httpContext.SetupGet(hc => hc.Request).Returns(http_request.Object);
			httpContext.SetupGet(hc => hc.Response).Returns(http_response.Object);
			var urlHelper = new UrlHelper(new RequestContext(httpContext.Object, new RouteData()));

			RouteConfigurator.Initialise(); // this populates route table, so ensure RouteTable.Routes.Clear() is called during cleanup

			document_store = new EmbeddableDocumentStore { RunInMemory = true, Conventions = new DocumentConvention { DefaultQueryingConsistency = ConsistencyOptions.QueryYourWrites } };
			document_store.Initialize();

			IndexCreation.CreateIndexes(typeof(DocumentStoreFactory).Assembly, document_store);

			session = document_store.OpenSession();

			controller = new HomeController(session) { ControllerContext = controllerContext.Object, Url = urlHelper };
		};

		Cleanup after = () => RouteTable.Routes.Clear();
	}
}