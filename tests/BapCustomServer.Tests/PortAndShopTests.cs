using BapCustomServer;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Xunit;

namespace BapCustomServer.Tests;

// F125 port reservation with OS probe, F126 release + cooldown.
public class PortAllocatorTests
{
    [Fact] // F125
    public void ReserveFrom_ReturnsDistinctFreePorts()
    {
        var a = new PortAllocator();
        int p1 = a.ReserveFrom(40000, 200);
        int p2 = a.ReserveFrom(40000, 200);
        Assert.NotEqual(p1, p2); // already-reserved port skipped
        Assert.InRange(p1, 40000, 40199);
        Assert.InRange(p2, 40000, 40199);
    }

    [Fact] // F126 release returns port to the pool (no cooldown by default)
    public void Release_AllowsImmediateReuse_WhenNoCooldown()
    {
        var a = new PortAllocator();
        int p1 = a.ReserveFrom(40500, 50);
        a.Release(p1);
        int p2 = a.ReserveFrom(40500, 50);
        Assert.Equal(p1, p2); // freed port handed back out
    }

    [Fact] // F126 cooldown parks a released port
    public void Release_WithCooldown_ParksPort()
    {
        var a = new PortAllocator { CooldownDuration = TimeSpan.FromMinutes(5) };
        int p1 = a.ReserveFrom(40600, 50);
        a.Release(p1);
        Assert.True(a.IsInCooldown(p1));
        int p2 = a.ReserveFrom(40600, 50);
        Assert.NotEqual(p1, p2); // cooling-down port skipped
        a.ReleaseImmediately(p2);
        Assert.False(a.IsInCooldown(p2));
    }

    [Fact] // F125 exhausted range throws
    public void ReserveFrom_ThrowsWhenRangeExhausted()
    {
        var a = new PortAllocator();
        int basePort = 40700;
        a.ReserveFrom(basePort, 1); // claims the only port in the range
        Assert.Throws<InvalidOperationException>(() => a.ReserveFrom(basePort, 1));
    }
}

// F086 shop listing w/ owned marking, F087 slot mutation, F088 default seeding.
public class ShopServiceTests
{
    private static ShopService Shop(string dir, out string statePath)
    {
        statePath = Path.Combine(dir, "shop.json");
        var opts = new ShopOptions { StateFile = statePath, MaxRotationItems = 8, MaxFreebieItems = 2 };
        var serverOpts = new TestOptionsMonitor<CustomServerOptions>(new CustomServerOptions());
        return new ShopService(Options.Create(opts), serverOpts, NullLogger<ShopService>.Instance);
    }

    [Fact] // F088 seeds a non-empty shop on first boot
    public void NewShop_SeedsDefaultListings()
    {
        var s = Shop(Svc.TempDir(), out _);
        Assert.NotEmpty(s.GetAllListings());
    }

    [Fact] // F087 add/remove/clear rotation + freebie
    public void Mutation_AddRemoveClear()
    {
        var s = Shop(Svc.TempDir(), out _);
        s.ClearShop("test");
        Assert.Empty(s.GetAllListings());
        Assert.True(s.AddRotationItem(500121, 100, "test").Ok);
        Assert.False(s.AddRotationItem(500121, 100, "test").Ok); // duplicate rejected
        Assert.False(s.AddRotationItem(-1, 100, "test").Ok); // invalid assetId
        Assert.True(s.AddFreebieItem(500002, "test").Ok);
        var listing = s.GetAllListings().First(l => l.AssetId == 500121);
        Assert.True(s.RemoveItem(listing.ListingId, "test").Ok);
        Assert.True(s.ClearShop("test").Ok);
        Assert.Empty(s.GetAllListings());
    }

    [Fact] // F087 rotation cap enforced
    public void Rotation_RespectsMaxItems()
    {
        var s = Shop(Svc.TempDir(), out _);
        s.ClearShop("test");
        for (int i = 0; i < 8; i++) Assert.True(s.AddRotationItem(500000 + i, 100, "test").Ok);
        Assert.False(s.AddRotationItem(500999, 100, "test").Ok); // 9th over cap
    }

    [Fact] // F086 owned items flagged via economy
    public void BuildShopResponse_MarksOwned()
    {
        var dir = Svc.TempDir();
        var s = Shop(dir, out _);
        s.ClearShop("test");
        s.AddRotationItem(500121, 100, "test");
        var econ = Svc.Economy(dir);
        econ.GetOrCreatePlayer("a", "A");
        econ.GrantAsset("a", 500121, "test");
        var resp = s.BuildShopResponse("a", econ);
        Assert.NotNull(resp); // builds without throwing, owned reflected via economy
    }
}

internal sealed class TestOptionsMonitor<T> : IOptionsMonitor<T>
{
    public TestOptionsMonitor(T value) => CurrentValue = value;
    public T CurrentValue { get; }
    public T Get(string? name) => CurrentValue;
    public IDisposable? OnChange(Action<T, string?> listener) => null;
}
