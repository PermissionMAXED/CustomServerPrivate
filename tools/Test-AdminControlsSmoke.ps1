param(
    [int]$ServerPort = 5158,
    [string]$AdminToken = "smoke-admin-token"
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
    $stateFile = Join-Path $Root "CustomMatchServer\data\admin-smoke-state.json"
    $auditFile = Join-Path $Root "CustomMatchServer\logs\admin-smoke-audit.jsonl"
    Remove-Item -LiteralPath $stateFile -Force -ErrorAction SilentlyContinue
    Remove-Item -LiteralPath $auditFile -Force -ErrorAction SilentlyContinue

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
    $psi.EnvironmentVariables["CustomServer__Admin__ApiToken"] = $AdminToken
    $psi.EnvironmentVariables["CustomServer__Admin__StateFile"] = $stateFile
    $psi.EnvironmentVariables["CustomServer__Admin__AuditLogFile"] = $auditFile
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

function Invoke-AdminCommand {
    param([hashtable]$Body)

    $headers = @{ "X-BAP-Admin-Token" = $AdminToken; "X-BAP-Admin-Actor" = "admin-smoke" }
    Invoke-RestMethod "http://127.0.0.1:$ServerPort/admin/commands" `
        -Method Post `
        -Headers $headers `
        -ContentType "application/json" `
        -Body ($Body | ConvertTo-Json -Compress -Depth 10)
}

function Invoke-Load {
    param([string]$AccountId)

    Invoke-RestMethod "http://127.0.0.1:$ServerPort/api/load?accountId=$AccountId&username=$AccountId"
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

try {
    $server = Start-TestServer
    Wait-Health | Out-Null

    $initial = Invoke-Load "admin-smoke-user"
    if ($initial.isAdmin -ne $false -or $initial.blocked -ne $false) {
        throw "Fresh account should not be admin or blocked."
    }

    $grant = Invoke-AdminCommand @{ command = "grant-admin"; accountId = "admin-smoke-user" }
    if ($grant.ok -ne $true) {
        throw "grant-admin failed."
    }

    $adminLoad = Invoke-Load "admin-smoke-user"
    if ($adminLoad.isAdmin -ne $true -or $adminLoad.blocked -ne $false) {
        throw "Granted admin account did not receive isAdmin=true."
    }

    $ban = Invoke-AdminCommand @{ command = "ban"; accountId = "banned-smoke-user"; reason = "smoke test" }
    if ($ban.ok -ne $true) {
        throw "ban command failed."
    }

    $bannedLoad = Invoke-Load "banned-smoke-user"
    if ($bannedLoad.blocked -ne $true -or $bannedLoad.isAdmin -ne $false) {
        throw "Banned account did not receive blocked=true and isAdmin=false."
    }

    $unban = Invoke-AdminCommand @{ command = "unban"; accountId = "banned-smoke-user" }
    if ($unban.ok -ne $true) {
        throw "unban command failed."
    }

    $unbannedLoad = Invoke-Load "banned-smoke-user"
    if ($unbannedLoad.blocked -ne $false) {
        throw "Unbanned account is still blocked."
    }

    $headers = @{ "X-BAP-Admin-Token" = $AdminToken }
    $state = Invoke-RestMethod "http://127.0.0.1:$ServerPort/admin/state" -Headers $headers
    $audit = Invoke-RestMethod "http://127.0.0.1:$ServerPort/admin/logs/audit?tail=20" -Headers $headers

    if (-not ($state.adminAccountIds -contains "admin-smoke-user")) {
        throw "Admin state did not persist admin-smoke-user."
    }

    if ($audit.lines.Count -lt 3) {
        throw "Audit log did not record admin mutations."
    }

    [pscustomobject]@{
        grantAdmin = $grant.ok
        adminLoadIsAdmin = $adminLoad.isAdmin
        ban = $ban.ok
        bannedLoadBlocked = $bannedLoad.blocked
        unban = $unban.ok
        unbannedLoadBlocked = $unbannedLoad.blocked
        adminCount = @($state.adminAccountIds).Count
        banCount = @($state.bans).Count
        auditLines = @($audit.lines).Count
    } | ConvertTo-Json -Compress
}
finally {
    Stop-ProcessSafe $server
}
