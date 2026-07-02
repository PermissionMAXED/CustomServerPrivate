param(
    [int]$ServerPort = 5172,
    [int]$GameServerReadyTimeoutSeconds = 150,
    [int]$GameEndedTimeoutSeconds = 180
)

$ErrorActionPreference = "Stop"
$Root = Resolve-Path (Join-Path $PSScriptRoot "..")

Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName System.Drawing

function Take-Screenshot([string]$Path) {
    $screen = [System.Windows.Forms.Screen]::PrimaryScreen.Bounds
    $bmp = [System.Drawing.Bitmap]::new($screen.Width, $screen.Height)
    $g = [System.Drawing.Graphics]::FromImage($bmp)
    $g.CopyFromScreen($screen.Location, [System.Drawing.Point]::Empty, $screen.Size)
    $g.Dispose()
    $bmp.Save($Path, [System.Drawing.Imaging.ImageFormat]::Png)
    $bmp.Dispose()
}

$logDir = Join-Path $Root "tools\logs"
New-Item -ItemType Directory -Force -Path $logDir | Out-Null

$ServerDll = Join-Path $Root "CustomMatchServer\bin\Release\net10.0\BapCustomServer.dll"
$SmokeGameArguments = "--melonloader.debug --melonloader.captureplayerlogs --melonloader.agfoffline --bapcustom-auto-end-after=30 --bapcustom-host=127.0.0.1 --bapcustom-server-port=$ServerPort --bapcustom-use-proxy=false --bapcustom-show-ui=false"

Write-Host "=== EXTENDED MATCH TEST (30s, 2 players + 4 bots, Lyceum map) ===" -ForegroundColor Cyan
Write-Host "Server port: $ServerPort"
Write-Host "Game arguments: $SmokeGameArguments"
Write-Host ""

# --- Helper Functions (same as smoke test) ---

function Test-PortFree {
    param([int]$Port)
    $client = [System.Net.Sockets.TcpClient]::new()
    try {
        $task = $client.ConnectAsync("127.0.0.1", $Port)
        $open = $task.Wait(250)
        return -not ($open -and $client.Connected)
    } catch { return $true }
    finally { $client.Dispose() }
}

