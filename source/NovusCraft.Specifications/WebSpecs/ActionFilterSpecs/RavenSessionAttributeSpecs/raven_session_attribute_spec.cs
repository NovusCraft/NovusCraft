// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using Machine.Specifications;
using NovusCraft.Web.ActionFilters;

namespace NovusCraft.Specifications.WebSpecs.ActionFilterSpecs.RavenSessionAttributeSpecs
{
	public abstract class raven_session_attribute_spec
	{
		protected static RavenSessionAttribute attribute;

		Establish context = () => attribute = new RavenSessionAttribute();
	}
}