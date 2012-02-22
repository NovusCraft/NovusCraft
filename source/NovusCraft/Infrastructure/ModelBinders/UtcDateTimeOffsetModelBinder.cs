// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using System;
using System.Web.Mvc;

namespace NovusCraft.Infrastructure.ModelBinders
{
	public class UtcDateTimeOffsetModelBinder : IModelBinder
	{
		#region IModelBinder Members

		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
			var output = (DateTimeOffset)valueProviderResult.ConvertTo(typeof(DateTimeOffset));

			return output.ToUniversalTime();
		}

		#endregion
	}
}