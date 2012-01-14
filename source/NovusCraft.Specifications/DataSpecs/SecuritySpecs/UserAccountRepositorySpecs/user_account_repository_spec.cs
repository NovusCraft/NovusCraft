// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using Machine.Specifications;
using NovusCraft.Data.Security;
using Raven.Client;
using Raven.Client.Embedded;

namespace NovusCraft.Specifications.DataSpecs.SecuritySpecs.UserAccountRepositorySpecs
{
	public abstract class user_account_repository_spec
	{
		protected static UserAccountRepository repository;
		protected static EmbeddableDocumentStore document_store;
		protected static IDocumentSession document_session;

		Establish context = () =>
			{
				document_store = new EmbeddableDocumentStore { RunInMemory = true };
				document_store.Initialize();

				using (var session = document_store.OpenSession())
				{
					session.Store(new UserAccount
					              	{
					              		Email = "example@company.com",
					              		PasswordHash = "hash"
					              	});

					session.SaveChanges();
				}

				document_session = document_store.OpenSession();
				repository = new UserAccountRepository(document_session);
			};
	}
}