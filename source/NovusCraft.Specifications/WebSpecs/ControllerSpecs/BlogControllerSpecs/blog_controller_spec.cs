// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Machine.Specifications;
using Moq;
using NovusCraft.Data;
using NovusCraft.Data.Blog;
using NovusCraft.Web;
using NovusCraft.Web.Controllers;
using Raven.Client;
using Raven.Client.Embedded;
using StructureMap;
using It = Moq.It;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.BlogControllerSpecs
{
	public abstract class blog_controller_spec
	{
		protected static BlogController controller;
		protected static Mock<HttpResponseBase> http_response;
		protected static Mock<IBlogPostRepository> repository;
		protected static IDocumentStore document_store;

		Establish context = () =>
			{
				var httpRequest = new Mock<HttpRequestBase>();
				httpRequest.SetupGet(hr => hr.ApplicationPath).Returns(string.Empty);
				httpRequest.SetupGet(hr => hr.Url).Returns(new Uri("http://novuscraft.com/blog/test-slug-1"));

				http_response = new Mock<HttpResponseBase>();
				http_response.Setup(hrb => hrb.ApplyAppPathModifier(It.IsAny<string>())).Returns((string s) => s);

				var controllerContext = new Mock<ControllerContext>();
				controllerContext.SetupGet(cc => cc.HttpContext.Request).Returns(httpRequest.Object);
				controllerContext.SetupGet(cc => cc.HttpContext.Response).Returns(http_response.Object);

				var httpContext = new Mock<HttpContextBase>();
				httpContext.SetupGet(hc => hc.Request).Returns(httpRequest.Object);
				httpContext.SetupGet(hc => hc.Response).Returns(http_response.Object);
				var urlHelper = new UrlHelper(new RequestContext(httpContext.Object, new RouteData()));

				RouteConfigurator.Initialise(); // this populates route table, so ensure RouteTable.Routes.Clear() is called during cleanup

				repository = new Mock<IBlogPostRepository>();

				document_store = new EmbeddableDocumentStore { RunInMemory = true };
				document_store.Initialize();

				var container = new Container();
				container.Configure(ce => ce.For<IDocumentStore>().Use(document_store));
				container.Configure(ce => ce.For<CommandHandler<AddBlogPostCommand>>().Use<AddBlogPostHandler>());
				var dispatcher = new CommandDispatcher(container);

				var session = document_store.OpenSession();

				controller = new BlogController(repository.Object, dispatcher, session) { ControllerContext = controllerContext.Object, Url = urlHelper };
			};

		Cleanup after = () => RouteTable.Routes.Clear();
	}
}