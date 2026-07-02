using System;
using System.Collections.Generic;

namespace CommandUndoRedo
{
	public class CommandGroup : ICommand
	{
		[NonSerialized]
		public List<ICommand> commands;

		public CommandGroup()
		{
		}

		public CommandGroup(List<ICommand> commands)
		{
		}

		public void Set(List<ICommand> commands)
		{
		}

		public void Add(ICommand command)
		{
		}

		public void Remove(ICommand command)
		{
		}

		public void Clear()
		{
		}

		public void Execute()
		{
		}

		public void UnExecute()
		{
		}
	}
}
