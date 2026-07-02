using System;
using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UILobbyTheme : MonoBehaviour
	{
		[Serializable]
		public class Configuration
		{
			[NamedArray(typeof(ColorPalette), 0)]
			public Color[] paletteColors;

			public float fadeDuration;
		}

		[NonSerialized]
		public ThemeMode currentThemeMode;

		[NonSerialized]
		public List<UIThemeElement> themeModeElements;

		[NonSerialized]
		public Configuration _configuration;

		[SerializeField]
		public UILobbyConfiguration _lobbyConfiguration;

		public void PreAwake()
		{
		}

		public void AddElementAndSetThemeMode(UIThemeElement element)
		{
		}

		public void SetUIThemeMode(ThemeMode mode)
		{
		}

		public Color GetPaletteColor(ColorPalette palette)
		{
			return default(Color);
		}

		public float GetFadeDuration()
		{
			return 0f;
		}
	}
}
