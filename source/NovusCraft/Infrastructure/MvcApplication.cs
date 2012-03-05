// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using NovusCraft.Infrastructure.ActionFilters;
using NovusCraft.Infrastructure.DataAnnotations;
using NovusCraft.Infrastructure.ModelBinders;
using StructureMap;
using HandleErrorAttribute = NovusCraft.Infrastructure.Diagnostics.HandleErrorAttribute;

namespace NovusCraft.Infrastructure
{
	public class MvcApplication : HttpApplication
	{
		public void Application_Start()
		{
			// register global filters
			GlobalFilters.Filters.Add(new HandleErrorAttribute());
			GlobalFilters.Filters.Add(new RavenSessionAttribute());

			// register areas
			RegisterAllAreas();

			// register routes
			RouteConfigurator.Initialise();

			// register AutoMapper mappings
			AutoMapperConfigurator.Initialise();

			// initialise StructureMap
			ObjectFactory.Initialize(ie => ie.AddRegistry<StructureMapConfigurationRegistry>());

			// register controller factory
			ControllerBuilder.Current.SetControllerFactory(typeof(StructureMapControllerFactory));

			// register adapter to force correct resource file resolution
			DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(RequiredAttribute), typeof(ResourceAwareRequiredAttributeAdapter));

			// registed custom model binders
			System.Web.Mvc.ModelBinders.Binders.Add(typeof(DateTimeOffset), new UtcDateTimeOffsetModelBinder());
		}

		protected virtual void RegisterAllAreas()
		{
			AreaRegistration.RegisterAllAreas();
		}
	}
}