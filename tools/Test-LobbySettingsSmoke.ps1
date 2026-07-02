param(
    [int]$ServerPort = 5156
)

$ErrorActionPreference = "Stop"

$Root = Resolve-Path (Join-Path $PSScriptRoot "..")
$ServerDll = Join-Path $Root "CustomMatchServer\bin\Release\net10.0\BapCustomServer.dll"

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
    $psi.EnvironmentVariables["CustomServer__LaunchGameServers"] = "false"
    $psi.EnvironmentVariables["CustomServer__RequireGameServerBootstrap"] = "false"
    return [System.Diagnostics.Process]::Start($psi)
}

function Wait-Health {
    $deadline = [DateTime]::UtcNow.AddSeconds(10)
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

    $json = $Message | ConvertTo-Json -Compress -Depth 10
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
    param([System.Net.WebSockets.ClientWebSocket]$Socket)

    $buffer = New-Object byte[] 65536
    $stream = [System.IO.MemoryStream]::new()
    try {
        do {
            $segment = [ArraySegment[byte]]::new($buffer)
            $task = $Socket.ReceiveAsync($segment, [Threading.CancellationToken]::None)
            # JoinLobbyAsync deliberately delays ~6s before JOIN_LOBBY_SUCCESS (LobbyService.cs),
            # so the receive budget must exceed that.
            if (-not $task.Wait(9000)) {
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
        [string]$Event
    )

    for ($i = 0; $i -lt 20; $i++) {
        $message = Receive-WsJson $Socket
        if ($message.event -eq $Event) {
            return $message
        }
    }

    throw "Did not receive $Event."
}

function Stop-ProcessSafe {
    param($Process)

    if ($null -eq $Process -or $Process.HasExited) {
        return
    }

    try {
        $Process.Kill()
        $Process.WaitForExit(5000) | Out-Null
    }
    catch {
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

    Receive-UntilEvent $socket "SOCKET_READY" | Out-Null

    Send-WsJson $socket @{
        event = "JOIN_LOBBY"
        payload = @{
            lobbyId = "SMOKE1"
            charId = 1
            regionId = "custom"
            gameModeId = 0
            isAutoFill = $false
        }
    }

    $join = Receive-UntilEvent $socket "JOIN_LOBBY_SUCCESS"
    if ($join.payload.lobby.lobbyId -ne "SMOKE1") {
        throw "Unexpected lobby id in JOIN_LOBBY_SUCCESS."
    }

    Send-WsJson $socket @{
        event = "UPDATE_CUSTOM_SETTINGS"
        payload = @{
            settings = @{
                gamemode = 1
                mapId = 1
                teamSize = 2
                maxTeams = 4
                botCount = 1
                botDifficulty = 2
                gameModifierIds = @(101, 102)
                dimensionData = @(
                    @{
                        dimensionId = 7
                        rounds = @(1, 2)
                    }
                )
                matchmakingGameMode = 3
                charSelectMillis = 12345
                spawnSelectMillis = 6789
                spawnShowMillis = 2345
            }
        }
    }

    $settings = Receive-UntilEvent $socket "UPDATE_CUSTOM_SETTINGS_SUCCESS"
    $actual = $settings.payload.settings

    if ($actual.gamemode -ne 1 -or
        $actual.mapId -ne 1 -or
        $actual.teamSize -ne 2 -or
        $actual.maxTeams -ne 4 -or
        $actual.botCount -ne 1 -or
        $actual.botDifficulty -ne 2 -or
        $actual.gameModifierIds[0] -ne 101 -or
        $actual.gameModifierIds[1] -ne 102 -or
        $actual.dimensionData[0].dimensionId -ne 7 -or
        $actual.dimensionData[0].rounds[0] -ne 1 -or
        $actual.dimensionData[0].rounds[1] -ne 2 -or
        $actual.matchmakingGameMode -ne 3 -or
        $actual.charSelectMillis -ne 12345 -or
        $actual.spawnSelectMillis -ne 6789 -or
        $actual.spawnShowMillis -ne 2345) {
        throw "Custom settings response did not match requested values."
    }

    [pscustomobject]@{
        lobbyId = $join.payload.lobby.lobbyId
        gamemode = $actual.gamemode
        mapId = $actual.mapId
        teamSize = $actual.teamSize
        maxTeams = $actual.maxTeams
        botCount = $actual.botCount
        botDifficulty = $actual.botDifficulty
        gameModifierIds = @($actual.gameModifierIds)
        dimensionData = @($actual.dimensionData)
        matchmakingGameMode = $actual.matchmakingGameMode
        charSelectMillis = $actual.charSelectMillis
        spawnSelectMillis = $actual.spawnSelectMillis
        spawnShowMillis = $actual.spawnShowMillis
        updateEvent = $settings.event
    } | ConvertTo-Json -Compress
}
finally {
    if ($socket) {
        $socket.Abort()
        $socket.Dispose()
    }

    Stop-ProcessSafe $server
}
