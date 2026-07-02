using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BAPBAP.UI
{
	[DefaultExecutionOrder(-50)]
	[ExecuteAlways]
	public class UIUberGraphicEventHandler : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, ISelectHandler, IDeselectHandler
	{
		[SerializeField]
		public UIUberGraphicSO baseGraphic;

		[SerializeField]
		public UIUberGraphicSO pointerEnter;

		[SerializeField]
		public UIUberGraphicSO pointerExit;

		[SerializeField]
		public UIUberGraphicSO pointerDown;

		[SerializeField]
		public UIUberGraphicSO pointerUp;

		[SerializeField]
		public UIUberGraphicSO select;

		[SerializeField]
		public UIUberGraphicSO deselect;

		public Action<UIUberGraphicSO> OnGraphicChanged;

		public bool IsSelected { get; set; }

		public void OnEnable()
		{
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
		}

		public void OnPointerExit(PointerEventData eventData)
		{
		}

		public void OnPointerDown(PointerEventData eventData)
		{
		}

		public void OnPointerUp(PointerEventData eventData)
		{
		}

		public void OnSelect(BaseEventData eventData)
		{
		}

		public void OnDeselect(BaseEventData eventData)
		{
		}

		public void OnPointerEnter()
		{
		}

		public void OnPointerExit()
		{
		}

		public void OnPointerDown()
		{
		}

		public void OnPointerUp()
		{
		}

		public void OnSelect()
		{
		}

		public void OnDeselect()
		{
		}
	}
}
