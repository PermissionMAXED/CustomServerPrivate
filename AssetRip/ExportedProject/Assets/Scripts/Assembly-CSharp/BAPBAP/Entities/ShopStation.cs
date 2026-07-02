using System;
using System.Runtime.InteropServices;
using BAPBAP.Game;
using BAPBAP.Items;
using BAPBAP.Local;
using BAPBAP.Localisation;
using BAPBAP.Player;
using BAPBAP.Utilities;
using Mirror;
using TMPro;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class ShopStation : InteractableStation
	{
		[Serializable]
		public class ListingItemSlot
		{
			public ItemObjectVisualizer itemVisualizer;

			public GameObject itemPriceTag;

			public TMP_Text itemPriceTagText;

			public GameObject onSaleTag;

			public TMP_Text onSaleTagText;

			public GameObject slotRestockVfx;
		}

		public class ListingEntry
		{
			[NonSerialized]
			public int _itemId;

			[NonSerialized]
			public byte _stock;

			[NonSerialized]
			public Action<int> itemIdSync;

			[NonSerialized]
			public Action<byte> stockSync;

			public int itemId
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public byte stock
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public ListingEntry(Action<int> itemIdSync, Action<byte> stockSync)
			{
			}
		}

		[Serializable]
		public class ConsumablePoolEntry
		{
			public Consumable consumable;

			public ByteRange stockRange;

			[Range(0f, 1f)]
			public float chance;
		}

		[Serializable]
		public class LootAbilityPoolEntry
		{
			public LootableAbility lootableAbility;

			public ByteRange stockRange;

			[Range(0f, 1f)]
			public float chance;
		}

		[Serializable]
		public class LootCutoff
		{
			public float uncommonCutoff;

			public float rareCutoff;

			public float epicCutoff;
		}

		[NonSerialized]
		public GameManager gameManager;

		[NonSerialized]
		public ItemManager itemManager;

		[NonSerialized]
		public ItemCurrencyManager itemCurrencyManager;

		[NonSerialized]
		public PassiveManager passiveManager;

		[SerializeField]
		[Header("References")]
		public ListingItemSlot[] listingItemSlots;

		[Header("Item Configs")]
		[SerializeField]
		public bool useCustomGearPool;

		[ConditionalHide("useCustomGearPool")]
		[SerializeField]
		[Tooltip("Only these gear items will be spawned in the shop, independently from the item manager enabled items")]
		public GearType[] customGearPool;

		[SerializeField]
		[ConditionalInverseHide("useCustomGearPool")]
		[Tooltip("Items that will be removed on this shops pool from the item manager enabled items")]
		public GearType[] blacklistedGear;

		[SerializeField]
		public IntRange gearStockRange;

		[Range(0f, 1f)]
		[SerializeField]
		[Space(5f)]
		public float uniquePercent;

		[SerializeField]
		public GearType[] uniqueItems;

		[Tooltip("Pool of pins to try to replace instead of gear")]
		[SerializeField]
		[Space(5f)]
		public LootDropEntry.GearDrop pinGear;

		[Range(0f, 1f)]
		[Tooltip("For each item the chance to turn it into a pin of the same rarity")]
		public float pinChanceNorm;

		[Space(5f)]
		[Range(0f, 1f)]
		[SerializeField]
		public float consumableChance;

		[SerializeField]
		public ConsumablePoolEntry[] consumablePool;

		[Space(5f)]
		[SerializeField]
		[Range(0f, 1f)]
		public float lootAbilityChance;

		[SerializeField]
		public LootAbilityPoolEntry[] lootAbilityPool;

		[Header("Settings")]
		[SerializeField]
		public float priceReductionPerDeadAlly;

		[SerializeField]
		public float initialReStockTime;

		[SerializeField]
		[Min(0f)]
		public float reStockTime;

		[SerializeField]
		public float extraPriceReduction;

		[SerializeField]
		public LootCutoff[] lootCutoffs;

		[SerializeField]
		public int rerollPrice;

		[SerializeField]
		public int rerollPriceIncrease;

		[SerializeField]
		public int rerollPriceCap;

		[SerializeField]
		public Sprite rerollIcon;

		[SerializeField]
		public Color itemPriceTagAbleToPurchaseColor;

		[SerializeField]
		public Color itemPriceTagUnableToPurchaseColor;

		[SerializeField]
		public CharVoicelineConfig purchaseVoiceline;

		[SerializeField]
		[Header("Anim Settings")]
		public string animSuccessState;

		[SerializeField]
		public string animFailState;

		[SerializeField]
		public string animHitState;

		[SerializeField]
		public float hitCdDuration;

		[SerializeField]
		[Header("Prefabs")]
		public GameObject itemEntityPingPrefab;

		[SerializeField]
		[Header("View References")]
		public GameObject npcRootGameObject;

		[SerializeField]
		public Animator npcAnimator;

		[SerializeField]
		public SimpleTargetDetectionCl targetDetectionCl;

		[SerializeField]
		public LookAtTargetConstraint followLookAtTarget;

		[SerializeField]
		public TMP_Text restockTimerMesh;

		[SerializeField]
		public Transform restockClockNeedle;

		[SerializeField]
		public SpriteRenderer restockProgressRingRend;

		[SerializeField]
		public Transform speechBubblePivot;

		[Header("Translation Keys")]
		[SerializeField]
		public string purchasingTrKey;

		[SerializeField]
		public string purchaseForTrKey;

		[SerializeField]
		public string noItemsTrKey;

		[SerializeField]
		public string rerollForTrKey;

		[SerializeField]
		public string uniqueTrKey;

		[SerializeField]
		public string[] speechFailTrKey;

		[SerializeField]
		public string[] speechPurchasedTrKey;

		[SerializeField]
		public string[] speechRestockTrKey;

		[SerializeField]
		public string[] speechAttackedTrKey;

		[NonSerialized]
		public GearType[] gearTypePool;

		[NonSerialized]
		public ListingEntry[] listings;

		[NonSerialized]
		public float currentRestockTimer;

		[NonSerialized]
		public float hitCdTime;

		[NonSerialized]
		public float prevAuthViewCharGold;

		[NonSerialized]
		public string purchasingStr;

		[NonSerialized]
		public string purchaseForStr;

		[NonSerialized]
		public string noItemsStr;

		[NonSerialized]
		public string rerollForStr;

		[NonSerialized]
		public string uniqueStr;

		[NonSerialized]
		public string[] speechFailStr;

		[NonSerialized]
		public string[] speechPurchasedStr;

		[NonSerialized]
		public string[] speechRestockStr;

		[NonSerialized]
		public string[] speechAttackedStr;

		[NonSerialized]
		public bool _isServer;

		[SyncVar]
		[NonSerialized]
		public ShopItemPingEntity pingEntity0;

		[SyncVar]
		[NonSerialized]
		public ShopItemPingEntity pingEntity1;

		[SyncVar]
		[NonSerialized]
		public ShopItemPingEntity pingEntity2;

		[SyncVar(hook = "OnItemId0Changed")]
		[NonSerialized]
		public int itemId0;

		[SyncVar(hook = "OnStock0Changed")]
		[NonSerialized]
		public byte stock0;

		[SyncVar(hook = "OnItemId1Changed")]
		[NonSerialized]
		public int itemId1;

		[SyncVar(hook = "OnStock1Changed")]
		[NonSerialized]
		public byte stock1;

		[SyncVar(hook = "OnItemId2Changed")]
		[NonSerialized]
		public int itemId2;

		[SyncVar(hook = "OnStock2Changed")]
		[NonSerialized]
		public byte stock2;

		[SyncVar(hook = "OnCurrentRestockTimerSyncChanged")]
		[NonSerialized]
		public ushort currentRestockTimerSync;

		[SyncVar(hook = "OnRerollChanged")]
		[NonSerialized]
		public int rerollCost;

		[NonSerialized]
		public NetworkBehaviourSyncVar ___pingEntity0NetId;

		[NonSerialized]
		public NetworkBehaviourSyncVar ___pingEntity1NetId;

		[NonSerialized]
		public NetworkBehaviourSyncVar ___pingEntity2NetId;

		public Action<int, int> _Mirror_SyncVarHookDelegate_itemId0;

		public Action<byte, byte> _Mirror_SyncVarHookDelegate_stock0;

		public Action<int, int> _Mirror_SyncVarHookDelegate_itemId1;

		public Action<byte, byte> _Mirror_SyncVarHookDelegate_stock1;

		public Action<int, int> _Mirror_SyncVarHookDelegate_itemId2;

		public Action<byte, byte> _Mirror_SyncVarHookDelegate_stock2;

		public Action<ushort, ushort> _Mirror_SyncVarHookDelegate_currentRestockTimerSync;

		public Action<int, int> _Mirror_SyncVarHookDelegate_rerollCost;

		public ShopItemPingEntity NetworkpingEntity0
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

		public ShopItemPingEntity NetworkpingEntity1
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

		public ShopItemPingEntity NetworkpingEntity2
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

		public int NetworkitemId0
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

		public byte Networkstock0
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

		public int NetworkitemId1
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

		public byte Networkstock1
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

		public int NetworkitemId2
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

		public byte Networkstock2
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

		public ushort NetworkcurrentRestockTimerSync
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

		public int NetworkrerollCost
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

		public override void Awake()
		{
		}

		public override void Start()
		{
		}

		public void OnDisable()
		{
		}

		public void Localise(Translator translator)
		{
		}

		public void FixedUpdate()
		{
		}

		public void Update()
		{
		}

		public void InitializeItemPool()
		{
		}

		public void DoRestock()
		{
		}

		public void InitializeListing(ListingEntry listing)
		{
		}

		public void GetRandomListing(out int itemId, out byte stock)
		{
			itemId = default(int);
			stock = default(byte);
		}

		public int GetRandomGearIdFromPool()
		{
			return 0;
		}

		public GearType GetRandomGearTypeFromPool()
		{
			return null;
		}

		public ItemTiers GetRandomItemTierFromPool()
		{
			return default(ItemTiers);
		}

		public override void ClOnForceUpdate(EntityManager entity, InteractableCollider slot)
		{
		}

		public override bool TryUseStation(EntityManager entity, int slotId)
		{
			return false;
		}

		public bool PurchaseItem(EntityManager entity, int listingId)
		{
			return false;
		}

		public override bool AbleToUseStation(EntityManager entity, int slotId)
		{
			return false;
		}

		public void SvOnHit(Vector3 hitDir, int dmg, StatusEffectInfo[] statusEffects, int playerId, int teamId, Collider collider)
		{
		}

		[ClientRpc]
		public void RpcOnHit()
		{
		}

		[ClientRpc]
		public void RpcOnPurchasedItem(EntityManager entity, int slotId, int itemId)
		{
		}

		[ClientRpc]
		public void RpcOnRestock()
		{
		}

		[ClientRpc]
		public override void RpcOnUseSuccess(EntityManager entity, int slotId)
		{
		}

		[ClientRpc]
		public override void RpcOnUseFail(EntityManager entity, int slotId)
		{
		}

		public override void ClOnEnter(EntityManager entity, InteractableCollider slot)
		{
		}

		public override void ClOnExit(EntityManager entity, InteractableCollider slot)
		{
		}

		public void ClRefreshItemDisplays()
		{
		}

		public void ClUpdateItemListingId(int id)
		{
		}

		public void ClUpdateListingDisplay(int listingId)
		{
		}

		public void ClUpdateListingDisplayPriceTag(int listingId)
		{
		}

		public void ClUpdateListingDisplayPriceTag(ListingItemSlot listingSlot, Item itemToPurchase)
		{
		}

		public void ClVisualizeItemObj(ItemObjectVisualizer itemVisualizer, int itemId, int amount)
		{
		}

		public void SetRestockProgressRing(float normValue)
		{
		}

		public void SetRestockNeedleProgress(float normValue)
		{
		}

		public override void UIShowFinishedWindow(InteractableCollider slot)
		{
		}

		public void UIShowInvalidWindow(InteractableCollider slot, Item item, EntityManager entity)
		{
		}

		public void UIShowValidWindow(InteractableCollider slot, Item item, EntityManager entity)
		{
		}

		public void UIRerollInvalid()
		{
		}

		public void UIRerollValid()
		{
		}

		public int GetCurrentSlotItemId(int listingId)
		{
			return 0;
		}

		public int GetSlotIdFromPingEntity(ShopItemPingEntity itemPingEntity)
		{
			return 0;
		}

		public int GetItemPrice(Item itemToPurchase, PlayerManager playerManager)
		{
			return 0;
		}

		public int GetModifiedPrice(int price, PlayerManager playerManager)
		{
			return 0;
		}

		public void OnRerollChanged(int oldValue, int newValue)
		{
		}

		public void OnCurrentRestockTimerSyncChanged(ushort oldValue, ushort newValue)
		{
		}

		public void OnItemId0Changed(int oldValue, int newValue)
		{
		}

		public void OnItemId1Changed(int oldValue, int newValue)
		{
		}

		public void OnItemId2Changed(int oldValue, int newValue)
		{
		}

		public void OnStock0Changed(byte oldValue, byte newValue)
		{
		}

		public void OnStock1Changed(byte oldValue, byte newValue)
		{
		}

		public void OnStock2Changed(byte oldValue, byte newValue)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcOnHit()
		{
		}

		public static void InvokeUserCode_RpcOnHit(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcOnPurchasedItem__EntityManager__Int32__Int32(EntityManager entity, int slotId, int itemId)
		{
		}

		public static void InvokeUserCode_RpcOnPurchasedItem__EntityManager__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcOnRestock()
		{
		}

		public static void InvokeUserCode_RpcOnRestock(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public override void UserCode_RpcOnUseSuccess__EntityManager__Int32(EntityManager entity, int slotId)
		{
		}

		public new static void InvokeUserCode_RpcOnUseSuccess__EntityManager__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public override void UserCode_RpcOnUseFail__EntityManager__Int32(EntityManager entity, int slotId)
		{
		}

		public new static void InvokeUserCode_RpcOnUseFail__EntityManager__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static ShopStation()
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
