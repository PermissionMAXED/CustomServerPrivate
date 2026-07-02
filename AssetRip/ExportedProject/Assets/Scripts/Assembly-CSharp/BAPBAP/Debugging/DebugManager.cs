using System;
using BAPBAP.Network;
using IngameDebugConsole;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.Debugging
{
	public class DebugManager : MonoBehaviour
	{
		public enum OperatorLevel
		{
			None = 0,
			Squad = 1,
			Admin = 2
		}

		[SerializeField]
		public BapLogConfig _bapLogsConfig;

		[SerializeField]
		public NetworkConfig _networkConfig;

		[NonSerialized]
		public DebugPerformanceManager perfManager;

		[SerializeField]
		public DebugLogManager debugLogManager;

		[NonSerialized]
		public DebugNetcodeManager netcodeManager;

		[NonSerialized]
		public DebugGameplayManager gameplayManager;

		[NonSerialized]
		public DebugCinematicManager cinematicManager;

		[SerializeField]
		public Canvas debugCanvas;

		[NonSerialized]
		public bool isOpen;

		[SerializeField]
		public GameObject debugConsole;

		[SerializeField]
		public Canvas graphCanvas;

		[SerializeField]
		public Text debugTogglesText;

		public OperatorLevel userOpLevel;

		[NonSerialized]
		public string opSquadPassword;

		[NonSerialized]
		public string opPassword;

		[NonSerialized]
		public bool addedCmds;

		[NonSerialized]
		public int keyCount;

		[NonSerialized]
		public bool showDebugToggles;

		[NonSerialized]
		public Canvas hpBarCanvas;

		public static DebugManager Instance;

		public void PreAwake()
		{
		}

		public void Start()
		{
		}

		public void SetBapLogLevel(BapLog.BapLogLevel logLevel)
		{
		}

		public void Update()
		{
		}

		public void LateUpdate()
		{
		}

		public void OpenWindowAndDisableInputs()
		{
		}

		public void CloseWindowAndEnableInputs()
		{
		}

		public void ParseChatCommand(string message)
		{
		}

		public void SetManagersEnabled(bool enabled)
		{
		}

		public void SetPlayerInputEnabled()
		{
		}

		public void SetPlayerInputDisabled()
		{
		}

		public void TrySetOpAccess(string inputPassword)
		{
		}

		public void OnOperatorChanged()
		{
		}

		public bool HasOpAccess(OperatorLevel level = OperatorLevel.Admin)
		{
			return false;
		}

		public void ToggleDebugToggles()
		{
		}
	}
}
