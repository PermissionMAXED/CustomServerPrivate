using System;
using BAPBAP.Local;
using BAPBAP.Localisation;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UIAbilities : MonoBehaviour
	{
		public struct AbilityCooldownData
		{
			public float cdTotal;

			public float cdProgress;

			public float chargeCdProgress;
		}

		[NonSerialized]
		public UIManager uiManager;

		[NonSerialized]
		public UITooltip uiTooltip;

		[NonSerialized]
		public InputSystem inputSystem;

		[SerializeField]
		[Header("General References")]
		public GameObject abilityElementsParent;

		[SerializeField]
		[Header("Elements")]
		public UIAbilityElement ability1;

		[SerializeField]
		public UIAbilityElement ability2;

		[SerializeField]
		public UIAbilityElement ability3;

		[SerializeField]
		public UIAbilityElement ability4;

		[SerializeField]
		public UIAbilityElement[] abilityConsumable;

		[SerializeField]
		public UIAbilityElement abilityLootable;

		[Header("Mobile Elements")]
		[SerializeField]
		public UIAbilityElement[] mobileAbilityElements;

		[Header("CD Pop Up Config")]
		[SerializeField]
		public GameObject CDPopUpPrefab;

		[SerializeField]
		public Vector3 CDPopUpScreenOffset;

		[SerializeField]
		[Header("Ability Config")]
		public string abilityType1TranslationKey;

		[SerializeField]
		public string abilityType2TranslationKey;

		[SerializeField]
		public string abilityType3TranslationKey;

		[SerializeField]
		public string abilityType4TranslationKey;

		[NonSerialized]
		public string[] abilityTypeNames;

		[NonSerialized]
		public UIAbilityElement[] abilityElementsByCmdId;

		[NonSerialized]
		public NonAllocCooldownsString[] abilityCooldownsByCmdId;

		[NonSerialized]
		public AbilityCooldownData[] abilityCdDataByCmdId;

		[NonSerialized]
		public GameObject currentCDPopUp;

		[NonSerialized]
		public int prevTickNum;

		[NonSerialized]
		public float barTimeElapsed;

		[NonSerialized]
		public int currentAbilityHoveredId;

		[NonSerialized]
		public InputBinding pingInput;

		[NonSerialized]
		public InputBinding tootlipExpandAction;

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void Localise(Translator translator)
		{
		}

		public void LateUpdate()
		{
		}

		public void LerpCooldown(int cmdId, float cdProgress, float cdTotal)
		{
		}

		public void EnableChargesUI(int cmdId, int currentCharges, int maxCharges)
		{
		}

		public void DisableChargeCooldown(int cmdId)
		{
		}

		public void SetChargeCooldown(int cmdId, float ccdProgress, float ccdTotal)
		{
		}

		public void LerpChargeCooldown(int cmdId, float ccdProgress, float ccdTotal)
		{
		}

		public void SetChargeProgressFill(int cmdId, float progress)
		{
		}

		public void SetCharges(int cmdId, int charges)
		{
		}

		public void LoadIcon(int cmdId, int charId)
		{
		}

		public void LoadIcon(int cmdId, Sprite icon, Color iconColor, Color titleColor, string titleStr, string descStr)
		{
		}

		public void ResetIcon(int cmdId)
		{
		}

		public void SetCooldown(int tickNum, int cmdId, float cooldown, float totalCooldown)
		{
		}

		public void TriggerReady(int cmdId)
		{
		}

		public void TriggerLMBChargedReady(int cmdId)
		{
		}

		public void HideProgressCd(int cmdId)
		{
		}

		public void SetReadyState(int cmdId)
		{
		}

		public void SetActiveState(int cmdId)
		{
		}

		public void SetCooldownState(int cmdId)
		{
		}

		public void SetAbilitiesSilenced(bool isEnabled)
		{
		}

		public void SetSilencedState(int cmdId, bool isEnabled)
		{
		}

		public void SpawnAbilityCDPopUp(int cmdId, float timeLeft)
		{
		}

		public void ClearAbilitiesState()
		{
		}

		public void ToggleAbilityUI(bool isEnabled)
		{
		}

		public void TryUpdateAbilityIconKey(InputBinding inputBinding, bool isGamepad)
		{
		}

		public void SetAbilityInputIcon(UIAbilityElement abilityElement, InputBinding inputBinding, bool isGamepad)
		{
		}

		public Color GetAbilityTitleColor()
		{
			return default(Color);
		}

		public string GetAbilityName(int cmdId)
		{
			return null;
		}

		public float GetAbilityRemainingCooldown(int cmdId)
		{
			return 0f;
		}

		public string GetAbilityTypeName(int abilityId)
		{
			return null;
		}

		public void ShowAbilityTooltip(int cmdId, bool fadeIn = true)
		{
		}

		public void TryUpdateCurrentTooltip()
		{
		}

		public void HideAbilityTooltip()
		{
		}
	}
}
