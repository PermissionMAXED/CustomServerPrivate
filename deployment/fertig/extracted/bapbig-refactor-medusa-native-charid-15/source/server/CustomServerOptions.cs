using System.Text.Json.Serialization;

namespace BapCustomServer;

/// <summary>
/// Controls which match-start paths the server allows.
/// </summary>
public enum MatchmakingPolicy
{
    /// <summary>Allow both matchmaking queue and custom match lobbies (default).</summary>
    Both = 0,

    /// <summary>Only the matchmaking queue starts matches. Custom Match lobbies (START_CUSTOM_GAME) are rejected.</summary>
    MatchmakingOnly = 1,

    /// <summary>Only Custom Match lobbies start matches. Matchmaking queue is rejected.</summary>
    CustomOnly = 2,
}

public sealed class CustomServerOptions
{
    public string PublicBaseUrl { get; set; } = "http://127.0.0.1:5055";
    public string PublicGameHost { get; set; } = "127.0.0.1";
    public MatchmakingPolicy MatchmakingPolicy { get; set; } = MatchmakingPolicy.Both;
    /// <summary>Maximum concurrent matches running on this server. 0 = unlimited.</summary>
    public int MaxConcurrentMatches { get; set; } = 0;
    /// <summary>Seconds to keep an active match process after its lobby becomes empty.</summary>
    public int EmptyLobbyMatchCleanupGraceSeconds { get; set; } = 20;
    /// <summary>Longer empty-lobby grace when the original match account still has an open lobby socket.</summary>
    public int EmptyLobbyMatchConnectedCleanupGraceSeconds { get; set; } = 45;
    public bool LaunchGameServers { get; set; } = true;
    public bool RequireGameServerBootstrap { get; set; } = true;
    public bool RequireGameServerKcpPort { get; set; } = false;
    public string GameLauncherPath { get; set; } = "";
    public string GameLauncherArguments { get; set; } = "\"{gameExecutable}\" {gameArguments}";
    public string GameExecutablePath { get; set; } = "../Spiel/Battleroyalebuild/bapbap.exe";
    public string GameWorkingDirectory { get; set; } = "../Spiel/Battleroyalebuild";
    public string GameLogDirectory { get; set; } = "logs/game-servers";
    public string HeadlessArguments { get; set; } =
        "-batchmode -logFile \"{logFile}\" -httpport={httpPort} -wsport={wsPort} -kcpport={kcpPort} -tcpport={tcpPort}";
    public string AdditionalGameArguments { get; set; } = "";
    public int BaseHttpPort { get; set; } = 7850;
    public int BaseWsPort { get; set; } = 7777;
    public int BaseKcpPort { get; set; } = 7778;
    public int BaseTcpPort { get; set; } = 7779;
    public int PortSearchRange { get; set; } = 200;
    public int PortReleaseCooldownSeconds { get; set; } = 0;
    public int GameServerReadyTimeoutSeconds { get; set; } = 300;
    public int GameServerBootstrapHttpTimeoutSeconds { get; set; } = 20;
    public int GameServerBootstrapResetPollMillis { get; set; } = 1500;
    public int GameServerManagedBootstrapStatusTimeoutSeconds { get; set; } = 180;
    public int GameServerManagedBootstrapListenerOnlyTimeoutSeconds { get; set; } = 0;
    public int GameServerTcpPortReadyTimeoutSeconds { get; set; } = 30;
    public int GameServerKcpPortReadyTimeoutSeconds { get; set; } = 45;
    public int GameServerReadyPollMillis { get; set; } = 500;
    public int GameServerBootstrapProgressLogSeconds { get; set; } = 15;
    public int GameServerDiagnosticTailLines { get; set; } = 80;
    public int GameServerStartAttempts { get; set; } = 2;
    public int GameServerStartRetryDelaySeconds { get; set; } = 2;
    public int GameServerStopWaitMillis { get; set; } = 5000;
    public int GameServerPostCleanupStartDelayMillis { get; set; } = 3000;
    public int GameServerStartupStallGraceSeconds { get; set; } = 45;
    public int GameServerStartupStallSeconds { get; set; } = 25;
    public int GameServerWrapperOnlyStartupStallGraceSeconds { get; set; } = 8;
    public int GameServerWrapperOnlyStartupStallSeconds { get; set; } = 5;
    public bool GameServerPrewarmOnStartup { get; set; } = false;
    public int GameServerPrewarmTimeoutSeconds { get; set; } = 180;
    public int GameServerPrewarmMatchWaitSeconds { get; set; } = 35;
    public int GameServerPrewarmPortOffset { get; set; } = 150;
    public int GameServerPrewarmSettleSeconds { get; set; } = 3;
    public string BootstrapConnectPath { get; set; } = "/setup-game";
    public string BootstrapAddTeamsPath { get; set; } = "/add-teams";
    public string BootstrapQueueMatchedPath { get; set; } = "/queue-matched";
    public string ModdingOverlayTitle { get; set; } = "BAPBAP Modding";
    public string ModdingOverlaySubtitle { get; set; } = "discord.gg/bapbapmods";
    public ExternalGameServerOptions ExternalGameServer { get; set; } = new();
    public MatchDefaults MatchDefaults { get; set; } = new();
    public AdminOptions Admin { get; set; } = new();
    public UnlockOptions Unlocks { get; set; } = new();

