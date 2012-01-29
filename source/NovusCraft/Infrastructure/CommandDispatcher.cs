// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using StructureMap;

namespace NovusCraft.Infrastructure
{
	public sealed class CommandDispatcher
	{
		readonly IContainer _container;

		[CLSCompliant(false)]
		public CommandDispatcher(IContainer container)
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