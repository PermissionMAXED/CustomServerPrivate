using System;
using System.Collections;
using System.Collections.Generic;
using BAPBAP.Localisation;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.UI
{
	public class ControllerManager
	{
		[Serializable]
		public class Config
		{
			public CharSelectController.Config CharSelect;

			public LoginController.Config Login;

			public PingController.Config Ping;

			public RegionController.Config Region;
		}

		[NonSerialized]
		public readonly List<ControllerBase> _controllers;

		public ModelManager Model { get; }

		public UILobby View { get; }

		public HttpClient Http { get; }

		public WebSocketClient Ws { get; }

		public NetworkConfig NetworkConfig { get; }

		public BattlePassController BattlePass { get; }

		public CharSelectController CharSelect { get; }

		public ChatController Chat { get; }

		public CommunityChallengeController CommunityChallenge { get; }

		public DebugController Debug { get; }

		public FriendsController Friends { get; }

		public IapController Iap { get; }

		public ShopController Shop { get; }

		public LobbyController Lobby { get; }

		public LockerController Locker { get; }

		public LoginController Login { get; }

		public MatchmakingController Matchmaking { get; }

		public PingController Ping { get; }

		public ProfileController Profile { get; }

		public RankingsController Rankings { get; }

		public RegionController Region { get; }

		public SpawnSelectController SpawnSelect { get; }

		public CustomGameController CustomGames { get; }

		public ControllerManager(Config config, ModelManager modelManager, UILobby view, HttpClient httpClient, WebSocketClient webSocketClient, NetworkConfig networkConfig)
		{
		}

		public void AddController(ControllerBase controller)
		{
		}

		public void OnLocalise(Translator translator)
		{
		}

		public void OnLoginComplete(LoadResponse response)
		{
		}

		public void Dispose()
		{
		}

		public Coroutine StartCoroutine(IEnumerator routine)
		{
			return null;
		}

		public void StopCoroutine(IEnumerator routine)
		{
		}
	}
}
