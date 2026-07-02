param(
    [string]$AmpBaseUrl   = "https://ark.atomi23.de",
    [string]$InstanceId   = "a8556e48-c8be-4f34-b7a1-517607f96b3b",
    [string]$Username     = "Sonic0810",
    [string]$SessionId    = "",
    # Pairs of "localPath=remotePath" (remote relative to instance root, e.g. game/Mods/Foo.dll)
    [Parameter(Mandatory=$true)][string[]]$Files
)
$ErrorActionPreference = "Stop"
if ([string]::IsNullOrWhiteSpace($SessionId)) {
    $tf = Join-Path $env:TEMP "amp_session.txt"
    if (Test-Path $tf) { $SessionId = (Get-Content $tf -Raw).Trim() }
}
if ([string]::IsNullOrWhiteSpace($SessionId)) { throw "No AMP SessionId." }

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

$manage = Invoke-AmpJson "/API/ADSModule/ManageInstance" @{ InstanceId = $InstanceId } $SessionId
$remoteToken = [string]$manage.Result; if ([string]::IsNullOrWhiteSpace($remoteToken)) { $remoteToken = [string]$manage.result }
if ([string]::IsNullOrWhiteSpace($remoteToken)) { throw "ManageInstance returned no token." }
$remotePrefix = "/API/ADSModule/Servers/$InstanceId/API"
$remoteLogin = Invoke-AmpJson "$remotePrefix/Core/Login" @{ username=$Username; password=""; token=$remoteToken; rememberMe=$false } ""
if (-not $remoteLogin.success -or [string]::IsNullOrWhiteSpace($remoteLogin.sessionID)) { throw "Remote Core/Login failed." }
$remoteSession = [string]$remoteLogin.sessionID
Step "Logged into child instance API."

$chunk = 1048576
foreach ($pair in $Files) {
    $idx = $pair.IndexOf("=")
    $local = $pair.Substring(0, $idx)
    $remote = $pair.Substring($idx + 1)
    if (-not (Test-Path -LiteralPath $local)) { throw "Local file not found: $local" }
    try { [void](Invoke-AmpJson "$remotePrefix/FileManagerPlugin/TrashFile" @{ Filename = $remote } $remoteSession) } catch {}
    $bytes = [System.IO.File]::ReadAllBytes((Resolve-Path -LiteralPath $local))
    $localMd5 = (Get-FileHash -LiteralPath $local -Algorithm MD5).Hash.ToLowerInvariant()
    Step "Uploading $([Math]::Round($bytes.Length/1KB,1)) KiB -> $remote"
    for ($offset=0L; $offset -lt $bytes.Length; $offset += $chunk) {
        $count = [Math]::Min($chunk, $bytes.Length - $offset)
        $data  = [Convert]::ToBase64String($bytes, [int]$offset, [int]$count)
        $final = ($offset + $count) -ge $bytes.Length
        $r = Invoke-AmpJson "$remotePrefix/FileManagerPlugin/WriteFileChunk" @{ Filename=$remote; Data=$data; Offset=$offset; FinalChunk=$final } $remoteSession
        if ($r.Status -eq $false) { throw "WriteFileChunk failed at $offset`: $($r.Reason)" }
    }
    $rm = Invoke-AmpJson "$remotePrefix/FileManagerPlugin/CalculateFileMD5Sum" @{ FilePath = $remote } $remoteSession
    $remoteMd5 = [string]$rm.Result
    if ($remoteMd5.ToLowerInvariant() -ne $localMd5) { throw "MD5 mismatch for $remote (local=$localMd5 remote=$remoteMd5)" }
    Step "OK $remote md5=$remoteMd5"
}
Step "All uploads verified."
