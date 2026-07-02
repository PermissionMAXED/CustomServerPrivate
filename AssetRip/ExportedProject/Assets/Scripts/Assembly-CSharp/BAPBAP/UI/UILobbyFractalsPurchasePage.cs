using System;
using BAPBAP.Localisation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UILobbyFractalsPurchasePage : UILobbyTabPage
	{
		[Serializable]
		public class Configuration
		{
			public Sprite[] sprites;

			public string titleTranslationKey;

			public string descriptionTranslationKey;

			public string fractalsTranslationKey;

			public string bonusTranslationKey;
		}

		public class Actions
		{
			public Action<string> purchaseAction;
		}

		[SerializeField]
		[Header("Tab Page")]
		public CanvasGroup _canvasGroup;

		[SerializeField]
		public Selectable _canvasGroupSelectable;

		[SerializeField]
		public UIPosLerpFade _uiLerpFade;

		[SerializeField]
		public UIAlphaFade _uiAlphaFade;

		[SerializeField]
		public UIAlphaFade _backgroundUIFade;

		[SerializeField]
		[Header("UI Elements")]
		public TMP_Text _titleTMPText;

		[SerializeField]
		public TMP_Text _descriptionTMPText;

		[SerializeField]
		public Button _closeButton;

		[SerializeField]
		public Button _fillButton;

		[Header("Option Elements")]
		[SerializeField]
		public UILobbyFractalPurchaseOption _optionPrefab;

		[SerializeField]
		public Transform _optionParent;

		[NonSerialized]
		public Configuration _config;

		[NonSerialized]
		public FractalsPurchaseModel _data;

		[NonSerialized]
		public Actions _actions;

		[NonSerialized]
		public Translator _translator;

		[NonSerialized]
		public UILobbyFractalPurchaseOption[] _options;

		public override CanvasGroup CanvasGroup => null;

		public override Selectable CanvasGroupSelectable => null;

		public override UIPosLerpFade UILerpFade => null;

		public override UIAlphaFade UIAlphaFade => null;

		public override UIAlphaFade backgroundUIFade => null;

		public Action CloseAction
		{
			set
			{
			}
		}

		public void FixedUpdate()
		{
		}

		public void Update()
		{
		}

		public void Build(Configuration config, Translator translator)
		{
		}

		public void SetActions(Actions actions)
		{
		}

		public void Initialise(FractalsPurchaseModel data)
		{
		}

		public override void Localise(Translator translator)
		{
		}

		public override void OnPageOpen()
		{
		}

		public void UpdateData(FractalsPurchaseModel data)
		{
		}

		public void ClosePage()
		{
		}

		public Sprite GetSpriteFromIndex(int index)
		{
			return null;
		}
	}
}
