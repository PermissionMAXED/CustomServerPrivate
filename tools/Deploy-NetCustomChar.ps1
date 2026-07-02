param(
    [string]$AmpBaseUrl   = "https://ark.atomi23.de",
    [string]$InstanceId   = "a8556e48-c8be-4f34-b7a1-517607f96b3b",
    [string]$InstanceName = "BAPBattle01",
    [string]$Username     = "Sonic0810",
    [string]$ZipPath      = "C:\Users\Administrator\Downloads\CustomServer\deployment\netcustomchar-deploy\netcustomchar-deploy.zip",
    [string]$RemoteZipPath = "netcustomchar-deploy.zip",
    [string]$SessionId    = "",
    [string[]]$DeleteRemoteFiles = @("game/Mods/BAPBAP.Medusa.dll","game/Mods/BAPCustomChars.dll"),
    [int]$ChunkSize       = 1048576
)
$ErrorActionPreference = "Stop"
if ([string]::IsNullOrWhiteSpace($SessionId)) {
    $tf = Join-Path $env:TEMP "amp_session.txt"
    if (Test-Path $tf) { $SessionId = (Get-Content $tf -Raw).Trim() }
}
if ([string]::IsNullOrWhiteSpace($SessionId)) { throw "No AMP SessionId (pass -SessionId or save to $env:TEMP\amp_session.txt)." }
if (-not (Test-Path -LiteralPath $ZipPath)) { throw "Zip not found: $ZipPath" }

Add-Type -AssemblyName System.Net.Http
$client = [System.Net.Http.HttpClient]::new(); $client.Timeout = [TimeSpan]::FromMinutes(5)
function Invoke-AmpJson { param([string]$Path,[hashtable]$Body,[string]$Sid)
    $payload = @{} + $Body; $payload["SESSIONID"] = $Sid
    $json = $payload | ConvertTo-Json -Depth 30 -Compress
    $req = [System.Net.Http.HttpRequestMessage]::new([System.Net.Http.HttpMethod]::Post, "$AmpBaseUrl$Path")
    [void]$req.Headers.Accept.ParseAdd("application/json")
    if (-not [string]::IsNullOrWhiteSpace($Sid)) { $req.Headers.Authorization = [System.Net.Http.Headers.AuthenticationHeaderValue]::new("Bearer", $Sid) }
    $req.Content = [System.Net.Http.StringContent]::new($json, [System.Text.Encoding]::UTF8, "application/json")
    $resp = $client.SendAsync($req).GetAwaiter().GetResult()
    $text = $resp.Content.ReadAsStringAsync().GetAwaiter().GetResult()
    if (-not $resp.IsSuccessStatusCode) { throw "AMP HTTP $([int]$resp.StatusCode) for $Path`: $text" }
    if ([string]::IsNullOrWhiteSpace($text)) { return $null }
    try { return $text | ConvertFrom-Json } catch { throw "AMP invalid JSON for $Path`: $($text.Substring(0,[Math]::Min(400,$text.Length)))" }
}
function Step($m){ Write-Host ("[{0:HH:mm:ss}] {1}" -f (Get-Date), $m) }

$session = $SessionId
$instance = Invoke-AmpJson "/API/ADSModule/GetInstance" @{ InstanceId = $InstanceId } $session
if (-not $instance.Running) {
    Step "Starting AMP child instance $InstanceName."
    [void](Invoke-AmpJson "/API/ADSModule/StartInstance" @{ InstanceName = $InstanceName } $session)
    for ($i=0;$i -lt 30;$i++){ Start-Sleep 2; $instance = Invoke-AmpJson "/API/ADSModule/GetInstance" @{ InstanceId = $InstanceId } $session; if ($instance.Running){break} }
}
Step "Child instance running=$($instance.Running) appState=$($instance.AppState)."

$serverId = $InstanceId
$remotePrefix = "/API/ADSModule/Servers/$serverId/API"
$manage = Invoke-AmpJson "/API/ADSModule/ManageInstance" @{ InstanceId = $InstanceId } $session
$remoteToken = [string]$manage.Result; if ([string]::IsNullOrWhiteSpace($remoteToken)) { $remoteToken = [string]$manage.result }
if ([string]::IsNullOrWhiteSpace($remoteToken)) { throw "ManageInstance returned no token: $($manage | ConvertTo-Json -Depth 6 -Compress)" }
$remoteLogin = Invoke-AmpJson "$remotePrefix/Core/Login" @{ username=$Username; password=""; token=$remoteToken; rememberMe=$false } ""
if (-not $remoteLogin.success -or [string]::IsNullOrWhiteSpace($remoteLogin.sessionID)) { throw "Remote Core/Login failed: $($remoteLogin | ConvertTo-Json -Depth 6 -Compress)" }
$remoteSession = [string]$remoteLogin.sessionID
Step "Logged into child instance API."

