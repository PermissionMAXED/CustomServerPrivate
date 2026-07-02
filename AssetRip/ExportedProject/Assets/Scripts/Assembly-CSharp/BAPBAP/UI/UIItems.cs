using System;
using BAPBAP.Entities;
using BAPBAP.Items;
using BAPBAP.Local;
using BAPBAP.Localisation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIItems : MonoBehaviour
	{
		[NonSerialized]
		public UIManager uiManager;

		[NonSerialized]
		public UITooltip uiTooltip;

		[NonSerialized]
		public ItemManager itemManager;

		[NonSerialized]
		public InputSystem inputSystem;

		[NonSerialized]
		public PassiveManager passiveManager;

		[SerializeField]
		[Header("Item Slots")]
		public UIItemSlotElement gearHatSlots;

		[SerializeField]
		public UIItemSlotElement gearTorsoSlots;

		[SerializeField]
		public UIItemSlotElement gearBootsSlots;

		[SerializeField]
		public UIItemSlotElement gearPinSlots;

		[SerializeField]
		public UIItemSlotElement upgradeHatSlot;

		[SerializeField]
		public UIItemSlotElement upgradeTorsoSlot;

		[SerializeField]
		public UIItemSlotElement upgradeBootSlot;

		[SerializeField]
		public UIItemSlotElement upgradePinSlot;

		[SerializeField]
		public UIItemSlotElement[] consumableSlots;

		[SerializeField]
		public UIItemSlotElement lootableAbilitySlot;

		[SerializeField]
		public UIItemSlotElement goldCurrencySlot;

		[SerializeField]
		public TMP_Text goldCurrencyText;

		[SerializeField]
		[Header("Item Dragger References")]
		public RectTransform itemDragger;

		[SerializeField]
		public Image itemDraggerBg;

		[SerializeField]
		public Image itemDraggerIcon;

		[SerializeField]
		[Header("Mobile Item/Consumable Slots")]
		public UIItemSlotElement mobileGearHatSlot;

		[SerializeField]
		public UIItemSlotElement mobileGearTorsoSlot;

		[SerializeField]
		public UIItemSlotElement mobileGearBootsSlot;

		[SerializeField]
		public UIItemSlotElement mobileJuiceSlot;

		[SerializeField]
		public UIItemSlotElement mobileConsumableSlot;

		[SerializeField]
		public UIItemSlotElement mobileGoldCurrencySlot;

		[SerializeField]
		public TMP_Text mobileGoldCurrencyText;

		[Header("Settings")]
		[SerializeField]
		public Color itemMaxCountColor;

		[SerializeField]
		public float upgradeSlotDisabledOpacity;

		[SerializeField]
		public string tooltipPressXToDropTrKey;

		[SerializeField]
		public string tooltipPressOrTranslationKey;

		[SerializeField]
		public string tooltipToExpandTranslationKey;

		[NonSerialized]
		public UIItemSlotElement[] gearSlots;

		[NonSerialized]
		public UIItemSlotElement[] upgradeSlots;

		[NonSerialized]
		public UIItemSlotElement[] _allSlots;

		[NonSerialized]
		public InputBinding _pingInput;

		[NonSerialized]
		public UIItemSlotElement _currentElementHovered;

		[NonSerialized]
		public InputBinding tootlipExpandAction;

		[NonSerialized]
		public bool _itemMenuOpen;

		[NonSerialized]
		public string _tooltipPressXToDropStr;

		[NonSerialized]
		public string _tooltipPressOr;

		[NonSerialized]
		public string _tooltipToExpandStr;

		[NonSerialized]
		public UIFader localLootableAbilityFader;

		[NonSerialized]
		public bool allowTooltips;

		public const int CONSTANT_ITEM_OFFSET = 4;

		public UIItemSlotElement CurrentElementHovered
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public UIFader LocalLootableAbilityFader
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string TooltipToExpandStr => null;

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void Localise(Translator translator)
		{
		}

		public void Update()
		{
		}

		public void FixedUpdate()
		{
		}

		public void DeFocusConsumableSlot(int consumableSlotId)
		{
		}

		public void FocusConsumableSlot(int consumableSlotId)
		{
		}

		public void FocusItemSlot(int slotId)
		{
		}

		public void EnableGearSlot(int itemId, int slotId)
		{
		}

		public void DisableGearSlot(int slotId)
		{
		}

		public void TriggerGearAnim(int slot)
		{
		}

		public void EnableConsumable(int slotId, int itemId, int count, int maxCount)
		{
		}

		public void RemoveConsumable(int slotId)
		{
		}

		public void SetConsumableCount(int slotId, int count, int maxCount)
		{
		}

		public void SetConsumableCountMax(UIItemSlotElement uIItemSlotElement, bool isEnabled)
		{
		}

		public void TriggerConsumableAnim(int slotId)
		{
		}

		public void EnableLootableAbility(int itemId, int charId = -1)
		{
		}

		public void RemoveLootableAbility()
		{
		}

		public void TriggerLootableAbilityAnim()
		{
		}

		public void SetGoldCurrency(int goldAmount)
		{
		}

		public void SetGoldAmountMax(bool isEnabled)
		{
		}

		public void TriggerCurrencyAnim()
		{
		}

		public void CheckUpgradePinAmount(UIItemSlotElement upgradeSlot, UIItemSlotElement slotToUpgrade, int goldAmount)
		{
		}

		public void ClearAll()
		{
		}

		public void SetUpInventory(CharItems.Inventory inventory, int charId = -1)
		{
		}

		public void EnableItemId(int itemId, int amount, int slotId)
		{
		}

		public void TryUpdateItemIconKey(InputBinding inputBinding, bool isGamepad)
		{
		}

		public void SetItemInputIcon(UIItemSlotElement itemSlotElement, InputBinding inputBinding, bool isGamepad)
		{
		}

		public ItemStat[] GetDeltaItemStats(int prevItemId, int newItemId)
		{
			return null;
		}

		public ItemStat[] GetDeltaItemStats(Gear prevGear, Gear newGear)
		{
			return null;
		}

		public void ShowItemSlotTooltip(UIItemSlotElement uiSlotElement)
		{
		}

		public void ShowPinUpgradeTooltip(UIItemSlotElement upgradeSlot, UIItemSlotElement slotToUpgrade)
		{
		}

		public string GetGearTooltipDescription(Gear gear, bool compact = false, bool skipPrimaryStats = false, bool skipSecondaryStats = false, bool allowPassiveSpacing = true)
		{
			return null;
		}
	}
}
