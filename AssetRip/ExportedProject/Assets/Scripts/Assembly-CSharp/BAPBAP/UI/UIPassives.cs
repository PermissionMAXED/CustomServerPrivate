using System;
using System.Collections.Generic;
using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UIPassives : MonoBehaviour
	{
		[NonSerialized]
		public UIManager uiManager;

		[NonSerialized]
		public UITooltip uiTooltip;

		[NonSerialized]
		public InputSystem inputSystem;

		[SerializeField]
		[Header("Objects and Prefabs")]
		public GameObject passiveElementsParent;

		[SerializeField]
		public GameObject passiveElement;

		[NonSerialized]
		public List<UIPassiveElement> passiveElements;

		[NonSerialized]
		public int currentPassiveHoveredId;

		[NonSerialized]
		public InputBinding pingInput;

		public void Awake()
		{
		}

		public UIPassiveElement AddPassive(int passiveId)
		{
			return null;
		}

		public void RemovePassive(UIPassiveElement passiveElement)
		{
		}

		public void AddPassiveStack(int passiveId)
		{
		}

		public void RemovePassiveStack(int passiveId)
		{
		}

		public void ClearAll()
		{
		}

		public void LateUpdate()
		{
		}

		public void LerpCooldown(UIPassiveElement uiPassive, float cdProgress, float cdTotal, bool iconDisabledOnCooldown, bool activeByDefault)
		{
		}

		public void TriggerReady(int cmdId)
		{
		}

		public void SetReadyState(UIPassiveElement uiPassive, bool iconDisabledOnCooldown, bool activeByDefault, bool abilityIsActive = false)
		{
		}

		public void SetCooldownState(UIPassiveElement uiPassive, bool iconDisabledOnCooldown, bool activeByDefault)
		{
		}

		public void ShowPassiveTooltip(int passiveId, UIPassiveElement element)
		{
		}

		public void HideAbilityTooltip()
		{
		}
	}
}
