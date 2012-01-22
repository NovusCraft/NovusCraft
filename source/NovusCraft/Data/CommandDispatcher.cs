// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using StructureMap;

namespace NovusCraft.Data
{
	public sealed class CommandDispatcher
	{
		readonly Container _container;

		[CLSCompliant(false)]
		public CommandDispatcher(Container container)
		{
			_container = container;
		}

		public void Dispatch<TCommand>(TCommand command) where TCommand : ICommand
		{
			var commandHandlers = _container.GetAllInstances<CommandHandler<TCommand>>();

			foreach (var commandHandler in commandHandlers)
				commandHandler.Execute(command);
		}
	}
}