using System;
using System.Collections.Generic;
using BAPBAP.Player;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIDeveloperLobby : MonoBehaviour
	{
		public struct ButtonCharId
		{
			public Button button;

			public int charId;
		}

		[NonSerialized]
		public UIManager uiManager;

		[SerializeField]
		public GameObject root;

		[SerializeField]
		public Transform charButtonParent;

		[SerializeField]
		public GameObject charButtonPrefab;

		[SerializeField]
		public Text[] teamPlayersText;

		[SerializeField]
		public Text[] teamReadyText;

		[SerializeField]
		public Button[] teamButton;

		[NonSerialized]
		public ButtonCharId[] charButtons;

		[SerializeField]
		public Button spectatorButton;

		[SerializeField]
		public Button randomCharButton;

		[SerializeField]
		public Button startGameButton;

		[SerializeField]
		public Button loadModulesButton;

		[SerializeField]
		public CustomTMP_Dropdown unityGameModeDropdown;

		[SerializeField]
		public CustomTMP_Dropdown levelDropdown;

		[SerializeField]
		public Toggle allowSameCharToggle;

		[SerializeField]
		public CustomTMP_Dropdown gameModeIdDropdown;

		[SerializeField]
		public InputField maxBotsTeamsField;

		[SerializeField]
		public CustomTMP_Dropdown botDifficultyDropdown;

		[NonSerialized]
		public List<int> playerIds;

		[NonSerialized]
		public List<PlayerManager> playerManagers;

		[NonSerialized]
		public List<int> levelDropdownToLevelListIds;

		public void Awake()
		{
		}

		public void OnStartMatchNowButton()
		{
		}

		public int GetLevelIndexFromValue()
		{
			return 0;
		}

		public int GetValueFromLevelIndex(int index)
		{
			return 0;
		}

		public void SvLoadModuleMaps()
		{
		}

		public void LoadModuleMaps()
		{
		}

		public void PopulateUnityGameModeDropdown()
		{
		}

		public void PopulateLevelDropdown(string[] levelArray)
		{
		}

		public void PopulateGameModeIdDropdown()
		{
		}

		public void PopulateBotDifficultyDropdown()
		{
		}

		public void UpdateLobby()
		{
		}

		public void AddLobbyPlayerEntry(PlayerManager playerManager)
		{
		}

		public void RemoveLobbyPlayerEntry(int playerId)
		{
		}

		public void UpdatePlayersTeamNames(int teamId)
		{
		}

		public void UpdatePlayersTeamReady(int teamId)
		{
		}

		public void SetCharButtonInteractable(int charIndex, bool isInteractable)
		{
		}
	}
}