    /// <summary>
    /// Per-character enable toggles for the AMP UI (15 named checkboxes). When ANY
    /// EnableX is set, the resolved roster is the union of all true ones, overriding
    /// MatchDefaults.AvailableCharacters / EnabledCharacterIds / EnabledCharactersByName.
    /// Default: every character true (identical to "all 15 chars enabled" behavior).
    /// </summary>
    public RosterOptions Roster { get; set; } = new();

    /// <summary>
    /// Per-map enable toggles for the AMP UI. These map IDs are the IDs consumed by the
    /// BAPBAP client/server QueueMatched + MatchmakingGameData payloads.
    /// </summary>
    public MapPoolOptions MapPool { get; set; } = new();

    /// <summary>
    /// Three configurable shop rotation slots + one freebie slot, set via AMP dropdowns.
    /// When any slot has a non-zero AssetId, the configured slots replace ShopService's
    /// SeedDefaultListingsIfEmpty default seed. Empty = use the default seed.
    /// </summary>
    public ShopSlotOptions ShopSlots { get; set; } = new();

    /// <summary>
    /// Mirror / KCP tuning hints. Read by the dedicated server bootstrap path
    /// (and forwarded as game launcher args / env vars) so the headless game process
    /// can apply Mirror NetworkServer.sendRate and KcpTransport window sizes.
    /// Has no effect on the lobby-only ASP.NET server itself.
    /// </summary>
    public NetworkTuningOptions Network { get; set; } = new();

    /// <summary>
    /// AMP AnalyticsPlugin regex configuration. The C# server does not consume these values
    /// directly - AMP's external Analytics plugin reads them from the GenericModule kvp
    /// (which is generated from this section in <c>appsettings.json</c>) and applies the
    /// regexes against the standard ASP.NET Core log stream forwarded by AMP.
    /// Storing them here keeps a single source of truth so AMP UI edits round-trip cleanly.
    /// </summary>
    public AnalyticsOptions Analytics { get; set; } = new();
}

// ===================== AMP AnalyticsPlugin regex configuration =====================

/// <summary>
/// Regex patterns surfaced by AMP's AnalyticsPlugin to extract player count and
/// match count time series from the standard ASP.NET Core log output. Defaults
/// match the log lines emitted by <c>LobbyService</c> and the bootstrap pipeline:
///
///   - Player join:  <c>Client {AccountId} connected. admin={IsAdmin}</c>
///   - Player leave: <c>Client {AccountId} disconnected.</c>
///   - Match start:  <c>Dedicated server ready for {GameId} after {Ms}ms</c>
///   - Match end:    <c>Game ended: {GameId}</c>
///
/// AMP convention: use named capture groups <c>player</c> and <c>match</c> / <c>message</c>
/// where applicable so the AMP UI can group the time series by player or match id.
/// </summary>
public sealed class AnalyticsOptions
{
    /// <summary>Master switch. When false, AMP should skip analytics ingestion for this server.</summary>
    public bool Enabled { get; set; } = true;

    /// <summary>Regex matched against each log line to detect a player join. Captures the account id as <c>player</c>.</summary>
    public string PlayerJoinRegex { get; set; } = @"Client (?<player>\S+) connected\.";

    /// <summary>Regex matched against each log line to detect a player leave. Captures the account id as <c>player</c>.</summary>
    public string PlayerLeaveRegex { get; set; } = @"Client (?<player>\S+) disconnected\.";

    /// <summary>Regex matched against each log line to detect a match start. Captures the game id as <c>match</c>.</summary>
    public string MatchStartRegex { get; set; } = @"Dedicated server ready for (?<match>\S+) after \d+ms";

    /// <summary>Regex matched against each log line to detect a match end. Captures the game id as <c>match</c>.</summary>
    public string MatchEndRegex { get; set; } = @"Game ended: (?<match>\S+)";

