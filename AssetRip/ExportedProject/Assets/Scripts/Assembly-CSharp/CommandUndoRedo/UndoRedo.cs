using System;

namespace CommandUndoRedo
{
	public class UndoRedo
	{
		[NonSerialized]
		public DropoutStack<ICommand> undoCommands;

		[NonSerialized]
		public DropoutStack<ICommand> redoCommands;

		public int maxUndoStored
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public UndoRedo()
		{
		}

		public UndoRedo(int maxUndoStored)
		{
		}

		public void Clear()
		{
		}

		public void Undo()
		{
		}

		public void Redo()
		{
		}

		public void Insert(ICommand command)
		{
		}

		public void Execute(ICommand command)
		{
		}

		public void SetMaxLength(int max)
		{
		}
	}
}
