﻿// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using NovusCraft.Web.ViewModels;

namespace NovusCraft.Data.Security
{
	public interface IAccountManagementService
	{
		bool AuthenticateUser(LogInDetails logInDetails);
	}
}