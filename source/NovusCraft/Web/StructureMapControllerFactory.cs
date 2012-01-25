// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using System.Web.Mvc;
using System.Web.Routing;
using Raven.Client;
using StructureMap;

namespace NovusCraft.Web
{
	public class StructureMapControllerFactory : DefaultControllerFactory
	{
		protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
		{
			var defaultContainer = ObjectFactory.Container;
			var documentStore = defaultContainer.GetInstance<IDocumentStore>();
			var session = documentStore.OpenSession();

			defaultContainer.Configure(c => c.For<IDocumentSession>().HybridHttpOrThreadLocalScoped().Use(session));

			return ObjectFactory.GetInstance(controllerType) as Controller;
		}
	}
}