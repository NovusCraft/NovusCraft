// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Machine.Specifications;
using Moq;
using NovusCraft.Infrastructure;
using NovusCraft.Infrastructure.Commands;
using NovusCraft.Model;
using NovusCraft.Specifications.SpecUtils;
using NovusCraft.Web.Controllers;
using Raven.Client;
using It = Machine.Specifications.It;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.BlogControllerSpecs
{
	[Subject(typeof(BlogController))]
	public class when_blog_post_is_deleted : blog_controller_spec
	{
		static ActionResult result;

		Because of = () =>
		{
			var httpRequest = new Mock<HttpRequestBase>();
			httpRequest.SetupGet(hr => hr.Url).Returns(new Uri("http://novuscraft.com/dashboard/blogpost/edit/1"));

			var httpResponse = new Mock<HttpResponseBase>();
			httpResponse.Setup(hrb => hrb.ApplyAppPathModifier(Moq.It.IsAny<string>())).Returns((string s) => s);

			var httpContext = new Mock<HttpContextBase>();
			httpContext.SetupGet(hc => hc.Request).Returns(httpRequest.Object);
			httpContext.SetupGet(hc => hc.Response).Returns(httpResponse.Object);
			var urlHelper = new UrlHelper(new RequestContext(httpContext.Object, new RouteData()));

			RouteConfigurator.Initialise(); // this populates route table, so ensure RouteTable.Routes.Clear() is called during cleanup

			controller.Url = urlHelper;

			container.Configure(ce => ce.For<CommandHandler<DeleteBlogPostCommand>>().Use<DeleteBlogPostHandler>());

			using (var session = document_store.OpenSession())
			{
				session.Store(new BlogPost { Id = 1 });

				session.SaveChanges();
			}

			result = controller.DeleteBlogPost(1);

			container.GetInstance<IDocumentSession>().SaveChanges(); // normally called by RavenSessionAttribute.OnActionExecuted(ActionExecutedContext)
		};

		It should_delete_blog_post =
			() => document_store.OpenSession().Query<BlogPost>().Customize(c => c.WaitForNonStaleResults()).Count(bp => bp.Id == 1).ShouldEqual(0);

		It should_return_json_result =
			() => result.ShouldBeOfType<JsonResult>();

		It should_return_json_result_with_redirect_target =
			() => result.As<JsonResult>().Data.Property<string>("redirectTo").ShouldEqual("http://novuscraft.com/dashboard");

		It should_validate_anti_forgery_token =
			() => This.Action<BlogController>(bc => bc.DeleteBlogPost(1)).ShouldBeDecoratedWith<ValidateAntiForgeryTokenAttribute>();

		It should_only_allow_http_delete =
			() => This.Action<BlogController>(bc => bc.DeleteBlogPost(1)).ShouldBeDecoratedWith<HttpDeleteAttribute>();

		It requires_authentication =
			() => This.Action<BlogController>(controller => controller.DeleteBlogPost(1)).ShouldBeDecoratedWith<AuthorizeAttribute>();
	}
}