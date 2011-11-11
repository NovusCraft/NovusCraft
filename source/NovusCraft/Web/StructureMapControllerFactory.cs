// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;

namespace NovusCraft.Web
{
	public sealed class StructureMapControllerFactory : DefaultControllerFactory
	{
		protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
		{
			return ObjectFactory.GetInstance(controllerType) as Controller;
		}
	}
}