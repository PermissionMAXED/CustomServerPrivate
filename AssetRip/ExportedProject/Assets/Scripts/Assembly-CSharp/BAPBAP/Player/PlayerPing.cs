using System;
using System.Collections.Generic;
using BAPBAP.Entities;
using BAPBAP.Game;
using BAPBAP.Local;
using BAPBAP.UI;
using Mirror;
using UnityEngine;

namespace BAPBAP.Player
{
	public class PlayerPing : NetworkBehaviour
	{
		[Serializable]
		public class Ping
		{
			public PingTarget target;

			public GameObject pingWorldObj;

			public GameObject pingUIObj;

			public GameObject pingMinimapIcon;

			public Vector2 worldPos;

			public float ttl;

			public void SetTargetAttached()
			{
			}

			public void SetTargetWorld()
			{
			}

			public Vector3 V3WorldPos()
			{
				return default(Vector3);
			}

			public virtual bool NullTarget()
			{
				return false;
			}

			public virtual void CreateOnWorld(float ttl)
			{
			}

			public void DestroyFromWorld()
			{
			}

			public virtual bool IsSameType(Ping otherPing)
			{
				return false;
			}

			public virtual bool IsEqual(Ping otherPing)
			{
				return false;
			}
		}

		public class PingCharacter : Ping
		{
			public int entityPrefabId;

			public CharType charType;

			public int characterId;

			public int playerId;

			public uint attachedNetId;

			public Transform attachedTransform;

			public PingCharacter(uint attachedNetId, Vector2 worldPos, CharType charType, int characterId, int entityPrefabId, int playerId)
			{
			}

			public override bool NullTarget()
			{
				return false;
			}

			public override void CreateOnWorld(float ttl)
			{
			}

			public override bool IsSameType(Ping otherPing)
			{
				return false;
			}

			public override bool IsEqual(Ping otherPing)
			{
				return false;
			}
		}

		public class PingEntity : Ping
		{
			public int entityPrefabId;

			public uint attachedNetId;

			public Transform attachedTransform;

			public PingEntity(uint attachedNetId, Vector2 worldPos, int entityPrefabId)
			{
			}

			public override bool NullTarget()
			{
				return false;
			}

			public override void CreateOnWorld(float ttl)
			{
			}

			public override bool IsSameType(Ping otherPing)
			{
				return false;
			}

			public override bool IsEqual(Ping otherPing)
			{
				return false;
			}
		}

		public class PingItem : Ping
		{
			public int entityPrefabId;

			public int itemId;

			public uint attachedNetId;

			public Transform attachedTransform;

			public PingItem(uint attachedNetId, Vector2 worldPos, int itemId, int entityPrefabId)
			{
			}

			public override bool NullTarget()
			{
				return false;
			}

			public override void CreateOnWorld(float ttl)
			{
			}

			public override bool IsSameType(Ping otherPing)
			{
				return false;
			}

			public override bool IsEqual(Ping otherPing)
			{
				return false;
			}
		}

		public class PingPosition : Ping
		{
			public PositionType positionType;

			public PingPosition(PositionType positionType, Vector3 worldPos)
			{
			}

			public override void CreateOnWorld(float ttl)
			{
			}

			public override bool IsSameType(Ping otherPing)
			{
				return false;
			}

			public override bool IsEqual(Ping otherPing)
			{
				return false;
			}
		}

		public enum PingTarget
		{
			World = 0,
			Attached = 1
		}

		public enum PositionType
		{
			Position = 0,
			EnemySpotted = 1,
			StickTogether = 2,
			OnMyWay = 3,
			Retreat = 4,
			Attack = 5,
			Wait = 6,
			NeedHelp = 7,
			Healing = 8
		}

		public enum CharType
		{
			Ally = 0,
			Enemy = 1,
			AllyNpc = 2,
			EnemyNpc = 3,
			Neutral = 4
		}

		[NonSerialized]
		public PlayerManager playerManager;

