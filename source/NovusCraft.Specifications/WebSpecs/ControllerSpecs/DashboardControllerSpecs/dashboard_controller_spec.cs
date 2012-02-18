// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using Machine.Specifications;
using NovusCraft.Specifications.SpecUtils;
using NovusCraft.Web.Controllers;
using Raven.Client;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.DashboardControllerSpecs
{
	public abstract class dashboard_controller_spec
	{
		protected static DashboardController controller;
		protected static IDocumentSession session;

		Establish context = () =>
		{
			session = Spec.RequiresRavenDBDocumentSession();
			controller = new DashboardController(session);
		};
	}
}