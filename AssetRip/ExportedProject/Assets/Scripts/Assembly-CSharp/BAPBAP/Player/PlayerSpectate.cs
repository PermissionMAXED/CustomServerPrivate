using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BAPBAP.Entities;
using BAPBAP.Game;
using BAPBAP.Local;
using BAPBAP.UI;
using Mirror;

namespace BAPBAP.Player
{
	public class PlayerSpectate : NetworkBehaviour
	{
		public enum CycleAction
		{
			None = 0,
			Next = 1,
			Previous = 2
		}

		[CompilerGenerated]
		public sealed class _003CWaitToSetSpectatedPlayer_003Ed__52 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public PlayerSpectate _003C_003E4__this;

			public PlayerManager playerToSpectate;

			public uint charToSpectateNetId;

			[NonSerialized]
			public EntityManager _003CcharToSpectate_003E5__2;

			[NonSerialized]
			public float _003Ctime_003E5__3;

			[NonSerialized]
			public EntityManager _003CcharManagerToSpectate_003E5__4;

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
			public _003CWaitToSetSpectatedPlayer_003Ed__52(int _003C_003E1__state)
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
		public PlayerManager playerManager;

		[NonSerialized]
		public InputManager inputManager;

		[NonSerialized]
		public GameManager gameManager;

		[NonSerialized]
		public UIManager uiManager;

		[NonSerialized]
		public UIGameMode uiGameMode;

		[NonSerialized]
		public UIAbilities uiAbilities;

		[NonSerialized]
		public UIItems uiItems;

		[NonSerialized]
		public UICanvasEffect uiCanvasEffect;

		[NonSerialized]
		public InputSystem inputSystem;

		[NonSerialized]
		public CameraController camController;

		[NonSerialized]
		public bool spectatorModeEnabled;

		[NonSerialized]
		public bool moveInputEnabled;

		[NonSerialized]
		public bool doCamLerpOnNewTargetByDistance;

		[NonSerialized]
		public float camLerpNewTargetDist;

		[NonSerialized]
		public int spectatedPlayerId;

		[NonSerialized]
		public int spectatedTeamId;

		[NonSerialized]
		public EntityManager spectatedChar;

		[NonSerialized]
		public PlayerManager spectatedPlayer;

		[NonSerialized]
		public float cooldownTime;

		[NonSerialized]
		public float cooldownDuration;

		[SyncVar(hook = "OnSpectatorCountChanged")]
		[NonSerialized]
		public int spectatorCount;

		[NonSerialized]
		public InputBinding moveLeftBinding;

		[NonSerialized]
		public InputBinding moveRightBinding;

		public Action<int, int> _Mirror_SyncVarHookDelegate_spectatorCount;

		public bool SpectatorModeEnabled => false;

		public int SpectatedPlayerId => 0;

		public int SpectatedTeamId => 0;

		public EntityManager SpectatedChar => null;

		public PlayerManager SpectatedPlayer => null;

		public int NetworkspectatorCount
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

		public override void OnStartClient()
		{
		}

		public void ManagedUpdate()
		{
		}

		public void SpectatorCycleNextPlayer()
		{
		}

		public void SpectatorCyclePrevPlayer()
		{
		}

		public void MouseSelectSpectatingPlayer()
		{
		}

		[Command]
		public void CmdGetSpectatedPlayer(CycleAction cycleAction)
		{
		}

		[Command]
		public void CmdGetSpectatedPlayer(int playerId)
		{
		}

		public void SetInputCycleEnabled(bool isEnabled)
		{
		}

		[Server]
		public void SvEnableSpectatorPlayer(int playerIdToFollow = 0)
		{
		}

		[Server]
		public void FindAndSetPlayerToSpectate(int playerToFollow, CycleAction cycleAction = CycleAction.None)
		{
		}

		[Server]
		public int GetSpectatedPlayerId(int startingPlayerId, CycleAction cycleAction)
		{
			return 0;
		}

		[Server]
		public void SvDisableSpectatorMode()
		{
		}

		[Server]
		public void SvRemoveCurrentSpectatorPlayerCount()
		{
		}

		[TargetRpc]
		public void TargetSetSpectatedPlayer(NetworkConnection conn, PlayerManager playerToSpectate, uint charNetId, int followPlayerId, int followTeamId)
		{
		}

		[TargetRpc]
		public void TargetRpcDisableSpectatorMode(NetworkConnection conn)
		{
		}

		[ClientRpc]
		public void RpcOnTeleported()
		{
		}

		[Client]
		public void ClEnableSpectatorMode()
		{
		}

		[Client]
		[IteratorStateMachine(typeof(_003CWaitToSetSpectatedPlayer_003Ed__52))]
		public IEnumerator WaitToSetSpectatedPlayer(PlayerManager playerToSpectate, uint charToSpectateNetId)
		{
			return null;
		}

		[Client]
		public void ClFollowSpectatedPlayer(EntityManager charToSpectate)
		{
		}

		[Client]
		public void ClDisableSpectatorMode()
		{
		}

		[Client]
		public void ClStartSpectatedPlayer(EntityManager spectatedChar)
		{
		}

		[Client]
		public void ClStopSpectatedPlayer(EntityManager spectatedChar)
		{
		}

		public void UpdatePlayerLocalOverlays(EntityManager charToSpectate)
		{
		}

		public void RefreshAllChars()
		{
		}

		public void SetSpectatorCameraTarget(EntityManager spectatedChar)
		{
		}

		public void UISetSpectatedPlayerName(string playerName)
		{
		}

		public void OnSpectatorCountChanged(int oldValue, int newValue)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_CmdGetSpectatedPlayer__CycleAction(CycleAction cycleAction)
		{
		}

		public static void InvokeUserCode_CmdGetSpectatedPlayer__CycleAction(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdGetSpectatedPlayer__Int32(int playerId)
		{
		}

		public static void InvokeUserCode_CmdGetSpectatedPlayer__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetSetSpectatedPlayer__NetworkConnection__PlayerManager__UInt32__Int32__Int32(NetworkConnection conn, PlayerManager playerToSpectate, uint charNetId, int followPlayerId, int followTeamId)
		{
		}

		public static void InvokeUserCode_TargetSetSpectatedPlayer__NetworkConnection__PlayerManager__UInt32__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetRpcDisableSpectatorMode__NetworkConnection(NetworkConnection conn)
		{
		}

		public static void InvokeUserCode_TargetRpcDisableSpectatorMode__NetworkConnection(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcOnTeleported()
		{
		}

		public static void InvokeUserCode_RpcOnTeleported(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static PlayerSpectate()
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
