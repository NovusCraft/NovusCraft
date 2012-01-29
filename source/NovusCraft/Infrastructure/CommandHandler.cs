// # Copyright � 2011, Novus Craft
// # All rights reserved. 

using Raven.Client;

namespace NovusCraft.Infrastructure
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