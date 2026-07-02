param(
    [int]$ServerPort = 5163,
    [int]$CharId = 15,
    [int]$BotCount = 7,
    [int]$GameServerReadyTimeoutSeconds = 200,
    [int]$MatchRunSeconds = 180
)
$ErrorActionPreference = "Stop"
$Root = Resolve-Path (Join-Path $PSScriptRoot "..")
$GameDir = Join-Path $Root "Spiel\Battleroyalebuild"
$GameExe = Join-Path $GameDir "bapbap.exe"
$LogDir = Join-Path $Root "logs"
$Stamp = Get-Date -Format "yyyyMMdd-HHmmss"
$RunDir = Join-Path $LogDir "visible-$Stamp"
New-Item -ItemType Directory -Force -Path $RunDir | Out-Null
$RunLog = Join-Path $RunDir "run.log"
$HostLog = Join-Path $RunDir "host.log"
$ClientLog = Join-Path $RunDir "client.log"

function Log { param([string]$m); "$(Get-Date -Format 'HH:mm:ss.fff') $m" | Tee-Object -FilePath $RunLog -Append | Write-Host }

function Start-TestServer {
    $psi = [System.Diagnostics.ProcessStartInfo]::new()
    $psi.FileName = "dotnet"; $psi.Arguments = "`"CustomMatchServer\bin\Release\net10.0\BapCustomServer.dll`""
    $psi.WorkingDirectory = $Root; $psi.UseShellExecute = $false; $psi.CreateNoWindow = $true
    $psi.EnvironmentVariables["ASPNETCORE_URLS"] = "http://127.0.0.1:$ServerPort"
    $psi.EnvironmentVariables["CustomServer__PublicBaseUrl"] = "http://127.0.0.1:$ServerPort"
    $psi.EnvironmentVariables["CustomServer__Admin__AllowLoopbackAdminWithoutToken"] = "true"
    $psi.EnvironmentVariables["CustomServer__LaunchGameServers"] = "true"
    $psi.EnvironmentVariables["CustomServer__RequireGameServerBootstrap"] = "true"
    $psi.EnvironmentVariables["CustomServer__GameServerPrewarmOnStartup"] = "false"
    $psi.EnvironmentVariables["CustomServer__GameServerStartAttempts"] = "2"
    $psi.EnvironmentVariables["CustomServer__GameServerReadyTimeoutSeconds"] = $GameServerReadyTimeoutSeconds.ToString()
    $psi.EnvironmentVariables["CustomServer__GameExecutablePath"] = $GameExe
    $psi.EnvironmentVariables["CustomServer__GameWorkingDirectory"] = $GameDir
    $psi.EnvironmentVariables["CustomServer__GameLogDirectory"] = (Join-Path $Root "logs\game-servers")
    $psi.EnvironmentVariables["CustomServer__AdditionalGameArguments"] = "-logFile `"$HostLog`" --melonloader.agfoffline --melonloader.captureplayerlogs --bapcustom-host=127.0.0.1 --bapcustom-server-port=$ServerPort --bapcustom-use-proxy=false --bapcustom-show-ui=false"
    # NO -logFile in HeadlessArguments: AdditionalGameArguments provides the -logFile.
    # Double -logFile causes Unity to crash (exitCode -532462766, 0-byte logs).
    $psi.EnvironmentVariables["CustomServer__HeadlessArguments"] = "-batchmode -nographics -httpport={httpPort} -wsport={wsPort} -kcpport={kcpPort} -tcpport={tcpPort}"
    # Matchmaking queue: 5s timer so solo players get matched with bots quickly
    $psi.EnvironmentVariables["CustomServer__MatchmakingQueue__QueueTimerSeconds"] = "5"
    $psi.EnvironmentVariables["CustomServer__MatchmakingQueue__MinPlayersToStart"] = "1"
    return [System.Diagnostics.Process]::Start($psi)
}

function New-Ws { param([string]$Account,[string]$User)
    $s = [System.Net.WebSockets.ClientWebSocket]::new()
    $u = [Uri]"ws://127.0.0.1:$ServerPort/ws?accountId=$Account&username=$User"
    $c = $s.ConnectAsync($u, [Threading.CancellationToken]::None)
    if (-not $c.Wait(8000)) { throw "WS connect timeout $u" }
    if ($c.IsFaulted) { throw $c.Exception }
    return $s
}

