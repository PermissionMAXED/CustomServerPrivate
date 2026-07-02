namespace BapAdminMelon;

internal sealed record AdminModSettings(
    string IniPath,
    string Host,
    int Port,
    string AccountId,
    string Username,
    string? Token,
    bool Enabled)
{
    private const string IniFileName = "BapCustomServer.ini";
    private const string AppDataFolderName = "BAPBAPBATTLEROYALE";

    public static AdminModSettings Load(string[] args)
    {
        string path = ResolveIniPath(args);
        Dictionary<string, Dictionary<string, string>> sections = ReadIni(path);

        string host = Read(sections, "Server", "Host", "127.0.0.1");
        int port = ReadInt(sections, "Server", "Port", 5055);
        string accountId = Read(sections, "Identity", "AccountId", "");
        string username = Read(sections, "Identity", "Username", "");
        string? token = ReadOptional(sections, "Admin", "Token");
        bool enabled = ReadBool(sections, "Admin", "Enabled", true);

        return new AdminModSettings(path, NormalizeHost(host), Math.Clamp(port, 1, 65535), accountId, username, token, enabled);
    }

    private static string ResolveIniPath(string[] args)
    {
        const string prefix = "--bapcustom-config=";
        foreach (string arg in args)
        {
            if (arg.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            {
                string requested = arg.Substring(prefix.Length).Trim().Trim('"');
                if (!string.IsNullOrWhiteSpace(requested)) return requested;
            }
        }

        string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        return Path.Combine(appData, AppDataFolderName, IniFileName);
    }

    private static Dictionary<string, Dictionary<string, string>> ReadIni(string path)
    {
        var result = new Dictionary<string, Dictionary<string, string>>(StringComparer.OrdinalIgnoreCase);
        if (!File.Exists(path)) return result;

        string section = "";
        foreach (string raw in File.ReadLines(path))
        {
            string line = raw.Trim();
            if (line.Length == 0 || line.StartsWith(";") || line.StartsWith("#")) continue;
            if (line.StartsWith("[") && line.EndsWith("]"))
            {
                section = line[1..^1].Trim();
                continue;
            }

            int equals = line.IndexOf('=');
            if (equals <= 0 || string.IsNullOrWhiteSpace(section)) continue;
            if (!result.TryGetValue(section, out Dictionary<string, string>? values))
            {
                values = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                result[section] = values;
            }

            values[line[..equals].Trim()] = line[(equals + 1)..].Trim().Trim('"');
        }

        return result;
    }

    private static string Read(Dictionary<string, Dictionary<string, string>> sections, string section, string key, string fallback) =>
        ReadOptional(sections, section, key) ?? fallback;

    private static string? ReadOptional(Dictionary<string, Dictionary<string, string>> sections, string section, string key) =>
        sections.TryGetValue(section, out Dictionary<string, string>? values) && values.TryGetValue(key, out string? value) && !string.IsNullOrWhiteSpace(value)
            ? value.Trim()
            : null;

    private static int ReadInt(Dictionary<string, Dictionary<string, string>> sections, string section, string key, int fallback) =>
        int.TryParse(ReadOptional(sections, section, key), out int value) ? value : fallback;

    private static bool ReadBool(Dictionary<string, Dictionary<string, string>> sections, string section, string key, bool fallback) =>
        bool.TryParse(ReadOptional(sections, section, key), out bool value) ? value : fallback;

    private static string NormalizeHost(string host) => host.Trim().TrimEnd('/').Replace("http://", "", StringComparison.OrdinalIgnoreCase).Replace("https://", "", StringComparison.OrdinalIgnoreCase);
}
