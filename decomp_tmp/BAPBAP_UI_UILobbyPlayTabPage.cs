using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BAPBAP.Content;
using BAPBAP.Local;
using BAPBAP.Localisation;
using BAPBAP.Steam;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BAPBAP.UI;

public class UILobbyPlayTabPage : UILobbyTabPage
{
	public class Actions
	{
		public Action<int> gameModeSelectAction;

		public Action<int, string> gameModeSelectWithPasswordAction;

		public Action<int> matchStartSelectCharAction;

		public Action<string, bool> joinLobbyAction;

		public Action<string> joinFriendLobbyAction;

		public Action readyAction;

		public Action unreadyAction;

		public Action cancelAction;

		public Action<string> sendChatMessageAction;

		public Action<string, string> sendWhisperAction;

		public Action inviteLinkAction;

		public Action copyUsernameIdAction;

		public Action<string, string> friendSendInviteLobbyAction;

		public Action<ulong> friendInviteSteamAction;

		public Action<string> friendRequestAcceptAction;

		public Action<string, int> friendSendRequestAction;

		public Action<string> friendRequestRejectAction;

		public Action<string> friendRemoveAction;

		public Action<string> kickTeammate;

		public Action<bool> sendOpenFriendRequests;

		public Action<bool> setClosedPartyAction;

		public Action<int> switchRegionAction;

		public Action openLoginWindowAction;

		public Action<string> completeLoginRequestAction;

		public Action dailyRewardRequestAction;
	}

	[Serializable]
	public class PlayerProfile
	{
		public TMP_Text levelText;

		public TransformScaleSimpleAnimation LevelTextAnim;

		public Image xpBarFill;

		public CanvasGroup BarFillAlpha;

		public CanvasGroup xpBarLevelUpAlpha;
	}

	[Serializable]
	public class DailyReward
	{
		public TMP_Text titleText;

		public TMP_Text refreshesText;

		public TMP_Text progressText;

		public TMP_Text dailyCompletedText;

		public Image progressBarDivider;

		public LayoutFitParentPercentage LevelProgressBar;

		public UIHoverTooltip tooltipHover;

		public UIAlphaFade tooltipAlphaFade;

		public TMP_Text tooltipDescText;
	}

	[Serializable]
	public class PlayerDisplay
	{
		public UILobbyPlayerContainer playerContainer;

		public GameObject playerDisplayObj;

		public CanvasGroup CanvasGroup;

		public TMP_Text ReadyText;

		public TMP_Text InQueueText;

		public OnPointerListener hoverButtonPointer;

		public EventTrigger eventTrigger;

		[NonSerialized]
		public string playerAccountId;
	}

	[Serializable]
	public class TeammateDisplay : PlayerDisplay
	{
		public InviteButton inviteButton;

		public TeammateLoader loader;
	}

	[Serializable]
	public class CharacterSelectPanelButton
	{
		public Button Button;

		public Image Highlight;
	}

	[Serializable]
	public class CharacterSelectButton
	{
		public Button Button;

		public TMP_Text Text;
	}

	[Serializable]
	public class InviteButton
	{
		public Transform transform;

		public CanvasGroup CanvasGroup;

		public Button Button;

		public UIAlphaFadeTimed alphaFadeTimed;

		public TMP_Text Text;
	}

	[Serializable]
	public class TeammateLoader
	{
		public CanvasGroup canvasGroup;

		public UIAlphaFade alphaFade;

		public RotateTransformZLoop animationScript;
	}

	[Serializable]
	public class ReadyButton
	{
		public GameObject Parent;

		public Button Button;

		public TMP_Text Text;
	}

	[Serializable]
	public class UnreadyButton
	{
		public GameObject Parent;

		public Button Button;

		public TMP_Text Text;
	}

	[Serializable]
	public class CancelButton
	{
		public GameObject Parent;

		public Button Button;

		public TMP_Text Text;
	}

	[Serializable]
	public class PlayersOnline
	{
		public CanvasGroup canvasGroup;

		public TMP_Text Text;

		public Image Icon;
	}

	[Serializable]
	public class CurrencyPanel
	{
		public TMP_Text Text;

		public UIHoverTooltip hoverTooltip;

		public UIAlphaFade tooltipAlphaFade;

		public TMP_Text tooltipTitleText;

		public TMP_Text tooltipDescText;
	}

	[Serializable]
	public class FriendsPanel
	{
		[Serializable]
		public class FriendsListTab
		{
			public GameObject gameObject;

			public Transform requestsParent;

			public Transform friendsParent;

			public CustomScrollRect friendsScrollRect;

			public TMP_Text noFriendsText;

			public UILobbyFriendHolderEntry onlineHolder;

			public UILobbyFriendHolderEntry offlineHolder;

			public UILobbyFriendHolderEntry steamOnlineHolder;

			public UILobbyFriendHolderEntry steamOfflineHolder;
		}

		[Serializable]
		public class AddFriendPanel
		{
			public CanvasGroup canvasGroup;

			public UIAlphaFade alphaFade;

			public UIPosLerpFade posLerpFade;

			public TMP_Text addFriendText;

			public TMP_InputField playerIdField;

			public Button sendRequestButton;
		}

		[Serializable]
		public class JoinLobbyPanel
		{
			public CanvasGroup canvasGroup;

			public UIAlphaFade alphaFade;

			public UIPosLerpFade posLerpFade;

			public TMP_InputField lobbyCodeField;

			public Button joinButton;
		}

		public CanvasGroup canvasGroup;

		public UIAlphaFade alphaFade;

		public UIPosLerpFade posLerpFade;

		public Button playerUsernameLinkButton;

		public TMP_Text playerUsernameId;

		public Image playerStateOnlineIcon;

		public TMP_Text playerStateText;

		public RawImage playerAvatarIcon;

		public AspectRatioFitter playerAvatarAspectRatio;

		public Button _hideLobbyCodeButton;

		public Button _leaveLobbyButton;

		public Button closeFillButton;

		public Button closeButton;

		public FriendsListTab friendsListTab;

		public AddFriendPanel addFriendPopup;

		public JoinLobbyPanel joinLobbyPopup;

		public GameObject guestLogInContainer;

		public TMP_Text guestLogInText;

		public Button guestLogInButton;

