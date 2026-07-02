param(
    [string]$AmpBaseUrl = "https://ark.atomi23.de",
    [string]$InstanceId = "a8556e48-c8be-4f34-b7a1-517607f96b3b",
    [string]$InstanceName = "BAPBattle01",
    [string]$Username = "Sonic0810",
    [string]$ZipPath = "C:\Users\Administrator\Downloads\CustomServer\artifacts\amp-medusa-current-root-upload.zip",
    [string]$RemoteZipPath = "amp-medusa-current-root-upload.zip",
    [string]$SessionId = "",
    [string]$ChildSessionId = "",
    [string]$RemoteServerId = "",
    [int]$ChunkSize = 1048576,
    [switch]$SkipStart
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

    $raw = ($files | ForEach-Object {
        try {
            $txt = [System.IO.File]::ReadAllText($_, [System.Text.Encoding]::GetEncoding('ISO-8859-1'))
            ($txt -split "`n") | Where-Object { $_ -match 'LastSessionID|SavedToken' }
        } catch { }
    }) -join "`n"
    [regex]::Matches($raw, "[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}") |
        ForEach-Object { $_.Value } |
        Select-Object -Unique
}

function Get-AmpSavedTokens {
    $levelDb = Join-Path $env:LOCALAPPDATA "Microsoft\Edge\User Data\Default\Local Storage\leveldb"
    $files = Get-ChildItem -LiteralPath $levelDb -File |
        Where-Object { $_.Extension -in ".ldb", ".log" } |
        ForEach-Object { $_.FullName }

    $raw = ($files | ForEach-Object {
        try {
            $txt = [System.IO.File]::ReadAllText($_, [System.Text.Encoding]::GetEncoding('ISO-8859-1'))
            ($txt -split "`n") | Where-Object { $_ -match 'SavedToken' }
        } catch { }
    }) -join "`n"
    [regex]::Matches($raw, "SavedToken[^0-9a-fA-F]*([0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12})") |
        ForEach-Object { $_.Groups[1].Value } |
        Select-Object -Unique
}

Add-Type -AssemblyName System.Net.Http
$client = [System.Net.Http.HttpClient]::new()
$client.Timeout = [TimeSpan]::FromMinutes(5)

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

    try {
        return $text | ConvertFrom-Json
    } catch {
        $snippetLength = [Math]::Min(500, $text.Length)
        $snippet = if ($snippetLength -gt 0) { $text.Substring(0, $snippetLength) } else { "<empty>" }
        throw "AMP API invalid JSON for $Path`: $snippet"
    }
}

function Get-ValidAmpSession {
    foreach ($candidate in Get-AmpSessionCandidates) {
        try {
            $status = Invoke-AmpJson -Path "/API/Core/GetStatus" -Body @{} -SessionId $candidate
            if ($null -ne $status.State) {
                return $candidate
            }
        } catch {
            # Stale local-storage entries are expected; keep looking.
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
            # Expired/revoked saved tokens are expected; keep trying candidates.
        }
    }

    throw "No valid AMP session or saved login token found. Open AMP in Edge and log in again."
}

function Write-Step($message) {
    Write-Host ("[{0:HH:mm:ss}] {1}" -f (Get-Date), $message)
}

if (-not (Test-Path -LiteralPath $ZipPath)) {
    throw "Zip not found: $ZipPath"
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
} else {
    Write-Step "Using provided child instance session."
}

$remoteStatus = Invoke-AmpJson -Path "$remotePrefix/Core/GetStatus" -Body @{} -SessionId $remoteSession
Write-Step "Remote app state before deploy: $($remoteStatus.State)."

