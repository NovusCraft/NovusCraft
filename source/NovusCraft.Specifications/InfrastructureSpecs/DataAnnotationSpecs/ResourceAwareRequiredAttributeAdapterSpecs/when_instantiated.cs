// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Machine.Specifications;
using NovusCraft.Infrastructure.DataAnnotations;
using NovusCraft.Resources;

namespace NovusCraft.Specifications.InfrastructureSpecs.DataAnnotationSpecs.ResourceAwareRequiredAttributeAdapterSpecs
{
	[Subject(typeof(ResourceAwareRequiredAttributeAdapter))]
	public class when_instantiated
	{
		static RequiredAttribute attribute;

		Because of = () =>
		{
			var modelMetadata = new ModelMetadata(new EmptyModelMetadataProvider(), null, null, typeof(object), null);
			var controllerContext = new ControllerContext();
			attribute = new RequiredAttribute();

			new ResourceAwareRequiredAttributeAdapter(modelMetadata, controllerContext, attribute);
		};

		It should_set_error_message_resource_type =
			() => attribute.ErrorMessageResourceType.ShouldEqual(typeof(ValidationMessages));

		It should_set_error_message_resource_name =
			() => attribute.ErrorMessageResourceName.ShouldEqual("PropertyValueRequired");
	}
}