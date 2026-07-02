using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using BapCustomServerMelon;
using MelonLoader;
using MelonLoader.Preferences;
using Microsoft.CodeAnalysis;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: MelonInfo(typeof(CustomServerMod), "BAP Custom Server", "1.0.0", "Sonic0810", null)]
[assembly: TargetFramework(".NETCoreApp,Version=v6.0", FrameworkDisplayName = ".NET 6.0")]
[assembly: AssemblyCompany("BapCustomServerMelon")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0+23bf8fb0ff8388326f650cbdc824a67e6f61a786")]
[assembly: AssemblyProduct("BapCustomServerMelon")]
[assembly: AssemblyTitle("BapCustomServerMelon")]
[assembly: AssemblyVersion("1.0.0.0")]
namespace Microsoft.CodeAnalysis
{
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
	internal sealed class EmbeddedAttribute : Attribute
	{
	}
}
namespace System.Runtime.CompilerServices
{
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter, AllowMultiple = false, Inherited = false)]
	internal sealed class NullableAttribute : Attribute
	{
		public readonly byte[] NullableFlags;

		public NullableAttribute(byte P_0)
		{
			NullableFlags = new byte[1] { P_0 };
		}

		public NullableAttribute(byte[] P_0)
		{
			NullableFlags = P_0;
		}
	}
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method | AttributeTargets.Interface | AttributeTargets.Delegate, AllowMultiple = false, Inherited = false)]
	internal sealed class NullableContextAttribute : Attribute
	{
		public readonly byte Flag;

		public NullableContextAttribute(byte P_0)
		{
			Flag = P_0;
		}
	}
}
namespace BapCustomServerMelon
{
	public sealed class CustomServerMod : MelonMod
	{
		private sealed record BootstrapPayload(string Path, string Json);

		private sealed record AutoGuestLoginRequest(object Controller, string Reason);

		private readonly struct DisabledScope : IDisposable
		{
			private readonly bool _previous = GUI.enabled;

			public DisabledScope(bool disabled)
			{
				GUI.enabled = !disabled;
			}

			public void Dispose()
			{
				GUI.enabled = _previous;
			}
		}

		private const string IniFileName = "BapCustomServer.ini";

		private const string AppDataFolderName = "BAPBAPBATTLEROYALE";

		private const int DefaultServerPort = 5055;

		private const int DefaultLocalProxyPort = 5055;

		private const float PatchIntervalSeconds = 2f;

		private const float FastPatchIntervalSeconds = 0.05f;

		private const float FastPatchUntilTime = 180f;

		private const float BootstrapRepairIntervalSeconds = 1f;

		private const float AutoJoinIntervalSeconds = 1f;

		private const float DedicatedMatchWaitForPlayersSeconds = 120f;

		private const float DedicatedLateJoinSeconds = 120f;

		private const string DefaultSecretHeaderName = "X-BAP-Custom-Secret";

		private const string DefaultSecretValue = "local-custom-server";

		private const string AccountHeaderName = "X-BAP-AccountId";

		private const string UsernameHeaderName = "X-BAP-Username";

		private const string DiscriminatorHeaderName = "X-BAP-Discriminator";

		private static readonly string[] KnownLevelNames = new string[8] { "Map2_BazaarCity 3", "Map2_BazaarCity 3", "Map3_Lyceum", "Arena_Map2", "OpenBetaMap#J02_P_Boccato", "Map2_BazaarCity 3", "Map3_Lyceum", "Arena_Map2" };

		private static CustomServerMod? s_active;

		private MelonPreferences_Category _category;

		private MelonPreferences_Entry<string> _hostEntry;

		private MelonPreferences_Entry<int> _serverPortEntry;

		private MelonPreferences_Entry<bool> _httpsEntry;

		private MelonPreferences_Entry<bool> _localProxyEntry;

		private MelonPreferences_Entry<int> _localPortEntry;

		private MelonPreferences_Entry<bool> _statusChipEntry;

		private MelonPreferences_Entry<bool> _moddingOverlayEntry;

		private MelonPreferences_Entry<bool> _productionModeEntry;

		private MelonPreferences_Entry<string> _moddingOverlayTitleEntry;

		private MelonPreferences_Entry<bool> _allowDevPanelEntry;

		private MelonPreferences_Entry<bool> _forceOnMatchStartedEnabled;

		private MelonPreferences_Entry<bool> _netTuneEnabledEntry;

		private MelonPreferences_Entry<string> _moddingOverlaySubtitleEntry;

		private MelonPreferences_Entry<bool> _nativeUiEntry;

		private MelonPreferences_Entry<string> _accountIdEntry;

		private MelonPreferences_Entry<string> _usernameEntry;

		private MelonPreferences_Entry<bool> _autoGuestLoginEntry;

		private string _iniPath = "";

		private LocalReverseProxy? _proxy;

		private Rect _windowRect = new Rect(24f, 24f, 430f, 330f);

		private Rect _setupWindowRect = new Rect(0f, 0f, 500f, 270f);

		private bool _showWindow;

		private bool _identitySetupRequired;

		private bool _identitySetupLogged;

		private bool _nativeUiExpanded;

		private bool _uiEnabled = true;

		private bool _uiFailureLogged;

		private bool _nativeUiBuildFailed;

		private bool _initialized;

		private bool _patchesInstalled;

		private bool _gameModePatchesInstalled;

		private bool _joinDiagnosticsPatchesInstalled;

		private bool _loginControllerPatchesInstalled;

		private bool _analyticsPatchesInstalled;

		private bool _characterSelectPatchInstalled;

		private bool _characterSelectDiagnosticsLogged;

		private bool _lobbyControllerGuardPatchesInstalled;

		private bool _characterUnlockPatchesInstalled;

		private bool _openCharSummarySkipInstalled;

		private bool _uiCharsConfigPatchInstalled;

		private bool _lifecycleGuardPatchesInstalled;

		private static bool _quitGuardActive = true;

		private static float _quitGuardExpireTime = float.MaxValue;

		private bool _charConfigPreloadDone;

		private string _serverMatchmakingPolicy = "Both";

		private bool _allowMatchmaking = true;

		private bool _allowCustomMatch = true;

		private bool _serverPolicyFetched;

		private string _serverModdingOverlayTitle = "";

		private string _serverModdingOverlaySubtitle = "";

		private float _nextServerPolicyFetchAt;

		private float _nextUiPatchStatsLogAt;

		private bool _unityWebRequestHeaderPatchInstalled;

		private bool _unityWebRequestCallbackUrlPatchLogged;

		private bool _webServerEndpointPatchLogged;

		private bool _identitySetupProcessRelaunchQueued;

		private float _identitySetupProcessRelaunchAt;

		private string? _pendingSetupUsername;

		private float _nextPatchAt;

		private float _nextBootstrapRepairAt;

		private bool _setupGameFailureLogged;

		private bool _setupGameApplied;

		private bool _currentGameModeRebound;

		private bool _onMatchStartedForced;

		private bool _devPanelHidePatchInstalled;

		private bool _shopThrottleInstalled;

		private static double _lastShopRequestUtcSeconds;

		private float _lastModScanTime;

		private bool _addTeamsApplied;

		private bool _queueMatchedApplied;

		private float _nextAutoGuestScanAt;

		private string? _primedLoginSessionId;

		private int? _dedicatedHttpPort;

		private int? _dedicatedWsPort;

		private int? _dedicatedKcpPort;

		private int? _dedicatedTcpPort;

		private string? _autoJoinGameAuthId;

		private string _autoJoinHost = "127.0.0.1";

		private int? _autoJoinWsPort;

		private int? _autoJoinKcpPort;

		private int? _autoJoinTcpPort;

		private float? _autoEndAfterSeconds;

		private bool _dedicatedProcess;

		private bool _dedicatedNetworkStarted;

		private bool _uiNetworkStartAttempted;

		private bool _gameNetworkStartAttempted;

		private bool _autoJoinAttempted;

		private bool _bootstrapRepairComplete;

		private bool _dedicatedGameManagerConfigured;

		private bool _gameModeLevelNamesPatched;

		private bool _autoEndMatchObserved;

		private bool _autoEndInvoked;

		private float _autoEndMatchStartAt;

		private float _nextAutoJoinAt;

		private string _lastNetworkRepairStatus = "";

		private string _lastBootstrapRepairStatus = "";

		private readonly ConcurrentQueue<BootstrapPayload> _pendingBootstrapPayloads = new ConcurrentQueue<BootstrapPayload>();

		private readonly ConcurrentQueue<AutoGuestLoginRequest> _pendingAutoGuestLogins = new ConcurrentQueue<AutoGuestLoginRequest>();

		private readonly List<BootstrapPayload> _retryBootstrapPayloads = new List<BootstrapPayload>();

		private readonly HashSet<int> _autoGuestLoginControllers = new HashSet<int>();

		private bool _autoGuestLoginControllerScanLogged;

		private bool _autoGuestLobbyScanLogged;

		private bool _splashGuestLoginInvoked;

		private bool _splashGuestLoginScanLogged;

		private float _splashGuestLoginInvokedAt;

		private bool _autoplayEnabled;

		private int _autoplayState;

		private float _autoplayNextActionAt;

		private bool _autoplayInMatch;

		private bool _postLoginUiFallbackApplied;

		private bool _postLoginUiFallbackLogged;

		private bool _postLoginUiDiagnosticsLogged;

		private float _postLoginUiFallbackAt;

		private int _postLoginUiFallbackAttempts;

		private float _nextForceDismissSplashAt;

		private bool _sceneReloadScheduled;

		private float _sceneReloadAt;

		private object? _lastLoginController;

		private object? _lastLoadResponse;

		private TcpListener? _bootstrapListener;

		private CancellationTokenSource? _bootstrapListenerCts;

		private Task? _bootstrapListenerTask;

		private string _serverPortText = 5055.ToString();

		private string _localPortText = 5055.ToString();

		private string _setupUsernameText = "";

		private string _setupErrorText = "";

		private string _statusText = "Not initialized";

		private string _lastAppliedApiHost = "";

		private int _customServerRequestLogCount;

		private int _unityWebRequestLogCount;

		private GameObject? _nativeUiRoot;

		private GameObject? _nativeUiChip;

		private GameObject? _nativeModdingOverlay;

		private Text? _nativeModdingTitle;

		private Text? _nativeModdingSub;

		private GameObject? _nativeUiPanel;

		private GameObject? _nativeSetupPanel;

		private bool _nativeUiAttachedToGameCanvas;

		private Text? _nativeChipText;

		private Text? _nativeStatusText;

		private Text? _nativeEndpointText;

		private Text? _nativeSetupStatusText;

		private RectTransform? _nativeChipRect;

		private RectTransform? _nativeSetupContinueRect;

		private RectTransform? _nativeApplyRect;

		private RectTransform? _nativeCloseRect;

		private RectTransform? _nativeDirectRect;

		private RectTransform? _nativeProxyRect;

		private RectTransform? _nativeHttpsRect;

		private RectTransform? _nativeProxyToggleRect;

		private RectTransform? _nativeStatusToggleRect;

		private GameObject? _nativeHttpsCheck;

		private GameObject? _nativeProxyCheck;

		private GameObject? _nativeStatusCheck;

		private InputField? _nativeHostInput;

		private InputField? _nativeServerPortInput;

		private InputField? _nativeLocalPortInput;

		private InputField? _nativeSetupNameInput;

		private float _nextNativeUiRefreshAt;

		private GameObject? _uguiOverlayRoot;

		private object? _uguiOverlayTmpText;

		private bool _uguiOverlayInstalled;

		private bool _uguiOverlayFailed;

		private static int _onGuiCallCount;

		private static readonly Rect ModOkGuiRect = new Rect(8f, 28f, 200f, 22f);

		private bool _charConfigViaUiManagerLogged;

		private bool _charConfigDiagLogged;

		private static bool _populateCharIdsDiagLogged;

		private static int _ensureLobbyCharIdsCallCount;

		private static int _ensureLobbyCharIdsFilledCount;

		private static bool _populateCharIdsPrefixLogged;

		private bool _forcePortFieldsDumped;

		private bool _serverConfigForcePatched;

		private int _rebindAttemptCount;

		private string _lastRebindStateLogged = "";

		private bool _spawnPointsCopied;

		private bool _duplicatesGameModesDestroyed;

		private int _forceMatchStartAttemptCount;

		private int _devPanelAttemptCount;

		private List<Type> _devPanelTypesPatched = new List<Type>();

		private bool _lockerCrashGuardInstalled;

		private bool _networkTuningApplied;

		private bool _networkTunerPatchInstalled;

		private int _networkTuneAttemptCount;

		private bool _networkTunerHarmonyInstalled;

		private bool _networkTunerLoggedAttempt;

		private bool _interpDisablePatchInstalled;

		private int _interpScanAttempts;

		private bool _crateRespawnDisabled;

		private int _crateScanAttemptCount;

		private bool _matchFoundDedupPatchInstalled;

		private static double _lastMatchFoundPlayedUtcSeconds;

		private bool _augmentTimerExtended;

		private int _augmentScanAttemptCount;

		public override void OnEarlyInitializeMelon()
		{
			InitializeCore("early");
			try
			{
				MelonCoroutines.Start(EarlyLobbyUiPatchLoop());
			}
			catch (Exception ex)
			{
				((MelonBase)this).LoggerInstance.Warning("Could not start EarlyLobbyUiPatchLoop: " + ex.GetBaseException().Message);
			}
		}

		private IEnumerator EarlyLobbyUiPatchLoop()
		{
			int attempts = 0;
			while (attempts < 3600 && (!_charConfigPreloadDone || !_uiCharsConfigPatchInstalled || !_characterSelectPatchInstalled))
			{
				attempts++;
				try
				{
					TryInstallCharacterSelectNullRefPatch();
				}
				catch
				{
				}
				yield return null;
			}
			((MelonBase)this).LoggerInstance.Msg($"[EarlyLobbyUiPatchLoop] exited after {attempts} frames. preloadDone={_charConfigPreloadDone} uiPatch={_uiCharsConfigPatchInstalled} charPatch={_characterSelectPatchInstalled}");
		}

		public override void OnInitializeMelon()
		{
			InitializeCore("normal");
		}

		private void InitializeCore(string phase)
		{
			if (!_initialized)
			{
				_initialized = true;
				s_active = this;
				AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
				_category = MelonPreferences.CreateCategory("BapCustomServer", "BAP Custom Server");
				_hostEntry = _category.CreateEntry<string>("Host", "127.0.0.1", "Server Host", (string)null, false, false, (ValueValidator)null, (string)null);
				_serverPortEntry = _category.CreateEntry<int>("ServerPort", 5055, "Server Port", (string)null, false, false, (ValueValidator)null, (string)null);
				_httpsEntry = _category.CreateEntry<bool>("UseHttps", false, "Use HTTPS", (string)null, false, false, (ValueValidator)null, (string)null);
				_localProxyEntry = _category.CreateEntry<bool>("UseLocalProxy", true, "Use Local Proxy", (string)null, false, false, (ValueValidator)null, (string)null);
				_localPortEntry = _category.CreateEntry<int>("LocalProxyPort", 5055, "Local Proxy Port", (string)null, false, false, (ValueValidator)null, (string)null);
				_statusChipEntry = _category.CreateEntry<bool>("ShowStatusChip", false, "Show Status Chip", (string)null, false, false, (ValueValidator)null, (string)null);
				_moddingOverlayEntry = _category.CreateEntry<bool>("ShowModdingOverlay", false, "Show BAPBAP Modding overlay (bottom center)", (string)null, false, false, (ValueValidator)null, (string)null);
				_moddingOverlayTitleEntry = _category.CreateEntry<string>("ModdingOverlayTitle", "BAPBAP Modding", "Modding Overlay Title", (string)null, false, false, (ValueValidator)null, (string)null);
				_productionModeEntry = _category.CreateEntry<bool>("ProductionMode", true, "Production mode: hide all mod overlays/labels (default ON)", (string)null, false, false, (ValueValidator)null, (string)null);
				_allowDevPanelEntry = _category.CreateEntry<bool>("AllowDevPanel", false, "Allow Dev/Debug Panel in match", (string)null, false, false, (ValueValidator)null, (string)null);
				_forceOnMatchStartedEnabled = _category.CreateEntry<bool>("ForceOnMatchStarted", false, "Force gameMode.OnMatchStarted/OnMatchBegin (default off; natural lifecycle now works)", (string)null, false, false, (ValueValidator)null, (string)null);
				_netTuneEnabledEntry = _category.CreateEntry<bool>("NetTuneEnabled", true, "Apply Mirror snapshotSettings + sendRate + KCP NoDelay tuning (default ON; set false to disable)", (string)null, false, false, (ValueValidator)null, (string)null);
				_moddingOverlaySubtitleEntry = _category.CreateEntry<string>("ModdingOverlaySubtitle", "discord.gg/bapbapmods", "Modding Overlay Subtitle", (string)null, false, false, (ValueValidator)null, (string)null);
				_nativeUiEntry = _category.CreateEntry<bool>("UseNativeGameUi", true, "Use Native Game UI", (string)null, false, false, (ValueValidator)null, (string)null);
				_accountIdEntry = _category.CreateEntry<string>("AccountId", "", "Custom Server Account ID", (string)null, false, false, (ValueValidator)null, (string)null);
				_usernameEntry = _category.CreateEntry<string>("Username", "", "Custom Server Username", (string)null, false, false, (ValueValidator)null, (string)null);
				_autoGuestLoginEntry = _category.CreateEntry<bool>("AutoGuestLogin", true, "Automatically enter the custom-server lobby with a local guest identity", (string)null, false, false, (ValueValidator)null, (string)null);
				string[] commandLineArgs = Environment.GetCommandLineArgs();
				_iniPath = ResolveIniPath(commandLineArgs);
				LoadIniSettings();
				ApplyCommandLineOverrides(commandLineArgs);
				UpdateIdentitySetupRequirement("startup configuration");
				CompletePendingIdentitySetupFromCommandLine();
				PrimeCustomServerLoginPrefs();
				_serverPortText = _serverPortEntry.Value.ToString();
				_localPortText = _localPortEntry.Value.ToString();
				TryInstallNetworkConfigPatches();
				TryInstallLifecycleGuardPatches();
				TryInstallAnalyticsPatches();
				TryInstallCharacterSelectNullRefPatch();
				TryInstallLobbyControllerGuardPatches();
				TryInstallCharacterUnlockPatches();
				TryFetchServerPolicy();
				ApplySettings(restartProxy: true, save: false);
				((MelonBase)this).LoggerInstance.Msg("Initialized during " + phase + " registration.");
			}
		}

		public override void OnApplicationQuit()
		{
			StopManagedBootstrapListener();
			StopProxy();
			DestroyNativeGameUi();
			AppDomain.CurrentDomain.ProcessExit -= OnProcessExit;
			s_active = null;
		}

		public override void OnSceneWasLoaded(int buildIndex, string sceneName)
		{
			((MelonBase)this).LoggerInstance.Msg($"[SceneLoaded] Scene '{sceneName}' (index {buildIndex}) loaded.");
			if (sceneName != null && (sceneName.Contains("Main", StringComparison.OrdinalIgnoreCase) || sceneName.Contains("Lobby", StringComparison.OrdinalIgnoreCase) || sceneName.Contains("Menu", StringComparison.OrdinalIgnoreCase)))
			{
				((MelonBase)this).LoggerInstance.Msg("[StateReset] Resetting match flags on lobby/menu scene '" + sceneName + "'");
				_currentGameModeRebound = false;
				_duplicatesGameModesDestroyed = false;
				_onMatchStartedForced = false;
				_crateRespawnDisabled = false;
				_augmentTimerExtended = false;
				_spawnPointsCopied = false;
				_setupGameApplied = false;
				_addTeamsApplied = false;
				_queueMatchedApplied = false;
				_interpDisablePatchInstalled = false;
			}
		}

		private void OnProcessExit(object? sender, EventArgs args)
		{
			StopManagedBootstrapListener();
			StopProxy();
		}

		public override void OnUpdate()
		{
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			DrainBootstrapPayloads();
			DrainAutoGuestLoginRequests();
			if (_uiEnabled && Input.GetKeyDown((KeyCode)288))
			{
				MelonPreferences_Entry<bool> productionModeEntry = _productionModeEntry;
				if (productionModeEntry == null || !productionModeEntry.Value)
				{
					ToggleUiPanel();
				}
			}
			CaptureIdentitySetupKeyboardInput();
			ProcessIdentitySetupProcessRelaunch();
			if (_uiEnabled && !_dedicatedProcess && !Application.isBatchMode)
			{
				MelonPreferences_Entry<bool> nativeUiEntry = _nativeUiEntry;
				if ((nativeUiEntry != null && nativeUiEntry.Value) || _identitySetupRequired)
				{
					EnsureNativeGameUi();
					if ((Object)(object)_nativeUiRoot != (Object)null && Time.realtimeSinceStartup >= _nextNativeUiRefreshAt)
					{
						_nextNativeUiRefreshAt = Time.realtimeSinceStartup + 0.5f;
						RefreshNativeGameUi(syncInputs: false);
					}
					if ((Object)(object)_nativeUiRoot != (Object)null && Input.GetMouseButtonDown(0))
					{
						HandleNativeUiPointer(Input.mousePosition);
					}
				}
			}
			bool flag = false;
			if (Time.realtimeSinceStartup - _lastModScanTime >= 2f)
			{
				_lastModScanTime = Time.realtimeSinceStartup;
				flag = true;
			}
			if (flag)
			{
				if (!_currentGameModeRebound)
				{
					try
					{
						TryRebindCurrentGameModeToPopulatedInstance();
					}
					catch
					{
					}
				}
				if (_currentGameModeRebound && !_onMatchStartedForced)
				{
					try
					{
						TryForceOnMatchStarted();
					}
					catch
					{
					}
				}
				if (!_devPanelHidePatchInstalled)
				{
					try
					{
						TryInstallDevPanelHidePatch();
					}
					catch
					{
					}
				}
				if (!_shopThrottleInstalled)
				{
					try
					{
						TryInstallShopThrottle();
					}
					catch
					{
					}
				}
				if (!_lockerCrashGuardInstalled)
				{
					try
					{
						TryInstallLockerCrashGuard();
					}
					catch
					{
					}
				}
				if (!_networkTuningApplied)
				{
					try
					{
						TryApplyNetworkTuning();
					}
					catch
					{
					}
				}
				if (!_networkTunerHarmonyInstalled)
				{
					try
					{
						TryInstallNetworkTunerHarmonyPatch();
					}
					catch
					{
					}
				}
				if (!_interpDisablePatchInstalled)
				{
					try
					{
						TryDisableLocalPlayerInterp();
					}
					catch
					{
					}
				}
				if (!_crateRespawnDisabled)
				{
					try
					{
						TryDisableCrateRespawn();
					}
					catch
					{
					}
				}
				if (!_matchFoundDedupPatchInstalled)
				{
					try
					{
						TryInstallMatchFoundDedupPatch();
					}
					catch
					{
					}
				}
				if (!_augmentTimerExtended)
				{
					try
					{
						TryExtendAugmentSelectTimer();
					}
					catch
					{
					}
				}
			}
			if (Time.realtimeSinceStartup >= _nextPatchAt)
			{
				_nextPatchAt = Time.realtimeSinceStartup + ((Time.realtimeSinceStartup < 180f) ? 0.05f : 2f);
				TryInstallNetworkConfigPatches();
				TryInstallLifecycleGuardPatches();
				TryInstallGameModePatches();
				TryInstallJoinDiagnosticsPatches();
				TryInstallLoginControllerPatches();
				TryInstallAnalyticsPatches();
				TryInstallCharacterSelectNullRefPatch();
				TryInstallLobbyControllerGuardPatches();
				TryInstallCharacterUnlockPatches();
				TryFetchServerPolicy();
				TryInstallUnityWebRequestHeaderPatch();
				PatchLoadedNetworkConfigs();
				PatchLoadedWebServers();
				TryProtectLobbyUiFromDestruction();
			}
			if (Time.realtimeSinceStartup >= _nextUiPatchStatsLogAt)
			{
				_nextUiPatchStatsLogAt = Time.realtimeSinceStartup + 15f;
				if (_uiCharsConfigPatchInstalled)
				{
					((MelonBase)this).LoggerInstance.Msg($"UI patch stats: EnsureLobbyCharIdsPrefix called={_ensureLobbyCharIdsCallCount} filled={_ensureLobbyCharIdsFilledCount}");
				}
			}
			if (!_dedicatedProcess)
			{
				MelonPreferences_Entry<bool> autoGuestLoginEntry = _autoGuestLoginEntry;
				if (autoGuestLoginEntry != null && autoGuestLoginEntry.Value && HasCompleteLocalIdentity() && Time.realtimeSinceStartup >= _nextAutoGuestScanAt)
				{
					_nextAutoGuestScanAt = Time.realtimeSinceStartup + 1.5f;
					if (_splashGuestLoginInvoked && !_postLoginUiFallbackApplied && _lastLoadResponse == null && _splashGuestLoginInvokedAt > 0f && Time.realtimeSinceStartup - _splashGuestLoginInvokedAt > 12f)
					{
						((MelonBase)this).LoggerInstance.Msg("Resetting splash guest-login invoked flag for retry (no LoadResponse received within timeout).");
						_splashGuestLoginInvoked = false;
						_splashGuestLoginScanLogged = false;
						_autoGuestLoginControllers.Clear();
						_splashGuestLoginInvokedAt = 0f;
					}
					PrimeCustomServerLoginPrefs();
					TryAutoGuestLoginFromLoadedLoginControllers();
					TryAutoGuestLoginFromLoadedLobbyClients();
					TryInvokeSplashGuestLoginAction();
				}
			}
			if (!_dedicatedProcess && _postLoginUiFallbackAt > 0f && Time.realtimeSinceStartup >= _postLoginUiFallbackAt)
			{
				_postLoginUiFallbackAt = 0f;
				ApplyPostLoginUiFallback("scheduled post-login check");
			}
			if (!_dedicatedProcess && Time.realtimeSinceStartup >= _nextForceDismissSplashAt)
			{
				_nextForceDismissSplashAt = Time.realtimeSinceStartup + 1f;
				ForceDismissSplashUiInMatch();
			}
			if (_autoplayEnabled && !_dedicatedProcess)
			{
				RunAutoplayLogic();
			}
			int? autoJoinWsPort;
			if (!_autoJoinAttempted && !string.IsNullOrWhiteSpace(_autoJoinGameAuthId))
			{
				autoJoinWsPort = _autoJoinWsPort;
				if (autoJoinWsPort.HasValue && autoJoinWsPort.GetValueOrDefault() > 0)
				{
					autoJoinWsPort = _autoJoinKcpPort;
					if (autoJoinWsPort.HasValue && autoJoinWsPort.GetValueOrDefault() > 0)
					{
						autoJoinWsPort = _autoJoinTcpPort;
						if (autoJoinWsPort.HasValue && autoJoinWsPort.GetValueOrDefault() > 0 && Time.realtimeSinceStartup >= _nextAutoJoinAt)
						{
							_nextAutoJoinAt = Time.realtimeSinceStartup + 1f;
							TryAutoJoinMatch(_autoJoinGameAuthId, _autoJoinHost, _autoJoinWsPort.Value, _autoJoinKcpPort.Value, _autoJoinTcpPort.Value);
						}
					}
				}
			}
			if (!_dedicatedProcess)
			{
				return;
			}
			autoJoinWsPort = _dedicatedHttpPort;
			if (!autoJoinWsPort.HasValue || autoJoinWsPort.GetValueOrDefault() <= 0)
			{
				return;
			}
			autoJoinWsPort = _dedicatedWsPort;
			if (!autoJoinWsPort.HasValue || autoJoinWsPort.GetValueOrDefault() <= 0)
			{
				return;
			}
			autoJoinWsPort = _dedicatedKcpPort;
			if (!autoJoinWsPort.HasValue || autoJoinWsPort.GetValueOrDefault() <= 0)
			{
				return;
			}
			autoJoinWsPort = _dedicatedTcpPort;
			if (autoJoinWsPort.HasValue && autoJoinWsPort.GetValueOrDefault() > 0 && Time.realtimeSinceStartup >= _nextBootstrapRepairAt)
			{
				_nextBootstrapRepairAt = Time.realtimeSinceStartup + 1f;
				EnsureManagedBootstrapListener(_dedicatedHttpPort.Value);
				TryConfigureDedicatedGameManagers();
				if (!_dedicatedNetworkStarted)
				{
					TryStartDedicatedGameNetwork(_dedicatedWsPort.Value, _dedicatedKcpPort.Value, _dedicatedTcpPort.Value);
				}
				if (!_bootstrapRepairComplete)
				{
					TryRepairDedicatedWebServer(_dedicatedHttpPort.Value);
				}
				TryAutoEndDedicatedMatch();
			}
		}

		public override void OnLateUpdate()
		{
			if (!_charConfigPreloadDone)
			{
				TryFixCharactersConfigurationCrash();
			}
		}

		public override void OnGUI()
		{
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			if (_dedicatedProcess)
			{
				return;
			}
			bool flag = _productionModeEntry?.Value ?? false;
			if (!flag)
			{
				try
				{
					GUI.Label(ModOkGuiRect, "MOD-OK");
				}
				catch
				{
				}
			}
			_onGuiCallCount++;
			if (_onGuiCallCount == 1 || _onGuiCallCount % 1000 == 0)
			{
				try
				{
					((MelonBase)this).LoggerInstance.Msg($"[OnGUI] called {_onGuiCallCount} times");
				}
				catch
				{
				}
			}
			if (!_uiEnabled || (flag && !_identitySetupRequired))
			{
				return;
			}
			try
			{
				MelonPreferences_Entry<bool> moddingOverlayEntry = _moddingOverlayEntry;
				if (moddingOverlayEntry != null && moddingOverlayEntry.Value)
				{
					try
					{
						DrawModdingOverlay();
					}
					catch
					{
					}
				}
				if (_identitySetupRequired)
				{
					if (!((Object)(object)_nativeUiRoot != (Object)null) || _nativeUiBuildFailed)
					{
						DrawIdentitySetupWindow();
					}
					return;
				}
				MelonPreferences_Entry<bool> nativeUiEntry = _nativeUiEntry;
				if (nativeUiEntry == null || !nativeUiEntry.Value || _nativeUiBuildFailed)
				{
					DrawGuiSurfaces();
				}
			}
			catch (MissingMethodException ex) when (ex.Message.Contains("WindowFunction", StringComparison.OrdinalIgnoreCase))
			{
				DisableGuiAfterFailure(ex);
			}
			catch (Exception ex2)
			{
				DisableGuiAfterFailure(ex2);
			}
		}

		private void DrawGuiSurfaces()
		{
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Expected O, but got Unknown
			//IL_005c: Expected O, but got Unknown
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			MelonPreferences_Entry<bool> statusChipEntry = _statusChipEntry;
			if (statusChipEntry != null && statusChipEntry.Value && !_showWindow)
			{
				DrawStatusChip();
			}
			if (_showWindow)
			{
				_windowRect = GUI.Window(7650505, _windowRect, new WindowFunction(DrawWindow), new GUIContent("BAP Custom Server"), GUI.skin.window);
			}
		}

		private void DrawIdentitySetupWindow()
		{
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Expected O, but got Unknown
			//IL_00ba: Expected O, but got Unknown
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			float num = Math.Min(500f, Math.Max(360f, (float)Screen.width - 48f));
			float num2 = 270f;
			_setupWindowRect = new Rect(Math.Max(12f, ((float)Screen.width - num) * 0.5f), Math.Max(12f, ((float)Screen.height - num2) * 0.5f), num, num2);
			GUI.Box(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), "");
			_setupWindowRect = GUI.Window(7650506, _setupWindowRect, new WindowFunction(DrawIdentitySetupContents), new GUIContent("BAP Custom Server Setup"), GUI.skin.window);
		}

		private void DrawIdentitySetupContents(int windowId)
		{
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0125: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Invalid comparison between Unknown and I4
			//IL_015b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0132: Unknown result type (might be due to invalid IL or missing references)
			//IL_0139: Invalid comparison between Unknown and I4
			GUILayout.Space(8f);
			GUILayout.Label("Choose your player name for this custom server.", Array.Empty<GUILayoutOption>());
			GUILayout.Label("Server: " + GetConfiguredApiHost(), Array.Empty<GUILayoutOption>());
			GUILayout.Space(12f);
			GUI.SetNextControlName("BapCustomSetupName");
			_setupUsernameText = LabeledTextField("Name", _setupUsernameText);
			GUILayout.Space(8f);
			GUILayout.Label("A local Account ID will be generated and saved to BapCustomServer.ini.", Array.Empty<GUILayoutOption>());
			if (!string.IsNullOrWhiteSpace(_setupErrorText))
			{
				GUILayout.Space(4f);
				GUI.contentColor = new Color(1f, 0.58f, 0.42f, 1f);
				GUILayout.Label(_setupErrorText, Array.Empty<GUILayoutOption>());
				GUI.contentColor = Color.white;
			}
			else
			{
				GUILayout.Space(4f);
				GUILayout.Label("Delete AccountId or Username from the ini to show this setup again.", Array.Empty<GUILayoutOption>());
			}
			GUILayout.FlexibleSpace();
			GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
			GUILayout.FlexibleSpace();
			if (GUILayout.Button("Continue", (GUILayoutOption[])(object)new GUILayoutOption[2]
			{
				GUILayout.Width(140f),
				GUILayout.Height(34f)
			}) || ((int)Event.current.type == 4 && (int)Event.current.keyCode == 13))
			{
				CompleteIdentitySetupFromGui();
			}
			GUILayout.EndHorizontal();
			GUI.DragWindow(new Rect(0f, 0f, 10000f, 24f));
		}

		private void DisableGuiAfterFailure(Exception ex)
		{
			_uiEnabled = false;
			_showWindow = false;
			if (_statusChipEntry != null)
			{
				_statusChipEntry.Value = false;
			}
			if (!_uiFailureLogged)
			{
				_uiFailureLogged = true;
				((MelonBase)this).LoggerInstance.Warning("Custom server IMGUI disabled after runtime UI failure: " + ex.GetBaseException().Message);
			}
		}

		private void DrawWindow(int windowId)
		{
			//IL_020a: Unknown result type (might be due to invalid IL or missing references)
			GUILayout.Space(6f);
			GUILayout.Label("Server", Array.Empty<GUILayoutOption>());
			_hostEntry.Value = LabeledTextField("IP / Host", _hostEntry.Value);
			_serverPortText = LabeledTextField("Port", _serverPortText);
			_accountIdEntry.Value = LabeledTextField("Account ID", _accountIdEntry.Value);
			_usernameEntry.Value = LabeledTextField("Username", _usernameEntry.Value);
			_httpsEntry.Value = GUILayout.Toggle(_httpsEntry.Value, "Use HTTPS", Array.Empty<GUILayoutOption>());
			GUILayout.Space(8f);
			GUILayout.Label("Routing", Array.Empty<GUILayoutOption>());
			_localProxyEntry.Value = GUILayout.Toggle(_localProxyEntry.Value, "Use in-game local proxy", Array.Empty<GUILayoutOption>());
			_statusChipEntry.Value = GUILayout.Toggle(_statusChipEntry.Value, "Show lobby status chip", Array.Empty<GUILayoutOption>());
			using (new DisabledScope(!_localProxyEntry.Value))
			{
				_localPortText = LabeledTextField("Local Port", _localPortText);
			}
			GUILayout.Space(8f);
			GUILayout.Label("Game API: " + GetConfiguredApiHost(), Array.Empty<GUILayoutOption>());
			GUILayout.Label("Status: " + _statusText, Array.Empty<GUILayoutOption>());
			GUILayout.Space(8f);
			GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
			if (GUILayout.Button("Apply + Save", (GUILayoutOption[])(object)new GUILayoutOption[1] { GUILayout.Height(28f) }))
			{
				ApplySettings(restartProxy: true, save: true);
			}
			if (GUILayout.Button("Close", (GUILayoutOption[])(object)new GUILayoutOption[1] { GUILayout.Height(28f) }))
			{
				_showWindow = false;
			}
			GUILayout.EndHorizontal();
			GUI.DragWindow(new Rect(0f, 0f, 10000f, 24f));
		}

		private void DrawStatusChip()
		{
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			float num = Math.Max(16f, (float)Screen.width - 430f - 24f);
			Rect val = default(Rect);
			((Rect)(ref val))..ctor(num, 18f, 430f, 64f);
			GUI.Box(val, "");
			GUILayout.BeginArea(new Rect(((Rect)(ref val)).x + 12f, ((Rect)(ref val)).y + 8f, ((Rect)(ref val)).width - 24f, ((Rect)(ref val)).height - 16f));
			GUILayout.Label("Custom Server: " + GetConfiguredApiHost(), Array.Empty<GUILayoutOption>());
			GUILayout.Label(_statusText + " | F7 settings", Array.Empty<GUILayoutOption>());
			GUILayout.EndArea();
		}

		private void DrawModdingOverlay()
		{
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			float num = ((float)Screen.width - 360f) * 0.5f;
			float num2 = (float)Screen.height - 50f - 16f;
			Rect val = default(Rect);
			((Rect)(ref val))..ctor(num, num2, 360f, 50f);
			Color color = GUI.color;
			GUI.color = new Color(0f, 0f, 0f, 0.55f);
			GUI.Box(val, "");
			GUI.color = color;
			GUILayout.BeginArea(new Rect(((Rect)(ref val)).x, ((Rect)(ref val)).y + 4f, ((Rect)(ref val)).width, ((Rect)(ref val)).height - 8f));
			GUILayout.FlexibleSpace();
			string text = ((!string.IsNullOrEmpty(_serverModdingOverlayTitle)) ? _serverModdingOverlayTitle : (_moddingOverlayTitleEntry?.Value ?? "BAPBAP Modding"));
			string obj = ((!string.IsNullOrEmpty(_serverModdingOverlaySubtitle)) ? _serverModdingOverlaySubtitle : (_moddingOverlaySubtitleEntry?.Value ?? "discord.gg/bapbapmods"));
			GUILayout.Label(text, Array.Empty<GUILayoutOption>());
			GUILayout.Label(obj, Array.Empty<GUILayoutOption>());
			GUILayout.FlexibleSpace();
			GUILayout.EndArea();
		}

