using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BAPBAP.Game;
using BAPBAP.Local;
using BAPBAP.Pooling;
using BAPBAP.Systems;
using BAPBAP.UI;
using Mirror;
using Mirror.SimpleWeb;
using UnityEngine;
using kcp2k;

namespace BAPBAP.Network;

public class GameNetworkManager : NetworkManager
{
	[Serializable]
	public class CharacterBotPrefabs
	{
		public GameObject charBotEasy;

		public GameObject charBotMedium;

		public GameObject charBotHard;

		public GameObject charBotExpert;

		public GameObject GetBotPrefab(BotDifficulty botDifficulty)
		{
			return null;
		}
	}

	public struct ClInitMsg : NetworkMessage
	{
		public string playerName;

		public string gameAuthId;
	}

	public struct SvInitMsg : NetworkMessage
	{
		public string buildVersion;

		public int teamIdCache;

		public int playerIdCache;

		public int[] teammatePlayerIdsCache;
	}

	[CompilerGenerated]
	public sealed class <ReconnectRoutine>d__52 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[NonSerialized]
		public int <>1__state;

		[NonSerialized]
		public object <>2__current;

		public GameNetworkManager <>4__this;

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
		public <ReconnectRoutine>d__52(int <>1__state)
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

	public const int AnnaCharId = 1;

	public const int ZookCharId = 5;

	public const int TeeveeCharId = 8;

	public const int SpriestCharId = 11;

	public const int IceMageCharId = 12;

	[HideInInspector]
	public string playerName;

	[HideInInspector]
	public string gameAuthId;

	[NonSerialized]
	public GameManager gameManager;

	[NonSerialized]
	public UIManager uiManager;

	[NonSerialized]
	public InputManager inputManager;

	[NonSerialized]
	public NetworkCache networkCache;

	[NonSerialized]
	public AnalyticsManager analyticsManager;

	[NonSerialized]
	public SystemManager systemManager;

	[HideInInspector]
	public WebServer webServer;

	[HideInInspector]
	public MultiplexTransport multiplexTransport;

	[HideInInspector]
	public SimpleWebTransport wsTransport;

	[HideInInspector]
	public KcpTransport kcpTransport;

	[HideInInspector]
	public TelepathyTransport tcpTransport;

	[HideInInspector]
	public LatencySimulation latencySimulation;

	[HideInInspector]
	public LobbyNetworkClient lobbyNetworkClient;

	[HideInInspector]
	public CustomSpatialHashInterestManagement aoi;

	[Header("Game Config")]
	[SerializeField]
	public string[] names;

	[SerializeField]
	public NetworkPrefabLibrary networkPrefabLibrary;

	[SerializeField]
	public GameObject[] characterPrefabsByCharId;

	[SerializeField]
	public CharacterBotPrefabs[] charBotPrefabsByCharId;

	[SerializeField]
	public NetworkConfig _networkConfig;

	[SerializeField]
	public float _reconnectTimeout;

	[SerializeField]
	public int _maxClientReconnectionAttempts;

	[HideInInspector]
	public bool firstPlayerConnected;

	[HideInInspector]
	public Command emptyCmd;

	[NonSerialized]
	public int roundRobinNameIndex;

	[NonSerialized]
	public int playerIdTotal;

	[NonSerialized]
	public bool serverStopped;

	[NonSerialized]
	public int _clientReconnectionAttempts;

	[NonSerialized]
	public bool _mmGameActive;

	[NonSerialized]
	public Dictionary<string, MatchmakingPlayerData> gameAuthIdToPlayer;

	[NonSerialized]
	public Dictionary<string, bool> alreadyConnected;

	[NonSerialized]
	public Dictionary<int, string> connectionIdToGameAuthId;

	public bool AllPlayersConnected;

	public static GameNetworkManager Instance;

	public string CharArrayDrawer(int i)
	{
		return null;
	}

	public void PreAwake(int wsPort, int kcpPort, int tcpPort)
	{
	}

	public override void Awake()
	{
	}

	public override void Start()
	{
	}

	public bool IsActive()
	{
		return false;
	}

	public GameObject GetCharacterBotPrefab(int charId, BotDifficulty botDifficulty)
	{
		return null;
	}

	public override void OnStartClient()
	{
	}

	public override void OnClientConnect()
	{
	}

	public override void OnClientDisconnect()
	{
	}

	[IteratorStateMachine(typeof(<ReconnectRoutine>d__52))]
	public IEnumerator ReconnectRoutine()
	{
		return null;
	}

	public void OnClientSvInit(SvInitMsg msg)
	{
	}

	public void ClMatchmakingGameEnded()
	{
	}

	public override void OnStartServer()
	{
	}

	public override void ConfigureHeadlessFrameRate()
	{
	}

	public override void OnServerConnect(NetworkConnectionToClient conn)
	{
	}

	public override void OnServerReady(NetworkConnectionToClient conn)
	{
	}

	public override void OnServerAddPlayer(NetworkConnectionToClient conn)
	{
	}

	public void OnServerClInit(NetworkConnectionToClient conn, ClInitMsg msg)
	{
	}

	public void OnServerDevLobbyClInit(NetworkConnectionToClient conn, ClInitMsg msg)
	{
	}

	public void OnServerMatchmakingClInit(NetworkConnectionToClient conn, ClInitMsg msg)
	{
	}

	public void OnServerMatchSetup(MatchmakingGameData mgd)
	{
	}

	public void OnServerMatchAddTeams(MatchmakingTeamData mtd)
	{
	}

	public void OnServerMatchReset()
	{
	}

	public void OnServerQueueMatched(QueueMatchedData qmd)
	{
	}

	public void OnServerMatchCleanUp()
	{
	}

	public override void OnServerDisconnect(NetworkConnectionToClient conn)
	{
	}

	public override void OnStopServer()
	{
	}

	public void ConnectMatchmaking(string gameAuthId, string gameHostname, int wsPort, int kcpPort, int tcpPort)
	{
	}
}
