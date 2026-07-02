using UnityEngine;

namespace BAPBAP.Local
{
	public abstract class SelectableResponse : ScriptableObject
	{
		public virtual void Initialize(ISelectable selectable)
		{
		}

		public virtual void GeneralUpdate(ISelectable selectable, float deltaTime)
		{
		}

		public virtual void OnSelect(ISelectable selectable)
		{
		}

		public virtual void OnDeselect(ISelectable selectable)
		{
		}

		public virtual void OnSelectUpdate(ISelectable selectable, float deltaTime)
		{
		}

		public virtual void OnHoverEnter(ISelectable selectable)
		{
		}

		public virtual void OnHoverExit(ISelectable selectable)
		{
		}

		public virtual void OnHoverUpdate(ISelectable selectable, float deltaTime)
		{
		}

		public SelectableResponse()
		{
		}
	}
}
