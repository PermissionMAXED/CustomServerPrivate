using System;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIThemeElementColorPalette : UIThemeElement
	{
		[SerializeField]
		[NamedArray(typeof(ThemeMode), 0)]
		public ColorPalette[] themePaletteColor;

		[SerializeField]
		public Graphic graphic;

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

		public void CrossFade(Color _targetColor)
		{
		}

		public void OnValidate()
		{
		}
	}
}
