using System;
using System.Runtime.InteropServices;
using BAPBAP.Player;
using BAPBAP.UI;
using Mirror;
using UnityEngine;

namespace BAPBAP.Game
{
	public class PlayerPreMatch : NetworkBehaviour
	{
		[NonSerialized]
		public PlayerManager _playerManager;

		[NonSerialized]
		public PreMatchManager _preMatchManager;

		[NonSerialized]
		public UIPreMatch _uiPreMatch;

		[SyncVar(hook = "OnLockStatusChanged")]
		public bool LockedCharacter;

		[SyncVar]
		public Vector2 SelectedSpawnPoint;

		[SyncVar]
		public bool IsSpawnLeader;

		public Action OnCharacterLockedEvent;

		public Action<bool, bool> _Mirror_SyncVarHookDelegate_LockedCharacter;

		public bool NetworkLockedCharacter
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

		public Vector2 NetworkSelectedSpawnPoint
		{
			get
			{
				return default(Vector2);
			}
			[param: In]
			set
			{
			}
		}

		public bool NetworkIsSpawnLeader
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

		public void Initialize(PlayerManager playerManager)
		{
		}

		public void SetPlayerCharacter(int charId)
		{
		}

		public void SetTeammateCharacter(PlayerManager teammate, int charId)
		{
		}

		public void SetPlayerCharacterLocked()
		{
		}

		public void SetTeammateCharacterLocked(PlayerManager teammate)
		{
		}

		[TargetRpc]
		public void TargetSetSpawnSelection(NetworkConnection conn, Vector2 spawnLocation, bool isLocked)
		{
		}

		[TargetRpc]
		public void TargetSetEnemySpawnSelection(NetworkConnection conn, Vector2 spawnLocation)
		{
		}

		[Command]
		public void CmdTrySelectCharacter(PlayerManager player, int charId)
		{
		}

		[Command]
		public void CmdTryLockCharacter(PlayerManager player)
		{
		}

		[Command]
		public void CmdTrySelectSpawnLocation(PlayerManager player, Vector2 spawnLocation)
		{
		}

		public void OnLockStatusChanged(bool oldValue, bool newValue)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_TargetSetSpawnSelection__NetworkConnection__Vector2__Boolean(NetworkConnection conn, Vector2 spawnLocation, bool isLocked)
		{
		}

		public static void InvokeUserCode_TargetSetSpawnSelection__NetworkConnection__Vector2__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetSetEnemySpawnSelection__NetworkConnection__Vector2(NetworkConnection conn, Vector2 spawnLocation)
		{
		}

		public static void InvokeUserCode_TargetSetEnemySpawnSelection__NetworkConnection__Vector2(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdTrySelectCharacter__PlayerManager__Int32(PlayerManager player, int charId)
		{
		}

		public static void InvokeUserCode_CmdTrySelectCharacter__PlayerManager__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdTryLockCharacter__PlayerManager(PlayerManager player)
		{
		}

		public static void InvokeUserCode_CmdTryLockCharacter__PlayerManager(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdTrySelectSpawnLocation__PlayerManager__Vector2(PlayerManager player, Vector2 spawnLocation)
		{
		}

		public static void InvokeUserCode_CmdTrySelectSpawnLocation__PlayerManager__Vector2(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static PlayerPreMatch()
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
