using System;
using System.Collections.Generic;
using BAPBAP.Network;
using Mirror;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UINetwork : MonoBehaviour
	{
		[NonSerialized]
		public GameNetworkManager _gameNetManager;

		public Canvas networkCanvas;

		public CanvasGroup networkCanvasGroup;

		public GraphicRaycaster networkGraphicRaycaster;

		[NonSerialized]
		public string _defaultSeverAddress;

		[NonSerialized]
		public int _defaultKcpPort;

		[NonSerialized]
		public int _defaultTcpPort;

		[NonSerialized]
		public int _defaultWsPort;

		[NonSerialized]
		public bool _defaultWsSecure;

		[NonSerialized]
		public List<string> _clientTransportOptions;

		[NonSerialized]
		public Transport _clientTransport;

		[NonSerialized]
		public float _defaultLatency;

		[NonSerialized]
		public float _defaultJitter;

		[NonSerialized]
		public float _defaultJitterSpeed;

		[NonSerialized]
		public float _defaultUnreliableLoss;

		[NonSerialized]
		public float _defaultUnreliableScramble;

		public Button hostTabButton;

		public Button clientTabButton;

		public Button serverTabButton;

		public Button debugTabButton;

		public GameObject hostGroup;

		public GameObject clientGroup;

		public GameObject serverGroup;

		public GameObject debugGroup;

		[NonSerialized]
		public Button[] _tabButtons;

		[NonSerialized]
		public GameObject[] _tabGroups;

		public Button hostStartButton;

		public InputField clientGameAuthField;

		public InputField clientPlayerNameField;

		public InputField clientIpField;

		public Dropdown clientTransportDropdown;

		public InputField clientPortField;

		public Toggle clientWsSecureToggle;

		public Button clientStartButton;

		public InputField serverIpField;

		public InputField serverKcpPortField;

		public InputField serverTcpPortField;

		public InputField serverWsPortField;

		public Toggle serverWsSecureToggle;

		public Button serverStartButton;

		public Toggle latencyToggle;

		public InputField latencyField;

		public InputField jitterField;

		public InputField jitterSpeedField;

		public InputField unreliableLossField;

		public InputField unreliableScrambleField;

		public int CachedTab
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public void Awake()
		{
		}

		public void StartHost()
		{
		}

		public void StartClient()
		{
		}

		public void StartServer()
		{
		}

		public void OverrideDefaultConfig(string address, int kcp, int tcp, int ws, bool wsSecure)
		{
		}

		public void ToggleVisibility(bool isVisible)
		{
		}

		public void OpenWindow()
		{
		}

		public void CloseWindow()
		{
		}
	}
}
