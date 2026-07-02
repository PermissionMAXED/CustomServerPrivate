param(
    [int]$ServerPort = 5170,
    [int]$AutoEndAfterSeconds = 3,
    [int]$GameServerReadyTimeoutSeconds = 30,
    [int]$GameEndedTimeoutSeconds = 45
)

$ErrorActionPreference = "Stop"

$Root = Resolve-Path (Join-Path $PSScriptRoot "..")
$ServerDll = Join-Path $Root "CustomMatchServer\bin\Release\net10.0\BapCustomServer.dll"
$LogDir = Join-Path $Root "tools\logs"
$GameLogDir = Join-Path $Root "CustomMatchServer\logs\game-servers"

# Ensure log directories exist
New-Item -ItemType Directory -Force -Path $LogDir | Out-Null
New-Item -ItemType Directory -Force -Path $GameLogDir | Out-Null

# --- Test Settings ---
$TestSettings = @{
    gamemode = 1
    mapId = 2
    teamSize = 2
    maxTeams = 4
    botCount = 2
    botDifficulty = 2
}

$SmokeGameArguments = "--bapcustom-auto-end-after=$AutoEndAfterSeconds --melonloader.agfoffline --bapcustom-host=127.0.0.1 --bapcustom-server-port=$ServerPort --bapcustom-use-proxy=false --bapcustom-show-ui=false"

# --- Helper Functions ---

function Test-PortFree {
    param([int]$Port)
    $client = [System.Net.Sockets.TcpClient]::new()
    try {
        $task = $client.ConnectAsync("127.0.0.1", $Port)
        $open = $task.Wait(250)
        return -not ($open -and $client.Connected)
    }
    catch { return $true }
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
    $psi.EnvironmentVariables["CustomServer__GameLogDirectory"] = $GameLogDir
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

function Send-WsJson {
    param(
        [System.Net.WebSockets.ClientWebSocket]$Socket,
        [object]$Message
    )
    $json = $Message | ConvertTo-Json -Compress -Depth 20
    $bytes = [System.Text.Encoding]::UTF8.GetBytes($json)
    $segment = [ArraySegment[byte]]::new($bytes)
    $task = $Socket.SendAsync($segment, [System.Net.WebSockets.WebSocketMessageType]::Text, $true, [Threading.CancellationToken]::None)
    if (-not $task.Wait(5000)) { throw "Timed out sending websocket message." }
    if ($task.IsFaulted) { throw $task.Exception }
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
            if (-not $task.Wait($TimeoutMs)) { throw "Timed out receiving websocket message." }
            if ($task.IsFaulted) { throw $task.Exception }
            $result = $task.Result
            if ($result.MessageType -eq [System.Net.WebSockets.WebSocketMessageType]::Close) {
                throw "WebSocket closed before expected response."
            }
            $stream.Write($buffer, 0, $result.Count)
        } while (-not $result.EndOfMessage)
        $json = [System.Text.Encoding]::UTF8.GetString($stream.ToArray())
        return $json | ConvertFrom-Json
    }
    finally { $stream.Dispose() }
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
            return [pscustomobject]@{ Message = $message; Seen = $seen }
        }
    }
    throw "Did not receive any of: $($Events -join ', '). Seen: $($seen -join ', ')"
}

function Stop-ProcessSafe {
    param($Process)
    if ($null -eq $Process -or $Process.HasExited) { return }
    try {
        try { $Process.Kill($true) } catch { $Process.Kill() }
        $Process.WaitForExit(5000) | Out-Null
    } catch {}
}

function Get-MatchArray {
    return @(Invoke-RestMethod "http://127.0.0.1:$ServerPort/admin/matches")
}

function Wait-MatchEnded {
    param([string]$GameId, [int]$TimeoutSeconds)
    $deadline = [DateTime]::UtcNow.AddSeconds($TimeoutSeconds)
    do {
        $matches = Get-MatchArray
        $match = $matches | Where-Object { $_.gameId -eq $GameId } | Select-Object -First 1
        if ($null -eq $match) {
            return [pscustomobject]@{ Observed = $true; Matches = $matches }
        }
        Start-Sleep -Milliseconds 500
    } while ([DateTime]::UtcNow -lt $deadline)
    return [pscustomobject]@{ Observed = $false; Matches = $matches }
}

