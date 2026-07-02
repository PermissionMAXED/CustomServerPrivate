using BapCustomServer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Net.WebSockets;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);
var diagnosticsLogBuffer = new DiagnosticsLogBuffer();

// NOTE: Kestrel NoDelay tweak removed - the API doesn't expose ListenOptions.NoDelay directly.
// TCP_NODELAY is set by default for HTTP/1.1 sockets in modern Kestrel anyway.

// The dedicated game-server bootstrap loop intentionally polls 127.0.0.1:<httpPort>
// while Unity/Wine starts. The default IHttpClientFactory handlers log every refused
// connection at Information level, which drowns out the real AMP diagnostics.
builder.Logging.AddFilter("System.Net.Http.HttpClient.game-server", LogLevel.Warning);
builder.Logging.AddFilter("System.Net.Http.HttpClient.game-server.ClientHandler", LogLevel.Warning);
builder.Logging.AddFilter("System.Net.Http.HttpClient.game-server.LogicalHandler", LogLevel.Warning);
builder.Logging.AddFilter("Microsoft.AspNetCore.Hosting.Diagnostics", LogLevel.Warning);
builder.Logging.AddFilter("Microsoft.AspNetCore.Routing.EndpointMiddleware", LogLevel.Warning);
builder.Logging.AddFilter("Microsoft.AspNetCore.Http.Result", LogLevel.Warning);
builder.Logging.AddProvider(new DiagnosticsLogBufferProvider(diagnosticsLogBuffer));

builder.Services.AddSingleton(diagnosticsLogBuffer);
builder.Services.Configure<CustomServerOptions>(builder.Configuration.GetSection("CustomServer"));
builder.Services.Configure<AdminOptions>(builder.Configuration.GetSection("CustomServer:Admin"));
builder.Services.Configure<UnlockOptions>(builder.Configuration.GetSection("CustomServer:Unlocks"));
builder.Services.Configure<FriendsOptions>(builder.Configuration.GetSection("CustomServer:Friends"));
builder.Services.Configure<EconomyOptions>(builder.Configuration.GetSection("CustomServer:Economy"));
builder.Services.Configure<ShopOptions>(builder.Configuration.GetSection("CustomServer:Shop"));
builder.Services.Configure<MatchHistoryOptions>(builder.Configuration.GetSection("CustomServer:MatchHistory"));
builder.Services.Configure<RankedOptions>(builder.Configuration.GetSection("CustomServer:Ranked"));
builder.Services.Configure<MatchmakingQueueOptions>(builder.Configuration.GetSection("CustomServer:MatchmakingQueue"));
builder.Services.Configure<PlayerStorageOptions>(builder.Configuration.GetSection("CustomServer:PlayerStorage"));
builder.Services.PostConfigure<CustomServerOptions>(options =>
{
    options.MatchDefaults.AvailableCharacters = options.MatchDefaults.AvailableCharacters
        .Concat(ParseIntCsv(options.MatchDefaults.AvailableCharactersCsv))
        .Where(CharacterCatalog.IsKnownId)
        .Distinct()
        .OrderBy(id => id)
        .ToArray();
    options.MatchDefaults.AvailableCharacters = options.MatchDefaults.AvailableCharacters.Length == 0
        ? CharacterCatalog.AllIds
        : options.MatchDefaults.AvailableCharacters.Distinct().ToArray();
    options.MatchDefaults.GameModifierIds = options.MatchDefaults.GameModifierIds
        .Concat(ParseIntCsv(options.MatchDefaults.GameModifierIdsCsv))
        .Distinct()
        .ToArray();
    DimensionData[] dimensionDataFromJson = ParseDimensionDataJson(options.MatchDefaults.DimensionDataJson);
    if (dimensionDataFromJson.Length > 0)
    {
        options.MatchDefaults.DimensionData = options.MatchDefaults.DimensionData
            .Concat(dimensionDataFromJson)
            .ToArray();
    }

    options.MatchDefaults.DimensionData = options.MatchDefaults.DimensionData
        .DistinctBy(entry => $"{entry.DimensionId}:{string.Join(",", entry.Rounds)}")
        .ToArray();

    MapMappingEntry[] mapsFromJson = ParseMapMappingJson(options.MatchDefaults.MapMappingJson);
    if (mapsFromJson.Length > 0)
    {
        // JSON entries override defaults: replace mapping for any UnityGameModeId provided in JSON.
        var byMode = options.MatchDefaults.MapMapping.ToDictionary(m => m.UnityGameModeId, m => m);
        foreach (MapMappingEntry entry in mapsFromJson)
        {
            byMode[entry.UnityGameModeId] = entry;
        }
        options.MatchDefaults.MapMapping = byMode.Values.ToArray();
    }

    options.MatchDefaults.MapMapping = options.MatchDefaults.MapMapping
        .DistinctBy(entry => $"{entry.UnityGameModeId}:{string.Join(",", entry.MapIds)}")
        .ToArray();

    options.Unlocks.CurrencyAssetIds = options.Unlocks.CurrencyAssetIds
        .Concat(ParseIntCsv(options.Unlocks.CurrencyAssetIdsCsv))
        .Distinct()
        .ToArray();
});
builder.Services.PostConfigure<EconomyOptions>(eco =>
{
    int[] fromCsv = ParseIntCsv(eco.PlacementGoldCsv);
    if (fromCsv.Length > 0)
    {
        eco.PlacementGold = fromCsv;
    }
});
builder.Services.PostConfigure<RankedOptions>(rank =>
{
    int[] fromCsv = ParseIntCsv(rank.PlacementPointsCsv);
    if (fromCsv.Length > 0)
    {
        rank.PlacementPoints = fromCsv;
    }
});
int gameServerBootstrapHttpTimeoutSeconds = Math.Clamp(
    builder.Configuration.GetValue<int?>("CustomServer:GameServerBootstrapHttpTimeoutSeconds") ?? 20,
    3,
    120);
builder.Services.AddHttpClient(GameServerProcessManager.HttpClientName, client =>
{
    client.Timeout = TimeSpan.FromSeconds(gameServerBootstrapHttpTimeoutSeconds);
});
builder.Services.AddSingleton(sp =>
{
    var options = sp.GetRequiredService<IOptions<CustomServerOptions>>().Value;
    return new PortAllocator
    {
        CooldownDuration = TimeSpan.FromSeconds(Math.Max(0, options.PortReleaseCooldownSeconds))
    };
});
builder.Services.AddSingleton<ServerAdminService>();
builder.Services.AddSingleton<PlayerStorageService>();
builder.Services.AddSingleton<FriendsService>();
builder.Services.AddSingleton<EconomyService>();
builder.Services.AddSingleton<ShopService>();
builder.Services.AddSingleton<MatchHistoryService>();
builder.Services.AddSingleton<RankedService>();
builder.Services.AddSingleton<MatchmakingQueueService>();
builder.Services.AddSingleton<GameServerPrewarmService>();
builder.Services.AddSingleton<GameServerProcessManager>();
builder.Services.AddSingleton<LobbyService>();
builder.Services.AddHostedService(sp => sp.GetRequiredService<GameServerPrewarmService>());
builder.Services.AddHostedService<MatchmakingHostedService>();
builder.Services.AddHostedService<ResourceMonitorService>();

// Rate limiting for admin endpoints (mitigates token brute-force).
// Fixed window: 20 requests / 10 seconds per remote IP, no queue.
builder.Services.AddRateLimiter(o =>
{
    o.AddFixedWindowLimiter("admin", opt =>
    {
        opt.Window = TimeSpan.FromSeconds(10);
        opt.PermitLimit = 20;
        opt.QueueLimit = 0;
    });
    o.RejectionStatusCode = 429;
});

var app = builder.Build();
DeploymentInfo deploymentInfo = LoadDeploymentInfo(app.Environment.ContentRootPath);
RuntimeDiagnostics runtimeDiagnostics = BuildRuntimeDiagnostics();
LogStartupDiagnostics(
    app,
    deploymentInfo,
    runtimeDiagnostics,
    app.Services.GetRequiredService<IOptions<CustomServerOptions>>().Value);

app.UseRateLimiter();

app.UseWebSockets(new WebSocketOptions
{
    KeepAliveInterval = TimeSpan.FromSeconds(20)
});

// Log 404s to help identify missing endpoints
app.Use(async (context, next) =>
{
    await next();
    if (context.Response.StatusCode == 404)
    {
        app.Logger.LogWarning("404 Not Found: {Method} {Path}", context.Request.Method, context.Request.Path);
    }
});

app.MapGet("/", (LobbyService lobbyService, IOptions<CustomServerOptions> options) =>
{
    return Results.Json(new
    {
        service = "BAPBAP custom match server",
        websocket = lobbyService.BuildSocketUrl(null),
        launchGameServers = options.Value.LaunchGameServers,
        medusa = new
        {
            charId = CharacterCatalog.MedusaCharId,
            rosterEnabled = options.Value.Roster.EnableMedusa,
            available = options.Value.MatchDefaults.AvailableCharacters.Contains(CharacterCatalog.MedusaCharId)
        },
        deployment = deploymentInfo,
        lobbies = lobbyService.GetLobbySnapshots()
    }, JsonContract.Options);
});

app.MapGet("/health", (IOptions<CustomServerOptions> options, IOptions<MatchmakingQueueOptions> queueOptions, GameServerPrewarmService prewarmService) => Results.Ok(new
{
    ok = true,
    release = deploymentInfo.ReleaseLabel,
    gitCommit = deploymentInfo.GitCommit,
    packageBuildUtc = deploymentInfo.PackageBuildUtc,
    runtime = new
    {
        os = runtimeDiagnostics.OsDescription,
        framework = runtimeDiagnostics.FrameworkDescription,
        wineAvailable = !string.IsNullOrWhiteSpace(runtimeDiagnostics.WinePath),
        winePath = runtimeDiagnostics.WinePath,
        wineVersion = runtimeDiagnostics.WineVersion,
        winebootAvailable = !string.IsNullOrWhiteSpace(runtimeDiagnostics.WinebootPath),
        xvfbRunAvailable = !string.IsNullOrWhiteSpace(runtimeDiagnostics.XvfbRunPath),
        xauthAvailable = !string.IsNullOrWhiteSpace(runtimeDiagnostics.XauthPath),
        glxinfoAvailable = !string.IsNullOrWhiteSpace(runtimeDiagnostics.GlxinfoPath),
        vulkanInfoAvailable = !string.IsNullOrWhiteSpace(runtimeDiagnostics.VulkanInfoPath),
        winePrefix = runtimeDiagnostics.WinePrefix,
        wineArch = runtimeDiagnostics.WineArch
    },
    queue = new
    {
        queueTimerSeconds = queueOptions.Value.QueueTimerSeconds,
        failedStartRetryDelaySeconds = queueOptions.Value.FailedStartRetryDelaySeconds,
        gameServerReadyTimeoutSeconds = options.Value.GameServerReadyTimeoutSeconds,
        gameServerBootstrapHttpTimeoutSeconds = options.Value.GameServerBootstrapHttpTimeoutSeconds,
        gameServerBootstrapResetPollMillis = options.Value.GameServerBootstrapResetPollMillis,
        gameServerManagedBootstrapStatusTimeoutSeconds = options.Value.GameServerManagedBootstrapStatusTimeoutSeconds,
        gameServerManagedBootstrapListenerOnlyTimeoutSeconds = options.Value.GameServerManagedBootstrapListenerOnlyTimeoutSeconds,
        effectiveGameServerManagedBootstrapListenerOnlyTimeoutSeconds = GameServerProcessManager.EffectiveManagedBootstrapListenerOnlyTimeoutSeconds(options.Value),
        requireGameServerKcpPort = options.Value.RequireGameServerKcpPort,
        gameServerTcpPortReadyTimeoutSeconds = options.Value.GameServerTcpPortReadyTimeoutSeconds,
        gameServerKcpPortReadyTimeoutSeconds = options.Value.GameServerKcpPortReadyTimeoutSeconds,
        gameServerStartAttempts = options.Value.GameServerStartAttempts,
        effectiveGameServerStartAttempts = GameServerProcessManager.EffectiveGameServerStartAttempts(options.Value),
        gameServerStartRetryDelaySeconds = options.Value.GameServerStartRetryDelaySeconds,
        gameServerStopWaitMillis = options.Value.GameServerStopWaitMillis,
        gameServerPostCleanupStartDelayMillis = options.Value.GameServerPostCleanupStartDelayMillis,
        gameServerStartupStallGraceSeconds = options.Value.GameServerStartupStallGraceSeconds,
        gameServerStartupStallSeconds = options.Value.GameServerStartupStallSeconds,
        gameServerWrapperOnlyStartupStallGraceSeconds = options.Value.GameServerWrapperOnlyStartupStallGraceSeconds,
        gameServerWrapperOnlyStartupStallSeconds = options.Value.GameServerWrapperOnlyStartupStallSeconds,
        effectiveNoisyStartupStallGraceSeconds = GameServerProcessManager.EffectiveNoisyStartupStallGraceSeconds(options.Value),
        effectiveNoisyStartupStallSeconds = GameServerProcessManager.EffectiveNoisyStartupStallSeconds(options.Value),
        effectiveWrapperOnlyStartupStallGraceSeconds = GameServerProcessManager.EffectiveWrapperOnlyStartupStallGraceSeconds(options.Value),
        effectiveWrapperOnlyStartupStallSeconds = GameServerProcessManager.EffectiveWrapperOnlyStartupStallSeconds(options.Value),
        gameServerPrewarmOnStartup = options.Value.GameServerPrewarmOnStartup,
        gameServerPrewarmTimeoutSeconds = options.Value.GameServerPrewarmTimeoutSeconds,
        gameServerPrewarmMatchWaitSeconds = options.Value.GameServerPrewarmMatchWaitSeconds,
        gameServerPrewarmPortOffset = options.Value.GameServerPrewarmPortOffset,
        emptyLobbyMatchCleanupGraceSeconds = options.Value.EmptyLobbyMatchCleanupGraceSeconds,
        emptyLobbyMatchConnectedCleanupGraceSeconds = options.Value.EmptyLobbyMatchConnectedCleanupGraceSeconds
    },
    prewarm = prewarmService.GetStatus(),
    artifacts = new
    {
        serverDllSha256 = deploymentInfo.ServerDllSha256,
        modDllSha256 = deploymentInfo.ModDllSha256,
        modApiDllSha256 = deploymentInfo.ModApiDllSha256,
        medusaDllSha256 = deploymentInfo.MedusaDllSha256,
        medusaBundleSha256 = deploymentInfo.MedusaBundleSha256,
        gameExeSha256 = deploymentInfo.GameExeSha256,
        startMatchSha256 = deploymentInfo.StartMatchSha256,
        packageSha256 = deploymentInfo.PackageSha256
    },
    medusa = new
    {
        charId = CharacterCatalog.MedusaCharId,
        rosterEnabled = options.Value.Roster.EnableMedusa,
        available = options.Value.MatchDefaults.AvailableCharacters.Contains(CharacterCatalog.MedusaCharId),
        modApiDllSha256 = deploymentInfo.ModApiDllSha256,
        medusaDllSha256 = deploymentInfo.MedusaDllSha256,
        medusaBundleSha256 = deploymentInfo.MedusaBundleSha256
    }
}));

