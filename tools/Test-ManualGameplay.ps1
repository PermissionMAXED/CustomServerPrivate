param(
    [int]$ServerPort = 5190,
    [int]$GameServerReadyTimeoutSeconds = 150,
    [int]$LeaderCharId = 15,
    [int]$MapId = 34
)

$ErrorActionPreference = "Stop"
$Root = Resolve-Path (Join-Path $PSScriptRoot "..")
$ServerDll = Join-Path $Root "CustomMatchServer\bin\Release\net10.0\BapCustomServer.dll"
$GameExe = Join-Path $Root "Spiel\Battleroyalebuild\bapbap.exe"
$GameDir = Join-Path $Root "Spiel\Battleroyalebuild"

# Set up local INI
Write-Host "=== Setting up INI ===" -ForegroundColor Cyan
$iniDir = "C:\Users\Administrator\AppData\Roaming\BAPBAPBATTLEROYALE"
New-Item -ItemType Directory -Force -Path $iniDir | Out-Null
$ini = "[Server]`nHost=127.0.0.1`nPort=$ServerPort`nUseHttps=false`nUseLocalProxy=true`nLocalProxyPort=5055`n`n[Identity]`nAccountId=`nUsername=`nAutoGuestLogin=true`n`n[UI]`nShowStatusChip=true`nUseNativeGameUi=true"
Set-Content -Path (Join-Path $iniDir "BapCustomServer.ini") -Value $ini -Encoding UTF8
Write-Host "INI written for local server on port $ServerPort"

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
    $psi.EnvironmentVariables["CustomServer__GameServerManagedBootstrapListenerOnlyTimeoutSeconds"] = "45"
    if ($env:BAPBAP_NETCUSTOM_AUTOCAST -eq "1") { $psi.EnvironmentVariables["BAPBAP_NETCUSTOM_AUTOCAST"] = "1" }
    $psi.EnvironmentVariables["CustomServer__GameExecutablePath"] = $GameExe
    $psi.EnvironmentVariables["CustomServer__GameWorkingDirectory"] = $GameDir
    $psi.EnvironmentVariables["CustomServer__GameLogDirectory"] = (Join-Path $Root "CustomMatchServer\logs\game-servers")
    $psi.EnvironmentVariables["CustomServer__AdditionalGameArguments"] = "--melonloader.agfoffline --bapcustom-use-proxy=false --bapcustom-show-ui=false"
    return [System.Diagnostics.Process]::Start($psi)
}

function Wait-Health {
    $deadline = [DateTime]::UtcNow.AddSeconds(30)
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
    if (-not $connect.Wait(15000)) { throw "Timed out connecting websocket for $AccountId." }
    if ($connect.IsFaulted) { throw $connect.Exception }
    return $socket
}

function Send-WsJson([System.Net.WebSockets.ClientWebSocket]$Socket, [object]$Message) {
    $json = $Message | ConvertTo-Json -Compress -Depth 20
    $bytes = [System.Text.Encoding]::UTF8.GetBytes($json)
    $segment = [ArraySegment[byte]]::new($bytes)
    $task = $Socket.SendAsync($segment, [System.Net.WebSockets.WebSocketMessageType]::Text, $true, [Threading.CancellationToken]::None)
    if (-not $task.Wait(15000)) { throw "Timed out sending websocket message." }
    if ($task.IsFaulted) { throw $task.Exception }
}

