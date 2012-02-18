// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using System.Web.Mvc;
using Machine.Specifications;
using Moq;
using NovusCraft.Infrastructure.ActionFilters;
using NovusCraft.Specifications.SpecUtils;
using It = Machine.Specifications.It;

namespace NovusCraft.Specifications.InfrastructureSpecs.ActionFilterSpecs.RavenSessionAttributeSpecs
{
	[Subject(typeof(RavenSessionAttribute))]
	public class after_action_is_executed : raven_session_attribute_spec
	{
		Because of = () => attribute.OnActionExecuted(new Mock<ActionExecutedContext>().Object);

		It should_commit_changes_in_ravendb_session =
			() => Spec.ContextDocumentSession.Advanced.HasChanges.ShouldBeFalse();
	}
}