// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Web.Routing;
using Machine.Specifications;
using NovusCraft.Resources;
using NovusCraft.Specifications.WebSpecs.MvcApplicationSpecs;
using NovusCraft.Web.DataAnnotations;

namespace NovusCraft.Specifications.WebSpecs.DataAnnotationSpecs
{
	[Subject(typeof(RequiredAttribute))]
	public class when_instantiated : mvc_application_spec
	{
		static RequiredAttribute attribute;
		Because of = () => attribute = new RequiredAttribute();

		Cleanup after = () => RouteTable.Routes.Clear();

		It should_set_error_message_resource_type_to_validation_messages =
			() => attribute.ErrorMessageResourceType.ShouldEqual(typeof(ValidationMessages));

		It should_set_error_message_resource_name_to_property_value_required =
			() => attribute.ErrorMessageResourceName.ShouldEqual("PropertyValueRequired");
	}
}