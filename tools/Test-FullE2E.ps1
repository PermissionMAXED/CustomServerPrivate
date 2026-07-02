$ErrorActionPreference = "Stop"

$Root = "C:\Users\Administrator\Downloads\CustomServer"
$ServerPort = 5192
$ServerDll = Join-Path $Root "CustomMatchServer\bin\Release\net10.0\BapCustomServer.dll"
$GameExe = Join-Path $Root "Spiel\Battleroyalebuild\bapbap.exe"
$GameDir = Join-Path $Root "Spiel\Battleroyalebuild"
$GameLogDir = Join-Path $Root "CustomMatchServer\logs\game-servers"
$IniPath = "C:\Users\Administrator\AppData\Roaming\BAPBAPBATTLEROYALE\BapCustomServer.ini"
$PlayerLogPath = "C:\Users\Administrator\AppData\LocalLow\gg.bapbap\BAPBAP\Player.log"

$results = @()
function Add-Result { param([string]$Name, [bool]$Pass, [string]$Detail = "")
    $script:results += [pscustomobject]@{ Test=$Name; Result=if($Pass){"PASS"}else{"FAIL"}; Detail=$Detail }
    $status = if($Pass){"PASS"}else{"FAIL"}
    Write-Host "[$status] $Name$(if($Detail){" : $Detail"})" -ForegroundColor $(if($Pass){"Green"}else{"Red"})
}

# --- CLEANUP FIRST ---
Write-Host "`n=== PRE-TEST CLEANUP ===" -ForegroundColor Cyan
Get-Process bapbap -ErrorAction SilentlyContinue | Stop-Process -Force -ErrorAction SilentlyContinue
Start-Sleep -Seconds 2
if (Test-Path $PlayerLogPath) {
    Remove-Item $PlayerLogPath -Force -ErrorAction SilentlyContinue
    Write-Host "  Deleted stale Player.log"
}

# Delete state files for clean test
@("data\economy-state.json","data\ranked-state.json","data\shop-state.json") | ForEach-Object {
    $f = Join-Path $Root $_
    if (Test-Path $f) { Remove-Item $f -Force; Write-Host "  Deleted: $_" }
}

# --- PHASE 0: SET INI ---
Write-Host "`n=== PHASE 0: SET INI ===" -ForegroundColor Cyan
$iniDir = Split-Path $IniPath
if (-not (Test-Path $iniDir)) { New-Item -ItemType Directory -Path $iniDir -Force | Out-Null }
$ini = "[Server]`nHost=127.0.0.1`nPort=$ServerPort`nUseHttps=false`nUseLocalProxy=true`nLocalProxyPort=5055`n`n[Identity]`nAccountId=custom-7fe0915bc438`nUsername=appdata1`nAutoGuestLogin=true`n`n[UI]`nShowStatusChip=true`nUseNativeGameUi=true"
Set-Content -Path $IniPath -Value $ini -Encoding UTF8
Write-Host "  INI set to local server on port $ServerPort"

# --- PHASE 1: SERVER START ---
Write-Host "`n=== PHASE 1: START SERVER ===" -ForegroundColor Cyan
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
$psi.EnvironmentVariables["CustomServer__AdditionalGameArguments"] = "--melonloader.agfoffline --bapcustom-auto-end-after=10 --bapcustom-host=127.0.0.1 --bapcustom-server-port=$ServerPort --bapcustom-use-proxy=false --bapcustom-show-ui=false"
$server = [System.Diagnostics.Process]::Start($psi)
Write-Host "  Server PID: $($server.Id)"

# Wait for health
$healthy = $false
$deadline = [DateTime]::UtcNow.AddSeconds(20)
while ([DateTime]::UtcNow -lt $deadline) {
    try {
        $h = Invoke-RestMethod "http://127.0.0.1:$ServerPort/health" -TimeoutSec 3
        $healthy = $true; break
    } catch { Start-Sleep -Milliseconds 500 }
}
Add-Result "Server Health Check" $healthy

if (-not $healthy) {
    Write-Host "Server failed to start. Aborting." -ForegroundColor Red
    if (-not $server.HasExited) { $server.Kill() }
    return
}

# --- WebSocket helpers ---
function Send-WsJson { param([System.Net.WebSockets.ClientWebSocket]$Socket, [object]$Message)
    $json = $Message | ConvertTo-Json -Compress -Depth 20
    $bytes = [System.Text.Encoding]::UTF8.GetBytes($json)
    $segment = [ArraySegment[byte]]::new($bytes)
    $task = $Socket.SendAsync($segment, [System.Net.WebSockets.WebSocketMessageType]::Text, $true, [Threading.CancellationToken]::None)
    if (-not $task.Wait(10000)) { throw "Send timeout" }
    if ($task.IsFaulted) { throw $task.Exception }
}

