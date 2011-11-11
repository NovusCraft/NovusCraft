// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;

namespace NovusCraft.Web.Utils
{
	public static class FormatExtensions
	{
		public static string ToIsoDate(this DateTimeOffset date)
		{
			return date.ToString("yyyy-MM-ddTHH:mm:sszzz");
		}

		public static string ToLongDate(this DateTimeOffset date)
		{
			return string.Format("{0:%d}{1} {0:MMMM} {0:yyyy}", date, GetDaySuffix(date.Day));
		}

		static object GetDaySuffix(int dayNumber)
		{
			switch (dayNumber % 100)
			{
				case 11:
				case 12:
				case 13:
					return "th";
			}

			switch (dayNumber % 10)
			{
				case 1:
					return "st";
				case 2:
					return "nd";
				case 3:
					return "rd";
				default:
					return "th";
			}
		}
	}
}