using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	[RequireComponent(typeof(EventTrigger))]
	public class UIHoverCursor : MonoBehaviour
	{
		[NonSerialized]
		public UIManager uiManager;

		[NonSerialized]
		public Selectable selectable;

		[NonSerialized]
		public EventTrigger eventTrigger;

		[SerializeField]
		[Header("Settings")]
		public bool onlyIfInteractable;

		public void Awake()
		{
		}

		public void OnDisable()
		{
		}

		public void OnBeginHover()
		{
		}

		public void OnStopHover()
		{
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
		}

		public void OnPointerExit(PointerEventData eventData)
		{
		}

		public void ForceSetHoverState(bool isHovering)
		{
		}
	}
}