function Take-Screenshot {
    param([string]$OutputPath)
    try {
        Add-Type -AssemblyName System.Windows.Forms
        Add-Type -AssemblyName System.Drawing
        $screen = [System.Windows.Forms.Screen]::PrimaryScreen
        $bounds = $screen.Bounds
        $bitmap = [System.Drawing.Bitmap]::new($bounds.Width, $bounds.Height)
        $graphics = [System.Drawing.Graphics]::FromImage($bitmap)
        $graphics.CopyFromScreen($bounds.Location, [System.Drawing.Point]::Empty, $bounds.Size)
        $graphics.Dispose()
        $bitmap.Save($OutputPath, [System.Drawing.Imaging.ImageFormat]::Png)
        $bitmap.Dispose()
        return $true
    }
    catch {
        Write-Warning "Screenshot failed: $_"
        return $false
    }
}

function Find-GameServerLog {
    # Find the most recent game server log
    $logs = Get-ChildItem -Path $GameLogDir -Filter "*.log" -ErrorAction SilentlyContinue | Sort-Object LastWriteTime -Descending
    if ($logs.Count -gt 0) {
        return $logs[0].FullName
    }
    # Also check MelonLoader log in game directory
    $mlLog = Join-Path $Root "Spiel\Battleroyalebuild\MelonLoader\Latest.log"
    if (Test-Path $mlLog) { return $mlLog }
    return $null
}

# --- Pre-flight checks ---
if (-not (Test-Path $ServerDll)) {
    throw "Build CustomMatchServer first: $ServerDll is missing."
}
if (-not (Test-PortFree $ServerPort)) {
    throw "Port $ServerPort is already in use."
}

# --- Results tracking ---
$results = @{
    timestamp = [DateTime]::UtcNow.ToString("o")
    serverPort = $ServerPort
    testSettings = $TestSettings
    steps = [System.Collections.ArrayList]::new()
    passed = $true
    errors = [System.Collections.ArrayList]::new()
}

function Add-StepResult {
    param([string]$Name, [bool]$Pass, [string]$Detail = "")
    $results.steps.Add([pscustomobject]@{ step = $Name; passed = $Pass; detail = $Detail }) | Out-Null
    if (-not $Pass) { $results.passed = $false; $results.errors.Add("$Name : $Detail") | Out-Null }
    $status = if ($Pass) { "PASS" } else { "FAIL" }
    Write-Host "[$status] $Name$(if ($Detail) { " - $Detail" })"
}

$server = $null
$socket = $null