		public TMP_Text guestLogInButtonText;

		public MultiGraphicButton addFriendButton;

		public MultiGraphicButton joinLobbyButton;

		public Button addFriendCloseButton;

		public Button joinLobbyCloseButton;

		[NonSerialized]
		public Color[] addFriendButtonNormalColors;

		[NonSerialized]
		public Color[] joinLobbyButtonNormalColors;

		public TMP_Text lobbyIdText;

		public Button lobbyCodeLinkButton;
	}

	[Serializable]
	public class FriendsPreview
	{
		[Serializable]
		public class PreviewEntry
		{
			public GameObject gameObject;

			public RawImage rawImage;

			public AspectRatioFitter aspectRatio;
		}

		public GameObject gameObject;

		public RectTransform containerRect;

		public PreviewEntry[] previewEntries;

		public TMP_Text countText;
	}

	[Serializable]
	public class FriendInviteLobbyPopup
	{
		public CanvasGroup canvasGroup;

		public UIPosLerpFade posLerpFade;

		public TMP_Text invitationText;

		public Button joinButton;

		public Button dismissButton;
	}

	[Serializable]
	public class SteamInvitePanel
	{
		public CanvasGroup canvasGroup;

		public UIAlphaFade alphaFade;

		public UIPosLerpFade posLerpFade;

		public Transform transform;

		public TMP_Text lobbyIdText;

		public Transform steamFriendsParent;

		public Button closeFillButton;

		public Button closeButton;

		public Button linkButton;

		public TMP_InputField lobbyCodeField;

		public Button joinButton;
	}

	[Serializable]
	public class GameModePlayButton
	{
		public CanvasGroup canvasGroup;

		public Button button;

		public TMP_Text gameModeText;

		public TMP_Text nameText;

		public TMP_Text typeText;

		public Image illustrationImage;

		public GameObject eventHeaderObj;

		public TMP_Text eventText;

		public TMP_Text eventTimeText;
	}

	[Serializable]
	public class OpenBetaChallenge
	{
		[Serializable]
		public class ChallengeEventPanel
		{
			public GameObject panelObj;

			public TMP_Text prizePoolText;

			public LayoutFitParentPercentage progressBar;

			public TMP_Text XSignUpsOutOfYText;

			public Button seeMoreButton;

			public TMP_Text seeMoreButtonText;
		}

		[Serializable]
		public class GameModeChallengeEventHeader
		{
			public GameObject headerObj;

			public TMP_Text eventTitleText;

			public TMP_Text livesText;

			public TMP_Text livesHeaderText;
		}

		[Serializable]
		public class PlayDisclaimerPopUp
		{
			public CanvasGroup canvasGroup;

			public UIAlphaFade alphaFade;

			public UIPosLerpFade posLerpFade;

			public TMP_Text headerText;

			public TMP_Text disclaimerText;

			public TMP_Text disclaimerNoRefundsText;

			public Button fillCloseButton;

			public Button closeButton;

			public Button readyUpButton;

			public TMP_Text readyUpButtonText;
		}

		[Serializable]
		public class OutOfLivesPopUp
		{
			public CanvasGroup canvasGroup;

			public UIAlphaFade alphaFade;

			public UIPosLerpFade posLerpFade;

			public TMP_Text headerText;

			public TMP_Text outOfLivesText;

			public TMP_Text obtainMoreLivesText;

			public Button fillCloseButton;

			public Button closeButton;

			public Button getMoreLivesButton;

			public TMP_Text getMoreLivesButtonText;
		}

		public ChallengeEventPanel challengePanel;

		public GameModeChallengeEventHeader gameModeEventHeader;

		public PlayDisclaimerPopUp disclaimerPopUp;

		public OutOfLivesPopUp outOfLivesPopUp;

		public Button newsSignUpButton;

		public TMP_Text newsSignUpButtonText;
	}

	[Serializable]
	public class GameModePanel
	{
		public CanvasGroup canvasGroup;

		public UIAlphaFade alphaFade;

		public UIPosLerpFade posLerpFade;

		public UIAlphaFade buttonsAlphaFade;

		public UIPosLerpFade buttonsPosLerpFade;

		public Button closePageFillRaycastButton;

		public Button closePageButton;

		public Button gmNormalButton;

		public Button gmRankedButton;

		public Button gmWarmupButton;

		public Button howToPlayButton;

		public TMP_Text selectGameModeText;

		public Transform buttonParentTransform;
	}

	[Serializable]
	public class GameQueuePanel
	{
		public TMP_Text gameModeText;

		public TMP_Text queueStatusText;

		public TMP_Text playerCountText;

		public TMP_Text elapsedTimeText;

		public CanvasGroup canvasGroup;

		public GameObject progressIconSpin;
	}

	[Serializable]
	public class MatchStartPanel
	{
		[Serializable]
		public class MatchPlayer
		{
			public GameObject gameObject;

			public RectTransform nameTextRect;

			public TMP_Text playerNameText;

			public UILobbyPlayerContainer playerContainer;

			public TMP_Text charNameText;

			public Image charImage;

			public RectTransform charRectTransform;

			public GameObject ChangeAnimObj;

			public UIAlphaAnim ChangeAnimAlphaFade;

			public TransformScaleAnimation ChangeAnimTransformScale;
		}

		[Serializable]
		public class CharacterSelectPanelAnimation
		{
			public float Duration;

			public AnimationCurve PanelAlphaCurve;

			public AnimationCurve CharacterPositionCurve;

			public AnimationCurve CharacterAlphaCurve;

			public float CharNameYPosOffset;

			public AnimationCurve CharNameTextYPosCurve;

			public AnimationCurve CharNameTextAlphaCurve;

			public Vector2 CharacterPositionOffset;
		}

		public CanvasGroup canvasGroup;

		public UIAlphaFade uiAlphaFade;

		public Transform charButtonsParent;

		public Transform _chatParent;

		public MatchPlayer localPlayer;

		public MatchPlayer[] teammatePlayers;

		public TMP_Text matchStartingInText;

		public TMP_Text matchCountdownText;

		public TransformScaleSimpleAnimation matchCountdownTextTickAnim;
	}

	[Serializable]
	public class ReferralCode
	{
		public GameObject gameObject;

