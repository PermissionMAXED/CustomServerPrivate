using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BAPBAP.Local
{
	[Serializable]
	public class InputBinding
	{
		[NonSerialized]
		public InputTarget _target;

		public KeyCode keybind;

		public InputAction action;

		public Sprite actionIcon;

		public string translationKey;

		public bool rebindable;

		public InputTarget target => default(InputTarget);

		public bool GetPressed()
		{
			return false;
		}

		public bool GetHeld()
		{
			return false;
		}

		public bool GetReleased()
		{
			return false;
		}

		public void SetActionBind(KeyCode newBind)
		{
		}
	}
}
