// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using Machine.Specifications;
using NovusCraft.Infrastructure;
using NovusCraft.Infrastructure.ActionFilters;
using NovusCraft.Infrastructure.ModelBinders;
using StructureMap;
using HandleErrorAttribute = NovusCraft.Infrastructure.Diagnostics.HandleErrorAttribute;

namespace NovusCraft.Specifications.InfrastructureSpecs.MvcApplicationSpecs
{
	[Subject(typeof(MvcApplication))]
	public class when_application_starts : mvc_application_spec
	{
		Because of = () => application.Application_Start();

		It should_add_handle_error_filter_to_global_filters =
			() => GlobalFilters.Filters.ShouldContain(f => f.Instance.GetType().Name == typeof(HandleErrorAttribute).Name);

		It should_add_raven_session_filter_to_global_filters =
			() => GlobalFilters.Filters.ShouldContain(f => f.Instance.GetType().Name == typeof(RavenSessionAttribute).Name);

		It should_register_mvc_routes =
			() => RouteTable.Routes.Count.ShouldBeGreaterThan(0);

		It should_register_automapper_mappings =
			() => Mapper.GetAllTypeMaps().Length.ShouldBeGreaterThan(0);

		// if current plugin instance count is greater than default plugin instance count, then StructureMap is initialised
		It should_initialise_structuremap_container =
			() => ObjectFactory.Model.AllInstances.Count().ShouldBeGreaterThan(new Container().Model.AllInstances.Count());

		It should_register_structuremap_controller_factory =
			() => ControllerBuilder.Current.GetControllerFactory().ShouldBeOfType<StructureMapControllerFactory>();

		It should_register_utc_datetimeoffset_model_binder =
			() => ModelBinders.Binders.Any(b => b.Key == typeof(DateTimeOffset) && b.Value.GetType() == typeof(UtcDateTimeOffsetModelBinder)).ShouldBeTrue();
	}
}