		public Button codeButton;

		public TMP_Text referalCodeText;

		public TMP_Text codeUsesText;
	}

	[Serializable]
	public class BattlePassPanel
	{
		public GameObject root;

		public TMP_Text BattlePassText;

		public TMP_Text EndsInRemainingDaysText;

		public Image LevelContainer;

		public TMP_Text LevelText;

		public TransformScaleSimpleAnimation LevelTextAnim;

		public TMP_Text LevelBarExpText;

		public RectTransform ProgressBarRect;

		public LayoutFitParentPercentage LevelProgressBar;

		public CanvasGroup BarFillAlpha;

		public CanvasGroup xpBarLevelUpAlpha;
	}

	[Serializable]
	public class NotificationsPanel
	{
		public Transform EntryParentTransform;
	}

	[Serializable]
	public class LiveWinnerFeed
	{
		public Transform EntryParentTransform;

		public TMP_Text LastWinnersText;
	}

	[Serializable]
	public class NewsPreviewButton
	{
		public Button Button;

		public Transform previewHolderParent;

		public Transform previewIconParent;

		public Image IconTemplate;

		public GameObject notificationObj;
	}

	[Serializable]
	public class Configuration
	{
		public GameModesConfiguration GameModesConfiguration;

		public UICharactersConfiguration CharacterConfiguration;

		public ContentConfiguration contentConfig;

		public PlayerBannerData playerBannerData;

		public View_Lobby_ReadyButton.Configuration readyButtonConfig;

		public string ReadyStatusTranslationKey;

		public string NotReadyStatusTranslationKey;

		public string InQueueStatusTranslationKey;

		public string QueueFindingPlayersTranslationKey;

		public string QueueGameStartingTranslationKey;

		public string InviteButtonTranslationKey;

		public string LobbyCodeTranslationKey;

		public string ReadyButtonTranslationKey;

		public string UnreadyButtonTranslationKey;

		public string CancelButtonTranslationKey;

		public string CharacterSelectButtonTranslationKey;

		public string PlayersOnlineTranslationKey;

		public string LinkCopiedPopUpTranslationKey;

		public string PlayerDisplayIsOnQueue;

		public string GameModeTranslationKey;

		public string BapPassNameText;

		public string PastWinnersTranslationKey;

		public string LevelTranslationKey;

		public string MaxLevelTranslationKey;

		public string GameModeEventStartsInStrTranslationKey;

		public string GameStartingInTranslationKey;

		public string ServersAreDownMessage;

		public string dailyRewardTranslationKey;

		public string dailyRewardTooltipDescTranslationKey;

		public string dailyRewardCompletedTranslationKey;

		public string dailyRewardRefreshesInTranslationKey;

		public string dailyRefreshDateFormatStr;

		public string goldCurrencyTooltipTitleTranslationKey;

		public string goldCurrencyTooltipDescTranslationKey;

		public string fractalCurrencyTooltipTitleTranslationKey;

		public string fractalCurrencyTooltipDescTranslationKey;

		public string onlineTranslationKey;

		public string offlineTranslationKey;

		public string steamOnlineTranslationKey;

		public string steamOfflineTranslationKey;

		public string inviteLobbyNotifTranslationKey;

		public string sentAGameInviteToTranslationKey;

		public string friendInviteSentToTranslationKey;

		public string friendInviteSentErrorTranslationKey;

		public string friendRequestAcceptedTranslationKey;

		public string usernameIdCopiedTranslationKey;

		public string friendJoinLobbyTranslationKey;

		public string leaveLobbyTranslationKey;

		public string friendInviteToGameTranslationKey;

		public string friendMessageFriendTranslationKey;

		public string friendViewProfileTranslationKey;

		public string friendUnfriendTranslationKey;

		public string areYouSureUnfriendTranslationKey;

		public string sendFriendRequestTranslationKey;

		public string playerKickTranslationKey;

		public string guestLogInTextTranslationKey;

		public string logInTextTranslationKey;

		public string noFriendsTranslationKey;

		public string noFriendRequestsTranslationKey;

		public string addFriendTranslationKey;

		public string closedPartyTranslationKey;

		public string lobbyCodeHiddenStr;

		public string closeTranslationKey;

		public Sprite optionJoinLobbyIcon;

		public Sprite optionInviteToGameIcon;

		public Sprite optionMessageFriendIcon;

		public Sprite optionViewProfileIcon;

		public Sprite optionUnfriendIcon;

		public Sprite optionSendFriendRequestIcon;

		public Sprite optionLeaveLobbyIcon;

		public Sprite optionPlayerKickIcon;

		public float TabSelectedAlpha;

		public float TabUnselectedAlpha;

		public string usernameIdDiscriminatorAlphaHex;

		public Color ReadyColour;

		public Color NotReadyColour;

		public Color InQueueColour;

		public Color LeaderIconColour;

		public Color PlayersOnlineIconColour;

		public Color friendOnlineColor;

		public Color friendOfflineColor;

		public SFXData friendInvitePopUp;

		public float playerInQueueDisplayAlpha;

		public float playButtonCooldownTime;

		public int minLevelForDefaultGmWarmup;

		public int GmWarmupId;

		public int lobbyCodeCharLength;

		public UILobbyCharacterSelectIcon.Configuration MatchStartCharacterSelectIconConfiguration;

		public MatchStartPanel.CharacterSelectPanelAnimation MatchStartCharacterSelectAnimation;

		public UILobbyFriendEntry.Configuration FriendEntryConfiguration;

		public UILobbyFriendRequestEntry.Configuration FriendRequestEntryConfiguration;

		public UILobbyNotificationEntry.Configuration NotificationEntryConfiguration;

		public UILobbyLiveWinnerFeedEntry.Configuration LiveWinnerFeedEntryConfiguration;

		public UILobbyFriendEntry friendEntryPrefab;

		public UILobbyFriendHolderEntry friendSeparatorEntryPrefab;

		public AudioManager.SFX playerJoinedLobbySfx;

		public float playerJoinedLobbySfxVolume;

		public AudioManager.SFX teamJoinedSfx;

		public float teamJoinedSfxVolume;

		public SFXData matchCountdownTickSfx;

		public SFXData matchCountdownLastTickSfx;

		public Color matchStartCountdownTextColor;

