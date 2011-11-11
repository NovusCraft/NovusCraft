// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using Machine.Specifications;
using NovusCraft.Specifications.WebSpecs.HelperSpecs.HtmlHelperSpecs;
using NovusCraft.Web.Utils;

namespace NovusCraft.Specifications.WebSpecs.UtilSpecs.FormatExtensionSpecs
{
	[Subject(typeof(FormatExtensions))]
	public class when_date_is_formatted_to_long_date : html_helper_spec
	{
		It should_return_formatted_long_date_for_day_1 =
			() => new DateTimeOffset(2011, 11, 1, 09, 08, 07, TimeSpan.FromHours(1)).ToLongDate().ShouldEqual("1st November 2011");

		It should_return_formatted_long_date_for_day_2 =
			() => new DateTimeOffset(2011, 11, 2, 09, 08, 07, TimeSpan.FromHours(1)).ToLongDate().ShouldEqual("2nd November 2011");

		It should_return_formatted_long_date_for_day_3 =
			() => new DateTimeOffset(2011, 11, 3, 09, 08, 07, TimeSpan.FromHours(1)).ToLongDate().ShouldEqual("3rd November 2011");

		It should_return_formatted_long_date_for_day_10 =
			() => new DateTimeOffset(2011, 11, 10, 09, 08, 07, TimeSpan.FromHours(1)).ToLongDate().ShouldEqual("10th November 2011");

		It should_return_formatted_long_date_for_day_11 =
			() => new DateTimeOffset(2011, 11, 11, 09, 08, 07, TimeSpan.FromHours(1)).ToLongDate().ShouldEqual("11th November 2011");
	}
}