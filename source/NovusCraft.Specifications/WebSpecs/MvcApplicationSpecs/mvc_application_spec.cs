// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Web.Routing;
using Machine.Specifications;
using NovusCraft.Web;
using Raven.Client;
using StructureMap;

namespace NovusCraft.Specifications.WebSpecs.MvcApplicationSpecs
{
	public abstract class mvc_application_spec
	{
		protected static MvcApplication application;

		Establish context = () => { application = new MvcApplication(); };

		Cleanup after = () =>
			{
				RouteTable.Routes.Clear();

				var documentStore = ObjectFactory.GetInstance<IDocumentStore>();
				if (documentStore != null) documentStore.Dispose();
			};
	}
}