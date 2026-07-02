using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BAPBAP.UI
{
	public class UIHoverTooltip : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		public Action OnOpenTooltipAction;

		public Action OnCloseTooltipAction;

		public void OnPointerEnter(PointerEventData eventData)
		{
		}

		public void OnPointerExit(PointerEventData eventData)
		{
		}

		public void OnElementExit()
		{
		}

		public void OnDisable()
		{
		}
	}
}
