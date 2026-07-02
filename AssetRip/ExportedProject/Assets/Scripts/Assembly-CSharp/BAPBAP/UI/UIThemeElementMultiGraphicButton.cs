using System;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UIThemeElementMultiGraphicButton : UIThemeElement
	{
		[Serializable]
		public class ButtonGraphicPalette
		{
			public ButtonPalette[] buttonPalettes;
		}

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

		[NamedArray(typeof(ThemeMode), 0)]
		[SerializeField]
		public ButtonGraphicPalette[] themeGraphicsPalette;

		[SerializeField]
		public MultiGraphicButton multiGraphicButton;

		[NonSerialized]
		public Color[] prevColor;

		[NonSerialized]
		public Color[] targetColor;

		public override void Start()
		{
		}

		public void Update()
		{
		}

		public override void SetThemeMode(ThemeMode mode, bool doFade)
		{
		}

		public void SetColorPaletteBlock(ButtonGraphicPalette graphicPalette)
		{
		}

		public void CrossFade()
		{
		}

		public void SetGraphicButtonColor(MultiGraphicButton.ButtonGraphicTransition graphicTransition, Color newCol)
		{
		}

		public void OnValidate()
		{
		}
	}
}
