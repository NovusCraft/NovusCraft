// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;

namespace NovusCraft.Specifications.Utils
{
	public static class This
	{
		public static MethodInfo Action<TController>(Expression<Action<TController>> action) where TController : Controller
		{
			return ((MethodCallExpression)action.Body).Method;
		}
	}
}