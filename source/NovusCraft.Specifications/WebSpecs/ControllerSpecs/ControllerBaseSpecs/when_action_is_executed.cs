// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Web.Mvc;
using Machine.Specifications;
using Moq;
using NovusCraft.Web.Controllers;
using It = Machine.Specifications.It;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.ControllerBaseSpecs
{
	[Subject(typeof(BlogController))]
	public class when_action_is_executed : controller_base_spec
	{
		Because of = () =>
			{
				var actionExecutedContext = new Mock<ActionExecutedContext>();
				actionExecutedContext.SetupGet(aec => aec.IsChildAction).Returns(false);
				controller.OnActionExecuted(actionExecutedContext.Object);
			};

		It should_save_document_session_changes =
			() => document_session.Verify(ds => ds.SaveChanges());

		It should_dispose_document_session =
			() => document_session.Verify(ds => ds.Dispose());
	}
}