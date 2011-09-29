using Machine.Specifications;
using NovusCraft.Web;

namespace NovusCraft.Specifications.WebSpecs.MvcApplicationSpecs
{
	public abstract class mvc_application_spec
	{
		protected static MvcApplication application;

		Establish context = () => { application = new MvcApplication(); };
	}
}