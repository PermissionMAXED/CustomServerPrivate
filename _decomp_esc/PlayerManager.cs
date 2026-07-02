using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using BAPBAP.Entities;
using BAPBAP.Game;
using BAPBAP.Local;
using BAPBAP.Network;
using BAPBAP.Systems;
using BAPBAP.UI;
using Mirror;
using UnityEngine;

namespace BAPBAP.Player;

public class PlayerManager : NetworkBehaviour
{
	public enum DownedState
	{
		None,
		Downed,
		BeingRevived,
		BeingExecuted
	}

	[NonSerialized]
	public GameManager gameManager;

	[NonSerialized]
	public NetworkCache networkCache;

	[NonSerialized]
	public LocalSavedData localSavedData;

	[NonSerialized]
	public GameNetworkManager gameNetManager;

	[NonSerialized]
	public CustomSpatialHashInterestManagement aoi;

	[NonSerialized]
	public SystemManager systemManager;

	[NonSerialized]
	public UIAbilities uiAbilities;

	[NonSerialized]
	public UIManager uiManager;

	[NonSerialized]
	public UIGameMode uiGameMode;

	[NonSerialized]
	public UIDeveloperLobby uiLobby;

	[NonSerialized]
	public PlayerChat playerChat;

	[NonSerialized]
	public PlayerDebug playerDebug;

	[NonSerialized]
	public PlayerDeveloperLobby playerLobby;

	[NonSerialized]
	public PlayerNetwork playerNetwork;

	[NonSerialized]
	public PlayerScores playerScores;

	[NonSerialized]
	public PlayerSpectate playerSpectate;

	[NonSerialized]
	public PlayerTeammates playerTeammates;

	[NonSerialized]
	public PlayerPing playerPing;

	[NonSerialized]
	public PlayerAugments playerAugments;

	[NonSerialized]
	public PlayerPreMatch playerPreMatch;

	[SyncVar]
	public int playerId;

	[SyncVar]
	public string playerName;

	[SyncVar(hook = "OnIsAnonymousChanged")]
	public bool isAnonymous;

	[NonSerialized]
	[SyncVar(hook = "OnCharacterChanged")]
	public int charId;

	[SyncVar(hook = "OnTeamIdChanged")]
	public int teamId;

	[SyncVar(hook = "OnDownedStateChanged")]
	public DownedState downedState;

	[SyncVar(hook = "OnIsDeadChanged")]
	public bool isDead;

	[NonSerialized]
	public int selectedTombstoneAssetId;

	[NonSerialized]
	public int skinAssetId;

	[NonSerialized]
	public EntityManager primaryCharManager;

	[NonSerialized]
	public List<EntityManager> secondaryCharManagers;

	[NonSerialized]
	public Transform followTargetOverride;

	public Action OnCharacterChangeEvent;

	public string accountId;

	[NonSerialized]
	public List<GameObject> zookActiveMines;

	[NonSerialized]
	public bool syncDirToCameraEnabled;

	public static PlayerManager LocalInstance;

	public Action<bool, bool> _Mirror_SyncVarHookDelegate_isAnonymous;

	public Action<int, int> _Mirror_SyncVarHookDelegate_charId;

	public Action<int, int> _Mirror_SyncVarHookDelegate_teamId;

	public Action<DownedState, DownedState> _Mirror_SyncVarHookDelegate_downedState;

	public Action<bool, bool> _Mirror_SyncVarHookDelegate_isDead;

	public int NetworkplayerId
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

	public string NetworkplayerName
	{
		get
		{
			return null;
		}
		[param: In]
		set
		{
		}
	}

	public bool NetworkisAnonymous
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

	public int NetworkcharId
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

	public int NetworkteamId
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

	public DownedState NetworkdownedState
	{
		get
		{
			return default(DownedState);
		}
		[param: In]
		set
		{
		}
	}

	public bool NetworkisDead
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

	public void Start()
	{
	}

	public void OnDestroy()
	{
	}

	public override void OnStartClient()
	{
	}

	public override void OnStartServer()
	{
	}

	public void AddCharObj(EntityManager _entityManager, bool isPrimary)
	{
	}

	public void RemoveCharObj(GameObject charObj)
	{
	}

	public void ManagedFixedUpdate()
	{
	}

	public void ManagedUpdate()
	{
	}

	public void ManagedLateUpdate()
	{
	}

	public override void OnStartLocalPlayer()
	{
	}

	public void UpdateAOI()
	{
	}

	public void UpdateAOI(Transform target)
	{
	}

	public string GetPlayerName(bool anonymousEnemies = true)
	{
		return null;
	}

	public void UpdateHideAllCurrentNames()
	{
	}

	public Transform GetFollowTarget()
	{
		return null;
	}

	public static int GetLocalTeamId()
	{
		return 0;
	}

	public static string GetLocalPlayerName()
	{
		return null;
	}

	public static bool IsAlly(int teamId)
	{
		return false;
	}

	public static int GetLocalPlayerId()
	{
		return 0;
	}

	public static bool IsLocalPlayer(int playerId)
	{
		return false;
	}

	public static bool IsAuthView(EntityManager entity)
	{
		return false;
	}

	public static bool IsAuthView(int playerId)
	{
		return false;
	}

	public static Transform GetCurrentAuthViewTarget()
	{
		return null;
	}

	public static EntityManager GetCurrentAuthViewCharacter()
	{
		return null;
	}

	public static int GetTeammateId(int playerId)
	{
		return 0;
	}

	public static bool IsTeammate(int playerId)
	{
		return false;
	}

	public static int GetSpectatingPlayerId()
	{
		return 0;
	}

	public static bool IsSpectatingPlayer(int playerId)
	{
		return false;
	}

	public static bool IsSpectating()
	{
		return false;
	}

	public void OnIsAnonymousChanged(bool oldValue, bool newValue)
	{
	}

	public void OnTeamIdChanged(int oldValue, int newValue)
	{
	}

	public void OnIsDeadChanged(bool oldValue, bool newValue)
	{
	}

	public void OnDownedStateChanged(DownedState oldValue, DownedState newValue)
	{
	}

	public void OnCharacterChanged(int oldValue, int newValue)
	{
	}

	[Command]
	public void CmdSetAnonymousMode(bool isEnabled)
	{
	}

	[Command]
	public void CmdSetSelectedTombstoneId(int assetId)
	{
	}

	[Command]
	public void CmdTryLeaveGame()
	{
	}

	[Command]
	public void CmdCloseConnection()
	{
	}

	public override bool Weaved()
	{
		return false;
	}

	public void UserCode_CmdSetAnonymousMode__Boolean(bool isEnabled)
	{
	}

	public static void InvokeUserCode_CmdSetAnonymousMode__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdSetSelectedTombstoneId__Int32(int assetId)
	{
	}

	public static void InvokeUserCode_CmdSetSelectedTombstoneId__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdTryLeaveGame()
	{
	}

	public static void InvokeUserCode_CmdTryLeaveGame(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	public void UserCode_CmdCloseConnection()
	{
	}

	public static void InvokeUserCode_CmdCloseConnection(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
	}

	static PlayerManager()
	{
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
	}
}
