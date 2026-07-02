using System;
using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.Local
{
	[CreateAssetMenu(menuName = "BAPBAP/Selectable/SelectableResponseFollowMouse")]
	public class SelectableResponseFollowMouse : SelectableResponse
	{
		public class MouseFollower
		{
			public Vector3 originalPosition;

			public Vector3 originalMousePosition;
		}

		public bool onHover;

		public bool onSelect;

		public float speed;

		public float maxDistance;

		public float minY;

		public float maxY;

		[NonSerialized]
		public Dictionary<ISelectable, MouseFollower> activeFollowers;

		public override void OnSelect(ISelectable selectable)
		{
		}

		public override void OnDeselect(ISelectable selectable)
		{
		}

		public override void OnHoverEnter(ISelectable selectable)
		{
		}

		public override void OnHoverExit(ISelectable selectable)
		{
		}

		public override void OnSelectUpdate(ISelectable selectable, float deltaTime)
		{
		}

		public override void OnHoverUpdate(ISelectable selectable, float deltaTime)
		{
		}

		public void SetRigidbodyState(ISelectable selectable, bool kinematic)
		{
		}

		public void AddFollower(ISelectable selectable)
		{
		}

		public void RemoveFollower(ISelectable selectable)
		{
		}

		public void UpdateFollowers()
		{
		}
	}
}