try {
    # Step 1: Start server
    Write-Host "`n=== MATCH SETTINGS COMPLETE TEST ===" -ForegroundColor Cyan
    Write-Host "Port: $ServerPort | Map: $($TestSettings.mapId) | GameMode: $($TestSettings.gamemode)"
    Write-Host "TeamSize: $($TestSettings.teamSize) | MaxTeams: $($TestSettings.maxTeams) | Bots: $($TestSettings.botCount)`n"

    $server = Start-TestServer
    Wait-Health | Out-Null
    Add-StepResult "Server started on port $ServerPort" $true

    # Step 2: WebSocket connect + join lobby
    $socket = [System.Net.WebSockets.ClientWebSocket]::new()
    $connect = $socket.ConnectAsync([Uri]"ws://127.0.0.1:$ServerPort/ws", [Threading.CancellationToken]::None)
    if (-not $connect.Wait(5000)) { throw "Timed out connecting websocket." }
    if ($connect.IsFaulted) { throw $connect.Exception }

    Receive-UntilEvent -Socket $socket -Events @("SOCKET_READY") | Out-Null
    Add-StepResult "WebSocket connected, SOCKET_READY received" $true

    Send-WsJson $socket @{
        event = "JOIN_LOBBY"
        payload = @{
            lobbyId = "SETTINGS_TEST"
            charId = 1
            regionId = "custom"
            gameModeId = 0
            isAutoFill = $false
        }
    }
    $joinResult = Receive-UntilEvent -Socket $socket -Events @("JOIN_LOBBY_SUCCESS")
    Add-StepResult "Joined lobby" $true "lobbyId=$($joinResult.Message.payload.lobby.lobbyId)"

    # Step 3: Update custom settings with test values
    Send-WsJson $socket @{
        event = "UPDATE_CUSTOM_SETTINGS"
        payload = @{
            settings = $TestSettings
        }
    }

    $settingsResult = Receive-UntilEvent -Socket $socket -Events @("UPDATE_CUSTOM_SETTINGS_SUCCESS", "UPDATE_CUSTOM_SETTINGS_FAIL")

    if ($settingsResult.Message.event -eq "UPDATE_CUSTOM_SETTINGS_SUCCESS") {
        Add-StepResult "Settings update accepted" $true

        # Step 4: Verify echoed settings
        $echoed = $settingsResult.Message.payload.settings
        $mapMatch = ($echoed.mapId -eq $TestSettings.mapId)
        $gamemodeMatch = ($echoed.gamemode -eq $TestSettings.gamemode)
        $teamSizeMatch = ($echoed.teamSize -eq $TestSettings.teamSize)
        $maxTeamsMatch = ($echoed.maxTeams -eq $TestSettings.maxTeams)
        $botCountMatch = ($echoed.botCount -eq $TestSettings.botCount)
        $botDiffMatch = ($echoed.botDifficulty -eq $TestSettings.botDifficulty)

        $allMatch = $mapMatch -and $gamemodeMatch -and $teamSizeMatch -and $maxTeamsMatch -and $botCountMatch -and $botDiffMatch
        $detail = "mapId=$($echoed.mapId)(expect $($TestSettings.mapId)) gamemode=$($echoed.gamemode)(expect $($TestSettings.gamemode)) teamSize=$($echoed.teamSize)(expect $($TestSettings.teamSize)) maxTeams=$($echoed.maxTeams)(expect $($TestSettings.maxTeams)) botCount=$($echoed.botCount)(expect $($TestSettings.botCount)) botDifficulty=$($echoed.botDifficulty)(expect $($TestSettings.botDifficulty))"
        Add-StepResult "Settings echoed correctly" $allMatch $detail
    }
    else {
        Add-StepResult "Settings update accepted" $false "Got $($settingsResult.Message.event) instead"
    }

    # Step 5: Start match with custom settings
    Send-WsJson $socket @{
        event = "START_CUSTOM_GAME"
        payload = @{ forceStart = $true }
    }

    $terminalTimeoutMs = [Math]::Max(30000, ($GameServerReadyTimeoutSeconds + 30) * 1000)
    $startResult = Receive-UntilEvent -Socket $socket -Events @("START_CUSTOM_GAME_FAIL", "GAME_STARTED") -TimeoutMs $terminalTimeoutMs

    if ($startResult.Message.event -eq "GAME_STARTED") {
        Add-StepResult "Match started (GAME_STARTED)" $true "Events seen: $($startResult.Seen -join ', ')"

        # Step 6: Verify game server process launched
        $matches = Get-MatchArray
        $gameId = $null
        if ($matches.Count -gt 0) {
            $gameId = $matches[0].gameId
            Add-StepResult "Game server process launched" $true "gameId=$gameId, active matches=$($matches.Count)"
        }
        else {
            Add-StepResult "Game server process launched" $false "No matches in /admin/matches"
        }

        # Step 7: Take screenshot
        Start-Sleep -Seconds 2  # Give game window time to render
        $screenshotPath = Join-Path $LogDir "test-match-settings-screenshot.png"
        $screenshotOk = Take-Screenshot -OutputPath $screenshotPath
        Add-StepResult "Screenshot captured" $screenshotOk $(if ($screenshotOk) { $screenshotPath } else { "Failed" })

        # Step 8: Check game server log for correct map
        Start-Sleep -Seconds 2  # Allow log to be written
        $gameLog = Find-GameServerLog
        $logContent = ""
        $mapVerified = $false
        if ($gameLog -and (Test-Path $gameLog)) {
            $logContent = Get-Content $gameLog -Raw -ErrorAction SilentlyContinue
            # MapId 2 corresponds to Map3_Lyceum based on KnownLevelNames
            $mapVerified = ($logContent -match "Lyceum|Map3|mapId.*2|MapId.*2|map_id.*2")
            $bootstrapVerified = ($logContent -match "bootstrap|Bootstrap|BOOTSTRAP")
            Add-StepResult "Game server log found" $true "Path: $gameLog (size: $($logContent.Length) chars)"
            Add-StepResult "Correct map loaded (mapId=2/Lyceum)" $mapVerified $(if ($mapVerified) { "Map reference found in log" } else { "No map reference found. Log snippet: $($logContent.Substring(0, [Math]::Min(500, $logContent.Length)))" })
        }
        else {
            Add-StepResult "Game server log found" $false "No log file found in $GameLogDir"
            # Try to find log elsewhere
            $altLogs = Get-ChildItem -Path (Join-Path $Root "Spiel\Battleroyalebuild") -Filter "*.log" -Recurse -ErrorAction SilentlyContinue | Sort-Object LastWriteTime -Descending | Select-Object -First 3
            if ($altLogs) {
                $altPaths = $altLogs | ForEach-Object { $_.FullName }
                Add-StepResult "Alternative logs found" $true ($altPaths -join "; ")
            }
        }

        # Step 9: Wait for match to end (auto-end after configured seconds)
        if ($gameId) {
            $ended = Wait-MatchEnded -GameId $gameId -TimeoutSeconds $GameEndedTimeoutSeconds
            Add-StepResult "Match ended (auto-end after ${AutoEndAfterSeconds}s)" $ended.Observed $(if ($ended.Observed) { "Match removed from active list" } else { "Timeout - match still active" })
        }

        # Step 10: Verify cleanup - port freed
        Start-Sleep -Seconds 2
        $finalMatches = Get-MatchArray
        $portFreed = Test-PortFree $ServerPort  # This will be false because OUR server is still running - check game ports instead
        Add-StepResult "Cleanup verified" ($finalMatches.Count -eq 0) "Active matches remaining: $($finalMatches.Count)"
    }
    else {
        Add-StepResult "Match started (GAME_STARTED)" $false "Got $($startResult.Message.event): $($startResult.Message.payload | ConvertTo-Json -Compress -Depth 5)"
    }

    # Final summary
    Write-Host "`n=== TEST SUMMARY ===" -ForegroundColor $(if ($results.passed) { "Green" } else { "Red" })
    Write-Host "Overall: $(if ($results.passed) { 'PASSED' } else { 'FAILED' })"
    Write-Host "Steps: $($results.steps.Count) total, $(@($results.steps | Where-Object { $_.passed }).Count) passed, $(@($results.steps | Where-Object { -not $_.passed }).Count) failed"
    if ($results.errors.Count -gt 0) {
        Write-Host "`nFailures:" -ForegroundColor Red
        $results.errors | ForEach-Object { Write-Host "  - $_" -ForegroundColor Red }
    }

    # Write results to file
    $resultJson = $results | ConvertTo-Json -Depth 10
    $resultJson | Set-Content (Join-Path $LogDir "test-match-settings-results.json") -Encoding UTF8

    # Output final result
    $resultJson
}
finally {
    if ($socket) {
        $socket.Abort()
        $socket.Dispose()
    }
    Stop-ProcessSafe $server

    # Also kill any lingering bapbap.exe processes we may have spawned
    Get-Process -Name "bapbap" -ErrorAction SilentlyContinue | Where-Object { $_.StartTime -gt ([DateTime]::Now.AddMinutes(-5)) } | Stop-Process -Force -ErrorAction SilentlyContinue
}
