namespace LevelEditor
{
	public class Tool
	{
		public static bool toolIsEnabled;

		public virtual void OnToolSelected()
		{
		}

		public virtual void OnToolUnselected()
		{
		}

		public virtual void OnMousePressed()
		{
		}

		public virtual void OnMouseHold()
		{
		}

		public virtual void OnMouseReleased()
		{
		}

		public virtual void OnInputKeyPressed()
		{
		}

		public virtual void OnToolInterrupted()
		{
		}

		public virtual void OnUpdate()
		{
		}

		public virtual void OnUndoRedo()
		{
		}

		public virtual void OnToolGUI()
		{
		}
	}
}
