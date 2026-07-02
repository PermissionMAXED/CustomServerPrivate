using System;
using BAPBAP.Localisation;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UIDropdownController : UIPropertyController
	{
		[SerializeField]
		[Header("References")]
		public UIDropdown Dropdown;

		public void Awake()
		{
		}

		public void Initialize(string propertyTrKey, string descTrKey, Action<UIPropertyController> onSelectedAction, Action<int> onValueSelectedEvent, UIDropdown.DropdownOptionData[] _optionData, int defaultSelectedId = 0)
		{
		}

		public override void Localise(Translator translator)
		{
		}

		public void SetValue(int valueId)
		{
		}

		public override void OnSubmit()
		{
		}

		public void OnHide()
		{
		}
	}
}
