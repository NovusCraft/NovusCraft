// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Web.Mvc;
using Raven.Client;
using StructureMap;

namespace NovusCraft.Web.Controllers
{
	public abstract class ControllerBase : Controller
	{
		protected override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			if (filterContext.IsChildAction)
				return;

			using (var documentSession = ObjectFactory.GetInstance<IDocumentSession>())
			{
				if (filterContext.Exception == null)
					documentSession.SaveChanges();
			}

			base.OnActionExecuted(filterContext);
		}
	}
}