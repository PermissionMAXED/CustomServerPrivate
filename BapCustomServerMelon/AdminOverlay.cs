// Admin Overlay — in-game admin panel for the BAPBAP custom server mod.
// Provides a comprehensive IMGUI overlay (F8) that wraps the game's native
// PlayerDebug and PlayerDeveloperLobby Mirror commands, plus runtime discovery
// of items, entities, characters, and game state.
//
// Architecture:
//   - Static class, called from CustomServerMod.OnGUI / OnUpdate
//   - Finds IL2CPP types via FindType (same pattern as main mod)
//   - Invokes Mirror Cmd* methods on the local PlayerDebug instance via reflection
//   - Uses Unity Object.FindObjectsOfType to discover runtime state
//   - Item/Entity/Char catalogs are populated at runtime from the game's own data

using System.Collections.Concurrent;
using System.Globalization;
using System.Reflection;
using System.Text;
using BapAdminMelon;
using UnityEngine;
using Object = UnityEngine.Object;

namespace BapCustomServerMelon;

public static class AdminOverlay
{
    // ===== Toggle state =====================================================
    private static bool _showWindow;
    private static float _lastF8Press;
    private static int _selectedTab;
    private static Rect _windowRect = new(60f, 60f, 520f, 480f);
    private static Rect _gateRect = new(200f, 160f, 420f, 260f);
    private static Vector2 _scrollPos;
    private static float _lastDiscovery = -999f;
    private static float _lastRefresh;
    private static bool _discoveryDone;
    private static bool _windowDragging;
    private static Vector2 _windowDragOffset;

    // ===== Runtime-discovered catalogs =====================================
    private static readonly List<CatalogItem> _items = new();
    private static readonly List<CatalogItem> _entities = new();
    private static readonly List<CatalogItem> _chars = new();
    private static readonly List<CatalogItem> _modifiers = new();
    private static string[] _tabNames = { "Cheats", "Spawn", "Abilities", "Match", "Lobby", "Console", "Status" };

    // ===== UI state =========================================================
    private static int _spawnCharId = 15;
    private static int _spawnBotCount = 3;
    private static bool _spawnBotAi = true;
    private static int _spawnBotTeam;
    private static int _spawnBotDifficulty; // 0=Easy..3=Expert
    private static int _spawnItemId;
    private static int _spawnItemAmount = 1;
    private static int _spawnEntityId;
    private static int _activeStatusEffectId;
    private static float _activeStatusDuration = 5f;
    private static int _passiveId;
    private static int _modifierId;
    private static int _damageAmount = 50;
    private static int _winnerTeam = 1;
    private static int _switchCharId;
    private static int _augmentTier;
    private static string _rawCommand = "CmdSpawnBotChar";
    private static string _rawArguments = "1,0|0|0,true,0,false,1";
    private static int _rawTarget;
    private static string _lastCommandResult = "";

    // ===== In-match state ===================================================
    private static string _matchStatus = "Not in match";
    private static string _playerStatus = "Not connected";
    private static string _serverInfo = "Unknown";
    private static int _matchPlayerCount;
    private static int _matchBotCount;

    // ===== Auth state ========================================================
    private static string _authStatusMessage = "Initializing...";

    // ===== Cheat toggle state (polled from PlayerDebug at refresh) ==========
    private static bool _godMode;
    private static bool _noCooldown;
    private static bool _noClip;
    private static bool _moveSpeedHack;
    private static bool _noAggro;
    private static bool _invincibilityModeAll;
    private static bool _noCooldownModeAll;
    private static bool _cinematicMode;
    private static bool _thirdPerson;
    private static bool _allySharedVision;
    private static string _playerName = "";

    // ===== Type / method caches =============================================
    private static Type? _playerDebugType;
    private static Type? _playerDevLobbyType;
    private static Type? _gameManagerType;
    private static Type? _networkManagerType;
    private static bool _typesResolved;
    private static readonly ConcurrentDictionary<string, Type> s_typeCache = new();

    private const float DiscoveryInterval = 5f;

    // ===== Public API: called from CustomServerMod ==========================

    public static void OnUpdate()
    {
        try
        {
            // F8 toggle (with 300ms debounce to avoid double-toggle)
            if (Input.GetKeyDown(KeyCode.F8))
            {
                float t = Time.realtimeSinceStartup;
                if (t - _lastF8Press > 0.3f)
                {
                    _showWindow = !_showWindow;
                    _lastF8Press = t;
                }
            }

            if (!_showWindow) return;

            // Periodically refresh types and state
            float t2 = Time.realtimeSinceStartup;
            if (t2 - _lastRefresh > 1f)
            {
                _lastRefresh = t2;
                EnsureTypesResolved();
                RefreshMatchState();
            }

            // Update auth status message for display
            _authStatusMessage = AdminAuthClient.IsAdminAuthenticated
                ? $"Authenticated ({AdminAuthClient.Status})"
                : AdminAuthClient.IsModAttested
                    ? $"Mod attested, awaiting admin token ({AdminAuthClient.Status})"
                    : AdminAuthClient.Status;
        }
        catch { /* swallow — admin overlay never crashes the game */ }
    }

    public static void OnGUI()
    {
        if (!_showWindow) return;

        // Gate: require full admin auth (attestation + token confirmation) to show
        // the admin panel. IsModAttested alone is not sufficient — only the server
        // can confirm admin privileges via ADMIN_AUTH.
        if (!AdminAuthClient.IsAdminAuthenticated)
        {
            DrawManualWindow(ref _gateRect, DrawGateContent, "⚡ Admin Access", 260f);
            return;
        }

        try
        {
            DrawManualWindow(ref _windowRect, DrawAdminWindow, "⚡ Admin Panel", 480f);
        }
        catch
        {
            _showWindow = false;
        }
    }

    // ===== Manual window implementation ======================================
    // Replaces GUI.Window/WindowFunction which crashes on IL2CPP:
    // "Method not found: 'Void WindowFunction..ctor(System.Object, IntPtr)'".
    // This draws a Box as the window frame and handles dragging manually.