		public Color matchStartCountdownTextLastTicksColor;

		[Tooltip("Start Playing last tick fx from X seconds")]
		public int matchCountdownTickStartSeconds;

		public int matchCountdownLastTickStartSeconds;

		public int[] defaultPlayerBannerIds;

		[Header("Reward Sequence anim")]
		public float rewardSequenceTimeBetweenAnim;

		[Header("Battle Pass Xp Bar anim")]
		public float expBarLerpDuration;

		public AnimationCurve expBarLerpCurve;

		public float expBarLevelUpDuration;

		public AnimationCurve xpBarLevelUpAlphaCurve;

		public AnimationCurve xpBarLevelUpFillAlphaCurve;

		public AudioManager.SFX battlePassLevelUpSfx;

		public float battlePassLevelUpSfxVolume;

		[Header("Soft Currency anim")]
		public float currencyLerpDuration;

		public AnimationCurve softCurrencyLerpCurve;

		[Header("Daily Reward anim")]
		public float dailyRewardLerpDuration;

		public AnimationCurve dailyRewardLerpCurve;

		[Header("View Configs")]
		public View_Lobby_News.Configuration newsConfig;

		public View_Lobby_OpenLobbyToggle.Configuration lobbyStatusConfig;

		public View_Lobby_InviteCodePage.Configuration invitePageConfig;

		[Header("Community Challenge")]
		public string challengeSeeMoreButtonTranslationKey;

		public string challengeSignUpTranslationKey;

		public string challengeXSignUpsOutOfYTranslationKey;

		public string challengeEventTitleTranslationKey;

		public string challengeEventLivesTranslationKey;

		public string challengeDisclaimerHeaderTranslationKey;

		public string challengeDisclaimerTranslationKey;

		public string challengeDisclaimerNoRefundsTranslationKey;

		public string readyUpTranslationKey;

		public string outOfLivesHeaderTranslationKey;

		public string outOfLivesTranslationKey;

		public string outOfLivesObtainMoreTranslationKey;

		public string getMoreLivesButtonTranslationKey;
	}

	[CompilerGenerated]
	public sealed class <RedeemDeltaSequenceCoroutine>d__268 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[NonSerialized]
		public int <>1__state;

		[NonSerialized]
		public object <>2__current;

		public UILobbyPlayTabPage <>4__this;

