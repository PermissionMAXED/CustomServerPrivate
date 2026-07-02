using System.Reflection;
using BapCustomServer;
using Xunit;

namespace BapCustomServer.Tests;

// F052 — event normalization/dispatch. NormalizeEvent maps the many casings/namespaces
// client builds emit (UPPER_SNAKE, colon-namespaced lobbies:join, lowercase) onto canonical
// event names, so protocol drift between client versions doesn't break the lobby flow.
public class EventNormalizationTests
{
    private static string Normalize(string evt)
    {
        MethodInfo mi = typeof(LobbyService).GetMethod("NormalizeEvent", BindingFlags.NonPublic | BindingFlags.Static)
            ?? throw new InvalidOperationException("NormalizeEvent not found (renamed?)");
        return (string)mi.Invoke(null, new object[] { evt })!;
    }

    [Theory] // colon-namespaced + lowercase aliases collapse to the same canonical event
    [InlineData("lobbies:join", "join_lobby")]
    [InlineData("LOBBIES:JOIN", "join_lobby")]
    [InlineData("join_lobby", "join_lobby")]
    public void Normalize_JoinAliasesConverge(string a, string b)
    {
        Assert.Equal(Normalize(a), Normalize(b));
    }

    [Theory] // all the cancel/leave variants map to a non-empty canonical event
    [InlineData("matchmaking:cancel")]
    [InlineData("lobbies:cancel")]
    [InlineData("cancel_matchmaking")]
    [InlineData("queue:cancel")]
    [InlineData("leave_queue")]
    public void Normalize_CancelVariantsResolve(string evt)
    {
        Assert.False(string.IsNullOrWhiteSpace(Normalize(evt)));
    }

    [Theory] // unknown events fall through to dash->underscore + UPPER
    [InlineData("some-custom-event", "SOME_CUSTOM_EVENT")]
    [InlineData("already_upper", "ALREADY_UPPER")]
    [InlineData("  spaced-event  ", "SPACED_EVENT")] // trims too
    public void Normalize_UnknownFallsBackToUpperSnake(string input, string expected)
    {
        Assert.Equal(expected, Normalize(input));
    }

    [Fact] // case-insensitive: switch_char and SWITCH_CHAR normalize identically
    public void Normalize_IsCaseInsensitive()
    {
        Assert.Equal(Normalize("switch_char"), Normalize("SWITCH_CHAR"));
    }
}
