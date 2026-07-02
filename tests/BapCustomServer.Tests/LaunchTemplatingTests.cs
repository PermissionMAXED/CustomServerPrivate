using BapCustomServer;
using Xunit;

namespace BapCustomServer.Tests;

// F112 — game launch command templating. SubstituteLaunchTokens fills {gameId}/{httpPort}/...
// (and {gameExecutable}/{gameArguments} for the launcher-wrapper path) so the right command is
// built whether launching the exe directly or via a Wine wrapper script. Extracted as a pure
// static so it is testable without spawning a process.
public class LaunchTemplatingTests
{
    [Fact] // F112 — headless arg template fills every port/id/log token
    public void SubstituteLaunchTokens_FillsHeadlessTokens()
    {
        string template = "-batchmode -logFile {logFile} -httpport={httpPort} -wsport={wsPort} -kcpport={kcpPort} -tcpport={tcpPort} -id={gameId}";
        string result = GameServerProcessManager.SubstituteLaunchTokens(
            template, "match-42", httpPort: 7850, wsPort: 7777, kcpPort: 7778, tcpPort: 7779, logFile: "C:/logs/match-42.log");

        Assert.Contains("-httpport=7850", result);
        Assert.Contains("-wsport=7777", result);
        Assert.Contains("-kcpport=7778", result);
        Assert.Contains("-tcpport=7779", result);
        Assert.Contains("-id=match-42", result);
        Assert.Contains("-logFile C:/logs/match-42.log", result);
        Assert.DoesNotContain("{", result); // no unresolved tokens
    }

    [Fact] // F112 — launcher-wrapper path nests {gameExecutable} + {gameArguments}
    public void SubstituteLaunchTokens_FillsLauncherWrapperTokens()
    {
        string launcherTemplate = "\"{gameExecutable}\" {gameArguments}";
        string gameArgs = "-batchmode -httpport=7850";
        string result = GameServerProcessManager.SubstituteLaunchTokens(
            launcherTemplate, "match-42", 7850, 7777, 7778, 7779, "log.txt",
            gameExecutable: "/opt/game/bapbap.exe", gameArguments: gameArgs);

        Assert.Equal("\"/opt/game/bapbap.exe\" -batchmode -httpport=7850", result);
    }

    [Fact] // F112 — case-insensitive token matching ({HttpPort} == {httpport})
    public void SubstituteLaunchTokens_IsCaseInsensitive()
    {
        string result = GameServerProcessManager.SubstituteLaunchTokens(
            "-p={HTTPPORT} -id={GameId}", "g1", 9000, 1, 2, 3, "l");
        Assert.Equal("-p=9000 -id=g1", result);
    }

    [Fact] // F112 — a template with no tokens passes through unchanged
    public void SubstituteLaunchTokens_NoTokens_Unchanged()
    {
        string result = GameServerProcessManager.SubstituteLaunchTokens(
            "-nographics -batchmode", "g1", 1, 2, 3, 4, "l");
        Assert.Equal("-nographics -batchmode", result);
    }
}
