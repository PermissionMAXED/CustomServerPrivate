using System;
using System.Collections.Generic;
using BAPBAP.Localisation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class View_Career_Leaderboard : View
	{
		public class Actions
		{
			public Action<int, int> LeaderboardRankAction;

			public Action<int, int> LeaderboardPageAction;

			public Action<int, int> LeaderboardFriendsAction;

			public Action<int> LeaderboardSelfAction;
		}

		[Header("Leaderboard Panel")]
		[SerializeField]
		public UIDropdown _gameModeDropdown;

		[SerializeField]
		public UIDropdown _characterDropdown;

		[SerializeField]
		public RectTransform _rankIconsParentTransform;

		[SerializeField]
		public Button _paginationPreviousButton;

		[SerializeField]
		public Button _paginationNextButton;

		[SerializeField]
		public Button _paginationFirstButton;

		[SerializeField]
		public Button _friendsLeaderboardButton;

		[SerializeField]
		public TMP_Text _nameLabelText;

		[SerializeField]
		public TMP_Text _killsLabelText;

		[SerializeField]
		public TMP_Text _winsLabelText;

		[SerializeField]
		public TMP_Text _rankTitleLabelText;

		[SerializeField]
		public TMP_Text _rankPointsLabelText;

		[SerializeField]
		public TMP_Text _noLeaderboardsFoundText;

		[SerializeField]
		public TMP_Text _paginationText;

		[SerializeField]
		public CustomScrollRect _scrollRect;

		[SerializeField]
		public Transform _entryParentTransform;

		[SerializeField]
		public RectTransform _viewportTransform;

		[SerializeField]
		public CanvasGroup _loaderCanvasGroup;

		[SerializeField]
		public UIAlphaFade _loaderAlphaFade;

		[SerializeField]
		public UIAlphaLoop _loaderAlphaLoop;

		[SerializeField]
		public CanvasGroup _contentsCanvasGroup;

		[SerializeField]
		public UIAlphaFade _contentsAlphaFade;

		[SerializeField]
		public UILobbyLeaderboardEntry _localPlayerEntry;

		[SerializeField]
		public UIToggle _friendsOnlyToggle;

		[SerializeField]
		[Header("Ranking Info Panel")]
		public CanvasGroup _rankInfoCanvasGroup;

		[SerializeField]
		public UIPosLerpFade _rankInfoLerpFade;

		[SerializeField]
		public UIAlphaFade _rankInfoAlphaFade;

		[SerializeField]
		public Image _rankImageDisplay;

		[SerializeField]
		public GameObject _obcImageDisplay;

		[SerializeField]
		public TMP_Text _rankText;

		[SerializeField]
		public TMP_Text _playerNameText;

		[SerializeField]
		public TMP_Text _rankTitleText;

		[SerializeField]
		public TMP_Text _rankPointsText;

		[SerializeField]
		public UILobbyPlayerContainer _playerContainer;

		[NonSerialized]
		public UIDropdown.DropdownOptionData[] _gameModeDropdownOptions;

		[NonSerialized]
		public UIDropdown.DropdownOptionData[] _characterDropdownOptions;

		[NonSerialized]
		public List<UILobbyRankIconEntry> _rankEntries;

		[NonSerialized]
		public UILobbyRankIconEntry.Pool _rankPool;

		[NonSerialized]
		public UILobbyRankIconEntry _selectedRankEntry;

		[NonSerialized]
		public List<UILobbyLeaderboardEntry> _leaderboardEntries;

		[NonSerialized]
		public UILobbyLeaderboardEntry.Pool _leaderboardPool;

		[NonSerialized]
		public UILobbyLeaderboardEntry _selectedLeaderboardEntry;

		[NonSerialized]
		public Translator _translator;

		[NonSerialized]
		public UILobbyRankingsTabPage.Configuration _rankConfig;

		[NonSerialized]
		public RankingsModel _rankingsModel;

		[NonSerialized]
		public Actions _actions;

		[NonSerialized]
		public int _selectedGameModeDataId;

		[NonSerialized]
		public int _selectedGameModeId;

		[NonSerialized]
		public int _selectedCharIndex;

		[NonSerialized]
		public int _selectedPage;

		[NonSerialized]
		public int _selectedRank;

		[NonSerialized]
		public int _selectedRankHigh;

		[NonSerialized]
		public int _divineRankId;

		[NonSerialized]
		public int _highRoyalLastTierRankLow;

		[NonSerialized]
		public string _rankStr;

		[NonSerialized]
		public string _rankPointsStr;

		[NonSerialized]
		public bool _isFriendsOnly;

		public void Build(UILobbyRankingsTabPage.Configuration configuration, Translator translator)
		{
		}

		public void Localise(Translator translator)
		{
		}

		public void SetActions(Actions actions)
		{
		}

		public void Initialise(RankingsModel data)
		{
		}

		public void OpenPage()
		{
		}

		public void UpdatePreview()
		{
		}

		public void UpdateData(RankingsModel data)
		{
		}

		public void UpdateSelfData(RankingsModel data)
		{
		}

		public void UpdateAvailableCharactersData()
		{
		}

		public void ToggleLeaderboardLoader(bool isEnabled)
		{
		}

		public void OnRankingButtonSelect(int rankId)
		{
		}

		public void OnLeaderboardEntrySelected(int leaderboardId)
		{
		}

		public void SelectLeaderboardEntry(UILobbyLeaderboardEntry entry, LeaderboardEntryModel entryData, bool scrollToContent = false)
		{
		}

		public void OnSelectGameModeButton(int gameModeIndex)
		{
		}

		public void OnSelectCharacterButton(int charIndex)
		{
		}

		public void OnFindPlayerButton()
		{
		}

		public void SelectGameMode(int gameModeIndex)
		{
		}

		public void SelectCharacter(int charIndex)
		{
		}

		public void SelectRank(int rankId)
		{
		}

		public void SelectPage(int page)
		{
		}

		public void SetPageText()
		{
		}

		public void SendLeaderboardRankUpdate()
		{
		}

		public void SendLeaderboardPageUpdate()
		{
		}

		public void SendLeaderboardSelfUpdate()
		{
		}

		public void PaginationPrevious()
		{
		}

		public void PaginationNext()
		{
		}

		public void PaginationFirst()
		{
		}

		public void ToggleFriendsOnly(bool toggle)
		{
		}

		public void ShowPlayerRankPanel()
		{
		}

		public void HidePlayerRankPanel()
		{
		}

		public void InitializePlayerRankPanel(string username, int bannerId, int level, int rankId, int tierId, int rankPosition, int rankPoints)
		{
		}

		public void GetRankIdAndTierIdFromRankPoints(int rankPoints, int position, out int rankId, out int tierId)
		{
			rankId = default(int);
			tierId = default(int);
		}

		public string GetRankTierName(int rankId, int tierId)
		{
			return null;
		}

		public int GetRankLocalPoints(int rankPoints, int rankId, int rankTierId)
		{
			return 0;
		}
	}
}
