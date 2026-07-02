param(
    [int]$Phase1Port = 5185,
    [int]$Phase8Port = 5186,
    [string]$AdminToken = "integration-test-token"
)

$ErrorActionPreference = "Stop"
$Root = "C:\Users\Administrator\Downloads\CustomServer"
$ServerDll = "$Root\CustomMatchServer\bin\Release\net10.0\BapCustomServer.dll"

if (-not (Test-Path $ServerDll)) {
    throw "Build CustomMatchServer first: $ServerDll is missing."
}

# ======================== Test Framework ========================
$passed = 0; $failed = 0; $total = 0; $failures = @()

function Assert($name, $condition, $detail = "") {
    $script:total++
    if ($condition) {
        $script:passed++
        Write-Host "[PASS] $name $(if($detail){" - $detail"})" -ForegroundColor Green
    } else {
        $script:failed++
        $script:failures += "${name}: $detail"
        Write-Host "[FAIL] $name $(if($detail){" - $detail"})" -ForegroundColor Red
    }
}

function Start-Server($port, $launchGame = "false", $additionalArgs = "") {
    $psi = [System.Diagnostics.ProcessStartInfo]::new()
    $psi.FileName = "dotnet"
    $psi.Arguments = "`"$ServerDll`""
    $psi.WorkingDirectory = $Root
    $psi.UseShellExecute = $false
    $psi.RedirectStandardOutput = $true
    $psi.RedirectStandardError = $true
    $psi.CreateNoWindow = $true
    $psi.EnvironmentVariables["ASPNETCORE_URLS"] = "http://127.0.0.1:$port"
    $psi.EnvironmentVariables["CustomServer__PublicBaseUrl"] = "http://127.0.0.1:$port"
    $psi.EnvironmentVariables["CustomServer__LaunchGameServers"] = $launchGame
    $psi.EnvironmentVariables["CustomServer__RequireGameServerBootstrap"] = "true"
    $psi.EnvironmentVariables["CustomServer__Admin__ApiToken"] = $AdminToken
    $psi.EnvironmentVariables["CustomServer__GameExecutablePath"] = "$Root\Spiel\Battleroyalebuild\bapbap.exe"
    $psi.EnvironmentVariables["CustomServer__GameWorkingDirectory"] = "$Root\Spiel\Battleroyalebuild"
    $psi.EnvironmentVariables["CustomServer__GameLogDirectory"] = "$Root\CustomMatchServer\logs\game-servers"
    $psi.EnvironmentVariables["CustomServer__GameServerReadyTimeoutSeconds"] = "150"
    if ($additionalArgs) {
        $psi.EnvironmentVariables["CustomServer__AdditionalGameArguments"] = $additionalArgs
    }
    return [System.Diagnostics.Process]::Start($psi)
}

function Wait-Health($port, $timeoutSec = 15) {
    $deadline = [DateTime]::UtcNow.AddSeconds($timeoutSec)
    do {
        try { $r = Invoke-RestMethod "http://127.0.0.1:$port/health" -TimeoutSec 2; return $true }
        catch { Start-Sleep -Milliseconds 300 }
    } while ([DateTime]::UtcNow -lt $deadline)
    return $false
}

function Stop-Safe($proc) {
    if ($proc -and !$proc.HasExited) { try { $proc.Kill(); $proc.WaitForExit(3000) | Out-Null } catch {} }
}

function Invoke-Api($port, $path, $method = "GET", $body = $null, $headers = @{}) {
    $url = "http://127.0.0.1:$port$path"
    $params = @{ Uri = $url; Method = $method; ContentType = "application/json"; Headers = $headers; TimeoutSec = 10 }
    if ($body) { $params["Body"] = $body }
    return Invoke-RestMethod @params
}

function Invoke-AdminCmd($port, $cmdBody) {
    $headers = @{ "X-BAP-Admin-Token" = $AdminToken; "X-BAP-Admin-Actor" = "integration-test" }
    return Invoke-RestMethod "http://127.0.0.1:$port/admin/commands" -Method Post -Headers $headers -ContentType "application/json" -Body ($cmdBody | ConvertTo-Json -Compress -Depth 5) -TimeoutSec 10
}

# ======================== WebSocket Helpers ========================
function New-WsSocket($port, $accountId, $username) {
    $socket = [System.Net.WebSockets.ClientWebSocket]::new()
    $uri = [Uri]"ws://127.0.0.1:$port/ws?accountId=$accountId&username=$username"
    $task = $socket.ConnectAsync($uri, [Threading.CancellationToken]::None)
    if (-not $task.Wait(5000)) { throw "WS connect timeout for $accountId" }
    if ($task.IsFaulted) { throw $task.Exception }
    return $socket
}

function Send-WsJson($socket, $msg) {
    $json = $msg | ConvertTo-Json -Compress -Depth 20
    $bytes = [System.Text.Encoding]::UTF8.GetBytes($json)
    $segment = [ArraySegment[byte]]::new($bytes)
    $task = $socket.SendAsync($segment, [System.Net.WebSockets.WebSocketMessageType]::Text, $true, [Threading.CancellationToken]::None)
    if (-not $task.Wait(5000)) { throw "WS send timeout" }
    if ($task.IsFaulted) { throw $task.Exception }
}

function Receive-WsJson($socket, $timeoutMs = 5000) {
    $buffer = New-Object byte[] 65536
    $stream = [System.IO.MemoryStream]::new()
    try {
        do {
            $segment = [ArraySegment[byte]]::new($buffer)
            $task = $socket.ReceiveAsync($segment, [Threading.CancellationToken]::None)
            if (-not $task.Wait($timeoutMs)) { throw "WS receive timeout" }
            if ($task.IsFaulted) { throw $task.Exception }
            $result = $task.Result
            if ($result.MessageType -eq [System.Net.WebSockets.WebSocketMessageType]::Close) { throw "WS closed" }
            $stream.Write($buffer, 0, $result.Count)
        } while (-not $result.EndOfMessage)
        $json = [System.Text.Encoding]::UTF8.GetString($stream.ToArray())
        return $json | ConvertFrom-Json
    } finally { $stream.Dispose() }
}

function Receive-UntilEvent($socket, [string[]]$events, $maxMsg = 50, $timeoutMs = 5000) {
    $seen = @()
    for ($i = 0; $i -lt $maxMsg; $i++) {
        $msg = Receive-WsJson $socket $timeoutMs
        $seen += $msg.event
        if ($events -contains $msg.event) { return [pscustomobject]@{ Message = $msg; Seen = $seen } }
    }
    throw "Did not receive any of: $($events -join ', '). Seen: $($seen -join ', ')"
}

# ======================== PHASE 1: Server Startup & Health ========================
Write-Host "`n========== PHASE 1: Server Startup & Health ==========" -ForegroundColor Cyan

# Clean state files for a fresh test run
$dataDir = "$Root\data"
$logsDir = "$Root\logs"
Remove-Item "$dataDir\economy-state.json" -Force -ErrorAction SilentlyContinue
Remove-Item "$dataDir\shop-state.json" -Force -ErrorAction SilentlyContinue
Remove-Item "$dataDir\ranked-state.json" -Force -ErrorAction SilentlyContinue
Remove-Item "$dataDir\admin-smoke-state.json" -Force -ErrorAction SilentlyContinue
Remove-Item "$dataDir\friends-state.json" -Force -ErrorAction SilentlyContinue
Remove-Item "$logsDir\match-history.jsonl" -Force -ErrorAction SilentlyContinue

$server1 = $null
try {
    $server1 = Start-Server $Phase1Port "false"
    $healthy = Wait-Health $Phase1Port
    Assert "Phase1: Server starts and /health responds" $healthy "port=$Phase1Port"

    if (-not $healthy) {
        Write-Host "Server failed to start. Cannot continue." -ForegroundColor Red
        throw "Server startup failed"
    }

    # Verify new endpoints respond
    $shop = Invoke-Api $Phase1Port "/api/shop"
    Assert "Phase1: /api/shop responds" ($null -ne $shop)

    $queueStatus = Invoke-Api $Phase1Port "/api/queue/status"
    Assert "Phase1: /api/queue/status responds" ($null -ne $queueStatus)

    $matchHistory = Invoke-Api $Phase1Port "/api/matches/history"
    Assert "Phase1: /api/matches/history responds" ($null -ne $matchHistory)

    $ranked = Invoke-Api $Phase1Port "/api/ranked/leaderboard"
    Assert "Phase1: /api/ranked/leaderboard responds" ($null -ne $ranked)

    $friends = Invoke-Api $Phase1Port "/api/friends" -headers @{"X-BAP-AccountId"="test";"X-BAP-Username"="Test"}
    Assert "Phase1: /api/friends responds" ($null -ne $friends)

    # ======================== PHASE 2: Economy System ========================
    Write-Host "`n========== PHASE 2: Economy System ==========" -ForegroundColor Cyan

    $headersA = @{ "X-BAP-AccountId" = "eco-player-a"; "X-BAP-Username" = "AlphaPlayer" }
    $headersB = @{ "X-BAP-AccountId" = "eco-player-b"; "X-BAP-Username" = "BetaPlayer" }

    # Player A loads - verify starting gold (1000)
    $loadA = Invoke-Api $Phase1Port "/api/load?accountId=eco-player-a&username=AlphaPlayer"
    $goldAssetA = $loadA.assets | Where-Object { $_.assetId -eq 1 } | Select-Object -First 1
    Assert "Phase2: Player A loads successfully" ($null -ne $loadA.accountId) "accountId=$($loadA.accountId)"
    Assert "Phase2: Player A starting gold = 1000" ($goldAssetA.balance -eq 1000) "balance=$($goldAssetA.balance)"

    # Player B loads - verify starting gold (1000)
    $loadB = Invoke-Api $Phase1Port "/api/load?accountId=eco-player-b&username=BetaPlayer"
    $goldAssetB = $loadB.assets | Where-Object { $_.assetId -eq 1 } | Select-Object -First 1
    Assert "Phase2: Player B loads successfully" ($null -ne $loadB.accountId) "accountId=$($loadB.accountId)"
    Assert "Phase2: Player B starting gold = 1000" ($goldAssetB.balance -eq 1000) "balance=$($goldAssetB.balance)"

    # Admin gives Player A 5000 gold
    $giveResult = Invoke-AdminCmd $Phase1Port @{ command = "give-gold"; accountId = "eco-player-a"; reason = "5000" }
    Assert "Phase2: Admin give-gold to Player A succeeds" ($giveResult.ok -eq $true) $giveResult.message

    # Verify Player A balance = 6000
    $loadA2 = Invoke-Api $Phase1Port "/api/load?accountId=eco-player-a&username=AlphaPlayer"
    $goldA2 = ($loadA2.assets | Where-Object { $_.assetId -eq 1 } | Select-Object -First 1).balance
    Assert "Phase2: Player A balance = 6000 after give" ($goldA2 -eq 6000) "balance=$goldA2"

    # Admin sets Player B gold to 9999
    $setResult = Invoke-AdminCmd $Phase1Port @{ command = "set-gold"; accountId = "eco-player-b"; reason = "9999" }
    Assert "Phase2: Admin set-gold Player B succeeds" ($setResult.ok -eq $true) $setResult.message

    # Verify Player B balance = 9999
    $loadB2 = Invoke-Api $Phase1Port "/api/load?accountId=eco-player-b&username=BetaPlayer"
    $goldB2 = ($loadB2.assets | Where-Object { $_.assetId -eq 1 } | Select-Object -First 1).balance
    Assert "Phase2: Player B balance = 9999 after set" ($goldB2 -eq 9999) "balance=$goldB2"

    # Economy leaderboard
    $ecoLb = Invoke-AdminCmd $Phase1Port @{ command = "economy-leaderboard" }
    Assert "Phase2: Economy leaderboard shows both players" ($ecoLb.ok -eq $true -and $ecoLb.data.Count -ge 2) "count=$($ecoLb.data.Count)"

    # ======================== PHASE 3: Shop System ========================
    Write-Host "`n========== PHASE 3: Shop System ==========" -ForegroundColor Cyan

    # Admin adds rotation item (assetId=300012, price=500)
    $addRotation = Invoke-AdminCmd $Phase1Port @{ command = "add-shop-item"; reason = "300012:500" }
    Assert "Phase3: Add rotation item 300012 at 500g" ($addRotation.ok -eq $true) $addRotation.message

    # Admin adds freebie (assetId=300007)
    $addFreebie = Invoke-AdminCmd $Phase1Port @{ command = "add-shop-freebie"; reason = "300007" }
    Assert "Phase3: Add freebie item 300007" ($addFreebie.ok -eq $true) $addFreebie.message

    # Verify /api/shop returns both
    $shopData = Invoke-Api $Phase1Port "/api/shop"
    $hasRotation = @($shopData.rotationListings | Where-Object { $_.rewards[0].assetId -eq 300012 }).Count -gt 0
    $hasFreebie = @($shopData.freebieListings | Where-Object { $_.rewards[0].assetId -eq 300007 }).Count -gt 0
    Assert "Phase3: Shop contains rotation item 300012" $hasRotation "rotationCount=$($shopData.rotationListings.Count)"
    Assert "Phase3: Shop contains freebie item 300007" $hasFreebie "freebieCount=$($shopData.freebieListings.Count)"

    # Player A purchases the rotation item
    $purchaseBody = @{ listingId = "shop-rotation-300012" } | ConvertTo-Json -Compress
    $purchaseResult = Invoke-Api $Phase1Port "/api/shop/rotation/purchase" -method "POST" -body $purchaseBody -headers $headersA
    Assert "Phase3: Player A purchases rotation item" ($purchaseResult.ok -eq $true) $purchaseResult.message
    # Verify gold deducted (6000 - 500 = 5500)
    $loadA3 = Invoke-Api $Phase1Port "/api/load?accountId=eco-player-a&username=AlphaPlayer"
    $goldA3 = ($loadA3.assets | Where-Object { $_.assetId -eq 1 } | Select-Object -First 1).balance
    Assert "Phase3: Player A gold deducted after purchase" ($goldA3 -eq 5500) "balance=$goldA3 (expected 5500)"

    # Player A claims freebie
    $freebieBody = @{ listingId = "shop-freebie-300007" } | ConvertTo-Json -Compress
    $freebieResult = Invoke-Api $Phase1Port "/api/shop/freebie/purchase" -method "POST" -body $freebieBody -headers $headersA
    Assert "Phase3: Player A claims freebie" ($freebieResult.ok -eq $true) $freebieResult.message

    # Player A loads again - verify owns 300012 and 300007
    $loadA4 = Invoke-Api $Phase1Port "/api/load?accountId=eco-player-a&username=AlphaPlayer"
    $owns300012 = @($loadA4.assets | Where-Object { $_.assetId -eq 300012 }).Count -gt 0
    $owns300007 = @($loadA4.assets | Where-Object { $_.assetId -eq 300007 }).Count -gt 0
    Assert "Phase3: Player A owns asset 300012" $owns300012
    Assert "Phase3: Player A owns asset 300007" $owns300007

    # Admin removes rotation item
    $removeResult = Invoke-AdminCmd $Phase1Port @{ command = "remove-shop-item"; reason = "shop-rotation-300012" }
    Assert "Phase3: Remove rotation item" ($removeResult.ok -eq $true) $removeResult.message

    # Verify shop updated (rotation should be empty, freebie still there)
    $shopData2 = Invoke-Api $Phase1Port "/api/shop"
    Assert "Phase3: Rotation empty after removal" ($shopData2.rotationListings.Count -eq 0) "count=$($shopData2.rotationListings.Count)"
    Assert "Phase3: Freebie still present" ($shopData2.freebieListings.Count -eq 1) "count=$($shopData2.freebieListings.Count)"

    # Admin clears shop
    $clearResult = Invoke-AdminCmd $Phase1Port @{ command = "clear-shop" }
    Assert "Phase3: Clear shop" ($clearResult.ok -eq $true) $clearResult.message

    $shopData3 = Invoke-Api $Phase1Port "/api/shop"
    Assert "Phase3: Shop empty after clear" ($shopData3.rotationListings.Count -eq 0 -and $shopData3.freebieListings.Count -eq 0)

    # ======================== PHASE 4: Ranked System ========================
    Write-Host "`n========== PHASE 4: Ranked System ==========" -ForegroundColor Cyan

    # Register players in ranked system by joining+leaving queue (triggers GetOrCreatePlayer)
    $regA = Invoke-Api $Phase1Port "/api/queue/join" -method "POST" -headers $headersA
    Invoke-Api $Phase1Port "/api/queue/leave" -method "POST" -headers $headersA | Out-Null
    $regB = Invoke-Api $Phase1Port "/api/queue/join" -method "POST" -headers $headersB
    Invoke-Api $Phase1Port "/api/queue/leave" -method "POST" -headers $headersB | Out-Null

    # Player A initial rank - Silver tier (1000 points, tier=2)
    $rankedSelfA = Invoke-Api $Phase1Port "/api/ranked/self" -headers $headersA
    Assert "Phase4: Player A initial points = 1000" ($rankedSelfA.points -eq 1000) "points=$($rankedSelfA.points)"
    Assert "Phase4: Player A initial tier = Silver" ($rankedSelfA.tierName -eq "Silver") "tier=$($rankedSelfA.tierName)"

    # Admin set Player A to 1175 points (simulates placement=1, kills=5: 100 + 75 = 175 points gain)
    $setPointsA = Invoke-AdminCmd $Phase1Port @{ command = "ranked-set-points"; accountId = "eco-player-a"; reason = "1175" }
    Assert "Phase4: Admin set Player A to 1175 points" ($setPointsA.ok -eq $true) $setPointsA.message

    $rankedA2 = Invoke-Api $Phase1Port "/api/ranked/self" -headers $headersA
    Assert "Phase4: Player A points increased to 1175" ($rankedA2.points -eq 1175) "points=$($rankedA2.points)"

    # Admin set Player B to 980 (simulates placement=8, kills=0: loss)
    $setPointsB = Invoke-AdminCmd $Phase1Port @{ command = "ranked-set-points"; accountId = "eco-player-b"; reason = "980" }
    Assert "Phase4: Admin set Player B to 980 points" ($setPointsB.ok -eq $true) $setPointsB.message

    $rankedB = Invoke-Api $Phase1Port "/api/ranked/self" -headers $headersB
    Assert "Phase4: Player B points = 980" ($rankedB.points -eq 980) "points=$($rankedB.points)"

    # Check leaderboard - Player A should be higher
    $lb = Invoke-Api $Phase1Port "/api/ranked/leaderboard"
    if ($lb.entries.Count -ge 2) {
        $posA = ($lb.entries | Where-Object { $_.accountId -eq "eco-player-a" }).position
        $posB = ($lb.entries | Where-Object { $_.accountId -eq "eco-player-b" }).position
        Assert "Phase4: Player A ranked higher than Player B" ($posA -lt $posB) "A_pos=$posA, B_pos=$posB"
    } else {
        Assert "Phase4: Leaderboard has both players" $false "entries=$($lb.entries.Count)"
    }

    # Admin resets Player B rank
    $resetB = Invoke-AdminCmd $Phase1Port @{ command = "ranked-reset"; accountId = "eco-player-b" }
    Assert "Phase4: Admin resets Player B rank" ($resetB.ok -eq $true) $resetB.message

    $rankedB2 = Invoke-Api $Phase1Port "/api/ranked/self" -headers $headersB
    Assert "Phase4: Player B reset to starting (1000)" ($rankedB2.points -eq 1000) "points=$($rankedB2.points)"

    # Admin sets Player A to 3000 points (Master tier)
    $setMaster = Invoke-AdminCmd $Phase1Port @{ command = "ranked-set-points"; accountId = "eco-player-a"; reason = "3000" }
    Assert "Phase4: Admin set Player A to 3000" ($setMaster.ok -eq $true) $setMaster.message

    $rankedA3 = Invoke-Api $Phase1Port "/api/ranked/self" -headers $headersA
    Assert "Phase4: Player A at Master tier" ($rankedA3.tierName -eq "Master") "tier=$($rankedA3.tierName), points=$($rankedA3.points)"

    # ======================== PHASE 5: Matchmaking Queue ========================
    Write-Host "`n========== PHASE 5: Matchmaking Queue ==========" -ForegroundColor Cyan

    # Player A joins queue
    $joinA = Invoke-Api $Phase1Port "/api/queue/join" -method "POST" -headers $headersA
    Assert "Phase5: Player A joins queue" ($joinA.ok -eq $true) "position=$($joinA.position), timer=$($joinA.secondsRemaining)s"
    Assert "Phase5: Player A timer ~ 30s" ($joinA.secondsRemaining -ge 28 -and $joinA.secondsRemaining -le 30) "seconds=$($joinA.secondsRemaining)"

    # Check queue status - 1 player, active
    $qs1 = Invoke-Api $Phase1Port "/api/queue/status"
    Assert "Phase5: Queue has 1 player" ($qs1.playerCount -eq 1) "count=$($qs1.playerCount)"
    Assert "Phase5: Queue is active" ($qs1.isActive -eq $true)

    # Player B joins
    $joinB = Invoke-Api $Phase1Port "/api/queue/join" -method "POST" -headers $headersB
    Assert "Phase5: Player B joins queue" ($joinB.ok -eq $true) "position=$($joinB.position)"

    # Check queue status - 2 players
    $qs2 = Invoke-Api $Phase1Port "/api/queue/status"
    Assert "Phase5: Queue has 2 players" ($qs2.playerCount -eq 2) "count=$($qs2.playerCount)"

    # Player A leaves
    $leaveA = Invoke-Api $Phase1Port "/api/queue/leave" -method "POST" -headers $headersA
    Assert "Phase5: Player A leaves queue" ($leaveA.ok -eq $true) $leaveA.message

    # Check queue status - 1 player
    $qs3 = Invoke-Api $Phase1Port "/api/queue/status"
    Assert "Phase5: Queue has 1 player after leave" ($qs3.playerCount -eq 1) "count=$($qs3.playerCount)"

    # Player B leaves
    $leaveB = Invoke-Api $Phase1Port "/api/queue/leave" -method "POST" -headers $headersB
    Assert "Phase5: Player B leaves queue" ($leaveB.ok -eq $true) $leaveB.message

    # Check queue empty and inactive
    $qs4 = Invoke-Api $Phase1Port "/api/queue/status"
    Assert "Phase5: Queue empty" ($qs4.playerCount -eq 0) "count=$($qs4.playerCount)"
    Assert "Phase5: Queue inactive" ($qs4.isActive -eq $false)

    # ======================== PHASE 6: Match History ========================
    Write-Host "`n========== PHASE 6: Match History ==========" -ForegroundColor Cyan

    $history = Invoke-Api $Phase1Port "/api/matches/history"
    Assert "Phase6: Match history endpoint works" ($null -ne $history)
    Assert "Phase6: History initially empty" ($history.matches.Count -eq 0) "count=$($history.matches.Count)"

    # Verify player history endpoint
    $playerHistory = Invoke-Api $Phase1Port "/api/matches/player/eco-player-a"
    Assert "Phase6: Player match history works" ($null -ne $playerHistory)
    Assert "Phase6: Player history initially empty" ($playerHistory.matches.Count -eq 0)

    # ======================== PHASE 7: Friends System ========================
    Write-Host "`n========== PHASE 7: Friends System ==========" -ForegroundColor Cyan

    $fHeadersA = @{ "X-BAP-AccountId" = "eco-player-a"; "X-BAP-Username" = "AlphaPlayer"; "X-BAP-Discriminator" = "1001" }
    $fHeadersB = @{ "X-BAP-AccountId" = "eco-player-b"; "X-BAP-Username" = "BetaPlayer"; "X-BAP-Discriminator" = "2002" }

    # Player A sends friend request to Player B
    $addFriend = Invoke-Api $Phase1Port "/api/friends/add" -method "POST" -body '{"accountId":"eco-player-b"}' -headers $fHeadersA
    Assert "Phase7: Player A sends friend request" ($addFriend.ok -eq $true) $addFriend.message

    # Player B accepts
    $acceptFriend = Invoke-Api $Phase1Port "/api/friends/accept" -method "POST" -body '{"accountId":"eco-player-a"}' -headers $fHeadersB
    Assert "Phase7: Player B accepts friend request" ($acceptFriend.ok -eq $true) $acceptFriend.message

    # Verify both see each other
    $friendsListA = Invoke-Api $Phase1Port "/api/friends" -headers $fHeadersA
    $friendsListB = Invoke-Api $Phase1Port "/api/friends" -headers $fHeadersB
    Assert "Phase7: Player A sees Player B in friends" ($friendsListA.friends.Count -ge 1) "count=$($friendsListA.friends.Count)"
    Assert "Phase7: Player B sees Player A in friends" ($friendsListB.friends.Count -ge 1) "count=$($friendsListB.friends.Count)"

    # Player A invites Player B (party invite) - requires WebSocket connection for "online" status
    # Connect lightweight WS sessions for online presence
    $wsA = $null; $wsB = $null
    try {
        $wsA = New-WsSocket $Phase1Port "eco-player-a" "AlphaPlayer"
        $wsB = New-WsSocket $Phase1Port "eco-player-b" "BetaPlayer"
        Receive-UntilEvent $wsA @("SOCKET_READY") | Out-Null
        Receive-UntilEvent $wsB @("SOCKET_READY") | Out-Null

        # Join a lobby so Player A has a lobbyId
        Send-WsJson $wsA @{ event = "JOIN_LOBBY"; payload = @{ lobbyId = "DUO1"; charId = 1; regionId = "custom"; gameModeId = 0; isAutoFill = $false } }
        Receive-UntilEvent $wsA @("JOIN_LOBBY_SUCCESS") | Out-Null

        $inviteBody = @{ accountId = "eco-player-b"; lobbyId = "DUO1" } | ConvertTo-Json -Compress
        $inviteResult = Invoke-Api $Phase1Port "/api/friends/invite" -method "POST" -body $inviteBody -headers $fHeadersA
        Assert "Phase7: Player A sends party invite" ($inviteResult.ok -eq $true) $inviteResult.message

        # Player B checks invites
        $invites = Invoke-Api $Phase1Port "/api/friends/invites" -headers $fHeadersB
        Assert "Phase7: Player B has pending invite" ($invites.invites.Count -ge 1) "count=$($invites.invites.Count)"
    } catch {
        Assert "Phase7: Player A sends party invite" $false "Error: $_"
        Assert "Phase7: Player B has pending invite" $false "Error: $_"
    } finally {
        if ($wsA) { try { $wsA.Abort(); $wsA.Dispose() } catch {} }
        if ($wsB) { try { $wsB.Abort(); $wsB.Dispose() } catch {} }
    }

    # Player A removes Player B
    $removeFriend = Invoke-Api $Phase1Port "/api/friends/remove" -method "POST" -body '{"accountId":"eco-player-b"}' -headers $fHeadersA
    Assert "Phase7: Player A removes Player B" ($removeFriend.ok -eq $true) $removeFriend.message

    $friendsAfter = Invoke-Api $Phase1Port "/api/friends" -headers $fHeadersA
    Assert "Phase7: Friends list empty after removal" ($friendsAfter.friends.Count -eq 0) "count=$($friendsAfter.friends.Count)"

} catch {
    Write-Host "[ERROR] Phase 1-7 exception: $_" -ForegroundColor Red
    $failed++; $total++; $failures += "Phase1-7 Exception: $_"
} finally {
    Stop-Safe $server1
}

# ======================== PHASE 8: Full Match Start ========================
Write-Host "`n========== PHASE 8: Full Match Start (Game Server) ==========" -ForegroundColor Cyan

$server2 = $null
$leaderWs = $null
$guestWs = $null

try {
    # Check if game executable exists
    $gameExe = "$Root\Spiel\Battleroyalebuild\bapbap.exe"
    if (-not (Test-Path $gameExe)) {
        Write-Host "[SKIP] Phase 8 skipped - game executable not found at $gameExe" -ForegroundColor Yellow
        $total++; $passed++
        Assert "Phase8: SKIPPED (no game exe)" $true "Game executable not available"
    } else {
        $smokeArgs = "--melonloader.debug --melonloader.captureplayerlogs --melonloader.agfoffline --bapcustom-auto-end-after=5 --bapcustom-host=127.0.0.1 --bapcustom-server-port=$Phase8Port --bapcustom-use-proxy=false --bapcustom-show-ui=false"
        $server2 = Start-Server $Phase8Port "true" $smokeArgs
        $healthy2 = Wait-Health $Phase8Port 20
        Assert "Phase8: Server starts with LaunchGameServers=true" $healthy2 "port=$Phase8Port"

        if ($healthy2) {
            # Connect 2 WebSocket clients
            $leaderWs = New-WsSocket $Phase8Port "leader-integ" "LeaderInteg"
            $guestWs = New-WsSocket $Phase8Port "guest-integ" "GuestInteg"

            $leaderReady = Receive-UntilEvent $leaderWs @("SOCKET_READY")
            $guestReady = Receive-UntilEvent $guestWs @("SOCKET_READY")
            Assert "Phase8: Leader connected" ($leaderReady.Message.event -eq "SOCKET_READY")
            Assert "Phase8: Guest connected" ($guestReady.Message.event -eq "SOCKET_READY")

            # Join same lobby
            Send-WsJson $leaderWs @{ event = "JOIN_LOBBY"; payload = @{ lobbyId = "DUO1"; charId = 1; regionId = "custom"; gameModeId = 0; isAutoFill = $false } }
            $leaderJoin = Receive-UntilEvent $leaderWs @("JOIN_LOBBY_SUCCESS")
            Assert "Phase8: Leader joined lobby" ($leaderJoin.Message.event -eq "JOIN_LOBBY_SUCCESS")

            Send-WsJson $guestWs @{ event = "JOIN_LOBBY"; payload = @{ lobbyId = "DUO1"; charId = 5; regionId = "custom"; gameModeId = 0; isAutoFill = $false } }
            $guestJoin = Receive-UntilEvent $guestWs @("JOIN_LOBBY_SUCCESS")
            Assert "Phase8: Guest joined lobby" ($guestJoin.Message.event -eq "JOIN_LOBBY_SUCCESS")

            # Configure settings (mapId=2, bots=2)
            Send-WsJson $leaderWs @{
                event = "UPDATE_CUSTOM_SETTINGS"
                payload = @{
                    settings = @{
                        gamemode = 1
                        mapId = 2
                        teamSize = 1
                        maxTeams = 2
                        botCount = 2
                        botDifficulty = 1
                    }
                }
            }
            $settingsOk = Receive-UntilEvent $leaderWs @("UPDATE_CUSTOM_SETTINGS_SUCCESS")
            Assert "Phase8: Settings updated" ($settingsOk.Message.event -eq "UPDATE_CUSTOM_SETTINGS_SUCCESS")

            # Start match
            Send-WsJson $leaderWs @{ event = "START_CUSTOM_GAME"; payload = @{ forceStart = $true } }

            # Wait for GAME_STARTED (allow up to 180s for game server to boot)
            $gameStartTimeout = 180 * 1000
            $leaderStarted = Receive-UntilEvent $leaderWs @("START_CUSTOM_GAME_FAIL", "GAME_STARTED") -maxMsg 80 -timeoutMs $gameStartTimeout
            Assert "Phase8: Leader received GAME_STARTED" ($leaderStarted.Message.event -eq "GAME_STARTED") "event=$($leaderStarted.Message.event)"

            if ($leaderStarted.Message.event -eq "GAME_STARTED") {
                $guestStarted = Receive-UntilEvent $guestWs @("GAME_STARTED") -timeoutMs 30000
                Assert "Phase8: Guest received GAME_STARTED" ($guestStarted.Message.event -eq "GAME_STARTED")

                # Wait for game to auto-end (bapcustom-auto-end-after=5 seconds + processing)
                # Note: game-ended callback requires game clients to connect to the game server.
                # Without actual game client processes joining, the game may not auto-end.
                Write-Host "  Waiting for game to auto-end (polling up to 45s)..." -ForegroundColor Gray
                $gameEndDeadline = [DateTime]::UtcNow.AddSeconds(45)
                $matchRecorded = $false
                while ([DateTime]::UtcNow -lt $gameEndDeadline) {
                    Start-Sleep -Seconds 5
                    try {
                        $histCheck = Invoke-Api $Phase8Port "/api/matches/history"
                        if ($histCheck.matches.Count -ge 1) { $matchRecorded = $true; break }
                    } catch {}
                }

                # Check match history was recorded
                $historyAfter = Invoke-Api $Phase8Port "/api/matches/history"
                if ($historyAfter.matches.Count -ge 1) {
                    Assert "Phase8: Match history recorded" $true "count=$($historyAfter.matches.Count)"
                } else {
                    # Game-ended requires game clients to actually join the game server process.
                    # If no auto-join clients are launched, game won't trigger the ended callback.
                    Write-Host "  [INFO] Game-ended callback not received (requires game client auto-join)" -ForegroundColor Yellow
                    Assert "Phase8: Match history recorded" $false "count=0 (game-ended callback requires auto-join clients)"
                }

                # Check economy rewards (leader should have gotten rewards - gold > starting 1000)
                $loadLeader = Invoke-Api $Phase8Port "/api/load?accountId=leader-integ&username=LeaderInteg"
                $leaderGold = ($loadLeader.assets | Where-Object { $_.assetId -eq 1 } | Select-Object -First 1).balance
                if ($matchRecorded) {
                    Assert "Phase8: Economy rewards applied (gold > 1000)" ($leaderGold -gt 1000) "gold=$leaderGold"
                } else {
                    Assert "Phase8: Economy rewards applied (gold > 1000)" $false "gold=$leaderGold (game-ended not triggered)"
                }

                # Check ranked points changed
                $rankedLeader = Invoke-Api $Phase8Port "/api/ranked/self" -headers @{"X-BAP-AccountId"="leader-integ";"X-BAP-Username"="LeaderInteg"}
                if ($matchRecorded) {
                    Assert "Phase8: Ranked points changed" ($rankedLeader.points -ne 1000 -or $rankedLeader.gamesPlayed -ge 1) "points=$($rankedLeader.points), games=$($rankedLeader.gamesPlayed)"
                } else {
                    Assert "Phase8: Ranked points changed" $false "points=$($rankedLeader.points) (game-ended not triggered)"
                }
            } else {
                Write-Host "  Game failed to start: $($leaderStarted.Message | ConvertTo-Json -Compress)" -ForegroundColor Yellow
                Assert "Phase8: Guest received GAME_STARTED" $false "Game did not start"
                Assert "Phase8: Match history recorded" $false "Game did not start"
                Assert "Phase8: Economy rewards applied" $false "Game did not start"
                Assert "Phase8: Ranked points changed" $false "Game did not start"
            }
        } else {
            Assert "Phase8: Leader connected" $false "Server failed"
            Assert "Phase8: Guest connected" $false "Server failed"
            Assert "Phase8: Leader joined lobby" $false "Server failed"
            Assert "Phase8: Guest joined lobby" $false "Server failed"
            Assert "Phase8: Settings updated" $false "Server failed"
            Assert "Phase8: GAME_STARTED received" $false "Server failed"
        }
    }
} catch {
    Write-Host "[ERROR] Phase 8 exception: $_" -ForegroundColor Red
    $failed++; $total++; $failures += "Phase8 Exception: $_"
} finally {
    if ($leaderWs) { try { $leaderWs.Abort(); $leaderWs.Dispose() } catch {} }
    if ($guestWs) { try { $guestWs.Abort(); $guestWs.Dispose() } catch {} }
    Stop-Safe $server2
}

# ======================== SUMMARY ========================
Write-Host "`n========================================" -ForegroundColor White
Write-Host "         INTEGRATION TEST SUMMARY" -ForegroundColor White
Write-Host "========================================" -ForegroundColor White
Write-Host "  Total tests: $total" -ForegroundColor White
Write-Host "  Passed:      $passed" -ForegroundColor Green
Write-Host "  Failed:      $failed" -ForegroundColor $(if ($failed -gt 0) { "Red" } else { "Green" })

if ($failures.Count -gt 0) {
    Write-Host "`n  Failures:" -ForegroundColor Red
    foreach ($f in $failures) {
        Write-Host "    - $f" -ForegroundColor Red
    }
}

Write-Host "========================================`n" -ForegroundColor White
exit $failed
