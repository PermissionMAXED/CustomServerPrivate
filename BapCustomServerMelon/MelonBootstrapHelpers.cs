using System.Text;

namespace BapCustomServerMelon;

// Pure (Unity-free) kernel of the in-game match-bootstrap TCP listener (F161). The listener
// hand-parses HTTP/1.1 (no chunked support — see the server's explicit Content-Length in F115)
// and routes GET /status + POST /setup-game|/add-teams|/queue-matched. Extracted so the parser
// and router are unit-testable without opening a real socket. CustomServerMod delegates to these.
internal static class MelonBootstrapHelpers
{
    public enum ParseState { NeedMoreData, Ok, BadRequest }

    public enum Route { Status, AcceptPayload, NotFound }

    // Parse the HTTP head from a buffer. Returns NeedMoreData until the CRLFCRLF boundary arrives,
    // BadRequest on a malformed request line, Ok with method/path/contentLength/headerEnd otherwise.
    public static ParseState TryParseHttpHead(
        byte[] data, int len,
        out string method, out string path, out int contentLength, out int headerEnd)
    {
        method = "";
        path = "/";
        contentLength = 0;
        headerEnd = -1;

        for (int i = 0; i + 3 < len; i++)
        {
            if (data[i] == 0x0D && data[i + 1] == 0x0A && data[i + 2] == 0x0D && data[i + 3] == 0x0A)
            {
                headerEnd = i + 4;
                break;
            }
        }
        if (headerEnd < 0)
        {
            return ParseState.NeedMoreData;
        }

        string headerText = Encoding.ASCII.GetString(data, 0, headerEnd);
        string[] lines = headerText.Split(new[] { "\r\n" }, StringSplitOptions.None);
        if (lines.Length == 0 || string.IsNullOrEmpty(lines[0]))
        {
            return ParseState.BadRequest;
        }

        string[] requestLine = lines[0].Split(' ');
        if (requestLine.Length < 3)
        {
            return ParseState.BadRequest;
        }

        method = requestLine[0];
        string rawPath = requestLine[1];
        int queryIndex = rawPath.IndexOf('?');
        if (queryIndex >= 0)
        {
            rawPath = rawPath.Substring(0, queryIndex);
        }
        path = rawPath.TrimEnd('/').ToLowerInvariant();
        if (string.IsNullOrWhiteSpace(path))
        {
            path = "/";
        }

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            if (string.IsNullOrEmpty(line)) continue;
            int colon = line.IndexOf(':');
            if (colon <= 0) continue;
            string name = line.Substring(0, colon).Trim();
            string value = line.Substring(colon + 1).Trim();
            if (string.Equals(name, "Content-Length", StringComparison.OrdinalIgnoreCase))
            {
                int.TryParse(value, out contentLength);
            }
        }

        return ParseState.Ok;
    }

    // Decide how to handle a parsed request: GET /status, POST to a known bootstrap path, or 404.
    public static Route Classify(string method, string path)
    {
        if (string.Equals(method, "GET", StringComparison.OrdinalIgnoreCase) && path == "/status")
        {
            return Route.Status;
        }
        if (string.Equals(method, "POST", StringComparison.OrdinalIgnoreCase) &&
            (path == "/setup-game" || path == "/add-teams" || path == "/queue-matched"))
        {
            return Route.AcceptPayload;
        }
        return Route.NotFound;
    }
}
