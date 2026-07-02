using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	[RequireComponent(typeof(Selectable))]
	public class UISelectableControllerButton : MonoBehaviour, ISelectHandler, IEventSystemHandler, IDeselectHandler
	{
		[NonSerialized]
		public Selectable selectable;

		[SerializeField]
		public UIControllerButton controllerButton;

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void OnSelect(BaseEventData eventData)
		{
		}

		public void OnDeselect(BaseEventData eventData)
		{
		}
	}
}
