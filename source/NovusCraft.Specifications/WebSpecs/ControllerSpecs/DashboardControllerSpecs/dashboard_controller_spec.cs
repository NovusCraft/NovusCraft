// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using Machine.Specifications;
using NovusCraft.Web.Controllers;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.DashboardControllerSpecs
{
	public abstract class dashboard_controller_spec
	{
		protected static DashboardController controller;

		Establish context = () => controller = new DashboardController();
	}
}