using System;
using BAPBAP.Localisation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UISelectorController : UIPropertyController
	{
		[SerializeField]
		[Header("References")]
		public Button prevButton;

		[SerializeField]
		public Button nextButton;

		[SerializeField]
		public TMP_Text valueDisplay;

		[SerializeField]
		public UIPosLerpFade posLerpFade;

		[SerializeField]
		[Header("Settings")]
		public float selectLerpAmount;

		[SerializeField]
		public Color barUnselectedColor;

		[SerializeField]
		public Color barSelectedColor;

		[NonSerialized]
		public string[] valuesTranslationKeys;

		[NonSerialized]
		public string[] values;

		[NonSerialized]
		public int selectedId;

		[NonSerialized]
		public int valuesLength;

		[SerializeField]
		public Transform optionBarHolder;

		[SerializeField]
		public Image optionBarTemplate;

		[NonSerialized]
		public Image[] optionBars;

		[NonSerialized]
		public Action<int> OnValueChanged;

		public void Awake()
		{
		}

		public void Initialize(string propertyTrKey, string descTrKey, Action<UIPropertyController> onSelectedAction, Action<int> onValueChangedEvent, string[] _valuesTranslationKeys, int defaultSelectedId = 0)
		{
		}

		public override void Localise(Translator translator)
		{
		}

		public void OnLeftArrowPressed()
		{
		}

		public void OnRightArrowPressed()
		{
		}

		public void SetValue(int valueId)
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