function Send-Ws { param($Socket,[object]$Object)
    $j = $Object | ConvertTo-Json -Compress -Depth 20
    $b = [System.Text.Encoding]::UTF8.GetBytes($j)
    $Socket.SendAsync([ArraySegment[byte]]::new($b), "Text", $true, [Threading.CancellationToken]::None).Wait(5000)
}

function Recv-Until { param($Socket,[string[]]$Events,[int]$TimeoutMs=30000,[int]$Max=100)
    $buf = New-Object byte[] 65536
    for ($i = 0; $i -lt $Max; $i++) {
        $ms = [System.IO.MemoryStream]::new()
        do {
            $seg = [ArraySegment[byte]]::new($buf)
            $task = $Socket.ReceiveAsync($seg, [Threading.CancellationToken]::None)
            if (-not $task.Wait($TimeoutMs)) { throw "Recv timeout $TimeoutMs ms" }
            if ($task.IsFaulted) { throw $task.Exception }
            $result = $task.Result
            if ($result.MessageType -eq "Close") { throw "Socket closed" }
            $ms.Write($buf, 0, $result.Count)
        } while (-not $result.EndOfMessage)
        $msg = ([System.Text.Encoding]::UTF8.GetString($ms.ToArray()) | ConvertFrom-Json)
        if ($Events -contains $msg.event) { return $msg }
    }
    throw "Did not see: $($Events -join ',') after $Max messages"
}

# === MAIN ===
Log "Killing old processes..."
Get-Process bapbap -ErrorAction SilentlyContinue | Stop-Process -Force
Get-Process dotnet -ErrorAction SilentlyContinue | Stop-Process -Force
Start-Sleep -Seconds 3

Log "Starting server..."
$server = Start-TestServer
$d = [DateTime]::UtcNow.AddSeconds(25)
do { try { Invoke-RestMethod "http://127.0.0.1:$ServerPort/health" -TimeoutSec 3 | Out-Null; break } catch { Start-Sleep -Milliseconds 400 } } while ([DateTime]::UtcNow -lt $d)
Log "Server healthy."

Log "Launching VISIBLE client with --bapcustom-autoplay..."
# NOTE: We do NOT pass --bapcustom-join-* args. The client's autoplay will:
# 1. Wait for login
# 2. POST /api/queue/join (enter matchmaking queue)
# 3. After 5s server fires match with bots
# 4. THE GAME'S OWN WS handler receives GAME_STARTED and auto-connects
#    (this requires the lobby UI to not crash - the lobby crash fix is in CharConfigFix)
$cArgs = @(
    "-logFile", $ClientLog,
    "--melonloader.agfoffline", "--melonloader.captureplayerlogs",
    "--bapcustom-use-proxy=false", "--bapcustom-show-ui=false",
    "--bapcustom-host=127.0.0.1", "--bapcustom-server-port=$ServerPort",
    "--bapcustom-selected-char=$CharId",
    "--bapcustom-autoplay", "--bapcustom-auto-select-augments"
)
$client = Start-Process -FilePath $GameExe -WorkingDirectory $GameDir -ArgumentList $cArgs -PassThru
Log "VISIBLE CLIENT PID=$($client.Id)"
Log "============================================"
Log "Client launched."
Log "============================================"

# Wait for match duration (or until client exits)
$elapsed = 0
while ($elapsed -lt $MatchRunSeconds -and -not $client.HasExited) {
    Start-Sleep -Seconds 5
    $elapsed += 5
    # Log markers from client log periodically
    if ($elapsed % 30 -eq 0 -and (Test-Path $ClientLog)) {
        $lines = Select-String -LiteralPath $ClientLog -Pattern "\[Autoplay\]|GameManager|PlayerManager|Queue join|GAME_STARTED|QUEUE_MATCHED" -ErrorAction SilentlyContinue | Select-Object -Last 5
        if ($lines) { $lines | ForEach-Object { Log "  CLIENT: $($_.Line)" } }
    }
}
if (-not $client.HasExited) { Stop-Process -Id $client.Id -Force }
Log "Match complete ($elapsed s). Logs in $RunDir"
