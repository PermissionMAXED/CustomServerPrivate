using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Localisation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UILobbyCommunityChallengePage : UILobbyTabPage
	{
		public class Actions
		{
			public Action challengeRequestAction;

			public Action twitchLinkAction;

			public Action copyReferralCodeAction;

			public Action<string> signUpAction;

			public Action<string> claimReferralLiveAction;

			public Action<string> claimGamesLiveAction;

			public Action<string, string> claimDropsLiveAction;
		}

		[Serializable]
		public class ContentTableEntry
		{
			public MultiGraphicButton button;

			public LayoutElement layoutElement;

			public TMP_Text titleText;
		}

		[Serializable]
		public class ChallengePanel
		{
			public RectTransform transform;

			public CanvasGroup canvasGroup;

			public UIPosLerpFade posLerpFade;

			public UIAlphaFade contentsAlphaFade;

			public UIPosLerpFade contentsPosLerpFade;

			public ContentTableEntry contentTableEntry;

			public virtual void Localise(Translator translator)
			{
			}

			public virtual void Animate()
			{
			}

			public virtual void OpenPanel(bool instant = false)
			{
			}

			public virtual void ClosePanel(bool instant = false)
			{
			}
		}

		[Serializable]
		public class PanelMain : ChallengePanel
		{
			[Serializable]
			public class Configuration
			{
				public string signUpTitleTranslationKey;

				public string timeToSignUpTranslationKey;

				public string xSignUpsTranslationKey;

				public string signUpsNeededToStartTranslationKey;

				public string earnLivesButtonTranslationKey;

				public string youAreSignedUpTranslationKey;

				public string signedUpInviteButtonTranslationKey;

				public string signUpsDescTranslationKey;

				public string signUpTimeExpiredTranslationKey;

				public SFXData prizePoolCountSfx;

				public SFXData prizePoolFinishedSfx;

				[Header("Fade in anim")]
				public float openAnimDuration;

				public AnimationCurve priceAnimCurve;

				public float openPriceAnimUpdRate;

				public AnimationCurve signUpButtonAlphaCurve;

				public AnimationCurve signUpButtonPosCurve;

				public float signUpButtonPosOffset;

				public AnimationCurve signUpsAlphaCurve;

				public AnimationCurve signUpsPosCurve;

				public float signUpsPosOffset;

				public AnimationCurve signUpsBarCurve;

				public AnimationCurve timeToSignUpAlphaCurve;

				public float prizePoolAnimDuration;
			}

			public RectTransform liveSignUpFeedPanel;

			public RectTransform liveSignUpEntryParent;

			public CanvasGroup signUpsCanvasGroup;

			public RectTransform signUpsPosRect;

			public TMP_Text priceText;

			public UIDigitAnimator priceDigitAnimator;

			public CanvasGroup timeToSignUpCanvasGroup;

			public TMP_Text timeToSignUpText;

			public TMP_Text timeToSignUpTimeText;

			public CanvasGroup signUpContainerCanvasGroup;

			public RectTransform signUpContainerPosRect;

			public GameObject signUpButtonContainer;

			public Button signUpButton;

			public TMP_Text signUpButtonText;

			public GameObject signedUpInviteButtonContainer;

			public TMP_Text youAreSignedUpText;

			public Button signedUpInviteButton;

			public TMP_Text signedUpInviteButtonText;

			public TMP_Text inviteCodeButtonText;

			public TMP_Text signUpTimeExpired;

			public LayoutFitParentPercentage signUpsProgressBar;

			public TMP_Text signUpsText;

			public TMP_Text signUpsNeededToStartText;

			public TMP_Text signUpsDescText;

			public Button earnLivesButton;

			public TMP_Text earnLivesButtonText;

			[NonSerialized]
			public Configuration config;

			[NonSerialized]
			public UILobbyCommunityChallengePage page;

			[NonSerialized]
			public bool animateMainPanel;

			[NonSerialized]
			public float mainPanelAnimTime;

			[NonSerialized]
			public float priceUpdTimer;

			[NonSerialized]
			public bool animatePrizePool;

			[NonSerialized]
			public float prizePoolAnimTime;

			[NonSerialized]
			public string xSignUpsStr;

			[NonSerialized]
			public string signUpsNeededToStartStr;

			[NonSerialized]
			public string signUpsDescStr;

			public void Build(Configuration config, UILobbyCommunityChallengePage page)
			{
			}

			public override void OpenPanel(bool instant = false)
			{
			}

			public override void ClosePanel(bool instant = false)
			{
			}

			public override void Localise(Translator translator)
			{
			}

			public void OnChallengeUpdated()
			{
			}

			public void UpdateStats()
			{
			}

			public override void Animate()
			{
			}

			public void AnimatePanelOpen(float nt)
			{
			}
		}

		[Serializable]
		public class PanelLives : ChallengePanel
		{
			[Serializable]
			public class Configuration
			{
				public string titleTranslationKey;

				public string descTranslationKey;

				public string yourReferralCodeTranslationKey;

				public string twitchUnlinkedTranslationKey;

				public string twitchLinkButtonTranslationKey;

				public string twitchLinkedToXTranslationKey;

				public float livesEntriesOpenDelay;

				public float livesEntriesScrollDuration;

				public AnimationCurve livesScrollLerpCurve;

				public float progressIconUnselectedAlpha;

				public int livesEntriesPerPanel;

				public UILobbyChallengeLivesEntry.Configuration earnLivesReferralsEntryConfig;

				public UILobbyChallengeLivesEntry.Configuration earnLivesTwitchEntryConfig;

				public UILobbyChallengeLivesEntry.Configuration earnLivesGamesEntryConfig;
			}

			[Serializable]
			public class EarnLivesPanel
			{
				public TMP_Text titleText;

				public Button prevButton;

				public Button nextButton;

				public RectTransform contentViewportTransform;

				public RectTransform contentScrollTransform;

				public Transform livesEntriesParent;

				public RectTransform progressHolder;

				public GameObject progressTemplate;

				[NonSerialized]
				public Image[] progressIcons;

				[NonSerialized]
				public Configuration config;

				[NonSerialized]
				public UILobbyChallengeLivesEntry.Configuration entryConfig;

				[NonSerialized]
				public UILobbyCommunityChallengePage page;

				[NonSerialized]
				public UILobbyChallengeLivesEntry.Pool earnLivesEntryPool;

				[NonSerialized]
				public List<UILobbyChallengeLivesEntry> earnLivesEntries;

				[NonSerialized]
				public int selectedIndex;

				[NonSerialized]
				public bool animateScroll;

				[NonSerialized]
				public float scrollAnimTime;

				[NonSerialized]
				public float scrollPrevPos;

				[NonSerialized]
				public float scrollTargetPos;

				[NonSerialized]
				public int dirtyFrame;

				public void Build(Configuration _config, UILobbyChallengeLivesEntry.Configuration _entryConfig, UILobbyCommunityChallengePage _page)
				{
				}

				public void UpdateData()
				{
				}

				public void Localise(Translator translator)
				{
				}

				public void Animate()
				{
				}

				public void OnCycleButtonPressed(bool next)
				{
				}

				public void SelectEntry(int selectedIndex, bool animate = true)
				{
				}

				public void MoveLivesScrollToEntryIndex(int entryIndex, bool animate = true)
				{
				}

				public float GetRewardsEntryLevelPosition(int index)
				{
					return 0f;
				}
			}

			public TMP_Text titleText;

			public TMP_Text descText;

			public Button inviteCodeCopyButton;

			public Transform inviteCodePopUpPoint;

			public TMP_Text yourReferralCodeText;

			public TMP_Text currentLivesText;

			public GameObject inviteCodeHolder;

			public TMP_Text inviteCodeText;

			public EarnLivesPanel livesReferrals;

			public EarnLivesPanel livesTwitch;

			public EarnLivesPanel livesGames;

			public GameObject twitchUnlinkedObj;

			public TMP_Text twitchUnlinkedText;

			public Button twitchLinkButton;

			public GameObject twitchLinkButtonSpinner;

			public TMP_Text twitchLinkButtonText;

			public GameObject twitchLinkedObj;

			public TMP_Text twitchLinkedText;

			public UIHoverTooltip twitchDropsHoverTooltip;

			public UIAlphaFade twitchDropsTooltipAlphaFade;

			public TMP_Text twitchDropsTooltipTitleText;

			public TMP_Text twitchDropsTooltipDescText;

			[NonSerialized]
			public Configuration config;

			[NonSerialized]
			public UILobbyCommunityChallengePage challengePage;

			[NonSerialized]
			public string twitchLinkedToStr;

			public void Build(Configuration _config, UILobbyCommunityChallengePage page)
			{
			}

			public void UpdateData(CommunityChallengeModel data)
			{
			}

			public override void Localise(Translator translator)
			{
			}

			public void SetTwitchEntryDays()
			{
			}

			public override void OpenPanel(bool instant = false)
			{
			}

			public override void Animate()
			{
			}
		}

		[Serializable]
		public class PanelPrizes : ChallengePanel
		{
			[Serializable]
			public class Configuration
			{
				public string titleTranslationKey;

				public string descTranslationKey;

				public string XPlaceTranslationKey;

				public string XPointsTranslationKey;

				public string participationTranslationKey;

				public string prizeEachTranslationKey;

				public UILobbyChallengePlaceRewardEntry.Configuration placeRewardEntryConfig;
			}

			public TMP_Text titleText;

			public TMP_Text descText;

			public UILobbyChallengePlaceRewardEntry place1Reward;

			public UILobbyChallengePlaceRewardEntry place2Reward;

			public UILobbyChallengePlaceRewardEntry place3Reward;

			public UILobbyChallengePlaceRewardEntry place4_50Reward;

			public UILobbyChallengePlaceRewardEntry points10Reward;

			public UILobbyChallengePlaceRewardEntry points5Reward;

			public UILobbyChallengePlaceRewardEntry points3Reward;

			public UILobbyChallengePlaceRewardEntry participationReward;

			[NonSerialized]
			public Configuration config;

			[NonSerialized]
			public string prizeXEachStr;

			public void Build(Configuration config, UILobbyCommunityChallengePage page)
			{
			}

			public override void Localise(Translator translator)
			{
			}

			public void UpdateStats(CommunityChallengeModel data)
			{
			}

			public override void OpenPanel(bool instant = false)
			{
			}
		}

		[Serializable]
		public class PanelHowToPlay : ChallengePanel
		{
			[Serializable]
			public class TutorialElement
			{
				public UIFadeDelayElement fade;

				public TMP_Text titleText;

				public TMP_Text descText;
			}

			[Serializable]
			public class Configuration
			{
				public string titleTranslationKey;

				public string descTranslationKey;

				public string tutorialLivesTitleTranslationKey;

				public string tutorialLivesDescTranslationKey;

				public string tutorialWinTitleTranslationKey;

				public string tutorialWinDescTranslationKey;

				public string tutorialLeaderboardTitleTranslationKey;

				public string tutorialLeaderboardDescTranslationKey;

				public float entryFadeDelay;
			}

			public TMP_Text titleText;

			public TMP_Text descText;

			public TutorialElement tutorialLives;

			public UIFadeDelayElement arrow1Fade;

			public TutorialElement tutorialWin;

			public UIFadeDelayElement arrow2Fade;

			public TutorialElement tutorialLeaderboard;

			[NonSerialized]
			public Configuration config;

			public void Build(Configuration config, UILobbyCommunityChallengePage page)
			{
			}

			public override void Localise(Translator translator)
			{
			}

			public override void OpenPanel(bool instant = false)
			{
			}
		}

		[Serializable]
		public class PanelFormat : ChallengePanel
		{
			[Serializable]
			public class FormatElement
			{
				public UIFadeDelayElement fade;

				public TMP_Text dayText;

				public TMP_Text titleText;

				public TMP_Text descText;

				public TMP_Text disclaimerText;
			}

			[Serializable]
			public class Configuration
			{
				public string titleTranslationKey;

				public string desc1TranslationKey;

				public string desc2TranslationKey;

				public string desc3TranslationKey;

				public string formatDayXTranslationKey;

				public string formatDay1TitleTranslationKey;

				public string formatDay1DescTranslationKey;

				public string formatDay1DisclaimerTranslationKey;

				public string formatDay2TitleTranslationKey;

				public string formatDay2DescTranslationKey;

				public string formatDay2DisclaimerTranslationKey;

				public string formatDay3TitleTranslationKey;

				public string formatDay3DescTranslationKey;

				public string formatDay3DisclaimerTranslationKey;

				public string formatDay4TitleTranslationKey;

				public string formatDay4DescTranslationKey;

				public string rulesTitleTranslationKey;

				public string rulesDescTranslationKey;

				public string rule1TranslationKey;

				public string rule2TranslationKey;

				public string rule3TranslationKey;

				public string rule4TranslationKey;

				public float entryFadeDelay;
			}

			public TMP_Text titleText;

			public TMP_Text descText;

			public FormatElement formatDay1;

			public FormatElement formatDay2;

			public FormatElement formatDay3;

			public FormatElement formatDay4;

			public UIFadeDelayElement rulesFade;

			public TMP_Text rulesTitleText;

			public TMP_Text rulesDescText;

			public TMP_Text rule1TitleText;

			public TMP_Text rule2TitleText;

			public TMP_Text rule3TitleText;

			public TMP_Text rule4TitleText;

			[NonSerialized]
			public Configuration config;

			public void Build(Configuration config, UILobbyCommunityChallengePage page)
			{
			}

			public override void Localise(Translator translator)
			{
			}

			public override void OpenPanel(bool instant = false)
			{
			}
		}

		[Serializable]
		public class PanelSignUp : ChallengePanel
		{
			[Serializable]
			public class Configuration
			{
				public string titleTranslationKey;

				public string signUpsTextTranslationKey;

				public string signUpsNeededToStartTranslationKey;

				public string scrollToTopTranslationKey;

				public string youAreSignedUpTranslationKey;

				public string signedUpInviteButtonTranslationKey;

				public string signUpTimeExpiredTranslationKey;

				[Header("Fade in anim")]
				public float openAnimDuration;

				public AnimationCurve signUpButtonAlphaCurve;

				public AnimationCurve signUpButtonPosCurve;

				public float signUpButtonPosOffset;

				public AnimationCurve signUpsAlphaCurve;

				public AnimationCurve signUpsPosCurve;

				public float signUpsPosOffset;

				public float signUpsBarAnimDuration;

				public AnimationCurve signUpsBarCurve;
			}

			public TMP_Text titleText;

			public CanvasGroup signUpsCanvasGroup;

			public RectTransform signUpsPosRect;

			public LayoutFitParentPercentage signUpsProgressBar;

			public TMP_Text signUpsText;

			public TMP_Text signUpsNeededToStartText;

			public CanvasGroup signUpButtonCanvasGroup;

			public RectTransform signUpButtonPosRect;

			public GameObject signUpButtonContainer;

			public Button signUpButton;

			public TMP_Text signUpButtonText;

			public GameObject signedUpInviteButtonContainer;

			public TMP_Text youAreSignedUpText;

			public Button signedUpInviteButton;

			public TMP_Text signedUpInviteButtonText;

			public TMP_Text inviteCodeButtonText;

			public TMP_Text signUpTimeExpired;

			public Button scrollToTopButton;

			public TMP_Text scrollToTopText;

			[NonSerialized]
			public Configuration config;

			[NonSerialized]
			public UILobbyCommunityChallengePage page;

			[NonSerialized]
			public bool animateMainPanel;

			[NonSerialized]
			public float mainPanelAnimTime;

			[NonSerialized]
			public bool animateSignUpsBar;

			[NonSerialized]
			public float signUpsBarAnimTime;

			[NonSerialized]
			public string titleStr;

			[NonSerialized]
			public string signUpsStr;

			[NonSerialized]
			public string signUpsNeededToStartStr;

			public void Build(Configuration config, UILobbyCommunityChallengePage page)
			{
			}

			public override void OpenPanel(bool instant = false)
			{
			}

			public override void Localise(Translator translator)
			{
			}

			public void UpdateStats()
			{
			}

			public override void Animate()
			{
			}

			public void AnimatePanelOpen(float nt)
			{
			}
		}

		[Serializable]
		public class SignUpWindow
		{
			public CanvasGroup canvasGroup;

			public UIAlphaFade uiAlphaFade;

			public UIPosLerpFade uiPosLerpFade;

			public TMP_Text headerText;

			public TMP_Text enterCodeText;

			public Button closeFillButton;

			public Button closeButton;

			public TMP_InputField codeInputField;

			public Button signUpButton;

			public TMP_Text signUpButtonText;

			public GameObject signUpButtonSpinner;
		}

		[Serializable]
		public class Configuration
		{
			public PanelMain.Configuration panelMainConfig;

			public PanelLives.Configuration panelLivesConfig;

			public PanelPrizes.Configuration panelPrizesConfig;

			public PanelHowToPlay.Configuration panelHowToPlayConfig;

			public PanelFormat.Configuration panelFormatConfig;

			public PanelSignUp.Configuration panelSignUpConfig;

			public UILobbyLiveSignUpFeedEntry.Configuration liveSignUpFeedEntryConfiguration;

			public string dateFormatStr;

			public string signUpWindowHeaderTranslationKey;

			public string signUpEnterCodeTranslationKey;

			public string loginTranslationKey;

			public string signUpTranslationKey;

			public string signedUpTranslationKey;

			public string inviteCodeCopiedTranslationKey;

			public string livesTooltipTitleTranslationKey;

			public string livesTooltipDescTranslationKey;

			public string twitchTooltipTitleTranslationKey;

			public string twitchTooltipDescTranslationKey;

			public Color tableOfContentEntryNormalColor;

			public Color tableOfContentEntrySelectedColor;

			public float tableOfContentEntryUnselectedHeight;

			public float tableOfContentEntrySelectedHeight;

			public SFXData pageFadeInSfx;
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
		public RectTransform panelOpenHeight;

		[SerializeField]
		public CustomScrollRect scrollRect;

		[SerializeField]
		public CanvasGroup contentCanvasGroup;

		[SerializeField]
		public PanelMain panelMain;

		[SerializeField]
		public PanelLives panelLives;

		[SerializeField]
		public PanelPrizes panelPrizes;

		[SerializeField]
		public PanelHowToPlay panelHowToPlay;

		[SerializeField]
		public PanelFormat panelFormat;

		[SerializeField]
		public PanelSignUp panelSignUp;

		[SerializeField]
		public CanvasGroup tableOfContentsCanvasGroup;

		[SerializeField]
		public UIAlphaFade tableOfContentsAlphaFade;

		[SerializeField]
		public UIAlphaFadeTimed pageLoader;

		[SerializeField]
		public SignUpWindow signUpWindow;

		[SerializeField]
		public UILobbyPlayTabPage.CurrencyPanel livesCurrencyPanel;

		[SerializeField]
		public UILobbyPopUpElement livesPanelPopUp;

		[SerializeField]
		public Button closeButton;

		[NonSerialized]
		public Configuration _configuration;

		[NonSerialized]
		public Translator _translator;

		[NonSerialized]
		public Actions _actions;

		[NonSerialized]
		public CommunityChallengeModel _data;

		[NonSerialized]
		public UILobbyLiveSignUpFeedEntry.Pool _liveSignUpFeedEntryPool;

		[NonSerialized]
		public ChallengePanel[] challengePanels;

		[NonSerialized]
		public int currentPanelId;

		[NonSerialized]
		public bool timeToSignUpEnabled;

		[NonSerialized]
		public float timeToSignUpTimer;

		[NonSerialized]
		public DateTime timeToSignUpDate;

		[NonSerialized]
		public int prevPrizePool;

		[NonSerialized]
		public int prizePool;

		[NonSerialized]
		public int numSignUps;

		[NonSerialized]
		public int numSignUpsNeeded;

		[NonSerialized]
		public float signUpsProgress;

		[NonSerialized]
		public int signUpRate;

		[NonSerialized]
		public bool isSignedUp;

		[NonSerialized]
		public string loginStr;

		[NonSerialized]
		public string signedUpStr;

		[NonSerialized]
		public string signUpStr;

		[NonSerialized]
		public string inviteCodeCopiedStr;

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

		public void Initialise(CommunityChallengeModel data)
		{
		}

		public void UpdateData(CommunityChallengeModel data)
		{
		}

		public void UpdateLivesData()
		{
		}

		public void OnSignUpSuccess()
		{
		}

		public void OnSignUpFail()
		{
		}

		public void OnChallengeStatsUpdated()
		{
		}

		public void UpdateChallengeStats()
		{
		}

		public void SpawnLiveSignUpFeedEntry(string username, int discriminator, int actionId, int value, string time)
		{
		}

		public void OnRedeemLiveSuccess(string listingId)
		{
		}

		public void OnSignUpButtonPressed()
		{
		}

		public void OnReferralCodeButtonPressed(Transform popUpPivot)
		{
		}

		public void SignUpWindowOpen()
		{
		}

		public void SignUpWindowClose()
		{
		}

		public void OnSignUpValidateReferral()
		{
		}

		public bool ValidateReferralCode()
		{
			return false;
		}

		public void OnWindowSignUpButton()
		{
		}

		public void SetSignUpWindowButtonLoader(bool isEnabled)
		{
		}

		public void SendChallengeRequest()
		{
		}

		public void OnOpenChallengePage()
		{
		}

		public void OpenPage()
		{
		}

		public void ClosePage()
		{
		}

		public void OnNextButtonPressed()
		{
		}

		public void OnPrevButtonPressed()
		{
		}

		public void ScrollToPanel(int panelId)
		{
		}

		public void UpdateCycleButtonsState()
		{
		}

		public void OnTwitchLinkButtonPressed()
		{
		}

		public void OnTwitchLinkingSuccess(string twitchUsername)
		{
		}

		public void OnContentTableEntryPressed(ChallengePanel panel)
		{
		}

		public void UpdateContentsTable()
		{
		}

		public static string GetPrizeFormatted(int amount)
		{
			return null;
		}

		public static string GetAmountFormatted(int amount)
		{
			return null;
		}

		public int GetLives()
		{
			return 0;
		}
	}
}
