using System;
using UnityEngine;
using UnityEngine.UI;

public class MultiGraphicButton : Button
{
	[Serializable]
	public class ButtonGraphicTransition
	{
		public Graphic graphic;

		public Color normalColor;

		public Color highlightedColor;

		public Color pressedColor;

		public Color selectedColor;

		public Color disabledColor;
	}

	[SerializeField]
	public ButtonGraphicTransition[] graphics;

	[SerializeField]
	public float fadeDuration;

	public override void DoStateTransition(SelectionState state, bool instant)
	{
	}

	public override void InstantClearState()
	{
	}

	public void TriggerClickUI()
	{
	}
}