		[NonSerialized]
		public PlayerTeammates playerTeammates;

		[NonSerialized]
		public PlayerChat playerChat;

		[NonSerialized]
		public PingManager pingManager;

		[NonSerialized]
		public GameManager gameManager;

		[NonSerialized]
		public ItemManager itemManager;

		[NonSerialized]
		public AudioManager audioManager;

		[NonSerialized]
		public UISelectionWheel uiSelectionWheel;

		[NonSerialized]
		public CameraController camController;

		[NonSerialized]
		public Camera mainCamera;

		[NonSerialized]
		public EntityAssetsManager entityAssetsManager;

		[NonSerialized]
		public UIManager uiManager;

		[NonSerialized]
		public UIGameMode uiGameMode;

		[NonSerialized]
		public UIChat uiChat;

		[NonSerialized]
		public UIMinimap uiMinimap;

		[NonSerialized]
		public UITeammates uiTeammates;

		[NonSerialized]
		public UIAbilities uiAbilities;

		[NonSerialized]
		public float cooldownTimer;

		[NonSerialized]
		public float pingSpamTimer;

		[NonSerialized]
		public int groundMask;

		[NonSerialized]
		public int entityMask;

		[NonSerialized]
		public int obstacleMask;

		[NonSerialized]
		public List<Ping> playerPings;

		public void Initialize(PlayerManager _playerManager)
		{
		}

		public void Awake()
		{
		}

		public void ManagedUpdate()
		{
		}

		public void DoPing(Vector2 screenPosition)
		{
		}

		public void DoContextualPingOnWorld(Vector2 screenPosition)
		{
		}

		public void DoMobilePing(PositionType type, Vector2 screenPosition)
		{
		}

		public void OnPositionPingOnMap(Vector2 screenPosition)
		{
		}

		public void OnMinimapNetIdPing(uint entityNetId, int entityPrefabId)
		{
		}

		public void DoWheelMarkerPing(int positionTypeId, Vector2 screenPos)
		{
		}

		public void TryCreatePing(Ping newPing)
		{
		}

		public Ping GetContextualPing(RaycastHit[] hits, Ray mouseRay)
		{
			return null;
		}

		public Ping TryGetCharacterPing(PingableEntity pingableEntity)
		{
			return null;
		}

		public Ping TryGetEntityPing(PingableEntity pingableEntity)
		{
			return null;
		}

		public Ping TryGetItemPing(PingableEntity pingableEntity)
		{
			return null;
		}

		public Ping TryGetShopItemPing(PingableEntity shopPingableEntity)
		{
			return null;
		}

		public Ping GetPositionPing(Vector3 worldPos, PositionType positionType = PositionType.Position)
		{
			return null;
		}

		public bool TryGetEqualPing(Ping newPing, out Ping equalPing)
		{
			equalPing = null;
			return false;
		}

		public bool TryGetEqualPingTeammate(Ping newPing, out Ping equalPing)
		{
			equalPing = null;
			return false;
		}

		public bool TryGetSameTypePing(Ping newPing, out Ping equalPing)
		{
			equalPing = null;
			return false;
		}

		public bool TryGetSameTypePingTeammate(Ping newPing, out Ping equalPing)
		{
			equalPing = null;
			return false;
		}

		public void ClCreatePing(Ping ping, bool playSfx = true)
		{
		}

		public void ClRemovePing(Ping referencePing)
		{
		}

		public bool GetIsPlayerOnCooldown()
		{
			return false;
		}

		public void OnSpamPingAdded()
		{
		}

		public bool TryGetWorldPositionFromMinimapPosition(Vector2 screenPos, out Vector2 worldPosition)
		{
			worldPosition = default(Vector2);
			return false;
		}

		public Transform TryGetTargetAttachedObj(uint attachedNetId)
		{
			return null;
		}

		public bool CurrentlyHasLineOfSight(Vector3 targetPos)
		{
			return false;
		}

