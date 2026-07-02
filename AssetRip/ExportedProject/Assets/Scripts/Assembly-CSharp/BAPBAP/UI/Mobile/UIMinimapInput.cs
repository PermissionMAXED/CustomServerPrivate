using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BAPBAP.UI.Mobile
{
	public class UIMinimapInput : OnScreenInput, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		[SerializeField]
		public CanvasGroup closeCanvasGroup;

		[NonSerialized]
		public UIMinimap minimap;

		public override void OnEnable()
		{
		}

		public void OnPointerDown(PointerEventData eventData)
		{
		}

		public void OnPointerUp(PointerEventData eventData)
		{
		}

		public void Awake()
		{
		}

		public void Update()
		{
		}
	}
}
