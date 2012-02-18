// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using Raven.Client;

namespace NovusCraft.Infrastructure.Commands
{
	public abstract class CommandHandler<TCommand>
	{
		protected readonly IDocumentSession Session;

		protected CommandHandler(IDocumentSession session)
		{
			Session = session;
		}

		public abstract void Execute(TCommand command);
	}
}