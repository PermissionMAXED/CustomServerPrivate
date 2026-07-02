using System;
using BAPBAP.Entities;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BAPBAP.UI.Mobile
{
	public class UIHealInput : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		[SerializeField]
		public OnScreenInput healInput;

		[SerializeField]
		public OnScreenInput cancelInput;

		[SerializeField]
		public CanvasGroup healCanvasGroup;

		[SerializeField]
		public CanvasGroup cancelCanvasGroup;

		[NonSerialized]
		public bool active;

		[NonSerialized]
		public bool casting;

		public void OnPointerDown(PointerEventData eventData)
		{
		}

		public void OnPointerUp(PointerEventData eventData)
		{
		}

		public void Update()
		{
		}

		public void Hide()
		{
		}

		public void ShowHeal()
		{
		}

		public void ShowCancel()
		{
		}

		public bool TryGetPlayerCharacter(out EntityManager @char)
		{
			@char = null;
			return false;
		}
	}
}
