using System;
using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.UI
{
	[CreateAssetMenu(fileName = "UILobbyConfiguration", menuName = "BAPBAP/Configuration/UI/Lobby")]
	public class UILobbyConfiguration : ScriptableObject
	{
		[Serializable]
		public class PlatformVariant
		{
			public RuntimePlatform Platform;

			public UILobbyPlatformVariant Prefab;
		}

		[Serializable]
		public class DebugConfiguration
		{
			public bool OverridePlatform;

			public RuntimePlatform PlatformOverride;
		}

		[SerializeField]
		public UILobbyPlatformVariant _defaultVariantPrefab;

		[SerializeField]
		public PlatformVariant[] _variantPrefabs;

		[SerializeField]
		public DebugConfiguration _debugConfiguration;

		[SerializeField]
		public UILobbyTheme.Configuration _themeConfiguration;

		[SerializeField]
		public UILobbyPlatformVariant.Configuration _variantConfiguration;

		[SerializeField]
		public UILobbySplashScreen.Configuration _splashConfiguration;

		[NonSerialized]
		public Dictionary<RuntimePlatform, PlatformVariant> _variantLookup;

		public UILobbyPlatformVariant PrefabVariant => null;

		public UILobbyPlatformVariant.Configuration VariantConfiguration => null;

		public UILobbySplashScreen.Configuration SplashConfiguration => null;

		public UILobbyTheme.Configuration ThemeConfiguration => null;

		public void OnEnable()
		{
		}

		public void OnValidate()
		{
		}
	}
}