if ($remoteStatus.State -ne 0) {
    Write-Step "Stopping application inside child instance."
    [void](Invoke-AmpJson -Path "$remotePrefix/Core/Stop" -Body @{} -SessionId $remoteSession)
    for ($i = 0; $i -lt 30; $i++) {
        Start-Sleep -Seconds 2
        $remoteStatus = Invoke-AmpJson -Path "$remotePrefix/Core/GetStatus" -Body @{} -SessionId $remoteSession
        if ($remoteStatus.State -eq 0) { break }
    }
    Write-Step "Remote app state after stop: $($remoteStatus.State)."

    if ($remoteStatus.State -ne 0) {
        Write-Step "Graceful stop timed out; forcing Core.Kill."
        [void](Invoke-AmpJson -Path "$remotePrefix/Core/Kill" -Body @{} -SessionId $remoteSession)
        for ($i = 0; $i -lt 30; $i++) {
            Start-Sleep -Seconds 1
            $remoteStatus = Invoke-AmpJson -Path "$remotePrefix/Core/GetStatus" -Body @{} -SessionId $remoteSession
            if ($remoteStatus.State -eq 0) { break }
        }
        Write-Step "Remote app state after kill: $($remoteStatus.State)."
    }

    if ($remoteStatus.State -ne 0) {
        throw "Remote application did not reach stopped state 0; current state=$($remoteStatus.State)."
    }
}

$rootListing = Invoke-AmpJson -Path "$remotePrefix/FileManagerPlugin/GetDirectoryListing" -Body @{ Dir = "" } -SessionId $remoteSession
$rootEntries = @($rootListing)
if ($rootEntries.Count -eq 1 -and $null -ne $rootListing.Title -and $null -ne $rootListing.Message) {
    throw "Remote root listing failed: $($rootListing.Title) - $($rootListing.Message)"
}
Write-Step "Remote root accessible, entries=$($rootEntries.Count)."

try {
    [void](Invoke-AmpJson -Path "$remotePrefix/FileManagerPlugin/TrashFile" -Body @{ Filename = $RemoteZipPath } -SessionId $remoteSession)
} catch {
    # The file may not exist.
}

$bytes = [System.IO.File]::ReadAllBytes((Resolve-Path -LiteralPath $ZipPath))
$localMd5 = (Get-FileHash -LiteralPath $ZipPath -Algorithm MD5).Hash.ToLowerInvariant()
Write-Step "Uploading $([Math]::Round($bytes.Length / 1MB, 2)) MiB to $RemoteZipPath."

for ($offset = 0L; $offset -lt $bytes.Length; $offset += $ChunkSize) {
    $count = [Math]::Min($ChunkSize, $bytes.Length - $offset)
    $data = [Convert]::ToBase64String($bytes, [int]$offset, [int]$count)
    $final = ($offset + $count) -ge $bytes.Length
    $result = Invoke-AmpJson -Path "$remotePrefix/FileManagerPlugin/WriteFileChunk" -Body @{
        Filename = $RemoteZipPath
        Data = $data
        Offset = $offset
        FinalChunk = $final
    } -SessionId $remoteSession
    if ($result.Status -eq $false) {
        throw "WriteFileChunk failed at offset $offset`: $($result.Reason)"
    }
    Write-Progress -Activity "AMP upload" -Status "$offset / $($bytes.Length)" -PercentComplete ([Math]::Min(100, (($offset + $count) * 100 / $bytes.Length)))
}
Write-Progress -Activity "AMP upload" -Completed

$remoteMd5Result = Invoke-AmpJson -Path "$remotePrefix/FileManagerPlugin/CalculateFileMD5Sum" -Body @{ FilePath = $RemoteZipPath } -SessionId $remoteSession
if ($remoteMd5Result.Status -eq $false) {
    throw "Remote MD5 failed: $($remoteMd5Result.Reason)"
}
$remoteMd5 = [string]$remoteMd5Result.Result
Write-Step "MD5 local=$localMd5 remote=$remoteMd5."
if ($remoteMd5.ToLowerInvariant() -ne $localMd5) {
    throw "Uploaded ZIP MD5 mismatch."
}

Write-Step "Extracting archive into remote root."
$extract = Invoke-AmpJson -Path "$remotePrefix/FileManagerPlugin/ExtractArchive" -Body @{
    ArchivePath = $RemoteZipPath
    DestinationPath = ""
} -SessionId $remoteSession
if ($extract.Status -eq $false) {
    throw "ExtractArchive failed: $($extract.Reason)"
}

if (-not $SkipStart) {
    Write-Step "Starting application inside child instance."
    $startApp = Invoke-AmpJson -Path "$remotePrefix/Core/Start" -Body @{} -SessionId $remoteSession
    if ($startApp.Status -eq $false) {
        throw "Remote Core.Start failed: $($startApp.Reason)"
    }
}

Write-Step "Deploy complete."
