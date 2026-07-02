param(
    [string]$AmpBaseUrl = "https://ark.atomi23.de",
    [string]$InstanceId = "a8556e48-c8be-4f34-b7a1-517607f96b3b",
    [string]$InstanceName = "BAPBattle01",
    [string]$Username = "Sonic0810",
    [string]$SessionId = "",
    [string]$ChildSessionId = "",
    [string]$RemoteServerId = ""
)

$ErrorActionPreference = "Stop"

function Get-AmpSessionCandidates {
    $levelDb = Join-Path $env:LOCALAPPDATA "Microsoft\Edge\User Data\Default\Local Storage\leveldb"
    $files = Get-ChildItem -LiteralPath $levelDb -File |
        Where-Object { $_.Extension -in ".ldb", ".log" } |
        ForEach-Object { $_.FullName }

    if (-not $files) {
        throw "No Edge local storage LevelDB files found."
    }

    $raw = (& rg -a "LastSessionID|SavedToken" @files 2>$null) -join "`n"
    [regex]::Matches($raw, "[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}") |
        ForEach-Object { $_.Value } |
        Select-Object -Unique
}

function Get-AmpSavedTokens {
    $levelDb = Join-Path $env:LOCALAPPDATA "Microsoft\Edge\User Data\Default\Local Storage\leveldb"
    $files = Get-ChildItem -LiteralPath $levelDb -File |
        Where-Object { $_.Extension -in ".ldb", ".log" } |
        ForEach-Object { $_.FullName }

    $raw = (& rg -a "SavedToken" @files 2>$null) -join "`n"
    [regex]::Matches($raw, "SavedToken[^0-9a-fA-F]*([0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12})") |
        ForEach-Object { $_.Groups[1].Value } |
        Select-Object -Unique
}

Add-Type -AssemblyName System.Net.Http
$client = [System.Net.Http.HttpClient]::new()
$client.Timeout = [TimeSpan]::FromMinutes(3)

function Invoke-AmpJson {
    param(
        [string]$Path,
        [hashtable]$Body,
        [string]$SessionId
    )

    $payload = @{} + $Body
    $payload["SESSIONID"] = $SessionId
    $json = $payload | ConvertTo-Json -Depth 30 -Compress

    $request = [System.Net.Http.HttpRequestMessage]::new([System.Net.Http.HttpMethod]::Post, "$AmpBaseUrl$Path")
    [void]$request.Headers.Accept.ParseAdd("application/json")
    if (-not [string]::IsNullOrWhiteSpace($SessionId)) {
        $request.Headers.Authorization = [System.Net.Http.Headers.AuthenticationHeaderValue]::new("Bearer", $SessionId)
    }
    $request.Content = [System.Net.Http.StringContent]::new($json, [System.Text.Encoding]::UTF8, "application/json")

    $response = $client.SendAsync($request).GetAwaiter().GetResult()
    $text = $response.Content.ReadAsStringAsync().GetAwaiter().GetResult()
    if (-not $response.IsSuccessStatusCode) {
        throw "AMP API HTTP $([int]$response.StatusCode) for $Path`: $text"
    }

    if ([string]::IsNullOrWhiteSpace($text)) {
        return $null
    }

    return $text | ConvertFrom-Json
}

function Get-ValidAmpSession {
    foreach ($candidate in Get-AmpSessionCandidates) {
        try {
            $status = Invoke-AmpJson -Path "/API/Core/GetStatus" -Body @{} -SessionId $candidate
            if ($null -ne $status.State) {
                return $candidate
            }
        } catch {
        }
    }

    foreach ($token in Get-AmpSavedTokens) {
        try {
            $login = Invoke-AmpJson -Path "/API/Core/Login" -Body @{
                username = $Username
                password = ""
                token = $token
                rememberMe = $true
            } -SessionId ""

            if ($login.success -and -not [string]::IsNullOrWhiteSpace($login.sessionID)) {
                return $login.sessionID
            }
        } catch {
        }
    }

    throw "No valid AMP session or saved login token found. Open AMP in Edge and log in again."
}

