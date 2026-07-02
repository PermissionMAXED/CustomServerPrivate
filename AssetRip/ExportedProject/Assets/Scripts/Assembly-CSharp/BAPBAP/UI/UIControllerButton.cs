using System;
using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UIControllerButton : MonoBehaviour
	{
		[SerializeField]
		public GameObject inputModeVisObj;

		[NonSerialized]
		public bool _iconVisEnabled;

		[NonSerialized]
		public bool _inputModeEnabled;

		public void Awake()
		{
		}

		public void OnInputModeChanged(InputMode inputMode)
		{
		}

		public void SetInputVisibility(bool isVisible)
		{
		}

		public void UpdateVisibility()
		{
		}
	}
}
