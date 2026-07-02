param(
    [int]$ServerPort = 5155,
    [int]$ProxyPort = 5055
)

$ErrorActionPreference = "Stop"

if ($ProxyPort -ne 5055) {
    throw "CustomClientProxy currently listens on 5055. Use -ProxyPort 5055."
}

$Root = Resolve-Path (Join-Path $PSScriptRoot "..")
$ServerDll = Join-Path $Root "CustomMatchServer\bin\Release\net10.0\BapCustomServer.dll"
$ProxyExe = Join-Path $Root "CustomClientProxy\publish\win-x64\BapCustomClientProxy.exe"

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

function Start-HiddenProcess {
    param(
        [string]$FileName,
        [string]$Arguments,
        [hashtable]$Environment = @{}
    )

    $psi = [System.Diagnostics.ProcessStartInfo]::new()
    $psi.FileName = $FileName
    $psi.Arguments = $Arguments
    $psi.WorkingDirectory = $Root
    $psi.UseShellExecute = $false
    $psi.RedirectStandardOutput = $true
    $psi.RedirectStandardError = $true
    $psi.CreateNoWindow = $true

    foreach ($key in $Environment.Keys) {
        $psi.EnvironmentVariables[$key] = [string]$Environment[$key]
    }

    return [System.Diagnostics.Process]::Start($psi)
}

function Wait-HttpOk {
    param([string]$Url)

    $deadline = [DateTime]::UtcNow.AddSeconds(10)
    do {
        try {
            $response = Invoke-RestMethod $Url
            return $response
        }
        catch {
            Start-Sleep -Milliseconds 250
        }
    } while ([DateTime]::UtcNow -lt $deadline)

    throw "Timed out waiting for $Url"
}

function Test-WebSocket {
    param([string]$Url)

    $ws = [System.Net.WebSockets.ClientWebSocket]::new()
    try {
        $task = $ws.ConnectAsync([Uri]$Url, [Threading.CancellationToken]::None)
        if (-not $task.Wait(5000)) {
            throw "Timed out connecting to $Url"
        }
        if ($task.IsFaulted) {
            throw $task.Exception
        }
        return $ws.State.ToString()
    }
    finally {
        $ws.Abort()
        $ws.Dispose()
    }
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

if (-not (Test-Path $ProxyExe)) {
    throw "Publish CustomClientProxy first: $ProxyExe is missing."
}

if (-not (Test-PortFree $ServerPort)) {
    throw "Port $ServerPort is already in use."
}

if (-not (Test-PortFree $ProxyPort)) {
    throw "Port $ProxyPort is already in use."
}

$server = $null
$proxy = $null

try {
    $server = Start-HiddenProcess "dotnet" "`"$ServerDll`"" @{
        "ASPNETCORE_URLS" = "http://127.0.0.1:$ServerPort"
        "CustomServer__PublicBaseUrl" = "http://127.0.0.1:$ServerPort"
        "CustomServer__LaunchGameServers" = "false"
        "CustomServer__RequireGameServerBootstrap" = "false"
    }

    $directHealth = Wait-HttpOk "http://127.0.0.1:$ServerPort/health"
    $directSocket = Invoke-RestMethod "http://127.0.0.1:$ServerPort/api/lobby/socket"
    $directWsState = Test-WebSocket "ws://127.0.0.1:$ServerPort/ws"

    $proxy = Start-HiddenProcess $ProxyExe "http://127.0.0.1:$ServerPort"

    $proxyHealth = Wait-HttpOk "http://127.0.0.1:$ProxyPort/health"
    $proxySocket = Invoke-RestMethod "http://127.0.0.1:$ProxyPort/api/lobby/socket"
    $proxyWsState = Test-WebSocket "ws://127.0.0.1:$ProxyPort/ws"

    [pscustomobject]@{
        directHealthOk = $directHealth.ok
        directSocketUrl = $directSocket.socketUrl
        directWebSocketState = $directWsState
        proxyHealthOk = $proxyHealth.ok
        proxySocketUrl = $proxySocket.socketUrl
        proxyWebSocketState = $proxyWsState
    } | ConvertTo-Json -Compress
}
finally {
    Stop-ProcessSafe $proxy
    Stop-ProcessSafe $server
}
