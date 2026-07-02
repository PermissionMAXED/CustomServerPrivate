param(
    [string]$AmpBaseUrl = "https://ark.atomi23.de",
    [string]$InstanceId = "a8556e48-c8be-4f34-b7a1-517607f96b3b",
    [string]$InstanceName = "BAPBattle01",
    [string]$Username = "Sonic0810",
    [string]$ExpectedRelease = "",
    [int]$TaskTimeoutSeconds = 900,
    [int]$StartTimeoutSeconds = 180,
    [switch]$SkipStart
)

$ErrorActionPreference = "Stop"

Add-Type -AssemblyName System.Net.Http

$client = [System.Net.Http.HttpClient]::new()
$client.Timeout = [TimeSpan]::FromMinutes(5)

function Write-Step {
    param([string]$Message)
    Write-Host ("[{0:HH:mm:ss}] {1}" -f (Get-Date), $Message)
}

function Invoke-AmpJson {
    param(
        [string]$Path,
        [hashtable]$Body = @{},
        [string]$SessionId = ""
    )

    $payload = @{} + $Body
    if (-not [string]::IsNullOrWhiteSpace($SessionId)) {
        $payload["SESSIONID"] = $SessionId
    }

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
    try {
        return $text | ConvertFrom-Json
    } catch {
        $snippet = $text.Substring(0, [Math]::Min(500, $text.Length))
        throw "AMP API invalid JSON for $Path`: $snippet"
    }
}

function Get-AmpLevelDbFiles {
    $levelDb = Join-Path $env:LOCALAPPDATA "Microsoft\Edge\User Data\Default\Local Storage\leveldb"
    if (-not (Test-Path -LiteralPath $levelDb)) {
        throw "Edge LevelDB path not found: $levelDb"
    }
    Get-ChildItem -LiteralPath $levelDb -File |
        Where-Object { $_.Extension -in ".ldb", ".log" } |
        ForEach-Object { $_.FullName }
}

function Get-AmpSessionCandidates {
    $files = @(Get-AmpLevelDbFiles)
    $raw = (& rg -a "LastSessionID|SavedToken" @files 2>$null) -join "`n"
    [regex]::Matches($raw, "[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}") |
        ForEach-Object { $_.Value } |
        Select-Object -Unique
}

function Get-AmpSavedTokens {
    $files = @(Get-AmpLevelDbFiles)
    $raw = (& rg -a "SavedToken" @files 2>$null) -join "`n"
    [regex]::Matches($raw, "SavedToken[^0-9a-fA-F]*([0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12})") |
        ForEach-Object { $_.Groups[1].Value } |
        Select-Object -Unique
}

function Get-ValidAmpSession {
    foreach ($candidate in Get-AmpSessionCandidates) {
        try {
            $status = Invoke-AmpJson -Path "/API/Core/GetStatus" -SessionId $candidate
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
            }

            if ($login.success -and -not [string]::IsNullOrWhiteSpace($login.sessionID)) {
                return $login.sessionID
            }
        } catch {
        }
    }

    throw "No valid AMP session or saved login token found. Open AMP in Edge and log in again."
}

function Wait-RemoteState {
    param(
        [string]$RemotePrefix,
        [string]$RemoteSession,
        [int]$WantedState,
        [int]$TimeoutSeconds
    )

    $deadline = (Get-Date).AddSeconds($TimeoutSeconds)
    do {
        $status = Invoke-AmpJson -Path "$RemotePrefix/Core/GetStatus" -SessionId $RemoteSession
        if ([int]$status.State -eq $WantedState) {
            return $status
        }
        Start-Sleep -Seconds 2
    } while ((Get-Date) -lt $deadline)

    return $status
}

function Wait-Tasks {
    param(
        [string]$RemotePrefix,
        [string]$RemoteSession,
        [int]$TimeoutSeconds
    )

    $deadline = (Get-Date).AddSeconds($TimeoutSeconds)
    do {
        $tasks = @(Invoke-AmpJson -Path "$RemotePrefix/Core/GetTasks" -SessionId $RemoteSession)
        $running = @($tasks | Where-Object {
            $stateNumber = 0
            $statusNumber = 0
            $hasStateNumber = [int]::TryParse([string]$_.State, [ref]$stateNumber)
            $hasStatusNumber = [int]::TryParse([string]$_.Status, [ref]$statusNumber)
            ($_.IsRunning -eq $true) -or
            ($_.Running -eq $true) -or
            ($_.State -match "Running|InProgress|Queued") -or
            ($_.Status -match "Running|InProgress|Queued") -or
            ($hasStateNumber -and $stateNumber -in @(1, 2, 3, 4)) -or
            ($hasStatusNumber -and $statusNumber -in @(0, 1, 2, 3, 4))
        })
        if ($tasks.Count -gt 0) {
            $summary = ($tasks | ForEach-Object {
                $name = $_.Name
                if ([string]::IsNullOrWhiteSpace([string]$name)) { $name = $_.Description }
                if ([string]::IsNullOrWhiteSpace([string]$name)) { $name = $_.Id }
                if ([string]::IsNullOrWhiteSpace([string]$name)) { $name = "<task>" }
                $state = $_.State
                if ([string]::IsNullOrWhiteSpace([string]$state)) { $state = $_.Status }
                if ([string]::IsNullOrWhiteSpace([string]$state)) { $state = $_.Progress }
                if ([string]::IsNullOrWhiteSpace([string]$state)) { $state = "" }
                "$name $state"
            }) -join "; "
            Write-Step "AMP tasks: $summary"
        }
        if ($running.Count -eq 0) {
            return $tasks
        }
        Start-Sleep -Seconds 5
    } while ((Get-Date) -lt $deadline)

    throw "Timed out waiting for AMP update tasks after $TimeoutSeconds seconds."
}

