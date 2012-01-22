// # Copyright © 2011, Novus Craft
// # All rights reserved. 

namespace NovusCraft.Data
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