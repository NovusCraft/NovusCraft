// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using System.Web.Routing;
using Machine.Specifications;
using NovusCraft.Infrastructure;
using Raven.Client;
using StructureMap;

namespace NovusCraft.Specifications.InfrastructureSpecs.MvcApplicationSpecs
{
	public abstract class mvc_application_spec
	{
		protected static MvcApplication application;
		protected static bool areas_registered;

		Establish context = () => application = new MvcApplicationProxy();

		Cleanup after = () =>
		{
			RouteTable.Routes.Clear();

			var documentStore = ObjectFactory.GetInstance<IDocumentStore>();
			if (documentStore != null) documentStore.Dispose();
		};

		class MvcApplicationProxy : MvcApplication
		{
			protected override void RegisterAllAreas()
			{
				areas_registered = true;
			}
		}
	}
}