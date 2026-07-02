using System;
using TMPro;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UIThemeElementInputFieldPalette : UIThemeElement
	{
		[NamedArray(typeof(ThemeMode), 0)]
		[SerializeField]
		public ColorPalette[] themePaletteColor;

		[SerializeField]
		public TMP_InputField inputField;

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
