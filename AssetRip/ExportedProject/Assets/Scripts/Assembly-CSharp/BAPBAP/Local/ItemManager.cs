using System;
using System.Collections.Generic;
using BAPBAP.Entities;
using BAPBAP.Items;
using BAPBAP.Localisation;
using BAPBAP.UI;
using UnityEngine;

namespace BAPBAP.Local
{
	public class ItemManager : MonoBehaviour
	{
		[Serializable]
		public class ItemSlotConfiguration
		{
			public string nameTranslationKey;

			public Sprite icon;

			[NonSerialized]
			public string localizedName;
		}

		[Serializable]
		public class ItemTierConfiguration
		{
			public string nameTranslationKey;

			public ItemTheme itemTheme;

			[NonSerialized]
			public string localizedName;
		}

		public struct ItemEntry
		{
			public int itemId;

			public int amount;
		}

		[NonSerialized]
		public UIManager uiManager;

		[SerializeField]
		[Expandable]
		[Header("Gear")]
		public Gear[] gearItems;

		[Expandable]
		[SerializeField]
		public Gear[] uniqueGearItems;

		[Expandable]
		[SerializeField]
		public Gear[] pinGearItems;

		[Expandable]
		[Space(5f)]
		[SerializeField]
		public Consumable[] consumables;

		[Space(5f)]
		[Expandable]
		[SerializeField]
		public Currency[] currencies;

		[Expandable]
		[SerializeField]
		[Space(5f)]
		public LootableAbility[] lootableAbilities;

		[Header("Settings")]
		[Tooltip("Any excluded gear types from the games gear pool")]
		[SerializeField]
		public List<GearType> vaultedGearTypes;

		[Tooltip("The maximum allowed health potions for players to hold")]
		[SerializeField]
		public int maxHealthPotionCount;

		[NonSerialized]
		public int numGearItems;

		[NonSerialized]
		public int numConsumableItems;

		[Tooltip("The maximum allowed gold amount for players to hold")]
		[SerializeField]
		public int maxGold;

		[SerializeField]
		[Tooltip("The maximum allowed gold amount for players to manually drop")]
		public int maxGoldDropAmount;

		[Header("Item Configs")]
		[NamedArray(typeof(ItemTiers), 0)]
		[SerializeField]
		public ItemTierConfiguration[] itemTierConfig;

		[NamedArray(typeof(GearSlot), 0)]
		[SerializeField]
		public ItemSlotConfiguration[] itemSlotConfig;

		[SerializeField]
		[Header("Item Object References")]
		public GameObject itemObjPrefab;

		[SerializeField]
		public Material[] defaultItemObjMats;

		[Header("Custom References")]
		[SerializeField]
		public Item C_HealthPotion_Item;

		[SerializeField]
		public Item C_Gold_Item;

		[SerializeField]
		public Item C_Page_Item;

		[SerializeField]
		[Header("Translation Keys")]
		public string gearTypeTranslationKey;

		[SerializeField]
		public string itemTypeTranslationKey;

		[SerializeField]
		public string consumableTypeTranslationKey;

		[SerializeField]
		public string lootableAbilityTypeTranslationKey;

		[SerializeField]
		public string currencyTypeTranslationKey;

		[Header("SFX Settings")]
		[SerializeField]
		public AudioClipData itemPickupSfxData;

		[SerializeField]
		public AudioClipData itemDropSfxData;

		[SerializeField]
		public AudioClipData consumablePickupSfxData;

		[SerializeField]
		public AudioClipData consumableDropSfxData;

		[SerializeField]
		public AudioClipData currencyPickupSfxData;

		[SerializeField]
		public AudioClipData currencyDropSfxData;

		[SerializeField]
		public AudioClipData lootAbilityPickupSfxData;

		[SerializeField]
		public AudioClipData lootAbilityDropSfxData;

		[NonSerialized]
		public int potionItemId;

		[NonSerialized]
		public int goldItemId;

		[NonSerialized]
		public int pagesItemId;

		[NonSerialized]
		public Item[] itemsById;

		[NonSerialized]
		public GearData[] gearDataByTypeId;

		[NonSerialized]
		public GearType[] enabledGearTypes;

		[NonSerialized]
		public GearType[] enabledUniqueTypes;

		[NonSerialized]
		public GearType[] enabledPinTypes;

		[NonSerialized]
		public int numItemTiers;

		[NonSerialized]
		public string itemTypeName;

		[NonSerialized]
		public string gearTypeName;

		[NonSerialized]
		public string consumableTypeName;

		[NonSerialized]
		public string lootableAbilityTypeName;

		[NonSerialized]
		public string currencyTypeName;

		[NonSerialized]
		public string[] itemNameByItemId;

		[NonSerialized]
		public string[] itemDescriptionByItemId;

		[NonSerialized]
		public AbilityBehaviourSO[] consumableBehaviourInstances;

		[NonSerialized]
		public AbilityBehaviourSO[] lootableAbilityBehaviours;