    /// <summary>
    /// Regex matched against each log line to detect a chat message. Empty by default - the
    /// custom server does not forward in-match chat into the ASP.NET log stream. Provide a
    /// pattern with named groups <c>player</c> and <c>message</c> to enable chat analytics.
    /// </summary>
    public string ChatMessageRegex { get; set; } = "";
}

// ===================== AMP-driven roster, map pool, and shop slots =====================

/// <summary>
/// Per-character enable booleans. AMP renders these as checkboxes (one per BAPBAP/custom char).
/// </summary>
public sealed class RosterOptions
{
    public bool EnableKitsu { get; set; } = true;
    public bool EnableAnna { get; set; } = true;
    public bool EnableChuck { get; set; } = true;
    public bool EnableSashimi { get; set; } = true;
    public bool EnableKiddo { get; set; } = true;
    public bool EnableZook { get; set; } = true;
    public bool EnableSkinny { get; set; } = true;
    public bool EnableFroggy { get; set; } = true;
    public bool EnableTeevee { get; set; } = true;
    public bool EnableSofia { get; set; } = true;
    public bool EnableJiro { get; set; } = true;
    public bool EnableBishop { get; set; } = true;
    public bool EnableCeleste { get; set; } = true;
    public bool EnableKate { get; set; } = true;
    public bool EnableRocky { get; set; } = true;
    public bool EnableMedusa { get; set; } = true;

    /// <summary>Resolve the AMP toggles into the canonical char-id list. Always returns at least one id.</summary>
    public int[] BuildEnabledCharIds()
    {
        var ids = new List<int>(CharacterCatalog.Names.Length);
        if (EnableKitsu)   ids.Add(0);
        if (EnableAnna)    ids.Add(1);
        if (EnableChuck)   ids.Add(2);
        if (EnableSashimi) ids.Add(3);
        if (EnableKiddo)   ids.Add(4);
        if (EnableZook)    ids.Add(5);
        if (EnableSkinny)  ids.Add(6);
        if (EnableFroggy)  ids.Add(7);
        if (EnableTeevee)  ids.Add(8);
        if (EnableSofia)   ids.Add(9);
        if (EnableJiro)    ids.Add(10);
        if (EnableBishop)  ids.Add(11);
        if (EnableCeleste) ids.Add(12);
        if (EnableKate)    ids.Add(13);
        if (EnableRocky)   ids.Add(14);
        if (EnableMedusa)  ids.Add(CharacterCatalog.MedusaCharId);
        if (ids.Count == 0)
        {
            // Defensive: never return an empty roster - matchmaking would deadlock.
            ids.Add(1); // Anna
        }
        return ids.ToArray();
    }

    /// <summary>True when at least one toggle differs from the default "all true" state.</summary>
    [JsonIgnore]
    public bool HasCustomization =>
        !(EnableKitsu && EnableAnna && EnableChuck && EnableSashimi && EnableKiddo &&
          EnableZook && EnableSkinny && EnableFroggy && EnableTeevee && EnableSofia &&
          EnableJiro && EnableBishop && EnableCeleste && EnableKate && EnableRocky &&
          EnableMedusa);
}

/// <summary>
/// Per-map enable booleans. AMP renders these as named checkboxes.
/// </summary>
public sealed class MapPoolOptions
{
    public bool? EnableMapBazaarCity { get; set; }
    public bool? EnableMapLyceum { get; set; }
    public bool? EnableMapArenaMap2 { get; set; }
    public bool? EnableMapOpenBetaBoccato { get; set; }

    // Legacy property names kept so older AMP instances retain their previous
    // enabled/disabled choices after updating. The labels were wrong, but they
    // still represented map IDs 1..4 in order.
    public bool EnableMapTireclub { get; set; } = true;
    public bool EnableMapBazaarcity { get; set; } = true;
    public bool EnableMapBonsai { get; set; } = true;
    public bool EnableMapSunset { get; set; } = true;

    /// <summary>
    /// When true, the enabled maps above apply to EVERY game mode (Solos, Duos, Trios, FFA, Custom)
    /// regardless of any per-mode MapMapping config. This lets operators force e.g. Solos players
    /// onto a Trios-default map. Default true so the AMP UI toggles act as a global allow-list.
    /// </summary>
    public bool AllMapsAllModes { get; set; } = true;

    /// <summary>Resolve to canonical map ids. Always returns at least one id.</summary>
    public int[] BuildEnabledMapIds()
    {
        var ids = new List<int>(4);
        if (EnableMapBazaarCity ?? EnableMapTireclub)          ids.Add(MapCatalog.BazaarCityId);
        if (EnableMapLyceum ?? EnableMapBazaarcity)            ids.Add(MapCatalog.LyceumId);
        if (EnableMapArenaMap2 ?? EnableMapBonsai)             ids.Add(MapCatalog.ArenaMap2Id);
        if (EnableMapOpenBetaBoccato ?? EnableMapSunset)       ids.Add(MapCatalog.OpenBetaBoccatoId);
        if (ids.Count == 0) ids.Add(MapCatalog.BazaarCityId); // never return empty
        return ids.ToArray();
    }

