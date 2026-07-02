using System;
using System.Runtime.InteropServices;
using BAPBAP.UI;
using Mirror;
using UnityEngine;

namespace BAPBAP.Game
{
	public class DeveloperLobbyManager : NetworkBehaviour
	{
		[NonSerialized]
		public GameManager gameManager;

		[NonSerialized]
		public UIGameMode uiGameMode;

		[NonSerialized]
		public UIDeveloperLobby uiLobby;

		[NonSerialized]
		public UIChat uiChat;

		[SerializeField]
		public GameModes defaultGameModeId;

		[SyncVar(hook = "OnLobbyGameModeChanged")]
		[NonSerialized]
		public GameModes selectedUnityGameMode;

		[SyncVar(hook = "OnGameModeIdChanged")]
		[NonSerialized]
		public int gameModeId;

		[SyncVar(hook = "OnMaxBotTeamsChanged")]
		[NonSerialized]
		public int maxBotTeams;

		[SyncVar(hook = "OnBotDifficultyChanged")]
		[NonSerialized]
		public BotDifficulty botDifficulty;

		[SyncVar(hook = "OnSelectedLevelChanged")]
		[NonSerialized]
		public int selectedLevelId;

		[SyncVar(hook = "OnAllowSameCharSelectChanged")]
		public bool allowSameCharSelect;

		[NonSerialized]
		public int roundRobinLobbyTeamIndex;

		public Action<GameModes, GameModes> _Mirror_SyncVarHookDelegate_selectedUnityGameMode;

		public Action<int, int> _Mirror_SyncVarHookDelegate_gameModeId;

		public Action<int, int> _Mirror_SyncVarHookDelegate_maxBotTeams;

		public Action<BotDifficulty, BotDifficulty> _Mirror_SyncVarHookDelegate_botDifficulty;

		public Action<int, int> _Mirror_SyncVarHookDelegate_selectedLevelId;

		public Action<bool, bool> _Mirror_SyncVarHookDelegate_allowSameCharSelect;

		public GameModes NetworkselectedUnityGameMode
		{
			get
			{
				return default(GameModes);
			}
			[param: In]
			set
			{
			}
		}

		public int NetworkgameModeId
		{
			get
			{
				return 0;
			}
			[param: In]
			set
			{
			}
		}

		public int NetworkmaxBotTeams
		{
			get
			{
				return 0;
			}
			[param: In]
			set
			{
			}
		}

		public BotDifficulty NetworkbotDifficulty
		{
			get
			{
				return default(BotDifficulty);
			}
			[param: In]
			set
			{
			}
		}

		public int NetworkselectedLevelId
		{
			get
			{
				return 0;
			}
			[param: In]
			set
			{
			}
		}

		public bool NetworkallowSameCharSelect
		{
			get
			{
				return false;
			}
			[param: In]
			set
			{
			}
		}

		public void Awake()
		{
		}

		public override void OnStartClient()
		{
		}

		public override void OnStartServer()
		{
		}

		[Server]
		public void TryStartMatch()
		{
		}

		[Server]
		public void ResetLobby()
		{
		}

		[Server]
		public void ChangeUnityGameMode(GameModes gameModeId)
		{
		}

		[Server]
		public void ChangeGameModeId(int gameModeId)
		{
		}

		[Server]
		public void ChangeBotDifficulty(BotDifficulty botDifficulty)
		{
		}

		[Server]
		public void SetMaxBotTeams(int maxBotTeams)
		{
		}

		[Server]
		public void ChangeLevel(int levelId)
		{
		}

		public void OnSelectedLevelChanged(int oldValue, int newValue)
		{
		}

		public void OnLobbyGameModeChanged(GameModes oldValue, GameModes newValue)
		{
		}

		public void OnGameModeIdChanged(int oldValue, int newValue)
		{
		}

		public void OnMaxBotTeamsChanged(int oldValue, int newValue)
		{
		}

		public void OnBotDifficultyChanged(BotDifficulty oldValue, BotDifficulty newValue)
		{
		}

		[Server]
		public void OnChangeTeam()
		{
		}

		[Server]
		public int GetNextTeamId()
		{
			return 0;
		}

		public void OnAllowSameCharSelectChanged(bool oldValue, bool newValue)
		{
		}

		public void ToggleSameCharSelect(bool isOn)
		{
		}

		[ClientRpc]
		public void RpcSetSetCharButtonInteractable(int charId, int lobbyTeamId, bool isInteractable)
		{
		}

		[ClientRpc]
		public void RpcResetAllCharButtons()
		{
		}

		[ClientRpc]
		public void RpcDeveloperLobbyEnd()
		{
		}

		[TargetRpc]
		public void TargetShowDeveloperLobby(NetworkConnection conn)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcSetSetCharButtonInteractable__Int32__Int32__Boolean(int charId, int lobbyTeamId, bool isInteractable)
		{
		}

		public static void InvokeUserCode_RpcSetSetCharButtonInteractable__Int32__Int32__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcResetAllCharButtons()
		{
		}

		public static void InvokeUserCode_RpcResetAllCharButtons(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcDeveloperLobbyEnd()
		{
		}

		public static void InvokeUserCode_RpcDeveloperLobbyEnd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetShowDeveloperLobby__NetworkConnection(NetworkConnection conn)
		{
		}

		public static void InvokeUserCode_TargetShowDeveloperLobby__NetworkConnection(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static DeveloperLobbyManager()
		{
		}

		public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
		{
		}

		public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
		{
		}
	}
}