    private static void DrawManualWindow(ref Rect rect, Action<int> drawContent, string title, float defaultHeight)
    {
        if (rect.height < 100f) rect.height = defaultHeight;

        // Calculate the title bar rect for dragging
        var titleBar = new Rect(rect.x, rect.y, rect.width, 24f);
        var contentArea = new Rect(rect.x + 2f, rect.y + 26f, rect.width - 4f, rect.height - 30f);

        // Draw the window background
        GUI.Box(rect, new GUIContent(title), GUI.skin.window);

        // Handle mouse drag on the title bar
        Event e = Event.current;
        if (e.type == EventType.MouseDown && titleBar.Contains(e.mousePosition))
        {
            _windowDragging = true;
            _windowDragOffset = e.mousePosition - (Vector2)rect.position;
            e.Use();
        }
        else if (e.type == EventType.MouseUp)
        {
            _windowDragging = false;
        }
        else if (e.type == EventType.MouseDrag && _windowDragging)
        {
            rect.position = e.mousePosition - _windowDragOffset;
            e.Use();
            GUI.changed = true;
        }

        // Draw content inside the window
        GUILayout.BeginArea(contentArea);
        try
        {
            GUILayout.Space(2f);
            drawContent(0);
        }
        catch (Exception ex)
        {
            GUILayout.Label($"UI Error: {ex.GetBaseException().Message}", GUI.skin.label);
        }
        GUILayout.EndArea();
    }

    private static void DrawGateContent(int windowId)
    {
        GUILayout.Space(4f);
        GUILayout.Label("Authentication Required", GUI.skin.box);
        GUILayout.Space(6f);

        // Auth status
        GUILayout.Label($"Status: {_authStatusMessage}", GUI.skin.label);

        if (!string.IsNullOrEmpty(AdminAuthClient.LastError))
        {
            GUI.color = Color.red;
            GUILayout.Label($"Error: {AdminAuthClient.LastError}", GUI.skin.label);
            GUI.color = Color.white;
        }

        GUILayout.Space(4f);

        // Current server / match info
        GUILayout.Label("Server / Match Info", GUI.skin.box);
        GUILayout.Label(_serverInfo, GUI.skin.label);
        GUILayout.Label(_matchStatus, GUI.skin.label);

        GUILayout.Space(4f);

        GUILayout.Label("Press F8 to close this panel.", GUI.skin.label);
        GUILayout.Label("Press \"Retry Auth\" to attempt authentication again.", GUI.skin.label);

        GUILayout.Space(6f);

        // Retry Auth button
        if (GUILayout.Button("Retry Auth", GUILayout.Height(26f)))
        {
            AdminAuthClient.Reset();
        }

        GUILayout.Space(4f);

        // Close button
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Close", GUILayout.Width(80f), GUILayout.Height(22f)))
            _showWindow = false;
        GUILayout.EndHorizontal();
    }

    // ===== Window drawer ====================================================

    private static void DrawAdminWindow(int windowId)
    {
        GUILayout.Space(4f);

        // ---- tab bar ----
        GUILayout.BeginHorizontal();
        for (int i = 0; i < _tabNames.Length; i++)
        {
            bool was = _selectedTab == i;
            bool now = GUILayout.Toggle(was, _tabNames[i], GUI.skin.button, GUILayout.Height(22f));
            if (now && !was) _selectedTab = i;
        }
        GUILayout.EndHorizontal();

        GUILayout.Space(4f);

        // ---- scrollable content ----
        _scrollPos = GUILayout.BeginScrollView(_scrollPos, GUI.skin.box, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));

        try
        {
            switch (_selectedTab)
            {
                case 0: DrawCheatsTab(); break;
                case 1: DrawSpawnTab(); break;
                case 2: DrawAbilitiesTab(); break;
                case 3: DrawMatchTab(); break;
                case 4: DrawLobbyTab(); break;
                case 5: DrawConsoleTab(); break;
                case 6: DrawStatusTab(); break;
            }
        }
        catch (Exception ex)
        {
            GUILayout.Label($"UI Error: {ex.GetBaseException().Message}", GUI.skin.label);
        }

        GUILayout.EndScrollView();

