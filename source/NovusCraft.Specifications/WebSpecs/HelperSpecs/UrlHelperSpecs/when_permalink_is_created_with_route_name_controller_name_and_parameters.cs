// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using System;
using Machine.Specifications;
using NovusCraft.Web.Helpers;

namespace NovusCraft.Specifications.WebSpecs.HelperSpecs.UrlHelperSpecs
{
	[Subject(typeof(UrlHelpers))]
	public class when_permalink_is_created_with_route_name_controller_name_and_parameters : url_helper_spec
	{
		static Uri permalink;
		Because of = () => permalink = helper.Permalink("RouteA", "Home", new { param1 = "param1Value" });

		It should_return_absolute_url =
			() => permalink.ShouldEqual(new Uri("http://www.novuscraft.com/route-a/param1Value"));
	}
}