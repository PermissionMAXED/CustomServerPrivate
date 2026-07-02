using Microsoft.Extensions.Options;
using System.Globalization;
using System.Text;
using System.Text.Json;

namespace BapCustomServer;

public sealed class ShopOptions
{
    public string StateFile { get; set; } = "data/shop-state.json";
    public int MaxRotationItems { get; set; } = 8;
    public int MaxFreebieItems { get; set; } = 2;
}

public sealed class ShopListing
{
    public string ListingId { get; set; } = "";
    public int AssetId { get; set; }
    public int Price { get; set; }
    public string Category { get; set; } = "";
    public DateTimeOffset AddedUtc { get; set; }
    public string AddedBy { get; set; } = "";
}

public sealed class ShopStateDocument
{
    public List<ShopListing> RotationListings { get; set; } = [];
    public List<ShopListing> FreebieListings { get; set; } = [];
    public string DropEndDate { get; set; } = "";
    public int DropId { get; set; } = 1;
}

public sealed record ShopMutationResult(bool Ok, string Message, string? ListingId = null);

public sealed class ShopService
{
    private readonly SemaphoreSlim _lock = new(1, 1);
    private readonly string _shopBuildTimestamp = DateTimeOffset.UtcNow.ToString("o");
    private readonly string _statePath;
    private readonly ShopOptions _options;
    private readonly IOptionsMonitor<CustomServerOptions> _serverOptions;
    private readonly ILogger<ShopService> _logger;

    private ShopStateDocument _state = new();

    public ShopService(
        IOptions<ShopOptions> options,
        IOptionsMonitor<CustomServerOptions> serverOptions,
        ILogger<ShopService> logger)
    {
        _options = options.Value;
        _serverOptions = serverOptions;
        _logger = logger;
        _statePath = ResolvePath(_options.StateFile);
        LoadState();
        SeedDefaultListingsIfEmpty();
    }

