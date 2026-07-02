using System;
using BAPBAP.Localisation;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIDropdown : MonoBehaviour
	{
		[Serializable]
		public struct DropdownOptionData
		{
			public string translationkey;

			public Sprite icon;
		}

		[SerializeField]
		[Header("References")]
		public CustomTMP_Dropdown dropdown;

		[SerializeField]
		public UISelectSfxElement sfxElement;

		[SerializeField]
		public UIOnClickYPosLerp clickPos;

		[SerializeField]
		public Image arrowIcon;

		[SerializeField]
		[Header("Settings")]
		public Color itemBgUnselectedColor;

		[SerializeField]
		public Color itemBgSelectedColor;

		[SerializeField]
		public Color itemTextUnselectedColor;

		[SerializeField]
		public Color itemTextSelectedColor;

		[NonSerialized]
		public DropdownOptionData[] _optionData;

		[NonSerialized]
		public int _selectedId;

		[NonSerialized]
		public Action<int> _onValueChanged;

		public void Awake()
		{
		}

		public void Update()
		{
		}

		public void Initialize(Action<int> onValueSelectedEvent, DropdownOptionData[] _optionData, int defaultSelectedId = 0)
		{
		}

		public void Localise(Translator translator)
		{
		}

		public void OnValuePressed(int newId)
		{
		}

		public void SetValue(int valueId)
		{
		}

		public void SetItemToggleSelectedColor(MultiGraphicToggle t)
		{
		}

		public void ToggleArrow(bool isInteractable)
		{
		}
	}
}
