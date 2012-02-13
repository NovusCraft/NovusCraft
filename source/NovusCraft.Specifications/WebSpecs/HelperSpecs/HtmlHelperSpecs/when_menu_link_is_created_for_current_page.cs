// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Web.Mvc;
using Machine.Specifications;
using NovusCraft.Web.Helpers;

namespace NovusCraft.Specifications.WebSpecs.HelperSpecs.HtmlHelperSpecs
{
	[Subject(typeof(HtmlHelpers))]
	public class when_menu_link_is_created_for_current_page : html_helper_spec
	{
		static MvcHtmlString menu_link;

		Because of = () =>
		{
			route_data.Values["action"] = "RouteB";
			menu_link = helper.MenuLink("RouteB", "Home", "Test");
		};

		It should_return_anchor_html_with_css_class_active =
			() => menu_link.ToHtmlString().ShouldEqual("<a class=\"active\" href=\"/route-b\">Test</a>");
	}
}