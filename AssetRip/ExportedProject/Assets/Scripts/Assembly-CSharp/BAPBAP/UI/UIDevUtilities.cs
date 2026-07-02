using System;
using BAPBAP.Game;
using BAPBAP.Local;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIDevUtilities : MonoBehaviour
	{
		[NonSerialized]
		public ItemManager itemManager;

		[SerializeField]
		public GameModeTraining trainingGamemode;

		[SerializeField]
		[Header("General")]
		public Button exitMatchButton;

		[Header("Char Settings")]
		[SerializeField]
		public Toggle setCooldownToggle;

		[SerializeField]
		public Toggle setInvincibilityToggle;

		[SerializeField]
		public Toggle setAggroToggle;

		[SerializeField]
		public Button damageButton;

		[SerializeField]
		public Button healButton;

		[Header("Item Spawn")]
		[SerializeField]
		public CustomTMP_Dropdown itemTypeDropdown;

		[SerializeField]
		public CustomTMP_Dropdown itemTierDropdown;

		[SerializeField]
		public Button itemSpawnButton;

		[Header("Consumable Spawn")]
		[SerializeField]
		public CustomTMP_Dropdown consumableTypeDropdown;

		[SerializeField]
		public Button consumableSpawnButton;

		[Header("Lootable Ability Spawn")]
		[SerializeField]
		public CustomTMP_Dropdown lootableAbilityTypeDropdown;

		[SerializeField]
		public Button lootableAbilitySpawnButton;

		[Header("Currency Spawn")]
		[SerializeField]
		public CustomTMP_Dropdown currencyTypeDropdown;

		[SerializeField]
		public Button currencySpawn100Button;

		[SerializeField]
		public Button currencySpawn1000Button;

		[Header("Char Spawn")]
		[SerializeField]
		public GameObject charSpawnHolder;

		[SerializeField]
		public CustomTMP_Dropdown charDropdown;

		[SerializeField]
		public Button charSpawnButton;

		[SerializeField]
		public Toggle spawnBotToggle;

		[SerializeField]
		public Toggle spawnBotAIEnabledToggle;

		[SerializeField]
		public Toggle spawnBotIsAllyToggle;

		[SerializeField]
		public CustomTMP_Dropdown botDifficultyDropdown;

		[Header("Passives")]
		[SerializeField]
		public CustomTMP_Dropdown passiveDropdown;

		[SerializeField]
		public Button passiveAddButton;

		[SerializeField]
		public Button passiveRemoveButton;

		[Header("Game Modifier Spawn")]
		[SerializeField]
		public CustomTMP_Dropdown gameModifierDropdown;

		[SerializeField]
		public Button gameModifierAddButton;

		[SerializeField]
		public Button gameModifierRemoveButton;

		[Header("Status Effects Spawn")]
		[SerializeField]
		public CustomTMP_Dropdown statusEffectDropdown;

		[SerializeField]
		public Button statusEffectAddButton;

		[SerializeField]
		public Button statusEffectRemoveButton;

		[SerializeField]
		public TMP_InputField statusEffectDurationInput;

		public void Start()
		{
		}

		public void ExitMatch()
		{
		}

		public void OnCooldownToggle(bool isOn)
		{
		}

		public void SetCooldownToggleState(bool isOn)
		{
		}

		public void OnInvincibleToggle(bool isOn)
		{
		}

		public void SetInvincibilityToggleState(bool isOn)
		{
		}

		public void OnAggroToggle(bool isOn)
		{
		}

		public void SetAggroToggleState(bool isOn)
		{
		}

		public void OnDealDamage()
		{
		}

		public void OnApplyHeal()
		{
		}

		public void PopulateItemSpawnDropdown()
		{
		}

		public void OnSpawnItem()
		{
		}

		public void PopulateConsumableSpawnDropdown()
		{
		}

		public void OnSpawnConsumable()
		{
		}

		public void PopulateLootableAbilitySpawnDropdown()
		{
		}

		public void OnSpawnLootableAbility()
		{
		}

		public void PopulateCurrencySpawnDropdown()
		{
		}

		public void OnSpawnCurrency(int amount)
		{
		}

		public void PopulateCharDropdown()
		{
		}

		public void OnSpawnCharacter()
		{
		}

		public void PopulatePassiveDropdown()
		{
		}

		public void OnAddPassive()
		{
		}

		public void OnRemovePassive()
		{
		}

		public void PopulateGameModifierDropdown()
		{
		}

		public void OnAddGameModifier()
		{
		}

		public void OnRemoveGameModifier()
		{
		}

		public void PopulateStatusEffectDropdown()
		{
		}

		public void OnAddStatusEffect()
		{
		}

		public void OnRemoveStatusEffect()
		{
		}
	}
}
