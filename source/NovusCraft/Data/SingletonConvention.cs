// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using StructureMap.TypeRules;

namespace NovusCraft.Data
{
	internal sealed class SingletonConvention : IRegistrationConvention
	{
		readonly Type _pluginFamily;

		public SingletonConvention(Type pluginFamily)
		{
			_pluginFamily = pluginFamily;
		}

		#region IRegistrationConvention Members

		public void Process(Type type, Registry registry)
		{
			if (!type.IsConcrete() || !type.CanBeCreated() || !type.Closes(_pluginFamily))
				return;

			registry.For(type.BaseType).Singleton().Use(type);
		}

		#endregion
	}
}