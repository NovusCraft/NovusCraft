// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using Machine.Specifications;
using NovusCraft.Specifications.WebSpecs.HelperSpecs.HtmlHelperSpecs;
using NovusCraft.Web.Utils;

namespace NovusCraft.Specifications.WebSpecs.UtilSpecs.FormatExtensionSpecs
{
	[Subject(typeof(FormatExtensions))]
	public class when_date_is_formatted_to_editor_long_datetime : html_helper_spec
	{
		It should_return_formatted_long_date_for_day_0_hours_0_minutes =
			() => new DateTimeOffset(2011, 11, 1, 0, 0, 0, TimeSpan.Zero).ToEditorLongDateTime().ShouldEqual("1 November 2011 00:00");

		It should_return_formatted_long_date_for_day_0_hours_1_minute =
			() => new DateTimeOffset(2011, 11, 1, 0, 1, 0, TimeSpan.Zero).ToEditorLongDateTime().ShouldEqual("1 November 2011 00:01");

		It should_return_formatted_long_date_for_day_1_hour_15_minutes =
			() => new DateTimeOffset(2011, 11, 1, 1, 15, 0, TimeSpan.Zero).ToEditorLongDateTime().ShouldEqual("1 November 2011 01:15");

		It should_return_formatted_long_date_for_day_23_hours_59_minutes =
			() => new DateTimeOffset(2011, 11, 1, 23, 59, 0, TimeSpan.Zero).ToEditorLongDateTime().ShouldEqual("1 November 2011 23:59");
	}
}