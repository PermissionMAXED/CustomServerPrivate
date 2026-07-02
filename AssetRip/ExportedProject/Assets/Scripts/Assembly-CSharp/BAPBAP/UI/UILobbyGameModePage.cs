using System;
using BAPBAP.Local;
using BAPBAP.Localisation;
using FMOD.Studio;
using FMODUnity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UILobbyGameModePage : UILobbyTabPage
	{
		[Serializable]
		public class Configuration
		{
			public GameModesConfiguration GameModesConfiguration;

			public SFXData openPageSfxData;

			public float gmButtonOpenDelay;

			public float gameModePanelShowDuration;

			public float gameModePanelHideDuration;

			public int[] defaultGmButtonGameModeIds;

			public int eventChallengeGmId;

			public Sprite howToPlayIllustration;

			public Sprite howToPlayIllustrationBg;

			public Sprite customGameIllustration;

			public Sprite customGameIllustrationBg;

			public string eventDateFormat;

			public string customGameTranslationKey;

			public string customGameHighlightBannerSymbol;

			public string howToPlayTranslationKey;

			public string howToPlayHighlightBannerSymbol;

			public string GameModeTranslationKey;

			public string GameModesTranslationKey;

			public int passwordCharacterLimit;

			public UILobbyGameModeButton.Configuration GameModeButtonConfiguration;

			public EventReference audioSnapshotEvent;
		}

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
		public CanvasGroup canvasGroup;

		[SerializeField]
		public UIAlphaFade alphaFade;

		[SerializeField]
		public UIPosLerpFade posLerpFade;

		[SerializeField]
		public Transform buttonParentTransform;

		[SerializeField]
		public UIAlphaFade buttonsAlphaFade;

		[SerializeField]
		public UIPosLerpFade buttonsPosLerpFade;

		[SerializeField]
		public TMP_Text selectGameModeText;

		[SerializeField]
		public Button closePageFillRaycastButton;

		[SerializeField]
		public Button closePageButton;

		[SerializeField]
		public UILobbyGameModeButton[] gmButtonSlots;

		[SerializeField]
		public UILobbyGameModeButton howToPlayButton;

		[SerializeField]
		public UILobbyGameModeButton customGameButton;

		[NonSerialized]
		public UIGameModePasswordWindow uiGameModePasswordWindow;

		[NonSerialized]
		public Configuration _configuration;

		[NonSerialized]
		public Translator _translator;

		[NonSerialized]
		public UILobbyPlayTabPage playTabPage;

		[NonSerialized]
		public UILobbyInfographicPage infographicPage;

		[NonSerialized]
		public int _selectedGameMode;

		[NonSerialized]
		public EventInstance _audioSnapshotInstance;

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

		public void UpdateGameModes(int selectedGameModeId, GameModeModel[] gameModes)
		{
		}

		public void UpdateEventChallengeLives(int balance)
		{
		}

		public void ShowGameModePanel()
		{
		}

		public void HideGameModePanel(bool instant = false)
		{
		}

		public void OnSubmitPassword(string arg0)
		{
		}

		public void OnSubmitPassword()
		{
		}

		public void OnCancelPassword()
		{
		}

		public void OpenPasswordWindow(GameModeModel gm)
		{
		}

		public void ClosePasswordWindow()
		{
		}

		public void VerifyPassword(bool correctPassword)
		{
		}

		public void TrySelectGameModeButton(GameModeModel gmModel)
		{
		}

		public void OnSelectGameModeButton(int id)
		{
		}

		public void OnHoverGameModeButton(int id)
		{
		}

		public void SetSelectedGameMode(int gameModeId)
		{
		}

		public void SelectGameModeButton(int selectedGameModeId)
		{
		}

		public void OpenHowToPlayPanel()
		{
		}

		public void OpenCustomGameLobby()
		{
		}
	}
}
