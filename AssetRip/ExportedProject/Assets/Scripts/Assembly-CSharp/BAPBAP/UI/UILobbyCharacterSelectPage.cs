using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Localisation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace BAPBAP.UI
{
	public class UILobbyCharacterSelectPage : UILobbyTabPage
	{
		public enum SubPage
		{
			Summary = 0,
			Mastery = 1,
			Lore = 2
		}

		public class Actions
		{
			public Action<int> characterSelectAction;

			public Action<int> openCharacterCustomizationAction;

			public Action<int, int> characterUnlockAction;
		}

		[Serializable]
		public class CharacterAbilityPanel
		{
			public CanvasGroup CanvasGroup;

			public UIAlphaFade alphaFade;

			public UIPosLerpFade posLerpFade;

			public UIAlphaFade infoAlphaFade;

			public UIPosLerpFade infoPosLerpFade;

			public Transform AbilityIconsContentParent;

			public TMP_Text TitleText;

			public UIInputIcon InputIcon;

			public TMP_Text DescriptionText;

			public GameObject videoPlayerPlaceholder;

			public VideoPlayer videoPlayer;

			public CanvasGroup videoPlayerCanvasGroup;

			public GameObject videoSpinner;
		}

		[Serializable]
		public class CharacterUnlockPanel
		{
			public CanvasGroup canvasGroup;

			public UIAlphaFade alphaFade;

			public UIPosLerpFade posLerpFade;

			public TMP_Text headerUnlockText;

			public Image charImage;

			public TMP_Text charNameText;

			public TMP_Text charDescriptionText;

			public TMP_Text unlockSoftCurrencyText;

			public Button headerCloseButton;

			public Button closeFillButton;

			public CanvasGroup unlockButtonsCanvasGroup;

			public Button[] unlockButtons;

			public TMP_Text[] unlockButtonTexts;

			public GameObject[] unlockButtonSpinners;
		}

		[Serializable]
		public class CharacterTokensProgress
		{
			public TMP_Text titleText;

			public TMP_Text progressText;

			public LayoutFitParentPercentage LevelProgressBar;
		}

		[Serializable]
		public class CharTokenPanel : UILobbyPlayTabPage.CurrencyPanel
		{
			public GameObject gameObject;

			public TMP_Text amountText;

			public UIAlphaFade alphaFade;
		}

		[Serializable]
		public class CharacterSelectPanelAnimation
		{
			public float InDuration;

			public float OutDuration;

			public AnimationCurve PanelAlphaCurve;

			public AnimationCurve BgColorCurve;

			public AnimationCurve CharacterPositionCurve;

			public AnimationCurve CharacterOutPositionCurve;

			public AnimationCurve CharacterClosePositionCurve;

			public AnimationCurve CharacterAlphaCurve;

			public AnimationCurve NameShadowScaleCurve;

			public AnimationCurve NameShadowAlphaCurve;

			public float CharNameYPosOffset;

			public AnimationCurve CharNameTextYPosCurve;

			public AnimationCurve CharNameTextAlphaCurve;

			public Vector2 CharacterPositionOffset;

			public Vector2 NameShadowScaleOffset;
		}

		[Serializable]
		public class CharacterAbilityPosAnimation
		{
			public float InDuration;

			public float OutDuration;

			public AnimationCurve PosCurve;

			public float CharXPosOffset;
		}

		[Serializable]
		public class Configuration
		{
			public UICharactersConfiguration CharacterConfiguration;

			public string CharacterSelectButtonTranslationKey;

			public string CharacterSelectedButtonTranslationKey;

			public string CharacterCloseButtonTranslationKey;

			public string CharacterUnlockButtonTranslationKey;

			public string CharacterUnlockHeaderTranslationKey;

			public string CharacterUnlockForTranslationKey;

			public string CharacterUnlockForXTranslationKey;

			public string charTokenTooltipTitleTranslationKey;

			public string charTokenTooltipDescTranslationKey;

			public string tokenProgressMaxTokensTranslationKey;

			public string AbilityTranslationKey;

			public string CustomizeTranslationKey;

			public string CloseTranslationKey;

			public string nextCharTokenTranslationKey;

			public UIAlphaFade characterBackgroundPrefab;

			public AudioManager.SFX charSelectAnimSfx;

			public float charSelectAnimSfxVolume;

			public float charSelectPanelOpenDuration;

			public float charSelectPanelCloseDuration;

			public UILobbyCharacterSelectIcon.Configuration CharacterSelectIconConfiguration;

			public UILobbyCharacterSelectAbility.Configuration CharacterSelectAbilityConfiguration;

			public int DefaultCharacterIndex;

			public Color unlockCurrencyTextAbleColor;

			public Color unlockCurrencyTextUnableColor;

			public CharacterSelectPanelAnimation CharacterSelectAnimation;

			public CharacterAbilityPosAnimation CharacterAbilityPosAnimation;
		}

		[Header("Tab Page")]
		[SerializeField]
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
		public CanvasGroup CharacterBGHiddenParent;

		[Header("Char Progress Panel")]
		[SerializeField]
		public UIAlphaFade charProgressPanelAlphaFade;

		[SerializeField]
		public UIPosLerpFade charProgressPanelPosFade;

		[SerializeField]
		public UIAlphaFade subpageAlphaFade;

		[SerializeField]
		public UIPosLerpFade subpagePosFade;

		[SerializeField]
		public Image charProgressPanelBarFill;

		[SerializeField]
		public TMP_Text NameText;

		[SerializeField]
		public TMP_Text DescriptionText;

		[Header("Select Panel")]
		[SerializeField]
		public CanvasGroup SelectPanelCanvas;

		[SerializeField]
		public UIAlphaFade SelectPanelAlphaFade;

		[SerializeField]
		public Transform CharacterBackgroundParent;

		[SerializeField]
		public Image CharacterImage;

		[SerializeField]
		public Image CharacterShadow;

		[SerializeField]
		public TMP_Text NameShadowText;

		[SerializeField]
		public UIAlphaAnim CharacterSelectAnimFade;

		[SerializeField]
		public TransformScaleAnimation CharacterSelectAnimTransformScale;

		[SerializeField]
		public Button AbilitiesButton;

		[SerializeField]
		public Button AbilitiesCloseButton;

		[SerializeField]
		public Button MasteryButton;

		[SerializeField]
		public TMP_Text MasteryButtonText;

		[SerializeField]
		public GameObject masteryButtonNotification;

		[SerializeField]
		public Button SelectButton;

		[SerializeField]
		public TMP_Text SelectButtonText;

		[SerializeField]
		public Button CloseButton;

		[SerializeField]
		public TMP_Text CloseButtonText;

		[SerializeField]
		public Button UnlockButton;

		[SerializeField]
		public TMP_Text LevelRequirementToUnlockText;

		[SerializeField]
		public UIAlphaFade UnlockButtonUIAlphaFade;

		[SerializeField]
		public UIPosLerpFade UnlockButtonUIPosLerp;

		[SerializeField]
		public TMP_Text UnlockButtonText;

		[SerializeField]
		public TMP_Text UnlockButtonCostText;

		[SerializeField]
		public Transform IconParent;

		[SerializeField]
		public RectTransform CharacterRectTransform;

		[SerializeField]
		[Space(5f)]
		public CharacterAbilityPanel _characterAbilityPanel;

		[SerializeField]
		[Space(5f)]
		public CharacterUnlockPanel _characterUnlockPanel;

		[Space(5f)]
		[SerializeField]
		public CharacterTokensProgress charTokenProgress;

		[Header("Subpages")]
		[SerializeField]
		public Button _summaryButton;

		[SerializeField]
		public UIAnchorWidthLerp _summaryButtonWidthLerp;

		[SerializeField]
		public UIAlphaFade _summaryAlphaFade;

		[SerializeField]
		public Button _masteryButton;

		[SerializeField]
		public UIAnchorWidthLerp _masteryButtonWidthLerp;

		[SerializeField]
		public Button _loreButton;

		[SerializeField]
		public UIAnchorWidthLerp _loreButtonWidthLerp;

		[SerializeField]
		public UIAlphaFade _loreAlphaFade;

		[Header("External")]
		[SerializeField]
		public CharTokenPanel charTokenPanel;

		[NonSerialized]
		public Actions _actions;

		[NonSerialized]
		public CharacterPageModel _data;

		[NonSerialized]
		public UILobbyCharacterCustomizePage charCustomizePage;

		[NonSerialized]
		public UILobbyPlayTabPage playPage;

		[NonSerialized]
		public UILobbyMatchCharacterSelectPage matchCharSelectPage;

		[NonSerialized]
		public Configuration _configuration;

		[NonSerialized]
		public Translator _translator;

		public const int characterOffset = 200000;

		[NonSerialized]
		public bool _animateCharacterChange;

		[NonSerialized]
		public bool _animateCharacterSelectPanel;

		[NonSerialized]
		public float _animationTime;

		[NonSerialized]
		public bool _animateCharAbilityPos;

		[NonSerialized]
		public float _animateCharAbilityStartPos;

		[NonSerialized]
		public float _animateCharAbilityEndPos;

		[NonSerialized]
		public float _animationCharAbilityPosTime;

		[NonSerialized]
		public List<UILobbyCharacterSelectAbility> _characterAbilityEntries;

		[NonSerialized]
		public UILobbyCharacterSelectAbility.Factory _characterSelectAbilityFactory;

		[NonSerialized]
		public UILobbyCharacterSelectAbility selectedAbilityIcon;

		[NonSerialized]
		public InputBinding selectedAbilityInput;

		[NonSerialized]
		public UILobbyCharacterSelectIcon.Factory _characterSelectIconFactory;

		[NonSerialized]
		public UILobbyCharacterSelectIcon[] _characterSelectIcons;

		[NonSerialized]
		public UIAlphaFade[] _characterBackgrounds;

		[NonSerialized]
		public UILobbyChatEntry.Pool _chatEntryPool;

		[NonSerialized]
		public UILobbyCharacterSelectIcon selectedCharacterIcon;

		[NonSerialized]
		public int selectedCharIndex;

		[NonSerialized]
		public int selectedCostIndex;

		[NonSerialized]
		public bool characterSelectActive;

		[NonSerialized]
		public bool preventCharcterSelect;

		[NonSerialized]
		public string charUnlockForXStr;

		[NonSerialized]
		public string charSelectButtonStr;

		[NonSerialized]
		public string charSelectedButtonStr;

		[NonSerialized]
		public string tokenProgressMaxTokensStr;

		[NonSerialized]
		public SubPage _currentSubPage;

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

		public void SetActions(Actions actions)
		{
		}

		public void Initialise(CharacterPageModel data)
		{
		}

		public void UpdateData(CharacterPageModel data)
		{
		}

		public void UpdateAvailableCharactersData()
		{
		}

		public void UpdateCharRotation()
		{
		}

		public void UpdateDataUnlockCharacter(int charId)
		{
		}

		public void UpdateCharTokenPassXp()
		{
		}

		public void TryUpdateCharMasteryBadge(int charId)
		{
		}

		public void SetCurrentCharTokenProgressUI(int progress, int progressNeeded)
		{
		}

		public void SetCharTokensCurrencyPanelUI(int balance)
		{
		}

		public void UpdateCharacterIconButtonXpAndLevel(int charId, float xpProgress, int level)
		{
		}

		public override void OnPageOpen()
		{
		}

		public override void OnPageClose()
		{
		}

		public void SelectCharIconButton(int selectedCharId)
		{
		}

		public void ToggleUnlockButton()
		{
		}

		public void HideUnlockButton()
		{
		}

		public void OpenCharacterSelectPage()
		{
		}

		public void CloseCharacterSelectPage(bool doFadeOut = true)
		{
		}

		public void ChangeSubPage(SubPage page, bool forceChange = false)
		{
		}

		public void OpenCharacterSummaryPage()
		{
		}

		public void OpenCharacterMasteryPage()
		{
		}

		public void OpenCharacterLorePage()
		{
		}

		public void OpenCharSelectPanel(bool instant = false)
		{
		}

		public void CloseCharSelectPanel(bool instant = false)
		{
		}

		public void OpenCharacterAbilityPanel()
		{
		}

		public void CloseCharacterAbilityPanel(bool lerpChar = true)
		{
		}

		public void InitializeCharacterAbilities(int charIndex)
		{
		}

		public void OnCharacterAbilitySelected(int abilityIndex)
		{
		}

		public void TryUpdateKeyBinds(InputBinding input, bool isGamepad)
		{
		}

		public void AnimateCharacterSelectPanel(float t)
		{
		}

		public void AnimateCharacterChange(float t)
		{
		}

		public void SelectCharacter()
		{
		}

		public void OnCharacterButtonSelect(UILobbyCharacterSelectIcon icon, int index)
		{
		}

		public void OnCharacterSelect(int charIndex)
		{
		}

		public void UpdateCharacterIconButtonsState(LobbyDataModel data)
		{
		}

		public void SetNotificationOnCharacterButton(int charId, bool isEnabled)
		{
		}

		public void SetMasteryButtonNotification(bool isEnabled)
		{
		}

		public void TrySetSelectedCharMasteryButtonNotification(int charId)
		{
		}

		public void SetPreventCharacterSelect(bool preventEnabled)
		{
		}

		public void SetCharacterButtonState(int charIndex)
		{
		}

		public void SetUnlockButtonActiveState(int charId)
		{
		}

		public void OpenCharacterUnlockPanel()
		{
		}

		public void CloseCharacterUnlockPanel()
		{
		}

		public void InitializeCharacterUnlockPanel(int charIndex)
		{
		}

		public void OnCharacterUnlockButton(int index)
		{
		}

		public void OnCharacterUnlockSuccess()
		{
		}

		public void OnCloseObtainedRewardPage()
		{
		}

		public void SetUnlockButtonSpinnerEnabled(bool isEnabled, int index)
		{
		}

		public int GetCharTokenLevelXpNeeded(int level)
		{
			return 0;
		}

		public int GetCurrentCharTokenLevelXpNeeded(int level)
		{
			return 0;
		}

		public int GetCharTokenLevelFromXp(int xp)
		{
			return 0;
		}

		public int GetCharTokenXp()
		{
			return 0;
		}

		public int GetPrevCharTokenXp()
		{
			return 0;
		}

		public int GetCharTokenPrevLevel()
		{
			return 0;
		}

		public int GetCharTokenLevel()
		{
			return 0;
		}

		public int GetCharTokenMaxLevel()
		{
			return 0;
		}

		public bool TryGetCharacterIdFromListing(string listingId, out int charId)
		{
			charId = default(int);
			return false;
		}

		public bool CharacterIsSelectable(int charId)
		{
			return false;
		}

		public bool CharacterIsUnlocked(int charId)
		{
			return false;
		}

		public bool CharacterIsInRotation(int charId)
		{
			return false;
		}

		public int GetCharacterListingIndexFromCharId(int charId)
		{
			return 0;
		}

		public int GetCharIndexFromCharId(int charId)
		{
			return 0;
		}
	}
}
