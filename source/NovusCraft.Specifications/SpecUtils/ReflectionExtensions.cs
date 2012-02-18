// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using System;
using System.Reflection;
using Machine.Specifications;

namespace NovusCraft.Specifications.SpecUtils
{
	public static class ReflectionExtensions
	{
		public static void ShouldBeDecoratedWith<TAttribute>(this MethodInfo method) where TAttribute : Attribute
		{
			method.IsDefined(typeof(TAttribute), inherit: false).ShouldBeTrue();
		}

		public static T Property<T>(this object source, string propertyName)
		{
			return (T)source.GetType().GetProperty(propertyName).GetValue(source, null);
		}
	}
}