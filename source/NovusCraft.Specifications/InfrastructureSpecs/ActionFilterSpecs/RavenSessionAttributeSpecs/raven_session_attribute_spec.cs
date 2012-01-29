// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using Machine.Specifications;
using NovusCraft.Infrastructure.ActionFilters;

namespace NovusCraft.Specifications.InfrastructureSpecs.ActionFilterSpecs.RavenSessionAttributeSpecs
{
	public abstract class raven_session_attribute_spec
	{
		protected static RavenSessionAttribute attribute;

		Establish context = () => attribute = new RavenSessionAttribute();
	}
}