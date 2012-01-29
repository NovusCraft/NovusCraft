// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using Machine.Specifications;
using NovusCraft.Web.Helpers;

namespace NovusCraft.Specifications.WebSpecs.HelperSpecs.UrlHelperSpecs
{
	[Subject(typeof(UrlHelpers))]
	public class when_permalink_is_created_without_parameters : url_helper_spec
	{
		static Uri permalink;

		Because of = () =>
		{
			route_data.Values.Add("controller", "Home");
			route_data.Values.Add("action", "RouteA");
			route_data.Values.Add("param1", "param1Value");

			permalink = helper.Permalink();
		};

		It should_return_absolute_url_created_using_context_information =
			() => permalink.ShouldEqual(new Uri("http://www.novuscraft.com/route-a/param1Value"));
	}
}