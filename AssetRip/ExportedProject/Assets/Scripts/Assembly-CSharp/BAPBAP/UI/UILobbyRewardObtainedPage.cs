using System;
using BAPBAP.Content;
using BAPBAP.Local;
using BAPBAP.Localisation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UILobbyRewardObtainedPage : UILobbyTabPage
	{
		[Serializable]
		public class ContentRewardPanel
		{
			public CanvasGroup canvasGroup;

			public CanvasGroup displayCanvasGroup;

			public UIAlphaFade displayAlphaFade;

			public Image displayImage;

			public Image glowImage;

			public GameObject lightRays;

			public Image speedFxImage;

			public UIContentRarityStars rarityStars;

			public TMP_Text categoryText;

			public TMP_Text rewardObtainedHeaderText;

			public TMP_Text typeRarityText;

			public TMP_Text titleText;

			public TMP_Text clickToContinueText;

			public TMP_Text controllerContinueText;

			public UIAlphaLoop clickToContinueLoop;

			public Button closePanelButton;
		}

		[Serializable]
		public class CharacterRewardPanel
		{
			public CanvasGroup canvasGroup;

			public CanvasGroup displayCanvasGroup;

			public UIAlphaFade displayAlphaFade;

			public Image displayImage;

			public Image glowImage;

			public GameObject lightRays;

			public Image speedFxImage;

			public TMP_Text rewardObtainedHeaderText;

			public TMP_Text titleText;

			public TMP_Text descriptionText;

			public TMP_Text clickToContinueText;

			public TMP_Text controllerContinueText;

			public UIAlphaLoop clickToContinueLoop;

			public Button closePanelButton;
		}

		[Serializable]
		public class Configuration
		{
			public ContentConfiguration contentConfig;

			public UICharactersConfiguration characterConfig;

			public CurrencyData currencyData;

			public string contentObtainedTranslationKey;

			public string characterObtainedTranslationKey;

			public string buttonEquipTranslationKey;

			public string buttonCloseTranslationKey;

			public string clickToContinueTranslationKey;

			public string controllerContinueTranslationKey;

			public float rewardObtainedAnimDuration;

			public AnimationCurve rewardObtainedGlowScaleCurve;

			public AnimationCurve rewardObtainedGlowAlphaCurve;

			public AnimationCurve rewardObtainedFxAlphaCurve;

			public AudioManager.SFX claimedRewardSound;

			public float claimedRewardSfxVolume;

			public AudioManager.SFX claimedCharacterSound;

			public float claimedCharacterSfxVolume;
		}

		[SerializeField]
		public CanvasGroup canvasGroup;

		[SerializeField]
		public Selectable _canvasGroupSelectable;

		[SerializeField]
		public UIPosLerpFade lerpFade;

		[SerializeField]
		public UIAlphaFade alphaFade;

		[SerializeField]
		public UIAlphaFade _backgroundUIFade;

		[SerializeField]
		public CanvasGroup panelsCanvasGroup;

		[SerializeField]
		public ContentRewardPanel contentRewardPanel;

		[SerializeField]
		public CharacterRewardPanel characterRewardPanel;

		[NonSerialized]
		public Configuration _configuration;

		[NonSerialized]
		public Translator _translator;

		[NonSerialized]
		public Action onRewardCloseAction;

		[NonSerialized]
		public BAPBAP.Content.Content contentToEquip;

		[NonSerialized]
		public bool animateContentObtained;

		[NonSerialized]
		public float contentObtainedTime;

		[NonSerialized]
		public bool animateCharacterObtained;

		[NonSerialized]
		public float characterObtainedTime;

		public override CanvasGroup CanvasGroup => null;

		public override Selectable CanvasGroupSelectable => null;

		public override UIPosLerpFade UILerpFade => null;

		public override UIAlphaFade UIAlphaFade => null;

		public override UIAlphaFade backgroundUIFade => null;

		public void FixedUpdate()
		{
		}

		public void Update()
		{
		}

		public void Build(Configuration configuration, Translator translator)
		{
		}

		public override void Localise(Translator translator)
		{
		}

		public void TryCloseRewardObtainedPage()
		{
		}

		public override void OnInputModeChanged(InputMode inputMode)
		{
		}

		public void EnableContentPanel(bool isEnabled)
		{
		}

		public void OpenCurrencyObtainedPanel(int assetId, int amount)
		{
		}

		public void OpenCurrencyObtainedPanel(Currency currency, int amount)
		{
		}

		public void SetOnRewardCloseAction(Action onRewardCloseAction)
		{
		}

		public void OpenContentObtainedPanel(int assetId, int balance = 0, Action onRewardCloseAction = null)
		{
		}

		public void OpenContentObtainedPanel(BAPBAP.Content.Content reward, int amount = 0)
		{
		}

		public void InitializeContentObtainedPanel(BAPBAP.Content.Content reward, int amount = 0)
		{
		}

		public void CloseContentObtainedPanel()
		{
		}

		public void CloseContentObtainedAndOpenEquipPage()
		{
		}

		public void EnableCharacterPanel(bool isEnabled)
		{
		}

		public void OpenCharacterObtainedPanel(int charId, Action onRewardCloseAction = null)
		{
		}

		public void InitializeCharacterObtainedPanel(int charId, Action onRewardCloseAction = null)
		{
		}

		public void CloseCharacterObtainedPanel()
		{
		}
	}
}
