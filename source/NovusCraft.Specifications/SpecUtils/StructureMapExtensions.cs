// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using System.Linq;
using Machine.Specifications;
using StructureMap;

namespace NovusCraft.Specifications.SpecUtils
{
	[CLSCompliant(false)]
	public static class StructureMapExtensions
	{
		public static void ShouldContainSingletonPluginFor<TPlugin, TConcreteType>(this IContainer container) where TPlugin : class
		{
			VerifyPlugin<TPlugin, TConcreteType>(container, InstanceScope.Singleton);
		}

		public static void ShouldContainHybridPluginFor<TPlugin, TConcreteType>(this IContainer container) where TPlugin : class
		{
			VerifyPlugin<TPlugin, TConcreteType>(container, InstanceScope.Hybrid);
		}

		static void VerifyPlugin<TPlugin, TConcreteType>(IContainer container, InstanceScope scope) where TPlugin : class
		{
			var plugin = container.Model.PluginTypes.SingleOrDefault(pt => pt.PluginType == typeof(TPlugin));

			if (plugin == null)
				throw new SpecificationException(string.Format("Plugin {0} not registered.", typeof(TPlugin).FullName));

			if (plugin.Lifecycle != scope.ToString())
				throw new SpecificationException(string.Format("Expected lifecycle \"{0}\", actual lifecycle is \"{1}\".", scope.ToString(), plugin.Lifecycle));

			if (plugin.Default.ConcreteType != null)
			{
				// statically registered default instance type
				if (plugin.Default.ConcreteType != typeof(TConcreteType))
					throw new SpecificationException(string.Format("Expected concrete type \"{0}\", actual concrete type is \"{1}\".", typeof(TConcreteType).FullName, plugin.Default.ConcreteType.FullName));
			}
			else
			{
				// dynamically constructed instance type
				var instance = container.GetInstance<TPlugin>();
				if (instance.GetType() != typeof(TConcreteType))
					throw new SpecificationException(string.Format("Expected concrete type \"{0}\", actual concrete type is \"{1}\".", typeof(TConcreteType).FullName, instance.GetType().FullName));
			}
		}
	}
}