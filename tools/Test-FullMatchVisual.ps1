param(
    [int]$ServerPort = 5190,
    [int]$GameServerReadyTimeoutSeconds = 150,
    [int]$GameEndedTimeoutSeconds = 120
)

$ErrorActionPreference = "Stop"
$Root = Resolve-Path (Join-Path $PSScriptRoot "..")
$ServerDll = Join-Path $Root "CustomMatchServer\bin\Release\net10.0\BapCustomServer.dll"
$LogDir = Join-Path $PSScriptRoot "logs"
$SmokeGameArguments = "--melonloader.agfoffline --bapcustom-auto-end-after=8 --bapcustom-host=127.0.0.1 --bapcustom-server-port=$ServerPort --bapcustom-use-proxy=false --bapcustom-show-ui=false"

New-Item -ItemType Directory -Force -Path $LogDir | Out-Null

# ===== Step 1: Setup INI =====
Write-Host "=== Step 1: Setting up INI ===" -ForegroundColor Cyan
$iniDir = "C:\Users\Administrator\AppData\Roaming\BAPBAPBATTLEROYALE"
New-Item -ItemType Directory -Force -Path $iniDir | Out-Null
$ini = "[Server]`nHost=127.0.0.1`nPort=$ServerPort`nUseHttps=false`nUseLocalProxy=false`nLocalProxyPort=5055`n`n[Identity]`nAccountId=`nUsername=`nAutoGuestLogin=true`n`n[UI]`nShowStatusChip=true`nUseNativeGameUi=true"
Set-Content -Path (Join-Path $iniDir "BapCustomServer.ini") -Value $ini -Encoding UTF8
Write-Host "INI written for local server on port $ServerPort"

# ===== Helper Functions =====
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
    Write-Host "  Screenshot saved: $Path ($(((Get-Item $Path).Length / 1KB).ToString('0.0')) KB)"
}

function Test-PortFree([int]$Port) {
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

function New-SmokeSocket([string]$AccountId, [string]$Username) {
    $socket = [System.Net.WebSockets.ClientWebSocket]::new()
    $uri = [Uri]"ws://127.0.0.1:${ServerPort}/ws?accountId=$AccountId&username=$Username"
    $connect = $socket.ConnectAsync($uri, [Threading.CancellationToken]::None)
    if (-not $connect.Wait(5000)) { throw "Timed out connecting websocket for $AccountId." }
    if ($connect.IsFaulted) { throw $connect.Exception }
    return $socket
}

function Send-WsJson([System.Net.WebSockets.ClientWebSocket]$Socket, [object]$Message) {
    $json = $Message | ConvertTo-Json -Compress -Depth 20
    $bytes = [System.Text.Encoding]::UTF8.GetBytes($json)
    $segment = [ArraySegment[byte]]::new($bytes)
    $task = $Socket.SendAsync($segment, [System.Net.WebSockets.WebSocketMessageType]::Text, $true, [Threading.CancellationToken]::None)
    if (-not $task.Wait(5000)) { throw "Timed out sending websocket message." }
    if ($task.IsFaulted) { throw $task.Exception }
}

function Receive-WsJson([System.Net.WebSockets.ClientWebSocket]$Socket, [int]$TimeoutMs = 5000) {
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
        return ([System.Text.Encoding]::UTF8.GetString($stream.ToArray()) | ConvertFrom-Json)
    } finally { $stream.Dispose() }
}

