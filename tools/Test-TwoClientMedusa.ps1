param(
    [int]$ServerPort = 5161,
    [int]$LeaderCharId = 15,
    [int]$GuestCharId = 1,
    [int]$GameServerReadyTimeoutSeconds = 160
)

$ErrorActionPreference = "Stop"
$Root = Resolve-Path (Join-Path $PSScriptRoot "..")
$ServerDll = Join-Path $Root "CustomMatchServer\bin\Release\net10.0\BapCustomServer.dll"
$GameDir = Join-Path $Root "Spiel\Battleroyalebuild"
$GameExe = Join-Path $GameDir "bapbap.exe"
$Cua = "C:\Users\Administrator\AppData\Local\Programs\Cua\cua-driver\bin\cua-driver.exe"
$ShotDir = Join-Path $Root "logs\cua"
$MatchHostArgs = "--melonloader.agfoffline --melonloader.captureplayerlogs --bapcustom-host=127.0.0.1 --bapcustom-server-port=$ServerPort --bapcustom-use-proxy=false --bapcustom-show-ui=false --bapcustom-auto-end-after=6"

function Test-PortFree([int]$Port){
    $c=[System.Net.Sockets.TcpClient]::new()
    try{ $t=$c.ConnectAsync("127.0.0.1",$Port); $o=$t.Wait(250); return -not ($o -and $c.Connected) }catch{ return $true }finally{ $c.Dispose() }
}
function Start-TestServer{
    $psi=[System.Diagnostics.ProcessStartInfo]::new()
    $psi.FileName="dotnet"; $psi.Arguments="`"$ServerDll`""; $psi.WorkingDirectory=$Root
    $psi.UseShellExecute=$false; $psi.CreateNoWindow=$true
    $psi.EnvironmentVariables["ASPNETCORE_URLS"]="http://127.0.0.1:$ServerPort"
    $psi.EnvironmentVariables["CustomServer__PublicBaseUrl"]="http://127.0.0.1:$ServerPort"
    $psi.EnvironmentVariables["CustomServer__Admin__AllowLoopbackAdminWithoutToken"]="true"
    $psi.EnvironmentVariables["CustomServer__LaunchGameServers"]="true"
    $psi.EnvironmentVariables["CustomServer__RequireGameServerBootstrap"]="true"
    $psi.EnvironmentVariables["CustomServer__GameServerReadyTimeoutSeconds"]=$GameServerReadyTimeoutSeconds.ToString()
    $psi.EnvironmentVariables["CustomServer__GameExecutablePath"]=$GameExe
    $psi.EnvironmentVariables["CustomServer__GameWorkingDirectory"]=$GameDir
    $psi.EnvironmentVariables["CustomServer__GameLogDirectory"]=(Join-Path $Root "CustomMatchServer\logs\game-servers")
    $psi.EnvironmentVariables["CustomServer__AdditionalGameArguments"]=$MatchHostArgs
    $psi.EnvironmentVariables["BAPBAP_NETCUSTOM_AUTOCAST"]="1"
    return [System.Diagnostics.Process]::Start($psi)
}
function Wait-Health{ $d=[DateTime]::UtcNow.AddSeconds(20); do{ try{ return Invoke-RestMethod "http://127.0.0.1:$ServerPort/health" }catch{ Start-Sleep -Milliseconds 300 } }while([DateTime]::UtcNow -lt $d); throw "no server health" }
function New-Sock([string]$AccountId,[string]$Username){
    $s=[System.Net.WebSockets.ClientWebSocket]::new()
    $u=[Uri]"ws://127.0.0.1:$ServerPort/ws?accountId=$AccountId&username=$Username"
    $c=$s.ConnectAsync($u,[Threading.CancellationToken]::None); if(-not $c.Wait(6000)){ throw "ws connect timeout $AccountId" }; if($c.IsFaulted){ throw $c.Exception }
    return $s
}
function Send-Ws($Socket,$Message){
    $j=$Message|ConvertTo-Json -Compress -Depth 20; $b=[System.Text.Encoding]::UTF8.GetBytes($j); $seg=[ArraySegment[byte]]::new($b)
    $t=$Socket.SendAsync($seg,[System.Net.WebSockets.WebSocketMessageType]::Text,$true,[Threading.CancellationToken]::None); if(-not $t.Wait(5000)){ throw "ws send timeout" }; if($t.IsFaulted){ throw $t.Exception }
}
function Recv-Ws($Socket,[int]$TimeoutMs=5000){
    $buf=New-Object byte[] 65536; $ms=[System.IO.MemoryStream]::new()
    try{ do{ $seg=[ArraySegment[byte]]::new($buf); $t=$Socket.ReceiveAsync($seg,[Threading.CancellationToken]::None); if(-not $t.Wait($TimeoutMs)){ throw "ws recv timeout" }; if($t.IsFaulted){ throw $t.Exception }; $r=$t.Result; if($r.MessageType -eq [System.Net.WebSockets.WebSocketMessageType]::Close){ throw "ws closed" }; $ms.Write($buf,0,$r.Count) }while(-not $r.EndOfMessage); return ([System.Text.Encoding]::UTF8.GetString($ms.ToArray())|ConvertFrom-Json) }finally{ $ms.Dispose() }
}
function Recv-Until($Socket,[string[]]$Events,[int]$Max=80,[int]$TimeoutMs=5000){
    $seen=@(); for($i=0;$i -lt $Max;$i++){ $m=Recv-Ws $Socket $TimeoutMs; $seen+=$m.event; if($Events -contains $m.event){ return [pscustomobject]@{Message=$m;Seen=$seen} } }
    throw "did not see: $($Events -join ',') seen: $($seen -join ',')"
}
function Start-Client($Payload,[string]$Label){
    $clientLog=Join-Path $Root ("CustomMatchServer\logs\game-servers\2c-{0}.log" -f $Label)
    $a="-logFile `"$clientLog`" --melonloader.agfoffline --melonloader.captureplayerlogs --bapcustom-use-proxy=false --bapcustom-show-ui=false --bapcustom-host=127.0.0.1 --bapcustom-server-port=$ServerPort --bapcustom-account-id=$Label --bapcustom-username=$Label --bapcustom-join-auth=$($Payload.gameAuthId) --bapcustom-join-host=$($Payload.gameDns) --bapcustom-join-ws=$($Payload.wsPort) --bapcustom-join-kcp=$($Payload.kcpPort) --bapcustom-join-tcp=$($Payload.tcpPort)"
    $p=Start-Process -FilePath $GameExe -WorkingDirectory $GameDir -ArgumentList $a -WindowStyle Normal -PassThru
    return [pscustomobject]@{ Process=$p; Label=$Label; Wid=0 }
}
function Find-Wid([int]$ProcId){
    try{ $w=(('{"pid":'+$ProcId+'}')|& $Cua call list_windows 2>&1)-join "`n"
        $id=0; foreach($m in [regex]::Matches($w,'"title":\s*"BAPBAP"[^}]*?"window_id":\s*(\d+)','Singleline')){$id=[int]$m.Groups[1].Value;break}
        if($id -eq 0){ foreach($m in [regex]::Matches($w,'"window_id":\s*(\d+)')){$id=[int]$m.Groups[1].Value;break} }
        return $id }catch{ return 0 }
}
function Shot([int]$ProcId,[int]$Wid,[string]$Tag){ $f=Join-Path $ShotDir ("2c-$Tag-{0}.png" -f (Get-Date -Format HHmmss)); ('{"pid":'+$ProcId+',"window_id":'+$Wid+'}')|& $Cua call get_window_state --screenshot-out-file $f *>$null; return $f }
function ClickRel([int]$ProcId,[int]$Wid,[double]$rx,[double]$ry){
    $r=(('{"pid":'+$ProcId+',"window_id":'+$Wid+'}')|& $Cua call get_window_state 2>&1)-join "`n"
    $ww=if($r -match '"screenshot_width":\s*(\d+)'){[int]$Matches[1]}else{1536}; $hh=if($r -match '"screenshot_height":\s*(\d+)'){[int]$Matches[1]}else{864}
    ('{"pid":'+$ProcId+',"window_id":'+$Wid+',"x":'+[int]($rx*$ww)+',"y":'+[int]($ry*$hh)+',"dispatch":"foreground"}')|& $Cua call click *>$null
}

