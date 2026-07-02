param(
  [string]$AmpBaseUrl = "https://ark.atomi23.de",
  [string]$InstanceId = "a8556e48-c8be-4f34-b7a1-517607f96b3b"
)
# READ-ONLY: report whether the saved AMP session token (%TEMP%\amp_session.txt) is still valid.
# Expired token => AMP returns "requires Session.Exists permission". Does NOT modify anything.
$ErrorActionPreference = "Stop"
$tf = Join-Path $env:TEMP "amp_session.txt"
if (-not (Test-Path $tf)) { Write-Output "NO_TOKEN_FILE"; exit }
$sid = (Get-Content $tf -Raw).Trim()
Add-Type -AssemblyName System.Net.Http
$client = [System.Net.Http.HttpClient]::new(); $client.Timeout = [TimeSpan]::FromSeconds(30)
function Api($path, $bodyHash, $s) {
  $payload = @{} + $bodyHash; $payload["SESSIONID"] = $s
  $json = $payload | ConvertTo-Json -Compress
  $req = [System.Net.Http.HttpRequestMessage]::new([System.Net.Http.HttpMethod]::Post, "$AmpBaseUrl$path")
  [void]$req.Headers.Accept.ParseAdd("application/json")
  if ($s) { $req.Headers.Authorization = [System.Net.Http.Headers.AuthenticationHeaderValue]::new("Bearer", $s) }
  $req.Content = [System.Net.Http.StringContent]::new($json, [Text.Encoding]::UTF8, "application/json")
  $resp = $client.SendAsync($req).GetAwaiter().GetResult()
  return @{ code = [int]$resp.StatusCode; body = $resp.Content.ReadAsStringAsync().GetAwaiter().GetResult() }
}
$r = Api "/API/ADSModule/GetInstance" @{ InstanceId = $InstanceId } $sid
if ([string]::IsNullOrWhiteSpace($r.body)) { Write-Output "EMPTY_BODY (token likely invalid)"; exit }
try {
  $j = $r.body | ConvertFrom-Json
  if ($null -ne $j.Running) { Write-Output ("TOKEN_VALID Running=" + $j.Running + " AppState=" + $j.AppState + " Name=" + $j.InstanceName) }
  else { Write-Output ("TOKEN_RESPONSE_NO_INSTANCE: " + $r.body.Substring(0, [Math]::Min(200, $r.body.Length))) }
} catch { Write-Output ("TOKEN_INVALID_OR_NONJSON: " + $r.body.Substring(0, [Math]::Min(200, $r.body.Length))) }
