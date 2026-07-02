param(
    [int]$ServerPort = 5159,
    [int]$GameServerReadyTimeoutSeconds = 150,
    [string]$AdditionalGameArguments = "--melonloader.debug --melonloader.captureplayerlogs --melonloader.agfoffline --bapcustom-auto-end-after=8",
    [int]$GameEndedTimeoutSeconds = 120
)

$ErrorActionPreference = "Stop"

$Root = Resolve-Path (Join-Path $PSScriptRoot "..")
$ServerDll = Join-Path $Root "CustomMatchServer\bin\Release\net10.0\BapCustomServer.dll"
$SmokeGameArguments = "$AdditionalGameArguments --bapcustom-host=127.0.0.1 --bapcustom-server-port=$ServerPort --bapcustom-use-proxy=false --bapcustom-show-ui=false"

function Test-PortFree {
    param([int]$Port)

    $client = [System.Net.Sockets.TcpClient]::new()
    try {
        $task = $client.ConnectAsync("127.0.0.1", $Port)
        $open = $task.Wait(250)
        return -not ($open -and $client.Connected)
    }
    catch {
        return $true
    }
    finally {
        $client.Dispose()
    }
}

function Start-TestServer {
    $psi = [System.Diagnostics.ProcessStartInfo]::new()
    $psi.FileName = "dotnet"
    $psi.Arguments = "`"$ServerDll`""
    $psi.WorkingDirectory = $Root
    $psi.UseShellExecute = $false
    $psi.RedirectStandardOutput = $false
    $psi.RedirectStandardError = $false
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
        try {
            return Invoke-RestMethod "http://127.0.0.1:$ServerPort/health"
        }
        catch {
            Start-Sleep -Milliseconds 250
        }
    } while ([DateTime]::UtcNow -lt $deadline)

    throw "Timed out waiting for server health."
}

function New-SmokeSocket {
    param(
        [string]$AccountId,
        [string]$Username
    )

    $socket = [System.Net.WebSockets.ClientWebSocket]::new()
    $uri = [Uri]"ws://127.0.0.1:$ServerPort/ws?accountId=$AccountId&username=$Username"
    $connect = $socket.ConnectAsync($uri, [Threading.CancellationToken]::None)
    if (-not $connect.Wait(5000)) {
        throw "Timed out connecting websocket for $AccountId."
    }
    if ($connect.IsFaulted) {
        throw $connect.Exception
    }

    return $socket
}

function Send-WsJson {
    param(
        [System.Net.WebSockets.ClientWebSocket]$Socket,
        [object]$Message
    )

    $json = $Message | ConvertTo-Json -Compress -Depth 20
    $bytes = [System.Text.Encoding]::UTF8.GetBytes($json)
    $segment = [ArraySegment[byte]]::new($bytes)
    $task = $Socket.SendAsync($segment, [System.Net.WebSockets.WebSocketMessageType]::Text, $true, [Threading.CancellationToken]::None)
    if (-not $task.Wait(5000)) {
        throw "Timed out sending websocket message."
    }
    if ($task.IsFaulted) {
        throw $task.Exception
    }
}

function Receive-WsJson {
    param(
        [System.Net.WebSockets.ClientWebSocket]$Socket,
        [int]$TimeoutMs = 5000
    )

    $buffer = New-Object byte[] 65536
    $stream = [System.IO.MemoryStream]::new()
    try {
        do {
            $segment = [ArraySegment[byte]]::new($buffer)
            $task = $Socket.ReceiveAsync($segment, [Threading.CancellationToken]::None)
            if (-not $task.Wait($TimeoutMs)) {
                throw "Timed out receiving websocket message."
            }
            if ($task.IsFaulted) {
                throw $task.Exception
            }

            $result = $task.Result
            if ($result.MessageType -eq [System.Net.WebSockets.WebSocketMessageType]::Close) {
                throw "WebSocket closed before expected response."
            }

            $stream.Write($buffer, 0, $result.Count)
        } while (-not $result.EndOfMessage)

        $json = [System.Text.Encoding]::UTF8.GetString($stream.ToArray())
        return $json | ConvertFrom-Json
    }
    finally {
        $stream.Dispose()
    }
}

function Receive-UntilEvent {
    param(
        [System.Net.WebSockets.ClientWebSocket]$Socket,
        [string[]]$Events,
        [int]$MaxMessages = 80,
        [int]$TimeoutMs = 5000
    )

    $seen = @()
    for ($i = 0; $i -lt $MaxMessages; $i++) {
        $message = Receive-WsJson -Socket $Socket -TimeoutMs $TimeoutMs
        $seen += $message.event
        if ($Events -contains $message.event) {
            return [pscustomobject]@{
                Message = $message
                Seen = $seen
            }
        }
    }

    throw "Did not receive any of: $($Events -join ', '). Seen: $($seen -join ', ')"
}

function Get-MatchArray {
    return @(Invoke-RestMethod "http://127.0.0.1:$ServerPort/admin/matches")
}

function Wait-MatchEnded {
    param(
        [string]$GameId,
        [int]$TimeoutSeconds
    )

    $deadline = [DateTime]::UtcNow.AddSeconds($TimeoutSeconds)
    $lastMatches = @()
    do {
        $lastMatches = Get-MatchArray
        $match = $lastMatches | Where-Object { $_.gameId -eq $GameId } | Select-Object -First 1
        if ($null -eq $match) {
            return [pscustomobject]@{
                Observed = $true
                Matches = $lastMatches
            }
        }

        Start-Sleep -Milliseconds 500
    } while ([DateTime]::UtcNow -lt $deadline)

    return [pscustomobject]@{
        Observed = $false
        Matches = $lastMatches
    }
}

function Start-AutoJoinClient {
    param(
        [object]$Payload,
        [string]$GameId,
        [string]$Label
    )

    $gameDirectory = Join-Path $Root "Spiel\Battleroyalebuild"
    $gameExecutable = Join-Path $gameDirectory "bapbap.exe"
    $logDirectory = Join-Path $Root "CustomMatchServer\logs\game-servers"
    $clientLog = Join-Path $logDirectory ("client-autojoin-{0}-{1}.log" -f $Label, $GameId)
    $args = "-logFile `"$clientLog`" --melonloader.debug --melonloader.captureplayerlogs --melonloader.agfoffline --bapcustom-use-proxy=false --bapcustom-show-ui=false --bapcustom-host=127.0.0.1 --bapcustom-server-port=$ServerPort --bapcustom-account-id=$Label --bapcustom-username=$Label --bapcustom-join-auth=$($Payload.gameAuthId) --bapcustom-join-host=$($Payload.gameDns) --bapcustom-join-ws=$($Payload.wsPort) --bapcustom-join-kcp=$($Payload.kcpPort) --bapcustom-join-tcp=$($Payload.tcpPort)"
    $process = Start-Process -FilePath $gameExecutable -WorkingDirectory $gameDirectory -ArgumentList $args -WindowStyle Hidden -PassThru

    return [pscustomobject]@{
        Process = $process
        Log = $clientLog
        Arguments = $args
    }
}

