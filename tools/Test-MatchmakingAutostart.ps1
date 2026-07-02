$ErrorActionPreference = "Stop"

$Root = "C:\Users\Administrator\Downloads\CustomServer"
$ServerPort = 5194
$ServerDll = Join-Path $Root "CustomMatchServer\bin\Release\net10.0\BapCustomServer.dll"
$GameExe = Join-Path $Root "Spiel\Battleroyalebuild\bapbap.exe"
$GameDir = Join-Path $Root "Spiel\Battleroyalebuild"
$GameLogDir = Join-Path $Root "CustomMatchServer\logs\game-servers"

$results = @()
function Add-Result {
    param([string]$Name, [bool]$Pass, [string]$Detail = "")
    $script:results += [pscustomobject]@{ Test = $Name; Result = if ($Pass) { "PASS" } else { "FAIL" }; Detail = $Detail }
    $status = if ($Pass) { "PASS" } else { "FAIL" }
    Write-Host "[$status] $Name$(if ($Detail) { " : $Detail" })" -ForegroundColor $(if ($Pass) { "Green" } else { "Red" })
}

function Stop-Safe {
    param($Item)
    if ($null -eq $Item) { return }
    try {
        if ($Item -is [System.Diagnostics.Process]) {
            if (-not $Item.HasExited) { $Item.Kill() }
            $Item.Dispose()
        } elseif ($Item.Process -is [System.Diagnostics.Process]) {
            if (-not $Item.Process.HasExited) { $Item.Process.Kill() }
            $Item.Process.Dispose()
        }
    } catch {}
}

function Send-WsJson {
    param([System.Net.WebSockets.ClientWebSocket]$Socket, [object]$Message)
    $json = $Message | ConvertTo-Json -Compress -Depth 20
    $bytes = [System.Text.Encoding]::UTF8.GetBytes($json)
    $task = $Socket.SendAsync(
        [ArraySegment[byte]]::new($bytes),
        [System.Net.WebSockets.WebSocketMessageType]::Text,
        $true,
        [Threading.CancellationToken]::None)
    if (-not $task.Wait(10000)) { throw "WebSocket send timeout" }
    if ($task.IsFaulted) { throw $task.Exception }
}

function Receive-WsJson {
    param([System.Net.WebSockets.ClientWebSocket]$Socket, [int]$TimeoutMs = 10000)
    $buffer = New-Object byte[] 65536
    $stream = [System.IO.MemoryStream]::new()
    try {
        $deadline = [DateTime]::UtcNow.AddMilliseconds($TimeoutMs)
        do {
            $remaining = [Math]::Max(1, [int]($deadline - [DateTime]::UtcNow).TotalMilliseconds)
            $cts = [Threading.CancellationTokenSource]::new($remaining)
            try {
                $task = $Socket.ReceiveAsync([ArraySegment[byte]]::new($buffer), $cts.Token)
                $task.Wait($remaining)
                if (-not $task.IsCompletedSuccessfully) { throw "WebSocket receive timeout" }
                $result = $task.Result
                if ($result.MessageType -eq [System.Net.WebSockets.WebSocketMessageType]::Close) { throw "WebSocket closed" }
                $stream.Write($buffer, 0, $result.Count)
            } finally {
                $cts.Dispose()
            }
        } until ($result.EndOfMessage)

        $json = [System.Text.Encoding]::UTF8.GetString($stream.ToArray())
        return $json | ConvertFrom-Json
    } finally {
        $stream.Dispose()
    }
}

function Receive-UntilEvent {
    param([System.Net.WebSockets.ClientWebSocket]$Socket, [string[]]$Events, [int]$TimeoutSec = 60)
    $deadline = [DateTime]::UtcNow.AddSeconds($TimeoutSec)
    $seen = @()
    while ([DateTime]::UtcNow -lt $deadline) {
        $msg = Receive-WsJson $Socket 10000
        $seen += $msg.event
        if ($Events -contains $msg.event) {
            return [pscustomobject]@{ Message = $msg; Seen = $seen }
        }
    }
    throw "Timed out waiting for one of: $($Events -join ', '); seen=$($seen -join ', ')"
}