    [JsonIgnore]
    public bool HasCustomization =>
        !((EnableMapBazaarCity ?? EnableMapTireclub) &&
          (EnableMapLyceum ?? EnableMapBazaarcity) &&
          (EnableMapArenaMap2 ?? EnableMapBonsai) &&
          (EnableMapOpenBetaBoccato ?? EnableMapSunset));
}

/// <summary>
/// AMP-friendly static shop slots. Each slot has an asset id (chosen via dropdown) and a price.
/// When ANY slot has a non-zero AssetId, ShopService prefers these over its built-in seed.
/// </summary>
public sealed class ShopSlotOptions
{
    public int Slot1AssetId { get; set; } = 0;
    public int Slot1Price { get; set; } = 100;
    public int Slot2AssetId { get; set; } = 0;
    public int Slot2Price { get; set; } = 150;
    public int Slot3AssetId { get; set; } = 0;
    public int Slot3Price { get; set; } = 200;
    public int FreebieAssetId { get; set; } = 0;

    [JsonIgnore]
    public bool AnySlotConfigured =>
        Slot1AssetId > 0 || Slot2AssetId > 0 || Slot3AssetId > 0 || FreebieAssetId > 0;
}

/// <summary>
/// Controls how the custom server reports cosmetic ownership to the client.
/// On a private/custom server there is no shop, so by default every cosmetic
/// asset (skin, banner, emote, mastery badge, tombstone) is reported as owned.
///
/// Master switch UX:
///   UnlockEverything = true  -> all per-category UnlockAll* flags are forced on (effective values).
///   UnlockEverything = false -> per-category flags decide individually.
///
/// Use the Effective* helpers when computing the actual ownership decision so callers
/// don't have to re-implement the master-switch override.
/// </summary>
public sealed class UnlockOptions
{
    /// <summary>Master switch - when true, every per-category Effective* flag is forced true.</summary>
    public bool UnlockEverything { get; set; } = false;

    // ------- Per-category toggles (drives the AMP "Unlock Everything" tab) -------

    /// <summary>Unlock every skin in [SkinAssetIdStart..SkinAssetIdEnd]. Default: true.</summary>
    public bool UnlockAllSkins { get; set; } = true;

    /// <summary>Unlock every banner in [BannerAssetIdStart..BannerAssetIdEnd]. Default: true.</summary>
    public bool UnlockAllBanners { get; set; } = true;

    /// <summary>Unlock every emote in [EmoteAssetIdStart..EmoteAssetIdEnd]. Default: false because emote IDs are fragile.</summary>
    public bool UnlockAllEmotes { get; set; } = false;

    /// <summary>Unlock every mastery badge in [MasteryBadgeAssetIdStart..MasteryBadgeAssetIdEnd]. Default: false.</summary>
    public bool UnlockAllMasteryBadges { get; set; } = false;

    /// <summary>Unlock every tombstone in [TombstoneAssetIdStart..TombstoneAssetIdEnd]. Default: false.</summary>
    public bool UnlockAllTombstones { get; set; } = false;

    /// <summary>Grant the configured CurrencyBalance for every CurrencyAssetId. Default: true.</summary>
    public bool GrantAllCurrencies { get; set; } = true;

    // ------- Asset id ranges (now used per-category, gated by the Effective* flags) -------

    /// <summary>Skin asset IDs use base 300000 (SkinData.assetSkinOffset). Inclusive range.</summary>
    public int SkinAssetIdStart { get; set; } = 300000;
    public int SkinAssetIdEnd { get; set; } = 300026;

    /// <summary>Emote asset IDs use base 400000 (EmoteData.assetEmoteOffset). Inclusive range.
    /// NOTE: Only send IDs that actually exist in EmoteData. Sending non-existent IDs
    /// causes NullReferenceException in EmoteData.GetEmoteByAssetId. Set to -1/-1 to disable.</summary>
    public int EmoteAssetIdStart { get; set; } = -1;
    public int EmoteAssetIdEnd { get; set; } = -1;

    /// <summary>Player banner asset IDs use base 500000 (PlayerBannerData.assetPlayerBannerOffset). Inclusive range.</summary>
    public int BannerAssetIdStart { get; set; } = -1;
    public int BannerAssetIdEnd { get; set; } = -1;

