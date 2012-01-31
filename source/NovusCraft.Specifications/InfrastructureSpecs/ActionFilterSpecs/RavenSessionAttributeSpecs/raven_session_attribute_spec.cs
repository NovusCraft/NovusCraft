// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using Machine.Specifications;
using NovusCraft.Infrastructure.ActionFilters;
using NovusCraft.Specifications.SpecUtils;
using Raven.Client;
using StructureMap;

namespace NovusCraft.Specifications.InfrastructureSpecs.ActionFilterSpecs.RavenSessionAttributeSpecs
{
	public abstract class raven_session_attribute_spec
	{
		protected static RavenSessionAttribute attribute;

		Establish context = () =>
		{
			ObjectFactory.Container.Configure(c => c.For<IDocumentSession>().Singleton().Use(() =>
			{
				var session = Spec.RequiresRavenDBDocumentSession();
				session.Store(new { });

				return session;
			}));

			attribute = new RavenSessionAttribute();
		};
	}
}