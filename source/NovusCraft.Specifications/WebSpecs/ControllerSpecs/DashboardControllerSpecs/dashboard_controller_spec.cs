// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using Machine.Specifications;
using Moq;
using NovusCraft.Data.Blog;
using NovusCraft.Web.Controllers;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.DashboardControllerSpecs
{
	public abstract class dashboard_controller_spec
	{
		protected static DashboardController controller;
		protected static Mock<IBlogPostRepository> repository;

		Establish context = () =>
			{
				repository = new Mock<IBlogPostRepository>();
				controller = new DashboardController(repository.Object);
			};
	}
}