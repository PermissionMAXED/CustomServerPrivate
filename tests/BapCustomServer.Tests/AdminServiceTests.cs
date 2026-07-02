using BapCustomServer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Xunit;

namespace BapCustomServer.Tests;

// F077 grant/revoke, F078 ban/unban w/ expiry, F079 audit log, B11 regression (no backdoor token).
public class AdminServiceTests
{
    private static ServerAdminService Admin(string dir)
    {
        var opts = new AdminOptions
        {
            StateFile = Path.Combine(dir, "admin.json"),
            AuditLogFile = Path.Combine(dir, "audit.jsonl")
        };
        return new ServerAdminService(Options.Create(opts), new StubEnv(dir), NullLogger<ServerAdminService>.Instance);
    }

    [Fact] // F077
    public void AddAndRemoveAdmin()
    {
        var a = Admin(Svc.TempDir());
        Assert.True(a.AddAdmin("a", "actor").Ok);
        Assert.True(a.IsAdmin("a"));
        Assert.True(a.RemoveAdmin("a", "actor").Ok);
        Assert.False(a.IsAdmin("a"));
        Assert.False(a.AddAdmin("  ", "actor").Ok); // empty rejected
    }

    [Fact] // F078
    public void BanAndUnban()
    {
        var a = Admin(Svc.TempDir());
        Assert.True(a.Ban("a", "rule break", null, "actor").Ok);
        Assert.True(a.IsBanned("a"));
        Assert.False(a.IsBanned("never-banned"));
        Assert.True(a.Unban("a", "actor").Ok);
        Assert.False(a.IsBanned("a"));
    }

    [Fact] // Phase-3 regression: admin unban of config-seeded ban must survive restart
    public void Unban_ConfigSeededBan_DoesNotReappearAfterRestart()
    {
        string dir = Svc.TempDir();
        var opts = new AdminOptions
        {
            StateFile = Path.Combine(dir, "admin.json"),
            AuditLogFile = Path.Combine(dir, "audit.jsonl"),
            BannedAccountIds = ["seeded"]
        };

        var a1 = new ServerAdminService(Options.Create(opts), new StubEnv(dir), NullLogger<ServerAdminService>.Instance);
        Assert.True(a1.IsBanned("seeded"));
        a1.Unban("seeded", "actor");
        Assert.False(a1.IsBanned("seeded"));

        var a2 = new ServerAdminService(Options.Create(opts), new StubEnv(dir), NullLogger<ServerAdminService>.Instance);

        Assert.False(a2.IsBanned("seeded"));
    }

    [Fact] // F078 admin/ban state persists across a restart + config seeds initial admins and bans
    public void State_PersistsAcrossRestart_AndSeedsFromConfig()
    {
        string dir = Svc.TempDir();
        var opts = new AdminOptions
        {
            StateFile = Path.Combine(dir, "admin.json"),
            AuditLogFile = Path.Combine(dir, "audit.jsonl"),
            AdminAccountIds = ["seed-admin"],
            BannedAccountIds = ["seed-ban"]
        };

        // First instance: config seeds seed-admin + seed-ban; we also add a runtime admin + ban.
        var a1 = new ServerAdminService(Options.Create(opts), new StubEnv(dir), NullLogger<ServerAdminService>.Instance);
        Assert.True(a1.IsAdmin("seed-admin"));   // seeded from config
        Assert.True(a1.IsBanned("seed-ban"));    // seeded from config
        a1.AddAdmin("runtime-admin", "actor");
        a1.Ban("runtime-ban", "reason", null, "actor");

        // Second instance over the SAME state file: runtime mutations were persisted via SaveStateLocked.
        var a2 = new ServerAdminService(Options.Create(opts), new StubEnv(dir), NullLogger<ServerAdminService>.Instance);
        Assert.True(a2.IsAdmin("runtime-admin")); // survived restart
        Assert.True(a2.IsBanned("runtime-ban"));  // survived restart
        Assert.True(a2.IsAdmin("seed-admin"));    // still seeded
    }

    [Fact] // F078 expired ban auto-clears
    public void Ban_WithPastExpiry_IsNotActive()
    {
        var a = Admin(Svc.TempDir());
        a.Ban("a", "temp", DateTimeOffset.UtcNow.AddSeconds(-1), "actor"); // already expired
        Assert.False(a.IsBanned("a"));
    }

    [Fact] // F079 audit log append + tail
    public void Audit_AppendsAndTails()
    {
        var a = Admin(Svc.TempDir());
        a.AddAdmin("a", "actor");
        a.Ban("b", "reason", null, "actor");
        var tail = a.ReadAuditTail(50);
        Assert.NotEmpty(tail);
    }

    [Fact] // F077 snapshot reflects state
    public void Snapshot_ReflectsAdminsAndBans()
    {
        var a = Admin(Svc.TempDir());
        a.AddAdmin("a", "actor");
        a.Ban("b", "reason", null, "actor");
        var snap = a.GetSnapshot();
        Assert.Contains("a", snap.AdminAccountIds);
        Assert.Contains(snap.Bans, x => x.AccountId == "b");
    }

    [Fact] // B11 regression: the removed "let-me-in" backdoor must NOT authorize
    public void AdminAuth_RejectsLegacyBackdoorToken()
    {
        var opts = new AdminOptions { ApiToken = "real-secret", AllowLoopbackAdminWithoutToken = false };
        var ctx = HttpCtx("let-me-in");
        Assert.False(AdminAuth.IsAuthorized(ctx, opts)); // backdoor gone
        Assert.True(AdminAuth.IsAuthorized(HttpCtx("real-secret"), opts)); // real token works
        Assert.False(AdminAuth.IsAuthorized(HttpCtx("wrong"), opts));
    }

    private static Microsoft.AspNetCore.Http.HttpContext HttpCtx(string token)
    {
        var ctx = new Microsoft.AspNetCore.Http.DefaultHttpContext();
        ctx.Request.Headers[AdminAuth.TokenHeader] = token;
        return ctx;
    }
}

internal sealed class StubEnv : IWebHostEnvironment
{
    public StubEnv(string root) => ContentRootPath = root;
    public string ApplicationName { get; set; } = "tests";
    public IFileProvider ContentRootFileProvider { get; set; } = new NullFileProvider();
    public string ContentRootPath { get; set; }
    public string EnvironmentName { get; set; } = "Development";
    public string WebRootPath { get; set; } = "";
    public IFileProvider WebRootFileProvider { get; set; } = new NullFileProvider();
}
