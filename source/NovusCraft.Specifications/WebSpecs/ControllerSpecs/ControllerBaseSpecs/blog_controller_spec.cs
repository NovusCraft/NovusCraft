// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Web.Mvc;
using Machine.Specifications;
using Moq;
using Raven.Client;
using StructureMap;
using ControllerBase = NovusCraft.Web.Controllers.ControllerBase;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.ControllerBaseSpecs
{
	public abstract class controller_base_spec
	{
		protected static ControllerBaseProxy controller;
		protected static Mock<IDocumentSession> document_session;

		Establish context = () =>
			{
				document_session = new Mock<IDocumentSession>();
				ObjectFactory.Initialize(i => i.For<IDocumentSession>().Use(document_session.Object));

				controller = new ControllerBaseProxy();
			};

		Cleanup after = () => ObjectFactory.ResetDefaults();

		#region Nested type: ControllerBaseProxy

		public class ControllerBaseProxy : ControllerBase
		{
			public new void OnActionExecuted(ActionExecutedContext filterContext)
			{
				base.OnActionExecuted(filterContext);
			}
		}

		#endregion
	}
}