// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using NovusCraft.Resources;

namespace NovusCraft.Web.DataAnnotations
{
	public class RequiredAttribute : System.ComponentModel.DataAnnotations.RequiredAttribute
	{
		public RequiredAttribute()
		{
			ErrorMessageResourceType = typeof(ValidationMessages);
			ErrorMessageResourceName = "PropertyValueRequired";
		}
	}
}