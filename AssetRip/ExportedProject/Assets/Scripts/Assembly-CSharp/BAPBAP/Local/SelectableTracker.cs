using System.Collections.Generic;

namespace BAPBAP.Local
{
	public class SelectableTracker
	{
		public class ActiveSelectable
		{
			public ISelectable selectable;

			public float selectionTime;
		}

		public List<ActiveSelectable> activeSelectables;

		public void Select(ISelectable selectable)
		{
		}

		public void UpdateSelectables(float deltaTime)
		{
		}

		public void Deselect(ISelectable selectable)
		{
		}

		public void ClearSelectables()
		{
		}
	}
}
