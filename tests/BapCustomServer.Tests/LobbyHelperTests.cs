using System.Reflection;
using BapCustomServer;
using Xunit;

namespace BapCustomServer.Tests;

// F075 gamemode mapping, F057 gamemode resolution, F063 char-select clamp.
// These are load-bearing pure static helpers in LobbyService — they guard against
// IndexOutOfRange in the dedicated host and a pre-match UI crash, so they are worth
// asserting directly. Accessed via reflection (private static) so the tests pin the
// real production methods rather than a copy.
public class LobbyHelperTests
{
    private static T Invoke<T>(string method, params object[] args)
    {
        MethodInfo mi = typeof(LobbyService).GetMethod(method, BindingFlags.NonPublic | BindingFlags.Static)
            ?? throw new InvalidOperationException($"{method} not found (renamed?)");
        return (T)mi.Invoke(null, args)!;
    }

    [Theory] // F075 — every matchmaking id 0..10 maps to a valid unity mode 1..3 (never 0/None, never out of range)
    [InlineData(0, 2)]   // Warmup -> Training
    [InlineData(1, 1)]   // MiniDuos -> BR
    [InlineData(3, 1)]   // Solos -> BR
    [InlineData(9, 3)]   // FreeForAll -> FFA
    [InlineData(10, 1)]  // CustomGame -> BR
    [InlineData(99, 1)]  // unknown -> BR (safe default)
    [InlineData(-1, 1)]  // negative -> BR (safe default)
    public void MapMatchmakingToUnityGameMode_StaysInValidRange(int input, int expected)
    {
        int unity = Invoke<int>("MapMatchmakingToUnityGameMode", input);
        Assert.Equal(expected, unity);
        Assert.InRange(unity, 1, 3); // never 0 (None) which would crash runtime arrays
    }

    [Theory] // F057 — non-positive requested mode falls back to the default lobby mode (Solos=3, matches queue-join default)
    [InlineData(4, 4)]
    [InlineData(0, 3)]   // 0 -> default
    [InlineData(-5, 3)]  // negative -> default
    public void ResolveLobbyGameModeId_FallsBackForNonPositive(int input, int expected)
    {
        Assert.Equal(expected, Invoke<int>("ResolveLobbyGameModeId", input));
    }

    [Theory] // F063 — char-select duration clamped up to the 20s minimum (prevents pre-match UI crash)
    [InlineData(0, 20000)]
    [InlineData(5000, 20000)]
    [InlineData(20000, 20000)]
    [InlineData(45000, 45000)]
    public void NormalizeCharSelectMillis_EnforcesMinimum(int input, int expected)
    {
        Assert.Equal(expected, Invoke<int>("NormalizeCharSelectMillis", input));
    }
}
