param(
    [string]$AmpBaseUrl = "https://ark.atomi23.de",
    [string]$InstanceId = "a8556e48-c8be-4f34-b7a1-517607f96b3b",
    [string]$Username   = "Sonic0810"
)
$ErrorActionPreference = "Stop"
$SessionId = (Get-Content (Join-Path $env:TEMP "amp_session.txt") -Raw).Trim()

Add-Type -AssemblyName System.Net.Http
$client = [System.Net.Http.HttpClient]::new(); $client.Timeout = [TimeSpan]::FromMinutes(3)
function Invoke-AmpJson { param([string]$Path,[hashtable]$Body,[string]$Sid)
    $payload = @{} + $Body; $payload["SESSIONID"] = $Sid
    $json = $payload | ConvertTo-Json -Depth 30 -Compress
    $req = [System.Net.Http.HttpRequestMessage]::new([System.Net.Http.HttpMethod]::Post, "$AmpBaseUrl$Path")
    [void]$req.Headers.Accept.ParseAdd("application/json")
    if ($Sid) { $req.Headers.Authorization = [System.Net.Http.Headers.AuthenticationHeaderValue]::new("Bearer", $Sid) }
    $req.Content = [System.Net.Http.StringContent]::new($json, [System.Text.Encoding]::UTF8, "application/json")
    $resp = $client.SendAsync($req).GetAwaiter().GetResult()
    $text = $resp.Content.ReadAsStringAsync().GetAwaiter().GetResult()
    if (-not $resp.IsSuccessStatusCode) { throw "HTTP $([int]$resp.StatusCode) $Path : $text" }
    if (-not $text) { return $null }
    return $text | ConvertFrom-Json
}
function Step($m){ Write-Host ("[{0:HH:mm:ss}] {1}" -f (Get-Date), $m) }

$manage = Invoke-AmpJson "/API/ADSModule/ManageInstance" @{ InstanceId = $InstanceId } $SessionId
$rt = [string]$manage.Result; if (-not $rt){ $rt = [string]$manage.result }
$remotePrefix = "/API/ADSModule/Servers/$InstanceId/API"
$rl = Invoke-AmpJson "$remotePrefix/Core/Login" @{ username=$Username; password=""; token=$rt; rememberMe=$false } ""
$rs = [string]$rl.sessionID
Step "Logged into child instance API."

# Wait up to 60s for the app to settle out of a transitional state.
$state = $null
for ($i=0; $i -lt 30; $i++) {
    $st = Invoke-AmpJson "$remotePrefix/Core/GetStatus" @{} $rs
    $state = $st.State
    Step "app State = $state"
    if ($state -eq 0 -or $state -eq 30) { break }   # 0=Stopped, 30=Ready/Running
    Start-Sleep -Seconds 2
}

if ($state -eq 30) { Step "App already Running. Done."; return }

if ($state -ne 0) {
    Step "App stuck in transitional state $state; issuing Core/Kill."
    [void](Invoke-AmpJson "$remotePrefix/Core/Kill" @{} $rs)
    for ($i=0; $i -lt 30; $i++) { Start-Sleep -Seconds 2; $st = Invoke-AmpJson "$remotePrefix/Core/GetStatus" @{} $rs; $state = $st.State; Step "after kill State = $state"; if ($state -eq 0) { break } }
}

if ($state -eq 0) {
    Step "Starting application."
    $sa = Invoke-AmpJson "$remotePrefix/Core/Start" @{} $rs
    if ($sa.Status -eq $false) { Step "Core/Start reason: $($sa.Reason)" }
    for ($i=0; $i -lt 40; $i++) { Start-Sleep -Seconds 3; $st = Invoke-AmpJson "$remotePrefix/Core/GetStatus" @{} $rs; Step "post-start State = $($st.State)"; if ($st.State -eq 30) { break } }
} else {
    Step "App did not reach Stopped; manual intervention may be needed (State=$state)."
}