function Start-TestServer {
    $psi = [System.Diagnostics.ProcessStartInfo]::new()
    $psi.FileName = "dotnet"
    $psi.Arguments = "`"$ServerDll`""
    $psi.WorkingDirectory = $Root
    $psi.UseShellExecute = $false
    $psi.RedirectStandardOutput = $true
    $psi.RedirectStandardError = $true
    $psi.CreateNoWindow = $true
    $psi.EnvironmentVariables["ASPNETCORE_URLS"] = "http://127.0.0.1:$ServerPort"
    $psi.EnvironmentVariables["CustomServer__PublicBaseUrl"] = "http://127.0.0.1:$ServerPort"
    $psi.EnvironmentVariables["CustomServer__Admin__AllowLoopbackAdminWithoutToken"] = "true"
    $psi.EnvironmentVariables["CustomServer__LaunchGameServers"] = "true"
    $psi.EnvironmentVariables["CustomServer__RequireGameServerBootstrap"] = "true"
    $psi.EnvironmentVariables["CustomServer__GameServerReadyTimeoutSeconds"] = $GameServerReadyTimeoutSeconds.ToString()
    $psi.EnvironmentVariables["CustomServer__GameExecutablePath"] = (Join-Path $Root "Spiel\Battleroyalebuild\bapbap.exe")
    $psi.EnvironmentVariables["CustomServer__GameWorkingDirectory"] = (Join-Path $Root "Spiel\Battleroyalebuild")
    $psi.EnvironmentVariables["CustomServer__GameLogDirectory"] = (Join-Path $Root "CustomMatchServer\logs\game-servers")
    $psi.EnvironmentVariables["CustomServer__AdditionalGameArguments"] = $SmokeGameArguments
    return [System.Diagnostics.Process]::Start($psi)
}

function Wait-Health {
    $deadline = [DateTime]::UtcNow.AddSeconds(15)
    do {
        try { return Invoke-RestMethod "http://127.0.0.1:$ServerPort/health" }
        catch { Start-Sleep -Milliseconds 250 }
    } while ([DateTime]::UtcNow -lt $deadline)
    throw "Timed out waiting for server health."
}

function New-SmokeSocket {
    param([string]$AccountId, [string]$Username)
    $socket = [System.Net.WebSockets.ClientWebSocket]::new()
    $uri = [Uri]"ws://127.0.0.1:$ServerPort/ws?accountId=$AccountId&username=$Username"
    $connect = $socket.ConnectAsync($uri, [Threading.CancellationToken]::None)
    if (-not $connect.Wait(5000)) { throw "Timed out connecting websocket for $AccountId." }
    if ($connect.IsFaulted) { throw $connect.Exception }
    return $socket
}

function Send-WsJson {
    param([System.Net.WebSockets.ClientWebSocket]$Socket, [object]$Message)
    $json = $Message | ConvertTo-Json -Compress -Depth 20
    $bytes = [System.Text.Encoding]::UTF8.GetBytes($json)
    $segment = [ArraySegment[byte]]::new($bytes)
    $task = $Socket.SendAsync($segment, [System.Net.WebSockets.WebSocketMessageType]::Text, $true, [Threading.CancellationToken]::None)
    if (-not $task.Wait(5000)) { throw "Timed out sending websocket message." }
    if ($task.IsFaulted) { throw $task.Exception }
}

function Receive-WsJson {
    param([System.Net.WebSockets.ClientWebSocket]$Socket, [int]$TimeoutMs = 5000)
    $buffer = New-Object byte[] 65536
    $stream = [System.IO.MemoryStream]::new()
    try {
        do {
            $segment = [ArraySegment[byte]]::new($buffer)
            $task = $Socket.ReceiveAsync($segment, [Threading.CancellationToken]::None)
            if (-not $task.Wait($TimeoutMs)) { throw "Timed out receiving websocket message." }
            if ($task.IsFaulted) { throw $task.Exception }
            $result = $task.Result
            if ($result.MessageType -eq [System.Net.WebSockets.WebSocketMessageType]::Close) { throw "WebSocket closed." }
            $stream.Write($buffer, 0, $result.Count)
        } while (-not $result.EndOfMessage)
        $json = [System.Text.Encoding]::UTF8.GetString($stream.ToArray())
        return $json | ConvertFrom-Json
    } finally { $stream.Dispose() }
}

function Receive-UntilEvent {
    param([System.Net.WebSockets.ClientWebSocket]$Socket, [string[]]$Events, [int]$MaxMessages = 80, [int]$TimeoutMs = 5000)
    $seen = @()
    for ($i = 0; $i -lt $MaxMessages; $i++) {
        $message = Receive-WsJson -Socket $Socket -TimeoutMs $TimeoutMs
        $seen += $message.event
        if ($Events -contains $message.event) {
            return [pscustomobject]@{ Message = $message; Seen = $seen }
        }
    }
    throw "Did not receive any of: $($Events -join ', '). Seen: $($seen -join ', ')"
}

function Get-MatchArray { return @(Invoke-RestMethod "http://127.0.0.1:$ServerPort/admin/matches") }

function Wait-MatchEnded {
    param([string]$GameId, [int]$TimeoutSeconds)
    $deadline = [DateTime]::UtcNow.AddSeconds($TimeoutSeconds)
    $lastMatches = @()
    do {
        $lastMatches = Get-MatchArray
        $match = $lastMatches | Where-Object { $_.gameId -eq $GameId } | Select-Object -First 1
        if ($null -eq $match) { return [pscustomobject]@{ Observed = $true; Matches = $lastMatches } }
        Start-Sleep -Milliseconds 500
    } while ([DateTime]::UtcNow -lt $deadline)
    return [pscustomobject]@{ Observed = $false; Matches = $lastMatches }
}

function Start-AutoJoinClient {
    param([object]$Payload, [string]$GameId, [string]$Label)
    $gameDirectory = Join-Path $Root "Spiel\Battleroyalebuild"
    $gameExecutable = Join-Path $gameDirectory "bapbap.exe"
    $logDirectory = Join-Path $Root "CustomMatchServer\logs\game-servers"
    $clientLog = Join-Path $logDirectory ("client-autojoin-{0}-{1}.log" -f $Label, $GameId)
    $args = "-logFile `"$clientLog`" --melonloader.debug --melonloader.captureplayerlogs --melonloader.agfoffline --bapcustom-use-proxy=false --bapcustom-show-ui=false --bapcustom-host=127.0.0.1 --bapcustom-server-port=$ServerPort --bapcustom-account-id=$Label --bapcustom-username=$Label --bapcustom-join-auth=$($Payload.gameAuthId) --bapcustom-join-host=$($Payload.gameDns) --bapcustom-join-ws=$($Payload.wsPort) --bapcustom-join-kcp=$($Payload.kcpPort) --bapcustom-join-tcp=$($Payload.tcpPort)"
    $process = Start-Process -FilePath $gameExecutable -WorkingDirectory $gameDirectory -ArgumentList $args -WindowStyle Hidden -PassThru
    return [pscustomobject]@{ Process = $process; Log = $clientLog; Arguments = $args }
}

