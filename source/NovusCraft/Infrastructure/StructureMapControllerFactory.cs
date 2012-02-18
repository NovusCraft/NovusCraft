// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using System;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;

namespace NovusCraft.Infrastructure
{
	public class StructureMapControllerFactory : DefaultControllerFactory
	{
		protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
		{
			return ObjectFactory.GetInstance(controllerType) as Controller;
		}
	}
}