using System;
using BAPBAP.Content;
using BAPBAP.Localisation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UILobbyGameSummaryPlayerStatsEntry : MonoBehaviour
	{
		[Serializable]
		public class Configuration
		{
			public string kdaTranslationKey;

			public string killsTranslationKey;

			public string deathsTranslationKey;

			public string assistsTranslationKey;

			public string dmgDealtTranslationKey;

			public string dmgTakenTranslationKey;

			public string friendRequestSentTranslationKey;
		}

		[SerializeField]
		[Header("Settings")]
		public Color baseTextColor;

		[SerializeField]
		public Color highlightTextColor;

		[SerializeField]
		public Color bgNormalColor;

		[SerializeField]
		public Color bgMvpColor;

		[SerializeField]
		[Header("Element References")]
		public CanvasGroup canvasGroup;

		[SerializeField]
		public UIPosLerpFade lerpFade;

		[SerializeField]
		public UIAlphaFade alphaFade;

		[SerializeField]
		public UIPosLerpFade charLerpFade;

		[SerializeField]
		public UIAlphaFade charAlphaFade;

		[SerializeField]
		public UIPosLerpFade playerBannerLerpFade;

		[SerializeField]
		public UIAlphaFade playerBannerAlphaFade;

		[SerializeField]
		public Button friendInviteButton;

		[SerializeField]
		public UILobbyPopUpElement friendInviteSentPopup;

		[SerializeField]
		[Header("UI References")]
		public Image bgImage;

		[SerializeField]
		public Image playerCharacterImage;

		[SerializeField]
		public TMP_Text playerNameText;

		[SerializeField]
		public GameObject mpvObj;

		[SerializeField]
		public UILobbyPlayerContainer playerContainer;

		[Header("Stats Header References")]
		[SerializeField]
		public TMP_Text headerKillsText;

		[SerializeField]
		public TMP_Text headerAssistsText;

		[SerializeField]
		public TMP_Text headerDamageDealtText;

		[Header("Stats References")]
		[SerializeField]
		public TMP_Text killsText;

		[SerializeField]
		public TMP_Text assistsText;

		[SerializeField]
		public TMP_Text damageDealtText;

		[NonSerialized]
		public Configuration _configuration;

		[NonSerialized]
		public Action friendInviteAction;

		[NonSerialized]
		public bool isElementEnabled;

		[NonSerialized]
		public float waitStartDelay;

		[NonSerialized]
		public float timeElapsed;

		public void Awake()
		{
		}

		public void Build(Configuration configuration)
		{
		}

		public void InitializePlayer(string playerName, PlayerBanner playerBanner, PlayerBannerData playerBannerData, Sprite charIcon, UICharactersConfiguration.SpriteTransformModifier transformModifier = null, Action friendInviteAction = null, bool showFriendInvite = false)
		{
		}

		public void Update()
		{
		}

		public void Localise(Translator translator)
		{
		}

		public void StartFadeIn(float delay = 0f)
		{
		}

		public void HideElement()
		{
		}

		public void DisableAndHideElement()
		{
		}

		public bool IsAnimating()
		{
			return false;
		}

		public void AdvanceToEnd()
		{
		}

		public void DoFadeIn()
		{
		}

		public void SetPlayerStatEnabled(bool isEnabled)
		{
		}

		public void OnFriendInviteButtonClick()
		{
		}

		public void SetUpPlayerStats(int kills, int deaths, int assists, int damageDealt, int damageTaken)
		{
		}

		public void SetUpPlayerMvp(bool isMvp)
		{
		}

		public void SetHighlight(bool isHighlighted)
		{
		}
	}
}
