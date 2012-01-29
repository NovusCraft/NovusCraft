// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System.Diagnostics;

namespace NovusCraft.Infrastructure.Commands
{
	[DebuggerStepThrough]
	public sealed class DeleteBlogPostCommand : Command<int>
	{
		public DeleteBlogPostCommand(int model) : base(model)
		{
		}
	}
}