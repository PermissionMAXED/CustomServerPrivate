using System;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIThemeElementSelectable : UIThemeElement
	{
		[Serializable]
		public class ButtonPalette
		{
			public bool customColors;

			[ConditionalInverseHide("customColors", true)]
			public ColorPalette normalColorPalette;

			[ConditionalInverseHide("customColors", true)]
			public ColorPalette highlightedColorPalette;

			[ConditionalInverseHide("customColors", true)]
			public ColorPalette pressedColorPalette;

			[ConditionalInverseHide("customColors", true)]
			public ColorPalette selectedColorPalette;

			[ConditionalInverseHide("customColors", true)]
			public ColorPalette disabledColorPalette;

			[ConditionalHide("customColors", true)]
			public Color normalColor;

			[ConditionalHide("customColors", true)]
			public Color highlightedColor;

			[ConditionalHide("customColors", true)]
			public Color pressedColor;

			[ConditionalHide("customColors", true)]
			public Color selectedColor;

			[ConditionalHide("customColors", true)]
			public Color disabledColor;

			public ButtonPalette(ColorPalette normalColorPalette, ColorPalette highlightedColorPalette, ColorPalette pressedColorPalette, ColorPalette selectedColorPalette, ColorPalette disabledColorPalette)
			{
			}

			public ButtonPalette(Color normalColor, Color highlightedColor, Color pressedColor, Color selectedColor, Color disabledColor)
			{
			}
		}

		[SerializeField]
		[NamedArray(typeof(ThemeMode), 0)]
		public ButtonPalette[] themePaletteColor;

		[SerializeField]
		public Selectable selectable;

		[NonSerialized]
		public Color prevColor;

		[NonSerialized]
		public Color targetColor;

		public override void Start()
		{
		}

		public void Update()
		{
		}

		public override void SetThemeMode(ThemeMode mode, bool doFade)
		{
		}

		public void SetColorPaletteBlock(ButtonPalette buttonPalette)
		{
		}

		public void CrossFade(Color _targetColor)
		{
		}

		public void OnValidate()
		{
		}
	}
}
