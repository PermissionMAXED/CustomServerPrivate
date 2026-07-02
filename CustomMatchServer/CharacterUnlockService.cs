using Microsoft.Extensions.Options;

namespace BapCustomServer;

public sealed class CharacterListingState
{
    public int CharId { get; init; }
    public string ListingId { get; init; } = "";
    public int Price { get; init; }
    public bool Owned { get; init; }
    public int CharTokenAssetId { get; init; }
    public int[] UnlockAssetIds { get; init; } = [];
    public int DefaultSkinAssetId { get; init; }
}

public sealed class CharacterUnlockService
{
    private readonly CustomServerOptions _options;
    private readonly PlayerOverridesService _overrides;

    public CharacterUnlockService(IOptions<CustomServerOptions> options, PlayerOverridesService overrides)
    {
        _options = options.Value;
        _overrides = overrides;
    }

    public CharacterUnlockOptions Options => _options.CharacterUnlocks;

    public int CharTokenAssetId => Options.CharTokenAssetId > 0
        ? Options.CharTokenAssetId
        : _options.Unlocks.CharTokenAssetId;

    public int[] GetRosterCharacterIds(string accountId)
    {
        int[] ids = _overrides.GetEnabledCharacterIds(accountId);
        if (ids.Length == 0)
        {
            ids = _options.Roster?.HasCustomization == true
                ? _options.Roster.BuildEnabledCharIds()
                : _options.MatchDefaults.AvailableCharacters;
        }

        return ids
            .Where(CharacterCatalog.IsKnownId)
            .Distinct()
            .OrderBy(id => id)
            .DefaultIfEmpty(CharacterCatalog.AllIds[0])
            .ToArray();
    }

    public int[] GetInitiallyUnlockedCharacterIds()
    {
        int[] ids = Options.InitiallyUnlockedCharacterIds ?? [];
        return ids
            .Where(CharacterCatalog.IsKnownId)
            .Distinct()
            .OrderBy(id => id)
            .DefaultIfEmpty(0)
            .ToArray();
    }

    public int GetPrice(int charId)
    {
        if (!CharacterCatalog.IsKnownId(charId)) return Math.Max(0, Options.DefaultPrice);

        CharacterPriceEntry? entry = Options.Prices?
            .LastOrDefault(p => p.CharId == charId);
        return Math.Max(0, entry?.Price ?? Options.DefaultPrice);
    }

    public static string ListingIdFor(int charId) => $"custom-char-{charId}";

    public static int[] UnlockAssetIdsFor(int charId) => CharacterCatalog.IsKnownId(charId)
        ? [100000 + charId, charId]
        : [];

    public bool IsInitiallyUnlocked(int charId) => GetInitiallyUnlockedCharacterIds().Contains(charId);

    public bool IsCharacterOwned(string accountId, int charId, EconomyService economyService)
    {
        if (!CharacterCatalog.IsKnownId(charId)) return false;
        PlayerOverrideEntry effectiveOverride = _overrides.GetEffective(accountId);
        if (Options.UnlockAllCharacters) return true;
        if (effectiveOverride.UnlockEverything == true) return true;
        if (IsInitiallyUnlocked(charId)) return true;
        if (effectiveOverride.ExtraOwnedAssetIds?.Intersect(UnlockAssetIdsFor(charId)).Any() == true) return true;
        return economyService.HasAnyAsset(accountId, UnlockAssetIdsFor(charId));
    }

    public CharacterListingState BuildListingState(string accountId, int charId, EconomyService economyService)
    {
        return new CharacterListingState
        {
            CharId = charId,
            ListingId = ListingIdFor(charId),
            Price = GetPrice(charId),
            Owned = IsCharacterOwned(accountId, charId, economyService),
            CharTokenAssetId = CharTokenAssetId,
            UnlockAssetIds = UnlockAssetIdsFor(charId),
            DefaultSkinAssetId = CharacterCatalog.GetDefaultSkinAssetId(charId)
        };
    }

    public int ResolveSelectableCharacter(string accountId, int requestedCharId, int? currentCharId, EconomyService economyService)
    {
        int[] roster = GetRosterCharacterIds(accountId);

        bool IsSelectable(int charId) =>
            CharacterCatalog.IsKnownId(charId) &&
            roster.Contains(charId) &&
            IsCharacterOwned(accountId, charId, economyService);

        if (IsSelectable(requestedCharId)) return requestedCharId;
        if (currentCharId.HasValue && IsSelectable(currentCharId.Value)) return currentCharId.Value;

        int ownedRoster = roster.FirstOrDefault(charId => IsSelectable(charId), int.MinValue);
        if (ownedRoster != int.MinValue) return ownedRoster;

        int initial = GetInitiallyUnlockedCharacterIds().FirstOrDefault(charId => roster.Contains(charId), int.MinValue);
        if (initial != int.MinValue) return initial;

        return roster.FirstOrDefault(CharacterCatalog.IsKnownId, CharacterCatalog.AllIds[0]);
    }

    public bool TryParseListingId(string? listingId, out int charId)
    {
        charId = -1;
        if (string.IsNullOrWhiteSpace(listingId)) return false;
        string value = listingId.Trim();
        const string prefix = "custom-char-";
        if (value.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
        {
            value = value[prefix.Length..];
        }
        return int.TryParse(value, out charId) && CharacterCatalog.IsKnownId(charId);
    }
}
