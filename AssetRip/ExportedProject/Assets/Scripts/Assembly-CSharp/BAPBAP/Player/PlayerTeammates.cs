using System;
using System.Collections.Generic;
using BAPBAP.Entities;
using BAPBAP.UI;
using Mirror;
using UnityEngine;

namespace BAPBAP.Player
{
	public class PlayerTeammates : NetworkBehaviour
	{
		public struct TeammatePosLerpData
		{
			public Vector2 lerpedPos;

			public Vector2 serverPos;
		}

		[NonSerialized]
		public PlayerManager playerManager;

		[NonSerialized]
		public UIManager uiManager;

		[NonSerialized]
		public UIMinimap uiMinimap;

		[NonSerialized]
		public UITeammates uiTeammates;

		public List<PlayerManager> teammatesPlayers;

		[NonSerialized]
		public bool isTeammateMuted;

		[NonSerialized]
		public float lerpFactor;

		[NonSerialized]
		public Dictionary<int, TeammatePosLerpData> teammateWorldPosByInstanceId;

		[NonSerialized]
		public List<int> keyCacheList;

		public void Initialize(PlayerManager _playerManager)
		{
		}

		public void ManagedFixedUpdate()
		{
		}

		public void ManagedLateUpdate()
		{
		}

		public void SvSendTeammatePosition(PlayerManager teammate, EntityManager entityManager, bool isPrimary)
		{
		}

		[TargetRpc]
		public void TargetRpcSendPrimaryTeammatePosition(NetworkConnection conn, int instanceId, Vector2 worldPos)
		{
		}

		[TargetRpc]
		public void TargetRpcSendSecondaryTeammatePosition(NetworkConnection conn, int id, Vector2 worldPos)
		{
		}

		public void CreateTeammateIcon(int instanceId)
		{
		}

		public void TryRemoveTeammateIcon(int instanceId)
		{
		}

		public void UpdateTeammateIconPosition(int instanceId, Vector2 worldPos)
		{
		}

		[Server]
		public void SvClearTeammates()
		{
		}

		[TargetRpc]
		public void TargetOnTeammateCharSpawned(NetworkConnection conn, int instanceId)
		{
		}

		[TargetRpc]
		public void TargetOnTeammateCharDestroyed(NetworkConnection conn, int instanceId)
		{
		}

		[TargetRpc]
		public void TargetOnTeammateHitReceived(NetworkConnection conn, int instanceId, bool hitFromPlayer)
		{
		}

		[TargetRpc]
		public void TargetOnTeammateHitLanded(NetworkConnection conn, int instanceId)
		{
		}

		[TargetRpc]
		public void TargetOnTeammateDowned(NetworkConnection conn, int instanceId, bool isDowned)
		{
		}

		[TargetRpc]
		public void TargetOnTeammateDownedTimer(NetworkConnection conn, float normTime)
		{
		}

		[TargetRpc]
		public void TargetAddTeammatePlayer(NetworkConnection conn, PlayerManager teammate)
		{
		}

		[TargetRpc]
		public void TargetRemoveTeammatePlayer(NetworkConnection conn, int teammatePlayerId, List<int> charInstanceIds)
		{
		}

		[TargetRpc]
		public void TargetClearAllTeammatePlayers(NetworkConnection conn)
		{
		}

		public void AddTeammate(PlayerManager teammatePlayer)
		{
		}

		public void RemoveTeammate(int playerId, List<int> charInstanceIds)
		{
		}

		public void RemoveAllTeammatesUI()
		{
		}

		public void OnPlayerIsDeadChanged()
		{
		}

		public void OnDownedStateChanged()
		{
		}

		public void OnTeammateKilled(int instanceId)
		{
		}

		public void OnTeammateOwnedSecondaryCharacterKilled(int instanceId)
		{
		}

		public void SetTeammateReviveAltarUpdate()
		{
		}

		public void RefreshShopPrices()
		{
		}

		public bool IsTeammate()
		{
			return false;
		}

		public int GetTeammateCount()
		{
			return 0;
		}

		[Server]
		public bool AreAllTeammatesAlive()
		{
			return false;
		}

		public bool AreAllTeammatesDead()
		{
			return false;
		}

		public bool AreAllTeammatesDownedOrDead()
		{
			return false;
		}

		public int GetAliveTeammateCount()
		{
			return 0;
		}

		public int GetDownedOrDeadTeammateCount()
		{
			return 0;
		}

		public int GetDownedTeammateCount()
		{
			return 0;
		}

		public bool IsAnyTeammateAlive()
		{
			return false;
		}

		public bool IsAnyTeammateDead()
		{
			return false;
		}

		public void SetTeammateMuted(bool isMuted)
		{
		}

		[TargetRpc]
		public void TargetUpdateTeammateHp(NetworkConnection conn, int hp, int maxHp, int shield)
		{
		}

		[TargetRpc]
		public void TargetUITeammateSetItem(NetworkConnection conn, int itemId, byte slotId)
		{
		}

		public void UITeammateAddItemToSlot(int itemId, int slotId)
		{
		}

		[TargetRpc]
		public void TargetUITeammateSetConsumable(NetworkConnection conn, byte slotId, int itemId, int count, int maxCount)
		{
		}

		public void UITeammateAddConsumable(int slotId, int itemId, int count, int maxCount)
		{
		}

		[TargetRpc]
		public void TargetUITeammateSetAbility(NetworkConnection conn, int itemId)
		{
		}

		public void UITeammateSetAbility(int itemId)
		{
		}

		[TargetRpc]
		public void TargetUITeammateSetGold(NetworkConnection conn, int amount)
		{
		}

		public void UITeammateSetGold(int amount)
		{
		}

