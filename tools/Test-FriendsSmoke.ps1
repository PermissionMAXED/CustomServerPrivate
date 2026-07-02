param(
    [int]$ServerPort = 5158
)

$ErrorActionPreference = "Stop"

$Root = Resolve-Path (Join-Path $PSScriptRoot "..")
$ServerDll = Join-Path $Root "CustomMatchServer\bin\Release\net10.0\BapCustomServer.dll"

if (-not (Test-Path $ServerDll)) {
    throw "Server DLL not built."
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
$psi.EnvironmentVariables["CustomServer__LaunchGameServers"] = "false"

$server = [System.Diagnostics.Process]::Start($psi)
try {
    $base = "http://127.0.0.1:$ServerPort"
    $deadline = [DateTime]::UtcNow.AddSeconds(12)
    do {
        try { $h = Invoke-RestMethod "$base/health" -TimeoutSec 1; if ($h.ok) { break } } catch {}
        Start-Sleep -Milliseconds 200
    } while ([DateTime]::UtcNow -lt $deadline)

    $headersA = @{ "X-BAP-AccountId" = "player-alpha"; "X-BAP-Username" = "Alpha"; "X-BAP-Discriminator" = "1001" }
    $headersB = @{ "X-BAP-AccountId" = "player-beta"; "X-BAP-Username" = "Beta"; "X-BAP-Discriminator" = "2002" }

    # Player A sends friend request to Player B
    $addResult = Invoke-RestMethod "$base/api/friends/add" -Method Post -Headers $headersA -Body '{"accountId":"player-beta"}' -ContentType "application/json"
    
    # Player B checks pending requests
    $pending = Invoke-RestMethod "$base/api/friends/requests" -Headers $headersB
    $pendingCount = $pending.payload.friendRequests.Count

    # Player B accepts
    $acceptResult = Invoke-RestMethod "$base/api/friends/accept" -Method Post -Headers $headersB -Body '{"accountId":"player-alpha"}' -ContentType "application/json"

    # Both check friends list
    $friendsA = Invoke-RestMethod "$base/api/friends" -Headers $headersA
    $friendsB = Invoke-RestMethod "$base/api/friends" -Headers $headersB

    # Player A removes Player B
    $removeResult = Invoke-RestMethod "$base/api/friends/remove" -Method Post -Headers $headersA -Body '{"accountId":"player-beta"}' -ContentType "application/json"

    # Verify empty
    $friendsAfterRemove = Invoke-RestMethod "$base/api/friends" -Headers $headersA

    # Toggle friend requests closed
    $toggleResult = Invoke-RestMethod "$base/api/friends/toggle-friend-requests" -Method Post -Headers $headersB

    [pscustomobject]@{
        sendRequestOk        = $addResult.ok
        pendingRequestCount  = $pendingCount
        acceptOk             = $acceptResult.ok
        friendsACount        = $friendsA.friends.Count
        friendsBCount        = $friendsB.friends.Count
        removeOk             = $removeResult.ok
        friendsAfterRemove   = $friendsAfterRemove.friends.Count
        toggleRequestsOk     = $toggleResult.ok
        friendRequestsClosed = (-not $toggleResult.friendRequestsOpen)
    } | ConvertTo-Json -Compress
}
finally {
    if (-not $server.HasExited) {
        try { $server.Kill() } catch {}
        $server.WaitForExit(2000) | Out-Null
    }
}
