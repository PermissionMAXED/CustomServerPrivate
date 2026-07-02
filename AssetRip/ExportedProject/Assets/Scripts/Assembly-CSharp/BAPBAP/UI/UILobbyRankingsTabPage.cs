using System;
using System.Collections.Generic;
using BAPBAP.Localisation;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UILobbyRankingsTabPage : UILobbyTabPage
	{
		public enum SubPage
		{
			Leaderboard = 0,
			History = 1,
			Stats = 2,
			RankInfo = 3
		}

		[Serializable]
		public class Configuration
		{
			public GameModesConfiguration GameModesConfig;

			public UICharactersConfiguration CharactersConfiguration;

			public UILobbyRankIconEntry.Configuration RankEntryConfiguration;

			public UILobbyLeaderboardEntry.Configuration LeaderboardEntryConfiguration;

			public GameObject RankIconDividerEntryPrefab;

			public string NoLeaderboardsFoundText;

			public string NameLabelTranslationKey;

			public string RankLabelTranslationKey;

			public string KillsLabelTranslationKey;

			public string WinsLabelTranslationKey;

			public string RankTranslationKey;

			public string RPTranslationKey;

			public int divineTopPosition;

			public int DefaultSelectedGameMode;
		}

		public class Actions
		{
			public Action sendStatsRequestAction;

			public Action<int, int> leaderboardRankAction;

			public Action<int, int> leaderboardPageAction;

			public Action<int> leaderboardSelfAction;
		}

		public View_Career_Leaderboard LeaderboardView;

		public View_Career_History HistoryView;

		public View_Career_Stats StatsView;

		[SerializeField]
		public List<UILobbySubNavButton> _subNavButtons;

		[SerializeField]
		public List<UIAlphaFade> _subPageAlphaFades;

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
		public RankingsModel _data;

		[NonSerialized]
		public Actions _actions;

		[NonSerialized]
		public SubPage _currentSubPage;

		public override CanvasGroup CanvasGroup => null;

		public override Selectable CanvasGroupSelectable => null;

		public override UIPosLerpFade UILerpFade => null;

		public override UIAlphaFade UIAlphaFade => null;

		public override UIAlphaFade backgroundUIFade => null;

		public void Build(Configuration configuration, UILobbyProfileTabPage.Configuration profileConfig, Translator translator)
		{
		}

		public override void Localise(Translator translator)
		{
		}

		public void SetActions(Actions actions)
		{
		}

		public void Initialise(RankingsModel data)
		{
		}

		public override void OnPageOpen()
		{
		}

		public void ChangeSubPage(int pageIndex)
		{
		}

		public void ChangeSubPage(SubPage page, bool forceChange = false)
		{
		}

		public void OnDisable()
		{
		}
	}
}
