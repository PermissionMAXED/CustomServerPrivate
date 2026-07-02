using System;
using BAPBAP.Local;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace BAPBAP.UI.Mobile
{
	public class UIAbilityInput : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IDragHandler
	{
		[SerializeField]
		public OnScreenInput button;

		[SerializeField]
		public OnScreenInput stick;

		[SerializeField]
		public float range;

		[NonSerialized]
		public BAPBAP.Local.InputSystem inputSystem;

		[NonSerialized]
		public InputAction cancelAction;

		[NonSerialized]
		public RectTransform selfRect;

		[NonSerialized]
		public RectTransform stickRect;

		[NonSerialized]
		public Vector2 startPosition;

		[NonSerialized]
		public Vector2 downPosition;

		[NonSerialized]
		public bool cancelled;

		public void OnPointerDown(PointerEventData eventData)
		{
		}

		public void OnPointerUp(PointerEventData eventData)
		{
		}

		public void OnDrag(PointerEventData eventData)
		{
		}

		public void Awake()
		{
		}

		public void OnEnable()
		{
		}

		public static void PointerToRect(RectTransform rt, PointerEventData @event, out Vector2 point)
		{
			point = default(Vector2);
		}
	}
}
