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
	public class when_child_action_is_executed : controller_base_spec
	{
		static Mock<ActionExecutedContext> action_executed_context;

		Because of = () =>
			{
				action_executed_context = new Mock<ActionExecutedContext>();
				action_executed_context.SetupGet(aec => aec.IsChildAction).Returns(true);
				controller.OnActionExecuted(action_executed_context.Object);
			};

		It should_stop_execution_when_action_is_a_child_action =
			() => action_executed_context.VerifyAll();
	}
}