$mainSession = Get-ValidAmpSession
Write-Step "Using live AMP session from Edge."

$instance = Invoke-AmpJson -Path "/API/ADSModule/GetInstance" -Body @{ InstanceId = $InstanceId } -SessionId $mainSession
Write-Step "AMP child instance running=$($instance.Running), appState=$($instance.AppState)."

if (-not $instance.Running) {
    Write-Step "Starting child instance shell $InstanceName before remote login."
    $startInstance = Invoke-AmpJson -Path "/API/ADSModule/StartInstance" -Body @{ InstanceName = $InstanceName } -SessionId $mainSession
    if ($startInstance.Status -eq $false) {
        throw "StartInstance failed: $($startInstance.Reason)"
    }
    for ($i = 0; $i -lt 45; $i++) {
        Start-Sleep -Seconds 2
        $instance = Invoke-AmpJson -Path "/API/ADSModule/GetInstance" -Body @{ InstanceId = $InstanceId } -SessionId $mainSession
        if ($instance.Running) {
            break
        }
    }
    if (-not $instance.Running) {
        throw "Child instance did not become running."
    }
}

$manage = Invoke-AmpJson -Path "/API/ADSModule/ManageInstance" -Body @{ InstanceId = $InstanceId } -SessionId $mainSession
$remoteToken = [string]$manage.Result
if ([string]::IsNullOrWhiteSpace($remoteToken)) { $remoteToken = [string]$manage.result }
if ([string]::IsNullOrWhiteSpace($remoteToken)) { $remoteToken = [string]$manage.Token }
if ([string]::IsNullOrWhiteSpace($remoteToken)) { $remoteToken = [string]$manage.token }
if ([string]::IsNullOrWhiteSpace($remoteToken)) {
    $json = $manage | ConvertTo-Json -Depth 8 -Compress
    throw "ManageInstance did not return a remote login token: $json"
}

$remotePrefix = "/API/ADSModule/Servers/$InstanceId/API"
$remoteLogin = Invoke-AmpJson -Path "$remotePrefix/Core/Login" -Body @{
    username = $Username
    password = ""
    token = $remoteToken
    rememberMe = $false
}
if (-not $remoteLogin.success -or [string]::IsNullOrWhiteSpace($remoteLogin.sessionID)) {
    $json = $remoteLogin | ConvertTo-Json -Depth 8 -Compress
    throw "Remote Core/Login failed: $json"
}
$remoteSession = [string]$remoteLogin.sessionID
Write-Step "Logged into child instance API."

$remoteStatus = Invoke-AmpJson -Path "$remotePrefix/Core/GetStatus" -SessionId $remoteSession
Write-Step "Remote app state before update: $($remoteStatus.State)."

if ([int]$remoteStatus.State -ne 0) {
    Write-Step "Stopping application inside child instance."
    [void](Invoke-AmpJson -Path "$remotePrefix/Core/Stop" -SessionId $remoteSession)
    $remoteStatus = Wait-RemoteState -RemotePrefix $remotePrefix -RemoteSession $remoteSession -WantedState 0 -TimeoutSeconds 90
    if ([int]$remoteStatus.State -ne 0) {
        Write-Step "Graceful stop timed out; forcing Core/Kill."
        [void](Invoke-AmpJson -Path "$remotePrefix/Core/Kill" -SessionId $remoteSession)
        $remoteStatus = Wait-RemoteState -RemotePrefix $remotePrefix -RemoteSession $remoteSession -WantedState 0 -TimeoutSeconds 45
    }
    if ([int]$remoteStatus.State -ne 0) {
        throw "Remote application did not stop; state=$($remoteStatus.State)."
    }
}

Write-Step "Starting AMP UpdateApplication."
$update = Invoke-AmpJson -Path "$remotePrefix/Core/UpdateApplication" -SessionId $remoteSession
if ($update.Status -eq $false) {
    throw "UpdateApplication failed: $($update.Reason)"
}

[void](Wait-Tasks -RemotePrefix $remotePrefix -RemoteSession $remoteSession -TimeoutSeconds $TaskTimeoutSeconds)
Write-Step "AMP update tasks completed."

if (-not $SkipStart) {
    Write-Step "Starting application inside child instance."
    $startApp = Invoke-AmpJson -Path "$remotePrefix/Core/Start" -SessionId $remoteSession
    if ($startApp.Status -eq $false) {
        throw "Core/Start failed: $($startApp.Reason)"
    }
    $deadline = (Get-Date).AddSeconds($StartTimeoutSeconds)
    do {
        Start-Sleep -Seconds 3
        try {
            $health = Invoke-RestMethod -Uri "http://ark.atomi23.de:5055/health" -TimeoutSec 5
            if (-not [string]::IsNullOrWhiteSpace($ExpectedRelease) -and $health.release -ne $ExpectedRelease) {
                Write-Step "Health is up but release is '$($health.release)', waiting for '$ExpectedRelease'."
                continue
            }
            Write-Step "Health OK: release=$($health.release), server=$($health.artifacts.serverDllSha256), mod=$($health.artifacts.modDllSha256), medusa=$($health.artifacts.medusaDllSha256), wine=$($health.runtime.wineAvailable)."
            $health | ConvertTo-Json -Depth 12
            break
        } catch {
            Write-Step "Health not ready yet: $($_.Exception.Message)"
        }
    } while ((Get-Date) -lt $deadline)

    if ((Get-Date) -ge $deadline) {
        throw "Timed out waiting for public health after start."
    }
}

Write-Step "AMP instance update complete."
