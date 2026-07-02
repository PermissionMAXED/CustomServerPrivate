param(
    [string]$Sid = "",
    [string]$ZipPath = "C:\Users\Administrator\Downloads\CustomServer\deployment\amp-server-hotfix\bapcustomserver-server-hotfix.zip",
    [string]$RemoteZipPath = "bapcustomserver-server-hotfix.zip",
    [int]$ChunkSize = 1048576
)
# Focused child-instance-API deploy: stop app -> upload+verify+extract zip -> start app.
# Avoids the ADSModule.StartInstance call (token lacks that permission); the instance is
# already running so only the inner application needs a restart.
$ErrorActionPreference = "Stop"
$Base = "https://ark.atomi23.de"
$Inst = "a8556e48-c8be-4f34-b7a1-517607f96b3b"
$User = "Sonic0810"
if (-not $Sid) { $Sid = (Get-Content "$env:TEMP\amp_session.txt" -Raw).Trim() }

Add-Type -AssemblyName System.Net.Http
$c = [System.Net.Http.HttpClient]::new(); $c.Timeout = [TimeSpan]::FromMinutes(5)
function J([string]$P, [hashtable]$B, [string]$S) {
    $b = @{} + $B; $b["SESSIONID"] = $S
    $j = $b | ConvertTo-Json -Depth 30 -Compress
    $r = [System.Net.Http.HttpRequestMessage]::new([System.Net.Http.HttpMethod]::Post, "$Base$P")
    [void]$r.Headers.Accept.ParseAdd("application/json")
    if ($S) { $r.Headers.Authorization = [System.Net.Http.Headers.AuthenticationHeaderValue]::new("Bearer", $S) }
    $r.Content = [System.Net.Http.StringContent]::new($j, [System.Text.Encoding]::UTF8, "application/json")
    $resp = $c.SendAsync($r).GetAwaiter().GetResult()
    $t = $resp.Content.ReadAsStringAsync().GetAwaiter().GetResult()
    if (-not $t) { return $null }
    return $t | ConvertFrom-Json
}
function Step($m) { Write-Host ("[{0:HH:mm:ss}] {1}" -f (Get-Date), $m) }

if (-not (Test-Path $ZipPath)) { throw "zip not found: $ZipPath" }

# Child API session via ManageInstance -> Core/Login (the path _amp-console.ps1 proves works)
$m = J "/API/ADSModule/ManageInstance" @{ InstanceId = $Inst } $Sid
$rt = [string]$m.Result; if (-not $rt) { $rt = [string]$m.result }
if (-not $rt) { throw "ManageInstance returned no remote token" }
$rp = "/API/ADSModule/Servers/$Inst/API"
$rl = J "$rp/Core/Login" @{ username = $User; password = ""; token = $rt; rememberMe = $false } ""
$rs = [string]$rl.sessionID
if (-not $rs) { throw "child Core/Login failed: $($rl | ConvertTo-Json -Compress)" }
Step "child API session OK"

$st = J "$rp/Core/GetStatus" @{} $rs
Step "app state before: $($st.State)"
if ($st.State -ne 0) {
    Step "stopping app"
    [void](J "$rp/Core/Stop" @{} $rs)
    for ($i = 0; $i -lt 40; $i++) { Start-Sleep 2; $st = J "$rp/Core/GetStatus" @{} $rs; if ($st.State -eq 0) { break } }
    Step "app state after stop: $($st.State)"
    if ($st.State -ne 0) { Step "forcing Kill"; [void](J "$rp/Core/Kill" @{} $rs); for ($i = 0; $i -lt 30; $i++) { Start-Sleep 1; $st = J "$rp/Core/GetStatus" @{} $rs; if ($st.State -eq 0) { break } } }
    if ($st.State -ne 0) { throw "app did not stop, state=$($st.State)" }
}

try { [void](J "$rp/FileManagerPlugin/TrashFile" @{ Filename = $RemoteZipPath } $rs) } catch {}

$bytes = [System.IO.File]::ReadAllBytes((Resolve-Path -LiteralPath $ZipPath))
$localMd5 = (Get-FileHash -LiteralPath $ZipPath -Algorithm MD5).Hash.ToLowerInvariant()
Step ("uploading {0:N1} KiB" -f ($bytes.Length / 1KB))
for ($off = 0L; $off -lt $bytes.Length; $off += $ChunkSize) {
    $cnt = [Math]::Min($ChunkSize, $bytes.Length - $off)
    $data = [Convert]::ToBase64String($bytes, [int]$off, [int]$cnt)
    $fin = ($off + $cnt) -ge $bytes.Length
    $res = J "$rp/FileManagerPlugin/WriteFileChunk" @{ Filename = $RemoteZipPath; Data = $data; Offset = $off; FinalChunk = $fin } $rs
    if ($res.Status -eq $false) { throw "WriteFileChunk failed at $off : $($res.Reason)" }
}
$rmd5 = [string](J "$rp/FileManagerPlugin/CalculateFileMD5Sum" @{ FilePath = $RemoteZipPath } $rs).Result
Step "md5 local=$localMd5 remote=$rmd5"
if ($rmd5.ToLowerInvariant() -ne $localMd5) { throw "MD5 mismatch" }

Step "extracting archive into root"
$ex = J "$rp/FileManagerPlugin/ExtractArchive" @{ ArchivePath = $RemoteZipPath; DestinationPath = "" } $rs
if ($ex.Status -eq $false) { throw "ExtractArchive failed: $($ex.Reason)" }

Step "starting app"
$sa = J "$rp/Core/Start" @{} $rs
if ($sa.Status -eq $false) { throw "Core/Start failed: $($sa.Reason)" }
Step "DEPLOY COMPLETE"
