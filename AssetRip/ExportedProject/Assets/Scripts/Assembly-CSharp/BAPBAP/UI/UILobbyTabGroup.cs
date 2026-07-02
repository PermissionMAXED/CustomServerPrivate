using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BAPBAP.Local;
using BAPBAP.Localisation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UILobbyTabGroup : MonoBehaviour
	{
		public enum PageIndex
		{
			Play = 0,
			Characters = 1,
			Rankings = 2,
			Locker = 3,
			Shop = 4,
			Profile = 5
		}

		[Serializable]
		public class TabButton
		{
			public UILobbyTabButton tabButton;

			public Button button;

			public TMP_Text text;

			public GameObject notification;

			public UIAnchorWidthLerp selectBarLerp;
		}

		[Serializable]
		public class Configuration
		{
			public PageIndex DefaultPage;

			public string TwitterInviteLinkUrl;

			public string DiscordInviteLinkUrl;

			public string SteamInviteLinkUrl;

			public int usernameCharMinLength;

			public int usernameCharMaxLength;

			public string usernameInvalidChars;

			public string temrsLinkUrl;

			public string privacyPolicyLinkUrl;

			public ColorBlock linkUrlButtonPressedColors;

			[Header("Localisation Keys")]
			public string PlayButtonLocalisationKey;

			public string BattlePassButtonLocalisationKey;

			public string StoreButtonLocalisationKey;

			public string ProfileButtonLocalisationKey;

			public string RankingsButtonLocalisationKey;

			public string LockerButtonLocalisationKey;

			public string CharactersButtonLocalisationKey;

			public string LoginButtonTranslationKey;

			public string LoginCompleteWindowHeaderTranslationKey;

			public string EnterYourUsernameTranslationKey;

			public string AcceptTermsToggleTranslationKey;

			public string NeedAcceptTermsWarningTranslationKey;

			public string UsernameCharsWarningTranslationKey;

			public string UsernameProfanityWarningTranslationKey;

			public string UsernameDuplicateWarningTranslationKey;

			[Header("Colors")]
			public float TabSelectedAlpha;

			public float TabUnselectedAlpha;

			public float TabSelectedNotificationAlpha;

			public float TabUnselectedNotificationAlpha;

			public Color navButtonNormalColor;

			public Color navButtonPressedColor;

			[Header("Pages")]
			public UILobbyPlayTabPage.Configuration PlayTab;

			[Space(4f)]
			public UILobbyBattlePassTabPage.Configuration BattlePassTab;

			[Space(4f)]
			public UILobbyShopTabPage.Configuration ShopPage;

			[Space(4f)]
			public UILobbyProfileTabPage.Configuration ProfileTab;

			[Space(4f)]
			public UILobbyRankingsTabPage.Configuration RankingsTab;

			[Space(4f)]
			public UILobbyLockerTabPage.Configuration LockerTab;

			[Space(4f)]
			public UILobbyCharacterSelectPage.Configuration CharacterSelectPage;

			[Space(4f)]
			public UILobbyCharacterCustomizePage.Configuration CharacterCustomizationPage;

			[Space(4f)]
			public UILobbyRewardObtainedPage.Configuration RewardObtainedPage;

			[Space(4f)]
			public UILobbyPostGameSummaryPage.Configuration PostGameSummaryPage;

			[Space(4f)]
			public UILobbyGameModePage.Configuration GameModePage;

			[Space(4f)]
			public UILobbyInfographicPage.Configuration InfographicPage;

			[Space(4f)]
			public UILobbyCommunityChallengePage.Configuration CommunityChallengePage;

			[Space(4f)]
			public UILobbyFractalsPurchasePage.Configuration FractalsPurchasePage;

			[Space(4f)]
			public UILobbyMatchCharacterSelectPage.Configuration MatchCharacterSelectPage;
		}

		[CompilerGenerated]
		public sealed class _003CStartProfileButtonInteractCdCoroutine_003Ed__91 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public UILobbyTabGroup _003C_003E4__this;

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
			public _003CStartProfileButtonInteractCdCoroutine_003Ed__91(int _003C_003E1__state)
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

		[SerializeField]
		public CanvasGroup _canvasGroup;

		[SerializeField]
		public UIAlphaFade _alphaFade;

		[SerializeField]
		public CanvasGroup _navContentsCanvasGroup;

		[SerializeField]
		public TabButton _playButton;

		[SerializeField]
		public TabButton _battlePassButton;

		[SerializeField]
		public TabButton _shopButton;

		[SerializeField]
		public TabButton _profileButton;

		[SerializeField]
		public TabButton _rankingsButton;

		[SerializeField]
		public TabButton _lockerButton;

		[SerializeField]
		public TabButton _charactersButton;

		[SerializeField]
		public UILobbyPlayTabPage _playPage;

		[SerializeField]
		public UILobbyBattlePassTabPage _battlePassPage;

		[SerializeField]
		public UILobbyShopTabPage _shopPage;

		[SerializeField]
		public UILobbyProfileTabPage _profilePage;

		[SerializeField]
		public UILobbyRankingsTabPage _rankingsPage;

		[SerializeField]
		public UILobbyLockerTabPage _lockerPage;

		[SerializeField]
		public UILobbyCharacterSelectPage _charactersPage;

		[SerializeField]
		public UILobbyCharacterCustomizePage _characterCustomizePage;

		[SerializeField]
		public UILobbyMatchCharacterSelectPage _matchCharacterSelectPage;

		[SerializeField]
		public UILobbyRewardObtainedPage _rewardObtainedPage;

		[SerializeField]
		public UILobbyPostGameSummaryPage _endGameSummaryPage;

		[SerializeField]
		public UILobbyGameModePage _gameModePage;

		[SerializeField]
		public UILobbyInfographicPage _infographicPage;

		[SerializeField]
		public UILobbyCommunityChallengePage _communityChallengePage;

		[SerializeField]
		public UILobbyFractalsPurchasePage _fractalsPurchasePage;

		[SerializeField]
		public Button settingsButton;

		[SerializeField]
		public Toggle muteButton;

		[SerializeField]
		public UIToggleSpriteSwap muteButtonSpriteSwap;

		[SerializeField]
		public Toggle fullscreenToggleButton;

		[SerializeField]
		public Button socialsTwitterButton;

		[SerializeField]
		public GameObject socialsTwitterButtonNotif;

		[SerializeField]
		public Button socialsDiscordButton;

		[SerializeField]
		public GameObject socialsDiscordButtonNotif;

		[SerializeField]
		public Button socialsSteamButton;

		[SerializeField]
		public GameObject socialsSteamButtonNotif;

		[SerializeField]
		public Button loginButton;

		[SerializeField]
		public TMP_Text loginButtonText;

		[SerializeField]
		public UICompleteLoginWindow completeLogin;

		[SerializeField]
		public UIAlphaFade queueTimeAlphaFade;

		[SerializeField]
		public TextMeshProUGUI queueTimeText;

		[NonSerialized]
		public TabButton[] _buttons;

		[NonSerialized]
		public Configuration _configuration;

		[NonSerialized]
		public UILobbyTabPage[] _pages;

		[NonSerialized]
		public int selectedPage;

		[NonSerialized]
		public LobbyDataModel _lobbyDataModel;

		public UILobbyPlayTabPage PlayPage => null;

		public UILobbyShopTabPage ShopPage => null;

		public UILobbyProfileTabPage ProfilePage => null;

		public UILobbyRankingsTabPage RankingsPage => null;

		public UILobbyLockerTabPage LockerPage => null;

		public UILobbyCharacterSelectPage CharacterSelectPage => null;

		public UILobbyCharacterCustomizePage CharacterCustomizePage => null;

		public UILobbyRewardObtainedPage RewardObtainedPage => null;

		public UILobbyPostGameSummaryPage EndGameSummaryPage => null;

		public UILobbyGameModePage GameModePage => null;

		public UILobbyInfographicPage InfographicPage => null;

		public UILobbyFractalsPurchasePage FractalsPurchasePage => null;

		public UILobbyCommunityChallengePage CommunityChallengePage => null;

		public UILobbyMatchCharacterSelectPage MatchCharacterSelectPage => null;

		public void FixedUpdate()
		{
		}

		public void Build(Configuration configuration, Translator translator)
		{
		}

		public void Localise(Translator translator)
		{
		}

		public void LocaliseButtons(Translator translator)
		{
		}

		public void CompleteLoginWindowLocalise(Translator translator)
		{
		}

		public void Initialise(LobbyDataModel lobbyDataModel)
		{
		}

		public void MovePrevTab()
		{
		}

		public void MoveNextTab()
		{
		}

		public bool IsPageOpened(PageIndex pageIndex)
		{
			return false;
		}

		public bool IsPageOpened(UILobbyTabPage page)
		{
			return false;
		}

		public void SetPage(PageIndex pageIndex)
		{
		}

		public void OpenPage(UILobbyTabPage page)
		{
		}

		public void ClosePage(UILobbyTabPage page)
		{
		}

		public void OnInputModeChanged(InputMode inputMode)
		{
		}

		public static void LocaliseTabButton(TabButton button, Translator translator, string key)
		{
		}

		public void SetTabNotification(PageIndex page, bool isEnabled)
		{
		}

		public void StartProfileButtonInteractCd()
		{
		}

		[IteratorStateMachine(typeof(_003CStartProfileButtonInteractCdCoroutine_003Ed__91))]
		public IEnumerator StartProfileButtonInteractCdCoroutine()
		{
			return null;
		}

		public void OpenInterface()
		{
		}

		public void CloseInterface()
		{
		}

		public void OpenNavContents()
		{
		}

		public void CloseNavContents()
		{
		}

		public void SetInteractNavContents(bool isInteractable)
		{
		}

		public void CloseAllPagesAndOpenPlayTab()
		{
		}

		public void OnMuteButtonToggle(bool isOn)
		{
		}

		public void SetMuteButtonStateUI(bool isOn)
		{
		}

		public void OnSocialsTwitterButtonPressed()
		{
		}

		public void OnSocialsDiscordButtonPressed()
		{
		}

		public void OpenDiscordInviteLink()
		{
		}

		public void OnSocialsSteamButtonPressed()
		{
		}

		public void SetLoginButtonVisible(bool isVisible)
		{
		}

		public void ShowFractalPurchasePopup()
		{
		}

		public void ToggleQueueTimerVisible(bool toggle)
		{
		}

		public void SetQueueTimerText(string timeStr)
		{
		}

		public void CompleteLoginWindowOpen()
		{
		}

		public void CompleteLoginWindowClose()
		{
		}

		public void OnLoginCompleteButtonConfirm()
		{
		}

		public void SetConfirmButtonLoader(bool isLoading)
		{
		}

		public void ValidateLogin()
		{
		}

		public void OnValidateUsername()
		{
		}

		public void OnValidateTerms()
		{
		}

		public bool GetIsValidateUsername(out bool validUsernameLength, out bool containsProfanity)
		{
			validUsernameLength = default(bool);
			containsProfanity = default(bool);
			return false;
		}

		public bool GetIsValidatedTerms()
		{
			return false;
		}

		public void OnCompleteLoginSuccess()
		{
		}

		public void OnCompleteLoginFailed(string errorCode)
		{
		}
	}
}
