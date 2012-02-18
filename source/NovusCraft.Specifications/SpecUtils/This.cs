// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;

namespace NovusCraft.Specifications.SpecUtils
{
	public static class This
	{
		public static MethodInfo Action<TController>(Expression<Action<TController>> action) where TController : Controller
		{
			return ((MethodCallExpression)action.Body).Method;
		}
	}
}