$started = $false
try {
    $remoteStatus = Invoke-AmpJson "$remotePrefix/Core/GetStatus" @{} $remoteSession
    Step "Remote app state before deploy: $($remoteStatus.State)."
    if ($remoteStatus.State -ne 0) {
        Step "Stopping application."
        [void](Invoke-AmpJson "$remotePrefix/Core/Stop" @{} $remoteSession)
        for ($i=0;$i -lt 30;$i++){ Start-Sleep 2; $remoteStatus = Invoke-AmpJson "$remotePrefix/Core/GetStatus" @{} $remoteSession; if ($remoteStatus.State -eq 0){break} }
        if ($remoteStatus.State -ne 0) { Step "Graceful stop timed out; Core.Kill."; [void](Invoke-AmpJson "$remotePrefix/Core/Kill" @{} $remoteSession); for ($i=0;$i -lt 30;$i++){ Start-Sleep 1; $remoteStatus = Invoke-AmpJson "$remotePrefix/Core/GetStatus" @{} $remoteSession; if ($remoteStatus.State -eq 0){break} } }
    }
    Step "Remote app state after stop: $($remoteStatus.State)."

    # --- disable the old conflicting char mod(s) so charId 15 has exactly one owner ---
    foreach ($df in $DeleteRemoteFiles) {
        try { [void](Invoke-AmpJson "$remotePrefix/FileManagerPlugin/TrashFile" @{ Filename = $df } $remoteSession); Step "Deleted remote: $df" }
        catch { Step "Delete remote skipped ($df): $($_.Exception.Message)" }
    }

    try { [void](Invoke-AmpJson "$remotePrefix/FileManagerPlugin/TrashFile" @{ Filename = $RemoteZipPath } $remoteSession) } catch {}

    $bytes = [System.IO.File]::ReadAllBytes((Resolve-Path -LiteralPath $ZipPath))
    $localMd5 = (Get-FileHash -LiteralPath $ZipPath -Algorithm MD5).Hash.ToLowerInvariant()
    Step "Uploading $([Math]::Round($bytes.Length/1MB,2)) MiB -> $RemoteZipPath."
    for ($offset=0L; $offset -lt $bytes.Length; $offset += $ChunkSize) {
        $count = [Math]::Min($ChunkSize, $bytes.Length - $offset)
        $data  = [Convert]::ToBase64String($bytes, [int]$offset, [int]$count)
        $final = ($offset + $count) -ge $bytes.Length
        $r = Invoke-AmpJson "$remotePrefix/FileManagerPlugin/WriteFileChunk" @{ Filename=$RemoteZipPath; Data=$data; Offset=$offset; FinalChunk=$final } $remoteSession
        if ($r.Status -eq $false) { throw "WriteFileChunk failed at $offset`: $($r.Reason)" }
    }
    $rm = Invoke-AmpJson "$remotePrefix/FileManagerPlugin/CalculateFileMD5Sum" @{ FilePath = $RemoteZipPath } $remoteSession
    $remoteMd5 = [string]$rm.Result
    Step "MD5 local=$localMd5 remote=$remoteMd5."
    if ($remoteMd5.ToLowerInvariant() -ne $localMd5) { throw "Uploaded ZIP MD5 mismatch." }

    Step "Extracting archive into remote root."
    $ex = Invoke-AmpJson "$remotePrefix/FileManagerPlugin/ExtractArchive" @{ ArchivePath=$RemoteZipPath; DestinationPath="" } $remoteSession
    if ($ex.Status -eq $false) { throw "ExtractArchive failed: $($ex.Reason)" }
}
finally {
    # ALWAYS try to bring the server back up, even if a step failed.
    try { Step "Starting application."; $sa = Invoke-AmpJson "$remotePrefix/Core/Start" @{} $remoteSession; if ($sa.Status -eq $false) { Step "Core.Start reason: $($sa.Reason)" } else { $started = $true } }
    catch { Step "Core.Start threw: $($_.Exception.Message)" }
}
Step "Deploy finished. started=$started"