using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIGameModifiers : MonoBehaviour
	{
		[NonSerialized]
		public UIManager uiManager;

		[NonSerialized]
		public UITooltip uiTooltip;

		[SerializeField]
		[Header("References")]
		public GameObject elementsParent;

		[SerializeField]
		public GraphicRaycaster graphicRaycaster;

		[SerializeField]
		public Transform modifierAnimPanelElementsParent;

		[SerializeField]
		public UIAlphaFade modifierAnimPanelFade;

		[SerializeField]
		public UIAlphaFadeTimed modifierAnimPanelFadeOut;

		[SerializeField]
		[Header("Prefabs")]
		public GameObject gameModifierElement;

		[SerializeField]
		public GameObject gameModifierStartAnimElementPrefab;

		[Header("Settings")]
		[SerializeField]
		public float gameModifierStartElementOpenDelay;

		[NonSerialized]
		public List<UIGameModifierElement> gameModifierElements;

		[NonSerialized]
		public List<UIGameModifierStartPanelElement> gameModifierStartElements;

		[NonSerialized]
		public int currentAbilityHoveredId;

		public void Awake()
		{
		}

		public void AddGameModifier(int gameModifierId, bool stackable = true)
		{
		}

		public void RemoveGameModifier(int gameModifierId, bool stackable = true)
		{
		}

		public void RemoveAllGameModifierUI()
		{
		}

		public void PlayGameModifierStart()
		{
		}

		public void ResetStartPanelAnim()
		{
		}

		public void ShowGameModifierTooltip(int gameModifierId, UIGameModifierElement element)
		{
		}

		public void HideAbilityTooltip()
		{
		}

		public Color GetAbilityTitleColor()
		{
			return default(Color);
		}
	}
}
