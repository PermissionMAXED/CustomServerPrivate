using System;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIThemeElementColor : UIThemeElement
	{
		[SerializeField]
		public bool applyAlpha;

		[SerializeField]
		[NamedArray(typeof(ThemeMode), 0)]
		public Color[] themeColor;

		[Tooltip("The graphic to perform the theme mode to. If null, will default to any existing graphic component in this object")]
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
