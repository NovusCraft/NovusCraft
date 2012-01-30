// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using Machine.Specifications;
using Moq;
using NovusCraft.Infrastructure;
using NovusCraft.Security;
using NovusCraft.Web.Controllers;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Embedded;
using Raven.Client.Indexes;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.UserAccountControllerSpecs
{
	public abstract class account_controller_spec
	{
		protected static UserAccountController controller;
		protected static EmbeddableDocumentStore document_store;
		protected static IDocumentSession session;
		protected static Mock<IFormsAuthenticationWrapper> forms_authentication_wrapper;

		Establish context = () =>
		{
			forms_authentication_wrapper = new Mock<IFormsAuthenticationWrapper>();

			document_store = new EmbeddableDocumentStore { RunInMemory = true, Conventions = new DocumentConvention { DefaultQueryingConsistency = ConsistencyOptions.QueryYourWrites } };
			document_store.Initialize();

			IndexCreation.CreateIndexes(typeof(DocumentStoreFactory).Assembly, document_store);

			session = document_store.OpenSession();

			controller = new UserAccountController(session, forms_authentication_wrapper.Object);
		};
	}
}