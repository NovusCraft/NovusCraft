// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.ComponentModel.DataAnnotations;

namespace NovusCraft.Web.ViewModels
{
	public sealed class LogInModel
	{
		[DataAnnotations.Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[DataAnnotations.Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}