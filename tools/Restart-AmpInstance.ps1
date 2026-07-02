param(
    [string]$AmpBaseUrl   = "https://ark.atomi23.de",
    [string]$InstanceId   = "a8556e48-c8be-4f34-b7a1-517607f96b3b",
    [string]$InstanceName = "BAPBattle01",
    [string]$Username     = "Sonic0810"
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

$inst = Invoke-AmpJson "/API/ADSModule/GetInstance" @{ InstanceId = $InstanceId } $SessionId
Step "Before: Running=$($inst.Running) AppState=$($inst.AppState)"

Step "Issuing ADSModule/RestartInstance ($InstanceName)."
$r = Invoke-AmpJson "/API/ADSModule/RestartInstance" @{ InstanceName = $InstanceName } $SessionId
Step "RestartInstance result: $($r | ConvertTo-Json -Depth 4 -Compress)"

for ($i=0; $i -lt 60; $i++) {
    Start-Sleep -Seconds 3
    $inst = Invoke-AmpJson "/API/ADSModule/GetInstance" @{ InstanceId = $InstanceId } $SessionId
    Step "poll $i`: Running=$($inst.Running) AppState=$($inst.AppState)"
    if ($inst.Running -and $inst.AppState -eq 20) { Step "App Ready."; break }
}

$inst = Invoke-AmpJson "/API/ADSModule/GetInstance" @{ InstanceId = $InstanceId } $SessionId
if ($inst.Running -and $inst.AppState -ne 20) {
    Step "App not Ready (AppState=$($inst.AppState)); starting via child API."
    $manage = Invoke-AmpJson "/API/ADSModule/ManageInstance" @{ InstanceId = $InstanceId } $SessionId
    $rt = [string]$manage.Result; if (-not $rt){ $rt = [string]$manage.result }
    $remotePrefix = "/API/ADSModule/Servers/$InstanceId/API"
    $rl = Invoke-AmpJson "$remotePrefix/Core/Login" @{ username=$Username; password=""; token=$rt; rememberMe=$false } ""
    $rs = [string]$rl.sessionID
    $st = Invoke-AmpJson "$remotePrefix/Core/GetStatus" @{} $rs
    Step "child app State before start: $($st.State)"
    if ($st.State -eq 0) {
        $sa = Invoke-AmpJson "$remotePrefix/Core/Start" @{} $rs
        if ($sa.Status -eq $false) { Step "Core/Start reason: $($sa.Reason)" }
        for ($i=0; $i -lt 40; $i++) { Start-Sleep -Seconds 3; $st = Invoke-AmpJson "$remotePrefix/Core/GetStatus" @{} $rs; Step "post-start State=$($st.State)"; if ($st.State -eq 20) { break } }
    }
}
Step "Done."
