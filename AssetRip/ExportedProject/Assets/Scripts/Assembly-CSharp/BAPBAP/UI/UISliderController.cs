using System;
using BAPBAP.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UISliderController : UIPropertyController
	{
		[Header("References")]
		[SerializeField]
		public Slider slider;

		[SerializeField]
		public TMP_Text valueDisplay;

		[SerializeField]
		public EventTrigger eventTrigger;

		[Header("Settings")]
		[SerializeField]
		public RangeFloat rangeValues;

		[SerializeField]
		public float ControllerMoveAmount;

		[NonSerialized]
		public float _controllerMoveAmount;

		[NonSerialized]
		public Action<float> onValueChangedEvent;

		public void Initialize(string propertyTrKey, string descTrKey, Action<UIPropertyController> onSelectedAction, Action<float> onValueChangedEvent, float propertyValue, bool fireActionOnRelease, RangeFloat range, RangeFloat sliderRange, bool wholeNumbers)
		{
		}

		public float GetNormalizedSliderValue()
		{
			return 0f;
		}

		public float GetRangeRemapValue(float normValue)
		{
			return 0f;
		}

		public float GetNormValueFromRemappedValue(float remappedValue)
		{
			return 0f;
		}

		public void SetValue()
		{
		}

		public float GetValue()
		{
			return 0f;
		}

		public void SetSliderDisplay(float sliderValue)
		{
		}

		public void SetSliderProgress(float normValue)
		{
		}

		public void SetDisplayValuePercentage(float value)
		{
		}

		public override void OnSubmit()
		{
		}

		public override void OnMove(Vector2 moveDir)
		{
		}
	}
}
