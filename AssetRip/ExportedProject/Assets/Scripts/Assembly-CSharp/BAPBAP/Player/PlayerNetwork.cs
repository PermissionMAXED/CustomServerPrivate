using System;
using System.Runtime.InteropServices;
using BAPBAP.Debugging;
using BAPBAP.Game;
using BAPBAP.Local;
using BAPBAP.Utilities;
using Mirror;
using UnityEngine;

namespace BAPBAP.Player
{
	public class PlayerNetwork : NetworkBehaviour
	{
		[HideInInspector]
		public PlayerManager playerManager;

		[Header("Input Configs")]
		[Tooltip("How much delay do we want on client inputs before applying prediction?")]
		[SerializeField]
		public int inputDelayTicks;

		[NonSerialized]
		public InputManager inputManager;

		[NonSerialized]
		public GameManager gameManager;

		[NonSerialized]
		public DebugNetcodeManager debugNetcodeManager;

		[HideInInspector]
		[SyncVar]
		public bool inputLock;

		[NonSerialized]
		public Command clCurrCmd;

		[NonSerialized]
		public Command[] clCmdHistory;

		[Tooltip("How often to send pings?")]
		[SerializeField]
		[Header("Ping Configs")]
		public float pingHz;

		[Tooltip("How smooth do we want the ping's moving average to be?")]
		[SerializeField]
		public int pingWindowSize;

		[NonSerialized]
		public ExpMovingAverageDouble rttEMA;

		[NonSerialized]
		public float pingDelay;

		[NonSerialized]
		public float timeSinceLastPing;

		[NonSerialized]
		public Command prevCmd;

		public double currClientTime;

		[NonSerialized]
		public int svLastAppliedCmdTickNum;

		[NonSerialized]
		public RingBufferQueue<Command> svCmdBuffer;

		[NonSerialized]
		public double lastRecvClientTime;

		[Header("Server Burstable Configs")]
		[SerializeField]
		[Tooltip("How many commands to remember before we mark them as stale?")]
		public int svMaxCmdBufferSize;

		[Tooltip("Maximum burst we support for clearing out the command buffer")]
		[SerializeField]
		public float svMaxBurstableCredit;

		[Tooltip("Maximum burst we support per tick")]
		[SerializeField]
		public int svMaxBurstablePerTick;

		[SerializeField]
		[Tooltip("How much burst to replenish per second")]
		public float svBurstReplenishPerSec;

		[Tooltip("How many ticks without receiving player input do we treat a player as laggy to apply duplicate commands (Server-side smoothing)? [Default = 333 Ping]")]
		[SerializeField]
		public float svLaggyTickThreshold;

		[SerializeField]
		[Tooltip("How many ticks without receiving player input do we treat a player as inactive to apply null commands? [Default = 1s] [Must be higher than laggy threshold]")]
		public float svInactivityTickThreshold;

		[NonSerialized]
		public float burstableCredit;

		[NonSerialized]
		public int noInputTickCount;

		public bool NetworkinputLock
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

		public void Initialize(PlayerManager _playerManager)
		{
		}

		public void ManagedFixedUpdate()
		{
		}

		public override void OnStartClient()
		{
		}

		public void ClTick()
		{
		}

		public Command ClGetCmdFromHistory(int tickNum)
		{
			return null;
		}

		public Command ClGetCurrCmd()
		{
			return null;
		}

		public override void OnStartServer()
		{
		}

		public void SvTick()
		{
		}

		public void ApplyCmd(Command cmd)
		{
		}

		[Command]
		public void CmdPlayerCmds(Command cmd)
		{
		}

		[Command]
		public void CmdSimPing(double clientTime)
		{
		}

		[TargetRpc]
		public void TargetSimPong(NetworkConnection conn, double clientTime)
		{
		}

		[Command]
		public void CmdGetSvTickRate()
		{
		}

		[TargetRpc]
		public void TargetGetSvTickRate(float svTickRate)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_CmdPlayerCmds__Command(Command cmd)
		{
		}

		public static void InvokeUserCode_CmdPlayerCmds__Command(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdSimPing__Double(double clientTime)
		{
		}

		public static void InvokeUserCode_CmdSimPing__Double(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetSimPong__NetworkConnection__Double(NetworkConnection conn, double clientTime)
		{
		}

		public static void InvokeUserCode_TargetSimPong__NetworkConnection__Double(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdGetSvTickRate()
		{
		}

		public static void InvokeUserCode_CmdGetSvTickRate(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetGetSvTickRate__Single(float svTickRate)
		{
		}

		public static void InvokeUserCode_TargetGetSvTickRate__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static PlayerNetwork()
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