app.MapGet("/api/diagnostics/runtime", () => Results.Json(new
{
    deployment = deploymentInfo,
    runtime = runtimeDiagnostics
}, JsonContract.Options));

app.MapGet("/api/diagnostics/game-logs", (IOptions<CustomServerOptions> options, int? tailLines, int? files) =>
{
    return Results.Json(
        BuildGameLogDiagnostics(app.Environment.ContentRootPath, options.Value, tailLines, files),
        JsonContract.Options);
});

app.MapGet("/api/diagnostics/server-log", (DiagnosticsLogBuffer buffer, int? tail) =>
{
    return Results.Json(new
    {
        tail = Math.Clamp(tail ?? 250, 1, 1200),
        entries = buffer.Tail(Math.Clamp(tail ?? 250, 1, 1200))
    }, JsonContract.Options);
});

app.MapGet("/api/server-config", (IOptions<CustomServerOptions> options) =>
{
    var opts = options.Value;
    return Results.Json(new
    {
        matchmakingPolicy = opts.MatchmakingPolicy.ToString(),
        allowMatchmaking = opts.MatchmakingPolicy != MatchmakingPolicy.CustomOnly,
        allowCustomMatch = opts.MatchmakingPolicy != MatchmakingPolicy.MatchmakingOnly,
        publicBaseUrl = opts.PublicBaseUrl,
        publicGameHost = opts.PublicGameHost,
        moddingOverlayTitle = opts.ModdingOverlayTitle,
        moddingOverlaySubtitle = opts.ModdingOverlaySubtitle,
        availableCharacters = opts.MatchDefaults.AvailableCharacters,
        medusa = new
        {
            charId = CharacterCatalog.MedusaCharId,
            rosterEnabled = opts.Roster.EnableMedusa,
            available = opts.MatchDefaults.AvailableCharacters.Contains(CharacterCatalog.MedusaCharId)
        },
    }, JsonContract.Options);
});

// Ensure game server processes are cleaned up on shutdown.
var lifetime = app.Services.GetRequiredService<IHostApplicationLifetime>();
var lobbyServiceForShutdown = app.Services.GetRequiredService<LobbyService>();
lifetime.ApplicationStopping.Register(() => lobbyServiceForShutdown.StopAllMatches());

MapSocketDiscovery(app, "/api/lobbies/socket");
MapSocketDiscovery(app, "/api/lobby/socket");
MapSocketDiscovery(app, "/lobbies/socket");
MapSocketDiscovery(app, "/lobby/socket");
MapSocketDiscovery(app, "/api/socket");
MapSocketDiscovery(app, "/socket");

app.MapGet("/api/internal/servers", GetInternalServers);
app.MapGet("/internal/servers", GetInternalServers);

app.MapGet("/api/load", BuildLoadResult);
app.MapPost("/api/load", BuildLoadResult);
app.MapGet("/load", BuildLoadResult);
app.MapPost("/load", BuildLoadResult);
app.MapGet("/api/login", BuildLoadResult);
app.MapPost("/api/login", BuildLoadResult);
app.MapGet("/login", BuildLoadResult);
app.MapPost("/login", BuildLoadResult);
app.MapGet("/api/guest", BuildLoadResult);
app.MapPost("/api/guest", BuildLoadResult);
app.MapGet("/guest", BuildLoadResult);
app.MapPost("/guest", BuildLoadResult);
app.MapGet("/api/auth/guest", BuildLoadResult);
app.MapPost("/api/auth/guest", BuildLoadResult);
app.MapGet("/auth/guest", BuildLoadResult);
app.MapPost("/auth/guest", BuildLoadResult);
app.MapGet("/api/link/{provider}", (string provider) => Results.Json(new { provider, @params = "" }, JsonContract.Options));
app.MapPost("/api/link/{provider}", (string provider) => Results.Json(new { provider, @params = "" }, JsonContract.Options));
app.MapGet("/link/{provider}", (string provider) => Results.Json(new { provider, @params = "" }, JsonContract.Options));
app.MapPost("/link/{provider}", (string provider) => Results.Json(new { provider, @params = "" }, JsonContract.Options));
app.MapGet("/api/complete", BuildCompleteResult);
app.MapPost("/api/complete", BuildCompleteResult);
app.MapGet("/complete", BuildCompleteResult);
app.MapPost("/complete", BuildCompleteResult);
app.MapGet("/api/return", () => Results.Json(new { twitchUsername = "" }, JsonContract.Options));
app.MapGet("/return", () => Results.Json(new { twitchUsername = "" }, JsonContract.Options));

// Additional auth aliases the client calls right after /api/load to dismiss the splash.
app.MapGet("/api/auth/complete", BuildCompleteResult);
app.MapPost("/api/auth/complete", BuildCompleteResult);
app.MapGet("/auth/complete", BuildCompleteResult);
app.MapPost("/auth/complete", BuildCompleteResult);
app.MapGet("/api/auth/link/{provider}", (string provider) => Results.Json(new { provider, @params = "" }, JsonContract.Options));
app.MapPost("/api/auth/link/{provider}", (string provider) => Results.Json(new { provider, @params = "" }, JsonContract.Options));
app.MapPost("/api/auth/logout", () => Results.Json(new { ok = true }, JsonContract.Options));
app.MapPost("/auth/logout", () => Results.Json(new { ok = true }, JsonContract.Options));
app.MapGet("/api/auth/logout", () => Results.Json(new { ok = true }, JsonContract.Options));
app.MapGet("/auth/logout", () => Results.Json(new { ok = true }, JsonContract.Options));
app.MapPost("/api/auth/steam-ticket/login", BuildLoadResult);
app.MapGet("/api/auth/steam-ticket/login", BuildLoadResult);

// Loadout endpoints. Every cosmetic is unlocked on a custom server, so equip
// requests just echo back success and update the in-memory load response shape.
app.MapPost("/api/loadout/banner", LoadoutEquipResult);
app.MapPost("/loadout/banner", LoadoutEquipResult);
app.MapPost("/api/loadout/skins", LoadoutEquipResult);
app.MapPost("/loadout/skins", LoadoutEquipResult);
app.MapGet("/api/loadout/banner", LoadoutEquipResult);
app.MapGet("/api/loadout/skins", LoadoutEquipResult);

// Stub endpoints that the client polls on first lobby entry. Returning an empty
// success keeps the post-auth loading state from stalling on a 404.
app.MapGet("/api/v1/user-lookup", () => Results.Json(new { users = Array.Empty<object>() }, JsonContract.Options));
app.MapPost("/api/v1/user-lookup", () => Results.Json(new { users = Array.Empty<object>() }, JsonContract.Options));
app.MapGet("/api/internal/api2/channels/", () => Results.Json(new { channels = Array.Empty<object>() }, JsonContract.Options));
app.MapPost("/api/internal/api2/channels/", () => Results.Json(new { channels = Array.Empty<object>() }, JsonContract.Options));
app.MapGet("/api/code/creator-code", () => Results.Json(new { creatorCode = "", creatorName = "" }, JsonContract.Options));
app.MapPost("/api/code/creator-code", () => Results.Json(new { creatorCode = "", creatorName = "" }, JsonContract.Options));
app.MapPost("/api/code/redeem", () => Results.Json(new { ok = true, message = "Codes are not used on custom servers." }, JsonContract.Options));

// Shop / IAP / character purchase endpoints are no-ops on custom servers.
app.MapPost("/api/iap/steam/finalise", () => Results.Json(new { ok = true }, JsonContract.Options));
app.MapPost("/api/iap/steam/purchase", () => Results.Json(new { ok = true }, JsonContract.Options));
app.MapPost("/api/iap/xsolla/purchase", () => Results.Json(new { ok = true, redirectUrl = "" }, JsonContract.Options));
app.MapPost("/api/shop/freebie/purchase", async (HttpContext context, ShopService shopService, EconomyService economyService) =>
{
    var identity = ResolveIdentity(context);
    string? listingId = await TryReadBodyFieldAsync(context, "listingId");
    if (string.IsNullOrWhiteSpace(listingId))
        return Results.Json(new { ok = false, message = "listingId required." }, JsonContract.Options);
    var listing = shopService.GetListing(listingId);
    if (listing is null)
        return Results.Json(new { ok = false, message = "Listing not found." }, JsonContract.Options);
    economyService.GetOrCreatePlayer(identity.AccountId, identity.Username);
    var result = economyService.GrantAsset(identity.AccountId, listing.AssetId, "freebie purchase");
    return Results.Json(new { ok = result.Ok, message = result.Message, listingId, purchases = 1, rewards = new[] { new { assetId = listing.AssetId, amount = 1, balance = 1 } } }, JsonContract.Options);
});

app.MapPost("/api/shop/rotation/purchase", async (HttpContext context, ShopService shopService, EconomyService economyService) =>
{
    var identity = ResolveIdentity(context);
    string? listingId = await TryReadBodyFieldAsync(context, "listingId");
    if (string.IsNullOrWhiteSpace(listingId))
        return Results.Json(new { ok = false, message = "listingId required." }, JsonContract.Options);
    var listing = shopService.GetListing(listingId);
    if (listing is null)
        return Results.Json(new { ok = false, message = "Listing not found." }, JsonContract.Options);
    economyService.GetOrCreatePlayer(identity.AccountId, identity.Username);
    var result = economyService.PurchaseAsset(identity.AccountId, listing.AssetId, listing.Price);
    if (!result.Ok)
        return Results.Json(new { ok = false, message = result.Message }, JsonContract.Options);
    return Results.Json(new { ok = true, listingId, purchases = 1, cost = new { assetId = 0, amount = listing.Price, balance = result.NewBalance }, rewards = new[] { new { assetId = listing.AssetId, amount = 1, balance = 1 } } }, JsonContract.Options);
});
app.MapPost("/api/shop/rotation/refresh", () => Results.Json(new { ok = true }, JsonContract.Options));
app.MapPost("/api/chars/listing/purchase", () => Results.Json(new { ok = true }, JsonContract.Options));
app.MapPost("/api/chars/mastery/purchase", () => Results.Json(new { ok = true }, JsonContract.Options));
app.MapGet("/api/chars/mastery/progress", (HttpContext context, EconomyService economyService) =>
{
    var identity = ResolveIdentity(context);
    return Results.Json(new
    {
        progress = economyService.GetAllCharacterMastery(identity.AccountId)
    }, JsonContract.Options);
});
app.MapGet("/api/chars/mastery/progress/{charId:int}", (int charId, HttpContext context, EconomyService economyService) =>
{
    if (!CharacterCatalog.IsKnownId(charId))
        return Results.Json(new { ok = false, message = $"Unknown character id {charId}." }, JsonContract.Options);
    var identity = ResolveIdentity(context);
    return Results.Json(new
    {
        ok = true,
        progress = economyService.GetCharacterMasteryProgress(identity.AccountId, charId)
    }, JsonContract.Options);
});
app.MapGet("/api/chars/mastery/{charId:int}", (int charId, HttpContext context, EconomyService economyService) =>
{
    if (!CharacterCatalog.IsKnownId(charId))
        return Results.Json(new { ok = false, message = $"Unknown character id {charId}." }, JsonContract.Options);
    var identity = ResolveIdentity(context);
    return Results.Json(
        MinimalCharMasteryPass(charId, economyService.GetCharacterMasteryProgress(identity.AccountId, charId)),
        JsonContract.Options);
});
app.MapPost("/api/chars/mastery/{charId:int}", (int charId, HttpContext context, EconomyService economyService) =>
{
    if (!CharacterCatalog.IsKnownId(charId))
        return Results.Json(new { ok = false, message = $"Unknown character id {charId}." }, JsonContract.Options);
    var identity = ResolveIdentity(context);
    return Results.Json(
        MinimalCharMasteryPass(charId, economyService.GetCharacterMasteryProgress(identity.AccountId, charId)),
        JsonContract.Options);
});

// Friends endpoints with real logic
app.MapPost("/api/friends/add", async (HttpContext context, FriendsService friendsService, IOptions<FriendsOptions> friendsOpt) =>
{
    if (!friendsOpt.Value.Enabled) return Results.Json(new { ok = false, message = "Friends system disabled." }, JsonContract.Options);
    var identity = ResolveIdentity(context);
    string? toAccountId = await TryReadBodyFieldAsync(context, "accountId");
    if (string.IsNullOrWhiteSpace(toAccountId))
        return Results.Json(new { ok = false, message = "accountId is required." }, JsonContract.Options);
    var result = friendsService.SendRequest(identity.AccountId, identity.Username, identity.Discriminator, toAccountId);
    return Results.Json(new { ok = result.Ok, message = result.Message }, JsonContract.Options);
});

app.MapPost("/api/friends/accept", async (HttpContext context, FriendsService friendsService, IOptions<FriendsOptions> friendsOpt) =>
{
    if (!friendsOpt.Value.Enabled) return Results.Json(new { ok = false, message = "Friends system disabled." }, JsonContract.Options);
    var identity = ResolveIdentity(context);
    string? fromAccountId = await TryReadBodyFieldAsync(context, "accountId");
    if (string.IsNullOrWhiteSpace(fromAccountId))
        return Results.Json(new { ok = false, message = "accountId is required." }, JsonContract.Options);
    var result = friendsService.AcceptRequest(identity.AccountId, fromAccountId);
    return Results.Json(new { ok = result.Ok, message = result.Message }, JsonContract.Options);
});

app.MapPost("/api/friends/decline", async (HttpContext context, FriendsService friendsService, IOptions<FriendsOptions> friendsOpt) =>
{
    if (!friendsOpt.Value.Enabled) return Results.Json(new { ok = false, message = "Friends system disabled." }, JsonContract.Options);
    var identity = ResolveIdentity(context);
    string? fromAccountId = await TryReadBodyFieldAsync(context, "accountId");
    if (string.IsNullOrWhiteSpace(fromAccountId))
        return Results.Json(new { ok = false, message = "accountId is required." }, JsonContract.Options);
    var result = friendsService.DeclineRequest(identity.AccountId, fromAccountId);
    return Results.Json(new { ok = result.Ok, message = result.Message }, JsonContract.Options);
});

