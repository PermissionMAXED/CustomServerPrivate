using System;
using System.Collections.Generic;
using BAPBAP.Localisation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class View_Career_Stats : View
	{
		public enum StatsTabs
		{
			Unranked = 0,
			Ranked = 1,
			FFA = 2
		}

		[Serializable]
		public class GameModeStatsPanel
		{
			public int UnityGameMode;

			public Transform ParentTransform;

			public TMP_Text HeaderText;

			public TMP_Text KDAText;

			public TMP_Text KillsText;

			public TMP_Text WinsText;
		}

		[Serializable]
		public class StatsWindowTabButton
		{
			public TMP_Text ButtonText;

			public MultiGraphicButton Button;
		}

		[SerializeField]
		public Button _bannerEditButton;

		[SerializeField]
		public Image _rankImageDisplay;

		[SerializeField]
		public TMP_Text _rankTitleText;

		[SerializeField]
		public TMP_Text _rankPointsText;

		[SerializeField]
		public Image _rankFillBar;

		[SerializeField]
		public TMP_Text _noStatsText;

		[SerializeField]
		public TMP_Text _noRankText;

		[SerializeField]
		public UIAlphaFade _rankPanelFade;

		[SerializeField]
		public UILobbyPlayerContainer _playerContainer;

		[SerializeField]
		public GameModeStatsPanel _duosPanel;

		[SerializeField]
		public GameModeStatsPanel _triosPanel;

		[SerializeField]
		public List<GameModeStatsPanel> _statsPanels;

		[SerializeField]
		public UILobbySubNavButton _unrankedTab;

		[SerializeField]
		public UILobbySubNavButton _rankedTab;

		[NonSerialized]
		public UILobbyProfileTabPage.Configuration _profileConfig;

		[NonSerialized]
		public UILobbyRankingsTabPage.Configuration _rankConfig;

		[NonSerialized]
		public ProfileModel _profileModel;

		[NonSerialized]
		public Translator _translator;

		[NonSerialized]
		public StatsTabs _currentTab;

		public void Initialise(ProfileModel profileModel)
		{
		}

		public void Build(UILobbyProfileTabPage.Configuration profileConfig, UILobbyRankingsTabPage.Configuration rankConfig)
		{
		}

		public void Localise(Translator translator)
		{
		}

		public void OpenPage()
		{
		}

		public void RefreshView()
		{
		}

		public void SelectTab(int tabIndex)
		{
		}

		public void SelectTab(StatsTabs tab, bool forceChange = false)
		{
		}

		public void UpdateDisplayedPlayerInfo()
		{
		}

		public void PopulateStats()
		{
		}
	}
}
