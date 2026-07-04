using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace BapCustomServer.Tests;

// Phase 0 protocol lock (rewrite-v2/03-protocol-compatibility.md §1.2/§2.2): the FULL set of
// route+method registrations is a frozen contract with the shipped game client. Minimal-API
// duplicate registrations do NOT fail at startup — they 500 with AmbiguousMatchException at
// request time (see the "/api/shop is now handled by ShopService" note at Program.cs ~1271),
// so uniqueness is asserted here instead of being left to runtime.
[Collection("HttpIntegration")] // serialize: the factory boots a full host with hosted services
public sealed class RouteManifestContractTests : IClassFixture<RouteManifestContractTests.AppFactory>
{
    private readonly AppFactory _factory;

    public RouteManifestContractTests(AppFactory factory) => _factory = factory;

    public sealed class AppFactory : WebApplicationFactory<ApiEntryPoint>
    {
        public readonly string DataDir = Path.Combine(Path.GetTempPath(), "bapcustom-routes", Guid.NewGuid().ToString("N"));

        protected override IHost CreateHost(IHostBuilder builder)
        {
            Directory.CreateDirectory(DataDir);
            // PlayerOverridesService regenerates an unlockEverything:true default document at any
            // missing StateFile path; pre-seed a NEUTRAL document so state stays deterministic.
            File.WriteAllText(
                Path.Combine(DataDir, "player-overrides.json"),
                """{ "defaults": {}, "players": {} }""");
            builder.UseEnvironment("Testing");
            builder.ConfigureHostConfiguration(cfg =>
            {
                cfg.AddInMemoryCollection(new Dictionary<string, string?>
                {
                    ["CustomServer:LaunchGameServers"] = "false",
                    ["CustomServer:GameServerPrewarmOnStartup"] = "false",
                    ["CustomServer:Economy:StateFile"] = Path.Combine(DataDir, "economy.json"),
                    ["CustomServer:Friends:StateFile"] = Path.Combine(DataDir, "friends.json"),
                    ["CustomServer:Ranked:StateFile"] = Path.Combine(DataDir, "ranked.json"),
                    ["CustomServer:MatchHistory:LogFile"] = Path.Combine(DataDir, "history.jsonl"),
                    ["CustomServer:Admin:StateFile"] = Path.Combine(DataDir, "admin.json"),
                    ["CustomServer:Admin:AuditLogFile"] = Path.Combine(DataDir, "audit.jsonl"),
                    ["CustomServer:PlayerStorage:PlayersDirectory"] = Path.Combine(DataDir, "players"),
                    ["CustomServer:PlayerOverrides:StateFile"] = Path.Combine(DataDir, "player-overrides.json"),
                    ["CustomServer:Shop:StateFile"] = Path.Combine(DataDir, "shop-state.json"),
                });
            });
            return base.CreateHost(builder);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            try { if (Directory.Exists(DataDir)) Directory.Delete(DataDir, recursive: true); } catch { }
        }
    }

    // Dumps every route+method pair the app registered, sorted ordinally. Endpoints without
    // HttpMethodMetadata (the /ws upgrade path) are reported as "ANY <route>".
    private List<string> DumpRouteMethodPairs()
    {
        _ = _factory.Server; // force server creation so WebApplication's endpoints are built

        var pairs = new List<string>();
        var sources = _factory.Services.GetServices<EndpointDataSource>();
        foreach (RouteEndpoint route in sources.SelectMany(s => s.Endpoints).OfType<RouteEndpoint>())
        {
            IReadOnlyList<string> methods =
                route.Metadata.GetMetadata<HttpMethodMetadata>()?.HttpMethods is { Count: > 0 } m
                    ? m
                    : new[] { "ANY" };
            foreach (string method in methods)
            {
                pairs.Add($"{method} {route.RoutePattern.RawText}");
            }
        }

        pairs.Sort(StringComparer.Ordinal);
        return pairs;
    }

    [Fact] // duplicate minimal-API registrations don't fail at startup — they 500 at request time
    public void RouteManifest_HasNoDuplicateRouteMethodRegistrations()
    {
        var pairs = DumpRouteMethodPairs();

        string[] duplicates = pairs
            .GroupBy(p => p, StringComparer.Ordinal)
            .Where(g => g.Count() > 1)
            .Select(g => $"{g.Key} (registered {g.Count()}x)")
            .ToArray();

        Assert.True(duplicates.Length == 0,
            "Duplicate route+method registrations found. Minimal APIs do not fail at startup on " +
            "duplicates; the route 500s (AmbiguousMatchException) at request time instead:\n  " +
            string.Join("\n  ", duplicates));
    }

    [Fact] // the checked-in manifest is the frozen protocol surface — set-compare, report both diffs
    public void RouteManifest_MatchesCheckedInContract()
    {
        var actual = DumpRouteMethodPairs();

        string fixturePath = Path.Combine(AppContext.BaseDirectory, "Fixtures", "routes.contract.json");
        Assert.True(File.Exists(fixturePath), $"Route contract fixture not found at {fixturePath}");
        string[] expected = JsonSerializer.Deserialize<string[]>(File.ReadAllText(fixturePath)) ?? [];

        var actualSet = new HashSet<string>(actual, StringComparer.Ordinal);
        var expectedSet = new HashSet<string>(expected, StringComparer.Ordinal);

        string[] missingFromServer = expectedSet.Except(actualSet).OrderBy(p => p, StringComparer.Ordinal).ToArray();
        string[] notInManifest = actualSet.Except(expectedSet).OrderBy(p => p, StringComparer.Ordinal).ToArray();

        if (missingFromServer.Length > 0 || notInManifest.Length > 0)
        {
            string actualDumpPath = Path.Combine(Path.GetTempPath(), "routes.actual.json");
            File.WriteAllText(actualDumpPath, JsonSerializer.Serialize(
                actualSet.OrderBy(p => p, StringComparer.Ordinal).ToArray(),
                new JsonSerializerOptions { WriteIndented = true }));

            Assert.Fail(
                "Route manifest drift detected.\n" +
                $"Missing from server (in manifest, not registered):\n  {(missingFromServer.Length == 0 ? "(none)" : string.Join("\n  ", missingFromServer))}\n" +
                $"Not in manifest (registered, not in manifest):\n  {(notInManifest.Length == 0 ? "(none)" : string.Join("\n  ", notInManifest))}\n" +
                "If this change is intentional, regenerate Fixtures/routes.contract.json. " +
                $"The actual route dump was written to {actualDumpPath}.");
        }
    }
}