function Receive-WsJson([System.Net.WebSockets.ClientWebSocket]$Socket, [int]$TimeoutMs = 15000) {
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

function Receive-UntilEvent([System.Net.WebSockets.ClientWebSocket]$Socket, [string[]]$Events, [int]$MaxMessages = 80, [int]$TimeoutMs = 15000) {
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

if (-not (Test-Path $ServerDll)) { throw "Build CustomMatchServer first: $ServerDll is missing." }
if (-not (Test-PortFree $ServerPort)) { throw "Port $ServerPort is already in use." }

$server = $null
$leader = $null
$guest = $null
$guest2 = $null
$client1 = $null
$client2 = $null
$client3 = $null

try {
    # Start Server
    Write-Host "=== Starting Server ===" -ForegroundColor Cyan
    $server = Start-TestServer
    Wait-Health | Out-Null
    Write-Host "Server running on port $ServerPort"

    # Match Orchestration via WebSocket (single Medusa player + bots)
    Write-Host "=== Setting up lobby and match ===" -ForegroundColor Cyan
    $leader = New-SmokeSocket -AccountId "match-leader" -Username "MatchLeader"
    Receive-UntilEvent -Socket $leader -Events @("SOCKET_READY") | Out-Null

    Send-WsJson $leader @{ event = "JOIN_LOBBY"; payload = @{ lobbyId = "PLAYTEST"; charId = $LeaderCharId; regionId = "custom"; gameModeId = 0; isAutoFill = $false } }
    Receive-UntilEvent -Socket $leader -Events @("JOIN_LOBBY_SUCCESS") -TimeoutMs 15000 | Out-Null
    Write-Host "  Joined lobby PLAYTEST as charId=$LeaderCharId"

    Send-WsJson $leader @{ event = "UPDATE_CUSTOM_SETTINGS"; payload = @{ settings = @{ gamemode = 1; mapId = $MapId; teamSize = 1; maxTeams = 2; botCount = 4; botDifficulty = 1 } } }
    Receive-UntilEvent -Socket $leader -Events @("UPDATE_CUSTOM_SETTINGS_SUCCESS") | Out-Null
    Write-Host "  Settings: mapId=$MapId botCount=4"

    Send-WsJson $leader @{ event = "START_CUSTOM_GAME"; payload = @{ forceStart = $true } }
    Write-Host "  Match start requested (waiting for game server boot)..."

    $terminalTimeoutMs = [Math]::Max(30000, ($GameServerReadyTimeoutSeconds + 30) * 1000)
    $leaderStarted = Receive-UntilEvent -Socket $leader -Events @("START_CUSTOM_GAME_FAIL", "GAME_STARTED") -TimeoutMs $terminalTimeoutMs
    if ($leaderStarted.Message.event -ne "GAME_STARTED") { throw "Did not receive GAME_STARTED. Got: $($leaderStarted.Message.event)" }
    $leaderPayload = $leaderStarted.Message.payload
    Write-Host "  GAME_STARTED mapId=$($leaderPayload.mapId)"

    Write-Host "=== Launching Game Client ===" -ForegroundColor Cyan
    # Proven playable client args (direct connect, native UI, no auto-input).
    $client1Args = "--melonloader.agfoffline --melonloader.captureplayerlogs --bapcustom-use-proxy=false --bapcustom-show-ui=false --bapcustom-host=127.0.0.1 --bapcustom-server-port=$ServerPort --bapcustom-account-id=match-leader --bapcustom-username=MatchLeader --bapcustom-auto-select-augment --bapcustom-selected-char=$LeaderCharId --bapcustom-join-auth=$($leaderPayload.gameAuthId) --bapcustom-join-host=127.0.0.1 --bapcustom-join-ws=$($leaderPayload.wsPort) --bapcustom-join-kcp=$($leaderPayload.kcpPort) --bapcustom-join-tcp=$($leaderPayload.tcpPort) --bapcustom-join-map=$($leaderPayload.mapId)"
    $client1 = Start-Process -FilePath $GameExe -WorkingDirectory $GameDir -ArgumentList $client1Args -PassThru
    Write-Host "  Medusa client started. PID: $($client1.Id)"

    Write-Host ""
    Write-Host "==========================================================" -ForegroundColor Green
    Write-Host " MATCH ACTIVE - play Medusa on the map!" -ForegroundColor Green
    Write-Host " - The game window has opened with 4 bots." -ForegroundColor Green
    Write-Host " - Close the game window when you're done." -ForegroundColor Green
    Write-Host "==========================================================" -ForegroundColor Green
    Write-Host ""

    # Keep server alive while the client window is open.
    while (-not $client1.HasExited) {
        Start-Sleep -Seconds 1
    }
    Write-Host "Client has closed. Cleaning up..."

} finally {
    Write-Host "=== Cleaning Up ===" -ForegroundColor Cyan
    if ($leader) { $leader.Abort(); $leader.Dispose() }
    if ($guest) { $guest.Abort(); $guest.Dispose() }
    if ($guest2) { $guest2.Abort(); $guest2.Dispose() }
    Stop-ProcessSafe $client1
    Stop-ProcessSafe $client2
    Stop-ProcessSafe $client3
    Get-Process -Name "bapbap" -ErrorAction SilentlyContinue | Stop-Process -Force -ErrorAction SilentlyContinue
    Stop-ProcessSafe $server

    # Restore production INI
    $prodIni = "[Server]`nHost=ark.atomi23.de`nPort=5056`nUseHttps=false`nUseLocalProxy=true`nLocalProxyPort=5055`n`n[Identity]`nAccountId=custom-7fe0915bc438`nUsername=appdata1`nAutoGuestLogin=true`n`n[UI]`nShowStatusChip=true`nUseNativeGameUi=true"
    Set-Content -Path (Join-Path $iniDir "BapCustomServer.ini") -Value $prodIni -Encoding UTF8
    Write-Host "  Production INI restored."
    Write-Host "TEST COMPLETE." -ForegroundColor Green
}
