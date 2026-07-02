using System;
using BAPBAP.Debugging;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BAPBAP.UI.Mobile
{
	public class UIDebugInput : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		[NonSerialized]
		public DebugManager debugManager;

		public void OnPointerDown(PointerEventData eventData)
		{
		}

		public void OnPointerUp(PointerEventData eventData)
		{
		}

		public void Awake()
		{
		}
	}
}