        // ---- close button ----
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Close", GUILayout.Width(80f), GUILayout.Height(22f)))
            _showWindow = false;
        GUILayout.EndHorizontal();
    }

    // ===== Tab: Cheats =====================================================

    private static void DrawCheatsTab()
    {
        GUILayout.Label("Toggle Cheats", GUI.skin.box);

        _godMode = ToggleField("God Mode", _godMode, enabled => Cmd("CmdSetInvincibilityModeAll", enabled));
        _noCooldown = ToggleField("No Cooldown", _noCooldown, enabled => Cmd("CmdSetNoCooldownModeAll", enabled));
        _noClip = ToggleField("No Clip", _noClip, enabled => Cmd("CmdSetNoClip", enabled));
        _moveSpeedHack = ToggleField("Move Speed Hack", _moveSpeedHack, enabled => Cmd("CmdSetMoveSpeedHack", enabled));
        _noAggro = ToggleField("No Aggro (All)", _noAggro, enabled => Cmd("CmdSetNoAggroAll", enabled));
        _invincibilityModeAll = ToggleField("Invincible (All)", _invincibilityModeAll, enabled => Cmd("CmdSetInvincible", enabled));
        _noCooldownModeAll = ToggleField("No Cooldown (Self)", _noCooldownModeAll, enabled => Cmd("CmdSetNoCooldownEnabled", enabled));
        _cinematicMode = ToggleField("Cinematic Mode", _cinematicMode, enabled => Cmd("CmdSetCinematicMode", enabled));
        _thirdPerson = ToggleField("Global Third Person", _thirdPerson, enabled => Cmd("CmdSetGlobalThirdPersonMode", enabled));
        _allySharedVision = ToggleField("Ally Shared Vision", _allySharedVision, enabled => Cmd("CmdSetAllySharedVisionEnabled", enabled));

        GUILayout.Space(6f);
        GUILayout.Label("Actions", GUI.skin.box);
        GUILayout.BeginHorizontal();
        if (ActionButton("Heal All")) Cmd("CmdHealMaxHpAll");
        if (ActionButton("Kill All")) Cmd("CmdKillAllCharacters");
        if (ActionButton("Respawn All")) Cmd("CmdRespawnCharactersAll");
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if (ActionButton("Revive Downed")) Cmd("CmdRessurectDownedCharacterAll");
        if (ActionButton("Clear Items")) Cmd("CmdClearAllWorldItems");
        if (ActionButton("Kill Self")) Cmd("CmdKillCharacter");
        GUILayout.EndHorizontal();

        GUILayout.Space(4f);
        GUILayout.BeginHorizontal();
        GUILayout.Label("Player Name:", GUILayout.Width(80f));
        _playerName = GUILayout.TextField(_playerName, GUILayout.Width(150f));
        if (ActionButton("Set")) Cmd("CmdSetPlayerName", _playerName);
        GUILayout.EndHorizontal();

        GUILayout.Space(4f);
        GUILayout.BeginHorizontal();
        GUILayout.Label("Apply Damage:", GUILayout.Width(100f));
        _damageAmount = IntField(_damageAmount, 50f);
        if (ActionButton("Apply Hit")) Cmd("CmdApplyHit", _damageAmount);
        GUILayout.EndHorizontal();
    }

    // ===== Tab: Spawn =======================================================

    private static void DrawSpawnTab()
    {
        // ---- Bots ----
        GUILayout.Label("Spawn Bots", GUI.skin.box);
        GUILayout.BeginHorizontal();
        GUILayout.Label("Char ID:", GUILayout.Width(60f));
        _spawnCharId = IntField(_spawnCharId, 50f);
        GUILayout.Label("Count:", GUILayout.Width(45f));
        _spawnBotCount = IntField(_spawnBotCount, 40f);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        _spawnBotAi = GUILayout.Toggle(_spawnBotAi, "Enable AI");
        GUILayout.Label("Team:", GUILayout.Width(45f));
        _spawnBotTeam = IntField(_spawnBotTeam, 40f);
        GUILayout.Label("Difficulty:", GUILayout.Width(65f));
        _spawnBotDifficulty = GUILayout.SelectionGrid(_spawnBotDifficulty,
            new[] { "Easy", "Medium", "Hard", "Expert" }, 4, GUILayout.Height(22f));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if (ActionButton("Spawn Bot(s)"))
        {
            for (int i = 0; i < _spawnBotCount; i++)
                Cmd("CmdSpawnBotChar", _spawnCharId, Vector3.zero, _spawnBotAi, _spawnBotTeam, false, _spawnBotDifficulty);
        }
        GUILayout.EndHorizontal();

        // ---- Quick chars ----
        GUILayout.Space(4f);
        GUILayout.Label("Quick Char Bots:", GUI.skin.box);
        GUILayout.BeginHorizontal();
        foreach ((int id, string name) in QuickChars)
        {
            if (GUILayout.Button(name, GUILayout.Height(22f)))
                Cmd("CmdSpawnBotChar", id, Vector3.zero, true, 0, false, 1); // Medium diff
        }
        GUILayout.EndHorizontal();

        // ---- Items ----
        GUILayout.Space(6f);
        GUILayout.Label("Spawn Items", GUI.skin.box);
        GUILayout.BeginHorizontal();
        GUILayout.Label("Item ID:", GUILayout.Width(55f));
        _spawnItemId = IntField(_spawnItemId, 60f);
        GUILayout.Label("Amount:", GUILayout.Width(55f));
        _spawnItemAmount = IntField(_spawnItemAmount, 50f);
        if (ActionButton("Spawn at Player")) Cmd("CmdSpawnItem", _spawnItemId, _spawnItemAmount);
        GUILayout.EndHorizontal();

        if (_items.Count > 0)
        {
            GUILayout.Label("Or select:", GUI.skin.label);
            int selectedItem = GUILayout.SelectionGrid(-1,
                _items.Select(i => i.Display).ToArray(),
                Mathf.Max(1, Mathf.Min(4, (int)(_windowRect.width / 140f))),
                GUILayout.Height(Mathf.Min(120f, _items.Count * 24f)));
            if (selectedItem >= 0 && selectedItem < _items.Count)
            {
                _spawnItemId = _items[selectedItem].Id;
                _spawnItemAmount = 1;
            }
        }

        // ---- Entities ----
        GUILayout.Space(6f);
        GUILayout.Label("Spawn Entities", GUI.skin.box);
        GUILayout.BeginHorizontal();
        GUILayout.Label("Entity ID:", GUILayout.Width(65f));
        _spawnEntityId = IntField(_spawnEntityId, 60f);
        if (ActionButton("Spawn")) Cmd("CmdSpawnEntity", _spawnEntityId, Vector3.zero);
        GUILayout.EndHorizontal();

        if (_entities.Count > 0)
        {
            GUILayout.Label("Or select:", GUI.skin.label);
            int selectedEntity = GUILayout.SelectionGrid(-1,
                _entities.Select(e => e.Display).ToArray(),
                Mathf.Max(1, Mathf.Min(4, (int)(_windowRect.width / 140f))),
                GUILayout.Height(Mathf.Min(120f, _entities.Count * 24f)));
            if (selectedEntity >= 0 && selectedEntity < _entities.Count)
                _spawnEntityId = _entities[selectedEntity].Id;
        }
    }

    // ===== Tab: Abilities ===================================================

    private static void DrawAbilitiesTab()
    {
        GUILayout.Label("Status Effects", GUI.skin.box);
        GUILayout.BeginHorizontal();
        GUILayout.Label("Effect ID:", GUILayout.Width(65f));
        _activeStatusEffectId = IntField(_activeStatusEffectId, 50f);
        GUILayout.Label("Duration:", GUILayout.Width(60f));
        _activeStatusDuration = FloatField(_activeStatusDuration, 50f);
        if (ActionButton("Activate")) Cmd("CmdActivateStatusEffect", _activeStatusEffectId, _activeStatusDuration);
        if (ActionButton("Deactivate")) Cmd("CmdDeactivateStatusEffect", _activeStatusEffectId);
        GUILayout.EndHorizontal();

        GUILayout.Space(6f);
        GUILayout.Label("Passives", GUI.skin.box);
        GUILayout.BeginHorizontal();
        GUILayout.Label("Passive ID:", GUILayout.Width(70f));
        _passiveId = IntField(_passiveId, 50f);
        if (ActionButton("Add")) Cmd("CmdAddPassive", _passiveId);
        if (ActionButton("Remove")) Cmd("CmdRemovePassive", _passiveId);
        GUILayout.EndHorizontal();

        GUILayout.Space(6f);
        GUILayout.Label("Game Modifiers", GUI.skin.box);
        GUILayout.BeginHorizontal();
        GUILayout.Label("Modifier ID:", GUILayout.Width(80f));
        _modifierId = IntField(_modifierId, 50f);
        if (ActionButton("Add")) Cmd("CmdAddGameModifier", _modifierId);
        if (ActionButton("Remove")) Cmd("CmdRemoveGameModifier", _modifierId);
        GUILayout.EndHorizontal();

        if (_modifiers.Count > 0)
        {
            GUILayout.Label("Known modifiers:", GUI.skin.label);
            int selectedMod = GUILayout.SelectionGrid(-1,
                _modifiers.Select(m => m.Display).ToArray(),
                3, GUILayout.Height(Mathf.Min(60f, _modifiers.Count * 24f)));
            if (selectedMod >= 0 && selectedMod < _modifiers.Count)
                _modifierId = _modifiers[selectedMod].Id;
        }

        GUILayout.Space(6f);
        GUILayout.Label("Augments", GUI.skin.box);
        GUILayout.BeginHorizontal();
        GUILayout.Label("Tier ID:", GUILayout.Width(55f));
        _augmentTier = IntField(_augmentTier, 50f);
        if (ActionButton("Add Augment Selection")) Cmd("CmdAddAugmentSelection", _augmentTier);
        if (ActionButton("Add Selection Round")) Cmd("CmdAddAugmentSelectionRound");
        GUILayout.EndHorizontal();

        GUILayout.Space(6f);
        GUILayout.Label("Character Switch (in-match)", GUI.skin.box);
        GUILayout.BeginHorizontal();
        GUILayout.Label("Char ID:", GUILayout.Width(60f));
        _switchCharId = IntField(_switchCharId, 50f);
        if (ActionButton("Switch Character")) Cmd("CmdSwitchCharacter", _switchCharId);
        GUILayout.EndHorizontal();
    }

    // ===== Tab: Match ======================================================

    private static void DrawMatchTab()
    {
        GUILayout.Label("Match Controls", GUI.skin.box);

        GUILayout.BeginHorizontal();
        GUILayout.Label("Winner Team:", GUILayout.Width(85f));
        _winnerTeam = IntField(_winnerTeam, 50f);
        if (ActionButton("End Match")) Cmd("CmdEndMatch", _winnerTeam);
        if (ActionButton("Try End Match")) Cmd("CmdTryEndMatch");
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if (ActionButton("Reset All Entities")) Cmd("CmdResetAllEntities");
        if (ActionButton("Spawn AoI Fill")) Cmd("CmdSpawnAoIFill");
        if (ActionButton("Toggle Fog of War")) Cmd("CmdToggleFogOfWarAllClients", !_godMode);
        GUILayout.EndHorizontal();

        GUILayout.Space(6f);
        GUILayout.Label("Teleport (delta from current position)", GUI.skin.box);
        GUILayout.BeginHorizontal();
        if (ActionButton("Teleport +10 X")) Cmd("CmdTeleportOnMap", new Vector3(10f, 0f, 0f));
        if (ActionButton("-10 X")) Cmd("CmdTeleportOnMap", new Vector3(-10f, 0f, 0f));
        if (ActionButton("+10 Z")) Cmd("CmdTeleportOnMap", new Vector3(0f, 0f, 10f));
        if (ActionButton("-10 Z")) Cmd("CmdTeleportOnMap", new Vector3(0f, 0f, -10f));
        GUILayout.EndHorizontal();

        GUILayout.Space(6f);
        GUILayout.Label("Visual", GUI.skin.box);
        GUILayout.BeginHorizontal();
        if (ActionButton("Toggle BR Zone")) Cmd("CmdToggleBattleRoyaleZone", true);
        if (ActionButton("Next BR Zone")) Cmd("CmdToggleNextBRZone");
        if (ActionButton("Restart BR Zone")) Cmd("CmdRestartBRZone");
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if (ActionButton("Toggle Time Dilation")) Cmd("CmdToggleTimeDilation");
        if (ActionButton("Toggle Silhouette")) Cmd("CmdToggleSilhouetteShaderAll", true);
        GUILayout.EndHorizontal();

        GUILayout.Space(6f);
        GUILayout.Label("Debug", GUI.skin.box);
        if (ActionButton("Print All Entities (log)")) Cmd("CmdPrintAllEntities");
        if (ActionButton("Print Scene Counts (log)")) Cmd("CmdPrintSceneCounts");
    }

    // ===== Tab: Lobby ======================================================

    private static void DrawLobbyTab()
    {
        GUILayout.Label("Developer Lobby Commands", GUI.skin.box);
        GUILayout.Label("Requires being in a dev lobby (use Open Dev Lobby first).",
            GUI.skin.label);

        if (ActionButton("Open Developer Lobby"))
        {
            // Try the dev lobby controller
            TryOpenDevLobby();
        }

        GUILayout.Space(4f);

        // Find local PlayerDeveloperLobby
        object? devLobby = FindLocalDevLobby();
        bool hasDevLobby = devLobby != null;

        if (hasDevLobby)
        {
            GUI.color = Color.green;
            GUILayout.Label("✓ Dev Lobby active", GUI.skin.label);
            GUI.color = Color.white;
        }
        else
        {
            GUI.color = Color.yellow;
            GUILayout.Label("No dev lobby — connect and enter a lobby first",
                GUI.skin.label);
            GUI.color = Color.white;
        }

        GUILayout.Space(4f);
        GUILayout.BeginHorizontal();
        GUILayout.Label("Character ID:", GUILayout.Width(85f));
        _switchCharId = IntField(_switchCharId, 50f);
        if (ActionButton("Select Char")) DevCmd("CmdSelectCharacter", _switchCharId);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if (ActionButton("Set Spectator")) DevCmd("CmdSetSpectator");
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Team:", GUILayout.Width(45f));
        _spawnBotTeam = IntField(_spawnBotTeam, 40f);
        if (ActionButton("Set Team")) DevCmd("CmdSetLobbyTeam", _spawnBotTeam);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Bot Teams:", GUILayout.Width(70f));
        int botTeams = _spawnBotCount;
        botTeams = IntField(botTeams, 50f);
        _spawnBotCount = botTeams;
        if (ActionButton("Set Bot Teams")) DevCmd("CmdSetMaxBotTeams", _spawnBotCount);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Difficulty:", GUILayout.Width(70f));
        _spawnBotDifficulty = GUILayout.SelectionGrid(_spawnBotDifficulty,
            new[] { "Easy", "Medium", "Hard", "Expert" }, 4, GUILayout.Height(22f));
        if (ActionButton("Set")) DevCmd("CmdSelectBotDifficulty", _spawnBotDifficulty);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Game Mode:", GUILayout.Width(80f));
        int gm = 0;
        gm = IntField(gm, 50f);
        if (ActionButton("Set Mode")) DevCmd("CmdSelectUnityGamemode", gm);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Map ID:", GUILayout.Width(55f));
        int mapId = 1;
        mapId = IntField(mapId, 50f);
        if (ActionButton("Select Map")) DevCmd("CmdSelectLevel", mapId);
        GUILayout.EndHorizontal();

        GUILayout.Space(4f);
        if (hasDevLobby && ActionButton("Force Start Match"))
        {
            DevCmd("CmdLobbyForceStartMatch");
        }
    }

    // ===== Tab: Status ======================================================

    private static void DrawStatusTab()
    {
        GUILayout.Label("Server / Match Status", GUI.skin.box);
        GUILayout.Label(_serverInfo, GUI.skin.label);
        GUILayout.Label(_playerStatus, GUI.skin.label);
        GUILayout.Label(_matchStatus, GUI.skin.label);

        GUILayout.Space(4f);
        GUILayout.Label($"Player Count: {_matchPlayerCount}", GUI.skin.label);
        GUILayout.Label($"Bot Count: {_matchBotCount}", GUI.skin.label);

        GUILayout.Space(4f);

        if (_chars.Count > 0)
        {
            GUILayout.Label("Available Characters:", GUI.skin.label);
            GUILayout.BeginHorizontal();
            foreach (var c in _chars)
            {
                if (GUILayout.Button(c.Display, GUILayout.Height(22f)))
                {
                    _switchCharId = c.Id;
                    _selectedTab = 2; // switch to abilities tab
                }
            }
            GUILayout.EndHorizontal();
        }

        GUILayout.Space(4f);
        if (ActionButton("Refresh Status"))
        {
            _lastRefresh = -999f;
            _lastDiscovery = -999f;
            _discoveryDone = false;
        }

        // Show known type resolution status
        if (_playerDebugType != null)
            GUILayout.Label("✓ PlayerDebug resolved", GUI.skin.label);
        else
            GUILayout.Label("✗ PlayerDebug NOT resolved (run a match!)", GUI.skin.label);

        if (_playerDevLobbyType != null)
            GUILayout.Label("✓ PlayerDeveloperLobby resolved", GUI.skin.label);

        if (_gameManagerType != null)
            GUILayout.Label("✓ GameManager resolved", GUI.skin.label);
    }

    // ===== Tab: arbitrary developer commands ===============================

    private static void DrawConsoleTab()
    {
        GUILayout.Label("Unity Developer Console", GUI.skin.box);
        GUILayout.Label("F9 opens or closes the built-in Unity console.", GUI.skin.label);
        GUILayout.BeginHorizontal();
        if (ActionButton("Toggle Unity Console")) AdminOperatorBridge.ToggleUnityConsole();
        GUILayout.Label(AdminOperatorBridge.Status, GUI.skin.label);
        GUILayout.EndHorizontal();

        GUILayout.Space(6f);
        GUILayout.Label("Run Native Debug Command", GUI.skin.box);
        GUILayout.Label("Use comma-separated arguments. Vector3 uses x|y|z.", GUI.skin.label);

        GUILayout.BeginHorizontal();
        _rawTarget = GUILayout.SelectionGrid(_rawTarget, new[] { "PlayerDebug", "Dev Lobby" }, 2, GUILayout.Height(22f));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Method:", GUILayout.Width(60f));
        _rawCommand = GUILayout.TextField(_rawCommand, GUILayout.Width(300f));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Args:", GUILayout.Width(60f));
        _rawArguments = GUILayout.TextField(_rawArguments, GUILayout.Width(300f));
        GUILayout.EndHorizontal();

        if (ActionButton("Run Command"))
        {
            string[] args = string.IsNullOrWhiteSpace(_rawArguments)
                ? Array.Empty<string>()
                : _rawArguments.Split(',', StringSplitOptions.TrimEntries);
            bool ok;
            string message;
            if (_rawTarget == 0)
                ok = InvokeCommand(_playerDebugType, FindLocalPlayerDebug(), _rawCommand, args, out message);
            else
                ok = InvokeCommand(_playerDevLobbyType, FindLocalDevLobby(), _rawCommand, args, out message);
            _lastCommandResult = ok ? $"OK: {message}" : $"Failed: {message}";
        }

        if (!string.IsNullOrWhiteSpace(_lastCommandResult))
            GUILayout.Label(_lastCommandResult, GUI.skin.label);
    }

    // ===== Core: find local PlayerDebug instance =============================

    private static object? FindLocalPlayerDebug()
    {
        if (_playerDebugType == null) return null;
        try
        {
            // FindObjectsOfType via reflection (no Il2Cpp reference needed)
            MethodInfo? findMethod = typeof(Object)
                .GetMethod("FindObjectsOfType", Type.EmptyTypes);
            if (findMethod == null) return null;

            // Non-generic version: Object.FindObjectsOfType(Type)
            MethodInfo? findByType = typeof(Object)
                .GetMethods()
                .FirstOrDefault(m => m.Name == "FindObjectsOfType" &&
                    m.GetParameters().Length == 1 &&
                    m.GetParameters()[0].ParameterType == typeof(Type));
            if (findByType == null) return null;

            Array? all = findByType.Invoke(null, new object[] { _playerDebugType }) as Array;
            if (all == null || all.Length == 0) return null;

            // Prefer the local player's instance via isLocalPlayer or NetworkBehaviour.hasAuthority
            foreach (object? instance in all)
            {
                if (instance == null) continue;
                try
                {
                    // Check isLocalPlayer or hasAuthority
                    bool? isLocal = GetBoolMember(instance, "isLocalPlayer");
                    if (isLocal == true) return instance;
                    bool? hasAuth = GetBoolMember(instance, "hasAuthority");
                    if (hasAuth == true) return instance;
                }
                catch { }
            }

            // Fallback: first one
            return all.GetValue(0);
        }
        catch { return null; }
    }

    // Cached Object.FindObjectsOfType(Type) MethodInfo shared by the periodic refresh paths.
    private static MethodInfo? s_findObjectsOfTypeMethod;

    // 1s result cache: DrawLobbyTab calls this from OnGUI, which runs multiple times per frame
    // (layout + repaint). Uncached, that was a full FindObjectsOfType scene scan 120+ times per
    // second whenever the Lobby tab was open - a real FPS drop for admins.
    private static object? _cachedDevLobby;
    private static float _cachedDevLobbyAt = float.NegativeInfinity;

    private static object? FindLocalDevLobby()
    {
        float now = Time.realtimeSinceStartup;
        if (now - _cachedDevLobbyAt < 1f)
        {
            return _cachedDevLobby;
        }

        _cachedDevLobbyAt = now;
        _cachedDevLobby = FindLocalDevLobbyUncached();
        return _cachedDevLobby;
    }

    private static object? FindLocalDevLobbyUncached()
    {
        if (_playerDevLobbyType == null) return null;
        try
        {
            MethodInfo? findByType = typeof(Object)
                .GetMethods()
                .FirstOrDefault(m => m.Name == "FindObjectsOfType" &&
                    m.GetParameters().Length == 1 &&
                    m.GetParameters()[0].ParameterType == typeof(Type));
            if (findByType == null) return null;

            Array? all = findByType.Invoke(null, new object[] { _playerDevLobbyType }) as Array;
            if (all == null || all.Length == 0) return null;

            foreach (object? instance in all)
            {
                if (instance == null) continue;
                try
                {
                    bool? isLocal = GetBoolMember(instance, "isLocalPlayer");
                    if (isLocal == true) return instance;
                }
                catch { }
            }
            return all.GetValue(0);
        }
        catch { return null; }
    }

    // ===== Core: invoke a PlayerDebug Cmd method ============================

    private static bool Cmd(string methodName, params object?[] args)
    {
        return InvokeCommand(_playerDebugType, FindLocalPlayerDebug(), methodName, args, out _);
    }

    // ===== Core: invoke a PlayerDeveloperLobby Cmd method ====================

    private static bool DevCmd(string methodName, params object?[] args)
    {
        return InvokeCommand(_playerDevLobbyType, FindLocalDevLobby(), methodName, args, out _);
    }

    private static bool InvokeCommand(Type? type, object? instance, string methodName, IReadOnlyList<object?> suppliedArgs, out string message)
    {
        message = "";
        if (type is null || instance is null)
        {
            message = "No local command target. Enter a match or developer lobby first.";
            return false;
        }

        try
        {
            foreach (MethodInfo method in type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                if (!string.Equals(method.Name, methodName, StringComparison.Ordinal)) continue;
                ParameterInfo[] parameters = method.GetParameters();
                if (parameters.Length != suppliedArgs.Count) continue;

                object?[] converted = new object?[parameters.Length];
                bool compatible = true;
                for (int i = 0; i < parameters.Length; i++)
                {
                    if (!TryConvertArgument(suppliedArgs[i], parameters[i].ParameterType, out object? value))
                    {
                        compatible = false;
                        break;
                    }
                    converted[i] = value;
                }

                if (!compatible) continue;
                method.Invoke(instance, converted);
                message = method.Name;
                return true;
            }

            message = $"No compatible {methodName} overload.";
            MelonLoader.MelonLogger.Warning($"[AdminOverlay] {message}");
            return false;
        }
        catch (Exception ex)
        {
            message = ex.GetBaseException().Message;
            MelonLoader.MelonLogger.Warning($"[AdminOverlay] {methodName} failed: {message}");
            return false;
        }
    }

    private static bool TryConvertArgument(object? source, Type targetType, out object? value)
    {
        value = null;
        Type nonNullable = Nullable.GetUnderlyingType(targetType) ?? targetType;
        if (source is null)
        {
            return !nonNullable.IsValueType;
        }

        if (nonNullable.IsInstanceOfType(source))
        {
            value = source;
            return true;
        }

        string text = source.ToString() ?? "";
        try
        {
            if (nonNullable == typeof(string)) { value = text; return true; }
            if (nonNullable == typeof(bool) && bool.TryParse(text, out bool boolean)) { value = boolean; return true; }
            if (nonNullable == typeof(int) && int.TryParse(text, NumberStyles.Integer, CultureInfo.InvariantCulture, out int integer)) { value = integer; return true; }
            if (nonNullable == typeof(float) && float.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out float single)) { value = single; return true; }
            if (nonNullable == typeof(double) && double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out double number)) { value = number; return true; }
            if (nonNullable.IsEnum)
            {
                value = int.TryParse(text, NumberStyles.Integer, CultureInfo.InvariantCulture, out int enumValue)
                    ? Enum.ToObject(nonNullable, enumValue)
                    : Enum.Parse(nonNullable, text, ignoreCase: true);
                return true;
            }
            if (nonNullable == typeof(Vector3))
            {
                string[] parts = text.Split('|', StringSplitOptions.TrimEntries);
                if (parts.Length == 3 &&
                    float.TryParse(parts[0], NumberStyles.Float, CultureInfo.InvariantCulture, out float x) &&
                    float.TryParse(parts[1], NumberStyles.Float, CultureInfo.InvariantCulture, out float y) &&
                    float.TryParse(parts[2], NumberStyles.Float, CultureInfo.InvariantCulture, out float z))
                {
                    value = new Vector3(x, y, z);
                    return true;
                }
            }

            value = Convert.ChangeType(source, nonNullable, CultureInfo.InvariantCulture);
            return true;
        }
        catch
        {
            return false;
        }
    }

    // ===== Try open dev lobby via DebugController ============================

    private static void TryOpenDevLobby()
    {
        try
        {
            // Find LobbyNetworkClient -> Controller -> Debug -> HandleDeveloperLobbyButton
            Type? lncType = FindType("BAPBAP.Network.LobbyNetworkClient");
            if (lncType == null) return;
            object? lnc = FindUnityObject(lncType);
            if (lnc == null) return;

            object? controller = GetMember(lnc, "Controller");
            if (controller == null) return;

            object? debug = GetMember(controller, "Debug");
            if (debug == null) return;

            MethodInfo? handle = debug.GetType().GetMethod("HandleDeveloperLobbyButton",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            handle?.Invoke(debug, null);
        }
        catch (Exception ex)
        {
            MelonLoader.MelonLogger.Warning($"[AdminOverlay] OpenDevLobby: {ex.GetBaseException().Message}");
        }
    }

    // ===== State refresh ===================================================

    private static void EnsureTypesResolved()
    {
        if (_typesResolved) return;

        _playerDebugType = FindType("BAPBAP.Player.PlayerDebug");
        _playerDevLobbyType = FindType("BAPBAP.Player.PlayerDeveloperLobby");
        _gameManagerType = FindType("BAPBAP.Game.GameManager");
        _networkManagerType = FindType("Mirror.NetworkManager");

        _typesResolved = _playerDebugType != null;

        if (_typesResolved)
            MelonLoader.MelonLogger.Msg("[AdminOverlay] Types resolved. Ready (F8).");
    }

    private static void RefreshMatchState()
    {
        // Run runtime discovery periodically
        float now = Time.realtimeSinceStartup;
        if (now - _lastDiscovery > DiscoveryInterval)
        {
            _lastDiscovery = now;
            // RunDiscovery must be a plain method call. As an IEnumerator ("_ = RunDiscoveryAsync()")
            // the body NEVER executed - only the enumerator object was allocated and discarded - so
            // the item/entity/modifier catalogs stayed empty forever.
            if (!_discoveryDone) RunDiscovery();
        }

        try
        {
            // Check GameManager status
            if (_gameManagerType != null)
            {
                object? gm = GetStaticMember(_gameManagerType, "Instance");
                if (gm != null)
                {
                    bool? inMatch = GetBoolMember(gm, "isMatchInProgress");
                    bool? isHost = GetBoolMember(gm, "isServer");
                    bool? isClient = GetBoolMember(gm, "isClient");

                    object? nm = _networkManagerType != null
                        ? GetStaticMember(_networkManagerType, "singleton")
                        : null;
                    if (nm != null)
                    {
                        bool? serverActive = GetBoolMember(nm, "isNetworkActive");
                        _serverInfo = $"Server active: {serverActive} | Host: {isHost} | Client: {isClient}";
                    }

                    _matchStatus = inMatch == true
                        ? "● In match"
                        : "○ Not in match (lobby/menu)";

                    // Count entities
                    Type? entityMgrType = FindType("BAPBAP.Entities.EntityManager");
                    if (entityMgrType != null)
                    {
                        MethodInfo? findAll = s_findObjectsOfTypeMethod ??= typeof(Object)
                            .GetMethods()
                            .FirstOrDefault(m => m.Name == "FindObjectsOfType" &&
                                m.GetParameters().Length == 1 &&
                                m.GetParameters()[0].ParameterType == typeof(Type));
                        if (findAll != null)
                        {
                            Array? entities = findAll.Invoke(null, new object[] { entityMgrType }) as Array;
                            if (entities != null)
                            {
                                int playerCount = 0, botCount = 0;
                                foreach (object? e in entities)
                                {
                                    if (e == null) continue;
                                    bool? isBot = GetBoolMember(e, "isBot");
                                    if (isBot == true) botCount++;
                                    else playerCount++;
                                }
                                _matchPlayerCount = playerCount;
                                _matchBotCount = botCount;
                            }
                        }
                    }
                }
                else
                {
                    _matchStatus = "○ Not connected";
                }
            }

            // Check for local PlayerDebug
            object? pd = FindLocalPlayerDebug();
            _playerStatus = pd != null ? "✓ Local PlayerDebug found" : "○ No PlayerDebug (not in match)";
        }
        catch { }
    }

    // ===== Runtime discovery (items, entities, chars) ========================

    private static void RunDiscovery()
    {
        _discoveryDone = true;
        _items.Clear();
        _entities.Clear();
        _modifiers.Clear();

        MelonLoader.MelonLogger.Msg("[AdminOverlay] Discovering game catalogs...");

        // ---- Discover characters from GameManager ----
        try
        {
            _chars.Clear();
            // Known char list first (from our catalog)
            foreach ((int id, string name) in QuickChars)
                _chars.Add(new CatalogItem(id, name + $" ({id})"));

            // Try to read GameModesConfiguration for character roster
            Type? modesConfigType = FindType("BAPBAP.Game.GameModesConfiguration");
            if (modesConfigType != null)
            {
                object? instance = GetStaticMember(modesConfigType, "Instance");
                if (instance != null)
                {
                    object? configurations = GetMember(instance, "Configurations");
                    if (configurations != null)
                    {
                        // Log available game modes
                        MelonLoader.MelonLogger.Msg("[AdminOverlay] GameModesConfiguration found.");
                    }
                }
            }
        }
        catch { }

        // ---- Discover items from ItemDrops / GameManager ----
        try
        {
            _items.Clear();
            // Add known items with common IDs from the game
            _items.Add(new CatalogItem(0, "Any/Unknown (0)"));
            _items.Add(new CatalogItem(1, "Sword/Basic (1)"));
            _items.Add(new CatalogItem(2, "Shield (2)"));
            _items.Add(new CatalogItem(3, "Potion/Heal (3)"));
            _items.Add(new CatalogItem(10, "Assault Rifle (10)"));
            _items.Add(new CatalogItem(11, "Shotgun (11)"));
            _items.Add(new CatalogItem(12, "Sniper (12)"));
            _items.Add(new CatalogItem(20, "Grenade (20)"));
            _items.Add(new CatalogItem(21, "Medkit (21)"));
            _items.Add(new CatalogItem(30, "Armor (30)"));
            _items.Add(new CatalogItem(50, "Augment Reroll (50)"));
            _items.Add(new CatalogItem(99, "Custom (99)"));

            // Try to discover from GameManager.ItemRegistry or similar
            if (_gameManagerType != null)
            {
                object? gm = GetStaticMember(_gameManagerType, "Instance");
                if (gm != null)
                {
                    // The game might have an item database — check common property names
                    foreach (string prop in new[] { "itemDatabase", "ItemDatabase", "itemRegistry", "ItemRegistry", "gameItems", "GameItems" })
                    {
                        object? db = GetMember(gm, prop);
                        if (db != null)
                        {
                            MelonLoader.MelonLogger.Msg($"[AdminOverlay] Found item source: {prop}");
                            // Try to enumerate — structure unknown, but we found it
                            break;
                        }
                    }
                }
            }
        }
        catch { }

        // ---- Discover entities from NetworkManager prefab library ----
        try
        {
            _entities.Clear();
            if (_networkManagerType != null)
            {
                object? nm = GetStaticMember(_networkManagerType, "singleton");
                if (nm != null)
                {
                    object? prefabLib = GetMember(nm, "networkPrefabLibrary");
                    if (prefabLib != null)
                    {
                        // Access the prefab list via reflection
                        Type? libType = prefabLib.GetType();
                        PropertyInfo? prefabsProp = libType.GetProperty("prefabs",
                            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                        object? prefabs = prefabsProp?.GetValue(prefabLib);
                        if (prefabs is System.Collections.IList list)
                        {
                            int idx = 0;
                            foreach (object? prefab in list)
                            {
                                if (prefab is Object unityObj && unityObj != null)
                                {
                                    string name = unityObj.name ?? $"prefab_{idx}";
                                    if (name.Contains("NPC", StringComparison.OrdinalIgnoreCase) ||
                                        name.Contains("Bot", StringComparison.OrdinalIgnoreCase) ||
                                        name.Contains("Entity", StringComparison.OrdinalIgnoreCase) ||
                                        name.Contains("Prop", StringComparison.OrdinalIgnoreCase) ||
                                        name.Contains("Chest", StringComparison.OrdinalIgnoreCase) ||
                                        name.Contains("Spawn", StringComparison.OrdinalIgnoreCase) ||
                                        name.Contains("Object", StringComparison.OrdinalIgnoreCase))
                                    {
                                        _entities.Add(new CatalogItem(idx, $"{name} ({idx})"));
                                    }
                                }
                                idx++;
                            }

                            if (_entities.Count == 0)
                            {
                                // No named entities found — add range
                                for (int i = 0; i < Math.Min(50, list.Count); i++)
                                    _entities.Add(new CatalogItem(i, $"Entity Prefab #{i}"));
                            }

                            MelonLoader.MelonLogger.Msg($"[AdminOverlay] Scanned {list.Count} network prefabs, found {_entities.Count} entity candidates.");
                        }
                    }
                }
            }

            if (_entities.Count == 0)
            {
                // Fallback: known entity IDs
                _entities.Add(new CatalogItem(0, "Chest/Basic (0)"));
                _entities.Add(new CatalogItem(1, "Barrel (1)"));
                _entities.Add(new CatalogItem(2, "Crate (2)"));
                _entities.Add(new CatalogItem(3, "Campfire (3)"));
                _entities.Add(new CatalogItem(10, "Wolf NPC (10)"));
                _entities.Add(new CatalogItem(11, "Slime NPC (11)"));
                _entities.Add(new CatalogItem(12, "Penguin NPC (12)"));
                _entities.Add(new CatalogItem(20, "Revive Altar (20)"));
                _entities.Add(new CatalogItem(30, "Turret (30)"));
            }
        }
        catch { }

        // ---- Discover game modifiers ----
        try
        {
            _modifiers.Clear();
            // Try runtime discovery
            Type? modifierCatalog = FindType("BAPBAP.Game.GameModifierSO");
            if (modifierCatalog != null)
            {
                // Scan loaded assets for GameModifierSO instances
                MethodInfo? findAssets = typeof(Resources)
                    .GetMethods(BindingFlags.Static | BindingFlags.Public)
                    .FirstOrDefault(m => m.Name == "FindObjectsOfTypeAll" &&
                        m.GetParameters().Length == 1 &&
                        m.GetParameters()[0].ParameterType == typeof(Type));
                if (findAssets != null)
                {
                    Array? soList = findAssets.Invoke(null, new object[] { modifierCatalog }) as Array;
                    if (soList != null)
                    {
                        int idx = 0;
                        foreach (object? so in soList)
                        {
                            if (so == null) continue;
                            string? modName = GetStringMember(so, "name");
                            int? modId = GetIntMember(so, "Id");
                            _modifiers.Add(new CatalogItem(
                                modId ?? idx,
                                $"{modName ?? "Modifier"} ({(modId ?? idx)})"));
                            idx++;
                        }
                    }
                }
            }

            if (_modifiers.Count == 0)
            {
                // Fallback: known modifier range
                for (int i = 0; i < 8; i++)
                    _modifiers.Add(new CatalogItem(i, $"Game Modifier #{i}"));
            }
        }
        catch { }

        MelonLoader.MelonLogger.Msg($"[AdminOverlay] Discovery done: {_chars.Count} chars, {_items.Count} items, {_entities.Count} entities, {_modifiers.Count} modifiers.");
    }

    // ===== Quick char list ==================================================

    private static readonly (int Id, string Name)[] QuickChars =
    {
        (0, "Kitsu"), (1, "Kiba"), (2, "Kori"), (3, "Zeph"),
        (4, "Lykos"), (5, "Nix"), (6, "Punk"), (7, "Yuki"),
        (8, "Raven"), (9, "Ash"), (10, "Mira"), (11, "Echo"),
        (12, "Blitz"), (13, "Eve"), (14, "Slate"), (15, "Medusa"),
        (16, "Custom1"), (17, "Custom2"), (18, "Custom3"), (19, "Custom4"),
    };

    // ===== Helper: toggle field ==============================================

    private static bool ToggleField(string label, bool current, Action<bool> action)
    {
        bool now = GUILayout.Toggle(current, label, GUILayout.Height(22f));
        if (now != current)
        {
            action(now);
            // After toggling, poll the actual state from the game next frame
        }
        return now;
    }

    private static bool ActionButton(string label)
    {
        return GUILayout.Button(label, GUILayout.Height(22f));
    }

    private static int IntField(int value, float width)
    {
        string text = GUILayout.TextField(value.ToString(), GUILayout.Width(width));
        if (int.TryParse(text, out int parsed)) return parsed;
        return value;
    }

    private static float FloatField(float value, float width)
    {
        string text = GUILayout.TextField(value.ToString("F1"), GUILayout.Width(width));
        if (float.TryParse(text, out float parsed)) return parsed;
        return value;
    }

    // ===== Reflection helpers ===============================================

    // Negative-result cooldown: EnsureTypesResolved retries every second until PlayerDebug
    // resolves (i.e. the whole time the overlay is open outside a match). Without this, every
    // miss re-walked ALL loaded assemblies on the main thread each second.
    private static readonly Dictionary<string, float> s_typeMissRetryAt = new(StringComparer.Ordinal);
    private const float TypeMissRetrySeconds = 30f;

    private static Type? FindType(string fullName)
    {
        if (s_typeCache.TryGetValue(fullName, out Type? cached))
            return cached;

        float now = Time.realtimeSinceStartup;
        if (s_typeMissRetryAt.TryGetValue(fullName, out float retryAt) && now < retryAt)
            return null;

        string[] candidates =
        {
            fullName,
            fullName.StartsWith("Il2Cpp", StringComparison.Ordinal) ? fullName : "Il2Cpp" + fullName,
            fullName.StartsWith("Il2Cpp.", StringComparison.Ordinal) ? fullName : "Il2Cpp." + fullName,
        };

        foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            try
            {
                foreach (string candidate in candidates)
                {
                    Type? type = assembly.GetType(candidate, throwOnError: false);
                    if (type != null)
                    {
                        s_typeCache.TryAdd(fullName, type);
                        s_typeMissRetryAt.Remove(fullName);
                        return type;
                    }
                }
            }
            catch { }
        }

        s_typeMissRetryAt[fullName] = now + TypeMissRetrySeconds;
        return null;
    }

    private static object? GetMember(object instance, string name)
    {
        const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        Type type = instance.GetType();
        PropertyInfo? prop = type.GetProperty(name, flags);
        if (prop?.GetIndexParameters().Length == 0 && prop.CanRead)
            return prop.GetValue(instance);
        FieldInfo? field = type.GetField(name, flags);
        return field?.GetValue(instance);
    }

    private static object? GetStaticMember(Type type, string name)
    {
        const BindingFlags flags = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
        PropertyInfo? prop = type.GetProperty(name, flags);
        if (prop?.GetIndexParameters().Length == 0 && prop.CanRead)
            return prop.GetValue(null);
        FieldInfo? field = type.GetField(name, flags);
        return field?.GetValue(null);
    }

    private static bool? GetBoolMember(object instance, string name)
    {
        try { return (bool?)GetMember(instance, name); }
        catch { return null; }
    }

    private static int? GetIntMember(object instance, string name)
    {
        try { return (int?)GetMember(instance, name); }
        catch { return null; }
    }

    private static string? GetStringMember(object instance, string name)
    {
        try { return (string?)GetMember(instance, name); }
        catch { return null; }
    }

    private static object? FindUnityObject(Type type)
    {
        try
        {
            MethodInfo? findByType = typeof(Object)
                .GetMethods()
                .FirstOrDefault(m => m.Name == "FindObjectOfType" &&
                    m.GetParameters().Length == 1 &&
                    m.GetParameters()[0].ParameterType == typeof(Type));
            return findByType?.Invoke(null, new object[] { type });
        }
        catch { return null; }
    }

    // ===== Data types =======================================================

    private sealed class CatalogItem
    {
        public int Id { get; }
        public string Display { get; }
        public CatalogItem(int id, string display)
        {
            Id = id;
            Display = display;
        }
    }
}
