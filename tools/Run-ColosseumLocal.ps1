param(
  [int]$MapId = 8,
  [int]$ServerPort = 5157
)
$ErrorActionPreference = "Stop"
$Root = "C:\Users\Administrator\Downloads\CustomServer"
$ServerDll = Join-Path $Root "CustomMatchServer\bin\Release\net10.0\BapCustomServer.dll"
$GameDir = Join-Path $Root "Spiel\Battleroyalebuild"
$OutDir = Join-Path $Root "logs\colosseum"
New-Item -ItemType Directory -Force -Path $OutDir | Out-Null
$srvOut = Join-Path $OutDir "server-out.log"
$srvErr = Join-Path $OutDir "server-err.log"

# Start server detached, output to files (NOT piped) per the proven recipe.
$env:ASPNETCORE_URLS = "http://127.0.0.1:$ServerPort"
$psi = @{
  FilePath = "dotnet"
  ArgumentList = "`"$ServerDll`""
  WorkingDirectory = $Root
  RedirectStandardOutput = $srvOut
  RedirectStandardError = $srvErr
  WindowStyle = "Hidden"
  PassThru = $true
}
$envPairs = @{
  "ASPNETCORE_URLS" = "http://127.0.0.1:$ServerPort"
  "CustomServer__PublicBaseUrl" = "http://127.0.0.1:$ServerPort"
  "CustomServer__Admin__AllowLoopbackAdminWithoutToken" = "true"
  "CustomServer__LaunchGameServers" = "true"
  "CustomServer__RequireGameServerBootstrap" = "true"
  "CustomServer__GameServerReadyTimeoutSeconds" = "300"
  "CustomServer__GameExecutablePath" = (Join-Path $GameDir "bapbap.exe")
  "CustomServer__GameWorkingDirectory" = $GameDir
  "CustomServer__GameLogDirectory" = (Join-Path $Root "CustomMatchServer\logs\game-servers")
}
foreach ($k in $envPairs.Keys) { [Environment]::SetEnvironmentVariable($k, $envPairs[$k]) }
$server = Start-Process @psi
Write-Host "server pid=$($server.Id) port=$ServerPort"

# Wait for health
$deadline = [DateTime]::UtcNow.AddSeconds(20)
$healthy = $false
do {
  try { Invoke-RestMethod "http://127.0.0.1:$ServerPort/health" -TimeoutSec 3 | Out-Null; $healthy = $true; break }
  catch { Start-Sleep -Milliseconds 400 }
} while ([DateTime]::UtcNow -lt $deadline)
if (-not $healthy) { Write-Host "HEALTH_TIMEOUT"; Stop-Process -Id $server.Id -Force; return }
Write-Host "health OK"

function Send-Ws($s,$o){ $j=$o|ConvertTo-Json -Compress -Depth 20; $b=[Text.Encoding]::UTF8.GetBytes($j); $seg=[ArraySegment[byte]]::new($b); $s.SendAsync($seg,[Net.WebSockets.WebSocketMessageType]::Text,$true,[Threading.CancellationToken]::None).Wait(5000)|Out-Null }
function Recv-Until($s,$events,$timeoutMs){
  $buf=New-Object byte[] 65536
  $end=[DateTime]::UtcNow.AddMilliseconds($timeoutMs)
  while([DateTime]::UtcNow -lt $end){
    $ms=[IO.MemoryStream]::new()
    do{
      $seg=[ArraySegment[byte]]::new($buf)
      $t=$s.ReceiveAsync($seg,[Threading.CancellationToken]::None)
      if(-not $t.Wait($timeoutMs)){ return $null }
      $r=$t.Result
      $ms.Write($buf,0,$r.Count)
    } while(-not $r.EndOfMessage)
    $txt=[Text.Encoding]::UTF8.GetString($ms.ToArray()); $ms.Dispose()
    try{ $obj=$txt|ConvertFrom-Json }catch{ continue }
    Write-Host ("WS <- " + $obj.event)
    if($events -contains $obj.event){ return $obj }
  }
  return $null
}

$socket=[Net.WebSockets.ClientWebSocket]::new()
$socket.ConnectAsync([Uri]"ws://127.0.0.1:$ServerPort/ws",[Threading.CancellationToken]::None).Wait(5000)|Out-Null
Recv-Until $socket @("SOCKET_READY") 8000 | Out-Null
Send-Ws $socket @{ event="JOIN_LOBBY"; payload=@{ lobbyId="MATCH1"; charId=1; regionId="custom"; gameModeId=0; isAutoFill=$false } }
Recv-Until $socket @("JOIN_LOBBY_SUCCESS") 8000 | Out-Null
Send-Ws $socket @{ event="UPDATE_CUSTOM_SETTINGS"; payload=@{ settings=@{ gamemode=1; mapId=$MapId; teamSize=1; maxTeams=2; botCount=1; botDifficulty=1 } } }
Recv-Until $socket @("UPDATE_CUSTOM_SETTINGS_SUCCESS") 8000 | Out-Null
Send-Ws $socket @{ event="START_CUSTOM_GAME"; payload=@{ forceStart=$true } }
$res = Recv-Until $socket @("GAME_STARTED","START_CUSTOM_GAME_FAIL") 240000
if($res){ Write-Host ("TERMINAL=" + $res.event); Write-Host ("PAYLOAD=" + ($res.payload | ConvertTo-Json -Compress -Depth 10)) }
else { Write-Host "TERMINAL=NONE_TIMEOUT" }
Start-Sleep 8
try{ $socket.Dispose() }catch{}
Stop-Process -Id $server.Id -Force -ErrorAction SilentlyContinue
Get-Process bapbap -ErrorAction SilentlyContinue | Stop-Process -Force -ErrorAction SilentlyContinue
Write-Host "DONE"