app.MapPost("/api/friends/remove", async (HttpContext context, FriendsService friendsService, IOptions<FriendsOptions> friendsOpt) =>
{
    if (!friendsOpt.Value.Enabled) return Results.Json(new { ok = false, message = "Friends system disabled." }, JsonContract.Options);
    var identity = ResolveIdentity(context);
    string? friendAccountId = await TryReadBodyFieldAsync(context, "accountId");
    if (string.IsNullOrWhiteSpace(friendAccountId))
        return Results.Json(new { ok = false, message = "accountId is required." }, JsonContract.Options);
    var result = friendsService.RemoveFriend(identity.AccountId, friendAccountId);
    return Results.Json(new { ok = result.Ok, message = result.Message }, JsonContract.Options);
});

app.MapPost("/api/friends/toggle-friend-requests", (HttpContext context, FriendsService friendsService, IOptions<FriendsOptions> friendsOpt) =>
{
    if (!friendsOpt.Value.Enabled) return Results.Json(new { ok = false, message = "Friends system disabled." }, JsonContract.Options);
    var identity = ResolveIdentity(context);
    bool current = friendsService.AreFriendRequestsOpen(identity.AccountId);
    friendsService.SetFriendRequestsOpen(identity.AccountId, !current);
    return Results.Json(new { ok = true, friendRequestsOpen = !current }, JsonContract.Options);
});

app.MapPost("/api/friends/toggle-friend-closed-party", (HttpContext context, FriendsService friendsService, IOptions<FriendsOptions> friendsOpt) =>
{
    if (!friendsOpt.Value.Enabled) return Results.Json(new { ok = false, message = "Friends system disabled." }, JsonContract.Options);
    var identity = ResolveIdentity(context);
    bool current = friendsService.IsPartyClosed(identity.AccountId);
    friendsService.SetClosedParty(identity.AccountId, !current);
    return Results.Json(new { ok = true, closedParty = !current }, JsonContract.Options);
});

// GET friends list
app.MapGet("/api/friends", (HttpContext context, FriendsService friendsService, IOptions<FriendsOptions> friendsOpt) =>
{
    if (!friendsOpt.Value.Enabled) return Results.Json(new { ok = false, message = "Friends system disabled." }, JsonContract.Options);
    var identity = ResolveIdentity(context);
    var friends = friendsService.GetFriends(identity.AccountId);
    return Results.Json(new { friends }, JsonContract.Options);
});

// GET/POST friends/requests returns actual pending friend requests
app.MapGet("/api/friends/requests", (HttpContext context, FriendsService friendsService, IOptions<FriendsOptions> friendsOpt) =>
{
    if (!friendsOpt.Value.Enabled) return Results.Json(new { ok = false, message = "Friends system disabled." }, JsonContract.Options);
    var identity = ResolveIdentity(context);
    var requests = friendsService.GetPendingRequests(identity.AccountId);
    return Results.Json(new
    {
        payload = new
        {
            friendRequests = requests.Select(r => new
            {
                accountId = r.FromAccountId,
                username = r.FromUsername,
                discriminator = r.FromDiscriminator,
                createdAt = r.CreatedUtc.ToString("O")
            }).ToArray()
        }
    }, JsonContract.Options);
});
app.MapPost("/api/friends/requests", (HttpContext context, FriendsService friendsService, IOptions<FriendsOptions> friendsOpt) =>
{
    if (!friendsOpt.Value.Enabled) return Results.Json(new { ok = false, message = "Friends system disabled." }, JsonContract.Options);
    var identity = ResolveIdentity(context);
    var requests = friendsService.GetPendingRequests(identity.AccountId);
    return Results.Json(new
    {
        payload = new
        {
            friendRequests = requests.Select(r => new
            {
                accountId = r.FromAccountId,
                username = r.FromUsername,
                discriminator = r.FromDiscriminator,
                createdAt = r.CreatedUtc.ToString("O")
            }).ToArray()
        }
    }, JsonContract.Options);
});

// Party invite endpoints
app.MapPost("/api/friends/invite", async (HttpContext context, FriendsService friendsService, LobbyService lobbyService, IOptions<FriendsOptions> friendsOpt) =>
{
    if (!friendsOpt.Value.Enabled) return Results.Json(new { ok = false, message = "Friends system disabled." }, JsonContract.Options);
    var identity = ResolveIdentity(context);
    string? toAccountId = await TryReadBodyFieldAsync(context, "accountId");
    string? lobbyId = await TryReadBodyFieldAsync(context, "lobbyId");
    if (string.IsNullOrWhiteSpace(toAccountId))
        return Results.Json(new { ok = false, message = "accountId is required." }, JsonContract.Options);
    if (string.IsNullOrWhiteSpace(lobbyId))
    {
        // Derive lobbyId from the sender's current lobby via presence tracking
        lobbyId = friendsService.GetPlayerLobbyId(identity.AccountId);
    }
    if (string.IsNullOrWhiteSpace(lobbyId))
        return Results.Json(new { ok = false, message = "lobbyId is required (you must be in a lobby)." }, JsonContract.Options);
    var result = friendsService.SendPartyInvite(identity.AccountId, identity.Username, lobbyId, toAccountId);
    return Results.Json(new { ok = result.Ok, message = result.Message }, JsonContract.Options);
});

app.MapGet("/api/friends/invites", (HttpContext context, FriendsService friendsService, IOptions<FriendsOptions> friendsOpt) =>
{
    if (!friendsOpt.Value.Enabled) return Results.Json(new { ok = false, message = "Friends system disabled." }, JsonContract.Options);
    var identity = ResolveIdentity(context);
    var invites = friendsService.GetPendingPartyInvites(identity.AccountId);
    return Results.Json(new { invites }, JsonContract.Options);
});

// Challenge / community challenge endpoints (used by community-challenge controller).
app.MapPost("/api/challenge/claim/drops", () => Results.Json(new { ok = true }, JsonContract.Options));
app.MapPost("/api/challenge/claim/games", () => Results.Json(new { ok = true }, JsonContract.Options));
app.MapPost("/api/challenge/claim/referral", () => Results.Json(new { ok = true }, JsonContract.Options));
app.MapPost("/api/challenge/signup", () => Results.Json(new { ok = true }, JsonContract.Options));

// Internal economy endpoints used by debug/admin builds; harmless no-ops here.
app.MapPost("/api/internal/gold", () => Results.Json(new { ok = true }, JsonContract.Options));
app.MapPost("/api/internal/xp", async (HttpContext context, EconomyService economyService) =>
{
    var identity = ResolveIdentity(context);
    string accountId = await TryReadBodyFieldAsync(context, "accountId") ?? identity.AccountId;
    string username = await TryReadBodyFieldAsync(context, "username") ?? identity.Username;
    int charId = await TryReadBodyIntAsync(context, "charId", "characterId") ?? CharacterCatalog.MedusaCharId;
    int xp = await TryReadBodyIntAsync(context, "xp", "amount", "xpAmount", "characterXp") ?? 0;

    if (!CharacterCatalog.IsKnownId(charId))
        return Results.Json(new { ok = false, message = $"Unknown character id {charId}." }, JsonContract.Options);
    if (xp <= 0)
        return Results.Json(new { ok = false, message = "xp must be positive." }, JsonContract.Options);

    CharacterMasteryProgress progress = economyService.RecordCharacterXp(accountId, username, charId, xp, "internal-xp");
    return Results.Json(new
    {
        ok = true,
        progress
    }, JsonContract.Options);
});
app.MapPost("/api/internal/reset-metagame", () => Results.Json(new { ok = true }, JsonContract.Options));

// Shop endpoints with real ShopService
// Asset index: maps asset IDs to readable names. Used by AMP UI to populate dropdowns.
// Returns { "300012": { "name": "Skin_Chuck_Default", "category": "skin", "index": 12 }, ... }
app.MapGet("/api/admin/asset-index", (HttpContext ctx, ServerAdminService adminService, IOptions<AdminOptions> adminOptions) =>
{
    if (!AdminAuth.IsAuthorized(ctx, adminOptions.Value)) return Results.Unauthorized();
    string indexPath = Path.Combine(AppContext.BaseDirectory, "assets", "asset-index.json");
    if (!File.Exists(indexPath))
    {
        // Legacy/local fallback: older workspaces generated this static asset reference under data/.
        string[] fallbackPaths =
        [
            Path.Combine(AppContext.BaseDirectory, "data", "asset-index.json"),
            Path.Combine(Directory.GetCurrentDirectory(), "assets", "asset-index.json"),
            Path.Combine(Directory.GetCurrentDirectory(), "data", "asset-index.json")
        ];
        string? altPath = fallbackPaths.FirstOrDefault(File.Exists);
        if (altPath is not null) indexPath = altPath;
        else return Results.Json(new { ok = false, message = "asset-index.json not found - run tools\\Build-AssetIndex.ps1" }, JsonContract.Options);
    }
    string content = File.ReadAllText(indexPath);
    adminService.Audit("api-admin-asset-index", AdminAuth.GetActor(ctx), null, $"path={indexPath}");
    return Results.Content(content, "application/json");
});

// Asset index filtered by category - convenient for AMP dropdowns
app.MapGet("/api/admin/asset-index/{category}", (string category, HttpContext ctx, ServerAdminService adminService, IOptions<AdminOptions> adminOptions) =>
{
    if (!AdminAuth.IsAuthorized(ctx, adminOptions.Value)) return Results.Unauthorized();
    string indexPath = Path.Combine(AppContext.BaseDirectory, "assets", "asset-index.json");
    if (!File.Exists(indexPath))
    {
        string[] fallbackPaths =
        [
            Path.Combine(AppContext.BaseDirectory, "data", "asset-index.json"),
            Path.Combine(Directory.GetCurrentDirectory(), "assets", "asset-index.json"),
            Path.Combine(Directory.GetCurrentDirectory(), "data", "asset-index.json")
        ];
        string? altPath = fallbackPaths.FirstOrDefault(File.Exists);
        if (altPath is not null) indexPath = altPath;
        else return Results.Json(new { ok = false, message = "asset-index.json not found" }, JsonContract.Options);
    }
    using JsonDocument doc = JsonDocument.Parse(File.ReadAllText(indexPath));
    var filtered = new Dictionary<string, object>();
    foreach (JsonProperty prop in doc.RootElement.EnumerateObject())
    {
        if (prop.Value.TryGetProperty("category", out JsonElement cat) && string.Equals(cat.GetString(), category, StringComparison.OrdinalIgnoreCase))
        {
            filtered[prop.Name] = new
            {
                name = prop.Value.GetProperty("name").GetString(),
                category = cat.GetString(),
                index = prop.Value.TryGetProperty("index", out JsonElement idx) ? idx.GetInt32() : -1
            };
        }
    }
    return Results.Json(filtered, JsonContract.Options);
});

// Bot config: GET current settings, POST to update both custom + matchmaking + active lobbies.
// Difficulty mapping (BAPBAP): 0=Easy, 1=Normal, 2=Medium, 3=Hard, 4=Expert
app.MapGet("/api/admin/bots", (HttpContext ctx, ServerAdminService adminService, IOptions<AdminOptions> adminOptions, IOptionsMonitor<CustomServerOptions> options, IOptionsMonitor<MatchmakingQueueOptions> queueOptions) =>
{
    if (!AdminAuth.IsAuthorized(ctx, adminOptions.Value)) return Results.Unauthorized();
    var opts = options.CurrentValue;
    var qOpts = queueOptions.CurrentValue;
    return Results.Json(new
    {
        customMatch = new
        {
            botCount = opts.MatchDefaults.BotTeams,
            botDifficulty = opts.MatchDefaults.BotDifficulty
        },
        matchmakingQueue = new
        {
            defaultBotCount = qOpts.DefaultBotCount,
            defaultBotDifficulty = qOpts.DefaultBotDifficulty
        },
        difficultyOptions = new[] { "0=Easy", "1=Normal", "2=Medium", "3=Hard", "4=Expert" }
    }, JsonContract.Options);
});

// POST /api/admin/bots { botCount: 4, botDifficulty: 2 } - applies to BOTH custom + matchmaking + active lobbies
app.MapPost("/api/admin/bots", async (HttpContext ctx, ServerAdminService adminService, IOptions<AdminOptions> adminOptions, IOptionsMonitor<CustomServerOptions> options, IOptionsMonitor<MatchmakingQueueOptions> queueOptions, LobbyService lobbyService) =>
{
    if (!AdminAuth.IsAuthorized(ctx, adminOptions.Value)) return Results.Unauthorized();
    string body = await new StreamReader(ctx.Request.Body).ReadToEndAsync();
    if (string.IsNullOrWhiteSpace(body)) body = "{}";
    using JsonDocument doc = JsonDocument.Parse(body);
    int botCount = doc.RootElement.TryGetProperty("botCount", out JsonElement bc) && bc.TryGetInt32(out int parsedCount) ? Math.Max(0, parsedCount) : -1;
    int botDifficulty = doc.RootElement.TryGetProperty("botDifficulty", out JsonElement bd) && bd.TryGetInt32(out int parsedDiff) ? Math.Max(0, Math.Min(4, parsedDiff)) : -1;
    if (botCount < 0 && botDifficulty < 0)
        return Results.Json(new { ok = false, message = "Provide at least 'botCount' or 'botDifficulty' in body." }, JsonContract.Options);

    var opts = options.CurrentValue;
    var qOpts = queueOptions.CurrentValue;
    if (botCount >= 0)
    {
        opts.MatchDefaults.BotTeams = botCount;
        qOpts.DefaultBotCount = botCount;
    }
    if (botDifficulty >= 0)
    {
        opts.MatchDefaults.BotDifficulty = botDifficulty;
        qOpts.DefaultBotDifficulty = botDifficulty;
    }
    int finalCount = botCount >= 0 ? botCount : opts.MatchDefaults.BotTeams;
    int finalDiff = botDifficulty >= 0 ? botDifficulty : opts.MatchDefaults.BotDifficulty;
    int lobbiesUpdated = lobbyService.SetActiveLobbyBots(finalCount, finalDiff);
    string[] diffNames = { "Easy", "Normal", "Medium", "Hard", "Expert" };
    adminService.Audit("api-admin-bots", AdminAuth.GetActor(ctx), null, $"botCount={finalCount} difficulty={finalDiff} lobbiesUpdated={lobbiesUpdated}");
    return Results.Json(new
    {
        ok = true,
        message = $"Bots updated: count={finalCount}, difficulty={finalDiff}({diffNames[finalDiff]}). {lobbiesUpdated} active lobbies updated.",
        botCount = finalCount,
        botDifficulty = finalDiff,
        difficultyName = diffNames[finalDiff],
        lobbiesUpdated
    }, JsonContract.Options);
});