		public CharType GetCharType(EntityManager entityManager)
		{
			return default(CharType);
		}

		public Color GetCharTypeColor(CharType charType)
		{
			return default(Color);
		}

		public string GetCharTypeName(CharType charType)
		{
			return null;
		}

		public bool IsPingTypeOverMaximumAllowed(Ping ping)
		{
			return false;
		}

		public int GetCountOfSameTypePing(Ping ping)
		{
			return 0;
		}

		public void CreatePingChatMsg(Ping ping)
		{
		}

		public void OnAbilityPing(int cmdId)
		{
		}

		public void OnItemSlotPing(int itemSlotId)
		{
		}

		[Command]
		public void CmdSendChatMsgPos(PositionType positionType)
		{
		}

		[ClientRpc]
		public void RpcSendChatMsgPos(PositionType positionType)
		{
		}

		[Command]
		public void CmdSendChatMsgChar(CharType charType, int charId, int entityPrefabId, int playerId)
		{
		}

		[ClientRpc]
		public void RpcSendChatMsgChar(CharType charType, int charId, int entityPrefabId, int playerId)
		{
		}

		[Command]
		public void CmdSendChatMsgItem(int itemId)
		{
		}

		[ClientRpc]
		public void RpcSendChatMsgItem(int itemId)
		{
		}

		[Command]
		public void CmdSendChatMsgItemShop(int itemId)
		{
		}

		[ClientRpc]
		public void RpcSendChatMsgItemShop(int itemId)
		{
		}

		[Command]
		public void CmdSendChatMsgEntity(int entityTypeId)
		{
		}

		[ClientRpc]
		public void RpcSendChatMsgEntity(int entityTypeId)
		{
		}

		[Command]
		public void CmdSendChatMsgAbility(int charId, int abilityId, float remainingCd)
		{
		}

		[ClientRpc]
		public void RpcSendChatMsgAbility(int charId, int abilityId, float cdDecValue)
		{
		}

		[Command]
		public void CmdSendChatMsgItemSlot(int itemSlotId)
		{
		}

		[ClientRpc]
		public void RpcSendChatMsgItemSlot(int itemSlotId)
		{
		}

		public void CreateLocalPlayerPing(Ping ping)
		{
		}

		public void DestroyLocalPlayerPing(Ping ping)
		{
		}

		public void UpdatePingOnTeam(Ping ping, bool createOrDestroy)
		{
		}

		[Command]
		public void CmdCreatePingPosition(PositionType posType, Vector2 worldPos)
		{
		}

		[Command]
		public void CmdCreatePingCharacter(uint attachedNetId, Vector2 worldPos, CharType charType, int characterId, int entityPrefabId, int playerId)
		{
		}

		[Command]
		public void CmdCreatePingEntity(uint attachedNetId, Vector2 worldPos, int entityTypeId)
		{
		}

		[Command]
		public void CmdCreatePingItem(uint attachedNetId, Vector2 worldPos, int itemId, int entityPrefabId)
		{
		}

		[TargetRpc]
		public void TargetCreatePingPosition(NetworkConnection conn, PositionType posType, Vector2 worldPos)
		{
		}

		[TargetRpc]
		public void TargetCreatePingCharacter(NetworkConnection conn, uint charNetId, Vector2 worldPos, CharType charType, int character, int entityPrefabId, int playerId)
		{
		}

		[TargetRpc]
		public void TargetCreatePingEntity(NetworkConnection conn, uint charNetId, Vector2 worldPos, int entityTypeId)
		{
		}

		[TargetRpc]
		public void TargetCreatePingItem(NetworkConnection conn, uint itemNetId, Vector2 worldPos, int itemId, int entityPrefabId)
		{
		}

		[Command]
		public void CmdDestroyPingPosition(PositionType posType, Vector2 worldPos)
		{
		}

		[Command]
		public void CmdDestroyPingCharacter(uint attachedNetId, CharType charType, int characterId)
		{
		}