if(-not (Test-Path $ServerDll)){ throw "build CustomMatchServer first: $ServerDll missing" }
Get-Process bapbap -EA SilentlyContinue | ForEach-Object { try{ ('{"pid":'+$_.Id+'}')|& $Cua call kill_app *>$null }catch{} }
Start-Sleep 2

$server=$null
if(Test-PortFree $ServerPort){ Write-Host "starting local server :$ServerPort"; $server=Start-TestServer; Wait-Health|Out-Null }else{ Write-Host "reusing server :$ServerPort" }
$leaderSock=$null; $guestSock=$null; $clients=@()
try{
    $leaderSock=New-Sock "med-leader" "med-leader"
    $guestSock=New-Sock "med-guest" "med-guest"
    Recv-Until $leaderSock @("SOCKET_READY")|Out-Null
    Recv-Until $guestSock @("SOCKET_READY")|Out-Null

    Send-Ws $leaderSock @{ event="JOIN_LOBBY"; payload=@{ lobbyId="MEDUO"; charId=$LeaderCharId; regionId="custom"; gameModeId=0; isAutoFill=$false } }
    Recv-Until $leaderSock @("JOIN_LOBBY_SUCCESS") 80 15000|Out-Null
    Send-Ws $guestSock @{ event="JOIN_LOBBY"; payload=@{ lobbyId="MEDUO"; charId=$GuestCharId; regionId="custom"; gameModeId=0; isAutoFill=$false } }
    Recv-Until $guestSock @("JOIN_LOBBY_SUCCESS") 80 15000|Out-Null

    Send-Ws $leaderSock @{ event="UPDATE_CUSTOM_SETTINGS"; payload=@{ settings=@{ gamemode=1; mapId=1; teamSize=2; maxTeams=4; botCount=6; botDifficulty=1 } } }
    Recv-Until $leaderSock @("UPDATE_CUSTOM_SETTINGS_SUCCESS")|Out-Null

    Send-Ws $leaderSock @{ event="START_CUSTOM_GAME"; payload=@{ forceStart=$true } }
    $tmo=[Math]::Max(40000,($GameServerReadyTimeoutSeconds+40)*1000)
    $ls=Recv-Until $leaderSock @("START_CUSTOM_GAME_FAIL","GAME_STARTED") 200 $tmo
    if($ls.Message.event -ne "GAME_STARTED"){ throw "leader no GAME_STARTED (got $($ls.Message.event))" }
    $gs=Recv-Until $guestSock @("GAME_STARTED") 200 40000
    Write-Host "GAME_STARTED both. gameDns=$($ls.Message.payload.gameDns) ws=$($ls.Message.payload.wsPort)"

    $clients+=Start-Client $ls.Message.payload "med-leader"
    $clients+=Start-Client $gs.Message.payload "med-guest"
    Write-Host "launched clients pids=$($clients.Process.Id -join ',')"

    # wait for load + char-select(20s) + spawn-select(10s)
    Start-Sleep 75
    foreach($cl in $clients){ $cl.Wid=Find-Wid $cl.Process.Id; Write-Host "$($cl.Label) pid=$($cl.Process.Id) wid=$($cl.Wid)" }

    # capture burst; clear augment panels (top card ~0.864,0.31) so combat view is visible
    for($round=1;$round -le 9;$round++){
        foreach($cl in $clients){
            if($cl.Wid -eq 0){ $cl.Wid=Find-Wid $cl.Process.Id }
            if($cl.Wid -ne 0 -and (Get-Process -Id $cl.Process.Id -EA SilentlyContinue)){
                if($round -le 3){ try{ ClickRel $cl.Process.Id $cl.Wid 0.864 0.31 }catch{}; Start-Sleep -Milliseconds 300; try{ ClickRel $cl.Process.Id $cl.Wid 0.864 0.31 }catch{} }
                $f=Shot $cl.Process.Id $cl.Wid ("$($cl.Label)-r$round")
                Write-Host "shot $($cl.Label) r$round = $f"
            }
        }
        Start-Sleep 9
    }
    Write-Host "CAPTURE DONE. Guest shots should show leader's charId-$LeaderCharId Medusa with nameplate 'med-leader'."
}
finally{
    if($leaderSock){ try{$leaderSock.Abort();$leaderSock.Dispose()}catch{} }
    if($guestSock){ try{$guestSock.Abort();$guestSock.Dispose()}catch{} }
    Start-Sleep 2
    foreach($cl in $clients){ try{ if(-not $cl.Process.HasExited){ ('{"pid":'+$cl.Process.Id+'}')|& $Cua call kill_app *>$null } }catch{} }
    if($server){ try{ if(-not $server.HasExited){ $server.Kill($true) } }catch{} }
}