// Modifier list - all 16 known game modifiers with enabled/disabled state.
// Used by AMP UI to render checkbox/dropdown.
app.MapGet("/api/admin/modifiers", (HttpContext ctx, ServerAdminService adminService, IOptions<AdminOptions> adminOptions, IOptionsMonitor<CustomServerOptions> options) =>
{
    if (!AdminAuth.IsAuthorized(ctx, adminOptions.Value)) return Results.Unauthorized();
    var opts = options.CurrentValue;
    var current = new HashSet<int>(opts.MatchDefaults.GameModifierIds);
    var list = GameModifierCatalog.KnownGameModifiers.Select(m => new { id = m.Id, name = m.Name, display = m.Display, enabled = current.Contains(m.Id) }).ToArray();
    return Results.Json(new { count = list.Length, enabled = current.Count, modifiers = list }, JsonContract.Options);
});

// Set active modifiers via simple REST: POST /api/admin/modifiers { ids: [4, 8, 9] }
// This also applies the modifiers to ALL currently active lobbies, so the next match
// they trigger will use these modifiers. (Without this, lobby's CustomSettings stays
// at its prior value and modifiers don't take effect until the lobby is recreated.)
app.MapPost("/api/admin/modifiers", async (HttpContext ctx, ServerAdminService adminService, IOptions<AdminOptions> adminOptions, IOptionsMonitor<CustomServerOptions> options, LobbyService lobbyService) =>
{
    if (!AdminAuth.IsAuthorized(ctx, adminOptions.Value)) return Results.Unauthorized();
    string body = await new StreamReader(ctx.Request.Body).ReadToEndAsync();
    if (string.IsNullOrWhiteSpace(body)) body = "{}";
    using JsonDocument doc = JsonDocument.Parse(body);
    var idsList = new List<int>();
    if (doc.RootElement.TryGetProperty("ids", out JsonElement idsElement) && idsElement.ValueKind == JsonValueKind.Array)
    {
        foreach (var el in idsElement.EnumerateArray())
        {
            if (el.ValueKind == JsonValueKind.Number && el.TryGetInt32(out int id) && id >= 0 && id < GameModifierCatalog.KnownGameModifiers.Length)
                idsList.Add(id);
        }
    }
    var opts = options.CurrentValue;
    int[] newIds = idsList.Distinct().ToArray();
    opts.MatchDefaults.GameModifierIds = newIds;
    int lobbiesUpdated = lobbyService.SetActiveLobbyModifiers(newIds);
    var names = newIds.Select(i => GameModifierCatalog.KnownGameModifiers[i].Name).ToArray();
    adminService.Audit("api-admin-modifiers", AdminAuth.GetActor(ctx), null, $"modifierIds=[{string.Join(",", newIds)}] lobbiesUpdated={lobbiesUpdated}");
    return Results.Json(new { ok = true, message = $"Set {newIds.Length} modifier(s) active. {lobbiesUpdated} lobbies updated.", modifierIds = newIds, names, lobbiesUpdated }, JsonContract.Options);
});

app.MapGet("/api/shop", (HttpContext ctx, ShopService shopService, EconomyService eco) => {
    var id = ResolveIdentity(ctx);
    return Results.Json(shopService.BuildShopResponse(id.AccountId, eco), JsonContract.Options);
});
app.MapPost("/api/shop", (HttpContext ctx, ShopService shopService, EconomyService eco) => {
    var id = ResolveIdentity(ctx);
    return Results.Json(shopService.BuildShopResponse(id.AccountId, eco), JsonContract.Options);
});

// Matchmaking Queue endpoints
app.MapPost("/api/queue/join", async (HttpContext context, MatchmakingQueueService queueService, RankedService rankedService, IOptions<CustomServerOptions> serverOptions) =>
{
    if (serverOptions.Value.MatchmakingPolicy == MatchmakingPolicy.CustomOnly)
    {
        return Results.Json(new { ok = false, message = "Matchmaking is disabled on this server. Use a custom match lobby instead.", position = 0, secondsRemaining = 0 }, JsonContract.Options);
    }

    var identity = ResolveIdentity(context);
    var ranked = rankedService.GetOrCreatePlayer(identity.AccountId, identity.Username);
    int charId = 1;
    string? requestedCharId = await TryReadBodyFieldAsync(context, "charId");
    if (!string.IsNullOrWhiteSpace(requestedCharId) && int.TryParse(requestedCharId, out int parsedCharId))
    {
        if (!CharacterCatalog.IsKnownId(parsedCharId))
        {
            return Results.Json(new { ok = false, message = $"Unknown character id {parsedCharId}.", position = 0, secondsRemaining = 0 }, JsonContract.Options);
        }

        charId = parsedCharId;
    }

    var result = queueService.JoinQueue(identity.AccountId, identity.Username, identity.Discriminator, charId, ranked.Points);
    return Results.Json(new { ok = result.Ok, message = result.Message, position = result.QueuePosition, secondsRemaining = result.SecondsRemaining }, JsonContract.Options);
});

app.MapPost("/api/queue/leave", (HttpContext context, MatchmakingQueueService queueService, ILogger<Program> logger) =>
{
    var identity = ResolveIdentity(context);
    bool left = queueService.LeaveQueue(identity.AccountId);
    logger.LogInformation("HTTP /api/queue/leave from {AccountId}: removed={Removed}", identity.AccountId, left);
    return Results.Json(new { ok = left, message = left ? "Left the queue." : "You were not in the queue." }, JsonContract.Options);
});

// Alias: BAPBAP and any frontend variants that send "cancel" instead of "leave" land here.
app.MapPost("/api/queue/cancel", (HttpContext context, MatchmakingQueueService queueService, ILogger<Program> logger) =>
{
    var identity = ResolveIdentity(context);
    bool left = queueService.LeaveQueue(identity.AccountId);
    logger.LogInformation("HTTP /api/queue/cancel from {AccountId}: removed={Removed}", identity.AccountId, left);
    return Results.Json(new { ok = true, wasInQueue = left, message = left ? "Cancelled queue." : "You were not in the queue." }, JsonContract.Options);
});

// REST-style alias.
app.MapDelete("/api/queue", (HttpContext context, MatchmakingQueueService queueService, ILogger<Program> logger) =>
{
    var identity = ResolveIdentity(context);
    bool left = queueService.LeaveQueue(identity.AccountId);
    logger.LogInformation("HTTP DELETE /api/queue from {AccountId}: removed={Removed}", identity.AccountId, left);
    return Results.Json(new { ok = true, wasInQueue = left }, JsonContract.Options);
});

// GET alias for clients that issue a navigation/redirect on cancel.
app.MapGet("/api/queue/cancel", (HttpContext context, MatchmakingQueueService queueService, ILogger<Program> logger) =>
{
    var identity = ResolveIdentity(context);
    bool left = queueService.LeaveQueue(identity.AccountId);
    logger.LogInformation("HTTP GET /api/queue/cancel from {AccountId}: removed={Removed}", identity.AccountId, left);
    return Results.Json(new { ok = true, wasInQueue = left }, JsonContract.Options);
});

app.MapGet("/api/queue/status", (MatchmakingQueueService queueService) =>
{
    var status = queueService.GetStatus();
    return Results.Json(status, JsonContract.Options);
});

// Match History endpoints
app.MapGet("/api/matches/history", (MatchHistoryService historyService, int? count) =>
{
    var matches = historyService.GetRecentMatches(count ?? 20);
    return Results.Json(new { matches }, JsonContract.Options);
});

app.MapGet("/api/matches/history/{gameId}", (string gameId, MatchHistoryService historyService) =>
{
    var match = historyService.GetMatch(gameId);
    if (match is null) return Results.NotFound(new { message = "Match not found." });
    return Results.Json(match, JsonContract.Options);
});

app.MapGet("/api/matches/player/{accountId}", (string accountId, MatchHistoryService historyService, int? count) =>
{
    var matches = historyService.GetPlayerMatches(accountId, count ?? 20);
    return Results.Json(new { matches }, JsonContract.Options);
});

// Ranked/Leaderboard endpoints with real data
app.MapGet("/api/ranked/self", (HttpContext context, RankedService rankedService) =>
{
    var identity = ResolveIdentity(context);
    return Results.Json(rankedService.BuildLeaderboardSelfResponse(identity.AccountId, 0), JsonContract.Options);
});

app.MapGet("/api/ranked/leaderboard", (RankedService rankedService, int? page, int? mode) =>
{
    return Results.Json(rankedService.BuildLeaderboardResponse(mode ?? 0, page ?? 0), JsonContract.Options);
});

MapMetagameBootstrapEndpoints(app);

app.MapPost("/api/internal/game-ping", (GamePing ping, LobbyService lobbyService) =>
{
    lobbyService.RecordGamePing(ping);
    return Results.Ok(new { ok = true });
});
app.MapPost("/game-ping", (GamePing ping, LobbyService lobbyService) =>
{
    lobbyService.RecordGamePing(ping);
    return Results.Ok(new { ok = true });
});

app.MapPost("/api/internal/game-ended", (GameEndedPayload payload, LobbyService lobbyService) =>
{
    lobbyService.RecordGameEnded(payload);
    return Results.Ok(new { ok = true });
});
app.MapPost("/api/internal/team-ended", (JsonElement payload) =>
{
    return Results.Ok(new { ok = true });
});
app.MapPost("/game-ended", (GameEndedPayload payload, LobbyService lobbyService) =>
{
    lobbyService.RecordGameEnded(payload);
    return Results.Ok(new { ok = true });
});
app.MapPost("/team-ended", (JsonElement payload) =>
{
    return Results.Ok(new { ok = true });
});

app.MapGet("/admin/state", (HttpContext context, ServerAdminService adminService, IOptions<AdminOptions> adminOptions) =>
{
    if (!AdminAuth.IsAuthorized(context, adminOptions.Value))
    {
        return Results.Unauthorized();
    }

    return Results.Json(adminService.GetSnapshot(), JsonContract.Options);
});

app.MapGet("/admin/logs/audit", (HttpContext context, ServerAdminService adminService, IOptions<AdminOptions> adminOptions, int? tail) =>
{
    if (!AdminAuth.IsAuthorized(context, adminOptions.Value))
    {
        return Results.Unauthorized();
    }

    return Results.Json(new { lines = adminService.ReadAuditTail(tail ?? 200) }, JsonContract.Options);
});

app.MapGet("/admin/lobbies", (HttpContext context, LobbyService lobbyService, IOptions<AdminOptions> adminOptions) =>
{
    if (!AdminAuth.IsAuthorized(context, adminOptions.Value))
    {
        return Results.Unauthorized();
    }

    return Results.Json(lobbyService.GetLobbySnapshots(), JsonContract.Options);
});

app.MapGet("/admin/matches", (HttpContext context, LobbyService lobbyService, IOptions<AdminOptions> adminOptions) =>
{
    if (!AdminAuth.IsAuthorized(context, adminOptions.Value))
    {
        return Results.Unauthorized();
    }

    return Results.Json(lobbyService.GetMatchSnapshots(), JsonContract.Options);
});

app.MapPost("/admin/commands", async (
    HttpContext context,
    AdminCommandRequest command,
    ServerAdminService adminService,
    LobbyService lobbyService,
    IOptions<AdminOptions> adminOptions,
    CancellationToken cancellationToken) =>
{
    if (!AdminAuth.IsAuthorized(context, adminOptions.Value))
    {
        return Results.Unauthorized();
    }

    string actor = AdminAuth.GetActor(context);
    string normalizedCommand = (command.Command ?? "").Trim().Replace('_', '-').ToLowerInvariant();
    AdminCommandResult result = normalizedCommand switch
    {
        "grant-admin" or "set-admin" or "add-admin" => ToCommandResult(normalizedCommand, adminService.AddAdmin(command.AccountId, actor)),
        "revoke-admin" or "remove-admin" => ToCommandResult(normalizedCommand, adminService.RemoveAdmin(command.AccountId, actor)),
        "ban" or "ban-account" => await BanAndKickAsync(normalizedCommand, command, actor, adminService, lobbyService, cancellationToken),
        "unban" or "unban-account" => ToCommandResult(normalizedCommand, adminService.Unban(command.AccountId, actor)),
        "kick" or "kick-player" => await KickAsync(normalizedCommand, command, actor, adminService, lobbyService, cancellationToken),
        "stop-match" => StopMatch(normalizedCommand, command, actor, adminService, lobbyService),
        "set-lobby-settings" => await SetLobbySettingsAsync(normalizedCommand, command, actor, adminService, lobbyService, cancellationToken),
        "list-lobbies" => new AdminCommandResult(true, normalizedCommand, "Lobby snapshot returned.", lobbyService.GetLobbySnapshots()),
        "list-matches" => new AdminCommandResult(true, normalizedCommand, "Match snapshot returned.", lobbyService.GetMatchSnapshots()),
        "give-gold" => AdminGiveGold(normalizedCommand, command, actor, adminService, app.Services.GetRequiredService<EconomyService>()),
        "set-gold" => AdminSetGold(normalizedCommand, command, actor, adminService, app.Services.GetRequiredService<EconomyService>()),
        "add-shop-item" => AdminAddShopItem(normalizedCommand, command, actor, adminService, app.Services.GetRequiredService<ShopService>()),
        "add-shop-freebie" => AdminAddShopFreebie(normalizedCommand, command, actor, adminService, app.Services.GetRequiredService<ShopService>()),
        "remove-shop-item" => AdminRemoveShopItem(normalizedCommand, command, actor, adminService, app.Services.GetRequiredService<ShopService>()),
        "clear-shop" => AdminClearShop(normalizedCommand, actor, adminService, app.Services.GetRequiredService<ShopService>()),
        "set-modifiers" => AdminSetModifiers(normalizedCommand, command, actor, adminService, app.Services.GetRequiredService<IOptionsMonitor<CustomServerOptions>>()),
        "list-modifiers" => AdminListModifiers(normalizedCommand, app.Services.GetRequiredService<IOptionsMonitor<CustomServerOptions>>()),
        "grant-asset" => AdminGrantAsset(normalizedCommand, command, actor, adminService, app.Services.GetRequiredService<EconomyService>()),
        "revoke-asset" => AdminRevokeAsset(normalizedCommand, command, actor, adminService, app.Services.GetRequiredService<EconomyService>()),
        "ranked-reset" => AdminRankedReset(normalizedCommand, command, actor, adminService, app.Services.GetRequiredService<RankedService>()),
        "ranked-set-points" => AdminRankedSetPoints(normalizedCommand, command, actor, adminService, app.Services.GetRequiredService<RankedService>()),
        "match-history" => new AdminCommandResult(true, normalizedCommand, "Recent matches.", app.Services.GetRequiredService<MatchHistoryService>().GetRecentMatches(20)),
        "queue-status" => new AdminCommandResult(true, normalizedCommand, "Queue status.", app.Services.GetRequiredService<MatchmakingQueueService>().GetStatus()),
        "queue-clear" or "clear-queue" => AdminClearQueue(normalizedCommand, actor, adminService, app.Services.GetRequiredService<MatchmakingQueueService>(), app.Services.GetRequiredService<ILogger<Program>>()),
        "queue-leave" or "queue-cancel" or "queue-kick" => AdminQueueLeave(normalizedCommand, command, actor, adminService, app.Services.GetRequiredService<MatchmakingQueueService>(), app.Services.GetRequiredService<ILogger<Program>>()),
        "economy-leaderboard" => new AdminCommandResult(true, normalizedCommand, "Economy leaderboard.", app.Services.GetRequiredService<EconomyService>().GetLeaderboard(20)),
        _ => new AdminCommandResult(false, normalizedCommand, $"Unknown admin command '{command.Command}'.")
    };

    return result.Ok ? Results.Json(result, JsonContract.Options) : Results.BadRequest(result);
});