    /// <summary>Mastery badge asset IDs use base 600000 (MasteryBadgeData.assetMasteryBadgeOffset). Inclusive range.</summary>
    public int MasteryBadgeAssetIdStart { get; set; } = -1;
    public int MasteryBadgeAssetIdEnd { get; set; } = -1;

    /// <summary>Tombstone asset IDs use base 700000 (TombstoneData.assetTombstoneOffset). Inclusive range.</summary>
    public int TombstoneAssetIdStart { get; set; } = -1;
    public int TombstoneAssetIdEnd { get; set; } = -1;

    /// <summary>Currency asset IDs that should be granted when GrantAllCurrencies is effective.</summary>
    public int[] CurrencyAssetIds { get; set; } = [1, 2, 3, 4, 5];

    /// <summary>Comma-separated list of currency asset IDs (alternative to CurrencyAssetIds, mergeable from AMP).</summary>
    public string CurrencyAssetIdsCsv { get; set; } = "";

    /// <summary>Balance returned for currency assets. Large enough that the client never thinks the player is broke.</summary>
    public int CurrencyBalance { get; set; } = 999_999;

    /// <summary>Asset ID that maps to BAPBAP charTokens. Default 2 (assetId 1=fractals, 2=charTokens, 3=gold).</summary>
    public int CharTokenAssetId { get; set; } = 2;

    /// <summary>Override balance for the charTokens asset. Default 0 since with UnlockEverything all chars are already unlocked.</summary>
    public int CharTokenBalance { get; set; } = 0;

    /// <summary>Asset ID that maps to BAPBAP gold. Default 0 (per CurrencyData.asset: gold=0, fractals=1, charTokens=2, challengeLive=3).</summary>
    public int GoldAssetId { get; set; } = 0;

    /// <summary>
    /// Optional explicit list of asset IDs to also report as owned (in addition to the ranges above).
    /// </summary>
    public int[] ExtraOwnedAssetIds { get; set; } = [];

    // ------- Effective getters (master switch overrides per-category when ON) -------
    // [JsonIgnore] keeps these out of any serialization round-trip; they are computed.

    [JsonIgnore] public bool EffectiveUnlockSkins         => UnlockEverything || UnlockAllSkins;
    [JsonIgnore] public bool EffectiveUnlockBanners       => UnlockEverything || UnlockAllBanners;
    [JsonIgnore] public bool EffectiveUnlockEmotes        => UnlockEverything || UnlockAllEmotes;
    [JsonIgnore] public bool EffectiveUnlockMasteryBadges => UnlockEverything || UnlockAllMasteryBadges;
    [JsonIgnore] public bool EffectiveUnlockTombstones    => UnlockEverything || UnlockAllTombstones;
    [JsonIgnore] public bool EffectiveGrantCurrencies     => UnlockEverything || GrantAllCurrencies;
}

public sealed class ExternalGameServerOptions
{
    public string Hostname { get; set; } = "127.0.0.1";
    public int WsPort { get; set; } = 7777;
    public int KcpPort { get; set; } = 7778;
    public int TcpPort { get; set; } = 7779;
}

public sealed class MatchDefaults
{
    public string RegionId { get; set; } = "custom";
    public int UnityGameMode { get; set; } = 0;
    public int MatchmakingGameMode { get; set; } = 3;
    public int MapId { get; set; } = 1;
    public int TeamSize { get; set; } = 1;
    public int MaxTeams { get; set; } = 8;
    public int BotTeams { get; set; } = 0;
    public int BotDifficulty { get; set; } = 1;
    public int CharSelectMillis { get; set; } = 20000;
    public int SpawnSelectMillis { get; set; } = 10000;
    public int SpawnShowMillis { get; set; } = 3000;

    /// <summary>
    /// Char IDs the client may pick. Lower priority than EnabledCharactersByName / EnabledCharacterIds.
    /// Empty defaults to all known character IDs.
    /// (Kept for compatibility with previously-deployed configs.)
    /// </summary>
    public int[] AvailableCharacters { get; set; } = CharacterCatalog.AllIds;

    /// <summary>Comma-separated list of character IDs (mergeable from AMP, alt to AvailableCharacters).</summary>
    public string AvailableCharactersCsv { get; set; } = "";

    /// <summary>
    /// Names of characters enabled for play. Resolved via <see cref="CharacterCatalog.NameToId"/>.
    /// Highest priority - if non-empty, EnabledCharacterIds and AvailableCharacters are ignored.
    /// Empty/null = fall through to EnabledCharacterIds.
    /// AMP tip: render this as a per-name toggle list using <see cref="CharacterCatalog.Names"/>.
    /// </summary>
    public string[] EnabledCharactersByName { get; set; } = [];

