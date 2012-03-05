// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using System;
using System.Web.Routing;
using Machine.Specifications;
using NovusCraft.Infrastructure.Commands;
using NovusCraft.Specifications.SpecUtils;
using NovusCraft.Web.Controllers;
using Raven.Client;
using StructureMap;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.BlogControllerSpecs
{
	public abstract class blog_controller_spec
	{
		protected static BlogController controller;
		protected static IDocumentSession session;

		[CLSCompliant(false)]
		protected static IContainer container;

		Establish context = () =>
		{
			Spec.RequiresRoutes();

			session = Spec.RequiresRavenDBDocumentSession();

			container = new Container();
			container.Configure(ce => ce.For<IDocumentSession>().Singleton().Use(session));

			var dispatcher = new CommandDispatcher(container);

			controller = new BlogController(session, dispatcher);
		};

		Cleanup after = () => RouteTable.Routes.Clear();
	}
}