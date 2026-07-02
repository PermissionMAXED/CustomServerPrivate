using System;
using BAPBAP.Localisation;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UILobby : MonoBehaviour
	{
		[SerializeField]
		public UILobbyConfiguration _lobbyConfiguration;

		[SerializeField]
		public LocalisationConfiguration _localisationConfiguration;

		[SerializeField]
		public UILobbySplashScreen _splashScreen;

		[SerializeField]
		public UILobbyTheme _uiLobbyTheme;

		[SerializeField]
		public View_Lobby_CustomGame _uiCustomLobby;

		[SerializeField]
		public CanvasGroup canvasGroup;

		[SerializeField]
		public UICompleteLoginWindow _uiCompleteLoginWindow;

		[SerializeField]
		public UIGameModePasswordWindow _uiGameModePasswordWindow;

		[NonSerialized]
		public UILobbyPlatformVariant _variant;

		public bool Initialized { get; set; }

		public bool DevLobby => false;

		public UILobbySplashScreen Splash => null;

		public UILobbyTabGroup Tabs => null;

		public UILobbyTheme Theme => null;

		public void Build()
		{
		}

		public void SetActions(UILobbySplashScreen.Actions splashActions, UILobbyPlayTabPage.Actions playTabActions, View_Lobby_Developer.Actions developerViewActions, View_Lobby_OpenLobbyToggle.Actions partyStatusViewActions, UILobbyBattlePassTabPage.Actions battlePassTabActions, UILobbyShopTabPage.Actions storeTabActions, UILobbyProfileTabPage.Actions profileTabActions, UILobbyRankingsTabPage.Actions rankingsTabActions, View_Career_Leaderboard.Actions leaderboardActions, UILobbyLockerTabPage.Actions lockerTabActions, UILobbyCharacterSelectPage.Actions characterSelectPageActions, UILobbyCharacterCustomizePage.Actions characterCustomizePageActions, UILobbyFractalsPurchasePage.Actions fractalsPurchasePageActions, UILobbyCommunityChallengePage.Actions communityChallengePageActions, UILobbyMatchCharacterSelectPage.Actions matchCharacterSelectPageActions, View_Lobby_CustomGame.Actions customLobbyActions, View_Lobby_InviteCodePage.Actions inviteCodePageActions)
		{
		}

		public void Initialise(ModelManager model)
		{
		}

		public void Localise(Translator translator)
		{
		}
	}
}
