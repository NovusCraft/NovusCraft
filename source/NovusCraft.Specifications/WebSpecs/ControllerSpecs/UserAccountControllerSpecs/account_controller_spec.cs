// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using Machine.Specifications;
using Moq;
using NovusCraft.Security;
using NovusCraft.Web.Controllers;
using Raven.Client.Embedded;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.UserAccountControllerSpecs
{
	public abstract class account_controller_spec
	{
		protected static UserAccountController controller;
		protected static Mock<IAuthenticationService> authentication_service;
		protected static EmbeddableDocumentStore document_store;
		protected static Mock<IFormsAuthenticationWrapper> forms_authentication_wrapper;

		Establish context = () =>
			{
				authentication_service = new Mock<IAuthenticationService>();

				forms_authentication_wrapper = new Mock<IFormsAuthenticationWrapper>();

				document_store = new EmbeddableDocumentStore { RunInMemory = true };
				document_store.Initialize();

				var session = document_store.OpenSession();

				controller = new UserAccountController(authentication_service.Object, session, forms_authentication_wrapper.Object);
			};
	}
}