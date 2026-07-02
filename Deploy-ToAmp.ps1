$AmpBaseUrl='https://ark.atomi23.de'; $Sid='848a9f37-16fd-4ce4-bb78-249b1dcfe91b'; $InstanceId='a8556e48-c8be-4f34-b7a1-517607f96b3b'; $Username='Sonic0810'
Add-Type -AssemblyName System.Net.Http
$client=[System.Net.Http.HttpClient]::new(); $client.Timeout=[TimeSpan]::FromMinutes(10)
function Api($Path,$Body,$S){ $payload=@{}+$Body;$payload['SESSIONID']=$S;$json=$payload|ConvertTo-Json -Depth 30 -Compress;$req=[System.Net.Http.HttpRequestMessage]::new([System.Net.Http.HttpMethod]::Post,"$AmpBaseUrl$Path");[void]$req.Headers.Accept.ParseAdd('application/json');if($S){$req.Headers.Authorization=[System.Net.Http.Headers.AuthenticationHeaderValue]::new('Bearer',$S)};$req.Content=[System.Net.Http.StringContent]::new($json,[System.Text.Encoding]::UTF8,'application/json');$resp=$client.SendAsync($req).GetAwaiter().GetResult();$text=$resp.Content.ReadAsStringAsync().GetAwaiter().GetResult();if(-not$resp.IsSuccessStatusCode){throw "HTTP $([int]$resp.StatusCode) $Path $text"};if($text){return $text|ConvertFrom-Json};return $null }
$manage=Api '/API/ADSModule/ManageInstance' @{InstanceId=$InstanceId} $Sid
$rt=[string]$manage.Result; if(-not$rt){$rt=[string]$manage.result}; if(-not$rt){$rt=[string]$manage.Token}; if(-not$rt){throw "no token: $($manage|ConvertTo-Json -Depth 8 -Compress)"}
$prefix="/API/ADSModule/Servers/$InstanceId/API"
$login=Api "$prefix/Core/Login" @{username=$Username;password='';token=$rt;rememberMe=$false} ''
Write-Host "CHILD_SESSION=$($login.sessionID)"
$status=Api "$prefix/Core/GetStatus" @{} $login.sessionID
Write-Host "APP_STATE=$($status.State)"
if($status.State -ne 0){ Api "$prefix/Core/Stop" @{} $login.sessionID | Out-Null; Start-Sleep -Seconds 5; $status=Api "$prefix/Core/GetStatus" @{} $login.sessionID; Write-Host "AFTER_STOP=$($status.State)" }

# Step 2 — Upload DLLs + start-match.sh:
$localRoot='C:\Users\Administrator\Downloads\CustomServer'
$files=@(
  @{Local=Join-Path $localRoot 'CustomMatchServer\bin\Release\net10.0\BapCustomServer.dll'; Remote='BapCustomServer.dll'}
  @{Local=Join-Path $localRoot 'BapCustomServerMelon\dist\BapCustomServerMelon.dll'; Remote='game/Mods/BapCustomServerMelon.dll'}
  @{Local=Join-Path $localRoot 'deployment\amp-full-linux-wine\start-match.sh'; Remote='start-match.sh'}
)
foreach($f in $files){
  $bytes=[System.IO.File]::ReadAllBytes($f.Local)
  Write-Host "UPLOADING $($f.Remote) $($bytes.Length)b"
  $chunkSize=524288
  for($offset=0L;$offset -lt $bytes.Length;$offset+=$chunkSize){
    $count=[Math]::Min($chunkSize,$bytes.Length-$offset)
    $data=[Convert]::ToBase64String($bytes,[int]$offset,[int]$count)
    $final=($offset+$count) -ge $bytes.Length
    $r=Api "$prefix/FileManagerPlugin/WriteFileChunk" @{Filename=$f.Remote;Data=$data;Offset=$offset;FinalChunk=$final} $login.sessionID
    if($r.Status -eq $false){throw "write failed at $($f.Remote) offset ${offset}: $($r.Reason)"}
  }
  $rm=Api "$prefix/FileManagerPlugin/CalculateFileMD5Sum" @{FilePath=$f.Remote} $login.sessionID
  $lm=(Get-FileHash -LiteralPath $f.Local -Algorithm MD5).Hash.ToLowerInvariant()
  Write-Host "UPLOAD_OK $($f.Remote) localMd5=$lm remoteMd5=$($rm.Result)"
  if($rm.Result.ToLowerInvariant() -ne $lm){throw "MD5 mismatch for $($f.Remote)"}
}

# Step 3 — Restart:
Write-Host "RESTARTING"
$sa=Api "$prefix/Core/Start" @{} $login.sessionID
Write-Host "START_RESULT status=$($sa.Status) reason=$($sa.Reason)"
for($i=0;$i -lt 30;$i++){Start-Sleep -Seconds 4;$st2=Api "$prefix/Core/GetStatus" @{} $login.sessionID;Write-Host "POLL_$i State=$($st2.State)";if($st2.State -eq 20){Write-Host "APP_READY";break}}
Write-Host "DONE"
