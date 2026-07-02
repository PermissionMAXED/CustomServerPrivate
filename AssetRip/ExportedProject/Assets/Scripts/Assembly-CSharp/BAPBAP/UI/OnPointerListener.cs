using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace BAPBAP.UI
{
	public class OnPointerListener : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		[HideInInspector]
		public UnityEvent invokeEvent;

		[SerializeField]
		public bool onLeftClick;

		[SerializeField]
		public bool onRightClick;

		[NonSerialized]
		public bool disabled;

		public void OnPointerClick(PointerEventData eventData)
		{
		}
	}
}
