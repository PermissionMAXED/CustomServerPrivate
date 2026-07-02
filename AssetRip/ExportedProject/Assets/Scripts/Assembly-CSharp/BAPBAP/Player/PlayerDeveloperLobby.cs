using System;
using System.Runtime.InteropServices;
using BAPBAP.Game;
using BAPBAP.UI;
using Mirror;

namespace BAPBAP.Player
{
	public class PlayerDeveloperLobby : NetworkBehaviour
	{
		[NonSerialized]
		public PlayerManager playerManager;

		[NonSerialized]
		public GameManager gameManager;

		[NonSerialized]
		public UIDeveloperLobby uiLobby;

		[NonSerialized]
		public DeveloperLobbyManager lobbyManager;

		[SyncVar(hook = "OnIsReadyChanged")]
		public bool isReady;

		[SyncVar(hook = "OnLobbyTeamIdChanged")]
		public int lobbyTeamId;

		[SyncVar(hook = "OnLobbyCharIdChanged")]
		public int lobbyCharId;

		public Action<bool, bool> _Mirror_SyncVarHookDelegate_isReady;

		public Action<int, int> _Mirror_SyncVarHookDelegate_lobbyTeamId;

		public Action<int, int> _Mirror_SyncVarHookDelegate_lobbyCharId;

		public bool NetworkisReady
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

		public int NetworklobbyTeamId
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

		public int NetworklobbyCharId
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

		public void Initialize(PlayerManager _playerManager)
		{
		}

		public void Start()
		{
		}

		public override void OnStartClient()
		{
		}

		public override void OnStopClient()
		{
		}

		[TargetRpc]
		public void TargetCharSelected(NetworkConnection conn)
		{
		}

		public static int GetLocalLobbyTeamId()
		{
			return 0;
		}

		[ClientRpc]
		public void RpcSetLobbyValues(int teamId, int charId)
		{
		}

		public void OnIsReadyChanged(bool oldValue, bool newValue)
		{
		}

		public void OnLobbyTeamIdChanged(int oldValue, int newValue)
		{
		}

		public void OnLobbyCharIdChanged(int oldValue, int newValue)
		{
		}

		[Command]
		public void CmdSetSpectator()
		{
		}

		[Command]
		public void CmdSelectCharacter(int newCharId)
		{
		}

		[Command]
		public void CmdSetLobbyTeam(int team)
		{
		}

		[Command]
		public void CmdSelectUnityGamemode(GameModes gameModeId)
		{
		}

		[Command]
		public void CmdSelectGameModeId(int gameModeId)
		{
		}

		[Command]
		public void CmdSelectBotDifficulty(BotDifficulty botDifficulty)
		{
		}

		[Command]
		public void CmdSetMaxBotTeams(int maxBotTeams)
		{
		}

		[Command]
		public void CmdSelectLevel(int mapId)
		{
		}

		[Command]
		public void CmdToggleSameCharSelect(bool isOn)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_TargetCharSelected__NetworkConnection(NetworkConnection conn)
		{
		}

		public static void InvokeUserCode_TargetCharSelected__NetworkConnection(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSetLobbyValues__Int32__Int32(int teamId, int charId)
		{
		}

		public static void InvokeUserCode_RpcSetLobbyValues__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdSetSpectator()
		{
		}

		public static void InvokeUserCode_CmdSetSpectator(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdSelectCharacter__Int32(int newCharId)
		{
		}

		public static void InvokeUserCode_CmdSelectCharacter__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdSetLobbyTeam__Int32(int team)
		{
		}

		public static void InvokeUserCode_CmdSetLobbyTeam__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdSelectUnityGamemode__GameModes(GameModes gameModeId)
		{
		}

		public static void InvokeUserCode_CmdSelectUnityGamemode__GameModes(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdSelectGameModeId__Int32(int gameModeId)
		{
		}

		public static void InvokeUserCode_CmdSelectGameModeId__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdSelectBotDifficulty__BotDifficulty(BotDifficulty botDifficulty)
		{
		}

		public static void InvokeUserCode_CmdSelectBotDifficulty__BotDifficulty(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdSetMaxBotTeams__Int32(int maxBotTeams)
		{
		}

		public static void InvokeUserCode_CmdSetMaxBotTeams__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdSelectLevel__Int32(int mapId)
		{
		}

		public static void InvokeUserCode_CmdSelectLevel__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdToggleSameCharSelect__Boolean(bool isOn)
		{
		}

		public static void InvokeUserCode_CmdToggleSameCharSelect__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static PlayerDeveloperLobby()
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