    private void SeedDefaultListingsIfEmpty()
    {
        if (_state.RotationListings.Count > 0 || _state.FreebieListings.Count > 0)
        {
            return;
        }

        // === AMP-driven static slots (preferred when configured) ===
        // CustomServerOptions.ShopSlots exposes Slot1/Slot2/Slot3 + Freebie via the AMP UI.
        // When AnySlotConfigured is true we replace the built-in seed with the operator's choices.
        var slots = _serverOptions.CurrentValue.ShopSlots;
        if (slots.AnySlotConfigured)
        {
            SeedFromConfiguredSlots(slots);
            return;
        }

        // Diverse rotation: skins, banners, emotes - to demonstrate the full shop UI.
        // Asset id ranges (BAPBAP source):
        //   300000+  = Skins        (SkinData.assetSkinOffset)
        //   400000+  = Emotes       (EmoteData.assetEmoteOffset)
        //   500000+  = Banners      (PlayerBannerData.assetPlayerBannerOffset)
        //   600000+  = MasteryBadge
        //   700000+  = Tombstone
        // Conservative seed: only banner asset IDs known to exist in BAPBAP's content DB.
        // Banner 500121 was confirmed valid (default user banner). Banners are safer than skins
        // because they don't need character-specific lookup in the locker UI.
        var rotationSeed = new (int assetId, int price, string category)[]
        {
            (500121,  50, "banner"),  // confirmed safe
            (500001, 100, "banner"),
            (500005, 150, "banner"),
            (500010, 200, "banner"),
        };

        foreach (var (assetId, price, category) in rotationSeed)
        {
            _state.RotationListings.Add(new ShopListing
            {
                ListingId = $"seed-rotation-{assetId}",
                AssetId = assetId,
                Price = price,
                Category = category,
                AddedUtc = DateTimeOffset.UtcNow,
                AddedBy = "system-seed"
            });
        }

        // 1 free banner so user can equip without spending gold
        var freebieSeed = new (int assetId, string category)[]
        {
            (500002, "banner"),
        };

        foreach (var (assetId, category) in freebieSeed)
        {
            _state.FreebieListings.Add(new ShopListing
            {
                ListingId = $"seed-freebie-{assetId}",
                AssetId = assetId,
                Price = 0,
                Category = category,
                AddedUtc = DateTimeOffset.UtcNow,
                AddedBy = "system-seed"
            });
        }

        _state.DropEndDate = DateTimeOffset.UtcNow.AddDays(7).ToString("yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture);
        SaveState();
        _logger.LogInformation("Seeded shop with default listings: {Rotation} rotation, {Freebie} freebie.",
            _state.RotationListings.Count, _state.FreebieListings.Count);
    }

    /// <summary>
    /// Build rotation + freebie listings from CustomServerOptions.ShopSlots.
    /// AssetId &lt;= 0 slots are skipped silently (operator chose to leave them empty).
    /// Categories are derived from BAPBAP's asset id ranges via <see cref="CategorizeAsset"/>.
    /// </summary>
    private void SeedFromConfiguredSlots(ShopSlotOptions slots)
    {
        AddRotationSlot(1, slots.Slot1AssetId, slots.Slot1Price);
        AddRotationSlot(2, slots.Slot2AssetId, slots.Slot2Price);
        AddRotationSlot(3, slots.Slot3AssetId, slots.Slot3Price);

        if (slots.FreebieAssetId > 0)
        {
            _state.FreebieListings.Add(new ShopListing
            {
                ListingId = $"amp-freebie-{slots.FreebieAssetId}",
                AssetId = slots.FreebieAssetId,
                Price = 0,
                Category = CategorizeAsset(slots.FreebieAssetId),
                AddedUtc = DateTimeOffset.UtcNow,
                AddedBy = "amp-config"
            });
        }

        _state.DropEndDate = DateTimeOffset.UtcNow.AddDays(7).ToString("yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture);
        SaveState();
        _logger.LogInformation(
            "Seeded shop from AMP ShopSlots: {Rotation} rotation, {Freebie} freebie.",
            _state.RotationListings.Count, _state.FreebieListings.Count);
    }

    private void AddRotationSlot(int slotNumber, int assetId, int price)
    {
        if (assetId <= 0) return;
        if (price < 0) price = 0;

        _state.RotationListings.Add(new ShopListing
        {
            ListingId = $"amp-slot{slotNumber}-{assetId}",
            AssetId = assetId,
            Price = price,
            Category = CategorizeAsset(assetId),
            AddedUtc = DateTimeOffset.UtcNow,
            AddedBy = "amp-config"
        });
    }

    /// <summary>
    /// Map a BAPBAP asset id to its content category. Mirrors the offsets used by the
    /// game's *Data.assetXxxOffset constants so the shop UI gets the right tab/icon.
    /// </summary>
    private static string CategorizeAsset(int assetId)
    {
        if (assetId >= 700000) return "tombstone";
        if (assetId >= 600000) return "masterybadge";
        if (assetId >= 500000) return "banner";
        if (assetId >= 400000) return "emote";
        if (assetId >= 300000) return "skin";
        return "asset";
    }

    // === Public API ===

    public object BuildShopResponse(string? accountId = null, EconomyService? economy = null, PlayerShopOverride? playerShop = null)
    {
        _lock.Wait();
        try
        {
            // Get user's owned asset IDs to mark already-purchased items
            HashSet<int> ownedAssets = new();
            if (!string.IsNullOrWhiteSpace(accountId) && economy != null)
            {
                try { ownedAssets = new HashSet<int>(economy.GetOwnedAssets(accountId)); } catch { }
            }

            // Wire DTO BAPBAP.Network.ShopResponse fields:
            // freebieListings, rotationListings, consumableListings, currentDropRefreshes, maxDropRefreshes.
            // Per-listing wire shape: { listingId, costs, rewards, purchases }.
            // purchases > 0 marks an item as already-claimed/bought - UI hides the buy button.

            // --- Global freebie listings ---
            var freebieListings = _state.FreebieListings.Select(l => new
            {
                listingId = l.ListingId,
                costs = Array.Empty<object>(),
                rewards = new[] { new { assetId = l.AssetId, amount = 1 } },
                purchases = ownedAssets.Contains(l.AssetId) ? 1 : 0
            }).ToArray();

            // --- Rotation listings: global + per-player override ---
            var rotationListTemplate = _state.RotationListings.Select(l => new
            {
                listingId = l.ListingId,
                costs = new[] { new { assetId = 0, amount = l.Price } },
                rewards = new[] { new { assetId = l.AssetId, amount = 1 } },
                purchases = ownedAssets.Contains(l.AssetId) ? 1 : 0
            });

            var rotationListings = new List<object>();
            if (playerShop is not { OverrideGlobal: true })
            {
                // Include global shop items (unless overridden)
                foreach (var item in rotationListTemplate)
                    rotationListings.Add(item);
            }

            // Merge per-player custom shop items
            if (playerShop?.Items is { Length: > 0 })
            {
                foreach (var item in playerShop.Items)
                {
                    string lid = !string.IsNullOrWhiteSpace(item.ListingId)
                        ? item.ListingId
                        : $"player-{item.AssetId}";
                    rotationListings.Add(new
                    {
                        listingId = lid,
                        costs = new[] { new { assetId = 0, amount = item.Price } },
                        rewards = new[] { new { assetId = item.AssetId, amount = 1 } },
                        purchases = ownedAssets.Contains(item.AssetId) ? 1 : 0
                    });
                }
            }

            return new
            {
                // Use a stable timestamp per server boot. The client's PlayerPrefs check
                // compares this string; if it changes every call the UI keeps re-fetching.
                timestamp = _shopBuildTimestamp,
                freebieListings = freebieListings,
                rotationListings = rotationListings.ToArray(),
                consumableListings = new[]
                {
                    new
                    {
                        listingId = "rotation-refresh",
                        costs = new[] { new { assetId = 0, amount = 100 } },
                        rewards = Array.Empty<object>(),
                        purchases = 0
                    }
                },
                dropId = _state.DropId,
                dropEndDate = string.IsNullOrWhiteSpace(_state.DropEndDate)
                    ? DateTimeOffset.UtcNow.AddDays(7).ToString("yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture)
                    : _state.DropEndDate,
                currentDropRefreshes = 0,
                maxDropRefreshes = 5
            };
        }
        finally
        {
            _lock.Release();
        }
    }

    public ShopMutationResult AddRotationItem(int assetId, int price, string actor)
    {
        if (assetId <= 0)
            return new ShopMutationResult(false, "Invalid asset ID.");

        if (price < 0)
            return new ShopMutationResult(false, "Price cannot be negative.");

        _lock.Wait();
        try
        {
            if (_state.RotationListings.Count >= _options.MaxRotationItems)
                return new ShopMutationResult(false, $"Rotation is full (max {_options.MaxRotationItems} items).");

            string listingId = $"shop-rotation-{assetId}";

            bool alreadyExists = _state.RotationListings.Any(l => l.AssetId == assetId) ||
                                 _state.FreebieListings.Any(l => l.AssetId == assetId);
            if (alreadyExists)
                return new ShopMutationResult(false, $"Asset {assetId} is already in the shop.");

            var listing = new ShopListing
            {
                ListingId = listingId,
                AssetId = assetId,
                Price = price,
                Category = "rotation",
                AddedUtc = DateTimeOffset.UtcNow,
                AddedBy = actor
            };

            _state.RotationListings.Add(listing);
            SaveState();

            _logger.LogInformation("Shop rotation item added: AssetId={AssetId}, Price={Price}, By={Actor}",
                assetId, price, actor);

            return new ShopMutationResult(true, $"Added asset {assetId} to rotation at {price} gold.", listingId);
        }
        finally
        {
            _lock.Release();
        }
    }

    public ShopMutationResult AddFreebieItem(int assetId, string actor)
    {
        if (assetId <= 0)
            return new ShopMutationResult(false, "Invalid asset ID.");

        _lock.Wait();
        try
        {
            if (_state.FreebieListings.Count >= _options.MaxFreebieItems)
                return new ShopMutationResult(false, $"Freebie slots are full (max {_options.MaxFreebieItems} items).");

            string listingId = $"shop-freebie-{assetId}";

            bool alreadyExists = _state.RotationListings.Any(l => l.AssetId == assetId) ||
                                 _state.FreebieListings.Any(l => l.AssetId == assetId);
            if (alreadyExists)
                return new ShopMutationResult(false, $"Asset {assetId} is already in the shop.");

            var listing = new ShopListing
            {
                ListingId = listingId,
                AssetId = assetId,
                Price = 0,
                Category = "freebie",
                AddedUtc = DateTimeOffset.UtcNow,
                AddedBy = actor
            };

            _state.FreebieListings.Add(listing);
            SaveState();

            _logger.LogInformation("Shop freebie item added: AssetId={AssetId}, By={Actor}", assetId, actor);

            return new ShopMutationResult(true, $"Added asset {assetId} as a freebie.", listingId);
        }
        finally
        {
            _lock.Release();
        }
    }

    public ShopMutationResult RemoveItem(string listingId, string actor)
    {
        if (string.IsNullOrWhiteSpace(listingId))
            return new ShopMutationResult(false, "Invalid listing ID.");

        _lock.Wait();
        try
        {
            ShopListing? rotationItem = _state.RotationListings
                .FirstOrDefault(l => string.Equals(l.ListingId, listingId, StringComparison.OrdinalIgnoreCase));

            if (rotationItem is not null)
            {
                _state.RotationListings.Remove(rotationItem);
                SaveState();
                _logger.LogInformation("Shop rotation item removed: {ListingId}, By={Actor}", listingId, actor);
                return new ShopMutationResult(true, $"Removed listing '{listingId}' from rotation.", listingId);
            }

            ShopListing? freebieItem = _state.FreebieListings
                .FirstOrDefault(l => string.Equals(l.ListingId, listingId, StringComparison.OrdinalIgnoreCase));

            if (freebieItem is not null)
            {
                _state.FreebieListings.Remove(freebieItem);
                SaveState();
                _logger.LogInformation("Shop freebie item removed: {ListingId}, By={Actor}", listingId, actor);
                return new ShopMutationResult(true, $"Removed listing '{listingId}' from freebies.", listingId);
            }

            return new ShopMutationResult(false, $"Listing '{listingId}' not found.");
        }
        finally
        {
            _lock.Release();
        }
    }

    public ShopMutationResult ClearShop(string actor)
    {
        _lock.Wait();
        try
        {
            int totalRemoved = _state.RotationListings.Count + _state.FreebieListings.Count;
            _state.RotationListings.Clear();
            _state.FreebieListings.Clear();
            SaveState();

            _logger.LogInformation("Shop cleared by {Actor}. Removed {Count} items.", actor, totalRemoved);
            return new ShopMutationResult(true, $"Shop cleared. Removed {totalRemoved} items.");
        }
        finally
        {
            _lock.Release();
        }
    }

    public void SetDropEndDate(string endDate, string actor)
    {
        _lock.Wait();
        try
        {
            _state.DropEndDate = endDate;
            SaveState();
            _logger.LogInformation("Shop drop end date set to '{EndDate}' by {Actor}.", endDate, actor);
        }
        finally
        {
            _lock.Release();
        }
    }

    public ShopListing? GetListing(string listingId)
    {
        if (string.IsNullOrWhiteSpace(listingId)) return null;

        _lock.Wait();
        try
        {
            return _state.RotationListings
                       .FirstOrDefault(l => string.Equals(l.ListingId, listingId, StringComparison.OrdinalIgnoreCase))
                   ?? _state.FreebieListings
                       .FirstOrDefault(l => string.Equals(l.ListingId, listingId, StringComparison.OrdinalIgnoreCase));
        }
        finally
        {
            _lock.Release();
        }
    }

    public ShopListing[] GetAllListings()
    {
        _lock.Wait();
        try
        {
            return _state.RotationListings
                .Concat(_state.FreebieListings)
                .ToArray();
        }
        finally
        {
            _lock.Release();
        }
    }

    // === Private Helpers ===

    private void LoadState()
    {
        try
        {
            if (!File.Exists(_statePath))
            {
                _logger.LogInformation("Shop state file not found at {Path}. Starting fresh.", _statePath);
                return;
            }

            string json = File.ReadAllText(_statePath, Encoding.UTF8);
            ShopStateDocument? loaded = JsonSerializer.Deserialize<ShopStateDocument>(json, JsonContract.Options);
            if (loaded is not null)
            {
                _state = loaded;
                _logger.LogInformation(
                    "Loaded shop state: {RotationCount} rotation items, {FreebieCount} freebie items, DropId={DropId}.",
                    _state.RotationListings.Count, _state.FreebieListings.Count, _state.DropId);
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Could not load shop state from {Path}. Starting fresh.", _statePath);
            _state = new ShopStateDocument();
        }
    }

    private void SaveState()
    {
        try
        {
            string? directory = Path.GetDirectoryName(_statePath);
            if (!string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string json = JsonSerializer.Serialize(_state, JsonContract.PrettyOptions);
            string tmpPath = _statePath + ".tmp";
            File.WriteAllText(tmpPath, json, Encoding.UTF8);
            File.Move(tmpPath, _statePath, overwrite: true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to save shop state to {Path}.", _statePath);
        }
    }

    private static string ResolvePath(string path)
    {
        if (Path.IsPathRooted(path))
        {
            return Path.GetFullPath(path);
        }

        return Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), path));
    }
}