function Receive-UntilEvent([System.Net.WebSockets.ClientWebSocket]$Socket, [string[]]$Events, [int]$MaxMessages = 80, [int]$TimeoutMs = 5000) {
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

function Stop-ProcessSafe($Process) {
    if ($null -eq $Process -or $Process.HasExited) { return }
    try { try { $Process.Kill($true) } catch { $Process.Kill() }; $Process.WaitForExit(5000) | Out-Null } catch {}
}

# ===== Pre-flight =====
if (-not (Test-Path $ServerDll)) { throw "Build CustomMatchServer first: $ServerDll is missing." }
if (-not (Test-PortFree $ServerPort)) { throw "Port $ServerPort is already in use." }

$server = $null
$leader = $null
$guest = $null
$client1 = $null
$client2 = $null
$results = @{}

try {
    # ===== Step 2: Start Server =====
    Write-Host "=== Step 2: Starting server on port $ServerPort ===" -ForegroundColor Cyan
    $server = Start-TestServer
    Wait-Health | Out-Null
    Write-Host "Server healthy (PID: $($server.Id))"
    $results["serverPid"] = $server.Id

    # ===== Step 3: WebSocket lobby + match start =====
    Write-Host "=== Step 3: Creating lobby and starting match ===" -ForegroundColor Cyan
    $leader = New-SmokeSocket -AccountId "match-leader" -Username "MatchLeader"
    $guest = New-SmokeSocket -AccountId "match-guest" -Username "MatchGuest"
    Receive-UntilEvent -Socket $leader -Events @("SOCKET_READY") | Out-Null
    Receive-UntilEvent -Socket $guest -Events @("SOCKET_READY") | Out-Null
    Write-Host "  Both WebSockets connected"

    Send-WsJson $leader @{ event = "JOIN_LOBBY"; payload = @{ lobbyId = "FULLTEST"; charId = 1; regionId = "custom"; gameModeId = 0; isAutoFill = $false } }
    Receive-UntilEvent -Socket $leader -Events @("JOIN_LOBBY_SUCCESS") -TimeoutMs 15000 | Out-Null
    Write-Host "  Leader joined lobby FULLTEST"

    Send-WsJson $guest @{ event = "JOIN_LOBBY"; payload = @{ lobbyId = "FULLTEST"; charId = 5; regionId = "custom"; gameModeId = 0; isAutoFill = $false } }
    Receive-UntilEvent -Socket $guest -Events @("JOIN_LOBBY_SUCCESS") -TimeoutMs 15000 | Out-Null
    Write-Host "  Guest joined lobby FULLTEST"

    Send-WsJson $leader @{ event = "UPDATE_CUSTOM_SETTINGS"; payload = @{ settings = @{ gamemode = 1; mapId = 1; teamSize = 1; maxTeams = 2; botCount = 0; botDifficulty = 1 } } }
    Receive-UntilEvent -Socket $leader -Events @("UPDATE_CUSTOM_SETTINGS_SUCCESS") | Out-Null
    Write-Host "  Settings updated: mapId=1, botCount=0, teamSize=1, maxTeams=2"

    Send-WsJson $leader @{ event = "START_CUSTOM_GAME"; payload = @{ forceStart = $true } }
    Write-Host "  Match start requested (waiting for game server...)"

    $terminalTimeoutMs = [Math]::Max(30000, ($GameServerReadyTimeoutSeconds + 30) * 1000)
    $leaderStarted = Receive-UntilEvent -Socket $leader -Events @("START_CUSTOM_GAME_FAIL", "GAME_STARTED") -TimeoutMs $terminalTimeoutMs
    if ($leaderStarted.Message.event -ne "GAME_STARTED") { throw "Leader did not receive GAME_STARTED. Got: $($leaderStarted.Message.event)" }
    Write-Host "  Leader received GAME_STARTED"

    $guestStarted = Receive-UntilEvent -Socket $guest -Events @("GAME_STARTED") -TimeoutMs 30000
    Write-Host "  Guest received GAME_STARTED"

    $leaderPayload = $leaderStarted.Message.payload
    $guestPayload = $guestStarted.Message.payload
    Write-Host "  Game Auth IDs: Leader=$($leaderPayload.gameAuthId), Guest=$($guestPayload.gameAuthId)"
    Write-Host "  Ports: WS=$($leaderPayload.wsPort), KCP=$($leaderPayload.kcpPort), TCP=$($leaderPayload.tcpPort)"

    $matches = @(Invoke-RestMethod "http://127.0.0.1:$ServerPort/admin/matches")
    $gameId = $matches[0].gameId
    $results["gameId"] = $gameId
    Write-Host "  Active match gameId: $gameId"

    # ===== Step 4: Launch 2 VISIBLE game clients =====
    Write-Host "=== Step 4: Launching 2 visible game clients ===" -ForegroundColor Cyan
    $gameExe = Join-Path $Root "Spiel\Battleroyalebuild\bapbap.exe"
    $gameDir = Join-Path $Root "Spiel\Battleroyalebuild"

    $client1Args = "--melonloader.agfoffline --bapcustom-use-proxy=false --bapcustom-show-ui=false --bapcustom-host=127.0.0.1 --bapcustom-server-port=$ServerPort --bapcustom-account-id=match-leader --bapcustom-username=MatchLeader --bapcustom-join-auth=$($leaderPayload.gameAuthId) --bapcustom-join-host=127.0.0.1 --bapcustom-join-ws=$($leaderPayload.wsPort) --bapcustom-join-kcp=$($leaderPayload.kcpPort) --bapcustom-join-tcp=$($leaderPayload.tcpPort)"
    $client1 = Start-Process -FilePath $gameExe -WorkingDirectory $gameDir -ArgumentList $client1Args -PassThru
    Write-Host "  Client 1 (Leader) started: PID $($client1.Id)"

    $client2Args = "--melonloader.agfoffline --bapcustom-use-proxy=false --bapcustom-show-ui=false --bapcustom-host=127.0.0.1 --bapcustom-server-port=$ServerPort --bapcustom-account-id=match-guest --bapcustom-username=MatchGuest --bapcustom-join-auth=$($guestPayload.gameAuthId) --bapcustom-join-host=127.0.0.1 --bapcustom-join-ws=$($guestPayload.wsPort) --bapcustom-join-kcp=$($guestPayload.kcpPort) --bapcustom-join-tcp=$($guestPayload.tcpPort)"
    $client2 = Start-Process -FilePath $gameExe -WorkingDirectory $gameDir -ArgumentList $client2Args -PassThru
    Write-Host "  Client 2 (Guest) started: PID $($client2.Id)"

    $results["client1Pid"] = $client1.Id
    $results["client2Pid"] = $client2.Id

    # ===== Step 5: Screenshots =====
    Write-Host "=== Step 5: Taking screenshots ===" -ForegroundColor Cyan
    Write-Host "  Waiting 30s for clients to boot..."
    Start-Sleep -Seconds 30
    
    $screenshotFiles = @()
    $intervals = @(30, 40, 50, 60, 70, 80)
    foreach ($sec in $intervals) {
        $file = Join-Path $LogDir "visual-match-${sec}s.png"
        Take-Screenshot $file
        $screenshotFiles += $file
        if ($sec -lt 80) { Start-Sleep -Seconds 10 }
    }
    $results["screenshots"] = $screenshotFiles

    # ===== Step 6: Wait for match to end =====
    Write-Host "=== Step 6: Waiting for match to end ===" -ForegroundColor Cyan
    $deadline = [DateTime]::UtcNow.AddSeconds($GameEndedTimeoutSeconds)
    $matchEnded = $false
    do {
        $currentMatches = @(Invoke-RestMethod "http://127.0.0.1:$ServerPort/admin/matches")
        $active = $currentMatches | Where-Object { $_.gameId -eq $gameId }
        if ($null -eq $active) {
            $matchEnded = $true
            break
        }
        Start-Sleep -Milliseconds 500
    } while ([DateTime]::UtcNow -lt $deadline)

    if ($matchEnded) {
        Write-Host "  Match ended successfully!" -ForegroundColor Green
    } else {
        Write-Host "  WARNING: Match did not end within timeout" -ForegroundColor Yellow
    }
    $results["matchEnded"] = $matchEnded

    # ===== Step 6b: Verify rewards =====
    Write-Host "=== Step 6b: Verifying rewards ===" -ForegroundColor Cyan
    Start-Sleep -Seconds 2

    try {
        $history = Invoke-RestMethod "http://127.0.0.1:$ServerPort/api/matches/history"
        $results["matchHistory"] = $history
        Write-Host "  Match history entries: $($history.Count)"
    } catch {
        Write-Host "  Could not fetch match history: $_" -ForegroundColor Yellow
        $results["matchHistory"] = $null
    }

    try {
        $leaderProfile = Invoke-RestMethod "http://127.0.0.1:$ServerPort/api/player/match-leader"
        $results["leaderGold"] = $leaderProfile.gold
        $results["leaderRanked"] = $leaderProfile.rankedPoints
        Write-Host "  Leader - Gold: $($leaderProfile.gold), Ranked: $($leaderProfile.rankedPoints)"
    } catch {
        Write-Host "  Could not fetch leader profile: $_" -ForegroundColor Yellow
    }

    try {
        $guestProfile = Invoke-RestMethod "http://127.0.0.1:$ServerPort/api/player/match-guest"
        $results["guestGold"] = $guestProfile.gold
        $results["guestRanked"] = $guestProfile.rankedPoints
        Write-Host "  Guest  - Gold: $($guestProfile.gold), Ranked: $($guestProfile.rankedPoints)"
    } catch {
        Write-Host "  Could not fetch guest profile: $_" -ForegroundColor Yellow
    }

    # Final screenshot
    $finalScreenshot = Join-Path $LogDir "visual-match-final.png"
    Take-Screenshot $finalScreenshot
    $screenshotFiles += $finalScreenshot

} finally {
    # ===== Step 7: Cleanup =====
    Write-Host "=== Step 7: Cleanup ===" -ForegroundColor Cyan

    if ($leader) { $leader.Abort(); $leader.Dispose() }
    if ($guest) { $guest.Abort(); $guest.Dispose() }
    Stop-ProcessSafe $client1
    Stop-ProcessSafe $client2
    
    # Kill any remaining game processes
    Get-Process -Name "bapbap" -ErrorAction SilentlyContinue | Stop-Process -Force -ErrorAction SilentlyContinue
    Stop-ProcessSafe $server

    Write-Host "  All processes stopped"

    # Restore production INI
    $prodIni = "[Server]`nHost=ark.atomi23.de`nPort=5056`nUseHttps=false`nUseLocalProxy=true`nLocalProxyPort=5055`n`n[Identity]`nAccountId=custom-7fe0915bc438`nUsername=appdata1`nAutoGuestLogin=true`n`n[UI]`nShowStatusChip=true`nUseNativeGameUi=true"
    Set-Content -Path (Join-Path $iniDir "BapCustomServer.ini") -Value $prodIni -Encoding UTF8
    Write-Host "  Production INI restored"
}

# ===== Step 8: Report =====
Write-Host ""
Write-Host "========================================" -ForegroundColor Green
Write-Host "  FULL MATCH TEST RESULTS" -ForegroundColor Green
Write-Host "========================================" -ForegroundColor Green
Write-Host "Server PID:       $($results['serverPid'])"
Write-Host "Client 1 PID:     $($results['client1Pid'])"
Write-Host "Client 2 PID:     $($results['client2Pid'])"
Write-Host "Game ID:          $($results['gameId'])"
Write-Host "Match Ended:      $($results['matchEnded'])"
Write-Host ""
Write-Host "Screenshots:" -ForegroundColor Cyan
foreach ($f in $screenshotFiles) {
    if (Test-Path $f) {
        $size = (Get-Item $f).Length / 1KB
        Write-Host "  $([IO.Path]::GetFileName($f)): $($size.ToString('0.0')) KB"
    }
}
Write-Host ""
Write-Host "Economy:" -ForegroundColor Cyan
Write-Host "  Leader Gold: $($results['leaderGold']), Ranked: $($results['leaderRanked'])"
Write-Host "  Guest  Gold: $($results['guestGold']), Ranked: $($results['guestRanked'])"
Write-Host ""

# Check game server logs
$gameLogDir = Join-Path $Root "CustomMatchServer\logs\game-servers"
if (Test-Path $gameLogDir) {
    $logFiles = Get-ChildItem $gameLogDir -Filter "*.log" -ErrorAction SilentlyContinue | Sort-Object LastWriteTime -Descending | Select-Object -First 3
    if ($logFiles) {
        Write-Host "Game Server Logs (latest):" -ForegroundColor Cyan
        foreach ($lf in $logFiles) {
            Write-Host "  $($lf.Name) ($($lf.Length / 1KB) KB)" 
            $tail = Get-Content $lf.FullName -Tail 5 -ErrorAction SilentlyContinue
            foreach ($line in $tail) { Write-Host "    $line" }
        }
    }
}

Write-Host ""
if ($results['matchEnded']) {
    Write-Host "TEST PASSED" -ForegroundColor Green
} else {
    Write-Host "TEST INCOMPLETE - match may not have ended" -ForegroundColor Yellow
}
