using System;
using BAPBAP.Player;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BAPBAP.UI.Mobile
{
	public class UIPingInput : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IDragHandler
	{
		[SerializeField]
		public PlayerPing.PositionType pingType;

		[NonSerialized]
		public RectTransform rect;

		[NonSerialized]
		public RectTransform parentRect;

		[NonSerialized]
		public Vector2 startPosition;

		[NonSerialized]
		public Vector2 position;

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

		public void DoPing()
		{
		}

		public static void PointerToRect(RectTransform rt, PointerEventData @event, out Vector2 point)
		{
			point = default(Vector2);
		}
	}
}
