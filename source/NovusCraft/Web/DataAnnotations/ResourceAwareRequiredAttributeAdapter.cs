// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using NovusCraft.Resources;

namespace NovusCraft.Web.DataAnnotations
{
	public sealed class ResourceAwareRequiredAttributeAdapter : RequiredAttributeAdapter
	{
		public ResourceAwareRequiredAttributeAdapter(ModelMetadata metadata, ControllerContext context, RequiredAttribute attribute) : base(metadata, context, attribute)
		{
			attribute.ErrorMessageResourceType = typeof(ValidationMessages);
			attribute.ErrorMessageResourceName = "PropertyValueRequired";
		}
	}
}