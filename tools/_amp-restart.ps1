param([string]$Sid = "8b2dae47-0f31-47a6-9d8c-b0329614a244")
$ErrorActionPreference = "Stop"
$Base = "https://ark.atomi23.de"
$Inst = "a8556e48-c8be-4f34-b7a1-517607f96b3b"
$User = "Sonic0810"
Add-Type -AssemblyName System.Net.Http
$c = [System.Net.Http.HttpClient]::new()
$c.Timeout = [TimeSpan]::FromMinutes(3)
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
$m = J "/API/ADSModule/ManageInstance" @{ InstanceId = $Inst } $Sid
$rt = [string]$m.Result; if (-not $rt) { $rt = [string]$m.result }
$rp = "/API/ADSModule/Servers/$Inst/API"
$rl = J "$rp/Core/Login" @{ username = $User; password = ""; token = $rt; rememberMe = $false } ""
$rs = [string]$rl.sessionID
Write-Host "child session len=$($rs.Length)"
$st = J "$rp/Core/GetStatus" @{} $rs
Write-Host "state=$($st.State)"
Write-Host "Kill..."
[void](J "$rp/Core/Kill" @{} $rs)
for ($i = 0; $i -lt 30; $i++) { Start-Sleep 2; $st = J "$rp/Core/GetStatus" @{} $rs; if ($st.State -eq 0) { break } }
Write-Host "after kill state=$($st.State)"
Write-Host "Start..."
[void](J "$rp/Core/Start" @{} $rs)
for ($i = 0; $i -lt 40; $i++) { Start-Sleep 3; $st = J "$rp/Core/GetStatus" @{} $rs; if ($st.State -eq 20) { break } }
Write-Host "after start state=$($st.State)"