		private void TryInstallModdingOverlayUgui()
		{
			//IL_0313: Unknown result type (might be due to invalid IL or missing references)
			//IL_0329: Unknown result type (might be due to invalid IL or missing references)
			//IL_033f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0355: Unknown result type (might be due to invalid IL or missing references)
			//IL_036b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0288: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Expected O, but got Unknown
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Expected O, but got Unknown
			if (_uguiOverlayInstalled || _uguiOverlayFailed || _dedicatedProcess)
			{
				return;
			}
			MelonPreferences_Entry<bool> moddingOverlayEntry = _moddingOverlayEntry;
			if (moddingOverlayEntry == null || !moddingOverlayEntry.Value)
			{
				return;
			}
			try
			{
				if ((Object)(object)GameObject.Find("BapModdingOverlay") != (Object)null)
				{
					_uguiOverlayInstalled = true;
					((MelonBase)this).LoggerInstance.Msg("uGUI overlay already exists (BapModdingOverlay found).");
					return;
				}
				GameObject val = new GameObject("BapModdingOverlay");
				Object.DontDestroyOnLoad((Object)(object)val);
				Canvas obj = val.AddComponent<Canvas>();
				obj.renderMode = (RenderMode)0;
				obj.sortingOrder = 32767;
				val.AddComponent<CanvasScaler>().uiScaleMode = (ScaleMode)0;
				val.AddComponent<GraphicRaycaster>();
				GameObject val2 = new GameObject("OverlayText");
				val2.transform.SetParent(val.transform, false);
				Type type = FindType("TMPro.TextMeshProUGUI");
				if (type == null)
				{
					type = FindType("TMPro.TextMeshProUGUI");
				}
				object obj2 = null;
				if (type != null)
				{
					try
					{
						MethodInfo method = typeof(GameObject).GetMethod("AddComponent", new Type[1] { typeof(Type) });
						if (method != null)
						{
							obj2 = method.Invoke(val2, new object[1] { type });
						}
					}
					catch (Exception ex)
					{
						((MelonBase)this).LoggerInstance.Msg("uGUI overlay: AddComponent(TextMeshProUGUI) failed: " + ex.GetBaseException().Message);
					}
				}
				if (obj2 != null)
				{
					try
					{
						string moddingOverlayText = GetModdingOverlayText();
						SetPropertyOrField(obj2, "text", moddingOverlayText);
						SetPropertyOrField(obj2, "fontSize", 22f);
						try
						{
							PropertyInfo property = obj2.GetType().GetProperty("alignment");
							if (property != null)
							{
								property.SetValue(obj2, Enum.ToObject(property.PropertyType, 514));
							}
						}
						catch
						{
						}
						try
						{
							PropertyInfo property2 = obj2.GetType().GetProperty("color");
							if (property2 != null)
							{
								property2.SetValue(obj2, (object)new Color(1f, 1f, 1f, 0.9f));
							}
						}
						catch
						{
						}
						try
						{
							SetPropertyOrField(obj2, "richText", true);
						}
						catch
						{
						}
					}
					catch (Exception ex2)
					{
						((MelonBase)this).LoggerInstance.Msg("uGUI overlay: setting TMP properties failed: " + ex2.GetBaseException().Message);
					}
					_uguiOverlayTmpText = obj2;
				}
				else
				{
					try
					{
						Text val3 = val2.AddComponent<Text>();
						val3.text = GetModdingOverlayTextPlain();
						val3.fontSize = 20;
						val3.alignment = (TextAnchor)4;
						((Graphic)val3).color = new Color(1f, 1f, 1f, 0.9f);
						val3.horizontalOverflow = (HorizontalWrapMode)1;
						val3.verticalOverflow = (VerticalWrapMode)1;
						try
						{
							Font builtinResource = Resources.GetBuiltinResource<Font>("Arial.ttf");
							if ((Object)(object)builtinResource != (Object)null)
							{
								val3.font = builtinResource;
							}
						}
						catch
						{
						}
						_uguiOverlayTmpText = val3;
					}
					catch (Exception ex3)
					{
						((MelonBase)this).LoggerInstance.Msg("uGUI overlay: fallback UI.Text also failed: " + ex3.GetBaseException().Message);
					}
				}
				RectTransform component = val2.GetComponent<RectTransform>();
				if ((Object)(object)component != (Object)null)
				{
					component.anchorMin = new Vector2(0.5f, 0f);
					component.anchorMax = new Vector2(0.5f, 0f);
					component.pivot = new Vector2(0.5f, 0f);
					component.anchoredPosition = new Vector2(0f, 32f);
					component.sizeDelta = new Vector2(600f, 56f);
				}
				_uguiOverlayRoot = val;
				_uguiOverlayInstalled = true;
				((MelonBase)this).LoggerInstance.Msg("uGUI overlay created on Canvas BapModdingOverlay (sortingOrder=32767, TMP=" + ((obj2 != null) ? "yes" : "no/fallback-Text") + ")");
			}
			catch (Exception ex4)
			{
				_uguiOverlayFailed = true;
				((MelonBase)this).LoggerInstance.Msg("uGUI overlay creation failed: " + ex4.GetBaseException().Message);
			}
		}

		private string GetModdingOverlayText()
		{
			string obj = ((!string.IsNullOrEmpty(_serverModdingOverlayTitle)) ? _serverModdingOverlayTitle : (_moddingOverlayTitleEntry?.Value ?? "BAPBAP Modding"));
			string text = ((!string.IsNullOrEmpty(_serverModdingOverlaySubtitle)) ? _serverModdingOverlaySubtitle : (_moddingOverlaySubtitleEntry?.Value ?? "discord.gg/bapbapmods"));
			return obj + "\n<size=70%>" + text + "</size>";
		}

		private string GetModdingOverlayTextPlain()
		{
			string obj = ((!string.IsNullOrEmpty(_serverModdingOverlayTitle)) ? _serverModdingOverlayTitle : (_moddingOverlayTitleEntry?.Value ?? "BAPBAP Modding"));
			string text = ((!string.IsNullOrEmpty(_serverModdingOverlaySubtitle)) ? _serverModdingOverlaySubtitle : (_moddingOverlaySubtitleEntry?.Value ?? "discord.gg/bapbapmods"));
			return obj + "\n" + text;
		}

		private void UpdateUguiOverlayText()
		{
			if (_uguiOverlayTmpText == null)
			{
				return;
			}
			try
			{
				object? uguiOverlayTmpText = _uguiOverlayTmpText;
				Text val = (Text)((uguiOverlayTmpText is Text) ? uguiOverlayTmpText : null);
				if (val != null)
				{
					val.text = GetModdingOverlayTextPlain();
				}
				else
				{
					SetPropertyOrField(_uguiOverlayTmpText, "text", GetModdingOverlayText());
				}
			}
			catch
			{
			}
		}

		private static void SetPropertyOrField(object target, string name, object value)
		{
			PropertyInfo property = target.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (property != null && property.CanWrite)
			{
				property.SetValue(target, value);
			}
			else
			{
				target.GetType().GetField(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)?.SetValue(target, value);
			}
		}

		private void ToggleUiPanel()
		{
			MelonPreferences_Entry<bool> nativeUiEntry = _nativeUiEntry;
			if (nativeUiEntry != null && nativeUiEntry.Value && !_dedicatedProcess)
			{
				EnsureNativeGameUi();
				_nativeUiExpanded = !_nativeUiExpanded;
				RefreshNativeGameUi(syncInputs: true);
			}
			else
			{
				_showWindow = !_showWindow;
			}
		}

		private void EnsureNativeGameUi()
		{
			if (_dedicatedProcess || Application.isBatchMode || (Object)(object)_nativeUiRoot != (Object)null || _nativeUiBuildFailed)
			{
				return;
			}
			try
			{
				BuildNativeGameUi();
				RefreshNativeGameUi(syncInputs: true);
				((MelonBase)this).LoggerInstance.Msg("Created native Unity custom server panel.");
			}
			catch (Exception ex)
			{
				_nativeUiBuildFailed = true;
				((MelonBase)this).LoggerInstance.Warning("Native custom server UI could not be created; IMGUI fallback remains available: " + ex.GetBaseException().Message);
			}
		}

