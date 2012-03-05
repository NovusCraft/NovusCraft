// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using System.Web.Mvc;
using System.Web.Routing;
using NovusCraft.Infrastructure;
using NovusCraft.Infrastructure.AreaRegistrations;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Embedded;
using Raven.Client.Indexes;
using StructureMap;

namespace NovusCraft.Specifications.SpecUtils
{
	public static class Spec
	{
		public static void RequiresAutoMapperConfiguration()
		{
			AutoMapperConfigurator.Initialise();
		}

		public static void RequiresRoutes()
		{
			var publicAreaRegistration = new PublicAreaRegistration();
			publicAreaRegistration.RegisterArea(new AreaRegistrationContext(publicAreaRegistration.AreaName, RouteTable.Routes));

			var dashboardAreaRegistration = new DashboardAreaRegistration();
			dashboardAreaRegistration.RegisterArea(new AreaRegistrationContext(dashboardAreaRegistration.AreaName, RouteTable.Routes));

			RouteConfigurator.Initialise();
		}

		public static IDocumentSession ContextDocumentSession
		{
			get { return ObjectFactory.Container.GetInstance<IDocumentSession>(); }
		}

		public static IDocumentSession RequiresRavenDBDocumentSession()
		{
			var documentStore = RequiresRavenDBDocumentStore();
			return documentStore.OpenSession();
		}

		public static EmbeddableDocumentStore RequiresRavenDBDocumentStore()
		{
			var documentStore = new EmbeddableDocumentStore { RunInMemory = true, Conventions = new DocumentConvention { DefaultQueryingConsistency = ConsistencyOptions.QueryYourWrites } };
			documentStore.Initialize();

			IndexCreation.CreateIndexes(typeof(DocumentStoreFactory).Assembly, documentStore);

			return documentStore;
		}
	}
}