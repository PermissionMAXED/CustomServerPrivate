param(
  [int]$MapId = 7,
  [int]$ServerPort = 5160
)
$ErrorActionPreference = "Continue"
$Root = "C:\Users\Administrator\Downloads\CustomServer"
$ServerDll = Join-Path $Root "CustomMatchServer\bin\Release\net10.0\BapCustomServer.dll"
$GameDir = Join-Path $Root "Spiel\Battleroyalebuild"
$GamePath = Join-Path $GameDir "bapbap.exe"
$ClientLog = Join-Path $GameDir "MelonLoader\Latest.log"
$OutDir = Join-Path $Root "logs\colosseum"
$ShotDir = Join-Path $Root "logs\cua"
New-Item -ItemType Directory -Force -Path $OutDir,$ShotDir | Out-Null
$cua = "C:\Users\Administrator\AppData\Local\Programs\Cua\cua-driver\bin\cua-driver.exe"
$FF = "C:\Users\Administrator\Downloads\CustomServer\tools\Force-Foreground.ps1"
$srvOut = Join-Path $OutDir "vis-server-out.log"
$srvErr = Join-Path $OutDir "vis-server-err.log"

function FG($w){ try{ powershell -NoProfile -ExecutionPolicy Bypass -File $FF -Hwnd $w *>$null }catch{} }
function Shot($p,$w,$tag){
  FG $w; Start-Sleep -Milliseconds 400
  $f = Join-Path $ShotDir ("colo-$tag-{0}.png" -f (Get-Date -Format HHmmss))
  ('{"pid":'+$p+',"window_id":'+$w+'}') | & $cua call get_window_state --screenshot-out-file $f *>$null
  Write-Host "SHOT $tag -> $f"
  return $f
}

# Clean
Get-Process bapbap -EA SilentlyContinue | ForEach-Object { try{ ('{"pid":'+$_.Id+'}') | & $cua call kill_app *>$null }catch{} }
Get-Process -Name dotnet -EA SilentlyContinue | Where-Object { $_.Path -and (Get-CimInstance Win32_Process -Filter "ProcessId=$($_.Id)").CommandLine -like "*BapCustomServer.dll*" } | ForEach-Object { try{ Stop-Process -Id $_.Id -Force }catch{} }
Start-Sleep 3

