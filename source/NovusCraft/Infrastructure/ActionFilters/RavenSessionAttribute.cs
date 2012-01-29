// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using System.Web.Mvc;
using Raven.Client;
using StructureMap;

namespace NovusCraft.Infrastructure.ActionFilters
{
	[AttributeUsage(AttributeTargets.Class, Inherited = true)]
	public class RavenSessionAttribute : FilterAttribute, IActionFilter
	{
		#region IActionFilter Members

		public void OnActionExecuting(ActionExecutingContext filterContext)
		{
		}

		public void OnActionExecuted(ActionExecutedContext filterContext)
		{
			if (filterContext.Exception != null)
				return;

			using (var session = ObjectFactory.GetInstance<IDocumentSession>())
				session.SaveChanges();
		}

		#endregion
	}
}