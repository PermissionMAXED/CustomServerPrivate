using System;
using TMPro;
using UnityEngine.EventSystems;

namespace BAPBAP.UI
{
	public class CustomTMP_Dropdown : TMP_Dropdown, ISelectHandler, IEventSystemHandler
	{
		[NonSerialized]
		public bool doDeselect;

		[NonSerialized]
		public bool prevInteractable;

		public Action onSelectAction;

		public Action<bool> onInteractableStateChanged;

		public override void OnPointerClick(PointerEventData eventData)
		{
		}

		public override void OnSelect(BaseEventData eventData)
		{
		}

		public override void OnSubmit(BaseEventData eventData)
		{
		}

		public override void OnCancel(BaseEventData eventData)
		{
		}

		public void Update()
		{
		}

		public void OnDropdownShown()
		{
		}
	}
}