    /// <summary>
    /// IDs of characters enabled for play. Used when EnabledCharactersByName is empty.
    /// Empty/null = fall through to AvailableCharacters, and ultimately to all known character IDs.
    /// </summary>
    public int[] EnabledCharacterIds { get; set; } = [];

    public int[] GameModifierIds { get; set; } = [];
    public string GameModifierIdsCsv { get; set; } = "";
    public DimensionData[] DimensionData { get; set; } = [];
    public string DimensionDataJson { get; set; } = "";

    /// <summary>
    /// Per-game-mode map pool. Lower priority than NamedMapPool but kept stable for
    /// existing deployments. Each entry maps a UnityGameModeId to a list of map IDs.
    /// </summary>
    public MapMappingEntry[] MapMapping { get; set; } =
    [
        new MapMappingEntry { UnityGameModeId = 0, MapIds = [1] },
        new MapMappingEntry { UnityGameModeId = 1, MapIds = [1, 2, 3, 4] }
    ];

    /// <summary>Optional JSON override for MapMapping (mergeable from AMP as a single string).</summary>
    public string MapMappingJson { get; set; } = "";

    /// <summary>
    /// Friendly per-game-mode map pool: same shape as MapMapping but accepts both
    /// names and ids and labels the game mode for display.
    /// Highest priority among map pool sources.
    /// Empty/null = fall through to EnabledMapIds, then EnabledMapsByName, then MapMapping.
    /// AMP tip: render game mode names with multi-select map name toggles.
    /// </summary>
    public NamedMapPoolEntry[] NamedMapPool { get; set; } = [];

    /// <summary>
    /// Names of maps enabled (across ALL game modes). Resolved via <see cref="MapCatalog.NameToId"/>.
    /// Empty/null = no name-based restriction; falls through to EnabledMapIds.
    /// AMP tip: render as a multi-select using <see cref="MapCatalog.NameToId"/> keys.
    /// </summary>
    public string[] EnabledMapsByName { get; set; } = [];

    /// <summary>
    /// IDs of maps enabled (across ALL game modes). Used when EnabledMapsByName is empty.
    /// Empty/null = no id-based restriction; falls through to MapMapping.
    /// </summary>
    public int[] EnabledMapIds { get; set; } = [];

    /// <summary>Comma-separated list of game mode IDs to advertise in the lobby. Empty = only Solos (3).
    /// Available: 0=Warmup, 1=MiniDuos, 2=MiniTrios, 3=Solos, 4=Duos, 5=Trios, 6=RankedDuos, 7=RankedTrios, 8=Event, 9=FreeForAll, 10=CustomGame</summary>
    public string EnabledGameModeIdsCsv { get; set; } = "3";
    public bool RandomizeMapPerMatch { get; set; } = true;
}

/// <summary>
/// Per-game-mode map pool with both names and ids for AMP-friendly editing.
/// Resolution rule: when both <see cref="MapIds"/> and <see cref="MapNames"/> are populated,
/// MapIds wins. Names are resolved via <see cref="MapCatalog.NameToId"/>; unknown names are dropped
/// with a warning by the consumer.
/// </summary>
public sealed class NamedMapPoolEntry
{
    public int UnityGameModeId { get; set; }

    /// <summary>Optional friendly game mode name for display only (e.g. "Solos"). Not used in resolution.</summary>
    public string GameModeName { get; set; } = "";

    /// <summary>Map IDs in the pool. Wins when non-empty.</summary>
    public int[] MapIds { get; set; } = [];

    /// <summary>Map names in the pool, resolved against MapCatalog when MapIds is empty.</summary>
    public string[] MapNames { get; set; } = [];
}

// ===================== Network tuning =====================

/// <summary>
/// Mirror / KCP tuning hints. Written by AMP and consumed by the dedicated server
/// (forwarded as game launcher arguments or env vars) to apply Mirror
/// NetworkServer.sendRate and KcpTransport window sizes. No effect on the lobby
/// ASP.NET server itself.
/// </summary>
public sealed class NetworkTuningOptions
{
    /// <summary>Master switch. When false, the dedicated server uses Mirror's defaults.</summary>
    public bool Enabled { get; set; } = true;

    /// <summary>Mirror NetworkServer send rate in Hz. 60 is BAPBAP's typical target.</summary>
    public int SendRate { get; set; } = 60;

    /// <summary>KcpTransport.SendWindowSize. Larger = better burst tolerance, more memory.</summary>
    public int KcpSendWindow { get; set; } = 4096;

