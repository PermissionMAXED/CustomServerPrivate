using BapCustomServerMelon;
using Xunit;

namespace BapCustomServer.Tests;

// F159 — command-line config overrides. Every --bapcustom-* flag routes through TryGetArgValue
// (case-insensitive prefix match, trimmed value) + TryParseBool (full truthy/falsy spelling set).
// Pure logic from CustomServerMod, linked via MelonArgHelpers.cs. The argument-application loop
// (which writes MelonPreferences) needs MelonLoader, but the parsing kernel is the testable part.
public class MelonArgHelpersTests
{
    [Fact] // F159 — matching prefix yields the trimmed value
    public void TryGetArgValue_MatchesPrefix_ReturnsTrimmedValue()
    {
        Assert.True(MelonArgHelpers.TryGetArgValue("--bapcustom-host=  example.com  ", "--bapcustom-host=", out string? v));
        Assert.Equal("example.com", v);
    }

    [Fact] // F159 — prefix match is case-insensitive
    public void TryGetArgValue_CaseInsensitive()
    {
        Assert.True(MelonArgHelpers.TryGetArgValue("--BAPCUSTOM-HOST=x", "--bapcustom-host=", out string? v));
        Assert.Equal("x", v);
    }

    [Fact] // F159 — non-matching prefix returns false + null
    public void TryGetArgValue_NoMatch()
    {
        Assert.False(MelonArgHelpers.TryGetArgValue("--other-flag=y", "--bapcustom-host=", out string? v));
        Assert.Null(v);
    }

    [Fact] // F159 — empty value after prefix is allowed (clears a setting)
    public void TryGetArgValue_EmptyValue()
    {
        Assert.True(MelonArgHelpers.TryGetArgValue("--bapcustom-account-id=", "--bapcustom-account-id=", out string? v));
        Assert.Equal("", v);
    }

    [Theory] // F159 — truthy spellings
    [InlineData("true")]
    [InlineData("True")]
    [InlineData("1")]
    [InlineData("yes")]
    [InlineData("y")]
    [InlineData("on")]
    [InlineData("enabled")]
    public void TryParseBool_Truthy(string input)
    {
        Assert.True(MelonArgHelpers.TryParseBool(input, out bool result));
        Assert.True(result);
    }

    [Theory] // F159 — falsy spellings
    [InlineData("false")]
    [InlineData("0")]
    [InlineData("no")]
    [InlineData("n")]
    [InlineData("off")]
    [InlineData("disabled")]
    public void TryParseBool_Falsy(string input)
    {
        Assert.True(MelonArgHelpers.TryParseBool(input, out bool result));
        Assert.False(result);
    }

    [Theory] // F159 — unrecognized values are rejected (TryParse returns false)
    [InlineData("maybe")]
    [InlineData("2")]
    [InlineData("")]
    public void TryParseBool_Unrecognized_ReturnsFalse(string input)
    {
        Assert.False(MelonArgHelpers.TryParseBool(input, out _));
    }

    // ---- F160 ----
    [Theory] // F160 — any port-quad arg flags the process as the dedicated match host
    [InlineData("-httpport=7850")]
    [InlineData("--httpport=7850")]
    [InlineData("-wsport=7777")]
    [InlineData("-kcpport=7778")]
    [InlineData("-tcpport=7779")]
    [InlineData("--TCPPORT=7779")] // case-insensitive
    public void IsDedicated_DetectsPortQuadArgs(string arg)
    {
        Assert.True(MelonArgHelpers.IsDedicatedGameServerProcess(new[] { "-batchmode", arg }));
    }

    [Fact] // F160 — a plain client launch (no port args) is NOT dedicated
    public void IsDedicated_ClientLaunch_False()
    {
        Assert.False(MelonArgHelpers.IsDedicatedGameServerProcess(new[] { "--bapcustom-host=x", "-screen-width", "1920" }));
        Assert.False(MelonArgHelpers.IsDedicatedGameServerProcess(Array.Empty<string>()));
    }
}
