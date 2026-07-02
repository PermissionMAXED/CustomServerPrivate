using System;
using BAPBAP.Content;
using BAPBAP.Localisation;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UILobbyProfileTabPage : UILobbyTabPage
	{
		public class Actions
		{
			public Action SendProfileRequestAction;

			public Action LogoutAction;
		}

		[Serializable]
		public class Configuration
		{
			public UICharactersConfiguration CharacterConfig;

			public GameModesConfiguration GameModesConfiguration;

			public PlayerBannerData PlayerBannerData;

			public string LogoutButtonTranslationKey;

			public string HistoryTitleTranslationKey;

			public string NoHistoryTranslationKey;

			public UILobbyStatsEntry.Configuration StatsEntryConfiguration;

			public UILobbyHistoryEntry.Configuration HistoryEntryConfiguration;
		}

		[SerializeField]
		public CanvasGroup _canvasGroup;

		[SerializeField]
		public Selectable _canvasGroupSelectable;

		[SerializeField]
		public UIPosLerpFade _uiLerpFade;

		[SerializeField]
		public UIAlphaFade _uiAlphaFade;

		[SerializeField]
		public UIAlphaFade _backgroundUIFade;

		[NonSerialized]
		public Translator _translator;

		[NonSerialized]
		public Configuration _configuration;

		[NonSerialized]
		public Actions _actions;

		[NonSerialized]
		public ProfileModel _profileModel;

		public View_Lobby_Profile ProfileView;

		public override CanvasGroup CanvasGroup => null;

		public override Selectable CanvasGroupSelectable => null;

		public override UIPosLerpFade UILerpFade => null;

		public override UIAlphaFade UIAlphaFade => null;

		public override UIAlphaFade backgroundUIFade => null;

		public void FixedUpdate()
		{
		}

		public void Build(Configuration configuration, Translator translator)
		{
		}

		public override void Localise(Translator translator)
		{
		}

		public void SetActions(Actions actions)
		{
		}

		public void Initialise(ProfileModel data)
		{
		}

		public override void OnPageOpen()
		{
		}

		public void UpdatePlayerBanner(int bannerAssetId, PlayerBanner banner)
		{
		}

		public void Logout()
		{
		}
	}
}
