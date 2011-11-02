// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Web.Mvc;
using Machine.Specifications;
using NovusCraft.Web;
using NovusCraft.Web.Helpers;

namespace NovusCraft.Specifications.WebSpecs.HelperSpecs
{
	[Subject(typeof(MvcApplication))]
	public class when_menu_link_is_created : html_helper_spec
	{
		static MvcHtmlString menu_link;
		Because of = () => menu_link = helper.MenuLink("RouteA", "Test", "test page");

		It should_return_anchor_html =
			() => menu_link.ToHtmlString().ShouldEqual("<a href=\"/route-a\" title=\"test page\">Test</a>");
	}
}