using BapCustomServerMelon;
using Xunit;

namespace BapCustomServer.Tests;

// F150 guest-name validation + account-id generation, F148 INI token normalization.
// Pure (Unity-free) logic from CustomServerMod, linked via MelonIdentityHelpers.cs.
public class MelonIdentityHelpersTests
{
    [Theory] // F150 — keep letters/digits/_/-, strip everything else, cap at 18
    [InlineData("Valid_Name-1", "Valid_Name-1")]
    [InlineData("bad name!@#", "badname")]
    [InlineData("  spaces  ", "spaces")]
    [InlineData("emoji🎮name", "emojiname")]
    public void NormalizePlayerName_StripsInvalidChars(string input, string expected)
    {
        Assert.Equal(expected, MelonIdentityHelpers.NormalizePlayerName(input));
    }

    [Fact] // F150 — caps at 18 chars
    public void NormalizePlayerName_CapsAt18()
    {
        string result = MelonIdentityHelpers.NormalizePlayerName(new string('a', 50));
        Assert.Equal(18, result.Length);
    }

    [Fact] // F150 — null/empty tolerated
    public void NormalizePlayerName_HandlesNullEmpty()
    {
        Assert.Equal("", MelonIdentityHelpers.NormalizePlayerName(null!));
        Assert.Equal("", MelonIdentityHelpers.NormalizePlayerName(""));
    }

    [Fact] // F150 — generated account id is custom-prefixed and <= 19 chars (matches the buffer the game primes)
    public void GenerateLocalAccountId_HasStablePrefixAndLength()
    {
        string id = MelonIdentityHelpers.GenerateLocalAccountId();
        Assert.StartsWith("custom-", id);
        Assert.Equal(19, id.Length);
        Assert.NotEqual(id, MelonIdentityHelpers.GenerateLocalAccountId()); // unique per call
    }

    [Theory] // F148 — INI tokens compared case/punctuation-insensitively
    [InlineData("Server Port", "serverport")]
    [InlineData("Local-Proxy_Port", "localproxyport")]
    [InlineData("AccountId", "accountid")]
    [InlineData("USE HTTPS", "usehttps")]
    public void NormalizeIniToken_LowercasesAndStripsPunctuation(string input, string expected)
    {
        Assert.Equal(expected, MelonIdentityHelpers.NormalizeIniToken(input));
    }

    [Fact] // F148 — aliasing: different spellings of the same key normalize equal
    public void NormalizeIniToken_AliasesConverge()
    {
        Assert.Equal(
            MelonIdentityHelpers.NormalizeIniToken("Local Proxy Port"),
            MelonIdentityHelpers.NormalizeIniToken("localProxyPort"));
    }
}
