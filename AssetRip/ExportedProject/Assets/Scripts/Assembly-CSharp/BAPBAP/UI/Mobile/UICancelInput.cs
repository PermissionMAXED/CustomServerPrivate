using System;
using BAPBAP.Local;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BAPBAP.UI.Mobile
{
	public class UICancelInput : OnScreenInput, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		public CanvasGroup canvasGroup;

		[NonSerialized]
		public InputSystem inputSystem;

		public void OnPointerEnter(PointerEventData eventData)
		{
		}

		public void OnPointerExit(PointerEventData eventData)
		{
		}

		public override void OnEnable()
		{
		}

		public void Awake()
		{
		}

		public void Update()
		{
		}

		public void Show()
		{
		}

		public void Hide()
		{
		}
	}
}