function Write-Step($message) {
    Write-Host ("[{0:HH:mm:ss}] {1}" -f (Get-Date), $message)
}

$session = if ([string]::IsNullOrWhiteSpace($SessionId)) { Get-ValidAmpSession } else { $SessionId }
Write-Step "Using live AMP session from Edge."

$instance = Invoke-AmpJson -Path "/API/ADSModule/GetInstance" -Body @{ InstanceId = $InstanceId } -SessionId $session
if (-not $instance.Running) {
    Write-Step "Starting AMP child instance $InstanceName."
    $startInstance = Invoke-AmpJson -Path "/API/ADSModule/StartInstance" -Body @{ InstanceName = $InstanceName } -SessionId $session
    if ($startInstance.Status -eq $false) {
        throw "StartInstance failed: $($startInstance.Reason)"
    }

    for ($i = 0; $i -lt 30; $i++) {
        Start-Sleep -Seconds 2
        $instance = Invoke-AmpJson -Path "/API/ADSModule/GetInstance" -Body @{ InstanceId = $InstanceId } -SessionId $session
        if ($instance.Running) { break }
    }
}

Write-Step "AMP child instance running=$($instance.Running), appState=$($instance.AppState)."

$serverId = if ([string]::IsNullOrWhiteSpace($RemoteServerId)) { $InstanceId } else { $RemoteServerId }
$remotePrefix = "/API/ADSModule/Servers/$serverId/API"
$remoteSession = $ChildSessionId

if ([string]::IsNullOrWhiteSpace($remoteSession)) {
    $manage = Invoke-AmpJson -Path "/API/ADSModule/ManageInstance" -Body @{ InstanceId = $InstanceId } -SessionId $session
    $remoteToken = [string]$manage.Result
    if ([string]::IsNullOrWhiteSpace($remoteToken)) { $remoteToken = [string]$manage.result }
    if ([string]::IsNullOrWhiteSpace($remoteToken)) { $remoteToken = [string]$manage.Token }
    if ([string]::IsNullOrWhiteSpace($remoteToken)) { $remoteToken = [string]$manage.token }
    if ([string]::IsNullOrWhiteSpace($remoteToken)) {
        $json = $manage | ConvertTo-Json -Depth 8 -Compress
        throw "ManageInstance did not return a remote login token: $json"
    }

    $remoteLogin = Invoke-AmpJson -Path "$remotePrefix/Core/Login" -Body @{
        username = $Username
        password = ""
        token = $remoteToken
        rememberMe = $false
    } -SessionId ""

    if (-not $remoteLogin.success -or [string]::IsNullOrWhiteSpace($remoteLogin.sessionID)) {
        $json = $remoteLogin | ConvertTo-Json -Depth 8 -Compress
        throw "Remote Core/Login failed: $json"
    }

    $remoteSession = [string]$remoteLogin.sessionID
    Write-Step "Logged into child instance API."
}

$status = Invoke-AmpJson -Path "$remotePrefix/Core/GetStatus" -Body @{} -SessionId $remoteSession
Write-Step "Remote app state before start: $($status.State)."
if ($status.State -eq 0) {
    $startApp = Invoke-AmpJson -Path "$remotePrefix/Core/Start" -Body @{} -SessionId $remoteSession
    if ($startApp.Status -eq $false) {
        throw "Remote Core.Start failed: $($startApp.Reason)"
    }
    Write-Step "Core/Start requested."
}

for ($i = 0; $i -lt 30; $i++) {
    Start-Sleep -Seconds 2
    $status = Invoke-AmpJson -Path "$remotePrefix/Core/GetStatus" -Body @{} -SessionId $remoteSession
    Write-Step "Remote app state poll $i`: $($status.State)."
    if ($status.State -ne 0) {
        break
    }
}

