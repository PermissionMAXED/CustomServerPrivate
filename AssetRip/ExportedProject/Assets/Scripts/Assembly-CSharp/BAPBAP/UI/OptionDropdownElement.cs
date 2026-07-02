using System;
using UnityEngine;

namespace BAPBAP.UI
{
	public class OptionDropdownElement
	{
		public Action onClickAction;

		public string str;

		public Sprite icon;

		public bool interactable;

		public OptionDropdownElement(Action onClickAction, string str, Sprite icon, bool interactable = true)
		{
		}
	}
}
