// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Web.Mvc;
using Machine.Specifications;
using Moq;
using NovusCraft.Infrastructure.ActionFilters;
using Raven.Client;
using Raven.Client.Embedded;
using StructureMap;
using It = Machine.Specifications.It;

namespace NovusCraft.Specifications.InfrastructureSpecs.ActionFilterSpecs.RavenSessionAttributeSpecs
{
	[Subject(typeof(RavenSessionAttribute))]
	public class after_action_is_executed : raven_session_attribute_spec
	{
		Because of = () =>
		{
			ObjectFactory.Container.Configure(c => c.For<IDocumentSession>().Singleton().Use(() =>
			{
				var documentStore = new EmbeddableDocumentStore { RunInMemory = true };
				documentStore.Initialize();
				var session = documentStore.OpenSession();

				session.Store(new { });

				return session;
			}));

			var filterContext = new Mock<ActionExecutedContext>();

			attribute.OnActionExecuted(filterContext.Object);
		};

		It should_commit_changes_in_ravendb_session =
			() => ObjectFactory.Container.GetInstance<IDocumentSession>().Advanced.HasChanges.ShouldBeFalse();
	}
}