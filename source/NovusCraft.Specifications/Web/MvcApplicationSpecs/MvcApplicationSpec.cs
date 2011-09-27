using Machine.Specifications;
using NovusCraft.Web;

namespace NovusCraft.Specifications.Web.MvcApplicationSpecs
{
	public abstract class MvcApplicationSpec
	{
		protected static MvcApplication Application;

		Establish context = () => { Application = new MvcApplication(); };
	}
}