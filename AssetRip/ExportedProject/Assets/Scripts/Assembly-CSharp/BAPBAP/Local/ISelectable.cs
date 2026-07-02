using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public interface ISelectable
	{
		Action OnSelected { get; set; }

		void Select();

		void HoverEnter();

		void HoverExit();

		void Deselect();

		bool CanSelect();

		GameObject GetGameObject();

		float GetSelectionTime();

		void OnSelectUpdate(float deltaTime);

		void OnHoverUpdate(float deltaTime);
	}
}