app.Map("/ws", async (HttpContext context, LobbyService lobbyService) =>
{
    if (!context.WebSockets.IsWebSocketRequest)
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        await context.Response.WriteAsync("Expected a WebSocket request.");
        return;
    }

    using WebSocket socket = await context.WebSockets.AcceptWebSocketAsync();
    await lobbyService.HandleSocketAsync(socket, context, context.RequestAborted);
});

app.Run();

static void MapSocketDiscovery(WebApplication app, string route)
{
    app.MapGet(route, (HttpContext context, LobbyService lobbyService) =>
        Results.Json(new LobbySocketResponse(lobbyService.BuildSocketUrl(context)), JsonContract.Options));
    app.MapPost(route, (HttpContext context, LobbyService lobbyService) =>
        Results.Json(new LobbySocketResponse(lobbyService.BuildSocketUrl(context)), JsonContract.Options));
}

static void MapMetagameBootstrapEndpoints(WebApplication app)
{
    MapClientJson(app, "/api/challenge/preview", () => new
    {
        prizePool = 0,
        numSignUps = 0,
        numSignUpsNeeded = 0
    });
    MapClientJson(app, "/api/iap/listing", () => new
    {
        iapListings = Array.Empty<object>()
    });
    // /api/shop is now handled by ShopService endpoint registered before MapMetagameBootstrapEndpoints
    MapClientJson(app, "/api/daily", () => new
    {
        timestamp = CurrentClientTimestamp(),
        progress = 0,
        max = 1
    });
    MapClientJson(app, "/api/profile", () => new
    {
        rankStats = Array.Empty<object>(),
        stats = Array.Empty<object>(),
        history = Array.Empty<object>()
    });
    MapClientJson(app, "/api/profile/levels", MinimalPassResponse);
    MapClientJson(app, "/api/chars/pass", MinimalPassResponse);
    MapClientJson(app, "/api/chars/mastery/preview", () => new
    {
        // The native lobby preview handler indexes into internal mastery UI
        // arrays that are not safe for synthetic/custom pass data. Keep this
        // endpoint intentionally empty; explicit progress endpoints still
        // expose character mastery state for tools and future custom UI work.
        passes = Array.Empty<object>()
    });
    MapClientJson(app, "/api/chars/listing", () => new
    {
        charListings = PlayableCharacterIds()
            .Select(MinimalCharacterListing)
            .ToArray()
    });
    MapClientJson(app, "/api/leaderboards/preview", () => new
    {
        gameModes = new[]
        {
            new
            {
                gameModeId = 1,
                showRanks = false,
                showPoints = false,
                showCharacters = true
            }
        }
    });
    MapClientJson(app, "/api/pinger", () => new
    {
        pingers = new[]
        {
            new
            {
                pingerUrl = "ws://127.0.0.1:5163/ws",
                regionId = "custom"
            }
        }
    });
    MapClientJson(app, "/api/leaderboards/all/{mode:int}", EmptyLeaderboardPage);
    MapClientJson(app, "/api/leaderboards/friends/{mode:int}", EmptyLeaderboardPage);
    MapClientJson(app, "/api/leaderboards/self/{mode:int}", () => new
    {
        self = new
        {
            username = "Custom",
            level = 1,
            bannerId = 0,
            wins = 0,
            kills = 0,
            rank = 0,
            position = 0,
            isSelf = true
        },
        top = Array.Empty<object>(),
        isEnd = true,
        pageOffset = 0
    });
}

static void MapClientJson(WebApplication app, string route, Func<object> responseFactory)
{
    app.MapGet(route, () => Results.Json(responseFactory(), JsonContract.Options));
    app.MapPost(route, () => Results.Json(responseFactory(), JsonContract.Options));
}

static object MinimalPassResponse()
{
    return new
    {
        passId = 1,
        passLevels = Enumerable.Range(1, 100)
            .Select(level => MinimalPassLevel(level, (level - 1) * 100))
            .ToArray()
    };
}

static object MinimalCharMasteryPass(int charId, CharacterMasteryProgress? progress = null)
{
    progress ??= new CharacterMasteryProgress
    {
        CharId = charId,
        CurrentLevel = 1,
        CurrentXpNeeded = 100,
        UpdatedUtc = DateTimeOffset.UtcNow
    };

    var passLevels = Enumerable.Range(1, 100)
        .Select(level => MinimalPassLevel(level, (level - 1) * 100, $"custom-mastery-{charId}-{level}"))
        .ToArray();

    return new
    {
        passId = NativeCharacterMasteryPassId(charId),
        charId,
        xp = progress.Xp,
        claimedLevels = progress.ClaimedLevels,
        unlockedBadgeAssetIds = progress.UnlockedBadgeAssetIds,
        currentLevel = progress.CurrentLevel,
        currentXp = progress.CurrentXp,
        currentXpNeeded = progress.CurrentXpNeeded,
        prevCurrentLevel = progress.PrevCurrentLevel,
        prevCurrentXp = progress.PrevCurrentXp,
        updatedUtc = progress.UpdatedUtc,
        passLevels,
        masteryPass = new
        {
            passId = NativeCharacterMasteryPassId(charId),
            passLevels
        }
    };
}

static int NativeCharacterMasteryPassId(int charId)
{
    return charId + 1;
}

static object MinimalCharacterListing(int charId)
{
    return new
    {
        listingId = $"custom-char-{charId}",
        charId,
        levelRequirement = 0,
        costs = Array.Empty<object>(),
        rewards = Array.Empty<object>(),
        purchases = 1
    };
}

static object MinimalPassLevel(int level, int xpNeeded, string? listingId = null)
{
    return new
    {
        level,
        xpNeeded,
        listings = string.IsNullOrWhiteSpace(listingId)
            ? Array.Empty<object>()
            : new object[]
            {
                new
                {
                    listingId,
                    costs = Array.Empty<object>(),
                    rewards = Array.Empty<object>(),
                    requirements = Array.Empty<object>(),
                    purchases = 1
                }
            }
    };
}

static int[] PlayableCharacterIds()
{
    return CharacterCatalog.AllIds;
}

static object EmptyLeaderboardPage()
{
    return new
    {
        top = Array.Empty<object>(),
        isEnd = true,
        pageOffset = 0
    };
}

static string CurrentClientTimestamp()
{
    return DateTimeOffset.UtcNow.ToString("O");
}

static IResult GetInternalServers(LobbyService lobbyService)
{
    return Results.Json(new InternalServersResponse(lobbyService.GetInternalServers()), JsonContract.Options);
}

static IResult BuildLoadResult(HttpContext context, ServerAdminService adminService, IOptions<UnlockOptions> unlockOptions)
{
    LoadResponse response = BuildLoadResponse(context, adminService, unlockOptions.Value);
    AttachSessionCookie(context, response.AccountId);
    return Results.Json(response, JsonContract.Options);
}

static IResult BuildCompleteResult(HttpContext context, ServerAdminService adminService, IOptions<UnlockOptions> unlockOptions)
{
    LoadResponse response = BuildLoadResponse(context, adminService, unlockOptions.Value);
    AttachSessionCookie(context, response.AccountId);
    return Results.Json(new
    {
        response.AccountId,
        response.Username,
        response.Discriminator,
        response.Level,
        response.IsAdmin,
        response.IsCompleted,
        response.IsGuest,
        response.Email
    }, JsonContract.Options);
}

static IResult LoadoutEquipResult(HttpContext context, ServerAdminService adminService, IOptions<UnlockOptions> unlockOptions)
{
    // The client sends EquipBannerBody / EquipSkinBody. On custom servers we
    // simply return the same load shape so the client treats the equip as
    // applied. The body itself does not need to be persisted - the lobby
    // and match flows already accept any equipped skin.
    LoadResponse response = BuildLoadResponse(context, adminService, unlockOptions.Value);
    return Results.Json(response, JsonContract.Options);
}

static void AttachSessionCookie(HttpContext context, string accountId)
{
    string normalized = string.IsNullOrWhiteSpace(accountId)
        ? $"custom-{Math.Abs(context.Connection.RemotePort):0000}"
        : accountId.Trim();

    context.Response.Cookies.Append(
        "sid",
        $"bapcustom-{normalized}",
        new CookieOptions
        {
            HttpOnly = false,
            IsEssential = true,
            SameSite = SameSiteMode.Lax,
            Path = "/"
        });
}

static ClientIdentity ResolveIdentity(HttpContext context)
{
    return ClientIdentityResolver.Resolve(
        context,
        $"custom-{Math.Abs(context.Connection.RemotePort):0000}",
        $"Custom{Math.Abs(context.Connection.RemotePort):0000}",
        context.Connection.RemotePort % 10000);
}

static async Task<string?> TryReadBodyFieldAsync(HttpContext context, string fieldName)
{
    try
    {
        context.Request.EnableBuffering();
        context.Request.Body.Position = 0;
        using var reader = new StreamReader(context.Request.Body, leaveOpen: true);
        string body = await reader.ReadToEndAsync();
        context.Request.Body.Position = 0;
        if (string.IsNullOrWhiteSpace(body)) return context.Request.Query[fieldName].FirstOrDefault();
        using JsonDocument doc = JsonDocument.Parse(body);
        if (doc.RootElement.TryGetProperty(fieldName, out JsonElement element))
            return element.ValueKind == JsonValueKind.String ? element.GetString() : element.ToString();
        // Try camelCase
        string camelCase = char.ToLowerInvariant(fieldName[0]) + fieldName[1..];
        if (doc.RootElement.TryGetProperty(camelCase, out element))
            return element.ValueKind == JsonValueKind.String ? element.GetString() : element.ToString();
    }
    catch (Exception)
    {
        // Body was malformed, already consumed, or stream is not seekable; fall through to query string
    }
    return context.Request.Query[fieldName].FirstOrDefault();
}

static async Task<int?> TryReadBodyIntAsync(HttpContext context, params string[] fieldNames)
{
    foreach (string fieldName in fieldNames)
    {
        string? value = await TryReadBodyFieldAsync(context, fieldName);
        if (int.TryParse(value, out int parsed))
        {
            return parsed;
        }
    }

    return null;
}

static LoadResponse BuildLoadResponse(HttpContext context, ServerAdminService adminService, UnlockOptions unlockOptions)
{
    string suffix = Math.Abs(context.Connection.RemotePort).ToString("0000");
    ClientIdentity identity = ClientIdentityResolver.Resolve(
        context,
        $"custom-{suffix}",
        $"Custom{suffix}",
        context.Connection.RemotePort % 10000);
    bool isBanned = adminService.IsBanned(identity.AccountId);

    LoadAsset[] ownedAssets = BuildOwnedAssets(unlockOptions);

    // Merge economy-owned assets
    var economyService = context.RequestServices.GetService<EconomyService>();
    if (economyService != null)
    {
        economyService.GetOrCreatePlayer(identity.AccountId, identity.Username);
        int[] economyAssets = economyService.GetOwnedAssets(identity.AccountId);
        if (economyAssets.Length > 0)
        {
            var merged = ownedAssets.ToList();
            foreach (int ecoAssetId in economyAssets)
            {
                if (merged.All(a => a.AssetId != ecoAssetId))
                    merged.Add(new LoadAsset { AssetId = ecoAssetId, Balance = 1 });
            }
            ownedAssets = merged.ToArray();
        }

        // Update gold balance in the assets array
        int gold = economyService.GetGold(identity.AccountId);
        var goldAsset = ownedAssets.FirstOrDefault(a => a.AssetId == unlockOptions.GoldAssetId);
        if (goldAsset != null)
            goldAsset.Balance = gold;
        else
            // If gold asset isn't in the owned list yet, add it explicitly
            ownedAssets = ownedAssets.Concat(new[] { new LoadAsset { AssetId = unlockOptions.GoldAssetId, Balance = gold } }).ToArray();
    }

    int[] equippedSkins = BuildDefaultLoadoutSkins(unlockOptions);

    return new LoadResponse
    {
        AccountId = identity.AccountId,
        Username = identity.Username,
        Discriminator = identity.Discriminator,
        IsGuest = false,
        Level = 50,
        IsAdmin = !isBanned && adminService.IsAdmin(identity.AccountId),
        IsCompleted = !isBanned,
        Email = "",
        Assets = ownedAssets,
        InviteCode = new LoadInviteCode
        {
            Code = "CUSTOM",
            UsesLeft = 999,
            UsesTotal = 999
        },
        Loadout = new Loadout
        {
            BannerId = 0,
            Skins = equippedSkins
        },
        TotalGames = 0,
        FriendRequestsOpen = true,
        // Keep /api/load consistent with /api/chars/listing and /api/server-config.
        // An empty roster here makes the native client fall back to its default
        // lobby character state, which breaks the Characters tab and causes
        // queue/match selection to drift back to Kitsu/charId=0.
        AvailableCharacters = PlayableCharacterIds(),
        Blocked = isBanned,
        CreatorCode = "",
        CreatorName = ""
    };
}

