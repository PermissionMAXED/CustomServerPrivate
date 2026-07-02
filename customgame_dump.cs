using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI;

public class View_Lobby_CustomGame : View
{
	public class Actions
	{
		public Action<PlayerModel, int> TeamJoinAction;

		public Action<string, CustomGameSettingsModel> SettingsUpdated;

		public Action<bool> ReadyButtonAction;

		public Action<bool> UnreadyButtonAction;

		public Action<bool> StartGameAction;

		public Action<string, bool> LeaveLobby;
	}

	[NonSerialized]
	public UIManager _uiManager;

	public GameObject Root;

	public CustomLobbyConfig Config;

	[SerializeField]
	public CanvasGroup _mainCanvasGroup;

	[SerializeField]
	public UIAlphaFade _uiAlphaFade;

	[SerializeField]
	public UIAlphaFade _backgroundOnEnable;

	[SerializeField]
	public GameObject _startingGameContainer;

	[SerializeField]
	public GameObject _readyButtonsContainer;

	[SerializeField]
	public int _numberOfTeams;

	[SerializeField]
	public UICustomLobbyTeam _teamPrefab;

	[SerializeField]
	public Transform _teamsParent;

	[SerializeField]
	public Button _spectatorButton;

	[SerializeField]
	public Button _startGameButton;

	[SerializeField]
	public Button _readyButton;

	[SerializeField]
	public Button _unreadyButton;

	[SerializeField]
	public Button _leaveLobbyButton;

	[SerializeField]
	public Button _inviteFriendButton;

	[SerializeField]
	public CustomTMP_Dropdown _unityGameModeDropdown;

	[SerializeField]
	public CustomTMP_Dropdown _levelDropdown;

	[SerializeField]
	public CustomTMP_Dropdown _teamSizeDropdown;

	[SerializeField]
	public CustomTMP_Dropdown _regionDropdown;

	[SerializeField]
	public InputField _maxBotsTeamsField;

	[SerializeField]
	public CustomTMP_Dropdown _botDifficultyDropdown;

	[NonSerialized]
	public readonly List<int> _levelDropdownToLevelListIds;

	[NonSerialized]
	public readonly List<UICustomLobbyTeam> _spawnedTeamPrefabs;

	[NonSerialized]
	public readonly Dictionary<PlayerModel, int> _playersTeamsMapping;

	[NonSerialized]
	public Actions _actions;

	[NonSerialized]
	public LobbyDataModel _lobbyDataModel;

	[NonSerialized]
	public CustomGameSettingsModel _settingsModel;

	[NonSerialized]
	public Dictionary<int, int[]> _cachedMapMapping;

	public bool IsOpen { get; set; }

	public void Initialize(LobbyDataModel lobbyDataModel, CustomGameSettingsModel settingsModel)
	{
	}

	public void SetActions(Actions actions)
	{
	}

	public void OpenCustomGameLobby()
	{
	}

	public void CloseCustomGameLobby()
	{
	}

	public void ClearLobbyEntries()
	{
	}

	public void OnStartMatchNowButton()
	{
	}

	public void OnTeamJoinButton(int teamIndex)
	{
	}

	public void OnStartCustomGameButton()
	{
	}

	public void OpenForceStartModal()
	{
	}

	public void OnReadyButton()
	{
	}

	public void OnUnreadyButton()
	{
	}

	public void OnLeaveLobbyButton()
	{
	}

	public void OnInviteButton()
	{
	}

	public void OnGameModeChanged(int gameModeId)
	{
	}

	public void OnLevelChanged(int index)
	{
	}

	public void OnTeamSizeChanged(int teamSize)
	{
	}

	public void OnRegionChanged(int value)
	{
	}

	public void OnBotCountChanged(string botCount)
	{
	}

	public void OnBotDifficultyChanged(int botDifficulty)
	{
	}

	public int GetLevelIndexFromValue(int value)
	{
		return 0;
	}

	public int GetValueFromLevelIndex(int index)
	{
		return 0;
	}

	public void PopulateUnityGameModeDropdown()
	{
	}

	public void PopulateLevelDropdown()
	{
	}

	public void PopulateGameModeIdDropdown()
	{
	}

	public void PopulateRegionDropdown()
	{
	}

	public void PopulateBotCountField()
	{
	}

	public void PopulateBotDifficultyDropdown()
	{
	}

	public void UpdateLobby()
	{
	}

	public void UpdateReadyButtons()
	{
	}

	public void UpdateSettings(CustomGameSettingsModel settings)
	{
	}

	public void UpdateRegionDropdown(int value)
	{
	}

	public void ToggleSettingsInteractable(bool isInteractable)
	{
	}

	public void ToggleStartGameContainer(bool show)
	{
	}

	public void SetPlayerToTeam(PlayerModel player, int teamId)
	{
	}

	public void SetPlayerReadyStatus(string accountId, bool isReady)
	{
	}

	public void RemoveLobbyPlayerEntry(PlayerModel player)
	{
	}

	public bool CompareMapMapping<TValue>(Dictionary<int, int[]> dict1, Dictionary<int, int[]> dict2)
	{
		return false;
	}
}
