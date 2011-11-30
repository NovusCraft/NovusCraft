// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Linq;
using System.Web;
using System.Web.Mvc;
using NovusCraft.Data;
using Raven.Client;
using StructureMap;

namespace NovusCraft.Web
{
	public class MvcApplication : HttpApplication
	{
		public void Application_Start()
		{
			// register global filters
			GlobalFilters.Filters.Add(new HandleErrorAttribute());

			// register routes
			RouteConfigurator.Initialise();

			// initialise structure map
			ObjectFactory.Initialize(ie => ie.AddRegistry<StructureMapConfigurationRegistry>());

			// register controller factory
			ControllerBuilder.Current.SetControllerFactory(typeof(StructureMapControllerFactory));
		}

		public void Application_EndRequest()
		{
			var documentSessionRef = ObjectFactory.Container.Model.InstancesOf<IDocumentSession>().Single();

			if (documentSessionRef.ObjectHasBeenCreated() == false)
				return;

			using (var documentSession = ObjectFactory.GetInstance<IDocumentSession>())
				documentSession.SaveChanges();
		}
	}
}