static LoadAsset[] BuildOwnedAssets(UnlockOptions options)
{
    var assets = new List<LoadAsset>(1024);

    int[] defaultSkins = CharacterCatalog.DefaultSkinAssetIds;

    if (!options.UnlockEverything)
    {
        // Even when not unlocking everything, ALWAYS grant the character Default skins.
        // Without these owned, BAPBAP's skin/locker UI doesn't render the skin tab and char-customize
        // doesn't show skin selection.
        foreach (int defaultSkin in defaultSkins.Distinct())
        {
            assets.Add(new LoadAsset { AssetId = defaultSkin, Balance = 1 });
        }
        return assets.ToArray();
    }

    AppendRange(assets, options.SkinAssetIdStart, options.SkinAssetIdEnd, balance: 1);

    // CRITICAL: Filter out empty skin asset IDs (300001, 300004, 300006) which are empty slots
    // in SkinData and trigger client-side NullReferenceExceptions in ShopController/Locker UI.
    assets.RemoveAll(a => a.AssetId == 300001 || a.AssetId == 300004 || a.AssetId == 300006);

    AppendRange(assets, options.EmoteAssetIdStart, options.EmoteAssetIdEnd, balance: 1);
    AppendRange(assets, options.BannerAssetIdStart, options.BannerAssetIdEnd, balance: 1);
    AppendRange(assets, options.MasteryBadgeAssetIdStart, options.MasteryBadgeAssetIdEnd, balance: 1);
    AppendRange(assets, options.TombstoneAssetIdStart, options.TombstoneAssetIdEnd, balance: 1);

    foreach (int currencyAssetId in options.CurrencyAssetIds.Distinct())
    {
        assets.Add(new LoadAsset { AssetId = currencyAssetId, Balance = options.CurrencyBalance });
    }

    // Override charTokens balance specifically (default 0 since chars are already unlocked).
    var charTokenAsset = assets.FirstOrDefault(a => a.AssetId == options.CharTokenAssetId);
    if (charTokenAsset != null)
    {
        charTokenAsset.Balance = options.CharTokenBalance;
    }
    else if (options.CharTokenAssetId > 0)
    {
        // CharTokens asset wasn't in the currency list; add it explicitly.
        assets.Add(new LoadAsset { AssetId = options.CharTokenAssetId, Balance = options.CharTokenBalance });
    }

    foreach (int extra in options.ExtraOwnedAssetIds.Distinct())
    {
        if (assets.All(a => a.AssetId != extra))
        {
            assets.Add(new LoadAsset { AssetId = extra, Balance = 1 });
        }
    }

    return assets.ToArray();
}

static void AppendRange(List<LoadAsset> assets, int start, int end, int balance)
{
    if (end < start)
    {
        return;
    }

    for (int id = start; id <= end; id++)
    {
        assets.Add(new LoadAsset { AssetId = id, Balance = balance });
    }
}

static int[] BuildDefaultLoadoutSkins(UnlockOptions options)
{
    // Always build a properly-sized skins[] array indexed by characterId,
    // because BAPBAP's UI assumes skins[charId] is accessible for every char.
    // Empty array = client crashes when trying to render skin slot.
    int[] characterIds = PlayableCharacterIds();
    int maxCharacterId = characterIds.Length == 0 ? 0 : characterIds.Max();
    int[] skins = new int[Math.Max(1, maxCharacterId + 1)];

    // Pre-equip per-char Default skin so the UI sees real skin IDs and renders the locker
    // skin tab + character customize. Default skins live at their correct character offsets.
    foreach (int charId in characterIds)
    {
        if (charId < 0 || charId >= skins.Length) continue;
        skins[charId] = CharacterCatalog.GetDefaultSkinAssetId(charId);
    }
    return skins;
}

static AdminCommandResult ToCommandResult(string command, AdminMutationResult result)
{
    return new AdminCommandResult(result.Ok, command, result.Message);
}