function Start-AutoJoinClient {
    param([object]$Payload)
    $clientLog = Join-Path $GameLogDir "client-matchmaking-autostart.log"
    $args = "-batchmode -nographics -logFile `"$clientLog`" --melonloader.agfoffline --bapcustom-use-proxy=false --bapcustom-show-ui=false --bapcustom-host=127.0.0.1 --bapcustom-server-port=$ServerPort --bapcustom-account-id=mm-player --bapcustom-username=Matchmaker --bapcustom-join-auth=$($Payload.gameAuthId) --bapcustom-join-host=$($Payload.gameDns) --bapcustom-join-ws=$($Payload.wsPort) --bapcustom-join-kcp=$($Payload.kcpPort) --bapcustom-join-tcp=$($Payload.tcpPort)"
    $proc = Start-Process -FilePath $GameExe -WorkingDirectory $GameDir -ArgumentList $args -WindowStyle Hidden -PassThru
    return [pscustomobject]@{ Process = $proc; Log = $clientLog }
}

$server = $null
$ws = $null
$autoJoinClient = $null

try {
    Write-Host "`n=== MATCHMAKING AUTOSTART SMOKE ===" -ForegroundColor Cyan
    Get-Process bapbap -ErrorAction SilentlyContinue | Stop-Process -Force -ErrorAction SilentlyContinue
    @("data\economy-state.json", "data\ranked-state.json", "data\shop-state.json") | ForEach-Object {
        $path = Join-Path $Root $_
        if (Test-Path $path) { Remove-Item $path -Force }
    }

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
    $psi.EnvironmentVariables["CustomServer__GameServerReadyTimeoutSeconds"] = "150"
    $psi.EnvironmentVariables["CustomServer__GameExecutablePath"] = $GameExe
    $psi.EnvironmentVariables["CustomServer__GameWorkingDirectory"] = $GameDir
    $psi.EnvironmentVariables["CustomServer__GameLogDirectory"] = $GameLogDir
    $psi.EnvironmentVariables["CustomServer__MatchmakingQueue__QueueTimerSeconds"] = "2"
    $psi.EnvironmentVariables["CustomServer__MatchmakingQueue__MinPlayersToStart"] = "1"
    $psi.EnvironmentVariables["CustomServer__AdditionalGameArguments"] = "--melonloader.agfoffline --bapcustom-auto-end-after=5 --bapcustom-host=127.0.0.1 --bapcustom-server-port=$ServerPort --bapcustom-use-proxy=false --bapcustom-show-ui=false"
    $server = [System.Diagnostics.Process]::Start($psi)

    $healthy = $false
    $deadline = [DateTime]::UtcNow.AddSeconds(25)
    while ([DateTime]::UtcNow -lt $deadline) {
        try {
            Invoke-RestMethod "http://127.0.0.1:$ServerPort/health" -TimeoutSec 2 | Out-Null
            $healthy = $true
            break
        } catch {
            Start-Sleep -Milliseconds 500
        }
    }
    Add-Result "Server Health" $healthy "port=$ServerPort"
    if (-not $healthy) { throw "Server did not become healthy" }

    $ws = [System.Net.WebSockets.ClientWebSocket]::new()
    $connectTask = $ws.ConnectAsync([Uri]"ws://127.0.0.1:$ServerPort/ws?accountId=mm-player&username=Matchmaker&discriminator=4242", [Threading.CancellationToken]::None)
    if (-not $connectTask.Wait(10000)) { throw "WebSocket connect timeout" }
    if ($connectTask.IsFaulted) { throw $connectTask.Exception }
    Add-Result "WebSocket Connect State" ($ws.State -eq [System.Net.WebSockets.WebSocketState]::Open) "state=$($ws.State)"
    Receive-UntilEvent $ws @("SOCKET_READY") 20 | Out-Null
    Add-Result "WebSocket Connected" $true

    $headers = @{
        "X-BAP-AccountId" = "mm-player"
        "X-BAP-Username" = "Matchmaker"
        "X-BAP-Discriminator" = "4242"
    }
    $join = Invoke-RestMethod "http://127.0.0.1:$ServerPort/api/queue/join" -Method POST -Headers $headers -ContentType "application/json" -Body '{"charId":5}'
    Add-Result "Queue Join" ($join.ok -eq $true) "position=$($join.position), remaining=$($join.secondsRemaining)"

    $queueMatched = Receive-UntilEvent $ws @("QUEUE_MATCHED") 60
    Add-Result "Queue Matched Event" ($queueMatched.Message.event -eq "QUEUE_MATCHED") "players=$($queueMatched.Message.payload.currentPlayerCount)"

    $started = Receive-UntilEvent $ws @("GAME_STARTED") 60
    Add-Result "Game Started Event" ($started.Message.event -eq "GAME_STARTED") "ws=$($started.Message.payload.wsPort), kcp=$($started.Message.payload.kcpPort), tcp=$($started.Message.payload.tcpPort)"

    $autoJoinClient = Start-AutoJoinClient -Payload $started.Message.payload
    Add-Result "Auto-Join Client Started" ($null -ne $autoJoinClient.Process -and -not $autoJoinClient.Process.HasExited) "pid=$($autoJoinClient.Process.Id)"

    $matchEnded = $false
    $deadline = [DateTime]::UtcNow.AddSeconds(120)
    while ([DateTime]::UtcNow -lt $deadline) {
        $matches = @(Invoke-RestMethod "http://127.0.0.1:$ServerPort/admin/matches")
        if ($matches.Count -eq 0) {
            $matchEnded = $true
            break
        }
        Start-Sleep -Seconds 2
    }
    Add-Result "Match Ended" $matchEnded

    if (Test-Path $autoJoinClient.Log) {
        $clientLog = Get-Content $autoJoinClient.Log -Raw -ErrorAction SilentlyContinue
        $nreCount = ([regex]::Matches($clientLog, "NullReferenceException")).Count
        Add-Result "Auto-Join Client Log No NREs" ($nreCount -eq 0) "NREs=$nreCount"
    } else {
        Add-Result "Auto-Join Client Log Exists" $false $autoJoinClient.Log
    }
} catch {
    Add-Result "Matchmaking Autostart Exception" $false $_.ToString()
} finally {
    if ($ws) {
        try { $ws.Abort(); $ws.Dispose() } catch {}
    }
    Stop-Safe $autoJoinClient
    Stop-Safe $server
    Get-Process bapbap -ErrorAction SilentlyContinue | Stop-Process -Force -ErrorAction SilentlyContinue
}

$failed = @($results | Where-Object { $_.Result -eq "FAIL" })
Write-Host "`n=== MATCHMAKING AUTOSTART SUMMARY ===" -ForegroundColor Cyan
$results | ForEach-Object {
    Write-Host "[$($_.Result)] $($_.Test)$(if ($_.Detail) { " - $($_.Detail)" })"
}

if ($failed.Count -gt 0) {
    exit 1
}