function Stop-ProcessSafe {
    param($Process)

    if ($null -eq $Process -or $Process.HasExited) {
        return
    }

    try {
        try {
            $Process.Kill($true)
        }
        catch {
            $Process.Kill()
        }

        $Process.WaitForExit(5000) | Out-Null
    }
    catch {
    }
}

if (-not (Test-Path $ServerDll)) {
    throw "Build CustomMatchServer first: $ServerDll is missing."
}

$server = $null
if (Test-PortFree $ServerPort) {
    Write-Host "Starting server on port $ServerPort"
    $server = Start-TestServer
    Wait-Health | Out-Null
} else {
    Write-Host "Using already running server on port $ServerPort"
}

$leader = $null
$guest = $null
$autoJoinClients = @()

try {
    $leader = New-SmokeSocket -AccountId "leader-smoke" -Username "LeaderSmoke"
    $guest = New-SmokeSocket -AccountId "guest-smoke" -Username "GuestSmoke"
    Receive-UntilEvent -Socket $leader -Events @("SOCKET_READY") | Out-Null
    Receive-UntilEvent -Socket $guest -Events @("SOCKET_READY") | Out-Null

    Send-WsJson $leader @{
        event = "JOIN_LOBBY"
        payload = @{
            lobbyId = "DUO1"
            charId = 1
            regionId = "custom"
            gameModeId = 0
            isAutoFill = $false
        }
    }
    $leaderJoin = Receive-UntilEvent -Socket $leader -Events @("JOIN_LOBBY_SUCCESS") -TimeoutMs 15000

    Send-WsJson $guest @{
        event = "JOIN_LOBBY"
        payload = @{
            lobbyId = "DUO1"
            charId = 5
            regionId = "custom"
            gameModeId = 0
            isAutoFill = $false
        }
    }
    $guestJoin = Receive-UntilEvent -Socket $guest -Events @("JOIN_LOBBY_SUCCESS") -TimeoutMs 15000

    Send-WsJson $leader @{
        event = "UPDATE_CUSTOM_SETTINGS"
        payload = @{
            settings = @{
                gamemode = 1
                mapId = 1
                teamSize = 1
                maxTeams = 2
                botCount = 0
                botDifficulty = 1
            }
        }
    }
    Receive-UntilEvent -Socket $leader -Events @("UPDATE_CUSTOM_SETTINGS_SUCCESS") | Out-Null

    Send-WsJson $leader @{
        event = "START_CUSTOM_GAME"
        payload = @{
            forceStart = $true
        }
    }

    $terminalTimeoutMs = [Math]::Max(30000, ($GameServerReadyTimeoutSeconds + 30) * 1000)
    $leaderStarted = Receive-UntilEvent -Socket $leader -Events @("START_CUSTOM_GAME_FAIL", "GAME_STARTED") -TimeoutMs $terminalTimeoutMs
    if ($leaderStarted.Message.event -ne "GAME_STARTED") {
        throw "Leader did not receive GAME_STARTED."
    }

    $guestStarted = Receive-UntilEvent -Socket $guest -Events @("GAME_STARTED") -TimeoutMs 30000
    $matches = Get-MatchArray
    if ($matches.Count -lt 1) {
        throw "No active match was returned by /admin/matches."
    }

    $gameId = $matches[0].gameId
    $autoJoinClients += Start-AutoJoinClient -Payload $leaderStarted.Message.payload -GameId $gameId -Label "leader-smoke"
    $autoJoinClients += Start-AutoJoinClient -Payload $guestStarted.Message.payload -GameId $gameId -Label "guest-smoke"

    $ended = Wait-MatchEnded -GameId $gameId -TimeoutSeconds $GameEndedTimeoutSeconds

    [pscustomobject]@{
        lobbyId = $leaderJoin.Message.payload.lobby.lobbyId
        guestLobbyId = $guestJoin.Message.payload.lobby.lobbyId
        additionalGameArguments = $SmokeGameArguments
        leaderSeenEvents = $leaderStarted.Seen
        guestSeenEvents = $guestStarted.Seen
        gameId = $gameId
        leaderGameStarted = $leaderStarted.Message.payload
        guestGameStarted = $guestStarted.Message.payload
        autoJoinClientProcessIds = @($autoJoinClients | ForEach-Object { $_.Process.Id })
        autoJoinClientLogs = @($autoJoinClients | ForEach-Object { $_.Log })
        matches = @($matches)
        gameEndedObserved = $ended.Observed
        postGameMatches = @($ended.Matches)
    } | ConvertTo-Json -Compress -Depth 20
}
finally {
    if ($leader) {
        $leader.Abort()
        $leader.Dispose()
    }

    if ($guest) {
        $guest.Abort()
        $guest.Dispose()
    }

    foreach ($client in $autoJoinClients) {
        Stop-ProcessSafe $client.Process
    }

    Stop-ProcessSafe $server
}
