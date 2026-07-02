using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIAugmentToggle : MonoBehaviour
	{
		[NonSerialized]
		public UIAugments _uiAugments;

		[SerializeField]
		public TMP_Text _counterText;

		[SerializeField]
		public Button _button;

		public void Awake()
		{
		}

		public void SetAugmentCounter(int augmentCounter)
		{
		}

		public void ToggleAugments()
		{
		}
	}
}
