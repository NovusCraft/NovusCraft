// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using NovusCraft.Data;
using NovusCraft.Web.ActionFilters;
using NovusCraft.Web.DataAnnotations;
using StructureMap;

namespace NovusCraft.Web
{
	public class MvcApplication : HttpApplication
	{
		public void Application_Start()
		{
			// register global filters
			GlobalFilters.Filters.Add(new HandleErrorAttribute());
			GlobalFilters.Filters.Add(new RavenSessionAttribute());

			// register routes
			RouteConfigurator.Initialise();

			// initialise structure map
			ObjectFactory.Initialize(ie => ie.AddRegistry<StructureMapConfigurationRegistry>());

			// register controller factory
			ControllerBuilder.Current.SetControllerFactory(typeof(StructureMapControllerFactory));

			// register adapter to force correct resource file resolution
			DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(RequiredAttribute), typeof(ResourceAwareRequiredAttributeAdapter));
		}
	}
}