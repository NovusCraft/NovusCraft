// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

namespace NovusCraft.Infrastructure
{
	public abstract class Command<TModel> : ICommand
	{
		protected Command(TModel model)
		{
			Model = model;
		}

		public TModel Model { get; private set; }
	}
}