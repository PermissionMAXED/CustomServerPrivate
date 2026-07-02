using System;
using BAPBAP.Local;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIPassiveElement : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[NonSerialized]
		public UIPassives uiPassives;

		[NonSerialized]
		public UIAbilities uiAbilities;

		[NonSerialized]
		public RectTransform rectTransform;

		[Header("Settings")]
		[SerializeField]
		public float cooldownIconAlpha;

		[Header("Key Settings")]
		public InputTarget action;

		[SerializeField]
		[Header("General References")]
		public Image bgImage;

		[SerializeField]
		public Image abilityIcon;

		[SerializeField]
		[Header("State References")]
		public Image activeState;

		[Header("Cooldown References")]
		[SerializeField]
		public Image cdProgressImage;

		[SerializeField]
		public Image _cdProgressBarFill;

		[SerializeField]
		public TMP_Text cdText;

		[SerializeField]
		public Material _cdIconMaterial;

		[SerializeField]
		[Header("Other References")]
		public GameObject readyAnim;

		[SerializeField]
		public GameObject pickupAnim;

		[SerializeField]
		public Material activeIconMaterial;

		[NonSerialized]
		public Material defaultItemMaterial;

		[Header("Passive References")]
		[SerializeField]
		public TMP_Text passiveStacksText;

		[SerializeField]
		public GameObject stacksParentObject;

		[NonSerialized]
		public int passiveId;

		[NonSerialized]
		public int passiveStacks;

		[NonSerialized]
		public bool show1Stack;

		[NonSerialized]
		public bool startStackAtZero;

		[NonSerialized]
		public int cmdId;

		[NonSerialized]
		public Color abilityIconColor;

		[NonSerialized]
		public Color abilityTitleColor;

		[NonSerialized]
		public string title;

		[NonSerialized]
		public string description;

		public void Awake()
		{
		}

		public void OnDisable()
		{
		}

		public void InitializePassive(UIPassives _uiPassives, int passiveId)
		{
		}

		public void SetActiveState(bool isAbilityActive, bool iconDisabledOnCooldown = true, bool activeByDefault = true)
		{
		}

		public void SetCooldownState(bool iconDisabledOnCooldown = true, bool activeByDefault = true)
		{
		}

		public void SetCooldownProgress(float cdPercent, bool iconDisabledOnCooldown = true, bool activeByDefault = true)
		{
		}

		public void SetCooldownText(string text)
		{
		}

		public void SetUIColors(bool isActive, bool iconDisabledOnCooldown, bool activeByDefault)
		{
		}

		public void PlayReadyAnim()
		{
		}

		public void TriggerPickupAnim()
		{
		}

		public void AddPassiveStacks()
		{
		}

		public void RemovePassiveStacks()
		{
		}

		public void UpdatePassiveStacksUI()
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
