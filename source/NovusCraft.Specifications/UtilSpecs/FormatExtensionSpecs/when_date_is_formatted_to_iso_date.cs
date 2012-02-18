// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using System;
using Machine.Specifications;
using NovusCraft.Specifications.WebSpecs.HelperSpecs.HtmlHelperSpecs;
using NovusCraft.Utils;

namespace NovusCraft.Specifications.UtilSpecs.FormatExtensionSpecs
{
	[Subject(typeof(FormatExtensions))]
	public class when_date_is_formatted_to_iso_date : html_helper_spec
	{
		It should_return_date_in_iso_format =
			() => new DateTimeOffset(2011, 11, 1, 09, 08, 07, TimeSpan.FromHours(1)).ToIsoDate().ShouldEqual("2011-11-01T09:08:07+01:00");
	}
}