		private void BuildNativeGameUi()
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0150: Unknown result type (might be due to invalid IL or missing references)
			//IL_015b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0170: Unknown result type (might be due to invalid IL or missing references)
			//IL_017b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0185: Unknown result type (might be due to invalid IL or missing references)
			//IL_021f: Unknown result type (might be due to invalid IL or missing references)
			//IL_022e: Unknown result type (might be due to invalid IL or missing references)
			//IL_023d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0256: Unknown result type (might be due to invalid IL or missing references)
			//IL_029a: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0310: Unknown result type (might be due to invalid IL or missing references)
			//IL_0342: Unknown result type (might be due to invalid IL or missing references)
			//IL_0351: Unknown result type (might be due to invalid IL or missing references)
			//IL_0360: Unknown result type (might be due to invalid IL or missing references)
			//IL_038e: Unknown result type (might be due to invalid IL or missing references)
			//IL_039d: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_03da: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0424: Unknown result type (might be due to invalid IL or missing references)
			//IL_0433: Unknown result type (might be due to invalid IL or missing references)
			//IL_0442: Unknown result type (might be due to invalid IL or missing references)
			//IL_0475: Unknown result type (might be due to invalid IL or missing references)
			//IL_0484: Unknown result type (might be due to invalid IL or missing references)
			//IL_0493: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_04d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_04e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_051d: Unknown result type (might be due to invalid IL or missing references)
			//IL_052c: Unknown result type (might be due to invalid IL or missing references)
			//IL_053b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0554: Unknown result type (might be due to invalid IL or missing references)
			//IL_0586: Unknown result type (might be due to invalid IL or missing references)
			//IL_0595: Unknown result type (might be due to invalid IL or missing references)
			//IL_05a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_05cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_05de: Unknown result type (might be due to invalid IL or missing references)
			//IL_05ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_0612: Unknown result type (might be due to invalid IL or missing references)
			//IL_064c: Unknown result type (might be due to invalid IL or missing references)
			//IL_065b: Unknown result type (might be due to invalid IL or missing references)
			//IL_066a: Unknown result type (might be due to invalid IL or missing references)
			//IL_069a: Unknown result type (might be due to invalid IL or missing references)
			//IL_06a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_06b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_06ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_06f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0708: Unknown result type (might be due to invalid IL or missing references)
			//IL_073d: Unknown result type (might be due to invalid IL or missing references)
			//IL_074c: Unknown result type (might be due to invalid IL or missing references)
			//IL_075b: Unknown result type (might be due to invalid IL or missing references)
			//IL_078d: Unknown result type (might be due to invalid IL or missing references)
			//IL_079c: Unknown result type (might be due to invalid IL or missing references)
			//IL_07ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_07d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_07e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_07f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0827: Unknown result type (might be due to invalid IL or missing references)
			//IL_0836: Unknown result type (might be due to invalid IL or missing references)
			//IL_0845: Unknown result type (might be due to invalid IL or missing references)
			//IL_0871: Unknown result type (might be due to invalid IL or missing references)
			//IL_0880: Unknown result type (might be due to invalid IL or missing references)
			//IL_088f: Unknown result type (might be due to invalid IL or missing references)
			//IL_08ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_08d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_08e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0923: Unknown result type (might be due to invalid IL or missing references)
			//IL_0932: Unknown result type (might be due to invalid IL or missing references)
			//IL_0941: Unknown result type (might be due to invalid IL or missing references)
			//IL_097c: Unknown result type (might be due to invalid IL or missing references)
			//IL_098b: Unknown result type (might be due to invalid IL or missing references)
			//IL_099a: Unknown result type (might be due to invalid IL or missing references)
			//IL_09cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_09de: Unknown result type (might be due to invalid IL or missing references)
			//IL_09ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a22: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a31: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a40: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a78: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a87: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a96: Unknown result type (might be due to invalid IL or missing references)
			EnsureEventSystem();
			_nativeUiRoot = new GameObject("BAP Custom Server UI");
			Transform val = TryFindGameUiParent();
			if ((Object)(object)val != (Object)null)
			{
				GameObject gameObject = ((Component)val.root).gameObject;
				Object.DontDestroyOnLoad((Object)(object)gameObject);
				((MelonBase)this).LoggerInstance.Msg("Protected root canvas '" + ((Object)gameObject).name + "' with DontDestroyOnLoad.");
				try
				{
					Array array = FindLoadedUnityObjects(typeof(GameObject));
					if (array != null)
					{
						int num = 0;
						foreach (GameObject item in array.Cast<GameObject>())
						{
							if (!((Object)(object)item == (Object)null) && !((Object)(object)item.transform.parent != (Object)null))
							{
								Object.DontDestroyOnLoad((Object)(object)item);
								num++;
							}
						}
						((MelonBase)this).LoggerInstance.Msg($"Protected {num} root GameObjects with DontDestroyOnLoad.");
					}
				}
				catch (Exception ex)
				{
					((MelonBase)this).LoggerInstance.Warning("Could not protect scene roots: " + ex.GetBaseException().Message);
				}
				_nativeUiRoot.transform.SetParent(val, false);
				RectTransform obj = _nativeUiRoot.AddComponent<RectTransform>();
				obj.anchorMin = Vector2.zero;
				obj.anchorMax = Vector2.one;
				obj.pivot = new Vector2(0.5f, 0.5f);
				obj.offsetMin = Vector2.zero;
				obj.offsetMax = Vector2.zero;
				_nativeUiAttachedToGameCanvas = true;
			}
			else
			{
				Object.DontDestroyOnLoad((Object)(object)_nativeUiRoot);
				Canvas obj2 = _nativeUiRoot.AddComponent<Canvas>();
				obj2.renderMode = (RenderMode)0;
				obj2.sortingOrder = 32000;
				CanvasScaler obj3 = _nativeUiRoot.AddComponent<CanvasScaler>();
				obj3.uiScaleMode = (ScaleMode)1;
				obj3.referenceResolution = new Vector2(1920f, 1080f);
				obj3.matchWidthOrHeight = 0.5f;
				_nativeUiRoot.AddComponent<GraphicRaycaster>();
				_nativeUiAttachedToGameCanvas = false;
			}
			_nativeUiChip = CreatePanel(_nativeUiRoot.transform, "CustomServerChip", new Vector2(320f, 56f), new Vector2(1f, 1f), new Vector2(-24f, -24f), new Color(0.04f, 0.05f, 0.07f, 0.92f));
			_nativeChipRect = _nativeUiChip.GetComponent<RectTransform>();
			_nativeChipText = CreateText(_nativeUiChip.transform, "ChipText", "Custom Server", 16, (TextAnchor)3, new Vector2(296f, 38f), new Vector2(0f, 0.5f), new Vector2(16f, 0f));
			_nativeSetupPanel = CreatePanel(_nativeUiRoot.transform, "CustomServerIdentitySetup", new Vector2(540f, 286f), new Vector2(0.5f, 0.5f), Vector2.zero, new Color(0.045f, 0.05f, 0.06f, 0.98f));
			CreateText(_nativeSetupPanel.transform, "SetupTitle", "Custom Server Setup", 24, (TextAnchor)3, new Vector2(470f, 34f), new Vector2(0f, 1f), new Vector2(24f, -26f));
			CreateText(_nativeSetupPanel.transform, "SetupBody", "Choose your player name. A local Account ID is generated and saved to BapCustomServer.ini.", 15, (TextAnchor)0, new Vector2(492f, 48f), new Vector2(0f, 1f), new Vector2(24f, -70f));
			CreateText(_nativeSetupPanel.transform, "SetupNameLabel", "Player name", 14, (TextAnchor)3, new Vector2(130f, 34f), new Vector2(0f, 1f), new Vector2(24f, -138f));
			_nativeSetupNameInput = CreateInput(_nativeSetupPanel.transform, "SetupNameInput", "PlayerName", new Vector2(330f, 38f), new Vector2(1f, 1f), new Vector2(-24f, -138f));
			_nativeSetupStatusText = CreateText(_nativeSetupPanel.transform, "SetupStatus", "", 13, (TextAnchor)0, new Vector2(492f, 42f), new Vector2(0f, 0f), new Vector2(24f, 74f));
			_nativeSetupContinueRect = CreateButton(_nativeSetupPanel.transform, "SetupContinue", "Continue", new Vector2(142f, 38f), new Vector2(1f, 0f), new Vector2(-24f, 24f)).GetComponent<RectTransform>();
			_nativeSetupPanel.SetActive(false);
			_nativeUiPanel = CreatePanel(_nativeUiRoot.transform, "CustomServerPanel", new Vector2(430f, 390f), new Vector2(1f, 1f), new Vector2(-24f, -92f), new Color(0.05f, 0.055f, 0.065f, 0.97f));
			CreateText(_nativeUiPanel.transform, "Title", "Custom Server", 22, (TextAnchor)3, new Vector2(260f, 34f), new Vector2(0f, 1f), new Vector2(20f, -24f));
			GameObject val2 = CreateButton(_nativeUiPanel.transform, "Close", "Close", new Vector2(84f, 30f), new Vector2(1f, 1f), new Vector2(-20f, -24f));
			((Graphic)val2.GetComponent<Image>()).color = new Color(0.13f, 0.14f, 0.16f, 0.95f);
			_nativeCloseRect = val2.GetComponent<RectTransform>();
			_nativeEndpointText = CreateText(_nativeUiPanel.transform, "Endpoint", "", 13, (TextAnchor)3, new Vector2(390f, 24f), new Vector2(0f, 1f), new Vector2(20f, -58f));
			_nativeHostInput = CreateInput(_nativeUiPanel.transform, "HostInput", "Host", new Vector2(250f, 34f), new Vector2(1f, 1f), new Vector2(-20f, -100f));
			CreateText(_nativeUiPanel.transform, "HostLabel", "Host", 14, (TextAnchor)3, new Vector2(120f, 30f), new Vector2(0f, 1f), new Vector2(20f, -100f));
			_nativeServerPortInput = CreateInput(_nativeUiPanel.transform, "ServerPortInput", 5055.ToString(), new Vector2(250f, 34f), new Vector2(1f, 1f), new Vector2(-20f, -142f));
			CreateText(_nativeUiPanel.transform, "ServerPortLabel", "Server port", 14, (TextAnchor)3, new Vector2(120f, 30f), new Vector2(0f, 1f), new Vector2(20f, -142f));
			_nativeLocalPortInput = CreateInput(_nativeUiPanel.transform, "LocalPortInput", "5055", new Vector2(250f, 34f), new Vector2(1f, 1f), new Vector2(-20f, -184f));
			CreateText(_nativeUiPanel.transform, "LocalPortLabel", "Local port", 14, (TextAnchor)3, new Vector2(120f, 30f), new Vector2(0f, 1f), new Vector2(20f, -184f));
			_nativeHttpsRect = CreateToggleRow(_nativeUiPanel.transform, "HttpsToggle", "Use HTTPS", new Vector2(180f, 28f), new Vector2(0f, 1f), new Vector2(20f, -226f), out _nativeHttpsCheck).GetComponent<RectTransform>();
			_nativeProxyToggleRect = CreateToggleRow(_nativeUiPanel.transform, "ProxyToggle", "Use in-game proxy", new Vector2(210f, 28f), new Vector2(0f, 1f), new Vector2(20f, -260f), out _nativeProxyCheck).GetComponent<RectTransform>();
			_nativeStatusToggleRect = CreateToggleRow(_nativeUiPanel.transform, "StatusToggle", "Show status chip", new Vector2(210f, 28f), new Vector2(0f, 1f), new Vector2(20f, -294f), out _nativeStatusCheck).GetComponent<RectTransform>();
			_nativeApplyRect = CreateButton(_nativeUiPanel.transform, "Apply", "Apply + Save", new Vector2(150f, 36f), new Vector2(0f, 0f), new Vector2(20f, 22f)).GetComponent<RectTransform>();
			_nativeDirectRect = CreateButton(_nativeUiPanel.transform, "Direct", "Direct mode", new Vector2(130f, 36f), new Vector2(0.5f, 0f), new Vector2(-4f, 22f)).GetComponent<RectTransform>();
			_nativeProxyRect = CreateButton(_nativeUiPanel.transform, "Proxy", "Proxy mode", new Vector2(130f, 36f), new Vector2(1f, 0f), new Vector2(-20f, 22f)).GetComponent<RectTransform>();
			_nativeStatusText = CreateText(_nativeUiPanel.transform, "Status", "", 13, (TextAnchor)0, new Vector2(390f, 48f), new Vector2(0f, 0f), new Vector2(20f, 72f));
			_nativeUiPanel.SetActive(false);
			((MelonBase)this).LoggerInstance.Msg(_nativeUiAttachedToGameCanvas ? "Native custom server UI attached to existing game UI canvas." : "Native custom server UI created as independent overlay canvas.");
		}

		private Transform? TryFindGameUiParent()
		{
			try
			{
				Type type = FindType("BAPBAP.UI.UIManager");
				if (type != null)
				{
					object memberValue = GetMemberValue(type, "Instance");
					if (memberValue != null)
					{
						object? memberValue2 = GetMemberValue(memberValue, "mainCanvas");
						Transform val = (Transform)((memberValue2 is Transform) ? memberValue2 : null);
						if (val != null)
						{
							return val;
						}
						object? memberValue3 = GetMemberValue(memberValue, "lobbyRoot");
						GameObject val2 = (GameObject)((memberValue3 is GameObject) ? memberValue3 : null);
						if (val2 != null)
						{
							Canvas componentInParent = val2.GetComponentInParent<Canvas>();
							if ((Object)(object)componentInParent != (Object)null)
							{
								return ((Component)componentInParent).transform;
							}
						}
					}
				}
				Canvas? obj = (from canvas in (FindLoadedUnityObjects(typeof(Canvas))?.Cast<object>() ?? Enumerable.Empty<object>()).OfType<Canvas>()
					where (Object)(object)canvas != (Object)null && canvas.isRootCanvas && ((Component)canvas).gameObject.activeInHierarchy
					orderby canvas.sortingOrder descending
					select canvas).FirstOrDefault((Canvas canvas) => ((Object)canvas).name.Contains("Lobby", StringComparison.OrdinalIgnoreCase) || ((Object)canvas).name.Contains("UI", StringComparison.OrdinalIgnoreCase) || ((Object)canvas).name.Contains("Canvas", StringComparison.OrdinalIgnoreCase));
				return (obj != null) ? ((Component)obj).transform : null;
			}
			catch (Exception ex)
			{
				((MelonBase)this).LoggerInstance.Warning("Could not locate game UI canvas for native integration: " + ex.GetBaseException().Message);
				return null;
			}
		}

		private void EnsureEventSystem()
		{
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			if (!((Object)(object)Object.FindObjectOfType<EventSystem>() != (Object)null))
			{
				GameObject val = new GameObject("BAP Custom Server EventSystem");
				Object.DontDestroyOnLoad((Object)val);
				val.AddComponent<EventSystem>();
				val.AddComponent<StandaloneInputModule>();
			}
		}

		private GameObject CreatePanel(Transform parent, string name, Vector2 size, Vector2 anchor, Vector2 anchoredPosition, Color color)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Expected O, but got Unknown
			GameObject val = new GameObject(name);
			val.transform.SetParent(parent, false);
			RectTransform obj = val.AddComponent<RectTransform>();
			obj.anchorMin = anchor;
			obj.anchorMax = anchor;
			obj.pivot = anchor;
			obj.sizeDelta = size;
			obj.anchoredPosition = anchoredPosition;
			((Graphic)val.AddComponent<Image>()).color = color;
			return val;
		}

		private Text CreateText(Transform parent, string name, string value, int fontSize, TextAnchor alignment, Vector2 size, Vector2 anchor, Vector2 anchoredPosition)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			GameObject val = new GameObject(name);
			val.transform.SetParent(parent, false);
			RectTransform obj = val.AddComponent<RectTransform>();
			obj.anchorMin = anchor;
			obj.anchorMax = anchor;
			obj.pivot = anchor;
			obj.sizeDelta = size;
			obj.anchoredPosition = anchoredPosition;
			Text obj2 = val.AddComponent<Text>();
			obj2.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
			obj2.fontSize = fontSize;
			obj2.alignment = alignment;
			((Graphic)obj2).color = Color.white;
			obj2.horizontalOverflow = (HorizontalWrapMode)0;
			obj2.verticalOverflow = (VerticalWrapMode)0;
			obj2.text = value;
			return obj2;
		}

		private GameObject CreateButton(Transform parent, string name, string label, Vector2 size, Vector2 anchor, Vector2 anchoredPosition)
		{
			//IL_0003: Unknown result type (might be due to invalid IL or missing references)
			//IL_0005: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			GameObject val = CreatePanel(parent, name, size, anchor, anchoredPosition, new Color(0.18f, 0.24f, 0.31f, 0.96f));
			CreateText(val.transform, "Label", label, 14, (TextAnchor)4, new Vector2(size.x - 12f, size.y - 8f), new Vector2(0.5f, 0.5f), Vector2.zero);
			return val;
		}

		private InputField CreateInput(Transform parent, string name, string placeholder, Vector2 size, Vector2 anchor, Vector2 anchoredPosition)
		{
			//IL_0003: Unknown result type (might be due to invalid IL or missing references)
			//IL_0005: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			GameObject val = CreatePanel(parent, name, size, anchor, anchoredPosition, new Color(0.1f, 0.11f, 0.13f, 0.98f));
			InputField obj = val.AddComponent<InputField>();
			((Selectable)obj).targetGraphic = (Graphic)(object)val.GetComponent<Image>();
			Text textComponent = CreateText(val.transform, "Text", "", 14, (TextAnchor)3, new Vector2(size.x - 24f, size.y - 8f), new Vector2(0f, 0.5f), new Vector2(12f, 0f));
			Text val2 = CreateText(val.transform, "Placeholder", placeholder, 14, (TextAnchor)3, new Vector2(size.x - 24f, size.y - 8f), new Vector2(0f, 0.5f), new Vector2(12f, 0f));
			((Graphic)val2).color = new Color(0.72f, 0.74f, 0.78f, 0.65f);
			obj.textComponent = textComponent;
			obj.placeholder = (Graphic)(object)val2;
			return obj;
		}

		private void HandleNativeUiPointer(Vector3 screenPosition)
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			if (_identitySetupRequired)
			{
				if (ContainsScreenPoint(_nativeSetupContinueRect, screenPosition))
				{
					InputField? nativeSetupNameInput = _nativeSetupNameInput;
					_setupUsernameText = ((nativeSetupNameInput != null) ? nativeSetupNameInput.text : null) ?? _setupUsernameText;
					CompleteIdentitySetupFromGui();
					RefreshNativeGameUi(syncInputs: true);
				}
				return;
			}
			if (_nativeUiExpanded)
			{
				if (ContainsScreenPoint(_nativeCloseRect, screenPosition))
				{
					_nativeUiExpanded = false;
					RefreshNativeGameUi(syncInputs: false);
					return;
				}
				if (ContainsScreenPoint(_nativeApplyRect, screenPosition))
				{
					ApplyNativeUiSettings();
					return;
				}
				if (ContainsScreenPoint(_nativeDirectRect, screenPosition))
				{
					_localProxyEntry.Value = false;
					ApplyNativeUiSettings();
					return;
				}
				if (ContainsScreenPoint(_nativeProxyRect, screenPosition))
				{
					_localProxyEntry.Value = true;
					ApplyNativeUiSettings();
					return;
				}
				if (ContainsScreenPoint(_nativeHttpsRect, screenPosition))
				{
					_httpsEntry.Value = !_httpsEntry.Value;
					RefreshNativeGameUi(syncInputs: true);
					return;
				}
				if (ContainsScreenPoint(_nativeProxyToggleRect, screenPosition))
				{
					_localProxyEntry.Value = !_localProxyEntry.Value;
					RefreshNativeGameUi(syncInputs: true);
					return;
				}
				if (ContainsScreenPoint(_nativeStatusToggleRect, screenPosition))
				{
					_statusChipEntry.Value = !_statusChipEntry.Value;
					RefreshNativeGameUi(syncInputs: true);
					return;
				}
			}
			if (ContainsScreenPoint(_nativeChipRect, screenPosition))
			{
				_nativeUiExpanded = !_nativeUiExpanded;
				RefreshNativeGameUi(syncInputs: true);
			}
		}

		private void CaptureIdentitySetupKeyboardInput()
		{
			if (!_identitySetupRequired || _dedicatedProcess)
			{
				return;
			}
			bool flag = false;
			bool flag2 = Input.GetKeyDown((KeyCode)13) || Input.GetKeyDown((KeyCode)271);
			if (Input.GetKeyDown((KeyCode)8) && _setupUsernameText.Length > 0)
			{
				string setupUsernameText = _setupUsernameText;
				_setupUsernameText = setupUsernameText.Substring(0, setupUsernameText.Length - 1);
				flag = true;
			}
			bool flag3 = Input.GetKey((KeyCode)304) || Input.GetKey((KeyCode)303);
			for (int i = 0; i < 26; i++)
			{
				if (_setupUsernameText.Length >= 18)
				{
					break;
				}
				if (Input.GetKeyDown((KeyCode)(97 + i)))
				{
					_setupUsernameText += (char)((flag3 ? 65 : 97) + i);
					flag = true;
				}
			}
			for (int j = 0; j < 10; j++)
			{
				if (_setupUsernameText.Length >= 18)
				{
					break;
				}
				if (Input.GetKeyDown((KeyCode)(48 + j)) || Input.GetKeyDown((KeyCode)(256 + j)))
				{
					_setupUsernameText += (char)(48 + j);
					flag = true;
				}
			}
			if (_setupUsernameText.Length < 18 && Input.GetKeyDown((KeyCode)45))
			{
				_setupUsernameText += (flag3 ? '_' : '-');
				flag = true;
			}
			if (flag && (Object)(object)_nativeSetupNameInput != (Object)null)
			{
				_nativeSetupNameInput.text = _setupUsernameText;
			}
			if (flag2)
			{
				CompleteIdentitySetupFromGui();
				RefreshNativeGameUi(syncInputs: true);
			}
		}

		private static bool ContainsScreenPoint(RectTransform? rect, Vector3 screenPosition)
		{
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			if ((Object)(object)rect == (Object)null)
			{
				return false;
			}
			Canvas componentInParent = ((Component)rect).GetComponentInParent<Canvas>();
			Camera val = (((Object)(object)componentInParent != (Object)null && (int)componentInParent.renderMode != 0) ? (componentInParent.worldCamera ?? Camera.main) : null);
			return RectTransformUtility.RectangleContainsScreenPoint(rect, Vector2.op_Implicit(screenPosition), val);
		}

		private GameObject CreateToggleRow(Transform parent, string name, string label, Vector2 size, Vector2 anchor, Vector2 anchoredPosition, out GameObject checkmark)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Expected O, but got Unknown
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0106: Unknown result type (might be due to invalid IL or missing references)
			//IL_010d: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			GameObject val = new GameObject(name);
			val.transform.SetParent(parent, false);
			RectTransform obj = val.AddComponent<RectTransform>();
			obj.anchorMin = anchor;
			obj.anchorMax = anchor;
			obj.pivot = anchor;
			obj.sizeDelta = size;
			obj.anchoredPosition = anchoredPosition;
			GameObject val2 = CreatePanel(val.transform, "Box", new Vector2(20f, 20f), new Vector2(0f, 0.5f), new Vector2(0f, 0f), new Color(0.1f, 0.11f, 0.13f, 0.98f));
			checkmark = CreatePanel(val2.transform, "Checkmark", new Vector2(12f, 12f), new Vector2(0.5f, 0.5f), Vector2.zero, new Color(0.26f, 0.58f, 0.9f, 1f));
			CreateText(val.transform, "Label", label, 14, (TextAnchor)3, new Vector2(size.x - 30f, size.y), new Vector2(0f, 0.5f), new Vector2(30f, 0f));
			return val;
		}

		private void ApplyNativeUiTextToEntries(bool validateOnly)
		{
			if ((Object)(object)_nativeHostInput != (Object)null)
			{
				_hostEntry.Value = NormalizeHost(_nativeHostInput.text);
			}
			if ((Object)(object)_nativeServerPortInput != (Object)null && int.TryParse(_nativeServerPortInput.text, out var result))
			{
				_serverPortText = result.ToString();
			}
			if ((Object)(object)_nativeLocalPortInput != (Object)null && int.TryParse(_nativeLocalPortInput.text, out var result2))
			{
				_localPortText = result2.ToString();
			}
			if (validateOnly)
			{
				RefreshNativeGameUi(syncInputs: false);
			}
		}

		private void ApplyNativeUiSettings()
		{
			ApplyNativeUiTextToEntries(validateOnly: false);
			ApplySettings(restartProxy: true, save: true);
			RefreshNativeGameUi(syncInputs: true);
		}

		private void RefreshNativeGameUi(bool syncInputs)
		{
			//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01de: Unknown result type (might be due to invalid IL or missing references)
			if ((Object)(object)_nativeUiRoot == (Object)null)
			{
				return;
			}
			if (syncInputs)
			{
				if ((Object)(object)_nativeHostInput != (Object)null)
				{
					_nativeHostInput.text = _hostEntry.Value;
				}
				if ((Object)(object)_nativeServerPortInput != (Object)null)
				{
					_nativeServerPortInput.text = _serverPortEntry.Value.ToString();
				}
				if ((Object)(object)_nativeLocalPortInput != (Object)null)
				{
					_nativeLocalPortInput.text = _localPortEntry.Value.ToString();
				}
				if ((Object)(object)_nativeSetupNameInput != (Object)null && _identitySetupRequired)
				{
					_nativeSetupNameInput.text = _setupUsernameText;
				}
				GameObject? nativeHttpsCheck = _nativeHttpsCheck;
				if (nativeHttpsCheck != null)
				{
					nativeHttpsCheck.SetActive(_httpsEntry.Value);
				}
				GameObject? nativeProxyCheck = _nativeProxyCheck;
				if (nativeProxyCheck != null)
				{
					nativeProxyCheck.SetActive(_localProxyEntry.Value);
				}
				GameObject? nativeStatusCheck = _nativeStatusCheck;
				if (nativeStatusCheck != null)
				{
					nativeStatusCheck.SetActive(_statusChipEntry.Value);
				}
			}
			string configuredApiHost = GetConfiguredApiHost();
			if ((Object)(object)_nativeChipText != (Object)null)
			{
				_nativeChipText.text = "Custom Server\n" + configuredApiHost;
			}
			if ((Object)(object)_nativeEndpointText != (Object)null)
			{
				_nativeEndpointText.text = "Active endpoint: " + configuredApiHost;
			}
			if ((Object)(object)_nativeStatusText != (Object)null)
			{
				_nativeStatusText.text = "Status: " + _statusText;
			}
			if ((Object)(object)_nativeSetupStatusText != (Object)null)
			{
				_nativeSetupStatusText.text = (string.IsNullOrWhiteSpace(_setupErrorText) ? "Delete AccountId or Username from the ini to show this setup again." : _setupErrorText);
				((Graphic)_nativeSetupStatusText).color = (string.IsNullOrWhiteSpace(_setupErrorText) ? new Color(0.78f, 0.82f, 0.88f, 1f) : new Color(1f, 0.58f, 0.42f, 1f));
			}
			GameObject? nativeSetupPanel = _nativeSetupPanel;
			if (nativeSetupPanel != null)
			{
				nativeSetupPanel.SetActive(_identitySetupRequired);
			}
			GameObject? nativeUiChip = _nativeUiChip;
			if (nativeUiChip == null)
			{
				goto IL_0253;
			}
			int active;
			if (!_identitySetupRequired)
			{
				MelonPreferences_Entry<bool> statusChipEntry = _statusChipEntry;
				if (statusChipEntry != null && statusChipEntry.Value)
				{
					active = ((!_nativeUiExpanded) ? 1 : 0);
					goto IL_024e;
				}
			}
			active = 0;
			goto IL_024e;
			IL_024e:
			nativeUiChip.SetActive((byte)active != 0);
			goto IL_0253;
			IL_0253:
			GameObject? nativeUiPanel = _nativeUiPanel;
			if (nativeUiPanel != null)
			{
				nativeUiPanel.SetActive(!_identitySetupRequired && _nativeUiExpanded);
			}
		}

		private void DestroyNativeGameUi()
		{
			if (!((Object)(object)_nativeUiRoot == (Object)null))
			{
				Object.Destroy((Object)(object)_nativeUiRoot);
				_nativeUiRoot = null;
				_nativeUiChip = null;
				_nativeUiPanel = null;
				_nativeSetupPanel = null;
				_nativeChipText = null;
				_nativeStatusText = null;
				_nativeEndpointText = null;
				_nativeSetupStatusText = null;
				_nativeChipRect = null;
				_nativeSetupContinueRect = null;
				_nativeApplyRect = null;
				_nativeCloseRect = null;
				_nativeDirectRect = null;
				_nativeProxyRect = null;
				_nativeHttpsRect = null;
				_nativeProxyToggleRect = null;
				_nativeStatusToggleRect = null;
				_nativeHttpsCheck = null;
				_nativeProxyCheck = null;
				_nativeStatusCheck = null;
				_nativeHostInput = null;
				_nativeServerPortInput = null;
				_nativeLocalPortInput = null;
				_nativeSetupNameInput = null;
			}
		}

		private static string LabeledTextField(string label, string value)
		{
			GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
			GUILayout.Label(label, (GUILayoutOption[])(object)new GUILayoutOption[1] { GUILayout.Width(92f) });
			string result = GUILayout.TextField(value ?? "", (GUILayoutOption[])(object)new GUILayoutOption[1] { GUILayout.MinWidth(220f) });
			GUILayout.EndHorizontal();
			return result;
		}

		private void ApplySettings(bool restartProxy, bool save)
		{
			bool flag = !int.TryParse(_serverPortText, out var result);
			if (!flag)
			{
				bool flag2 = ((result <= 0 || result > 65535) ? true : false);
				flag = flag2;
			}
			if (flag)
			{
				_statusText = "Invalid server port";
				return;
			}
			flag = !int.TryParse(_localPortText, out var result2);
			if (!flag)
			{
				bool flag2 = ((result2 <= 0 || result2 > 65535) ? true : false);
				flag = flag2;
			}
			if (flag)
			{
				_statusText = "Invalid local proxy port";
				return;
			}
			_serverPortEntry.Value = result;
			_localPortEntry.Value = result2;
			_hostEntry.Value = NormalizeHost(_hostEntry.Value);
			UpdateIdentitySetupRequirement("settings apply");
			if (save)
			{
				MelonPreferences.Save();
				SaveIniSettings();
			}
			Uri uri = BuildUpstreamUri();
			_lastAppliedApiHost = GetConfiguredApiHost();
			if (_localProxyEntry.Value)
			{
				if (result2 == result && IsLoopbackHost(uri.Host))
				{
					StopProxy();
					_statusText = "Proxy disabled: local port equals upstream server port";
					((MelonBase)this).LoggerInstance.Warning(_statusText);
					PatchLoadedNetworkConfigs();
					return;
				}
				if (restartProxy)
				{
					RestartProxy(result2, uri);
				}
			}
			else
			{
				StopProxy();
				_statusText = $"Direct mode -> {uri}";
			}
			PatchLoadedNetworkConfigs();
		}

		private static string ResolveIniPath(string[] args)
		{
			for (int i = 0; i < args.Length; i++)
			{
				if (TryGetArgValue(args[i], "--bapcustom-config=", out string value) && !string.IsNullOrWhiteSpace(value))
				{
					return Path.GetFullPath(Environment.ExpandEnvironmentVariables(value.Trim().Trim('"')));
				}
			}
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			if (!string.IsNullOrWhiteSpace(folderPath))
			{
				string text = Path.Combine(folderPath, "BAPBAPBATTLEROYALE", "BapCustomServer.ini");
				MigrateLegacyIniToAppData(text);
				return text;
			}
			return ResolveLegacyIniPath();
		}

		private static string ResolveLegacyIniPath()
		{
			string location = typeof(CustomServerMod).Assembly.Location;
			string text = (string.IsNullOrWhiteSpace(location) ? null : Path.GetDirectoryName(location));
			if (!string.IsNullOrWhiteSpace(text))
			{
				return Path.Combine(text, "BapCustomServer.ini");
			}
			return Path.Combine(Environment.CurrentDirectory, "Mods", "BapCustomServer.ini");
		}

		private static void MigrateLegacyIniToAppData(string appDataIniPath)
		{
			try
			{
				if (File.Exists(appDataIniPath))
				{
					return;
				}
				string text = ResolveLegacyIniPath();
				if (File.Exists(text))
				{
					string directoryName = Path.GetDirectoryName(appDataIniPath);
					if (!string.IsNullOrWhiteSpace(directoryName))
					{
						Directory.CreateDirectory(directoryName);
					}
					File.Copy(text, appDataIniPath, overwrite: false);
				}
			}
			catch
			{
			}
		}

		private void LoadIniSettings()
		{
			try
			{
				if (string.IsNullOrWhiteSpace(_iniPath))
				{
					return;
				}
				if (!File.Exists(_iniPath))
				{
					SaveIniSettings();
					((MelonBase)this).LoggerInstance.Msg("Created default custom server ini: " + _iniPath);
					return;
				}
				string section = "";
				string[] array = File.ReadAllLines(_iniPath, Encoding.UTF8);
				for (int i = 0; i < array.Length; i++)
				{
					string text = array[i].Trim();
					if (text.Length == 0 || text.StartsWith("#", StringComparison.Ordinal) || text.StartsWith(";", StringComparison.Ordinal))
					{
						continue;
					}
					if (text.StartsWith("[", StringComparison.Ordinal) && text.EndsWith("]", StringComparison.Ordinal))
					{
						string text2 = text;
						section = text2.Substring(1, text2.Length - 1 - 1).Trim();
						continue;
					}
					int num = text.IndexOf('=');
					if (num > 0)
					{
						string key = text.Substring(0, num).Trim();
						string text2 = text;
						int num2 = num + 1;
						string value = text2.Substring(num2, text2.Length - num2).Trim().Trim('"');
						ApplyIniValue(section, key, value);
					}
				}
				((MelonBase)this).LoggerInstance.Msg("Loaded custom server ini.");
			}
			catch (Exception ex)
			{
				((MelonBase)this).LoggerInstance.Warning("Failed to load custom server ini '" + _iniPath + "': " + ex.GetBaseException().Message);
			}
		}

		private void ApplyIniValue(string section, string key, string value)
		{
			string text = NormalizeIniToken(section);
			string text2 = NormalizeIniToken(key);
			if (((text != null && text.Length == 0) || text == "server" || text == "network") ? true : false)
			{
				switch (text2)
				{
				case "host":
				case "serverip":
				case "serverhost":
				case "ip":
					_hostEntry.Value = NormalizeHost(value);
					return;
				case "port":
				case "serverport":
				{
					if (int.TryParse(value, out var result3))
					{
						_serverPortEntry.Value = result3;
					}
					return;
				}
				case "usehttps":
				case "https":
				case "ssl":
				{
					if (TryParseBool(value, out var result4))
					{
						_httpsEntry.Value = result4;
					}
					return;
				}
				case "localproxy":
				case "proxy":
				case "uselocalproxy":
				{
					if (TryParseBool(value, out var result2))
					{
						_localProxyEntry.Value = result2;
					}
					return;
				}
				case "localport":
				case "proxyport":
				case "localproxyport":
				{
					if (int.TryParse(value, out var result))
					{
						_localPortEntry.Value = result;
					}
					return;
				}
				}
			}
			if (((text != null && text.Length == 0) || text == "identity" || text == "account") ? true : false)
			{
				switch (text2)
				{
				case "accountid":
				case "userid":
				case "id":
					_accountIdEntry.Value = value.Trim();
					return;
				case "username":
				case "name":
					_usernameEntry.Value = value.Trim();
					return;
				case "autologin":
				case "autoguestlogin":
				case "guestlogin":
				{
					if (TryParseBool(value, out var result5))
					{
						_autoGuestLoginEntry.Value = result5;
					}
					return;
				}
				}
			}
			if (((text == null || text.Length != 0) && !(text == "ui")) || 1 == 0)
			{
				return;
			}
			switch (text2)
			{
			case "showstatuschip":
			case "statuschip":
			{
				if (TryParseBool(value, out var result7))
				{
					_statusChipEntry.Value = result7;
				}
				break;
			}
			case "usenativegameui":
			case "nativeui":
			{
				if (TryParseBool(value, out var result6))
				{
					_nativeUiEntry.Value = result6;
				}
				break;
			}
			}
		}

		private void SaveIniSettings()
		{
			try
			{
				if (!string.IsNullOrWhiteSpace(_iniPath))
				{
					string directoryName = Path.GetDirectoryName(_iniPath);
					if (!string.IsNullOrWhiteSpace(directoryName))
					{
						Directory.CreateDirectory(directoryName);
					}
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.AppendLine("[Server]");
					StringBuilder stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder3 = stringBuilder2;
					StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(5, 1, stringBuilder2);
					handler.AppendLiteral("Host=");
					handler.AppendFormatted(NormalizeHost(_hostEntry.Value));
					stringBuilder3.AppendLine(ref handler);
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder4 = stringBuilder2;
					handler = new StringBuilder.AppendInterpolatedStringHandler(5, 1, stringBuilder2);
					handler.AppendLiteral("Port=");
					handler.AppendFormatted(_serverPortEntry.Value);
					stringBuilder4.AppendLine(ref handler);
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder5 = stringBuilder2;
					handler = new StringBuilder.AppendInterpolatedStringHandler(9, 1, stringBuilder2);
					handler.AppendLiteral("UseHttps=");
					handler.AppendFormatted(FormatBool(_httpsEntry.Value));
					stringBuilder5.AppendLine(ref handler);
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder6 = stringBuilder2;
					handler = new StringBuilder.AppendInterpolatedStringHandler(14, 1, stringBuilder2);
					handler.AppendLiteral("UseLocalProxy=");
					handler.AppendFormatted(FormatBool(_localProxyEntry.Value));
					stringBuilder6.AppendLine(ref handler);
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder7 = stringBuilder2;
					handler = new StringBuilder.AppendInterpolatedStringHandler(15, 1, stringBuilder2);
					handler.AppendLiteral("LocalProxyPort=");
					handler.AppendFormatted(_localPortEntry.Value);
					stringBuilder7.AppendLine(ref handler);
					stringBuilder.AppendLine();
					stringBuilder.AppendLine("[Identity]");
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder8 = stringBuilder2;
					handler = new StringBuilder.AppendInterpolatedStringHandler(10, 1, stringBuilder2);
					handler.AppendLiteral("AccountId=");
					handler.AppendFormatted(_accountIdEntry.Value.Trim());
					stringBuilder8.AppendLine(ref handler);
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder9 = stringBuilder2;
					handler = new StringBuilder.AppendInterpolatedStringHandler(9, 1, stringBuilder2);
					handler.AppendLiteral("Username=");
					handler.AppendFormatted(_usernameEntry.Value.Trim());
					stringBuilder9.AppendLine(ref handler);
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder10 = stringBuilder2;
					handler = new StringBuilder.AppendInterpolatedStringHandler(15, 1, stringBuilder2);
					handler.AppendLiteral("AutoGuestLogin=");
					handler.AppendFormatted(FormatBool(_autoGuestLoginEntry.Value));
					stringBuilder10.AppendLine(ref handler);
					File.WriteAllText(_iniPath, stringBuilder.ToString(), Encoding.UTF8);
				}
			}
			catch (Exception ex)
			{
				((MelonBase)this).LoggerInstance.Warning("Failed to save custom server ini '" + _iniPath + "': " + ex.GetBaseException().Message);
			}
		}

		private bool HasCompleteLocalIdentity()
		{
			if (!string.IsNullOrWhiteSpace(_accountIdEntry.Value))
			{
				return !string.IsNullOrWhiteSpace(_usernameEntry.Value);
			}
			return false;
		}

		private int GetDiscriminatorForHeaders()
		{
			return Math.Abs((_accountIdEntry?.Value?.Trim() ?? "").GetHashCode() % 9000) + 1000;
		}

		private void UpdateIdentitySetupRequirement(string reason)
		{
			if (_dedicatedProcess)
			{
				_identitySetupRequired = false;
				return;
			}
			if (HasCompleteLocalIdentity())
			{
				_identitySetupRequired = false;
				_setupUsernameText = _usernameEntry.Value.Trim();
				_setupErrorText = "";
				return;
			}
			_identitySetupRequired = true;
			_showWindow = false;
			_setupUsernameText = (string.IsNullOrWhiteSpace(_usernameEntry.Value) ? "" : _usernameEntry.Value.Trim());
			_statusText = "Waiting for player setup";
			ClearCustomServerLoginPrefs("identity setup required");
			if (!_identitySetupLogged)
			{
				_identitySetupLogged = true;
				((MelonBase)this).LoggerInstance.Msg("Custom server identity setup required after " + reason + "; AccountId and Username must both be present.");
			}
		}

		private void CompleteIdentitySetupFromGui(bool queueRelaunch = true)
		{
			if ((Object)(object)_nativeSetupNameInput != (Object)null && !string.IsNullOrWhiteSpace(_nativeSetupNameInput.text))
			{
				_setupUsernameText = _nativeSetupNameInput.text;
			}
			string text = NormalizePlayerName(_setupUsernameText);
			if (text.Length < 3)
			{
				_setupErrorText = "Use 3-18 letters, numbers, underscore, or dash.";
				RefreshNativeGameUi(syncInputs: false);
				return;
			}
			_usernameEntry.Value = text;
			_accountIdEntry.Value = GenerateLocalAccountId();
			_autoGuestLoginEntry.Value = true;
			_identitySetupRequired = false;
			_identitySetupLogged = false;
			_setupErrorText = "";
			_showWindow = false;
			MelonPreferences.Save();
			SaveIniSettings();
			ApplySettings(restartProxy: true, save: false);
			PrimeCustomServerLoginPrefs();
			_autoGuestLoginControllers.Clear();
			_splashGuestLoginInvoked = false;
			_splashGuestLoginScanLogged = false;
			_nextAutoGuestScanAt = 0f;
			TryAutoGuestLoginFromLoadedLoginControllers();
			TryAutoGuestLoginFromLoadedLobbyClients();
			TryInvokeSplashGuestLoginAction();
			if (queueRelaunch)
			{
				QueueIdentitySetupProcessRelaunch();
			}
			((MelonBase)this).LoggerInstance.Msg($"Created first-start custom-server identity: {text} ({_accountIdEntry.Value}).");
		}

		private void CompletePendingIdentitySetupFromCommandLine()
		{
			if (!_dedicatedProcess && _identitySetupRequired && !string.IsNullOrWhiteSpace(_pendingSetupUsername))
			{
				_setupUsernameText = _pendingSetupUsername;
				_pendingSetupUsername = null;
				CompleteIdentitySetupFromGui(queueRelaunch: false);
			}
		}

		private void QueueIdentitySetupProcessRelaunch()
		{
			if (!_dedicatedProcess && !_identitySetupProcessRelaunchQueued)
			{
				_identitySetupProcessRelaunchAt = Time.realtimeSinceStartup + 0.5f;
				_identitySetupProcessRelaunchQueued = true;
				((MelonBase)this).LoggerInstance.Msg("Queued game relaunch after first-start identity setup.");
			}
		}

		private void ProcessIdentitySetupProcessRelaunch()
		{
			if (!_identitySetupProcessRelaunchQueued || Time.realtimeSinceStartup < _identitySetupProcessRelaunchAt)
			{
				return;
			}
			_identitySetupProcessRelaunchQueued = false;
			try
			{
				string text = TryGetCurrentProcessPath();
				if (string.IsNullOrWhiteSpace(text) || !File.Exists(text))
				{
					((MelonBase)this).LoggerInstance.Warning("Could not relaunch game after first-start identity setup because the executable path was not found.");
					return;
				}
				string workingDirectory = Path.GetDirectoryName(text) ?? Directory.GetCurrentDirectory();
				string text2 = string.Join(" ", Environment.GetCommandLineArgs().Skip(1).Select(QuoteCommandArgument));
				string arguments = "/c ping 127.0.0.1 -n 3 > nul && start \"\" " + QuoteCommandArgument(text) + " " + text2;
				Process.Start(new ProcessStartInfo
				{
					FileName = "cmd.exe",
					Arguments = arguments,
					WorkingDirectory = workingDirectory,
					UseShellExecute = false,
					CreateNoWindow = true
				});
				((MelonBase)this).LoggerInstance.Msg("Relaunching game after first-start identity setup so the saved custom-server session is used during startup.");
				_quitGuardActive = false;
				Application.Quit();
			}
			catch (Exception ex)
			{
				((MelonBase)this).LoggerInstance.Warning("Failed to relaunch game after first-start identity setup: " + ex.GetBaseException().Message);
			}
		}

		private static string? TryGetCurrentProcessPath()
		{
			try
			{
				string text = Process.GetCurrentProcess().MainModule?.FileName;
				if (!string.IsNullOrWhiteSpace(text))
				{
					return text;
				}
			}
			catch
			{
			}
			string text2 = Application.dataPath ?? "";
			DirectoryInfo directoryInfo = (string.IsNullOrWhiteSpace(text2) ? null : Directory.GetParent(text2));
			if (directoryInfo == null)
			{
				return null;
			}
			string text3 = Path.Combine(directoryInfo.FullName, "bapbap.exe");
			if (!File.Exists(text3))
			{
				return null;
			}
			return text3;
		}

		private static string QuoteCommandArgument(string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				return "\"\"";
			}
			if (value.IndexOfAny(new char[8] { ' ', '\t', '"', '&', '(', ')', '^', '|' }) >= 0)
			{
				return "\"" + value.Replace("\"", "\\\"") + "\"";
			}
			return value;
		}

		private void ClearCustomServerLoginPrefs(string reason)
		{
			try
			{
				PlayerPrefs.DeleteKey("SESSION_ID");
				PlayerPrefs.SetInt("AUTO_LOGIN", 0);
				PlayerPrefs.Save();
				_primedLoginSessionId = null;
				((MelonBase)this).LoggerInstance.Msg("Cleared BAPBAP auto-login prefs because " + reason + ".");
			}
			catch (Exception ex)
			{
				((MelonBase)this).LoggerInstance.Warning("Failed to clear BAPBAP auto-login prefs: " + ex.GetBaseException().Message);
			}
		}

		private static string GenerateLocalAccountId()
		{
			return $"custom-{Guid.NewGuid():N}".Substring(0, 19);
		}

		private static string NormalizePlayerName(string value)
		{
			return new string((value ?? "").Where(delegate(char ch)
			{
				bool flag = char.IsLetterOrDigit(ch);
				if (!flag)
				{
					bool flag2 = ((ch == '-' || ch == '_') ? true : false);
					flag = flag2;
				}
				return flag;
			}).Take(18).ToArray());
		}

		private void PrimeCustomServerLoginPrefs()
		{
			if (_dedicatedProcess)
			{
				return;
			}
			MelonPreferences_Entry<bool> autoGuestLoginEntry = _autoGuestLoginEntry;
			if (autoGuestLoginEntry == null || !autoGuestLoginEntry.Value)
			{
				return;
			}
			string text = _accountIdEntry.Value.Trim();
			if (string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(_usernameEntry.Value))
			{
				UpdateIdentitySetupRequirement("login priming");
				return;
			}
			string text2 = "bapcustom-" + text;
			if (string.Equals(_primedLoginSessionId, text2, StringComparison.Ordinal))
			{
				return;
			}
			try
			{
				PlayerPrefs.SetString("SESSION_ID", text2);
				PlayerPrefs.SetInt("AUTO_LOGIN", 1);
				PlayerPrefs.Save();
				_primedLoginSessionId = text2;
				((MelonBase)this).LoggerInstance.Msg("Primed auto-login prefs for custom server session.");
			}
			catch (Exception ex)
			{
				((MelonBase)this).LoggerInstance.Warning("Failed to prime BAPBAP auto-login prefs: " + ex.GetBaseException().Message);
			}
		}

		private static string NormalizeIniToken(string value)
		{
			return new string((value ?? "").Where(char.IsLetterOrDigit).Select(char.ToLowerInvariant).ToArray());
		}

		private static string FormatBool(bool value)
		{
			if (!value)
			{
				return "false";
			}
			return "true";
		}

		private void ApplyCommandLineOverrides(string[] args)
		{
			bool flag = false;
			foreach (string text in args)
			{
				string value2;
				int result;
				string value3;
				int result2;
				string value4;
				bool result3;
				string value5;
				bool result4;
				string value6;
				bool result5;
				string value7;
				string value8;
				string value9;
				string value10;
				bool result6;
				string value11;
				string value12;
				string value13;
				int result7;
				string value14;
				int result8;
				string value15;
				int result9;
				string value16;
				float result10;
				string value17;
				int result11;
				string value18;
				int result12;
				string value19;
				int result13;
				string value20;
				int result14;
				if (TryGetArgValue(text, "--bapcustom-host=", out string value))
				{
					_hostEntry.Value = NormalizeHost(value);
				}
				else if (TryGetArgValue(text, "--bapcustom-server-port=", out value2) && int.TryParse(value2, out result))
				{
					_serverPortEntry.Value = result;
				}
				else if (TryGetArgValue(text, "--bapcustom-local-port=", out value3) && int.TryParse(value3, out result2))
				{
					_localPortEntry.Value = result2;
				}
				else if (TryGetArgValue(text, "--bapcustom-use-https=", out value4) && value4 != null && TryParseBool(value4, out result3))
				{
					_httpsEntry.Value = result3;
				}
				else if (TryGetArgValue(text, "--bapcustom-use-proxy=", out value5) && value5 != null && TryParseBool(value5, out result4))
				{
					_localProxyEntry.Value = result4;
					flag = true;
				}
				else if (TryGetArgValue(text, "--bapcustom-show-ui=", out value6) && value6 != null && TryParseBool(value6, out result5))
				{
					_uiEnabled = result5;
					_showWindow = result5;
					if (!result5 && _statusChipEntry != null)
					{
						_statusChipEntry.Value = false;
					}
				}
				else if (TryGetArgValue(text, "--bapcustom-account-id=", out value7))
				{
					_accountIdEntry.Value = (string.IsNullOrWhiteSpace(value7) ? "" : value7.Trim());
				}
				else if (TryGetArgValue(text, "--bapcustom-username=", out value8))
				{
					_usernameEntry.Value = (string.IsNullOrWhiteSpace(value8) ? "" : value8.Trim());
				}
				else if (TryGetArgValue(text, "--bapcustom-setup-username=", out value9))
				{
					_pendingSetupUsername = (string.IsNullOrWhiteSpace(value9) ? null : value9.Trim());
				}
				else if (TryGetArgValue(text, "--bapcustom-auto-login=", out value10) && value10 != null && TryParseBool(value10, out result6))
				{
					_autoGuestLoginEntry.Value = result6;
				}
				else if (TryGetArgValue(text, "--bapcustom-join-auth=", out value11))
				{
					_autoJoinGameAuthId = (string.IsNullOrWhiteSpace(value11) ? null : value11.Trim());
				}
				else if (TryGetArgValue(text, "--bapcustom-join-host=", out value12))
				{
					_autoJoinHost = NormalizeHost(value12);
				}
				else if (TryGetArgValue(text, "--bapcustom-join-ws=", out value13) && int.TryParse(value13, out result7))
				{
					_autoJoinWsPort = result7;
				}
				else if (TryGetArgValue(text, "--bapcustom-join-kcp=", out value14) && int.TryParse(value14, out result8))
				{
					_autoJoinKcpPort = result8;
				}
				else if (TryGetArgValue(text, "--bapcustom-join-tcp=", out value15) && int.TryParse(value15, out result9))
				{
					_autoJoinTcpPort = result9;
				}
				else if (TryGetArgValue(text, "--bapcustom-auto-end-after=", out value16) && float.TryParse(value16, out result10) && result10 > 0f)
				{
					_autoEndAfterSeconds = result10;
				}
				else if (text.Equals("--bapcustom-autoplay", StringComparison.OrdinalIgnoreCase))
				{
					_autoplayEnabled = true;
				}
				else if ((TryGetArgValue(text, "-httpport=", out value17) || TryGetArgValue(text, "--httpport=", out value17)) && int.TryParse(value17, out result11))
				{
					_dedicatedHttpPort = result11;
					_dedicatedProcess = true;
				}
				else if ((TryGetArgValue(text, "-wsport=", out value18) || TryGetArgValue(text, "--wsport=", out value18)) && int.TryParse(value18, out result12))
				{
					_dedicatedWsPort = result12;
					_dedicatedProcess = true;
				}
				else if ((TryGetArgValue(text, "-kcpport=", out value19) || TryGetArgValue(text, "--kcpport=", out value19)) && int.TryParse(value19, out result13))
				{
					_dedicatedKcpPort = result13;
					_dedicatedProcess = true;
				}
				else if ((TryGetArgValue(text, "-tcpport=", out value20) || TryGetArgValue(text, "--tcpport=", out value20)) && int.TryParse(value20, out result14))
				{
					_dedicatedTcpPort = result14;
					_dedicatedProcess = true;
				}
			}
			if (!flag && IsDedicatedGameServerProcess(args))
			{
				_localProxyEntry.Value = false;
				_dedicatedProcess = true;
				_uiEnabled = false;
				_showWindow = false;
				if (_statusChipEntry != null)
				{
					_statusChipEntry.Value = false;
				}
			}
			try
			{
				if (!_dedicatedProcess && Application.isBatchMode)
				{
					_localProxyEntry.Value = false;
					_dedicatedProcess = true;
					_uiEnabled = false;
					_showWindow = false;
					if (_statusChipEntry != null)
					{
						_statusChipEntry.Value = false;
					}
					((MelonBase)this).LoggerInstance.Msg("[BatchMode] Application.isBatchMode=true -> skipping local proxy, native UI, identity setup, and client-only mod features");
				}
			}
			catch (Exception ex)
			{
				((MelonBase)this).LoggerInstance.Warning("BatchMode detection failed: " + ex.Message);
			}
			if (_dedicatedProcess)
			{
				try
				{
					Application.targetFrameRate = 240;
					QualitySettings.vSyncCount = 0;
					((MelonBase)this).LoggerInstance.Msg("[Perf] Dedicated server: targetFrameRate=240, vSync=0 (kept default fixedDeltaTime)");
					return;
				}
				catch (Exception ex2)
				{
					((MelonBase)this).LoggerInstance.Warning("Perf settings failed: " + ex2.Message);
					return;
				}
			}
			try
			{
				Application.targetFrameRate = 144;
				QualitySettings.vSyncCount = 0;
				((MelonBase)this).LoggerInstance.Msg("[Perf] Client: targetFrameRate=144, vSync=0 (reduce DWM stall stutter)");
			}
			catch
			{
			}
		}

		private static bool IsDedicatedGameServerProcess(IEnumerable<string> args)
		{
			return args.Any((string arg) => arg.StartsWith("-httpport=", StringComparison.OrdinalIgnoreCase) || arg.StartsWith("--httpport=", StringComparison.OrdinalIgnoreCase) || arg.StartsWith("-wsport=", StringComparison.OrdinalIgnoreCase) || arg.StartsWith("--wsport=", StringComparison.OrdinalIgnoreCase) || arg.StartsWith("-kcpport=", StringComparison.OrdinalIgnoreCase) || arg.StartsWith("--kcpport=", StringComparison.OrdinalIgnoreCase) || arg.StartsWith("-tcpport=", StringComparison.OrdinalIgnoreCase) || arg.StartsWith("--tcpport=", StringComparison.OrdinalIgnoreCase));
		}

		private static bool TryGetArgValue(string arg, string prefix, out string? value)
		{
			if (arg.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
			{
				int length = prefix.Length;
				value = arg.Substring(length, arg.Length - length).Trim();
				return true;
			}
			value = null;
			return false;
		}

		private static bool TryParseBool(string value, out bool result)
		{
			value = (value ?? "").Trim();
			if (bool.TryParse(value, out result))
			{
				return true;
			}
			string text = value.ToLowerInvariant();
			bool flag;
			switch (text)
			{
			case "1":
			case "yes":
			case "y":
			case "on":
			case "enabled":
				flag = true;
				break;
			default:
				flag = false;
				break;
			}
			if (flag)
			{
				result = true;
				return true;
			}
			switch (text)
			{
			case "0":
			case "no":
			case "n":
			case "off":
			case "disabled":
				flag = true;
				break;
			default:
				flag = false;
				break;
			}
			if (flag)
			{
				result = false;
				return true;
			}
			return false;
		}

		private string GetConfiguredApiHost()
		{
			MelonPreferences_Entry<bool> localProxyEntry = _localProxyEntry;
			if (localProxyEntry != null && localProxyEntry.Value)
			{
				return $"http://127.0.0.1:{_localPortEntry.Value}";
			}
			return BuildUpstreamUri().ToString().TrimEnd('/');
		}

		private Uri BuildUpstreamUri()
		{
			string scheme = (_httpsEntry.Value ? Uri.UriSchemeHttps : Uri.UriSchemeHttp);
			string host = NormalizeHost(_hostEntry.Value);
			return new UriBuilder(scheme, host, _serverPortEntry.Value).Uri;
		}

		private static string NormalizeHost(string? host)
		{
			host = (host ?? "").Trim();
			if ((host.StartsWith("http://", StringComparison.OrdinalIgnoreCase) || host.StartsWith("https://", StringComparison.OrdinalIgnoreCase)) && Uri.TryCreate(host, UriKind.Absolute, out Uri result))
			{
				return result.Host;
			}
			if (!string.IsNullOrWhiteSpace(host))
			{
				return host;
			}
			return "127.0.0.1";
		}

		private static bool IsLoopbackHost(string host)
		{
			if (!string.Equals(host, "localhost", StringComparison.OrdinalIgnoreCase) && !string.Equals(host, "127.0.0.1", StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(host, "::1", StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		private void RestartProxy(int localPort, Uri upstream)
		{
			if (_dedicatedProcess || Application.isBatchMode)
			{
				return;
			}
			StopProxy();
			try
			{
				_proxy = new LocalReverseProxy(localPort, upstream, () => (AccountId: _accountIdEntry?.Value?.Trim() ?? "", Username: _usernameEntry?.Value?.Trim() ?? "", Discriminator: GetDiscriminatorForHeaders().ToString()), delegate(string message)
				{
					((MelonBase)this).LoggerInstance.Msg(message);
				}, delegate(string message)
				{
					((MelonBase)this).LoggerInstance.Warning(message);
				}, delegate(string message)
				{
					((MelonBase)this).LoggerInstance.Error(message);
				});
				_proxy.Start();
				_statusText = $"Proxy 127.0.0.1:{localPort} -> {upstream}";
			}
			catch (Exception ex)
			{
				_proxy = null;
				_statusText = "Proxy failed: " + ex.Message;
				((MelonBase)this).LoggerInstance.Error($"Failed to start local proxy: {ex}");
			}
		}

		private void StopProxy()
		{
			try
			{
				_proxy?.Dispose();
			}
			catch (Exception ex)
			{
				((MelonBase)this).LoggerInstance.Warning("Failed to stop local proxy cleanly: " + ex.Message);
			}
			finally
			{
				_proxy = null;
			}
		}

		private void TryInstallNetworkConfigPatches()
		{
			if (_patchesInstalled)
			{
				return;
			}
			Type type = FindType("BAPBAP.Network.NetworkConfig");
			if (type == null)
			{
				return;
			}
			MethodInfo method = typeof(CustomServerMod).GetMethod("NetworkConfigClientPostfix", BindingFlags.Static | BindingFlags.NonPublic);
			MethodInfo method2 = typeof(CustomServerMod).GetMethod("NetworkConfigServerPostfix", BindingFlags.Static | BindingFlags.NonPublic);
			if (method == null || method2 == null)
			{
				return;
			}
			int num = 0;
			try
			{
				MethodInfo methodInfo = type.GetProperty("Client", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)?.GetGetMethod(nonPublic: true);
				if (methodInfo != null && PatchHarmonyPostfix(methodInfo, method))
				{
					num++;
				}
				MethodInfo method3 = type.GetMethod("GetClient", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				if (method3 != null && PatchHarmonyPostfix(method3, method))
				{
					num++;
				}
				MethodInfo methodInfo2 = type.GetProperty("Server", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)?.GetGetMethod(nonPublic: true);
				if (methodInfo2 != null && PatchHarmonyPostfix(methodInfo2, method2))
				{
					num++;
				}
				MethodInfo method4 = type.GetMethod("GetServer", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				if (method4 != null && PatchHarmonyPostfix(method4, method2))
				{
					num++;
				}
				_patchesInstalled = num > 0;
				if (_patchesInstalled)
				{
					((MelonBase)this).LoggerInstance.Msg($"Installed {num} NetworkConfig runtime patch(es).");
				}
			}
			catch (Exception ex)
			{
				((MelonBase)this).LoggerInstance.Warning("NetworkConfig Harmony patch was not installed: " + ex.Message);
			}
		}

		private void TryInstallGameModePatches()
		{
			if (_gameModePatchesInstalled)
			{
				return;
			}
			Type type = FindType("BAPBAP.Game.GameMode");
			if (type == null)
			{
				return;
			}
			MethodInfo method = typeof(CustomServerMod).GetMethod("GameModeLevelNamesPrefix", BindingFlags.Static | BindingFlags.NonPublic);
			if (method == null)
			{
				return;
			}
			int num = 0;
			try
			{
				string[] array = new string[3] { "Load", "LoadCoroutine", "GetMapDataMMCacheByLevelId" };
				foreach (string name in array)
				{
					MethodInfo method2 = type.GetMethod(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					if (method2 != null && PatchHarmonyPrefix(method2, method))
					{
						num++;
					}
				}
				_gameModePatchesInstalled = num > 0;
				if (_gameModePatchesInstalled)
				{
					((MelonBase)this).LoggerInstance.Msg($"Installed {num} GameMode level-name runtime patch(es).");
				}
			}
			catch (Exception ex)
			{
				((MelonBase)this).LoggerInstance.Warning("GameMode Harmony patch was not installed: " + ex.GetBaseException().Message);
			}
		}

		private void TryInstallJoinDiagnosticsPatches()
		{
			if (_joinDiagnosticsPatchesInstalled)
			{
				return;
			}
			Type type = FindType("BAPBAP.Game.GameManager");
			if (type == null)
			{
				return;
			}
			MethodInfo method = typeof(CustomServerMod).GetMethod("AddPlayerMatchmakingPrefix", BindingFlags.Static | BindingFlags.NonPublic);
			MethodInfo method2 = type.GetMethod("AddPlayerMatchmaking", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (method == null || method2 == null)
			{
				return;
			}
			try
			{
				if (PatchHarmonyPrefix(method2, method))
				{
					_joinDiagnosticsPatchesInstalled = true;
					((MelonBase)this).LoggerInstance.Msg("Installed AddPlayerMatchmaking runtime diagnostic patch.");
				}
			}
			catch (Exception ex)
			{
				((MelonBase)this).LoggerInstance.Warning("AddPlayerMatchmaking diagnostic patch was not installed: " + ex.GetBaseException().Message);
			}
		}

		private void TryInstallLoginControllerPatches()
		{
			if (_loginControllerPatchesInstalled)
			{
				return;
			}
			Type type = FindType("BAPBAP.UI.LoginController");
			if (type == null)
			{
				return;
			}
			MethodInfo method = typeof(CustomServerMod).GetMethod("LoginControllerAutoGuestPostfix", BindingFlags.Static | BindingFlags.NonPublic);
			MethodInfo method2 = typeof(CustomServerMod).GetMethod("LoginControllerHandleLoadResponsePostfix", BindingFlags.Static | BindingFlags.NonPublic);
			string[] array = new string[6] { "StartLoginFlow", "HandleOpenLoginWindow", "LoginSteam", "LoginDiscord", "LoginGoogle", "LoginFacebook" };
			int num = 0;
			try
			{
				if (method != null)
				{
					string[] array2 = array;
					foreach (string name in array2)
					{
						MethodInfo method3 = type.GetMethod(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
						if (method3 != null && PatchHarmonyPostfix(method3, method))
						{
							num++;
						}
					}
				}
				MethodInfo methodInfo = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).FirstOrDefault((MethodInfo methodInfo2) => !(methodInfo2.Name != "HandleLoadResponse") && methodInfo2.GetParameters().Length == 1);
				if (methodInfo != null && method2 != null && PatchHarmonyPostfix(methodInfo, method2))
				{
					num++;
				}
				_loginControllerPatchesInstalled = num > 0;
				if (_loginControllerPatchesInstalled)
				{
					((MelonBase)this).LoggerInstance.Msg($"Installed {num} LoginController custom guest-login patch(es).");
				}
			}
			catch (Exception ex)
			{
				((MelonBase)this).LoggerInstance.Warning("LoginController custom guest-login patch was not installed: " + ex.GetBaseException().Message);
			}
		}

		private void TryInstallCharacterSelectNullRefPatch()
		{
			if (_characterSelectPatchInstalled)
			{
				return;
			}
			Type type = FindType("BAPBAP.UI.UILobbyPlayTabPage");
			if (type == null)
			{
				return;
			}
			try
			{
				Type type2 = FindType("BAPBAP.UI.UILobbyCharacterSelectPage");
				Type type3 = FindType("BAPBAP.UI.UILobbyMatchCharacterSelectPage");
				typeof(CustomServerMod).GetMethod("CharacterSelectPrefix", BindingFlags.Static | BindingFlags.NonPublic);
				int num = 0;
				string[] array;
				if (type2 != null)
				{
					MethodInfo method = typeof(CustomServerMod).GetMethod("CustomServerNullRefFinalizer", BindingFlags.Static | BindingFlags.NonPublic);
					array = new string[14]
					{
						"UpdateData", "Initialise", "UpdateAvailableCharactersData", "SetCharacterButtonState", "UpdateCharacterIconButtonsState", "SetCurrentCharTokenProgressUI", "SelectCharIconButton", "OpenCharSelectPanel", "CloseCharSelectPanel", "TryUpdateCharMasteryBadge",
						"UpdateCharTokenPassXp", "TryUpdateKeyBinds", "UpdateCharRotation", "UpdateDataUnlockCharacter"
					};
					foreach (string methodName in array)
					{
						foreach (MethodInfo item in from m in type2.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
							where m.Name == methodName
							select m)
						{
							if (method != null && PatchHarmonyFinalizer(item, method))
							{
								num++;
							}
						}
					}
					MethodInfo method2 = typeof(CustomServerMod).GetMethod("UnconditionalSkipPrefix", BindingFlags.Static | BindingFlags.NonPublic);
					MethodInfo methodInfo = type2.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).FirstOrDefault((MethodInfo m) => m.Name == "TrySetSelectedCharMasteryButtonNotification");
					if (methodInfo != null && method2 != null && PatchHarmonyPrefix(methodInfo, method2))
					{
						num++;
					}
					MethodInfo methodInfo2 = type2.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).FirstOrDefault((MethodInfo m) => m.Name == "GetCharacterListingIndexFromCharId");
					MethodInfo method3 = typeof(CustomServerMod).GetMethod("GetCharacterListingIndexFromCharIdPrefix", BindingFlags.Static | BindingFlags.NonPublic);
					if (methodInfo2 != null && method3 != null && PatchHarmonyPrefix(methodInfo2, method3))
					{
						num++;
					}
				}
				if (type3 != null)
				{
					string[] array2 = new string[16]
					{
						"UpdateData", "UpdateAvailableCharactersData", "SetPlayTabData", "UpdateLocalPlayer", "UpdateCharacterIconButtonsState", "UpdateLockButtonState", "UpdateEquipButtonState", "UpdateGameModifiers", "UpdateDimensions", "SetCountdownSeconds",
						"UpdateMatchStartData", "UpdateMatchmakingCharacter", "UpdateMatchmakingLockedStatus", "UpdateMatchmakingSpawnSelected", "UpdateMatchmakingFinalSpawnPoints", "UpdateMatchmakingTransitionToSpawnSelect"
					};
					typeof(CustomServerMod).GetMethod("MatchCharacterSelectPrefix", BindingFlags.Static | BindingFlags.NonPublic);
					MethodInfo method4 = typeof(CustomServerMod).GetMethod("CustomServerNullRefFinalizer", BindingFlags.Static | BindingFlags.NonPublic);
					if (method4 != null)
					{
						array = array2;
						foreach (string methodName2 in array)
						{
							foreach (MethodInfo item2 in from m in type3.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
								where m.Name == methodName2
								select m)
							{
								if (PatchHarmonyFinalizer(item2, method4))
								{
									num++;
								}
							}
						}
					}
					typeof(CustomServerMod).GetMethod("PlayPlayerCharChangeAnimPrefix", BindingFlags.Static | BindingFlags.NonPublic);
					MethodInfo method5 = typeof(CustomServerMod).GetMethod("CustomServerNullRefFinalizer", BindingFlags.Static | BindingFlags.NonPublic);
					foreach (MethodInfo item3 in from m in type3.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
						where m.Name == "PlayPlayerCharChangeAnim"
						select m)
					{
						if (method5 != null && PatchHarmonyFinalizer(item3, method5))
						{
							num++;
						}
					}
				}
				if (num > 0)
				{
					_characterSelectPatchInstalled = true;
					((MelonBase)this).LoggerInstance.Msg($"Installed {num} character-select NullRef guard prefix patch(es).");
				}
				if (type2 != null)
				{
					MethodInfo method6 = typeof(CustomServerMod).GetMethod("PopulateCharIdsBeforeBuildPrefix", BindingFlags.Static | BindingFlags.NonPublic);
					if (method6 != null)
					{
						string[] obj = new string[5] { "Build", "Initialise", "UpdateData", "UpdateAvailableCharactersData", "OpenCharSelectPanel" };
						int num2 = 0;
						array = obj;
						foreach (string methodName3 in array)
						{
							foreach (MethodInfo item4 in from m in type2.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
								where m.Name == methodName3
								select m)
							{
								if (PatchHarmonyPrefix(item4, method6))
								{
									num2++;
								}
							}
						}
						if (num2 > 0)
						{
							((MelonBase)this).LoggerInstance.Msg($"Installed {num2} PopulateCharIdsBeforeBuild prefix(es) on UILobbyCharacterSelectPage.");
						}
					}
				}
				if (!(type != null))
				{
					return;
				}
				MethodInfo method7 = typeof(CustomServerMod).GetMethod("PopulateCharIdsBeforeBuildPrefix", BindingFlags.Static | BindingFlags.NonPublic);
				if (!(method7 != null))
				{
					return;
				}
				string[] obj2 = new string[3] { "Build", "Initialise", "UpdateData" };
				int num3 = 0;
				array = obj2;
				foreach (string methodName4 in array)
				{
					foreach (MethodInfo item5 in from m in type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
						where m.Name == methodName4
						select m)
					{
						if (PatchHarmonyPrefix(item5, method7))
						{
							num3++;
						}
					}
				}
				if (num3 > 0)
				{
					((MelonBase)this).LoggerInstance.Msg($"Installed {num3} PopulateCharIdsBeforeBuild prefix(es) on UILobbyPlayTabPage.");
				}
			}
			catch (Exception ex)
			{
				((MelonBase)this).LoggerInstance.Warning("CharacterSelectPage NullRef prefix patch failed: " + ex.GetBaseException().Message);
			}
		}

		private void TryInstallLobbyControllerGuardPatches()
		{
			if (_lobbyControllerGuardPatchesInstalled)
			{
				return;
			}
			Type type = FindType("BAPBAP.UI.LobbyController");
			if (type == null)
			{
				return;
			}
			MethodInfo method = typeof(CustomServerMod).GetMethod("CustomServerNullRefFinalizer", BindingFlags.Static | BindingFlags.NonPublic);
			if (method == null)
			{
				return;
			}
			try
			{
				int num = 0;
				string[] array = new string[13]
				{
					"HandleLobbyJoinedMessage", "HandleJoinLobbySuccessMessage", "HandleLeaveLobbyMessage", "HandleLobbyUpdateMessage", "HandleCustomGameSettingsMessage", "HandleGameStartedMessage", "HandleStartCustomGameSuccessMessage", "HandlePlayerLeftMessage", "HandlePlayerJoinedMessage", "HandleUpdateGameModesMessage",
					"HandleUpdateMatchmakingMessage", "HandleQueueMatchedMessage", "HandlePlayerProfileUpdatedMessage"
				};
				foreach (string targetName in array)
				{
					foreach (MethodInfo item in from m in type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
						where m.Name == targetName
						select m)
					{
						if (PatchHarmonyFinalizer(item, method))
						{
							num++;
						}
					}
				}
				string[] array2 = new string[8] { "BAPBAP.UI.UILobby", "BAPBAP.UI.UILobbyCharacterCustomizePage", "BAPBAP.UI.UILobbyMatchCharacterSelectPage", "BAPBAP.UI.UILobbyCharacterSelectPage", "BAPBAP.UI.UILobbyPlayTabPage", "BAPBAP.UI.UILobbyMastery", "BAPBAP.UI.UILobbyShopTabPage", "BAPBAP.UI.LobbyController" };
				string[] array3 = new string[16]
				{
					"Initialise", "Initialize", "UpdateData", "UpdateTabNotification", "TrySetSelectedCharMasteryButtonNotification", "PlayPlayerCharChangeAnim", "CharacterIsUnlocked", "GetCharacterListingIndexFromCharId", "SetCharacterButtonState", "UpdateCharacterIconButtonsState",
					"UpdateAvailableCharactersData", "UpdateLocalPlayer", "Build", "OnEnable", "Refresh", "RefreshState"
				};
				array = array2;
				for (int i = 0; i < array.Length; i++)
				{
					Type type2 = FindType(array[i]);
					if (type2 == null)
					{
						continue;
					}
					string[] array4 = array3;
					foreach (string targetName2 in array4)
					{
						foreach (MethodInfo item2 in from m in type2.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
							where m.Name == targetName2
							select m)
						{
							if (PatchHarmonyFinalizer(item2, method))
							{
								num++;
							}
						}
					}
				}
				_lobbyControllerGuardPatchesInstalled = num > 0;
				if (_lobbyControllerGuardPatchesInstalled)
				{
					((MelonBase)this).LoggerInstance.Msg($"Installed {num} LobbyController NullRef guard finalizer patch(es).");
				}
			}
			catch (Exception ex)
			{
				((MelonBase)this).LoggerInstance.Warning("LobbyController NullRef guard patch failed: " + ex.GetBaseException().Message);
			}
		}

		private void TryInstallCharacterUnlockPatches()
		{
			if (_characterUnlockPatchesInstalled)
			{
				return;
			}
			MethodInfo method = typeof(CustomServerMod).GetMethod("CharacterIsUnlockedPrefix", BindingFlags.Static | BindingFlags.NonPublic);
			if (method == null)
			{
				return;
			}
			try
			{
				int num = 0;
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				foreach (Assembly assembly in assemblies)
				{
					Type[] array;
					try
					{
						array = assembly.GetTypes();
					}
					catch (ReflectionTypeLoadException ex)
					{
						array = ex.Types.Where((Type t) => t != null).Cast<Type>().ToArray();
					}
					catch
					{
						continue;
					}
					Type[] array2 = array;
					for (int num2 = 0; num2 < array2.Length; num2++)
					{
						MethodInfo[] methods = array2[num2].GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
						foreach (MethodInfo methodInfo in methods)
						{
							if (!(methodInfo.Name != "CharacterIsUnlocked") && !(methodInfo.ReturnType != typeof(bool)))
							{
								ParameterInfo[] parameters = methodInfo.GetParameters();
								if (parameters.Length == 1 && !(parameters[0].ParameterType != typeof(int)) && PatchHarmonyPrefix(methodInfo, method))
								{
									num++;
								}
							}
						}
					}
				}
				_characterUnlockPatchesInstalled = num > 0;
				if (_characterUnlockPatchesInstalled)
				{
					((MelonBase)this).LoggerInstance.Msg($"Installed {num} CharacterIsUnlocked force-unlock patch(es).");
				}
			}
			catch (Exception ex2)
			{
				((MelonBase)this).LoggerInstance.Warning("Character unlock patch failed: " + ex2.GetBaseException().Message);
			}
		}

		private void TryFixCharactersConfigurationCrash()
		{
			Type type = FindType("BAPBAP.UI.UICharactersConfiguration");
			if (type == null)
			{
				return;
			}
			try
			{
				int[] allCharIds = Enumerable.Range(0, 15).ToArray();
				int updated = 0;
				Array array = FindLoadedUnityObjects(type);
				if (array != null && array.Length > 0)
				{
					foreach (object item in array)
					{
						if (item != null)
						{
							PopulateCharIdsOnInstance(item, type, allCharIds, ref updated);
						}
					}
				}
				if (updated == 0)
				{
					Type type2 = FindType("BAPBAP.UI.UIManager");
					if (type2 != null)
					{
						Array array2 = FindLoadedUnityObjects(type2);
						if (!_charConfigDiagLogged && array2 != null && array2.Length > 0)
						{
							_charConfigDiagLogged = true;
							((MelonBase)this).LoggerInstance.Msg($"[CharConfig] Found {array2.Length} UIManager instance(s). Searching for characterConfig field...");
							FieldInfo[] fields = type2.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
							foreach (FieldInfo fieldInfo in fields)
							{
								if (fieldInfo.Name.Contains("haracter", StringComparison.OrdinalIgnoreCase) || fieldInfo.Name.Contains("config", StringComparison.OrdinalIgnoreCase))
								{
									((MelonBase)this).LoggerInstance.Msg($"  UIManager field: {fieldInfo.Name} ({fieldInfo.FieldType.Name})");
								}
							}
						}
						if (array2 != null)
						{
							FieldInfo field = type2.GetField("characterConfig", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
							if (field == null)
							{
								field = type2.GetField("_characterConfig", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
							}
							foreach (object item2 in array2)
							{
								if (item2 == null)
								{
									continue;
								}
								object obj = field?.GetValue(item2);
								if (obj != null)
								{
									PopulateCharIdsOnInstance(obj, type, allCharIds, ref updated);
									if (!_charConfigViaUiManagerLogged)
									{
										_charConfigViaUiManagerLogged = true;
										((MelonBase)this).LoggerInstance.Msg("[CharConfig] Found UICharactersConfiguration via UIManager.characterConfig field.");
									}
								}
							}
						}
					}
				}
				if (updated == 0)
				{
					Type type3 = FindType("BAPBAP.UI.UILobbyCharacterSelectPage");
					if (type3 != null)
					{
						Array array3 = FindLoadedUnityObjects(type3);
						if (array3 != null)
						{
							foreach (object item3 in array3)
							{
								if (item3 == null)
								{
									continue;
								}
								FieldInfo[] fields = type3.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
								foreach (FieldInfo fieldInfo2 in fields)
								{
									if (!(fieldInfo2.FieldType == type) && !fieldInfo2.FieldType.IsAssignableFrom(type) && !type.IsAssignableFrom(fieldInfo2.FieldType))
									{
										continue;
									}
									try
									{
										object value = fieldInfo2.GetValue(item3);
										if (value != null)
										{
											PopulateCharIdsOnInstance(value, type, allCharIds, ref updated);
										}
									}
									catch
									{
									}
								}
							}
						}
					}
				}
				if (updated == 0)
				{
					try
					{
						PropertyInfo property = type.GetProperty("Il2CppType", BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
						if (property != null)
						{
							object value2 = property.GetValue(null);
							if (value2 != null)
							{
								MethodInfo method = typeof(Resources).GetMethod("FindObjectsOfTypeAll", new Type[1] { value2.GetType() });
								if (method != null && method.Invoke(null, new object[1] { value2 }) is Array { Length: >0 } array4)
								{
									foreach (object item4 in array4)
									{
										if (item4 != null)
										{
											PopulateCharIdsOnInstance(item4, type, allCharIds, ref updated);
										}
									}
									if (updated > 0)
									{
										((MelonBase)this).LoggerInstance.Msg($"[CharConfig] Strategy D (Il2CppType) found {array4.Length} config(s).");
									}
								}
							}
						}
					}
					catch
					{
					}
				}
				if (updated > 0 && !_charConfigPreloadDone)
				{
					_charConfigPreloadDone = true;
					((MelonBase)this).LoggerInstance.Msg($"_lobbyAvailableCharacterIds populated on {updated} configurations (charIds [0..14]).");
				}
			}
			catch (Exception ex)
			{
				((MelonBase)this).LoggerInstance.Warning("TryFixCharactersConfigurationCrash failed: " + ex.GetBaseException().Message);
			}
		}

		private static object? CreateIl2CppArray(Type fieldType, int[] managedArray)
		{
			ConstructorInfo constructor = fieldType.GetConstructor(new Type[1] { typeof(int[]) });
			if (constructor != null)
			{
				return constructor.Invoke(new object[1] { managedArray });
			}
			ConstructorInfo constructor2 = fieldType.GetConstructor(new Type[1] { typeof(long) });
			if (constructor2 != null)
			{
				object obj = constructor2.Invoke(new object[1] { (long)managedArray.Length });
				PropertyInfo propertyInfo = fieldType.GetProperty("Item") ?? fieldType.GetProperties().FirstOrDefault((PropertyInfo p) => p.GetIndexParameters().Length == 1);
				if (propertyInfo != null)
				{
					for (int num = 0; num < managedArray.Length; num++)
					{
						propertyInfo.SetValue(obj, managedArray[num], new object[1] { num });
					}
				}
				return obj;
			}
			ConstructorInfo constructor3 = fieldType.GetConstructor(new Type[1] { typeof(int) });
			if (constructor3 != null)
			{
				object obj2 = constructor3.Invoke(new object[1] { managedArray.Length });
				PropertyInfo propertyInfo2 = fieldType.GetProperty("Item") ?? fieldType.GetProperties().FirstOrDefault((PropertyInfo p) => p.GetIndexParameters().Length == 1);
				if (propertyInfo2 != null)
				{
					for (int num2 = 0; num2 < managedArray.Length; num2++)
					{
						propertyInfo2.SetValue(obj2, managedArray[num2], new object[1] { num2 });
					}
				}
				return obj2;
			}
			try
			{
				return Activator.CreateInstance(fieldType, managedArray);
			}
			catch
			{
			}
			try
			{
				return Activator.CreateInstance(fieldType, (long)managedArray.Length);
			}
			catch
			{
			}
			return null;
		}

		private static void PopulateCharIdsOnInstance(object cfg, Type charsConfigType, int[] allCharIds, ref int updated)
		{
			FieldInfo field = charsConfigType.GetField("_lobbyAvailableCharacterIds", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (field == null)
			{
				return;
			}
			try
			{
				Type fieldType = field.FieldType;
				if (!_populateCharIdsDiagLogged)
				{
					_populateCharIdsDiagLogged = true;
					CustomServerMod? customServerMod = s_active;
					if (customServerMod != null)
					{
						((MelonBase)customServerMod).LoggerInstance.Msg($"[CharConfig] _lobbyAvailableCharacterIds field type: {fieldType.FullName} (IsArray={fieldType.IsArray}, BaseType={fieldType.BaseType?.FullName})");
					}
					ConstructorInfo[] constructors = fieldType.GetConstructors();
					for (int i = 0; i < constructors.Length; i++)
					{
						ParameterInfo[] parameters = constructors[i].GetParameters();
						CustomServerMod? customServerMod2 = s_active;
						if (customServerMod2 != null)
						{
							((MelonBase)customServerMod2).LoggerInstance.Msg("  ctor(" + string.Join(", ", parameters.Select((ParameterInfo p) => p.ParameterType.Name)) + ")");
						}
					}
				}
				object obj;
				if (fieldType == typeof(int[]) || fieldType.IsAssignableFrom(typeof(int[])))
				{
					obj = allCharIds;
				}
				else
				{
					obj = CreateIl2CppArray(fieldType, allCharIds);
					if (obj == null)
					{
						CustomServerMod? customServerMod3 = s_active;
						if (customServerMod3 != null)
						{
							((MelonBase)customServerMod3).LoggerInstance.Warning("[CharConfig] Failed to create IL2CPP array of type " + fieldType.FullName + ". Falling back to managed int[].");
						}
						obj = allCharIds;
					}
				}
				field.SetValue(cfg, obj);
				updated++;
			}
			catch (Exception ex)
			{
				CustomServerMod? customServerMod4 = s_active;
				if (customServerMod4 != null)
				{
					((MelonBase)customServerMod4).LoggerInstance.Warning("Could not set _lobbyAvailableCharacterIds: " + ex.GetBaseException().Message);
				}
			}
			MethodInfo method = charsConfigType.GetMethod("UpdateAvailableCharacterList", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (!(method != null))
			{
				return;
			}
			try
			{
				ParameterInfo[] parameters2 = method.GetParameters();
				if (parameters2 != null && parameters2.Length == 1)
				{
					Type parameterType = parameters2[0].ParameterType;
					object obj2 = ((!(parameterType == typeof(int[])) && !parameterType.IsAssignableFrom(typeof(int[]))) ? (CreateIl2CppArray(parameterType, allCharIds) ?? allCharIds) : allCharIds);
					method.Invoke(cfg, new object[1] { obj2 });
				}
				else if (parameters2 == null || parameters2.Length == 0)
				{
					method.Invoke(cfg, Array.Empty<object>());
				}
			}
			catch
			{
			}
		}

		private void TryInstallLifecycleGuardPatches()
		{
			if (_lifecycleGuardPatchesInstalled)
			{
				return;
			}
			try
			{
				Type typeFromHandle = typeof(Application);
				if (typeFromHandle == null)
				{
					return;
				}
				MethodInfo method = typeof(CustomServerMod).GetMethod("ApplicationQuitGuardPrefix", BindingFlags.Static | BindingFlags.NonPublic);
				if (method == null)
				{
					return;
				}
				int num = 0;
				foreach (MethodInfo item in from m in typeFromHandle.GetMethods(BindingFlags.Static | BindingFlags.Public)
					where m.Name == "Quit"
					select m)
				{
					if (PatchHarmonyPrefix(item, method))
					{
						num++;
					}
				}
				if (num > 0)
				{
					_lifecycleGuardPatchesInstalled = true;
					_quitGuardActive = true;
					_quitGuardExpireTime = float.MaxValue;
					((MelonBase)this).LoggerInstance.Msg($"Installed lifecycle guard on {num} Application.Quit overload(s). Guard PERMANENT (custom servers).");
				}
			}
			catch (Exception ex)
			{
				((MelonBase)this).LoggerInstance.Warning("TryInstallLifecycleGuardPatches failed: " + ex.GetBaseException().Message);
			}
		}

		private static bool ApplicationQuitGuardPrefix()
		{
			if (!_quitGuardActive || Time.realtimeSinceStartup >= _quitGuardExpireTime)
			{
				_quitGuardActive = false;
				return true;
			}
			CustomServerMod? customServerMod = s_active;
			if (customServerMod != null)
			{
				((MelonBase)customServerMod).LoggerInstance.Warning($"BLOCKED Application.Quit() during lobby startup (guard expires in {_quitGuardExpireTime - Time.realtimeSinceStartup:F0}s). " + "The game tried to self-quit due to a lobby build error, but this is suppressed on custom servers.");
			}
			return false;
		}

		private void TryInstallUICharactersConfigPatch()
		{
			if (_uiCharsConfigPatchInstalled)
			{
				return;
			}
			Type type = FindType("BAPBAP.UI.UICharactersConfiguration");
			if (type == null)
			{
				return;
			}
			try
			{
				MethodInfo method = type.GetMethod("TryGetLobbyCharConfigByIndex", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				MethodInfo method2 = typeof(CustomServerMod).GetMethod("EnsureLobbyCharIdsPrefix", BindingFlags.Static | BindingFlags.NonPublic);
				if (method != null && method2 != null && PatchHarmonyPrefix(method, method2))
				{
					((MelonBase)this).LoggerInstance.Msg("Installed prefix on UICharactersConfiguration.TryGetLobbyCharConfigByIndex (right-panel-render fix).");
				}
				MethodInfo methodInfo = type.GetProperty("AvailableCharacterIds")?.GetGetMethod();
				MethodInfo method3 = typeof(CustomServerMod).GetMethod("EnsureLobbyCharIdsPrefix", BindingFlags.Static | BindingFlags.NonPublic);
				if (methodInfo != null && method3 != null)
				{
					PatchHarmonyPrefix(methodInfo, method3);
					((MelonBase)this).LoggerInstance.Msg("Installed prefix on UICharactersConfiguration.AvailableCharacterIds getter.");
				}
				Type type2 = FindType("BAPBAP.UI.UIManager");
				if (type2 != null)
				{
					MethodInfo method4 = type2.GetMethod("Awake", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					MethodInfo method5 = typeof(CustomServerMod).GetMethod("UIManagerAwakePrefix", BindingFlags.Static | BindingFlags.NonPublic);
					if (method4 != null && method5 != null && PatchHarmonyPrefix(method4, method5))
					{
						((MelonBase)this).LoggerInstance.Msg("Installed prefix on UIManager.Awake for pre-build char config population.");
					}
					MethodInfo method6 = typeof(CustomServerMod).GetMethod("UIManagerAwakePostfix", BindingFlags.Static | BindingFlags.NonPublic);
					if (method4 != null && method6 != null && PatchHarmonyPostfix(method4, method6))
					{
						((MelonBase)this).LoggerInstance.Msg("Installed postfix on UIManager.Awake for post-build char config verification.");
					}
				}
				_uiCharsConfigPatchInstalled = true;
			}
			catch (Exception ex)
			{
				((MelonBase)this).LoggerInstance.Warning("TryInstallUICharactersConfigPatch failed: " + ex.GetBaseException().Message);
			}
		}

		private static void UIManagerAwakePrefix(object __instance)
		{
			try
			{
				Type type = FindType("BAPBAP.UI.UICharactersConfiguration");
				if (type == null)
				{
					return;
				}
				int[] allCharIds = Enumerable.Range(0, 15).ToArray();
				int updated = 0;
				if (__instance != null)
				{
					updated += PopulateCharIdsFromOwnerFields(__instance, type, allCharIds, "UIManager.Awake prefix");
				}
				Array array = FindLoadedUnityObjects(type);
				if (array != null)
				{
					foreach (object item in array)
					{
						if (item != null)
						{
							PopulateCharIdsOnInstance(item, type, allCharIds, ref updated);
						}
					}
				}
				if (updated > 0)
				{
					if (s_active != null)
					{
						s_active._charConfigPreloadDone = true;
					}
					CustomServerMod? customServerMod = s_active;
					if (customServerMod != null)
					{
						((MelonBase)customServerMod).LoggerInstance.Msg($"[UIManagerAwakePrefix] _lobbyAvailableCharacterIds populated on {updated} configuration reference(s).");
					}
				}
			}
			catch (Exception ex)
			{
				CustomServerMod? customServerMod2 = s_active;
				if (customServerMod2 != null)
				{
					((MelonBase)customServerMod2).LoggerInstance.Warning("[UIManagerAwakePrefix] Failed: " + ex.GetBaseException().Message);
				}
			}
		}

		private static void UIManagerAwakePostfix()
		{
			try
			{
				Type type = FindType("BAPBAP.UI.UICharactersConfiguration");
				if (type == null)
				{
					return;
				}
				Array array = FindLoadedUnityObjects(type);
				if (array == null || array.Length == 0)
				{
					return;
				}
				int[] allCharIds = Enumerable.Range(0, 15).ToArray();
				int updated = 0;
				foreach (object item in array)
				{
					if (item != null)
					{
						PopulateCharIdsOnInstance(item, type, allCharIds, ref updated);
					}
				}
				if (updated > 0)
				{
					if (s_active != null)
					{
						s_active._charConfigPreloadDone = true;
					}
					CustomServerMod? customServerMod = s_active;
					if (customServerMod != null)
					{
						((MelonBase)customServerMod).LoggerInstance.Msg($"[UIManagerAwakePostfix] _lobbyAvailableCharacterIds populated on {updated} configurations.");
					}
				}
			}
			catch (Exception ex)
			{
				CustomServerMod? customServerMod2 = s_active;
				if (customServerMod2 != null)
				{
					((MelonBase)customServerMod2).LoggerInstance.Warning("[UIManagerAwakePostfix] Failed: " + ex.GetBaseException().Message);
				}
			}
		}

		private static int PopulateCharIdsFromOwnerFields(object owner, Type charsConfigType, int[] allCharIds, string reason)
		{
			int updated = 0;
			Type type = owner.GetType();
			FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (FieldInfo fieldInfo in fields)
			{
				try
				{
					bool num = fieldInfo.Name.Contains("character", StringComparison.OrdinalIgnoreCase) || fieldInfo.Name.Contains("char", StringComparison.OrdinalIgnoreCase) || fieldInfo.Name.Contains("config", StringComparison.OrdinalIgnoreCase);
					bool flag = charsConfigType.IsAssignableFrom(fieldInfo.FieldType) || string.Equals(fieldInfo.FieldType.FullName, charsConfigType.FullName, StringComparison.Ordinal);
					if (!num && !flag)
					{
						continue;
					}
					object value = fieldInfo.GetValue(owner);
					if (value != null)
					{
						Type type2 = value.GetType();
						if (charsConfigType.IsAssignableFrom(type2) || string.Equals(type2.FullName, charsConfigType.FullName, StringComparison.Ordinal))
						{
							PopulateCharIdsOnInstance(value, charsConfigType, allCharIds, ref updated);
						}
					}
				}
				catch
				{
				}
			}
			if (updated > 0)
			{
				CustomServerMod? customServerMod = s_active;
				if (customServerMod != null)
				{
					((MelonBase)customServerMod).LoggerInstance.Msg($"[{reason}] populated UICharactersConfiguration from {type.FullName} fields. count={updated}");
				}
			}
			return updated;
		}

		private static void EnsureLobbyCharIdsPrefix(object __instance)
		{
			try
			{
				_ensureLobbyCharIdsCallCount++;
				if (__instance == null)
				{
					return;
				}
				FieldInfo field = __instance.GetType().GetField("_lobbyAvailableCharacterIds", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				if (field == null)
				{
					return;
				}
				object value = field.GetValue(__instance);
				bool flag = value == null;
				if (!flag && value is ICollection { Count: 0 })
				{
					flag = true;
				}
				if (!flag && value != null)
				{
					PropertyInfo property = value.GetType().GetProperty("Length");
					if (property != null)
					{
						object value2 = property.GetValue(value);
						if (value2 is int && (int)value2 == 0)
						{
							flag = true;
						}
					}
				}
				if (!flag)
				{
					return;
				}
				int[] array = Enumerable.Range(0, 15).ToArray();
				try
				{
					if (field.FieldType == typeof(int[]) || field.FieldType.IsAssignableFrom(typeof(int[])))
					{
						field.SetValue(__instance, array);
						_ensureLobbyCharIdsFilledCount++;
						return;
					}
					object obj = CreateIl2CppArray(field.FieldType, array);
					if (obj != null)
					{
						field.SetValue(__instance, obj);
						_ensureLobbyCharIdsFilledCount++;
					}
				}
				catch
				{
				}
			}
			catch
			{
			}
		}

		private static void PopulateCharIdsBeforeBuildPrefix()
		{
			try
			{
				Type type = FindType("BAPBAP.UI.UICharactersConfiguration");
				if (type == null)
				{
					return;
				}
				Array array = FindLoadedUnityObjects(type);
				if (array == null || array.Length == 0)
				{
					return;
				}
				int[] allCharIds = Enumerable.Range(0, 15).ToArray();
				int updated = 0;
				foreach (object item in array)
				{
					if (item != null)
					{
						PopulateCharIdsOnInstance(item, type, allCharIds, ref updated);
					}
				}
				if (updated > 0 && !_populateCharIdsPrefixLogged)
				{
					_populateCharIdsPrefixLogged = true;
					CustomServerMod? customServerMod = s_active;
					if (customServerMod != null)
					{
						((MelonBase)customServerMod).LoggerInstance.Msg($"[PopulateCharIdsBeforeBuildPrefix] Filled _lobbyAvailableCharacterIds on {updated} UICharactersConfiguration instance(s) before Build/Initialise.");
					}
				}
			}
			catch
			{
			}
		}

		private void TryFetchServerPolicy()
		{
			if (_serverPolicyFetched || Time.realtimeSinceStartup < _nextServerPolicyFetchAt)
			{
				return;
			}
			_nextServerPolicyFetchAt = Time.realtimeSinceStartup + 5f;
			try
			{
				HttpWebRequest obj = (HttpWebRequest)WebRequest.Create(BuildServerPolicyUrl());
				obj.Timeout = 2000;
				obj.ReadWriteTimeout = 2000;
				obj.Method = "GET";
				using HttpWebResponse httpWebResponse = (HttpWebResponse)obj.GetResponse();
				using Stream stream = httpWebResponse.GetResponseStream();
				if (stream == null)
				{
					return;
				}
				using StreamReader streamReader = new StreamReader(stream);
				string body = streamReader.ReadToEnd();
				string text = ExtractJsonString(body, "matchmakingPolicy") ?? "Both";
				bool flag = ExtractJsonBool(body, "allowMatchmaking") ?? true;
				bool flag2 = ExtractJsonBool(body, "allowCustomMatch") ?? true;
				_serverMatchmakingPolicy = text;
				_allowMatchmaking = flag;
				_allowCustomMatch = flag2;
				_serverModdingOverlayTitle = ExtractJsonString(body, "moddingOverlayTitle") ?? "";
				_serverModdingOverlaySubtitle = ExtractJsonString(body, "moddingOverlaySubtitle") ?? "";
				_serverPolicyFetched = true;
				UpdateUguiOverlayText();
				((MelonBase)this).LoggerInstance.Msg($"Server match policy fetched: {text} (matchmaking={(flag ? "allowed" : "blocked")}, custom={(flag2 ? "allowed" : "blocked")}). " + "When a path is blocked, the mod logs a clear error if the user tries to use it.");
			}
			catch (Exception ex)
			{
				((MelonBase)this).LoggerInstance.Msg("Could not fetch /api/server-config yet (" + ex.GetBaseException().Message + "). Will retry.");
			}
		}

		private string BuildServerPolicyUrl()
		{
			MelonPreferences_Entry<bool> localProxyEntry = _localProxyEntry;
			if (localProxyEntry == null || localProxyEntry.Value)
			{
				int value = _localPortEntry?.Value ?? 5055;
				return $"http://127.0.0.1:{value}/api/server-config";
			}
			string value2 = _hostEntry?.Value ?? "127.0.0.1";
			int value3 = _serverPortEntry?.Value ?? 5198;
			MelonPreferences_Entry<bool> httpsEntry = _httpsEntry;
			string value4 = ((httpsEntry != null && httpsEntry.Value) ? "https" : "http");
			return $"{value4}://{value2}:{value3}/api/server-config";
		}

		private static string? ExtractJsonString(string body, string key)
		{
			string text = "\"" + key + "\":\"";
			int num = body.IndexOf(text, StringComparison.OrdinalIgnoreCase);
			if (num < 0)
			{
				return null;
			}
			int num2 = num + text.Length;
			int num3 = body.IndexOf('"', num2);
			if (num3 < 0)
			{
				return null;
			}
			return body.Substring(num2, num3 - num2);
		}

		private static bool? ExtractJsonBool(string body, string key)
		{
			string text = "\"" + key + "\":";
			int num = body.IndexOf(text, StringComparison.OrdinalIgnoreCase);
			if (num < 0)
			{
				return null;
			}
			int i;
			for (i = num + text.Length; i < body.Length && char.IsWhiteSpace(body[i]); i++)
			{
			}
			if (body.Length - i >= 4 && body.Substring(i, 4).Equals("true", StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
			if (body.Length - i >= 5 && body.Substring(i, 5).Equals("false", StringComparison.OrdinalIgnoreCase))
			{
				return false;
			}
			return null;
		}

		private void TryInstallAnalyticsPatches()
		{
			if (_analyticsPatchesInstalled)
			{
				return;
			}
			Type type = FindType("BAPBAP.Local.AnalyticsManager");
			if (type == null)
			{
				return;
			}
			MethodInfo method = typeof(CustomServerMod).GetMethod("AnalyticsManagerSetupAnalyticsPrefix", BindingFlags.Static | BindingFlags.NonPublic);
			MethodInfo methodInfo = type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).FirstOrDefault((MethodInfo methodInfo2) => !(methodInfo2.Name != "SetupAnalytics") && methodInfo2.GetParameters().Length == 3);
			if (method == null || methodInfo == null)
			{
				return;
			}
			try
			{
				if (PatchHarmonyPrefix(methodInfo, method))
				{
					_analyticsPatchesInstalled = true;
					((MelonBase)this).LoggerInstance.Msg("Installed AnalyticsManager custom-server no-op patch.");
				}
			}
			catch (Exception ex)
			{
				((MelonBase)this).LoggerInstance.Warning("AnalyticsManager custom-server patch was not installed: " + ex.GetBaseException().Message);
			}
		}

		private void TryInstallUnityWebRequestHeaderPatch()
		{
			if (_unityWebRequestHeaderPatchInstalled)
			{
				return;
			}
			Type type = FindType("UnityEngine.Networking.UnityWebRequest");
			if (type == null)
			{
				return;
			}
			MethodInfo method = typeof(CustomServerMod).GetMethod("UnityWebRequestSetRequestHeaderPrefix", BindingFlags.Static | BindingFlags.NonPublic);
			MethodInfo method2 = typeof(CustomServerMod).GetMethod("UnityWebRequestSendWebRequestPrefix", BindingFlags.Static | BindingFlags.NonPublic);
			MethodInfo methodInfo = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).FirstOrDefault(delegate(MethodInfo methodInfo2)
			{
				if (methodInfo2.Name != "SetRequestHeader")
				{
					return false;
				}
				ParameterInfo[] parameters = methodInfo2.GetParameters();
				return parameters.Length == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(string);
			});
			MethodInfo method3 = type.GetMethod("SendWebRequest", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
			if ((method == null || methodInfo == null) && (method2 == null || method3 == null))
			{
				return;
			}
			try
			{
				int num = 0;
				if (method != null && methodInfo != null && PatchHarmonyPrefix(methodInfo, method))
				{
					num++;
				}
				if (method2 != null && method3 != null && PatchHarmonyPrefix(method3, method2))
				{
					num++;
				}
				if (num > 0)
				{
					_unityWebRequestHeaderPatchInstalled = true;
					((MelonBase)this).LoggerInstance.Msg($"Installed {num} UnityWebRequest callback repair patch(es).");
				}
			}
			catch (Exception ex)
			{
				((MelonBase)this).LoggerInstance.Warning("UnityWebRequest empty-header repair patch was not installed: " + ex.GetBaseException().Message);
			}
		}

		private void TryStartDedicatedGameNetwork(int wsPort, int kcpPort, int tcpPort)
		{
			if (IsTcpPortOpen("127.0.0.1", wsPort, 50) || IsTcpPortOpen("127.0.0.1", tcpPort, 50))
			{
				_dedicatedNetworkStarted = true;
				SetNetworkRepairStatus($"Dedicated game network is listening. ws={wsPort} kcp={kcpPort} tcp={tcpPort}", logRepeated: false);
				return;
			}
			Type type = FindType("BAPBAP.UI.UINetwork");
			Type type2 = FindType("Il2CppBAPBAP.Network.GameNetworkManager") ?? FindType("Il2CppBAPBAP.Network.GameNetworkManager") ?? FindType("BAPBAP.Network.GameNetworkManager");
			if (type == null && type2 == null)
			{
				SetNetworkRepairStatus("Waiting for dedicated network types. UINetwork=False GameNetworkManager=False", logRepeated: false);
			}
			else
			{
				if (_dedicatedNetworkStarted)
				{
					return;
				}
				int value = 0;
				int num = 0;
				bool flag = false;
				string text = "unknown";
				string text2 = "unknown";
				if (type != null)
				{
					Array array = FindLoadedUnityObjects(type);
					value = array?.Length ?? 0;
					if (array != null)
					{
						foreach (object item in array)
						{
							if (GetMemberValue(item, "_gameNetManager") != null)
							{
								try
								{
									InvokeInstance(item, "OverrideDefaultConfig", "127.0.0.1", kcpPort, tcpPort, wsPort, false);
									InvokeInstance(item, "StartServer");
									flag = true;
									_uiNetworkStartAttempted = true;
									SetNetworkRepairStatus($"Requested dedicated server start through UINetwork. ws={wsPort} kcp={kcpPort} tcp={tcpPort}", logRepeated: true);
								}
								catch (Exception ex)
								{
									SetNetworkRepairStatus("UINetwork dedicated start failed: " + ex.GetBaseException().Message, logRepeated: false);
									continue;
								}
								break;
							}
						}
					}
				}
				if (type2 != null)
				{
					bool flag2 = default(bool);
					bool flag3 = default(bool);
					foreach (object item2 in FindGameNetworkManagers(type2))
					{
						num++;
						try
						{
							SetMemberValue(item2, "networkAddress", "127.0.0.1");
							DumpAndForcePortFields(item2, wsPort, kcpPort, tcpPort);
							ForcePatchStaticServerConfig(type2.Assembly, tcpPort);
							object obj = InvokeInstance(item2, "IsActive");
							object? memberValue = GetMemberValue(item2, "mode");
							text2 = obj?.ToString() ?? "null";
							text = memberValue?.ToString() ?? "null";
							int num2;
							if (obj is bool)
							{
								flag2 = (bool)obj;
								num2 = 1;
							}
							else
							{
								num2 = 0;
							}
							if (((uint)num2 & (flag2 ? 1u : 0u)) != 0)
							{
								_dedicatedNetworkStarted = true;
								_gameNetworkStartAttempted = true;
								SetNetworkRepairStatus("Dedicated GameNetworkManager is already active. mode=" + text, logRepeated: true);
								return;
							}
							InvokeInstance(item2, "StartServer");
							flag = true;
							SetNetworkRepairStatus("Requested dedicated server start through GameNetworkManager. modeBefore=" + text + " activeBefore=" + text2, logRepeated: true);
							Thread.Sleep(200);
							object obj2 = InvokeInstance(item2, "IsActive");
							object memberValue2 = GetMemberValue(item2, "mode");
							((MelonBase)this).LoggerInstance.Msg($"[NetworkRepair] post-StartServer: mode={memberValue2 ?? "null"} active={obj2 ?? "null"}");
							int num3;
							if (obj2 is bool)
							{
								flag3 = (bool)obj2;
								num3 = 1;
							}
							else
							{
								num3 = 0;
							}
							if (((uint)num3 & (flag3 ? 1u : 0u)) != 0)
							{
								_dedicatedNetworkStarted = true;
								_gameNetworkStartAttempted = true;
							}
						}
						catch (Exception ex2)
						{
							SetNetworkRepairStatus("GameNetworkManager dedicated start failed: " + ex2.GetBaseException().Message, logRepeated: false);
							continue;
						}
						break;
					}
				}
				if (IsTcpPortOpen("127.0.0.1", wsPort, 100) || IsTcpPortOpen("127.0.0.1", tcpPort, 100))
				{
					_dedicatedNetworkStarted = true;
					SetNetworkRepairStatus($"Started dedicated game network. ws={wsPort} kcp={kcpPort} tcp={tcpPort}", logRepeated: true);
				}
				else if (!flag && !_uiNetworkStartAttempted && !_gameNetworkStartAttempted)
				{
					SetNetworkRepairStatus($"Waiting for dedicated network instances. UINetwork={value} GameNetworkManager={num}", logRepeated: false);
				}
				else
				{
					SetNetworkRepairStatus($"Dedicated network start is pending; TCP listeners are not open yet. ws={wsPort} tcp={tcpPort}", logRepeated: false);
				}
			}
		}

		private void RunAutoplayLogic()
		{
			if (Time.realtimeSinceStartup < _autoplayNextActionAt)
			{
				return;
			}
			_autoplayNextActionAt = Time.realtimeSinceStartup + 2f;
			try
			{
				switch (_autoplayState)
				{
				case 0:
					if (_lastLoadResponse != null)
					{
						_autoplayState = 1;
						_autoplayNextActionAt = Time.realtimeSinceStartup + 3f;
						((MelonBase)this).LoggerInstance.Msg("[Autoplay] Login complete, will join lobby in 3s.");
					}
					break;
				case 1:
					if (TryAutoplayJoinLobby())
					{
						_autoplayState = 2;
						_autoplayNextActionAt = Time.realtimeSinceStartup + 2f;
						((MelonBase)this).LoggerInstance.Msg("[Autoplay] Joined lobby, will set ready in 2s.");
					}
					break;
				case 2:
					if (TryAutoplaySetReady())
					{
						_autoplayState = 3;
						_autoplayNextActionAt = Time.realtimeSinceStartup + 1f;
						((MelonBase)this).LoggerInstance.Msg("[Autoplay] Ready set. Waiting for match.");
					}
					break;
				case 3:
					TryAutoplayDetectMatch();
					_autoplayNextActionAt = Time.realtimeSinceStartup + 0.5f;
					break;
				}
			}
			catch (Exception ex)
			{
				((MelonBase)this).LoggerInstance.Warning($"[Autoplay] Error in state {_autoplayState}: {ex.GetBaseException().Message}");
				_autoplayNextActionAt = Time.realtimeSinceStartup + 5f;
			}
		}

		private bool TryAutoplayJoinLobby()
		{
			Type type = FindType("BAPBAP.Network.LobbyNetworkClient");
			if (type == null)
			{
				return false;
			}
			Array array = FindLoadedUnityObjects(type);
			if (array == null || array.Length == 0)
			{
				return false;
			}
			foreach (object item in array)
			{
				object obj = GetMemberValue(item, "_controllerManager") ?? GetMemberValue(item, "controllerManager");
				object obj2 = ((obj != null) ? (GetMemberValue(obj, "Ws") ?? GetMemberValue(obj, "_ws")) : null);
				if (obj2 == null)
				{
					obj2 = GetMemberValue(item, "_webSocketClient") ?? GetMemberValue(item, "_wsClient");
				}
				if (obj2 != null)
				{
					string text = "{\"event\":\"JOIN_LOBBY\",\"payload\":{\"lobbyId\":\"\",\"charId\":1,\"regionId\":\"custom\",\"gameModeId\":1,\"isAutoFill\":false}}";
					InvokeInstance(obj2, "Send", text);
					return true;
				}
			}
			return false;
		}

		private bool TryAutoplaySetReady()
		{
			Type type = FindType("BAPBAP.Network.LobbyNetworkClient");
			if (type == null)
			{
				return false;
			}
			Array array = FindLoadedUnityObjects(type);
			if (array == null || array.Length == 0)
			{
				return false;
			}
			foreach (object item in array)
			{
				object obj = GetMemberValue(item, "_controllerManager") ?? GetMemberValue(item, "controllerManager");
				object obj2 = ((obj != null) ? (GetMemberValue(obj, "Ws") ?? GetMemberValue(obj, "_ws")) : null);
				if (obj2 == null)
				{
					obj2 = GetMemberValue(item, "_webSocketClient") ?? GetMemberValue(item, "_wsClient");
				}
				if (obj2 != null)
				{
					string text = "{\"event\":\"SWITCH_CUSTOM_READY\",\"payload\":{\"isReady\":true}}";
					InvokeInstance(obj2, "Send", text);
					return true;
				}
			}
			return false;
		}

		private void TryAutoplayDetectMatch()
		{
			if (_autoplayInMatch)
			{
				return;
			}
			Type type = FindType("BAPBAP.Game.GameManager");
			if (type == null)
			{
				return;
			}
			Array array = FindLoadedUnityObjects(type);
			if (array != null && array.Length > 0)
			{
				_autoplayInMatch = true;
				((MelonBase)this).LoggerInstance.Msg("[Autoplay] GameManager detected - match is running!");
			}
			Type type2 = FindType("BAPBAP.Player.PlayerManager");
			if (!(type2 == null))
			{
				Array array2 = FindLoadedUnityObjects(type2);
				if (array2 != null && array2.Length > 0)
				{
					_autoplayInMatch = true;
					((MelonBase)this).LoggerInstance.Msg("[Autoplay] Players detected - match is running!");
				}
			}
		}

		private void TryAutoJoinMatch(string gameAuthId, string host, int wsPort, int kcpPort, int tcpPort)
		{
			Type type = FindType("Il2CppBAPBAP.Network.GameNetworkManager") ?? FindType("Il2CppBAPBAP.Network.GameNetworkManager") ?? FindType("BAPBAP.Network.GameNetworkManager");
			if (type == null)
			{
				_statusText = "Waiting for GameNetworkManager before auto-join";
				return;
			}
			object obj = FindGameNetworkManagers(type).FirstOrDefault();
			if (obj == null)
			{
				_statusText = "Waiting for GameNetworkManager instance before auto-join";
				return;
			}
			try
			{
				InvokeInstance(obj, "ConnectMatchmaking", gameAuthId, host, wsPort, kcpPort, tcpPort);
				_autoJoinAttempted = true;
				_statusText = $"Auto-joining match {host}:{kcpPort}";
				((MelonBase)this).LoggerInstance.Msg($"Requested matchmaking client connect. auth={gameAuthId} host={host} ws={wsPort} kcp={kcpPort} tcp={tcpPort}");
			}
			catch (Exception ex)
			{
				_statusText = "Auto-join failed: " + ex.GetBaseException().Message;
				((MelonBase)this).LoggerInstance.Warning(_statusText);
			}
		}

		private void DumpAndForcePortFields(object manager, int wsPort, int kcpPort, int tcpPort)
		{
			if (manager == null)
			{
				return;
			}
			try
			{
				Type type = manager.GetType();
				FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				int num = 0;
				foreach (FieldInfo fieldInfo in fields)
				{
					string text = fieldInfo.Name.ToLowerInvariant();
					int? num2 = null;
					if (text.Contains("ws") && text.Contains("port"))
					{
						num2 = wsPort;
					}
					else if (text.Contains("kcp") && text.Contains("port"))
					{
						num2 = kcpPort;
					}
					else if (text.Contains("tcp") && text.Contains("port"))
					{
						num2 = tcpPort;
					}
					else if (text == "listenport" || text == "_listenport" || text.Contains("listenport"))
					{
						num2 = tcpPort;
					}
					else if (text.Contains("networkport"))
					{
						num2 = tcpPort;
					}
					if (!num2.HasValue || !fieldInfo.FieldType.IsValueType)
					{
						continue;
					}
					try
					{
						object obj = num2.Value;
						if (fieldInfo.FieldType == typeof(ushort))
						{
							obj = (ushort)num2.Value;
							goto IL_01f9;
						}
						if (fieldInfo.FieldType == typeof(short))
						{
							obj = (short)num2.Value;
							goto IL_01f9;
						}
						if (fieldInfo.FieldType == typeof(uint))
						{
							obj = (uint)num2.Value;
							goto IL_01f9;
						}
						if (fieldInfo.FieldType == typeof(long))
						{
							obj = (long)num2.Value;
							goto IL_01f9;
						}
						if (fieldInfo.FieldType == typeof(int))
						{
							obj = num2.Value;
							goto IL_01f9;
						}
						goto end_IL_0118;
						IL_01f9:
						fieldInfo.SetValue(manager, obj);
						num++;
						((MelonBase)this).LoggerInstance.Msg($"[ForcePort] {type.Name}.{fieldInfo.Name} ({fieldInfo.FieldType.Name}) = {num2.Value}");
						end_IL_0118:;
					}
					catch (Exception ex)
					{
						((MelonBase)this).LoggerInstance.Msg($"[ForcePort] failed {type.Name}.{fieldInfo.Name}: {ex.Message}");
					}
				}
				((MelonBase)this).LoggerInstance.Msg($"[ForcePort] Patched {num}/{fields.Length} fields on {type.Name}");
				if (!_forcePortFieldsDumped)
				{
					_forcePortFieldsDumped = true;
					int count = Math.Min(40, fields.Length);
					string value = string.Join(", ", from x in fields.Take(count)
						select x.Name);
					((MelonBase)this).LoggerInstance.Msg($"[ForcePort] {type.Name} fields ({fields.Length}): {value}");
				}
			}
			catch (Exception ex2)
			{
				((MelonBase)this).LoggerInstance.Msg("[ForcePort] DumpAndForcePortFields failed: " + ex2.Message);
			}
		}

		private void ForcePatchStaticServerConfig(Assembly hostAssembly, int listenPort)
		{
			try
			{
				Type type = FindType("BAPBAP.Local.NetworkConfig") ?? FindType("BAPBAP.Network.NetworkConfig");
				if (type == null)
				{
					Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
					foreach (Assembly assembly in assemblies)
					{
						Type[] types;
						try
						{
							types = assembly.GetTypes();
						}
						catch
						{
							continue;
						}
						Type[] array = types;
						foreach (Type type2 in array)
						{
							if (type2.Name == "NetworkConfig" || type2.Name == "Il2CppNetworkConfig")
							{
								type = type2;
								break;
							}
						}
						if (type != null)
						{
							break;
						}
					}
				}
				if (type == null)
				{
					((MelonBase)this).LoggerInstance.Msg("[ServerConfigForce] No NetworkConfig type found");
					_serverConfigForcePatched = true;
					return;
				}
				object obj2 = null;
				PropertyInfo property = type.GetProperty("Server", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
				if (property != null)
				{
					obj2 = property.GetValue(null);
				}
				if (obj2 == null)
				{
					FieldInfo fieldInfo = type.GetField("Server", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic) ?? type.GetField("_server", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic) ?? type.GetField("s_server", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
					if (fieldInfo != null)
					{
						obj2 = fieldInfo.GetValue(null);
					}
				}
				if (obj2 == null)
				{
					((MelonBase)this).LoggerInstance.Msg("[ServerConfigForce] " + type.FullName + " has no Server property/field");
					_serverConfigForcePatched = true;
					return;
				}
				Type type3 = obj2.GetType();
				int num = 0;
				FieldInfo field = type3.GetField("ListenPort", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				if (field != null)
				{
					Type fieldType = field.FieldType;
					object value = listenPort;
					if (fieldType == typeof(ushort))
					{
						value = (ushort)listenPort;
					}
					else if (fieldType == typeof(short))
					{
						value = (short)listenPort;
					}
					field.SetValue(obj2, value);
					num++;
					((MelonBase)this).LoggerInstance.Msg($"[ServerConfigForce] ServerConfig.ListenPort = {listenPort}");
				}
				FieldInfo field2 = type3.GetField("MatchmakingHost", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				if (field2 != null)
				{
					field2.SetValue(obj2, "127.0.0.1");
					num++;
					((MelonBase)this).LoggerInstance.Msg("[ServerConfigForce] ServerConfig.MatchmakingHost = 127.0.0.1");
				}
				FieldInfo field3 = type3.GetField("HeaderSecretKey", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				if (field3 != null && string.IsNullOrWhiteSpace(field3.GetValue(obj2) as string))
				{
					field3.SetValue(obj2, "X-BAP-Custom-Secret");
					num++;
				}
				FieldInfo field4 = type3.GetField("HeaderSecret", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				if (field4 != null && string.IsNullOrWhiteSpace(field4.GetValue(obj2) as string))
				{
					field4.SetValue(obj2, "local-custom-server");
					num++;
				}
				((MelonBase)this).LoggerInstance.Msg($"[ServerConfigForce] Patched {num} fields on {type3.FullName}");
				_serverConfigForcePatched = true;
			}
			catch (Exception ex)
			{
				((MelonBase)this).LoggerInstance.Msg("[ServerConfigForce] failed: " + ex.Message);
			}
		}

		private IEnumerable<object> FindGameNetworkManagers(Type gameNetworkManagerType)
		{
			Array array = FindLoadedUnityObjects(gameNetworkManagerType);
			if (array != null)
			{
				foreach (object item in array)
				{
					if (item != null && gameNetworkManagerType.IsInstanceOfType(item))
					{
						yield return item;
					}
				}
			}
			object obj = gameNetworkManagerType.GetProperty("Instance", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)?.GetValue(null) ?? gameNetworkManagerType.GetField("Instance", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)?.GetValue(null);
			if (obj != null && gameNetworkManagerType.IsInstanceOfType(obj))
			{
				yield return obj;
			}
		}

		private void SetNetworkRepairStatus(string status, bool logRepeated)
		{
			_statusText = status;
			if (logRepeated || !string.Equals(_lastNetworkRepairStatus, status, StringComparison.Ordinal))
			{
				_lastNetworkRepairStatus = status;
				((MelonBase)this).LoggerInstance.Msg(status);
			}
		}

		private void EnsureManagedBootstrapListener(int httpPort)
		{
			TcpListener? bootstrapListener = _bootstrapListener;
			if (bootstrapListener != null && bootstrapListener.Server?.IsBound == true)
			{
				return;
			}
			try
			{
				StopManagedBootstrapListener();
				TcpListener listener = new TcpListener(IPAddress.Loopback, httpPort);
				listener.Start();
				CancellationTokenSource cts = new CancellationTokenSource();
				_bootstrapListener = listener;
				_bootstrapListenerCts = cts;
				cts.Token.Register(delegate
				{
					try
					{
						listener.Stop();
					}
					catch
					{
					}
				});
				_bootstrapListenerTask = Task.Run(() => RunManagedBootstrapListenerAsync(listener, cts.Token));
				SetBootstrapRepairStatus("Managed match bootstrap listener is active.", logRepeated: true);
			}
			catch (Exception ex)
			{
				SetBootstrapRepairStatus("Managed match bootstrap listener failed: " + ex.GetBaseException().Message, logRepeated: false);
			}
		}

		private async Task RunManagedBootstrapListenerAsync(TcpListener listener, CancellationToken cancellationToken)
		{
			while (!cancellationToken.IsCancellationRequested)
			{
				TcpClient client;
				try
				{
					client = await listener.AcceptTcpClientAsync().ConfigureAwait(continueOnCapturedContext: false);
				}
				catch (ObjectDisposedException)
				{
					break;
				}
				catch (InvalidOperationException) when (cancellationToken.IsCancellationRequested)
				{
					break;
				}
				catch (SocketException) when (cancellationToken.IsCancellationRequested)
				{
					break;
				}
				catch (Exception ex4)
				{
					if (cancellationToken.IsCancellationRequested)
					{
						break;
					}
					((MelonBase)this).LoggerInstance.Warning("Managed bootstrap listener accept failed: " + ex4.GetBaseException().Message);
					continue;
				}
				Task.Run(() => HandleBootstrapTcpClientAsync(client), cancellationToken);
			}
		}

		private async Task HandleBootstrapTcpClientAsync(TcpClient client)
		{
			string path = "/";
			try
			{
				client.NoDelay = true;
				using NetworkStream stream = client.GetStream();
				byte[] buffer = new byte[8192];
				using MemoryStream pending = new MemoryStream();
				int headerEnd = -1;
				int contentLength = 0;
				bool headersParsed = false;
				string method = "";
				do
				{
					IL_00b1:
					int num = await stream.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(continueOnCapturedContext: false);
					if (num <= 0)
					{
						break;
					}
					pending.Write(buffer, 0, num);
					if (headersParsed)
					{
						continue;
					}
					byte[] buffer2 = pending.GetBuffer();
					int num2 = (int)pending.Length;
					for (int i = 0; i + 3 < num2; i++)
					{
						if (buffer2[i] == 13 && buffer2[i + 1] == 10 && buffer2[i + 2] == 13 && buffer2[i + 3] == 10)
						{
							headerEnd = i + 4;
							break;
						}
					}
					if (headerEnd < 0)
					{
						if (pending.Length > 65536)
						{
							await WriteBootstrapTcpResponseAsync(stream, 400, "Bad Request", "{\"ok\":false}").ConfigureAwait(continueOnCapturedContext: false);
							return;
						}
						goto IL_00b1;
					}
					string[] array = Encoding.ASCII.GetString(buffer2, 0, headerEnd).Split(new string[1] { "\r\n" }, StringSplitOptions.None);
					if (array.Length == 0 || string.IsNullOrEmpty(array[0]))
					{
						await WriteBootstrapTcpResponseAsync(stream, 400, "Bad Request", "{\"ok\":false}").ConfigureAwait(continueOnCapturedContext: false);
						return;
					}
					string[] array2 = array[0].Split(' ');
					if (array2.Length < 3)
					{
						await WriteBootstrapTcpResponseAsync(stream, 400, "Bad Request", "{\"ok\":false}").ConfigureAwait(continueOnCapturedContext: false);
						return;
					}
					method = array2[0];
					string text = array2[1];
					int num3 = text.IndexOf('?');
					if (num3 >= 0)
					{
						text = text.Substring(0, num3);
					}
					path = text.TrimEnd('/').ToLowerInvariant();
					if (string.IsNullOrWhiteSpace(path))
					{
						path = "/";
					}
					for (int j = 1; j < array.Length; j++)
					{
						string text2 = array[j];
						if (string.IsNullOrEmpty(text2))
						{
							continue;
						}
						int num4 = text2.IndexOf(':');
						if (num4 > 0)
						{
							string a = text2.Substring(0, num4).Trim();
							string s = text2.Substring(num4 + 1).Trim();
							if (string.Equals(a, "Content-Length", StringComparison.OrdinalIgnoreCase))
							{
								int.TryParse(s, out contentLength);
							}
						}
					}
					headersParsed = true;
				}
				while (!headersParsed || pending.Length - headerEnd < contentLength);
				if (!headersParsed)
				{
					return;
				}
				if (!string.Equals(method, "POST", StringComparison.OrdinalIgnoreCase) || (path != "/setup-game" && path != "/add-teams" && path != "/queue-matched"))
				{
					await WriteBootstrapTcpResponseAsync(stream, 404, "Not Found", "{\"ok\":false}").ConfigureAwait(continueOnCapturedContext: false);
					return;
				}
				string json = "";
				if (contentLength > 0)
				{
					byte[] buffer3 = pending.GetBuffer();
					int count = (int)Math.Min(contentLength, pending.Length - headerEnd);
					json = Encoding.UTF8.GetString(buffer3, headerEnd, count);
				}
				_pendingBootstrapPayloads.Enqueue(new BootstrapPayload(path, json));
				await WriteBootstrapTcpResponseAsync(stream, 200, "OK", "{\"ok\":true}").ConfigureAwait(continueOnCapturedContext: false);
				((MelonBase)this).LoggerInstance.Msg("Queued managed match bootstrap payload: " + path);
			}
			catch (Exception ex)
			{
				((MelonBase)this).LoggerInstance.Warning("Managed bootstrap request failed: " + ex.GetBaseException().Message);
				try
				{
					await WriteBootstrapTcpResponseAsync(client.GetStream(), 500, "Internal Server Error", "{\"ok\":false}").ConfigureAwait(continueOnCapturedContext: false);
				}
				catch
				{
				}
			}
			finally
			{
				try
				{
					client.Close();
				}
				catch
				{
				}
			}
		}

		private static async Task WriteBootstrapTcpResponseAsync(NetworkStream stream, int statusCode, string statusText, string body)
		{
			byte[] bodyBytes = Encoding.UTF8.GetBytes(body);
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("HTTP/1.1 ").Append(statusCode).Append(' ')
				.Append(statusText)
				.Append("\r\n");
			stringBuilder.Append("Content-Type: application/json; charset=utf-8\r\n");
			stringBuilder.Append("Content-Length: ").Append(bodyBytes.Length).Append("\r\n");
			stringBuilder.Append("Connection: close\r\n");
			stringBuilder.Append("\r\n");
			byte[] bytes = Encoding.ASCII.GetBytes(stringBuilder.ToString());
			await stream.WriteAsync(bytes, 0, bytes.Length).ConfigureAwait(continueOnCapturedContext: false);
			if (bodyBytes.Length != 0)
			{
				await stream.WriteAsync(bodyBytes, 0, bodyBytes.Length).ConfigureAwait(continueOnCapturedContext: false);
			}
			await stream.FlushAsync().ConfigureAwait(continueOnCapturedContext: false);
		}

		private void StopManagedBootstrapListener()
		{
			try
			{
				_bootstrapListenerCts?.Cancel();
				_bootstrapListener?.Stop();
			}
			catch
			{
			}
			finally
			{
				_bootstrapListener = null;
				_bootstrapListenerCts?.Dispose();
				_bootstrapListenerCts = null;
				_bootstrapListenerTask = null;
			}
		}

		private void DrainBootstrapPayloads()
		{
			BootstrapPayload result;
			while (_pendingBootstrapPayloads.TryDequeue(out result))
			{
				_retryBootstrapPayloads.Add(result);
			}
			int num = 0;
			while (num < _retryBootstrapPayloads.Count && TryProcessBootstrapPayload(_retryBootstrapPayloads[num]))
			{
				_retryBootstrapPayloads.RemoveAt(num);
			}
		}

		private void DrainAutoGuestLoginRequests()
		{
			AutoGuestLoginRequest result;
			while (_pendingAutoGuestLogins.TryDequeue(out result))
			{
				TryAutoGuestLogin(result.Controller, result.Reason);
			}
		}

		private void TryAutoGuestLoginFromLoadedLobbyClients()
		{
			Type type = FindType("BAPBAP.Network.LobbyNetworkClient");
			if (type == null)
			{
				return;
			}
			try
			{
				Array array = FindLoadedUnityObjects(type);
				if (array == null)
				{
					return;
				}
				if (!_autoGuestLobbyScanLogged)
				{
					_autoGuestLobbyScanLogged = true;
					((MelonBase)this).LoggerInstance.Msg($"Custom guest-login scan saw {array.Length} LobbyNetworkClient object(s).");
				}
				foreach (object item in array)
				{
					object obj = GetMemberValue(item, "_controller") ?? GetMemberValue(item, "Controller");
					object obj2 = ((obj == null) ? null : GetMemberValue(obj, "Login"));
					if (obj != null && obj2 != null)
					{
						if (!_autoGuestLoginControllerScanLogged)
						{
							_autoGuestLoginControllerScanLogged = true;
							((MelonBase)this).LoggerInstance.Msg("Custom guest-login scan resolved LobbyNetworkClient.Controller.Login.");
						}
						TryAutoGuestLogin(obj2, "loaded LobbyNetworkClient");
					}
				}
			}
			catch (Exception ex)
			{
				((MelonBase)this).LoggerInstance.Warning("Custom guest-login scan failed: " + ex.GetBaseException().Message);
			}
		}

		private void TryAutoGuestLoginFromLoadedLoginControllers()
		{
			Type type = FindType("BAPBAP.UI.LoginController");
			if (type == null)
			{
				return;
			}
			try
			{
				Array array = FindLoadedUnityObjects(type);
				if (array == null)
				{
					return;
				}
				foreach (object item in array)
				{
					TryAutoGuestLogin(item, "loaded LoginController");
				}
			}
			catch (Exception ex)
			{
				((MelonBase)this).LoggerInstance.Warning("Custom LoginController guest-login scan failed: " + ex.GetBaseException().Message);
			}
		}

		private void TryInvokeSplashGuestLoginAction()
		{
			if (_dedicatedProcess || _splashGuestLoginInvoked)
			{
				return;
			}
			MelonPreferences_Entry<bool> autoGuestLoginEntry = _autoGuestLoginEntry;
			if (autoGuestLoginEntry == null || !autoGuestLoginEntry.Value || !HasCompleteLocalIdentity())
			{
				return;
			}
			Type type = FindType("BAPBAP.UI.UILobbySplashScreen");
			if (type == null)
			{
				return;
			}
			try
			{
				Array array = FindLoadedUnityObjects(type);
				if (array == null || array.Length == 0)
				{
					if (!_splashGuestLoginScanLogged)
					{
						_splashGuestLoginScanLogged = true;
						((MelonBase)this).LoggerInstance.Msg("Custom splash guest-login scan saw 0 UILobbySplashScreen object(s).");
					}
					return;
				}
				((MelonBase)this).LoggerInstance.Msg($"Custom splash guest-login scan saw {array.Length} UILobbySplashScreen object(s).");
				foreach (object item in array)
				{
					object memberValue = GetMemberValue(item, "_actions");
					object obj = ((memberValue == null) ? null : GetMemberValue(memberValue, "GuestLoginAction"));
					if (obj != null)
					{
						SetMemberValue(item, "LoginCancelled", false);
						object obj2 = ((obj is Delegate obj3) ? obj3.DynamicInvoke() : InvokeInstance(obj, "Invoke"));
						_splashGuestLoginInvoked = true;
						_splashGuestLoginInvokedAt = Time.realtimeSinceStartup;
						((MelonBase)this).LoggerInstance.Msg($"Invoked custom-server guest login through UILobbySplashScreen action. Result={obj2 ?? "void"}");
						break;
					}
					object memberValue2 = GetMemberValue(item, "_loginScreen");
					object obj4 = ((memberValue2 == null) ? null : GetMemberValue(memberValue2, "GuestButton"));
					object obj5 = ((obj4 == null) ? null : GetMemberValue(obj4, "onClick"));
					if (obj5 == null)
					{
						((MelonBase)this).LoggerInstance.Msg($"UILobbySplashScreen guest-login action unavailable. actions={memberValue != null} guestButton={obj4 != null}");
						continue;
					}
					SetMemberValue(item, "LoginCancelled", false);
					object obj6 = InvokeInstance(obj5, "Invoke");
					_splashGuestLoginInvoked = true;
					_splashGuestLoginInvokedAt = Time.realtimeSinceStartup;
					((MelonBase)this).LoggerInstance.Msg($"Invoked custom-server guest login through UILobbySplashScreen GuestButton.onClick. Result={obj6 ?? "void"}");
					break;
				}
			}
			catch (Exception ex)
			{
				((MelonBase)this).LoggerInstance.Warning("Custom splash guest-login action failed: " + ex.GetBaseException().Message);
			}
		}

		private void TryAutoGuestLogin(object loginController, string reason)
		{
			if (_dedicatedProcess)
			{
				return;
			}
			MelonPreferences_Entry<bool> autoGuestLoginEntry = _autoGuestLoginEntry;
			if (autoGuestLoginEntry == null || !autoGuestLoginEntry.Value)
			{
				return;
			}
			int hashCode = RuntimeHelpers.GetHashCode(loginController);
			if (!_autoGuestLoginControllers.Add(hashCode))
			{
				return;
			}
			try
			{
				string text = _accountIdEntry.Value.Trim();
				string value = _usernameEntry.Value.Trim();
				if (string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(value))
				{
					UpdateIdentitySetupRequirement("guest login via " + reason);
					_autoGuestLoginControllers.Remove(hashCode);
					return;
				}
				string text2 = "bapcustom-" + text;
				SetMemberValue(loginController, "SessionId", text2);
				SetMemberValue(loginController, "AutoLogin", true);
				InvokeInstance(loginController, "UpdateCookie", text2);
				if (InvokeInstance(loginController, "LoginGuest") == null)
				{
					InvokeInstance(loginController, "SendLoadRequest");
				}
				((MelonBase)this).LoggerInstance.Msg($"Requested custom-server guest login via {reason}: {value} ({text}).");
			}
			catch (Exception ex)
			{
				_autoGuestLoginControllers.Remove(hashCode);
				((MelonBase)this).LoggerInstance.Warning("Custom-server guest login failed: " + ex.GetBaseException().Message);
			}
		}

		private void SchedulePostLoginUiFallback(string reason, float delaySeconds = 4f)
		{
			if (!_dedicatedProcess && !_postLoginUiFallbackApplied && !_identitySetupRequired && HasCompleteLocalIdentity())
			{
				float num = Time.realtimeSinceStartup + delaySeconds;
				if (_postLoginUiFallbackAt <= 0f || num < _postLoginUiFallbackAt)
				{
					_postLoginUiFallbackAt = num;
				}
				if (!_postLoginUiFallbackLogged)
				{
					_postLoginUiFallbackLogged = true;
					((MelonBase)this).LoggerInstance.Msg("Scheduled custom-server post-login splash fallback after " + reason + ".");
				}
			}
		}

		private void ApplyPostLoginUiFallback(string reason)
		{
			if (_dedicatedProcess || _postLoginUiFallbackApplied || _identitySetupRequired)
			{
				return;
			}
			_postLoginUiFallbackAttempts++;
			try
			{
				int value = 0;
				int num = 0;
				int num2 = 0;
				Type type = FindType("BAPBAP.UI.UILobby");
				if (type != null)
				{
					Array array = FindLoadedUnityObjects(type);
					value = array?.Length ?? 0;
					if (array != null)
					{
						foreach (object item in array)
						{
							EnsureLobbyCanvasVisible(item);
							object obj = GetMemberValue(item, "_splashScreen") ?? GetMemberValue(item, "Splash");
							if (obj != null)
							{
								num++;
								if (HideSplashObject(obj))
								{
									num2++;
								}
							}
						}
					}
				}
				if (num2 == 0)
				{
					Type type2 = FindType("BAPBAP.UI.UILobbySplashScreen");
					if (type2 != null)
					{
						Array array2 = FindLoadedUnityObjects(type2);
						if (array2 != null)
						{
							num += array2.Length;
							foreach (object item2 in array2)
							{
								if (HideSplashObject(item2))
								{
									num2++;
								}
							}
						}
					}
				}
				if (num2 > 0)
				{
					_postLoginUiFallbackApplied = true;
					((MelonBase)this).LoggerInstance.Msg($"Applied custom-server post-login splash fallback ({reason}). lobbies={value} splashes={num} hidden={num2}");
				}
				else if (_postLoginUiFallbackAttempts < 8)
				{
					LogLoadedUiDiagnostics("post-login fallback waiting");
					_postLoginUiFallbackAt = Time.realtimeSinceStartup + 2f;
					((MelonBase)this).LoggerInstance.Msg($"Post-login splash fallback waiting for lobby UI. attempt={_postLoginUiFallbackAttempts} lobbies={value} splashes={num}");
				}
				else if (_postLoginUiFallbackAttempts == 8)
				{
					LogAllGameObjectsForDiagnostics();
					_postLoginUiFallbackAt = Time.realtimeSinceStartup + 5f;
					((MelonBase)this).LoggerInstance.Warning($"Post-login splash fallback could not find lobby splash UI after {_postLoginUiFallbackAttempts} attempts. Continuing at slower rate.");
				}
				else
				{
					_postLoginUiFallbackAt = Time.realtimeSinceStartup + 5f;
				}
			}
			catch (Exception ex)
			{
				((MelonBase)this).LoggerInstance.Warning("Post-login splash fallback failed: " + ex.GetBaseException().Message);
			}
		}

		private void ForceDismissSplashUiInMatch()
		{
			if (_dedicatedProcess)
			{
				return;
			}
			try
			{
				Type type = FindType("UnityEngine.SceneManagement.SceneManager");
				if (type == null)
				{
					return;
				}
				MethodInfo method = type.GetMethod("GetActiveScene", BindingFlags.Static | BindingFlags.Public);
				if (method == null)
				{
					return;
				}
				object obj = method.Invoke(null, null);
				string text = (obj.GetType().GetProperty("name", BindingFlags.Instance | BindingFlags.Public)?.GetValue(obj) as string) ?? "";
				if (string.IsNullOrEmpty(text) || text.Equals("MainScene", StringComparison.OrdinalIgnoreCase) || text.Equals("Login", StringComparison.OrdinalIgnoreCase) || text.Equals("Bootstrap", StringComparison.OrdinalIgnoreCase))
				{
					return;
				}
				Type type2 = FindType("BAPBAP.UI.UIManager");
				if (type2 != null)
				{
					object obj2 = type2.GetProperty("Instance", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)?.GetValue(null) ?? type2.GetField("Instance", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)?.GetValue(null);
					if (obj2 != null)
					{
						InvokeInstance(obj2, "HideLoadingScreenSimple", 0f);
					}
				}
				Type type3 = FindType("BAPBAP.UI.UILobbySplashScreen");
				if (!(type3 != null))
				{
					return;
				}
				Array array = FindLoadedUnityObjects(type3);
				if (array == null || array.Length <= 0)
				{
					return;
				}
				foreach (object item in array)
				{
					if (item != null)
					{
						HideSplashObject(item);
					}
				}
			}
			catch (Exception ex)
			{
				((MelonBase)this).LoggerInstance.Warning("ForceDismissSplashUiInMatch failed: " + ex.GetBaseException().Message);
			}
		}

		private void LogLoadedUiDiagnostics(string reason)
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
			if (_postLoginUiDiagnosticsLogged)
			{
				return;
			}
			_postLoginUiDiagnosticsLogged = true;
			try
			{
				Scene activeScene = SceneManager.GetActiveScene();
				((MelonBase)this).LoggerInstance.Msg($"Loaded UI diagnostics ({reason}): activeScene='{((Scene)(ref activeScene)).name}' path='{((Scene)(ref activeScene)).path}' isLoaded={((Scene)(ref activeScene)).isLoaded}");
				LogSceneRootsReflective(activeScene);
				Array array = FindLoadedUnityObjects(typeof(Canvas));
				((MelonBase)this).LoggerInstance.Msg($"Loaded UI diagnostics canvases={array?.Length ?? 0}");
				if (array == null)
				{
					return;
				}
				foreach (Canvas item in array.Cast<Canvas>().Take(18))
				{
					((MelonBase)this).LoggerInstance.Msg("Loaded UI canvas: path='" + GetTransformPath(((Component)item).transform) + "' " + $"activeSelf={((Component)item).gameObject.activeSelf} " + $"activeInHierarchy={((Component)item).gameObject.activeInHierarchy} " + $"renderMode={item.renderMode} " + $"sortingOrder={item.sortingOrder}");
				}
				LogInterestingGameObjects();
			}
			catch (Exception ex)
			{
				((MelonBase)this).LoggerInstance.Warning("Loaded UI diagnostics failed: " + ex.GetBaseException().Message);
			}
		}

		private void LogInterestingGameObjects()
		{
			LogAllGameObjectsForDiagnostics();
		}

		private void ScheduleSceneReloadIfEmpty()
		{
			if (!_dedicatedProcess && !_sceneReloadScheduled)
			{
				TryProtectLobbyUiFromDestruction();
			}
		}

		private void TryProtectLobbyUiFromDestruction()
		{
			try
			{
				Type type = FindType("BAPBAP.UI.UIManager");
				if (type != null)
				{
					Array array = FindLoadedUnityObjects(type);
					if (array != null)
					{
						foreach (object item in array)
						{
							object? memberValue = GetMemberValue(item, "gameObject");
							GameObject val = (GameObject)((memberValue is GameObject) ? memberValue : null);
							if (val != null)
							{
								Object.DontDestroyOnLoad((Object)(object)val);
								((MelonBase)this).LoggerInstance.Msg("Protected UIManager '" + ((Object)val).name + "' with DontDestroyOnLoad.");
							}
						}
					}
				}
				Type type2 = FindType("Il2CppBAPBAP.Network.GameNetworkManager") ?? FindType("Il2CppBAPBAP.Network.GameNetworkManager") ?? FindType("BAPBAP.Network.GameNetworkManager");
				if (type2 != null)
				{
					Array array2 = FindLoadedUnityObjects(type2);
					if (array2 != null)
					{
						foreach (object item2 in array2)
						{
							object? memberValue2 = GetMemberValue(item2, "gameObject");
							GameObject val2 = (GameObject)((memberValue2 is GameObject) ? memberValue2 : null);
							if (val2 != null)
							{
								Object.DontDestroyOnLoad((Object)(object)val2);
								((MelonBase)this).LoggerInstance.Msg("Protected GameNetworkManager '" + ((Object)val2).name + "' with DontDestroyOnLoad.");
							}
						}
					}
				}
				Array array3 = FindLoadedUnityObjects(typeof(Canvas));
				if (array3 == null)
				{
					return;
				}
				foreach (Canvas item3 in array3.Cast<Canvas>())
				{
					if ((Object)(object)item3 != (Object)null && item3.isRootCanvas && (Object)(object)((Component)item3).gameObject != (Object)null)
					{
						Object.DontDestroyOnLoad((Object)(object)((Component)item3).gameObject);
						((MelonBase)this).LoggerInstance.Msg("Protected Canvas '" + ((Object)((Component)item3).gameObject).name + "' with DontDestroyOnLoad.");
					}
				}
			}
			catch (Exception ex)
			{
				((MelonBase)this).LoggerInstance.Warning("TryProtectLobbyUiFromDestruction failed: " + ex.GetBaseException().Message);
			}
		}

		private void TryReloadSceneForLobbyUi()
		{
			try
			{
				int num = FindLoadedUnityObjects(typeof(Canvas))?.Length ?? 0;
				if (num > 0)
				{
					((MelonBase)this).LoggerInstance.Msg($"Scene reload skipped — {num} canvas(es) already present.");
					return;
				}
				Type type = FindType("BAPBAP.UI.UILobby");
				if (type != null)
				{
					Array array = FindLoadedUnityObjects(type);
					if (array != null && array.Length > 0)
					{
						((MelonBase)this).LoggerInstance.Msg($"Scene reload skipped — {array.Length} UILobby object(s) found. Trying to activate them.");
						{
							foreach (object item in array)
							{
								object? memberValue = GetMemberValue(item, "gameObject");
								GameObject val = (GameObject)((memberValue is GameObject) ? memberValue : null);
								if (val != null && !val.activeInHierarchy)
								{
									val.SetActive(true);
									((MelonBase)this).LoggerInstance.Msg("Activated inactive UILobby: '" + ((Object)val).name + "'");
								}
							}
							return;
						}
					}
				}
				Type type2 = FindType("UnityEngine.SceneManagement.SceneManager");
				if (type2 == null)
				{
					((MelonBase)this).LoggerInstance.Warning("SceneManager type not found. Cannot reload scene.");
					return;
				}
				MethodInfo methodInfo = type2.GetMethods(BindingFlags.Static | BindingFlags.Public).FirstOrDefault((MethodInfo m) => m.Name == "GetActiveScene" && m.GetParameters().Length == 0);
				int num2 = 0;
				string text = "MainScene";
				if (methodInfo != null)
				{
					object obj = methodInfo.Invoke(null, null);
					Type type3 = obj.GetType();
					PropertyInfo property = type3.GetProperty("buildIndex", BindingFlags.Instance | BindingFlags.Public);
					PropertyInfo property2 = type3.GetProperty("name", BindingFlags.Instance | BindingFlags.Public);
					if (property != null)
					{
						num2 = (int)property.GetValue(obj);
					}
					if (property2 != null)
					{
						text = (property2.GetValue(obj) as string) ?? "MainScene";
					}
				}
				((MelonBase)this).LoggerInstance.Msg($"Reloading scene '{text}' (buildIndex={num2}) to restore lobby UI.");
				MethodInfo methodInfo2 = type2.GetMethods(BindingFlags.Static | BindingFlags.Public).FirstOrDefault((MethodInfo m) => m.Name == "LoadScene" && m.GetParameters().Length == 1 && m.GetParameters()[0].ParameterType == typeof(int));
				if (methodInfo2 != null)
				{
					methodInfo2.Invoke(null, new object[1] { num2 });
					return;
				}
				MethodInfo methodInfo3 = type2.GetMethods(BindingFlags.Static | BindingFlags.Public).FirstOrDefault((MethodInfo m) => m.Name == "LoadScene" && m.GetParameters().Length == 1 && m.GetParameters()[0].ParameterType == typeof(string));
				if (methodInfo3 != null)
				{
					methodInfo3.Invoke(null, new object[1] { text });
				}
				else
				{
					((MelonBase)this).LoggerInstance.Warning("Could not find any SceneManager.LoadScene overload.");
				}
			}
			catch (Exception ex)
			{
				((MelonBase)this).LoggerInstance.Warning("Scene reload failed: " + ex.GetBaseException().Message);
			}
		}

		private void LogAllGameObjectsForDiagnostics()
		{
			Array array = FindLoadedUnityObjects(typeof(GameObject));
			((MelonBase)this).LoggerInstance.Msg($"[FULL DIAGNOSTICS] Total GameObjects: {array?.Length ?? 0}");
			if (array == null)
			{
				return;
			}
			int num = 0;
			foreach (GameObject item in array.Cast<GameObject>())
			{
				string text = ((Object)item).name ?? "";
				if (text.Contains("Lobby", StringComparison.OrdinalIgnoreCase) || text.Contains("Canvas", StringComparison.OrdinalIgnoreCase) || text.Contains("UI", StringComparison.OrdinalIgnoreCase) || text.Contains("Splash", StringComparison.OrdinalIgnoreCase) || text.Contains("Login", StringComparison.OrdinalIgnoreCase) || text.Contains("Network", StringComparison.OrdinalIgnoreCase) || text.Contains("Manager", StringComparison.OrdinalIgnoreCase) || text.Contains("Camera", StringComparison.OrdinalIgnoreCase) || text.Contains("Loading", StringComparison.OrdinalIgnoreCase))
				{
					((MelonBase)this).LoggerInstance.Msg($"  GO: '{GetTransformPath(item.transform)}' active={item.activeSelf} inHierarchy={item.activeInHierarchy}");
					num++;
					if (num >= 100)
					{
						break;
					}
				}
			}
		}

		private static string SafeTag(GameObject gameObject)
		{
			try
			{
				return gameObject.tag;
			}
			catch
			{
				return "";
			}
		}

		private void LogSceneRootsReflective(Scene scene)
		{
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				MethodInfo methodInfo = typeof(Scene).GetMethods(BindingFlags.Instance | BindingFlags.Public).FirstOrDefault((MethodInfo method) => !(method.Name != "GetRootGameObjects") && method.GetParameters().Length == 0);
				if (methodInfo == null)
				{
					((MelonBase)this).LoggerInstance.Msg("Loaded UI diagnostics root scan unavailable: Scene.GetRootGameObjects not present.");
					return;
				}
				object obj = scene;
				if (methodInfo.Invoke(obj, null) is GameObject[] array)
				{
					((MelonBase)this).LoggerInstance.Msg($"Loaded UI diagnostics roots={array.Length}: {string.Join(", ", from root in array.Take(16)
						select ((Object)root).name)}");
				}
			}
			catch (Exception ex)
			{
				((MelonBase)this).LoggerInstance.Msg("Loaded UI diagnostics root scan failed: " + ex.GetBaseException().Message);
			}
		}

		private static string GetTransformPath(Transform transform)
		{
			List<string> list = new List<string>();
			Transform val = transform;
			while ((Object)(object)val != (Object)null)
			{
				list.Add(((Object)val).name);
				val = val.parent;
			}
			list.Reverse();
			return string.Join("/", list);
		}

		private static void EnsureLobbyCanvasVisible(object lobby)
		{
			object? memberValue = GetMemberValue(lobby, "canvasGroup");
			CanvasGroup val = (CanvasGroup)((memberValue is CanvasGroup) ? memberValue : null);
			if (val != null)
			{
				val.alpha = 1f;
				val.interactable = true;
				val.blocksRaycasts = true;
			}
		}

		private static bool HideSplashObject(object splash)
		{
			bool flag = false;
			SetMemberValue(splash, "LoginCancelled", false);
			flag = InvokeInstance(splash, "HideLogin") != null || flag;
			flag = InvokeInstance(splash, "HideLoginSpinner") != null || flag;
			flag = InvokeInstance(splash, "HideLoginProviders") != null || flag;
			flag = InvokeInstance(splash, "HideSplashSpinner") != null || flag;
			flag = InvokeInstance(splash, "HideLoadingSimpleScreen", 0f) != null || flag;
			flag = InvokeInstance(splash, "HideSplashScreen") != null || flag;
			flag = HideSplashCanvasGroup(GetMemberValue(splash, "_loginScreen")) || flag;
			flag = HideSplashCanvasGroup(GetMemberValue(splash, "_loadingSimpleScreen")) || flag;
			flag = HideSplashCanvasGroup(GetMemberValue(splash, "_loadingMainScreen")) || flag;
			object? memberValue = GetMemberValue(splash, "gameObject");
			GameObject val = (GameObject)((memberValue is GameObject) ? memberValue : null);
			if (val != null)
			{
				val.SetActive(false);
				flag = true;
			}
			return flag;
		}

		private static bool HideSplashCanvasGroup(object? screen)
		{
			if (screen == null)
			{
				return false;
			}
			bool flag = false;
			object? memberValue = GetMemberValue(screen, "CanvasGroup");
			CanvasGroup val = (CanvasGroup)((memberValue is CanvasGroup) ? memberValue : null);
			if (val != null)
			{
				val.alpha = 0f;
				val.interactable = false;
				val.blocksRaycasts = false;
				flag = true;
			}
			object memberValue2 = GetMemberValue(screen, "LoadingSpinner");
			if (memberValue2 != null)
			{
				flag = HideSplashCanvasGroup(memberValue2) || flag;
			}
			return flag;
		}

		private bool TryProcessBootstrapPayload(BootstrapPayload payload)
		{
			Type type = FindType("Il2CppBAPBAP.Network.GameNetworkManager") ?? FindType("Il2CppBAPBAP.Network.GameNetworkManager") ?? FindType("BAPBAP.Network.GameNetworkManager");
			object obj = ((type == null) ? null : FindGameNetworkManagers(type).FirstOrDefault());
			if (obj == null)
			{
				SetBootstrapRepairStatus("Waiting for GameNetworkManager before applying " + payload.Path + ".", logRepeated: false);
				return false;
			}
			string text;
			string text2;
			switch (payload.Path)
			{
			case "/setup-game":
				text = "OnServerMatchSetup";
				text2 = "BAPBAP.Network.MatchmakingGameData";
				break;
			case "/add-teams":
				text = "OnServerMatchAddTeams";
				text2 = "BAPBAP.Network.MatchmakingTeamData";
				break;
			case "/queue-matched":
				text = "OnServerQueueMatched";
				text2 = "BAPBAP.Network.QueueMatchedData";
				break;
			default:
				return true;
			}
			Type type2 = FindType(text2);
			if (type2 == null)
			{
				SetBootstrapRepairStatus("Waiting for bootstrap payload type " + text2 + ".", logRepeated: false);
				return false;
			}
			try
			{
				TryConfigureDedicatedGameManagers();
				if (payload.Path == "/setup-game" && _setupGameApplied)
				{
					return true;
				}
				if (payload.Path == "/add-teams" && _addTeamsApplied)
				{
					return true;
				}
				if (payload.Path == "/queue-matched" && _queueMatchedApplied)
				{
					return true;
				}
				if (payload.Path != "/setup-game" && !IsServerMatchMapReady(obj))
				{
					SetBootstrapRepairStatus("Waiting for loaded map before applying " + payload.Path + ".", logRepeated: false);
					return false;
				}
				if (payload.Path == "/setup-game" && !IsMirrorServerActive(obj))
				{
					SetBootstrapRepairStatus("Waiting for Mirror server to be active before applying /setup-game.", logRepeated: false);
					return false;
				}
				PatchLoadedGameModeLevelNames();
				object obj2 = CreateIl2CppPayload(type2, payload.Json);
				if (obj2 == null)
				{
					SetBootstrapRepairStatus("Could not create payload for " + payload.Path + ".", logRepeated: false);
					return false;
				}
				ApplyGameManagerBootstrapState(obj, payload.Path, obj2);
				InvokeInstance(obj, text, obj2);
				ApplyGameManagerBootstrapState(obj, payload.Path, obj2);
				SetBootstrapRepairStatus($"Applied managed match bootstrap payload {payload.Path} via {text}.", logRepeated: true);
				switch (payload.Path)
				{
				case "/setup-game":
					_setupGameApplied = true;
					break;
				case "/add-teams":
					_addTeamsApplied = true;
					break;
				case "/queue-matched":
					_queueMatchedApplied = true;
					break;
				}
				return true;
			}
			catch (Exception ex)
			{
				string message = ex.GetBaseException().Message;
				string value = ex.GetBaseException().StackTrace ?? "(no stack)";
				if (payload.Path == "/setup-game" && !_setupGameFailureLogged)
				{
					_setupGameFailureLogged = true;
					((MelonBase)this).LoggerInstance.Warning($"Bootstrap /setup-game permanent failure: {message}\nFull stack:\n{value}\nFurther retries on /setup-game will be silently skipped.");
				}
				else if (payload.Path != "/setup-game")
				{
					SetBootstrapRepairStatus("Bootstrap payload " + payload.Path + " failed: " + message, logRepeated: false);
				}
				return false;
			}
		}

		private void ApplyGameManagerBootstrapState(object gameNetworkManager, string path, object il2CppPayload)
		{
			string text = ((path == "/setup-game") ? "mgd" : ((!(path == "/queue-matched")) ? null : "qmd"));
			string text2 = text;
			if (text2 == null)
			{
				return;
			}
			int num = 0;
			if (SetGameManagerBootstrapMember(GetMemberValue(gameNetworkManager, "gameManager"), text2, il2CppPayload))
			{
				num++;
			}
			if (num > 0)
			{
				SetBootstrapRepairStatus("Assigned GameManager." + text2 + " on primary GameManager (single-instance write).", logRepeated: true);
				return;
			}
			Type type = FindType("BAPBAP.Game.GameManager");
			if (type != null && SetGameManagerBootstrapMember(type.GetProperty("Instance", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)?.GetValue(null) ?? type.GetField("Instance", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)?.GetValue(null), text2, il2CppPayload))
			{
				SetBootstrapRepairStatus("Assigned GameManager." + text2 + " via GameManager.Instance fallback.", logRepeated: true);
			}
		}

		private static bool SetGameManagerBootstrapMember(object? gameManager, string memberName, object il2CppPayload)
		{
			if (gameManager == null)
			{
				return false;
			}
			return SetMemberValue(gameManager, memberName, il2CppPayload);
		}

		private void TryRebindCurrentGameModeToPopulatedInstance()
		{
			if (_currentGameModeRebound)
			{
				return;
			}
			_rebindAttemptCount++;
			object obj = FindPrimaryGameManager();
			if (obj == null)
			{
				string text = "no-primary";
				if (_lastRebindStateLogged != text)
				{
					((MelonBase)this).LoggerInstance.Msg("[MapFix] no primary GameManager found yet.");
					_lastRebindStateLogged = text;
				}
				return;
			}
			object memberValue = GetMemberValue(obj, "gameModes");
			if (memberValue == null)
			{
				string text2 = "no-gameModes";
				if (_lastRebindStateLogged != text2)
				{
					((MelonBase)this).LoggerInstance.Msg("[MapFix] GameManager.gameModes is null. Will retry.");
					_lastRebindStateLogged = text2;
				}
				return;
			}
			List<object> list = new List<object>();
			try
			{
				if (memberValue is Array array)
				{
					for (int i = 0; i < array.Length; i++)
					{
						list.Add(array.GetValue(i));
					}
				}
				else if (memberValue is IEnumerable enumerable)
				{
					foreach (object item in enumerable)
					{
						list.Add(item);
					}
				}
				else
				{
					PropertyInfo propertyInfo = memberValue.GetType().GetProperty("Length") ?? memberValue.GetType().GetProperty("Count");
					PropertyInfo property = memberValue.GetType().GetProperty("Item", new Type[1] { typeof(int) });
					if (!(propertyInfo != null) || !(property != null))
					{
						return;
					}
					int num = (int)(propertyInfo.GetValue(memberValue) ?? ((object)0));
					for (int j = 0; j < num; j++)
					{
						object value = property.GetValue(memberValue, new object[1] { j });
						if (value != null)
						{
							list.Add(value);
						}
					}
				}
			}
			catch
			{
				return;
			}
			if (list.Count == 0)
			{
				string text3 = "empty-gameModes";
				if (_lastRebindStateLogged != text3)
				{
					((MelonBase)this).LoggerInstance.Msg("[MapFix] gameModes empty. Will retry.");
					_lastRebindStateLogged = text3;
				}
				return;
			}
			object obj3 = null;
			List<int> list2 = new List<int>();
			for (int k = 0; k < list.Count; k++)
			{
				object obj4 = list[k];
				if (obj4 == null)
				{
					list2.Add(-1);
					continue;
				}
				try
				{
					object memberValue2 = GetMemberValue(obj4, "spawnPoints");
					int num2 = -1;
					if (memberValue2 is ICollection collection)
					{
						num2 = collection.Count;
					}
					else if (memberValue2 != null)
					{
						PropertyInfo propertyInfo2 = memberValue2.GetType().GetProperty("Count") ?? memberValue2.GetType().GetProperty("Length");
						if (propertyInfo2 != null)
						{
							num2 = (int)(propertyInfo2.GetValue(memberValue2) ?? ((object)(-1)));
						}
					}
					list2.Add(num2);
					if (num2 > 0 && obj3 == null)
					{
						obj3 = obj4;
					}
				}
				catch
				{
					list2.Add(-2);
				}
			}
			if (obj3 == null)
			{
				string text4 = "no-populated-counts=" + string.Join(",", list2);
				if (_lastRebindStateLogged != text4)
				{
					((MelonBase)this).LoggerInstance.Msg($"[MapFix] {list.Count} GameMode(s), spawnCounts=[{string.Join(",", list2)}]. Waiting for populated map...");
					_lastRebindStateLogged = text4;
				}
				return;
			}
			object memberValue3 = GetMemberValue(obj, "currentGameMode");
			if (memberValue3 == obj3)
			{
				_currentGameModeRebound = true;
				((MelonBase)this).LoggerInstance.Msg($"[MapFix] currentGameMode already populated ({obj3.GetType().Name}, counts=[{string.Join(",", list2)}]). Rebind skipped.");
			}
			else if (SetMemberValue(obj, "currentGameMode", obj3))
			{
				_currentGameModeRebound = true;
				string value2 = memberValue3?.GetType()?.Name ?? "null";
				((MelonBase)this).LoggerInstance.Msg($"[MapFix] Rebound currentGameMode from {value2} to populated {obj3.GetType().Name} (counts=[{string.Join(",", list2)}]).");
			}
			else
			{
				((MelonBase)this).LoggerInstance.Msg("[MapFix] SetMemberValue currentGameMode failed.");
			}
		}

		private void TryCopySpawnPointsToAllGameModes()
		{
			if (_spawnPointsCopied || !_currentGameModeRebound || !IsRunningAsDedicatedServer())
			{
				return;
			}
			object obj = FindPrimaryGameManager();
			if (obj == null)
			{
				return;
			}
			object memberValue = GetMemberValue(obj, "gameModes");
			if (memberValue == null)
			{
				return;
			}
			List<object> list = new List<object>();
			try
			{
				if (memberValue is Array array)
				{
					for (int i = 0; i < array.Length; i++)
					{
						list.Add(array.GetValue(i));
					}
				}
				else if (memberValue is IEnumerable enumerable)
				{
					foreach (object item in enumerable)
					{
						list.Add(item);
					}
				}
				else
				{
					PropertyInfo propertyInfo = memberValue.GetType().GetProperty("Length") ?? memberValue.GetType().GetProperty("Count");
					PropertyInfo property = memberValue.GetType().GetProperty("Item", new Type[1] { typeof(int) });
					if (propertyInfo != null && property != null)
					{
						int num = (int)(propertyInfo.GetValue(memberValue) ?? ((object)0));
						for (int j = 0; j < num; j++)
						{
							list.Add(property.GetValue(memberValue, new object[1] { j }));
						}
					}
				}
			}
			catch
			{
				return;
			}
			if (list.Count <= 1)
			{
				_spawnPointsCopied = true;
				return;
			}
			object obj3 = null;
			foreach (object item2 in list)
			{
				if (item2 == null)
				{
					continue;
				}
				try
				{
					object memberValue2 = GetMemberValue(item2, "spawnPoints");
					if (memberValue2 is ICollection { Count: >0 })
					{
						obj3 = item2;
						break;
					}
					if (memberValue2 != null)
					{
						PropertyInfo propertyInfo2 = memberValue2.GetType().GetProperty("Count") ?? memberValue2.GetType().GetProperty("Length");
						if (propertyInfo2 != null && Convert.ToInt32(propertyInfo2.GetValue(memberValue2) ?? ((object)0)) > 0)
						{
							obj3 = item2;
							break;
						}
					}
				}
				catch
				{
				}
			}
			if (obj3 == null)
			{
				return;
			}
			object memberValue3 = GetMemberValue(obj3, "spawnPoints");
			object memberValue4 = GetMemberValue(obj3, "availableSpawnPoints");
			object memberValue5 = GetMemberValue(obj3, "dimensionSpawnPoints");
			object memberValue6 = GetMemberValue(obj3, "currentEnvManager");
			int num2 = 0;
			foreach (object item3 in list)
			{
				if (item3 == null || item3 == obj3)
				{
					continue;
				}
				try
				{
					if (memberValue3 != null)
					{
						SetMemberValue(item3, "spawnPoints", memberValue3);
					}
					if (memberValue4 != null)
					{
						SetMemberValue(item3, "availableSpawnPoints", memberValue4);
					}
					if (memberValue5 != null)
					{
						SetMemberValue(item3, "dimensionSpawnPoints", memberValue5);
					}
					if (memberValue6 != null)
					{
						SetMemberValue(item3, "currentEnvManager", memberValue6);
					}
					num2++;
				}
				catch (Exception ex)
				{
					((MelonBase)this).LoggerInstance.Msg("[MapFix] copy spawnPoints failed: " + ex.GetBaseException().Message);
				}
			}
			if (num2 > 0)
			{
				((MelonBase)this).LoggerInstance.Msg($"[MapFix] Copied spawn points/envManager from populated GameMode to {num2} duplicate(s).");
			}
			_spawnPointsCopied = true;
		}

		private void TryDestroyDuplicateGameModes()
		{
			if (_duplicatesGameModesDestroyed || !_currentGameModeRebound || !IsRunningAsDedicatedServer())
			{
				return;
			}
			object obj = FindPrimaryGameManager();
			if (obj == null)
			{
				return;
			}
			object memberValue = GetMemberValue(obj, "gameModes");
			if (memberValue == null)
			{
				return;
			}
			List<object> list = new List<object>();
			try
			{
				if (memberValue is Array array)
				{
					for (int i = 0; i < array.Length; i++)
					{
						list.Add(array.GetValue(i));
					}
				}
				else if (memberValue is IEnumerable enumerable)
				{
					foreach (object item in enumerable)
					{
						list.Add(item);
					}
				}
				else
				{
					PropertyInfo propertyInfo = memberValue.GetType().GetProperty("Length") ?? memberValue.GetType().GetProperty("Count");
					PropertyInfo property = memberValue.GetType().GetProperty("Item", new Type[1] { typeof(int) });
					if (propertyInfo != null && property != null)
					{
						int num = (int)(propertyInfo.GetValue(memberValue) ?? ((object)0));
						for (int j = 0; j < num; j++)
						{
							list.Add(property.GetValue(memberValue, new object[1] { j }));
						}
					}
				}
			}
			catch
			{
				return;
			}
			if (list.Count <= 1)
			{
				_duplicatesGameModesDestroyed = true;
				return;
			}
			object memberValue2 = GetMemberValue(obj, "currentGameMode");
			if (memberValue2 == null)
			{
				return;
			}
			int num2 = 0;
			foreach (object item2 in list)
			{
				if (item2 == null || item2 == memberValue2)
				{
					continue;
				}
				try
				{
					PropertyInfo property2 = item2.GetType().GetProperty("enabled");
					if (property2 != null && property2.CanWrite)
					{
						property2.SetValue(item2, false);
						num2++;
					}
				}
				catch (Exception ex)
				{
					((MelonBase)this).LoggerInstance.Msg("[MapFix] disable duplicate failed: " + ex.GetBaseException().Message);
				}
			}
			if (num2 > 0)
			{
				((MelonBase)this).LoggerInstance.Msg($"[MapFix] Disabled .enabled on {num2} duplicate GameMode behaviour(s) (kept GameObject intact).");
			}
			_duplicatesGameModesDestroyed = true;
		}

		private bool IsRunningAsDedicatedServer()
		{
			try
			{
				Type type = FindType("Il2CppMirror.NetworkServer") ?? FindType("Il2CppMirror.NetworkServer") ?? FindType("Mirror.NetworkServer");
				if (type != null)
				{
					PropertyInfo property = type.GetProperty("active", BindingFlags.Static | BindingFlags.Public);
					if (property != null)
					{
						object value = property.GetValue(null);
						if (value is bool)
						{
							return (bool)value;
						}
					}
				}
			}
			catch
			{
			}
			return false;
		}

		private void TryForceOnMatchStarted()
		{
			if (_onMatchStartedForced || !_currentGameModeRebound)
			{
				return;
			}
			MelonPreferences_Entry<bool> forceOnMatchStartedEnabled = _forceOnMatchStartedEnabled;
			if (forceOnMatchStartedEnabled == null || !forceOnMatchStartedEnabled.Value)
			{
				_onMatchStartedForced = true;
				return;
			}
			if (!IsRunningAsDedicatedServer())
			{
				_onMatchStartedForced = true;
				return;
			}
			_forceMatchStartAttemptCount++;
			bool flag = _forceMatchStartAttemptCount % 300 == 1;
			object obj = FindPrimaryGameManager();
			if (obj == null)
			{
				if (flag)
				{
					((MelonBase)this).LoggerInstance.Msg("[MapFix] force OnMatchStarted: no primary GameManager.");
				}
				return;
			}
			try
			{
				object memberValue = GetMemberValue(obj, "preMatchManager");
				if (memberValue != null)
				{
					object obj2 = GetMemberValue(memberValue, "CurrentState") ?? GetMemberValue(memberValue, "currentState");
					if (obj2 != null)
					{
						int num = Convert.ToInt32(obj2);
						if (num < 3)
						{
							if (flag)
							{
								((MelonBase)this).LoggerInstance.Msg($"[MapFix] preMatchState={num} (still in WaitingForPlayers/CharSelect/SpawnSelect). Waiting...");
							}
							return;
						}
					}
				}
			}
			catch (Exception ex)
			{
				if (flag)
				{
					((MelonBase)this).LoggerInstance.Msg("[MapFix] preMatchManager state check failed: " + ex.GetBaseException().Message);
				}
			}
			object memberValue2 = GetMemberValue(obj, "matchStarted");
			bool flag2 = default(bool);
			int num2;
			if (memberValue2 is bool)
			{
				flag2 = (bool)memberValue2;
				num2 = 1;
			}
			else
			{
				num2 = 0;
			}
			if (((uint)num2 & (flag2 ? 1u : 0u)) != 0)
			{
				_onMatchStartedForced = true;
				((MelonBase)this).LoggerInstance.Msg("[MapFix] matchStarted=true already, no force needed.");
				return;
			}
			object memberValue3 = GetMemberValue(obj, "currentGameMode");
			if (memberValue3 == null)
			{
				if (flag)
				{
					((MelonBase)this).LoggerInstance.Msg("[MapFix] force OnMatchStarted: currentGameMode is null.");
				}
				return;
			}
			string[] array = new string[2] { "OnMatchStarted", "OnMatchBegin" };
			foreach (string text in array)
			{
				try
				{
					MethodInfo method = memberValue3.GetType().GetMethod(text, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
					if (method != null)
					{
						method.Invoke(memberValue3, null);
						((MelonBase)this).LoggerInstance.Msg("[MapFix] Forced gameMode." + text + "() to kick off match timer / zone / audio.");
					}
				}
				catch (Exception ex2)
				{
					((MelonBase)this).LoggerInstance.Msg("[MapFix] " + text + "() invocation failed: " + ex2.GetBaseException().Message);
				}
			}
			try
			{
				MethodInfo methodInfo = null;
				MethodInfo[] methods = memberValue3.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (MethodInfo methodInfo2 in methods)
				{
					if (methodInfo2.Name == "StartZoneRound" && methodInfo2.GetParameters().Length == 1)
					{
						methodInfo = methodInfo2;
						break;
					}
				}
				if (methodInfo != null)
				{
					methodInfo.Invoke(memberValue3, new object[1] { 0 });
					((MelonBase)this).LoggerInstance.Msg("[MapFix] Forced gameMode.StartZoneRound(0) to start zone + crate respawn loop.");
				}
				else
				{
					Type type = FindType("BAPBAP.Game.GameModeBattleRoyale");
					if (type != null)
					{
						methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
						foreach (MethodInfo methodInfo3 in methods)
						{
							if (methodInfo3.Name == "StartZoneRound" && methodInfo3.GetParameters().Length == 1)
							{
								methodInfo = methodInfo3;
								break;
							}
						}
						if (methodInfo != null && type.IsAssignableFrom(memberValue3.GetType()))
						{
							methodInfo.Invoke(memberValue3, new object[1] { 0 });
							((MelonBase)this).LoggerInstance.Msg("[MapFix] Forced gameMode.StartZoneRound(0) via BattleRoyale type.");
						}
						else
						{
							((MelonBase)this).LoggerInstance.Msg("[MapFix] StartZoneRound not found on " + memberValue3.GetType().FullName + ". Match should still progress via natural lifecycle.");
						}
					}
				}
			}
			catch (Exception ex3)
			{
				((MelonBase)this).LoggerInstance.Msg("[MapFix] StartZoneRound(0) failed: " + ex3.GetBaseException().Message);
			}
			_onMatchStartedForced = true;
		}

		private void TryInstallLockerCrashGuard()
		{
			if (_lockerCrashGuardInstalled)
			{
				return;
			}
			Type type = FindType("Il2CppBAPBAP.UI.UILobbyLockerTabPage") ?? FindType("BAPBAP.UI.UILobbyLockerTabPage");
			if (type == null)
			{
				return;
			}
			MethodInfo method = typeof(CustomServerMod).GetMethod("LockerCrashFinalizer", BindingFlags.Static | BindingFlags.NonPublic);
			if (method == null)
			{
				return;
			}
			int num = 0;
			string[] array = new string[10] { "AddContentEntry", "AddSkinEntry", "AddBannerEntry", "AddEmoteEntry", "AddTombstoneEntry", "UpdateDisplayedSkins", "SetSkinsEquipButtonState", "InitializeSelectPanelContent", "OnContentEntrySelected", "UpdateData" };
			foreach (string text in array)
			{
				try
				{
					MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					foreach (MethodInfo methodInfo in methods)
					{
						if (methodInfo.Name == text && PatchHarmonyFinalizer(methodInfo, method))
						{
							num++;
							break;
						}
					}
				}
				catch
				{
				}
			}
			if (num > 0)
			{
				_lockerCrashGuardInstalled = true;
				((MelonBase)this).LoggerInstance.Msg($"[LockerGuard] Installed exception-swallow finalizer on {num} locker method(s)");
			}
		}

		private static Exception? LockerCrashFinalizer(Exception __exception)
		{
			return null;
		}

		private void TryInstallShopThrottle()
		{
			if (_shopThrottleInstalled)
			{
				return;
			}
			Type type = FindType("Il2CppBAPBAP.UI.UILobbyShopTabPage") ?? FindType("BAPBAP.UI.UILobbyShopTabPage");
			if (type == null)
			{
				return;
			}
			MethodInfo method = typeof(CustomServerMod).GetMethod("ShopThrottlePrefix", BindingFlags.Static | BindingFlags.NonPublic);
			if (method == null)
			{
				return;
			}
			int num = 0;
			string[] array = new string[3] { "SendShopRequest", "RequestShop", "FetchShop" };
			foreach (string name in array)
			{
				try
				{
					MethodInfo method2 = type.GetMethod(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
					if (method2 != null && PatchHarmonyPrefix(method2, method))
					{
						num++;
					}
				}
				catch
				{
				}
			}
			if (num > 0)
			{
				_shopThrottleInstalled = true;
				((MelonBase)this).LoggerInstance.Msg($"[ShopThrottle] Patched {num} method(s)");
			}
		}

		private static bool ShopThrottlePrefix()
		{
			double totalSeconds = (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
			if (totalSeconds - _lastShopRequestUtcSeconds < 5.0)
			{
				return false;
			}
			_lastShopRequestUtcSeconds = totalSeconds;
			return true;
		}

		private void TryInstallDevPanelHidePatch()
		{
			MelonPreferences_Entry<bool> allowDevPanelEntry = _allowDevPanelEntry;
			if (allowDevPanelEntry != null && allowDevPanelEntry.Value)
			{
				return;
			}
			_devPanelAttemptCount++;
			bool flag = _devPanelAttemptCount % 120 == 1;
			string[] array = new string[14]
			{
				"BAPBAP.UI.UIDeveloperLobby", "BAPBAP.UI.UIDevUtilities", "BAPBAP.UI.UIDevLobbyCharButton", "BAPBAP.UI.View_Lobby_Developer", "BAPBAP.UI.UIDeveloperPanel", "BAPBAP.UI.DeveloperPanel", "BAPBAP.UI.UIDevPanel", "BAPBAP.UI.UIInGameDevPanel", "BAPBAP.UI.UIInMatchDeveloperPanel", "BAPBAP.UI.UIDebugPanel",
				"BAPBAP.UI.UIInGameDebugPanel", "BAPBAP.UI.UIDebug", "BAPBAP.UI.UIDevTools", "BAPBAP.UI.UIInMatchDevTools"
			};
			if (_devPanelHidePatchInstalled)
			{
				return;
			}
			MethodInfo method = typeof(CustomServerMod).GetMethod("DevPanelHidePostfix", BindingFlags.Static | BindingFlags.NonPublic);
			if (method == null)
			{
				return;
			}
			List<string> list = new List<string>();
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				Type type = FindType(array2[i]);
				if (type == null || _devPanelTypesPatched.Contains(type))
				{
					continue;
				}
				int num = 0;
				string[] array3 = new string[7] { "OnEnable", "Awake", "Show", "Open", "Initialize", "Initialise", "Start" };
				foreach (string name in array3)
				{
					try
					{
						MethodInfo method2 = type.GetMethod(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
						if (method2 != null && PatchHarmonyPostfix(method2, method))
						{
							num++;
						}
					}
					catch
					{
					}
				}
				if (num > 0)
				{
					_devPanelTypesPatched.Add(type);
					list.Add($"{type.Name}({num})");
				}
			}
			if (list.Count > 0)
			{
				((MelonBase)this).LoggerInstance.Msg($"[DevPanel] Patched {list.Count} type(s) for hide on activation: {string.Join(", ", list)}");
			}
			else if (flag)
			{
				try
				{
					Type type2 = FindType("BAPBAP.UI.UILobbyPlayTabPage");
					if (type2 != null)
					{
						Assembly assembly = type2.Assembly;
						List<string> list2 = new List<string>();
						Type[] types = assembly.GetTypes();
						foreach (Type type3 in types)
						{
							if (!(type3 == null) && type3.FullName != null && type3.FullName.StartsWith("BAPBAP.") && (type3.FullName.IndexOf("Dev", StringComparison.OrdinalIgnoreCase) >= 0 || type3.FullName.IndexOf("Debug", StringComparison.OrdinalIgnoreCase) >= 0))
							{
								list2.Add(type3.FullName);
							}
						}
						if (list2.Count > 0)
						{
							((MelonBase)this).LoggerInstance.Msg($"[DevPanel] attempt={_devPanelAttemptCount} no exact match. Available BAPBAP Dev/Debug types: [{string.Join(", ", list2.Take(15))}]");
						}
						else
						{
							((MelonBase)this).LoggerInstance.Msg($"[DevPanel] attempt={_devPanelAttemptCount} no Dev/Debug types found at all in BAPBAP assembly.");
						}
					}
				}
				catch (Exception ex)
				{
					((MelonBase)this).LoggerInstance.Msg("[DevPanel] type scan failed: " + ex.GetBaseException().Message);
				}
			}
			if (_devPanelTypesPatched.Count > 0)
			{
				_devPanelHidePatchInstalled = true;
			}
		}

		private static void DevPanelHidePostfix(object __instance)
		{
			try
			{
				if (__instance != null)
				{
					object obj = __instance.GetType().GetProperty("gameObject")?.GetValue(__instance);
					obj?.GetType().GetMethod("SetActive", new Type[1] { typeof(bool) })?.Invoke(obj, new object[1] { false });
				}
			}
			catch
			{
			}
		}

		private void TryDisableLocalPlayerInterp()
		{
			if (_interpDisablePatchInstalled)
			{
				return;
			}
			_interpScanAttempts++;
			bool flag = _interpScanAttempts % 60 == 1;
			if ((object)FindType("Il2CppMirror.NetworkBehaviour") == null)
			{
				FindType("Mirror.NetworkBehaviour");
			}
			Type type = FindType("Il2CppMirror.NetworkTransformBase") ?? FindType("Mirror.NetworkTransformBase") ?? FindType("Il2CppMirror.NetworkTransform") ?? FindType("Mirror.NetworkTransform");
			if (type == null)
			{
				if (flag)
				{
					((MelonBase)this).LoggerInstance.Msg("[InterpFix] NetworkTransform type not found yet");
				}
				return;
			}
			Array array = FindLoadedUnityObjects(type);
			if (array == null || array.Length == 0)
			{
				if (flag)
				{
					((MelonBase)this).LoggerInstance.Msg($"[InterpFix] no NetworkTransform instances yet (attempt={_interpScanAttempts})");
				}
				return;
			}
			int num = 0;
			bool flag2 = default(bool);
			foreach (object item in array)
			{
				if (item == null)
				{
					continue;
				}
				try
				{
					object obj = GetMemberValue(item, "isOwned") ?? GetMemberValue(item, "hasAuthority");
					int num2;
					if (obj is bool)
					{
						flag2 = (bool)obj;
						num2 = 1;
					}
					else
					{
						num2 = 0;
					}
					if (((uint)num2 & (flag2 ? 1u : 0u)) != 0)
					{
						SetMemberValue(item, "interpolatePosition", false);
						SetMemberValue(item, "interpolateRotation", false);
						SetMemberValue(item, "interpolateScale", false);
						num++;
					}
				}
				catch
				{
				}
			}
			if (num > 0)
			{
				_interpDisablePatchInstalled = true;
				((MelonBase)this).LoggerInstance.Msg($"[InterpFix] Disabled interpolation on {num} owner NetworkTransform(s)");
			}
		}

		private void TryInstallNetworkTunerHarmonyPatch()
		{
			if (_networkTunerHarmonyInstalled)
			{
				return;
			}
			MelonPreferences_Entry<bool> netTuneEnabledEntry = _netTuneEnabledEntry;
			if (netTuneEnabledEntry != null && !netTuneEnabledEntry.Value)
			{
				_networkTunerHarmonyInstalled = true;
				return;
			}
			Type type = FindType("Il2CppBAPBAP.Network.GameNetworkManager") ?? FindType("Il2CppBAPBAP.Network.GameNetworkManager") ?? FindType("BAPBAP.Network.GameNetworkManager");
			if (!_networkTunerLoggedAttempt)
			{
				_networkTunerLoggedAttempt = true;
				((MelonBase)this).LoggerInstance.Msg($"[NetTune] Looking for GameNetworkManager type... found={type != null}");
				if (type == null)
				{
					string[] value = (from t in AppDomain.CurrentDomain.GetAssemblies().SelectMany(delegate(Assembly a)
						{
							try
							{
								return a.GetTypes();
							}
							catch
							{
								return Array.Empty<Type>();
							}
						})
						where t.FullName != null && t.FullName.Contains("GameNetworkManager")
						select t.FullName).Take(5).ToArray();
					((MelonBase)this).LoggerInstance.Msg("[NetTune] GameNetworkManager candidates: " + string.Join(", ", value));
				}
			}
			if (type == null)
			{
				return;
			}
			MethodInfo method = typeof(CustomServerMod).GetMethod("NetworkTunerPostfix", BindingFlags.Static | BindingFlags.NonPublic);
			if (method == null)
			{
				return;
			}
			int num = 0;
			string[] array = new string[4] { "Awake", "Start", "OnStartServer", "OnStartClient" };
			foreach (string name in array)
			{
				try
				{
					MethodInfo method2 = type.GetMethod(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
					if (method2 != null && PatchHarmonyPostfix(method2, method))
					{
						num++;
					}
				}
				catch
				{
				}
			}
			if (num > 0)
			{
				_networkTunerHarmonyInstalled = true;
				((MelonBase)this).LoggerInstance.Msg($"[NetTune] Harmony postfix on {num} GameNetworkManager hook(s).");
			}
		}

		private static void NetworkTunerPostfix()
		{
			try
			{
				Type[] array = new Type[4]
				{
					FindTypeStatic("Mirror.NetworkServer"),
					FindTypeStatic("Il2CppMirror.NetworkServer"),
					FindTypeStatic("Mirror.NetworkClient"),
					FindTypeStatic("Il2CppMirror.NetworkClient")
				}.Where((Type t) => t != null).Cast<Type>().ToArray();
				int num = 0;
				Type[] array2 = array;
				foreach (Type type in array2)
				{
					try
					{
						PropertyInfo property = type.GetProperty("sendRate", BindingFlags.Static | BindingFlags.Public);
						if (property != null && property.CanWrite)
						{
							property.SetValue(null, 60);
							num++;
						}
						FieldInfo field = type.GetField("sendRate", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
						if (field != null)
						{
							field.SetValue(null, 60);
							num++;
						}
						PropertyInfo property2 = type.GetProperty("tickRate", BindingFlags.Static | BindingFlags.Public);
						if (property2 != null && property2.CanWrite)
						{
							property2.SetValue(null, 60);
							num++;
						}
						FieldInfo field2 = type.GetField("tickRate", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
						if (field2 != null)
						{
							field2.SetValue(null, 60);
							num++;
						}
						FieldInfo field3 = type.GetField("snapshotSettings", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
						if (!(field3 != null))
						{
							continue;
						}
						object value = field3.GetValue(null);
						if (value != null)
						{
							FieldInfo field4 = value.GetType().GetField("bufferTimeMultiplier");
							if (field4 != null)
							{
								field4.SetValue(value, 1.0);
								num++;
							}
							FieldInfo field5 = value.GetType().GetField("dynamicAdjustment");
							if (field5 != null)
							{
								field5.SetValue(value, false);
							}
							field3.SetValue(null, value);
						}
					}
					catch
					{
					}
				}
				if (num > 0)
				{
					MelonLogger.Msg($"[NetTune] Harmony postfix tuned {num} Mirror static field(s) on {array.Length} type candidate(s).");
				}
			}
			catch
			{
			}
		}

		private static Type? FindTypeStatic(string fullName)
		{
			try
			{
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				for (int i = 0; i < assemblies.Length; i++)
				{
					Type type = assemblies[i].GetType(fullName, throwOnError: false);
					if (type != null)
					{
						return type;
					}
				}
			}
			catch
			{
			}
			return null;
		}

		private void TryApplyNetworkTuning()
		{
			if (_networkTuningApplied)
			{
				return;
			}
			MelonPreferences_Entry<bool> netTuneEnabledEntry = _netTuneEnabledEntry;
			if (netTuneEnabledEntry != null && !netTuneEnabledEntry.Value)
			{
				_networkTuningApplied = true;
				return;
			}
			_networkTuneAttemptCount++;
			bool flag = _networkTuneAttemptCount % 300 == 1;
			Type type = FindType("Il2CppMirror.NetworkServer") ?? FindType("Il2CppMirror.NetworkServer") ?? FindType("Mirror.NetworkServer");
			Type type2 = FindType("Il2CppMirror.NetworkClient") ?? FindType("Il2CppMirror.NetworkClient") ?? FindType("Mirror.NetworkClient");
			bool flag2 = false;
			try
			{
				object obj = (type?.GetField("snapshotSettings", BindingFlags.Static | BindingFlags.Public) ?? type?.GetField("snapshotSettings", BindingFlags.Static | BindingFlags.NonPublic))?.GetValue(null);
				if (obj != null)
				{
					FieldInfo field = obj.GetType().GetField("bufferTimeMultiplier");
					if (field != null)
					{
						field.SetValue(obj, 1.0);
						flag2 = true;
					}
					obj.GetType().GetField("dynamicAdjustment")?.SetValue(obj, false);
				}
			}
			catch (Exception ex)
			{
				if (flag)
				{
					((MelonBase)this).LoggerInstance.Msg("[NetTune] Explicit server snapshot tune failed: " + ex.GetBaseException().Message);
				}
			}
			try
			{
				Type[] array = new Type[2] { type, type2 };
				foreach (Type type3 in array)
				{
					if (type3 == null)
					{
						continue;
					}
					object obj2 = type3.GetField("snapshotSettings", BindingFlags.Static | BindingFlags.Public)?.GetValue(null);
					if (obj2 != null)
					{
						FieldInfo field2 = obj2.GetType().GetField("bufferTimeMultiplier");
						if (field2 != null)
						{
							field2.SetValue(obj2, 1.0);
							flag2 = true;
						}
						PropertyInfo property = obj2.GetType().GetProperty("bufferTimeMultiplier");
						if (property != null && property.CanWrite)
						{
							property.SetValue(obj2, 1.0);
							flag2 = true;
						}
						obj2.GetType().GetField("dynamicAdjustment")?.SetValue(obj2, false);
					}
				}
			}
			catch (Exception ex2)
			{
				if (flag)
				{
					((MelonBase)this).LoggerInstance.Msg("[NetTune] Snapshot tune failed: " + ex2.GetBaseException().Message);
				}
			}
			try
			{
				if (type != null)
				{
					PropertyInfo property2 = type.GetProperty("sendRate", BindingFlags.Static | BindingFlags.Public);
					if (property2 != null && property2.CanWrite)
					{
						property2.SetValue(null, 30);
						flag2 = true;
					}
					FieldInfo field3 = type.GetField("sendRate", BindingFlags.Static | BindingFlags.Public);
					if (field3 != null)
					{
						field3.SetValue(null, 30);
						flag2 = true;
					}
				}
			}
			catch (Exception ex3)
			{
				if (flag)
				{
					((MelonBase)this).LoggerInstance.Msg("[NetTune] SendRate tune failed: " + ex3.GetBaseException().Message);
				}
			}
			try
			{
				Type type4 = FindType("Il2Cppkcp2k.KcpTransport") ?? FindType("kcp2k.KcpTransport") ?? FindType("Mirror.KcpTransport");
				if (type4 != null)
				{
					Array array2 = FindLoadedUnityObjects(type4);
					if (array2 != null)
					{
						foreach (object item in array2)
						{
							if (item != null)
							{
								SetMemberValue(item, "NoDelay", true);
								SetMemberValue(item, "Interval", 10u);
								SetMemberValue(item, "FastResend", 2);
								SetMemberValue(item, "CongestionWindow", false);
								SetMemberValue(item, "SendWindowSize", 4096u);
								SetMemberValue(item, "ReceiveWindowSize", 4096u);
								SetMemberValue(item, "Timeout", 30000);
								flag2 = true;
							}
						}
					}
				}
			}
			catch (Exception ex4)
			{
				if (flag)
				{
					((MelonBase)this).LoggerInstance.Msg("[NetTune] KCP tune failed: " + ex4.GetBaseException().Message);
				}
			}
			try
			{
				Type type5 = FindType("Il2CppMirror.NetworkServer") ?? FindType("Mirror.NetworkServer");
				if (type5 != null)
				{
					FieldInfo field4 = type5.GetField("sendInterval", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
					if (field4 != null)
					{
						field4.SetValue(null, 1f / 60f);
						flag2 = true;
					}
					PropertyInfo property3 = type5.GetProperty("sendInterval", BindingFlags.Static | BindingFlags.Public);
					if (property3 != null && property3.CanWrite)
					{
						property3.SetValue(null, 1f / 60f);
						flag2 = true;
					}
				}
			}
			catch (Exception ex5)
			{
				if (flag)
				{
					((MelonBase)this).LoggerInstance.Msg("[NetTune] sendInterval tune failed: " + ex5.GetBaseException().Message);
				}
			}
			if (flag2)
			{
				_networkTuningApplied = true;
				((MelonBase)this).LoggerInstance.Msg("[NetTune] Mirror bufferTimeMultiplier=1, sendRate=30, KCP NoDelay applied (reduces server-feel-slow lag).");
			}
			else if (flag)
			{
				((MelonBase)this).LoggerInstance.Msg($"[NetTune] attempt={_networkTuneAttemptCount} no tunable fields found yet.");
			}
		}

		private void TryDisableCrateRespawn()
		{
			if (_crateRespawnDisabled || !IsRunningAsDedicatedServer() || !_currentGameModeRebound)
			{
				return;
			}
			_crateScanAttemptCount++;
			bool flag = _crateScanAttemptCount % 300 == 1;
			Type type = FindType("BAPBAP.Entities.EntitySpawner");
			if (type == null)
			{
				if (flag)
				{
					((MelonBase)this).LoggerInstance.Msg("[CrateFix] EntitySpawner type not found yet.");
				}
				return;
			}
			Array array = FindLoadedUnityObjects(type);
			if (array == null || array.Length == 0)
			{
				if (flag)
				{
					((MelonBase)this).LoggerInstance.Msg($"[CrateFix] no EntitySpawner instances loaded yet (attempt={_crateScanAttemptCount}).");
				}
				return;
			}
			int num = 0;
			foreach (object item in array)
			{
				if (item == null)
				{
					continue;
				}
				try
				{
					if (SetMemberValue(item, "_respawnAble", false))
					{
						num++;
					}
					else if (SetMemberValue(item, "respawnAble", false))
					{
						num++;
					}
					SetMemberValue(item, "respawnDuration", float.MaxValue);
				}
				catch (Exception ex)
				{
					if (flag)
					{
						((MelonBase)this).LoggerInstance.Msg("[CrateFix] failed to disable on one spawner: " + ex.GetBaseException().Message);
					}
				}
			}
			if (num > 0)
			{
				_crateRespawnDisabled = true;
				((MelonBase)this).LoggerInstance.Msg($"[CrateFix] Disabled crate respawn on {num}/{array.Length} EntitySpawner instance(s).");
			}
			else if (flag)
			{
				((MelonBase)this).LoggerInstance.Msg($"[CrateFix] EntitySpawner has {array.Length} instances but none could be disabled. Field name may differ.");
			}
		}

		private void TryInstallMatchFoundDedupPatch()
		{
			if (_matchFoundDedupPatchInstalled)
			{
				return;
			}
			Type type = FindType("BAPBAP.UI.LobbyController");
			Type type2 = FindType("BAPBAP.UI.MatchmakingController");
			if (type == null && type2 == null)
			{
				return;
			}
			MethodInfo method = typeof(CustomServerMod).GetMethod("MatchFoundDedupPrefix", BindingFlags.Static | BindingFlags.NonPublic);
			if (method == null)
			{
				return;
			}
			int num = 0;
			Type[] array = new Type[2] { type, type2 };
			foreach (Type type3 in array)
			{
				if (type3 == null)
				{
					continue;
				}
				try
				{
					MethodInfo method2 = type3.GetMethod("PlayMatchFoundSequence", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					if (method2 != null && PatchHarmonyPrefix(method2, method))
					{
						num++;
					}
				}
				catch
				{
				}
			}
			if (num > 0)
			{
				_matchFoundDedupPatchInstalled = true;
				((MelonBase)this).LoggerInstance.Msg($"[MatchFoundDedup] Installed dedup prefix on {num} PlayMatchFoundSequence target(s).");
			}
		}

		private static bool MatchFoundDedupPrefix()
		{
			double totalSeconds = (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
			if (totalSeconds - _lastMatchFoundPlayedUtcSeconds < 3.0)
			{
				return false;
			}
			_lastMatchFoundPlayedUtcSeconds = totalSeconds;
			return true;
		}

		private void TryExtendAugmentSelectTimer()
		{
			if (_augmentTimerExtended)
			{
				return;
			}
			_augmentScanAttemptCount++;
			bool flag = _augmentScanAttemptCount % 300 == 1;
			Type type = FindType("BAPBAP.UI.UIAugments");
			if (type == null)
			{
				if (flag)
				{
					((MelonBase)this).LoggerInstance.Msg("[AugmentFix] UIAugments type not found yet.");
				}
				return;
			}
			Array array = FindLoadedUnityObjects(type);
			if (array == null || array.Length == 0)
			{
				if (flag)
				{
					((MelonBase)this).LoggerInstance.Msg($"[AugmentFix] no UIAugments instances loaded yet (attempt={_augmentScanAttemptCount}).");
				}
				return;
			}
			int num = 0;
			foreach (object item in array)
			{
				if (item == null)
				{
					continue;
				}
				try
				{
					if (SetMemberValue(item, "augmentSelectWaitDuration", 30f))
					{
						num++;
					}
					SetMemberValue(item, "augmentRerollWaitDuration", 30f);
				}
				catch
				{
				}
			}
			if (num > 0)
			{
				_augmentTimerExtended = true;
				((MelonBase)this).LoggerInstance.Msg($"[AugmentFix] Extended augmentSelectWaitDuration on {num}/{array.Length} UIAugments instance(s) to 30s.");
			}
		}

		private void TryAutoEndDedicatedMatch()
		{
			float? autoEndAfterSeconds = _autoEndAfterSeconds;
			if (!autoEndAfterSeconds.HasValue || !(autoEndAfterSeconds.GetValueOrDefault() > 0f) || _autoEndInvoked)
			{
				return;
			}
			object obj = FindPrimaryGameManager();
			if (obj == null)
			{
				return;
			}
			object memberValue = GetMemberValue(obj, "matchStarted");
			if (!(memberValue is bool) || !(bool)memberValue)
			{
				return;
			}
			if (!_autoEndMatchObserved)
			{
				_autoEndMatchObserved = true;
				_autoEndMatchStartAt = Time.realtimeSinceStartup;
				((MelonBase)this).LoggerInstance.Msg($"Observed official match start; auto-end scheduled in {_autoEndAfterSeconds.Value:0.##}s.");
			}
			else if (!(Time.realtimeSinceStartup - _autoEndMatchStartAt < _autoEndAfterSeconds.Value))
			{
				try
				{
					InvokeInstance(obj, "EndMatch", 1);
					_autoEndInvoked = true;
					((MelonBase)this).LoggerInstance.Msg("Requested dedicated match auto-end with winnerTeamId=1.");
				}
				catch (Exception ex)
				{
					_autoEndInvoked = true;
					((MelonBase)this).LoggerInstance.Warning("Dedicated match auto-end failed: " + ex.GetBaseException().Message);
				}
			}
		}

		private object? FindPrimaryGameManager()
		{
			Type type = FindType("Il2CppBAPBAP.Network.GameNetworkManager") ?? FindType("Il2CppBAPBAP.Network.GameNetworkManager") ?? FindType("BAPBAP.Network.GameNetworkManager");
			if (type != null)
			{
				foreach (object item in FindGameNetworkManagers(type))
				{
					object memberValue = GetMemberValue(item, "gameManager");
					if (memberValue != null)
					{
						return memberValue;
					}
				}
			}
			Type type2 = FindType("BAPBAP.Game.GameManager");
			if (type2 == null)
			{
				return null;
			}
			object obj = type2.GetProperty("Instance", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)?.GetValue(null) ?? type2.GetField("Instance", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)?.GetValue(null);
			if (obj != null)
			{
				return obj;
			}
			Array array = FindLoadedUnityObjects(type2);
			if (array == null || array.Length <= 0)
			{
				return null;
			}
			return array.GetValue(0);
		}

		private void TryConfigureDedicatedGameManagers()
		{
			if (!_dedicatedProcess)
			{
				return;
			}
			Type type = FindType("BAPBAP.Game.GameManager");
			if (type == null)
			{
				return;
			}
			int num = 0;
			Type type2 = FindType("Il2CppBAPBAP.Network.GameNetworkManager") ?? FindType("Il2CppBAPBAP.Network.GameNetworkManager") ?? FindType("BAPBAP.Network.GameNetworkManager");
			if (type2 != null)
			{
				foreach (object item in FindGameNetworkManagers(type2))
				{
					if (ConfigureDedicatedGameManager(GetMemberValue(item, "gameManager")))
					{
						num++;
					}
				}
			}
			Array array = FindLoadedUnityObjects(type);
			if (array != null)
			{
				foreach (object item2 in array)
				{
					if (ConfigureDedicatedGameManager(item2))
					{
						num++;
					}
				}
			}
			if (ConfigureDedicatedGameManager(type.GetProperty("Instance", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)?.GetValue(null) ?? type.GetField("Instance", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)?.GetValue(null)))
			{
				num++;
			}
			if (num > 0 && !_dedicatedGameManagerConfigured)
			{
				_dedicatedGameManagerConfigured = true;
				SetBootstrapRepairStatus($"Extended dedicated matchmaking wait windows to {120f:0}s on {num} GameManager instance(s).", logRepeated: true);
			}
		}

		private static bool ConfigureDedicatedGameManager(object? gameManager)
		{
			if (gameManager == null)
			{
				return false;
			}
			return (byte)(0u | (RaiseFloatMember(gameManager, "matchWaitForStartMaxTimeMatchmaking", 120f) ? 1u : 0u) | (RaiseFloatMember(gameManager, "matchLateJoinTimeMatchmaking", 120f) ? 1u : 0u)) != 0;
		}

		private static bool RaiseFloatMember(object instance, string name, float minimumValue)
		{
			if (GetMemberValue(instance, name) is float num && num >= minimumValue)
			{
				return false;
			}
			return SetMemberValue(instance, name, minimumValue);
		}

		private bool IsMirrorServerActive(object gameNetworkManager)
		{
			try
			{
				object obj = InvokeInstance(gameNetworkManager, "IsActive");
				bool flag = default(bool);
				int num;
				if (obj is bool)
				{
					flag = (bool)obj;
					num = 1;
				}
				else
				{
					num = 0;
				}
				if (((uint)num & (flag ? 1u : 0u)) != 0)
				{
					return true;
				}
				Type type = FindType("Il2CppMirror.NetworkServer") ?? FindType("Il2CppMirror.NetworkServer") ?? FindType("Mirror.NetworkServer");
				if (type != null)
				{
					PropertyInfo property = type.GetProperty("active", BindingFlags.Static | BindingFlags.Public);
					if (property != null)
					{
						object value = property.GetValue(null);
						bool flag2 = default(bool);
						int num2;
						if (value is bool)
						{
							flag2 = (bool)value;
							num2 = 1;
						}
						else
						{
							num2 = 0;
						}
						if (((uint)num2 & (flag2 ? 1u : 0u)) != 0)
						{
							return true;
						}
					}
				}
				return false;
			}
			catch
			{
				return false;
			}
		}

		private bool IsServerMatchMapReady(object gameNetworkManager)
		{
			object memberValue = GetMemberValue(gameNetworkManager, "gameManager");
			if (memberValue == null)
			{
				return false;
			}
			object obj = GetMemberValue(memberValue, "currentGameMode") ?? GetMemberValue(memberValue, "battleRoyale") ?? GetMemberValue(memberValue, "ffa");
			if (obj == null)
			{
				return false;
			}
			object memberValue2 = GetMemberValue(obj, "currentEnvManager");
			object memberValue3 = GetMemberValue(obj, "spawnPoints");
			object memberValue4 = GetMemberValue(obj, "isLoading");
			bool flag = default(bool);
			int num;
			if (memberValue4 is bool)
			{
				flag = (bool)memberValue4;
				num = 1;
			}
			else
			{
				num = 0;
			}
			if (((uint)num & (flag ? 1u : 0u)) != 0)
			{
				return false;
			}
			if (memberValue2 == null || memberValue3 == null)
			{
				return false;
			}
			if (memberValue3 is ICollection { Count: 0 })
			{
				return false;
			}
			return true;
		}

		private void PatchLoadedGameModeLevelNames()
		{
			Type type = FindType("BAPBAP.Game.GameMode");
			if (type == null)
			{
				return;
			}
			int num = 0;
			Type type2 = FindType("Il2CppBAPBAP.Network.GameNetworkManager") ?? FindType("Il2CppBAPBAP.Network.GameNetworkManager") ?? FindType("BAPBAP.Network.GameNetworkManager");
			if (type2 != null)
			{
				foreach (object item in FindGameNetworkManagers(type2))
				{
					num += PatchGameModesFromGameManager(GetMemberValue(item, "gameManager"));
				}
			}
			Type type3 = FindType("BAPBAP.Game.GameManager");
			if (type3 != null)
			{
				Array array = FindLoadedUnityObjects(type3);
				if (array != null)
				{
					foreach (object item2 in array)
					{
						num += PatchGameModesFromGameManager(item2);
					}
				}
				object gameManager = type3.GetProperty("Instance", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)?.GetValue(null) ?? type3.GetField("Instance", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)?.GetValue(null);
				num += PatchGameModesFromGameManager(gameManager);
			}
			Array array2 = FindLoadedUnityObjects(type);
			if (array2 != null)
			{
				foreach (object item3 in array2)
				{
					num += PatchGameModeObject(item3);
				}
			}
			if (num > 0 && !_gameModeLevelNamesPatched)
			{
				_gameModeLevelNamesPatched = true;
				SetBootstrapRepairStatus($"Patched {num} GameMode levelNames array(s) for custom matches.", logRepeated: true);
			}
		}

		private int PatchGameModesFromGameManager(object? gameManager)
		{
			if (gameManager == null)
			{
				return 0;
			}
			return 0 + PatchGameModeObject(GetMemberValue(gameManager, "currentGameMode")) + PatchGameModeObject(GetMemberValue(gameManager, "battleRoyale")) + PatchGameModeObject(GetMemberValue(gameManager, "ffa"));
		}

		private int PatchGameModeObject(object? gameMode)
		{
			if (gameMode == null)
			{
				return 0;
			}
			try
			{
				Type type = gameMode.GetType().GetProperty("levelNames", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)?.PropertyType;
				if (type == null)
				{
					return 0;
				}
				object obj = Activator.CreateInstance(type, new object[1] { KnownLevelNames });
				return (obj != null && SetMemberValue(gameMode, "levelNames", obj)) ? 1 : 0;
			}
			catch (Exception ex)
			{
				SetBootstrapRepairStatus("GameMode levelNames patch failed: " + ex.GetBaseException().Message, logRepeated: false);
				return 0;
			}
		}

		private static bool HasUsableStringArray(object? value)
		{
			if (value == null)
			{
				return false;
			}
			if (!(value.GetType().GetProperty("Length", BindingFlags.Instance | BindingFlags.Public)?.GetValue(value) is int num) || num <= 1)
			{
				return false;
			}
			PropertyInfo property = value.GetType().GetProperty("Item", BindingFlags.Instance | BindingFlags.Public);
			if (property == null)
			{
				return false;
			}
			for (int i = 0; i < Math.Min(num, 4); i++)
			{
				if (!string.IsNullOrWhiteSpace(property.GetValue(value, new object[1] { i }) as string))
				{
					return true;
				}
			}
			return false;
		}

		private static object? CreateIl2CppPayload(Type payloadType, string json)
		{
			using JsonDocument jsonDocument = JsonDocument.Parse(json);
			return CreateIl2CppObject(payloadType, jsonDocument.RootElement);
		}

		private static object? CreateIl2CppObject(Type objectType, JsonElement element)
		{
			if (element.ValueKind != JsonValueKind.Object)
			{
				return null;
			}
			object obj = Activator.CreateInstance(objectType);
			if (obj == null)
			{
				return null;
			}
			foreach (JsonProperty item in element.EnumerateObject())
			{
				SetJsonMemberValue(obj, objectType, item.Name, item.Value);
			}
			return obj;
		}

		private static void SetJsonMemberValue(object instance, Type objectType, string name, JsonElement value)
		{
			PropertyInfo property = objectType.GetProperty(name, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if ((object)property != null && property.GetIndexParameters().Length == 0 && property.CanWrite)
			{
				object value2 = ConvertJsonValue(value, property.PropertyType);
				property.SetValue(instance, value2);
				return;
			}
			FieldInfo field = objectType.GetField(name, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (field != null)
			{
				object value3 = ConvertJsonValue(value, field.FieldType);
				field.SetValue(instance, value3);
			}
		}

		private static object? ConvertJsonValue(JsonElement value, Type targetType)
		{
			if (value.ValueKind == JsonValueKind.Null)
			{
				return null;
			}
			if (targetType == typeof(string))
			{
				return value.GetString() ?? "";
			}
			if (targetType == typeof(int))
			{
				return (value.ValueKind == JsonValueKind.Number) ? value.GetInt32() : 0;
			}
			if (targetType == typeof(float))
			{
				return (value.ValueKind == JsonValueKind.Number) ? value.GetSingle() : 0f;
			}
			if (targetType == typeof(double))
			{
				return (value.ValueKind == JsonValueKind.Number) ? value.GetDouble() : 0.0;
			}
			bool result = default(bool);
			if (targetType == typeof(bool))
			{
				return value.ValueKind == JsonValueKind.True || (value.ValueKind == JsonValueKind.String && bool.TryParse(value.GetString(), out result) && result);
			}
			if (IsIl2CppStructArray(targetType) && targetType.GenericTypeArguments[0] == typeof(int))
			{
				int[] array = ((value.ValueKind == JsonValueKind.Array) ? (from item in value.EnumerateArray()
					select (item.ValueKind == JsonValueKind.Number) ? item.GetInt32() : 0).ToArray() : Array.Empty<int>());
				return Activator.CreateInstance(targetType, array);
			}
			if (IsIl2CppList(targetType))
			{
				object obj = Activator.CreateInstance(targetType);
				if (obj == null)
				{
					return null;
				}
				MethodInfo method = targetType.GetMethod("Add", BindingFlags.Instance | BindingFlags.Public);
				Type targetType2 = targetType.GenericTypeArguments[0];
				if (method != null && value.ValueKind == JsonValueKind.Array)
				{
					foreach (JsonElement item in value.EnumerateArray())
					{
						object obj2 = ConvertJsonValue(item, targetType2);
						method.Invoke(obj, new object[1] { obj2 });
					}
				}
				return obj;
			}
			if (value.ValueKind == JsonValueKind.Object)
			{
				return CreateIl2CppObject(targetType, value);
			}
			return null;
		}

		private static bool IsIl2CppStructArray(Type type)
		{
			if (type.IsGenericType)
			{
				return string.Equals(type.GetGenericTypeDefinition().FullName, "Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppStructArray`1", StringComparison.Ordinal);
			}
			return false;
		}

		private static bool IsIl2CppList(Type type)
		{
			if (type.IsGenericType)
			{
				return string.Equals(type.GetGenericTypeDefinition().FullName, "Il2CppSystem.Collections.Generic.List`1", StringComparison.Ordinal);
			}
			return false;
		}

		private void TryRepairDedicatedWebServer(int httpPort)
		{
			if (IsTcpPortOpen("127.0.0.1", httpPort, 50))
			{
				_bootstrapRepairComplete = true;
				SetBootstrapRepairStatus("Game bootstrap HTTP listener is active.", logRepeated: false);
				return;
			}
			Type type = FindType("BAPBAP.Game.GameManager");
			Type type2 = FindType("BAPBAP.Network.WebServer");
			if (type == null || type2 == null)
			{
				SetBootstrapRepairStatus($"Waiting for game bootstrap types. GameManager={type != null} WebServer={type2 != null}", logRepeated: false);
				return;
			}
			Array array = FindLoadedUnityObjects(type);
			if (array == null || array.Length == 0)
			{
				SetBootstrapRepairStatus("Waiting for GameManager instance before starting bootstrap WebServer.", logRepeated: false);
				return;
			}
			foreach (object item in array)
			{
				try
				{
					object obj = GetMemberValue(item, "webServer");
					if (obj == null || !type2.IsInstanceOfType(obj))
					{
						obj = FindOrCreateWebServer(item, type2);
						if (obj != null)
						{
							SetMemberValue(item, "webServer", obj);
						}
					}
					if (obj == null)
					{
						SetBootstrapRepairStatus("GameManager exists but no WebServer component could be attached.", logRepeated: false);
						continue;
					}
					PatchWebServerRuntime(obj);
					InvokeInstance(obj, "PreAwake", httpPort);
					PatchWebServerRuntime(obj);
					InvokeInstance(obj, "StartWebserver", item);
					PatchWebServerRuntime(obj);
					if (!IsTcpPortOpen("127.0.0.1", httpPort, 100))
					{
						InvokeInstance(obj, "StartHttpListener");
					}
					if (IsTcpPortOpen("127.0.0.1", httpPort, 250))
					{
						_bootstrapRepairComplete = true;
						SetBootstrapRepairStatus($"Started game bootstrap WebServer on 127.0.0.1:{httpPort}.", logRepeated: true);
						break;
					}
					object memberValue = GetMemberValue(obj, "_listenPort");
					object memberValue2 = GetMemberValue(obj, "_listener");
					SetBootstrapRepairStatus($"Called WebServer bootstrap repair but port is still closed. listenPort={memberValue ?? "null"} listener={memberValue2 != null}", logRepeated: false);
				}
				catch (Exception ex)
				{
					SetBootstrapRepairStatus("Dedicated WebServer repair failed: " + ex.GetBaseException().Message, logRepeated: false);
				}
			}
		}

		private object? FindOrCreateWebServer(object gameManager, Type webServerType)
		{
			Array array = FindLoadedUnityObjects(webServerType);
			if (array != null)
			{
				foreach (object item in array)
				{
					if (item != null && webServerType.IsInstanceOfType(item))
					{
						return item;
					}
				}
			}
			object memberValue = GetMemberValue(gameManager, "gameObject");
			return memberValue?.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public).FirstOrDefault(delegate(MethodInfo method)
			{
				if (method.Name != "AddComponent")
				{
					return false;
				}
				ParameterInfo[] parameters = method.GetParameters();
				return parameters.Length == 1 && parameters[0].ParameterType == typeof(Type);
			})?.Invoke(memberValue, new object[1] { webServerType });
		}

		private void SetBootstrapRepairStatus(string status, bool logRepeated)
		{
			_statusText = status;
			if (logRepeated || !string.Equals(_lastBootstrapRepairStatus, status, StringComparison.Ordinal))
			{
				_lastBootstrapRepairStatus = status;
				((MelonBase)this).LoggerInstance.Msg(status);
			}
		}

		private static bool IsTcpPortOpen(string host, int port, int timeoutMs)
		{
			try
			{
				using TcpClient tcpClient = new TcpClient();
				IAsyncResult asyncResult = tcpClient.BeginConnect(host, port, null, null);
				if (!asyncResult.AsyncWaitHandle.WaitOne(timeoutMs))
				{
					return false;
				}
				tcpClient.EndConnect(asyncResult);
				return tcpClient.Connected;
			}
			catch
			{
				return false;
			}
		}

		private static object? GetMemberValue(object instance, string name)
		{
			Type type = instance.GetType();
			PropertyInfo property = type.GetProperty(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if ((object)property != null && property.GetIndexParameters().Length == 0 && property.CanRead)
			{
				return property.GetValue(instance);
			}
			return type.GetField(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)?.GetValue(instance);
		}

		private static object? GetMemberValue(Type type, string name)
		{
			PropertyInfo property = type.GetProperty(name, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			if ((object)property != null && property.GetIndexParameters().Length == 0 && property.CanRead)
			{
				return property.GetValue(null);
			}
			return type.GetField(name, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)?.GetValue(null);
		}

		private static bool SetMemberValue(object instance, string name, object? value)
		{
			Type type = instance.GetType();
			PropertyInfo property = type.GetProperty(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if ((object)property != null && property.GetIndexParameters().Length == 0 && property.CanWrite)
			{
				property.SetValue(instance, value);
				return true;
			}
			FieldInfo field = type.GetField(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (field == null)
			{
				return false;
			}
			field.SetValue(instance, value);
			return true;
		}

		private static object? InvokeInstance(object instance, string methodName, params object?[] args)
		{
			return instance.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).FirstOrDefault((MethodInfo candidate) => !(candidate.Name != methodName) && candidate.GetParameters().Length == args.Length)?.Invoke(instance, args);
		}

		private bool PatchHarmonyPostfix(MethodBase original, MethodInfo postfix)
		{
			object harmonyInstanceReflective = GetHarmonyInstanceReflective();
			if (harmonyInstanceReflective == null)
			{
				return false;
			}
			Type type = FindType("HarmonyLib.HarmonyMethod") ?? harmonyInstanceReflective.GetType().Assembly.GetType("HarmonyLib.HarmonyMethod");
			if (type == null)
			{
				return false;
			}
			object obj = Activator.CreateInstance(type, postfix);
			if (obj == null)
			{
				return false;
			}
			MethodInfo methodInfo = (from method in harmonyInstanceReflective.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public)
				where method.Name == "Patch"
				select method).FirstOrDefault(delegate(MethodInfo method)
			{
				ParameterInfo[] parameters2 = method.GetParameters();
				return parameters2.Length >= 3 && typeof(MethodBase).IsAssignableFrom(parameters2[0].ParameterType) && parameters2.Any((ParameterInfo parameter) => parameter.Name == "postfix");
			});
			if (methodInfo == null)
			{
				return false;
			}
			ParameterInfo[] parameters = methodInfo.GetParameters();
			object[] array = new object[parameters.Length];
			array[0] = original;
			for (int num = 1; num < parameters.Length; num++)
			{
				if (parameters[num].Name == "postfix")
				{
					array[num] = obj;
				}
			}
			methodInfo.Invoke(harmonyInstanceReflective, array);
			return true;
		}

		private bool PatchHarmonyPrefix(MethodBase original, MethodInfo prefix)
		{
			object harmonyInstanceReflective = GetHarmonyInstanceReflective();
			if (harmonyInstanceReflective == null)
			{
				return false;
			}
			Type type = FindType("HarmonyLib.HarmonyMethod") ?? harmonyInstanceReflective.GetType().Assembly.GetType("HarmonyLib.HarmonyMethod");
			if (type == null)
			{
				return false;
			}
			object obj = Activator.CreateInstance(type, prefix);
			if (obj == null)
			{
				return false;
			}
			MethodInfo methodInfo = (from method in harmonyInstanceReflective.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public)
				where method.Name == "Patch"
				select method).FirstOrDefault(delegate(MethodInfo method)
			{
				ParameterInfo[] parameters2 = method.GetParameters();
				return parameters2.Length >= 2 && typeof(MethodBase).IsAssignableFrom(parameters2[0].ParameterType) && parameters2.Any((ParameterInfo parameter) => parameter.Name == "prefix");
			});
			if (methodInfo == null)
			{
				return false;
			}
			ParameterInfo[] parameters = methodInfo.GetParameters();
			object[] array = new object[parameters.Length];
			array[0] = original;
			for (int num = 1; num < parameters.Length; num++)
			{
				if (parameters[num].Name == "prefix")
				{
					array[num] = obj;
				}
			}
			methodInfo.Invoke(harmonyInstanceReflective, array);
			return true;
		}

		private bool PatchHarmonyFinalizer(MethodBase original, MethodInfo finalizer)
		{
			object harmonyInstanceReflective = GetHarmonyInstanceReflective();
			if (harmonyInstanceReflective == null)
			{
				return false;
			}
			Type type = FindType("HarmonyLib.HarmonyMethod") ?? harmonyInstanceReflective.GetType().Assembly.GetType("HarmonyLib.HarmonyMethod");
			if (type == null)
			{
				return false;
			}
			object obj = Activator.CreateInstance(type, finalizer);
			if (obj == null)
			{
				return false;
			}
			MethodInfo methodInfo = (from method in harmonyInstanceReflective.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public)
				where method.Name == "Patch"
				select method).FirstOrDefault(delegate(MethodInfo method)
			{
				ParameterInfo[] parameters2 = method.GetParameters();
				return parameters2.Length >= 2 && typeof(MethodBase).IsAssignableFrom(parameters2[0].ParameterType) && parameters2.Any((ParameterInfo parameter) => parameter.Name == "finalizer");
			});
			if (methodInfo == null)
			{
				return false;
			}
			ParameterInfo[] parameters = methodInfo.GetParameters();
			object[] array = new object[parameters.Length];
			array[0] = original;
			for (int num = 1; num < parameters.Length; num++)
			{
				if (parameters[num].Name == "finalizer")
				{
					array[num] = obj;
				}
			}
			methodInfo.Invoke(harmonyInstanceReflective, array);
			return true;
		}

		private object? GetHarmonyInstanceReflective()
		{
			try
			{
				return typeof(MelonBase).GetProperty("HarmonyInstance", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)?.GetValue(this);
			}
			catch
			{
				return null;
			}
		}

		private static void NetworkConfigClientPostfix(object __result)
		{
			s_active?.PatchClientConfig(__result);
		}

		private static void NetworkConfigServerPostfix(object __result)
		{
			PatchServerConfig(__result);
		}

		private static void GameModeLevelNamesPrefix(object __instance)
		{
			s_active?.PatchGameModeObject(__instance);
		}

		private static void AddPlayerMatchmakingPrefix(object? __instance, object? conn, object? player, object? mpd, object? teammatePlayerIds)
		{
			CustomServerMod customServerMod = s_active;
			if (customServerMod == null)
			{
				return;
			}
			try
			{
				((MelonBase)customServerMod).LoggerInstance.Msg("AddPlayerMatchmaking preflight: " + $"connNull={conn == null} " + $"playerNull={player == null} " + "mpd=" + DescribeMatchmakingPlayer(mpd) + " teammates=" + GetCountOrNull(teammatePlayerIds) + " gm=" + DescribeGameManager(__instance));
			}
			catch (Exception ex)
			{
				((MelonBase)customServerMod).LoggerInstance.Warning("AddPlayerMatchmaking preflight logging failed: " + ex.GetBaseException().Message);
			}
		}

		private static void LoginControllerAutoGuestPostfix(object __instance)
		{
			CustomServerMod customServerMod = s_active;
			if (customServerMod != null && __instance != null)
			{
				customServerMod._pendingAutoGuestLogins.Enqueue(new AutoGuestLoginRequest(__instance, "LoginController"));
			}
		}

		private static bool CharacterSelectPrefix(object __instance)
		{
			if (__instance == null)
			{
				return false;
			}
			try
			{
				string text = __instance.GetType().FullName ?? __instance.GetType().Name;
				if (text.Contains("UILobbyCharacterSelectPage"))
				{
					if (GetMemberValue(__instance, "_charListingEntries") == null)
					{
						CustomServerMod? customServerMod = s_active;
						if (customServerMod != null)
						{
							((MelonBase)customServerMod).LoggerInstance.Warning("CharacterSelectPrefix: UILobbyCharacterSelectPage method " + __instance.GetType().Name + " skipped because _charListingEntries is null.");
						}
						return false;
					}
				}
				else if (text.Contains("UILobbyPlayTabPage"))
				{
					Type type = FindType("BAPBAP.UI.UILobbyCharacterSelectPage");
					if (type != null)
					{
						Array array = FindLoadedUnityObjects(type);
						if (array == null || array.Length <= 0)
						{
							CustomServerMod? customServerMod2 = s_active;
							if (customServerMod2 != null)
							{
								((MelonBase)customServerMod2).LoggerInstance.Warning("CharacterSelectPrefix: UILobbyPlayTabPage method skipped because no UILobbyCharacterSelectPage instance exists yet.");
							}
							return false;
						}
						object value = array.GetValue(0);
						if (value != null && GetMemberValue(value, "_charListingEntries") == null)
						{
							CustomServerMod? customServerMod3 = s_active;
							if (customServerMod3 != null)
							{
								((MelonBase)customServerMod3).LoggerInstance.Warning("CharacterSelectPrefix: UILobbyPlayTabPage method skipped because UILobbyCharacterSelectPage._charListingEntries is null.");
							}
							return false;
						}
					}
				}
			}
			catch (Exception value2)
			{
				CustomServerMod? customServerMod4 = s_active;
				if (customServerMod4 != null)
				{
					((MelonBase)customServerMod4).LoggerInstance.Error($"Error in CharacterSelectPrefix: {value2}");
				}
			}
			return true;
		}

		private static bool MatchCharacterSelectPrefix(object __instance)
		{
			if (__instance == null)
			{
				return false;
			}
			try
			{
				string[] array = new string[5] { "_charSelectButtons", "_actions", "_data", "_lobbyDataModel", "_matchStartPanel" };
				foreach (string text in array)
				{
					if (GetMemberValue(__instance, text) == null)
					{
						CustomServerMod? customServerMod = s_active;
						if (customServerMod != null)
						{
							((MelonBase)customServerMod).LoggerInstance.Warning($"MatchCharacterSelectPrefix: skipped method on {__instance.GetType().Name} because {text} is null.");
						}
						return false;
					}
				}
			}
			catch (Exception value)
			{
				CustomServerMod? customServerMod2 = s_active;
				if (customServerMod2 != null)
				{
					((MelonBase)customServerMod2).LoggerInstance.Error($"Error in MatchCharacterSelectPrefix: {value}");
				}
			}
			return true;
		}

		private static bool PlayPlayerCharChangeAnimPrefix()
		{
			CustomServerMod? customServerMod = s_active;
			if (customServerMod != null)
			{
				((MelonBase)customServerMod).LoggerInstance.Msg("Skipped UILobbyMatchCharacterSelectPage.PlayPlayerCharChangeAnim on custom server.");
			}
			return false;
		}

		private static bool UnconditionalSkipPrefix(MethodBase __originalMethod)
		{
			if (__originalMethod != null)
			{
				CustomServerMod? customServerMod = s_active;
				if (customServerMod != null)
				{
					((MelonBase)customServerMod).LoggerInstance.Msg($"Unconditionally skipped {__originalMethod.DeclaringType?.Name}.{__originalMethod.Name} on custom server.");
				}
			}
			return false;
		}

		private static bool CharacterIsUnlockedPrefix(ref bool __result)
		{
			__result = true;
			return false;
		}

		private static bool GetCharacterListingIndexFromCharIdPrefix(object __instance, int charId, ref int __result)
		{
			if (__instance == null)
			{
				__result = -1;
				return false;
			}
			try
			{
				if (GetMemberValue(__instance, "_charListingEntries") == null)
				{
					CustomServerMod? customServerMod = s_active;
					if (customServerMod != null)
					{
						((MelonBase)customServerMod).LoggerInstance.Warning("GetCharacterListingIndexFromCharIdPrefix: _charListingEntries is null. Returning -1.");
					}
					__result = -1;
					return false;
				}
			}
			catch (Exception value)
			{
				CustomServerMod? customServerMod2 = s_active;
				if (customServerMod2 != null)
				{
					((MelonBase)customServerMod2).LoggerInstance.Error($"Error in GetCharacterListingIndexFromCharIdPrefix: {value}");
				}
				__result = -1;
				return false;
			}
			return true;
		}

		private static Exception? CustomServerNullRefFinalizer(Exception? __exception)
		{
			if (__exception == null)
			{
				return null;
			}
			if (LooksLikeNullReference(__exception))
			{
				CustomServerMod? customServerMod = s_active;
				if (customServerMod != null)
				{
					((MelonBase)customServerMod).LoggerInstance.Warning("Suppressed custom-server lobby UI NullReferenceException: " + __exception.GetType().FullName);
				}
				return null;
			}
			return __exception;
		}

		private static Exception? PlayTabPageNullRefFinalizer(Exception? __exception)
		{
			if (__exception != null && LooksLikeNullReference(__exception))
			{
				return null;
			}
			return __exception;
		}

		private static bool LooksLikeNullReference(Exception exception)
		{
			for (Exception ex = exception; ex != null; ex = ex.InnerException)
			{
				string text = ex.GetType().FullName ?? ex.GetType().Name;
				string text2 = ex.Message ?? "";
				string text3 = ex.StackTrace ?? "";
				if (ex is NullReferenceException || text.Contains("NullReferenceException", StringComparison.OrdinalIgnoreCase) || text2.Contains("NullReferenceException", StringComparison.OrdinalIgnoreCase) || text3.Contains("NullReferenceException", StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}
			return false;
		}

		private static void LoginControllerHandleLoadResponsePostfix(object __instance, object response)
		{
			CustomServerMod customServerMod = s_active;
			if (customServerMod == null || __instance == null || response == null)
			{
				return;
			}
			customServerMod._lastLoginController = __instance;
			customServerMod._lastLoadResponse = response;
			((MelonBase)customServerMod).LoggerInstance.Msg("Custom-server load response handled by LoginController.");
			try
			{
				int[] array = ExtractAvailableCharacters(response);
				if (array.Length == 0)
				{
					array = Enumerable.Range(0, 15).ToArray();
				}
				customServerMod.PopulateAllUICharactersConfigurations(array);
			}
			catch (Exception ex)
			{
				((MelonBase)customServerMod).LoggerInstance.Warning("Failed to populate UICharactersConfiguration: " + ex.GetBaseException().Message);
			}
			customServerMod.SchedulePostLoginUiFallback("LoginController.HandleLoadResponse", 5f);
			customServerMod.ScheduleSceneReloadIfEmpty();
		}

		private static int[] ExtractAvailableCharacters(object response)
		{
			try
			{
				FieldInfo field = response.GetType().GetField("availableCharacters", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				if (field == null)
				{
					return Array.Empty<int>();
				}
				object value = field.GetValue(response);
				if (value == null)
				{
					return Array.Empty<int>();
				}
				if (value is int[] result)
				{
					return result;
				}
				List<int> list = new List<int>();
				if (value is IEnumerable enumerable)
				{
					foreach (object item2 in enumerable)
					{
						int result2;
						if (item2 is int item)
						{
							list.Add(item);
						}
						else if (item2 != null && int.TryParse(item2.ToString(), out result2))
						{
							list.Add(result2);
						}
					}
					return list.ToArray();
				}
				return Array.Empty<int>();
			}
			catch
			{
				return Array.Empty<int>();
			}
		}

		private void PopulateAllUICharactersConfigurations(int[] charIds)
		{
			Type type = FindType("BAPBAP.UI.UICharactersConfiguration");
			if (type == null)
			{
				((MelonBase)this).LoggerInstance.Msg("PopulateAllUICharactersConfigurations: type not found yet");
				return;
			}
			Array array = FindLoadedUnityObjects(type);
			if (array == null || array.Length == 0)
			{
				((MelonBase)this).LoggerInstance.Msg("PopulateAllUICharactersConfigurations: no instances found yet");
				return;
			}
			FieldInfo field = type.GetField("_lobbyAvailableCharacterIds", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (field == null)
			{
				((MelonBase)this).LoggerInstance.Msg("PopulateAllUICharactersConfigurations: field not found");
				return;
			}
			Type fieldType = field.FieldType;
			int num = 0;
			foreach (object item in array)
			{
				if (item == null)
				{
					continue;
				}
				try
				{
					object obj = null;
					if (fieldType == typeof(int[]) || fieldType.IsAssignableFrom(typeof(int[])))
					{
						obj = charIds;
					}
					else
					{
						ConstructorInfo constructor = fieldType.GetConstructor(new Type[1] { typeof(int[]) });
						if (constructor != null)
						{
							obj = constructor.Invoke(new object[1] { charIds });
						}
						else
						{
							ConstructorInfo constructor2 = fieldType.GetConstructor(new Type[1] { typeof(long) });
							if (constructor2 != null)
							{
								object obj2 = constructor2.Invoke(new object[1] { (long)charIds.Length });
								PropertyInfo property = fieldType.GetProperty("Item");
								if (property != null)
								{
									for (int i = 0; i < charIds.Length; i++)
									{
										property.SetValue(obj2, charIds[i], new object[1] { (long)i });
									}
									obj = obj2;
								}
							}
						}
					}
					if (obj != null)
					{
						field.SetValue(item, obj);
						num++;
					}
					else
					{
						((MelonBase)this).LoggerInstance.Msg("PopulateAllUICharactersConfigurations: could not construct value of " + fieldType.FullName);
					}
				}
				catch (Exception ex)
				{
					((MelonBase)this).LoggerInstance.Msg("PopulateAllUICharactersConfigurations item err: " + ex.GetBaseException().Message);
				}
			}
			((MelonBase)this).LoggerInstance.Msg($"PopulateAllUICharactersConfigurations: populated _lobbyAvailableCharacterIds=[{string.Join(",", charIds)}] on {num}/{array.Length} instances. fieldType={fieldType.FullName}");
		}

		private static bool AnalyticsManagerSetupAnalyticsPrefix(string accountId, bool isGuest, int totalGames)
		{
			CustomServerMod? customServerMod = s_active;
			if (customServerMod != null)
			{
				((MelonBase)customServerMod).LoggerInstance.Msg("Suppressed Unity Analytics setup for custom-server session.");
			}
			return false;
		}

		private static void UnityWebRequestSetRequestHeaderPrefix(ref string name, ref string value)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				name = "X-BAP-Custom-Secret";
				if (string.IsNullOrWhiteSpace(value))
				{
					value = "local-custom-server";
				}
				CustomServerMod? customServerMod = s_active;
				if (customServerMod != null)
				{
					((MelonBase)customServerMod).LoggerInstance.Msg("Repaired empty UnityWebRequest header name for custom-server callback.");
				}
			}
		}

		private static void UnityWebRequestSendWebRequestPrefix(object __instance)
		{
			s_active?.LogUnityWebRequest(__instance);
			s_active?.LogCustomServerRequest(__instance);
			s_active?.ApplyCustomServerIdentityHeaders(__instance);
			s_active?.RewriteUnityWebRequestCallbackUrl(__instance);
		}

		private void LogUnityWebRequest(object request)
		{
			if (_unityWebRequestLogCount < 80 && GetMemberValue(request, "url") is string text && Uri.TryCreate(text, UriKind.Absolute, out Uri result) && (!(result.Scheme != Uri.UriSchemeHttp) || !(result.Scheme != Uri.UriSchemeHttps)))
			{
				_unityWebRequestLogCount++;
				string value = SanitizeUrlForLog(text);
				((MelonBase)this).LoggerInstance.Msg($"UnityWebRequest #{_unityWebRequestLogCount}: {value}");
			}
		}

		private static string SanitizeUrlForLog(string url)
		{
			if (string.IsNullOrEmpty(url))
			{
				return "(empty)";
			}
			try
			{
				Uri uri = new Uri(url, UriKind.RelativeOrAbsolute);
				if (uri.IsAbsoluteUri)
				{
					string value = ((uri.Host == "127.0.0.1" || uri.Host == "localhost" || uri.Host.StartsWith("192.168.") || uri.Host.StartsWith("10.")) ? "local" : "remote");
					return $"[{value}]{uri.AbsolutePath}{uri.Query}";
				}
				return url;
			}
			catch
			{
				return "(invalid url)";
			}
		}

		private void LogCustomServerRequest(object request)
		{
			if (_customServerRequestLogCount < 24 && ShouldAttachCustomServerHeaders(request) && GetMemberValue(request, "url") is string text)
			{
				_customServerRequestLogCount++;
				((MelonBase)this).LoggerInstance.Msg($"Custom server HTTP request #{_customServerRequestLogCount}: {SanitizeUrlForLog(text)}");
				if (text.Contains("/api/lobby/socket", StringComparison.OrdinalIgnoreCase) || text.Contains("/lobby/socket", StringComparison.OrdinalIgnoreCase))
				{
					SchedulePostLoginUiFallback("lobby socket discovery");
				}
			}
		}

		private void ApplyCustomServerIdentityHeaders(object request)
		{
			string text = _accountIdEntry?.Value?.Trim() ?? "";
			if (string.IsNullOrWhiteSpace(text) || !ShouldAttachCustomServerHeaders(request))
			{
				return;
			}
			MethodInfo methodInfo = request.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).FirstOrDefault(delegate(MethodInfo method)
			{
				if (method.Name != "SetRequestHeader")
				{
					return false;
				}
				ParameterInfo[] parameters = method.GetParameters();
				return parameters.Length == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(string);
			});
			if (methodInfo == null)
			{
				return;
			}
			try
			{
				methodInfo.Invoke(request, new object[2] { "X-BAP-AccountId", text });
				string text2 = _usernameEntry?.Value?.Trim() ?? "";
				if (!string.IsNullOrWhiteSpace(text2))
				{
					methodInfo.Invoke(request, new object[2] { "X-BAP-Username", text2 });
				}
				methodInfo.Invoke(request, new object[2]
				{
					"X-BAP-Discriminator",
					GetDiscriminatorForHeaders().ToString()
				});
			}
			catch (Exception ex)
			{
				((MelonBase)this).LoggerInstance.Warning("Could not attach custom server identity headers: " + ex.GetBaseException().Message);
			}
		}

		private bool ShouldAttachCustomServerHeaders(object request)
		{
			if (!(GetMemberValue(request, "url") is string uriString) || !Uri.TryCreate(uriString, UriKind.Absolute, out Uri result))
			{
				return false;
			}
			if (IsLoopbackHost(result.Host) && (result.Port == 5055 || result.Port == 5055 || result.Port == _serverPortEntry.Value || result.Port == _localPortEntry.Value))
			{
				return true;
			}
			if (!Uri.TryCreate(string.IsNullOrWhiteSpace(_lastAppliedApiHost) ? GetConfiguredApiHost() : _lastAppliedApiHost, UriKind.Absolute, out Uri result2))
			{
				return false;
			}
			int num = ((!result2.IsDefaultPort) ? result2.Port : (result2.Scheme.Equals("https", StringComparison.OrdinalIgnoreCase) ? 443 : 80));
			int num2 = ((!result.IsDefaultPort) ? result.Port : (result.Scheme.Equals("https", StringComparison.OrdinalIgnoreCase) ? 443 : 80));
			if (string.Equals(result.Host, result2.Host, StringComparison.OrdinalIgnoreCase))
			{
				return num == num2;
			}
			return false;
		}

		private void RewriteUnityWebRequestCallbackUrl(object request)
		{
			if (GetMemberValue(request, "url") is string text && Uri.TryCreate(text, UriKind.Absolute, out Uri result) && IsLoopbackHost(result.Host) && (result.Port == 5055 || result.Port == 5055) && result.AbsolutePath.StartsWith("/api/internal", StringComparison.OrdinalIgnoreCase))
			{
				if (string.IsNullOrWhiteSpace(_lastAppliedApiHost))
				{
					_lastAppliedApiHost = GetConfiguredApiHost();
				}
				string text2 = _lastAppliedApiHost.TrimEnd('/') + result.PathAndQuery;
				if (!string.Equals(text, text2, StringComparison.OrdinalIgnoreCase) && SetMemberValue(request, "url", text2) && !_unityWebRequestCallbackUrlPatchLogged)
				{
					_unityWebRequestCallbackUrlPatchLogged = true;
					((MelonBase)this).LoggerInstance.Msg("Rewrote UnityWebRequest callback URL.");
				}
			}
		}

		private static string DescribeMatchmakingPlayer(object? mpd)
		{
			if (mpd == null)
			{
				return "null";
			}
			return $"auth={GetMemberValue(mpd, "gameAuthId") ?? "null"} playerId={GetMemberValue(mpd, "playerId") ?? "null"} teamId={GetMemberValue(mpd, "teamId") ?? "null"} charId={GetMemberValue(mpd, "charId") ?? "null"}";
		}

		private static string DescribeLoadResponse(object? response)
		{
			if (response == null)
			{
				return "null";
			}
			return $"accountId={GetMemberValue(response, "accountId") ?? GetMemberValue(response, "AccountId") ?? "null"} username={GetMemberValue(response, "username") ?? GetMemberValue(response, "Username") ?? "null"} isGuest={GetMemberValue(response, "isGuest") ?? GetMemberValue(response, "IsGuest") ?? "null"} isCompleted={GetMemberValue(response, "isCompleted") ?? GetMemberValue(response, "IsCompleted") ?? "null"} blocked={GetMemberValue(response, "blocked") ?? GetMemberValue(response, "Blocked") ?? "null"}";
		}

		private static string DescribeGameManager(object? gameManager)
		{
			if (gameManager == null)
			{
				return "null";
			}
			return $"playersByPlayerId={GetCountOrNull(GetMemberValue(gameManager, "playersByPlayerId"))} connIdToPlayerId={GetCountOrNull(GetMemberValue(gameManager, "connIdToPlayerId"))} preMatchManager={GetMemberValue(gameManager, "preMatchManager") != null} currentGameMode={GetMemberValue(gameManager, "currentGameMode") != null} qmd={GetMemberValue(gameManager, "qmd") != null} mgd={GetMemberValue(gameManager, "mgd") != null}";
		}

		private static string GetCountOrNull(object? value)
		{
			if (value == null)
			{
				return "null";
			}
			return value.GetType().GetProperty("Count", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)?.GetValue(value)?.ToString() ?? "unknown";
		}

		private void PatchLoadedNetworkConfigs()
		{
			if (string.IsNullOrWhiteSpace(_lastAppliedApiHost))
			{
				_lastAppliedApiHost = GetConfiguredApiHost();
			}
			Type type = FindType("BAPBAP.Network.NetworkConfig");
			if (type == null)
			{
				return;
			}
			try
			{
				Array array = FindLoadedUnityObjects(type);
				if (array == null)
				{
					return;
				}
				foreach (object item in array)
				{
					PatchNetworkConfig(item, type);
				}
			}
			catch (Exception ex)
			{
				((MelonBase)this).LoggerInstance.Warning("Failed to patch loaded NetworkConfig assets: " + ex.Message);
			}
		}

		private void PatchLoadedWebServers()
		{
			Type type = FindType("BAPBAP.Network.WebServer");
			if (type == null)
			{
				return;
			}
			try
			{
				Array array = FindLoadedUnityObjects(type);
				if (array == null)
				{
					return;
				}
				foreach (object item in array)
				{
					PatchWebServerRuntime(item);
				}
			}
			catch (Exception ex)
			{
				((MelonBase)this).LoggerInstance.Warning("Failed to patch loaded WebServer secrets: " + ex.GetBaseException().Message);
			}
		}

		private void PatchWebServerRuntime(object webServer)
		{
			if (string.IsNullOrWhiteSpace(_lastAppliedApiHost))
			{
				_lastAppliedApiHost = GetConfiguredApiHost();
			}
			PatchWebServerSecrets(webServer);
			string text = _lastAppliedApiHost.TrimEnd('/');
			string text2 = text + "/api/internal";
			string value = text + "/api/matchmaking";
			bool flag = SetStringMemberIfDifferent(webServer, "_internalApiEndpoint", text2);
			if ((SetStringMemberIfDifferent(webServer, "_matchmakingEndpoint", value) || flag) && !_webServerEndpointPatchLogged)
			{
				_webServerEndpointPatchLogged = true;
				((MelonBase)this).LoggerInstance.Msg("Patched WebServer callback endpoints to " + text2 + ".");
			}
		}

		private static void PatchWebServerSecrets(object webServer)
		{
			if (!(GetMemberValue(webServer, "_secretHeader") is string value) || string.IsNullOrWhiteSpace(value))
			{
				SetMemberValue(webServer, "_secretHeader", "X-BAP-Custom-Secret");
			}
			if (!(GetMemberValue(webServer, "_secret") is string value2) || string.IsNullOrWhiteSpace(value2))
			{
				SetMemberValue(webServer, "_secret", "local-custom-server");
			}
		}

		private static bool SetStringMemberIfDifferent(object instance, string name, string value)
		{
			if (GetMemberValue(instance, name) is string a && string.Equals(a, value, StringComparison.Ordinal))
			{
				return false;
			}
			return SetMemberValue(instance, name, value);
		}

		private static Array? FindLoadedUnityObjects(Type objectType)
		{
			Array array = TryInvokeUnityObjectFinder(typeof(Object), "FindObjectsOfType", objectType, includeInactive: true);
			if (array != null)
			{
				return array;
			}
			array = TryInvokeUnityObjectFinder(typeof(Object), "FindObjectsOfType", objectType, includeInactive: false);
			if (array != null)
			{
				return array;
			}
			return typeof(Resources).GetMethods(BindingFlags.Static | BindingFlags.Public).FirstOrDefault(delegate(MethodInfo candidate)
			{
				if (candidate.Name != "FindObjectsOfTypeAll")
				{
					return false;
				}
				ParameterInfo[] parameters = candidate.GetParameters();
				return parameters.Length == 1 && parameters[0].ParameterType == typeof(Type);
			})?.Invoke(null, new object[1] { objectType }) as Array;
		}

		private static Array? TryInvokeUnityObjectFinder(Type ownerType, string methodName, Type objectType, bool includeInactive)
		{
			try
			{
				MethodInfo methodInfo = ownerType.GetMethods(BindingFlags.Static | BindingFlags.Public).FirstOrDefault(delegate(MethodInfo candidate)
				{
					if (candidate.Name != methodName)
					{
						return false;
					}
					ParameterInfo[] parameters2 = candidate.GetParameters();
					return parameters2.Length switch
					{
						1 => parameters2[0].ParameterType == typeof(Type) && !includeInactive, 
						2 => parameters2[0].ParameterType == typeof(Type) && parameters2[1].ParameterType == typeof(bool), 
						_ => false, 
					};
				});
				if (methodInfo == null)
				{
					return null;
				}
				object[] parameters = ((methodInfo.GetParameters().Length != 1) ? new object[2] { objectType, includeInactive } : new object[1] { objectType });
				return methodInfo.Invoke(null, parameters) as Array;
			}
			catch
			{
				return null;
			}
		}

		private void PatchNetworkConfig(object config, Type networkConfigType)
		{
			object obj = networkConfigType.GetField("_client", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)?.GetValue(config);
			if (obj != null)
			{
				PatchClientConfig(obj);
			}
			if (networkConfigType.GetField("_clientList", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)?.GetValue(config) is Array array)
			{
				foreach (object item in array)
				{
					if (item != null)
					{
						PatchClientConfig(item);
					}
				}
			}
			object obj2 = networkConfigType.GetField("_server", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)?.GetValue(config);
			if (obj2 != null)
			{
				PatchServerConfig(obj2);
			}
			if (!(networkConfigType.GetField("_serverList", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)?.GetValue(config) is Array array2))
			{
				return;
			}
			foreach (object item2 in array2)
			{
				if (item2 != null)
				{
					PatchServerConfig(item2);
				}
			}
		}

		private void PatchClientConfig(object clientConfig)
		{
			if (clientConfig == null)
			{
				return;
			}
			try
			{
				Type type = clientConfig.GetType();
				FieldInfo? field = type.GetField("ApiHost", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				string text = field?.GetValue(clientConfig) as string;
				field?.SetValue(clientConfig, _lastAppliedApiHost);
				type.GetField("CookieDomain", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)?.SetValue(clientConfig, GetCookieDomain(_lastAppliedApiHost));
				FieldInfo field2 = type.GetField("CookieSessionKey", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				if (field2 != null && string.IsNullOrWhiteSpace(field2.GetValue(clientConfig) as string))
				{
					field2.SetValue(clientConfig, "sid");
				}
				if (!string.Equals(text, _lastAppliedApiHost, StringComparison.Ordinal) && !string.IsNullOrWhiteSpace(text))
				{
					((MelonBase)this).LoggerInstance.Msg($"Patched NetworkConfig.ClientConfig ApiHost: '{text}' -> '{_lastAppliedApiHost}'");
				}
			}
			catch (Exception ex)
			{
				((MelonBase)this).LoggerInstance.Warning("Failed to patch client config: " + ex.Message);
			}
		}

		private static void PatchServerConfig(object serverConfig)
		{
			if (serverConfig == null)
			{
				return;
			}
			try
			{
				Type type = serverConfig.GetType();
				FieldInfo field = type.GetField("HeaderSecretKey", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				if (field != null && string.IsNullOrWhiteSpace(field.GetValue(serverConfig) as string))
				{
					field.SetValue(serverConfig, "X-BAP-Custom-Secret");
				}
				FieldInfo field2 = type.GetField("HeaderSecret", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				if (field2 != null && string.IsNullOrWhiteSpace(field2.GetValue(serverConfig) as string))
				{
					field2.SetValue(serverConfig, "local-custom-server");
				}
				CustomServerMod customServerMod = s_active;
				if (customServerMod == null || !customServerMod._dedicatedProcess)
				{
					return;
				}
				int? num = customServerMod._dedicatedTcpPort ?? customServerMod._dedicatedWsPort;
				if (num.HasValue && num.Value > 0)
				{
					FieldInfo field3 = type.GetField("ListenPort", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					if (field3 != null)
					{
						Type fieldType = field3.FieldType;
						object value = field3.GetValue(serverConfig);
						if ((value is int num2) ? (num2 == 0) : ((value is ushort num3) ? (num3 == 0) : ((value is short num4) ? (num4 == 0) : ((value is uint num5) ? (num5 == 0) : (value is long num6 && num6 == 0)))))
						{
							object value2 = num.Value;
							if (fieldType == typeof(ushort))
							{
								value2 = (ushort)num.Value;
							}
							else if (fieldType == typeof(short))
							{
								value2 = (short)num.Value;
							}
							else if (fieldType == typeof(uint))
							{
								value2 = (uint)num.Value;
							}
							else if (fieldType == typeof(long))
							{
								value2 = (long)num.Value;
							}
							field3.SetValue(serverConfig, value2);
							((MelonBase)customServerMod).LoggerInstance.Msg($"[ServerConfig] Patched ListenPort 0 -> {num.Value}");
						}
					}
				}
				FieldInfo field4 = type.GetField("MatchmakingHost", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				if (field4 != null && string.IsNullOrWhiteSpace(field4.GetValue(serverConfig) as string))
				{
					field4.SetValue(serverConfig, "127.0.0.1");
					((MelonBase)customServerMod).LoggerInstance.Msg("[ServerConfig] Patched MatchmakingHost '' -> '127.0.0.1'");
				}
			}
			catch
			{
			}
		}

		private static string GetCookieDomain(string apiHost)
		{
			if (Uri.TryCreate(apiHost, UriKind.Absolute, out Uri result))
			{
				return result.Host;
			}
			return "127.0.0.1";
		}

		private static Type? FindType(string fullName)
		{
			string[] array = new string[3]
			{
				fullName,
				fullName.StartsWith("Il2Cpp", StringComparison.Ordinal) ? fullName : ("Il2Cpp" + fullName),
				fullName.StartsWith("Il2Cpp.", StringComparison.Ordinal) ? fullName : ("Il2Cpp." + fullName)
			};
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			foreach (Assembly assembly in assemblies)
			{
				try
				{
					string[] array2 = array;
					foreach (string name in array2)
					{
						Type type = assembly.GetType(name, throwOnError: false);
						if (type != null)
						{
							return type;
						}
					}
				}
				catch
				{
				}
			}
			return null;
		}
	}
	internal sealed class LocalReverseProxy : IDisposable
	{
		private static readonly HashSet<string> HopByHopHeaders = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "Connection", "Keep-Alive", "Proxy-Authenticate", "Proxy-Authorization", "TE", "Trailer", "Transfer-Encoding", "Upgrade", "Host", "Content-Length" };

		private readonly int _listenPort;

		private readonly Uri _upstreamBaseUri;

		private readonly Func<(string AccountId, string Username, string Discriminator)> _identityProvider;

		private readonly Action<string> _log;

		private readonly Action<string> _warn;

		private readonly Action<string> _error;

		private readonly HttpListener _listener = new HttpListener();

		private readonly HttpClient _httpClient;

		private readonly CancellationTokenSource _shutdown = new CancellationTokenSource();

		private Task? _acceptLoop;

		public LocalReverseProxy(int listenPort, Uri upstreamBaseUri, Func<(string AccountId, string Username, string Discriminator)> identityProvider, Action<string> log, Action<string> warn, Action<string> error)
		{
			_listenPort = listenPort;
			_upstreamBaseUri = upstreamBaseUri;
			_identityProvider = identityProvider;
			_log = log;
			_warn = warn;
			_error = error;
			_httpClient = new HttpClient(new SocketsHttpHandler
			{
				AllowAutoRedirect = false,
				UseCookies = false
			});
		}

		public void Start()
		{
			_listener.Prefixes.Add($"http://127.0.0.1:{_listenPort}/");
			_listener.Start();
			_acceptLoop = Task.Run((Func<Task?>)AcceptLoopAsync);
			_log($"Local proxy ready (port {_listenPort})");
		}

		public void Dispose()
		{
			_shutdown.Cancel();
			try
			{
				_listener.Close();
			}
			catch
			{
			}
			_httpClient.Dispose();
			_shutdown.Dispose();
		}

		private async Task AcceptLoopAsync()
		{
			while (!_shutdown.IsCancellationRequested)
			{
				HttpListenerContext context;
				try
				{
					context = await _listener.GetContextAsync().ConfigureAwait(continueOnCapturedContext: false);
				}
				catch (ObjectDisposedException)
				{
					break;
				}
				catch (HttpListenerException)
				{
					break;
				}
				catch (InvalidOperationException)
				{
					break;
				}
				catch (Exception ex4)
				{
					_warn("Proxy accept failed: " + ex4.Message);
					continue;
				}
				Task.Run(() => HandleContextAsync(context), _shutdown.Token);
			}
		}

		private async Task HandleContextAsync(HttpListenerContext context)
		{
			_ = 1;
			try
			{
				if (context.Request.IsWebSocketRequest)
				{
					await ProxyWebSocketAsync(context).ConfigureAwait(continueOnCapturedContext: false);
				}
				else
				{
					await ProxyHttpAsync(context).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			catch (Exception ex)
			{
				_warn("Proxy request failed: " + ex.Message);
				TryWriteError(context.Response, 502, ex.Message);
			}
		}

		private async Task ProxyHttpAsync(HttpListenerContext context)
		{
			Uri requestUri = BuildUpstreamUri(context.Request.Url, websocket: false);
			using HttpRequestMessage upstreamRequest = new HttpRequestMessage(new HttpMethod(context.Request.HttpMethod), requestUri);
			CopyRequestHeaders(context.Request, upstreamRequest);
			ApplyIdentityHeaders(upstreamRequest);
			if (HasRequestBody(context.Request))
			{
				upstreamRequest.Content = new StreamContent(context.Request.InputStream);
				CopyContentHeaders(context.Request, upstreamRequest.Content.Headers);
			}
			using HttpResponseMessage upstreamResponse = await _httpClient.SendAsync(upstreamRequest, HttpCompletionOption.ResponseHeadersRead, _shutdown.Token).ConfigureAwait(continueOnCapturedContext: false);
			context.Response.StatusCode = (int)upstreamResponse.StatusCode;
			CopyResponseHeaders(upstreamResponse, context.Response);
			if (ShouldRewriteSocketDiscovery(context.Request.Url, upstreamResponse))
			{
				string s = RewriteSocketDiscovery(await upstreamResponse.Content.ReadAsStringAsync(_shutdown.Token).ConfigureAwait(continueOnCapturedContext: false));
				byte[] bytes = Encoding.UTF8.GetBytes(s);
				context.Response.ContentType = "application/json; charset=utf-8";
				context.Response.ContentLength64 = bytes.Length;
				await context.Response.OutputStream.WriteAsync(bytes, _shutdown.Token).ConfigureAwait(continueOnCapturedContext: false);
			}
			else
			{
				await using Stream stream = await upstreamResponse.Content.ReadAsStreamAsync(_shutdown.Token).ConfigureAwait(continueOnCapturedContext: false);
				await stream.CopyToAsync(context.Response.OutputStream, _shutdown.Token).ConfigureAwait(continueOnCapturedContext: false);
			}
			context.Response.OutputStream.Close();
		}

		private async Task ProxyWebSocketAsync(HttpListenerContext context)
		{
			Uri upstreamUri = BuildUpstreamUri(context.Request.Url, websocket: true);
			using WebSocket clientSocket = (await context.AcceptWebSocketAsync(null).ConfigureAwait(continueOnCapturedContext: false)).WebSocket;
			using ClientWebSocket upstreamSocket = new ClientWebSocket();
			string[] allKeys = context.Request.Headers.AllKeys;
			foreach (string text in allKeys)
			{
				if (!string.IsNullOrWhiteSpace(text) && !HopByHopHeaders.Contains(text) && !text.StartsWith("Sec-WebSocket", StringComparison.OrdinalIgnoreCase))
				{
					string text2 = context.Request.Headers[text];
					if (!string.IsNullOrWhiteSpace(text2))
					{
						TrySetWebSocketHeader(upstreamSocket, text, text2);
					}
				}
			}
			ApplyIdentityHeaders(upstreamSocket);
			await upstreamSocket.ConnectAsync(upstreamUri, _shutdown.Token).ConfigureAwait(continueOnCapturedContext: false);
			Task task = PumpWebSocketAsync(clientSocket, upstreamSocket, _shutdown.Token);
			Task task2 = PumpWebSocketAsync(upstreamSocket, clientSocket, _shutdown.Token);
			await Task.WhenAny(task, task2).ConfigureAwait(continueOnCapturedContext: false);
			await CloseSocketAsync(clientSocket).ConfigureAwait(continueOnCapturedContext: false);
			await CloseSocketAsync(upstreamSocket).ConfigureAwait(continueOnCapturedContext: false);
		}

		private Uri BuildUpstreamUri(Uri? requestUri, bool websocket)
		{
			string requestPath = requestUri?.AbsolutePath ?? "/";
			string path = CombinePath(_upstreamBaseUri.AbsolutePath.TrimEnd('/'), requestPath);
			return new UriBuilder(_upstreamBaseUri)
			{
				Scheme = ((!websocket) ? _upstreamBaseUri.Scheme : ((_upstreamBaseUri.Scheme == Uri.UriSchemeHttps) ? "wss" : "ws")),
				Path = path,
				Query = (requestUri?.Query.TrimStart('?') ?? "")
			}.Uri;
		}

		private static string CombinePath(string basePath, string requestPath)
		{
			if (string.IsNullOrWhiteSpace(basePath) || basePath == "/")
			{
				if (!string.IsNullOrWhiteSpace(requestPath))
				{
					return requestPath;
				}
				return "/";
			}
			if (string.IsNullOrWhiteSpace(requestPath) || requestPath == "/")
			{
				return basePath;
			}
			return basePath.TrimEnd('/') + "/" + requestPath.TrimStart('/');
		}

		private static bool HasRequestBody(HttpListenerRequest request)
		{
			if (!request.HasEntityBody && request.ContentLength64 <= 0)
			{
				return string.Equals(request.Headers["Transfer-Encoding"], "chunked", StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		private static void CopyRequestHeaders(HttpListenerRequest source, HttpRequestMessage target)
		{
			string[] allKeys = source.Headers.AllKeys;
			foreach (string text in allKeys)
			{
				if (!string.IsNullOrWhiteSpace(text) && !HopByHopHeaders.Contains(text))
				{
					string value = source.Headers[text];
					if (!string.IsNullOrWhiteSpace(value) && !target.Headers.TryAddWithoutValidation(text, value) && target.Content != null)
					{
						target.Content.Headers.TryAddWithoutValidation(text, value);
					}
				}
			}
		}

		private static void CopyContentHeaders(HttpListenerRequest source, HttpContentHeaders target)
		{
			string[] allKeys = source.Headers.AllKeys;
			foreach (string text in allKeys)
			{
				if (!string.IsNullOrWhiteSpace(text) && !HopByHopHeaders.Contains(text))
				{
					string value = source.Headers[text];
					if (!string.IsNullOrWhiteSpace(value))
					{
						target.TryAddWithoutValidation(text, value);
					}
				}
			}
		}

		private void ApplyIdentityHeaders(HttpRequestMessage request)
		{
			var (value, value2, value3) = _identityProvider();
			if (!string.IsNullOrWhiteSpace(value))
			{
				request.Headers.Remove("X-BAP-AccountId");
				request.Headers.Remove("X-BAP-UserId");
				request.Headers.Remove("X-BAP-Username");
				request.Headers.Remove("X-BAP-Discriminator");
				request.Headers.TryAddWithoutValidation("X-BAP-AccountId", value);
				request.Headers.TryAddWithoutValidation("X-BAP-UserId", value);
				if (!string.IsNullOrWhiteSpace(value2))
				{
					request.Headers.TryAddWithoutValidation("X-BAP-Username", value2);
				}
				if (!string.IsNullOrWhiteSpace(value3))
				{
					request.Headers.TryAddWithoutValidation("X-BAP-Discriminator", value3);
				}
			}
		}

		private void ApplyIdentityHeaders(ClientWebSocket socket)
		{
			var (text, text2, text3) = _identityProvider();
			if (!string.IsNullOrWhiteSpace(text))
			{
				TrySetWebSocketHeader(socket, "X-BAP-AccountId", text);
				TrySetWebSocketHeader(socket, "X-BAP-UserId", text);
				if (!string.IsNullOrWhiteSpace(text2))
				{
					TrySetWebSocketHeader(socket, "X-BAP-Username", text2);
				}
				if (!string.IsNullOrWhiteSpace(text3))
				{
					TrySetWebSocketHeader(socket, "X-BAP-Discriminator", text3);
				}
			}
		}

		private static void CopyResponseHeaders(HttpResponseMessage source, HttpListenerResponse target)
		{
			foreach (KeyValuePair<string, IEnumerable<string>> header in source.Headers)
			{
				TrySetResponseHeader(target, header.Key, header.Value);
			}
			foreach (KeyValuePair<string, IEnumerable<string>> header2 in source.Content.Headers)
			{
				TrySetResponseHeader(target, header2.Key, header2.Value);
			}
		}

		private static void TrySetResponseHeader(HttpListenerResponse target, string headerName, IEnumerable<string> values)
		{
			if (HopByHopHeaders.Contains(headerName))
			{
				return;
			}
			try
			{
				string value = string.Join(", ", values);
				if (!string.IsNullOrWhiteSpace(value))
				{
					target.Headers[headerName] = value;
				}
			}
			catch
			{
			}
		}

		private bool ShouldRewriteSocketDiscovery(Uri? requestUri, HttpResponseMessage response)
		{
			if (!(requestUri?.AbsolutePath ?? "").Contains("socket", StringComparison.OrdinalIgnoreCase))
			{
				return false;
			}
			string text = response.Content.Headers.ContentType?.MediaType;
			if (!string.IsNullOrWhiteSpace(text) && !text.Contains("json", StringComparison.OrdinalIgnoreCase))
			{
				return text.Contains("text", StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		private string RewriteSocketDiscovery(string body)
		{
			string text = $"ws://127.0.0.1:{_listenPort}/ws";
			try
			{
				if (JsonNode.Parse(body) is JsonObject jsonObject)
				{
					if (jsonObject.ContainsKey("socketUrl"))
					{
						jsonObject["socketUrl"] = text;
					}
					if (jsonObject.ContainsKey("socket_url"))
					{
						jsonObject["socket_url"] = text;
					}
					return jsonObject.ToJsonString(new JsonSerializerOptions
					{
						WriteIndented = false
					});
				}
			}
			catch (JsonException)
			{
			}
			return Regex.Replace(Regex.Replace(body, "\"socketUrl\"\\s*:\\s*\"[^\"]*\"", "\"socketUrl\":\"" + text + "\"", RegexOptions.CultureInvariant), "\"socket_url\"\\s*:\\s*\"[^\"]*\"", "\"socket_url\":\"" + text + "\"", RegexOptions.CultureInvariant);
		}

		private static void TrySetWebSocketHeader(ClientWebSocket socket, string headerName, string headerValue)
		{
			try
			{
				socket.Options.SetRequestHeader(headerName, headerValue);
			}
			catch
			{
			}
		}

		private static async Task PumpWebSocketAsync(WebSocket source, WebSocket destination, CancellationToken cancellationToken)
		{
			byte[] buffer = new byte[65536];
			while (!cancellationToken.IsCancellationRequested && source.State == WebSocketState.Open && destination.State == WebSocketState.Open)
			{
				WebSocketReceiveResult webSocketReceiveResult = await source.ReceiveAsync(buffer, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				if (webSocketReceiveResult.MessageType == WebSocketMessageType.Close)
				{
					break;
				}
				await destination.SendAsync(new ArraySegment<byte>(buffer, 0, webSocketReceiveResult.Count), webSocketReceiveResult.MessageType, webSocketReceiveResult.EndOfMessage, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
		}

		private static async Task CloseSocketAsync(WebSocket socket)
		{
			try
			{
				WebSocketState state = socket.State;
				if ((state == WebSocketState.Open || state == WebSocketState.CloseReceived) ? true : false)
				{
					await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "proxy closed", CancellationToken.None).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			catch
			{
			}
		}

		private static void TryWriteError(HttpListenerResponse response, int statusCode, string message)
		{
			try
			{
				response.StatusCode = statusCode;
				byte[] bytes = Encoding.UTF8.GetBytes(message);
				response.ContentType = "text/plain; charset=utf-8";
				response.ContentLength64 = bytes.Length;
				response.OutputStream.Write(bytes, 0, bytes.Length);
				response.OutputStream.Close();
			}
			catch
			{
			}
		}
	}
}
