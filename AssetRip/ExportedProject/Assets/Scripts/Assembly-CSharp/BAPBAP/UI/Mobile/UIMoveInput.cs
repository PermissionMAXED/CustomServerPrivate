using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BAPBAP.UI.Mobile
{
	public class UIMoveInput : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IDragHandler
	{
		[SerializeField]
		public float range;

		[SerializeField]
		public OnScreenInput stick;

		[NonSerialized]
		public RectTransform rect;

		[NonSerialized]
		public RectTransform parentRect;

		[NonSerialized]
		public Vector2 startPosition;

		[NonSerialized]
		public Vector2 downPosition;

		public void OnPointerDown(PointerEventData eventData)
		{
		}

		public void OnDrag(PointerEventData eventData)
		{
		}

		public void OnPointerUp(PointerEventData eventData)
		{
		}

		public void OnEnable()
		{
		}

		public void Awake()
		{
		}

		public static void PointerToRect(RectTransform rt, PointerEventData @event, out Vector2 point)
		{
			point = default(Vector2);
		}
	}
}
