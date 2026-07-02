param(
    [string]$AmpBaseUrl   = "https://ark.atomi23.de",
    [string]$InstanceId   = "a8556e48-c8be-4f34-b7a1-517607f96b3b",
    [string]$InstanceName = "BAPBattle01",
    [string]$Username     = "Sonic0810",
    [string]$LocalFile    = "C:\Users\Administrator\Downloads\CustomServer\Spiel\Battleroyalebuild\UserData\CustomMaps\customcitadel.json",
    [string]$RemoteDir    = "game/UserData/CustomMaps",
    [string]$SessionId    = "",
    [switch]$ListOnly
)
$ErrorActionPreference = "Stop"
if ([string]::IsNullOrWhiteSpace($SessionId)) {
    $tf = Join-Path $env:TEMP "amp_session.txt"
    if (Test-Path $tf) { $SessionId = (Get-Content $tf -Raw).Trim() }
}
if ([string]::IsNullOrWhiteSpace($SessionId)) { throw "No AMP SessionId." }
if (-not $ListOnly -and -not (Test-Path -LiteralPath $LocalFile)) { throw "File not found: $LocalFile" }

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
$manage = Invoke-AmpJson "/API/ADSModule/ManageInstance" @{ InstanceId = $InstanceId } $session
$remoteToken = [string]$manage.Result; if ([string]::IsNullOrWhiteSpace($remoteToken)) { $remoteToken = [string]$manage.result }
if ([string]::IsNullOrWhiteSpace($remoteToken)) { throw "ManageInstance returned no token." }
$remotePrefix = "/API/ADSModule/Servers/$InstanceId/API"
$remoteLogin = Invoke-AmpJson "$remotePrefix/Core/Login" @{ username=$Username; password=""; token=$remoteToken; rememberMe=$false } ""
if (-not $remoteLogin.success -or [string]::IsNullOrWhiteSpace($remoteLogin.sessionID)) { throw "Remote Core/Login failed." }
$remoteSession = [string]$remoteLogin.sessionID
Step "Logged into child instance API."

# List remote CustomMaps to confirm the path is right.
$dir = Invoke-AmpJson "$remotePrefix/FileManagerPlugin/GetDirectoryListing" @{ Dir = $RemoteDir } $remoteSession
Step "Remote ${RemoteDir} listing:"
foreach ($f in $dir) { Step ("  {0}  {1}b" -f $f.Filename, $f.SizeBytes) }
if ($ListOnly) { return }

$remotePath = "$RemoteDir/" + [System.IO.Path]::GetFileName($LocalFile)
try { [void](Invoke-AmpJson "$remotePrefix/FileManagerPlugin/TrashFile" @{ Filename = $remotePath } $remoteSession); Step "Removed old $remotePath" } catch {}

$bytes = [System.IO.File]::ReadAllBytes((Resolve-Path -LiteralPath $LocalFile))
$localMd5 = (Get-FileHash -LiteralPath $LocalFile -Algorithm MD5).Hash.ToLowerInvariant()
$data = [Convert]::ToBase64String($bytes)
Step "Uploading $($bytes.Length)b -> $remotePath"
$r = Invoke-AmpJson "$remotePrefix/FileManagerPlugin/WriteFileChunk" @{ Filename=$remotePath; Data=$data; Offset=0; FinalChunk=$true } $remoteSession
if ($r.Status -eq $false) { throw "WriteFileChunk failed: $($r.Reason)" }
$rm = Invoke-AmpJson "$remotePrefix/FileManagerPlugin/CalculateFileMD5Sum" @{ FilePath = $remotePath } $remoteSession
$remoteMd5 = [string]$rm.Result
Step "MD5 local=$localMd5 remote=$remoteMd5"
if ($remoteMd5.ToLowerInvariant() -ne $localMd5) { throw "MD5 mismatch after upload." }
Step "Upload OK: $remotePath"
