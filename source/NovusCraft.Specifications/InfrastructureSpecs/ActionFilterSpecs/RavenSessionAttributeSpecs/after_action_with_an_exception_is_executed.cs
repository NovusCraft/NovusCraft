// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using System;
using System.Web.Mvc;
using Machine.Specifications;
using Moq;
using NovusCraft.Infrastructure.ActionFilters;
using NovusCraft.Specifications.SpecUtils;
using It = Machine.Specifications.It;

namespace NovusCraft.Specifications.InfrastructureSpecs.ActionFilterSpecs.RavenSessionAttributeSpecs
{
	[Subject(typeof(RavenSessionAttribute))]
	public class after_action_with_an_exception_is_executed : raven_session_attribute_spec
	{
		Because of = () =>
		{
			var filterContext = new Mock<ActionExecutedContext>();
			filterContext.SetupGet(fc => fc.Exception).Returns(new Exception());

			attribute.OnActionExecuted(filterContext.Object);
		};

		It should_commit_changes_in_ravendb_session =
			() => Spec.ContextDocumentSession.Advanced.HasChanges.ShouldBeTrue();
	}
}