using System;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIToggle : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		public Toggle toggle;

		[SerializeField]
		public RectTransform knob;

		[SerializeField]
		public Image toggleBg;

		[SerializeField]
		public Image knobBg;

		[SerializeField]
		[Header("Settings")]
		public float lerpSpeed;

		[SerializeField]
		public float togglePos;

		[SerializeField]
		public Color enabledColor;

		[SerializeField]
		public Color disabledColor;

		[SerializeField]
		public Color knobEnabledColor;

		[SerializeField]
		public Color knobDisabledColor;

		[NonSerialized]
		public float timer;

		public void Awake()
		{
		}

		public void Initialize(Action<bool> onTogglePressedEvent, bool isOn = false)
		{
		}

		public void SetToggleState()
		{
		}

		public void Update()
		{
		}

		public void OnToggleStateChanged()
		{
		}
	}
}
