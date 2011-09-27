using Machine.Specifications;
using NovusCraft.Web;

namespace NovusCraft.Specifications.WebSpecs.MvcApplicationSpecs
{
	public abstract class MvcApplicationSpec
	{
		protected static MvcApplication Application;

		Establish context = () => { Application = new MvcApplication(); };
	}
}