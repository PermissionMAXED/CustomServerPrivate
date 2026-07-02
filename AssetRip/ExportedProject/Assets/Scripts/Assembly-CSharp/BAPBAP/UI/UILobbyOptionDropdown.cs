using System;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UILobbyOptionDropdown : MonoBehaviour
	{
		[SerializeField]
		public GameObject containerGameObject;

		[SerializeField]
		public OnPointerListener blocker;

		[SerializeField]
		public UIPosLerpFade dropdownPosLerpFade;

		[SerializeField]
		public Transform dropdownPivotTransform;

		[SerializeField]
		public Transform optionContainer;

		[SerializeField]
		public UISelectSfxElement uiSelectSfxElement;

		[SerializeField]
		public float horizontalPadding;

		[SerializeField]
		public float verticalPadding;

		[SerializeField]
		public GameObject optionTemplate;

		[NonSerialized]
		public int optionCount;

		[NonSerialized]
		public Button[] optionButtons;

		public void Awake()
		{
		}

		public void Initialize(OptionDropdownElement[] options)
		{
		}

		public Button SpawnOption(OptionDropdownElement optionElement)
		{
			return null;
		}

		public void OpenOptionDropdown(Vector2 screenPos)
		{
		}

		public void CloseOptionDropdown()
		{
		}

		public bool IsOpen()
		{
			return false;
		}
	}
}