    /// <summary>KcpTransport.ReceiveWindowSize. Larger = better burst tolerance, more memory.</summary>
    public int KcpReceiveWindow { get; set; } = 4096;

    /// <summary>NetworkClient.snapshotSettings.bufferTimeMultiplier. 2.0 = light buffer, 3.0 = forgiving.</summary>
    public double SnapshotBufferTimeMultiplier { get; set; } = 2.0;

    /// <summary>
    /// When true, AI projectile NetworkBehaviour clientToServer / serverToClient transforms
    /// skip interpolation and rely on raw snapshots. This is the targeted workaround for
    /// the playtest AI-projectile-desync bug; safe to leave on for custom servers.
    /// </summary>
    public bool DisableInterpolationForProjectiles { get; set; } = true;
}

// ===================== Static shop seeding =====================

/// <summary>
/// Static shop entry used by AMP-driven shop seeding. When AMP supplies any
/// <c>StaticShopListings</c> on <c>ShopOptions</c>, the server treats those entries as
/// the authoritative shop rotation and skips the built-in default seed.
/// Defined here (instead of in ShopService.cs) so AMP-facing config DTOs are colocated.
/// </summary>
public sealed class StaticShopItem
{
    /// <summary>BAPBAP asset id (300000+ skins, 400000+ emotes, 500000+ banners, 600000+ mastery, 700000+ tombstones).</summary>
    public int AssetId { get; set; }

    /// <summary>Display name shown in AMP / shop responses. Free-form, e.g. "Skin_Chuck_Default".</summary>
    public string Name { get; set; } = "";

    /// <summary>Gold price.</summary>
    public int Price { get; set; }

    /// <summary>Lower-case category. One of "skin", "banner", "emote", "mastery", "tombstone".</summary>
    public string Category { get; set; } = "";
}

// ===================== Catalogs (server-side resolution of AMP names -> ids) =====================

/// <summary>
/// Friendly character names &lt;-&gt; charIds. Resolves <see cref="MatchDefaults.EnabledCharactersByName"/>.
/// Source of truth for the "Character toggles" AMP tab.
/// </summary>
public static class CharacterCatalog
{
    public const int MedusaCharId = 15;

    /// <summary>Index = charId, value = canonical display name. Order matches Program.PlayableCharacterIds.</summary>
    public static readonly string[] Names =
    {
        "Kitsu",   //  0
        "Anna",    //  1
        "Chuck",   //  2
        "Sashimi", //  3
        "Kiddo",   //  4
        "Zook",    //  5
        "Skinny",  //  6
        "Froggy",  //  7
        "Teevee",  //  8
        "Sofia",   //  9
        "Jiro",    // 10
        "Bishop",  // 11
        "Celeste", // 12
        "Kate",    // 13
        "Rocky",   // 14
        "Medusa"   // 15 - custom ModAPI character
    };

    /// <summary>Known playable IDs, including custom characters shipped with this server bundle.</summary>
    public static int[] AllIds => Enumerable.Range(0, Names.Length).ToArray();

    /// <summary>
    /// Default skin asset per charId. Medusa currently reuses Kitsu's default skin id because
    /// the upstream Medusa asset drop contains no native 2D/skin asset entry for this older build.
    /// </summary>
    public static readonly int[] DefaultSkinAssetIds =
    [
        300018, // 0: Kitsu
        300000, // 1: Anna
        300007, // 2: Chuck
        300020, // 3: Sashimi
        300017, // 4: Kiddo
        300026, // 5: Zook
        300021, // 6: Skinny
        300013, // 7: Froggy
        300025, // 8: Teevee
        300023, // 9: Sofia
        300015, // 10: Jiro
        300003, // 11: Bishop
        300005, // 12: Celeste
        300016, // 13: Kate
        300019, // 14: Rocky
        300018  // 15: Medusa fallback skin
    ];

    public static bool IsKnownId(int charId) => charId >= 0 && charId < Names.Length;

    public static int GetDefaultSkinAssetId(int charId) =>
        IsKnownId(charId) ? DefaultSkinAssetIds[charId] : DefaultSkinAssetIds[0];

    /// <summary>Case-insensitive lookup name -> id.</summary>
    public static readonly Dictionary<string, int> NameToId =
        Enumerable.Range(0, Names.Length)
            .ToDictionary(i => Names[i], i => i, StringComparer.OrdinalIgnoreCase);

    public static bool TryResolve(string? name, out int charId)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            charId = -1;
            return false;
        }
        return NameToId.TryGetValue(name.Trim(), out charId);
    }

    /// <summary>Resolve a sequence of names to a sorted, distinct array of charIds. Unknown names are silently dropped.</summary>
    public static int[] ResolveAll(IEnumerable<string>? names)
    {
        if (names is null) return [];
        var ids = new List<int>();
        foreach (var n in names)
        {
            if (TryResolve(n, out int id)) ids.Add(id);
        }
        return ids.Distinct().OrderBy(i => i).ToArray();
    }
}