		[NonSerialized]
		public float <timeBetweenAnims>5__2;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public <RedeemDeltaSequenceCoroutine>d__268(int <>1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
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
	[Header("Contents")]
	public CanvasGroup contentsCanvasGroup;

	[Header("Player Displays")]
	[SerializeField]
	public PlayerDisplay _playerDisplay;

	[SerializeField]
	public TeammateDisplay _teammate1Display;

	[SerializeField]
	public TeammateDisplay _teammate2Display;

	[SerializeField]
	[Header("Ready")]
	public GameObject _playContainer;

	[SerializeField]
	public View_Lobby_ReadyButton _newReadyButton;

	[SerializeField]
	public ReadyButton _readyButton;

	[SerializeField]
	public UnreadyButton _unreadyButton;

	[SerializeField]
	public CancelButton _cancelButton;

	[SerializeField]
	public TMP_Text playMaintenanceMessageText;

	[SerializeField]
	public TMP_Text betaServiceMessageText;

	[SerializeField]
	public GameQueuePanel _gameQueuePanel;

	[SerializeField]
	[Header("GameModes")]
	public GameModePlayButton _gameModePlayButton;

	[SerializeField]
	public CustomTMP_Dropdown _regionDropdown;

	[SerializeField]
	[Header("Match Start")]
	public MatchStartPanel _matchStartPanel;

	[SerializeField]
	[Header("Other")]
	public Transform _chatParent;

	[SerializeField]
	public DailyReward _dailyReward;

	[SerializeField]
	public Button profileButton;

	[SerializeField]
	public BattlePassPanel _battlePassPanel;

	[SerializeField]
	public UILobbyPopUpElement _battlePassXpPopUp;

	[SerializeField]
	public PlayersOnline _playersOnline;

	[SerializeField]
	public LiveWinnerFeed _liveWinnerFeedPanel;

	[SerializeField]
	[Header("External")]
	public NotificationsPanel _notificationsPanel;

	[SerializeField]
	public UILobbyPopUpElement _lobbyPopUp;

	[SerializeField]
	public UILobbyOptionDropdown _lobbyOptionDropdown;

	[SerializeField]
	[Header("Friends")]
	public FriendsPanel _friendsPanel;

	[SerializeField]
	public FriendInviteLobbyPopup _friendInviteLobbyPopup;

	[SerializeField]
	public Button _friendsButton;

	[SerializeField]
	public GameObject _friendsButtonNotification;

	[SerializeField]
	public TMP_Text _friendsButtonNotificationText;

	[SerializeField]
	public FriendsPreview _friendsPreview;

	[Space(10f)]
	[SerializeField]
	public CurrencyPanel _goldCurrencyPanel;

	[SerializeField]
	public CurrencyPanel _fractalCurrencyPanel;

	[SerializeField]
	public Button _fractalPurchaseButton;

	[SerializeField]
	public GameObject _fractalCurrencyPanelRoot;

	[SerializeField]
	public UILobbyPopUpElement _softCurrencyPopUp;

	[SerializeField]
	public UILobbyPopUpElement _fractalsCurrencyPopUp;

	[SerializeField]
	public UILobbyPopUpElement _charTokenCurrencyPopUp;

	[SerializeField]
	public UILobbyPopUpElement _profileXpPopUp;

	[SerializeField]
	public ReferralCode _referralCode;

	[Header("News Panel")]
	[SerializeField]
	public NewsPreviewButton newsPreviewButton;

	[Header("Open Beta Challenge")]
	[SerializeField]
	public OpenBetaChallenge openBetaChallenge;

	[Header("Custom Games")]
	[SerializeField]
	public UIAlphaFade _customGameBackground;

	[SerializeField]
	public List<GameObject> _elementsToDisableOnCustomGame;

	[NonSerialized]
	public Dictionary<GameObject, bool> _customGameElementActiveCache;

	public View_Lobby_News NewsPanel;

	public View_Lobby_Developer DeveloperPanel;

	public View_Lobby_OpenLobbyToggle LobbyOpenTogglePanel;

	public View_Lobby_CustomGame CustomGameLobby;

	public View_Lobby_InviteCodePage InviteCodePage;

	[NonSerialized]
	public UILobbyGameModePage gameModePage;

	[NonSerialized]
	public Configuration _configuration;

	[NonSerialized]
	public Translator _translator;

	[NonSerialized]
	public Actions _actions;

	[NonSerialized]
	public LobbyDataModel _lobbyDataModel;

	[NonSerialized]
	public TeammateDisplay[] _teammateDisplays;

	[NonSerialized]
	public UILobbyCharacterSelectIcon.Factory _characterSelectIconFactory;

	[NonSerialized]
	public UILobbyCharacterSelectIcon[] matchStartCharSelectButtons;

	[NonSerialized]
	public UILobbyCharacterSelectIcon matchStartSelectedCharacterIcon;

	[NonSerialized]
	public int matchStartSelectedCharIndex;

	[NonSerialized]
	public bool matchStartAnimateCharSelect;

	[NonSerialized]
	public float matchStartAnimTime;

	[NonSerialized]
	public UILobbyNotificationEntry.Pool _notificationEntryPool;

	[NonSerialized]
	public UILobbyLiveWinnerFeedEntry.Pool _liveWinnerFeedEntryPool;

	[NonSerialized]
	public UILobbyTabButton[] friendsPanelTabButtons;

	[NonSerialized]
	public UILobbyFriendEntry.Pool _friendEntryPool;

	[NonSerialized]
	public UILobbyFriendRequestEntry.Pool _friendRequestEntryPool;

	[NonSerialized]
	public List<UILobbyFriendEntry> activeFriendEntries;

	[NonSerialized]
	public List<UILobbyFriendRequestEntry> activeFriendRequestEntries;

	[NonSerialized]
	public Action friendInviteLobbyAction;

	[NonSerialized]
	public float playButtonCooldown;

	[NonSerialized]
	public UIAlphaFade[] newsPreviewElements;

	[NonSerialized]
	public Image[] newsPreviewIcons;

	[NonSerialized]
	public bool newsPreviewCycleAnimate;

	[NonSerialized]
	public float latestNewsButtonCycleTimer;

	[NonSerialized]
	public int latestNewsButtonCycleId;

	[NonSerialized]
	public DateTime dailyRewardRefreshDate;

	[NonSerialized]
	public bool dailyRewardCountdownEnabled;

	[NonSerialized]
	public float dailyRewardCountdownTimer;

	[NonSerialized]
	public bool animateDailyRewardProgress;

	[NonSerialized]
	public float dailyRewardAnimTime;

	[NonSerialized]
	public float lerpedDailyRewardProgress;

	[NonSerialized]
	public int currentDailyRewardProgress;

	[NonSerialized]
	public int prevCurrentDailyRewardProgress;

	[NonSerialized]
	public int dailyRewardProgressMax;

	[NonSerialized]
	public Coroutine redeemCoroutine;

	[NonSerialized]
	public int currentBpLevel;

	[NonSerialized]
	public int currentBpXp;

	[NonSerialized]
	public int currentBpXpNeeded;

	[NonSerialized]
	public int prevCurrentBpLevel;

	[NonSerialized]
	public int prevCurrentBpXp;

	[NonSerialized]
	public int maxBpLevel;

	[NonSerialized]
	public DateTime bpEndDate;

	[NonSerialized]
	public bool _animateBpXpBar;

	[NonSerialized]
	public float _animateBpXpBarTime;

	[NonSerialized]
	public int _animCurrentBpLevel;

	[NonSerialized]
	public float _animCurrentBpXp;

	[NonSerialized]
	public float _animCurrentBpXpNeeded;

	[NonSerialized]
	public float _lerpedCurrentBpXp;

	[NonSerialized]
	public int bpXpObtainedAmount;

	[NonSerialized]
	public bool queueBpXpObtain;

	[NonSerialized]
	public bool _animateBpXpBarLevelUp;

	[NonSerialized]
	public float _animateBpXpBarLevelUpTime;

	[NonSerialized]
	public int currentAccountLevel;

	[NonSerialized]
	public int currentAccountXp;

	[NonSerialized]
	public int currentAccountXpNeeded;

	[NonSerialized]
	public int prevCurrentAccountLevel;

	[NonSerialized]
	public int prevCurrentAccountXp;

	[NonSerialized]
	public int maxAccountLevel;

	[NonSerialized]
	public bool _animateAccountXpBar;

	[NonSerialized]
	public float _animateAccountXpBarTime;

	[NonSerialized]
	public int _animCurrentAccountLevel;

	[NonSerialized]
	public float _animCurrentAccountXp;

	[NonSerialized]
	public float _animCurrentAccountXpNeeded;

	[NonSerialized]
	public float _lerpedCurrentAccountXp;

	[NonSerialized]
	public int accountXpObtainedAmount;

	[NonSerialized]
	public bool queueAccountXpObtain;

	[NonSerialized]
	public bool _animateAccountXpBarLevelUp;

	[NonSerialized]
	public float _animateAccountXpBarLevelUpTime;

	[NonSerialized]
	public int softCurrency;

	[NonSerialized]
	public bool animateSoftCurrency;

	[NonSerialized]
	public float softCurrencyAnimTime;

	[NonSerialized]
	public int lerpedSoftCurrency;

	[NonSerialized]
	public bool queueGoldObtain;

	[NonSerialized]
	public int goldObtainedAmount;

	[NonSerialized]
	public int fractalsCurrency;

	[NonSerialized]
	public bool animateFractalsCurrency;

	[NonSerialized]
	public float fractalsCurrencyAnimTime;

	[NonSerialized]
	public int lerpedFractalsCurrency;

	[NonSerialized]
	public bool queueFractalsObtain;

	[NonSerialized]
	public int fractalsObtainedAmount;

	[NonSerialized]
	public int charTokenCurrency;

	[NonSerialized]
	public bool animateCharTokenCurrency;

	[NonSerialized]
	public float charTokenCurrencyAnimTime;

	[NonSerialized]
	public int lerpedCharTokenCurrency;

	[NonSerialized]
	public bool queueCharTokenObtain;

	[NonSerialized]
	public int charTokenObtainedAmount;

	[NonSerialized]
	public string _readyStatusString;

	[NonSerialized]
	public string _notReadyStatusString;

	[NonSerialized]
	public string _inQueueStatusString;

	[NonSerialized]
	public string _queueFindingPlayersStr;

	[NonSerialized]
	public string _queueGameStartingStr;

	[NonSerialized]
	public string _playersOnlineString;

	[NonSerialized]
	public string _linkCopiedPopUpString;

	[NonSerialized]
	public string usernameIdCopiedString;

	[NonSerialized]
	public string maxLevelStr;

	[NonSerialized]
	public string dailyRewardRefreshesInStr;

	[NonSerialized]
	public string gameModeEventStartsInStr;

	[NonSerialized]
	public string inviteLobbyNotifStr;

	[NonSerialized]
	public string onlineStr;

	[NonSerialized]
	public string offlineStr;

	[NonSerialized]
	public string steamOnlineStr;

	[NonSerialized]
	public string steamOfflineStr;

	[NonSerialized]
	public string sentAGameInviteToStr;

	[NonSerialized]
	public string friendInviteSentToStr;

	[NonSerialized]
	public string friendInviteSentErrorStr;

	[NonSerialized]
	public string friendRequestAcceptedStr;

	[NonSerialized]
	public string joinLobbyStr;

	[NonSerialized]
	public string leaveLobbyStr;

	[NonSerialized]
	public string inviteToGameStr;

	[NonSerialized]
	public string messageFriendStr;

	[NonSerialized]
	public string playerViewProfileStr;

	[NonSerialized]
	public string friendUnfriendStr;

	[NonSerialized]
	public string sendFriendRequestStr;

	[NonSerialized]
	public string playerLobbyKickStr;

	[NonSerialized]
	public string challengeXSignUpsOutOfYStr;

	[NonSerialized]
	public bool eventCountdownGmEnabled;

	[NonSerialized]
	public float eventCountdownGmTimer;

	[NonSerialized]
	public UILobbyGameModeButton eventCountdownGmButton;

	[NonSerialized]
	public bool hideLobbyCode;

	public const string FirstTimeTutorialPageKey = "FirstTimeTutorialPage";

	public const string LatestNewsTimestampKey = "LatestNewsTimestamp";

	public const string HideLobbyCodeKey = "HideLobbyCode";

	public override CanvasGroup CanvasGroup => null;

	public override Selectable CanvasGroupSelectable => null;

	public override UIPosLerpFade UILerpFade => null;

	public override UIAlphaFade UIAlphaFade => null;

	public override UIAlphaFade backgroundUIFade => null;

	public Button FractalPurchaseButton => null;

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

	public void Initialise(LobbyDataModel data)
	{
	}

	public override void OnPageOpen()
	{
	}

	public override void OnPageClose()
	{
	}

	public override void OnInputModeChanged(InputMode inputMode)
	{
	}

	public void FocusDefaultSelectable()
	{
	}

	public void UpdateData(LobbyDataModel data)
	{
	}

	public void UpdateFriendData(LobbyDataModel data, LobbyDataModel.Friend friend)
	{
	}

	public void AddNewFriendEntry(LobbyDataModel.Friend friend)
	{
	}

	public void UpdateFriendEntry(UILobbyFriendEntry entry, LobbyDataModel.Friend friend)
	{
	}

	public void RemoveFriendEntry(UILobbyFriendEntry friendEntry)
	{
	}

	public void UpdateFriendRequestsData(LobbyDataModel data)
	{
	}

	public void UpdateInviteLobbyNotification(string receiverAccountId, string senderAccountId, string lobbyId)
	{
	}

	public void UpdateFriendStatus(string accountId, int status)
	{
	}

	public void UpdateFriendAvatarId(string accountId, int avatarId)
	{
	}

	public void UpdateFriendLobbyOpen(string accountId, bool lobbyOpen)
	{
	}

	public void PlayFriendEntryFadeIn(string accountId)
	{
	}

	public void PlayFriendRequestEntryFadeIn(string accountId)
	{
	}

	public void SetPlayerCurrentStatus()
	{
	}

	public void UpdatePlayerFriendStatus(int statusId)
	{
	}

	public void SetOpenFriendRequests(bool isEnabled)
	{
	}

	public void SetClosedPartyRequests(bool isEnabled)
	{
	}

	public void SetTimeZoneMaintenanceMessage()
	{
	}

	public void OnLoginButtonPressed()
	{
	}

	public void OnExitLobby()
	{
	}

	public void SwitchRegion(int index)
	{
	}

	public void PopulateRegionDropdown()
	{
	}

	public void OnRegionDropdownChanged(int value)
	{
	}

	public void UpdateRegionUI(int regionId)
	{
	}

	public void SetLocalPlayerBanner(int bannerAssetId)
	{
	}

	public void UpdateLocalPlayerBanner(int bannerAssetId)
	{
	}

	public void PopulateTeammateDisplays(List<PlayerModel> teammates)
	{
	}

	public void PlayTeamJoinedSfx()
	{
	}

	public void UpdateLocalPlayerDisplay()
	{
	}

	public void UpdateGameModes(GameModeModel[] gameModes)
	{
	}

	public void UpdateReadyStatus(string accountId, bool isReady, bool isInQueue)
	{
	}

	public void UpdateDailyRewardData(LobbyDataModel.DailyReward dailyRewardData)
	{
	}

	public void OnSoftCurrencyChanged(int amount)
	{
	}

	public void OnFractalsCurrencyChanged(int amount)
	{
	}

	public void OnCharTokenCurrencyChanged(int amount)
	{
	}

	public void OnAccountXpChanged(int xpAmount)
	{
	}

	public void OnBattlePassXpChanged(int xpAmount)
	{
	}

	public void OnDailyRewardProgressChanged(int progress, int max)
	{
	}

	public void QueueCurrencyGoldObtain(int amount)
	{
	}

	public void QueueCurrencyFractalsObtain(int amount)
	{
	}

	public void QueueCurrencyCharTokensObtain(int amount)
	{
	}

	public void QueueAccountXpObtain(int xpAmount)
	{
	}

	public void QueueBattlePassXpObtain(int xpAmount)
	{
	}

	public void UpdateAccountPassData(LobbyDataModel _playTabData)
	{
	}

	public void UpdateBattlePassData(int maxLevel)
	{
	}

	public void UpdateGoldCurrency(int balance)
	{
	}

	public void UpdateFractalsCurrency(int balance)
	{
	}

	public void UpdateCharTokensCurrency(int balance)
	{
	}

	public void UpdateAccountPassXp()
	{
	}

	public void UpdateBapPassXp(BattlePassModel data)
	{
	}

	public void PlayerAccountBannerUpdate(string accountId)
	{
	}

	public void PlayerAccountLevelUpdate(string accountId)
	{
	}

	public void UpdatePlayersOnline(int players)
	{
	}

	public void ShowLobbyNotification(string message, UILobbyNotificationEntry.MessageType messageType)
	{
	}

	public void SpawnLiveWinnerFeedEntry(string usernames, int squadKills, DateTime time)
	{
	}

	public void ShowLiveWinnerFeed()
	{
	}

	public void HideLiveWinnerFeed()
	{
	}

	public void UpdateEventChallengeLives(int balance)
	{
	}

	public void UpdateEventPanel(int prizePool, int signUps, int maxSignUps)
	{
	}

	public void SetGoldCurrencyPanelUI(int balance)
	{
	}

	public void SetFractalsCurrencyPanelUI(int balance)
	{
	}

	public void SetCharTokenCurrencyPanelUI(int balance)
	{
	}

	public void SetCurrentBattlePassUI()
	{
	}

	public void SetCurrentBattlePassUIRemainingDays(string textStr, bool isEnabled)
	{
	}

	public void SetCurrentAccountPassUI()
	{
	}

	public void SetCurrentDailyRewardUI()
	{
	}

	public void ShowPopUpLinkCopied(Vector2 screenPos)
	{
	}

	public void ShowPopUp(Vector2 screenPos, string str)
	{
	}

	public void PlayRedeemDeltaSequenceCoroutine()
	{
	}

	[IteratorStateMachine(typeof(<RedeemDeltaSequenceCoroutine>d__268))]
	public IEnumerator RedeemDeltaSequenceCoroutine()
	{
		return null;
	}

	public void CheckForCustomLobby()
	{
	}

	public void OpenCustomLobbyWindow()
	{
	}

	public void CloseCustomLobbyWindow()
	{
	}

	public int GetCustomLobbyGameModeId()
	{
		return 0;
	}

	public int GetCurrentSoftCurrency()
	{
		return 0;
	}

	public int GetCurrentFractalsCurrency()
	{
		return 0;
	}

	public int GetCurrentTokenCurrency()
	{
		return 0;
	}

	public int GetCurrencyBalanceFromAssetId(int assetId)
	{
		return 0;
	}

	public int GetSelectedBannerAssetId()
	{
		return 0;
	}

	public bool IsPlayerBannerAssetIdEquiped(int bannerAssetId)
	{
		return false;
	}

	public int GetSelectedSkinAssetId(int charId)
	{
		return 0;
	}

	public bool IsSkinAssetIdEquipped(int charId, int skinAssetId)
	{
		return false;
	}

	public int GetAccountLevelXpNeeded(int level)
	{
		return 0;
	}

	public int GetCurrentAccountLevelXpNeeded(int level)
	{
		return 0;
	}

	public int GetAccountXp()
	{
		return 0;
	}

	public int GetPrevAccountXp()
	{
		return 0;
	}

	public int GetAccountPrevLevel()
	{
		return 0;
	}

	public int GetAccountLevel()
	{
		return 0;
	}

	public int GetAccountMaxLevel()
	{
		return 0;
	}

	public int GetBapPassXp()
	{
		return 0;
	}

	public int GetBapPassPrevXp()
	{
		return 0;
	}

	public int GetBapPassPreviousLevel()
	{
		return 0;
	}

	public int GetBapPassLevel()
	{
		return 0;
	}

	public int GetBapPassMaxLevel()
	{
		return 0;
	}

	public int GetDailyProgress()
	{
		return 0;
	}

	public int GetPrevDailyProgress()
	{
		return 0;
	}

	public int GetDailyProgressMax()
	{
		return 0;
	}

	public int GetAccountLevelFromXp(int xp)
	{
		return 0;
	}

	public bool IsUserGuest()
	{
		return false;
	}

	public bool PlayerOwnsAssetId(int assetId)
	{
		return false;
	}

	public void EnableInteractableContents()
	{
	}

	public void DisableInteractableContents()
	{
	}

	public void ClickNewReadyButton()
	{
	}

	public void ClickReadyButton()
	{
	}

	public void ClickUnreadyButton()
	{
	}

	public void ClickCancelButton()
	{
	}

	public void HidePlayButton()
	{
	}

	public void ShowPlayReadyButton()
	{
	}

	public void ShowPlayUnreadyButton()
	{
	}

	public void ShowPlayCancelButton()
	{
	}

	public void SetPlayButtonCooldown()
	{
	}

	public void OnPlayButtonCooldownEnded()
	{
	}

	public void ShowMaintenanceMessage()
	{
	}

	public void HideMaintenanceMessage()
	{
	}

	public void OnCommunityChallengeReadyButtonPressed()
	{
	}

	public void OpenChallengeEventWarningPopUp()
	{
	}

	public void CloseChallengeEventDisclaimerPopUp()
	{
	}

	public void OpenChallengeEventNoMoreLivesPopUp()
	{
	}

	public void CloseChallengeEventOutOfLivesPopUp()
	{
	}

	public void UpdateDailyRewardResfreshUI(TimeSpan timeSpan)
	{
	}

	public void OnDailyRewardRefreshEnded()
	{
	}

	public void ShowBattlePass()
	{
	}

	public void HideBattlePass()
	{
	}

	public void CloseMatchStartPanel()
	{
	}

	public void AnimateCharacterSelect(float t)
	{
	}

	public void SetAndShowPlayerDisplay(PlayerDisplay display, PlayerModel player)
	{
	}

	public void UpdatePlayerDisplayLevel(PlayerDisplay display, PlayerModel player)
	{
	}

	public void UpdatePlayerDisplayBanner(PlayerDisplay display, PlayerBanner banner)
	{
	}

	public void PlayPlayerCharJoinSfx()
	{
	}

	public void ShowPlayerReadys()
	{
	}

	public void HidePlayerReadys()
	{
	}

	public void SetPlayerCharDisplaySprite(Sprite charSprite)
	{
	}

	public void HideCharacterDisplay(PlayerDisplay display)
	{
	}

	public PlayerBanner GetDefaultPlayerBanner()
	{
		return null;
	}

	public PlayerBanner GetPlayerBannerFromAcountId(string accountId)
	{
		return null;
	}

	public void OpenPlayerOptionDropdown(RectTransform rectTransform)
	{
	}

	public void OpenTeammateOptionDropdown(string accountId, RectTransform rectTransform)
	{
	}

	public void OnTeammateOptionKick(string accountId)
	{
	}

	public void ShowInviteButton(InviteButton invite)
	{
	}

	public void HideInviteButton(InviteButton invite)
	{
	}

	public void ShowLoader(TeammateLoader loader)
	{
	}

	public void HideLoader(TeammateLoader loader)
	{
	}

	public void ShowGmPairingTeamSpinners()
	{
	}

	public void HideAllPairingTeamSpinners()
	{
	}

	public void HideAllInviteButton()
	{
	}

	public void OnInviteButtonPressed(InviteButton invite)
	{
	}

	public void OnFriendsButtonPressed()
	{
	}

	public void OnReferralCodeButtonPressed()
	{
	}

	public void SetInviteCodesRemainingUses(int usesLeft, int usesTotal)
	{
	}

	public void OpenOptionDropdown(Vector2 screenPos)
	{
	}

	public void CloseOptionDropdown()
	{
	}

	public void ShowFriendsPanel()
	{
	}

	public void CloseFriendsPanel()
	{
	}

	public void FriendsPanelSetGuestMode(bool isGuest)
	{
	}

	public void OnAddFriendPopupButton()
	{
	}

	public void OpenAddFriendPopup()
	{
	}

	public void CloseAddFriendPopup()
	{
	}

	public void OnJoinLobbyPopupButton()
	{
	}

	public void OpenJoinLobbyPopup()
	{
	}

	public void CloseJoinLobbyPopup()
	{
	}

	public void SetButtonSelectedState(MultiGraphicButton button, bool isSelected, Color[] normalColors)
	{
	}

	public void UpdateFriendsPreview()
	{
	}

	public void OpenFriendInviteNotification()
	{
	}

	public void CloseFriendInviteNotification()
	{
	}

	public void InitialiseFriendInviteNotification(string username, string lobbyCode)
	{
	}

	public void OnFriendInviteLobbyNotificationJoin(string lobbyCode)
	{
	}

	public void SendFriendInvite(string username, int discriminator)
	{
	}

	public void UpdateFriendLocalPlayerAvatar(int avatarId)
	{
	}

	public void SetHideLobbyCodeButton(bool _hideLobbyCode)
	{
	}

	public void SetLobbyIdCode(string lobbyId)
	{
	}

	public void SendFriendLobbyInvite(UILobbyFriendEntry entry)
	{
	}

	public void SendSteamFriendLobbyInvite(UILobbyFriendEntry entry, SteamManager.SteamFriend steamFriend)
	{
	}

	public void InitializeFriendsPanel()
	{
	}

	public void ClearFriendsPanel()
	{
	}

	public void PopulateFriendsPanel()
	{
	}

	public void PopulateSteamFriendsPanel()
	{
	}

	public List<UILobbyFriendEntry> GetFriendListEntries()
	{
		return null;
	}

	public void OnFriendEntrySelected(UILobbyFriendEntry friendEntry)
	{
	}

	public void OpenOptionDropdown(string accountId, RectTransform rectTransform)
	{
	}

	public void RefreshFriendOptionsDropdown(string accountId)
	{
	}

	public void OnFriendOptionJoinLobby(string accountId)
	{
	}

	public void OnFriendOptionInviteToGame(string accountId)
	{
	}

	public void OnFriendOptionDirectMessage(string accountId)
	{
	}

	public void OnFriendOptionUnfriend(string accountId)
	{
	}

	public void InitializeRequestsPanel()
	{
	}

	public void UpdateFriendRequestsNotification()
	{
	}

	public void UpdateFriendEntryHolders()
	{
	}

	public void OnSendFriendLobbyInvite(string username)
	{
	}

	public void OnSendFriendRequestSuccess(string usernameId)
	{
	}

	public void OnSendFriendRequestFail(string errorStr)
	{
	}

	public void OnFriendRequestAcceptSuccess(string accountId)
	{
	}

	public void OnFriendRequestDeclineSuccess(string accountId)
	{
	}

	public void TryRemoveFriendRequest(string accountId)
	{
	}

	public string GetUsernameId(string username, int discriminator)
	{
		return null;
	}

	public Texture2D GetFriendAvatar(int avatarId)
	{
		return null;
	}

	public Vector2 GetFriendAvatarOffset(int avatarId)
	{
		return default(Vector2);
	}

	public Vector2 GetFriendAvatarSize(int avatarId)
	{
		return default(Vector2);
	}

	public bool PlayerIsFriend(string accountId)
	{
		return false;
	}

	public void ShowGameModeButton()
	{
	}

	public void HideGameModeButton()
	{
	}

	public void SetSelectedGameMode()
	{
	}

	public void SetGameModeSelectButton(int gameModeId)
	{
	}

	public void GameModeSelectButtonEventEnable(UILobbyGameModeButton eventGmButton)
	{
	}

	public void GameModeSelectButtonEventDisable()
	{
	}

	public void SetGameModeSelectLoader(bool loaderEnabled)
	{
	}

	public void ShowQueuePanel()
	{
	}

	public void HideQueuePanel()
	{
	}

	public void SetQueuePanelPlayerCount()
	{
	}

	public void SetQueuePanelElapsedTime(double elapsedTime)
	{
	}

	public void SetQueueStateInQueue()
	{
	}

	public void SetQueueStateQueueMatched()
	{
	}

	public void SetQueueStateInQueueNoCounts()
	{
	}

	public void SetGameModePanelName()
	{
	}

	public void JoinLobbyVoiceChannel()
	{
	}
}
