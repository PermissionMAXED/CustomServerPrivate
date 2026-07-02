using System;
using System.Text;
using BAPBAP.Game;
using BAPBAP.Items;
using BAPBAP.Local;
using BAPBAP.Network;
using BAPBAP.UI;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	[DisallowMultipleComponent]
	public class CharItems : NetworkBehaviour, INetworkPredicted
	{
		public class Inventory
		{
			public struct ConsumableEntry
			{
				public int itemId;

				public int count;

				public ConsumableEntry(int _itemId, int _count)
				{
					itemId = 0;
					count = 0;
				}
			}

			public int[] gearItemIds;

			public ConsumableEntry[] consumables;

			public int gold;

			public int abilityItemId;

			public Inventory()
			{
			}

			public Inventory(int gearCount, int consumableCount)
			{
			}
		}

		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public CharAbilities charAbilities;

		[NonSerialized]
		public CharHurtbox charHurtbox;

		[NonSerialized]
		public CharTriggerbox charTriggerbox;

		[NonSerialized]
		public EntityMovement charMove;

		[NonSerialized]
		public CharItemPickupAnim charItemPickupAnim;

		[NonSerialized]
		public GameManager gameManager;

		[NonSerialized]
		public ItemManager itemManager;

		[NonSerialized]
		public UIItems uiItems;

		[NonSerialized]
		public UIItemsWorldTooltip uiItemsWorldTooltip;

		[NonSerialized]
		public UISelectionWheelItemSwap uiConsumableSwapWheel;

		[NonSerialized]
		public UIPopUp uiPopUp;

		[NonSerialized]
		public AudioManager audioManager;

		[Tooltip("If enabled, will automatically update the power level when items change")]
		[SerializeField]
		[Header("Settings")]
		public bool updateItemPowerLevel;

		[NonSerialized]
		public float powerLevel;

		[NonSerialized]
		public bool allowItemDrops;

		[NonSerialized]
		public Inventory inventory;

		[NonSerialized]
		public ItemObject currentSelectedItem;

		[NonSerialized]
		public bool initialized;

		public void PreAwake(EntityManager e)
		{
		}

		public void Start()
		{
		}

		public void OnTick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public void Update()
		{
		}

		public void OnDisable()
		{
		}

		public void ClStartAuth()
		{
		}

		public void ClStopAuth()
		{
		}

		public void ForceAllHoveringItemsOnEnter()
		{
		}

		public void ForceHoveringItemOnEnter(ICharInteractable interactable)
		{
		}

		public void OnItemTriggerEnter(ItemObject itemObject)
		{
		}

		public void OnItemStartHovering(ItemObject itemObject)
		{
		}

		public void OnItemEnter(ItemObject itemObject)
		{
		}

		public void OnItemExit(ItemObject itemObject)
		{
		}

		public void InteractWithItem(ItemObject itemObject)
		{
		}

		public void UpdateCurrentItemPowerLevel()
		{
		}

		public float GetItemPowerLevel()
		{
			return 0f;
		}

		public bool ItemIsHovered(ItemObject itemObject)
		{
			return false;
		}

		public void RemoveHoveredItem(ItemObject itemObject)
		{
		}

		public bool ContainsBetterItem(int itemId, int itemTier)
		{
			return false;
		}

		public bool HasAvailableItemSlot(int slot)
		{
			return false;
		}

		public bool CanPickupItemObject(Item item)
		{
			return false;
		}

		public bool CanPickupItem(Gear gear)
		{
			return false;
		}

		public int GetCurrentJuiceCount()
		{
			return 0;
		}

		public int GetCurrentConsumableTypeCount(int id)
		{
			return 0;
		}

		public int GetCurrentConsumableSlot(int itemId)
		{
			return 0;
		}

		public int GetEmptyConsumableSlot()
		{
			return 0;
		}

		public int GetPickupConsumableSlot(int itemId)
		{
			return 0;
		}

		public bool IsConsumableMaxCount(int itemId)
		{
			return false;
		}

		public static int GetPickupConsumableSlot(Inventory inventory, int itemId)
		{
			return 0;
		}

		public bool CanPickupLootableAbility()
		{
			return false;
		}

		public void UpgradeGear(int slotId)
		{
		}

		[Command]
		public void CmdUpgradeGear(byte slotId)
		{
		}

		public void TryUpgradePin(int slotId)
		{
		}

		public void DeleteCurrentGear(int slot, bool deactivatePassive = true)
		{
		}

		public int GetSlotGearId(int slotId)
		{
			return 0;
		}

		public void DropItemOnWorld(int itemId, int amount = 1)
		{
		}

		[TargetRpc]
		public void TargetRpcStartConsumableSwapWheel(NetworkConnection conn, ItemObject itemObject)
		{
		}

		public void ClOpenConsumableSwapWheel()
		{
		}

		public void ClCloseConsumableSwapWheel()
		{
		}

		public void ClLoadConsumableWheelOptions()
		{
		}

		[Server]
		public bool TryGetGearObject(ItemObject itemObject)
		{
			return false;
		}

		[Server]
		public bool TryGetConsumableObject(ItemObject itemObject)
		{
			return false;
		}

		[Server]
		public bool TryGetLootableAbilityObject(ItemObject itemObject)
		{
			return false;
		}

		public bool TryGetCurrencyObject(ItemObject itemObject)
		{
			return false;
		}

		public void ObtainInventory(Inventory inventory)
		{
		}

		public void GetGearOnSlot(int slotId, int itemId)
		{
		}

		public bool TryGetConsumable(int itemId, int count)
		{
			return false;
		}

		public void GetConsumable(int slotId, int itemId, int count)
		{
		}

		public void GetLootableAbilityId(int itemId)
		{
		}

		public void GetGold(int currencyAmount)
		{
		}

		public void DropCurrentGear(int slotId)
		{
		}

		public void DropAndTrySwitchSlotItem(int slotId)
		{
		}

		public void DestroyCurrentItem(int slotId)
		{
		}

		public void DropAndTrySwitchConsumable(int slotId)
		{
		}

		public void DropConsumable(int slotId)
		{
		}

		[Command]
		public void CmdDropConsumableAmount(int slotId, int amount)
		{
		}

		public void DropConsumableAmount(int slotId, int amount)
		{
		}

		[Command]
		public void CmdSwapConsumableSlots(int slotId, int targetSlotId)
		{
		}

		public void RemoveConsumable(int slotId, bool playSFX)
		{
		}

		public void DropAndTrySwitchLootableAbility(bool checkCooldown)
		{
		}

		public void DropLootableAbility()
		{
		}

		public void RemoveLootableAbility(bool playSFX)
		{
		}

		public void ConsumeConsumable(int itemId)
		{
		}

		public void DropGoldCurrency()
		{
		}

		public void RemoveCurrentGoldAmount(bool playSFX, int amountToDrop)
		{
		}

		public void DropInventoryOnWorld(bool dropConsumables, bool dropGold)
		{
		}

		public void AssignNewGear(int slotId, int itemId)
		{
		}

		public void RemoveCurrentGear(int slotId)
		{
		}

		public void AssignNewLootableAbility(int itemId)
		{
		}

		public void RemoveLootableAbilitySlot(bool playSFX)
		{
		}

		public void ChangeGoldCurrency(int deltaAmount, bool playSfx = true)
		{
		}

		public void AssignCurrentGold(int newGold)
		{
		}

		public void ActivateGear(int itemId)
		{
		}

		public void DeactivateGear(int itemId, bool deactivatePassive = true)
		{
		}

		public void ActivateGearPassive(Gear gear)
		{
		}

		public void DeactivateGearPassive(Gear gear)
		{
		}

		public void ActivateItemStats(ItemStat[] itemStats)
		{
		}

		public void DeactivateItemStats(ItemStat[] itemStats)
		{
		}

		public void ActivateItemStat(ItemStat itemStat)
		{
		}

		public void DeactivateItemStat(ItemStat itemStat)
		{
		}

		public void SvPickUpItemAnimCl(ItemObject item)
		{
		}

		[ClientRpc]
		public void RpcPickUpItemAnim(ItemObject item)
		{
		}

		public void ClPickUpItemTransformAnim(Transform itemTransform, int itemId, int amount = 1)
		{
		}

		public void SvOnDropItemAnimCl(int itemId)
		{
		}

		[ClientRpc]
		public void RpcOnDropItemAnim(int itemId)
		{
		}

		[ClientRpc]
		public void RpcUIItemPlayFX(int itemId, byte slotId)
		{
		}

		public void UIItemPlayFX(int itemId, int slotId)
		{
		}

		public void UIConsumablePlayFX(int slotId, int newCount, bool added, int itemId)
		{
		}

		[ClientRpc]
		public void RpcPlayUnableToDropLootableFX()
		{
		}

		[ClientRpc]
		public void RpcUILootableAbilityPlayFX(int itemId)
		{
		}

		public void UILootableAbilityPlayFX(int itemId)
		{
		}

		[ClientRpc]
		public void RpcUIGoldPlayFX(int amount)
		{
		}

		public void UIGoldPlayFX(int amount, bool added)
		{
		}

		public void UIAddItem(int itemId, int slotId, bool playFx)
		{
		}

		public void UIRemoveItem(int itemId, int slotId)
		{
		}

		public void UIAddConsumable(int itemId, int slotId, bool playFx = true)
		{
		}

		public void UIRemoveConsumable(int itemId, int slotId, bool playSFX = true)
		{
		}

		public void UIAddLootableAbility(int itemId, bool playFx = true)
		{
		}

		public void UIRemoveLootableAbility(bool playSFX, int itemId)
		{
		}

		public void UIAddGold(int deltaAmount, bool playFx = true)
		{
		}

		public void UIRemoveGold(int deltaAmount, bool playSFX)
		{
		}

		public void SvUpdateItemOnAllTeammates(int itemId, int slotId)
		{
		}

		public void SvUpdateConsumableOnAllTeammates(int slotId, int itemId, int count, int maxCount)
		{
		}

		public void SvUpdateConsumableAbilityOnAllTeammates(int itemId)
		{
		}

		public void SvUpdateGoldOnAllTeammates(int goldAmount)
		{
		}

		public void OnCurrentItemIdChanged(int slotId)
		{
		}

		public void OnConsumableChanged(int slotId, int oldItemId, int oldCount, bool playSFX = true)
		{
		}

		public void OnCurrentCurrencyChanged(int oldGoldAmount, bool playSFX = true)
		{
		}

		public void OnLootableAbilityChanged(int oldItemId, bool playSFX = true)
		{
		}

		public void OnNetDeserialize(NetworkReader netReader)
		{
		}

		public void OnNetSerialize(NetworkWriter netWriter)
		{
		}

		public bool OnNetDebugCompare(NetworkReader netReader)
		{
			return false;
		}

		public void OnNetDebugLog(StringBuilder sb)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_CmdUpgradeGear__Byte(byte slotId)
		{
		}

		public static void InvokeUserCode_CmdUpgradeGear__Byte(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetRpcStartConsumableSwapWheel__NetworkConnection__ItemObject(NetworkConnection conn, ItemObject itemObject)
		{
		}

		public static void InvokeUserCode_TargetRpcStartConsumableSwapWheel__NetworkConnection__ItemObject(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdDropConsumableAmount__Int32__Int32(int slotId, int amount)
		{
		}

		public static void InvokeUserCode_CmdDropConsumableAmount__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdSwapConsumableSlots__Int32__Int32(int slotId, int targetSlotId)
		{
		}

		public static void InvokeUserCode_CmdSwapConsumableSlots__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcPickUpItemAnim__ItemObject(ItemObject item)
		{
		}

		public static void InvokeUserCode_RpcPickUpItemAnim__ItemObject(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcOnDropItemAnim__Int32(int itemId)
		{
		}

		public static void InvokeUserCode_RpcOnDropItemAnim__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcUIItemPlayFX__Int32__Byte(int itemId, byte slotId)
		{
		}

		public static void InvokeUserCode_RpcUIItemPlayFX__Int32__Byte(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcPlayUnableToDropLootableFX()
		{
		}

		public static void InvokeUserCode_RpcPlayUnableToDropLootableFX(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcUILootableAbilityPlayFX__Int32(int itemId)
		{
		}

		public static void InvokeUserCode_RpcUILootableAbilityPlayFX__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcUIGoldPlayFX__Int32(int amount)
		{
		}

		public static void InvokeUserCode_RpcUIGoldPlayFX__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static CharItems()
		{
		}
	}
}
