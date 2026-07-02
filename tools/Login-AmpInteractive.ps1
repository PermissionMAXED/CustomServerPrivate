param(
  [string]$AmpBaseUrl = "https://ark.atomi23.de",
  [string]$Username   = "Sonic0810",
  [string]$InstanceId = "a8556e48-c8be-4f34-b7a1-517607f96b3b",
  [string]$SessionOut = (Join-Path $env:TEMP "amp_session.txt")
)
# Interactive AMP login. Prompts for the password (never stored/printed), does Core/Login,
# validates the session, and writes the session id to %TEMP%\amp_session.txt for the deploy script.
$ErrorActionPreference = "Stop"

$sec = Read-Host -AsSecureString ("AMP password for {0}@{1}" -f $Username, $AmpBaseUrl)
$bstr = [Runtime.InteropServices.Marshal]::SecureStringToBSTR($sec)
$password = [Runtime.InteropServices.Marshal]::PtrToStringBSTR($bstr)
[Runtime.InteropServices.Marshal]::ZeroFreeBSTR($bstr)

Add-Type -AssemblyName System.Net.Http
$client = [System.Net.Http.HttpClient]::new(); $client.Timeout = [TimeSpan]::FromMinutes(2)
function Api($path, $bodyHash, $sid) {
  $json = ($bodyHash + @{ SESSIONID = $sid }) | ConvertTo-Json -Compress
  $req = [System.Net.Http.HttpRequestMessage]::new([System.Net.Http.HttpMethod]::Post, "$AmpBaseUrl$path")
  [void]$req.Headers.Accept.ParseAdd("application/json")
  if ($sid) { $req.Headers.Authorization = [System.Net.Http.Headers.AuthenticationHeaderValue]::new("Bearer", $sid) }
  $req.Content = [System.Net.Http.StringContent]::new($json, [Text.Encoding]::UTF8, "application/json")
  $resp = $client.SendAsync($req).GetAwaiter().GetResult()
  return ($resp.Content.ReadAsStringAsync().GetAwaiter().GetResult() | ConvertFrom-Json)
}

$login = Api "/API/Core/Login" @{ username = $Username; password = $password; token = ""; rememberMe = $true } ""
$password = $null
if (-not $login.success -or [string]::IsNullOrWhiteSpace($login.sessionID)) {
  Write-Output ("LOGIN_FAILED resultReason=" + $login.resultReason)
  return
}
$sid = [string]$login.sessionID
$inst = Api "/API/ADSModule/GetInstance" @{ InstanceId = $InstanceId } $sid
Set-Content -Path $SessionOut -Value $sid -Encoding ASCII -NoNewline
Write-Output ("SESSION_OK instanceRunning=" + $inst.Running + " appState=" + $inst.AppState + " savedTo=" + $SessionOut)
