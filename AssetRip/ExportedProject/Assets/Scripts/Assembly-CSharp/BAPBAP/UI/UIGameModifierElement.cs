using System;
using BAPBAP.Local;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIGameModifierElement : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[NonSerialized]
		public UIGameModifiers uiGameModifiers;

		[SerializeField]
		[Header("General References")]
		public Image bgImage;

		[SerializeField]
		public Image iconImage;

		[Header("State References")]
		[SerializeField]
		public Image activeState;

		[SerializeField]
		[Header("Cooldown References")]
		public Image cdProgressImage;

		[SerializeField]
		public TMP_Text cdText;

		[SerializeField]
		[Header("Other References")]
		public GameObject readyAnim;

		[SerializeField]
		public Material activeIconMaterial;

		[SerializeField]
		[Header("GameModifier References")]
		public TMP_Text gameModifierStacksText;

		[Header("Settings")]
		[SerializeField]
		public float cooldownIconAlpha;

		[Header("Key Settings")]
		[SerializeField]
		public InputTarget action;

		[NonSerialized]
		public Material defaultItemMaterial;

		[NonSerialized]
		public int gameModifierId;

		[NonSerialized]
		public int gameModifierStacks;

		[NonSerialized]
		public UIAbilities uiAbilities;

		[NonSerialized]
		public RectTransform rectTransform;

		[NonSerialized]
		public Color abilityIconColor;

		[NonSerialized]
		public Color abilityTitleColor;

		[NonSerialized]
		public string title;

		[NonSerialized]
		public string description;

		[NonSerialized]
		public int cmdId;

		public void Awake()
		{
		}

		public void OnDisable()
		{
		}

		public void InitializeGameModifier(UIGameModifiers _uiGameModifiers, int _gameModifierId)
		{
		}

		public void SetActiveState(bool isAbilityActive)
		{
		}

		public void SetCooldownState()
		{
		}

		public void SetCooldownProgress(float cdPercent)
		{
		}

		public void SetCooldownText(string text)
		{
		}

		public void SetGameModifierStacks(int i)
		{
		}

		public void AddGameModifierStacks()
		{
		}

		public void RemoveGameModifierStacks()
		{
		}

		public void PlayReadyAnim()
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
