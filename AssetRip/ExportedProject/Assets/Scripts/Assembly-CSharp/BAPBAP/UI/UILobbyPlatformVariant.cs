using System;
using BAPBAP.Localisation;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UILobbyPlatformVariant : MonoBehaviour
	{
		[Serializable]
		public class LogoButton
		{
			public Button Button;

			public Image Logo;
		}

		[Serializable]
		public class Configuration
		{
			public UILobbyTabGroup.Configuration TabGroup;
		}

		[Serializable]
		public class Background
		{
			public bool is3d;

			public UI3DBackground background3DPrefab;

			public GameObject background2d;

			[NonSerialized]
			public UI3DBackground background3DInstance;

			public UI3DBackground Background3DInstance => null;

			public void DestroyInstance()
			{
			}
		}

		[SerializeField]
		public string _name;

		[SerializeField]
		public Background _background;

		[SerializeField]
		public LogoButton _logoButton;

		[SerializeField]
		public UILobbyTabGroup _tabGroup;

		[NonSerialized]
		public Configuration _configuration;

		[NonSerialized]
		public Translator _translator;

		public UILobbyTabGroup Tabs => null;

		public void Build(Configuration configuration, Translator translator)
		{
		}

		public void OnEnable()
		{
		}

		public void OnDisable()
		{
		}

		public void Localise(Translator translator)
		{
		}
	}
}