static int[] ParseIntCsv(string? value)
{
    if (string.IsNullOrWhiteSpace(value))
    {
        return [];
    }

    return value
        .Split([',', ';', ' ', '\r', '\n'], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
        .Select(item => int.TryParse(item, out int parsed) ? parsed : (int?)null)
        .Where(item => item.HasValue)
        .Select(item => item!.Value)
        .ToArray();
}

static DimensionData[] ParseDimensionDataJson(string? value)
{
    if (string.IsNullOrWhiteSpace(value))
    {
        return [];
    }

    try
    {
        return JsonSerializer.Deserialize<DimensionData[]>(value, JsonContract.Options) ?? [];
    }
    catch
    {
        return [];
    }
}

static MapMappingEntry[] ParseMapMappingJson(string? value)
{
    if (string.IsNullOrWhiteSpace(value))
    {
        return [];
    }

    try
    {
        return JsonSerializer.Deserialize<MapMappingEntry[]>(value, JsonContract.Options) ?? [];
    }
    catch
    {
        return [];
    }
}

static async Task<AdminCommandResult> BanAndKickAsync(
    string command,
    AdminCommandRequest request,
    string actor,
    ServerAdminService adminService,
    LobbyService lobbyService,
    CancellationToken cancellationToken)
{
    AdminMutationResult mutation = adminService.Ban(request.AccountId, request.Reason, request.ExpiresUtc, actor);
    if (!mutation.Ok)
    {
        return ToCommandResult(command, mutation);
    }

    bool kicked = await lobbyService.KickAccountAsync(request.AccountId, request.Reason ?? "Banned.", cancellationToken);
    return new AdminCommandResult(true, command, kicked ? "Account banned and active connection kicked." : "Account banned.");
}

static async Task<AdminCommandResult> KickAsync(
    string command,
    AdminCommandRequest request,
    string actor,
    ServerAdminService adminService,
    LobbyService lobbyService,
    CancellationToken cancellationToken)
{
    if (string.IsNullOrWhiteSpace(request.AccountId))
    {
        return new AdminCommandResult(false, command, "AccountId is required.");
    }

    bool kicked = await lobbyService.KickAccountAsync(request.AccountId, request.Reason ?? "Kicked by server admin.", cancellationToken);
    adminService.Audit(kicked ? "account-kicked" : "account-kick-miss", actor, request.AccountId, request.Reason);
    return new AdminCommandResult(kicked, command, kicked ? "Account kicked." : "No active connection matched AccountId.");
}

static AdminCommandResult StopMatch(
    string command,
    AdminCommandRequest request,
    string actor,
    ServerAdminService adminService,
    LobbyService lobbyService)
{
    if (string.IsNullOrWhiteSpace(request.GameId))
    {
        return new AdminCommandResult(false, command, "GameId is required.");
    }

    bool stopped = lobbyService.StopMatch(request.GameId);
    adminService.Audit(stopped ? "match-stopped" : "match-stop-miss", actor, null, request.GameId);
    return new AdminCommandResult(stopped, command, stopped ? "Match process stopped." : "No active match matched GameId.");
}

static async Task<AdminCommandResult> SetLobbySettingsAsync(
    string command,
    AdminCommandRequest request,
    string actor,
    ServerAdminService adminService,
    LobbyService lobbyService,
    CancellationToken cancellationToken)
{
    if (string.IsNullOrWhiteSpace(request.LobbyId))
    {
        return new AdminCommandResult(false, command, "LobbyId is required.");
    }

    if (request.Settings is null)
    {
        return new AdminCommandResult(false, command, "Settings are required.");
    }

    bool updated = await lobbyService.SetLobbySettingsAsync(request.LobbyId, request.Settings, cancellationToken);
    adminService.Audit(updated ? "lobby-settings-updated" : "lobby-settings-miss", actor, null, request.LobbyId);
    return new AdminCommandResult(updated, command, updated ? "Lobby settings updated and broadcast." : "No lobby matched LobbyId.");
}

static AdminCommandResult AdminGiveGold(string command, AdminCommandRequest request, string actor, ServerAdminService adminService, EconomyService economyService)
{
    if (string.IsNullOrWhiteSpace(request.AccountId)) return new AdminCommandResult(false, command, "AccountId required.");
    if (!int.TryParse(request.Reason, out int amount) || amount == 0) return new AdminCommandResult(false, command, "Set Reason to the gold amount (e.g. '500').");
    economyService.GetOrCreatePlayer(request.AccountId, "");
    var result = economyService.AdminGiveGold(request.AccountId, amount, actor);
    adminService.Audit("give-gold", actor, request.AccountId, $"amount={amount} msg={result.Message}");
    return new AdminCommandResult(result.Ok, command, result.Message);
}

static AdminCommandResult AdminSetGold(string command, AdminCommandRequest request, string actor, ServerAdminService adminService, EconomyService economyService)
{
    if (string.IsNullOrWhiteSpace(request.AccountId)) return new AdminCommandResult(false, command, "AccountId required.");
    if (!int.TryParse(request.Reason, out int amount) || amount < 0) return new AdminCommandResult(false, command, "Set Reason to the gold amount (e.g. '5000').");
    economyService.GetOrCreatePlayer(request.AccountId, "");
    var result = economyService.AdminSetGold(request.AccountId, amount, actor);
    adminService.Audit("set-gold", actor, request.AccountId, $"amount={amount} msg={result.Message}");
    return new AdminCommandResult(result.Ok, command, result.Message);
}

static AdminCommandResult AdminAddShopItem(string command, AdminCommandRequest request, string actor, ServerAdminService adminService, ShopService shopService)
{
    if (string.IsNullOrWhiteSpace(request.Reason)) return new AdminCommandResult(false, command, "Set Reason to 'assetId:price' (e.g. '300005:500').");
    string[] parts = request.Reason.Split(':');
    if (parts.Length != 2 || !int.TryParse(parts[0], out int assetId) || !int.TryParse(parts[1], out int price))
        return new AdminCommandResult(false, command, "Format: 'assetId:price' (e.g. '300005:500').");
    var result = shopService.AddRotationItem(assetId, price, actor);
    adminService.Audit("shop-add-rotation", actor, request.AccountId, $"assetId={assetId} price={price} msg={result.Message}");
    return new AdminCommandResult(result.Ok, command, result.Message);
}

static AdminCommandResult AdminAddShopFreebie(string command, AdminCommandRequest request, string actor, ServerAdminService adminService, ShopService shopService)
{
    if (string.IsNullOrWhiteSpace(request.Reason)) return new AdminCommandResult(false, command, "Set Reason to asset ID (e.g. '300005').");
    if (!int.TryParse(request.Reason, out int assetId)) return new AdminCommandResult(false, command, "Reason must be a valid asset ID.");
    var result = shopService.AddFreebieItem(assetId, actor);
    adminService.Audit("shop-add-freebie", actor, request.AccountId, $"assetId={assetId} msg={result.Message}");
    return new AdminCommandResult(result.Ok, command, result.Message);
}

static AdminCommandResult AdminRemoveShopItem(string command, AdminCommandRequest request, string actor, ServerAdminService adminService, ShopService shopService)
{
    if (string.IsNullOrWhiteSpace(request.Reason)) return new AdminCommandResult(false, command, "Set Reason to the listing ID (e.g. 'shop-rotation-300005').");
    var result = shopService.RemoveItem(request.Reason, actor);
    adminService.Audit("shop-remove", actor, request.AccountId, $"listingId={request.Reason} msg={result.Message}");
    return new AdminCommandResult(result.Ok, command, result.Message);
}

static AdminCommandResult AdminClearShop(string command, string actor, ServerAdminService adminService, ShopService shopService)
{
    var result = shopService.ClearShop(actor);
    adminService.Audit("shop-clear", actor, null, $"msg={result.Message}");
    return new AdminCommandResult(result.Ok, command, result.Message);
}

// Admin: empty the matchmaking queue.
//   POST /admin/commands { "command":"queue-clear" }
// Useful when the queue gets jammed with phantom entries from network drops.
static AdminCommandResult AdminClearQueue(string command, string actor, ServerAdminService adminService, MatchmakingQueueService queueService, ILogger<Program> logger)
{
    QueueStatus before = queueService.GetStatus();
    queueService.ClearQueue();
    logger.LogInformation("Admin {Actor} cleared matchmaking queue. {Count} entries dropped.", actor, before.PlayerCount);
    adminService.Audit("queue-clear", actor, null, $"dropped={before.PlayerCount}");
    return new AdminCommandResult(true, command, $"Cleared matchmaking queue ({before.PlayerCount} entries).", before);
}

// Admin: pull a specific account out of the matchmaking queue.
//   POST /admin/commands { "command":"queue-leave", "accountId":"custom-..." }
static AdminCommandResult AdminQueueLeave(string command, AdminCommandRequest request, string actor, ServerAdminService adminService, MatchmakingQueueService queueService, ILogger<Program> logger)
{
    if (string.IsNullOrWhiteSpace(request.AccountId)) return new AdminCommandResult(false, command, "AccountId required.");
    bool removed = queueService.LeaveQueue(request.AccountId);
    logger.LogInformation("Admin {Actor} pulled {AccountId} from matchmaking queue: removed={Removed}.", actor, request.AccountId, removed);
    adminService.Audit(removed ? "queue-leave" : "queue-leave-miss", actor, request.AccountId, $"removed={removed}");
    return new AdminCommandResult(true, command, removed ? $"Removed {request.AccountId} from queue." : $"{request.AccountId} was not in queue.");
}

// AdminSetModifiers: sets the active modifier IDs from a CSV in Reason field.
// Example: { "command":"set-modifiers", "reason":"4,8,9" } enables Gold Drop, MoveSpeed, Night.
// Empty Reason = disable all modifiers.
static AdminCommandResult AdminSetModifiers(string command, AdminCommandRequest request, string actor, ServerAdminService adminService, IOptionsMonitor<CustomServerOptions> options)
{
    var opts = options.CurrentValue;
    int[] newIds;
    if (string.IsNullOrWhiteSpace(request.Reason))
    {
        newIds = Array.Empty<int>();
    }
    else
    {
        var parts = request.Reason.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        var validIds = new List<int>();
        foreach (var p in parts)
        {
            if (int.TryParse(p, out int id) && id >= 0 && id < GameModifierCatalog.KnownGameModifiers.Length)
                validIds.Add(id);
            else
                return new AdminCommandResult(false, command, $"Invalid modifier ID '{p}'. Use 0-{GameModifierCatalog.KnownGameModifiers.Length-1}, see list-modifiers.");
        }
        newIds = validIds.Distinct().ToArray();
    }

    opts.MatchDefaults.GameModifierIds = newIds;
    var names = newIds.Select(i => $"{i}={GameModifierCatalog.KnownGameModifiers[i].Name}").ToArray();
    string msg = newIds.Length == 0
        ? "All modifiers disabled."
        : $"Enabled {newIds.Length} modifier(s): {string.Join(", ", names)}";
    adminService.Audit("modifiers-set", actor, null, $"ids=[{string.Join(",", newIds)}] msg={msg}");
    return new AdminCommandResult(true, command, msg, new { modifierIds = newIds, names });
}

static AdminCommandResult AdminListModifiers(string command, IOptionsMonitor<CustomServerOptions> options)
{
    var opts = options.CurrentValue;
    var current = new HashSet<int>(opts.MatchDefaults.GameModifierIds);
    var list = GameModifierCatalog.KnownGameModifiers.Select(m => new { id = m.Id, name = m.Name, display = m.Display, enabled = current.Contains(m.Id) }).ToArray();
    return new AdminCommandResult(true, command, $"{GameModifierCatalog.KnownGameModifiers.Length} modifiers available, {current.Count} enabled.", list);
}

static AdminCommandResult AdminGrantAsset(string command, AdminCommandRequest request, string actor, ServerAdminService adminService, EconomyService economyService)
{
    if (string.IsNullOrWhiteSpace(request.AccountId)) return new AdminCommandResult(false, command, "AccountId required.");
    if (!int.TryParse(request.Reason, out int assetId)) return new AdminCommandResult(false, command, "Set Reason to asset ID.");
    economyService.GetOrCreatePlayer(request.AccountId, "");
    var result = economyService.GrantAsset(request.AccountId, assetId, $"admin grant by {actor}");
    adminService.Audit("asset-grant", actor, request.AccountId, $"assetId={assetId} msg={result.Message}");
    return new AdminCommandResult(result.Ok, command, result.Message);
}

static AdminCommandResult AdminRevokeAsset(string command, AdminCommandRequest request, string actor, ServerAdminService adminService, EconomyService economyService)
{
    if (string.IsNullOrWhiteSpace(request.AccountId)) return new AdminCommandResult(false, command, "AccountId required.");
    if (!int.TryParse(request.Reason, out int assetId)) return new AdminCommandResult(false, command, "Set Reason to asset ID.");
    var result = economyService.RevokeAsset(request.AccountId, assetId, $"admin revoke by {actor}");
    adminService.Audit("asset-revoke", actor, request.AccountId, $"assetId={assetId} msg={result.Message}");
    return new AdminCommandResult(result.Ok, command, result.Message);
}

static AdminCommandResult AdminRankedReset(string command, AdminCommandRequest request, string actor, ServerAdminService adminService, RankedService rankedService)
{
    if (string.IsNullOrWhiteSpace(request.AccountId)) return new AdminCommandResult(false, command, "AccountId required.");
    rankedService.AdminResetPlayer(request.AccountId, actor);
    adminService.Audit("ranked-reset", actor, request.AccountId, "ranked state reset");
    return new AdminCommandResult(true, command, $"Reset ranked state for {request.AccountId}.");
}

static AdminCommandResult AdminRankedSetPoints(string command, AdminCommandRequest request, string actor, ServerAdminService adminService, RankedService rankedService)
{
    if (string.IsNullOrWhiteSpace(request.AccountId)) return new AdminCommandResult(false, command, "AccountId required.");
    if (!int.TryParse(request.Reason, out int points)) return new AdminCommandResult(false, command, "Set Reason to points value.");
    rankedService.AdminSetPoints(request.AccountId, points, actor);
    adminService.Audit("ranked-set-points", actor, request.AccountId, $"points={points}");
    return new AdminCommandResult(true, command, $"Set ranked points to {points} for {request.AccountId}.");
}

static DeploymentInfo LoadDeploymentInfo(string contentRoot)
{
    string path = Path.Combine(contentRoot, "deployment-info.json");
    string loadError = "";
    try
    {
        if (File.Exists(path))
        {
            DeploymentInfo? info = JsonSerializer.Deserialize<DeploymentInfo>(
                File.ReadAllText(path),
                JsonContract.Options);

            if (info is not null)
            {
                info.FilePath = path;
                return info;
            }
        }
    }
    catch (Exception ex)
    {
        loadError = $"{ex.GetType().Name}: {ex.Message}";
    }

    Assembly assembly = Assembly.GetExecutingAssembly();
    string informationalVersion = assembly
        .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
        .InformationalVersion ?? assembly.GetName().Version?.ToString() ?? "unknown";

    return new DeploymentInfo
    {
        SchemaVersion = 1,
        ReleaseLabel = Environment.GetEnvironmentVariable("BAPCUSTOM_RELEASE_LABEL") ?? informationalVersion,
        GitCommit = Environment.GetEnvironmentVariable("BAPCUSTOM_GIT_COMMIT") ?? "unknown",
        GitBranch = Environment.GetEnvironmentVariable("BAPCUSTOM_GIT_BRANCH") ?? "unknown",
        PackageBuildUtc = "unknown",
        Configuration = "unknown",
        SelfContained = null,
        PublicHost = "",
        FilePath = path,
        LoadError = loadError
    };
}

static RuntimeDiagnostics BuildRuntimeDiagnostics()
{
    return new RuntimeDiagnostics
    {
        OsDescription = RuntimeInformation.OSDescription,
        ProcessArchitecture = RuntimeInformation.ProcessArchitecture.ToString(),
        FrameworkDescription = RuntimeInformation.FrameworkDescription,
        CommandLine = Environment.CommandLine,
        ContentRoot = Directory.GetCurrentDirectory(),
        AspNetCoreUrls = Environment.GetEnvironmentVariable("ASPNETCORE_URLS") ?? "",
        Path = Environment.GetEnvironmentVariable("PATH") ?? "",
        WinePath = RunShellProbe("command -v wine || true").StdoutSingleLine,
        WineVersion = RunShellProbe("wine --version 2>&1 || true").StdoutSingleLine,
        WinebootPath = RunShellProbe("command -v wineboot || true").StdoutSingleLine,
        XvfbRunPath = RunShellProbe("command -v xvfb-run || true").StdoutSingleLine,
        XauthPath = RunShellProbe("command -v xauth || true").StdoutSingleLine,
        GlxinfoPath = RunShellProbe("command -v glxinfo || true").StdoutSingleLine,
        VulkanInfoPath = RunShellProbe("command -v vulkaninfo || true").StdoutSingleLine,
        GraphicsPackageStatus = BuildLinuxGraphicsPackageStatus(),
        LibGlAlwaysSoftware = Environment.GetEnvironmentVariable("LIBGL_ALWAYS_SOFTWARE") ?? "",
        GalliumDriver = Environment.GetEnvironmentVariable("GALLIUM_DRIVER") ?? "",
        MesaLoaderDriverOverride = Environment.GetEnvironmentVariable("MESA_LOADER_DRIVER_OVERRIDE") ?? "",
        MesaGlVersionOverride = Environment.GetEnvironmentVariable("MESA_GL_VERSION_OVERRIDE") ?? "",
        WinePrefix = Environment.GetEnvironmentVariable("WINEPREFIX") ?? "",
        WineArch = Environment.GetEnvironmentVariable("WINEARCH") ?? ""
    };
}

static GameLogDiagnostics BuildGameLogDiagnostics(string contentRoot, CustomServerOptions options, int? requestedTailLines, int? requestedFiles)
{
    int tailLines = Math.Clamp(requestedTailLines ?? options.GameServerDiagnosticTailLines, 20, 300);
    int maxFiles = Math.Clamp(requestedFiles ?? 12, 1, 30);
    string logDirectory = ResolveDiagnosticPath(contentRoot, options.GameLogDirectory);
    var candidates = new List<string>();

    try
    {
        if (Directory.Exists(logDirectory))
        {
            candidates.AddRange(Directory.EnumerateFiles(logDirectory, "*.log", SearchOption.TopDirectoryOnly));
        }
    }
    catch
    {
    }

    string melonLog = Path.Combine(contentRoot, "game", "MelonLoader", "Latest.log");
    if (File.Exists(melonLog))
    {
        candidates.Add(melonLog);
    }

    GameLogFileTail[] fileTails = candidates
        .Distinct(StringComparer.OrdinalIgnoreCase)
        .Select(BuildGameLogFileTail)
        .Where(file => file.Exists)
        .OrderByDescending(file => file.LastWriteUtc)
        .ThenBy(file => file.Path, StringComparer.OrdinalIgnoreCase)
        .Take(maxFiles)
        .Select(file => file with
        {
            Tail = ReadLastLines(file.Path, tailLines),
            ImportantTail = ReadImportantLines(file.Path, tailLines)
        })
        .ToArray();

    return new GameLogDiagnostics
    {
        ContentRoot = contentRoot,
        GameLogDirectory = logDirectory,
        TailLines = tailLines,
        MaxFiles = maxFiles,
        Files = fileTails
    };
}

static string ResolveDiagnosticPath(string contentRoot, string path)
{
    if (Path.IsPathRooted(path))
    {
        return Path.GetFullPath(path);
    }

    return Path.GetFullPath(Path.Combine(contentRoot, path));
}

static GameLogFileTail BuildGameLogFileTail(string path)
{
    try
    {
        var file = new FileInfo(path);
        return new GameLogFileTail
        {
            Path = path,
            Name = file.Name,
            Kind = file.Name.EndsWith(".wrapper.log", StringComparison.OrdinalIgnoreCase)
                ? "wrapper"
                : file.FullName.Contains($"{Path.DirectorySeparatorChar}MelonLoader{Path.DirectorySeparatorChar}", StringComparison.OrdinalIgnoreCase)
                    ? "melon"
                    : "unity",
            Exists = file.Exists,
            SizeBytes = file.Exists ? file.Length : 0,
            LastWriteUtc = file.Exists ? file.LastWriteTimeUtc : null,
        };
    }
    catch (Exception ex)
    {
        return new GameLogFileTail
        {
            Path = path,
            Name = Path.GetFileName(path),
            Kind = "unknown",
            Exists = false,
            Error = ex.GetBaseException().Message
        };
    }
}

static string[] ReadLastLines(string path, int maxLines)
{
    try
    {
        return File.ReadLines(path)
            .TakeLast(maxLines)
            .Select(CompactDiagnosticLogLine)
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .ToArray();
    }
    catch (Exception ex)
    {
        return [$"<could not read log: {ex.GetBaseException().Message}>"];
    }
}

static string[] ReadImportantLines(string path, int maxLines)
{
    try
    {
        return File.ReadLines(path)
            .Select(CompactDiagnosticLogLine)
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Where(line => !IsDiagnosticNoiseLine(line))
            .Where(IsImportantDiagnosticLogLine)
            .TakeLast(maxLines)
            .ToArray();
    }
    catch (Exception ex)
    {
        return [$"<could not read log: {ex.GetBaseException().Message}>"];
    }
}

static bool IsImportantDiagnosticLogLine(string line)
{
    string[] markers =
    [
        "BAPCUSTOM",
        "BAP_Custom",
        "deployment.",
        "unityGraphicsArgs",
        "glxinfo",
        "vulkan",
        "wine",
        "xvfb",
        "bootstrap",
        "setup-game",
        "add-teams",
        "queue-matched",
        "httpport",
        "Mirror",
        "KCP",
        "TcpListener",
        "GameNetworkManager",
        "StartServer",
        "InitializeEngineGraphics",
        "graphics device is Null",
        "d3d11",
        "DXGI",
        "ERROR",
        "Error",
        "Exception",
        "failed",
        "fatal",
        "crash"
    ];

    return markers.Any(marker => line.Contains(marker, StringComparison.OrdinalIgnoreCase));
}

static bool IsDiagnosticNoiseLine(string line)
{
    return line.Contains("shader is not supported on this GPU", StringComparison.OrdinalIgnoreCase) ||
           line.Contains("Shader Unsupported:", StringComparison.OrdinalIgnoreCase) ||
           line.Contains("All subshaders removed", StringComparison.OrdinalIgnoreCase) ||
           line.Contains("#pragma only_renderers", StringComparison.OrdinalIgnoreCase) ||
           line.Contains("Fallback off", StringComparison.OrdinalIgnoreCase) ||
           line.Contains("Could not find material Hidden/Video", StringComparison.OrdinalIgnoreCase) ||
           line.Contains("Could not find video decode shader pass", StringComparison.OrdinalIgnoreCase) ||
           line.Contains("Video shaders not found", StringComparison.OrdinalIgnoreCase) ||
           line.Contains("Microsoft Media Foundation video decoding to texture disabled", StringComparison.OrdinalIgnoreCase) ||
           line.Contains("WindowsVideoMedia error", StringComparison.OrdinalIgnoreCase) ||
           line.Contains("Unable to find an AppUISettings instance", StringComparison.OrdinalIgnoreCase) ||
           line.Contains("ALSA lib ", StringComparison.OrdinalIgnoreCase) ||
           line.Contains("[KCP] Server: RawSend invalid connectionId=", StringComparison.OrdinalIgnoreCase) ||
           line.Contains("kcp2k.KcpServer:RawSend", StringComparison.OrdinalIgnoreCase) ||
           line.Contains("kcp2k.KcpServerConnection:RawSend", StringComparison.OrdinalIgnoreCase) ||
           line.Contains("kcp2k.KcpPeer:SendDisconnect", StringComparison.OrdinalIgnoreCase);
}

static string CompactDiagnosticLogLine(string line)
{
    return string.Join(' ', (line ?? "").Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries));
}

