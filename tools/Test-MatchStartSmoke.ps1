param(
    [int]$ServerPort = 5157,
    [bool]$LaunchGameServers = $true,
    [bool]$RequireGameServerBootstrap = $true,
    [int]$GameServerReadyTimeoutSeconds = 10,
    [string]$AdditionalGameArguments = "",
    [bool]$WaitForGameEnded = $false,
    [int]$GameEndedTimeoutSeconds = 75,
    [bool]$LaunchAutoJoinClient = $false,
    [int]$MapId = 1
)

$ErrorActionPreference = "Stop"

$Root = Resolve-Path (Join-Path $PSScriptRoot "..")
$ServerDll = Join-Path $Root "CustomMatchServer\bin\Release\net10.0\BapCustomServer.dll"
$SmokeGameArguments = "--bapcustom-host=127.0.0.1 --bapcustom-server-port=$ServerPort --bapcustom-use-proxy=false --bapcustom-show-ui=false"
if (-not [string]::IsNullOrWhiteSpace($AdditionalGameArguments)) {
    $SmokeGameArguments = "$AdditionalGameArguments $SmokeGameArguments"
}

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
    $psi.RedirectStandardOutput = $true
    $psi.RedirectStandardError = $true
    $psi.CreateNoWindow = $true
    $psi.EnvironmentVariables["ASPNETCORE_URLS"] = "http://127.0.0.1:$ServerPort"
    $psi.EnvironmentVariables["CustomServer__PublicBaseUrl"] = "http://127.0.0.1:$ServerPort"
    $psi.EnvironmentVariables["CustomServer__Admin__AllowLoopbackAdminWithoutToken"] = "true"
    $psi.EnvironmentVariables["CustomServer__LaunchGameServers"] = $LaunchGameServers.ToString().ToLowerInvariant()
    $psi.EnvironmentVariables["CustomServer__RequireGameServerBootstrap"] = $RequireGameServerBootstrap.ToString().ToLowerInvariant()
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
        [int]$MaxMessages = 40,
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
        [string]$GameId
    )

    $gameDirectory = Join-Path $Root "Spiel\Battleroyalebuild"
    $gameExecutable = Join-Path $gameDirectory "bapbap.exe"
    $logDirectory = Join-Path $Root "CustomMatchServer\logs\game-servers"
    $clientLog = Join-Path $logDirectory ("client-autojoin-{0}.log" -f $GameId)
    $args = "-logFile `"$clientLog`" --melonloader.debug --melonloader.captureplayerlogs --melonloader.agfoffline --bapcustom-use-proxy=false --bapcustom-show-ui=false --bapcustom-host=127.0.0.1 --bapcustom-server-port=$ServerPort --bapcustom-join-auth=$($Payload.gameAuthId) --bapcustom-join-host=$($Payload.gameDns) --bapcustom-join-ws=$($Payload.wsPort) --bapcustom-join-kcp=$($Payload.kcpPort) --bapcustom-join-tcp=$($Payload.tcpPort)"
    $process = Start-Process -FilePath $gameExecutable -WorkingDirectory $gameDirectory -ArgumentList $args -WindowStyle Hidden -PassThru

    return [pscustomobject]@{
        Process = $process
        Log = $clientLog
        Arguments = $args
    }
}

if (-not (Test-Path $ServerDll)) {
    throw "Build CustomMatchServer first: $ServerDll is missing."
}

if (-not (Test-PortFree $ServerPort)) {
    throw "Port $ServerPort is already in use."
}

$server = $null
$socket = $null
$autoJoinClient = $null

try {
    $server = Start-TestServer
    Wait-Health | Out-Null

    $socket = [System.Net.WebSockets.ClientWebSocket]::new()
    $connect = $socket.ConnectAsync([Uri]"ws://127.0.0.1:$ServerPort/ws", [Threading.CancellationToken]::None)
    if (-not $connect.Wait(5000)) {
        throw "Timed out connecting websocket."
    }
    if ($connect.IsFaulted) {
        throw $connect.Exception
    }

    Receive-UntilEvent -Socket $socket -Events @("SOCKET_READY") | Out-Null

    Send-WsJson $socket @{
        event = "JOIN_LOBBY"
        payload = @{
            lobbyId = "MATCH1"
            charId = 1
            regionId = "custom"
            gameModeId = 0
            isAutoFill = $false
        }
    }

    $join = Receive-UntilEvent -Socket $socket -Events @("JOIN_LOBBY_SUCCESS")

    Send-WsJson $socket @{
        event = "UPDATE_CUSTOM_SETTINGS"
        payload = @{
            settings = @{
                gamemode = 1
                mapId = $MapId
                teamSize = 1
                maxTeams = 2
                botCount = 1
                botDifficulty = 1
            }
        }
    }

    Receive-UntilEvent -Socket $socket -Events @("UPDATE_CUSTOM_SETTINGS_SUCCESS") | Out-Null

    Send-WsJson $socket @{
        event = "START_CUSTOM_GAME"
        payload = @{
            forceStart = $true
        }
    }

    $terminalTimeoutMs = [Math]::Max(30000, ($GameServerReadyTimeoutSeconds + 30) * 1000)
    $result = Receive-UntilEvent -Socket $socket -Events @("START_CUSTOM_GAME_FAIL", "GAME_STARTED") -TimeoutMs $terminalTimeoutMs
    $matches = Get-MatchArray
    $gameId = $null
    if ($matches.Count -gt 0) {
        $gameId = $matches[0].gameId
    }

    if ($LaunchAutoJoinClient) {
        if ([string]::IsNullOrWhiteSpace($gameId)) {
            throw "Cannot launch auto-join client because no match id was returned by /admin/matches."
        }

        $autoJoinClient = Start-AutoJoinClient -Payload $result.Message.payload -GameId $gameId
    }

    $gameEndedObserved = $false
    $postGameMatches = $matches
    if ($WaitForGameEnded) {
        if ([string]::IsNullOrWhiteSpace($gameId)) {
            throw "Cannot wait for game-ended because no match id was returned by /admin/matches."
        }

        $ended = Wait-MatchEnded -GameId $gameId -TimeoutSeconds $GameEndedTimeoutSeconds
        $gameEndedObserved = $ended.Observed
        $postGameMatches = $ended.Matches
    }

    [pscustomobject]@{
        lobbyId = $join.Message.payload.lobby.lobbyId
        launchGameServers = $LaunchGameServers
        requireGameServerBootstrap = $RequireGameServerBootstrap
        additionalGameArguments = $SmokeGameArguments
        terminalEvent = $result.Message.event
        payload = $result.Message.payload
        seenEvents = $result.Seen
        gameId = $gameId
        gameEndedObserved = $gameEndedObserved
        autoJoinClientProcessId = if ($autoJoinClient) { $autoJoinClient.Process.Id } else { $null }
        autoJoinClientLog = if ($autoJoinClient) { $autoJoinClient.Log } else { $null }
        matches = @($matches)
        postGameMatches = @($postGameMatches)
    } | ConvertTo-Json -Compress -Depth 20
}
finally {
    if ($socket) {
        $socket.Abort()
        $socket.Dispose()
    }

    if ($autoJoinClient) {
        Stop-ProcessSafe $autoJoinClient.Process
    }

    Stop-ProcessSafe $server
}