		public void Awake()
		{
		}

		public void Localise(Translator translator)
		{
		}

		public void GetCurrentEnabledItems()
		{
		}

		public int GetLootableAbilityBehaviourId(PassiveSO lootableAbility)
		{
			return 0;
		}

		public AbilityBehaviourSO GetLootableAbilityBehaviour(int lootableAbilityId)
		{
			return null;
		}

		public void DoLootableAbility(LootableAbility consumable, EntityManager entityManager, Vector3 landingPoint)
		{
		}

		public AbilityBehaviourSO GetConsumableAbilityBehaviour(int consumableId)
		{
			return null;
		}

		public void SpawnMultipleItems(int[] itemIds, Vector3 spawnPos, float spawnRadius = 1f, CharItems prevOwner = null, Action<GameObject> onInstanceSpawned = null)
		{
		}

		public void SpawnMultipleItems(ItemEntry[] items, Vector3 spawnPos, Vector3 initialDir = default(Vector3), float spawnRadius = 1f, CharItems prevOwner = null, Action<GameObject> onInstanceSpawned = null)
		{
		}

		public GameObject SpawnItem(int itemId, Vector3 spawnPos, Vector3 dir = default(Vector3), float spawnRadius = 1f, CharItems prevOwner = null)
		{
			return null;
		}

		public GameObject SpawnItem(int itemId, int amount, Vector3 spawnPos, Vector3 dir = default(Vector3), float spawnRadius = 1f, CharItems prevOwner = null)
		{
			return null;
		}

		public Item GetItem(int itemId)
		{
			return null;
		}

		public Gear GetGear(int gearId)
		{
			return null;
		}

		public Item GetConsumable(int consumableId)
		{
			return null;
		}

		public Item GetCurrency(int currencyId)
		{
			return null;
		}

		public GearType GetRandomGearType()
		{
			return null;
		}

		public GearType GetRandomUniqueType()
		{
			return null;
		}

		public GearType GetRandomPinType()
		{
			return null;
		}

		public int GetRandomGearByTier(int tier)
		{
			return 0;
		}

		public int GetGearItemIdByTypeAndTier(GearType type, ItemTiers tier)
		{
			return 0;
		}

		public int GetGearItemIdByTypeAndTier(int typeId, int tierId)
		{
			return 0;
		}

		public int GetItemId(Item item)
		{
			return 0;
		}

		public int GetConsumableItemId(int consumableId)
		{
			return 0;
		}

		public int GetLootableAbilityItemId(int lootableAbilityId)
		{
			return 0;
		}

		public int GetConsumableIdByItemId(int itemId)
		{
			return 0;
		}

		public int GetConsumableMaxCount(int itemId)
		{
			return 0;
		}

		public bool GetConsumableIsDroppable(int itemId)
		{
			return false;
		}

		public int GetLootableAbilityIdByItemId(int itemId)
		{
			return 0;
		}

		public int GetCurrencyItemId(int currencyId)
		{
			return 0;
		}

		public bool IsItemMaxTier(int itemId)
		{
			return false;
		}

		public bool IsItemMaxTier(Item item)
		{
			return false;
		}

		public int GetNextItemTier(int itemId)
		{
			return 0;
		}

		public int GetNextItemTier(Gear gear)
		{
			return 0;
		}

		public float GetItemPowerLevelNorm(int itemId)
		{
			return 0f;
		}

		public float GetItemPowerLevelNorm(Item item)
		{
			return 0f;
		}

		public ItemTheme GetItemThemeByTier(ItemTiers tier)
		{
			return null;
		}

		public string BuildStatString(ItemStat itemStat, bool compact = false)
		{
			return null;
		}

		public string GetStatValue(ItemStat itemStat)
		{
			return null;
		}

		public string GetItemTypeName(Item item)
		{
			return null;
		}

		public string GetItemName(Item item)
		{
			return null;
		}

		public string GetItemName(int itemId)
		{
			return null;
		}

		public string GetItemDescription(Item item)
		{
			return null;
		}

		public string GetItemDescription(int itemId)
		{
			return null;
		}

		public Color GetItemColor(Item item)
		{
			return default(Color);
		}

		public Color GetTierColor(ItemTiers tier)
		{
			return default(Color);
		}

		public string GetTierName(ItemTiers tier)
		{
			return null;
		}

		public Sprite GetGearSlotIcon(Gear item)
		{
			return null;
		}

		public string GetGearSlotName(int slotId)
		{
			return null;
		}

		public string GetTierAndSlotTypeName(Gear item)
		{
			return null;
		}

		public AudioClipData GetPickupSfx(int itemId)
		{
			return null;
		}

		public AudioClipData GetDropSfx(int itemId)
		{
			return null;
		}

		public AudioClipData GetPickupSfx(Item item)
		{
			return null;
		}

		public AudioClipData GetDropSfx(Item item)
		{
			return null;
		}
	}
}
