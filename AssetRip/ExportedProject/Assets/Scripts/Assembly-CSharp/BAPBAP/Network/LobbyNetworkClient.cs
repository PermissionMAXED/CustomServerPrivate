using System;
using BAPBAP.UI;
using UnityEngine;

namespace BAPBAP.Network
{
	public class LobbyNetworkClient : MonoBehaviour
	{
		[Serializable]
		public class Config
		{
			public bool LogHttp;

			public bool LogWebsocket;

			public bool LobbyEnabled;
		}

		[SerializeField]
		public ControllerManager.Config _controllerConfig;

		[SerializeField]
		public NetworkConfig _networkConfig;

		[SerializeField]
		public Config _config;

		[NonSerialized]
		public HttpClient _httpClient;

		[NonSerialized]
		public WebSocketClient _websocketClient;

		[NonSerialized]
		public ModelManager _model;

		[NonSerialized]
		public ControllerManager _controller;

		[NonSerialized]
		public UILobby _view;

		[NonSerialized]
		public bool lobbyEnabled;

		public ModelManager Model => null;

		public ControllerManager Controller => null;

		public void PreAwake()
		{
		}

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void OnApplicationQuit()
		{
		}

		public void SetViewActions(ControllerManager controller)
		{
		}
	}
}
