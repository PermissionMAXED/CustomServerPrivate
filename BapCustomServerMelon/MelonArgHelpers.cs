namespace BapCustomServerMelon;

// Pure (Unity-free) command-line argument parsing kernel from CustomServerMod (F159).
// Every --bapcustom-* override flag routes through TryGetArgValue + TryParseBool, so testing
// these pins the parsing contract (case-insensitive prefix match, trimmed value, the full set
// of truthy/falsy boolean spellings) without loading MelonLoader. CustomServerMod delegates here.
internal static class MelonArgHelpers
{
    public static bool TryGetArgValue(string arg, string prefix, out string? value)
    {
        if (arg.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
        {
            value = arg[prefix.Length..].Trim();
            return true;
        }

        value = null;
        return false;
    }

    public static bool TryParseBool(string value, out bool result)
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

    // F160 — a process is the dedicated match host (not a player client) when launched with any
    // of the port-quad args. This gates whether the mod runs the proxy/UI/login (client) or the
    // headless bootstrap listener + game-network startup (host). Pure: the Application.isBatchMode
    // half of the detection needs Unity, but this arg-based half is the deterministic contract.
    public static bool IsDedicatedGameServerProcess(IEnumerable<string> args)
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
}
