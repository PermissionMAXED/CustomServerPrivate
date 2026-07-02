using System;
using UnityEngine;
using UnityEngine.UI;

public class MultiGraphicToggle : Toggle
{
	[Serializable]
	public class ToggleGraphicTransition
	{
		public Graphic graphic;

		public Color normalColor;

		public Color highlightedColor;

		public Color pressedColor;

		public Color selectedColor;

		public Color disabledColor;
	}

	[SerializeField]
	public ToggleGraphicTransition[] graphics;

	[SerializeField]
	public float fadeDuration;

	public override void DoStateTransition(SelectionState state, bool instant)
	{
	}
}
