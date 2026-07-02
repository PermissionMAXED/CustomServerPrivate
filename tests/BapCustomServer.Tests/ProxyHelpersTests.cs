using BapCustomClientProxy;
using Xunit;

namespace BapCustomServer.Tests;

// F175 target resolution, F177 upstream URI building, F179 header sanitization, F180 socket-discovery rewrite.
public class ProxyHelpersTests
{
    [Theory] // F175 — bare host/ip gets http:// prefix; full URLs preserved
    [InlineData("1.2.3.4:5055", "http://1.2.3.4:5055/")]
    [InlineData("example.com", "http://example.com/")]
    [InlineData("https://example.com", "https://example.com/")]
    [InlineData("http://10.0.0.1:8080", "http://10.0.0.1:8080/")]
    public void ResolveTarget_NormalizesValidTargets(string input, string expected)
    {
        Uri? uri = ProxyHelpers.ResolveTarget(input);
        Assert.NotNull(uri);
        Assert.Equal(expected, uri!.ToString());
    }

    [Theory] // F175 — invalid/empty rejected
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    [InlineData("ftp://example.com")] // non-http scheme rejected
    [InlineData("ht!tp://bad")]
    public void ResolveTarget_RejectsInvalid(string? input)
    {
        Assert.Null(ProxyHelpers.ResolveTarget(input));
    }

    [Theory] // F177 — base path + request path combine without duplicate slashes
    [InlineData("/", "/api/load", "/api/load")]
    [InlineData("/prefix", "/api/load", "/prefix/api/load")]
    [InlineData("/prefix/", "/api/load", "/prefix/api/load")]
    [InlineData("/", "", "")]
    public void CombinePath_MergesCleanly(string basePath, string reqPath, string expected)
    {
        Assert.Equal(expected, ProxyHelpers.CombinePath(basePath, reqPath));
    }

    [Fact] // F177 — query string copied verbatim
    public void BuildUpstreamUri_PreservesPathAndQuery()
    {
        var target = new Uri("http://example.com:5055/");
        Uri uri = ProxyHelpers.BuildUpstreamUri(target, "/api/load", "?a=1&b=2");
        Assert.Equal("http://example.com:5055/api/load?a=1&b=2", uri.ToString());
    }

    [Theory] // F179 — Host and Sec-WebSocket-* are stripped; others pass
    [InlineData("Host", true)]
    [InlineData("host", true)]
    [InlineData("Sec-WebSocket-Key", true)]
    [InlineData("sec-websocket-version", true)]
    [InlineData("Authorization", false)]
    [InlineData("Content-Type", false)]
    public void ShouldSkipRequestHeader_DropsOnlyHostAndWebSocket(string header, bool skip)
    {
        Assert.Equal(skip, ProxyHelpers.ShouldSkipRequestHeader(header));
    }

    [Theory] // F180 — rewrite only for socket-discovery JSON responses
    [InlineData("/api/lobbies/socket", "application/json", true)]
    [InlineData("/api/lobbies/socket", null, true)]
    [InlineData("/api/socket", "text/json", true)]
    [InlineData("/api/load", "application/json", false)] // not a socket path
    [InlineData("/api/lobbies/socket", "text/html", false)] // not json
    public void ShouldRewriteSocketDiscovery_GatesCorrectly(string path, string? mediaType, bool expected)
    {
        Assert.Equal(expected, ProxyHelpers.ShouldRewriteSocketDiscovery(path, mediaType));
    }

    [Fact] // F180 — socketUrl rewritten to local proxy
    public void RewriteSocketDiscovery_ReplacesSocketUrl()
    {
        string body = "{\"socketUrl\":\"wss://remote.example.com/ws\",\"region\":\"us\"}";
        string rewritten = ProxyHelpers.RewriteSocketDiscovery(body);
        Assert.Contains(ProxyHelpers.LocalSocketUrl, rewritten);
        Assert.DoesNotContain("remote.example.com", rewritten);
        Assert.Contains("\"region\":\"us\"", rewritten); // other fields preserved
    }

    [Fact] // F180 — snake_case variant handled
    public void RewriteSocketDiscovery_ReplacesSocketUnderscoreUrl()
    {
        string body = "{\"socket_url\":\"wss://remote/ws\"}";
        Assert.Contains(ProxyHelpers.LocalSocketUrl, ProxyHelpers.RewriteSocketDiscovery(body));
    }

    [Fact] // F180 — non-object / non-JSON left untouched
    public void RewriteSocketDiscovery_LeavesNonObjectUntouched()
    {
        Assert.Equal("not json at all", ProxyHelpers.RewriteSocketDiscovery("not json at all"));
        Assert.Equal("[1,2,3]", ProxyHelpers.RewriteSocketDiscovery("[1,2,3]"));
    }
}
