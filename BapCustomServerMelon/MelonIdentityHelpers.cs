using System.Linq;

namespace BapCustomServerMelon;

// Pure (Unity-free) identity/config helpers extracted from CustomServerMod so the guest-name
// validation (F150) and INI token normalization (F148) can be unit-tested without MelonLoader.
// CustomServerMod delegates to these.
internal static class MelonIdentityHelpers
{
    // F150 — normalize a first-start guest display name: keep only letters/digits/_/-, cap at 18.
    public static string NormalizePlayerName(string value)
    {
        return new string((value ?? "")
            .Where(ch => char.IsLetterOrDigit(ch) || ch is '_' or '-')
            .Take(18)
            .ToArray());
    }

    // F150 — generate a stable-prefixed local guest account id, truncated to 19 chars.
    public static string GenerateLocalAccountId()
    {
        return $"custom-{System.Guid.NewGuid():N}"[..19];
    }

    // F148 — normalize an INI section/key token for case/punctuation-insensitive matching.
    public static string NormalizeIniToken(string value)
    {
        return new string((value ?? "")
            .Where(char.IsLetterOrDigit)
            .Select(char.ToLowerInvariant)
            .ToArray());
    }
}
