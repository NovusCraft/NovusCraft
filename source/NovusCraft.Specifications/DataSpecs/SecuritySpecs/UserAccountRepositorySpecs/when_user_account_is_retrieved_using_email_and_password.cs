// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using Machine.Specifications;
using NovusCraft.Data.Security;

namespace NovusCraft.Specifications.DataSpecs.SecuritySpecs.UserAccountRepositorySpecs
{
	[Subject(typeof(UserAccountRepository))]
	public class when_user_account_is_retrieved_using_email_and_password : user_account_repository_spec
	{
		static UserAccount user_account;
		Because of = () => user_account = repository.GetUserByEmailAndPassword(email: "example@company.com", passwordHash: "hash");

		It should_return_user_account_with_email_example_at_company_dot_com =
			() => user_account.Email.ShouldEqual("example@company.com");
	}
}