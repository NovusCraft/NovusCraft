// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Machine.Specifications;
using NovusCraft.Resources;
using NovusCraft.Web.DataAnnotations;

namespace NovusCraft.Specifications.WebSpecs.DataAnnotationSpecs.ResourceAwareRequiredAttributeAdapterSpecs
{
	[Subject(typeof(ResourceAwareRequiredAttributeAdapter))]
	public class when_instantiated
	{
		static RequiredAttribute attribute;

		Because of = () =>
			{
				var modelMetadata = new ModelMetadata(new EmptyModelMetadataProvider(), null, null, typeof(object), null);
				attribute = new RequiredAttribute();
				var controllerContext = new ControllerContext();
				new ResourceAwareRequiredAttributeAdapter(modelMetadata, controllerContext, attribute);
			};

		It should_set_error_message_resource_type =
			() => attribute.ErrorMessageResourceType.ShouldEqual(typeof(ValidationMessages));

		It should_set_error_message_resource_name =
			() => attribute.ErrorMessageResourceName.ShouldEqual("PropertyValueRequired");
	}
}