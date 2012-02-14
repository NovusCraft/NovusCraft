// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using System.Web;
using System.Web.Mvc;
using Elmah;

namespace NovusCraft.Infrastructure.Diagnostics
{
	// From: http://stackoverflow.com/a/779961/169
	public class HandleErrorAttribute : System.Web.Mvc.HandleErrorAttribute
	{
		public override void OnException(ExceptionContext context)
		{
			base.OnException(context);

			var e = context.Exception;
			if (!context.ExceptionHandled // if unhandled, will be logged anyhow
			    || RaiseErrorSignal(e) // prefer signaling, if possible
			    || IsFiltered(context)) // filtered?
				return;

			LogException(e);
		}

		static bool RaiseErrorSignal(Exception e)
		{
			var context = HttpContext.Current;
			if (context == null)
				return false;

			var signal = ErrorSignal.FromContext(context);
			if (signal == null)
				return false;

			signal.Raise(e, context);
			return true;
		}

		static bool IsFiltered(ExceptionContext context)
		{
			var config = context.HttpContext.GetSection("elmah/errorFilter") as ErrorFilterConfiguration;

			if (config == null)
				return false;

			var testContext = new ErrorFilterModule.AssertionHelperContext(context.Exception, HttpContext.Current);
			return config.Assertion.Test(testContext);
		}

		static void LogException(Exception e)
		{
			var context = HttpContext.Current;
			ErrorLog.GetDefault(context).Log(new Error(e, context));
		}
	}
}