function Receive-WsJson { param([System.Net.WebSockets.ClientWebSocket]$Socket, [int]$TimeoutMs = 10000)
    $buffer = New-Object byte[] 65536
    $stream = [System.IO.MemoryStream]::new()
    try {
        do {
            $segment = [ArraySegment[byte]]::new($buffer)
            $task = $Socket.ReceiveAsync($segment, [Threading.CancellationToken]::None)
            if (-not $task.Wait($TimeoutMs)) { throw "Receive timeout (${TimeoutMs}ms)" }
            if ($task.IsFaulted) { throw $task.Exception }
            $result = $task.Result
            if ($result.MessageType -eq [System.Net.WebSockets.WebSocketMessageType]::Close) { throw "WS closed" }
            $stream.Write($buffer, 0, $result.Count)
        } while (-not $result.EndOfMessage)
        return ([System.Text.Encoding]::UTF8.GetString($stream.ToArray()) | ConvertFrom-Json)
    } finally { $stream.Dispose() }
}

function Receive-UntilEvent { param([System.Net.WebSockets.ClientWebSocket]$Socket, [string[]]$Events, [int]$MaxMessages = 80, [int]$TimeoutMs = 10000)
    $seen = @()
    for ($i = 0; $i -lt $MaxMessages; $i++) {
        $msg = Receive-WsJson -Socket $Socket -TimeoutMs $TimeoutMs
        $seen += $msg.event
        if ($Events -contains $msg.event) {
            return [pscustomobject]@{ Message=$msg; Seen=$seen }
        }
    }
    throw "Did not receive any of: $($Events -join ', '). Seen: $($seen -join ', ')"
}

# --- PHASE 1B: LOBBY + MATCH START ---
Write-Host "`n=== PHASE 1B: LOBBY + MATCH START ===" -ForegroundColor Cyan

$leader = $null; $guest = $null; $autoJoinClients = @()
$matchSuccess = $false; $gameId = $null; $leaderPayload = $null; $guestPayload = $null

