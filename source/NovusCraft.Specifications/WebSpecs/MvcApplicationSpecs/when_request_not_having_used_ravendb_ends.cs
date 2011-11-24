// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using Machine.Specifications;
using Moq;
using NovusCraft.Web;
using Raven.Client;
using StructureMap;
using It = Machine.Specifications.It;

namespace NovusCraft.Specifications.WebSpecs.MvcApplicationSpecs
{
	[Subject(typeof(MvcApplication))]
	public class when_request_not_having_used_ravendb_ends : mvc_application_spec
	{
		static Mock<IDocumentSession> document_session;

		Because of = () =>
			{
				document_session = new Mock<IDocumentSession>();
				ObjectFactory.Initialize(i => i.For<IDocumentSession>().Use(document_session.Object));

				application.Application_EndRequest();
			};

		Cleanup after = () => ObjectFactory.ResetDefaults();

		It should_dispose_document_session =
			() => document_session.Verify(ds => ds.Dispose(), Times.Never());

		It should_save_document_session_changes =
			() => document_session.Verify(ds => ds.SaveChanges(), Times.Never());
	}
}