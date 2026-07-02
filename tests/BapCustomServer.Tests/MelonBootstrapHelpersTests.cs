using System.Text;
using BapCustomServerMelon;
using Xunit;

namespace BapCustomServer.Tests;

// F161 — headless match-bootstrap TCP listener's hand-rolled HTTP/1.1 parser + router.
// Pure logic extracted to MelonBootstrapHelpers; the socket plumbing needs the game, but the
// parser (which must read Content-Length bodies, NOT chunked — the contract with F115) and the
// GET /status vs POST /setup-game|/add-teams|/queue-matched routing are the testable kernel.
public class MelonBootstrapHelpersTests
{
    private static byte[] Req(string raw) => Encoding.ASCII.GetBytes(raw);

    [Fact] // F161 — a complete GET /status request parses Ok with method/path/headerEnd
    public void Parse_GetStatus()
    {
        byte[] data = Req("GET /status HTTP/1.1\r\nHost: 127.0.0.1\r\n\r\n");
        var state = MelonBootstrapHelpers.TryParseHttpHead(data, data.Length, out string method, out string path, out int cl, out int headerEnd);
        Assert.Equal(MelonBootstrapHelpers.ParseState.Ok, state);
        Assert.Equal("GET", method);
        Assert.Equal("/status", path);
        Assert.Equal(0, cl);
        Assert.Equal(data.Length, headerEnd);
        Assert.Equal(MelonBootstrapHelpers.Route.Status, MelonBootstrapHelpers.Classify(method, path));
    }

    [Fact] // F161 — POST /setup-game with Content-Length parses and routes to AcceptPayload
    public void Parse_PostSetupGame_WithContentLength()
    {
        string body = "{\"gameId\":\"g1\"}";
        byte[] data = Req($"POST /setup-game HTTP/1.1\r\nContent-Type: application/json\r\nContent-Length: {body.Length}\r\n\r\n{body}");
        var state = MelonBootstrapHelpers.TryParseHttpHead(data, data.Length, out string method, out string path, out int cl, out int headerEnd);
        Assert.Equal(MelonBootstrapHelpers.ParseState.Ok, state);
        Assert.Equal("POST", method);
        Assert.Equal("/setup-game", path);
        Assert.Equal(body.Length, cl);  // F115 contract: Content-Length is read
        Assert.Equal(MelonBootstrapHelpers.Route.AcceptPayload, MelonBootstrapHelpers.Classify(method, path));
        // body is exactly what's after headerEnd
        Assert.Equal(body, Encoding.UTF8.GetString(data, headerEnd, cl));
    }

    [Theory] // F161 — all three bootstrap POST paths are accepted; trailing slash tolerated
    [InlineData("/setup-game")]
    [InlineData("/add-teams")]
    [InlineData("/queue-matched")]
    [InlineData("/setup-game/")] // trimmed to /setup-game
    public void Classify_AcceptsBootstrapPaths(string rawPath)
    {
        byte[] data = Req($"POST {rawPath} HTTP/1.1\r\nContent-Length: 0\r\n\r\n");
        MelonBootstrapHelpers.TryParseHttpHead(data, data.Length, out string method, out string path, out _, out _);
        Assert.Equal(MelonBootstrapHelpers.Route.AcceptPayload, MelonBootstrapHelpers.Classify(method, path));
    }

    [Fact] // F161 — unknown path / wrong verb => NotFound (the server gets a 404)
    public void Classify_UnknownAndWrongVerb()
    {
        Assert.Equal(MelonBootstrapHelpers.Route.NotFound, MelonBootstrapHelpers.Classify("POST", "/unknown"));
        Assert.Equal(MelonBootstrapHelpers.Route.NotFound, MelonBootstrapHelpers.Classify("GET", "/setup-game")); // wrong verb
        Assert.Equal(MelonBootstrapHelpers.Route.NotFound, MelonBootstrapHelpers.Classify("DELETE", "/status"));
    }

    [Fact] // F161 — query string is stripped from the path
    public void Parse_StripsQueryString()
    {
        byte[] data = Req("GET /status?foo=bar HTTP/1.1\r\n\r\n");
        MelonBootstrapHelpers.TryParseHttpHead(data, data.Length, out _, out string path, out _, out _);
        Assert.Equal("/status", path);
    }

    [Fact] // F161 — incomplete head (no CRLFCRLF yet) => NeedMoreData (keep reading the socket)
    public void Parse_IncompleteHead_NeedsMoreData()
    {
        byte[] data = Req("POST /setup-game HTTP/1.1\r\nContent-Length: 10\r\n"); // no blank line yet
        var state = MelonBootstrapHelpers.TryParseHttpHead(data, data.Length, out _, out _, out _, out _);
        Assert.Equal(MelonBootstrapHelpers.ParseState.NeedMoreData, state);
    }

    [Fact] // F161 — malformed request line => BadRequest (the server gets a 400)
    public void Parse_MalformedRequestLine_BadRequest()
    {
        byte[] data = Req("GARBAGE\r\n\r\n");
        var state = MelonBootstrapHelpers.TryParseHttpHead(data, data.Length, out _, out _, out _, out _);
        Assert.Equal(MelonBootstrapHelpers.ParseState.BadRequest, state);
    }

    [Fact] // F161 — Content-Length header is matched case-insensitively
    public void Parse_ContentLengthCaseInsensitive()
    {
        byte[] data = Req("POST /add-teams HTTP/1.1\r\ncontent-length: 42\r\n\r\n");
        MelonBootstrapHelpers.TryParseHttpHead(data, data.Length, out _, out _, out int cl, out _);
        Assert.Equal(42, cl);
    }
}
