// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using Raven.Client;

namespace NovusCraft.Data
{
	public abstract class CommandHandler<TCommand>
	{
		protected readonly IDocumentStore DocumentStore;

		protected CommandHandler(IDocumentStore documentStore)
		{
			DocumentStore = documentStore;
		}

		public abstract void Execute(TCommand command);
	}
}