using System;
using BAPBAP.Local;
using BAPBAP.Localisation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UILobbySplashScreen : MonoBehaviour
	{
		public class Actions
		{
			public Action ReconnectAction;

			public Action LogoutAction;

			public Action GoogleLoginAction;

			public Action FacebookLoginAction;

			public Action DiscordLoginAction;

			public Action SteamLoginAction;

			public Action GuestLoginAction;
		}

		[Serializable]
		public class LoginScreen
		{
			public CanvasGroup CanvasGroup;

			public UIAlphaFade AlphaFade;

			public UIAlphaFade PromptAlphaFade;

			public UIAlphaFade ProviderAlphaFade;

			public UIAlphaFade CancelAlphaFade;

			public Image PromptBackground;

			public Image MainProviderIcon;

			public Button GoogleButton;

			public Button FacebookButton;

			public Button DiscordButton;

			public Button SteamButton;

			public Button GuestButton;

			public Button CancelButton;

			public Toggle MuteButton;

			public UIToggleSpriteSwap MuteButtonSpriteSwap;

			public LoadingSpinner LoadingSpinner;

			public TMP_Text PromptText;

			public TMP_Text CancelText;

			public TMP_Text ContinueText;

			public TMP_Text ProvidersText;
		}

		[Serializable]
		public class LoadingMainScreen
		{
			public CanvasGroup CanvasGroup;

			public UIAlphaFade AlphaFade;

			public LoadingSpinner LoadingSpinner;
		}

		[Serializable]
		public class LoadingSimpleScreen
		{
			public CanvasGroup CanvasGroup;

			public UIAlphaFade AlphaFade;

			public TransformScaleAnimation loadingStarAnim;
		}

		[Serializable]
		public class LoadingSpinner
		{
			public CanvasGroup CanvasGroup;

			public UIAlphaFade AlphaFade;

			public TMP_Text LoadingStateText;

			public TransformScaleAnimation loadingStarAnim;
		}

		[Serializable]
		public class DisconnectedMessage
		{
			public GameObject gameObject;

			public UIPosLerpFade posLerp;

			public TMP_Text messageText;

			public TMProUGUIHyperlinks clickLinkHandler;
		}

		[Serializable]
		public class AlreadyLoggedInMessage
		{
			public GameObject gameObject;

			public UIPosLerpFade posLerp;

			public TMP_Text messageText;

			public TMProUGUIHyperlinks clickLinkHandler;
		}

		[Serializable]
		public class ServerErrorMessage
		{
			public GameObject gameObject;

			public UIPosLerpFade posLerp;

			public TMP_Text messageText;

			public TMProUGUIHyperlinks clickLinkHandler;
		}

		[Serializable]
		public class MatchFoundPanel
		{
			public UIAlphaFade UiAlphaFade;

			public float PreMatchFoundWarmupUptime;

			public float MatchFoundScreenUptime;
		}

		[Serializable]
		public class Configuration
		{
			public string loadingTranslationKey;

			public string loginPromptSelectTranslationKey;

			public string loginPromptRedirectTranslationKey;

			public string loginPromptProgressTranslationKey;

			public string loginPromptReturnTranslationKey;

			public string loginPromptIncompleteTranslationKey;

			public string loginPromptFailedTranslationKey;

			public string loginPromptSuccessTranslationKey;

			public string loginCancelButtonTranslationKey;

			public string loginContinuePromptTranslationKey;

			public string loginSteamUnavailableTranslationKey;

			public string loginLoggingInTranslationKey;

			public string loginOtherProvidersTranslationKey;

			public string loginPromptDuplicateConnectionKey;

			public string disconnectedMessageTranslationKey;

			public string alreadyLoggedInMessageTranslationKey;

			public string maintenanceMessageTranslationKey;

			public Color negativePromptColor;

			public Color positivePromptColor;
		}

		[SerializeField]
		public LoginScreen _loginScreen;

		[SerializeField]
		public LoadingSimpleScreen _loadingSimpleScreen;

		[SerializeField]
		public LoadingMainScreen _loadingMainScreen;

		[SerializeField]
		public DisconnectedMessage _disconnectedMessage;

		[SerializeField]
		public AlreadyLoggedInMessage _alreadyLoggedInMessage;

		[SerializeField]
		public AlreadyLoggedInMessage _serverErrorMessage;

		[SerializeField]
		public AlreadyLoggedInMessage _serverMaintenanceMessage;

		[SerializeField]
		public MatchFoundPanel _matchFoundPanel;

		[NonSerialized]
		public Configuration _configuration;

		[NonSerialized]
		public Translator _translator;

		[NonSerialized]
		public Actions _actions;

		[NonSerialized]
		public string _cachedSteamString;

		[NonSerialized]
		public string _loginPromptSelectString;

		[NonSerialized]
		public string _loginPromptRedirectString;

		[NonSerialized]
		public string _loginPromptProgressString;

		[NonSerialized]
		public string _loginPromptReturnString;

		[NonSerialized]
		public string _loginPromptIncompleteString;

		[NonSerialized]
		public string _loginPromptFailedString;

		[NonSerialized]
		public string _loginPromptSuccessString;

		[NonSerialized]
		public string _loginPromptDuplicateConnectionString;

		[NonSerialized]
		public string _loginPromptContinueWithSteamString;

		[NonSerialized]
		public string _loginPromptSteamUnavailableString;

		[NonSerialized]
		public string _loginActivelyLoggingInString;

		public bool LoginCancelled { get; set; }

		public void Build(Configuration configuration)
		{
		}

		public void SetActions(Actions actions)
		{
		}

		public void Initialize()
		{
		}

		public void Localise(Translator translator)
		{
		}

		public void ShowLogin(bool guestAvailable, bool steamAvailable)
		{
		}

		public void HideLogin()
		{
		}

		public void ShowLoginSpinner()
		{
		}

		public void HideLoginSpinner()
		{
		}

		public void ShowLoginProviders()
		{
		}

		public void HideLoginProviders()
		{
		}

		public void ShowSplashSpinner()
		{
		}

		public void HideSplashSpinner()
		{
		}

		public void ShowSplashScreen()
		{
		}

		public void HideSplashScreen()
		{
		}

		public void ShowLoadingSimpleScreen(bool fadeIn = false)
		{
		}

		public void HideLoadingSimpleScreen(float delay = 0f)
		{
		}

		public void SetLoginPromptSelectMessage()
		{
		}

		public void SetLoginPromptRedirectMessage(string provider)
		{
		}

		public void SetLoginPromptProgressMessage(string provider)
		{
		}

		public void SetLoginPromptReturnMessage(string provider)
		{
		}

		public void SetLoginPromptIncompleteMessage(string provider)
		{
		}

		public void SetLoginPromptFailedMessage(string provider)
		{
		}

		public void SetLoginPromptSuccessMessage(string provider)
		{
		}

		public void SetLoginPromptDuplicateConnectionMessage()
		{
		}

		public void ShowCancelButton()
		{
		}

		public void HideCancelButton()
		{
		}

		public void EnableSteamButton()
		{
		}

		public void DisableSteamButton(string disabledString)
		{
		}

		public void ShowDisconnectedMessage()
		{
		}

		public void HideDisconnectedMessage()
		{
		}

		public void ShowAlreadyLoggedInMessage()
		{
		}

		public void HideAlreadyLoggedInMessage()
		{
		}

		public void ShowServerErrorMessage()
		{
		}

		public void HideServerErrorMessage()
		{
		}

		public void ShowMaintenanceMessage()
		{
		}

		public void HideMaintenanceMessage()
		{
		}

		public void PlayMatchFoundSequence(Action onSequenceEndAction)
		{
		}

		public void OnCancelButtonPressed()
		{
		}
	}
}