		[TargetRpc]
		public void TargetUITeammateSetAugment(NetworkConnection conn, int augmentId)
		{
		}

		public void SetTeammateName(int playerId, string name)
		{
		}

		public void SetTeammateHp(int playerId, int hp, int maxHp, int shield)
		{
		}

		public void SetTeammateCharPortrait(int playerId, Sprite portrait)
		{
		}

		public void SetTeammateDeadStatus(int playerId, bool isDead)
		{
		}

		public void SetTeammateDownedStatus(int playerId, PlayerManager.DownedState downedState)
		{
		}

		public void SetTeammateDownedTime(int playerId, float normTime)
		{
		}

		public void TriggerTeammateDowned(int playerId)
		{
		}

		public void TriggerTeammateDamageOverlay(int playerId, int instanceId, bool hitFromPlayer)
		{
		}

		public void SetTeammateItem(int playerId, int slotId, int itemId)
		{
		}

		public void RemoveTeammateItem(int playerId, int slotId)
		{
		}

		public void SetTeammateConsumable(int playerId, int slotId, int itemId)
		{
		}

		public void SetTeammateConsumableCount(int playerId, int slotId, int count, int maxCount)
		{
		}

		public void RemoveTeammateConsumable(int playerId, int slotId)
		{
		}

		public void SetTeammateAbility(int playerId, int itemId)
		{
		}

		public void RemoveTeammateAbility(int playerId)
		{
		}

		public void SetTeammateAugment(int playerId, int augmentId)
		{
		}

		public void SetTeammateGold(int playerId, int amount)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_TargetRpcSendPrimaryTeammatePosition__NetworkConnection__Int32__Vector2(NetworkConnection conn, int instanceId, Vector2 worldPos)
		{
		}

		public static void InvokeUserCode_TargetRpcSendPrimaryTeammatePosition__NetworkConnection__Int32__Vector2(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetRpcSendSecondaryTeammatePosition__NetworkConnection__Int32__Vector2(NetworkConnection conn, int id, Vector2 worldPos)
		{
		}

		public static void InvokeUserCode_TargetRpcSendSecondaryTeammatePosition__NetworkConnection__Int32__Vector2(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetOnTeammateCharSpawned__NetworkConnection__Int32(NetworkConnection conn, int instanceId)
		{
		}

		public static void InvokeUserCode_TargetOnTeammateCharSpawned__NetworkConnection__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetOnTeammateCharDestroyed__NetworkConnection__Int32(NetworkConnection conn, int instanceId)
		{
		}

		public static void InvokeUserCode_TargetOnTeammateCharDestroyed__NetworkConnection__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetOnTeammateHitReceived__NetworkConnection__Int32__Boolean(NetworkConnection conn, int instanceId, bool hitFromPlayer)
		{
		}

		public static void InvokeUserCode_TargetOnTeammateHitReceived__NetworkConnection__Int32__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetOnTeammateHitLanded__NetworkConnection__Int32(NetworkConnection conn, int instanceId)
		{
		}

		public static void InvokeUserCode_TargetOnTeammateHitLanded__NetworkConnection__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetOnTeammateDowned__NetworkConnection__Int32__Boolean(NetworkConnection conn, int instanceId, bool isDowned)
		{
		}

		public static void InvokeUserCode_TargetOnTeammateDowned__NetworkConnection__Int32__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetOnTeammateDownedTimer__NetworkConnection__Single(NetworkConnection conn, float normTime)
		{
		}

		public static void InvokeUserCode_TargetOnTeammateDownedTimer__NetworkConnection__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetAddTeammatePlayer__NetworkConnection__PlayerManager(NetworkConnection conn, PlayerManager teammate)
		{
		}

		public static void InvokeUserCode_TargetAddTeammatePlayer__NetworkConnection__PlayerManager(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetRemoveTeammatePlayer__NetworkConnection__Int32__List_00601(NetworkConnection conn, int teammatePlayerId, List<int> charInstanceIds)
		{
		}

		public static void InvokeUserCode_TargetRemoveTeammatePlayer__NetworkConnection__Int32__List_00601(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetClearAllTeammatePlayers__NetworkConnection(NetworkConnection conn)
		{
		}

		public static void InvokeUserCode_TargetClearAllTeammatePlayers__NetworkConnection(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetUpdateTeammateHp__NetworkConnection__Int32__Int32__Int32(NetworkConnection conn, int hp, int maxHp, int shield)
		{
		}

		public static void InvokeUserCode_TargetUpdateTeammateHp__NetworkConnection__Int32__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetUITeammateSetItem__NetworkConnection__Int32__Byte(NetworkConnection conn, int itemId, byte slotId)
		{
		}

		public static void InvokeUserCode_TargetUITeammateSetItem__NetworkConnection__Int32__Byte(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetUITeammateSetConsumable__NetworkConnection__Byte__Int32__Int32__Int32(NetworkConnection conn, byte slotId, int itemId, int count, int maxCount)
		{
		}

		public static void InvokeUserCode_TargetUITeammateSetConsumable__NetworkConnection__Byte__Int32__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetUITeammateSetAbility__NetworkConnection__Int32(NetworkConnection conn, int itemId)
		{
		}

		public static void InvokeUserCode_TargetUITeammateSetAbility__NetworkConnection__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetUITeammateSetGold__NetworkConnection__Int32(NetworkConnection conn, int amount)
		{
		}

		public static void InvokeUserCode_TargetUITeammateSetGold__NetworkConnection__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetUITeammateSetAugment__NetworkConnection__Int32(NetworkConnection conn, int augmentId)
		{
		}

		public static void InvokeUserCode_TargetUITeammateSetAugment__NetworkConnection__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static PlayerTeammates()
		{
		}
	}
}
