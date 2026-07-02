using System.Reflection;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using MelonLoader;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Object = UnityEngine.Object;

[assembly: MelonInfo(typeof(BapCustomServerMelon.CustomServerMod), "BAP Custom Server", "1.0.5", "Sonic0810")]

namespace BapCustomServerMelon;

public sealed class CustomServerMod : MelonMod
{
    private const string IniFileName = "BapCustomServer.ini";
    private const string AppDataFolderName = "BAPBAPBATTLEROYALE";
    private const int DefaultServerPort = 5055;
    private const int DefaultLocalProxyPort = 5055;
    private const float PatchIntervalSeconds = 2.0f;
    private const float FastPatchIntervalSeconds = 0.05f;
    private const float FastPatchUntilTime = 180.0f;
    private const float BootstrapRepairIntervalSeconds = 1.0f;
    private const float AutoJoinIntervalSeconds = 1.0f;
    private const float DedicatedMatchWaitForPlayersSeconds = 120.0f;
    private const float DedicatedLateJoinSeconds = 120.0f;
    private const int DedicatedCharSelectMillis = 20000;
    private const int DedicatedSpawnSelectMillis = 10000;
    private const int DedicatedSpawnShowMillis = 3000;
    private const int KcpTransportTimeoutMillis = 60000;
    private const int VanillaCharacterCount = 15;
    private const int MedusaCharacterId = 15;
    private const string DefaultSecretHeaderName = "X-BAP-Custom-Secret";
    private const string DefaultSecretValue = "local-custom-server";
    private const string AccountHeaderName = "X-BAP-AccountId";
    private const string UsernameHeaderName = "X-BAP-Username";
    private const string DiscriminatorHeaderName = "X-BAP-Discriminator";
    private static readonly string[] KnownLevelNames =
    {
        "Map2_BazaarCity 3",
        "Map2_BazaarCity 3",
        "Map3_Lyceum",
        "Arena_Map2",
        "OpenBetaMap#J02_P_Boccato",
        "Map2_BazaarCity 3",
        "Map3_Lyceum",
        "Arena_Map2"
    };

    private static CustomServerMod? s_active;
    private static readonly ConcurrentDictionary<string, Type> s_typeCache = new();

    private MelonPreferences_Category _category = null!;
    private MelonPreferences_Entry<string> _hostEntry = null!;
    private MelonPreferences_Entry<int> _serverPortEntry = null!;
    private MelonPreferences_Entry<bool> _httpsEntry = null!;
    private MelonPreferences_Entry<bool> _localProxyEntry = null!;
    private MelonPreferences_Entry<int> _localPortEntry = null!;
    private MelonPreferences_Entry<bool> _statusChipEntry = null!;
    private MelonPreferences_Entry<bool> _moddingOverlayEntry = null!;
    private MelonPreferences_Entry<bool> _productionModeEntry = null!;
    private MelonPreferences_Entry<string> _moddingOverlayTitleEntry = null!;
    private MelonPreferences_Entry<bool> _allowDevPanelEntry = null!;
    private MelonPreferences_Entry<bool> _forceOnMatchStartedEnabled = null!;
    private MelonPreferences_Entry<bool> _netTuneEnabledEntry = null!;
    private MelonPreferences_Entry<string> _moddingOverlaySubtitleEntry = null!;
    private MelonPreferences_Entry<bool> _nativeUiEntry = null!;
    private MelonPreferences_Entry<string> _accountIdEntry = null!;
    private MelonPreferences_Entry<string> _usernameEntry = null!;
    private MelonPreferences_Entry<bool> _autoGuestLoginEntry = null!;

    private string _iniPath = "";
    private LocalReverseProxy? _proxy;
    private Rect _windowRect = new(24f, 24f, 430f, 330f);
    private Rect _setupWindowRect = new(0f, 0f, 500f, 270f);
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
    private int[] _lastAvailableCharacterIds = Array.Empty<int>();
    private float _nextServerPolicyFetchAt;
    private float _nextUiPatchStatsLogAt;
    private bool _unityWebRequestHeaderPatchInstalled;
    private bool _unityWebRequestCallbackUrlPatchLogged;
    private bool _unityWebRequestLoopbackUrlPatchLogged;
    private bool _httpClientHostPatchInstalled;
    private bool _httpClientHostPatchFailed;
    private bool _httpClientHostRewriteLogged;
    private bool _httpClientUriBuilderRewriteLogged;
    private bool _httpClientConfigurationRewriteLogged;
    private bool _controllerManagerNetworkPatchInstalled;
    private bool _controllerManagerNetworkPatchLogged;
    private bool _preAwakeManagerNetworkPatchInstalled;
    private bool _preAwakeManagerNetworkRuntimeLogged;
    private bool _lobbyNetworkClientPatchInstalled;
    private bool _lobbyNetworkClientPatchLogged;
    private bool _lobbyNetworkClientRuntimeLogged;
    private bool _webSocketClientSelectionPatchInstalled;
    private bool _characterSelectionTrackerInstalled;
    private bool _directModeCompatibilityProxyLogged;
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
    private float _nextLobbyQueueRecoveryAt;
    private float _lobbyQueueInQueueSince;
    private Task<bool>? _lobbyQueueIdleProbe;
    private int _lobbyQueueRecoveryLogCount;
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
    private int? _requestedCharacterId;
    private float? _autoEndAfterSeconds;
    private bool _dedicatedProcess;
    private bool _dedicatedNetworkStarted;
    private bool _uiNetworkStartAttempted;
    private bool _gameNetworkStartAttempted;
    private int _uiNetworkStartAttemptCount;
    private int _gameNetworkStartAttemptCount;
    private float _nextDedicatedNetworkStartRetryAt;
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
    private readonly ConcurrentQueue<BootstrapPayload> _pendingBootstrapPayloads = new();
    private readonly ConcurrentQueue<AutoGuestLoginRequest> _pendingAutoGuestLogins = new();
    private readonly List<BootstrapPayload> _retryBootstrapPayloads = new();
    private readonly HashSet<int> _autoGuestLoginControllers = new();
    private bool _autoGuestLoginControllerScanLogged;
    private bool _autoGuestLobbyScanLogged;
    private bool _splashGuestLoginInvoked;
    private bool _splashGuestLoginScanLogged;
    private float _splashGuestLoginInvokedAt;

    // --bapcustom-autoplay dev flag state
    private bool _autoplayEnabled;
    private bool _autoSelectAugmentsEnabled;
    private int _autoplayState; // 0=waiting-for-login, 1=joining-lobby, 2=set-ready, 3=in-match
    private float _autoplayNextActionAt;
    private bool _autoplayInMatch;
    private static int _lastKnownSelectedCharacterId = -1;
    private static int _characterSelectionTrackerLogCount;
    private static int _webSocketSelectionRewriteLogCount;
    private static bool _sendingSyntheticSwitchChar;

    private bool _postLoginUiFallbackApplied;
    private bool _postLoginUiFallbackLogged;
    private bool _postLoginUiDiagnosticsLogged;
    private float _postLoginUiFallbackAt;
    private int _postLoginUiFallbackAttempts;
    private float _nextForceDismissSplashAt;
    private bool _matchLoadingOverlayHiddenLogged;
    private int _lastMatchLoadingOverlayHiddenCount;
    private bool _sceneReloadScheduled;
    private float _sceneReloadAt;
    private object? _lastLoginController;
    private object? _lastLoadResponse;
    private TcpListener? _bootstrapListener;
    private CancellationTokenSource? _bootstrapListenerCts;
    private Task? _bootstrapListenerTask;
    private string _serverPortText = DefaultServerPort.ToString();
    private string _localPortText = DefaultLocalProxyPort.ToString();
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

    // uGUI modding overlay (Stage B - replaces IMGUI which never renders in IL2CPP)
    private GameObject? _uguiOverlayRoot;
    private object? _uguiOverlayTmpText; // TextMeshProUGUI instance (stored as object for reflection)
    private bool _uguiOverlayInstalled;
    private bool _uguiOverlayFailed;

    public override void OnEarlyInitializeMelon()
    {
        InitializeCore("early");
        // Critical: start an every-frame poll IMMEDIATELY so we install UI
        // prefixes and populate UICharactersConfiguration as soon as IL2CPP
        // exposes those types, before UIManager.Awake -> UILobby.Build runs.
        try { MelonLoader.MelonCoroutines.Start(EarlyLobbyUiPatchLoop()); }
        catch (Exception ex) { LoggerInstance.Warning($"Could not start EarlyLobbyUiPatchLoop: {ex.GetBaseException().Message}"); }
    }

    private System.Collections.IEnumerator EarlyLobbyUiPatchLoop()
    {
        int attempts = 0;
        // Run aggressively through the fragile startup window. Some IL2CPP UI
        // types become visible only shortly before MainScene UIManager.Awake.
        while (attempts < 3600 &&
               (!_charConfigPreloadDone || !_uiCharsConfigPatchInstalled || !_characterSelectPatchInstalled))
        {
            attempts++;
            try
            {
                TryInstallCharacterSelectNullRefPatch();
                // Experimental crash-fixes disabled - they destabilized the lobby:
                // TryInstallUICharactersConfigPatch();
                // TryFixCharactersConfigurationCrash();
            }
            catch { }
            yield return null;
        }
        LoggerInstance.Msg($"[EarlyLobbyUiPatchLoop] exited after {attempts} frames. preloadDone={_charConfigPreloadDone} uiPatch={_uiCharsConfigPatchInstalled} charPatch={_characterSelectPatchInstalled}");
    }

    public override void OnInitializeMelon()
    {
        InitializeCore("normal");
    }

    private void InitializeCore(string phase)
    {
        if (_initialized)
        {
            return;
        }

        _initialized = true;
        s_active = this;
        AppDomain.CurrentDomain.ProcessExit += OnProcessExit;

        _category = MelonPreferences.CreateCategory("BapCustomServer", "BAP Custom Server");
        _hostEntry = _category.CreateEntry("Host", "127.0.0.1", "Server Host");
        _serverPortEntry = _category.CreateEntry("ServerPort", DefaultServerPort, "Server Port");
        _httpsEntry = _category.CreateEntry("UseHttps", false, "Use HTTPS");
        _localProxyEntry = _category.CreateEntry("UseLocalProxy", true, "Use Local Proxy");
        _localPortEntry = _category.CreateEntry("LocalProxyPort", DefaultLocalProxyPort, "Local Proxy Port");
        _statusChipEntry = _category.CreateEntry("ShowStatusChip", false, "Show Status Chip");
        _moddingOverlayEntry = _category.CreateEntry("ShowModdingOverlay", false, "Show BAPBAP Modding overlay (bottom center)");
        _moddingOverlayTitleEntry = _category.CreateEntry("ModdingOverlayTitle", "BAPBAP Modding", "Modding Overlay Title");
        _productionModeEntry = _category.CreateEntry("ProductionMode", true, "Production mode: hide all mod overlays/labels (default ON)");
        _allowDevPanelEntry = _category.CreateEntry("AllowDevPanel", false, "Allow Dev/Debug Panel in match");
        _forceOnMatchStartedEnabled = _category.CreateEntry("ForceOnMatchStarted", false, "Force gameMode.OnMatchStarted/OnMatchBegin (default off; natural lifecycle now works)");
        _netTuneEnabledEntry = _category.CreateEntry("NetTuneEnabled", true, "Apply Mirror snapshotSettings + sendRate + KCP NoDelay tuning (default ON; set false to disable)");
        _moddingOverlaySubtitleEntry = _category.CreateEntry("ModdingOverlaySubtitle", "discord.gg/bapbapmods", "Modding Overlay Subtitle");
        _nativeUiEntry = _category.CreateEntry("UseNativeGameUi", true, "Use Native Game UI");
        _accountIdEntry = _category.CreateEntry("AccountId", "", "Custom Server Account ID");
        _usernameEntry = _category.CreateEntry("Username", "", "Custom Server Username");
        _autoGuestLoginEntry = _category.CreateEntry("AutoGuestLogin", true, "Automatically enter the custom-server lobby with a local guest identity");

        string[] commandLineArgs = Environment.GetCommandLineArgs();
        _iniPath = ResolveIniPath(commandLineArgs);
        LoadIniSettings();
        ApplyCommandLineOverrides(commandLineArgs);
        TryStartManagedBootstrapListenerEarly();
        UpdateIdentitySetupRequirement("startup configuration");
        CompletePendingIdentitySetupFromCommandLine();
        PrimeCustomServerLoginPrefs();
        _serverPortText = _serverPortEntry.Value.ToString();
        _localPortText = _localPortEntry.Value.ToString();

        TryInstallNetworkConfigPatches();
        TryInstallPreAwakeManagerNetworkPatch();
        TryInstallHttpClientHostPatch();
        TryInstallControllerManagerNetworkPatch();
        TryInstallLobbyNetworkClientPatches();
        TryInstallCharacterSelectionTrackerPatches();
        TryInstallWebSocketClientSelectionPatch();
        TryInstallLifecycleGuardPatches();
        TryInstallAnalyticsPatches();
        TryInstallCharacterSelectNullRefPatch();
        TryInstallLobbyControllerGuardPatches();
        TryInstallCharacterUnlockPatches();
        // The following 3 were experimental crash-fix attempts that destabilized the lobby. Disabled.
        // TryFixCharactersConfigurationCrash();
        // TryInstallUICharactersConfigPatch();
        TryFetchServerPolicy();
        ApplySettings(restartProxy: true, save: false);

        LoggerInstance.Msg(
            $"Initialized BAP Custom Server v1.0.5 during {phase} registration. " +
            $"dedicated={_dedicatedProcess} http={_dedicatedHttpPort?.ToString() ?? "n/a"} ws={_dedicatedWsPort?.ToString() ?? "n/a"} kcp={_dedicatedKcpPort?.ToString() ?? "n/a"} tcp={_dedicatedTcpPort?.ToString() ?? "n/a"}");
    }

    private void TryStartManagedBootstrapListenerEarly()
    {
        if (!_dedicatedProcess || _dedicatedHttpPort is not > 0)
        {
            return;
        }

        try
        {
            EnsureManagedBootstrapListener(_dedicatedHttpPort.Value);
        }
        catch (Exception ex)
        {
            LoggerInstance.Warning($"Early managed bootstrap listener start failed: {ex.GetBaseException().Message}");
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
        // Aggressively populate char config on every scene load to catch the lobby scene
        LoggerInstance.Msg($"[SceneLoaded] Scene '{sceneName}' (index {buildIndex}) loaded.");
        // TryFixCharactersConfigurationCrash(); // Disabled - destabilized lobby

        // Re-arm match-related state flags whenever we return to a lobby/menu scene so the
        // next match's bootstrap, game-mode rebind, crate/augment patches, and bootstrap
        // payload handling all run fresh instead of being skipped due to stale flags.
        if (sceneName != null && (sceneName.Contains("Main", StringComparison.OrdinalIgnoreCase) || sceneName.Contains("Lobby", StringComparison.OrdinalIgnoreCase) || sceneName.Contains("Menu", StringComparison.OrdinalIgnoreCase)))
        {
            LoggerInstance.Msg($"[StateReset] Resetting match flags on lobby/menu scene '{sceneName}'");
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
            _matchLoadingOverlayHiddenLogged = false;
            _lastMatchLoadingOverlayHiddenCount = 0;
            _nextLobbyQueueRecoveryAt = Time.realtimeSinceStartup + 2.0f;
            _lobbyQueueInQueueSince = 0f;
            _lobbyQueueIdleProbe = null;
        }
    }

    private void OnProcessExit(object? sender, EventArgs args)
    {
        StopManagedBootstrapListener();
        StopProxy();
    }

    public override void OnUpdate()
    {
        // DISABLED: every-frame TryFixCharactersConfigurationCrash. Reflection on a Unity ScriptableObject
        // every frame caused destabilization. Lobby was stable before this was added.
        // if (!_charConfigPreloadDone) { try { TryFixCharactersConfigurationCrash(); } catch { } }

        DrainBootstrapPayloads();
        DrainAutoGuestLoginRequests();

        // F7 panel disabled in production mode (regular users can't access mod settings via hotkey)
        if (_uiEnabled && Input.GetKeyDown(KeyCode.F7) && _productionModeEntry?.Value != true)
        {
            ToggleUiPanel();
        }

        CaptureIdentitySetupKeyboardInput();
        ProcessIdentitySetupProcessRelaunch();

        if (_uiEnabled && !_dedicatedProcess && !UnityEngine.Application.isBatchMode && (_nativeUiEntry?.Value == true || _identitySetupRequired))
        {
            EnsureNativeGameUi();
            if (_nativeUiRoot != null && Time.realtimeSinceStartup >= _nextNativeUiRefreshAt)
            {
                _nextNativeUiRefreshAt = Time.realtimeSinceStartup + 0.5f;
                RefreshNativeGameUi(syncInputs: false);
            }

            if (_nativeUiRoot != null && Input.GetMouseButtonDown(0))
            {
                HandleNativeUiPointer(Input.mousePosition);
            }
        }

        // Disabled experimental crash fix - destabilized lobby
        // if (!_charConfigPreloadDone) { TryFixCharactersConfigurationCrash(); }

        // Throttle expensive Unity FindObjectsOfType scans to once every 2 seconds.
        // Without this, the patches re-scan every frame at 60-200Hz, causing 80%+ CPU usage.
        bool runScans = false;
        if (Time.realtimeSinceStartup - _lastModScanTime >= 2f)
        {
            _lastModScanTime = Time.realtimeSinceStartup;
            runScans = true;
        }
        if (runScans)
        {
            if (!_currentGameModeRebound) { try { TryRebindCurrentGameModeToPopulatedInstance(); } catch { } }
            // DISABLED: shared spawn point references between GameModes caused worse stutter.
            // if (_currentGameModeRebound && !_spawnPointsCopied) { try { TryCopySpawnPointsToAllGameModes(); } catch { } }
            // DISABLED: disabling NetworkBehaviour .enabled may interfere with Mirror sync delta.
            // if (_currentGameModeRebound && !_duplicatesGameModesDestroyed) { try { TryDestroyDuplicateGameModes(); } catch { } }
            if (_currentGameModeRebound && !_onMatchStartedForced) { try { TryForceOnMatchStarted(); } catch { } }
            if (!_devPanelHidePatchInstalled) { try { TryInstallDevPanelHidePatch(); } catch { } }
            if (!_shopThrottleInstalled) { try { TryInstallShopThrottle(); } catch { } }
            if (!_lockerCrashGuardInstalled) { try { TryInstallLockerCrashGuard(); } catch { } }
            if (!_dedicatedProcess && !_kcpTimeoutGuardApplied) { try { TryApplyKcpTimeoutGuard(); } catch { } }
            if (!_networkTuningApplied) { try { TryApplyNetworkTuning(); } catch { } }
            if (!_networkTunerHarmonyInstalled) { try { TryInstallNetworkTunerHarmonyPatch(); } catch { } }
            if (!_interpDisablePatchInstalled) { try { TryDisableLocalPlayerInterp(); } catch { } }
            if (!_crateRespawnDisabled) { try { TryDisableCrateRespawn(); } catch { } }
            if (!_matchFoundDedupPatchInstalled) { try { TryInstallMatchFoundDedupPatch(); } catch { } }
            if (!_augmentTimerExtended) { try { TryExtendAugmentSelectTimer(); } catch { } }
            if (!_dedicatedProcess && _autoSelectAugmentsEnabled)
            {
                try { TryAutoSelectOpenAugment(); }
                catch (Exception ex)
                {
                    if (!_autoAugmentErrorLogged)
                    {
                        _autoAugmentErrorLogged = true;
                        LoggerInstance.Warning($"[AugmentFix] auto-select top-level failure: {ex.GetBaseException().Message}");
                    }
                }
            }
        }

        if (!_dedicatedProcess && Time.realtimeSinceStartup >= _nextLobbyQueueRecoveryAt)
        {
            _nextLobbyQueueRecoveryAt = Time.realtimeSinceStartup + 2.0f;
            try { TryRecoverStaleLobbyQueueUi(); } catch { }
        }

        if (Time.realtimeSinceStartup >= _nextPatchAt)
        {
            _nextPatchAt = Time.realtimeSinceStartup + (Time.realtimeSinceStartup < FastPatchUntilTime ? FastPatchIntervalSeconds : PatchIntervalSeconds);
            TryInstallNetworkConfigPatches();
            TryInstallPreAwakeManagerNetworkPatch();
            TryInstallHttpClientHostPatch();
            TryInstallControllerManagerNetworkPatch();
            TryInstallLobbyNetworkClientPatches();
            TryInstallCharacterSelectionTrackerPatches();
            TryInstallWebSocketClientSelectionPatch();
            TryInstallLifecycleGuardPatches();
            TryInstallGameModePatches();
            TryInstallJoinDiagnosticsPatches();
            TryInstallLoginControllerPatches();
            TryInstallAnalyticsPatches();
            TryInstallCharacterSelectNullRefPatch();
            TryInstallLobbyControllerGuardPatches();
            // TEMPORARILY DISABLED:
            TryInstallCharacterUnlockPatches();
            // TryFixCharactersConfigurationCrash(); // Disabled - destabilized lobby
        // TryInstallUICharactersConfigPatch(); // Disabled - DMD on IL2CPP ScriptableObject getter caused 0xC0000005
        TryFetchServerPolicy();
            TryInstallUnityWebRequestHeaderPatch();
            PatchLoadedNetworkConfigs();
            PatchLoadedLobbyNetworkClients();
            PatchLoadedWebServers();
            TryProtectLobbyUiFromDestruction();
            // TryInstallModdingOverlayUgui(); // Disabled - cosmetic add destabilized lobby
        }

        if (Time.realtimeSinceStartup >= _nextUiPatchStatsLogAt)
        {
            _nextUiPatchStatsLogAt = Time.realtimeSinceStartup + 15f;
            if (_uiCharsConfigPatchInstalled)
            {
                LoggerInstance.Msg($"UI patch stats: EnsureLobbyCharIdsPrefix called={_ensureLobbyCharIdsCallCount} filled={_ensureLobbyCharIdsFilledCount}");
            }
        }

        if (!_dedicatedProcess &&
            _autoGuestLoginEntry?.Value == true &&
            HasCompleteLocalIdentity() &&
            Time.realtimeSinceStartup >= _nextAutoGuestScanAt)
        {
            _nextAutoGuestScanAt = Time.realtimeSinceStartup + 1.5f;

            // Retry guest login if it was invoked but never progressed (no LoadResponse within 12s)
            if (_splashGuestLoginInvoked &&
                !_postLoginUiFallbackApplied &&
                _lastLoadResponse == null &&
                _splashGuestLoginInvokedAt > 0f &&
                Time.realtimeSinceStartup - _splashGuestLoginInvokedAt > 12f)
            {
                LoggerInstance.Msg("Resetting splash guest-login invoked flag for retry (no LoadResponse received within timeout).");
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

        if (!_dedicatedProcess &&
            _postLoginUiFallbackAt > 0f &&
            Time.realtimeSinceStartup >= _postLoginUiFallbackAt)
        {
            _postLoginUiFallbackAt = 0f;
            ApplyPostLoginUiFallback("scheduled post-login check");
        }

        if (!_dedicatedProcess && Time.realtimeSinceStartup >= _nextForceDismissSplashAt)
        {
            _nextForceDismissSplashAt = Time.realtimeSinceStartup + 1.0f;
            ForceDismissSplashUiInMatch();
        }

        if (_autoplayEnabled && !_dedicatedProcess)
        {
            RunAutoplayLogic();
        }

        if (!_autoJoinAttempted &&
            !string.IsNullOrWhiteSpace(_autoJoinGameAuthId) &&
            _autoJoinWsPort is > 0 &&
            _autoJoinKcpPort is > 0 &&
            _autoJoinTcpPort is > 0 &&
            Time.realtimeSinceStartup >= _nextAutoJoinAt)
        {
            _nextAutoJoinAt = Time.realtimeSinceStartup + AutoJoinIntervalSeconds;
            TryAutoJoinMatch(_autoJoinGameAuthId, _autoJoinHost, _autoJoinWsPort.Value, _autoJoinKcpPort.Value, _autoJoinTcpPort.Value);
        }

        if (_dedicatedProcess &&
            _dedicatedHttpPort is > 0 &&
            _dedicatedWsPort is > 0 &&
            _dedicatedKcpPort is > 0 &&
            _dedicatedTcpPort is > 0 &&
            Time.realtimeSinceStartup >= _nextBootstrapRepairAt)
        {
            _nextBootstrapRepairAt = Time.realtimeSinceStartup + BootstrapRepairIntervalSeconds;
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

            DrainBootstrapPayloads();
            TryAutoEndDedicatedMatch();
        }
    }

    public override void OnLateUpdate()
    {
        // Extra chance to populate char config before the async Build coroutine resumes
        if (!_charConfigPreloadDone)
        {
            TryFixCharactersConfigurationCrash();
        }
    }

    private static readonly Rect ModOkGuiRect = new(8f, 28f, 200f, 22f);

    public override void OnGUI()
    {
        // Dedicated game-server process: skip all GUI work entirely (no window, no input).
        if (_dedicatedProcess) return;

        // Production mode: hide ALL mod overlays - no MOD-OK label, no panels, no chips.
        // Identity setup window still shows when AccountId+Username are missing (mandatory).
        bool productionMode = _productionModeEntry?.Value == true;

        // Pure cosmetic top-left marker - hidden in production mode.
        if (!productionMode)
        {
            try { GUI.Label(ModOkGuiRect, "MOD-OK"); } catch { }
        }

        if (!_uiEnabled)
        {
            return;
        }

        // Production mode: skip all custom GUI panels - identity setup is the only exception
        if (productionMode && !_identitySetupRequired)
        {
            return;
        }

        try
        {
            // Always-on overlay (independent from setup window / native UI / status chip)
            if (_moddingOverlayEntry?.Value == true)
            {
                try { DrawModdingOverlay(); } catch { }
            }

            if (_identitySetupRequired)
            {
                if (_nativeUiRoot != null && !_nativeUiBuildFailed)
                {
                    return;
                }

                DrawIdentitySetupWindow();
                return;
            }

            if (_nativeUiEntry?.Value == true && !_nativeUiBuildFailed)
            {
                return;
            }

            DrawGuiSurfaces();
        }
        catch (MissingMethodException ex) when (ex.Message.Contains("WindowFunction", StringComparison.OrdinalIgnoreCase))
        {
            DisableGuiAfterFailure(ex);
        }
        catch (Exception ex)
        {
            DisableGuiAfterFailure(ex);
        }
    }

    private void DrawGuiSurfaces()
    {
        if (_statusChipEntry?.Value == true && !_showWindow)
        {
            DrawStatusChip();
        }

        if (!_showWindow)
        {
            return;
        }

        _windowRect = GUI.Window(
            7650505,
            _windowRect,
            DrawWindow,
            new GUIContent("BAP Custom Server"),
            GUI.skin.window);
    }

    private void DrawIdentitySetupWindow()
    {
        float width = Math.Min(500f, Math.Max(360f, Screen.width - 48f));
        float height = 270f;
        _setupWindowRect = new Rect(
            Math.Max(12f, (Screen.width - width) * 0.5f),
            Math.Max(12f, (Screen.height - height) * 0.5f),
            width,
            height);

        GUI.Box(new Rect(0f, 0f, Screen.width, Screen.height), "");
        _setupWindowRect = GUI.Window(
            7650506,
            _setupWindowRect,
            DrawIdentitySetupContents,
            new GUIContent("BAP Custom Server Setup"),
            GUI.skin.window);
    }

    private void DrawIdentitySetupContents(int windowId)
    {
        GUILayout.Space(8f);
        GUILayout.Label("Choose your player name for this custom server.");
        GUILayout.Label($"Server: {GetConfiguredApiHost()}");

        GUILayout.Space(12f);
        GUI.SetNextControlName("BapCustomSetupName");
        _setupUsernameText = LabeledTextField("Name", _setupUsernameText);

        GUILayout.Space(8f);
        GUILayout.Label("A local Account ID will be generated and saved to BapCustomServer.ini.");

        if (!string.IsNullOrWhiteSpace(_setupErrorText))
        {
            GUILayout.Space(4f);
            GUI.contentColor = new Color(1f, 0.58f, 0.42f, 1f);
            GUILayout.Label(_setupErrorText);
            GUI.contentColor = Color.white;
        }
        else
        {
            GUILayout.Space(4f);
            GUILayout.Label("Delete AccountId or Username from the ini to show this setup again.");
        }

        GUILayout.FlexibleSpace();
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Continue", GUILayout.Width(140f), GUILayout.Height(34f)) ||
            (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.Return))
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

        if (_uiFailureLogged)
        {
            return;
        }

        _uiFailureLogged = true;
        LoggerInstance.Warning($"Custom server IMGUI disabled after runtime UI failure: {ex.GetBaseException().Message}");
    }

    private void DrawWindow(int windowId)
    {
        GUILayout.Space(6f);

        GUILayout.Label("Server");
        _hostEntry.Value = LabeledTextField("IP / Host", _hostEntry.Value);
        _serverPortText = LabeledTextField("Port", _serverPortText);
        _accountIdEntry.Value = LabeledTextField("Account ID", _accountIdEntry.Value);
        _usernameEntry.Value = LabeledTextField("Username", _usernameEntry.Value);
        _httpsEntry.Value = GUILayout.Toggle(_httpsEntry.Value, "Use HTTPS");

        GUILayout.Space(8f);
        GUILayout.Label("Routing");
        _localProxyEntry.Value = GUILayout.Toggle(_localProxyEntry.Value, "Use in-game local proxy");
        _statusChipEntry.Value = GUILayout.Toggle(_statusChipEntry.Value, "Show lobby status chip");
        using (new DisabledScope(!_localProxyEntry.Value))
        {
            _localPortText = LabeledTextField("Local Port", _localPortText);
        }

        GUILayout.Space(8f);
        GUILayout.Label($"Game API: {GetConfiguredApiHost()}");
        GUILayout.Label($"Status: {_statusText}");

        GUILayout.Space(8f);
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Apply + Save", GUILayout.Height(28f)))
        {
            ApplySettings(restartProxy: true, save: true);
        }

        if (GUILayout.Button("Close", GUILayout.Height(28f)))
        {
            _showWindow = false;
        }

        GUILayout.EndHorizontal();

        GUI.DragWindow(new Rect(0f, 0f, 10000f, 24f));
    }

    private void DrawStatusChip()
    {
        const float width = 430f;
        const float height = 64f;
        float x = Math.Max(16f, Screen.width - width - 24f);
        Rect rect = new(x, 18f, width, height);

        GUI.Box(rect, "");
        GUILayout.BeginArea(new Rect(rect.x + 12f, rect.y + 8f, rect.width - 24f, rect.height - 16f));
        GUILayout.Label($"Custom Server: {GetConfiguredApiHost()}");
        GUILayout.Label($"{_statusText} | F7 settings");
        GUILayout.EndArea();
    }

    private void DrawModdingOverlay()
    {
        const float width = 360f;
        const float height = 50f;
        float x = (Screen.width - width) * 0.5f;
        float y = Screen.height - height - 16f;
        Rect rect = new(x, y, width, height);

        // Subtle dark backdrop using the default box style
        var prevColor = GUI.color;
        GUI.color = new Color(0f, 0f, 0f, 0.55f);
        GUI.Box(rect, "");
        GUI.color = prevColor;

        // Use the built-in skin label - no new GUIStyle (which is fragile in IL2CPP)
        GUILayout.BeginArea(new Rect(rect.x, rect.y + 4f, rect.width, rect.height - 8f));
        GUILayout.FlexibleSpace();
        string title = !string.IsNullOrEmpty(_serverModdingOverlayTitle) ? _serverModdingOverlayTitle : (_moddingOverlayTitleEntry?.Value ?? "BAPBAP Modding");
        string subtitle = !string.IsNullOrEmpty(_serverModdingOverlaySubtitle) ? _serverModdingOverlaySubtitle : (_moddingOverlaySubtitleEntry?.Value ?? "discord.gg/bapbapmods");
        GUILayout.Label(title);
        GUILayout.Label(subtitle);
        GUILayout.FlexibleSpace();
        GUILayout.EndArea();
    }

    private void TryInstallModdingOverlayUgui()
    {
        if (_uguiOverlayInstalled || _uguiOverlayFailed || _dedicatedProcess)
            return;
        if (_moddingOverlayEntry?.Value != true)
            return;

        try
        {
            // Avoid duplicates
            if (GameObject.Find("BapModdingOverlay") != null)
            {
                _uguiOverlayInstalled = true;
                LoggerInstance.Msg("uGUI overlay already exists (BapModdingOverlay found).");
                return;
            }

            // Create root Canvas GameObject
            var overlayGo = new GameObject("BapModdingOverlay");
            Object.DontDestroyOnLoad(overlayGo);

            // Add Canvas component
            var canvas = overlayGo.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.sortingOrder = 32767;

            // Add CanvasScaler
            var scaler = overlayGo.AddComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;

            // Add GraphicRaycaster (required for proper Canvas)
            overlayGo.AddComponent<GraphicRaycaster>();

            // Create text child
            var textGo = new GameObject("OverlayText");
            textGo.transform.SetParent(overlayGo.transform, false);

            // Try to add TextMeshProUGUI via reflection (BAPBAP uses TMP)
            Type? tmpType = FindType("TMPro.TextMeshProUGUI");
            if (tmpType == null)
                tmpType = FindType("TMPro.TextMeshProUGUI");

            object? tmpComponent = null;
            if (tmpType != null)
            {
                try
                {
                    // AddComponent via the generic-less overload: gameObject.AddComponent(Type)
                    MethodInfo? addComp = typeof(GameObject).GetMethod("AddComponent", new[] { typeof(Type) });
                    if (addComp != null)
                    {
                        tmpComponent = addComp.Invoke(textGo, new object[] { tmpType });
                    }
                }
                catch (Exception ex)
                {
                    LoggerInstance.Msg($"uGUI overlay: AddComponent(TextMeshProUGUI) failed: {ex.GetBaseException().Message}");
                }
            }

            if (tmpComponent != null)
            {
                // Set text properties via reflection
                try
                {
                    string overlayText = GetModdingOverlayText();
                    SetPropertyOrField(tmpComponent, "text", overlayText);
                    SetPropertyOrField(tmpComponent, "fontSize", 22f);
                    // alignment = Center (TextAlignmentOptions.Center = 514 in TMP)
                    try
                    {
                        var alignProp = tmpComponent.GetType().GetProperty("alignment");
                        if (alignProp != null)
                        {
                            // TextAlignmentOptions.Bottom = 1024, Center = 514, BottomCenter might not exist
                            // Use 514 for centered text
                            alignProp.SetValue(tmpComponent, Enum.ToObject(alignProp.PropertyType, 514));
                        }
                    }
                    catch { }

                    // Set color to white
                    try
                    {
                        var colorProp = tmpComponent.GetType().GetProperty("color");
                        if (colorProp != null)
                            colorProp.SetValue(tmpComponent, new Color(1f, 1f, 1f, 0.9f));
                    }
                    catch { }

                    // Enable rich text
                    try { SetPropertyOrField(tmpComponent, "richText", true); } catch { }
                }
                catch (Exception ex)
                {
                    LoggerInstance.Msg($"uGUI overlay: setting TMP properties failed: {ex.GetBaseException().Message}");
                }

                _uguiOverlayTmpText = tmpComponent;
            }
            else
            {
                // Fallback: use Unity UI Text
                try
                {
                    var uiText = textGo.AddComponent<Text>();
                    uiText.text = GetModdingOverlayTextPlain();
                    uiText.fontSize = 20;
                    uiText.alignment = TextAnchor.MiddleCenter;
                    uiText.color = new Color(1f, 1f, 1f, 0.9f);
                    uiText.horizontalOverflow = HorizontalWrapMode.Overflow;
                    uiText.verticalOverflow = VerticalWrapMode.Overflow;
                    // Try to assign a font
                    try
                    {
                        var builtinFont = Resources.GetBuiltinResource<Font>("Arial.ttf");
                        if (builtinFont != null) uiText.font = builtinFont;
                    }
                    catch { }
                    _uguiOverlayTmpText = uiText;
                }
                catch (Exception ex)
                {
                    LoggerInstance.Msg($"uGUI overlay: fallback UI.Text also failed: {ex.GetBaseException().Message}");
                }
            }

            // Configure RectTransform for bottom-center positioning
            var rt = textGo.GetComponent<RectTransform>();
            if (rt != null)
            {
                rt.anchorMin = new Vector2(0.5f, 0f);
                rt.anchorMax = new Vector2(0.5f, 0f);
                rt.pivot = new Vector2(0.5f, 0f);
                rt.anchoredPosition = new Vector2(0f, 32f);
                rt.sizeDelta = new Vector2(600f, 56f);
            }

            _uguiOverlayRoot = overlayGo;
            _uguiOverlayInstalled = true;
            LoggerInstance.Msg($"uGUI overlay created on Canvas BapModdingOverlay (sortingOrder=32767, TMP={(tmpComponent != null ? "yes" : "no/fallback-Text")})");
        }
        catch (Exception ex)
        {
            _uguiOverlayFailed = true;
            LoggerInstance.Msg($"uGUI overlay creation failed: {ex.GetBaseException().Message}");
        }
    }

    private string GetModdingOverlayText()
    {
        string title = !string.IsNullOrEmpty(_serverModdingOverlayTitle) ? _serverModdingOverlayTitle : (_moddingOverlayTitleEntry?.Value ?? "BAPBAP Modding");
        string subtitle = !string.IsNullOrEmpty(_serverModdingOverlaySubtitle) ? _serverModdingOverlaySubtitle : (_moddingOverlaySubtitleEntry?.Value ?? "discord.gg/bapbapmods");
        return $"{title}\n<size=70%>{subtitle}</size>";
    }

    private string GetModdingOverlayTextPlain()
    {
        string title = !string.IsNullOrEmpty(_serverModdingOverlayTitle) ? _serverModdingOverlayTitle : (_moddingOverlayTitleEntry?.Value ?? "BAPBAP Modding");
        string subtitle = !string.IsNullOrEmpty(_serverModdingOverlaySubtitle) ? _serverModdingOverlaySubtitle : (_moddingOverlaySubtitleEntry?.Value ?? "discord.gg/bapbapmods");
        return $"{title}\n{subtitle}";
    }

    private void UpdateUguiOverlayText()
    {
        if (_uguiOverlayTmpText == null) return;
        try
        {
            if (_uguiOverlayTmpText is Text uiText)
            {
                uiText.text = GetModdingOverlayTextPlain();
            }
            else
            {
                SetPropertyOrField(_uguiOverlayTmpText, "text", GetModdingOverlayText());
            }
        }
        catch { }
    }

    private static void SetPropertyOrField(object target, string name, object value)
    {
        var prop = target.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        if (prop != null && prop.CanWrite)
        {
            prop.SetValue(target, value);
            return;
        }
        var field = target.GetType().GetField(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        field?.SetValue(target, value);
    }

    private void ToggleUiPanel()
    {
        if (_nativeUiEntry?.Value == true && !_dedicatedProcess)
        {
            EnsureNativeGameUi();
            _nativeUiExpanded = !_nativeUiExpanded;
            RefreshNativeGameUi(syncInputs: true);
            return;
        }

        _showWindow = !_showWindow;
    }

    private void EnsureNativeGameUi()
    {
        if (_dedicatedProcess || UnityEngine.Application.isBatchMode)
        {
            // Client-only feature: skip native UI on dedicated/headless game server processes.
            return;
        }

        if (_nativeUiRoot != null || _nativeUiBuildFailed)
        {
            return;
        }

        try
        {
            BuildNativeGameUi();
            RefreshNativeGameUi(syncInputs: true);
            LoggerInstance.Msg("Created native Unity custom server panel.");
        }
        catch (Exception ex)
        {
            _nativeUiBuildFailed = true;
            LoggerInstance.Warning($"Native custom server UI could not be created; IMGUI fallback remains available: {ex.GetBaseException().Message}");
        }
    }

    private void BuildNativeGameUi()
    {
        EnsureEventSystem();

        _nativeUiRoot = new GameObject("BAP Custom Server UI");
        Transform? gameUiParent = TryFindGameUiParent();
        if (gameUiParent != null)
        {
            // Protect the game UI canvas and its root from being destroyed by the login flow
            GameObject rootCanvasGo = gameUiParent.root.gameObject;
            Object.DontDestroyOnLoad(rootCanvasGo);
            LoggerInstance.Msg($"Protected root canvas '{rootCanvasGo.name}' with DontDestroyOnLoad.");

            // Also protect all sibling root objects that look like managers
            try
            {
                Array? allGos = FindLoadedUnityObjects(typeof(GameObject));
                if (allGos != null)
                {
                    int protectedCount = 0;
                    foreach (GameObject root in allGos.Cast<GameObject>())
                    {
                        if (root == null || root.transform.parent != null) continue;
                        Object.DontDestroyOnLoad(root);
                        protectedCount++;
                    }
                    LoggerInstance.Msg($"Protected {protectedCount} root GameObjects with DontDestroyOnLoad.");
                }
            }
            catch (Exception ex)
            {
                LoggerInstance.Warning($"Could not protect scene roots: {ex.GetBaseException().Message}");
            }

            _nativeUiRoot.transform.SetParent(gameUiParent, worldPositionStays: false);
            RectTransform rootRect = _nativeUiRoot.AddComponent<RectTransform>();
            rootRect.anchorMin = Vector2.zero;
            rootRect.anchorMax = Vector2.one;
            rootRect.pivot = new Vector2(0.5f, 0.5f);
            rootRect.offsetMin = Vector2.zero;
            rootRect.offsetMax = Vector2.zero;
            _nativeUiAttachedToGameCanvas = true;
        }
        else
        {
            Object.DontDestroyOnLoad(_nativeUiRoot);
            Canvas canvas = _nativeUiRoot.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.sortingOrder = 32000;
            CanvasScaler scaler = _nativeUiRoot.AddComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(1920f, 1080f);
            scaler.matchWidthOrHeight = 0.5f;
            _nativeUiRoot.AddComponent<GraphicRaycaster>();
            _nativeUiAttachedToGameCanvas = false;
        }

        _nativeUiChip = CreatePanel(_nativeUiRoot.transform, "CustomServerChip", new Vector2(320f, 56f), new Vector2(1f, 1f), new Vector2(-24f, -24f), new Color(0.04f, 0.05f, 0.07f, 0.92f));
        _nativeChipRect = _nativeUiChip.GetComponent<RectTransform>();
        _nativeChipText = CreateText(_nativeUiChip.transform, "ChipText", "Custom Server", 16, TextAnchor.MiddleLeft, new Vector2(296f, 38f), new Vector2(0f, 0.5f), new Vector2(16f, 0f));

        // Bottom-center modding overlay (BAPBAP Modding / discord.gg/bapbapmods)
        // Disabled experimental modding overlay - was a cosmetic add that may have destabilized things
        // _nativeModdingOverlay = CreatePanel(_nativeUiRoot.transform, "BapModdingOverlay", new Vector2(420f, 60f), new Vector2(0.5f, 0f), new Vector2(0f, 24f), new Color(0f, 0f, 0f, 0.55f));
        // _nativeModdingTitle = CreateText(_nativeModdingOverlay.transform, "ModdingTitle", "BAPBAP Modding", 18, TextAnchor.MiddleCenter, new Vector2(400f, 24f), new Vector2(0.5f, 1f), new Vector2(0f, -6f));
        // _nativeModdingSub = CreateText(_nativeModdingOverlay.transform, "ModdingSub", "discord.gg/bapbapmods", 13, TextAnchor.MiddleCenter, new Vector2(400f, 20f), new Vector2(0.5f, 0f), new Vector2(0f, 6f));

        _nativeSetupPanel = CreatePanel(_nativeUiRoot.transform, "CustomServerIdentitySetup", new Vector2(540f, 286f), new Vector2(0.5f, 0.5f), Vector2.zero, new Color(0.045f, 0.05f, 0.06f, 0.98f));
        CreateText(_nativeSetupPanel.transform, "SetupTitle", "Custom Server Setup", 24, TextAnchor.MiddleLeft, new Vector2(470f, 34f), new Vector2(0f, 1f), new Vector2(24f, -26f));
        CreateText(_nativeSetupPanel.transform, "SetupBody", "Choose your player name. A local Account ID is generated and saved to BapCustomServer.ini.", 15, TextAnchor.UpperLeft, new Vector2(492f, 48f), new Vector2(0f, 1f), new Vector2(24f, -70f));
        CreateText(_nativeSetupPanel.transform, "SetupNameLabel", "Player name", 14, TextAnchor.MiddleLeft, new Vector2(130f, 34f), new Vector2(0f, 1f), new Vector2(24f, -138f));
        _nativeSetupNameInput = CreateInput(_nativeSetupPanel.transform, "SetupNameInput", "PlayerName", new Vector2(330f, 38f), new Vector2(1f, 1f), new Vector2(-24f, -138f));
        _nativeSetupStatusText = CreateText(_nativeSetupPanel.transform, "SetupStatus", "", 13, TextAnchor.UpperLeft, new Vector2(492f, 42f), new Vector2(0f, 0f), new Vector2(24f, 74f));
        _nativeSetupContinueRect = CreateButton(_nativeSetupPanel.transform, "SetupContinue", "Continue", new Vector2(142f, 38f), new Vector2(1f, 0f), new Vector2(-24f, 24f)).GetComponent<RectTransform>();
        _nativeSetupPanel.SetActive(false);

        _nativeUiPanel = CreatePanel(_nativeUiRoot.transform, "CustomServerPanel", new Vector2(430f, 390f), new Vector2(1f, 1f), new Vector2(-24f, -92f), new Color(0.05f, 0.055f, 0.065f, 0.97f));
        CreateText(_nativeUiPanel.transform, "Title", "Custom Server", 22, TextAnchor.MiddleLeft, new Vector2(260f, 34f), new Vector2(0f, 1f), new Vector2(20f, -24f));
        GameObject closeButton = CreateButton(_nativeUiPanel.transform, "Close", "Close", new Vector2(84f, 30f), new Vector2(1f, 1f), new Vector2(-20f, -24f));
        closeButton.GetComponent<Image>().color = new Color(0.13f, 0.14f, 0.16f, 0.95f);
        _nativeCloseRect = closeButton.GetComponent<RectTransform>();

        _nativeEndpointText = CreateText(_nativeUiPanel.transform, "Endpoint", "", 13, TextAnchor.MiddleLeft, new Vector2(390f, 24f), new Vector2(0f, 1f), new Vector2(20f, -58f));
        _nativeHostInput = CreateInput(_nativeUiPanel.transform, "HostInput", "Host", new Vector2(250f, 34f), new Vector2(1f, 1f), new Vector2(-20f, -100f));
        CreateText(_nativeUiPanel.transform, "HostLabel", "Host", 14, TextAnchor.MiddleLeft, new Vector2(120f, 30f), new Vector2(0f, 1f), new Vector2(20f, -100f));
        _nativeServerPortInput = CreateInput(_nativeUiPanel.transform, "ServerPortInput", DefaultServerPort.ToString(), new Vector2(250f, 34f), new Vector2(1f, 1f), new Vector2(-20f, -142f));
        CreateText(_nativeUiPanel.transform, "ServerPortLabel", "Server port", 14, TextAnchor.MiddleLeft, new Vector2(120f, 30f), new Vector2(0f, 1f), new Vector2(20f, -142f));
        _nativeLocalPortInput = CreateInput(_nativeUiPanel.transform, "LocalPortInput", "5055", new Vector2(250f, 34f), new Vector2(1f, 1f), new Vector2(-20f, -184f));
        CreateText(_nativeUiPanel.transform, "LocalPortLabel", "Local port", 14, TextAnchor.MiddleLeft, new Vector2(120f, 30f), new Vector2(0f, 1f), new Vector2(20f, -184f));

        _nativeHttpsRect = CreateToggleRow(_nativeUiPanel.transform, "HttpsToggle", "Use HTTPS", new Vector2(180f, 28f), new Vector2(0f, 1f), new Vector2(20f, -226f), out _nativeHttpsCheck).GetComponent<RectTransform>();
        _nativeProxyToggleRect = CreateToggleRow(_nativeUiPanel.transform, "ProxyToggle", "Use in-game proxy", new Vector2(210f, 28f), new Vector2(0f, 1f), new Vector2(20f, -260f), out _nativeProxyCheck).GetComponent<RectTransform>();
        _nativeStatusToggleRect = CreateToggleRow(_nativeUiPanel.transform, "StatusToggle", "Show status chip", new Vector2(210f, 28f), new Vector2(0f, 1f), new Vector2(20f, -294f), out _nativeStatusCheck).GetComponent<RectTransform>();

        _nativeApplyRect = CreateButton(_nativeUiPanel.transform, "Apply", "Apply + Save", new Vector2(150f, 36f), new Vector2(0f, 0f), new Vector2(20f, 22f)).GetComponent<RectTransform>();
        _nativeDirectRect = CreateButton(_nativeUiPanel.transform, "Direct", "Direct mode", new Vector2(130f, 36f), new Vector2(0.5f, 0f), new Vector2(-4f, 22f)).GetComponent<RectTransform>();
        _nativeProxyRect = CreateButton(_nativeUiPanel.transform, "Proxy", "Proxy mode", new Vector2(130f, 36f), new Vector2(1f, 0f), new Vector2(-20f, 22f)).GetComponent<RectTransform>();

        _nativeStatusText = CreateText(_nativeUiPanel.transform, "Status", "", 13, TextAnchor.UpperLeft, new Vector2(390f, 48f), new Vector2(0f, 0f), new Vector2(20f, 72f));
        _nativeUiPanel.SetActive(false);
        LoggerInstance.Msg(_nativeUiAttachedToGameCanvas
            ? "Native custom server UI attached to existing game UI canvas."
            : "Native custom server UI created as independent overlay canvas.");
    }

    private Transform? TryFindGameUiParent()
    {
        try
        {
            Type? uiManagerType = FindType("BAPBAP.UI.UIManager");
            if (uiManagerType != null)
            {
                object? instance = GetMemberValue(uiManagerType, "Instance");
                if (instance != null)
                {
                    if (GetMemberValue(instance, "mainCanvas") is Transform mainCanvas)
                    {
                        return mainCanvas;
                    }

                    if (GetMemberValue(instance, "lobbyRoot") is GameObject lobbyRoot)
                    {
                        Canvas? lobbyCanvas = lobbyRoot.GetComponentInParent<Canvas>();
                        if (lobbyCanvas != null)
                        {
                            return lobbyCanvas.transform;
                        }
                    }
                }
            }

            Array? canvases = FindLoadedUnityObjects(typeof(Canvas));
            Canvas? candidate = (canvases?.Cast<object>() ?? Enumerable.Empty<object>())
                .OfType<Canvas>()
                .Where(canvas => canvas != null && canvas.isRootCanvas && canvas.gameObject.activeInHierarchy)
                .OrderByDescending(canvas => canvas.sortingOrder)
                .FirstOrDefault(canvas =>
                    canvas.name.Contains("Lobby", StringComparison.OrdinalIgnoreCase) ||
                    canvas.name.Contains("UI", StringComparison.OrdinalIgnoreCase) ||
                    canvas.name.Contains("Canvas", StringComparison.OrdinalIgnoreCase));

            return candidate?.transform;
        }
        catch (Exception ex)
        {
            LoggerInstance.Warning($"Could not locate game UI canvas for native integration: {ex.GetBaseException().Message}");
            return null;
        }
    }

    private void EnsureEventSystem()
    {
        if (Object.FindObjectOfType<EventSystem>() != null)
        {
            return;
        }

        GameObject eventSystem = new("BAP Custom Server EventSystem");
        Object.DontDestroyOnLoad(eventSystem);
        eventSystem.AddComponent<EventSystem>();
        eventSystem.AddComponent<StandaloneInputModule>();
    }

    private GameObject CreatePanel(Transform parent, string name, Vector2 size, Vector2 anchor, Vector2 anchoredPosition, Color color)
    {
        GameObject panel = new(name);
        panel.transform.SetParent(parent, worldPositionStays: false);
        RectTransform rect = panel.AddComponent<RectTransform>();
        rect.anchorMin = anchor;
        rect.anchorMax = anchor;
        rect.pivot = anchor;
        rect.sizeDelta = size;
        rect.anchoredPosition = anchoredPosition;
        Image image = panel.AddComponent<Image>();
        image.color = color;
        return panel;
    }

    private Text CreateText(Transform parent, string name, string value, int fontSize, TextAnchor alignment, Vector2 size, Vector2 anchor, Vector2 anchoredPosition)
    {
        GameObject textObject = new(name);
        textObject.transform.SetParent(parent, worldPositionStays: false);
        RectTransform rect = textObject.AddComponent<RectTransform>();
        rect.anchorMin = anchor;
        rect.anchorMax = anchor;
        rect.pivot = anchor;
        rect.sizeDelta = size;
        rect.anchoredPosition = anchoredPosition;
        Text text = textObject.AddComponent<Text>();
        text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        text.fontSize = fontSize;
        text.alignment = alignment;
        text.color = Color.white;
        text.horizontalOverflow = HorizontalWrapMode.Wrap;
        text.verticalOverflow = VerticalWrapMode.Truncate;
        text.text = value;
        return text;
    }

    private GameObject CreateButton(Transform parent, string name, string label, Vector2 size, Vector2 anchor, Vector2 anchoredPosition)
    {
        GameObject buttonObject = CreatePanel(parent, name, size, anchor, anchoredPosition, new Color(0.18f, 0.24f, 0.31f, 0.96f));
        CreateText(buttonObject.transform, "Label", label, 14, TextAnchor.MiddleCenter, new Vector2(size.x - 12f, size.y - 8f), new Vector2(0.5f, 0.5f), Vector2.zero);
        return buttonObject;
    }

    private InputField CreateInput(Transform parent, string name, string placeholder, Vector2 size, Vector2 anchor, Vector2 anchoredPosition)
    {
        GameObject inputObject = CreatePanel(parent, name, size, anchor, anchoredPosition, new Color(0.1f, 0.11f, 0.13f, 0.98f));
        InputField input = inputObject.AddComponent<InputField>();
        input.targetGraphic = inputObject.GetComponent<Image>();
        Text text = CreateText(inputObject.transform, "Text", "", 14, TextAnchor.MiddleLeft, new Vector2(size.x - 24f, size.y - 8f), new Vector2(0f, 0.5f), new Vector2(12f, 0f));
        Text placeholderText = CreateText(inputObject.transform, "Placeholder", placeholder, 14, TextAnchor.MiddleLeft, new Vector2(size.x - 24f, size.y - 8f), new Vector2(0f, 0.5f), new Vector2(12f, 0f));
        placeholderText.color = new Color(0.72f, 0.74f, 0.78f, 0.65f);
        input.textComponent = text;
        input.placeholder = placeholderText;
        return input;
    }

    private void HandleNativeUiPointer(Vector3 screenPosition)
    {
        if (_identitySetupRequired)
        {
            if (ContainsScreenPoint(_nativeSetupContinueRect, screenPosition))
            {
                _setupUsernameText = _nativeSetupNameInput?.text ?? _setupUsernameText;
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

        bool changed = false;
        bool submit = Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter);

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (_setupUsernameText.Length > 0)
            {
                _setupUsernameText = _setupUsernameText[..^1];
                changed = true;
            }
        }

        bool shift = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        for (int i = 0; i < 26 && _setupUsernameText.Length < 18; i++)
        {
            KeyCode key = (KeyCode)((int)KeyCode.A + i);
            if (Input.GetKeyDown(key))
            {
                char value = (char)((shift ? 'A' : 'a') + i);
                _setupUsernameText += value;
                changed = true;
            }
        }

        for (int i = 0; i < 10 && _setupUsernameText.Length < 18; i++)
        {
            if (Input.GetKeyDown((KeyCode)((int)KeyCode.Alpha0 + i)) ||
                Input.GetKeyDown((KeyCode)((int)KeyCode.Keypad0 + i)))
            {
                _setupUsernameText += (char)('0' + i);
                changed = true;
            }
        }

        if (_setupUsernameText.Length < 18 && Input.GetKeyDown(KeyCode.Minus))
        {
            _setupUsernameText += shift ? '_' : '-';
            changed = true;
        }

        if (changed && _nativeSetupNameInput != null)
        {
            _nativeSetupNameInput.text = _setupUsernameText;
        }

        if (submit)
        {
            CompleteIdentitySetupFromGui();
            RefreshNativeGameUi(syncInputs: true);
        }
    }

    private static bool ContainsScreenPoint(RectTransform? rect, Vector3 screenPosition)
    {
        if (rect == null)
        {
            return false;
        }

        Canvas? canvas = rect.GetComponentInParent<Canvas>();
        Camera? camera = canvas != null && canvas.renderMode != RenderMode.ScreenSpaceOverlay
            ? canvas.worldCamera ?? Camera.main
            : null;
        return RectTransformUtility.RectangleContainsScreenPoint(rect, screenPosition, camera);
    }

    private GameObject CreateToggleRow(Transform parent, string name, string label, Vector2 size, Vector2 anchor, Vector2 anchoredPosition, out GameObject checkmark)
    {
        GameObject toggleObject = new(name);
        toggleObject.transform.SetParent(parent, worldPositionStays: false);
        RectTransform rect = toggleObject.AddComponent<RectTransform>();
        rect.anchorMin = anchor;
        rect.anchorMax = anchor;
        rect.pivot = anchor;
        rect.sizeDelta = size;
        rect.anchoredPosition = anchoredPosition;

        GameObject background = CreatePanel(toggleObject.transform, "Box", new Vector2(20f, 20f), new Vector2(0f, 0.5f), new Vector2(0f, 0f), new Color(0.1f, 0.11f, 0.13f, 0.98f));
        checkmark = CreatePanel(background.transform, "Checkmark", new Vector2(12f, 12f), new Vector2(0.5f, 0.5f), Vector2.zero, new Color(0.26f, 0.58f, 0.9f, 1f));
        CreateText(toggleObject.transform, "Label", label, 14, TextAnchor.MiddleLeft, new Vector2(size.x - 30f, size.y), new Vector2(0f, 0.5f), new Vector2(30f, 0f));
        return toggleObject;
    }

    private void ApplyNativeUiTextToEntries(bool validateOnly)
    {
        if (_nativeHostInput != null)
        {
            _hostEntry.Value = NormalizeHost(_nativeHostInput.text);
        }

        if (_nativeServerPortInput != null && int.TryParse(_nativeServerPortInput.text, out int serverPort))
        {
            _serverPortText = serverPort.ToString();
        }

        if (_nativeLocalPortInput != null && int.TryParse(_nativeLocalPortInput.text, out int localPort))
        {
            _localPortText = localPort.ToString();
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
        if (_nativeUiRoot == null)
        {
            return;
        }

        if (syncInputs)
        {
            if (_nativeHostInput != null)
            {
                _nativeHostInput.text = _hostEntry.Value;
            }

            if (_nativeServerPortInput != null)
            {
                _nativeServerPortInput.text = _serverPortEntry.Value.ToString();
            }

            if (_nativeLocalPortInput != null)
            {
                _nativeLocalPortInput.text = _localPortEntry.Value.ToString();
            }

            if (_nativeSetupNameInput != null && _identitySetupRequired)
            {
                _nativeSetupNameInput.text = _setupUsernameText;
            }

            _nativeHttpsCheck?.SetActive(_httpsEntry.Value);
            _nativeProxyCheck?.SetActive(_localProxyEntry.Value);
            _nativeStatusCheck?.SetActive(_statusChipEntry.Value);
        }

        string endpoint = GetConfiguredApiHost();
        if (_nativeChipText != null)
        {
            _nativeChipText.text = $"Custom Server\n{endpoint}";
        }

        if (_nativeEndpointText != null)
        {
            _nativeEndpointText.text = $"Active endpoint: {endpoint}";
        }

        if (_nativeStatusText != null)
        {
            _nativeStatusText.text = $"Status: {_statusText}";
        }

        if (_nativeSetupStatusText != null)
        {
            _nativeSetupStatusText.text = string.IsNullOrWhiteSpace(_setupErrorText)
                ? "Delete AccountId or Username from the ini to show this setup again."
                : _setupErrorText;
            _nativeSetupStatusText.color = string.IsNullOrWhiteSpace(_setupErrorText)
                ? new Color(0.78f, 0.82f, 0.88f, 1f)
                : new Color(1f, 0.58f, 0.42f, 1f);
        }

        _nativeSetupPanel?.SetActive(_identitySetupRequired);
        _nativeUiChip?.SetActive(!_identitySetupRequired && _statusChipEntry?.Value == true && !_nativeUiExpanded);

        // Modding overlay disabled - was destabilizing the lobby
        _nativeUiPanel?.SetActive(!_identitySetupRequired && _nativeUiExpanded);
    }

    private void DestroyNativeGameUi()
    {
        if (_nativeUiRoot == null)
        {
            return;
        }

        Object.Destroy(_nativeUiRoot);
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

    private static string LabeledTextField(string label, string value)
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label(label, GUILayout.Width(92f));
        string next = GUILayout.TextField(value ?? "", GUILayout.MinWidth(220f));
        GUILayout.EndHorizontal();
        return next;
    }

    private void ApplySettings(bool restartProxy, bool save)
    {
        if (!int.TryParse(_serverPortText, out int serverPort) || serverPort is <= 0 or > 65535)
        {
            _statusText = "Invalid server port";
            return;
        }

        if (!int.TryParse(_localPortText, out int localPort) || localPort is <= 0 or > 65535)
        {
            _statusText = "Invalid local proxy port";
            return;
        }

        _serverPortEntry.Value = serverPort;
        _localPortEntry.Value = localPort;
        _hostEntry.Value = NormalizeHost(_hostEntry.Value);
        UpdateIdentitySetupRequirement("settings apply");

        if (save)
        {
            MelonPreferences.Save();
            SaveIniSettings();
        }

        Uri upstream = BuildUpstreamUri();
        _lastAppliedApiHost = GetConfiguredApiHost();

        if (_localProxyEntry.Value)
        {
            if (localPort == serverPort && IsLoopbackHost(upstream.Host))
            {
                StopProxy();
                _statusText = "Proxy disabled: local port equals upstream server port";
                LoggerInstance.Warning(_statusText);
                PatchLoadedNetworkConfigs();
                return;
            }

            if (restartProxy)
            {
                RestartProxy(localPort, upstream);
            }
        }
        else
        {
            _statusText = $"Direct mode -> {upstream}";
            bool canRunCompatibilityProxy = localPort != serverPort || !IsLoopbackHost(upstream.Host);
            if (canRunCompatibilityProxy)
            {
                if (restartProxy)
                {
                    RestartProxy(localPort, upstream);
                }

                _statusText = $"Direct mode -> {upstream} (compat proxy 127.0.0.1:{localPort})";
                if (!_directModeCompatibilityProxyLogged)
                {
                    _directModeCompatibilityProxyLogged = true;
                    LoggerInstance.Msg($"Direct mode compatibility proxy enabled for legacy loopback API calls: 127.0.0.1:{localPort} -> {upstream}");
                }
            }
            else
            {
                StopProxy();
            }
        }

        PatchLoadedNetworkConfigs();
    }

    private static string ResolveIniPath(string[] args)
    {
        foreach (string arg in args)
        {
            if (TryGetArgValue(arg, "--bapcustom-config=", out string? configPath) &&
                !string.IsNullOrWhiteSpace(configPath))
            {
                return Path.GetFullPath(Environment.ExpandEnvironmentVariables(configPath.Trim().Trim('"')));
            }
        }

        string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        if (!string.IsNullOrWhiteSpace(appData))
        {
            string appDataIniPath = Path.Combine(appData, AppDataFolderName, IniFileName);
            MigrateLegacyIniToAppData(appDataIniPath);
            return appDataIniPath;
        }

        return ResolveLegacyIniPath();
    }

    private static string ResolveLegacyIniPath()
    {
        string assemblyPath = typeof(CustomServerMod).Assembly.Location;
        string? assemblyDirectory = string.IsNullOrWhiteSpace(assemblyPath) ? null : Path.GetDirectoryName(assemblyPath);
        if (!string.IsNullOrWhiteSpace(assemblyDirectory))
        {
            return Path.Combine(assemblyDirectory, IniFileName);
        }

        return Path.Combine(Environment.CurrentDirectory, "Mods", IniFileName);
    }

    private static void MigrateLegacyIniToAppData(string appDataIniPath)
    {
        try
        {
            if (File.Exists(appDataIniPath))
            {
                return;
            }

            string legacyIniPath = ResolveLegacyIniPath();
            if (!File.Exists(legacyIniPath))
            {
                return;
            }

            string? directory = Path.GetDirectoryName(appDataIniPath);
            if (!string.IsNullOrWhiteSpace(directory))
            {
                Directory.CreateDirectory(directory);
            }

            File.Copy(legacyIniPath, appDataIniPath, overwrite: false);
        }
        catch
        {
            // Loading will create a fresh per-device ini if migration is unavailable.
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
                LoggerInstance.Msg($"Created default custom server ini: {_iniPath}");
                return;
            }

            string section = "";
            foreach (string rawLine in File.ReadAllLines(_iniPath, Encoding.UTF8))
            {
                string line = rawLine.Trim();
                if (line.Length == 0 || line.StartsWith("#", StringComparison.Ordinal) || line.StartsWith(";", StringComparison.Ordinal))
                {
                    continue;
                }

                if (line.StartsWith("[", StringComparison.Ordinal) && line.EndsWith("]", StringComparison.Ordinal))
                {
                    section = line[1..^1].Trim();
                    continue;
                }

                int separator = line.IndexOf('=');
                if (separator <= 0)
                {
                    continue;
                }

                string key = line[..separator].Trim();
                string value = line[(separator + 1)..].Trim().Trim('"');
                ApplyIniValue(section, key, value);
            }

            LoggerInstance.Msg("Loaded custom server ini.");
        }
        catch (Exception ex)
        {
            LoggerInstance.Warning($"Failed to load custom server ini '{_iniPath}': {ex.GetBaseException().Message}");
        }
    }

    private void ApplyIniValue(string section, string key, string value)
    {
        string normalizedSection = NormalizeIniToken(section);
        string normalizedKey = NormalizeIniToken(key);

        if (normalizedSection is "" or "server" or "network")
        {
            switch (normalizedKey)
            {
                case "host":
                case "ip":
                case "serverip":
                case "serverhost":
                    _hostEntry.Value = NormalizeHost(value);
                    return;
                case "port":
                case "serverport":
                    if (int.TryParse(value, out int serverPort))
                    {
                        _serverPortEntry.Value = serverPort;
                    }
                    return;
                case "https":
                case "usehttps":
                case "ssl":
                    if (TryParseBool(value, out bool useHttps))
                    {
                        _httpsEntry.Value = useHttps;
                    }
                    return;
                case "proxy":
                case "localproxy":
                case "uselocalproxy":
                    if (TryParseBool(value, out bool useProxy))
                    {
                        _localProxyEntry.Value = useProxy;
                    }
                    return;
                case "localport":
                case "proxyport":
                case "localproxyport":
                    if (int.TryParse(value, out int localPort))
                    {
                        _localPortEntry.Value = localPort;
                    }
                    return;
            }
        }

        if (normalizedSection is "" or "identity" or "account")
        {
            switch (normalizedKey)
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
                case "autoguestlogin":
                case "autologin":
                case "guestlogin":
                    if (TryParseBool(value, out bool autoGuestLogin))
                    {
                        _autoGuestLoginEntry.Value = autoGuestLogin;
                    }
                    return;
            }
        }

        if (normalizedSection is "" or "ui")
        {
            switch (normalizedKey)
            {
                case "showstatuschip":
                case "statuschip":
                    if (TryParseBool(value, out bool showStatusChip))
                    {
                        _statusChipEntry.Value = showStatusChip;
                    }
                    return;
                case "usenativegameui":
                case "nativeui":
                    if (TryParseBool(value, out bool useNativeUi))
                    {
                        _nativeUiEntry.Value = useNativeUi;
                    }
                    return;
            }
        }
    }

    private void SaveIniSettings()
    {
        try
        {
            if (string.IsNullOrWhiteSpace(_iniPath))
            {
                return;
            }

            string? directory = Path.GetDirectoryName(_iniPath);
            if (!string.IsNullOrWhiteSpace(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var builder = new StringBuilder();
            builder.AppendLine("[Server]");
            builder.AppendLine($"Host={NormalizeHost(_hostEntry.Value)}");
            builder.AppendLine($"Port={_serverPortEntry.Value}");
            builder.AppendLine($"UseHttps={FormatBool(_httpsEntry.Value)}");
            builder.AppendLine($"UseLocalProxy={FormatBool(_localProxyEntry.Value)}");
            builder.AppendLine($"LocalProxyPort={_localPortEntry.Value}");
            builder.AppendLine();
            builder.AppendLine("[Identity]");
            builder.AppendLine($"AccountId={_accountIdEntry.Value.Trim()}");
            builder.AppendLine($"Username={_usernameEntry.Value.Trim()}");
            builder.AppendLine($"AutoGuestLogin={FormatBool(_autoGuestLoginEntry.Value)}");

            File.WriteAllText(_iniPath, builder.ToString(), Encoding.UTF8);
            // Don't log the ini path (privacy - log location reveals user account)
        }
        catch (Exception ex)
        {
            LoggerInstance.Warning($"Failed to save custom server ini '{_iniPath}': {ex.GetBaseException().Message}");
        }
    }

    private bool HasCompleteLocalIdentity()
    {
        return !string.IsNullOrWhiteSpace(_accountIdEntry.Value) &&
               !string.IsNullOrWhiteSpace(_usernameEntry.Value);
    }

    private int GetDiscriminatorForHeaders()
    {
        string accountId = _accountIdEntry?.Value?.Trim() ?? "";
        return Math.Abs(accountId.GetHashCode() % 9000) + 1000;
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
        _setupUsernameText = string.IsNullOrWhiteSpace(_usernameEntry.Value) ? "" : _usernameEntry.Value.Trim();
        _statusText = "Waiting for player setup";
        ClearCustomServerLoginPrefs("identity setup required");

        if (!_identitySetupLogged)
        {
            _identitySetupLogged = true;
            LoggerInstance.Msg($"Custom server identity setup required after {reason}; AccountId and Username must both be present.");
        }
    }

    private void CompleteIdentitySetupFromGui(bool queueRelaunch = true)
    {
        if (_nativeSetupNameInput != null && !string.IsNullOrWhiteSpace(_nativeSetupNameInput.text))
        {
            _setupUsernameText = _nativeSetupNameInput.text;
        }

        string username = NormalizePlayerName(_setupUsernameText);
        if (username.Length < 3)
        {
            _setupErrorText = "Use 3-18 letters, numbers, underscore, or dash.";
            RefreshNativeGameUi(syncInputs: false);
            return;
        }

        _usernameEntry.Value = username;
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

        LoggerInstance.Msg($"Created first-start custom-server identity: {username} ({_accountIdEntry.Value}).");
    }

    private void CompletePendingIdentitySetupFromCommandLine()
    {
        if (_dedicatedProcess || !_identitySetupRequired || string.IsNullOrWhiteSpace(_pendingSetupUsername))
        {
            return;
        }

        _setupUsernameText = _pendingSetupUsername;
        _pendingSetupUsername = null;
        CompleteIdentitySetupFromGui(queueRelaunch: false);
    }

    private void QueueIdentitySetupProcessRelaunch()
    {
        if (_dedicatedProcess || _identitySetupProcessRelaunchQueued)
        {
            return;
        }

        _identitySetupProcessRelaunchAt = Time.realtimeSinceStartup + 0.5f;
        _identitySetupProcessRelaunchQueued = true;
        LoggerInstance.Msg("Queued game relaunch after first-start identity setup.");
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
            string? exePath = TryGetCurrentProcessPath();
            if (string.IsNullOrWhiteSpace(exePath) || !File.Exists(exePath))
            {
                LoggerInstance.Warning("Could not relaunch game after first-start identity setup because the executable path was not found.");
                return;
            }

            string workingDirectory = Path.GetDirectoryName(exePath) ?? Directory.GetCurrentDirectory();
            string arguments = string.Join(" ", Environment.GetCommandLineArgs().Skip(1).Select(QuoteCommandArgument));
            string command = $"/c ping 127.0.0.1 -n 3 > nul && start \"\" {QuoteCommandArgument(exePath)} {arguments}";
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = command,
                WorkingDirectory = workingDirectory,
                UseShellExecute = false,
                CreateNoWindow = true
            });

            LoggerInstance.Msg("Relaunching game after first-start identity setup so the saved custom-server session is used during startup.");
            _quitGuardActive = false;
            Application.Quit();
        }
        catch (Exception ex)
        {
            LoggerInstance.Warning($"Failed to relaunch game after first-start identity setup: {ex.GetBaseException().Message}");
        }
    }

    private static string? TryGetCurrentProcessPath()
    {
        try
        {
            string? path = System.Diagnostics.Process.GetCurrentProcess().MainModule?.FileName;
            if (!string.IsNullOrWhiteSpace(path))
            {
                return path;
            }
        }
        catch
        {
        }

        string dataPath = Application.dataPath ?? "";
        DirectoryInfo? dataDirectory = string.IsNullOrWhiteSpace(dataPath)
            ? null
            : Directory.GetParent(dataPath);
        if (dataDirectory == null)
        {
            return null;
        }

        string fallback = Path.Combine(dataDirectory.FullName, "bapbap.exe");
        return File.Exists(fallback) ? fallback : null;
    }

    private static string QuoteCommandArgument(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return "\"\"";
        }

        return value.IndexOfAny(new[] { ' ', '\t', '"', '&', '(', ')', '^', '|' }) < 0
            ? value
            : "\"" + value.Replace("\"", "\\\"") + "\"";
    }

    private void ClearCustomServerLoginPrefs(string reason)
    {
        try
        {
            PlayerPrefs.DeleteKey("SESSION_ID");
            PlayerPrefs.SetInt("AUTO_LOGIN", 0);
            PlayerPrefs.Save();
            _primedLoginSessionId = null;
            LoggerInstance.Msg($"Cleared BAPBAP auto-login prefs because {reason}.");
        }
        catch (Exception ex)
        {
            LoggerInstance.Warning($"Failed to clear BAPBAP auto-login prefs: {ex.GetBaseException().Message}");
        }
    }

    private static string GenerateLocalAccountId()
    {
        return $"custom-{Guid.NewGuid():N}"[..19];
    }

    private static string NormalizePlayerName(string value)
    {
        return new string((value ?? "")
            .Where(ch => char.IsLetterOrDigit(ch) || ch is '_' or '-')
            .Take(18)
            .ToArray());
    }

    private void PrimeCustomServerLoginPrefs()
    {
        if (_dedicatedProcess || _autoGuestLoginEntry?.Value != true)
        {
            return;
        }

        string accountId = _accountIdEntry.Value.Trim();
        if (string.IsNullOrWhiteSpace(accountId) || string.IsNullOrWhiteSpace(_usernameEntry.Value))
        {
            UpdateIdentitySetupRequirement("login priming");
            return;
        }

        string sid = $"bapcustom-{accountId}";
        if (string.Equals(_primedLoginSessionId, sid, StringComparison.Ordinal))
        {
            return;
        }

        try
        {
            PlayerPrefs.SetString("SESSION_ID", sid);
            PlayerPrefs.SetInt("AUTO_LOGIN", 1);
            PlayerPrefs.Save();
            _primedLoginSessionId = sid;
            LoggerInstance.Msg($"Primed auto-login prefs for custom server session.");
        }
        catch (Exception ex)
        {
            LoggerInstance.Warning($"Failed to prime BAPBAP auto-login prefs: {ex.GetBaseException().Message}");
        }
    }

    private static string NormalizeIniToken(string value)
    {
        return new string((value ?? "")
            .Where(char.IsLetterOrDigit)
            .Select(char.ToLowerInvariant)
            .ToArray());
    }

    private static string FormatBool(bool value)
    {
        return value ? "true" : "false";
    }

    private void ApplyCommandLineOverrides(string[] args)
    {
        bool proxyExplicit = false;

        foreach (string arg in args)
        {
            if (TryGetArgValue(arg, "--bapcustom-host=", out string? host))
            {
                _hostEntry.Value = NormalizeHost(host);
            }
            else if (TryGetArgValue(arg, "--bapcustom-server-port=", out string? serverPort) &&
                     int.TryParse(serverPort, out int parsedServerPort))
            {
                _serverPortEntry.Value = parsedServerPort;
            }
            else if (TryGetArgValue(arg, "--bapcustom-local-port=", out string? localPort) &&
                     int.TryParse(localPort, out int parsedLocalPort))
            {
                _localPortEntry.Value = parsedLocalPort;
            }
            else if (TryGetArgValue(arg, "--bapcustom-use-https=", out string? https) &&
                     https != null &&
                     TryParseBool(https, out bool parsedHttps))
            {
                _httpsEntry.Value = parsedHttps;
            }
            else if (TryGetArgValue(arg, "--bapcustom-use-proxy=", out string? proxy) &&
                     proxy != null &&
                     TryParseBool(proxy, out bool parsedProxy))
            {
                _localProxyEntry.Value = parsedProxy;
                proxyExplicit = true;
            }
            else if (TryGetArgValue(arg, "--bapcustom-show-ui=", out string? showUi) &&
                     showUi != null &&
                     TryParseBool(showUi, out bool parsedShowUi))
            {
                _uiEnabled = parsedShowUi;
                _showWindow = parsedShowUi;
                if (!parsedShowUi && _statusChipEntry != null)
                {
                    _statusChipEntry.Value = false;
                }
            }
            else if (TryGetArgValue(arg, "--bapcustom-account-id=", out string? accountId))
            {
                _accountIdEntry.Value = string.IsNullOrWhiteSpace(accountId) ? "" : accountId.Trim();
            }
            else if (TryGetArgValue(arg, "--bapcustom-username=", out string? username))
            {
                _usernameEntry.Value = string.IsNullOrWhiteSpace(username) ? "" : username.Trim();
            }
            else if (TryGetArgValue(arg, "--bapcustom-setup-username=", out string? setupUsername))
            {
                _pendingSetupUsername = string.IsNullOrWhiteSpace(setupUsername) ? null : setupUsername.Trim();
            }
            else if (TryGetArgValue(arg, "--bapcustom-auto-login=", out string? autoLogin) &&
                     autoLogin != null &&
                     TryParseBool(autoLogin, out bool parsedAutoLogin))
            {
                _autoGuestLoginEntry.Value = parsedAutoLogin;
            }
            else if (TryGetArgValue(arg, "--bapcustom-join-auth=", out string? joinAuth))
            {
                _autoJoinGameAuthId = string.IsNullOrWhiteSpace(joinAuth) ? null : joinAuth.Trim();
            }
            else if (TryGetArgValue(arg, "--bapcustom-join-host=", out string? joinHost))
            {
                _autoJoinHost = NormalizeHost(joinHost);
            }
            else if (TryGetArgValue(arg, "--bapcustom-join-ws=", out string? joinWsPort) &&
                     int.TryParse(joinWsPort, out int parsedJoinWsPort))
            {
                _autoJoinWsPort = parsedJoinWsPort;
            }
            else if (TryGetArgValue(arg, "--bapcustom-join-kcp=", out string? joinKcpPort) &&
                     int.TryParse(joinKcpPort, out int parsedJoinKcpPort))
            {
                _autoJoinKcpPort = parsedJoinKcpPort;
            }
            else if (TryGetArgValue(arg, "--bapcustom-join-tcp=", out string? joinTcpPort) &&
                     int.TryParse(joinTcpPort, out int parsedJoinTcpPort))
            {
                _autoJoinTcpPort = parsedJoinTcpPort;
            }
            else if (TryGetArgValue(arg, "--bapcustom-selected-char=", out string? selectedChar) &&
                     int.TryParse(selectedChar, out int parsedSelectedChar) &&
                     parsedSelectedChar >= 0)
            {
                _requestedCharacterId = parsedSelectedChar;
                _lastKnownSelectedCharacterId = parsedSelectedChar;
            }
            else if (TryGetArgValue(arg, "--bapcustom-auto-end-after=", out string? autoEndAfter) &&
                     float.TryParse(autoEndAfter, out float parsedAutoEndAfter) &&
                     parsedAutoEndAfter > 0f)
            {
                _autoEndAfterSeconds = parsedAutoEndAfter;
            }
            else if (arg.Equals("--bapcustom-autoplay", StringComparison.OrdinalIgnoreCase))
            {
                _autoplayEnabled = true;
            }
            else if (arg.Equals("--bapcustom-auto-select-augment", StringComparison.OrdinalIgnoreCase) ||
                     arg.Equals("--bapcustom-auto-select-augments", StringComparison.OrdinalIgnoreCase))
            {
                _autoSelectAugmentsEnabled = true;
            }
            else if ((TryGetArgValue(arg, "-httpport=", out string? httpPort) ||
                      TryGetArgValue(arg, "--httpport=", out httpPort)) &&
                     int.TryParse(httpPort, out int parsedHttpPort))
            {
                _dedicatedHttpPort = parsedHttpPort;
                _dedicatedProcess = true;
            }
            else if ((TryGetArgValue(arg, "-wsport=", out string? wsPort) ||
                      TryGetArgValue(arg, "--wsport=", out wsPort)) &&
                     int.TryParse(wsPort, out int parsedWsPort))
            {
                _dedicatedWsPort = parsedWsPort;
                _dedicatedProcess = true;
            }
            else if ((TryGetArgValue(arg, "-kcpport=", out string? kcpPort) ||
                      TryGetArgValue(arg, "--kcpport=", out kcpPort)) &&
                     int.TryParse(kcpPort, out int parsedKcpPort))
            {
                _dedicatedKcpPort = parsedKcpPort;
                _dedicatedProcess = true;
            }
            else if ((TryGetArgValue(arg, "-tcpport=", out string? tcpPort) ||
                      TryGetArgValue(arg, "--tcpport=", out tcpPort)) &&
                     int.TryParse(tcpPort, out int parsedTcpPort))
            {
                _dedicatedTcpPort = parsedTcpPort;
                _dedicatedProcess = true;
            }
        }

        if (!proxyExplicit && IsDedicatedGameServerProcess(args))
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

        // Batch-mode guard: when Unity runs headless (-batchmode), suppress the local proxy,
        // native UI, identity-setup panel, and other client-only features. We promote it to
        // _dedicatedProcess=true so every existing `!_dedicatedProcess` gate (proxy startup,
        // EnsureNativeGameUi, identity setup, autoplay, etc.) automatically applies.
        try
        {
            if (!_dedicatedProcess && UnityEngine.Application.isBatchMode)
            {
                _localProxyEntry.Value = false;
                _dedicatedProcess = true;
                _uiEnabled = false;
                _showWindow = false;
                if (_statusChipEntry != null)
                {
                    _statusChipEntry.Value = false;
                }
                LoggerInstance.Msg("[BatchMode] Application.isBatchMode=true -> skipping local proxy, native UI, identity setup, and client-only mod features");
            }
        }
        catch (Exception ex)
        {
            LoggerInstance.Warning($"BatchMode detection failed: {ex.Message}");
        }

        if (_dedicatedProcess)
        {
            try
            {
                UnityEngine.Application.targetFrameRate = 240;
                UnityEngine.QualitySettings.vSyncCount = 0;
                // DO NOT change Time.fixedDeltaTime - BAPBAP physics is calibrated for default 50Hz.
                LoggerInstance.Msg("[Perf] Dedicated server: targetFrameRate=240, vSync=0 (kept default fixedDeltaTime)");
            }
            catch (Exception ex) { LoggerInstance.Warning($"Perf settings failed: {ex.Message}"); }
        }
        else
        {
            try
            {
                UnityEngine.Application.targetFrameRate = 144;
                UnityEngine.QualitySettings.vSyncCount = 0;
                LoggerInstance.Msg("[Perf] Client: targetFrameRate=144, vSync=0 (reduce DWM stall stutter)");
            }
            catch { }
        }

        LoggerInstance.Msg(
            $"[BAPCustomConfig] mode={(_dedicatedProcess ? "dedicated" : "client")} " +
            $"upstream={BuildUpstreamUri().ToString().TrimEnd('/')} proxy={_localProxyEntry.Value} localPort={_localPortEntry.Value} " +
            $"dedicatedPorts=http:{_dedicatedHttpPort?.ToString() ?? "-"} ws:{_dedicatedWsPort?.ToString() ?? "-"} kcp:{_dedicatedKcpPort?.ToString() ?? "-"} tcp:{_dedicatedTcpPort?.ToString() ?? "-"} " +
            $"batchMode={UnityEngine.Application.isBatchMode} containsNoGraphicsArg={args.Any(a => a.Contains("-nographics", StringComparison.OrdinalIgnoreCase))} " +
            $"autoJoin={(string.IsNullOrWhiteSpace(_autoJoinGameAuthId) ? "none" : $"{_autoJoinHost}:{_autoJoinKcpPort}")}");
    }

    private static bool IsDedicatedGameServerProcess(IEnumerable<string> args)
    {
        return args.Any(arg => arg.StartsWith("-httpport=", StringComparison.OrdinalIgnoreCase) ||
                               arg.StartsWith("--httpport=", StringComparison.OrdinalIgnoreCase) ||
                               arg.StartsWith("-wsport=", StringComparison.OrdinalIgnoreCase) ||
                               arg.StartsWith("--wsport=", StringComparison.OrdinalIgnoreCase) ||
                               arg.StartsWith("-kcpport=", StringComparison.OrdinalIgnoreCase) ||
                               arg.StartsWith("--kcpport=", StringComparison.OrdinalIgnoreCase) ||
                               arg.StartsWith("-tcpport=", StringComparison.OrdinalIgnoreCase) ||
                               arg.StartsWith("--tcpport=", StringComparison.OrdinalIgnoreCase));
    }

    private static bool TryGetArgValue(string arg, string prefix, out string? value)
    {
        if (arg.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
        {
            value = arg[prefix.Length..].Trim();
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

        string normalized = value.ToLowerInvariant();
        if (normalized is "1" or "yes" or "y" or "on" or "enabled")
        {
            result = true;
            return true;
        }

        if (normalized is "0" or "no" or "n" or "off" or "disabled")
        {
            result = false;
            return true;
        }

        return false;
    }

    private string GetConfiguredApiHost()
    {
        if (_localProxyEntry?.Value == true)
        {
            return $"http://127.0.0.1:{_localPortEntry.Value}";
        }

        return BuildUpstreamUri().ToString().TrimEnd('/');
    }

    private Uri BuildUpstreamUri()
    {
        string scheme = _httpsEntry.Value ? Uri.UriSchemeHttps : Uri.UriSchemeHttp;
        string host = NormalizeHost(_hostEntry.Value);
        return new UriBuilder(scheme, host, _serverPortEntry.Value).Uri;
    }

    private static string NormalizeHost(string? host)
    {
        host = (host ?? "").Trim();

        if (host.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
            host.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
        {
            if (Uri.TryCreate(host, UriKind.Absolute, out Uri? parsed))
            {
                return parsed.Host;
            }
        }

        return string.IsNullOrWhiteSpace(host) ? "127.0.0.1" : host;
    }

    private static bool IsLoopbackHost(string host)
    {
        return string.Equals(host, "localhost", StringComparison.OrdinalIgnoreCase) ||
               string.Equals(host, "127.0.0.1", StringComparison.OrdinalIgnoreCase) ||
               string.Equals(host, "::1", StringComparison.OrdinalIgnoreCase);
    }

    private void RestartProxy(int localPort, Uri upstream)
    {
        if (_dedicatedProcess || UnityEngine.Application.isBatchMode)
        {
            // Client-only feature: skip proxy startup on dedicated/headless game server processes.
            return;
        }

        StopProxy();

        try
        {
            _proxy = new LocalReverseProxy(
                localPort,
                upstream,
                () => (
                    _accountIdEntry?.Value?.Trim() ?? "",
                    _usernameEntry?.Value?.Trim() ?? "",
                    GetDiscriminatorForHeaders().ToString()),
                message => LoggerInstance.Msg(message),
                message => LoggerInstance.Warning(message),
                message => LoggerInstance.Error(message));

            _proxy.Start();
            _statusText = $"Proxy 127.0.0.1:{localPort} -> {upstream}";
        }
        catch (Exception ex)
        {
            _proxy = null;
            _statusText = $"Proxy failed: {ex.Message}";
            LoggerInstance.Error($"Failed to start local proxy: {ex}");
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
            LoggerInstance.Warning($"Failed to stop local proxy cleanly: {ex.Message}");
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

        Type? networkConfigType = FindType("BAPBAP.Network.NetworkConfig");
        if (networkConfigType == null)
        {
            return;
        }

        MethodInfo? postfix = typeof(CustomServerMod).GetMethod(
            nameof(NetworkConfigClientPostfix),
            BindingFlags.Static | BindingFlags.NonPublic);
        MethodInfo? serverPostfix = typeof(CustomServerMod).GetMethod(
            nameof(NetworkConfigServerPostfix),
            BindingFlags.Static | BindingFlags.NonPublic);

        if (postfix == null || serverPostfix == null)
        {
            return;
        }

        int patched = 0;
        try
        {
            PropertyInfo? clientProperty = networkConfigType.GetProperty(
                "Client",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            MethodInfo? clientGetter = clientProperty?.GetGetMethod(nonPublic: true);
            if (clientGetter != null && PatchHarmonyPostfix(clientGetter, postfix))
            {
                patched++;
            }

            MethodInfo? getClient = networkConfigType.GetMethod(
                "GetClient",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            if (getClient != null && PatchHarmonyPostfix(getClient, postfix))
            {
                patched++;
            }

            PropertyInfo? serverProperty = networkConfigType.GetProperty(
                "Server",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            MethodInfo? serverGetter = serverProperty?.GetGetMethod(nonPublic: true);
            if (serverGetter != null && PatchHarmonyPostfix(serverGetter, serverPostfix))
            {
                patched++;
            }

            MethodInfo? getServer = networkConfigType.GetMethod(
                "GetServer",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            if (getServer != null && PatchHarmonyPostfix(getServer, serverPostfix))
            {
                patched++;
            }

            _patchesInstalled = patched > 0;
            if (_patchesInstalled)
            {
                LoggerInstance.Msg($"Installed {patched} NetworkConfig runtime patch(es).");
            }
        }
        catch (Exception ex)
        {
            LoggerInstance.Warning($"NetworkConfig Harmony patch was not installed: {ex.Message}");
        }
    }

    private void TryInstallPreAwakeManagerNetworkPatch()
    {
        if (_preAwakeManagerNetworkPatchInstalled)
        {
            return;
        }

        Type? preAwakeManagerType = FindType("BAPBAP.Local.PreAwakeManager");
        if (preAwakeManagerType == null)
        {
            return;
        }

        MethodInfo? prefix = typeof(CustomServerMod).GetMethod(
            nameof(PreAwakeManagerAwakePrefix),
            BindingFlags.Static | BindingFlags.NonPublic);
        MethodInfo? postfix = typeof(CustomServerMod).GetMethod(
            nameof(PreAwakeManagerAwakePostfix),
            BindingFlags.Static | BindingFlags.NonPublic);
        if (prefix == null || postfix == null)
        {
            return;
        }

        MethodInfo? awake = preAwakeManagerType.GetMethod(
            "Awake",
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        if (awake == null)
        {
            return;
        }

        int patched = 0;
        List<string> failures = new();
        try
        {
            if (PatchHarmonyPrefix(awake, prefix))
            {
                patched++;
            }
        }
        catch (Exception ex)
        {
            failures.Add($"prefix: {ex.GetBaseException().Message}");
        }

        try
        {
            if (PatchHarmonyPostfix(awake, postfix))
            {
                patched++;
            }
        }
        catch (Exception ex)
        {
            failures.Add($"postfix: {ex.GetBaseException().Message}");
        }

        if (patched > 0)
        {
            _preAwakeManagerNetworkPatchInstalled = true;
            string failureSuffix = failures.Count > 0 ? $" partialFailures={string.Join(" | ", failures.Take(3))}" : "";
            LoggerInstance.Msg($"Installed {patched} PreAwakeManager network config patch(es).{failureSuffix}");
        }
        else if (failures.Count > 0)
        {
            LoggerInstance.Warning($"PreAwakeManager network config patch was not installed: {string.Join(" | ", failures.Take(3))}");
        }
    }

    private void TryInstallHttpClientHostPatch()
    {
        if (_httpClientHostPatchInstalled || _httpClientHostPatchFailed)
        {
            return;
        }

        Type? httpClientType = FindType("BAPBAP.Network.HttpClient");
        if (httpClientType == null)
        {
            return;
        }

        MethodInfo? constructorPrefix = typeof(CustomServerMod).GetMethod(
            nameof(HttpClientConstructorPrefix),
            BindingFlags.Static | BindingFlags.NonPublic);
        MethodInfo? constructorPostfix = typeof(CustomServerMod).GetMethod(
            nameof(HttpClientConstructorPostfix),
            BindingFlags.Static | BindingFlags.NonPublic);
        MethodInfo? sendPrefix = typeof(CustomServerMod).GetMethod(
            nameof(HttpClientSendRequestPrefix),
            BindingFlags.Static | BindingFlags.NonPublic);
        if (constructorPrefix == null || constructorPostfix == null || sendPrefix == null)
        {
            return;
        }

        ConstructorInfo? constructor = httpClientType.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .FirstOrDefault(candidate =>
            {
                ParameterInfo[] parameters = candidate.GetParameters();
                return parameters.Length == 3 &&
                       parameters[1].ParameterType == typeof(string) &&
                       parameters[2].ParameterType == typeof(bool);
            });
        if (constructor == null)
        {
            return;
        }

        int patched = 0;
        List<string> failures = new();

        if (constructor != null)
        {
            try
            {
                if (PatchHarmonyPrefix(constructor, constructorPrefix))
                {
                    patched++;
                }
            }
            catch (Exception ex)
            {
                failures.Add($"ctor-prefix: {ex.GetBaseException().Message}");
            }

            try
            {
                if (PatchHarmonyPostfix(constructor, constructorPostfix))
                {
                    patched++;
                }
            }
            catch (Exception ex)
            {
                failures.Add($"ctor-postfix: {ex.GetBaseException().Message}");
            }
        }

        foreach (MethodInfo method in httpClientType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                     .Where(candidate =>
                     {
                         if (candidate.Name != "SendGetRequest" && candidate.Name != "SendPostRequest")
                         {
                             return false;
                         }

                         if (candidate.ContainsGenericParameters)
                         {
                             return false;
                         }

                         ParameterInfo[] parameters = candidate.GetParameters();
                         return parameters.Length >= 1 && parameters[0].ParameterType == typeof(string);
                     }))
        {
            try
            {
                if (PatchHarmonyPrefix(method, sendPrefix))
                {
                    patched++;
                }
            }
            catch (Exception ex)
            {
                failures.Add($"{method.Name}: {ex.GetBaseException().Message}");
            }
        }

        if (patched > 0)
        {
            _httpClientHostPatchInstalled = true;
            string failureSuffix = failures.Count > 0 ? $" partialFailures={string.Join(" | ", failures.Take(3))}" : "";
            LoggerInstance.Msg($"Installed {patched} HttpClient host rewrite patch(es).{failureSuffix}");
        }
        else if (failures.Count > 0)
        {
            _httpClientHostPatchFailed = true;
            LoggerInstance.Warning($"HttpClient host rewrite patch was not installed; direct URL rewrites remain active. reason={string.Join(" | ", failures.Take(3))}");
        }
    }

    private void TryInstallControllerManagerNetworkPatch()
    {
        if (_controllerManagerNetworkPatchInstalled)
        {
            return;
        }

        Type? controllerManagerType = FindType("BAPBAP.UI.ControllerManager");
        if (controllerManagerType == null)
        {
            return;
        }

        MethodInfo? postfix = typeof(CustomServerMod).GetMethod(
            nameof(ControllerManagerConstructorPostfix),
            BindingFlags.Static | BindingFlags.NonPublic);
        if (postfix == null)
        {
            return;
        }

        ConstructorInfo? constructor = controllerManagerType
            .GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .FirstOrDefault(candidate =>
            {
                ParameterInfo[] parameters = candidate.GetParameters();
                return parameters.Length == 6 &&
                       parameters.Any(parameter => (parameter.ParameterType.FullName ?? "").Contains("HttpClient", StringComparison.Ordinal)) &&
                       parameters.Any(parameter => (parameter.ParameterType.FullName ?? "").Contains("NetworkConfig", StringComparison.Ordinal));
            });
        if (constructor == null)
        {
            return;
        }

        try
        {
            if (PatchHarmonyPostfix(constructor, postfix))
            {
                _controllerManagerNetworkPatchInstalled = true;
                LoggerInstance.Msg("Installed ControllerManager network runtime patch.");
            }
        }
        catch (Exception ex)
        {
            LoggerInstance.Warning($"ControllerManager network patch was not installed: {ex.GetBaseException().Message}");
        }
    }

    private void TryInstallLobbyNetworkClientPatches()
    {
        if (_lobbyNetworkClientPatchInstalled)
        {
            return;
        }

        Type? lobbyNetworkClientType = FindType("BAPBAP.Network.LobbyNetworkClient");
        if (lobbyNetworkClientType == null)
        {
            return;
        }

        MethodInfo? postfix = typeof(CustomServerMod).GetMethod(
            nameof(LobbyNetworkClientNetworkPostfix),
            BindingFlags.Static | BindingFlags.NonPublic);
        if (postfix == null)
        {
            return;
        }

        string[] lifecycleMethods = { "PreAwake", "Awake", "Start", "SetViewActions" };
        int patched = 0;
        List<string> failures = new();

        foreach (MethodInfo method in lobbyNetworkClientType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                     .Where(candidate => lifecycleMethods.Contains(candidate.Name, StringComparer.Ordinal) && !candidate.ContainsGenericParameters))
        {
            try
            {
                if (PatchHarmonyPostfix(method, postfix))
                {
                    patched++;
                }
            }
            catch (Exception ex)
            {
                failures.Add($"{method.Name}: {ex.GetBaseException().Message}");
            }
        }

        if (patched > 0)
        {
            _lobbyNetworkClientPatchInstalled = true;
            string failureSuffix = failures.Count > 0 ? $" partialFailures={string.Join(" | ", failures.Take(3))}" : "";
            LoggerInstance.Msg($"Installed {patched} LobbyNetworkClient runtime network patch(es).{failureSuffix}");
        }
        else if (failures.Count > 0 && !_lobbyNetworkClientPatchLogged)
        {
            _lobbyNetworkClientPatchLogged = true;
            LoggerInstance.Warning($"LobbyNetworkClient runtime network patch was not installed: {string.Join(" | ", failures.Take(3))}");
        }
    }

    private void TryInstallWebSocketClientSelectionPatch()
    {
        if (_webSocketClientSelectionPatchInstalled)
        {
            return;
        }

        Type? webSocketClientType = FindType("BAPBAP.Network.WebSocketClient");
        if (webSocketClientType == null)
        {
            return;
        }

        MethodInfo? prefix = typeof(CustomServerMod).GetMethod(
            nameof(WebSocketClientSendPrefix),
            BindingFlags.Static | BindingFlags.NonPublic);
        if (prefix == null)
        {
            return;
        }

        int patched = 0;
        List<string> failures = new();
        foreach (MethodInfo method in webSocketClientType
                     .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                     .Where(candidate =>
                     {
                         if (candidate.Name != "Send" || candidate.ContainsGenericParameters)
                         {
                             return false;
                         }

                         ParameterInfo[] parameters = candidate.GetParameters();
                         return parameters.Length >= 1 && parameters[0].ParameterType == typeof(string);
                     }))
        {
            try
            {
                if (PatchHarmonyPrefix(method, prefix))
                {
                    patched++;
                }
            }
            catch (Exception ex)
            {
                failures.Add($"{method.Name}({method.GetParameters().Length}): {ex.GetBaseException().Message}");
            }
        }

        if (patched > 0)
        {
            _webSocketClientSelectionPatchInstalled = true;
            string failureSuffix = failures.Count > 0 ? $" partialFailures={string.Join(" | ", failures.Take(3))}" : "";
            LoggerInstance.Msg($"Installed {patched} WebSocketClient selection propagation patch(es).{failureSuffix}");
        }
        else if (failures.Count > 0)
        {
            LoggerInstance.Warning($"WebSocketClient selection propagation patch was not installed: {string.Join(" | ", failures.Take(3))}");
        }
    }

    private void TryInstallCharacterSelectionTrackerPatches()
    {
        if (_characterSelectionTrackerInstalled)
        {
            return;
        }

        MethodInfo? postfix = typeof(CustomServerMod).GetMethod(
            nameof(CharacterSelectionTrackerPostfix),
            BindingFlags.Static | BindingFlags.NonPublic);
        if (postfix == null)
        {
            return;
        }

        string[] typeNames =
        {
            "BAPBAP.UI.CharSelectController",
            "BAPBAP.UI.UILobbyCharacterSelectPage",
            "BAPBAP.UI.UILobbyMatchCharacterSelectPage",
            "BAPBAP.UI.UIPreMatch",
            "BAPBAP.UI.View_PreMatch_CharSelect",
            "BAPBAP.Network.PlayerPreMatch",
            "BAPBAP.Network.PreMatchManager"
        };
        string[] methodNames =
        {
            "SwitchCharacter",
            "OnCharacterSelect",
            "OnCharacterButtonSelect",
            "OnCharacterLockButtonSelect",
            "SelectCharIconButton",
            "SetDisplayedCharacter",
            "SetLocalPlayerCharacter",
            "CmdTrySelectCharacter",
            "UserCode_CmdTrySelectCharacter__PlayerManager__Int32",
            "SetPlayerCharacter",
            "TrySelectCharacter"
        };

        int patched = 0;
        List<string> failures = new();
        foreach (string typeName in typeNames)
        {
            Type? type = FindType(typeName);
            if (type == null)
            {
                continue;
            }

            foreach (MethodInfo method in type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                         .Where(candidate => methodNames.Contains(candidate.Name, StringComparer.Ordinal) && !candidate.ContainsGenericParameters))
            {
                try
                {
                    if (PatchHarmonyPostfix(method, postfix))
                    {
                        patched++;
                    }
                }
                catch (Exception ex)
                {
                    failures.Add($"{type.Name}.{method.Name}: {ex.GetBaseException().Message}");
                }
            }
        }

        if (patched > 0)
        {
            _characterSelectionTrackerInstalled = true;
            string failureSuffix = failures.Count > 0 ? $" partialFailures={string.Join(" | ", failures.Take(3))}" : "";
            LoggerInstance.Msg($"Installed {patched} character selection tracker patch(es).{failureSuffix}");
        }
        else if (failures.Count > 0)
        {
            LoggerInstance.Warning($"Character selection tracker patch was not installed: {string.Join(" | ", failures.Take(3))}");
        }
    }

    private void TryInstallGameModePatches()
    {
        if (_gameModePatchesInstalled)
        {
            return;
        }

        Type? gameModeType = FindType("BAPBAP.Game.GameMode");
        if (gameModeType == null)
        {
            return;
        }

        MethodInfo? prefix = typeof(CustomServerMod).GetMethod(
            nameof(GameModeLevelNamesPrefix),
            BindingFlags.Static | BindingFlags.NonPublic);
        if (prefix == null)
        {
            return;
        }

        int patched = 0;
        const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        try
        {
            foreach (string methodName in new[] { "Load", "LoadCoroutine", "GetMapDataMMCacheByLevelId" })
            {
                MethodInfo? method = gameModeType.GetMethod(methodName, flags);
                if (method != null && PatchHarmonyPrefix(method, prefix))
                {
                    patched++;
                }
            }

            _gameModePatchesInstalled = patched > 0;
            if (_gameModePatchesInstalled)
            {
                LoggerInstance.Msg($"Installed {patched} GameMode level-name runtime patch(es).");
            }
        }
        catch (Exception ex)
        {
            LoggerInstance.Warning($"GameMode Harmony patch was not installed: {ex.GetBaseException().Message}");
        }
    }

    private void TryInstallJoinDiagnosticsPatches()
    {
        if (_joinDiagnosticsPatchesInstalled)
        {
            return;
        }

        Type? gameManagerType = FindType("BAPBAP.Game.GameManager");
        if (gameManagerType == null)
        {
            return;
        }

        MethodInfo? prefix = typeof(CustomServerMod).GetMethod(
            nameof(AddPlayerMatchmakingPrefix),
            BindingFlags.Static | BindingFlags.NonPublic);
        MethodInfo? postfix = typeof(CustomServerMod).GetMethod(
            nameof(AddPlayerMatchmakingPostfix),
            BindingFlags.Static | BindingFlags.NonPublic);
        MethodInfo? addPlayer = gameManagerType.GetMethod(
            "AddPlayerMatchmaking",
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        if (prefix == null || postfix == null || addPlayer == null)
        {
            return;
        }

        try
        {
            bool patched = PatchHarmonyPrefix(addPlayer, prefix);
            patched = PatchHarmonyPostfix(addPlayer, postfix) || patched;
            if (patched)
            {
                _joinDiagnosticsPatchesInstalled = true;
                LoggerInstance.Msg("Installed AddPlayerMatchmaking runtime diagnostics and Medusa skin patch.");
            }
        }
        catch (Exception ex)
        {
            LoggerInstance.Warning($"AddPlayerMatchmaking diagnostic patch was not installed: {ex.GetBaseException().Message}");
        }
    }

    private void TryInstallLoginControllerPatches()
    {
        if (_loginControllerPatchesInstalled)
        {
            return;
        }

        Type? loginControllerType = FindType("BAPBAP.UI.LoginController");
        if (loginControllerType == null)
        {
            return;
        }

        MethodInfo? autoLoginPostfix = typeof(CustomServerMod).GetMethod(
            nameof(LoginControllerAutoGuestPostfix),
            BindingFlags.Static | BindingFlags.NonPublic);
        MethodInfo? loadResponsePostfix = typeof(CustomServerMod).GetMethod(
            nameof(LoginControllerHandleLoadResponsePostfix),
            BindingFlags.Static | BindingFlags.NonPublic);

        string[] patchTargets =
        {
            "StartLoginFlow",
            "HandleOpenLoginWindow",
            "LoginSteam",
            "LoginDiscord",
            "LoginGoogle",
            "LoginFacebook"
        };

        int patched = 0;
        try
        {
            if (autoLoginPostfix != null)
            {
                foreach (string methodName in patchTargets)
                {
                    MethodInfo? method = loginControllerType.GetMethod(
                        methodName,
                        BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                        binder: null,
                        types: Type.EmptyTypes,
                        modifiers: null);
                    if (method != null && PatchHarmonyPostfix(method, autoLoginPostfix))
                    {
                        patched++;
                    }
                }
            }

            MethodInfo? handleLoadResponse = loginControllerType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .FirstOrDefault(method =>
                {
                    if (method.Name != "HandleLoadResponse")
                    {
                        return false;
                    }

                    ParameterInfo[] parameters = method.GetParameters();
                    return parameters.Length == 1;
                });
            if (handleLoadResponse != null &&
                loadResponsePostfix != null &&
                PatchHarmonyPostfix(handleLoadResponse, loadResponsePostfix))
            {
                patched++;
            }

            _loginControllerPatchesInstalled = patched > 0;
            if (_loginControllerPatchesInstalled)
            {
                LoggerInstance.Msg($"Installed {patched} LoginController custom guest-login patch(es).");
            }
        }
        catch (Exception ex)
        {
            LoggerInstance.Warning($"LoginController custom guest-login patch was not installed: {ex.GetBaseException().Message}");
        }
    }

    private void TryInstallCharacterSelectNullRefPatch()
    {
        if (_characterSelectPatchInstalled)
        {
            return;
        }

        // STEP 0 disabled: skip on OpenCharacterSummaryPage was experimental
        // if (!_openCharSummarySkipInstalled) { ... }

        Type? playTabType = FindType("BAPBAP.UI.UILobbyPlayTabPage");
        if (playTabType == null)
        {
            return;
        }

        try
        {
            // Diagnostic field dumps were here. Disabled because they took >1 second
            // and delayed the critical OpenCharacterSummaryPage skip patch beyond
            // the UILobby.Build crash window. Re-enable temporarily only if debugging.
            Type? charSelectType = FindType("BAPBAP.UI.UILobbyCharacterSelectPage");
            // (intentionally no field dump here)
            // if (playTabType != null) { ... }
            Type? matchCharSelectType = FindType("BAPBAP.UI.UILobbyMatchCharacterSelectPage");
            Type? charCustomizeType = FindType("BAPBAP.UI.UILobbyCharacterCustomizePage");
            // (intentionally no field dump here)

            MethodInfo? prefix = typeof(CustomServerMod).GetMethod(
                nameof(CharacterSelectPrefix),
                BindingFlags.Static | BindingFlags.NonPublic);

            int patched = 0;
            // NOTE: We deliberately do NOT prefix-patch UILobbyPlayTabPage.Initialise/UpdateData/UpdateCharacterData
            // because those methods set up data that the rest of the lobby UI needs (including the
            // PLAY button render). The Lobby/UI finalizer guards catch any NullRef inside.

            if (charSelectType != null)
            {
                // The "_charListingEntries" field referenced before doesn't actually exist on
                // UILobbyCharacterSelectPage in IL2CPP. Adding finalizer-style guards on each
                // problematic method is far more reliable than trying to predict null state.
                MethodInfo? finalizerMethod = typeof(CustomServerMod).GetMethod(
                    nameof(CustomServerNullRefFinalizer),
                    BindingFlags.Static | BindingFlags.NonPublic);

                string[] charSelectMethods = {
                    "UpdateData", "Initialise",
                    "UpdateAvailableCharactersData",
                    "SetCharacterButtonState",
                    "UpdateCharacterIconButtonsState",
                    "SetCurrentCharTokenProgressUI",
                    "SelectCharIconButton",
                    "OpenCharSelectPanel",
                    "CloseCharSelectPanel",
                    "TryUpdateCharMasteryBadge",
                    "UpdateCharTokenPassXp",
                    "TryUpdateKeyBinds",
                    "UpdateCharRotation",
                    "UpdateDataUnlockCharacter",
                };

                foreach (string methodName in charSelectMethods)
                {
                    foreach (MethodInfo target in charSelectType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                                 .Where(m => m.Name == methodName))
                    {
                        if (finalizerMethod != null && PatchHarmonyFinalizer(target, finalizerMethod))
                        {
                            patched++;
                        }
                    }
                }

                // TrySetSelectedCharMasteryButtonNotification: still always-skip since calling it
                // is observed to be the source of UpdateTabNotification's NullRef cascade.
                MethodInfo? unconditionalSkip = typeof(CustomServerMod).GetMethod(
                    nameof(UnconditionalSkipPrefix),
                    BindingFlags.Static | BindingFlags.NonPublic);
                MethodInfo? quietSkip = typeof(CustomServerMod).GetMethod(
                    nameof(QuietSkipPrefix),
                    BindingFlags.Static | BindingFlags.NonPublic);

                foreach (MethodInfo trySetMastery in charSelectType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                             .Where(m => m.Name == "TrySetSelectedCharMasteryButtonNotification"))
                {
                    if (quietSkip != null && PatchHarmonyPrefix(trySetMastery, quietSkip))
                    {
                        patched++;
                    }
                    else if (unconditionalSkip != null && PatchHarmonyPrefix(trySetMastery, unconditionalSkip))
                    {
                        patched++;
                    }

                    if (finalizerMethod != null && PatchHarmonyFinalizer(trySetMastery, finalizerMethod))
                    {
                        patched++;
                    }
                }

                // OpenCharacterSummaryPage skip disabled - was experimental, may have destabilized things
                // MethodInfo? openCharSummaryMethod = charSelectType.GetMethods(...)
                //     .FirstOrDefault(m => m.Name == "OpenCharacterSummaryPage");
                // if (openCharSummaryMethod != null && unconditionalSkip != null && PatchHarmonyPrefix(...)) { patched++; ... }

                // GetCharacterListingIndexFromCharId: returns -1 when entries are null.
                MethodInfo? getIndexMethod = charSelectType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .FirstOrDefault(m => m.Name == "GetCharacterListingIndexFromCharId");
                MethodInfo? getIndexPrefix = typeof(CustomServerMod).GetMethod(
                    nameof(GetCharacterListingIndexFromCharIdPrefix),
                    BindingFlags.Static | BindingFlags.NonPublic);
                if (getIndexMethod != null && getIndexPrefix != null && PatchHarmonyPrefix(getIndexMethod, getIndexPrefix))
                {
                    patched++;
                }

                MethodInfo? updateDataGuardPrefix = typeof(CustomServerMod).GetMethod(
                    nameof(CharacterPageUpdateDataGuardPrefix),
                    BindingFlags.Static | BindingFlags.NonPublic);
                if (updateDataGuardPrefix != null)
                {
                    foreach (string methodName in new[] { "Initialise", "UpdateData" })
                    {
                        foreach (MethodInfo target in charSelectType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                                     .Where(m => m.Name == methodName))
                        {
                            if (PatchHarmonyPrefix(target, updateDataGuardPrefix))
                            {
                                patched++;
                            }
                        }
                    }
                }

                MethodInfo? availableGuardPrefix = typeof(CustomServerMod).GetMethod(
                    nameof(CharacterPageAvailableGuardPrefix),
                    BindingFlags.Static | BindingFlags.NonPublic);
                if (availableGuardPrefix != null)
                {
                    foreach (MethodInfo target in charSelectType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                                 .Where(m => m.Name == "UpdateAvailableCharactersData"))
                    {
                        if (PatchHarmonyPrefix(target, availableGuardPrefix))
                        {
                            patched++;
                        }
                    }
                }

                MethodInfo? buttonStateGuardPrefix = typeof(CustomServerMod).GetMethod(
                    nameof(CharacterPageButtonStateGuardPrefix),
                    BindingFlags.Static | BindingFlags.NonPublic);
                if (buttonStateGuardPrefix != null)
                {
                    foreach (MethodInfo target in charSelectType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                                 .Where(m => m.Name == "SetCharacterButtonState"))
                    {
                        if (PatchHarmonyPrefix(target, buttonStateGuardPrefix))
                        {
                            patched++;
                        }
                    }
                }
            }

            // Also patch UILobbyCharacterCustomizePage.UpdateTabNotification only.
            // Do NOT touch UpdateData; it sets data the rest of the lobby relies on.
            // It calls TrySetSelectedCharMasteryButtonNotification during partial lobby init,
            // which logs noisy NullRefs on custom-server Medusa rosters. Skipping only the
            // notification badge update leaves match character selection intact.
            if (charCustomizeType != null)
            {
                MethodInfo? quietSkip = typeof(CustomServerMod).GetMethod(
                    nameof(QuietSkipPrefix),
                    BindingFlags.Static | BindingFlags.NonPublic);
                MethodInfo? finalizerMethod = typeof(CustomServerMod).GetMethod(
                    nameof(CustomServerNullRefFinalizer),
                    BindingFlags.Static | BindingFlags.NonPublic);

                foreach (MethodInfo updateTabNotification in charCustomizeType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                             .Where(m => m.Name == "UpdateTabNotification"))
                {
                    if (quietSkip != null && PatchHarmonyPrefix(updateTabNotification, quietSkip))
                    {
                        patched++;
                    }

                    if (finalizerMethod != null && PatchHarmonyFinalizer(updateTabNotification, finalizerMethod))
                    {
                        patched++;
                    }
                }
            }

            if (matchCharSelectType != null)
            {
                string[] matchMethods = {
                    "UpdateData", "UpdateAvailableCharactersData",
                    "SetPlayTabData", "UpdateLocalPlayer", "UpdateCharacterIconButtonsState",
                    "UpdateLockButtonState", "UpdateEquipButtonState", "UpdateGameModifiers",
                    "UpdateDimensions", "SetCountdownSeconds", "UpdateMatchStartData",
                    "UpdateMatchmakingCharacter", "UpdateMatchmakingLockedStatus",
                    "UpdateMatchmakingSpawnSelected", "UpdateMatchmakingFinalSpawnPoints",
                    "UpdateMatchmakingTransitionToSpawnSelect"
                };
                MethodInfo? matchPrefix = typeof(CustomServerMod).GetMethod(
                    nameof(MatchCharacterSelectPrefix),
                    BindingFlags.Static | BindingFlags.NonPublic);
                // DISABLED to allow char pick: in-match char select prefix-skip patches
                // were preventing the in-match character select page from running its
                // body, which caused char select to be instantly skipped. Now that
                // UICharactersConfiguration crash is fixed, the in-match char select
                // can run normally; the CustomServerNullRefFinalizer below still catches
                // any residual NullRef without skipping the body.
                if (false && matchPrefix != null)
                {
                    foreach (string methodName in matchMethods)
                    {
                        MethodInfo? target = matchCharSelectType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                            .FirstOrDefault(m => m.Name == methodName);
                        // DISABLED to allow char pick: if (target != null && PatchHarmonyPrefix(target, matchPrefix))
                        if (false && target != null && PatchHarmonyPrefix(target, matchPrefix))
                        {
                            patched++;
                        }
                    }
                }

                // Install finalizer on the same matchMethods so any residual NullRef
                // is swallowed AFTER the method body runs (rather than skipping it).
                MethodInfo? matchFinalizer = typeof(CustomServerMod).GetMethod(
                    nameof(CustomServerNullRefFinalizer),
                    BindingFlags.Static | BindingFlags.NonPublic);
                if (matchFinalizer != null)
                {
                    foreach (string methodName in matchMethods)
                    {
                        foreach (MethodInfo target in matchCharSelectType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                                     .Where(m => m.Name == methodName))
                        {
                            if (PatchHarmonyFinalizer(target, matchFinalizer))
                            {
                                patched++;
                            }
                        }
                    }
                }

                MethodInfo? charChangeAnimPrefix = typeof(CustomServerMod).GetMethod(
                    nameof(PlayPlayerCharChangeAnimPrefix),
                    BindingFlags.Static | BindingFlags.NonPublic);
                MethodInfo? charChangeAnimFinalizer = typeof(CustomServerMod).GetMethod(
                    nameof(CustomServerNullRefFinalizer),
                    BindingFlags.Static | BindingFlags.NonPublic);
                foreach (MethodInfo target in matchCharSelectType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                             .Where(m => m.Name == "PlayPlayerCharChangeAnim"))
                {
                    // DISABLED to allow char pick: PlayPlayerCharChangeAnim prefix was
                    // unconditionally returning false, which suppressed the character
                    // change animation. The finalizer below still swallows any NullRef.
                    if (false && charChangeAnimPrefix != null && PatchHarmonyPrefix(target, charChangeAnimPrefix))
                    {
                        patched++;
                    }

                    if (charChangeAnimFinalizer != null && PatchHarmonyFinalizer(target, charChangeAnimFinalizer))
                    {
                        patched++;
                    }
                }
            }

            if (patched > 0)
            {
                _characterSelectPatchInstalled = true;
                LoggerInstance.Msg($"Installed {patched} character-select NullRef guard prefix patch(es).");
            }

            // Install PopulateCharIdsBeforeBuildPrefix on UILobbyCharacterSelectPage methods
            // that read _lobbyAvailableCharacterIds. Since finalizers on these methods work,
            // prefixes should too - unlike TryGetLobbyCharConfigByIndex which silently fails.
            if (charSelectType != null)
            {
                MethodInfo? populatePrefix = typeof(CustomServerMod).GetMethod(
                    nameof(PopulateCharIdsBeforeBuildPrefix),
                    BindingFlags.Static | BindingFlags.NonPublic);
                if (populatePrefix != null)
                {
                    string[] populateTargets = { "Build", "Initialise", "UpdateData", "UpdateAvailableCharactersData", "OpenCharSelectPanel" };
                    int populatePatched = 0;
                    foreach (string methodName in populateTargets)
                    {
                        foreach (MethodInfo target in charSelectType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                                     .Where(m => m.Name == methodName))
                        {
                            if (PatchHarmonyPrefix(target, populatePrefix))
                            {
                                populatePatched++;
                            }
                        }
                    }
                    if (populatePatched > 0)
                    {
                        LoggerInstance.Msg($"Installed {populatePatched} PopulateCharIdsBeforeBuild prefix(es) on UILobbyCharacterSelectPage.");
                    }
                }
            }

            // Also install on UILobbyPlayTabPage.Initialise/UpdateData/Build since it drives the char select
            if (playTabType != null)
            {
                MethodInfo? populatePrefix = typeof(CustomServerMod).GetMethod(
                    nameof(PopulateCharIdsBeforeBuildPrefix),
                    BindingFlags.Static | BindingFlags.NonPublic);
                if (populatePrefix != null)
                {
                    string[] populateTargets = { "Build", "Initialise", "UpdateData" };
                    int populatePatched = 0;
                    foreach (string methodName in populateTargets)
                    {
                        foreach (MethodInfo target in playTabType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                                     .Where(m => m.Name == methodName))
                        {
                            if (PatchHarmonyPrefix(target, populatePrefix))
                            {
                                populatePatched++;
                            }
                        }
                    }
                    if (populatePatched > 0)
                    {
                        LoggerInstance.Msg($"Installed {populatePatched} PopulateCharIdsBeforeBuild prefix(es) on UILobbyPlayTabPage.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            LoggerInstance.Warning($"CharacterSelectPage NullRef prefix patch failed: {ex.GetBaseException().Message}");
        }
    }

    private void TryInstallLobbyControllerGuardPatches()
    {
        if (_lobbyControllerGuardPatchesInstalled)
        {
            return;
        }

        Type? lobbyControllerType = FindType("BAPBAP.UI.LobbyController");
        if (lobbyControllerType == null)
        {
            return;
        }

        MethodInfo? finalizer = typeof(CustomServerMod).GetMethod(
            nameof(CustomServerNullRefFinalizer),
            BindingFlags.Static | BindingFlags.NonPublic);
        if (finalizer == null)
        {
            return;
        }

        try
        {
            int patched = 0;
            // Cover the entire lobby message-handling surface area; all of these have been observed
            // to throw NullReferenceException during lobby init when game data is partially populated.
            string[] lobbyControllerTargets = {
                "HandleLobbyJoinedMessage",
                "HandleJoinLobbySuccessMessage",
                "HandleLeaveLobbyMessage",
                "HandleLobbyUpdateMessage",
                "HandleCustomGameSettingsMessage",
                "HandleGameStartedMessage",
                "HandleStartCustomGameSuccessMessage",
                "HandlePlayerLeftMessage",
                "HandlePlayerJoinedMessage",
                "HandleUpdateGameModesMessage",
                "HandleUpdateMatchmakingMessage",
                "HandleQueueMatchedMessage",
                "HandlePlayerProfileUpdatedMessage",
            };

            foreach (string targetName in lobbyControllerTargets)
            {
                foreach (MethodInfo target in lobbyControllerType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                             .Where(m => m.Name == targetName))
                {
                    if (PatchHarmonyFinalizer(target, finalizer))
                    {
                        patched++;
                    }
                }
            }

            // Also blanket-cover UILobby.Initialise and UILobbyCharacterCustomizePage methods,
            // since most of the observed NullRefs originate further down in those chains.
            string[] uiTypeNames = {
                "BAPBAP.UI.UILobby",
                "BAPBAP.UI.UILobbyCharacterCustomizePage",
                "BAPBAP.UI.UILobbyMatchCharacterSelectPage",
                "BAPBAP.UI.UILobbyCharacterSelectPage",
                "BAPBAP.UI.UILobbyPlayTabPage",
                "BAPBAP.UI.UILobbyMastery",
                "BAPBAP.UI.UILobbyShopTabPage",
                "BAPBAP.UI.LobbyController",
            };

            string[] uiTargetMethodNames = {
                "Initialise",
                "Initialize",
                "UpdateData",
                "UpdateTabNotification",
                "TrySetSelectedCharMasteryButtonNotification",
                "PlayPlayerCharChangeAnim",
                "CharacterIsUnlocked",
                "GetCharacterListingIndexFromCharId",
                "SetCharacterButtonState",
                "UpdateCharacterIconButtonsState",
                "UpdateAvailableCharactersData",
                "UpdateLocalPlayer",
                "Build",
                "OnEnable",
                "Refresh",
                "RefreshState",
            };

            foreach (string typeName in uiTypeNames)
            {
                Type? uiType = FindType(typeName);
                if (uiType == null)
                {
                    continue;
                }

                foreach (string targetName in uiTargetMethodNames)
                {
                    foreach (MethodInfo target in uiType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                                 .Where(m => m.Name == targetName))
                    {
                        if (PatchHarmonyFinalizer(target, finalizer))
                        {
                            patched++;
                        }
                    }
                }
            }

            _lobbyControllerGuardPatchesInstalled = patched > 0;
            if (_lobbyControllerGuardPatchesInstalled)
            {
                LoggerInstance.Msg($"Installed {patched} LobbyController NullRef guard finalizer patch(es).");
            }
        }
        catch (Exception ex)
        {
            LoggerInstance.Warning($"LobbyController NullRef guard patch failed: {ex.GetBaseException().Message}");
        }
    }

    private void TryInstallCharacterUnlockPatches()
    {
        if (_characterUnlockPatchesInstalled)
        {
            return;
        }

        MethodInfo? prefix = typeof(CustomServerMod).GetMethod(
            nameof(CharacterIsUnlockedPrefix),
            BindingFlags.Static | BindingFlags.NonPublic);
        if (prefix == null)
        {
            return;
        }

        try
        {
            int patched = 0;
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                Type[] types;
                try
                {
                    types = assembly.GetTypes();
                }
                catch (ReflectionTypeLoadException ex)
                {
                    types = ex.Types.Where(t => t != null).Cast<Type>().ToArray();
                }
                catch
                {
                    continue;
                }

                foreach (Type type in types)
                {
                    foreach (MethodInfo method in type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
                    {
                        if (method.Name != "CharacterIsUnlocked" || method.ReturnType != typeof(bool))
                        {
                            continue;
                        }

                        ParameterInfo[] parameters = method.GetParameters();
                        if (parameters.Length != 1 || parameters[0].ParameterType != typeof(int))
                        {
                            continue;
                        }

                        if (PatchHarmonyPrefix(method, prefix))
                        {
                            patched++;
                        }
                    }
                }
            }

            _characterUnlockPatchesInstalled = patched > 0;
            if (_characterUnlockPatchesInstalled)
            {
                LoggerInstance.Msg($"Installed {patched} CharacterIsUnlocked force-unlock patch(es).");
            }
        }
        catch (Exception ex)
        {
            LoggerInstance.Warning($"Character unlock patch failed: {ex.GetBaseException().Message}");
        }
    }

    private bool _charConfigViaUiManagerLogged;
    private bool _charConfigDiagLogged;

    private static int[] GetClientCharacterIds()
    {
        int[]? cached = s_active?._lastAvailableCharacterIds;
        if (cached != null && cached.Length > 0)
        {
            return cached;
        }

        int count = IsMedusaClientModPresent() ? MedusaCharacterId + 1 : VanillaCharacterCount;
        return Enumerable.Range(0, count).ToArray();
    }

    private static bool IsMedusaClientModPresent()
    {
        try
        {
            string[] roots =
            {
                Environment.CurrentDirectory,
                AppContext.BaseDirectory
            };

            foreach (string root in roots)
            {
                if (string.IsNullOrWhiteSpace(root)) continue;
                if (File.Exists(Path.Combine(root, "Mods", "BAPBAP.Medusa.dll")))
                {
                    return true;
                }
            }
        }
        catch { }

        return false;
    }

    private void TryFixCharactersConfigurationCrash()
    {
        Type? charsConfigType = FindType("BAPBAP.UI.UICharactersConfiguration");
        if (charsConfigType == null)
        {
            return;
        }

        try
        {
            int[] allCharIds = GetClientCharacterIds();
            int updated = 0;

            // Strategy A: find via Resources.FindObjectsOfTypeAll (ScriptableObject)
            Array? configs = FindLoadedUnityObjects(charsConfigType);
            if (configs != null && configs.Length > 0)
            {
                foreach (object cfg in configs)
                {
                    if (cfg == null) continue;
                    PopulateCharIdsOnInstance(cfg, charsConfigType, allCharIds, ref updated);
                }
            }

            // Strategy B: find via UIManager.characterConfig field (MonoBehaviour in scene)
            if (updated == 0)
            {
                Type? uiManagerType = FindType("BAPBAP.UI.UIManager");
                if (uiManagerType != null)
                {
                    Array? managers = FindLoadedUnityObjects(uiManagerType);
                    if (!_charConfigDiagLogged && managers != null && managers.Length > 0)
                    {
                        _charConfigDiagLogged = true;
                        LoggerInstance.Msg($"[CharConfig] Found {managers.Length} UIManager instance(s). Searching for characterConfig field...");
                        var fields = uiManagerType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                        foreach (var f in fields)
                        {
                            if (f.Name.Contains("haracter", StringComparison.OrdinalIgnoreCase) || f.Name.Contains("config", StringComparison.OrdinalIgnoreCase))
                                LoggerInstance.Msg($"  UIManager field: {f.Name} ({f.FieldType.Name})");
                        }
                    }
                    if (managers != null)
                    {
                        FieldInfo? charConfigField = uiManagerType.GetField("characterConfig",
                            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                        if (charConfigField == null)
                        {
                            charConfigField = uiManagerType.GetField("_characterConfig",
                                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                        }
                        foreach (object mgr in managers)
                        {
                            if (mgr == null) continue;
                            object? cfg = charConfigField?.GetValue(mgr);
                            if (cfg != null)
                            {
                                PopulateCharIdsOnInstance(cfg, charsConfigType, allCharIds, ref updated);
                                if (!_charConfigViaUiManagerLogged)
                                {
                                    _charConfigViaUiManagerLogged = true;
                                    LoggerInstance.Msg("[CharConfig] Found UICharactersConfiguration via UIManager.characterConfig field.");
                                }
                            }
                        }
                    }
                }
            }

            // Strategy C: find via UILobbyCharacterSelectPage fields
            if (updated == 0)
            {
                Type? charSelectType = FindType("BAPBAP.UI.UILobbyCharacterSelectPage");
                if (charSelectType != null)
                {
                    Array? pages = FindLoadedUnityObjects(charSelectType);
                    if (pages != null)
                    {
                        foreach (object page in pages)
                        {
                            if (page == null) continue;
                            foreach (FieldInfo fi in charSelectType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
                            {
                                if (fi.FieldType == charsConfigType || fi.FieldType.IsAssignableFrom(charsConfigType) || charsConfigType.IsAssignableFrom(fi.FieldType))
                                {
                                    try
                                    {
                                        object? cfg = fi.GetValue(page);
                                        if (cfg != null)
                                        {
                                            PopulateCharIdsOnInstance(cfg, charsConfigType, allCharIds, ref updated);
                                        }
                                    }
                                    catch { }
                                }
                            }
                        }
                    }
                }
            }

            // Strategy D: Use Il2Cpp generic FindObjectsOfType<UICharactersConfiguration> via Object.FindObjectsOfType(Type, bool)
            if (updated == 0)
            {
                try
                {
                    // Try Resources.FindObjectsOfTypeAll with the Il2Cpp system type
                    var il2cppType = charsConfigType.GetProperty("Il2CppType", BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
                    if (il2cppType != null)
                    {
                        object? sysType = il2cppType.GetValue(null);
                        if (sysType != null)
                        {
                            // Resources.FindObjectsOfTypeAll(Il2CppSystem.Type)
                            MethodInfo? findAll = typeof(Resources).GetMethod("FindObjectsOfTypeAll",
                                new[] { sysType.GetType() });
                            if (findAll != null)
                            {
                                var result = findAll.Invoke(null, new[] { sysType }) as Array;
                                if (result != null && result.Length > 0)
                                {
                                    foreach (object cfg in result)
                                    {
                                        if (cfg == null) continue;
                                        PopulateCharIdsOnInstance(cfg, charsConfigType, allCharIds, ref updated);
                                    }
                                    if (updated > 0)
                                        LoggerInstance.Msg($"[CharConfig] Strategy D (Il2CppType) found {result.Length} config(s).");
                                }
                            }
                        }
                    }
                }
                catch { }
            }

            if (updated > 0 && !_charConfigPreloadDone)
            {
                _charConfigPreloadDone = true;
                LoggerInstance.Msg($"_lobbyAvailableCharacterIds populated on {updated} configurations (charIds [{string.Join(",", allCharIds)}]).");
            }
        }
        catch (Exception ex)
        {
            LoggerInstance.Warning($"TryFixCharactersConfigurationCrash failed: {ex.GetBaseException().Message}");
        }
    }

    private static bool _populateCharIdsDiagLogged;

    private static object? CreateIl2CppArray(Type fieldType, int[] managedArray)
    {
        // Strategy 1: Constructor that takes int[] directly (Il2CppStructArray<int>(int[]))
        var ctorIntArr = fieldType.GetConstructor(new[] { typeof(int[]) });
        if (ctorIntArr != null)
        {
            return ctorIntArr.Invoke(new object[] { managedArray });
        }

        // Strategy 2: Constructor that takes long (size), then fill via indexer
        var ctorLong = fieldType.GetConstructor(new[] { typeof(long) });
        if (ctorLong != null)
        {
            object arr = ctorLong.Invoke(new object[] { (long)managedArray.Length });
            // Try indexer set via reflection
            var indexer = fieldType.GetProperty("Item") ?? fieldType.GetProperties()
                .FirstOrDefault(p => p.GetIndexParameters().Length == 1);
            if (indexer != null)
            {
                for (int i = 0; i < managedArray.Length; i++)
                    indexer.SetValue(arr, managedArray[i], new object[] { i });
            }
            return arr;
        }

        // Strategy 3: Constructor that takes int (size), then fill
        var ctorInt = fieldType.GetConstructor(new[] { typeof(int) });
        if (ctorInt != null)
        {
            object arr = ctorInt.Invoke(new object[] { managedArray.Length });
            var indexer = fieldType.GetProperty("Item") ?? fieldType.GetProperties()
                .FirstOrDefault(p => p.GetIndexParameters().Length == 1);
            if (indexer != null)
            {
                for (int i = 0; i < managedArray.Length; i++)
                    indexer.SetValue(arr, managedArray[i], new object[] { i });
            }
            return arr;
        }

        // Strategy 4: Activator fallback with explicit single-element object array
        try { return Activator.CreateInstance(fieldType, managedArray); }
        catch { }
        try { return Activator.CreateInstance(fieldType, new object[] { (long)managedArray.Length }); }
        catch { }

        return null;
    }

    private static void PopulateCharIdsOnInstance(object cfg, Type charsConfigType, int[] allCharIds, ref int updated)
    {
        FieldInfo? lobbyIdsField = charsConfigType.GetField(
            "_lobbyAvailableCharacterIds",
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        if (lobbyIdsField == null) return;

        try
        {
            Type fieldType = lobbyIdsField.FieldType;

            // Log field type once for diagnostics
            if (!_populateCharIdsDiagLogged)
            {
                _populateCharIdsDiagLogged = true;
                s_active?.LoggerInstance.Msg($"[CharConfig] _lobbyAvailableCharacterIds field type: {fieldType.FullName} (IsArray={fieldType.IsArray}, BaseType={fieldType.BaseType?.FullName})");
                var ctors = fieldType.GetConstructors();
                foreach (var c in ctors)
                {
                    var ps = c.GetParameters();
                    s_active?.LoggerInstance.Msg($"  ctor({string.Join(", ", ps.Select(p => p.ParameterType.Name))})");
                }
            }

            object? newValue;
            if (fieldType == typeof(int[]) || fieldType.IsAssignableFrom(typeof(int[])))
            {
                newValue = allCharIds;
            }
            else
            {
                newValue = CreateIl2CppArray(fieldType, allCharIds);
                if (newValue == null)
                {
                    s_active?.LoggerInstance.Warning($"[CharConfig] Failed to create IL2CPP array of type {fieldType.FullName}. Falling back to managed int[].");
                    newValue = allCharIds;
                }
            }

            lobbyIdsField.SetValue(cfg, newValue);
            updated++;
        }
        catch (Exception innerEx)
        {
            s_active?.LoggerInstance.Warning($"Could not set _lobbyAvailableCharacterIds: {innerEx.GetBaseException().Message}");
        }

        // Also try invoking UpdateAvailableCharacterList if it exists
        MethodInfo? updateMethod = charsConfigType.GetMethod(
            "UpdateAvailableCharacterList",
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        if (updateMethod != null)
        {
            try
            {
                ParameterInfo[]? parms = updateMethod.GetParameters();
                if (parms != null && parms.Length == 1)
                {
                    Type pType = parms[0].ParameterType;
                    object? arg;
                    if (pType == typeof(int[]) || pType.IsAssignableFrom(typeof(int[])))
                        arg = allCharIds;
                    else
                        arg = CreateIl2CppArray(pType, allCharIds) ?? allCharIds;
                    updateMethod.Invoke(cfg, new[] { arg });
                }
                else if (parms == null || parms.Length == 0)
                {
                    updateMethod.Invoke(cfg, Array.Empty<object>());
                }
            }
            catch { }
        }
    }

    /// <summary>
    /// Patches UnityEngine.Application.Quit (all overloads) to block the game from
    /// self-quitting during the lobby startup phase. The game calls Application.Quit()
    /// when UILobby.Build encounters a fatal state (e.g. no characters available),
    /// but on a custom server this is a transient condition that resolves once the
    /// lobby data arrives. The guard expires after 120 seconds to allow intentional quits.
    /// Patched method: UnityEngine.Application.Quit (0-arg and 1-arg overloads).
    /// </summary>
    private void TryInstallLifecycleGuardPatches()
    {
        if (_lifecycleGuardPatchesInstalled) return;

        try
        {
            Type? appType = typeof(Application);
            if (appType == null) return;

            MethodInfo? prefix = typeof(CustomServerMod).GetMethod(
                nameof(ApplicationQuitGuardPrefix),
                BindingFlags.Static | BindingFlags.NonPublic);
            if (prefix == null) return;

            int patched = 0;
            foreach (MethodInfo quitMethod in appType.GetMethods(BindingFlags.Static | BindingFlags.Public)
                         .Where(m => m.Name == "Quit"))
            {
                if (PatchHarmonyPrefix(quitMethod, prefix))
                    patched++;
            }

            if (patched > 0)
            {
                _lifecycleGuardPatchesInstalled = true;
                _quitGuardActive = true;
                _quitGuardExpireTime = float.MaxValue; // permanent guard against rogue Application.Quit()
                LoggerInstance.Msg($"Installed lifecycle guard on {patched} Application.Quit overload(s). Guard PERMANENT (custom servers).");
            }
        }
        catch (Exception ex)
        {
            LoggerInstance.Warning($"TryInstallLifecycleGuardPatches failed: {ex.GetBaseException().Message}");
        }
    }

    private static bool ApplicationQuitGuardPrefix()
    {
        // Allow quit if guard has expired (player intentionally quitting)
        if (!_quitGuardActive || Time.realtimeSinceStartup >= _quitGuardExpireTime)
        {
            _quitGuardActive = false;
            return true; // let original run
        }

        // Block the quit during lobby startup
        s_active?.LoggerInstance.Warning(
            $"BLOCKED Application.Quit() during lobby startup (guard expires in {_quitGuardExpireTime - Time.realtimeSinceStartup:F0}s). " +
            "The game tried to self-quit due to a lobby build error, but this is suppressed on custom servers.");
        return false; // skip original
    }

    private void TryInstallUICharactersConfigPatch()
    {
        if (_uiCharsConfigPatchInstalled) return;

        Type? cfgType = FindType("BAPBAP.UI.UICharactersConfiguration");
        if (cfgType == null) return;

        try
        {
            MethodInfo? tryGet = cfgType.GetMethod(
                "TryGetLobbyCharConfigByIndex",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            MethodInfo? prefix = typeof(CustomServerMod).GetMethod(
                nameof(EnsureLobbyCharIdsPrefix),
                BindingFlags.Static | BindingFlags.NonPublic);
            if (tryGet != null && prefix != null && PatchHarmonyPrefix(tryGet, prefix))
            {
                LoggerInstance.Msg("Installed prefix on UICharactersConfiguration.TryGetLobbyCharConfigByIndex (right-panel-render fix).");
            }

            MethodInfo? availIdsGetter = cfgType.GetProperty("AvailableCharacterIds")?.GetGetMethod();
            MethodInfo? availIdsPrefix = typeof(CustomServerMod).GetMethod(
                nameof(EnsureLobbyCharIdsPrefix),
                BindingFlags.Static | BindingFlags.NonPublic);
            if (availIdsGetter != null && availIdsPrefix != null)
            {
                PatchHarmonyPrefix(availIdsGetter, availIdsPrefix);
                LoggerInstance.Msg("Installed prefix on UICharactersConfiguration.AvailableCharacterIds getter.");
            }

            // Hook UIManager.Awake before UILobby.Build runs. A postfix is too
            // late: the crash path is inside Awake -> UILobby.Build.
            Type? uiManagerType = FindType("BAPBAP.UI.UIManager");
            if (uiManagerType != null)
            {
                MethodInfo? awakeMethod = uiManagerType.GetMethod("Awake",
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                MethodInfo? populatePrefix = typeof(CustomServerMod).GetMethod(
                    nameof(UIManagerAwakePrefix),
                    BindingFlags.Static | BindingFlags.NonPublic);
                if (awakeMethod != null && populatePrefix != null && PatchHarmonyPrefix(awakeMethod, populatePrefix))
                {
                    LoggerInstance.Msg("Installed prefix on UIManager.Awake for pre-build char config population.");
                }

                MethodInfo? populatePostfix = typeof(CustomServerMod).GetMethod(
                    nameof(UIManagerAwakePostfix),
                    BindingFlags.Static | BindingFlags.NonPublic);
                if (awakeMethod != null && populatePostfix != null && PatchHarmonyPostfix(awakeMethod, populatePostfix))
                {
                    LoggerInstance.Msg("Installed postfix on UIManager.Awake for post-build char config verification.");
                }
            }

            _uiCharsConfigPatchInstalled = true;
        }
        catch (Exception ex)
        {
            LoggerInstance.Warning($"TryInstallUICharactersConfigPatch failed: {ex.GetBaseException().Message}");
        }
    }

    private static void UIManagerAwakePrefix(object __instance)
    {
        // This is the earliest reliable point where the UIManager instance can
        // expose its serialized UICharactersConfiguration reference. Populate it
        // before Awake enters UILobby.Build and opens the default character page.
        try
        {
            Type? charsConfigType = FindType("BAPBAP.UI.UICharactersConfiguration");
            if (charsConfigType == null) return;

            int[] allCharIds = GetClientCharacterIds();
            int updated = 0;

            if (__instance != null)
            {
                updated += PopulateCharIdsFromOwnerFields(__instance, charsConfigType, allCharIds, "UIManager.Awake prefix");
            }

            Array? configs = FindLoadedUnityObjects(charsConfigType);
            if (configs != null)
            {
                foreach (object cfg in configs)
                {
                    if (cfg == null) continue;
                    PopulateCharIdsOnInstance(cfg, charsConfigType, allCharIds, ref updated);
                }
            }

            if (updated > 0)
            {
                if (s_active != null)
                {
                    s_active._charConfigPreloadDone = true;
                }

                s_active?.LoggerInstance.Msg($"[UIManagerAwakePrefix] _lobbyAvailableCharacterIds populated on {updated} configuration reference(s).");
            }
        }
        catch (Exception ex)
        {
            s_active?.LoggerInstance.Warning($"[UIManagerAwakePrefix] Failed: {ex.GetBaseException().Message}");
        }
    }

    private static void UIManagerAwakePostfix()
    {
        // Safety verification after Awake. The real pre-build fix is the prefix above.
        try
        {
            Type? charsConfigType = FindType("BAPBAP.UI.UICharactersConfiguration");
            if (charsConfigType == null) return;

            Array? configs = FindLoadedUnityObjects(charsConfigType);
            if (configs == null || configs.Length == 0) return;

            int[] allCharIds = GetClientCharacterIds();
            int updated = 0;
            foreach (object cfg in configs)
            {
                if (cfg == null) continue;
                PopulateCharIdsOnInstance(cfg, charsConfigType, allCharIds, ref updated);
            }

            if (updated > 0)
            {
                if (s_active != null)
                {
                    s_active._charConfigPreloadDone = true;
                }

                s_active?.LoggerInstance.Msg($"[UIManagerAwakePostfix] _lobbyAvailableCharacterIds populated on {updated} configurations.");
            }
        }
        catch (Exception ex)
        {
            s_active?.LoggerInstance.Warning($"[UIManagerAwakePostfix] Failed: {ex.GetBaseException().Message}");
        }
    }

    private static int PopulateCharIdsFromOwnerFields(object owner, Type charsConfigType, int[] allCharIds, string reason)
    {
        int updated = 0;
        Type ownerType = owner.GetType();

        foreach (FieldInfo field in ownerType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
        {
            try
            {
                bool nameLooksRelevant =
                    field.Name.Contains("character", StringComparison.OrdinalIgnoreCase) ||
                    field.Name.Contains("char", StringComparison.OrdinalIgnoreCase) ||
                    field.Name.Contains("config", StringComparison.OrdinalIgnoreCase);
                bool typeLooksRelevant =
                    charsConfigType.IsAssignableFrom(field.FieldType) ||
                    string.Equals(field.FieldType.FullName, charsConfigType.FullName, StringComparison.Ordinal);

                if (!nameLooksRelevant && !typeLooksRelevant)
                {
                    continue;
                }

                object? value = field.GetValue(owner);
                if (value == null)
                {
                    continue;
                }

                Type valueType = value.GetType();
                if (!charsConfigType.IsAssignableFrom(valueType) &&
                    !string.Equals(valueType.FullName, charsConfigType.FullName, StringComparison.Ordinal))
                {
                    continue;
                }

                PopulateCharIdsOnInstance(value, charsConfigType, allCharIds, ref updated);
            }
            catch { }
        }

        if (updated > 0)
        {
            s_active?.LoggerInstance.Msg($"[{reason}] populated UICharactersConfiguration from {ownerType.FullName} fields. count={updated}");
        }

        return updated;
    }

    private static int _ensureLobbyCharIdsCallCount;
    private static int _ensureLobbyCharIdsFilledCount;

    private static void EnsureLobbyCharIdsPrefix(object __instance)
    {
        try
        {
            _ensureLobbyCharIdsCallCount++;
            if (__instance == null) return;
            Type t = __instance.GetType();
            FieldInfo? f = t.GetField("_lobbyAvailableCharacterIds",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (f == null) return;
            object? current = f.GetValue(__instance);
            bool needsFill = current == null;
            if (!needsFill && current is System.Collections.ICollection col && col.Count == 0)
            {
                needsFill = true;
            }
            // Also check Il2CppStructArray Length property via reflection
            if (!needsFill && current != null)
            {
                var lengthProp = current.GetType().GetProperty("Length");
                if (lengthProp != null)
                {
                    object? lenVal = lengthProp.GetValue(current);
                    if (lenVal is int len && len == 0) needsFill = true;
                }
            }
            if (!needsFill) return;

            int[] all = GetClientCharacterIds();
            try
            {
                if (f.FieldType == typeof(int[]) || f.FieldType.IsAssignableFrom(typeof(int[])))
                {
                    f.SetValue(__instance, all);
                    _ensureLobbyCharIdsFilledCount++;
                }
                else
                {
                    object? wrapped = CreateIl2CppArray(f.FieldType, all);
                    if (wrapped != null)
                    {
                        f.SetValue(__instance, wrapped);
                        _ensureLobbyCharIdsFilledCount++;
                    }
                }
            }
            catch { }
        }
        catch { }
    }

    /// <summary>
    /// Prefix installed on UILobbyCharacterSelectPage.Build / Initialise / UpdateData.
    /// Finds all live UICharactersConfiguration instances and populates _lobbyAvailableCharacterIds
    /// with the server/client character IDs so the right-panel character list renders.
    /// </summary>
    private static bool _populateCharIdsPrefixLogged;
    private static void PopulateCharIdsBeforeBuildPrefix()
    {
        try
        {
            Type? charsConfigType = FindType("BAPBAP.UI.UICharactersConfiguration");
            if (charsConfigType == null) return;

            Array? configs = FindLoadedUnityObjects(charsConfigType);
            if (configs == null || configs.Length == 0) return;

            int[] allCharIds = GetClientCharacterIds();
            int updated = 0;
            foreach (object cfg in configs)
            {
                if (cfg == null) continue;
                PopulateCharIdsOnInstance(cfg, charsConfigType, allCharIds, ref updated);
            }

            if (updated > 0 && !_populateCharIdsPrefixLogged)
            {
                _populateCharIdsPrefixLogged = true;
                s_active?.LoggerInstance.Msg($"[PopulateCharIdsBeforeBuildPrefix] Filled _lobbyAvailableCharacterIds on {updated} UICharactersConfiguration instance(s) before Build/Initialise.");
            }
        }
        catch { }
    }

    private void TryFetchServerPolicy()
    {
        if (_serverPolicyFetched)
        {
            return;
        }

        if (UnityEngine.Time.realtimeSinceStartup < _nextServerPolicyFetchAt)
        {
            return;
        }
        _nextServerPolicyFetchAt = UnityEngine.Time.realtimeSinceStartup + 5f;

        try
        {
            string url = BuildServerPolicyUrl();
            var req = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            req.Timeout = 2000;
            req.ReadWriteTimeout = 2000;
            req.Method = "GET";
            using var resp = (System.Net.HttpWebResponse)req.GetResponse();
            using var stream = resp.GetResponseStream();
            if (stream == null) { return; }
            using var reader = new System.IO.StreamReader(stream);
            string body = reader.ReadToEnd();

            // Minimal manual parse - avoid pulling in Json libs.
            string policy = ExtractJsonString(body, "matchmakingPolicy") ?? "Both";
            bool allowMm = ExtractJsonBool(body, "allowMatchmaking") ?? true;
            bool allowCm = ExtractJsonBool(body, "allowCustomMatch") ?? true;

            _serverMatchmakingPolicy = policy;
            _allowMatchmaking = allowMm;
            _allowCustomMatch = allowCm;
            _serverModdingOverlayTitle = ExtractJsonString(body, "moddingOverlayTitle") ?? "";
            _serverModdingOverlaySubtitle = ExtractJsonString(body, "moddingOverlaySubtitle") ?? "";
            _serverPolicyFetched = true;
            UpdateUguiOverlayText();

            LoggerInstance.Msg(
                $"Server match policy fetched: {policy} (matchmaking={(allowMm ? "allowed" : "blocked")}, custom={(allowCm ? "allowed" : "blocked")}). " +
                "When a path is blocked, the mod logs a clear error if the user tries to use it.");
        }
        catch (Exception ex)
        {
            LoggerInstance.Msg($"Could not fetch /api/server-config yet ({ex.GetBaseException().Message}). Will retry.");
        }
    }

    private string BuildServerPolicyUrl()
    {
        bool useLocalProxy = _localProxyEntry?.Value ?? true;
        if (useLocalProxy)
        {
            int port = _localPortEntry?.Value ?? DefaultLocalProxyPort;
            return $"http://127.0.0.1:{port}/api/server-config";
        }
        string host = _hostEntry?.Value ?? "127.0.0.1";
        int upPort = _serverPortEntry?.Value ?? 5198;
        bool https = _httpsEntry?.Value ?? false;
        string scheme = https ? "https" : "http";
        return $"{scheme}://{host}:{upPort}/api/server-config";
    }

    private static string? ExtractJsonString(string body, string key)
    {
        // naive: look for "key":"value"
        string needle = "\"" + key + "\":\"";
        int idx = body.IndexOf(needle, StringComparison.OrdinalIgnoreCase);
        if (idx < 0) return null;
        int start = idx + needle.Length;
        int end = body.IndexOf('"', start);
        if (end < 0) return null;
        return body.Substring(start, end - start);
    }

    private static bool? ExtractJsonBool(string body, string key)
    {
        string needle = "\"" + key + "\":";
        int idx = body.IndexOf(needle, StringComparison.OrdinalIgnoreCase);
        if (idx < 0) return null;
        int start = idx + needle.Length;
        // skip whitespace
        while (start < body.Length && char.IsWhiteSpace(body[start])) start++;
        if (body.Length - start >= 4 && body.Substring(start, 4).Equals("true", StringComparison.OrdinalIgnoreCase)) return true;
        if (body.Length - start >= 5 && body.Substring(start, 5).Equals("false", StringComparison.OrdinalIgnoreCase)) return false;
        return null;
    }

    private void TryInstallAnalyticsPatches()
    {
        if (_analyticsPatchesInstalled)
        {
            return;
        }

        Type? analyticsType = FindType("BAPBAP.Local.AnalyticsManager");
        if (analyticsType == null)
        {
            return;
        }

        MethodInfo? prefix = typeof(CustomServerMod).GetMethod(
            nameof(AnalyticsManagerSetupAnalyticsPrefix),
            BindingFlags.Static | BindingFlags.NonPublic);
        MethodInfo? setupAnalytics = analyticsType.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
            .FirstOrDefault(method =>
            {
                if (method.Name != "SetupAnalytics")
                {
                    return false;
                }

                ParameterInfo[] parameters = method.GetParameters();
                return parameters.Length == 3;
            });
        if (prefix == null || setupAnalytics == null)
        {
            return;
        }

        try
        {
            if (PatchHarmonyPrefix(setupAnalytics, prefix))
            {
                _analyticsPatchesInstalled = true;
                LoggerInstance.Msg("Installed AnalyticsManager custom-server no-op patch.");
            }
        }
        catch (Exception ex)
        {
            LoggerInstance.Warning($"AnalyticsManager custom-server patch was not installed: {ex.GetBaseException().Message}");
        }
    }

    private void TryInstallUnityWebRequestHeaderPatch()
    {
        if (_unityWebRequestHeaderPatchInstalled)
        {
            return;
        }

        Type? requestType = FindType("UnityEngine.Networking.UnityWebRequest");
        if (requestType == null)
        {
            return;
        }

        MethodInfo? headerPrefix = typeof(CustomServerMod).GetMethod(
            nameof(UnityWebRequestSetRequestHeaderPrefix),
            BindingFlags.Static | BindingFlags.NonPublic);
        MethodInfo? sendPrefix = typeof(CustomServerMod).GetMethod(
            nameof(UnityWebRequestSendWebRequestPrefix),
            BindingFlags.Static | BindingFlags.NonPublic);
        MethodInfo? setRequestHeader = requestType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .FirstOrDefault(method =>
            {
                if (method.Name != "SetRequestHeader")
                {
                    return false;
                }

                ParameterInfo[] parameters = method.GetParameters();
                return parameters.Length == 2 &&
                       parameters[0].ParameterType == typeof(string) &&
                       parameters[1].ParameterType == typeof(string);
            });
        MethodInfo? sendWebRequest = requestType.GetMethod(
            "SendWebRequest",
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
            binder: null,
            types: Type.EmptyTypes,
            modifiers: null);
        if ((headerPrefix == null || setRequestHeader == null) &&
            (sendPrefix == null || sendWebRequest == null))
        {
            return;
        }

        try
        {
            int patched = 0;
            if (headerPrefix != null && setRequestHeader != null && PatchHarmonyPrefix(setRequestHeader, headerPrefix))
            {
                patched++;
            }

            if (sendPrefix != null && sendWebRequest != null && PatchHarmonyPrefix(sendWebRequest, sendPrefix))
            {
                patched++;
            }

            if (patched > 0)
            {
                _unityWebRequestHeaderPatchInstalled = true;
                LoggerInstance.Msg($"Installed {patched} UnityWebRequest callback repair patch(es).");
            }
        }
        catch (Exception ex)
        {
            LoggerInstance.Warning($"UnityWebRequest empty-header repair patch was not installed: {ex.GetBaseException().Message}");
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

        Type? uiNetworkType = FindType("BAPBAP.UI.UINetwork");
        Type? gameNetworkManagerType = FindType("Il2CppBAPBAP.Network.GameNetworkManager") ?? FindType("Il2CppBAPBAP.Network.GameNetworkManager") ?? FindType("BAPBAP.Network.GameNetworkManager");
        if (uiNetworkType == null && gameNetworkManagerType == null)
        {
            SetNetworkRepairStatus("Waiting for dedicated network types. UINetwork=False GameNetworkManager=False", logRepeated: false);
            return;
        }

        if (_dedicatedNetworkStarted)
        {
            return;
        }

        float now = Time.realtimeSinceStartup;
        const int maxNetworkStartAttempts = 10;
        const float networkStartRetrySeconds = 3f;
        bool retryWindowOpen = now >= _nextDedicatedNetworkStartRetryAt;
        if ((_uiNetworkStartAttempted || _gameNetworkStartAttempted) && !retryWindowOpen)
        {
            SetNetworkRepairStatus(
                $"Dedicated network start retry pending. uiAttempts={_uiNetworkStartAttemptCount} managerAttempts={_gameNetworkStartAttemptCount} nextRetryIn={_nextDedicatedNetworkStartRetryAt - now:0.0}s",
                logRepeated: false);
            return;
        }

        int uiCount = 0;
        int managerCount = 0;
        bool attempted = false;
        string lastMode = "unknown";
        string lastActive = "unknown";

        if (uiNetworkType != null &&
            (_uiNetworkStartAttemptCount == 0 || retryWindowOpen) &&
            _uiNetworkStartAttemptCount < maxNetworkStartAttempts)
        {
            Array? uiNetworks = FindLoadedUnityObjects(uiNetworkType);
            uiCount = uiNetworks?.Length ?? 0;
            if (uiNetworks != null)
            {
                foreach (object uiNetwork in uiNetworks)
                {
                    object? manager = GetMemberValue(uiNetwork, "_gameNetManager");
                    if (manager == null)
                    {
                        continue;
                    }

                    try
                    {
                        InvokeInstance(uiNetwork, "OverrideDefaultConfig", "127.0.0.1", kcpPort, tcpPort, wsPort, false);
                        PatchGameNetworkManagerTransports(
                            manager,
                            "dedicated-ui-before-start",
                            wsPort,
                            kcpPort,
                            tcpPort,
                            logIfSeen: true);
                        _uiNetworkStartAttempted = true;
                        _uiNetworkStartAttemptCount++;
                        _nextDedicatedNetworkStartRetryAt = now + networkStartRetrySeconds;
                        InvokeInstance(uiNetwork, "StartServer");
                        attempted = true;
                        SetNetworkRepairStatus($"Requested dedicated server start through UINetwork. attempt={_uiNetworkStartAttemptCount}/{maxNetworkStartAttempts} ws={wsPort} kcp={kcpPort} tcp={tcpPort}", logRepeated: true);
                        break;
                    }
                    catch (Exception ex)
                    {
                        SetNetworkRepairStatus($"UINetwork dedicated start failed: {ex.GetBaseException().Message}", logRepeated: false);
                    }
                }
            }
        }

        if (gameNetworkManagerType != null &&
            (_gameNetworkStartAttemptCount == 0 || retryWindowOpen) &&
            _gameNetworkStartAttemptCount < maxNetworkStartAttempts)
        {
            foreach (object manager in FindGameNetworkManagers(gameNetworkManagerType))
            {
                managerCount++;
                try
                {
                    SetMemberValue(manager, "networkAddress", "127.0.0.1");

                    // OLD A3B0F0CD path: just PreAwake + StartServer. Belt-and-braces helpers
                    // (DumpAndForcePortFields, ForcePatchStaticServerConfig) caused port-conflict
                    // because they wrote on stale fields creating zombie transport state.
                    InvokeInstance(manager, "PreAwake", wsPort, kcpPort, tcpPort);
                    PatchGameNetworkManagerTransports(
                        manager,
                        "dedicated-manager-before-start",
                        wsPort,
                        kcpPort,
                        tcpPort,
                        logIfSeen: true);

                    object? active = InvokeInstance(manager, "IsActive");
                    object? mode = GetMemberValue(manager, "mode");
                    lastActive = active?.ToString() ?? "null";
                    lastMode = mode?.ToString() ?? "null";

                    if (active is bool isActive && isActive)
                    {
                        _dedicatedNetworkStarted = true;
                        _gameNetworkStartAttempted = true;
                        SetNetworkRepairStatus($"Dedicated GameNetworkManager is already active. mode={lastMode}", logRepeated: true);
                        return;
                    }

                    // Mark attempted BEFORE StartServer so an exception is logged once per throttled retry.
                    _gameNetworkStartAttempted = true;
                    _gameNetworkStartAttemptCount++;
                    _nextDedicatedNetworkStartRetryAt = now + networkStartRetrySeconds;

                    InvokeInstance(manager, "StartServer");
                    PatchGameNetworkManagerTransports(
                        manager,
                        "dedicated-manager-after-start",
                        wsPort,
                        kcpPort,
                        tcpPort,
                        logIfSeen: true);
                    attempted = true;
                    SetNetworkRepairStatus($"Requested dedicated server start through GameNetworkManager. attempt={_gameNetworkStartAttemptCount}/{maxNetworkStartAttempts} modeBefore={lastMode} activeBefore={lastActive}", logRepeated: true);

                    // Log if it actually went active
                    object? activeAfter = InvokeInstance(manager, "IsActive");
                    object? modeAfter = GetMemberValue(manager, "mode");
                    LoggerInstance.Msg($"[NetworkRepair] post-StartServer: mode={modeAfter ?? "null"} active={activeAfter ?? "null"}");

                    if (activeAfter is bool b && b)
                    {
                        _dedicatedNetworkStarted = true;
                    }
                    break;
                }
                catch (Exception ex)
                {
                    SetNetworkRepairStatus($"GameNetworkManager dedicated start failed: {ex.GetBaseException().Message}", logRepeated: false);
                }
            }
        }

        if (IsTcpPortOpen("127.0.0.1", wsPort, 100) || IsTcpPortOpen("127.0.0.1", tcpPort, 100))
        {
            _dedicatedNetworkStarted = true;
            SetNetworkRepairStatus($"Started dedicated game network. ws={wsPort} kcp={kcpPort} tcp={tcpPort}", logRepeated: true);
            return;
        }

        if (!attempted && !_uiNetworkStartAttempted && !_gameNetworkStartAttempted)
        {
            SetNetworkRepairStatus($"Waiting for dedicated network instances. UINetwork={uiCount} GameNetworkManager={managerCount}", logRepeated: false);
        }
        else
        {
            SetNetworkRepairStatus($"Dedicated network start is pending; TCP listeners are not open yet. ws={wsPort} tcp={tcpPort}", logRepeated: false);
        }
    }

    // ──────────────────────────────────────────────────────────────────────────
    // Autoplay logic (--bapcustom-autoplay dev flag)
    // ──────────────────────────────────────────────────────────────────────────

    private void RunAutoplayLogic()
    {
        if (Time.realtimeSinceStartup < _autoplayNextActionAt) return;
        _autoplayNextActionAt = Time.realtimeSinceStartup + 2f;

        try
        {
            switch (_autoplayState)
            {
                case 0: // Waiting for login to complete
                    if (_lastLoadResponse != null)
                    {
                        _autoplayState = 1;
                        _autoplayNextActionAt = Time.realtimeSinceStartup + 3f;
                        LoggerInstance.Msg("[Autoplay] Login complete, will join lobby in 3s.");
                    }
                    break;

                case 1: // Join lobby via WebSocket
                    if (TryAutoplayJoinLobby())
                    {
                        _autoplayState = 2;
                        _autoplayNextActionAt = Time.realtimeSinceStartup + 2f;
                        LoggerInstance.Msg("[Autoplay] Joined lobby, will set ready in 2s.");
                    }
                    break;

                case 2: // Set ready
                    if (TryAutoplaySetReady())
                    {
                        _autoplayState = 3;
                        _autoplayNextActionAt = Time.realtimeSinceStartup + 1f;
                        LoggerInstance.Msg("[Autoplay] Ready set. Waiting for match.");
                    }
                    break;

                case 3: // In match - detect and log
                    TryAutoplayDetectMatch();
                    _autoplayNextActionAt = Time.realtimeSinceStartup + 0.5f;
                    break;
            }
        }
        catch (Exception ex)
        {
            LoggerInstance.Warning($"[Autoplay] Error in state {_autoplayState}: {ex.GetBaseException().Message}");
            _autoplayNextActionAt = Time.realtimeSinceStartup + 5f;
        }
    }

    private bool TryAutoplayJoinLobby()
    {
        // Find LobbyNetworkClient to get the WebSocketClient instance
        Type? lobbyNetClientType = FindType("BAPBAP.Network.LobbyNetworkClient");
        if (lobbyNetClientType == null) return false;

        Array? lobbyClients = FindLoadedUnityObjects(lobbyNetClientType);
        if (lobbyClients == null || lobbyClients.Length == 0) return false;

        foreach (object lobbyClient in lobbyClients)
        {
            object? ctrlMgr = GetMemberValue(lobbyClient, "_controllerManager")
                            ?? GetMemberValue(lobbyClient, "controllerManager");

            object? wsClient = ctrlMgr != null
                ? (GetMemberValue(ctrlMgr, "Ws") ?? GetMemberValue(ctrlMgr, "_ws"))
                : null;
            wsClient ??= GetMemberValue(lobbyClient, "_webSocketClient")
                      ?? GetMemberValue(lobbyClient, "_wsClient");

            if (wsClient == null) continue;

            int selectedCharId = _requestedCharacterId.GetValueOrDefault(1);
            // Send JOIN_LOBBY via the WebSocketClient.Send(string) overload
            string joinJson = $"{{\"event\":\"JOIN_LOBBY\",\"payload\":{{\"lobbyId\":\"\",\"charId\":{selectedCharId},\"regionId\":\"custom\",\"gameModeId\":1,\"isAutoFill\":false}}}}";
            InvokeInstance(wsClient, "Send", joinJson);
            LoggerInstance.Msg($"[Autoplay] JOIN_LOBBY sent with charId={selectedCharId}.");
            return true;
        }

        return false;
    }

    private bool TryAutoplaySetReady()
    {
        Type? lobbyNetClientType = FindType("BAPBAP.Network.LobbyNetworkClient");
        if (lobbyNetClientType == null) return false;

        Array? lobbyClients = FindLoadedUnityObjects(lobbyNetClientType);
        if (lobbyClients == null || lobbyClients.Length == 0) return false;

        foreach (object lobbyClient in lobbyClients)
        {
            object? ctrlMgr = GetMemberValue(lobbyClient, "_controllerManager")
                            ?? GetMemberValue(lobbyClient, "controllerManager");

            object? wsClient = ctrlMgr != null
                ? (GetMemberValue(ctrlMgr, "Ws") ?? GetMemberValue(ctrlMgr, "_ws"))
                : null;
            wsClient ??= GetMemberValue(lobbyClient, "_webSocketClient")
                      ?? GetMemberValue(lobbyClient, "_wsClient");

            if (wsClient == null) continue;

            int selectedCharId = _requestedCharacterId.GetValueOrDefault(1);
            if (selectedCharId != 1)
            {
                string switchCharJson = $"{{\"event\":\"SWITCH_CHAR\",\"payload\":{{\"charId\":{selectedCharId}}}}}";
                InvokeInstance(wsClient, "Send", switchCharJson);
                LoggerInstance.Msg($"[Autoplay] SWITCH_CHAR sent before ready with charId={selectedCharId}.");
            }

            string readyJson = "{\"event\":\"SWITCH_CUSTOM_READY\",\"payload\":{\"isReady\":true}}";
            InvokeInstance(wsClient, "Send", readyJson);
            return true;
        }

        return false;
    }

    private void TryAutoplayDetectMatch()
    {
        if (_autoplayInMatch) return;

        // Check if a GameManager exists (indicates match has started)
        Type? gmType = FindType("BAPBAP.Game.GameManager");
        if (gmType == null) return;

        Array? gms = FindLoadedUnityObjects(gmType);
        if (gms != null && gms.Length > 0)
        {
            _autoplayInMatch = true;
            LoggerInstance.Msg("[Autoplay] GameManager detected - match is running!");
        }

        // Also detect via PlayerManager
        Type? playerMgrType = FindType("BAPBAP.Player.PlayerManager");
        if (playerMgrType == null) return;

        Array? players = FindLoadedUnityObjects(playerMgrType);
        if (players != null && players.Length > 0)
        {
            _autoplayInMatch = true;
            LoggerInstance.Msg("[Autoplay] Players detected - match is running!");
        }
    }

    private void TryAutoJoinMatch(string gameAuthId, string host, int wsPort, int kcpPort, int tcpPort)
    {
        Type? gameNetworkManagerType = FindType("Il2CppBAPBAP.Network.GameNetworkManager") ?? FindType("Il2CppBAPBAP.Network.GameNetworkManager") ?? FindType("BAPBAP.Network.GameNetworkManager");
        if (gameNetworkManagerType == null)
        {
            _statusText = "Waiting for GameNetworkManager before auto-join";
            return;
        }

        object? manager = FindGameNetworkManagers(gameNetworkManagerType).FirstOrDefault();
        if (manager == null)
        {
            _statusText = "Waiting for GameNetworkManager instance before auto-join";
            return;
        }

        try
        {
            PatchGameNetworkManagerTransports(
                manager,
                "client-autojoin-before-connect",
                wsPort,
                kcpPort,
                tcpPort,
                logIfSeen: true);
            InvokeInstance(manager, "ConnectMatchmaking", gameAuthId, host, wsPort, kcpPort, tcpPort);
            PatchGameNetworkManagerTransports(
                manager,
                "client-autojoin-after-connect",
                wsPort,
                kcpPort,
                tcpPort,
                logIfSeen: true);
            _autoJoinAttempted = true;
            _statusText = $"Auto-joining match {host}:{kcpPort}";
            LoggerInstance.Msg($"Requested matchmaking client connect. auth={gameAuthId} host={host} ws={wsPort} kcp={kcpPort} tcp={tcpPort}");
        }
        catch (Exception ex)
        {
            _statusText = $"Auto-join failed: {ex.GetBaseException().Message}";
            LoggerInstance.Warning(_statusText);
        }
    }

    private void DumpAndForcePortFields(object manager, int wsPort, int kcpPort, int tcpPort)
    {
        if (manager == null) return;
        try
        {
            Type t = manager.GetType();
            const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

            FieldInfo[] fields = t.GetFields(flags);
            int patched = 0;
            for (int i = 0; i < fields.Length; i++)
            {
                FieldInfo f = fields[i];
                string n = f.Name.ToLowerInvariant();
                int? targetPort = null;
                if (n.Contains("ws") && n.Contains("port")) targetPort = wsPort;
                else if (n.Contains("kcp") && n.Contains("port")) targetPort = kcpPort;
                else if (n.Contains("tcp") && n.Contains("port")) targetPort = tcpPort;
                else if (n == "listenport" || n == "_listenport" || n.Contains("listenport")) targetPort = tcpPort;
                else if (n.Contains("networkport")) targetPort = tcpPort;

                if (targetPort.HasValue && f.FieldType.IsValueType)
                {
                    try
                    {
                        object newVal = targetPort.Value;
                        if (f.FieldType == typeof(ushort)) newVal = (ushort)targetPort.Value;
                        else if (f.FieldType == typeof(short)) newVal = (short)targetPort.Value;
                        else if (f.FieldType == typeof(uint)) newVal = (uint)targetPort.Value;
                        else if (f.FieldType == typeof(long)) newVal = (long)targetPort.Value;
                        else if (f.FieldType == typeof(int)) newVal = targetPort.Value;
                        else continue;
                        f.SetValue(manager, newVal);
                        patched++;
                        LoggerInstance.Msg($"[ForcePort] {t.Name}.{f.Name} ({f.FieldType.Name}) = {targetPort.Value}");
                    }
                    catch (Exception ex)
                    {
                        LoggerInstance.Msg($"[ForcePort] failed {t.Name}.{f.Name}: {ex.Message}");
                    }
                }
            }
            LoggerInstance.Msg($"[ForcePort] Patched {patched}/{fields.Length} fields on {t.Name}");

            if (!_forcePortFieldsDumped)
            {
                _forcePortFieldsDumped = true;
                int max = Math.Min(40, fields.Length);
                string names = string.Join(", ", fields.Take(max).Select(x => x.Name));
                LoggerInstance.Msg($"[ForcePort] {t.Name} fields ({fields.Length}): {names}");
            }
        }
        catch (Exception ex)
        {
            LoggerInstance.Msg($"[ForcePort] DumpAndForcePortFields failed: {ex.Message}");
        }
    }

    private bool _forcePortFieldsDumped;
    private bool _serverConfigForcePatched;

    private void ForcePatchStaticServerConfig(Assembly hostAssembly, int listenPort)
    {
        // Re-assert every tick - cheap and defends against asset reload paths
        try
        {
            Type? networkConfigType = FindType("BAPBAP.Local.NetworkConfig") ?? FindType("BAPBAP.Network.NetworkConfig");
            if (networkConfigType == null)
            {
                foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
                {
                    Type[] types;
                    try { types = a.GetTypes(); } catch { continue; }
                    foreach (Type tt in types)
                    {
                        if (tt.Name == "NetworkConfig" || tt.Name == "Il2CppNetworkConfig")
                        {
                            networkConfigType = tt;
                            break;
                        }
                    }
                    if (networkConfigType != null) break;
                }
            }

            if (networkConfigType == null)
            {
                LoggerInstance.Msg("[ServerConfigForce] No NetworkConfig type found");
                _serverConfigForcePatched = true;
                return;
            }

            const BindingFlags flags = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
            object? serverConfig = null;
            PropertyInfo? serverProp = networkConfigType.GetProperty("Server", flags);
            if (serverProp != null) serverConfig = serverProp.GetValue(null);
            if (serverConfig == null)
            {
                FieldInfo? serverField = networkConfigType.GetField("Server", flags) ?? networkConfigType.GetField("_server", flags) ?? networkConfigType.GetField("s_server", flags);
                if (serverField != null) serverConfig = serverField.GetValue(null);
            }

            if (serverConfig == null)
            {
                LoggerInstance.Msg($"[ServerConfigForce] {networkConfigType.FullName} has no Server property/field");
                _serverConfigForcePatched = true;
                return;
            }

            Type sct = serverConfig.GetType();
            const BindingFlags ifl = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

            int patched = 0;
            FieldInfo? listenField = sct.GetField("ListenPort", ifl);
            if (listenField != null)
            {
                Type fieldType = listenField.FieldType;
                object newVal = listenPort;
                if (fieldType == typeof(ushort)) newVal = (ushort)listenPort;
                else if (fieldType == typeof(short)) newVal = (short)listenPort;
                listenField.SetValue(serverConfig, newVal);
                patched++;
                LoggerInstance.Msg($"[ServerConfigForce] ServerConfig.ListenPort = {listenPort}");
            }

            FieldInfo? mmHostField = sct.GetField("MatchmakingHost", ifl);
            if (mmHostField != null)
            {
                mmHostField.SetValue(serverConfig, "127.0.0.1");
                patched++;
                LoggerInstance.Msg($"[ServerConfigForce] ServerConfig.MatchmakingHost = 127.0.0.1");
            }

            FieldInfo? hsKey = sct.GetField("HeaderSecretKey", ifl);
            if (hsKey != null && string.IsNullOrWhiteSpace(hsKey.GetValue(serverConfig) as string))
            {
                hsKey.SetValue(serverConfig, DefaultSecretHeaderName);
                patched++;
            }

            FieldInfo? hs = sct.GetField("HeaderSecret", ifl);
            if (hs != null && string.IsNullOrWhiteSpace(hs.GetValue(serverConfig) as string))
            {
                hs.SetValue(serverConfig, DefaultSecretValue);
                patched++;
            }

            LoggerInstance.Msg($"[ServerConfigForce] Patched {patched} fields on {sct.FullName}");
            _serverConfigForcePatched = true;
        }
        catch (Exception ex)
        {
            LoggerInstance.Msg($"[ServerConfigForce] failed: {ex.Message}");
        }
    }


    private IEnumerable<object> FindGameNetworkManagers(Type gameNetworkManagerType)
    {
        Array? managers = FindLoadedUnityObjects(gameNetworkManagerType);
        if (managers != null)
        {
            foreach (object manager in managers)
            {
                if (manager != null && gameNetworkManagerType.IsInstanceOfType(manager))
                {
                    yield return manager;
                }
            }
        }

        const BindingFlags flags = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
        object? instance = gameNetworkManagerType.GetProperty("Instance", flags)?.GetValue(null) ??
                           gameNetworkManagerType.GetField("Instance", flags)?.GetValue(null);
        if (instance != null && gameNetworkManagerType.IsInstanceOfType(instance))
        {
            yield return instance;
        }
    }

    private int PatchGameNetworkManagerTransports(
        object? manager,
        string source,
        int? wsPort,
        int? kcpPort,
        int? tcpPort,
        bool logIfSeen)
    {
        if (manager == null)
        {
            return 0;
        }

        int patched = 0;
        object? kcp = GetMemberValueSafe(manager, "kcpTransport");
        object? ws = GetMemberValueSafe(manager, "wsTransport");
        object? tcp = GetMemberValueSafe(manager, "tcpTransport");
        object? multiplex = GetMemberValueSafe(manager, "multiplexTransport");

        if (kcp != null && PatchKcpTransportRuntime(kcp, kcpPort))
        {
            patched++;
        }

        if (ws != null && PatchTransportPortRuntime(ws, wsPort))
        {
            patched++;
        }

        if (tcp != null && PatchTransportPortRuntime(tcp, tcpPort))
        {
            patched++;
        }

        if (RaiseFloatMember(manager, "_reconnectTimeout", 60f))
        {
            patched++;
        }

        if (RaiseIntMember(manager, "_maxClientReconnectionAttempts", 5))
        {
            patched++;
        }

        if ((logIfSeen || !_kcpTransportRuntimeLogged) && (kcp != null || ws != null || tcp != null || multiplex != null))
        {
            _kcpTransportRuntimeLogged = true;
            LoggerInstance.Msg(
                $"[KcpRuntime] {source}: manager={manager.GetType().FullName} " +
                $"ws={DescribeTransportRuntime(ws)} kcp={DescribeTransportRuntime(kcp)} tcp={DescribeTransportRuntime(tcp)} " +
                $"multiplex={DescribeTransportRuntime(multiplex)} patched={patched}.");
        }

        return patched;
    }

    private int PatchGameNetworkManagerTransports(
        Type? gameNetworkManagerType,
        string source,
        int? wsPort,
        int? kcpPort,
        int? tcpPort,
        bool logIfSeen)
    {
        gameNetworkManagerType ??= FindType("Il2CppBAPBAP.Network.GameNetworkManager") ??
                                  FindType("BAPBAP.Network.GameNetworkManager");
        if (gameNetworkManagerType == null)
        {
            return 0;
        }

        int patched = 0;
        foreach (object manager in FindGameNetworkManagers(gameNetworkManagerType))
        {
            patched += PatchGameNetworkManagerTransports(manager, source, wsPort, kcpPort, tcpPort, logIfSeen);
        }

        return patched;
    }

    private static bool PatchKcpTransportRuntime(object transport, int? port)
    {
        bool patched = false;

        if (port is > 0 and <= ushort.MaxValue)
        {
            ushort portValue = (ushort)port.Value;
            patched |= SetMemberValueBestEffort(transport, "port", portValue);
            patched |= SetMemberValueBestEffort(transport, "Port", portValue);
        }

        patched |= SetMemberValueBestEffort(transport, "Timeout", KcpTransportTimeoutMillis);
        patched |= SetMemberValueBestEffort(transport, "NoDelay", true);
        patched |= SetMemberValueBestEffort(transport, "Interval", (uint)10);
        patched |= SetMemberValueBestEffort(transport, "FastResend", 2);
        patched |= SetMemberValueBestEffort(transport, "CongestionWindow", false);
        patched |= SetMemberValueBestEffort(transport, "ReceiveWindowSize", (uint)4096);
        patched |= SetMemberValueBestEffort(transport, "SendWindowSize", (uint)4096);

        object? config = GetMemberValueSafe(transport, "config");
        if (config != null)
        {
            patched |= SetMemberValueBestEffort(config, "Timeout", KcpTransportTimeoutMillis);
            patched |= SetMemberValueBestEffort(config, "NoDelay", true);
            patched |= SetMemberValueBestEffort(config, "Interval", (uint)10);
            patched |= SetMemberValueBestEffort(config, "FastResend", 2);
            patched |= SetMemberValueBestEffort(config, "CongestionWindow", false);
            patched |= SetMemberValueBestEffort(config, "ReceiveWindowSize", (uint)4096);
            patched |= SetMemberValueBestEffort(config, "SendWindowSize", (uint)4096);
        }

        return patched;
    }

    private static bool PatchTransportPortRuntime(object transport, int? port)
    {
        if (port is not > 0 or > ushort.MaxValue)
        {
            return false;
        }

        ushort portValue = (ushort)port.Value;
        bool patched = SetMemberValueBestEffort(transport, "port", portValue);
        patched |= SetMemberValueBestEffort(transport, "Port", portValue);
        return patched;
    }

    private static string DescribeTransportRuntime(object? transport)
    {
        if (transport == null)
        {
            return "null";
        }

        return $"{transport.GetType().FullName} " +
               $"port={GetMemberValueSafe(transport, "port") ?? GetMemberValueSafe(transport, "Port") ?? "null"} " +
               $"timeout={GetMemberValueSafe(transport, "Timeout") ?? "null"} " +
               $"client={(GetMemberValueSafe(transport, "client") != null)} " +
               $"server={(GetMemberValueSafe(transport, "server") != null)}";
    }

    private void SetNetworkRepairStatus(string status, bool logRepeated)
    {
        _statusText = status;
        if (logRepeated || !string.Equals(_lastNetworkRepairStatus, status, StringComparison.Ordinal))
        {
            _lastNetworkRepairStatus = status;
            LoggerInstance.Msg(status);
        }
    }

    private void EnsureManagedBootstrapListener(int httpPort)
    {
        if (_bootstrapListener?.Server?.IsBound == true)
        {
            return;
        }

        try
        {
            StopManagedBootstrapListener();

            TcpListener listener = new(IPAddress.Loopback, httpPort);
            listener.Start();

            CancellationTokenSource cts = new();
            _bootstrapListener = listener;
            _bootstrapListenerCts = cts;
            // Ensure pending Accept calls unblock when the token is cancelled.
            cts.Token.Register(() =>
            {
                try { listener.Stop(); } catch { /* best effort */ }
            });
            _bootstrapListenerTask = Task.Run(() => RunManagedBootstrapListenerAsync(listener, cts.Token));

            SetBootstrapRepairStatus($"Managed match bootstrap listener is active.", logRepeated: true);
        }
        catch (Exception ex)
        {
            SetBootstrapRepairStatus($"Managed match bootstrap listener failed: {ex.GetBaseException().Message}", logRepeated: false);
        }
    }

    private async Task RunManagedBootstrapListenerAsync(TcpListener listener, CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            TcpClient client;
            try
            {
                client = await listener.AcceptTcpClientAsync().ConfigureAwait(false);
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
            catch (Exception ex)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    break;
                }

                LoggerInstance.Warning($"Managed bootstrap listener accept failed: {ex.GetBaseException().Message}");
                continue;
            }

            _ = Task.Run(() => HandleBootstrapTcpClientAsync(client), cancellationToken);
        }
    }

    private async Task HandleBootstrapTcpClientAsync(TcpClient client)
    {
        string path = "/";
        try
        {
            client.NoDelay = true;
            using NetworkStream stream = client.GetStream();

            // Read the request bytes until we have all headers (CRLFCRLF) and the full body.
            byte[] buffer = new byte[8192];
            using MemoryStream pending = new();
            int headerEnd = -1;
            int contentLength = 0;
            bool headersParsed = false;
            string method = "";

            while (true)
            {
                int read = await stream.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false);
                if (read <= 0)
                {
                    break;
                }

                pending.Write(buffer, 0, read);

                if (!headersParsed)
                {
                    byte[] data = pending.GetBuffer();
                    int len = (int)pending.Length;
                    for (int i = 0; i + 3 < len; i++)
                    {
                        if (data[i] == 0x0D && data[i + 1] == 0x0A && data[i + 2] == 0x0D && data[i + 3] == 0x0A)
                        {
                            headerEnd = i + 4;
                            break;
                        }
                    }

                    if (headerEnd < 0)
                    {
                        // Need more bytes for headers.
                        if (pending.Length > 64 * 1024)
                        {
                            // Headers too large; reject.
                            await WriteBootstrapTcpResponseAsync(stream, 400, "Bad Request", "{\"ok\":false}").ConfigureAwait(false);
                            return;
                        }
                        continue;
                    }

                    string headerText = Encoding.ASCII.GetString(data, 0, headerEnd);
                    string[] lines = headerText.Split(new[] { "\r\n" }, StringSplitOptions.None);
                    if (lines.Length == 0 || string.IsNullOrEmpty(lines[0]))
                    {
                        await WriteBootstrapTcpResponseAsync(stream, 400, "Bad Request", "{\"ok\":false}").ConfigureAwait(false);
                        return;
                    }

                    string[] requestLine = lines[0].Split(' ');
                    if (requestLine.Length < 3)
                    {
                        await WriteBootstrapTcpResponseAsync(stream, 400, "Bad Request", "{\"ok\":false}").ConfigureAwait(false);
                        return;
                    }

                    method = requestLine[0];
                    string rawPath = requestLine[1];
                    int queryIndex = rawPath.IndexOf('?');
                    if (queryIndex >= 0)
                    {
                        rawPath = rawPath.Substring(0, queryIndex);
                    }
                    path = rawPath.TrimEnd('/').ToLowerInvariant();
                    if (string.IsNullOrWhiteSpace(path))
                    {
                        path = "/";
                    }

                    for (int i = 1; i < lines.Length; i++)
                    {
                        string line = lines[i];
                        if (string.IsNullOrEmpty(line))
                        {
                            continue;
                        }
                        int colon = line.IndexOf(':');
                        if (colon <= 0)
                        {
                            continue;
                        }
                        string name = line.Substring(0, colon).Trim();
                        string value = line.Substring(colon + 1).Trim();
                        if (string.Equals(name, "Content-Length", StringComparison.OrdinalIgnoreCase))
                        {
                            int.TryParse(value, out contentLength);
                        }
                    }

                    headersParsed = true;
                }

                if (headersParsed)
                {
                    long bodySoFar = pending.Length - headerEnd;
                    if (bodySoFar >= contentLength)
                    {
                        break;
                    }
                }
            }

            if (!headersParsed)
            {
                // Connection closed before headers arrived.
                return;
            }

            if (string.Equals(method, "GET", StringComparison.OrdinalIgnoreCase) &&
                path == "/status")
            {
                await WriteBootstrapTcpResponseAsync(stream, 200, "OK", BuildManagedBootstrapStatusJson()).ConfigureAwait(false);
                return;
            }

            if (!string.Equals(method, "POST", StringComparison.OrdinalIgnoreCase) ||
                (path != "/setup-game" && path != "/add-teams" && path != "/queue-matched"))
            {
                await WriteBootstrapTcpResponseAsync(stream, 404, "Not Found", "{\"ok\":false}").ConfigureAwait(false);
                return;
            }

            string json = "";
            if (contentLength > 0)
            {
                byte[] data = pending.GetBuffer();
                int available = (int)Math.Min(contentLength, pending.Length - headerEnd);
                json = Encoding.UTF8.GetString(data, headerEnd, available);
            }

            _pendingBootstrapPayloads.Enqueue(new BootstrapPayload(path, json));

            await WriteBootstrapTcpResponseAsync(stream, 200, "OK", "{\"ok\":true}").ConfigureAwait(false);
            LoggerInstance.Msg("Queued managed match bootstrap payload: " + path);
        }
        catch (Exception ex)
        {
            LoggerInstance.Warning($"Managed bootstrap request failed: {ex.GetBaseException().Message}");
            try
            {
                NetworkStream stream = client.GetStream();
                await WriteBootstrapTcpResponseAsync(stream, 500, "Internal Server Error", "{\"ok\":false}").ConfigureAwait(false);
            }
            catch
            {
                // The caller may already have disconnected.
            }
        }
        finally
        {
            try { client.Close(); } catch { /* best effort */ }
        }
    }

    private string BuildManagedBootstrapStatusJson()
    {
        try
        {
            return JsonSerializer.Serialize(new
            {
                ok = true,
                dedicatedProcess = _dedicatedProcess,
                networkStarted = _dedicatedNetworkStarted,
                setupGameApplied = _setupGameApplied,
                addTeamsApplied = _addTeamsApplied,
                queueMatchedApplied = _queueMatchedApplied,
                bootstrapRepairComplete = _bootstrapRepairComplete,
                lastStatus = _lastBootstrapRepairStatus,
                httpPort = _dedicatedHttpPort,
                wsPort = _dedicatedWsPort,
                kcpPort = _dedicatedKcpPort,
                tcpPort = _dedicatedTcpPort,
                realtime = Time.realtimeSinceStartup
            });
        }
        catch (Exception ex)
        {
            return "{\"ok\":false,\"error\":\"" + EscapeJsonString(ex.GetBaseException().Message) + "\"}";
        }
    }

    private static string EscapeJsonString(string value)
    {
        return value
            .Replace("\\", "\\\\", StringComparison.Ordinal)
            .Replace("\"", "\\\"", StringComparison.Ordinal)
            .Replace("\r", "\\r", StringComparison.Ordinal)
            .Replace("\n", "\\n", StringComparison.Ordinal);
    }

    private static async Task WriteBootstrapTcpResponseAsync(NetworkStream stream, int statusCode, string statusText, string body)
    {
        byte[] bodyBytes = Encoding.UTF8.GetBytes(body);
        StringBuilder sb = new();
        sb.Append("HTTP/1.1 ").Append(statusCode).Append(' ').Append(statusText).Append("\r\n");
        sb.Append("Content-Type: application/json; charset=utf-8\r\n");
        sb.Append("Content-Length: ").Append(bodyBytes.Length).Append("\r\n");
        sb.Append("Connection: close\r\n");
        sb.Append("\r\n");
        byte[] headerBytes = Encoding.ASCII.GetBytes(sb.ToString());

        await stream.WriteAsync(headerBytes, 0, headerBytes.Length).ConfigureAwait(false);
        if (bodyBytes.Length > 0)
        {
            await stream.WriteAsync(bodyBytes, 0, bodyBytes.Length).ConfigureAwait(false);
        }
        await stream.FlushAsync().ConfigureAwait(false);
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
            // Best effort cleanup during game shutdown.
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
        while (_pendingBootstrapPayloads.TryDequeue(out BootstrapPayload? payload))
        {
            _retryBootstrapPayloads.Add(payload);
        }

        for (int i = 0; i < _retryBootstrapPayloads.Count;)
        {
            if (TryProcessBootstrapPayload(_retryBootstrapPayloads[i]))
            {
                _retryBootstrapPayloads.RemoveAt(i);
            }
            else
            {
                break;
            }
        }
    }

    private void DrainAutoGuestLoginRequests()
    {
        while (_pendingAutoGuestLogins.TryDequeue(out AutoGuestLoginRequest? request))
        {
            TryAutoGuestLogin(request.Controller, request.Reason);
        }
    }

    private void TryAutoGuestLoginFromLoadedLobbyClients()
    {
        Type? lobbyNetworkClientType = FindType("BAPBAP.Network.LobbyNetworkClient");
        if (lobbyNetworkClientType == null)
        {
            return;
        }

        try
        {
            Array? clients = FindLoadedUnityObjects(lobbyNetworkClientType);
            if (clients == null)
            {
                return;
            }

            if (!_autoGuestLobbyScanLogged)
            {
                _autoGuestLobbyScanLogged = true;
                LoggerInstance.Msg($"Custom guest-login scan saw {clients.Length} LobbyNetworkClient object(s).");
            }

            foreach (object client in clients)
            {
                object? controller = GetMemberValue(client, "_controller") ?? GetMemberValue(client, "Controller");
                object? login = controller == null
                    ? null
                    : GetMemberValue(controller, "Login");
                if (controller == null || login == null)
                {
                    continue;
                }

                if (!_autoGuestLoginControllerScanLogged)
                {
                    _autoGuestLoginControllerScanLogged = true;
                    LoggerInstance.Msg("Custom guest-login scan resolved LobbyNetworkClient.Controller.Login.");
                }

                TryAutoGuestLogin(login, "loaded LobbyNetworkClient");
            }
        }
        catch (Exception ex)
        {
            LoggerInstance.Warning($"Custom guest-login scan failed: {ex.GetBaseException().Message}");
        }
    }

    private void TryAutoGuestLoginFromLoadedLoginControllers()
    {
        Type? loginControllerType = FindType("BAPBAP.UI.LoginController");
        if (loginControllerType == null)
        {
            return;
        }

        try
        {
            Array? loginControllers = FindLoadedUnityObjects(loginControllerType);
            if (loginControllers == null)
            {
                return;
            }

            foreach (object loginController in loginControllers)
            {
                TryAutoGuestLogin(loginController, "loaded LoginController");
            }
        }
        catch (Exception ex)
        {
            LoggerInstance.Warning($"Custom LoginController guest-login scan failed: {ex.GetBaseException().Message}");
        }
    }

    private void TryInvokeSplashGuestLoginAction()
    {
        if (_dedicatedProcess || _splashGuestLoginInvoked || _autoGuestLoginEntry?.Value != true || !HasCompleteLocalIdentity())
        {
            return;
        }

        Type? splashType = FindType("BAPBAP.UI.UILobbySplashScreen");
        if (splashType == null)
        {
            return;
        }

        try
        {
            Array? splashScreens = FindLoadedUnityObjects(splashType);
            if (splashScreens == null || splashScreens.Length == 0)
            {
                if (!_splashGuestLoginScanLogged)
                {
                    _splashGuestLoginScanLogged = true;
                    LoggerInstance.Msg("Custom splash guest-login scan saw 0 UILobbySplashScreen object(s).");
                }

                return;
            }

            LoggerInstance.Msg($"Custom splash guest-login scan saw {splashScreens.Length} UILobbySplashScreen object(s).");

            foreach (object splashScreen in splashScreens)
            {
                object? actions = GetMemberValue(splashScreen, "_actions");
                object? guestLoginAction = actions == null ? null : GetMemberValue(actions, "GuestLoginAction");
                if (guestLoginAction != null)
                {
                    SetMemberValue(splashScreen, "LoginCancelled", false);
                    object? invokeResult = guestLoginAction is Delegate action
                        ? action.DynamicInvoke()
                        : InvokeInstance(guestLoginAction, "Invoke");

                    _splashGuestLoginInvoked = true;
                    _splashGuestLoginInvokedAt = Time.realtimeSinceStartup;
                    LoggerInstance.Msg($"Invoked custom-server guest login through UILobbySplashScreen action. Result={(invokeResult ?? "void")}");
                    return;
                }

                object? loginScreen = GetMemberValue(splashScreen, "_loginScreen");
                object? guestButton = loginScreen == null ? null : GetMemberValue(loginScreen, "GuestButton");
                object? onClick = guestButton == null ? null : GetMemberValue(guestButton, "onClick");
                if (onClick == null)
                {
                    LoggerInstance.Msg($"UILobbySplashScreen guest-login action unavailable. actions={(actions != null)} guestButton={(guestButton != null)}");
                    continue;
                }

                SetMemberValue(splashScreen, "LoginCancelled", false);
                object? buttonResult = InvokeInstance(onClick, "Invoke");
                _splashGuestLoginInvoked = true;
                _splashGuestLoginInvokedAt = Time.realtimeSinceStartup;
                LoggerInstance.Msg($"Invoked custom-server guest login through UILobbySplashScreen GuestButton.onClick. Result={(buttonResult ?? "void")}");
                return;
            }
        }
        catch (Exception ex)
        {
            LoggerInstance.Warning($"Custom splash guest-login action failed: {ex.GetBaseException().Message}");
        }
    }

    private void TryAutoGuestLogin(object loginController, string reason)
    {
        if (_dedicatedProcess || _autoGuestLoginEntry?.Value != true)
        {
            return;
        }

        int id = RuntimeHelpers.GetHashCode(loginController);
        if (!_autoGuestLoginControllers.Add(id))
        {
            return;
        }

        try
        {
            string accountId = _accountIdEntry.Value.Trim();
            string username = _usernameEntry.Value.Trim();
            if (string.IsNullOrWhiteSpace(accountId) || string.IsNullOrWhiteSpace(username))
            {
                UpdateIdentitySetupRequirement($"guest login via {reason}");
                _autoGuestLoginControllers.Remove(id);
                return;
            }

            string sid = $"bapcustom-{accountId}";
            SetMemberValue(loginController, "SessionId", sid);
            SetMemberValue(loginController, "AutoLogin", true);
            InvokeInstance(loginController, "UpdateCookie", sid);

            object? guestResult = InvokeInstance(loginController, "LoginGuest");
            if (guestResult == null)
            {
                InvokeInstance(loginController, "SendLoadRequest");
            }

            LoggerInstance.Msg($"Requested custom-server guest login via {reason}: {username} ({accountId}).");
        }
        catch (Exception ex)
        {
            _autoGuestLoginControllers.Remove(id);
            LoggerInstance.Warning($"Custom-server guest login failed: {ex.GetBaseException().Message}");
        }
    }

    private void SchedulePostLoginUiFallback(string reason, float delaySeconds = 4f)
    {
        if (_dedicatedProcess ||
            _postLoginUiFallbackApplied ||
            _identitySetupRequired ||
            !HasCompleteLocalIdentity())
        {
            return;
        }

        float next = Time.realtimeSinceStartup + delaySeconds;
        if (_postLoginUiFallbackAt <= 0f || next < _postLoginUiFallbackAt)
        {
            _postLoginUiFallbackAt = next;
        }

        if (!_postLoginUiFallbackLogged)
        {
            _postLoginUiFallbackLogged = true;
            LoggerInstance.Msg($"Scheduled custom-server post-login splash fallback after {reason}.");
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
            int lobbyCount = 0;
            int splashCount = 0;
            int hiddenCount = 0;

            Type? lobbyType = FindType("BAPBAP.UI.UILobby");
            if (lobbyType != null)
            {
                Array? lobbies = FindLoadedUnityObjects(lobbyType);
                lobbyCount = lobbies?.Length ?? 0;
                if (lobbies != null)
                {
                    foreach (object lobby in lobbies)
                    {
                        EnsureLobbyCanvasVisible(lobby);
                        object? splash = GetMemberValue(lobby, "_splashScreen") ?? GetMemberValue(lobby, "Splash");
                        if (splash != null)
                        {
                            splashCount++;
                            if (HideSplashObject(splash))
                            {
                                hiddenCount++;
                            }
                        }
                    }
                }
            }

            if (hiddenCount == 0)
            {
                Type? splashType = FindType("BAPBAP.UI.UILobbySplashScreen");
                if (splashType != null)
                {
                    Array? splashes = FindLoadedUnityObjects(splashType);
                    if (splashes != null)
                    {
                        splashCount += splashes.Length;
                        foreach (object splash in splashes)
                        {
                            if (HideSplashObject(splash))
                            {
                                hiddenCount++;
                            }
                        }
                    }
                }
            }

            if (hiddenCount > 0)
            {
                _postLoginUiFallbackApplied = true;
                LoggerInstance.Msg($"Applied custom-server post-login splash fallback ({reason}). lobbies={lobbyCount} splashes={splashCount} hidden={hiddenCount}");
                return;
            }

            if (_postLoginUiFallbackAttempts < 8)
            {
                LogLoadedUiDiagnostics("post-login fallback waiting");
                _postLoginUiFallbackAt = Time.realtimeSinceStartup + 2f;
                LoggerInstance.Msg($"Post-login splash fallback waiting for lobby UI. attempt={_postLoginUiFallbackAttempts} lobbies={lobbyCount} splashes={splashCount}");
            }
            else if (_postLoginUiFallbackAttempts == 8)
            {
                // Log ALL game objects at attempt 8 to understand what exists
                LogAllGameObjectsForDiagnostics();
                _postLoginUiFallbackAt = Time.realtimeSinceStartup + 5f;
                LoggerInstance.Warning($"Post-login splash fallback could not find lobby splash UI after {_postLoginUiFallbackAttempts} attempts. Continuing at slower rate.");
            }
            else
            {
                _postLoginUiFallbackAt = Time.realtimeSinceStartup + 5f;
            }
        }
        catch (Exception ex)
        {
            LoggerInstance.Warning($"Post-login splash fallback failed: {ex.GetBaseException().Message}");
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
            string sceneName = GetActiveSceneNameSafe();
            bool sceneLooksLikeMatch = !string.IsNullOrEmpty(sceneName) &&
                                       !sceneName.Equals("MainScene", StringComparison.OrdinalIgnoreCase) &&
                                       !sceneName.Equals("Login", StringComparison.OrdinalIgnoreCase) &&
                                       !sceneName.Equals("Bootstrap", StringComparison.OrdinalIgnoreCase);
            bool runtimeLooksLikeMatch = HasActiveMatchRuntime();

            if (!sceneLooksLikeMatch && !runtimeLooksLikeMatch)
            {
                return;
            }

            int hidden = HideMatchLoadingUi(sceneName);
            if (hidden > 0 && (!_matchLoadingOverlayHiddenLogged || hidden != _lastMatchLoadingOverlayHiddenCount))
            {
                _matchLoadingOverlayHiddenLogged = true;
                _lastMatchLoadingOverlayHiddenCount = hidden;
                LoggerInstance.Msg($"Hid {hidden} match loading/splash overlay object(s). activeScene='{sceneName}' runtimeMatch={runtimeLooksLikeMatch}");
            }
        }
        catch (Exception ex)
        {
            LoggerInstance.Warning($"ForceDismissSplashUiInMatch failed: {ex.GetBaseException().Message}");
        }
    }

    private static string GetActiveSceneNameSafe()
    {
        try
        {
            return UnityEngine.SceneManagement.SceneManager.GetActiveScene().name ?? "";
        }
        catch
        {
            return "";
        }
    }

    private bool HasActiveMatchRuntime()
    {
        try
        {
            Array? gameObjects = FindLoadedUnityObjects(typeof(GameObject));
            if (gameObjects != null)
            {
                foreach (GameObject go in gameObjects.Cast<GameObject>())
                {
                    string name = go == null ? "" : go.name ?? "";
                    if (name.StartsWith("Char_", StringComparison.OrdinalIgnoreCase) &&
                        name.Contains("(Clone)", StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
            }

            Type? playerManagerType = FindType("BAPBAP.Player.PlayerManager") ?? FindType("Il2CppBAPBAP.Player.PlayerManager");
            Array? players = playerManagerType == null ? null : FindLoadedUnityObjects(playerManagerType);
            if (players is { Length: > 0 })
            {
                return true;
            }

            Type? gameManagerType = FindType("BAPBAP.Game.GameManager") ?? FindType("Il2CppBAPBAP.Game.GameManager");
            Array? gameManagers = gameManagerType == null ? null : FindLoadedUnityObjects(gameManagerType);
            if (gameManagers != null)
            {
                foreach (object gameManager in gameManagers)
                {
                    if (GetMemberValue(gameManager, "matchStarted") is bool matchStarted && matchStarted)
                    {
                        return true;
                    }

                    object? currentGameMode = GetMemberValue(gameManager, "currentGameMode");
                    if (currentGameMode != null &&
                        (GetMemberValue(gameManager, "qmd") != null ||
                         GetMemberValue(gameManager, "mgd") != null ||
                         HasCollectionItems(GetMemberValue(gameManager, "playersByPlayerId"))))
                    {
                        return true;
                    }
                }
            }

            Type? gameNetworkManagerType = FindType("Il2CppBAPBAP.Network.GameNetworkManager") ?? FindType("BAPBAP.Network.GameNetworkManager");
            if (gameNetworkManagerType != null)
            {
                foreach (object networkManager in FindGameNetworkManagers(gameNetworkManagerType))
                {
                    object? gameManager = GetMemberValue(networkManager, "gameManager");
                    if (gameManager != null && GetMemberValue(gameManager, "currentGameMode") != null)
                    {
                        return true;
                    }
                }
            }
        }
        catch
        {
            return false;
        }

        return false;
    }

    private int HideMatchLoadingUi(string sceneName)
    {
        int hidden = 0;

        // We are in a match/gameplay scene. Forcefully hide all UIManager loading screens and UILobbySplashScreens.
        try
        {
            Type? uiManagerType = FindType("BAPBAP.UI.UIManager");
            if (uiManagerType != null)
            {
                const BindingFlags staticFlags = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
                object? instance = uiManagerType.GetProperty("Instance", staticFlags)?.GetValue(null)
                                ?? uiManagerType.GetField("Instance", staticFlags)?.GetValue(null);
                if (instance != null)
                {
                    TryInvokeInstance(instance, "HideLoadingScreenSimple", 0f);
                    TryInvokeInstance(instance, "HideLoadingScreen", 0f);
                    hidden += HideNamedOverlayMembers(instance);
                }
            }
        }
        catch
        {
            // Continue with object-level cleanup below.
        }

        try
        {
            Type? splashType = FindType("BAPBAP.UI.UILobbySplashScreen");
            if (splashType != null)
            {
                Array? splashes = FindLoadedUnityObjects(splashType);
                if (splashes != null && splashes.Length > 0)
                {
                    foreach (object splash in splashes)
                    {
                        if (splash != null)
                        {
                            hidden += HideSplashObject(splash) ? 1 : 0;
                            hidden += HideNamedOverlayMembers(splash);
                        }
                    }
                }
            }
        }
        catch
        {
            // Continue with object-level cleanup below.
        }

        try
        {
            Array? gameObjects = FindLoadedUnityObjects(typeof(GameObject));
            if (gameObjects != null)
            {
                HashSet<int> hiddenTargets = new();
                foreach (GameObject go in gameObjects.Cast<GameObject>())
                {
                    if (!ShouldHideMatchOverlayObject(go))
                    {
                        continue;
                    }

                    GameObject target = ResolveMatchOverlayHideTarget(go);
                    if (hiddenTargets.Add(target.GetInstanceID()))
                    {
                        hidden += HideGameObjectOverlay(target);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            LoggerInstance.Warning($"Match loading overlay object cleanup failed in scene '{sceneName}': {ex.GetBaseException().Message}");
        }

        return hidden;
    }

    private static bool ShouldHideMatchOverlayObject(GameObject? go)
    {
        if (go == null || !go.activeInHierarchy)
        {
            return false;
        }

        string name = go.name ?? "";
        if (name.Contains("BAP Custom Server", StringComparison.OrdinalIgnoreCase) ||
            name.Contains("CustomServer", StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        string path = GetTransformPath(go.transform);
        bool hasLoadingText = ContainsLoadingText(go);
        bool looksLikeOverlay = path.Contains("Loading", StringComparison.OrdinalIgnoreCase) ||
                                path.Contains("Splash", StringComparison.OrdinalIgnoreCase) ||
                                path.Contains("UILobbySplashScreen", StringComparison.OrdinalIgnoreCase) ||
                                path.Contains("GameStarting", StringComparison.OrdinalIgnoreCase) ||
                                path.Contains("Game Starting", StringComparison.OrdinalIgnoreCase) ||
                                hasLoadingText;
        if (!looksLikeOverlay)
        {
            return false;
        }

        return go.GetComponentInParent<Canvas>() != null || go.GetComponent<CanvasGroup>() != null;
    }

    private static GameObject ResolveMatchOverlayHideTarget(GameObject go)
    {
        Canvas? canvas = go.GetComponentInParent<Canvas>();
        if (canvas == null || go.transform == canvas.transform)
        {
            return go;
        }

        Transform current = go.transform;
        Transform? namedLoadingAncestor = null;
        while (current.parent != null && current.parent != canvas.transform)
        {
            string name = current.name ?? "";
            if (name.Contains("Loading", StringComparison.OrdinalIgnoreCase) ||
                name.Contains("Splash", StringComparison.OrdinalIgnoreCase) ||
                name.Contains("Starting", StringComparison.OrdinalIgnoreCase) ||
                name.Contains("GameStart", StringComparison.OrdinalIgnoreCase))
            {
                namedLoadingAncestor = current;
            }

            current = current.parent;
        }

        if (namedLoadingAncestor != null)
        {
            return namedLoadingAncestor.gameObject;
        }

        if (ContainsLoadingText(go) && go.transform.parent != null)
        {
            return go.transform.parent.gameObject;
        }

        return go.transform.parent?.gameObject ?? go;
    }

    private static bool ContainsLoadingText(GameObject go)
    {
        try
        {
            Component[] components = go.GetComponentsInChildren<Component>(true);
            foreach (Component component in components)
            {
                if (component == null)
                {
                    continue;
                }

                Type type = component.GetType();
                if (!type.Name.Contains("Text", StringComparison.OrdinalIgnoreCase) &&
                    !type.Name.Contains("Label", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                object? text = GetMemberValueSafe(component, "text") ?? GetMemberValueSafe(component, "m_text");
                if (text is string value && IsBlockingOverlayText(value))
                {
                    return true;
                }
            }
        }
        catch
        {
            return false;
        }

        return false;
    }

    private static bool IsBlockingOverlayText(string text)
    {
        return text.Contains("Loading", StringComparison.OrdinalIgnoreCase) ||
               text.Contains("Game Starting", StringComparison.OrdinalIgnoreCase) ||
               text.Contains("Game is Starting", StringComparison.OrdinalIgnoreCase) ||
               text.Contains("Starting Game", StringComparison.OrdinalIgnoreCase);
    }

    private static int HideNamedOverlayMembers(object instance)
    {
        int hidden = 0;
        const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        Type type = instance.GetType();

        foreach (FieldInfo field in type.GetFields(flags))
        {
            if (IsOverlayMemberName(field.Name))
            {
                hidden += HidePossibleOverlayValue(SafeReadField(field, instance), depth: 0);
            }
        }

        foreach (PropertyInfo property in type.GetProperties(flags))
        {
            if (!IsOverlayMemberName(property.Name) || property.GetIndexParameters().Length != 0 || !property.CanRead)
            {
                continue;
            }

            hidden += HidePossibleOverlayValue(SafeReadProperty(property, instance), depth: 0);
        }

        return hidden;
    }

    private static bool IsOverlayMemberName(string name)
    {
        return name.Contains("Loading", StringComparison.OrdinalIgnoreCase) ||
               name.Contains("Splash", StringComparison.OrdinalIgnoreCase) ||
               name.Contains("Spinner", StringComparison.OrdinalIgnoreCase);
    }

    private static object? SafeReadField(FieldInfo field, object instance)
    {
        try { return field.GetValue(instance); }
        catch { return null; }
    }

    private static object? SafeReadProperty(PropertyInfo property, object instance)
    {
        try { return property.GetValue(instance); }
        catch { return null; }
    }

    private static int HidePossibleOverlayValue(object? value, int depth)
    {
        if (value == null || depth > 2)
        {
            return 0;
        }

        if (value is GameObject gameObject)
        {
            return HideGameObjectOverlay(gameObject);
        }

        if (value is Component component)
        {
            return HideGameObjectOverlay(component.gameObject);
        }

        if (value is CanvasGroup canvasGroup)
        {
            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            return 1;
        }

        int hidden = 0;
        if (GetMemberValueSafe(value, "gameObject") is GameObject memberGameObject)
        {
            hidden += HideGameObjectOverlay(memberGameObject);
        }

        if (GetMemberValueSafe(value, "CanvasGroup") is CanvasGroup memberCanvasGroup)
        {
            memberCanvasGroup.alpha = 0f;
            memberCanvasGroup.interactable = false;
            memberCanvasGroup.blocksRaycasts = false;
            hidden++;
        }

        if (hidden > 0 || depth >= 1)
        {
            return hidden;
        }

        const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        Type type = value.GetType();
        foreach (FieldInfo field in type.GetFields(flags))
        {
            if (IsOverlayMemberName(field.Name))
            {
                hidden += HidePossibleOverlayValue(SafeReadField(field, value), depth + 1);
            }
        }

        foreach (PropertyInfo property in type.GetProperties(flags))
        {
            if (IsOverlayMemberName(property.Name) && property.GetIndexParameters().Length == 0 && property.CanRead)
            {
                hidden += HidePossibleOverlayValue(SafeReadProperty(property, value), depth + 1);
            }
        }

        return hidden;
    }

    private static int HideGameObjectOverlay(GameObject go)
    {
        int touched = 0;

        try
        {
            CanvasGroup[] groups = go.GetComponentsInChildren<CanvasGroup>(true);
            foreach (CanvasGroup group in groups)
            {
                group.alpha = 0f;
                group.interactable = false;
                group.blocksRaycasts = false;
                touched++;
            }
        }
        catch
        {
            // Best effort; SetActive below is the final guard.
        }

        if (go.activeSelf)
        {
            go.SetActive(false);
            touched++;
        }

        return touched;
    }

    private void LogLoadedUiDiagnostics(string reason)
    {
        if (_postLoginUiDiagnosticsLogged)
        {
            return;
        }

        _postLoginUiDiagnosticsLogged = true;

        try
        {
            UnityEngine.SceneManagement.Scene scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
            LoggerInstance.Msg($"Loaded UI diagnostics ({reason}): activeScene='{scene.name}' path='{scene.path}' isLoaded={scene.isLoaded}");

            LogSceneRootsReflective(scene);

            Array? canvases = FindLoadedUnityObjects(typeof(Canvas));
            LoggerInstance.Msg($"Loaded UI diagnostics canvases={canvases?.Length ?? 0}");
            if (canvases == null)
            {
                return;
            }

            foreach (Canvas canvas in canvases.Cast<Canvas>().Take(18))
            {
                LoggerInstance.Msg(
                    "Loaded UI canvas: " +
                    $"path='{GetTransformPath(canvas.transform)}' " +
                    $"activeSelf={canvas.gameObject.activeSelf} " +
                    $"activeInHierarchy={canvas.gameObject.activeInHierarchy} " +
                    $"renderMode={canvas.renderMode} " +
                    $"sortingOrder={canvas.sortingOrder}");
            }

            LogInterestingGameObjects();
        }
        catch (Exception ex)
        {
            LoggerInstance.Warning($"Loaded UI diagnostics failed: {ex.GetBaseException().Message}");
        }
    }

    private void LogInterestingGameObjects()
    {
        LogAllGameObjectsForDiagnostics();
    }

    private void ScheduleSceneReloadIfEmpty()
    {
        if (_dedicatedProcess || _sceneReloadScheduled)
        {
            return;
        }

        // Instead of reloading the scene, try to protect UI objects from destruction
        // The game's login flow destroys all root GOs. We prevent this by marking
        // key objects as DontDestroyOnLoad before the login response processes.
        TryProtectLobbyUiFromDestruction();
    }

    private void TryProtectLobbyUiFromDestruction()
    {
        try
        {
            // Find UIManager and mark it DontDestroyOnLoad
            Type? uiManagerType = FindType("BAPBAP.UI.UIManager");
            if (uiManagerType != null)
            {
                Array? uiManagers = FindLoadedUnityObjects(uiManagerType);
                if (uiManagers != null)
                {
                    foreach (object mgr in uiManagers)
                    {
                        if (GetMemberValue(mgr, "gameObject") is GameObject go)
                        {
                            Object.DontDestroyOnLoad(go);
                            LoggerInstance.Msg($"Protected UIManager '{go.name}' with DontDestroyOnLoad.");
                        }
                    }
                }
            }

            // Find GameNetworkManager and protect it too
            Type? gnmType = FindType("Il2CppBAPBAP.Network.GameNetworkManager") ?? FindType("Il2CppBAPBAP.Network.GameNetworkManager") ?? FindType("BAPBAP.Network.GameNetworkManager");
            if (gnmType != null)
            {
                Array? gnms = FindLoadedUnityObjects(gnmType);
                if (gnms != null)
                {
                    foreach (object gnm in gnms)
                    {
                        if (GetMemberValue(gnm, "gameObject") is GameObject go)
                        {
                            Object.DontDestroyOnLoad(go);
                            LoggerInstance.Msg($"Protected GameNetworkManager '{go.name}' with DontDestroyOnLoad.");
                        }
                    }
                }
            }

            // Also protect all root canvas objects
            Array? canvases = FindLoadedUnityObjects(typeof(Canvas));
            if (canvases != null)
            {
                foreach (Canvas canvas in canvases.Cast<Canvas>())
                {
                    if (canvas != null && canvas.isRootCanvas && canvas.gameObject != null)
                    {
                        Object.DontDestroyOnLoad(canvas.gameObject);
                        LoggerInstance.Msg($"Protected Canvas '{canvas.gameObject.name}' with DontDestroyOnLoad.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            LoggerInstance.Warning($"TryProtectLobbyUiFromDestruction failed: {ex.GetBaseException().Message}");
        }
    }

    private void TryReloadSceneForLobbyUi()
    {
        try
        {
            Array? canvases = FindLoadedUnityObjects(typeof(Canvas));
            int canvasCount = canvases?.Length ?? 0;

            // If there are already canvases (lobby UI loaded naturally), skip reload
            if (canvasCount > 0)
            {
                LoggerInstance.Msg($"Scene reload skipped — {canvasCount} canvas(es) already present.");
                return;
            }

            // Check if any UILobby exists (even inactive)
            Type? lobbyType = FindType("BAPBAP.UI.UILobby");
            if (lobbyType != null)
            {
                Array? lobbies = FindLoadedUnityObjects(lobbyType);
                if (lobbies != null && lobbies.Length > 0)
                {
                    LoggerInstance.Msg($"Scene reload skipped — {lobbies.Length} UILobby object(s) found. Trying to activate them.");
                    foreach (object lobby in lobbies)
                    {
                        if (GetMemberValue(lobby, "gameObject") is GameObject lobbyGo && !lobbyGo.activeInHierarchy)
                        {
                            lobbyGo.SetActive(true);
                            LoggerInstance.Msg($"Activated inactive UILobby: '{lobbyGo.name}'");
                        }
                    }
                    return;
                }
            }

            // The scene is empty (0 GameObjects/Canvases after login). Reload the active scene.
            // Use full reflection since IL2CPP SceneManager types may not be directly accessible
            Type? sceneManagerType = FindType("UnityEngine.SceneManagement.SceneManager");
            if (sceneManagerType == null)
            {
                LoggerInstance.Warning("SceneManager type not found. Cannot reload scene.");
                return;
            }

            MethodInfo? getActiveScene = sceneManagerType.GetMethods(BindingFlags.Static | BindingFlags.Public)
                .FirstOrDefault(m => m.Name == "GetActiveScene" && m.GetParameters().Length == 0);

            int buildIndex = 0;
            string sceneName = "MainScene";
            if (getActiveScene != null)
            {
                object sceneObj = getActiveScene.Invoke(null, null)!;
                Type sceneType = sceneObj.GetType();
                PropertyInfo? buildIndexProp = sceneType.GetProperty("buildIndex", BindingFlags.Instance | BindingFlags.Public);
                PropertyInfo? nameProp = sceneType.GetProperty("name", BindingFlags.Instance | BindingFlags.Public);
                if (buildIndexProp != null) buildIndex = (int)buildIndexProp.GetValue(sceneObj)!;
                if (nameProp != null) sceneName = nameProp.GetValue(sceneObj) as string ?? "MainScene";
            }

            LoggerInstance.Msg($"Reloading scene '{sceneName}' (buildIndex={buildIndex}) to restore lobby UI.");

            MethodInfo? loadSceneInt = sceneManagerType.GetMethods(BindingFlags.Static | BindingFlags.Public)
                .FirstOrDefault(m => m.Name == "LoadScene" && m.GetParameters().Length == 1 &&
                                     m.GetParameters()[0].ParameterType == typeof(int));
            if (loadSceneInt != null)
            {
                loadSceneInt.Invoke(null, new object[] { buildIndex });
            }
            else
            {
                MethodInfo? loadSceneStr = sceneManagerType.GetMethods(BindingFlags.Static | BindingFlags.Public)
                    .FirstOrDefault(m => m.Name == "LoadScene" && m.GetParameters().Length == 1 &&
                                         m.GetParameters()[0].ParameterType == typeof(string));
                if (loadSceneStr != null)
                {
                    loadSceneStr.Invoke(null, new object[] { sceneName });
                }
                else
                {
                    LoggerInstance.Warning("Could not find any SceneManager.LoadScene overload.");
                }
            }
        }
        catch (Exception ex)
        {
            LoggerInstance.Warning($"Scene reload failed: {ex.GetBaseException().Message}");
        }
    }

    private void LogAllGameObjectsForDiagnostics()
    {
        Array? gameObjects = FindLoadedUnityObjects(typeof(GameObject));
        LoggerInstance.Msg($"[FULL DIAGNOSTICS] Total GameObjects: {gameObjects?.Length ?? 0}");
        if (gameObjects == null) return;

        int logged = 0;
        foreach (GameObject go in gameObjects.Cast<GameObject>())
        {
            string name = go.name ?? "";
            bool isInteresting = name.Contains("Lobby", StringComparison.OrdinalIgnoreCase) ||
                                 name.Contains("Canvas", StringComparison.OrdinalIgnoreCase) ||
                                 name.Contains("UI", StringComparison.OrdinalIgnoreCase) ||
                                 name.Contains("Splash", StringComparison.OrdinalIgnoreCase) ||
                                 name.Contains("Login", StringComparison.OrdinalIgnoreCase) ||
                                 name.Contains("Network", StringComparison.OrdinalIgnoreCase) ||
                                 name.Contains("Manager", StringComparison.OrdinalIgnoreCase) ||
                                 name.Contains("Camera", StringComparison.OrdinalIgnoreCase) ||
                                 name.Contains("Loading", StringComparison.OrdinalIgnoreCase);
            if (!isInteresting) continue;

            LoggerInstance.Msg($"  GO: '{GetTransformPath(go.transform)}' active={go.activeSelf} inHierarchy={go.activeInHierarchy}");
            logged++;
            if (logged >= 100) break;
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

    private void LogSceneRootsReflective(UnityEngine.SceneManagement.Scene scene)
    {
        try
        {
            MethodInfo? getRoots = typeof(UnityEngine.SceneManagement.Scene)
                .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .FirstOrDefault(method =>
                {
                    if (method.Name != "GetRootGameObjects")
                    {
                        return false;
                    }

                    return method.GetParameters().Length == 0;
                });
            if (getRoots == null)
            {
                LoggerInstance.Msg("Loaded UI diagnostics root scan unavailable: Scene.GetRootGameObjects not present.");
                return;
            }

            object boxedScene = scene;
            if (getRoots.Invoke(boxedScene, null) is GameObject[] roots)
            {
                LoggerInstance.Msg($"Loaded UI diagnostics roots={roots.Length}: {string.Join(", ", roots.Take(16).Select(root => root.name))}");
            }
        }
        catch (Exception ex)
        {
            LoggerInstance.Msg($"Loaded UI diagnostics root scan failed: {ex.GetBaseException().Message}");
        }
    }

    private static string GetTransformPath(Transform transform)
    {
        List<string> names = new();
        Transform? current = transform;
        while (current != null)
        {
            names.Add(current.name);
            current = current.parent;
        }

        names.Reverse();
        return string.Join("/", names);
    }

    private static void EnsureLobbyCanvasVisible(object lobby)
    {
        if (GetMemberValue(lobby, "canvasGroup") is CanvasGroup group)
        {
            group.alpha = 1f;
            group.interactable = true;
            group.blocksRaycasts = true;
        }
    }

    private static bool HideSplashObject(object splash)
    {
        bool touched = false;

        SetMemberValue(splash, "LoginCancelled", false);
        touched = InvokeInstance(splash, "HideLogin") != null || touched;
        touched = InvokeInstance(splash, "HideLoginSpinner") != null || touched;
        touched = InvokeInstance(splash, "HideLoginProviders") != null || touched;
        touched = InvokeInstance(splash, "HideSplashSpinner") != null || touched;
        touched = InvokeInstance(splash, "HideLoadingSimpleScreen", 0f) != null || touched;
        touched = InvokeInstance(splash, "HideSplashScreen") != null || touched;

        touched = HideSplashCanvasGroup(GetMemberValue(splash, "_loginScreen")) || touched;
        touched = HideSplashCanvasGroup(GetMemberValue(splash, "_loadingSimpleScreen")) || touched;
        touched = HideSplashCanvasGroup(GetMemberValue(splash, "_loadingMainScreen")) || touched;

        if (GetMemberValue(splash, "gameObject") is GameObject gameObject)
        {
            gameObject.SetActive(false);
            touched = true;
        }

        return touched;
    }

    private static bool HideSplashCanvasGroup(object? screen)
    {
        if (screen == null)
        {
            return false;
        }

        bool touched = false;
        if (GetMemberValue(screen, "CanvasGroup") is CanvasGroup group)
        {
            group.alpha = 0f;
            group.interactable = false;
            group.blocksRaycasts = false;
            touched = true;
        }

        if (GetMemberValue(screen, "LoadingSpinner") is object spinner)
        {
            touched = HideSplashCanvasGroup(spinner) || touched;
        }

        return touched;
    }

    private bool TryProcessBootstrapPayload(BootstrapPayload payload)
    {
        Type? gameNetworkManagerType = FindType("Il2CppBAPBAP.Network.GameNetworkManager") ?? FindType("Il2CppBAPBAP.Network.GameNetworkManager") ?? FindType("BAPBAP.Network.GameNetworkManager");
        object? manager = gameNetworkManagerType == null
            ? null
            : FindGameNetworkManagers(gameNetworkManagerType).FirstOrDefault();
        if (manager == null)
        {
            SetBootstrapRepairStatus($"Waiting for GameNetworkManager before applying {payload.Path}.", logRepeated: false);
            return false;
        }

        string methodName;
        string payloadTypeName;
        switch (payload.Path)
        {
            case "/setup-game":
                methodName = "OnServerMatchSetup";
                payloadTypeName = "BAPBAP.Network.MatchmakingGameData";
                break;
            case "/add-teams":
                methodName = "OnServerMatchAddTeams";
                payloadTypeName = "BAPBAP.Network.MatchmakingTeamData";
                break;
            case "/queue-matched":
                methodName = "OnServerQueueMatched";
                payloadTypeName = "BAPBAP.Network.QueueMatchedData";
                break;
            default:
                return true;
        }

        Type? payloadType = FindType(payloadTypeName);
        if (payloadType == null)
        {
            SetBootstrapRepairStatus($"Waiting for bootstrap payload type {payloadTypeName}.", logRepeated: false);
            return false;
        }

        try
        {
            TryConfigureDedicatedGameManagers();

            // Idempotency: each bootstrap path only applies ONCE per match.
            // Re-applying mgd/qmd causes duplicate map loads and breaks spawn points.
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

            if (payload.Path == "/setup-game" && !IsMirrorServerActive(manager))
            {
                if (_dedicatedWsPort is > 0 && _dedicatedKcpPort is > 0 && _dedicatedTcpPort is > 0)
                {
                    TryStartDedicatedGameNetwork(_dedicatedWsPort.Value, _dedicatedKcpPort.Value, _dedicatedTcpPort.Value);
                }

                if (!IsMirrorServerActive(manager))
                {
                    SetBootstrapRepairStatus("Waiting for Mirror server to become active before applying /setup-game.", logRepeated: false);
                    return false;
                }

                SetBootstrapRepairStatus("Mirror server is active before /setup-game; applying setup payload.", logRepeated: false);
            }

            if (payload.Path != "/setup-game" && !IsServerMatchMapReady(manager))
            {
                SetBootstrapRepairStatus($"Waiting for loaded map before applying {payload.Path}.", logRepeated: false);
                return false;
            }

            PatchLoadedGameModeLevelNames();

            object? il2CppPayload = CreateIl2CppPayload(payloadType, payload.Json);
            if (il2CppPayload == null)
            {
                SetBootstrapRepairStatus($"Could not create payload for {payload.Path}.", logRepeated: false);
                return false;
            }

            PrepareBootstrapPayload(payload.Path, il2CppPayload);
            ApplyGameManagerBootstrapState(manager, payload.Path, il2CppPayload);
            InvokeInstance(manager, methodName, il2CppPayload);
            ApplyGameManagerBootstrapState(manager, payload.Path, il2CppPayload);
            LogBootstrapPayloadSnapshot(payload.Path, il2CppPayload, manager);
            SetBootstrapRepairStatus($"Applied managed match bootstrap payload {payload.Path} via {methodName}.", logRepeated: true);

            // Mark this path as applied so the retry loop won't re-execute it.
            switch (payload.Path)
            {
                case "/setup-game": _setupGameApplied = true; break;
                case "/add-teams": _addTeamsApplied = true; break;
                case "/queue-matched": _queueMatchedApplied = true; break;
            }
            return true;
        }
        catch (Exception ex)
        {
            // Once /setup-game fails with IndexOutOfRange, retrying won't help - the payload shape is incompatible
            // with the IL2CPP method's index assumptions. Log full stack ONCE and stop retry spam.
            string baseMsg = ex.GetBaseException().Message;
            string fullTrace = ex.GetBaseException().StackTrace ?? "(no stack)";
            if (payload.Path == "/setup-game" && !_setupGameFailureLogged)
            {
                _setupGameFailureLogged = true;
                LoggerInstance.Warning($"Bootstrap /setup-game permanent failure: {baseMsg}\nFull stack:\n{fullTrace}\nFurther retries on /setup-game will be silently skipped.");
            }
            else if (payload.Path != "/setup-game")
            {
                SetBootstrapRepairStatus($"Bootstrap payload {payload.Path} failed: {baseMsg}", logRepeated: false);
            }
            return false;
        }
    }

    private void PrepareBootstrapPayload(string path, object il2CppPayload)
    {
        if (path != "/setup-game")
        {
            return;
        }

        int oldCharSelect = GetIntMemberOrDefault(il2CppPayload, "charSelectMillis", -1);
        int oldSpawnSelect = GetIntMemberOrDefault(il2CppPayload, "spawnSelectMillis", -1);
        int oldSpawnShow = GetIntMemberOrDefault(il2CppPayload, "spawnShowMillis", -1);

        bool changed = false;
        changed |= RaiseIntMember(il2CppPayload, "charSelectMillis", DedicatedCharSelectMillis);
        changed |= RaiseIntMember(il2CppPayload, "spawnSelectMillis", DedicatedSpawnSelectMillis);
        changed |= RaiseIntMember(il2CppPayload, "spawnShowMillis", DedicatedSpawnShowMillis);

        LoggerInstance.Msg(
            "[PrematchTiming] /setup-game " +
            $"charSelectMillis={oldCharSelect}->{GetIntMemberOrDefault(il2CppPayload, "charSelectMillis", -1)} " +
            $"spawnSelectMillis={oldSpawnSelect}->{GetIntMemberOrDefault(il2CppPayload, "spawnSelectMillis", -1)} " +
            $"spawnShowMillis={oldSpawnShow}->{GetIntMemberOrDefault(il2CppPayload, "spawnShowMillis", -1)} " +
            $"changed={changed}.");
    }

    private void LogBootstrapPayloadSnapshot(string path, object il2CppPayload, object gameNetworkManager)
    {
        try
        {
            object? gameManager = GetMemberValue(gameNetworkManager, "gameManager");
            if (path == "/setup-game")
            {
                LoggerInstance.Msg(
                    "[PrematchTiming] GameManager after /setup-game: " +
                    $"mgd={DescribeMatchTiming(il2CppPayload)} gm={DescribeGameManager(gameManager)}.");
                return;
            }

            if (path == "/queue-matched")
            {
                LoggerInstance.Msg(
                    "[PrematchTiming] GameManager after /queue-matched: " +
                    $"qmdPlayers={DescribeQueueMatchedPlayers(il2CppPayload)} " +
                    $"available={DescribeAvailableCharacters(il2CppPayload)} " +
                    $"gm={DescribeGameManager(gameManager)}.");
            }
        }
        catch (Exception ex)
        {
            LoggerInstance.Warning($"Prematch bootstrap snapshot failed for {path}: {ex.GetBaseException().Message}");
        }
    }

    private void ApplyGameManagerBootstrapState(object gameNetworkManager, string path, object il2CppPayload)
    {
        string? memberName = path switch
        {
            "/setup-game" => "mgd",
            "/queue-matched" => "qmd",
            _ => null
        };
        if (memberName == null)
        {
            return;
        }

        // CRITICAL: write ONLY to the primary GameManager (the one attached to gameNetworkManager.gameManager).
        // Writing to all FindLoadedUnityObjects results spreads payload to duplicate map instances and
        // causes spawnPoints to be read from a duplicate without map data, breaking match start.
        int assigned = 0;
        object? directGameManager = GetMemberValue(gameNetworkManager, "gameManager");
        if (SetGameManagerBootstrapMember(directGameManager, memberName, il2CppPayload))
        {
            assigned++;
        }

        if (assigned > 0)
        {
            SetBootstrapRepairStatus($"Assigned GameManager.{memberName} on primary GameManager (single-instance write).", logRepeated: true);
        }
        else
        {
            // Primary not available yet - fall back to GameManager.Instance only (still single-instance).
            Type? gameManagerType = FindType("BAPBAP.Game.GameManager");
            if (gameManagerType != null)
            {
                const BindingFlags staticFlags = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
                object? instance = gameManagerType.GetProperty("Instance", staticFlags)?.GetValue(null) ??
                                   gameManagerType.GetField("Instance", staticFlags)?.GetValue(null);
                if (SetGameManagerBootstrapMember(instance, memberName, il2CppPayload))
                {
                    SetBootstrapRepairStatus($"Assigned GameManager.{memberName} via GameManager.Instance fallback.", logRepeated: true);
                }
            }
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

    private int _rebindAttemptCount;
    private string _lastRebindStateLogged = "";
    private void TryRebindCurrentGameModeToPopulatedInstance()
    {
        if (_currentGameModeRebound) return;

        _rebindAttemptCount++;

        object? primary = FindPrimaryGameManager();
        if (primary == null)
        {
            string state = "no-primary";
            if (_lastRebindStateLogged != state) { LoggerInstance.Msg($"[MapFix] no primary GameManager found yet."); _lastRebindStateLogged = state; }
            return;
        }

        // Get GameManager.gameModes - could be GameMode[] (Array), Il2CppReferenceArray<GameMode>,
        // or List<GameMode>. Use generic enumeration.
        object? gameModesObj = GetMemberValue(primary, "gameModes");
        if (gameModesObj == null)
        {
            string state = "no-gameModes";
            if (_lastRebindStateLogged != state) { LoggerInstance.Msg($"[MapFix] GameManager.gameModes is null. Will retry."); _lastRebindStateLogged = state; }
            return;
        }

        // Convert to enumerable
        var gameModeList = new System.Collections.Generic.List<object>();
        try
        {
            if (gameModesObj is Array arr)
            {
                for (int i = 0; i < arr.Length; i++) gameModeList.Add(arr.GetValue(i)!);
            }
            else if (gameModesObj is System.Collections.IEnumerable iEnum)
            {
                foreach (var item in iEnum) gameModeList.Add(item);
            }
            else
            {
                var lengthProp = gameModesObj.GetType().GetProperty("Length") ?? gameModesObj.GetType().GetProperty("Count");
                var indexer = gameModesObj.GetType().GetProperty("Item", new[] { typeof(int) });
                if (lengthProp != null && indexer != null)
                {
                    int len = (int)(lengthProp.GetValue(gameModesObj) ?? 0);
                    for (int i = 0; i < len; i++)
                    {
                        var item = indexer.GetValue(gameModesObj, new object[] { i });
                        if (item != null) gameModeList.Add(item);
                    }
                }
                else return;
            }
        }
        catch { return; }

        if (gameModeList.Count == 0)
        {
            string state = "empty-gameModes";
            if (_lastRebindStateLogged != state) { LoggerInstance.Msg($"[MapFix] gameModes empty. Will retry."); _lastRebindStateLogged = state; }
            return;
        }

        // Inspect each GameMode's spawnPoints (List<Vector3>) for population
        object? populated = null;
        var spawnCounts = new System.Collections.Generic.List<int>();
        for (int i = 0; i < gameModeList.Count; i++)
        {
            object? gm = gameModeList[i];
            if (gm == null) { spawnCounts.Add(-1); continue; }
            try
            {
                object? spawnPoints = GetMemberValue(gm, "spawnPoints");
                int cnt = -1;
                if (spawnPoints is System.Collections.ICollection col) cnt = col.Count;
                else if (spawnPoints != null)
                {
                    var cprop = spawnPoints.GetType().GetProperty("Count") ?? spawnPoints.GetType().GetProperty("Length");
                    if (cprop != null) cnt = (int)(cprop.GetValue(spawnPoints) ?? -1);
                }
                spawnCounts.Add(cnt);
                if (cnt > 0 && populated == null) populated = gm;
            }
            catch { spawnCounts.Add(-2); }
        }

        if (populated == null)
        {
            string state = $"no-populated-counts={string.Join(",", spawnCounts)}";
            if (_lastRebindStateLogged != state)
            {
                LoggerInstance.Msg($"[MapFix] {gameModeList.Count} GameMode(s), spawnCounts=[{string.Join(",", spawnCounts)}]. Waiting for populated map...");
                _lastRebindStateLogged = state;
            }
            return;
        }

        object? current = GetMemberValue(primary, "currentGameMode");
        bool sameInstance = ReferenceEquals(current, populated);
        if (sameInstance)
        {
            _currentGameModeRebound = true;
            LoggerInstance.Msg($"[MapFix] currentGameMode already populated ({populated.GetType().Name}, counts=[{string.Join(",", spawnCounts)}]). Rebind skipped.");
            return;
        }

        if (SetMemberValue(primary, "currentGameMode", populated))
        {
            _currentGameModeRebound = true;
            string currentName = current?.GetType()?.Name ?? "null";
            LoggerInstance.Msg($"[MapFix] Rebound currentGameMode from {currentName} to populated {populated.GetType().Name} (counts=[{string.Join(",", spawnCounts)}]).");
        }
        else
        {
            LoggerInstance.Msg($"[MapFix] SetMemberValue currentGameMode failed.");
        }
    }

    // After identifying the populated GameMode (with 55 spawn points), COPY the spawn-point
    // collections to all other GameMode instances so any reference path to ReserveSpawnPoint
    // sees the correct data, not just GameManager.currentGameMode.
    private bool _spawnPointsCopied;
    private void TryCopySpawnPointsToAllGameModes()
    {
        if (_spawnPointsCopied) return;
        if (!_currentGameModeRebound) return;
        if (!IsRunningAsDedicatedServer()) return;

        object? primary = FindPrimaryGameManager();
        if (primary == null) return;
        object? gameModesObj = GetMemberValue(primary, "gameModes");
        if (gameModesObj == null) return;
        var gameModeList = new System.Collections.Generic.List<object>();
        try
        {
            if (gameModesObj is Array arr) for (int i = 0; i < arr.Length; i++) gameModeList.Add(arr.GetValue(i)!);
            else if (gameModesObj is System.Collections.IEnumerable iEnum) foreach (var item in iEnum) gameModeList.Add(item);
            else
            {
                var lengthProp = gameModesObj.GetType().GetProperty("Length") ?? gameModesObj.GetType().GetProperty("Count");
                var indexer = gameModesObj.GetType().GetProperty("Item", new[] { typeof(int) });
                if (lengthProp != null && indexer != null)
                {
                    int len = (int)(lengthProp.GetValue(gameModesObj) ?? 0);
                    for (int i = 0; i < len; i++) gameModeList.Add(indexer.GetValue(gameModesObj, new object[] { i })!);
                }
            }
        }
        catch { return; }

        if (gameModeList.Count <= 1) { _spawnPointsCopied = true; return; }

        // Find the populated GameMode (one with non-empty spawnPoints)
        object? populated = null;
        foreach (var gm in gameModeList)
        {
            if (gm == null) continue;
            try
            {
                object? spawnPoints = GetMemberValue(gm, "spawnPoints");
                if (spawnPoints is System.Collections.ICollection col && col.Count > 0) { populated = gm; break; }
                if (spawnPoints != null)
                {
                    var cprop = spawnPoints.GetType().GetProperty("Count") ?? spawnPoints.GetType().GetProperty("Length");
                    if (cprop != null && Convert.ToInt32(cprop.GetValue(spawnPoints) ?? 0) > 0) { populated = gm; break; }
                }
            }
            catch { }
        }
        if (populated == null) return;

        // Get all 3 spawn-related collections from populated
        object? srcSpawnPoints = GetMemberValue(populated, "spawnPoints");
        object? srcAvailable = GetMemberValue(populated, "availableSpawnPoints");
        object? srcDimSpawns = GetMemberValue(populated, "dimensionSpawnPoints");
        object? srcEnvManager = GetMemberValue(populated, "currentEnvManager");

        int copied = 0;
        foreach (var gm in gameModeList)
        {
            if (gm == null || ReferenceEquals(gm, populated)) continue;
            try
            {
                if (srcSpawnPoints != null) SetMemberValue(gm, "spawnPoints", srcSpawnPoints);
                if (srcAvailable != null) SetMemberValue(gm, "availableSpawnPoints", srcAvailable);
                if (srcDimSpawns != null) SetMemberValue(gm, "dimensionSpawnPoints", srcDimSpawns);
                if (srcEnvManager != null) SetMemberValue(gm, "currentEnvManager", srcEnvManager);
                copied++;
            }
            catch (Exception ex)
            {
                LoggerInstance.Msg($"[MapFix] copy spawnPoints failed: {ex.GetBaseException().Message}");
            }
        }

        if (copied > 0)
        {
            LoggerInstance.Msg($"[MapFix] Copied spawn points/envManager from populated GameMode to {copied} duplicate(s).");
        }
        _spawnPointsCopied = true;
    }

    // Disable the .enabled flag on the empty/placeholder GameMode NetworkBehaviour instances.
    // CAUTION: Do NOT call UnSpawn or SetActive(false) on the GameObject - all 3 GameMode
    // components share the same GameObject, so that would unspawn the GameManager too!
    private bool _duplicatesGameModesDestroyed;
    private void TryDestroyDuplicateGameModes()
    {
        if (_duplicatesGameModesDestroyed) return;
        if (!_currentGameModeRebound) return;
        if (!IsRunningAsDedicatedServer()) return;

        object? primary = FindPrimaryGameManager();
        if (primary == null) return;
        object? gameModesObj = GetMemberValue(primary, "gameModes");
        if (gameModesObj == null) return;

        var gameModeList = new System.Collections.Generic.List<object>();
        try
        {
            if (gameModesObj is Array arr) for (int i = 0; i < arr.Length; i++) gameModeList.Add(arr.GetValue(i)!);
            else if (gameModesObj is System.Collections.IEnumerable iEnum) foreach (var item in iEnum) gameModeList.Add(item);
            else
            {
                var lengthProp = gameModesObj.GetType().GetProperty("Length") ?? gameModesObj.GetType().GetProperty("Count");
                var indexer = gameModesObj.GetType().GetProperty("Item", new[] { typeof(int) });
                if (lengthProp != null && indexer != null)
                {
                    int len = (int)(lengthProp.GetValue(gameModesObj) ?? 0);
                    for (int i = 0; i < len; i++) gameModeList.Add(indexer.GetValue(gameModesObj, new object[] { i })!);
                }
            }
        }
        catch { return; }

        if (gameModeList.Count <= 1) { _duplicatesGameModesDestroyed = true; return; }

        object? current = GetMemberValue(primary, "currentGameMode");
        if (current == null) return;

        int disabled = 0;
        foreach (var gm in gameModeList)
        {
            if (gm == null || ReferenceEquals(gm, current)) continue;
            try
            {
                // Only disable the Behaviour component, NOT the GameObject (would unspawn whole game).
                var enabledProp = gm.GetType().GetProperty("enabled");
                if (enabledProp != null && enabledProp.CanWrite)
                {
                    enabledProp.SetValue(gm, false);
                    disabled++;
                }
            }
            catch (Exception ex)
            {
                LoggerInstance.Msg($"[MapFix] disable duplicate failed: {ex.GetBaseException().Message}");
            }
        }

        if (disabled > 0)
        {
            LoggerInstance.Msg($"[MapFix] Disabled .enabled on {disabled} duplicate GameMode behaviour(s) (kept GameObject intact).");
        }
        _duplicatesGameModesDestroyed = true;
    }

    private bool IsRunningAsDedicatedServer()
    {
        try
        {
            Type? networkServerType = FindType("Il2CppMirror.NetworkServer") ?? FindType("Il2CppMirror.NetworkServer") ?? FindType("Mirror.NetworkServer");
            if (networkServerType != null)
            {
                PropertyInfo? activeProp = networkServerType.GetProperty("active", BindingFlags.Static | BindingFlags.Public);
                if (activeProp != null)
                {
                    object? serverActive = activeProp.GetValue(null);
                    if (serverActive is bool mirrorActive) return mirrorActive;
                }
            }
        }
        catch { }
        return false;
    }

    private int _forceMatchStartAttemptCount;
    private void TryForceOnMatchStarted()
    {
        if (_onMatchStartedForced) return;
        if (!_currentGameModeRebound) return;
        // Default OFF: the natural BAPBAP lifecycle handles match start once teamId fix is in place.
        // Forcing OnMatchStarted causes double-initialization which leads to rubber-banding.
        if (_forceOnMatchStartedEnabled?.Value != true)
        {
            _onMatchStartedForced = true;
            return;
        }
        // Only run on the dedicated server side. Calling [Server]-attributed methods on client throws or no-ops.
        if (!IsRunningAsDedicatedServer())
        {
            _onMatchStartedForced = true; // skip permanently on client
            return;
        }

        _forceMatchStartAttemptCount++;
        bool verbose = (_forceMatchStartAttemptCount % 300 == 1); // log every ~5s instead of 1s

        object? primary = FindPrimaryGameManager();
        if (primary == null)
        {
            if (verbose) LoggerInstance.Msg("[MapFix] force OnMatchStarted: no primary GameManager.");
            return;
        }

        // Wait until PreMatchManager has progressed past CharSelect/SpawnSelect.
        // PreMatchState: 0=WaitingForPlayers, 1=CharSelect, 2=SpawnSelect, 3=SpawnLock, 4=InGame
        // We only force OnMatchStarted when state >= SpawnLock (3) so we don't disrupt char/spawn selection.
        try
        {
            object? preMatchManager = GetMemberValue(primary, "preMatchManager");
            if (preMatchManager != null)
            {
                object? currentState = GetMemberValue(preMatchManager, "CurrentState") ?? GetMemberValue(preMatchManager, "currentState");
                if (currentState != null)
                {
                    int stateInt = Convert.ToInt32(currentState);
                    if (stateInt < 3)
                    {
                        if (verbose) LoggerInstance.Msg($"[MapFix] preMatchState={stateInt} (still in WaitingForPlayers/CharSelect/SpawnSelect). Waiting...");
                        return;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            if (verbose) LoggerInstance.Msg($"[MapFix] preMatchManager state check failed: {ex.GetBaseException().Message}");
        }

        object? matchStartedValue = GetMemberValue(primary, "matchStarted");
        if (matchStartedValue is bool ms && ms)
        {
            _onMatchStartedForced = true;
            LoggerInstance.Msg("[MapFix] matchStarted=true already, no force needed.");
            return;
        }

        object? gm = GetMemberValue(primary, "currentGameMode");
        if (gm == null)
        {
            if (verbose) LoggerInstance.Msg("[MapFix] force OnMatchStarted: currentGameMode is null.");
            return;
        }

        // Try a list of method names that BAPBAP gamemodes commonly use to start the match.
        string[] methods = { "OnMatchStarted", "OnMatchBegin" };
        foreach (string m in methods)
        {
            try
            {
                MethodInfo? mi = gm.GetType().GetMethod(m, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
                if (mi != null)
                {
                    mi.Invoke(gm, null);
                    LoggerInstance.Msg($"[MapFix] Forced gameMode.{m}() to kick off match timer / zone / audio.");
                }
            }
            catch (Exception ex)
            {
                LoggerInstance.Msg($"[MapFix] {m}() invocation failed: {ex.GetBaseException().Message}");
            }
        }

        // Also force StartZoneRound(0) to start the first zone shrink + reset crate respawn cycle.
        // IL2CPP reflection sometimes fails on strict GetMethod overload - search by name + 1-param.
        try
        {
            MethodInfo? startZone = null;
            foreach (var mi in gm.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                if (mi.Name == "StartZoneRound" && mi.GetParameters().Length == 1)
                {
                    startZone = mi;
                    break;
                }
            }
            if (startZone != null)
            {
                startZone.Invoke(gm, new object[] { 0 });
                LoggerInstance.Msg("[MapFix] Forced gameMode.StartZoneRound(0) to start zone + crate respawn loop.");
            }
            else
            {
                // Try via base type
                Type? brType = FindType("BAPBAP.Game.GameModeBattleRoyale");
                if (brType != null)
                {
                    foreach (var mi in brType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
                    {
                        if (mi.Name == "StartZoneRound" && mi.GetParameters().Length == 1)
                        {
                            startZone = mi;
                            break;
                        }
                    }
                    if (startZone != null && brType.IsAssignableFrom(gm.GetType()))
                    {
                        startZone.Invoke(gm, new object[] { 0 });
                        LoggerInstance.Msg("[MapFix] Forced gameMode.StartZoneRound(0) via BattleRoyale type.");
                    }
                    else
                    {
                        LoggerInstance.Msg($"[MapFix] StartZoneRound not found on {gm.GetType().FullName}. Match should still progress via natural lifecycle.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            LoggerInstance.Msg($"[MapFix] StartZoneRound(0) failed: {ex.GetBaseException().Message}");
        }

        _onMatchStartedForced = true;
    }

    private int _devPanelAttemptCount;
    private System.Collections.Generic.List<Type> _devPanelTypesPatched = new System.Collections.Generic.List<Type>();

    // Locker tab can throw IndexOutOfRange when a purchased asset isn't in the content database.
    // Wrap the failing methods with a Harmony finalizer so the exception is swallowed and the
    // UI doesn't crash. This prevents the UILobby.Initialise chain from breaking.
    private bool _lockerCrashGuardInstalled;
    private void TryInstallLockerCrashGuard()
    {
        if (_lockerCrashGuardInstalled) return;
        Type? lockerType = FindType("Il2CppBAPBAP.UI.UILobbyLockerTabPage") ?? FindType("BAPBAP.UI.UILobbyLockerTabPage");
        if (lockerType == null) return;
        MethodInfo? finalizer = typeof(CustomServerMod).GetMethod(nameof(LockerCrashFinalizer), BindingFlags.Static | BindingFlags.NonPublic);
        if (finalizer == null) return;

        int patched = 0;
        // Install finalizer ONLY (catches exceptions thrown by original method).
        // Do NOT install a prefix that re-invokes via reflection - that causes infinite recursion
        // because reflection invoke goes through Harmony's patched version again -> stack overflow.
        foreach (string mn in new[] { "AddContentEntry", "AddSkinEntry", "AddBannerEntry", "AddEmoteEntry", "AddTombstoneEntry", "UpdateDisplayedSkins", "SetSkinsEquipButtonState", "InitializeSelectPanelContent", "OnContentEntrySelected", "UpdateData" })
        {
            try
            {
                foreach (MethodInfo mi in lockerType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
                {
                    if (mi.Name == mn && PatchHarmonyFinalizer(mi, finalizer))
                    {
                        patched++;
                        break;
                    }
                }
            }
            catch { }
        }

        if (patched > 0)
        {
            _lockerCrashGuardInstalled = true;
            LoggerInstance.Msg($"[LockerGuard] Installed exception-swallow finalizer on {patched} locker method(s)");
        }
    }

    private static System.Exception? LockerCrashFinalizer(System.Exception __exception)
    {
        // Swallow all exceptions from locker UI methods so the game keeps running.
        // The user might see an empty/incomplete locker tab, but the lobby UI itself stays alive.
        return null;
    }

    private void TryInstallShopThrottle()
    {
        if (_shopThrottleInstalled) return;
        Type? shopType = FindType("Il2CppBAPBAP.UI.UILobbyShopTabPage") ?? FindType("BAPBAP.UI.UILobbyShopTabPage");
        if (shopType == null) return;
        MethodInfo? prefix = typeof(CustomServerMod).GetMethod(nameof(ShopThrottlePrefix), BindingFlags.Static | BindingFlags.NonPublic);
        if (prefix == null) return;
        int patched = 0;
        foreach (string mn in new[] { "SendShopRequest", "RequestShop", "FetchShop" })
        {
            try
            {
                MethodInfo? mi = shopType.GetMethod(mn, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
                if (mi != null && PatchHarmonyPrefix(mi, prefix)) patched++;
            }
            catch { }
        }
        if (patched > 0) { _shopThrottleInstalled = true; LoggerInstance.Msg($"[ShopThrottle] Patched {patched} method(s)"); }
    }

    private static bool ShopThrottlePrefix()
    {
        double now = (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
        if (now - _lastShopRequestUtcSeconds < 5.0) return false;
        _lastShopRequestUtcSeconds = now;
        return true;
    }

    private void TryInstallDevPanelHidePatch()
    {
        if (_allowDevPanelEntry?.Value == true) return;

        _devPanelAttemptCount++;
        bool verbose = (_devPanelAttemptCount % 120 == 1);

        // Search all candidate types - dev panel may be in different namespaces or use different names.
        // CRITICAL: only UI types! Manager types (DebugGameplayManager, DeveloperLobbyManager, DebugManager)
        // are part of game lifecycle - patching them blocks loading screen / match start.
        string[] typeCandidates = {
            "BAPBAP.UI.UIDeveloperLobby",
            "BAPBAP.UI.UIDevUtilities",
            "BAPBAP.UI.UIDevLobbyCharButton",
            "BAPBAP.UI.View_Lobby_Developer",
            "BAPBAP.UI.UIDeveloperPanel",
            "BAPBAP.UI.DeveloperPanel",
            "BAPBAP.UI.UIDevPanel",
            "BAPBAP.UI.UIInGameDevPanel",
            "BAPBAP.UI.UIInMatchDeveloperPanel",
            "BAPBAP.UI.UIDebugPanel",
            "BAPBAP.UI.UIInGameDebugPanel",
            "BAPBAP.UI.UIDebug",
            "BAPBAP.UI.UIDevTools",
            "BAPBAP.UI.UIInMatchDevTools"
        };

        // NOTE: We previously scanned and hid all instances every call. That FindLoadedUnityObjects()
        // is too expensive in IL2CPP. The Harmony postfix patches below will hide the panels on
        // OnEnable/Awake/Show/Open/Initialize/Start - that is sufficient.

        // Install permanent patches once per type
        if (_devPanelHidePatchInstalled) return;

        MethodInfo? hidePostfix = typeof(CustomServerMod).GetMethod(nameof(DevPanelHidePostfix), BindingFlags.Static | BindingFlags.NonPublic);
        if (hidePostfix == null) return;

        var newlyPatched = new System.Collections.Generic.List<string>();
        foreach (var name in typeCandidates)
        {
            Type? t = FindType(name);
            if (t == null) continue;
            if (_devPanelTypesPatched.Contains(t)) continue;

            int patchedMethodCount = 0;
            foreach (string mn in new[] { "OnEnable", "Awake", "Show", "Open", "Initialize", "Initialise", "Start" })
            {
                try
                {
                    MethodInfo? mi = t.GetMethod(mn, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
                    if (mi != null && PatchHarmonyPostfix(mi, hidePostfix))
                    {
                        patchedMethodCount++;
                    }
                }
                catch { }
            }
            if (patchedMethodCount > 0)
            {
                _devPanelTypesPatched.Add(t);
                newlyPatched.Add($"{t.Name}({patchedMethodCount})");
            }
        }

        if (newlyPatched.Count > 0)
        {
            LoggerInstance.Msg($"[DevPanel] Patched {newlyPatched.Count} type(s) for hide on activation: {string.Join(", ", newlyPatched)}");
        }
        else if (verbose)
        {
            // Fallback: scan whole assembly for Dev/Debug UI types
            try
            {
                Type? assemblyMarker = FindType("BAPBAP.UI.UILobbyPlayTabPage");
                if (assemblyMarker != null)
                {
                    var asm = assemblyMarker.Assembly;
                    var found = new System.Collections.Generic.List<string>();
                    foreach (var t in asm.GetTypes())
                    {
                        if (t == null || t.FullName == null) continue;
                        if (!t.FullName.StartsWith("BAPBAP.")) continue;
                        if (t.FullName.IndexOf("Dev", StringComparison.OrdinalIgnoreCase) < 0 &&
                            t.FullName.IndexOf("Debug", StringComparison.OrdinalIgnoreCase) < 0) continue;
                        found.Add(t.FullName);
                    }
                    if (found.Count > 0) LoggerInstance.Msg($"[DevPanel] attempt={_devPanelAttemptCount} no exact match. Available BAPBAP Dev/Debug types: [{string.Join(", ", found.Take(15))}]");
                    else LoggerInstance.Msg($"[DevPanel] attempt={_devPanelAttemptCount} no Dev/Debug types found at all in BAPBAP assembly.");
                }
            }
            catch (Exception ex) { LoggerInstance.Msg($"[DevPanel] type scan failed: {ex.GetBaseException().Message}"); }
        }

        // Mark installed once we've patched at least one type
        if (_devPanelTypesPatched.Count > 0)
        {
            _devPanelHidePatchInstalled = true;
        }
    }

    private static void DevPanelHidePostfix(object __instance)
    {
        try
        {
            if (__instance == null) return;
            var goProp = __instance.GetType().GetProperty("gameObject");
            object? go = goProp?.GetValue(__instance);
            if (go == null) return;
            var setActive = go.GetType().GetMethod("SetActive", new[] { typeof(bool) });
            setActive?.Invoke(go, new object[] { false });
        }
        catch { }
    }

    // ===== Mirror tick rate + KCP optimization (anti-rubber-band) =====
    // BAPBAP defaults to ~30Hz send rate which causes visible rubber-banding even at low ping.
    // We boost server send rate to 60Hz and force KCP NoDelay/Interval=10 for low-latency LAN.
    private bool _networkTuningApplied;
    private bool _networkTunerPatchInstalled;
    private int _networkTuneAttemptCount;
    private bool _networkTunerHarmonyInstalled;
    private bool _networkTunerLoggedAttempt;
    private bool _kcpTimeoutGuardApplied;
    private int _kcpTimeoutGuardAttemptCount;
    private bool _kcpTransportRuntimeLogged;
    private bool _interpDisablePatchInstalled;
    private int _interpScanAttempts;
    private void TryDisableLocalPlayerInterp()
    {
        if (_interpDisablePatchInstalled) return;
        _interpScanAttempts++;
        bool verbose = (_interpScanAttempts % 60 == 1);

        Type? networkBehType = FindType("Il2CppMirror.NetworkBehaviour") ?? FindType("Mirror.NetworkBehaviour");
        Type? ntType = FindType("Il2CppMirror.NetworkTransformBase") ?? FindType("Mirror.NetworkTransformBase") ?? FindType("Il2CppMirror.NetworkTransform") ?? FindType("Mirror.NetworkTransform");
        if (ntType == null)
        {
            if (verbose) LoggerInstance.Msg("[InterpFix] NetworkTransform type not found yet");
            return;
        }

        Array? all = FindLoadedUnityObjects(ntType);
        if (all == null || all.Length == 0)
        {
            if (verbose) LoggerInstance.Msg($"[InterpFix] no NetworkTransform instances yet (attempt={_interpScanAttempts})");
            return;
        }

        int patched = 0;
        foreach (object nt in all)
        {
            if (nt == null) continue;
            try
            {
                // Only modify if isOwned (local player)
                object? isOwned = GetMemberValue(nt, "isOwned") ?? GetMemberValue(nt, "hasAuthority");
                if (isOwned is bool owned && owned)
                {
                    SetMemberValue(nt, "interpolatePosition", false);
                    SetMemberValue(nt, "interpolateRotation", false);
                    SetMemberValue(nt, "interpolateScale", false);
                    patched++;
                }
            }
            catch { }
        }

        if (patched > 0)
        {
            _interpDisablePatchInstalled = true;
            LoggerInstance.Msg($"[InterpFix] Disabled interpolation on {patched} owner NetworkTransform(s)");
        }
    }

    private void TryInstallNetworkTunerHarmonyPatch()
    {
        if (_networkTunerHarmonyInstalled) return;
        if (_netTuneEnabledEntry?.Value == false) { _networkTunerHarmonyInstalled = true; return; }

        Type? gnmType = FindType("Il2CppBAPBAP.Network.GameNetworkManager") ?? FindType("Il2CppBAPBAP.Network.GameNetworkManager") ?? FindType("BAPBAP.Network.GameNetworkManager");
        if (!_networkTunerLoggedAttempt)
        {
            _networkTunerLoggedAttempt = true;
            LoggerInstance.Msg($"[NetTune] Looking for GameNetworkManager type... found={gnmType != null}");
            if (gnmType == null)
            {
                var found = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(a => { try { return a.GetTypes(); } catch { return Array.Empty<Type>(); } })
                    .Where(t => t.FullName != null && t.FullName.Contains("GameNetworkManager"))
                    .Select(t => t.FullName)
                    .Take(5)
                    .ToArray();
                LoggerInstance.Msg($"[NetTune] GameNetworkManager candidates: {string.Join(", ", found)}");
            }
        }
        if (gnmType == null) return;

        MethodInfo? postfix = typeof(CustomServerMod).GetMethod(nameof(NetworkTunerPostfix), BindingFlags.Static | BindingFlags.NonPublic);
        if (postfix == null) return;

        int patched = 0;
        foreach (string mn in new[] { "Awake", "Start", "OnStartServer", "OnStartClient" })
        {
            try
            {
                MethodInfo? mi = gnmType.GetMethod(mn, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
                if (mi != null && PatchHarmonyPostfix(mi, postfix)) patched++;
            }
            catch { }
        }
        if (patched > 0)
        {
            _networkTunerHarmonyInstalled = true;
            LoggerInstance.Msg($"[NetTune] Harmony postfix on {patched} GameNetworkManager hook(s).");
        }
    }

    // Static postfix - runs AFTER Mirror's GameNetworkManager initializes. Uses both standard
    // reflection AND IL2CPP-namespaced types to set Mirror static fields.
    private static void NetworkTunerPostfix()
    {
        try
        {
            // Try multiple type-name candidates. Il2CppInterop wraps Mirror types under Il2Cpp* namespace.
            Type[] candidates = new[]
            {
                FindTypeStatic("Mirror.NetworkServer"),
                FindTypeStatic("Il2CppMirror.NetworkServer"),
                FindTypeStatic("Mirror.NetworkClient"),
                FindTypeStatic("Il2CppMirror.NetworkClient")
            }.Where(t => t != null).Cast<Type>().ToArray();

            int hits = 0;
            foreach (var t in candidates)
            {
                try
                {
                    // sendRate
                    var sendRateProp = t.GetProperty("sendRate", BindingFlags.Static | BindingFlags.Public);
                    if (sendRateProp != null && sendRateProp.CanWrite) { sendRateProp.SetValue(null, 60); hits++; }
                    var sendRateField = t.GetField("sendRate", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                    if (sendRateField != null) { sendRateField.SetValue(null, 60); hits++; }

                    // tickRate (Mirror 78+)
                    var tickRateProp = t.GetProperty("tickRate", BindingFlags.Static | BindingFlags.Public);
                    if (tickRateProp != null && tickRateProp.CanWrite) { tickRateProp.SetValue(null, 60); hits++; }
                    var tickRateField = t.GetField("tickRate", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                    if (tickRateField != null) { tickRateField.SetValue(null, 60); hits++; }

                    // snapshotSettings - read struct, mutate, write back
                    var snapField = t.GetField("snapshotSettings", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                    if (snapField != null)
                    {
                        var snap = snapField.GetValue(null);
                        if (snap != null)
                        {
                            var bufField = snap.GetType().GetField("bufferTimeMultiplier");
                            if (bufField != null) { bufField.SetValue(snap, 1.0); hits++; }
                            var dynField = snap.GetType().GetField("dynamicAdjustment");
                            if (dynField != null) dynField.SetValue(snap, false);
                            snapField.SetValue(null, snap);
                        }
                    }
                }
                catch { }
            }

            if (hits > 0)
            {
                MelonLogger.Msg($"[NetTune] Harmony postfix tuned {hits} Mirror static field(s) on {candidates.Length} type candidate(s).");
            }
        }
        catch { }
    }

    // Static helper for use inside static postfix (where 'this' is unavailable).
    private static Type? FindTypeStatic(string fullName)
    {
        try
        {
            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                Type? t = asm.GetType(fullName, false);
                if (t != null) return t;
            }
        }
        catch { }
        return null;
    }

    private void TryApplyKcpTimeoutGuard()
    {
        if (_kcpTimeoutGuardApplied) return;

        _kcpTimeoutGuardAttemptCount++;
        bool verbose = _kcpTimeoutGuardAttemptCount % 60 == 1;

        int managerPatched = PatchGameNetworkManagerTransports(
            gameNetworkManagerType: null,
            source: "timeout-guard-manager",
            wsPort: _autoJoinWsPort,
            kcpPort: _autoJoinKcpPort,
            tcpPort: _autoJoinTcpPort,
            logIfSeen: verbose);

        if (managerPatched > 0)
        {
            _kcpTimeoutGuardApplied = true;
            LoggerInstance.Msg($"[KcpTimeoutGuard] Applied KCP timeout/port guard through GameNetworkManager transport(s); patched={managerPatched}.");
            return;
        }

        Type? kcpType = FindType("kcp2k.ThreadedKcpTransport") ??
                         FindType("Il2Cppkcp2k.ThreadedKcpTransport") ??
                         FindType("kcp2k.KcpTransport") ??
                         FindType("Il2Cppkcp2k.KcpTransport") ??
                         FindType("Mirror.KcpTransport");
        if (kcpType == null)
        {
            if (verbose) LoggerInstance.Msg($"[KcpTimeoutGuard] KcpTransport type not loaded yet (attempt={_kcpTimeoutGuardAttemptCount}).");
            return;
        }

        Array? transports = FindLoadedUnityObjects(kcpType);
        if (transports == null || transports.Length == 0)
        {
            if (verbose) LoggerInstance.Msg($"[KcpTimeoutGuard] no KcpTransport instances yet (attempt={_kcpTimeoutGuardAttemptCount}).");
            return;
        }

        int changed = 0;
        foreach (object transport in transports)
        {
            if (transport == null) continue;
            bool applied = SetMemberValue(transport, "Timeout", KcpTransportTimeoutMillis);
            applied |= SetMemberValue(transport, "timeout", KcpTransportTimeoutMillis);
            if (applied) changed++;
        }

        if (changed > 0)
        {
            _kcpTimeoutGuardApplied = true;
            LoggerInstance.Msg($"[KcpTimeoutGuard] Applied KCP timeout={KcpTransportTimeoutMillis}ms on {changed}/{transports.Length} transport instance(s) type={kcpType.FullName}.");
            return;
        }

        if (verbose)
        {
            LoggerInstance.Msg($"[KcpTimeoutGuard] found {transports.Length} KcpTransport instance(s), but no writable Timeout member.");
        }
    }

    private void TryApplyNetworkTuning()
    {
        if (_networkTuningApplied) return;
        // ENABLED by default (anti-rubber-band). Set INI 'NetTuneEnabled=false' to opt out.
        // Tunes Mirror snapshotSettings.bufferTimeMultiplier=1, sendRate=30, KCP NoDelay.
        if (_netTuneEnabledEntry?.Value == false)
        {
            _networkTuningApplied = true;
            return;
        }
        _networkTuneAttemptCount++;
        bool verbose = (_networkTuneAttemptCount % 300 == 1);

        Type? networkServerType = FindType("Il2CppMirror.NetworkServer") ?? FindType("Il2CppMirror.NetworkServer") ?? FindType("Mirror.NetworkServer");
        Type? networkClientType = FindType("Il2CppMirror.NetworkClient") ?? FindType("Il2CppMirror.NetworkClient") ?? FindType("Mirror.NetworkClient");
        bool tuned = false;

        // Explicit Mirror.NetworkServer.snapshotSettings static field access (in addition to loop below).
        // In IL2CPP, sometimes only the static field exists and not a property; ensure we hit it directly.
        try
        {
            FieldInfo? serverSnapField = networkServerType?.GetField("snapshotSettings", BindingFlags.Static | BindingFlags.Public)
                                       ?? networkServerType?.GetField("snapshotSettings", BindingFlags.Static | BindingFlags.NonPublic);
            object? serverSnap = serverSnapField?.GetValue(null);
            if (serverSnap != null)
            {
                FieldInfo? bufField = serverSnap.GetType().GetField("bufferTimeMultiplier");
                if (bufField != null) { bufField.SetValue(serverSnap, 1.0); tuned = true; }
                FieldInfo? dynField = serverSnap.GetType().GetField("dynamicAdjustment");
                dynField?.SetValue(serverSnap, false);
            }
        }
        catch (Exception ex)
        {
            if (verbose) LoggerInstance.Msg($"[NetTune] Explicit server snapshot tune failed: {ex.GetBaseException().Message}");
        }

        // 1) Reduce snapshot interpolation buffer time on both server and client.
        //    snapshotSettings.bufferTimeMultiplier defaults to 2 -> playback delay = 2x sendInterval.
        //    At sendInterval=0.05 (20Hz default) that's 100ms perceived lag = "server is slow" feel.
        //    Setting to 1 = sendInterval delay only = ~50ms (at 20Hz) or ~33ms (at 30Hz).
        try
        {
            foreach (Type? t in new[] { networkServerType, networkClientType })
            {
                if (t == null) continue;
                FieldInfo? snapshotField = t.GetField("snapshotSettings", BindingFlags.Static | BindingFlags.Public);
                object? snapshotSettings = snapshotField?.GetValue(null);
                if (snapshotSettings != null)
                {
                    FieldInfo? bufField = snapshotSettings.GetType().GetField("bufferTimeMultiplier");
                    if (bufField != null)
                    {
                        bufField.SetValue(snapshotSettings, 1.0);  // halve the playback delay
                        tuned = true;
                    }
                    PropertyInfo? bufProp = snapshotSettings.GetType().GetProperty("bufferTimeMultiplier");
                    if (bufProp != null && bufProp.CanWrite)
                    {
                        bufProp.SetValue(snapshotSettings, 1.0);
                        tuned = true;
                    }
                    // Also disable dynamic adjustment which can re-grow the buffer
                    FieldInfo? dynField = snapshotSettings.GetType().GetField("dynamicAdjustment");
                    dynField?.SetValue(snapshotSettings, false);
                }
            }
        }
        catch (Exception ex)
        {
            if (verbose) LoggerInstance.Msg($"[NetTune] Snapshot tune failed: {ex.GetBaseException().Message}");
        }

        // 2) Bump sendRate from 20Hz to 30Hz (BAPBAP often uses 20Hz default).
        //    More frequent updates = smaller per-tick deltas = less jitter when buffer reduced.
        try
        {
            if (networkServerType != null)
            {
                PropertyInfo? sendRateProp = networkServerType.GetProperty("sendRate", BindingFlags.Static | BindingFlags.Public);
                if (sendRateProp != null && sendRateProp.CanWrite) { sendRateProp.SetValue(null, 30); tuned = true; }
                FieldInfo? sendRate = networkServerType.GetField("sendRate", BindingFlags.Static | BindingFlags.Public);
                if (sendRate != null) { sendRate.SetValue(null, 30); tuned = true; }
            }
        }
        catch (Exception ex)
        {
            if (verbose) LoggerInstance.Msg($"[NetTune] SendRate tune failed: {ex.GetBaseException().Message}");
        }

        // 3) KCP transport: NoDelay + low interval for low-latency local UDP
        try
        {
            Type? kcpType = FindType("kcp2k.ThreadedKcpTransport") ??
                            FindType("Il2Cppkcp2k.ThreadedKcpTransport") ??
                            FindType("Il2Cppkcp2k.KcpTransport") ??
                            FindType("kcp2k.KcpTransport") ??
                            FindType("Mirror.KcpTransport");
            if (kcpType != null)
            {
                Array? all = FindLoadedUnityObjects(kcpType);
                if (all != null)
                {
                    foreach (object kcp in all)
                    {
                        if (kcp == null) continue;
                        // Conservative low-latency localhost tuning
                        SetMemberValue(kcp, "NoDelay", true);
                        SetMemberValue(kcp, "Interval", (uint)10);         // back to 10ms (was 1 = too aggressive)
                        SetMemberValue(kcp, "FastResend", 2);
                        SetMemberValue(kcp, "CongestionWindow", false);
                        SetMemberValue(kcp, "SendWindowSize", (uint)4096); // back to defaults
                        SetMemberValue(kcp, "ReceiveWindowSize", (uint)4096);
                        SetMemberValue(kcp, "Timeout", KcpTransportTimeoutMillis);
                        tuned = true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            if (verbose) LoggerInstance.Msg($"[NetTune] KCP tune failed: {ex.GetBaseException().Message}");
        }

        // 4) sendInterval: try setting NetworkServer.sendInterval directly (independent of sendRate)
        //    Lower sendInterval = more frequent updates = smaller per-tick lag
        try
        {
            Type? netSrvType = FindType("Il2CppMirror.NetworkServer") ?? FindType("Mirror.NetworkServer");
            if (netSrvType != null)
            {
                FieldInfo? sendIntervalField = netSrvType.GetField("sendInterval", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                if (sendIntervalField != null) { sendIntervalField.SetValue(null, 1f / 60f); tuned = true; }
                PropertyInfo? sendIntervalProp = netSrvType.GetProperty("sendInterval", BindingFlags.Static | BindingFlags.Public);
                if (sendIntervalProp != null && sendIntervalProp.CanWrite) { sendIntervalProp.SetValue(null, 1f / 60f); tuned = true; }
            }
        }
        catch (Exception ex)
        {
            if (verbose) LoggerInstance.Msg($"[NetTune] sendInterval tune failed: {ex.GetBaseException().Message}");
        }

        if (tuned)
        {
            _networkTuningApplied = true;
            LoggerInstance.Msg("[NetTune] Mirror bufferTimeMultiplier=1, sendRate=30, KCP NoDelay applied (reduces server-feel-slow lag).");
        }
        else if (verbose)
        {
            LoggerInstance.Msg($"[NetTune] attempt={_networkTuneAttemptCount} no tunable fields found yet.");
        }
    }

    // ===== Crate Respawn Disable (server-side) =====
    private bool _crateRespawnDisabled;
    private int _crateScanAttemptCount;
    private void TryDisableCrateRespawn()
    {
        if (_crateRespawnDisabled) return;
        if (!IsRunningAsDedicatedServer()) return;
        if (!_currentGameModeRebound) return; // wait until match is set up

        _crateScanAttemptCount++;
        bool verbose = (_crateScanAttemptCount % 300 == 1);

        Type? entitySpawnerType = FindType("BAPBAP.Entities.EntitySpawner");
        if (entitySpawnerType == null)
        {
            if (verbose) LoggerInstance.Msg("[CrateFix] EntitySpawner type not found yet.");
            return;
        }

        Array? all = FindLoadedUnityObjects(entitySpawnerType);
        if (all == null || all.Length == 0)
        {
            if (verbose) LoggerInstance.Msg($"[CrateFix] no EntitySpawner instances loaded yet (attempt={_crateScanAttemptCount}).");
            return;
        }

        int disabled = 0;
        foreach (object spawner in all)
        {
            if (spawner == null) continue;
            try
            {
                // Set _respawnAble = false to stop the respawn cycle
                if (SetMemberValue(spawner, "_respawnAble", false))
                {
                    disabled++;
                }
                else if (SetMemberValue(spawner, "respawnAble", false))
                {
                    disabled++;
                }
                // Also set respawnDuration high to be safe
                SetMemberValue(spawner, "respawnDuration", float.MaxValue);
            }
            catch (Exception ex)
            {
                if (verbose) LoggerInstance.Msg($"[CrateFix] failed to disable on one spawner: {ex.GetBaseException().Message}");
            }
        }

        if (disabled > 0)
        {
            _crateRespawnDisabled = true;
            LoggerInstance.Msg($"[CrateFix] Disabled crate respawn on {disabled}/{all.Length} EntitySpawner instance(s).");
        }
        else if (verbose)
        {
            LoggerInstance.Msg($"[CrateFix] EntitySpawner has {all.Length} instances but none could be disabled. Field name may differ.");
        }
    }

    // ===== MATCH FOUND duplicate notification dedup =====
    // BAPBAP has both LobbyController and MatchmakingController playing the splash on QUEUE_MATCHED.
    // We patch LobbyController.PlayMatchFoundSequence to no-op when MatchmakingController already played.
    private bool _matchFoundDedupPatchInstalled;
    private static double _lastMatchFoundPlayedUtcSeconds;
    private void TryInstallMatchFoundDedupPatch()
    {
        if (_matchFoundDedupPatchInstalled) return;

        Type? lobbyCtrlType = FindType("BAPBAP.UI.LobbyController");
        Type? matchCtrlType = FindType("BAPBAP.UI.MatchmakingController");
        if (lobbyCtrlType == null && matchCtrlType == null) return;

        MethodInfo? prefix = typeof(CustomServerMod).GetMethod(nameof(MatchFoundDedupPrefix), BindingFlags.Static | BindingFlags.NonPublic);
        if (prefix == null) return;

        int patched = 0;
        foreach (Type? t in new[] { lobbyCtrlType, matchCtrlType })
        {
            if (t == null) continue;
            try
            {
                MethodInfo? mi = t.GetMethod("PlayMatchFoundSequence", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if (mi != null && PatchHarmonyPrefix(mi, prefix))
                {
                    patched++;
                }
            }
            catch { }
        }

        if (patched > 0)
        {
            _matchFoundDedupPatchInstalled = true;
            LoggerInstance.Msg($"[MatchFoundDedup] Installed dedup prefix on {patched} PlayMatchFoundSequence target(s).");
        }
    }

    private static bool MatchFoundDedupPrefix()
    {
        // Skip if same notification was played within last 3 seconds
        double now = (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
        if (now - _lastMatchFoundPlayedUtcSeconds < 3.0)
        {
            return false; // skip original method - dedup
        }
        _lastMatchFoundPlayedUtcSeconds = now;
        return true; // run original
    }

    private void TryRecoverStaleLobbyQueueUi()
    {
        string sceneName = "";
        try { sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name ?? ""; } catch { }
        bool lobbyScene =
            sceneName.Contains("Main", StringComparison.OrdinalIgnoreCase) ||
            sceneName.Contains("Lobby", StringComparison.OrdinalIgnoreCase) ||
            sceneName.Contains("Menu", StringComparison.OrdinalIgnoreCase);
        if (!lobbyScene)
        {
            _lobbyQueueInQueueSince = 0f;
            _lobbyQueueIdleProbe = null;
            return;
        }

        if (HasLivePrematchContext())
        {
            return;
        }

        if (!TryGetLobbyReadyButtonCounts(out int totalButtons, out int inQueueButtons) || inQueueButtons <= 0)
        {
            _lobbyQueueInQueueSince = 0f;
            _lobbyQueueIdleProbe = null;
            return;
        }

        float now = Time.realtimeSinceStartup;
        if (_lobbyQueueInQueueSince <= 0f)
        {
            _lobbyQueueInQueueSince = now;
            return;
        }

        float stuckSeconds = now - _lobbyQueueInQueueSince;
        if (stuckSeconds < 8f)
        {
            return;
        }

        if (_lobbyQueueIdleProbe == null)
        {
            string apiHost = GetConfiguredApiHost().TrimEnd('/');
            _lobbyQueueIdleProbe = Task.Run(() => IsRemoteQueueDefinitelyIdleAsync(apiHost));
            return;
        }

        if (!_lobbyQueueIdleProbe.IsCompleted)
        {
            return;
        }

        bool serverIdle = false;
        try { serverIdle = _lobbyQueueIdleProbe.Result; } catch { }
        _lobbyQueueIdleProbe = null;
        if (!serverIdle)
        {
            return;
        }

        int stopped = InvokeMatchmakingStopOnControllers();
        int resetButtons = ForceReadyButtonsToWaiting();
        int cancelSends = SendCancelMatchmakingViaSocket();
        _lobbyQueueInQueueSince = 0f;

        if (_lobbyQueueRecoveryLogCount < 12)
        {
            _lobbyQueueRecoveryLogCount++;
            LoggerInstance.Msg(
                $"[QueueRecovery] Repaired stale lobby queue UI after {stuckSeconds:0.0}s: buttons={inQueueButtons}/{totalButtons} reset={resetButtons} controllers={stopped} cancelSends={cancelSends}.");
        }
    }

    private static async Task<bool> IsRemoteQueueDefinitelyIdleAsync(string apiHost)
    {
        try
        {
            using HttpClient client = new() { Timeout = TimeSpan.FromSeconds(2) };
            using JsonDocument queueDoc = await JsonDocument.ParseAsync(
                await client.GetStreamAsync($"{apiHost}/api/queue/status")).ConfigureAwait(false);
            JsonElement queueRoot = queueDoc.RootElement;
            bool isActive = queueRoot.TryGetProperty("isActive", out JsonElement activeElement) && activeElement.ValueKind == JsonValueKind.True;
            int playerCount = queueRoot.TryGetProperty("playerCount", out JsonElement playerCountElement) && playerCountElement.TryGetInt32(out int parsedCount)
                ? parsedCount
                : 0;
            if (isActive || playerCount > 0)
            {
                return false;
            }

            using JsonDocument rootDoc = await JsonDocument.ParseAsync(
                await client.GetStreamAsync(apiHost)).ConfigureAwait(false);
            if (rootDoc.RootElement.TryGetProperty("lobbies", out JsonElement lobbies) && lobbies.ValueKind == JsonValueKind.Array)
            {
                foreach (JsonElement lobby in lobbies.EnumerateArray())
                {
                    if (lobby.TryGetProperty("starting", out JsonElement starting) && starting.ValueKind == JsonValueKind.True)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        catch
        {
            return false;
        }
    }

    private static bool HasLivePrematchContext()
    {
        try
        {
            foreach (string typeName in new[] { "BAPBAP.Game.PreMatchManager", "Il2CppBAPBAP.Game.PreMatchManager" })
            {
                Type? type = FindType(typeName);
                if (type == null) continue;
                Array? all = FindLoadedUnityObjects(type);
                if (all != null && all.Length > 0) return true;
            }
        }
        catch { }
        return false;
    }

    private static bool TryGetLobbyReadyButtonCounts(out int totalButtons, out int inQueueButtons)
    {
        totalButtons = 0;
        inQueueButtons = 0;
        Type? type = FindType("BAPBAP.UI.View_Lobby_ReadyButton") ?? FindType("Il2CppBAPBAP.UI.View_Lobby_ReadyButton");
        if (type == null) return false;
        Array? buttons = FindLoadedUnityObjects(type);
        if (buttons == null || buttons.Length == 0) return false;

        foreach (object? button in buttons)
        {
            if (button == null) continue;
            totalButtons++;
            object? state = GetMemberValue(button, "CurrentState") ?? GetMemberValue(button, "_currentState");
            if (state != null && string.Equals(state.ToString(), "InQueue", StringComparison.OrdinalIgnoreCase))
            {
                inQueueButtons++;
            }
        }

        return totalButtons > 0;
    }

    private static int ForceReadyButtonsToWaiting()
    {
        Type? type = FindType("BAPBAP.UI.View_Lobby_ReadyButton") ?? FindType("Il2CppBAPBAP.UI.View_Lobby_ReadyButton");
        if (type == null) return 0;
        Array? buttons = FindLoadedUnityObjects(type);
        if (buttons == null || buttons.Length == 0) return 0;

        int reset = 0;
        foreach (object? button in buttons)
        {
            if (button == null) continue;
            object? state = GetMemberValue(button, "CurrentState") ?? GetMemberValue(button, "_currentState");
            if (state == null || !string.Equals(state.ToString(), "InQueue", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            object? waiting = null;
            try
            {
                Type stateType = state.GetType();
                if (stateType.IsEnum)
                {
                    waiting = Enum.Parse(stateType, "WaitingToReady");
                }
            }
            catch { }

            if (waiting != null)
            {
                try { InvokeInstance(button, "SetState", waiting); reset++; }
                catch { }
            }
        }

        return reset;
    }

    private static int InvokeMatchmakingStopOnControllers()
    {
        Type? type = FindType("BAPBAP.UI.MatchmakingController") ?? FindType("Il2CppBAPBAP.UI.MatchmakingController");
        if (type == null) return 0;
        Array? controllers = FindLoadedUnityObjects(type);
        if (controllers == null || controllers.Length == 0) return 0;

        int invoked = 0;
        foreach (object? controller in controllers)
        {
            if (controller == null) continue;
            try
            {
                InvokeInstance(controller, "OnMatchMakingStop");
                invoked++;
            }
            catch { }
        }

        return invoked;
    }

    private static int SendCancelMatchmakingViaSocket()
    {
        Type? lobbyNetworkClientType = FindType("BAPBAP.Network.LobbyNetworkClient") ?? FindType("Il2CppBAPBAP.Network.LobbyNetworkClient");
        if (lobbyNetworkClientType == null) return 0;
        Array? lobbyClients = FindLoadedUnityObjects(lobbyNetworkClientType);
        if (lobbyClients == null || lobbyClients.Length == 0) return 0;

        int sent = 0;
        foreach (object? lobbyClient in lobbyClients)
        {
            if (lobbyClient == null) continue;
            object? ctrlMgr = GetMemberValue(lobbyClient, "_controllerManager")
                            ?? GetMemberValue(lobbyClient, "controllerManager");
            object? wsClient = ctrlMgr != null
                ? (GetMemberValue(ctrlMgr, "Ws") ?? GetMemberValue(ctrlMgr, "_ws"))
                : null;
            wsClient ??= GetMemberValue(lobbyClient, "_webSocketClient")
                      ?? GetMemberValue(lobbyClient, "_wsClient");
            if (wsClient == null) continue;

            try
            {
                InvokeInstance(wsClient, "Send", "{\"event\":\"CANCEL_MATCHMAKING\",\"payload\":{}}");
                sent++;
            }
            catch { }
        }

        return sent;
    }

    // ===== Augment select wait duration extension =====
    // UIAugments.augmentSelectWaitDuration is the timer for auto-confirm. Default ~5s = too short during respawn.
    // Extend to 30s so player has time to actually click an augment.
    private bool _augmentTimerExtended;
    private int _augmentScanAttemptCount;
    private readonly HashSet<int> _autoSelectedAugmentUiInstances = new();
    private readonly Dictionary<int, int> _autoAugmentCommandAttempts = new();
    private int _autoAugmentScanAttemptCount;
    private bool _autoAugmentErrorLogged;
    private void TryExtendAugmentSelectTimer()
    {
        if (_augmentTimerExtended) return;
        _augmentScanAttemptCount++;
        bool verbose = (_augmentScanAttemptCount % 300 == 1);

        Type? uiAugmentsType = FindType("BAPBAP.UI.UIAugments");
        if (uiAugmentsType == null)
        {
            if (verbose) LoggerInstance.Msg("[AugmentFix] UIAugments type not found yet.");
            return;
        }

        Array? all = FindLoadedUnityObjects(uiAugmentsType);
        if (all == null || all.Length == 0)
        {
            if (verbose) LoggerInstance.Msg($"[AugmentFix] no UIAugments instances loaded yet (attempt={_augmentScanAttemptCount}).");
            return;
        }

        int extended = 0;
        foreach (object inst in all)
        {
            if (inst == null) continue;
            try
            {
                // Set augmentSelectWaitDuration to 30 (default ~5)
                if (SetMemberValue(inst, "augmentSelectWaitDuration", 30f)) extended++;
                // Reroll wait too
                SetMemberValue(inst, "augmentRerollWaitDuration", 30f);
            }
            catch { }
        }

        if (extended > 0)
        {
            _augmentTimerExtended = true;
            LoggerInstance.Msg($"[AugmentFix] Extended augmentSelectWaitDuration on {extended}/{all.Length} UIAugments instance(s) to 30s.");
        }
    }

    private void TryAutoSelectOpenAugment()
    {
        _autoAugmentScanAttemptCount++;
        bool verbose = _autoAugmentScanAttemptCount % 120 == 1;

        if (TryAutoSelectOpenAugmentViaPlayerAugments(verbose))
        {
            return;
        }

        if (TryAutoSelectOpenAugmentViaUiManagers(verbose))
        {
            return;
        }

        Type? uiAugmentsType = FindType("BAPBAP.UI.UIAugments");
        if (uiAugmentsType == null)
        {
            if (verbose) LoggerInstance.Msg("[AugmentFix] auto-select: UIAugments type not found yet.");
            return;
        }

        object[] all = FindLoadedUnityComponents(uiAugmentsType).ToArray();
        if (all.Length == 0)
        {
            if (verbose) LoggerInstance.Msg("[AugmentFix] auto-select: no UIAugments instances loaded yet.");
            return;
        }

        foreach (object inst in all)
        {
            if (TryAutoSelectUiAugments(inst, "UIAugments scan", verbose))
            {
                return;
            }
        }
    }

    private bool TryAutoSelectOpenAugmentViaUiManagers(bool verbose)
    {
        Type? uiManagerType = FindType("BAPBAP.UI.UIManager");
        if (uiManagerType == null)
        {
            if (verbose) LoggerInstance.Msg("[AugmentFix] auto-select: UIManager type not found yet.");
            return false;
        }

        object[] managers = FindLoadedUnityComponents(uiManagerType).ToArray();
        if (managers.Length == 0)
        {
            if (verbose) LoggerInstance.Msg("[AugmentFix] auto-select: no UIManager instances loaded yet.");
            return false;
        }

        foreach (object manager in managers)
        {
            object? uiAugments = GetMemberValueSafe(manager, "uiAugments");
            if (TryAutoSelectUiAugments(uiAugments, "UIManager.uiAugments", verbose))
            {
                return true;
            }
        }

        return false;
    }

    private bool TryAutoSelectUiAugments(object? uiAugments, string source, bool verbose)
    {
        if (uiAugments == null)
        {
            return false;
        }

        int instanceId = GetUnityInstanceId(uiAugments);
        if (!IsAugmentSelectionVisible(uiAugments))
        {
            _autoSelectedAugmentUiInstances.Remove(instanceId);
            return false;
        }

        if (_autoSelectedAugmentUiInstances.Contains(instanceId))
        {
            return false;
        }

        try
        {
            if (TryInvokeInstanceIfPresent(uiAugments, "ClSelectAugment", 0))
            {
                _autoSelectedAugmentUiInstances.Add(instanceId);
                LoggerInstance.Msg($"[AugmentFix] Auto-selected first augment via {source}.ClSelectAugment(0) for automated custom-server test run.");
                return true;
            }

            if (TrySelectFirstAugmentElement(uiAugments))
            {
                _autoSelectedAugmentUiInstances.Add(instanceId);
                LoggerInstance.Msg($"[AugmentFix] Auto-selected first augment via {source}.UIAugmentElement.SelectedAugment() fallback for automated custom-server test run.");
                return true;
            }
        }
        catch (Exception ex)
        {
            if (verbose)
            {
                LoggerInstance.Warning($"[AugmentFix] auto-select via {source} failed: {ex.GetBaseException().Message}");
            }
        }

        return false;
    }

    private bool TryAutoSelectOpenAugmentViaPlayerAugments(bool verbose)
    {
        object? playerAugments = FindLocalPlayerAugmentsForClient(out string source);
        if (playerAugments == null)
        {
            if (verbose) LoggerInstance.Msg("[AugmentFix] auto-select: no local PlayerAugments found.");
            return false;
        }

        if (TryAutoSelectUiAugments(GetMemberValueSafe(playerAugments, "uiAugments"), $"{source}.uiAugments", verbose))
        {
            return true;
        }

        int instanceId = GetUnityInstanceId(playerAugments);
        if (_autoSelectedAugmentUiInstances.Contains(instanceId))
        {
            return false;
        }

        object? selection = GetMemberValueSafe(playerAugments, "CurrentSelection") ??
                            GetMemberValueSafe(playerAugments, "currentSelection");
        bool hasSelection = selection != null;
        _autoAugmentCommandAttempts.TryGetValue(instanceId, out int attempts);
        if (!hasSelection && attempts >= 6)
        {
            return false;
        }

        if (!hasSelection && verbose)
        {
            LoggerInstance.Msg($"[AugmentFix] auto-select: PlayerAugments found via {source}, current selection is not readable yet; trying guarded command attempt={attempts + 1}.");
        }

        try
        {
            if (TryInvokeInstanceIfPresent(playerAugments, "CmdSelectAugment", 0))
            {
                _autoAugmentCommandAttempts[instanceId] = attempts + 1;
                if (hasSelection)
                {
                    _autoSelectedAugmentUiInstances.Add(instanceId);
                }

                LoggerInstance.Msg($"[AugmentFix] Auto-selected first augment via PlayerAugments.CmdSelectAugment(0), source={source}, currentSelection={hasSelection}.");
                return true;
            }
        }
        catch (Exception ex)
        {
            LoggerInstance.Warning($"[AugmentFix] PlayerAugments.CmdSelectAugment(0) failed: {ex.GetBaseException().Message}");
        }

        return false;
    }

    private static object? FindLocalPlayerAugmentsForClient(out string source)
    {
        source = "none";
        object? player = FindBestLocalPlayerManagerForClient();
        object? playerAugments = GetMemberValueSafe(player, "playerAugments");
        if (playerAugments != null)
        {
            source = "PlayerManager.playerAugments";
            return playerAugments;
        }

        Type? playerAugmentsType = FindType("BAPBAP.Game.PlayerAugments");
        object[] all = playerAugmentsType == null
            ? Array.Empty<object>()
            : FindLoadedUnityComponents(playerAugmentsType).ToArray();
        if (all.Length == 0)
        {
            return null;
        }

        object? local = null;
        foreach (object? candidate in all)
        {
            if (candidate == null) continue;
            if (GetBoolMember(candidate, "isLocalPlayer") ||
                GetBoolMember(candidate, "hasAuthority") ||
                GetBoolMember(candidate, "isOwned"))
            {
                source = "owned PlayerAugments scan";
                return candidate;
            }

            local ??= candidate;
        }

        if (all.Length == 1)
        {
            source = "single PlayerAugments scan";
            return local;
        }

        return null;
    }

    private static object? FindBestLocalPlayerManagerForClient()
    {
        Type? playerManagerType = FindType("BAPBAP.Player.PlayerManager");
        object[] players = playerManagerType == null
            ? Array.Empty<object>()
            : FindLoadedUnityComponents(playerManagerType).ToArray();
        if (players.Length == 0)
        {
            return null;
        }

        object? first = null;
        foreach (object? player in players)
        {
            if (player == null) continue;
            first ??= player;

            if (GetBoolMember(player, "isLocalPlayer") ||
                GetBoolMember(player, "hasAuthority") ||
                GetBoolMember(player, "isOwned"))
            {
                return player;
            }
        }

        return players.Length == 1 ? first : null;
    }

    private static IEnumerable<object> FindLoadedUnityComponents(Type componentType)
    {
        HashSet<int> seen = new();
        Array? direct = FindLoadedUnityObjects(componentType);
        if (direct == null)
        {
            yield break;
        }

        foreach (object? item in direct)
        {
            if (item == null)
            {
                continue;
            }

            int id = GetUnityInstanceId(item);
            if (seen.Add(id))
            {
                yield return item;
            }
        }
    }

    private static bool GetBoolMember(object? instance, string name)
    {
        object? value = GetMemberValueSafe(instance, name);
        return value is bool flag && flag;
    }

    private static bool IsAugmentSelectionVisible(object uiAugments)
    {
        if (GetMemberValueSafe(uiAugments, "_showingAugments") is bool showing && showing)
        {
            return true;
        }

        object? holder = GetMemberValueSafe(uiAugments, "augmentSelectHolder");
        if (IsUnityObjectVisible(holder))
        {
            return true;
        }

        object? group = GetMemberValueSafe(uiAugments, "augmentsCanvasGroup");
        if (group is CanvasGroup canvasGroup && canvasGroup.gameObject.activeInHierarchy && canvasGroup.alpha > 0.01f)
        {
            return true;
        }

        return false;
    }

    private static bool IsUnityObjectVisible(object? value)
    {
        try
        {
            switch (value)
            {
                case GameObject gameObject:
                    return gameObject.activeInHierarchy;
                case Component component:
                    return component.gameObject.activeInHierarchy;
                default:
                    object? gameObjectValue = value == null ? null : GetMemberValue(value, "gameObject");
                    return gameObjectValue is GameObject go && go.activeInHierarchy;
            }
        }
        catch
        {
            return false;
        }
    }

    private static bool TrySelectFirstAugmentElement(object uiAugments)
    {
        object? elements = GetMemberValue(uiAugments, "augmentElements");
        foreach (object? element in EnumerateObjects(elements))
        {
            if (element == null) continue;
            return TryInvokeInstanceIfPresent(element, "SelectedAugment") ||
                   TryInvokeInstanceIfPresent(element, "SelectAugment") ||
                   TryInvokeButtonOnClick(GetMemberValue(element, "_button") ?? GetMemberValue(element, "button"));
        }

        return false;
    }

    private static IEnumerable<object?> EnumerateObjects(object? value)
    {
        if (value == null) yield break;

        if (value is Array array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                yield return array.GetValue(i);
            }

            yield break;
        }

        if (value is System.Collections.IEnumerable enumerable && value is not string)
        {
            foreach (object? item in enumerable)
            {
                yield return item;
            }

            yield break;
        }

        object? countObj = GetMemberValue(value, "Count") ?? GetMemberValue(value, "Length");
        if (countObj == null)
        {
            yield break;
        }

        int count;
        try { count = Convert.ToInt32(countObj); }
        catch { yield break; }

        PropertyInfo? indexer = value.GetType().GetProperty("Item", new[] { typeof(int) });
        if (indexer == null)
        {
            yield break;
        }

        for (int i = 0; i < count; i++)
        {
            object? item = null;
            try { item = indexer.GetValue(value, new object[] { i }); }
            catch { }
            yield return item;
        }
    }

    private static bool TryInvokeButtonOnClick(object? button)
    {
        object? onClick = button == null ? null : GetMemberValue(button, "onClick");
        return onClick != null && TryInvokeInstanceIfPresent(onClick, "Invoke");
    }

    private static int GetUnityInstanceId(object value)
    {
        try
        {
            if (value is Object unityObject)
            {
                return unityObject.GetInstanceID();
            }
        }
        catch { }

        return RuntimeHelpers.GetHashCode(value);
    }

    private void TryAutoEndDedicatedMatch()
    {
        if (_autoEndAfterSeconds is not > 0f || _autoEndInvoked)
        {
            return;
        }

        object? gameManager = FindPrimaryGameManager();
        if (gameManager == null)
        {
            return;
        }

        object? matchStartedValue = GetMemberValue(gameManager, "matchStarted");
        if (matchStartedValue is not bool matchStarted || !matchStarted)
        {
            return;
        }

        if (!_autoEndMatchObserved)
        {
            _autoEndMatchObserved = true;
            _autoEndMatchStartAt = Time.realtimeSinceStartup;
            LoggerInstance.Msg($"Observed official match start; auto-end scheduled in {_autoEndAfterSeconds.Value:0.##}s.");
            return;
        }

        if (Time.realtimeSinceStartup - _autoEndMatchStartAt < _autoEndAfterSeconds.Value)
        {
            return;
        }

        try
        {
            InvokeInstance(gameManager, "EndMatch", 1);
            _autoEndInvoked = true;
            LoggerInstance.Msg("Requested dedicated match auto-end with winnerTeamId=1.");
        }
        catch (Exception ex)
        {
            _autoEndInvoked = true;
            LoggerInstance.Warning($"Dedicated match auto-end failed: {ex.GetBaseException().Message}");
        }
    }

    private object? FindPrimaryGameManager()
    {
        Type? gameNetworkManagerType = FindType("Il2CppBAPBAP.Network.GameNetworkManager") ?? FindType("Il2CppBAPBAP.Network.GameNetworkManager") ?? FindType("BAPBAP.Network.GameNetworkManager");
        if (gameNetworkManagerType != null)
        {
            foreach (object networkManager in FindGameNetworkManagers(gameNetworkManagerType))
            {
                object? gameManager = GetMemberValue(networkManager, "gameManager");
                if (gameManager != null)
                {
                    return gameManager;
                }
            }
        }

        Type? gameManagerType = FindType("BAPBAP.Game.GameManager");
        if (gameManagerType == null)
        {
            return null;
        }

        const BindingFlags staticFlags = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
        object? instance = gameManagerType.GetProperty("Instance", staticFlags)?.GetValue(null) ??
                           gameManagerType.GetField("Instance", staticFlags)?.GetValue(null);
        if (instance != null)
        {
            return instance;
        }

        Array? gameManagers = FindLoadedUnityObjects(gameManagerType);
        return gameManagers?.Length > 0 ? gameManagers.GetValue(0) : null;
    }

    private void TryConfigureDedicatedGameManagers()
    {
        if (!_dedicatedProcess)
        {
            return;
        }

        Type? gameManagerType = FindType("BAPBAP.Game.GameManager");
        if (gameManagerType == null)
        {
            return;
        }

        int configured = 0;

        Type? gameNetworkManagerType = FindType("Il2CppBAPBAP.Network.GameNetworkManager") ?? FindType("Il2CppBAPBAP.Network.GameNetworkManager") ?? FindType("BAPBAP.Network.GameNetworkManager");
        if (gameNetworkManagerType != null)
        {
            foreach (object networkManager in FindGameNetworkManagers(gameNetworkManagerType))
            {
                if (ConfigureDedicatedGameManager(GetMemberValue(networkManager, "gameManager")))
                {
                    configured++;
                }
            }
        }

        Array? gameManagers = FindLoadedUnityObjects(gameManagerType);
        if (gameManagers != null)
        {
            foreach (object gameManager in gameManagers)
            {
                if (ConfigureDedicatedGameManager(gameManager))
                {
                    configured++;
                }
            }
        }

        const BindingFlags staticFlags = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
        object? instance = gameManagerType.GetProperty("Instance", staticFlags)?.GetValue(null) ??
                           gameManagerType.GetField("Instance", staticFlags)?.GetValue(null);
        if (ConfigureDedicatedGameManager(instance))
        {
            configured++;
        }

        if (configured > 0)
        {
            if (!_dedicatedGameManagerConfigured)
            {
                _dedicatedGameManagerConfigured = true;
                SetBootstrapRepairStatus(
                    $"Extended dedicated matchmaking wait windows to {DedicatedMatchWaitForPlayersSeconds:0}s on {configured} GameManager instance(s).",
                    logRepeated: true);
            }
        }
    }

    private static bool ConfigureDedicatedGameManager(object? gameManager)
    {
        if (gameManager == null)
        {
            return false;
        }

        bool changed = false;
        changed |= RaiseFloatMember(gameManager, "matchWaitForStartMaxTimeMatchmaking", DedicatedMatchWaitForPlayersSeconds);
        changed |= RaiseFloatMember(gameManager, "matchLateJoinTimeMatchmaking", DedicatedLateJoinSeconds);
        return changed;
    }

    private static bool RaiseFloatMember(object instance, string name, float minimumValue)
    {
        object? current = GetMemberValue(instance, name);
        if (current is float value && value >= minimumValue)
        {
            return false;
        }

        return SetMemberValue(instance, name, minimumValue);
    }

    private static bool RaiseIntMember(object instance, string name, int minimumValue)
    {
        if (TryGetIntMember(instance, name, out int value) && value >= minimumValue)
        {
            return false;
        }

        return SetMemberValue(instance, name, minimumValue);
    }

    private static int GetIntMemberOrDefault(object? instance, string name, int fallback)
    {
        return TryGetIntMember(instance, name, out int value) ? value : fallback;
    }

    private static string DescribeMatchTiming(object? mgd)
    {
        if (mgd == null)
        {
            return "null";
        }

        return $"charSelectMillis={GetIntMemberOrDefault(mgd, "charSelectMillis", -1)} " +
               $"spawnSelectMillis={GetIntMemberOrDefault(mgd, "spawnSelectMillis", -1)} " +
               $"spawnShowMillis={GetIntMemberOrDefault(mgd, "spawnShowMillis", -1)}";
    }

    private static string DescribeQueueMatchedPlayers(object? qmd)
    {
        object? players = GetMemberValueSafe(qmd, "players");
        if (players == null)
        {
            return "null";
        }

        List<string> parts = new();
        foreach (object? player in EnumerateListLike(players))
        {
            parts.Add(DescribeMatchmakingPlayer(player));
            if (parts.Count >= 8)
            {
                break;
            }
        }

        return parts.Count == 0 ? "empty" : string.Join(" | ", parts);
    }

    private static string DescribeAvailableCharacters(object? qmd)
    {
        object? available = GetMemberValueSafe(qmd, "availableCharacters");
        if (available == null)
        {
            return "null";
        }

        List<string> parts = new();
        foreach (object? item in EnumerateListLike(available))
        {
            if (item == null)
            {
                continue;
            }

            parts.Add(item.ToString() ?? "null");
            if (parts.Count >= 24)
            {
                break;
            }
        }

        return parts.Count == 0 ? "empty" : string.Join(",", parts);
    }

    private bool IsMirrorServerActive(object gameNetworkManager)
    {
        try
        {
            // Check GameNetworkManager.IsActive()
            object? active = InvokeInstance(gameNetworkManager, "IsActive");
            if (active is bool isActive && isActive)
            {
                return true;
            }

            // Also check Mirror.NetworkServer.active via reflection
            Type? networkServerType = FindType("Il2CppMirror.NetworkServer") ?? FindType("Il2CppMirror.NetworkServer") ?? FindType("Mirror.NetworkServer");
            if (networkServerType != null)
            {
                PropertyInfo? activeProp = networkServerType.GetProperty("active", BindingFlags.Static | BindingFlags.Public);
                if (activeProp != null)
                {
                    object? serverActive = activeProp.GetValue(null);
                    if (serverActive is bool mirrorActive && mirrorActive)
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
        object? gameManager = GetMemberValue(gameNetworkManager, "gameManager");
        if (gameManager == null)
        {
            return false;
        }

        object? gameMode = GetMemberValue(gameManager, "currentGameMode") ??
                           GetMemberValue(gameManager, "battleRoyale") ??
                           GetMemberValue(gameManager, "ffa");
        if (gameMode == null)
        {
            return false;
        }

        object? currentEnvManager = GetMemberValue(gameMode, "currentEnvManager");
        object? spawnPoints = GetMemberValue(gameMode, "spawnPoints");
        object? isLoading = GetMemberValue(gameMode, "isLoading");
        if (isLoading is bool loading && loading)
        {
            return false;
        }
        if (currentEnvManager == null || spawnPoints == null)
        {
            return false;
        }

        // CRITICAL: also validate that spawnPoints is non-empty. Without this, the map duplicate
        // (no NavMesh, empty spawn list) is treated as ready and the match starts on a broken instance.
        if (spawnPoints is System.Collections.ICollection spc && spc.Count == 0)
        {
            return false;
        }

        return true;
    }

    private void PatchLoadedGameModeLevelNames()
    {
        Type? gameModeType = FindType("BAPBAP.Game.GameMode");
        if (gameModeType == null)
        {
            return;
        }

        int patched = 0;

        Type? gameNetworkManagerType = FindType("Il2CppBAPBAP.Network.GameNetworkManager") ?? FindType("Il2CppBAPBAP.Network.GameNetworkManager") ?? FindType("BAPBAP.Network.GameNetworkManager");
        if (gameNetworkManagerType != null)
        {
            foreach (object networkManager in FindGameNetworkManagers(gameNetworkManagerType))
            {
                patched += PatchGameModesFromGameManager(GetMemberValue(networkManager, "gameManager"));
            }
        }

        Type? gameManagerType = FindType("BAPBAP.Game.GameManager");
        if (gameManagerType != null)
        {
            Array? gameManagers = FindLoadedUnityObjects(gameManagerType);
            if (gameManagers != null)
            {
                foreach (object gameManager in gameManagers)
                {
                    patched += PatchGameModesFromGameManager(gameManager);
                }
            }

            const BindingFlags staticFlags = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
            object? instance = gameManagerType.GetProperty("Instance", staticFlags)?.GetValue(null) ??
                               gameManagerType.GetField("Instance", staticFlags)?.GetValue(null);
            patched += PatchGameModesFromGameManager(instance);
        }

        Array? gameModes = FindLoadedUnityObjects(gameModeType);
        if (gameModes != null)
        {
            foreach (object gameMode in gameModes)
            {
                patched += PatchGameModeObject(gameMode);
            }
        }

        if (patched > 0 && !_gameModeLevelNamesPatched)
        {
            _gameModeLevelNamesPatched = true;
            SetBootstrapRepairStatus($"Patched {patched} GameMode levelNames array(s) for custom matches.", logRepeated: true);
        }
    }

    private int PatchGameModesFromGameManager(object? gameManager)
    {
        if (gameManager == null)
        {
            return 0;
        }

        int patched = 0;
        patched += PatchGameModeObject(GetMemberValue(gameManager, "currentGameMode"));
        patched += PatchGameModeObject(GetMemberValue(gameManager, "battleRoyale"));
        patched += PatchGameModeObject(GetMemberValue(gameManager, "ffa"));
        return patched;
    }

    private int PatchGameModeObject(object? gameMode)
    {
        if (gameMode == null)
        {
            return 0;
        }

        try
        {
            PropertyInfo? property = gameMode.GetType().GetProperty(
                "levelNames",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            Type? arrayType = property?.PropertyType;
            if (arrayType == null)
            {
                return 0;
            }

            object? il2CppNames = Activator.CreateInstance(arrayType, new object[] { KnownLevelNames });
            return il2CppNames != null && SetMemberValue(gameMode, "levelNames", il2CppNames) ? 1 : 0;
        }
        catch (Exception ex)
        {
            SetBootstrapRepairStatus($"GameMode levelNames patch failed: {ex.GetBaseException().Message}", logRepeated: false);
            return 0;
        }
    }

    private static bool HasUsableStringArray(object? value)
    {
        if (value == null)
        {
            return false;
        }

        PropertyInfo? lengthProperty = value.GetType().GetProperty("Length", BindingFlags.Instance | BindingFlags.Public);
        if (lengthProperty?.GetValue(value) is not int length || length <= 1)
        {
            return false;
        }

        PropertyInfo? itemProperty = value.GetType().GetProperty("Item", BindingFlags.Instance | BindingFlags.Public);
        if (itemProperty == null)
        {
            return false;
        }

        for (int i = 0; i < Math.Min(length, 4); i++)
        {
            if (!string.IsNullOrWhiteSpace(itemProperty.GetValue(value, new object[] { i }) as string))
            {
                return true;
            }
        }

        return false;
    }

    private static object? CreateIl2CppPayload(Type payloadType, string json)
    {
        using JsonDocument document = JsonDocument.Parse(json);
        return CreateIl2CppObject(payloadType, document.RootElement);
    }

    private static object? CreateIl2CppObject(Type objectType, JsonElement element)
    {
        if (element.ValueKind != JsonValueKind.Object)
        {
            return null;
        }

        object? instance = Activator.CreateInstance(objectType);
        if (instance == null)
        {
            return null;
        }

        foreach (JsonProperty jsonProperty in element.EnumerateObject())
        {
            SetJsonMemberValue(instance, objectType, jsonProperty.Name, jsonProperty.Value);
        }

        return instance;
    }

    private static void SetJsonMemberValue(object instance, Type objectType, string name, JsonElement value)
    {
        const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.IgnoreCase;

        PropertyInfo? property = objectType.GetProperty(name, flags);
        if (property?.GetIndexParameters().Length == 0 && property.CanWrite)
        {
            object? converted = ConvertJsonValue(value, property.PropertyType);
            property.SetValue(instance, converted);
            return;
        }

        FieldInfo? field = objectType.GetField(name, flags);
        if (field != null)
        {
            object? converted = ConvertJsonValue(value, field.FieldType);
            field.SetValue(instance, converted);
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
            return value.ValueKind == JsonValueKind.Number ? value.GetInt32() : 0;
        }

        if (targetType == typeof(float))
        {
            return value.ValueKind == JsonValueKind.Number ? value.GetSingle() : 0f;
        }

        if (targetType == typeof(double))
        {
            return value.ValueKind == JsonValueKind.Number ? value.GetDouble() : 0d;
        }

        if (targetType == typeof(bool))
        {
            return value.ValueKind == JsonValueKind.True ||
                   (value.ValueKind == JsonValueKind.String && bool.TryParse(value.GetString(), out bool parsed) && parsed);
        }

        if (IsIl2CppStructArray(targetType))
        {
            Type elementType = targetType.GenericTypeArguments[0];
            if (elementType == typeof(int))
            {
                int[] values = value.ValueKind == JsonValueKind.Array
                    ? value.EnumerateArray().Select(item => item.ValueKind == JsonValueKind.Number ? item.GetInt32() : 0).ToArray()
                    : Array.Empty<int>();
                return Activator.CreateInstance(targetType, new object[] { values });
            }
        }

        if (IsIl2CppList(targetType))
        {
            object? list = Activator.CreateInstance(targetType);
            if (list == null)
            {
                return null;
            }

            MethodInfo? add = targetType.GetMethod("Add", BindingFlags.Instance | BindingFlags.Public);
            Type itemType = targetType.GenericTypeArguments[0];
            if (add != null && value.ValueKind == JsonValueKind.Array)
            {
                foreach (JsonElement item in value.EnumerateArray())
                {
                    object? converted = ConvertJsonValue(item, itemType);
                    add.Invoke(list, new[] { converted });
                }
            }

            return list;
        }

        if (value.ValueKind == JsonValueKind.Object)
        {
            return CreateIl2CppObject(targetType, value);
        }

        return null;
    }

    private static bool IsIl2CppStructArray(Type type)
    {
        return type.IsGenericType &&
               string.Equals(type.GetGenericTypeDefinition().FullName, "Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppStructArray`1", StringComparison.Ordinal);
    }

    private static bool IsIl2CppList(Type type)
    {
        return type.IsGenericType &&
               string.Equals(type.GetGenericTypeDefinition().FullName, "Il2CppSystem.Collections.Generic.List`1", StringComparison.Ordinal);
    }

    private void TryRepairDedicatedWebServer(int httpPort)
    {
        if (IsTcpPortOpen("127.0.0.1", httpPort, 50))
        {
            _bootstrapRepairComplete = true;
            SetBootstrapRepairStatus($"Game bootstrap HTTP listener is active.", logRepeated: false);
            return;
        }

        Type? gameManagerType = FindType("BAPBAP.Game.GameManager");
        Type? webServerType = FindType("BAPBAP.Network.WebServer");
        if (gameManagerType == null || webServerType == null)
        {
            SetBootstrapRepairStatus($"Waiting for game bootstrap types. GameManager={gameManagerType != null} WebServer={webServerType != null}", logRepeated: false);
            return;
        }

        Array? managers = FindLoadedUnityObjects(gameManagerType);
        if (managers == null || managers.Length == 0)
        {
            SetBootstrapRepairStatus("Waiting for GameManager instance before starting bootstrap WebServer.", logRepeated: false);
            return;
        }

        foreach (object manager in managers)
        {
            try
            {
                object? webServer = GetMemberValue(manager, "webServer");
                if (webServer == null || !webServerType.IsInstanceOfType(webServer))
                {
                    webServer = FindOrCreateWebServer(manager, webServerType);
                    if (webServer != null)
                    {
                        SetMemberValue(manager, "webServer", webServer);
                    }
                }

                if (webServer == null)
                {
                    SetBootstrapRepairStatus("GameManager exists but no WebServer component could be attached.", logRepeated: false);
                    continue;
                }

                PatchWebServerRuntime(webServer);
                InvokeInstance(webServer, "PreAwake", httpPort);
                PatchWebServerRuntime(webServer);
                InvokeInstance(webServer, "StartWebserver", manager);
                PatchWebServerRuntime(webServer);

                if (!IsTcpPortOpen("127.0.0.1", httpPort, 100))
                {
                    InvokeInstance(webServer, "StartHttpListener");
                }

                if (IsTcpPortOpen("127.0.0.1", httpPort, 250))
                {
                    _bootstrapRepairComplete = true;
                    SetBootstrapRepairStatus($"Started game bootstrap WebServer on 127.0.0.1:{httpPort}.", logRepeated: true);
                    return;
                }

                object? listenPort = GetMemberValue(webServer, "_listenPort");
                object? listener = GetMemberValue(webServer, "_listener");
                SetBootstrapRepairStatus($"Called WebServer bootstrap repair but port is still closed. listenPort={listenPort ?? "null"} listener={(listener != null)}", logRepeated: false);
            }
            catch (Exception ex)
            {
                SetBootstrapRepairStatus($"Dedicated WebServer repair failed: {ex.GetBaseException().Message}", logRepeated: false);
            }
        }
    }

    private object? FindOrCreateWebServer(object gameManager, Type webServerType)
    {
        Array? existing = FindLoadedUnityObjects(webServerType);
        if (existing != null)
        {
            foreach (object item in existing)
            {
                if (item != null && webServerType.IsInstanceOfType(item))
                {
                    return item;
                }
            }
        }

        object? gameObject = GetMemberValue(gameManager, "gameObject");
        if (gameObject == null)
        {
            return null;
        }

        MethodInfo? addComponent = gameObject.GetType()
            .GetMethods(BindingFlags.Instance | BindingFlags.Public)
            .FirstOrDefault(method =>
            {
                if (method.Name != "AddComponent")
                {
                    return false;
                }

                ParameterInfo[] parameters = method.GetParameters();
                return parameters.Length == 1 && parameters[0].ParameterType == typeof(Type);
            });

        return addComponent?.Invoke(gameObject, new object[] { webServerType });
    }

    private void SetBootstrapRepairStatus(string status, bool logRepeated)
    {
        _statusText = status;
        if (logRepeated || !string.Equals(_lastBootstrapRepairStatus, status, StringComparison.Ordinal))
        {
            _lastBootstrapRepairStatus = status;
            LoggerInstance.Msg(status);
        }
    }

    private static bool IsTcpPortOpen(string host, int port, int timeoutMs)
    {
        try
        {
            using TcpClient client = new();
            IAsyncResult result = client.BeginConnect(host, port, null, null);
            bool connected = result.AsyncWaitHandle.WaitOne(timeoutMs);
            if (!connected)
            {
                return false;
            }

            client.EndConnect(result);
            return client.Connected;
        }
        catch
        {
            return false;
        }
    }

    private static object? GetMemberValue(object instance, string name)
    {
        const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        Type type = instance.GetType();
        PropertyInfo? property = type.GetProperty(name, flags);
        if (property?.GetIndexParameters().Length == 0 && property.CanRead)
        {
            return property.GetValue(instance);
        }

        FieldInfo? field = type.GetField(name, flags);
        return field?.GetValue(instance);
    }

    private static object? GetMemberValue(Type type, string name)
    {
        const BindingFlags flags = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
        PropertyInfo? property = type.GetProperty(name, flags);
        if (property?.GetIndexParameters().Length == 0 && property.CanRead)
        {
            return property.GetValue(null);
        }

        FieldInfo? field = type.GetField(name, flags);
        return field?.GetValue(null);
    }

    private static bool SetMemberValue(object instance, string name, object? value)
    {
        const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        Type type = instance.GetType();
        PropertyInfo? property = type.GetProperty(name, flags);
        if (property?.GetIndexParameters().Length == 0 && property.CanWrite)
        {
            property.SetValue(instance, value);
            return true;
        }

        FieldInfo? field = type.GetField(name, flags);
        if (field == null)
        {
            return false;
        }

        field.SetValue(instance, value);
        return true;
    }

    private static object? InvokeInstance(object instance, string methodName, params object?[] args)
    {
        const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        MethodInfo? method = instance.GetType()
            .GetMethods(flags)
            .FirstOrDefault(candidate =>
            {
                if (candidate.Name != methodName)
                {
                    return false;
                }

                ParameterInfo[] parameters = candidate.GetParameters();
                return parameters.Length == args.Length;
            });

        return method?.Invoke(instance, args);
    }

    private static bool TryInvokeInstanceIfPresent(object instance, string methodName, params object?[] args)
    {
        const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        MethodInfo? method = instance.GetType()
            .GetMethods(flags)
            .FirstOrDefault(candidate =>
            {
                if (candidate.Name != methodName)
                {
                    return false;
                }

                ParameterInfo[] parameters = candidate.GetParameters();
                return parameters.Length == args.Length;
            });

        if (method == null)
        {
            return false;
        }

        method.Invoke(instance, args);
        return true;
    }

    private bool PatchHarmonyPostfix(MethodBase original, MethodInfo postfix)
    {
        object? harmony = GetHarmonyInstanceReflective();
        if (harmony == null)
        {
            return false;
        }

        Type? harmonyMethodType = FindType("HarmonyLib.HarmonyMethod") ??
                                  harmony.GetType().Assembly.GetType("HarmonyLib.HarmonyMethod");
        if (harmonyMethodType == null)
        {
            return false;
        }

        object? harmonyMethod = Activator.CreateInstance(harmonyMethodType, postfix);
        if (harmonyMethod == null)
        {
            return false;
        }

        MethodInfo? patchMethod = harmony.GetType()
            .GetMethods(BindingFlags.Instance | BindingFlags.Public)
            .Where(method => method.Name == "Patch")
            .FirstOrDefault(method =>
            {
                ParameterInfo[] parameters = method.GetParameters();
                return parameters.Length >= 3 &&
                       typeof(MethodBase).IsAssignableFrom(parameters[0].ParameterType) &&
                       parameters.Any(parameter => parameter.Name == "postfix");
            });

        if (patchMethod == null)
        {
            return false;
        }

        ParameterInfo[] patchParameters = patchMethod.GetParameters();
        object?[] args = new object?[patchParameters.Length];
        args[0] = original;

        for (int i = 1; i < patchParameters.Length; i++)
        {
            if (patchParameters[i].Name == "postfix")
            {
                args[i] = harmonyMethod;
            }
        }

        patchMethod.Invoke(harmony, args);
        return true;
    }

    private bool PatchHarmonyPrefix(MethodBase original, MethodInfo prefix)
    {
        object? harmony = GetHarmonyInstanceReflective();
        if (harmony == null)
        {
            return false;
        }

        Type? harmonyMethodType = FindType("HarmonyLib.HarmonyMethod") ??
                                  harmony.GetType().Assembly.GetType("HarmonyLib.HarmonyMethod");
        if (harmonyMethodType == null)
        {
            return false;
        }

        object? harmonyMethod = Activator.CreateInstance(harmonyMethodType, prefix);
        if (harmonyMethod == null)
        {
            return false;
        }

        MethodInfo? patchMethod = harmony.GetType()
            .GetMethods(BindingFlags.Instance | BindingFlags.Public)
            .Where(method => method.Name == "Patch")
            .FirstOrDefault(method =>
            {
                ParameterInfo[] parameters = method.GetParameters();
                return parameters.Length >= 2 &&
                       typeof(MethodBase).IsAssignableFrom(parameters[0].ParameterType) &&
                       parameters.Any(parameter => parameter.Name == "prefix");
            });

        if (patchMethod == null)
        {
            return false;
        }

        ParameterInfo[] patchParameters = patchMethod.GetParameters();
        object?[] args = new object?[patchParameters.Length];
        args[0] = original;

        for (int i = 1; i < patchParameters.Length; i++)
        {
            if (patchParameters[i].Name == "prefix")
            {
                args[i] = harmonyMethod;
            }
        }

        patchMethod.Invoke(harmony, args);
        return true;
    }

    private bool PatchHarmonyFinalizer(MethodBase original, MethodInfo finalizer)
    {
        object? harmony = GetHarmonyInstanceReflective();
        if (harmony == null) return false;

        Type? harmonyMethodType = FindType("HarmonyLib.HarmonyMethod") ??
                                  harmony.GetType().Assembly.GetType("HarmonyLib.HarmonyMethod");
        if (harmonyMethodType == null) return false;

        object? harmonyMethod = Activator.CreateInstance(harmonyMethodType, finalizer);
        if (harmonyMethod == null) return false;

        MethodInfo? patchMethod = harmony.GetType()
            .GetMethods(BindingFlags.Instance | BindingFlags.Public)
            .Where(method => method.Name == "Patch")
            .FirstOrDefault(method =>
            {
                ParameterInfo[] parameters = method.GetParameters();
                return parameters.Length >= 2 &&
                       typeof(MethodBase).IsAssignableFrom(parameters[0].ParameterType) &&
                       parameters.Any(parameter => parameter.Name == "finalizer");
            });

        if (patchMethod == null) return false;

        ParameterInfo[] patchParameters = patchMethod.GetParameters();
        object?[] args = new object?[patchParameters.Length];
        args[0] = original;
        for (int i = 1; i < patchParameters.Length; i++)
        {
            if (patchParameters[i].Name == "finalizer")
                args[i] = harmonyMethod;
        }

        patchMethod.Invoke(harmony, args);
        return true;
    }

    private object? GetHarmonyInstanceReflective()
    {
        try
        {
            PropertyInfo? property = typeof(MelonBase).GetProperty(
                "HarmonyInstance",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            return property?.GetValue(this);
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

    private static void PreAwakeManagerAwakePrefix(object __instance)
    {
        s_active?.PatchPreAwakeManagerNetworkRuntime(__instance, "PreAwakeManager.Awake.prefix");
    }

    private static void PreAwakeManagerAwakePostfix(object __instance)
    {
        s_active?.PatchPreAwakeManagerNetworkRuntime(__instance, "PreAwakeManager.Awake.postfix");
    }

    private static void HttpClientConstructorPrefix(ref string host)
    {
        s_active?.RewriteHttpClientHost(ref host);
    }

    private static void HttpClientConstructorPostfix(object __instance)
    {
        s_active?.PatchHttpClientRuntime(__instance);
    }

    private static void HttpClientSendRequestPrefix(object __instance)
    {
        s_active?.PatchHttpClientRuntime(__instance);
    }

    private static void ControllerManagerConstructorPostfix(object __instance)
    {
        s_active?.PatchControllerManagerNetworkRuntime(__instance, "ControllerManager.ctor");
    }

    private static void LobbyNetworkClientNetworkPostfix(object __instance, MethodBase __originalMethod)
    {
        string source = __originalMethod == null ? "LobbyNetworkClient.lifecycle" : $"LobbyNetworkClient.{__originalMethod.Name}";
        s_active?.PatchLobbyNetworkClientRuntime(__instance, source);
    }

    private static void NetworkConfigServerPostfix(object __result)
    {
        PatchServerConfig(__result);
    }

    private static void GameModeLevelNamesPrefix(object __instance)
    {
        s_active?.PatchGameModeObject(__instance);
    }

    private static void AddPlayerMatchmakingPrefix(
        object? __instance,
        object? conn,
        object? player,
        object? mpd,
        object? teammatePlayerIds,
        ref int __state)
    {
        CustomServerMod? active = s_active;
        if (active == null)
        {
            return;
        }

        try
        {
            __state = TryGetIntMember(mpd, "charId", out int requestedCharId) ? requestedCharId : -1;
            if (requestedCharId == MedusaCharacterId)
            {
                object? resolvedPlayer = ResolvePlayerManagerForMatchmaking(player, mpd, __instance);
                bool charPatched = SetMemberValueBestEffort(mpd, "charId", MedusaCharacterId);
                bool skinPatched = SetMemberValueBestEffort(mpd, "skinAssetId", -1);
                bool playerPatched = ForceMedusaPlayerManager(resolvedPlayer, "AddPlayerMatchmaking.prefix.resolvedPlayer");
                active.LoggerInstance.Msg(
                    "Medusa AddPlayerMatchmaking prefix guard: " +
                    $"charPatched={charPatched} " +
                    $"skinPatched={skinPatched} " +
                    $"playerPatched={playerPatched} " +
                    $"playerType={DescribeObjectType(player)} " +
                    $"resolvedType={DescribeObjectType(resolvedPlayer)} " +
                    $"mpd={DescribeMatchmakingPlayer(mpd)}");
            }

            active.LoggerInstance.Msg(
                "AddPlayerMatchmaking preflight: " +
                $"connNull={conn == null} " +
                $"playerNull={player == null} " +
                $"playerType={DescribeObjectType(player)} " +
                $"mpd={DescribeMatchmakingPlayer(mpd)} " +
                $"teammates={GetCountOrNull(teammatePlayerIds)} " +
                $"gm={DescribeGameManager(__instance)}");
        }
        catch (Exception ex)
        {
            active.LoggerInstance.Warning($"AddPlayerMatchmaking preflight logging failed: {ex.GetBaseException().Message}");
        }
    }

    private static void AddPlayerMatchmakingPostfix(
        object? __instance,
        object? conn,
        object? player,
        object? mpd,
        object? teammatePlayerIds,
        int __state)
    {
        CustomServerMod? active = s_active;
        if (active == null)
        {
            return;
        }

        int requestedCharId = __state;
        if (requestedCharId != MedusaCharacterId)
        {
            if (requestedCharId >= 0 &&
                TryGetIntMember(mpd, "charId", out int mutatedCharId) &&
                mutatedCharId == MedusaCharacterId)
            {
                bool restored = SetMemberValueBestEffort(mpd, "charId", requestedCharId);
                active.LoggerInstance.Warning(
                    "Medusa AddPlayerMatchmaking post guard skipped: " +
                    $"originalRequested={requestedCharId} mutatedMpdChar={mutatedCharId} restoredOriginal={restored} " +
                    $"mpd={DescribeMatchmakingPlayer(mpd)}");
            }
            return;
        }

        try
        {
            object? resolvedPlayer = ResolvePlayerManagerForMatchmaking(player, mpd, __instance);
            bool charPatched = SetMemberValueBestEffort(mpd, "charId", MedusaCharacterId);
            bool skinPatched = SetMemberValueBestEffort(mpd, "skinAssetId", -1);
            bool playerPatched = ForceMedusaPlayerManager(resolvedPlayer, "AddPlayerMatchmaking.postfix.resolvedPlayer");
            object? loadedPlayer = TryFindLoadedPlayerManager(
                TryGetIntMember(mpd, "playerId", out int playerId) ? playerId : -1,
                TryGetStringMember(mpd, "accountId"),
                TryGetStringMember(mpd, "gameAuthId"));
            bool loadedPlayerPatched = !ReferenceEquals(loadedPlayer, resolvedPlayer) &&
                                       ForceMedusaPlayerManager(loadedPlayer, "AddPlayerMatchmaking.postfix.loaded");
            int queuePatched = ForceMedusaQueuedPlayerData(__instance, mpd);
            bool prematchPatched = ForceMedusaPrematchSelection(__instance, loadedPlayer ?? resolvedPlayer ?? player, mpd);

            active.LoggerInstance.Msg(
                "Medusa AddPlayerMatchmaking post guard: " +
                $"requested={__state} " +
                $"charPatched={charPatched} " +
                $"skinPatched={skinPatched} " +
                $"playerPatched={playerPatched} " +
                $"loadedPlayerPatched={loadedPlayerPatched} " +
                $"queuePatched={queuePatched} " +
                $"prematchPatched={prematchPatched} " +
                $"playerType={DescribeObjectType(player)} " +
                $"resolvedType={DescribeObjectType(resolvedPlayer)} " +
                $"loadedType={DescribeObjectType(loadedPlayer)} " +
                $"mpd={DescribeMatchmakingPlayer(mpd)}");
        }
        catch (Exception ex)
        {
            active.LoggerInstance.Warning($"Medusa AddPlayerMatchmaking guard failed: {ex.GetBaseException().Message}");
        }
    }

    private static void LoginControllerAutoGuestPostfix(object __instance)
    {
        CustomServerMod? active = s_active;
        if (active == null || __instance == null)
        {
            return;
        }

        active._pendingAutoGuestLogins.Enqueue(new AutoGuestLoginRequest(__instance, "LoginController"));
    }

    private static bool CharacterSelectPrefix(object __instance)
    {
        if (__instance == null)
        {
            return false;
        }

        try
        {
            string typeName = __instance.GetType().FullName ?? __instance.GetType().Name;
            if (typeName.Contains("UILobbyCharacterSelectPage"))
            {
                object? entries = GetMemberValue(__instance, "_charListingEntries");
                if (entries == null)
                {
                    s_active?.LoggerInstance.Warning($"CharacterSelectPrefix: UILobbyCharacterSelectPage method {__instance.GetType().Name} skipped because _charListingEntries is null.");
                    return false;
                }
            }
            else if (typeName.Contains("UILobbyPlayTabPage"))
            {
                Type? charSelectType = FindType("BAPBAP.UI.UILobbyCharacterSelectPage");
                if (charSelectType != null)
                {
                    Array? objects = FindLoadedUnityObjects(charSelectType);
                    if (objects != null && objects.Length > 0)
                    {
                        object? charSelectPage = objects.GetValue(0);
                        if (charSelectPage != null)
                        {
                            object? entries = GetMemberValue(charSelectPage, "_charListingEntries");
                            if (entries == null)
                            {
                                s_active?.LoggerInstance.Warning("CharacterSelectPrefix: UILobbyPlayTabPage method skipped because UILobbyCharacterSelectPage._charListingEntries is null.");
                                return false;
                            }
                        }
                    }
                    else
                    {
                        s_active?.LoggerInstance.Warning("CharacterSelectPrefix: UILobbyPlayTabPage method skipped because no UILobbyCharacterSelectPage instance exists yet.");
                        return false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            s_active?.LoggerInstance.Error($"Error in CharacterSelectPrefix: {ex}");
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
            string[] criticalFieldNames = { "_charSelectButtons", "_actions", "_data", "_lobbyDataModel", "_matchStartPanel" };
            foreach (string name in criticalFieldNames)
            {
                object? val = GetMemberValue(__instance, name);
                if (val == null)
                {
                    s_active?.LoggerInstance.Warning($"MatchCharacterSelectPrefix: skipped method on {__instance.GetType().Name} because {name} is null.");
                    return false;
                }
            }
        }
        catch (Exception ex)
        {
            s_active?.LoggerInstance.Error($"Error in MatchCharacterSelectPrefix: {ex}");
        }

        return true;
    }

    private static void WebSocketClientSendPrefix(object __instance, ref string __0)
    {
        try
        {
            s_active?.RewriteOutgoingLobbySelection(__instance, ref __0);
        }
        catch (Exception ex)
        {
            if (_webSocketSelectionRewriteLogCount < 8)
            {
                _webSocketSelectionRewriteLogCount++;
                s_active?.LoggerInstance.Warning($"[CharacterSelection] WebSocket Send patch failed: {ex.GetBaseException().Message}");
            }
        }
    }

    private void RewriteOutgoingLobbySelection(object wsClient, ref string message)
    {
        if (_dedicatedProcess ||
            _sendingSyntheticSwitchChar ||
            string.IsNullOrWhiteSpace(message) ||
            (!message.Contains("JOIN_LOBBY", StringComparison.OrdinalIgnoreCase) &&
             !message.Contains("SWITCH_CHAR", StringComparison.OrdinalIgnoreCase) &&
             !message.Contains("SWITCH_CUSTOM_READY", StringComparison.OrdinalIgnoreCase) &&
             !message.Contains("SWITCH_READY", StringComparison.OrdinalIgnoreCase)))
        {
            return;
        }

        JsonNode? node = JsonNode.Parse(message);
        if (node is not JsonObject obj)
        {
            return;
        }

        string? eventName = TryGetJsonString(obj, "event");
        if (string.IsNullOrWhiteSpace(eventName))
        {
            return;
        }

        JsonObject? payload = obj["payload"] as JsonObject;
        if (IsLobbyCharacterEvent(eventName))
        {
            if (payload == null)
            {
                return;
            }

            int oldCharId = TryGetJsonInt(payload, "charId", -1);
            int selectedCharId = ResolveCurrentSelectedCharacterId();
            if (selectedCharId < 0)
            {
                if (IsKnownClientCharacterId(oldCharId))
                {
                    RememberKnownSelectedCharacter(oldCharId, $"ws.{eventName}.observed");
                }
                return;
            }

            RememberKnownSelectedCharacter(selectedCharId, $"ws.{eventName}.current");
            if (oldCharId == selectedCharId)
            {
                return;
            }

            payload["charId"] = selectedCharId;
            message = obj.ToJsonString(new JsonSerializerOptions { WriteIndented = false });
            LogSelectionPropagation($"rewrote {eventName} charId {oldCharId}->{selectedCharId}");
            return;
        }

        if (IsLobbyReadyEvent(eventName) && IsReadyPayload(payload))
        {
            int selectedCharId = ResolveCurrentSelectedCharacterId();
            if (!IsKnownClientCharacterId(selectedCharId))
            {
                LogSelectionPropagation($"ready {eventName} has no known selected char; leaving message unchanged");
                return;
            }

            SendSyntheticSwitchCharacter(wsClient, selectedCharId, eventName);
        }
    }

    private void SendSyntheticSwitchCharacter(object wsClient, int charId, string readyEvent)
    {
        if (!IsKnownClientCharacterId(charId))
        {
            return;
        }

        _sendingSyntheticSwitchChar = true;
        try
        {
            string switchCharJson = $"{{\"event\":\"SWITCH_CHAR\",\"payload\":{{\"charId\":{charId}}}}}";
            InvokeInstance(wsClient, "Send", switchCharJson);
            LogSelectionPropagation($"sent SWITCH_CHAR charId={charId} before {readyEvent}");
        }
        finally
        {
            _sendingSyntheticSwitchChar = false;
        }
    }

    private static void CharacterSelectionTrackerPostfix(object __instance, MethodBase __originalMethod, object[] __args)
    {
        try
        {
            if (TryResolveSelectedCharacterFromHook(__instance, __originalMethod, __args, out int charId))
            {
                RememberKnownSelectedCharacter(charId, $"{__originalMethod.DeclaringType?.Name}.{__originalMethod.Name}");
            }
        }
        catch (Exception ex)
        {
            if (_characterSelectionTrackerLogCount < 8)
            {
                _characterSelectionTrackerLogCount++;
                s_active?.LoggerInstance.Warning($"[CharacterSelection] tracker failed: {ex.GetBaseException().Message}");
            }
        }
    }

    private static bool TryResolveSelectedCharacterFromHook(object? instance, MethodBase? method, object?[]? args, out int charId)
    {
        charId = -1;
        string methodName = method?.Name ?? "";
        args ??= Array.Empty<object?>();

        if (methodName == "SetDisplayedCharacter")
        {
            return args.Length > 0 && TryGetCharacterIdFromObject(args[0], out charId);
        }

        if (methodName == "OnCharacterLockButtonSelect")
        {
            if (instance != null && TryGetIntMember(instance, "_selectedCharIndex", out int selectedIndex))
            {
                return TryResolveCharacterIdFromSelectionIndex(instance, selectedIndex, out charId);
            }

            return false;
        }

        if (methodName == "OnCharacterSelect" ||
            methodName == "OnCharacterButtonSelect" ||
            methodName == "SelectCharIconButton")
        {
            return TryGetLastIntArg(args, out int index) &&
                   TryResolveCharacterIdFromSelectionIndex(instance, index, out charId);
        }

        if (methodName == "SwitchCharacter" ||
            methodName == "SetLocalPlayerCharacter" ||
            methodName == "CmdTrySelectCharacter" ||
            methodName == "UserCode_CmdTrySelectCharacter__PlayerManager__Int32" ||
            methodName == "SetPlayerCharacter" ||
            methodName == "TrySelectCharacter")
        {
            return TryGetLastIntArg(args, out charId) && IsKnownClientCharacterId(charId);
        }

        return false;
    }

    private static bool TryResolveCharacterIdFromSelectionIndex(object? page, int index, out int charId)
    {
        charId = -1;
        if (index < 0)
        {
            return false;
        }

        object? data = GetMemberValueSafe(page, "_data");
        object? charListings = GetMemberValueSafe(data, "charListings");
        if (TryGetCharacterIdAtListIndex(GetMemberValueSafe(charListings, "charListings"), index, out charId))
        {
            return true;
        }

        if (TryGetCharacterIdAtListIndex(GetMemberValueSafe(data, "availableCharacters"), index, out charId))
        {
            return true;
        }

        if (TryGetCharacterIdAtListIndex(GetMemberValueSafe(page, "_charListingEntries"), index, out charId))
        {
            return true;
        }

        int[] ids = GetClientCharacterIds();
        if (index < ids.Length && IsKnownClientCharacterId(ids[index]))
        {
            charId = ids[index];
            return true;
        }

        return false;
    }

    private static bool TryGetCharacterIdAtListIndex(object? list, int index, out int charId)
    {
        charId = -1;
        int currentIndex = 0;
        foreach (object? item in EnumerateListLikePreserveNulls(list))
        {
            if (currentIndex == index)
            {
                if (TryGetCharacterIdFromObject(item, out charId) && IsKnownClientCharacterId(charId))
                {
                    return true;
                }

                try
                {
                    int parsed = Convert.ToInt32(item, System.Globalization.CultureInfo.InvariantCulture);
                    if (IsKnownClientCharacterId(parsed))
                    {
                        charId = parsed;
                        return true;
                    }
                }
                catch
                {
                }

                return false;
            }

            currentIndex++;
        }

        return false;
    }

    private static bool TryGetCharacterIdFromObject(object? value, out int charId)
    {
        charId = -1;
        if (value == null)
        {
            return false;
        }

        if (value is int directInt)
        {
            charId = directInt;
            return IsKnownClientCharacterId(charId);
        }

        string[] names = { "charId", "CharId", "characterId", "CharacterId", "id", "Id" };
        foreach (string name in names)
        {
            if (TryGetIntMember(value, name, out charId) && IsKnownClientCharacterId(charId))
            {
                return true;
            }
        }

        return TryParseTrailingInt(TryGetStringMember(value, "listingId") ?? TryGetStringMember(value, "ListingId"), out charId) &&
               IsKnownClientCharacterId(charId);
    }

    private static bool TryGetLastIntArg(object?[] args, out int value)
    {
        for (int i = args.Length - 1; i >= 0; i--)
        {
            object? arg = args[i];
            if (arg == null)
            {
                continue;
            }

            try
            {
                value = Convert.ToInt32(arg, System.Globalization.CultureInfo.InvariantCulture);
                return true;
            }
            catch
            {
            }
        }

        value = -1;
        return false;
    }

    private int ResolveCurrentSelectedCharacterId()
    {
        if (IsKnownClientCharacterId(_lastKnownSelectedCharacterId))
        {
            return _lastKnownSelectedCharacterId;
        }

        if (_requestedCharacterId is int requested && IsKnownClientCharacterId(requested))
        {
            return requested;
        }

        return -1;
    }

    private static void RememberKnownSelectedCharacter(int charId, string source)
    {
        if (!IsKnownClientCharacterId(charId))
        {
            return;
        }

        if (_lastKnownSelectedCharacterId == charId)
        {
            return;
        }

        int oldCharId = _lastKnownSelectedCharacterId;
        _lastKnownSelectedCharacterId = charId;
        if (_characterSelectionTrackerLogCount < 24)
        {
            _characterSelectionTrackerLogCount++;
            s_active?.LoggerInstance.Msg($"[CharacterSelection] selected char tracked via {source}: {oldCharId}->{charId}.");
        }
    }

    private static bool IsKnownClientCharacterId(int charId)
    {
        return charId >= 0 && charId <= MedusaCharacterId;
    }

    private static bool IsLobbyCharacterEvent(string eventName)
    {
        return eventName.Equals("JOIN_LOBBY", StringComparison.OrdinalIgnoreCase) ||
               eventName.Equals("SWITCH_CHAR", StringComparison.OrdinalIgnoreCase);
    }

    private static bool IsLobbyReadyEvent(string eventName)
    {
        return eventName.Equals("SWITCH_CUSTOM_READY", StringComparison.OrdinalIgnoreCase) ||
               eventName.Equals("SWITCH_READY", StringComparison.OrdinalIgnoreCase);
    }

    private static bool IsReadyPayload(JsonObject? payload)
    {
        if (payload == null)
        {
            return true;
        }

        JsonNode? ready = payload["isReady"] ?? payload["ready"];
        if (ready == null)
        {
            return true;
        }

        try
        {
            return ready.GetValue<bool>();
        }
        catch
        {
            return true;
        }
    }

    private static string? TryGetJsonString(JsonObject obj, string name)
    {
        try
        {
            return obj[name]?.GetValue<string>();
        }
        catch
        {
            return null;
        }
    }

    private static int TryGetJsonInt(JsonObject obj, string name, int fallback)
    {
        try
        {
            return obj[name]?.GetValue<int>() ?? fallback;
        }
        catch
        {
            return fallback;
        }
    }

    private static void LogSelectionPropagation(string message)
    {
        if (_webSocketSelectionRewriteLogCount >= 24)
        {
            return;
        }

        _webSocketSelectionRewriteLogCount++;
        s_active?.LoggerInstance.Msg("[CharacterSelection] " + message + ".");
    }

    private static bool PlayPlayerCharChangeAnimPrefix()
    {
        s_active?.LoggerInstance.Msg("Skipped UILobbyMatchCharacterSelectPage.PlayPlayerCharChangeAnim on custom server.");
        return false;
    }

    private static bool UnconditionalSkipPrefix(MethodBase __originalMethod)
    {
        // Used for UI methods that are known to NullRef during lobby init on the custom server,
        // and are not required for match loading. Always skip these.
        if (__originalMethod != null)
        {
            s_active?.LoggerInstance.Msg(
                $"Unconditionally skipped {__originalMethod.DeclaringType?.Name}.{__originalMethod.Name} on custom server.");
        }
        return false;
    }

    private static bool QuietSkipPrefix()
    {
        return false;
    }

    private static int _characterPageDataGuardLogCount;

    private static bool CharacterPageUpdateDataGuardPrefix(object __instance, object? data)
    {
        if (__instance == null)
        {
            return false;
        }

        if (data == null)
        {
            LogCharacterPageDataGuard("skipped UILobbyCharacterSelectPage.UpdateData/Initialise because data is null.");
            return false;
        }

        SetMemberValueBestEffort(__instance, "_data", data);
        return true;
    }

    private static bool CharacterPageAvailableGuardPrefix(object __instance)
    {
        if (__instance == null)
        {
            return false;
        }

        object? data = GetMemberValueSafe(__instance, "_data");
        if (CharacterPageModelHasListings(data))
        {
            return true;
        }

        LogCharacterPageDataGuard("skipped UILobbyCharacterSelectPage.UpdateAvailableCharactersData before charListings were available.");
        return false;
    }

    private static bool CharacterPageButtonStateGuardPrefix(object __instance)
    {
        if (__instance == null)
        {
            return false;
        }

        object? data = GetMemberValueSafe(__instance, "_data");
        if (CharacterPageModelHasListings(data))
        {
            return true;
        }

        LogCharacterPageDataGuard("skipped UILobbyCharacterSelectPage.SetCharacterButtonState before charListings were available.");
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
            if (TryFindCharacterListingIndexFromPageData(__instance, charId, out int index))
            {
                __result = index;
                return false;
            }

            object? entries = GetMemberValue(__instance, "_charListingEntries");
            if (entries != null && TryFindCharacterListingIndex(entries, charId, out index))
            {
                __result = index;
                return false;
            }

            if (TryFindCharacterIdIndex(GetClientCharacterIds(), charId, out index))
            {
                __result = index;
                LogCharacterPageDataGuard($"resolved charId={charId} from fallback character id list at index={index}.");
                return false;
            }

            LogCharacterPageDataGuard($"charId={charId} not found in page data. Returning -1.");
            __result = -1;
            return false;
        }
        catch (Exception ex)
        {
            s_active?.LoggerInstance.Error($"Error in GetCharacterListingIndexFromCharIdPrefix: {ex}");
            __result = -1;
            return false;
        }

    }

    private static bool TryFindCharacterListingIndexFromPageData(object page, int charId, out int index)
    {
        index = -1;
        object? data = GetMemberValueSafe(page, "_data");
        object? charListings = GetMemberValueSafe(data, "charListings");
        object? entries = GetMemberValueSafe(charListings, "charListings");
        if (entries != null && TryFindCharacterListingIndex(entries, charId, out index))
        {
            return true;
        }

        object? availableCharacters = GetMemberValueSafe(data, "availableCharacters");
        if (TryFindCharacterListingIndexFromIntList(availableCharacters, charId, out index))
        {
            return true;
        }

        return false;
    }

    private static bool CharacterPageModelHasListings(object? data)
    {
        object? charListings = GetMemberValueSafe(data, "charListings");
        object? entries = GetMemberValueSafe(charListings, "charListings");
        return HasListLikeItems(entries);
    }

    private static bool HasListLikeItems(object? list)
    {
        if (list == null)
        {
            return false;
        }

        if (TryGetListLikeCount(list, out int count))
        {
            return count > 0;
        }

        foreach (object? _ in EnumerateListLikePreserveNulls(list))
        {
            return true;
        }

        return false;
    }

    private static bool TryFindCharacterListingIndexFromIntList(object? list, int charId, out int index)
    {
        index = -1;
        int currentIndex = 0;
        foreach (object? item in EnumerateListLikePreserveNulls(list))
        {
            try
            {
                if (item != null && Convert.ToInt32(item, System.Globalization.CultureInfo.InvariantCulture) == charId)
                {
                    index = currentIndex;
                    return true;
                }
            }
            catch
            {
            }

            currentIndex++;
        }

        return false;
    }

    private static bool TryFindCharacterIdIndex(int[] ids, int charId, out int index)
    {
        for (int i = 0; i < ids.Length; i++)
        {
            if (ids[i] == charId)
            {
                index = i;
                return true;
            }
        }

        index = -1;
        return false;
    }

    private static bool TryGetListLikeCount(object list, out int count)
    {
        count = 0;
        try
        {
            object? rawCount = GetMemberValueSafe(list, "Count") ?? GetMemberValueSafe(list, "Length");
            if (rawCount != null)
            {
                count = Convert.ToInt32(rawCount, System.Globalization.CultureInfo.InvariantCulture);
                return true;
            }

            if (list is Array array)
            {
                count = array.Length;
                return true;
            }
        }
        catch
        {
            count = 0;
        }

        return false;
    }

    private static void LogCharacterPageDataGuard(string message)
    {
        if (_characterPageDataGuardLogCount >= 8)
        {
            return;
        }

        _characterPageDataGuardLogCount++;
        s_active?.LoggerInstance.Msg("[CharacterPageDataGuard] " + message);
    }

    private static bool TryFindCharacterListingIndex(object entries, int charId, out int index)
    {
        index = -1;
        int currentIndex = 0;

        foreach (object? entry in EnumerateListLikePreserveNulls(entries))
        {
            if (TryGetCharacterIdFromListingEntry(entry, out int entryCharId) && entryCharId == charId)
            {
                index = currentIndex;
                return true;
            }

            currentIndex++;
        }

        return false;
    }

    private static IEnumerable<object?> EnumerateListLikePreserveNulls(object? list)
    {
        if (list == null)
        {
            yield break;
        }

        if (list is System.Collections.IEnumerable enumerable)
        {
            foreach (object? item in enumerable)
            {
                yield return item;
            }

            yield break;
        }

        int count = 0;
        if (!TryGetListLikeCount(list, out count) || count <= 0)
        {
            yield break;
        }

        PropertyInfo? itemProperty = list.GetType().GetProperty("Item", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        for (int i = 0; i < count; i++)
        {
            object? item = null;
            try
            {
                item = itemProperty?.GetValue(list, new object[] { i });
            }
            catch
            {
                try
                {
                    item = itemProperty?.GetValue(list, new object[] { (long)i });
                }
                catch
                {
                    item = TryInvokeInstance(list, "get_Item", i) ?? TryInvokeInstance(list, "get_Item", (long)i);
                }
            }

            yield return item;
        }
    }

    private static bool TryGetCharacterIdFromListingEntry(object? entry, out int charId)
    {
        charId = -1;
        if (entry == null)
        {
            return false;
        }

        string[] intMemberNames = { "charId", "CharId", "characterId", "CharacterId", "id", "Id" };
        foreach (string name in intMemberNames)
        {
            if (TryGetIntMember(entry, name, out charId))
            {
                return true;
            }
        }

        string? listingId = TryGetStringMember(entry, "listingId") ??
                            TryGetStringMember(entry, "ListingId");
        return TryParseTrailingInt(listingId, out charId);
    }

    private static bool TryParseTrailingInt(string? value, out int result)
    {
        result = -1;
        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }

        int end = value.Length - 1;
        while (end >= 0 && !char.IsDigit(value[end]))
        {
            end--;
        }

        if (end < 0)
        {
            return false;
        }

        int start = end;
        while (start >= 0 && char.IsDigit(value[start]))
        {
            start--;
        }

        string digits = value.Substring(start + 1, end - start);
        return int.TryParse(digits, out result);
    }

    private static Exception? CustomServerNullRefFinalizer(Exception? __exception)
    {
        if (__exception == null)
        {
            return null;
        }

        if (LooksLikeNullReference(__exception))
        {
            s_active?.LoggerInstance.Warning($"Suppressed custom-server lobby UI NullReferenceException: {__exception.GetType().FullName}");
            return null;
        }

        return __exception;
    }

    private static Exception? PlayTabPageNullRefFinalizer(Exception? __exception)
    {
        // Suppress NullReferenceException from character select page during lobby init.
        // This happens when GetCharacterListingIndexFromCharId is called before
        // the character listing data has been loaded from /api/chars/listing.
        if (__exception != null && LooksLikeNullReference(__exception))
        {
            return null; // Swallow the exception
        }
        return __exception;
    }


    private static bool LooksLikeNullReference(Exception exception)
    {
        for (Exception? current = exception; current != null; current = current.InnerException)
        {
            string typeName = current.GetType().FullName ?? current.GetType().Name;
            string message = current.Message ?? "";
            string stack = current.StackTrace ?? "";
            if (current is NullReferenceException ||
                typeName.Contains("NullReferenceException", StringComparison.OrdinalIgnoreCase) ||
                message.Contains("NullReferenceException", StringComparison.OrdinalIgnoreCase) ||
                stack.Contains("NullReferenceException", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }

    private static void LoginControllerHandleLoadResponsePostfix(object __instance, object response)
    {
        CustomServerMod? active = s_active;
        if (active == null || __instance == null || response == null)
        {
            return;
        }

        active._lastLoginController = __instance;
        active._lastLoadResponse = response;
        active.LoggerInstance.Msg($"Custom-server load response handled by LoginController.");

        // CRITICAL: extract availableCharacters from the response and DIRECTLY populate
        // UICharactersConfiguration._lobbyAvailableCharacterIds. The original game flow
        // would do this via HandleUpdateAvailableCharacterList -> UpdateAvailableCharacterList,
        // but in our setup that wiring fails silently and the lobby UI crashes natively
        // when TryGetLobbyCharConfigByIndex hits the empty array.
        try
        {
            int[] charIds = ExtractAvailableCharacters(response);
            if (charIds.Length == 0)
            {
                charIds = GetClientCharacterIds();
            }
            active._lastAvailableCharacterIds = charIds
                .Where(id => id >= 0)
                .Distinct()
                .OrderBy(id => id)
                .ToArray();
            active.PopulateAllUICharactersConfigurations(active._lastAvailableCharacterIds);
        }
        catch (Exception ex)
        {
            active.LoggerInstance.Warning($"Failed to populate UICharactersConfiguration: {ex.GetBaseException().Message}");
        }

        active.SchedulePostLoginUiFallback("LoginController.HandleLoadResponse", delaySeconds: 5f);
        active.ScheduleSceneReloadIfEmpty();
    }

    private static int[] ExtractAvailableCharacters(object response)
    {
        try
        {
            FieldInfo? f = response.GetType().GetField("availableCharacters",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (f == null) return Array.Empty<int>();
            object? val = f.GetValue(response);
            if (val == null) return Array.Empty<int>();
            // val could be int[] or Il2CppStructArray<int>
            if (val is int[] arr) return arr;
            // Try IEnumerable<int> via reflection
            var list = new List<int>();
            if (val is System.Collections.IEnumerable enumerable)
            {
                foreach (var item in enumerable)
                {
                    if (item is int n) list.Add(n);
                    else if (item != null && int.TryParse(item.ToString(), out int parsed)) list.Add(parsed);
                }
                return list.ToArray();
            }
            return Array.Empty<int>();
        }
        catch { return Array.Empty<int>(); }
    }

    private void PopulateAllUICharactersConfigurations(int[] charIds)
    {
        Type? cfgType = FindType("BAPBAP.UI.UICharactersConfiguration");
        if (cfgType == null)
        {
            LoggerInstance.Msg("PopulateAllUICharactersConfigurations: type not found yet");
            return;
        }

        Array? configs = FindLoadedUnityObjects(cfgType);
        if (configs == null || configs.Length == 0)
        {
            LoggerInstance.Msg("PopulateAllUICharactersConfigurations: no instances found yet");
            return;
        }

        FieldInfo? f = cfgType.GetField("_lobbyAvailableCharacterIds",
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        if (f == null)
        {
            LoggerInstance.Msg("PopulateAllUICharactersConfigurations: field not found");
            return;
        }

        Type fieldType = f.FieldType;
        int populated = 0;
        foreach (object cfg in configs)
        {
            if (cfg == null) continue;
            try
            {
                object? toAssign = null;
                // Direct int[] assignment
                if (fieldType == typeof(int[]) || fieldType.IsAssignableFrom(typeof(int[])))
                {
                    toAssign = charIds;
                }
                else
                {
                    // Try ctor that takes int[]
                    ConstructorInfo? ctorArr = fieldType.GetConstructor(new[] { typeof(int[]) });
                    if (ctorArr != null)
                    {
                        toAssign = ctorArr.Invoke(new object[] { charIds });
                    }
                    else
                    {
                        // Try ctor(long size) + set via Item indexer
                        ConstructorInfo? ctorSize = fieldType.GetConstructor(new[] { typeof(long) });
                        if (ctorSize != null)
                        {
                            object wrapper = ctorSize.Invoke(new object[] { (long)charIds.Length });
                            PropertyInfo? indexer = fieldType.GetProperty("Item");
                            if (indexer != null)
                            {
                                for (int i = 0; i < charIds.Length; i++)
                                {
                                    indexer.SetValue(wrapper, charIds[i], new object[] { (long)i });
                                }
                                toAssign = wrapper;
                            }
                        }
                    }
                }
                if (toAssign != null)
                {
                    f.SetValue(cfg, toAssign);
                    populated++;
                }
                else
                {
                    LoggerInstance.Msg($"PopulateAllUICharactersConfigurations: could not construct value of {fieldType.FullName}");
                }
            }
            catch (Exception ex)
            {
                LoggerInstance.Msg($"PopulateAllUICharactersConfigurations item err: {ex.GetBaseException().Message}");
            }
        }

        LoggerInstance.Msg($"PopulateAllUICharactersConfigurations: populated _lobbyAvailableCharacterIds=[{string.Join(",", charIds)}] on {populated}/{configs.Length} instances. fieldType={fieldType.FullName}");
    }

    private static bool AnalyticsManagerSetupAnalyticsPrefix(string accountId, bool isGuest, int totalGames)
    {
        s_active?.LoggerInstance.Msg(
            $"Suppressed Unity Analytics setup for custom-server session.");
        return false;
    }

    private static void UnityWebRequestSetRequestHeaderPrefix(ref string name, ref string value)
    {
        if (!string.IsNullOrWhiteSpace(name))
        {
            return;
        }

        name = DefaultSecretHeaderName;
        if (string.IsNullOrWhiteSpace(value))
        {
            value = DefaultSecretValue;
        }

        s_active?.LoggerInstance.Msg("Repaired empty UnityWebRequest header name for custom-server callback.");
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
        if (_unityWebRequestLogCount >= 80)
        {
            return;
        }

        object? urlValue = GetMemberValue(request, "url");
        if (urlValue is not string url || !Uri.TryCreate(url, UriKind.Absolute, out Uri? uri))
        {
            return;
        }

        if (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps)
        {
            return;
        }

        _unityWebRequestLogCount++;
        // Strip host/port to avoid leaking server IP in logs - only log path
        string sanitized = SanitizeUrlForLog(url);
        LoggerInstance.Msg($"UnityWebRequest #{_unityWebRequestLogCount}: {sanitized}");
    }

    private static string SanitizeUrlForLog(string url)
    {
        if (string.IsNullOrEmpty(url)) return "(empty)";
        try
        {
            var uri = new Uri(url, UriKind.RelativeOrAbsolute);
            if (uri.IsAbsoluteUri)
            {
                // For local addresses, keep "local" tag; for external, redact
                bool isLocal = uri.Host == "127.0.0.1" || uri.Host == "localhost" || uri.Host.StartsWith("192.168.") || uri.Host.StartsWith("10.");
                string hostTag = isLocal ? "local" : "remote";
                return $"[{hostTag}]{uri.AbsolutePath}{uri.Query}";
            }
            return url;
        }
        catch { return "(invalid url)"; }
    }

    private void LogCustomServerRequest(object request)
    {
        if (_customServerRequestLogCount >= 24 || !ShouldAttachCustomServerHeaders(request))
        {
            return;
        }

        object? urlValue = GetMemberValue(request, "url");
        if (urlValue is not string url)
        {
            return;
        }

        _customServerRequestLogCount++;
        LoggerInstance.Msg($"Custom server HTTP request #{_customServerRequestLogCount}: {SanitizeUrlForLog(url)}");

        if (url.Contains("/api/lobby/socket", StringComparison.OrdinalIgnoreCase) ||
            url.Contains("/lobby/socket", StringComparison.OrdinalIgnoreCase))
        {
            SchedulePostLoginUiFallback("lobby socket discovery", delaySeconds: 4f);
        }
    }

    private void ApplyCustomServerIdentityHeaders(object request)
    {
        string accountId = _accountIdEntry?.Value?.Trim() ?? "";
        if (string.IsNullOrWhiteSpace(accountId) || !ShouldAttachCustomServerHeaders(request))
        {
            return;
        }

        MethodInfo? setHeader = request.GetType()
            .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .FirstOrDefault(method =>
            {
                if (method.Name != "SetRequestHeader")
                {
                    return false;
                }

                ParameterInfo[] parameters = method.GetParameters();
                return parameters.Length == 2 &&
                       parameters[0].ParameterType == typeof(string) &&
                       parameters[1].ParameterType == typeof(string);
            });

        if (setHeader == null)
        {
            return;
        }

        try
        {
            setHeader.Invoke(request, new object[] { AccountHeaderName, accountId });
            string username = _usernameEntry?.Value?.Trim() ?? "";
            if (!string.IsNullOrWhiteSpace(username))
            {
                setHeader.Invoke(request, new object[] { UsernameHeaderName, username });
            }

            setHeader.Invoke(request, new object[] { DiscriminatorHeaderName, GetDiscriminatorForHeaders().ToString() });
        }
        catch (Exception ex)
        {
            LoggerInstance.Warning($"Could not attach custom server identity headers: {ex.GetBaseException().Message}");
        }
    }

    private bool ShouldAttachCustomServerHeaders(object request)
    {
        object? urlValue = GetMemberValue(request, "url");
        if (urlValue is not string url || !Uri.TryCreate(url, UriKind.Absolute, out Uri? uri))
        {
            return false;
        }

        if (IsLoopbackHost(uri.Host) && (uri.Port == DefaultLocalProxyPort || uri.Port == DefaultServerPort || uri.Port == _serverPortEntry.Value || uri.Port == _localPortEntry.Value))
        {
            return true;
        }

        string apiHost = string.IsNullOrWhiteSpace(_lastAppliedApiHost) ? GetConfiguredApiHost() : _lastAppliedApiHost;
        if (!Uri.TryCreate(apiHost, UriKind.Absolute, out Uri? configured))
        {
            return false;
        }

        int configuredPort = configured.IsDefaultPort ? (configured.Scheme.Equals("https", StringComparison.OrdinalIgnoreCase) ? 443 : 80) : configured.Port;
        int requestPort = uri.IsDefaultPort ? (uri.Scheme.Equals("https", StringComparison.OrdinalIgnoreCase) ? 443 : 80) : uri.Port;
        return string.Equals(uri.Host, configured.Host, StringComparison.OrdinalIgnoreCase) && configuredPort == requestPort;
    }

    private void RewriteUnityWebRequestCallbackUrl(object request)
    {
        object? urlValue = GetMemberValue(request, "url");
        if (urlValue is not string url ||
            !Uri.TryCreate(url, UriKind.Absolute, out Uri? uri) ||
            !IsLoopbackHost(uri.Host))
        {
            return;
        }

        bool knownLocalApiPort =
            uri.Port == DefaultLocalProxyPort ||
            uri.Port == DefaultServerPort ||
            uri.Port == _serverPortEntry.Value ||
            uri.Port == _localPortEntry.Value;
        if (!knownLocalApiPort)
        {
            return;
        }

        bool isCallback = uri.AbsolutePath.StartsWith("/api/internal", StringComparison.OrdinalIgnoreCase);
        bool proxyDisabled = _localProxyEntry?.Value != true;
        if (!isCallback && !proxyDisabled)
        {
            return;
        }

        if (string.IsNullOrWhiteSpace(_lastAppliedApiHost))
        {
            _lastAppliedApiHost = GetConfiguredApiHost();
        }

        string replacement = _lastAppliedApiHost.TrimEnd('/') + uri.PathAndQuery;
        if (string.Equals(url, replacement, StringComparison.OrdinalIgnoreCase))
        {
            return;
        }

        if (!SetMemberValue(request, "url", replacement))
        {
            return;
        }

        if (isCallback)
        {
            if (_unityWebRequestCallbackUrlPatchLogged)
            {
                return;
            }

            _unityWebRequestCallbackUrlPatchLogged = true;
            LoggerInstance.Msg("Rewrote UnityWebRequest callback URL.");
            return;
        }

        if (_unityWebRequestLoopbackUrlPatchLogged)
        {
            return;
        }

        _unityWebRequestLoopbackUrlPatchLogged = true;
        LoggerInstance.Msg("Rewrote UnityWebRequest loopback API URL for direct custom-server mode.");
    }

    private static string DescribeMatchmakingPlayer(object? mpd)
    {
        if (mpd == null)
        {
            return "null";
        }

        return $"auth={GetMemberValue(mpd, "gameAuthId") ?? "null"} " +
               $"playerId={GetMemberValue(mpd, "playerId") ?? "null"} " +
               $"teamId={GetMemberValue(mpd, "teamId") ?? "null"} " +
               $"charId={GetMemberValue(mpd, "charId") ?? "null"}";
    }

    private static object? GetMemberValueSafe(object? instance, string name)
    {
        if (instance == null)
        {
            return null;
        }

        try
        {
            return GetMemberValue(instance, name);
        }
        catch
        {
            return null;
        }
    }

    private static bool TryGetIntMember(object? instance, string name, out int value)
    {
        value = 0;
        object? raw = GetMemberValueSafe(instance, name);
        if (raw == null)
        {
            return false;
        }

        try
        {
            value = Convert.ToInt32(raw);
            return true;
        }
        catch
        {
            return false;
        }
    }

    private static string? TryGetStringMember(object? instance, string name)
    {
        return GetMemberValueSafe(instance, name)?.ToString();
    }

    private static object? ResolvePlayerManagerForMatchmaking(object? player, object? mpd, object? gameManager)
    {
        object? direct = TryResolvePlayerManagerObject(player);
        if (direct != null)
        {
            return direct;
        }

        foreach (string memberName in new[] { "playerManager", "_playerManager", "PlayerManager", "ownerPlayer", "_ownerPlayer" })
        {
            object? member = TryResolvePlayerManagerObject(GetMemberValueSafe(player, memberName));
            if (member != null)
            {
                return member;
            }
        }

        if (TryGetIntMember(mpd, "playerId", out int playerId) && playerId > 0)
        {
            object? byGameManager = TryFindPlayerManagerInGameManager(gameManager, playerId);
            if (byGameManager != null)
            {
                return byGameManager;
            }

            object? byScene = TryFindLoadedPlayerManager(playerId, TryGetStringMember(mpd, "accountId"), TryGetStringMember(mpd, "gameAuthId"));
            if (byScene != null)
            {
                return byScene;
            }
        }

        return TryFindLoadedPlayerManager(-1, TryGetStringMember(mpd, "accountId"), TryGetStringMember(mpd, "gameAuthId"));
    }

    private static object? TryResolvePlayerManagerObject(object? candidate)
    {
        if (candidate == null)
        {
            return null;
        }

        Type? playerManagerType = FindPlayerManagerType();
        if ((playerManagerType != null && playerManagerType.IsInstanceOfType(candidate)) ||
            LooksLikePlayerManager(candidate))
        {
            return candidate;
        }

        if (playerManagerType != null)
        {
            object? component = TryGetComponent(candidate, playerManagerType);
            if (component != null)
            {
                return component;
            }
        }

        object? gameObject = GetMemberValueSafe(candidate, "gameObject");
        if (!ReferenceEquals(gameObject, candidate) && gameObject != null && playerManagerType != null)
        {
            object? component = TryGetComponent(gameObject, playerManagerType);
            if (component != null)
            {
                return component;
            }
        }

        return null;
    }

    private static Type? FindPlayerManagerType()
    {
        return FindType("BAPBAP.Player.PlayerManager") ??
               FindType("Il2CppBAPBAP.Player.PlayerManager");
    }

    private static bool LooksLikePlayerManager(object? candidate)
    {
        if (candidate == null)
        {
            return false;
        }

        string? fullName = candidate.GetType().FullName;
        if (string.Equals(fullName, "BAPBAP.Player.PlayerManager", StringComparison.Ordinal) ||
            string.Equals(fullName, "Il2CppBAPBAP.Player.PlayerManager", StringComparison.Ordinal) ||
            string.Equals(candidate.GetType().Name, "PlayerManager", StringComparison.Ordinal))
        {
            return true;
        }

        return TryGetIntMember(candidate, "playerId", out _) &&
               (GetMemberValueSafe(candidate, "primaryCharManager") != null ||
                GetMemberValueSafe(candidate, "playerPreMatch") != null ||
                GetMemberValueSafe(candidate, "charId") != null);
    }

    private static object? TryGetComponent(object? player, Type componentType)
    {
        try
        {
            if (player != null && componentType.IsInstanceOfType(player))
            {
                return player;
            }

            if (player is Component component)
            {
                object? directComponent = TryFindComponentByType(component.gameObject, componentType, includeChildren: false);
                if (directComponent != null)
                {
                    return directComponent;
                }

                return TryFindComponentByType(component.gameObject, componentType, includeChildren: true);
            }

            if (player is GameObject gameObject)
            {
                object? directComponent = TryFindComponentByType(gameObject, componentType, includeChildren: false);
                if (directComponent != null)
                {
                    return directComponent;
                }

                return TryFindComponentByType(gameObject, componentType, includeChildren: true);
            }

            return null;
        }
        catch
        {
            return null;
        }
    }

    private static object? TryFindComponentByType(GameObject? gameObject, Type componentType, bool includeChildren)
    {
        if (gameObject == null)
        {
            return null;
        }

        try
        {
            Component[] components = includeChildren
                ? gameObject.GetComponentsInChildren<Component>(true)
                : gameObject.GetComponents<Component>();

            foreach (Component? component in components)
            {
                if (component == null)
                {
                    continue;
                }

                if (componentType.IsInstanceOfType(component) || LooksLikePlayerManager(component))
                {
                    return component;
                }
            }
        }
        catch
        {
            return null;
        }

        return null;
    }

    private static object? TryFindPlayerManagerInGameManager(object? gameManager, int playerId)
    {
        object? playersByPlayerId = GetMemberValueSafe(gameManager, "playersByPlayerId");
        if (playersByPlayerId == null)
        {
            return null;
        }

        object? value = TryDictionaryGetValue(playersByPlayerId, playerId);
        if (value != null)
        {
            return value;
        }

        foreach (object entry in EnumerateListLike(playersByPlayerId))
        {
            object? candidate = GetMemberValueSafe(entry, "Value");
            if (candidate != null && TryGetIntMember(candidate, "playerId", out int candidateId) && candidateId == playerId)
            {
                return candidate;
            }
        }

        return null;
    }

    private static object? TryFindLoadedPlayerManager(int playerId, string? accountId, string? gameAuthId)
    {
        Type? playerManagerType = FindType("BAPBAP.Player.PlayerManager");
        if (playerManagerType == null)
        {
            return null;
        }

        Array? players = FindLoadedUnityObjects(playerManagerType);
        if (players == null)
        {
            return null;
        }

        foreach (object? candidate in players)
        {
            if (candidate == null)
            {
                continue;
            }

            if (playerId > 0 && TryGetIntMember(candidate, "playerId", out int candidateId) && candidateId == playerId)
            {
                return candidate;
            }

            string? candidateAccountId = TryGetStringMember(candidate, "accountId");
            if (!string.IsNullOrWhiteSpace(accountId) &&
                string.Equals(candidateAccountId, accountId, StringComparison.OrdinalIgnoreCase))
            {
                return candidate;
            }

            string? candidateAuthId = TryGetStringMember(candidate, "gameAuthId");
            if (!string.IsNullOrWhiteSpace(gameAuthId) &&
                string.Equals(candidateAuthId, gameAuthId, StringComparison.OrdinalIgnoreCase))
            {
                return candidate;
            }
        }

        return null;
    }

    private static bool ForceMedusaPlayerManager(object? playerManager, string source)
    {
        if (playerManager == null)
        {
            return false;
        }

        int oldCharId = TryGetIntMember(playerManager, "charId", out int current) ? current : -1;
        bool changed = false;
        changed = SetMemberValueBestEffort(playerManager, "skinAssetId", -1) || changed;
        changed = SetMemberValueBestEffort(playerManager, "charId", MedusaCharacterId) || changed;
        changed = SetMemberValueBestEffort(playerManager, "NetworkcharId", MedusaCharacterId) || changed;

        object? primaryCharManager = GetMemberValueSafe(playerManager, "primaryCharManager");
        if (primaryCharManager != null)
        {
            changed = SetMemberValueBestEffort(primaryCharManager, "charId", MedusaCharacterId) || changed;
            changed = SetMemberValueBestEffort(primaryCharManager, "NetworkcharId", MedusaCharacterId) || changed;
        }

        if (oldCharId != MedusaCharacterId)
        {
            TryInvokeInstance(playerManager, "OnCharacterChanged", oldCharId, MedusaCharacterId);
        }

        s_active?.LoggerInstance.Msg($"Medusa player state forced via {source}: old={oldCharId} new={MedusaCharacterId} skin=-1.");
        return changed;
    }

    private static int ForceMedusaQueuedPlayerData(object? gameManager, object? mpd)
    {
        object? qmd = GetMemberValueSafe(gameManager, "qmd");
        object? players = GetMemberValueSafe(qmd, "players");
        if (players == null)
        {
            return 0;
        }

        int updated = 0;
        foreach (object playerData in EnumerateListLike(players))
        {
            if (!IsSameMatchmakingPlayer(playerData, mpd))
            {
                continue;
            }

            if (SetMemberValueBestEffort(playerData, "charId", MedusaCharacterId))
            {
                updated++;
            }

            SetMemberValueBestEffort(playerData, "skinAssetId", -1);
        }

        return updated;
    }

    private static bool ForceMedusaPrematchSelection(object? gameManager, object? playerManager, object? mpd)
    {
        int playerId = -1;
        if (!TryGetIntMember(playerManager, "playerId", out playerId))
        {
            TryGetIntMember(mpd, "playerId", out playerId);
        }

        if (playerId <= 0)
        {
            return false;
        }

        object? preMatchManager = GetMemberValueSafe(gameManager, "preMatchManager");
        object? selected = GetMemberValueSafe(preMatchManager, "_currentSelectedCharacters")
                           ?? GetMemberValueSafe(preMatchManager, "currentSelectedCharacters");
        return TryDictionarySetValue(selected, playerId, MedusaCharacterId);
    }

    private static bool IsSameMatchmakingPlayer(object? left, object? right)
    {
        if (left == null || right == null)
        {
            return false;
        }

        if (TryGetIntMember(left, "playerId", out int leftPlayerId) &&
            TryGetIntMember(right, "playerId", out int rightPlayerId) &&
            leftPlayerId > 0 &&
            leftPlayerId == rightPlayerId)
        {
            return true;
        }

        string? leftAuth = TryGetStringMember(left, "gameAuthId");
        string? rightAuth = TryGetStringMember(right, "gameAuthId");
        if (!string.IsNullOrWhiteSpace(leftAuth) &&
            string.Equals(leftAuth, rightAuth, StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }

        string? leftAccount = TryGetStringMember(left, "accountId");
        string? rightAccount = TryGetStringMember(right, "accountId");
        return !string.IsNullOrWhiteSpace(leftAccount) &&
               string.Equals(leftAccount, rightAccount, StringComparison.OrdinalIgnoreCase);
    }

    private static object? TryDictionaryGetValue(object dictionary, int key)
    {
        try
        {
            PropertyInfo? item = dictionary.GetType().GetProperty("Item", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            return item?.GetValue(dictionary, new object[] { key });
        }
        catch
        {
            return null;
        }
    }

    private static bool TryDictionarySetValue(object? dictionary, int key, int value)
    {
        if (dictionary == null)
        {
            return false;
        }

        if (TryInvokeInstance(dictionary, "set_Item", key, value) != null)
        {
            return true;
        }

        try
        {
            PropertyInfo? item = dictionary.GetType().GetProperty("Item", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (item?.CanWrite == true)
            {
                item.SetValue(dictionary, value, new object[] { key });
                return true;
            }
        }
        catch
        {
            // Add below if the key is not present yet.
        }

        try
        {
            object? contains = TryInvokeInstance(dictionary, "ContainsKey", key);
            if (contains is bool present && present)
            {
                return false;
            }

            TryInvokeInstance(dictionary, "Add", key, value);
            return true;
        }
        catch
        {
            return false;
        }
    }

    private static IEnumerable<object> EnumerateListLike(object? list)
    {
        if (list == null)
        {
            yield break;
        }

        if (list is System.Collections.IEnumerable enumerable)
        {
            foreach (object? item in enumerable)
            {
                if (item != null)
                {
                    yield return item;
                }
            }

            yield break;
        }

        int count = 0;
        try
        {
            object? rawCount = GetMemberValueSafe(list, "Count");
            if (rawCount != null)
            {
                count = Convert.ToInt32(rawCount);
            }
        }
        catch
        {
            count = 0;
        }

        if (count <= 0)
        {
            yield break;
        }

        PropertyInfo? itemProperty = list.GetType().GetProperty("Item", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        for (int i = 0; i < count; i++)
        {
            object? item = null;
            try
            {
                item = itemProperty?.GetValue(list, new object[] { i });
            }
            catch
            {
                item = TryInvokeInstance(list, "get_Item", i);
            }

            if (item != null)
            {
                yield return item;
            }
        }
    }

    private static bool SetMemberValueBestEffort(object? instance, string name, object? value)
    {
        if (instance == null)
        {
            return false;
        }

        try
        {
            return SetMemberValue(instance, name, value);
        }
        catch
        {
            return false;
        }
    }

    private static object? TryInvokeInstance(object? instance, string methodName, params object?[] args)
    {
        if (instance == null)
        {
            return null;
        }

        try
        {
            return InvokeInstance(instance, methodName, args);
        }
        catch
        {
            return null;
        }
    }

    private static string DescribeLoadResponse(object? response)
    {
        if (response == null)
        {
            return "null";
        }

        return $"accountId={GetMemberValue(response, "accountId") ?? GetMemberValue(response, "AccountId") ?? "null"} " +
               $"username={GetMemberValue(response, "username") ?? GetMemberValue(response, "Username") ?? "null"} " +
               $"isGuest={GetMemberValue(response, "isGuest") ?? GetMemberValue(response, "IsGuest") ?? "null"} " +
               $"isCompleted={GetMemberValue(response, "isCompleted") ?? GetMemberValue(response, "IsCompleted") ?? "null"} " +
               $"blocked={GetMemberValue(response, "blocked") ?? GetMemberValue(response, "Blocked") ?? "null"}";
    }

    private static string DescribeGameManager(object? gameManager)
    {
        if (gameManager == null)
        {
            return "null";
        }

        return $"playersByPlayerId={GetCountOrNull(GetMemberValue(gameManager, "playersByPlayerId"))} " +
               $"connIdToPlayerId={GetCountOrNull(GetMemberValue(gameManager, "connIdToPlayerId"))} " +
               $"preMatchManager={GetMemberValue(gameManager, "preMatchManager") != null} " +
               $"currentGameMode={GetMemberValue(gameManager, "currentGameMode") != null} " +
               $"qmd={GetMemberValue(gameManager, "qmd") != null} " +
               $"mgd={GetMemberValue(gameManager, "mgd") != null}";
    }

    private static string DescribeObjectType(object? instance)
    {
        return instance?.GetType().FullName ?? "null";
    }

    private static string GetCountOrNull(object? value)
    {
        if (value == null)
        {
            return "null";
        }

        PropertyInfo? count = value.GetType().GetProperty("Count", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        return count?.GetValue(value)?.ToString() ?? "unknown";
    }

    private static bool HasCollectionItems(object? value)
    {
        if (value == null)
        {
            return false;
        }

        PropertyInfo? count = value.GetType().GetProperty("Count", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        if (count == null)
        {
            return false;
        }

        try
        {
            return Convert.ToInt32(count.GetValue(value)) > 0;
        }
        catch
        {
            return false;
        }
    }

    private void PatchLoadedNetworkConfigs()
    {
        if (string.IsNullOrWhiteSpace(_lastAppliedApiHost))
        {
            _lastAppliedApiHost = GetConfiguredApiHost();
        }

        Type? networkConfigType = FindType("BAPBAP.Network.NetworkConfig");
        if (networkConfigType == null)
        {
            return;
        }

        try
        {
            Array? configs = FindLoadedUnityObjects(networkConfigType);
            if (configs == null)
            {
                return;
            }

            foreach (object config in configs)
            {
                PatchNetworkConfig(config, networkConfigType);
            }
        }
        catch (Exception ex)
        {
            LoggerInstance.Warning($"Failed to patch loaded NetworkConfig assets: {ex.Message}");
        }
    }

    private void PatchLoadedLobbyNetworkClients()
    {
        Type? lobbyNetworkClientType = FindType("BAPBAP.Network.LobbyNetworkClient");
        if (lobbyNetworkClientType == null)
        {
            return;
        }

        try
        {
            Array? lobbyClients = FindLoadedUnityObjects(lobbyNetworkClientType);
            if (lobbyClients == null)
            {
                return;
            }

            foreach (object lobbyClient in lobbyClients)
            {
                PatchLobbyNetworkClientRuntime(lobbyClient, "LobbyNetworkClient.loaded-sweep");
            }
        }
        catch (Exception ex)
        {
            LoggerInstance.Warning($"Failed to patch loaded LobbyNetworkClient instances: {ex.GetBaseException().Message}");
        }
    }

    private void PatchLoadedWebServers()
    {
        Type? webServerType = FindType("BAPBAP.Network.WebServer");
        if (webServerType == null)
        {
            return;
        }

        try
        {
            Array? webServers = FindLoadedUnityObjects(webServerType);
            if (webServers == null)
            {
                return;
            }

            foreach (object webServer in webServers)
            {
                PatchWebServerRuntime(webServer);
            }
        }
        catch (Exception ex)
        {
            LoggerInstance.Warning($"Failed to patch loaded WebServer secrets: {ex.GetBaseException().Message}");
        }
    }

    private void PatchWebServerRuntime(object webServer)
    {
        if (string.IsNullOrWhiteSpace(_lastAppliedApiHost))
        {
            _lastAppliedApiHost = GetConfiguredApiHost();
        }

        PatchWebServerSecrets(webServer);

        string apiHost = _lastAppliedApiHost.TrimEnd('/');
        string internalEndpoint = $"{apiHost}/api/internal";
        string matchmakingEndpoint = $"{apiHost}/api/matchmaking";
        bool changed = SetStringMemberIfDifferent(webServer, "_internalApiEndpoint", internalEndpoint);
        changed = SetStringMemberIfDifferent(webServer, "_matchmakingEndpoint", matchmakingEndpoint) || changed;

        if (changed && !_webServerEndpointPatchLogged)
        {
            _webServerEndpointPatchLogged = true;
            LoggerInstance.Msg($"Patched WebServer callback endpoints to {internalEndpoint}.");
        }
    }

    private static void PatchWebServerSecrets(object webServer)
    {
        object? secretHeader = GetMemberValue(webServer, "_secretHeader");
        if (secretHeader is not string header || string.IsNullOrWhiteSpace(header))
        {
            SetMemberValue(webServer, "_secretHeader", DefaultSecretHeaderName);
        }

        object? secret = GetMemberValue(webServer, "_secret");
        if (secret is not string value || string.IsNullOrWhiteSpace(value))
        {
            SetMemberValue(webServer, "_secret", DefaultSecretValue);
        }
    }

    private static bool SetStringMemberIfDifferent(object instance, string name, string value)
    {
        object? current = GetMemberValue(instance, name);
        if (current is string currentString && string.Equals(currentString, value, StringComparison.Ordinal))
        {
            return false;
        }

        return SetMemberValue(instance, name, value);
    }

    private static Array? FindLoadedUnityObjects(Type objectType)
    {
        Array? found = TryInvokeUnityObjectFinder(typeof(Object), "FindObjectsOfType", objectType, includeInactive: true);
        if (found != null)
        {
            return found;
        }

        found = TryInvokeUnityObjectFinder(typeof(Object), "FindObjectsOfType", objectType, includeInactive: false);
        if (found != null)
        {
            return found;
        }

        MethodInfo? method = typeof(Resources)
            .GetMethods(BindingFlags.Static | BindingFlags.Public)
            .FirstOrDefault(candidate =>
            {
                if (candidate.Name != "FindObjectsOfTypeAll")
                {
                    return false;
                }

                ParameterInfo[] parameters = candidate.GetParameters();
                return parameters.Length == 1 && parameters[0].ParameterType == typeof(Type);
            });

        return method?.Invoke(null, new object[] { objectType }) as Array;
    }

    private static Array? TryInvokeUnityObjectFinder(Type ownerType, string methodName, Type objectType, bool includeInactive)
    {
        try
        {
            MethodInfo? method = ownerType
                .GetMethods(BindingFlags.Static | BindingFlags.Public)
                .FirstOrDefault(candidate =>
                {
                    if (candidate.Name != methodName)
                    {
                        return false;
                    }

                    ParameterInfo[] parameters = candidate.GetParameters();
                    return parameters.Length switch
                    {
                        1 => parameters[0].ParameterType == typeof(Type) && !includeInactive,
                        2 => parameters[0].ParameterType == typeof(Type) && parameters[1].ParameterType == typeof(bool),
                        _ => false
                    };
                });

            if (method == null)
            {
                return null;
            }

            object?[] args = method.GetParameters().Length == 1
                ? new object?[] { objectType }
                : new object?[] { objectType, includeInactive };
            return method.Invoke(null, args) as Array;
        }
        catch
        {
            return null;
        }
    }

    private void PatchNetworkConfig(object config, Type networkConfigType)
    {
        if (config == null)
        {
            return;
        }

        string typeName = config.GetType().FullName ?? config.GetType().Name;
        if (typeName.EndsWith("ClientConfig", StringComparison.OrdinalIgnoreCase))
        {
            PatchClientConfig(config);
            return;
        }

        if (typeName.EndsWith("ServerConfig", StringComparison.OrdinalIgnoreCase))
        {
            PatchServerConfig(config);
            return;
        }

        foreach (string name in new[] { "_client", "Client", "client" })
        {
            object? client = GetMemberValueSafe(config, name);
            if (client != null)
            {
                PatchClientConfig(client);
            }
        }

        foreach (string name in new[] { "_clientList", "ClientList", "clientList" })
        {
            foreach (object item in EnumerateListLike(GetMemberValueSafe(config, name)))
            {
                PatchClientConfig(item);
            }
        }

        foreach (string name in new[] { "_server", "Server", "server" })
        {
            object? server = GetMemberValueSafe(config, name);
            if (server != null)
            {
                PatchServerConfig(server);
            }
        }

        foreach (string name in new[] { "_serverList", "ServerList", "serverList" })
        {
            foreach (object item in EnumerateListLike(GetMemberValueSafe(config, name)))
            {
                PatchServerConfig(item);
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
            string? previousHost = TryGetStringMember(clientConfig, "ApiHost");
            bool changed = SetMemberValueBestEffort(clientConfig, "ApiHost", _lastAppliedApiHost);
            changed = SetMemberValueBestEffort(clientConfig, "CookieDomain", GetCookieDomain(_lastAppliedApiHost)) || changed;

            if (string.IsNullOrWhiteSpace(TryGetStringMember(clientConfig, "CookieSessionKey")))
            {
                changed = SetMemberValueBestEffort(clientConfig, "CookieSessionKey", "sid") || changed;
            }

            if (changed &&
                !string.Equals(previousHost, _lastAppliedApiHost, StringComparison.Ordinal) &&
                !string.IsNullOrWhiteSpace(previousHost))
            {
                LoggerInstance.Msg($"Patched NetworkConfig.ClientConfig ApiHost: '{previousHost}' -> '{_lastAppliedApiHost}'");
            }
        }
        catch (Exception ex)
        {
            LoggerInstance.Warning($"Failed to patch client config: {ex.Message}");
        }
    }

    private void PatchPreAwakeManagerNetworkRuntime(object? preAwakeManager, string source)
    {
        if (preAwakeManager == null)
        {
            return;
        }

        try
        {
            if (string.IsNullOrWhiteSpace(_lastAppliedApiHost))
            {
                _lastAppliedApiHost = GetConfiguredApiHost();
            }

            object? networkConfig = GetMemberValueSafe(preAwakeManager, "networkConfig")
                                    ?? GetMemberValueSafe(preAwakeManager, "_networkConfig")
                                    ?? GetMemberValueSafe(preAwakeManager, "NetworkConfig");
            if (networkConfig != null)
            {
                PatchNetworkConfig(networkConfig, networkConfig.GetType());
            }

            if (!_preAwakeManagerNetworkRuntimeLogged && networkConfig != null)
            {
                _preAwakeManagerNetworkRuntimeLogged = true;
                object? client = GetMemberValueSafe(networkConfig, "_client")
                                 ?? GetMemberValueSafe(networkConfig, "Client")
                                 ?? GetMemberValueSafe(networkConfig, "client");
                LoggerInstance.Msg(
                    $"PreAwakeManager network config patched via {source}: " +
                    $"networkConfig=True clientHost='{TryGetStringMember(client, "ApiHost") ?? "null"}'.");
            }
        }
        catch (Exception ex)
        {
            if (!_preAwakeManagerNetworkRuntimeLogged)
            {
                _preAwakeManagerNetworkRuntimeLogged = true;
                LoggerInstance.Warning($"Failed to patch PreAwakeManager network config via {source}: {ex.GetBaseException().Message}");
            }
        }
    }

    private void PatchControllerManagerNetworkRuntime(object? controllerManager, string source)
    {
        if (controllerManager == null)
        {
            return;
        }

        try
        {
            if (string.IsNullOrWhiteSpace(_lastAppliedApiHost))
            {
                _lastAppliedApiHost = GetConfiguredApiHost();
            }

            object? networkConfig = GetMemberValueSafe(controllerManager, "NetworkConfig")
                                    ?? GetMemberValueSafe(controllerManager, "_NetworkConfig_k__BackingField")
                                    ?? GetMemberValueSafe(controllerManager, "<NetworkConfig>k__BackingField");
            if (networkConfig != null)
            {
                PatchNetworkConfig(networkConfig, networkConfig.GetType());
            }

            object? httpClient = GetMemberValueSafe(controllerManager, "Http")
                                 ?? GetMemberValueSafe(controllerManager, "_Http_k__BackingField")
                                 ?? GetMemberValueSafe(controllerManager, "<Http>k__BackingField");
            if (httpClient != null)
            {
                PatchHttpClientRuntime(httpClient);
            }

            if (!_controllerManagerNetworkPatchLogged)
            {
                _controllerManagerNetworkPatchLogged = true;
                object? builder = httpClient == null ? null : GetMemberValueSafe(httpClient, "_uriBuilder");
                LoggerInstance.Msg(
                    $"ControllerManager network runtime patched via {source}: " +
                    $"networkConfig={networkConfig != null} httpClient={httpClient != null} uriBuilder='{builder ?? "null"}'.");
            }
        }
        catch (Exception ex)
        {
            if (!_controllerManagerNetworkPatchLogged)
            {
                _controllerManagerNetworkPatchLogged = true;
                LoggerInstance.Warning($"Failed to patch ControllerManager network runtime via {source}: {ex.GetBaseException().Message}");
            }
        }
    }

    private void PatchLobbyNetworkClientRuntime(object? lobbyNetworkClient, string source)
    {
        if (lobbyNetworkClient == null)
        {
            return;
        }

        try
        {
            if (string.IsNullOrWhiteSpace(_lastAppliedApiHost))
            {
                _lastAppliedApiHost = GetConfiguredApiHost();
            }

            object? networkConfig = GetMemberValueSafe(lobbyNetworkClient, "_networkConfig")
                                    ?? GetMemberValueSafe(lobbyNetworkClient, "NetworkConfig")
                                    ?? GetMemberValueSafe(lobbyNetworkClient, "networkConfig");
            if (networkConfig != null)
            {
                PatchNetworkConfig(networkConfig, networkConfig.GetType());
            }

            object? httpClient = GetMemberValueSafe(lobbyNetworkClient, "_httpClient")
                                 ?? GetMemberValueSafe(lobbyNetworkClient, "Http")
                                 ?? GetMemberValueSafe(lobbyNetworkClient, "httpClient");
            if (httpClient != null)
            {
                PatchHttpClientRuntime(httpClient);
            }

            object? controller = GetMemberValueSafe(lobbyNetworkClient, "Controller")
                                 ?? GetMemberValueSafe(lobbyNetworkClient, "_controller")
                                 ?? GetMemberValueSafe(lobbyNetworkClient, "_controllerManager")
                                 ?? GetMemberValueSafe(lobbyNetworkClient, "controllerManager");
            if (controller != null)
            {
                PatchControllerManagerNetworkRuntime(controller, $"{source}->controller");
            }

            if (!_lobbyNetworkClientRuntimeLogged && (networkConfig != null || httpClient != null || controller != null))
            {
                _lobbyNetworkClientRuntimeLogged = true;
                object? directBuilder = httpClient == null ? null : GetMemberValueSafe(httpClient, "_uriBuilder");
                object? controllerHttp = controller == null ? null :
                    GetMemberValueSafe(controller, "Http")
                    ?? GetMemberValueSafe(controller, "_Http_k__BackingField")
                    ?? GetMemberValueSafe(controller, "<Http>k__BackingField");
                object? controllerBuilder = controllerHttp == null ? null : GetMemberValueSafe(controllerHttp, "_uriBuilder");
                LoggerInstance.Msg(
                    $"LobbyNetworkClient runtime patched via {source}: " +
                    $"networkConfig={networkConfig != null} httpClient={httpClient != null} controller={controller != null} " +
                    $"directUriBuilder='{directBuilder ?? "null"}' controllerUriBuilder='{controllerBuilder ?? "null"}'.");
            }
        }
        catch (Exception ex)
        {
            if (!_lobbyNetworkClientRuntimeLogged)
            {
                _lobbyNetworkClientRuntimeLogged = true;
                LoggerInstance.Warning($"Failed to patch LobbyNetworkClient runtime via {source}: {ex.GetBaseException().Message}");
            }
        }
    }

    private void RewriteHttpClientHost(ref string host)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(host))
            {
                return;
            }

            bool proxyDisabled = _localProxyEntry?.Value != true;
            if (!proxyDisabled)
            {
                return;
            }

            if (!Uri.TryCreate(host, UriKind.Absolute, out Uri? uri) || !IsLoopbackHost(uri.Host))
            {
                return;
            }

            bool knownLocalApiPort =
                uri.Port == DefaultLocalProxyPort ||
                uri.Port == DefaultServerPort ||
                uri.Port == _serverPortEntry.Value ||
                uri.Port == _localPortEntry.Value;
            if (!knownLocalApiPort)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(_lastAppliedApiHost))
            {
                _lastAppliedApiHost = GetConfiguredApiHost();
            }

            string replacement = _lastAppliedApiHost.TrimEnd('/');
            if (string.Equals(host.TrimEnd('/'), replacement, StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            string previous = host;
            host = replacement;
            if (!_httpClientHostRewriteLogged)
            {
                _httpClientHostRewriteLogged = true;
                LoggerInstance.Msg($"Rewrote BAPBAP.Network.HttpClient host for direct custom-server mode: '{previous}' -> '{replacement}'.");
            }
        }
        catch (Exception ex)
        {
            if (!_httpClientHostRewriteLogged)
            {
                _httpClientHostRewriteLogged = true;
                LoggerInstance.Warning($"Failed to rewrite HttpClient host: {ex.GetBaseException().Message}");
            }
        }
    }

    private void PatchHttpClientRuntime(object? httpClient)
    {
        PatchHttpClientUriBuilder(httpClient);
        PatchHttpClientConfiguration(httpClient);
    }

    private void PatchHttpClientUriBuilder(object? httpClient)
    {
        try
        {
            if (httpClient == null || _localProxyEntry?.Value == true)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(_lastAppliedApiHost))
            {
                _lastAppliedApiHost = GetConfiguredApiHost();
            }

            if (!Uri.TryCreate(_lastAppliedApiHost, UriKind.Absolute, out Uri? target))
            {
                return;
            }

            object? builder = GetMemberValue(httpClient, "_uriBuilder");
            if (builder == null)
            {
                return;
            }

            string before = builder.ToString() ?? "";
            if (Uri.TryCreate(before, UriKind.Absolute, out Uri? current) &&
                !IsLoopbackHost(current.Host))
            {
                return;
            }

            bool changed = false;
            changed |= SetMemberValue(builder, "Scheme", target.Scheme);
            changed |= SetMemberValue(builder, "Host", target.Host);
            int port = target.IsDefaultPort ? -1 : target.Port;
            changed |= SetMemberValue(builder, "Port", port);

            if (changed && !_httpClientUriBuilderRewriteLogged)
            {
                _httpClientUriBuilderRewriteLogged = true;
                LoggerInstance.Msg($"Rewrote BAPBAP.Network.HttpClient UriBuilder for direct custom-server mode: '{before}' -> '{builder}'.");
            }
        }
        catch (Exception ex)
        {
            if (!_httpClientUriBuilderRewriteLogged)
            {
                _httpClientUriBuilderRewriteLogged = true;
                LoggerInstance.Warning($"Failed to patch HttpClient UriBuilder: {ex.GetBaseException().Message}");
            }
        }
    }

    private void PatchHttpClientConfiguration(object? httpClient)
    {
        try
        {
            if (httpClient == null || _localProxyEntry?.Value == true)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(_lastAppliedApiHost))
            {
                _lastAppliedApiHost = GetConfiguredApiHost();
            }

            if (!Uri.TryCreate(_lastAppliedApiHost, UriKind.Absolute, out Uri? target))
            {
                return;
            }

            object? configuration = GetMemberValueSafe(httpClient, "_configuration")
                                    ?? GetMemberValueSafe(httpClient, "configuration")
                                    ?? GetMemberValueSafe(httpClient, "Configuration");
            if (configuration == null)
            {
                return;
            }

            string? previousEndpoint = TryGetStringMember(configuration, "endpoint");
            object? previousPort = GetMemberValueSafe(configuration, "port");
            bool changed = false;
            changed = SetMemberValueBestEffort(configuration, "scheme", target.Scheme) || changed;
            changed = SetMemberValueBestEffort(configuration, "endpoint", target.Host) || changed;
            changed = SetMemberValueBestEffort(configuration, "port", target.IsDefaultPort ? -1 : target.Port) || changed;

            if (changed && !_httpClientConfigurationRewriteLogged)
            {
                _httpClientConfigurationRewriteLogged = true;
                LoggerInstance.Msg(
                    "Rewrote BAPBAP.Network.HttpClient Configuration for direct custom-server mode: " +
                    $"endpoint='{previousEndpoint ?? "null"}' port={previousPort ?? "null"} -> " +
                    $"{target.Scheme}://{target.Host}:{(target.IsDefaultPort ? -1 : target.Port)}.");
            }
        }
        catch (Exception ex)
        {
            if (!_httpClientConfigurationRewriteLogged)
            {
                _httpClientConfigurationRewriteLogged = true;
                LoggerInstance.Warning($"Failed to patch HttpClient Configuration: {ex.GetBaseException().Message}");
            }
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
            const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

            FieldInfo? headerSecretKey = type.GetField("HeaderSecretKey", flags);
            if (headerSecretKey != null && string.IsNullOrWhiteSpace(headerSecretKey.GetValue(serverConfig) as string))
            {
                headerSecretKey.SetValue(serverConfig, DefaultSecretHeaderName);
            }

            FieldInfo? headerSecret = type.GetField("HeaderSecret", flags);
            if (headerSecret != null && string.IsNullOrWhiteSpace(headerSecret.GetValue(serverConfig) as string))
            {
                headerSecret.SetValue(serverConfig, DefaultSecretValue);
            }

            // Dedicated-server fix: set ListenPort + MatchmakingHost so Mirror's transport actually binds.
            // Without this, ServerConfig.ListenPort stays 0 → no TCP listener opens → clients cannot join match.
            CustomServerMod? active = s_active;
            if (active != null && active._dedicatedProcess)
            {
                int? listenPort = active._dedicatedTcpPort ?? active._dedicatedWsPort;
                if (listenPort.HasValue && listenPort.Value > 0)
                {
                    FieldInfo? listenPortField = type.GetField("ListenPort", flags);
                    if (listenPortField != null)
                    {
                        Type fieldType = listenPortField.FieldType;
                        object? current = listenPortField.GetValue(serverConfig);
                        bool needsPatch = current switch
                        {
                            int i => i == 0,
                            ushort us => us == 0,
                            short s => s == 0,
                            uint u => u == 0,
                            long l => l == 0,
                            _ => false,
                        };

                        if (needsPatch)
                        {
                            object newValue = listenPort.Value;
                            if (fieldType == typeof(ushort)) { newValue = (ushort)listenPort.Value; }
                            else if (fieldType == typeof(short)) { newValue = (short)listenPort.Value; }
                            else if (fieldType == typeof(uint)) { newValue = (uint)listenPort.Value; }
                            else if (fieldType == typeof(long)) { newValue = (long)listenPort.Value; }
                            listenPortField.SetValue(serverConfig, newValue);
                            active.LoggerInstance.Msg($"[ServerConfig] Patched ListenPort 0 -> {listenPort.Value}");
                        }
                    }
                }

                FieldInfo? matchmakingHostField = type.GetField("MatchmakingHost", flags);
                if (matchmakingHostField != null)
                {
                    string? currentHost = matchmakingHostField.GetValue(serverConfig) as string;
                    if (string.IsNullOrWhiteSpace(currentHost))
                    {
                        matchmakingHostField.SetValue(serverConfig, "127.0.0.1");
                        active.LoggerInstance.Msg("[ServerConfig] Patched MatchmakingHost '' -> '127.0.0.1'");
                    }
                }
            }
        }
        catch
        {
            // Server config patching is best-effort for local callback auth.
        }
    }

    private static string GetCookieDomain(string apiHost)
    {
        if (Uri.TryCreate(apiHost, UriKind.Absolute, out Uri? uri))
        {
            return uri.Host;
        }

        return "127.0.0.1";
    }

    private static Type? FindType(string fullName)
    {
        if (s_typeCache.TryGetValue(fullName, out Type? cached))
        {
            return cached;
        }

        string[] candidates =
        {
            fullName,
            fullName.StartsWith("Il2Cpp", StringComparison.Ordinal) ? fullName : "Il2Cpp" + fullName,
            fullName.StartsWith("Il2Cpp.", StringComparison.Ordinal) ? fullName : "Il2Cpp." + fullName
        };

        foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            if (!ShouldSearchAssemblyForType(assembly, fullName))
            {
                continue;
            }

            try
            {
                foreach (string candidate in candidates)
                {
                    Type? type = assembly.GetType(candidate, throwOnError: false);
                    if (type != null)
                    {
                        s_typeCache.TryAdd(fullName, type);
                        return type;
                    }
                }
            }
            catch
            {
                // Some Unity assemblies can throw while enumerating. Keep scanning.
            }
        }

        return null;
    }

    private static bool ShouldSearchAssemblyForType(Assembly assembly, string fullName)
    {
        string assemblyName;
        try
        {
            assemblyName = assembly.GetName().Name ?? "";
        }
        catch
        {
            return false;
        }

        if (string.IsNullOrWhiteSpace(assemblyName))
        {
            return false;
        }

        if (fullName.StartsWith("BAPBAP.", StringComparison.Ordinal) ||
            fullName.StartsWith("Il2CppBAPBAP.", StringComparison.Ordinal) ||
            fullName.StartsWith("Il2Cpp.BAPBAP.", StringComparison.Ordinal))
        {
            return assemblyName.Equals("Assembly-CSharp", StringComparison.OrdinalIgnoreCase) ||
                   assemblyName.Equals("Il2CppAssembly-CSharp", StringComparison.OrdinalIgnoreCase) ||
                   assemblyName.Contains("BAPBAP", StringComparison.OrdinalIgnoreCase);
        }

        if (fullName.StartsWith("UnityEngine.", StringComparison.Ordinal) ||
            fullName.StartsWith("Il2CppUnityEngine.", StringComparison.Ordinal))
        {
            return assemblyName.StartsWith("UnityEngine", StringComparison.OrdinalIgnoreCase);
        }

        if (fullName.StartsWith("TMPro.", StringComparison.Ordinal) ||
            fullName.StartsWith("Il2CppTMPro.", StringComparison.Ordinal))
        {
            return assemblyName.Contains("TextMeshPro", StringComparison.OrdinalIgnoreCase) ||
                   assemblyName.Contains("TMPro", StringComparison.OrdinalIgnoreCase);
        }

        if (fullName.StartsWith("Mirror.", StringComparison.Ordinal) ||
            fullName.StartsWith("Il2CppMirror.", StringComparison.Ordinal))
        {
            return assemblyName.Contains("Mirror", StringComparison.OrdinalIgnoreCase) ||
                   assemblyName.Equals("Assembly-CSharp", StringComparison.OrdinalIgnoreCase) ||
                   assemblyName.Equals("Il2CppAssembly-CSharp", StringComparison.OrdinalIgnoreCase);
        }

        if (fullName.StartsWith("kcp2k.", StringComparison.Ordinal) ||
            fullName.StartsWith("Il2Cppkcp2k.", StringComparison.Ordinal))
        {
            return assemblyName.Contains("kcp", StringComparison.OrdinalIgnoreCase) ||
                   assemblyName.Contains("Mirror.Transports", StringComparison.OrdinalIgnoreCase) ||
                   assemblyName.Equals("Il2CppMirror.Transports", StringComparison.OrdinalIgnoreCase);
        }

        if (fullName.StartsWith("HarmonyLib.", StringComparison.Ordinal))
        {
            return assemblyName.Contains("Harmony", StringComparison.OrdinalIgnoreCase) ||
                   assemblyName.Equals("0Harmony", StringComparison.OrdinalIgnoreCase);
        }

        return assemblyName.Equals("Assembly-CSharp", StringComparison.OrdinalIgnoreCase) ||
               assemblyName.StartsWith("Il2Cpp", StringComparison.OrdinalIgnoreCase);
    }

    private sealed record BootstrapPayload(string Path, string Json);

    private sealed record AutoGuestLoginRequest(object Controller, string Reason);

    private readonly struct DisabledScope : IDisposable
    {
        private readonly bool _previous;

        public DisabledScope(bool disabled)
        {
            _previous = GUI.enabled;
            GUI.enabled = !disabled;
        }

        public void Dispose()
        {
            GUI.enabled = _previous;
        }
    }
}

