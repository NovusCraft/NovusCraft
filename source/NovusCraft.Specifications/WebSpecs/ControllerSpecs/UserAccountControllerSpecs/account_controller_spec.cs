// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using Machine.Specifications;
using Moq;
using NovusCraft.Security;
using NovusCraft.Specifications.SpecUtils;
using NovusCraft.Web.Controllers;
using Raven.Client;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.UserAccountControllerSpecs
{
	public abstract class account_controller_spec
	{
		protected static UserAccountController controller;
		protected static IDocumentSession session;
		protected static Mock<IFormsAuthenticationWrapper> forms_authentication_wrapper;

		Establish context = () =>
		{
			forms_authentication_wrapper = new Mock<IFormsAuthenticationWrapper>();

			var documentStore = Spec.RequiresRavenDBDocumentStore();
			session = documentStore.OpenSession();

			controller = new UserAccountController(session, forms_authentication_wrapper.Object);
		};
	}
}