try {
    # Connect 2 WebSocket clients
    $leader = [System.Net.WebSockets.ClientWebSocket]::new()
    $leaderUri = [Uri]"ws://127.0.0.1:${ServerPort}/ws?accountId=match-leader&username=Leader"
    $ct = $leader.ConnectAsync($leaderUri, [Threading.CancellationToken]::None)
    if (-not $ct.Wait(10000)) { throw "Leader WS connect timeout" }

    $guest = [System.Net.WebSockets.ClientWebSocket]::new()
    $guestUri = [Uri]"ws://127.0.0.1:${ServerPort}/ws?accountId=match-guest&username=Guest"
    $ct2 = $guest.ConnectAsync($guestUri, [Threading.CancellationToken]::None)
    if (-not $ct2.Wait(10000)) { throw "Guest WS connect timeout" }

    Receive-UntilEvent -Socket $leader -Events @("SOCKET_READY") | Out-Null
    Receive-UntilEvent -Socket $guest -Events @("SOCKET_READY") | Out-Null
    Write-Host "  Both clients connected and SOCKET_READY received"

    # Join lobby - leader
    Send-WsJson $leader @{ event="JOIN_LOBBY"; payload=@{ lobbyId="E2E_TEST"; charId=1; regionId="custom"; gameModeId=0; isAutoFill=$false } }
    $ljoin = Receive-UntilEvent -Socket $leader -Events @("JOIN_LOBBY_SUCCESS","JOIN_LOBBY_FAIL") -TimeoutMs 15000
    Add-Result "Leader Join Lobby" ($ljoin.Message.event -eq "JOIN_LOBBY_SUCCESS")

    # Join lobby - guest
    Send-WsJson $guest @{ event="JOIN_LOBBY"; payload=@{ lobbyId="E2E_TEST"; charId=5; regionId="custom"; gameModeId=0; isAutoFill=$false } }
    $gjoin = Receive-UntilEvent -Socket $guest -Events @("JOIN_LOBBY_SUCCESS","JOIN_LOBBY_FAIL") -TimeoutMs 15000
    Add-Result "Guest Join Lobby" ($gjoin.Message.event -eq "JOIN_LOBBY_SUCCESS")

    # Small delay to let server finish processing joins
    Start-Sleep -Seconds 2

    # Update settings: mapId=1, bots=0
    Write-Host "  Updating custom settings..."
    Send-WsJson $leader @{ event="UPDATE_CUSTOM_SETTINGS"; payload=@{ settings=@{ gamemode=1; mapId=1; teamSize=1; maxTeams=2; botCount=0; botDifficulty=1 } } }
    $settingsResult = Receive-UntilEvent -Socket $leader -Events @("UPDATE_CUSTOM_SETTINGS_SUCCESS","UPDATE_CUSTOM_SETTINGS_FAIL") -TimeoutMs 15000
    Add-Result "Update Custom Settings" ($settingsResult.Message.event -eq "UPDATE_CUSTOM_SETTINGS_SUCCESS")

    # Force-start match
    Write-Host "  Starting custom game (force-start)..."
    Send-WsJson $leader @{ event="START_CUSTOM_GAME"; payload=@{ forceStart=$true } }

    # Wait up to 180s for game server to boot
    $leaderStarted = Receive-UntilEvent -Socket $leader -Events @("START_CUSTOM_GAME_FAIL","GAME_STARTED") -TimeoutMs 180000
    Add-Result "Leader GAME_STARTED" ($leaderStarted.Message.event -eq "GAME_STARTED") $leaderStarted.Message.event

    if ($leaderStarted.Message.event -eq "GAME_STARTED") {
        $leaderPayload = $leaderStarted.Message.payload
        $guestStarted = Receive-UntilEvent -Socket $guest -Events @("GAME_STARTED") -TimeoutMs 30000
        Add-Result "Guest GAME_STARTED" ($guestStarted.Message.event -eq "GAME_STARTED")
        $guestPayload = $guestStarted.Message.payload

        # Get active match
        $matches = @(Invoke-RestMethod "http://127.0.0.1:$ServerPort/admin/matches")
        $gameId = $matches[0].gameId
        Write-Host "  Match active: gameId=$gameId"
        $matchSuccess = $true
    }
} catch {
    Write-Host "  ERROR during lobby/match: $_" -ForegroundColor Red
    Add-Result "Lobby/Match Phase" $false $_.ToString()
}

