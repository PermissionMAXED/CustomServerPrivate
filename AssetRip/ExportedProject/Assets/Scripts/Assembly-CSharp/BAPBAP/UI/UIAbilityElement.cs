using System;
using BAPBAP.Local;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIAbilityElement : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[NonSerialized]
		public UIAbilities _uiAbilities;

		[Header("Settings")]
		[SerializeField]
		public float cooldownIconAlpha;

		[SerializeField]
		public Color chargeActiveColor;

		[SerializeField]
		public Color chargeInactiveColor;

		[SerializeField]
		public Color cooldownColor;

		[Header("Key Settings")]
		[SerializeField]
		public InputTarget target;

		[Header("General References")]
		[SerializeField]
		public Image bgImage;

		[SerializeField]
		public Image abilityIcon;

		[Header("State References")]
		[SerializeField]
		public Image activeState;

		[SerializeField]
		public Image silencedState;

		[SerializeField]
		[Header("Cooldown References")]
		public Image cdTopTab;

		[SerializeField]
		public Image cdProgressBarOutline;

		[SerializeField]
		public Image cdProgressBarFill;

		[SerializeField]
		public TMP_Text cdText;

		[SerializeField]
		public Material _cdIconMaterial;

		[SerializeField]
		public float _minFontSize;

		[SerializeField]
		public float _maxFontSize;

		[SerializeField]
		public float _fontIncreaseThreshold;

		[Header("Key References")]
		[SerializeField]
		public UIInputIcon inputIcon;

		[SerializeField]
		public Image inputIconBG;

		[Header("Charges References")]
		[SerializeField]
		public GameObject chargesParent;

		[SerializeField]
		public Image chargesProgress;

		[SerializeField]
		public Image[] chargeImages;

		[Header("Other References")]
		[SerializeField]
		public GameObject readyAnim;

		[SerializeField]
		public UIAlphaAnim readyAlphaAnim;

		[SerializeField]
		public Image readyAlphaAnimImage;

		[SerializeField]
		public Material activeIconMaterial;

		[SerializeField]
		public UIItemSlotElement uiItemSlot;

		[NonSerialized]
		public bool hasItemSlot;

		[NonSerialized]
		public RectTransform rectTransform;

		[NonSerialized]
		public Color abilityTitleColor;

		[NonSerialized]
		public string titleStr;

		[NonSerialized]
		public Material _defaultItemMaterial;

		[NonSerialized]
		public Color _primaryAbilityColor;

		[NonSerialized]
		public int _cmdId;

		public void Awake()
		{
		}

		public void OnDisable()
		{
		}

		public void Initialize(UIAbilities uiAbilities, int cmdId)
		{
		}

		public void LoadIcon(UICharactersConfiguration.CharacterConfiguration charConfig)
		{
		}

		public void LoadIcon(Sprite icon, Color iconColor, Color titleColor, string titleStr, string descStr)
		{
		}

		public void SetActiveState(bool isAbilityActive)
		{
		}

		public void SetCooldownState()
		{
		}

		public void SetSilencedState(bool isEnabled)
		{
		}

		public void SetCooldownProgress(float cdPercent)
		{
		}

		public void SetCooldownText(string text)
		{
		}

		public void SetCooldownText(char[] charArray)
		{
		}

		public void SetTextVisual(float cdValue)
		{
		}

		public void InitializeChargesUI(int maxCharges)
		{
		}

		public void DisableChargesUI()
		{
		}

		public void HideProgressCd()
		{
		}

		public void SetChargeProgressCd(float cdPercent)
		{
		}

		public void SetCharges(int amount)
		{
		}

		public void PlayReadyAnim()
		{
		}

		public void SetInputIcon(InputBinding inputBinding, bool isGamepad)
		{
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
		}

		public void OnPointerExit(PointerEventData eventData)
		{
		}

		public void OnElementExit()
		{
		}
	}
}