# Server (output to files, keep alive)
$envPairs = @{
  "ASPNETCORE_URLS" = "http://127.0.0.1:$ServerPort"
  "CustomServer__PublicBaseUrl" = "http://127.0.0.1:$ServerPort"
  "CustomServer__Admin__AllowLoopbackAdminWithoutToken" = "true"
  "CustomServer__LaunchGameServers" = "true"
  "CustomServer__RequireGameServerBootstrap" = "true"
  "CustomServer__GameServerReadyTimeoutSeconds" = "300"
  "CustomServer__GameExecutablePath" = $GamePath
  "CustomServer__GameWorkingDirectory" = $GameDir
  "CustomServer__GameLogDirectory" = (Join-Path $Root "CustomMatchServer\logs\game-servers")
}
foreach ($k in $envPairs.Keys) { [Environment]::SetEnvironmentVariable($k, $envPairs[$k]) }
$server = Start-Process -FilePath "dotnet" -ArgumentList "`"$ServerDll`"" -WorkingDirectory $Root -RedirectStandardOutput $srvOut -RedirectStandardError $srvErr -WindowStyle Hidden -PassThru
Write-Host "server pid=$($server.Id) port=$ServerPort"

$deadline=[DateTime]::UtcNow.AddSeconds(20); $ok=$false
do { try{ Invoke-RestMethod "http://127.0.0.1:$ServerPort/health" -TimeoutSec 3 | Out-Null; $ok=$true; break }catch{ Start-Sleep -Milliseconds 400 } } while([DateTime]::UtcNow -lt $deadline)
if(-not $ok){ Write-Host "HEALTH_TIMEOUT"; Stop-Process -Id $server.Id -Force; return }
Write-Host "health OK"

function Send-Ws($s,$o){ $j=$o|ConvertTo-Json -Compress -Depth 20; $b=[Text.Encoding]::UTF8.GetBytes($j); $seg=[ArraySegment[byte]]::new($b); $s.SendAsync($seg,[Net.WebSockets.WebSocketMessageType]::Text,$true,[Threading.CancellationToken]::None).Wait(5000)|Out-Null }
function Recv-Until($s,$events,$timeoutMs){
  $buf=New-Object byte[] 65536; $end=[DateTime]::UtcNow.AddMilliseconds($timeoutMs)
  while([DateTime]::UtcNow -lt $end){
    $ms=[IO.MemoryStream]::new()
    do{ $seg=[ArraySegment[byte]]::new($buf); $t=$s.ReceiveAsync($seg,[Threading.CancellationToken]::None); if(-not $t.Wait($timeoutMs)){ return $null }; $r=$t.Result; $ms.Write($buf,0,$r.Count) } while(-not $r.EndOfMessage)
    $txt=[Text.Encoding]::UTF8.GetString($ms.ToArray()); $ms.Dispose()
    try{ $obj=$txt|ConvertFrom-Json }catch{ continue }
    Write-Host ("WS <- " + $obj.event)
    if($events -contains $obj.event){ return $obj }
  }
  return $null
}

# Drive custom game -> mapId 7
$socket=[Net.WebSockets.ClientWebSocket]::new()
$socket.ConnectAsync([Uri]"ws://127.0.0.1:$ServerPort/ws",[Threading.CancellationToken]::None).Wait(5000)|Out-Null
Recv-Until $socket @("SOCKET_READY") 8000 | Out-Null
Send-Ws $socket @{ event="JOIN_LOBBY"; payload=@{ lobbyId="MATCH1"; charId=1; regionId="custom"; gameModeId=0; isAutoFill=$false } }
Recv-Until $socket @("JOIN_LOBBY_SUCCESS") 8000 | Out-Null
Send-Ws $socket @{ event="UPDATE_CUSTOM_SETTINGS"; payload=@{ settings=@{ gamemode=1; mapId=$MapId; teamSize=1; maxTeams=2; botCount=1; botDifficulty=1 } } }
Recv-Until $socket @("UPDATE_CUSTOM_SETTINGS_SUCCESS") 8000 | Out-Null
Send-Ws $socket @{ event="START_CUSTOM_GAME"; payload=@{ forceStart=$true } }
$res = Recv-Until $socket @("GAME_STARTED","START_CUSTOM_GAME_FAIL") 240000
if(-not $res -or $res.event -ne "GAME_STARTED"){ Write-Host "NO_GAME_STARTED"; Stop-Process -Id $server.Id -Force; return }
$pl = $res.payload
Write-Host ("GAME_STARTED mapId=" + $pl.mapId + " ws=" + $pl.wsPort + " auth=" + $pl.gameAuthId)

# Clear client log so we read THIS client's load markers
try{ Remove-Item $ClientLog -Force -EA SilentlyContinue }catch{}

# Launch VISIBLE client into the match via CUA
$joinArgs = @(
  "--melonloader.agfoffline","--melonloader.captureplayerlogs",
  "--bapcustom-use-proxy=false","--bapcustom-show-ui=false",
  "--bapcustom-host=127.0.0.1","--bapcustom-server-port=$ServerPort",
  "--bapcustom-join-auth=$($pl.gameAuthId)","--bapcustom-join-host=$($pl.gameDns)",
  "--bapcustom-join-ws=$($pl.wsPort)","--bapcustom-join-kcp=$($pl.kcpPort)","--bapcustom-join-tcp=$($pl.tcpPort)"
)
$argsJson = ($joinArgs | ForEach-Object { '"' + $_ + '"' }) -join ","
$lr = ('{"path":"'+($GamePath -replace '\\','\\')+'","additional_arguments":['+$argsJson+']}') | & $cua call launch_app 2>&1
$gpid = if((($lr) -join "`n") -match '"pid":\s*(\d+)'){ [int]$Matches[1] } else { 0 }
Write-Host "client pid=$gpid"
Start-Sleep 55

# Find window
$wins = ('{"pid":'+$gpid+'}' | & $cua call list_windows 2>&1) -join "`n"
$wid=0; foreach($m in [regex]::Matches($wins,'"title":\s*"BAPBAP"[^}]*?"window_id":\s*(\d+)','Singleline')){ $wid=[int]$m.Groups[1].Value; break }
if($wid -eq 0){ foreach($m in [regex]::Matches($wins,'"window_id":\s*(\d+)')){ $wid=[int]$m.Groups[1].Value; break } }
Write-Host "client window=$wid"
Shot $gpid $wid "connect" | Out-Null
Start-Sleep 30
Shot $gpid $wid "match1" | Out-Null
Start-Sleep 25
Shot $gpid $wid "match2" | Out-Null

# Report client-side map load
Write-Host "=== CLIENT [MAP] markers ==="
if(Test-Path $ClientLog){ Select-String -Path $ClientLog -Pattern "\[MAP\]|Loaded Map|SpawnLevel|bootstrap mapId|CustomColosseum|Bazaar" -EA SilentlyContinue | Select-Object -Last 20 | ForEach-Object { Write-Host $_.Line } }
Write-Host "DONE client=$gpid window=$wid server=$($server.Id)"