		[Command]
		public void CmdDestroyPingEntity(uint attachedNetId, int entityTypeId)
		{
		}

		[Command]
		public void CmdDestroyPingItem(uint attachedNetId, int itemId, int entityPrefabId)
		{
		}

		[TargetRpc]
		public void TargetDestroyPingPosition(NetworkConnection conn, PositionType posType, Vector2 worldPos)
		{
		}

		[TargetRpc]
		public void TargetDestroyPingCharacter(NetworkConnection conn, uint charNetId, CharType charType, int character)
		{
		}

		[TargetRpc]
		public void TargetDestroyPingEntity(NetworkConnection conn, uint charNetId, int entityTypeId)
		{
		}

		[TargetRpc]
		public void TargetDestroyPingItem(NetworkConnection conn, uint itemNetId, int itemId, int entityPrefabId)
		{
		}

		public void OnDestroy()
		{
		}

		public void DestroyAllPings()
		{
		}

		public void OnAttachedPingableObjectDestroyed(uint _netId)
		{
		}

		public void TryDestroyAttachedPing(uint _netId)
		{
		}

		public void TryRemoveReviveAltarPings(uint respawnAltarNetId)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_CmdSendChatMsgPos__PositionType(PositionType positionType)
		{
		}

		public static void InvokeUserCode_CmdSendChatMsgPos__PositionType(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSendChatMsgPos__PositionType(PositionType positionType)
		{
		}

		public static void InvokeUserCode_RpcSendChatMsgPos__PositionType(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdSendChatMsgChar__CharType__Int32__Int32__Int32(CharType charType, int charId, int entityPrefabId, int playerId)
		{
		}

		public static void InvokeUserCode_CmdSendChatMsgChar__CharType__Int32__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSendChatMsgChar__CharType__Int32__Int32__Int32(CharType charType, int charId, int entityPrefabId, int playerId)
		{
		}

		public static void InvokeUserCode_RpcSendChatMsgChar__CharType__Int32__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdSendChatMsgItem__Int32(int itemId)
		{
		}

		public static void InvokeUserCode_CmdSendChatMsgItem__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSendChatMsgItem__Int32(int itemId)
		{
		}

		public static void InvokeUserCode_RpcSendChatMsgItem__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdSendChatMsgItemShop__Int32(int itemId)
		{
		}

		public static void InvokeUserCode_CmdSendChatMsgItemShop__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSendChatMsgItemShop__Int32(int itemId)
		{
		}

		public static void InvokeUserCode_RpcSendChatMsgItemShop__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdSendChatMsgEntity__Int32(int entityTypeId)
		{
		}

		public static void InvokeUserCode_CmdSendChatMsgEntity__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSendChatMsgEntity__Int32(int entityTypeId)
		{
		}

		public static void InvokeUserCode_RpcSendChatMsgEntity__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdSendChatMsgAbility__Int32__Int32__Single(int charId, int abilityId, float remainingCd)
		{
		}

		public static void InvokeUserCode_CmdSendChatMsgAbility__Int32__Int32__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSendChatMsgAbility__Int32__Int32__Single(int charId, int abilityId, float cdDecValue)
		{
		}

		public static void InvokeUserCode_RpcSendChatMsgAbility__Int32__Int32__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdSendChatMsgItemSlot__Int32(int itemSlotId)
		{
		}

		public static void InvokeUserCode_CmdSendChatMsgItemSlot__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSendChatMsgItemSlot__Int32(int itemSlotId)
		{
		}

		public static void InvokeUserCode_RpcSendChatMsgItemSlot__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdCreatePingPosition__PositionType__Vector2(PositionType posType, Vector2 worldPos)
		{
		}

		public static void InvokeUserCode_CmdCreatePingPosition__PositionType__Vector2(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdCreatePingCharacter__UInt32__Vector2__CharType__Int32__Int32__Int32(uint attachedNetId, Vector2 worldPos, CharType charType, int characterId, int entityPrefabId, int playerId)
		{
		}

		public static void InvokeUserCode_CmdCreatePingCharacter__UInt32__Vector2__CharType__Int32__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdCreatePingEntity__UInt32__Vector2__Int32(uint attachedNetId, Vector2 worldPos, int entityTypeId)
		{
		}

		public static void InvokeUserCode_CmdCreatePingEntity__UInt32__Vector2__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdCreatePingItem__UInt32__Vector2__Int32__Int32(uint attachedNetId, Vector2 worldPos, int itemId, int entityPrefabId)
		{
		}

		public static void InvokeUserCode_CmdCreatePingItem__UInt32__Vector2__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetCreatePingPosition__NetworkConnection__PositionType__Vector2(NetworkConnection conn, PositionType posType, Vector2 worldPos)
		{
		}

		public static void InvokeUserCode_TargetCreatePingPosition__NetworkConnection__PositionType__Vector2(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetCreatePingCharacter__NetworkConnection__UInt32__Vector2__CharType__Int32__Int32__Int32(NetworkConnection conn, uint charNetId, Vector2 worldPos, CharType charType, int character, int entityPrefabId, int playerId)
		{
		}

		public static void InvokeUserCode_TargetCreatePingCharacter__NetworkConnection__UInt32__Vector2__CharType__Int32__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetCreatePingEntity__NetworkConnection__UInt32__Vector2__Int32(NetworkConnection conn, uint charNetId, Vector2 worldPos, int entityTypeId)
		{
		}

		public static void InvokeUserCode_TargetCreatePingEntity__NetworkConnection__UInt32__Vector2__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetCreatePingItem__NetworkConnection__UInt32__Vector2__Int32__Int32(NetworkConnection conn, uint itemNetId, Vector2 worldPos, int itemId, int entityPrefabId)
		{
		}

		public static void InvokeUserCode_TargetCreatePingItem__NetworkConnection__UInt32__Vector2__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdDestroyPingPosition__PositionType__Vector2(PositionType posType, Vector2 worldPos)
		{
		}

		public static void InvokeUserCode_CmdDestroyPingPosition__PositionType__Vector2(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdDestroyPingCharacter__UInt32__CharType__Int32(uint attachedNetId, CharType charType, int characterId)
		{
		}

		public static void InvokeUserCode_CmdDestroyPingCharacter__UInt32__CharType__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdDestroyPingEntity__UInt32__Int32(uint attachedNetId, int entityTypeId)
		{
		}

		public static void InvokeUserCode_CmdDestroyPingEntity__UInt32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdDestroyPingItem__UInt32__Int32__Int32(uint attachedNetId, int itemId, int entityPrefabId)
		{
		}

		public static void InvokeUserCode_CmdDestroyPingItem__UInt32__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetDestroyPingPosition__NetworkConnection__PositionType__Vector2(NetworkConnection conn, PositionType posType, Vector2 worldPos)
		{
		}

		public static void InvokeUserCode_TargetDestroyPingPosition__NetworkConnection__PositionType__Vector2(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetDestroyPingCharacter__NetworkConnection__UInt32__CharType__Int32(NetworkConnection conn, uint charNetId, CharType charType, int character)
		{
		}

		public static void InvokeUserCode_TargetDestroyPingCharacter__NetworkConnection__UInt32__CharType__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetDestroyPingEntity__NetworkConnection__UInt32__Int32(NetworkConnection conn, uint charNetId, int entityTypeId)
		{
		}

		public static void InvokeUserCode_TargetDestroyPingEntity__NetworkConnection__UInt32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetDestroyPingItem__NetworkConnection__UInt32__Int32__Int32(NetworkConnection conn, uint itemNetId, int itemId, int entityPrefabId)
		{
		}

		public static void InvokeUserCode_TargetDestroyPingItem__NetworkConnection__UInt32__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static PlayerPing()
		{
		}
	}
}