# --- PHASE 1C: AUTO-JOIN GAME CLIENTS ---
if ($matchSuccess) {
    Write-Host "`n=== PHASE 1C: AUTO-JOIN CLIENTS ===" -ForegroundColor Cyan

    function Start-AutoJoinClient { param([object]$Payload, [string]$AccountId, [string]$Label)
        $clientLog = Join-Path $GameLogDir ("client-e2e-{0}.log" -f $Label)
        $args = "-batchmode -nographics -logFile `"$clientLog`" --melonloader.agfoffline --bapcustom-use-proxy=false --bapcustom-show-ui=false --bapcustom-host=127.0.0.1 --bapcustom-server-port=$ServerPort --bapcustom-account-id=$AccountId --bapcustom-username=$Label --bapcustom-join-auth=$($Payload.gameAuthId) --bapcustom-join-host=$($Payload.gameDns) --bapcustom-join-ws=$($Payload.wsPort) --bapcustom-join-kcp=$($Payload.kcpPort) --bapcustom-join-tcp=$($Payload.tcpPort)"
        $proc = Start-Process -FilePath $GameExe -WorkingDirectory $GameDir -ArgumentList $args -WindowStyle Hidden -PassThru
        return [pscustomobject]@{ Process=$proc; Log=$clientLog; Label=$Label }
    }

    $autoJoinClients += Start-AutoJoinClient -Payload $leaderPayload -AccountId "match-leader" -Label "leader"
    $autoJoinClients += Start-AutoJoinClient -Payload $guestPayload -AccountId "match-guest" -Label "guest"
    Write-Host "  Started 2 auto-join clients (PIDs: $($autoJoinClients[0].Process.Id), $($autoJoinClients[1].Process.Id))"

    # Wait for match to end (up to 120s)
    Write-Host "  Waiting for match to end (timeout 120s)..."
    $matchEnded = $false
    $endDeadline = [DateTime]::UtcNow.AddSeconds(120)
    while ([DateTime]::UtcNow -lt $endDeadline) {
        $currentMatches = @(Invoke-RestMethod "http://127.0.0.1:$ServerPort/admin/matches")
        $found = $currentMatches | Where-Object { $_.gameId -eq $gameId }
        if ($null -eq $found) {
            $matchEnded = $true; break
        }
        Start-Sleep -Seconds 2
    }
    Add-Result "Match Ended Within Timeout" $matchEnded
}

# --- PHASE 1D: POST-MATCH VERIFICATION ---
Write-Host "`n=== PHASE 1D: POST-MATCH VERIFICATION ===" -ForegroundColor Cyan

# Check Player.log for NullReferenceExceptions
if (Test-Path $PlayerLogPath) {
    $logContent = Get-Content $PlayerLogPath -Raw -ErrorAction SilentlyContinue
    $nreCount = ([regex]::Matches($logContent, "NullReferenceException")).Count
    Add-Result "Player.log No NullReferenceExceptions" ($nreCount -eq 0) "Found $nreCount NREs"
} else {
    Add-Result "Player.log No NullReferenceExceptions" $true "No foreground Player.log produced by headless auto-join run"
}

# Match history
try {
    $history = @(Invoke-RestMethod "http://127.0.0.1:$ServerPort/api/matches/history")
    Add-Result "Match History Has Entry" ($history.Count -ge 1) "Count: $($history.Count)"
} catch {
    Add-Result "Match History Has Entry" $false $_.ToString()
}

# Economy rewards - the /api/load response has 'assets' array with assetId=1 being gold
try {
    $leaderLoad = Invoke-RestMethod "http://127.0.0.1:$ServerPort/api/load?accountId=match-leader&username=Leader"
    $goldAsset = $leaderLoad.assets | Where-Object { $_.assetId -eq 1 } | Select-Object -First 1
    $leaderGold = if ($goldAsset) { $goldAsset.balance } else { 0 }
    Add-Result "Leader Economy Rewards (gold > 1000)" ($leaderGold -gt 1000) "Gold: $leaderGold"
} catch {
    $leaderGold = 0
    Add-Result "Leader Economy Rewards" $false $_.ToString()
}

try {
    $guestLoad = Invoke-RestMethod "http://127.0.0.1:$ServerPort/api/load?accountId=match-guest&username=Guest"
    $gGoldAsset = $guestLoad.assets | Where-Object { $_.assetId -eq 1 } | Select-Object -First 1
    $guestGold = if ($gGoldAsset) { $gGoldAsset.balance } else { 0 }
    Add-Result "Guest Economy Rewards (gold > 1000)" ($guestGold -gt 1000) "Gold: $guestGold"
} catch {
    Add-Result "Guest Economy Rewards" $false $_.ToString()
}

# Ranked points changed from 1000
try {
    $ranked = Invoke-RestMethod "http://127.0.0.1:$ServerPort/api/ranked/self" -Headers @{ "X-BAP-AccountId"="match-leader" }
    $rankedPts = $ranked.points
    Add-Result "Ranked Points Changed (!=1000)" ($rankedPts -ne 1000) "Points: $rankedPts"
} catch {
    Add-Result "Ranked Points Changed" $false $_.ToString()
}

# --- PHASE 2: SHOP PURCHASE TEST ---
Write-Host "`n=== PHASE 2: SHOP PURCHASE ===" -ForegroundColor Cyan

# Admin adds a shop item
try {
    $addShopResult = Invoke-RestMethod "http://127.0.0.1:$ServerPort/admin/commands" -Method POST -ContentType "application/json" -Body '{"command":"add-shop-item","reason":"300007:200"}'
    Add-Result "Admin Add Shop Item" $true "Response: $($addShopResult | ConvertTo-Json -Compress)"
} catch {
    Add-Result "Admin Add Shop Item" $false $_.ToString()
}

# Player purchases it
try {
    $purchaseBody = '{"listingId":"shop-rotation-300007"}'
    $purchaseResult = Invoke-RestMethod "http://127.0.0.1:$ServerPort/api/shop/rotation/purchase" -Method POST -ContentType "application/json" -Body $purchaseBody -Headers @{ "X-BAP-AccountId"="match-leader"; "X-BAP-Username"="Leader" }
    Add-Result "Player Purchase Shop Item" $true "Response: $($purchaseResult | ConvertTo-Json -Compress)"
} catch {
    Add-Result "Player Purchase Shop Item" $false $_.ToString()
}

# Verify player's gold decreased and they own asset 300007
try {
    $postPurchaseLoad = Invoke-RestMethod "http://127.0.0.1:$ServerPort/api/load?accountId=match-leader&username=Leader"
    $postGoldAsset = $postPurchaseLoad.assets | Where-Object { $_.assetId -eq 1 } | Select-Object -First 1
    $postGold = if ($postGoldAsset) { $postGoldAsset.balance } else { 0 }
    $ownsAsset = ($postPurchaseLoad.assets | Where-Object { $_.assetId -eq 300007 }) -ne $null
    $goldDecreased = $postGold -lt $leaderGold
    Add-Result "Gold Decreased After Purchase" $goldDecreased "Before: $leaderGold, After: $postGold"
    Add-Result "Player Owns Asset 300007" ([bool]$ownsAsset) "Assets count: $($postPurchaseLoad.assets.Count)"
} catch {
    Add-Result "Post-Purchase Verification" $false $_.ToString()
}

# --- PHASE 3: PLAYER.LOG FINAL CHECK ---
Write-Host "`n=== PHASE 3: GAME CLIENT LOG CHECK ===" -ForegroundColor Cyan

# Check auto-join client logs
foreach ($client in $autoJoinClients) {
    if (Test-Path $client.Log) {
        $clog = Get-Content $client.Log -Raw -ErrorAction SilentlyContinue
        $cNre = ([regex]::Matches($clog, "NullReferenceException")).Count
        Add-Result "Client $($client.Label) Log No NREs" ($cNre -eq 0) "NREs: $cNre"
    } else {
        Add-Result "Client $($client.Label) Log Exists" $false "Not found: $($client.Log)"
    }
}

# --- CLEANUP ---
Write-Host "`n=== CLEANUP ===" -ForegroundColor Cyan

# Close WebSockets
if ($leader -and $leader.State -eq [System.Net.WebSockets.WebSocketState]::Open) {
    try { $leader.CloseAsync([System.Net.WebSockets.WebSocketCloseStatus]::NormalClosure, "", [Threading.CancellationToken]::None).Wait(2000) | Out-Null } catch {}
}
if ($leader) { $leader.Dispose() }
if ($guest -and $guest.State -eq [System.Net.WebSockets.WebSocketState]::Open) {
    try { $guest.CloseAsync([System.Net.WebSockets.WebSocketCloseStatus]::NormalClosure, "", [Threading.CancellationToken]::None).Wait(2000) | Out-Null } catch {}
}
if ($guest) { $guest.Dispose() }

# Kill game processes
foreach ($client in $autoJoinClients) {
    if ($client.Process -and -not $client.Process.HasExited) {
        try { $client.Process.Kill($true) } catch { try { $client.Process.Kill() } catch {} }
    }
}
Get-Process bapbap -ErrorAction SilentlyContinue | Stop-Process -Force -ErrorAction SilentlyContinue
Start-Sleep -Seconds 2

# Stop server
if ($server -and -not $server.HasExited) {
    try { $server.Kill($true) } catch { try { $server.Kill() } catch {} }
    $server.WaitForExit(5000) | Out-Null
}
Write-Host "  Server and game processes stopped"

# Restore INI
$restoreIni = "[Server]`nHost=ark.atomi23.de`nPort=5056`nUseHttps=false`nUseLocalProxy=true`nLocalProxyPort=5055`n`n[Identity]`nAccountId=custom-7fe0915bc438`nUsername=appdata1`nAutoGuestLogin=true`n`n[UI]`nShowStatusChip=true`nUseNativeGameUi=true"
Set-Content -Path $IniPath -Value $restoreIni -Encoding UTF8
Write-Host "  INI restored to ark.atomi23.de:5056"

# --- FINAL REPORT ---
Write-Host "`n" -NoNewline
Write-Host "============================================" -ForegroundColor Yellow
Write-Host "        FULL E2E TEST RESULTS SUMMARY       " -ForegroundColor Yellow
Write-Host "============================================" -ForegroundColor Yellow
$passCount = ($results | Where-Object { $_.Result -eq "PASS" }).Count
$failCount = ($results | Where-Object { $_.Result -eq "FAIL" }).Count
foreach ($r in $results) {
    $color = if($r.Result -eq "PASS"){"Green"}else{"Red"}
    Write-Host "  [$($r.Result)] $($r.Test)$(if($r.Detail){' - '+$r.Detail})" -ForegroundColor $color
}
Write-Host "--------------------------------------------" -ForegroundColor Yellow
Write-Host "  TOTAL: $($results.Count) tests | PASS: $passCount | FAIL: $failCount" -ForegroundColor $(if($failCount -eq 0){"Green"}else{"Red"})
Write-Host "============================================" -ForegroundColor Yellow
