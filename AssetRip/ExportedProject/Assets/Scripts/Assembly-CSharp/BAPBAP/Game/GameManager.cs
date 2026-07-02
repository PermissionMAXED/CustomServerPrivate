using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BAPBAP.Debugging;
using BAPBAP.Entities;
using BAPBAP.Maps;
using BAPBAP.Network;
using BAPBAP.Player;
using BAPBAP.UI;
using Mirror;
using Mirror.SimpleWeb;
using UnityEngine;

namespace BAPBAP.Game
{
	public class GameManager : NetworkBehaviour
	{
		[CompilerGenerated]
		public sealed class _003CDoClientMatchEnd_003Ed__92 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public int winnerTeamId;

			public GameManager _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CDoClientMatchEnd_003Ed__92(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		public sealed class _003CDoTimeScaleEffect_003Ed__65 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public GameManager _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CDoTimeScaleEffect_003Ed__65(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		public sealed class _003CPreMatchCycle_003Ed__66 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public GameManager _003C_003E4__this;

			[NonSerialized]
			public float _003ChiddenTimer_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CPreMatchCycle_003Ed__66(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		public sealed class _003CResetLifeCycle_003Ed__64 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public GameManager _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CResetLifeCycle_003Ed__64(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		public sealed class _003CStartLifeCycle_003Ed__63 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public GameManager _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CStartLifeCycle_003Ed__63(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[NonSerialized]
		public UIManager uiManager;

		[NonSerialized]
		public UIGameMode uiGameMode;

		[NonSerialized]
		public NetworkManager netManager;

		[NonSerialized]
		public GameNetworkManager gameNetworkManager;

		[NonSerialized]
		public WebServer webServer;

		[NonSerialized]
		public DeveloperLobbyManager devLobbyManager;

		[NonSerialized]
		public PreMatchManager preMatchManager;

		[NonSerialized]
		public SimpleWebTransport transport;

		[NonSerialized]
		public DebugNetcodeManager debugNetManager;

		[NonSerialized]
		public bool isWaitingForGame;

		[NonSerialized]
		public bool isWaitingForStart;

		[NonSerialized]
		public bool isWaitingForPlayers;

		[NonSerialized]
		public bool isWaitingForSpawnSelect;

		[NonSerialized]
		[SyncVar(hook = "OnMatchStartCountdownChanged")]
		public bool matchStartCountdown;

		[NonSerialized]
		public bool matchStarted;

		[NonSerialized]
		public bool isReset;

		[NonSerialized]
		public bool isLateJoinable;

		[NamedArray(typeof(GameModes), 1)]
		public GameMode[] gameModes;

		[SerializeField]
		[Tooltip("Max time allowed to wait if no player connects to the game")]
		[Header("Match Time Configs")]
		public float matchWaitForStartMaxTimeMatchmaking;

		[Tooltip("Max time allowed after starting until the game isn't joinable anymore")]
		[SerializeField]
		public float matchLateJoinTimeMatchmaking;

		[Header("End Time Effect Configs")]
		[SerializeField]
		public float endTimeScaleTime;

		[SerializeField]
		public AnimationCurve endTimeScaleCurve;

		[Header("Misc References")]
		[SerializeField]
		public GameObject baseEnvPrefab;

		[SerializeField]
		public GameModesConfiguration gameModeConfiguration;

		[SerializeField]
		public AssetPalette assetPalette;

		[NonSerialized]
		public int svCurrTickNum;

		[NonSerialized]
		[SyncVar]
		public bool isDevLobbyMode;

		[NonSerialized]
		public Dictionary<int, PlayerManager> playersByPlayerId;

		[NonSerialized]
		public List<EntityManager> currentBotCharacters;

		[NonSerialized]
		public Dictionary<int, int> connIdToPlayerId;

		[NonSerialized]
		public GameStats gameStats;

		[NonSerialized]
		public float lateJoinTimer;

		[NonSerialized]
		public float waitForStartTimeElapsed;

		[NonSerialized]
		public float timeScaleElapsed;

		[SyncVar]
		public float PreMatchTimer;

		[NonSerialized]
		public bool doTimescaleSubroutine;

		[NonSerialized]
		public int matchWinnerTeamId;

		[NonSerialized]
		public GameModes currentGameModeId;

		[NonSerialized]
		public GameMode currentGameMode;

		[NonSerialized]
		public GameModeBattleRoyale battleRoyale;

		[NonSerialized]
		public GameModeFFA ffa;

		[NonSerialized]
		public BotDifficulty botDifficulty;

		[NonSerialized]
		public int currentMaxBotTeams;

		[NonSerialized]
		public QueueMatchedData qmd;

		[NonSerialized]
		public MatchmakingGameData mgd;

		[NonSerialized]
		public int _gameModeId;

		[SyncVar]
		[NonSerialized]
		public int _gmTeamSize;

		public static GameManager Instance;

		[NonSerialized]
		[SyncVar(hook = "OnAllySharedVisionEnabledChanged")]
		public bool allySharedVisionEnabled;

		[NonSerialized]
		[SyncVar(hook = "OnGlobalThirdPersonModeEnabledChanged")]
		public bool globalThirdPersonModeEnabled;

		public Action<bool, bool> _Mirror_SyncVarHookDelegate_matchStartCountdown;

		public Action<bool, bool> _Mirror_SyncVarHookDelegate_allySharedVisionEnabled;

		public Action<bool, bool> _Mirror_SyncVarHookDelegate_globalThirdPersonModeEnabled;

		public int GmTeamSize => 0;

		public static bool IsServer => false;

		public static bool IsClient => false;

		public bool NetworkmatchStartCountdown
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

		public bool NetworkisDevLobbyMode
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

		public float NetworkPreMatchTimer
		{
			get
			{
				return 0f;
			}
			[param: In]
			set
			{
			}
		}

		public int Network_gmTeamSize
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

		public bool NetworkallySharedVisionEnabled
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

		public bool NetworkglobalThirdPersonModeEnabled
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

		public void PreAwake()
		{
		}

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public override void OnStartServer()
		{
		}

		public void FixedUpdate()
		{
		}

		[Server]
		public void Reset()
		{
		}

		[Server]
		public void AddPlayerMatchmaking(NetworkConnectionToClient conn, GameObject player, MatchmakingPlayerData mpd, List<int> teammatePlayerIds)
		{
		}

		public void SyncGameStateOnPlayer(NetworkConnectionToClient conn, PlayerManager playerManager)
		{
		}

		[Server]
		public void RemovePlayer(NetworkConnectionToClient conn)
		{
		}

		[IteratorStateMachine(typeof(_003CStartLifeCycle_003Ed__63))]
		[Server]
		public IEnumerator StartLifeCycle()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CResetLifeCycle_003Ed__64))]
		public IEnumerator ResetLifeCycle()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CDoTimeScaleEffect_003Ed__65))]
		public IEnumerator DoTimeScaleEffect()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CPreMatchCycle_003Ed__66))]
		public IEnumerator PreMatchCycle()
		{
			return null;
		}

		public void OnGameReadyToStart()
		{
		}

		[Server]
		public void StartMatch(bool _isDevLobbyMode, MatchmakingGameData mgd)
		{
		}

		[Server]
		public void EndMatch(int winnerTeamId)
		{
		}

		public void ToggleGameMode(GameModes gameModeId, bool isEnabled)
		{
		}

		public void DisableAllGameModes()
		{
		}

		[Server]
		public void AddPlayerDevLobby(NetworkConnectionToClient conn, GameObject player, int playerId, string playerName, int teamId)
		{
		}

		[Server]
		public void GetAndAssignAllDevLobbyTeammates()
		{
		}

		public List<PlayerManager> GetDevLobbyTeammates(int playerId, int teamId)
		{
			return null;
		}

		[Server]
		public void LockPlayerInputs(bool isLocked)
		{
		}

		public void ResetSpectatorOnAllPlayers()
		{
		}

		public Vector2[] GetDimensionSpawns(Vector2[] dimensionSpawnArray, int spawnsToPick)
		{
			return null;
		}

		[Server]
		public int GetPlayerCount()
		{
			return 0;
		}

		[Server]
		public int GetAlivePlayerCount()
		{
			return 0;
		}

		public float GetTeamMultiplier(EntityManager entityManager)
		{
			return 0f;
		}

		public static EntityManager SvGetEntityFromNetId(uint netId)
		{
			return null;
		}

		public static EntityManager ClGetEntityFromNetId(uint netId)
		{
			return null;
		}

		public EntityManager GetBotEntityManager(int playerId)
		{
			return null;
		}

		[ClientRpc]
		public void RpcCleanMemory()
		{
		}

		public void CleanMemory()
		{
		}

		[TargetRpc]
		public void TargetTryLeaveGame(NetworkConnection conn)
		{
		}

		[Client]
		public void ClOnMatchStarted()
		{
		}

		[Client]
		public void ClOnMatchEnded()
		{
		}

		public void ClMatchmakingEnd()
		{
		}

		[ClientRpc]
		public void RpcMatchmakingEnd()
		{
		}

		[ClientRpc]
		public void RpcMatchEnd(int winnerTeamId)
		{
		}

		[IteratorStateMachine(typeof(_003CDoClientMatchEnd_003Ed__92))]
		public IEnumerator DoClientMatchEnd(int winnerTeamId)
		{
			return null;
		}

		[ClientRpc]
		public void RpcDisableGameMode(GameModes gameModeId)
		{
		}

		[TargetRpc]
		public void TargetEnableGameMode(NetworkConnectionToClient conn, GameModes gameModeId, int levelId)
		{
		}

		[ClientRpc]
		public void RpcSendChatMessage(string msgString)
		{
		}

		[ClientRpc]
		public void RpcShowPlayerDisconnectedMsg(string playerName)
		{
		}

		[TargetRpc]
		public void TargetShowTeammateDisconnectedMsg(NetworkConnectionToClient conn, string playerName)
		{
		}

		public void OnMatchStartCountdownChanged(bool oldValue, bool newValue)
		{
		}

		public void OnAllySharedVisionEnabledChanged(bool oldValue, bool newValue)
		{
		}

		public void OnGlobalThirdPersonModeEnabledChanged(bool oldValue, bool newValue)
		{
		}

		public void ToggleNetSyncServer()
		{
		}

		[ClientRpc]
		public void RpcToggleNetSyncServer(bool netSync)
		{
		}

		public void ToggleDeltaCompressionServer()
		{
		}

		[ClientRpc]
		public void RpcToggleDeltaCompressionServer(bool deltaCompression)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcCleanMemory()
		{
		}

		public static void InvokeUserCode_RpcCleanMemory(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetTryLeaveGame__NetworkConnection(NetworkConnection conn)
		{
		}

		public static void InvokeUserCode_TargetTryLeaveGame__NetworkConnection(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcMatchmakingEnd()
		{
		}

		public static void InvokeUserCode_RpcMatchmakingEnd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcMatchEnd__Int32(int winnerTeamId)
		{
		}

		public static void InvokeUserCode_RpcMatchEnd__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcDisableGameMode__GameModes(GameModes gameModeId)
		{
		}

		public static void InvokeUserCode_RpcDisableGameMode__GameModes(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetEnableGameMode__NetworkConnectionToClient__GameModes__Int32(NetworkConnectionToClient conn, GameModes gameModeId, int levelId)
		{
		}

		public static void InvokeUserCode_TargetEnableGameMode__NetworkConnectionToClient__GameModes__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSendChatMessage__String(string msgString)
		{
		}

		public static void InvokeUserCode_RpcSendChatMessage__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcShowPlayerDisconnectedMsg__String(string playerName)
		{
		}

		public static void InvokeUserCode_RpcShowPlayerDisconnectedMsg__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetShowTeammateDisconnectedMsg__NetworkConnectionToClient__String(NetworkConnectionToClient conn, string playerName)
		{
		}

		public static void InvokeUserCode_TargetShowTeammateDisconnectedMsg__NetworkConnectionToClient__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcToggleNetSyncServer__Boolean(bool netSync)
		{
		}

		public static void InvokeUserCode_RpcToggleNetSyncServer__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcToggleDeltaCompressionServer__Boolean(bool deltaCompression)
		{
		}

		public static void InvokeUserCode_RpcToggleDeltaCompressionServer__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static GameManager()
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