/// <summary>
/// Friendly map names &lt;-&gt; mapIds. Resolves <see cref="MatchDefaults.EnabledMapsByName"/>
/// and <see cref="NamedMapPoolEntry.MapNames"/>.
///
/// NOTE: This catalog is the SINGLE SOURCE OF TRUTH for map name -> id resolution and MUST
/// stay in sync with <see cref="MapPoolOptions.BuildEnabledMapIds"/> and the AMP config file
/// (deployment/amp-github-autoinstall/bapcustomservergithubconfig.json), which describe these
/// IDs in player-facing labels. The canonical mapping comes from the Melon mod's
/// KnownLevelNames table:
///   1 = Map2_BazaarCity 3
///   2 = Map3_Lyceum
///   3 = Arena_Map2
///   4 = OpenBetaMap#J02_P_Boccato
/// If BAPBAP ships new maps or renumbers them, update this dictionary AND MapPoolOptions
/// AND the AMP config descriptions in lockstep.
/// </summary>
public static class MapCatalog
{
    public const int BazaarCityId = 1;
    public const int LyceumId = 2;
    public const int ArenaMap2Id = 3;
    public const int OpenBetaBoccatoId = 4;

    public static readonly Dictionary<int, string> IdToName = new()
    {
        { BazaarCityId, "Map2_BazaarCity 3" },
        { LyceumId, "Map3_Lyceum" },
        { ArenaMap2Id, "Arena_Map2" },
        { OpenBetaBoccatoId, "OpenBetaMap#J02_P_Boccato" },
    };

    /// <summary>Friendly name -> mapId. Must match <see cref="MapPoolOptions.BuildEnabledMapIds"/>.</summary>
    public static readonly Dictionary<string, int> NameToId = new(StringComparer.OrdinalIgnoreCase)
    {
        { "Map2_BazaarCity 3", BazaarCityId },
        { "BazaarCity", BazaarCityId },
        { "Bazaarcity", BazaarCityId },
        { "Tireclub", BazaarCityId },
        { "Tire Club", BazaarCityId },

        { "Map3_Lyceum", LyceumId },
        { "Lyceum", LyceumId },
        { "BazaarcityLegacyId2", LyceumId },

        { "Arena_Map2", ArenaMap2Id },
        { "Arena Map2", ArenaMap2Id },
        { "Arena", ArenaMap2Id },
        { "Bonsai", ArenaMap2Id },

        { "OpenBetaMap#J02_P_Boccato", OpenBetaBoccatoId },
        { "OpenBeta Boccato", OpenBetaBoccatoId },
        { "Boccato", OpenBetaBoccatoId },
        { "Sunset", OpenBetaBoccatoId },
    };

    public static bool TryResolve(string? name, out int mapId)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            mapId = -1;
            return false;
        }
        return NameToId.TryGetValue(name.Trim(), out mapId);
    }

    /// <summary>Resolve a sequence of names to a sorted, distinct array of mapIds. Unknown names are silently dropped.</summary>
    public static int[] ResolveAll(IEnumerable<string>? names)
    {
        if (names is null) return [];
        var ids = new List<int>();
        foreach (var n in names)
        {
            if (TryResolve(n, out int id)) ids.Add(id);
        }
        return ids.Distinct().OrderBy(i => i).ToArray();
    }
}

/// <summary>Game mode id -> friendly name catalog for AMP display.
/// Used by NamedMapPoolEntry display labels and to render the game mode dropdown.</summary>
public static class GameModeCatalog
{
    public static readonly Dictionary<int, string> IdToName = new()
    {
        { 0,  "Warmup" },
        { 1,  "MiniDuos" },
        { 2,  "MiniTrios" },
        { 3,  "Solos" },
        { 4,  "Duos" },
        { 5,  "Trios" },
        { 6,  "RankedDuos" },
        { 7,  "RankedTrios" },
        { 8,  "Event" },
        { 9,  "FreeForAll" },
        { 10, "CustomGame" },
    };

    public static readonly Dictionary<string, int> NameToId =
        IdToName.ToDictionary(kv => kv.Value, kv => kv.Key, StringComparer.OrdinalIgnoreCase);

    public static bool TryResolve(string? name, out int gameModeId)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            gameModeId = -1;
            return false;
        }
        return NameToId.TryGetValue(name.Trim(), out gameModeId);
    }
}