static void LogStartupDiagnostics(WebApplication app, DeploymentInfo deployment, RuntimeDiagnostics runtime, CustomServerOptions options)
{
    if (!string.IsNullOrWhiteSpace(deployment.LoadError))
    {
        app.Logger.LogWarning(
            "BAPCUSTOM_DEPLOYMENT_INFO_INVALID path={DeploymentInfoFile} error={LoadError}",
            deployment.FilePath,
            deployment.LoadError);
    }

    app.Logger.LogInformation(
        "BAPCUSTOM_STARTUP release={ReleaseLabel} git={GitCommit} branch={GitBranch} dirty={GitDirty} packageUtc={PackageBuildUtc} configuration={Configuration} selfContained={SelfContained} contentRoot={ContentRoot} deploymentInfo={DeploymentInfoFile}",
        deployment.ReleaseLabel,
        deployment.GitCommit,
        deployment.GitBranch,
        deployment.GitDirty,
        deployment.PackageBuildUtc,
        deployment.Configuration,
        deployment.SelfContained,
        app.Environment.ContentRootPath,
        deployment.FilePath);

    app.Logger.LogInformation(
        "BAPCUSTOM_CONFIG publicBaseUrl={PublicBaseUrl} publicGameHost={PublicGameHost} launchGameServers={LaunchGameServers} gameExecutable={GameExecutable} gameLauncher={GameLauncher} gameLauncherArgs={GameLauncherArgs} ports ws={WsPort} kcp={KcpPort} tcp={TcpPort} http={HttpPort} range={PortRange} portCooldown={PortCooldown}s readyTimeout={ReadyTimeout}s bootstrapHttpTimeout={BootstrapHttpTimeout}s bootstrapResetPoll={BootstrapResetPoll}ms managedBootstrapTimeout={ManagedBootstrapTimeout}s managedBootstrapListenerOnly={ManagedBootstrapListenerOnly}s requireKcp={RequireKcp} tcpTimeout={TcpTimeout}s kcpTimeout={KcpTimeout}s startAttempts={StartAttempts} effectiveStartAttempts={EffectiveStartAttempts} startRetryDelay={StartRetryDelay}s stopWait={StopWaitMillis}ms postCleanupStartDelay={PostCleanupStartDelayMillis}ms startupStallGrace={StartupStallGrace}s startupStall={StartupStall}s noisyStallGrace={NoisyStallGrace}s noisyStall={NoisyStall}s wrapperOnlyStallGrace={WrapperOnlyStallGrace}s wrapperOnlyStall={WrapperOnlyStall}s prewarm={PrewarmEnabled} prewarmTimeout={PrewarmTimeout}s prewarmMatchWait={PrewarmMatchWait}s maxMatches={MaxMatches} emptyLobbyGrace={EmptyLobbyGrace}s emptyLobbyConnectedGrace={EmptyLobbyConnectedGrace}s",
        options.PublicBaseUrl,
        options.PublicGameHost,
        options.LaunchGameServers,
        options.GameExecutablePath,
        options.GameLauncherPath,
        options.GameLauncherArguments,
        options.BaseWsPort,
        options.BaseKcpPort,
        options.BaseTcpPort,
        options.BaseHttpPort,
        options.PortSearchRange,
        options.PortReleaseCooldownSeconds,
        options.GameServerReadyTimeoutSeconds,
        options.GameServerBootstrapHttpTimeoutSeconds,
        options.GameServerBootstrapResetPollMillis,
        options.GameServerManagedBootstrapStatusTimeoutSeconds,
        options.GameServerManagedBootstrapListenerOnlyTimeoutSeconds,
        options.RequireGameServerKcpPort,
        options.GameServerTcpPortReadyTimeoutSeconds,
        options.GameServerKcpPortReadyTimeoutSeconds,
        options.GameServerStartAttempts,
        GameServerProcessManager.EffectiveGameServerStartAttempts(options),
        options.GameServerStartRetryDelaySeconds,
        options.GameServerStopWaitMillis,
        options.GameServerPostCleanupStartDelayMillis,
        options.GameServerStartupStallGraceSeconds,
        options.GameServerStartupStallSeconds,
        GameServerProcessManager.EffectiveNoisyStartupStallGraceSeconds(options),
        GameServerProcessManager.EffectiveNoisyStartupStallSeconds(options),
        GameServerProcessManager.EffectiveWrapperOnlyStartupStallGraceSeconds(options),
        GameServerProcessManager.EffectiveWrapperOnlyStartupStallSeconds(options),
        options.GameServerPrewarmOnStartup,
        options.GameServerPrewarmTimeoutSeconds,
        options.GameServerPrewarmMatchWaitSeconds,
        options.MaxConcurrentMatches,
        options.EmptyLobbyMatchCleanupGraceSeconds,
        options.EmptyLobbyMatchConnectedCleanupGraceSeconds);

    app.Logger.LogInformation(
        "BAPCUSTOM_ARTIFACTS serverDllSha256={ServerDllSha256} modDllSha256={ModDllSha256} modApiDllSha256={ModApiDllSha256} medusaDllSha256={MedusaDllSha256} medusaBundleSha256={MedusaBundleSha256} gameExeSha256={GameExeSha256} startMatchSha256={StartMatchSha256} packageSha256={PackageSha256}",
        deployment.ServerDllSha256,
        deployment.ModDllSha256,
        deployment.ModApiDllSha256,
        deployment.MedusaDllSha256,
        deployment.MedusaBundleSha256,
        deployment.GameExeSha256,
        deployment.StartMatchSha256,
        deployment.PackageSha256);

    app.Logger.LogInformation(
        "BAPCUSTOM_MEDUSA charId={CharId} rosterEnabled={RosterEnabled} advertised={Advertised}",
        CharacterCatalog.MedusaCharId,
        options.Roster.EnableMedusa,
        options.MatchDefaults.AvailableCharacters.Contains(CharacterCatalog.MedusaCharId));

    app.Logger.LogInformation(
        "BAPCUSTOM_RUNTIME os={OsDescription} arch={ProcessArchitecture} framework={FrameworkDescription} urls={AspNetCoreUrls} winePath={WinePath} wineVersion={WineVersion} winebootPath={WinebootPath} xvfbRunPath={XvfbRunPath} xauthPath={XauthPath} glxinfoPath={GlxinfoPath} vulkanInfoPath={VulkanInfoPath}",
        runtime.OsDescription,
        runtime.ProcessArchitecture,
        runtime.FrameworkDescription,
        runtime.AspNetCoreUrls,
        runtime.WinePath,
        runtime.WineVersion,
        runtime.WinebootPath,
        runtime.XvfbRunPath,
        runtime.XauthPath,
        runtime.GlxinfoPath,
        runtime.VulkanInfoPath);

    app.Logger.LogInformation(
        "BAPCUSTOM_GRAPHICS_PACKAGES {GraphicsPackageStatus}",
        string.Join(" | ", runtime.GraphicsPackageStatus));

    app.Logger.LogInformation(
        "BAPCUSTOM_GRAPHICS_ENV LIBGL_ALWAYS_SOFTWARE={LibGlAlwaysSoftware} GALLIUM_DRIVER={GalliumDriver} MESA_LOADER_DRIVER_OVERRIDE={MesaLoaderDriverOverride} MESA_GL_VERSION_OVERRIDE={MesaGlVersionOverride} WINEPREFIX={WinePrefix} WINEARCH={WineArch}",
        runtime.LibGlAlwaysSoftware,
        runtime.GalliumDriver,
        runtime.MesaLoaderDriverOverride,
        runtime.MesaGlVersionOverride,
        runtime.WinePrefix,
        runtime.WineArch);

    if (string.IsNullOrWhiteSpace(runtime.WinePath) ||
        string.IsNullOrWhiteSpace(runtime.XvfbRunPath) ||
        string.IsNullOrWhiteSpace(runtime.XauthPath))
    {
        app.Logger.LogWarning(
            "BAPCUSTOM_RUNTIME_CHECK missing required Wine/Xvfb tool(s): winePath={WinePath} xvfbRunPath={XvfbRunPath} xauthPath={XauthPath}",
            runtime.WinePath,
            runtime.XvfbRunPath,
            runtime.XauthPath);
    }
    else
    {
        app.Logger.LogInformation("BAPCUSTOM_RUNTIME_CHECK wine_xvfb_ready=true");
    }
}

static CommandProbeResult RunShellProbe(string command)
{
    if (!OperatingSystem.IsLinux() && !OperatingSystem.IsMacOS())
    {
        return new CommandProbeResult("", "", -1);
    }

    try
    {
        using var process = new Process();
        process.StartInfo = new ProcessStartInfo
        {
            FileName = "/bin/sh",
            ArgumentList = { "-lc", command },
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };
        process.Start();
        if (!process.WaitForExit(2000))
        {
            try { process.Kill(entireProcessTree: true); } catch { }
            return new CommandProbeResult("", "timeout", -1);
        }

        return new CommandProbeResult(
            process.StandardOutput.ReadToEnd().Trim(),
            process.StandardError.ReadToEnd().Trim(),
            process.ExitCode);
    }
    catch (Exception ex)
    {
        return new CommandProbeResult("", ex.Message, -1);
    }
}

static string[] BuildLinuxGraphicsPackageStatus()
{
    if (!OperatingSystem.IsLinux())
    {
        return [];
    }

    const string packages = "wine wine32 wine64 xvfb xauth libgl1 libgl1:i386 libgl1-mesa-dri libgl1-mesa-dri:i386 libglx-mesa0 libglx-mesa0:i386 libvulkan1 libvulkan1:i386 mesa-vulkan-drivers mesa-vulkan-drivers:i386 mesa-utils x11-utils";
    string script = "for p in " + packages + "; do dpkg-query -W -f='${Package}=${Version}\\n' \"$p\" 2>/dev/null || echo \"$p=<missing>\"; done";
    CommandProbeResult result = RunShellProbe(script);
    if (string.IsNullOrWhiteSpace(result.Stdout))
    {
        return [$"<package probe unavailable: {result.Stderr}>"];
    }

    return result.Stdout
        .Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
        .ToArray();
}

public sealed class DeploymentInfo
{
    public int SchemaVersion { get; set; }
    public string ReleaseLabel { get; set; } = "unknown";
    public string PackageBuildUtc { get; set; } = "unknown";
    public string GitCommit { get; set; } = "unknown";
    public string GitBranch { get; set; } = "unknown";
    [JsonConverter(typeof(FlexibleBooleanJsonConverter))]
    public bool GitDirty { get; set; }
    public string Configuration { get; set; } = "unknown";
    public bool? SelfContained { get; set; }
    public string PublicHost { get; set; } = "";
    public string ServerDllSha256 { get; set; } = "";
    public string ModDllSha256 { get; set; } = "";
    public string ModApiDllSha256 { get; set; } = "";
    public string MedusaDllSha256 { get; set; } = "";
    public string MedusaBundleSha256 { get; set; } = "";
    public int MedusaCharId { get; set; }
    public string GameExeSha256 { get; set; } = "";
    public string StartMatchSha256 { get; set; } = "";
    public string PackageSha256 { get; set; } = "";
    public Dictionary<string, int> Ports { get; set; } = new();
    public string FilePath { get; set; } = "";
    public string LoadError { get; set; } = "";
}

public sealed class FlexibleBooleanJsonConverter : JsonConverter<bool>
{
    public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.TokenType switch
        {
            JsonTokenType.True => true,
            JsonTokenType.False => false,
            JsonTokenType.Number => reader.TryGetInt64(out long value) && value != 0,
            JsonTokenType.String => !string.IsNullOrWhiteSpace(reader.GetString())
                && !string.Equals(reader.GetString(), "false", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(reader.GetString(), "0", StringComparison.OrdinalIgnoreCase),
            JsonTokenType.StartArray => ReadNonEmptyArray(ref reader),
            JsonTokenType.Null => false,
            _ => throw new JsonException($"Cannot convert {reader.TokenType} to Boolean.")
        };
    }

    public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
    {
        writer.WriteBooleanValue(value);
    }

    private static bool ReadNonEmptyArray(ref Utf8JsonReader reader)
    {
        bool hasItems = reader.Read() && reader.TokenType != JsonTokenType.EndArray;
        while (reader.TokenType != JsonTokenType.EndArray && reader.Read())
        {
        }

        return hasItems;
    }
}

public sealed class RuntimeDiagnostics
{
    public string OsDescription { get; set; } = "";
    public string ProcessArchitecture { get; set; } = "";
    public string FrameworkDescription { get; set; } = "";
    public string CommandLine { get; set; } = "";
    public string ContentRoot { get; set; } = "";
    public string AspNetCoreUrls { get; set; } = "";
    public string Path { get; set; } = "";
    public string WinePath { get; set; } = "";
    public string WineVersion { get; set; } = "";
    public string WinebootPath { get; set; } = "";
    public string XvfbRunPath { get; set; } = "";
    public string XauthPath { get; set; } = "";
    public string GlxinfoPath { get; set; } = "";
    public string VulkanInfoPath { get; set; } = "";
    public string[] GraphicsPackageStatus { get; set; } = [];
    public string LibGlAlwaysSoftware { get; set; } = "";
    public string GalliumDriver { get; set; } = "";
    public string MesaLoaderDriverOverride { get; set; } = "";
    public string MesaGlVersionOverride { get; set; } = "";
    public string WinePrefix { get; set; } = "";
    public string WineArch { get; set; } = "";
}

public sealed class GameLogDiagnostics
{
    public string ContentRoot { get; set; } = "";
    public string GameLogDirectory { get; set; } = "";
    public int TailLines { get; set; }
    public int MaxFiles { get; set; }
    public GameLogFileTail[] Files { get; set; } = [];
}

public sealed record GameLogFileTail
{
    public string Path { get; init; } = "";
    public string Name { get; init; } = "";
    public string Kind { get; init; } = "";
    public bool Exists { get; init; }
    public long SizeBytes { get; init; }
    public DateTime? LastWriteUtc { get; init; }
    public string Error { get; init; } = "";
    public string[] Tail { get; init; } = [];
    public string[] ImportantTail { get; init; } = [];
}

public sealed record CommandProbeResult(string Stdout, string Stderr, int ExitCode)
{
    public string StdoutSingleLine => Stdout
        .Replace('\r', ' ')
        .Replace('\n', ' ')
        .Trim();
}

// 16 known game modifiers from BAPBAP source (BAPBAP/Local/GM_*.cs subclasses).
// Modifier ID = position in GameModifierManager.gameModifiers[] array.
static class GameModifierCatalog
{
    public static readonly (int Id, string Name, string Display)[] KnownGameModifiers = new[]
    {
        (0,  "GM_AllGigantic",         "All Gigantic - all chars huge"),
        (1,  "GM_AngledMap",           "Angled Map - tilted terrain"),
        (2,  "GM_CDReduction",         "Cooldown Reduction"),
        (3,  "GM_FastZone",            "Fast Zone - storm closes faster"),
        (4,  "GM_GoldDropIncrease",    "Gold Drop Increase"),
        (5,  "GM_HpReduction",         "HP Reduction - less health"),
        (6,  "GM_MeteorShower",        "Meteor Shower"),
        (7,  "GM_MoneyIsPower",        "Money Is Power"),
        (8,  "GM_MoveSpeedBoost",      "Move Speed Boost"),
        (9,  "GM_NightTime",           "Night Time - dark map"),
        (10, "GM_NoPainNoGain",        "No Pain No Gain"),
        (11, "GM_NoPotionDrops",       "No Potion Drops"),
        (12, "GM_ReviveTeammateOnKill","Revive Teammate On Kill"),
        (13, "GM_UniqueItemChance",    "Unique Item Chance"),
        (14, "GM_UseJuiceBoost",       "Juice Boost"),
        (15, "GM_XCOM",                "XCOM - misses possible")
    };
}
