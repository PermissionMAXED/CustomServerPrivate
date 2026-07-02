using System;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIToggleController : UIPropertyController
	{
		[SerializeField]
		[Header("References")]
		public Button onButton;

		[SerializeField]
		public Button offButton;

		[NonSerialized]
		public Action<bool> pressedEvent;

		public void Initialize(string propertyTrKey, string descTrKey, Action<UIPropertyController> onSelectedAction, Action<bool> _pressedEvent, bool isOn = false)
		{
		}

		public void SelectButton(bool isOn)
		{
		}

		public void SetSelectedButton(bool isOn)
		{
		}

		public override void OnSubmit()
		{
		}
	}
}