function Stop-ProcessSafe {
    param($Process)
    if ($null -eq $Process -or $Process.HasExited) { return }
    try {
        try { $Process.Kill($true) } catch { $Process.Kill() }
        $Process.WaitForExit(5000) | Out-Null
    } catch {}
}

# --- Pre-flight checks ---
if (-not (Test-Path $ServerDll)) { throw "Build CustomMatchServer first: $ServerDll is missing." }
if (-not (Test-PortFree $ServerPort)) { throw "Port $ServerPort is already in use." }

$server = $null
$leader = $null
$guest = $null
$autoJoinClients = @()

try {
    Write-Host "[1/7] Starting custom match server..." -ForegroundColor Yellow
    $server = Start-TestServer
    Wait-Health | Out-Null
    Write-Host "  Server healthy on port $ServerPort" -ForegroundColor Green

    Write-Host "[2/7] Connecting 2 WebSocket clients..." -ForegroundColor Yellow
    $leader = New-SmokeSocket -AccountId "ext-leader" -Username "ExtLeader"
    $guest = New-SmokeSocket -AccountId "ext-guest" -Username "ExtGuest"
    Receive-UntilEvent -Socket $leader -Events @("SOCKET_READY") | Out-Null
    Receive-UntilEvent -Socket $guest -Events @("SOCKET_READY") | Out-Null
    Write-Host "  Both clients connected" -ForegroundColor Green

    Write-Host "[3/7] Joining lobby and configuring match (4 bots, Lyceum, Medium difficulty)..." -ForegroundColor Yellow
    Send-WsJson $leader @{ event = "JOIN_LOBBY"; payload = @{ lobbyId = "EXTENDED1"; charId = 1; regionId = "custom"; gameModeId = 0; isAutoFill = $false } }
    $leaderJoin = Receive-UntilEvent -Socket $leader -Events @("JOIN_LOBBY_SUCCESS") -TimeoutMs 15000

    Send-WsJson $guest @{ event = "JOIN_LOBBY"; payload = @{ lobbyId = "EXTENDED1"; charId = 5; regionId = "custom"; gameModeId = 0; isAutoFill = $false } }
    $guestJoin = Receive-UntilEvent -Socket $guest -Events @("JOIN_LOBBY_SUCCESS") -TimeoutMs 15000

    # Configure with BOTS: 4 bots, medium difficulty, Lyceum map, FFA with 8 max teams
    Send-WsJson $leader @{
        event = "UPDATE_CUSTOM_SETTINGS"
        payload = @{
            settings = @{
                gamemode = 1
                mapId = 2
                teamSize = 1
                maxTeams = 8
                botCount = 4
                botDifficulty = 2
            }
        }
    }
    Receive-UntilEvent -Socket $leader -Events @("UPDATE_CUSTOM_SETTINGS_SUCCESS") | Out-Null
    Write-Host "  Settings applied: mapId=2(Lyceum), botCount=4, botDifficulty=2(Medium), maxTeams=8" -ForegroundColor Green

    Write-Host "[4/7] Starting custom game..." -ForegroundColor Yellow
    Send-WsJson $leader @{ event = "START_CUSTOM_GAME"; payload = @{ forceStart = $true } }

    $terminalTimeoutMs = [Math]::Max(30000, ($GameServerReadyTimeoutSeconds + 30) * 1000)
    $leaderStarted = Receive-UntilEvent -Socket $leader -Events @("START_CUSTOM_GAME_FAIL", "GAME_STARTED") -TimeoutMs $terminalTimeoutMs
    if ($leaderStarted.Message.event -ne "GAME_STARTED") { throw "Leader did not receive GAME_STARTED. Got: $($leaderStarted.Message.event)" }

    $guestStarted = Receive-UntilEvent -Socket $guest -Events @("GAME_STARTED") -TimeoutMs 30000
    Write-Host "  Both players received GAME_STARTED" -ForegroundColor Green

    $matches = Get-MatchArray
    if ($matches.Count -lt 1) { throw "No active match returned by /admin/matches." }
    $gameId = $matches[0].gameId
    Write-Host "  Game ID: $gameId" -ForegroundColor Green

    Write-Host "[5/7] Launching auto-join game clients..." -ForegroundColor Yellow
    $autoJoinClients += Start-AutoJoinClient -Payload $leaderStarted.Message.payload -GameId $gameId -Label "ext-leader"
    $autoJoinClients += Start-AutoJoinClient -Payload $guestStarted.Message.payload -GameId $gameId -Label "ext-guest"
    Write-Host "  2 game clients launched (PIDs: $($autoJoinClients[0].Process.Id), $($autoJoinClients[1].Process.Id))" -ForegroundColor Green

    # Take mid-match screenshot after 10 seconds
    Write-Host "[6/7] Waiting for 30s match to play out (taking screenshots)..." -ForegroundColor Yellow
    Start-Sleep -Seconds 10
    Take-Screenshot (Join-Path $logDir "extended-match-midgame.png")
    Write-Host "  Mid-game screenshot taken (10s)"

    Start-Sleep -Seconds 10
    Take-Screenshot (Join-Path $logDir "extended-match-20s.png")
    Write-Host "  20s screenshot taken"

    # Wait for match to end
    $ended = Wait-MatchEnded -GameId $gameId -TimeoutSeconds $GameEndedTimeoutSeconds
    Write-Host "  Match ended observed: $($ended.Observed)" -ForegroundColor Green

    Take-Screenshot (Join-Path $logDir "extended-match-final.png")

    Write-Host ""
    Write-Host "[7/7] Match result:" -ForegroundColor Yellow
    $resultObj = [pscustomobject]@{
        lobbyId = $leaderJoin.Message.payload.lobby.lobbyId
        gameId = $gameId
        leaderSeenEvents = $leaderStarted.Seen
        guestSeenEvents = $guestStarted.Seen
        gameEndedObserved = $ended.Observed
        autoJoinClientLogs = @($autoJoinClients | ForEach-Object { $_.Log })
    }
    $resultObj | ConvertTo-Json -Depth 10
    Write-Host ""

    # === DEEP LOG ANALYSIS ===
    Write-Host ""
    Write-Host "=============================================" -ForegroundColor Cyan
    Write-Host "=== EXTENDED GAME LOG ANALYSIS ===" -ForegroundColor Cyan
    Write-Host "=============================================" -ForegroundColor Cyan

    $gameLogDir = Join-Path $Root "CustomMatchServer\logs\game-servers"
    $latestLog = Get-ChildItem $gameLogDir -Filter "custom-*.log" | Sort-Object LastWriteTime -Descending | Select-Object -First 1

    if ($latestLog) {
        $lines = Get-Content $latestLog.FullName
        Write-Host ""
        Write-Host "Game server log: $($latestLog.Name)" -ForegroundColor White
        Write-Host "  Size: $($latestLog.Length) bytes, Lines: $($lines.Count)"
        Write-Host ""

        # === MATCH LIFECYCLE ===
        Write-Host "--- MATCH LIFECYCLE ---" -ForegroundColor Yellow
        $lifecycleLines = $lines | Select-String "START MATCH|Loaded Map|PRE-MATCH|LIFECYCLE|Match has officially|game-ended|MatchManager|GameManager|match started|match ended|GameOver"
        Write-Host "  Events: $($lifecycleLines.Count)"
        $lifecycleLines | Select-Object -First 15 | ForEach-Object { Write-Host "  $($_.Line.Trim().Substring(0, [Math]::Min(200, $_.Line.Trim().Length)))" }

        # === PLAYER CONNECTIONS ===
        Write-Host ""
        Write-Host "--- PLAYER CONNECTIONS ---" -ForegroundColor Yellow
        $playerLines = $lines | Select-String "Matchmaking player connected|player connected|AllPlayersConnected|OnServerConnect|OnServerDisconnect|client connected|PlayerJoined"
        Write-Host "  Connection events: $($playerLines.Count)"
        $playerLines | Select-Object -First 15 | ForEach-Object { Write-Host "  $($_.Line.Trim().Substring(0, [Math]::Min(200, $_.Line.Trim().Length)))" }

        # === BOT BEHAVIOR ===
        Write-Host ""
        Write-Host "--- BOT AI BEHAVIOR ---" -ForegroundColor Yellow
        $botLines = $lines | Select-String -Pattern "bot|Bot|BOT|AI |AiState|BotController|NavMesh|pathfind|Pathfind" | Where-Object { $_.Line -notmatch "robot|Robot|about" }
        Write-Host "  Bot-related lines: $($botLines.Count)"
        $botLines | Select-Object -First 20 | ForEach-Object { Write-Host "  $($_.Line.Trim().Substring(0, [Math]::Min(200, $_.Line.Trim().Length)))" }

        # === SPAWNING ===
        Write-Host ""
        Write-Host "--- SPAWNING ---" -ForegroundColor Yellow
        $spawnLines = $lines | Select-String "spawn|Spawn|SPAWN|SpawnPlayer|OnSpawn|Respawn|InstantiatePlayer|PlayerSpawn"
        Write-Host "  Spawn events: $($spawnLines.Count)"
        $spawnLines | Select-Object -First 15 | ForEach-Object { Write-Host "  $($_.Line.Trim().Substring(0, [Math]::Min(200, $_.Line.Trim().Length)))" }

        # === ABILITIES & COMBAT ===
        Write-Host ""
        Write-Host "--- ABILITIES & COMBAT ---" -ForegroundColor Yellow
        $combatLines = $lines | Select-String "ability|Ability|damage|Damage|attack|Attack|hit|Hit|kill|Kill|health|Health|projectile|Projectile|weapon|Weapon|fire|Fire|cast|Cast|cooldown|Cooldown|ultimate|Ultimate|skill|Skill"
        Write-Host "  Combat/ability lines: $($combatLines.Count)"
        $combatLines | Select-Object -First 25 | ForEach-Object { Write-Host "  $($_.Line.Trim().Substring(0, [Math]::Min(200, $_.Line.Trim().Length)))" }

        # === NETWORK SYNC ===
        Write-Host ""
        Write-Host "--- NETWORK SYNC ---" -ForegroundColor Yellow
        $syncLines = $lines | Select-String "Cmd|Rpc|SyncVar|NetworkBehaviour|Mirror|serialize|Serialize|desync|Desync|NetworkIdentity|authority|Authority"
        Write-Host "  Network sync lines: $($syncLines.Count)"
        $syncLines | Select-Object -First 15 | ForEach-Object { Write-Host "  $($_.Line.Trim().Substring(0, [Math]::Min(200, $_.Line.Trim().Length)))" }

        # === CHARACTER SELECTION ===
        Write-Host ""
        Write-Host "--- CHARACTER SELECTION ---" -ForegroundColor Yellow
        $charLines = $lines | Select-String "char|Char|character|Character|charId|CharId|skin|Skin|selected|Selected|loadout|Loadout"
        Write-Host "  Character-related lines: $($charLines.Count)"
        $charLines | Select-Object -First 15 | ForEach-Object { Write-Host "  $($_.Line.Trim().Substring(0, [Math]::Min(200, $_.Line.Trim().Length)))" }

        # === MAP LOADING ===
        Write-Host ""
        Write-Host "--- MAP LOADING ---" -ForegroundColor Yellow
        $mapLines = $lines | Select-String "map|Map|MAP|scene|Scene|LoadScene|Lyceum|Arena|level|Level"
        Write-Host "  Map/scene lines: $($mapLines.Count)"
        $mapLines | Select-Object -First 15 | ForEach-Object { Write-Host "  $($_.Line.Trim().Substring(0, [Math]::Min(200, $_.Line.Trim().Length)))" }

        # === GAME STATE (zones, rounds, timers) ===
        Write-Host ""
        Write-Host "--- GAME STATE (zones, rounds, scoring) ---" -ForegroundColor Yellow
        $stateLines = $lines | Select-String "round|Round|zone|Zone|circle|Circle|timer|Timer|score|Score|placement|Placement|elimination|Elimination|shrink|Shrink|ring|Ring"
        Write-Host "  Game state events: $($stateLines.Count)"
        $stateLines | Select-Object -First 15 | ForEach-Object { Write-Host "  $($_.Line.Trim().Substring(0, [Math]::Min(200, $_.Line.Trim().Length)))" }

        # === ERRORS & WARNINGS ===
        Write-Host ""
        Write-Host "--- ERRORS & WARNINGS ---" -ForegroundColor Red
        $errorLines = $lines | Select-String "error|Error|ERROR|exception|Exception|EXCEPTION|NullRef|null ref|failed|Failed|FAILED|stack trace|StackTrace|ArgumentException|InvalidOperation|IndexOutOfRange"
        Write-Host "  Error/warning lines: $($errorLines.Count)"
        $errorLines | Select-Object -First 20 | ForEach-Object { Write-Host "  $($_.Line.Trim().Substring(0, [Math]::Min(200, $_.Line.Trim().Length)))" }

        # === RAW LOG SAMPLE (first 30 and last 30 lines) ===
        Write-Host ""
        Write-Host "--- RAW LOG: FIRST 30 LINES ---" -ForegroundColor Magenta
        $lines | Select-Object -First 30 | ForEach-Object { Write-Host "  $_" }

        Write-Host ""
        Write-Host "--- RAW LOG: LAST 30 LINES ---" -ForegroundColor Magenta
        $lines | Select-Object -Last 30 | ForEach-Object { Write-Host "  $_" }

        # === SUMMARY ===
        Write-Host ""
        Write-Host "=============================================" -ForegroundColor Green
        Write-Host "=== SUMMARY ===" -ForegroundColor Green
        Write-Host "=============================================" -ForegroundColor Green
        Write-Host "  Total log lines:        $($lines.Count)"
        Write-Host "  Match lifecycle events:  $($lifecycleLines.Count)"
        Write-Host "  Player connections:      $($playerLines.Count)"
        Write-Host "  Bot AI events:           $($botLines.Count)"
        Write-Host "  Spawn events:            $($spawnLines.Count)"
        Write-Host "  Combat/ability events:   $($combatLines.Count)"
        Write-Host "  Network sync events:     $($syncLines.Count)"
        Write-Host "  Character selection:     $($charLines.Count)"
        Write-Host "  Map loading events:      $($mapLines.Count)"
        Write-Host "  Game state events:       $($stateLines.Count)"
        Write-Host "  Errors/warnings:         $($errorLines.Count)"
    } else {
        Write-Host "  WARNING: No game server log found in $gameLogDir" -ForegroundColor Red
    }

    # === CLIENT LOGS ===
    Write-Host ""
    Write-Host "=== CLIENT LOG ANALYSIS ===" -ForegroundColor Cyan
    foreach ($client in $autoJoinClients) {
        if (Test-Path $client.Log) {
            $cLines = Get-Content $client.Log
            Write-Host ""
            Write-Host "Client log: $(Split-Path $client.Log -Leaf) ($($cLines.Count) lines)" -ForegroundColor White
            $cErrors = $cLines | Select-String "error|Error|ERROR|exception|Exception"
            $cConnect = $cLines | Select-String "connect|Connect|joined|Joined"
            $cSpawn = $cLines | Select-String "spawn|Spawn"
            Write-Host "  Connections: $($cConnect.Count), Spawns: $($cSpawn.Count), Errors: $($cErrors.Count)"
            if ($cErrors.Count -gt 0) {
                Write-Host "  First 5 errors:" -ForegroundColor Red
                $cErrors | Select-Object -First 5 | ForEach-Object { Write-Host "    $($_.Line.Trim().Substring(0, [Math]::Min(150, $_.Line.Trim().Length)))" }
            }
            Write-Host "  Last 10 lines:" -ForegroundColor Gray
            $cLines | Select-Object -Last 10 | ForEach-Object { Write-Host "    $_" }
        } else {
            Write-Host "  Client log not found: $($client.Log)" -ForegroundColor Red
        }
    }

    Write-Host ""
    Write-Host "Screenshots saved to: tools\logs\" -ForegroundColor Cyan
    Write-Host "=== EXTENDED MATCH TEST COMPLETE ===" -ForegroundColor Cyan
}
finally {
    if ($leader) { $leader.Abort(); $leader.Dispose() }
    if ($guest) { $guest.Abort(); $guest.Dispose() }
    foreach ($client in $autoJoinClients) { Stop-ProcessSafe $client.Process }
    Stop-ProcessSafe $server
}
