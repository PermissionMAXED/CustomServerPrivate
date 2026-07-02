using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BAPBAP.UI
{
	[DefaultExecutionOrder(-50)]
	[ExecuteAlways]
	public class UberSDFEventHandler : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, ISelectHandler, IDeselectHandler
	{
		[SerializeField]
		public UberSDFSO baseSDF;

		[SerializeField]
		public UberSDFSO pointerEnter;

		[SerializeField]
		public UberSDFSO pointerExit;

		[SerializeField]
		public UberSDFSO pointerDown;

		[SerializeField]
		public UberSDFSO pointerUp;

		[SerializeField]
		public UberSDFSO select;

		[SerializeField]
		public UberSDFSO deselect;

		public Action<UberSDFSO> OnSDFChanged;

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
