namespace CommandUndoRedo
{
	public static class UndoRedoManager
	{
		public static UndoRedo undoRedo;

		public static int maxUndoStored
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public static void Clear()
		{
		}

		public static void Undo()
		{
		}

		public static void Redo()
		{
		}

		public static void Insert(ICommand command)
		{
		}

		public static void Execute(ICommand command)
		{
		}
	}
}
