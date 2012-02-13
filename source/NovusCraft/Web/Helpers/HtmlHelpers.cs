// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace NovusCraft.Web.Helpers
{
	public static class HtmlHelpers
	{
		public static MvcHtmlString MenuLink(this HtmlHelper<dynamic> html, string actionName, string controllerName, string linkText)
		{
			var htmlAttributes = new object();
			var contextActionName = html.ViewContext.RouteData.Values["action"] ?? string.Empty;
			if (string.Compare(contextActionName.ToString(), actionName, StringComparison.OrdinalIgnoreCase) == 0)
				htmlAttributes = new { @class = "active" };
			
			return html.ActionLink(linkText, actionName, controllerName, null, htmlAttributes);
		}
	}
}