param(
    [string]$BaseUrl = "http://ark.atomi23.de:5055",
    [string]$GameHost = "ark.atomi23.de",
    [int]$CharacterId = 15,
    [int]$ObserveSeconds = 105,
    [int]$MatchEventTimeoutMs = 300000,
    [switch]$UseLocalProxy,
    [switch]$ClickPrematchLockIn,
    [switch]$EnableMedusaAutoSelectForClient,
    [switch]$SkipInputs,
    [switch]$KillFirst
)

$ErrorActionPreference = "Stop"

$Root = Resolve-Path (Join-Path $PSScriptRoot "..")
$GameDir = Join-Path $Root "Spiel\Battleroyalebuild"
$GameExe = Join-Path $GameDir "bapbap.exe"
$LogDir = Join-Path $Root "logs"
$PlayerLog = "C:\Users\Administrator\AppData\LocalLow\gg.bapbap\BAPBAP\Player.log"
$RunStamp = Get-Date -Format "yyyyMMdd-HHmmss"
$ReleaseHint = "live-medusa-direct"
$RunLog = Join-Path $LogDir "$ReleaseHint-$RunStamp.log"
$ClientOut = Join-Path $LogDir "$ReleaseHint-client-$RunStamp.log"
$ClientErr = Join-Path $LogDir "$ReleaseHint-client-$RunStamp.err.log"
$ServerPort = ([Uri]$BaseUrl).Port
if ($ServerPort -le 0) {
    $ServerPort = if ($BaseUrl.StartsWith("https:", [StringComparison]::OrdinalIgnoreCase)) { 443 } else { 80 }
}

New-Item -ItemType Directory -Force -Path $LogDir | Out-Null

$watch = [System.Diagnostics.Stopwatch]::StartNew()

function Log([string]$Message) {
    $ts = Get-Date -Format "HH:mm:ss.fff"
    $elapsed = [Math]::Round($watch.Elapsed.TotalSeconds, 1)
    "$ts [t+${elapsed}s] $Message" | Tee-Object -FilePath $RunLog -Append | Write-Host
}

function New-Ws([string]$AccountId, [string]$Username) {
    $socket = [System.Net.WebSockets.ClientWebSocket]::new()
    $wsUrl = $BaseUrl -replace '^http:', 'ws:' -replace '^https:', 'wss:'
    $uri = [Uri]"$wsUrl/ws?accountId=$AccountId&username=$Username&discriminator=1761"
    $connect = $socket.ConnectAsync($uri, [Threading.CancellationToken]::None)
    if (-not $connect.Wait(10000)) { throw "WebSocket connect timeout: $uri" }
    if ($connect.IsFaulted) { throw $connect.Exception }
    return $socket
}

function Receive-WsJson([System.Net.WebSockets.ClientWebSocket]$Socket, [int]$TimeoutMs) {
    $buffer = New-Object byte[] 65536
    $stream = [System.IO.MemoryStream]::new()
    try {
        do {
            $segment = [ArraySegment[byte]]::new($buffer)
            $task = $Socket.ReceiveAsync($segment, [Threading.CancellationToken]::None)
            if (-not $task.Wait($TimeoutMs)) { throw "Timed out receiving websocket message after ${TimeoutMs}ms" }
            if ($task.IsFaulted) { throw $task.Exception }
            $result = $task.Result
            if ($result.MessageType -eq [System.Net.WebSockets.WebSocketMessageType]::Close) { throw "WebSocket closed." }
            $stream.Write($buffer, 0, $result.Count)
        } while (-not $result.EndOfMessage)
        return ([System.Text.Encoding]::UTF8.GetString($stream.ToArray()) | ConvertFrom-Json)
    }
    finally {
        $stream.Dispose()
    }
}

function Receive-UntilEvent(
    [System.Net.WebSockets.ClientWebSocket]$Socket,
    [string[]]$Events,
    [int]$TimeoutMs,
    [int]$MaxMessages = 120
) {
    for ($i = 0; $i -lt $MaxMessages; $i++) {
        $message = Receive-WsJson -Socket $Socket -TimeoutMs $TimeoutMs
        Log "WS -> $($message.event)"
        if ($Events -contains $message.event) {
            return $message
        }
    }
    throw "Did not receive any of: $($Events -join ', ')"
}

function Start-VisibleClient([object]$Payload, [string]$AccountId, [string]$Username) {
    $useProxyText = if ($UseLocalProxy) { "true" } else { "false" }
    $args = @(
        "--melonloader.agfoffline",
        "--melonloader.captureplayerlogs",
        "--bapcustom-use-proxy=$useProxyText",
        "--bapcustom-show-ui=false",
        "--bapcustom-host=$GameHost",
        "--bapcustom-server-port=$ServerPort",
        "--bapcustom-account-id=$AccountId",
        "--bapcustom-username=$Username",
        "--bapcustom-auto-select-augment",
        "--bapcustom-selected-char=$CharacterId",
        "--bapcustom-join-auth=$($Payload.gameAuthId)",
        "--bapcustom-join-host=$($Payload.gameDns)",
        "--bapcustom-join-ws=$($Payload.wsPort)",
        "--bapcustom-join-kcp=$($Payload.kcpPort)",
        "--bapcustom-join-tcp=$($Payload.tcpPort)"
    )

    Log "Starting visible client: $($args -join ' ')"
    if ($EnableMedusaAutoSelectForClient) {
        Log "Setting BAPBAP_MEDUSA_AUTOSELECT=1 for this test client process only"
    }
    $oldMedusaAutoSelect = [Environment]::GetEnvironmentVariable("BAPBAP_MEDUSA_AUTOSELECT", "Process")
    try {
        if ($EnableMedusaAutoSelectForClient) {
            [Environment]::SetEnvironmentVariable("BAPBAP_MEDUSA_AUTOSELECT", "1", "Process")
        }
        $proc = Start-Process -FilePath $GameExe `
            -WorkingDirectory $GameDir `
            -ArgumentList $args `
            -RedirectStandardOutput $ClientOut `
            -RedirectStandardError $ClientErr `
            -PassThru
    }
    finally {
        [Environment]::SetEnvironmentVariable("BAPBAP_MEDUSA_AUTOSELECT", $oldMedusaAutoSelect, "Process")
    }

    Log "Visible client started pid=$($proc.Id) stdout=$ClientOut stderr=$ClientErr"
    return $proc
}

function Wait-MainWindowHandle([int]$ProcessId, [int]$TimeoutSeconds = 45) {
    $deadline = (Get-Date).AddSeconds($TimeoutSeconds)
    while ((Get-Date) -lt $deadline) {
        $proc = Get-Process -Id $ProcessId -ErrorAction SilentlyContinue
        if (-not $proc) { throw "Process $ProcessId exited while waiting for a window handle." }
        if ($proc.MainWindowHandle -ne [IntPtr]::Zero) {
            return $proc.MainWindowHandle
        }
        Start-Sleep -Milliseconds 250
    }
    throw "Timed out waiting for a main window handle for process $ProcessId."
}

function Start-PrematchLockInAutomation([int]$ProcessId, [IntPtr]$WindowHandle) {
    $selectorScript = Join-Path $Root "tools\Select-MedusaOnPrematch.ps1"
    $selectorDir = Join-Path $LogDir "$ReleaseHint-prematch-click-$RunStamp"
    $selectorOut = Join-Path $LogDir "$ReleaseHint-prematch-click-$RunStamp.out.log"
    $selectorErr = Join-Path $LogDir "$ReleaseHint-prematch-click-$RunStamp.err.log"
    New-Item -ItemType Directory -Force -Path $selectorDir | Out-Null

    $selectorArgs = @(
        "-ExecutionPolicy", "Bypass",
        "-File", $selectorScript,
        "-ProcId", "$ProcessId",
        "-Hwnd", "$($WindowHandle.ToInt64())",
        "-LogPath", $ClientOut,
        "-OutputDirectory", $selectorDir,
        "-TimeoutSeconds", "180"
    )

    Log "Starting prematch Lock In automation: $($selectorArgs -join ' ')"
    $selector = Start-Process -FilePath "powershell" `
        -ArgumentList $selectorArgs `
        -RedirectStandardOutput $selectorOut `
        -RedirectStandardError $selectorErr `
        -PassThru

    Log "Prematch automation started pid=$($selector.Id) out=$selectorOut err=$selectorErr dir=$selectorDir"
    return $selector
}

function Take-Shot([int]$ProcessId, [int]$AtSeconds) {
    $shot = Join-Path $LogDir "$ReleaseHint-$RunStamp-t$AtSeconds.png"
    & powershell -ExecutionPolicy Bypass -File (Join-Path $Root "tools\Take-WindowShot.ps1") -ProcId $ProcessId -Path $shot 2>&1 | Out-Null
    $size = 0
    if (Test-Path -LiteralPath $shot) { $size = (Get-Item -LiteralPath $shot).Length }
    Log "Screenshot t=$AtSeconds path=$shot size=$size"
}

function Send-ClientKeys([int]$ProcessId, [string]$Keys, [string]$Reason, [int]$AtSeconds) {
    Log "Input t=$AtSeconds keys='$Keys' reason=$Reason"
    & powershell -ExecutionPolicy Bypass -File (Join-Path $Root "tools\Send-Keys.ps1") -ProcId $ProcessId -Keys $Keys 2>&1 |
        ForEach-Object { Log "  input: $_" }
}

function Click-Client([int]$ProcessId, [int]$X, [int]$Y, [string]$Reason, [int]$AtSeconds) {
    Log "Input t=$AtSeconds click=($X,$Y) reason=$Reason"
    & powershell -ExecutionPolicy Bypass -File (Join-Path $Root "tools\Click-At.ps1") -ProcId $ProcessId -X $X -Y $Y -RelativeToWindow 2>&1 |
        ForEach-Object { Log "  input: $_" }
}

function Log-KeyLines {
    $latestMelon = Get-ChildItem -LiteralPath (Join-Path $GameDir "MelonLoader\Logs") -Filter "*.log" -ErrorAction SilentlyContinue |
        Sort-Object LastWriteTime -Descending |
        Select-Object -First 1

    $sources = @()
    if (Test-Path -LiteralPath $ClientOut) { $sources += $ClientOut }
    if (Test-Path -LiteralPath $PlayerLog) { $sources += $PlayerLog }
    if ($latestMelon) { $sources += $latestMelon.FullName }

    Log "Key log scan sources: $($sources -join ' | ')"
    foreach ($source in $sources) {
        Log "Key lines from $source"
        Get-Content -LiteralPath $source -ErrorAction SilentlyContinue |
            Where-Object {
                $_ -match 'BAP Custom Server v|Loaded \(v|Rewrote UnityWebRequest|Rewrote BAPBAP\.Network\.HttpClient|Patched NetworkConfig\.ClientConfig|ApiHost:|Curl error 7|Cannot connect to destination host|AugmentFix|CharacterSelectPage|Char_Medusa|MedusaBase|Medusa_Material_Native|runtime ability UI applied|native cast FX emitted|live local diag ready|visual layer sync'
            } |
            Select-Object -Last 80 |
            ForEach-Object { Log "  $_" }
    }
}

if ($KillFirst) {
    Log "Killing existing bapbap processes"
    Get-Process bapbap -ErrorAction SilentlyContinue | Stop-Process -Force -ErrorAction SilentlyContinue
    Start-Sleep -Seconds 2
}

if (-not (Test-Path -LiteralPath $GameExe)) { throw "Game exe not found: $GameExe" }
if (Test-Path -LiteralPath $PlayerLog) { Remove-Item -LiteralPath $PlayerLog -Force -ErrorAction SilentlyContinue }

$account = "codex-live-v177-$RunStamp"
$username = "CodexLiveV177"
$client = $null
$ws = $null
$prematchAutomation = $null

try {
    Log "START live Medusa queue direct test account=$account charId=$CharacterId proxy=$($UseLocalProxy.IsPresent)"
    $health = Invoke-RestMethod -Uri "$BaseUrl/health" -TimeoutSec 10
    Log "Health release=$($health.release) medusaDll=$($health.medusa.medusaDllSha256) medusaBundle=$($health.medusa.medusaBundleSha256)"

    $ws = New-Ws -AccountId $account -Username $username
    Receive-UntilEvent -Socket $ws -Events @("SOCKET_READY") -TimeoutMs 30000 | Out-Null

    $headers = @{
        "X-BAP-AccountId" = $account
        "X-BAP-Username" = $username
        "X-BAP-Discriminator" = "1761"
    }
    $joinBody = @{ charId = $CharacterId } | ConvertTo-Json -Compress
    $join = Invoke-RestMethod -Uri "$BaseUrl/api/queue/join" -Method POST -Headers $headers -ContentType "application/json" -Body $joinBody -TimeoutSec 15
    Log "Queue join ok=$($join.ok) position=$($join.position) remaining=$($join.secondsRemaining)"

    $matched = Receive-UntilEvent -Socket $ws -Events @("QUEUE_MATCHED") -TimeoutMs $MatchEventTimeoutMs
    Log "Queue matched payload=$($matched.payload | ConvertTo-Json -Compress -Depth 12)"

    $started = Receive-UntilEvent -Socket $ws -Events @("GAME_STARTED") -TimeoutMs $MatchEventTimeoutMs
    Log "Game started payload=$($started.payload | ConvertTo-Json -Compress -Depth 12)"

    $client = Start-VisibleClient -Payload $started.payload -AccountId $account -Username $username

    $meta = [pscustomobject]@{
        stamp = $RunStamp
        account = $account
        username = $username
        pid = $client.Id
        runLog = $RunLog
        clientLog = $ClientOut
        clientErr = $ClientErr
        payload = $started.payload
        serverRelease = $health.release
        medusaServerDll = $health.medusa.medusaDllSha256
        useLocalProxy = $UseLocalProxy.IsPresent
    }
    $metaPath = Join-Path $LogDir "$ReleaseHint-$RunStamp.json"
    $meta | ConvertTo-Json -Depth 12 | Set-Content -LiteralPath $metaPath -Encoding UTF8
    Log "Meta written $metaPath"

    if ($ClickPrematchLockIn -and -not $SkipInputs) {
        $hwnd = Wait-MainWindowHandle -ProcessId $client.Id
        $prematchAutomation = Start-PrematchLockInAutomation -ProcessId $client.Id -WindowHandle $hwnd
    }

    $shotTimes = @(10, 25, 45, 75, 105) | Where-Object { $_ -le $ObserveSeconds }
    $events = @()
    foreach ($shotTime in $shotTimes) {
        $events += [pscustomobject]@{ At = $shotTime; Kind = "shot"; Value = ""; X = 0; Y = 0; Reason = "" }
    }

    if (-not $SkipInputs) {
        $events += [pscustomobject]@{ At = 52; Kind = "keys"; Value = "{ENTER}"; X = 0; Y = 0; Reason = "confirm first augment if focused" }
        $events += [pscustomobject]@{ At = 55; Kind = "keys"; Value = "1"; X = 0; Y = 0; Reason = "select first augment hotkey fallback" }
        $events += [pscustomobject]@{ At = 58; Kind = "click"; Value = ""; X = 1780; Y = 455; Reason = "click first augment card in right panel" }
        $events += [pscustomobject]@{ At = 61; Kind = "click"; Value = ""; X = 1780; Y = 455; Reason = "second first-card click if first was ignored" }
        $events += [pscustomobject]@{ At = 66; Kind = "keys"; Value = "ww"; X = 0; Y = 0; Reason = "wake movement/input after augment" }
        $events += [pscustomobject]@{ At = 70; Kind = "keys"; Value = "q"; X = 0; Y = 0; Reason = "cast ability Q" }
        $events += [pscustomobject]@{ At = 74; Kind = "keys"; Value = "e"; X = 0; Y = 0; Reason = "cast ability E" }
        $events += [pscustomobject]@{ At = 78; Kind = "keys"; Value = "r"; X = 0; Y = 0; Reason = "cast ability R" }
        $events += [pscustomobject]@{ At = 82; Kind = "keys"; Value = "f"; X = 0; Y = 0; Reason = "cast ability F" }
        $events += [pscustomobject]@{ At = 86; Kind = "keys"; Value = " "; X = 0; Y = 0; Reason = "cast ability Space" }
        $events += [pscustomobject]@{ At = 90; Kind = "click"; Value = ""; X = 650; Y = 380; Reason = "primary attack / aimed cast" }
        $events += [pscustomobject]@{ At = 98; Kind = "keys"; Value = "qe"; X = 0; Y = 0; Reason = "second ability pass" }
    }

    $events = $events | Where-Object { $_.At -le $ObserveSeconds } | Sort-Object At, Kind
    $previous = 0
    foreach ($event in $events) {
        $sleep = $event.At - $previous
        if ($sleep -gt 0) { Start-Sleep -Seconds $sleep }
        $previous = $event.At
        if ($client.HasExited) {
            Log "Client exited before t=$($event.At) event=$($event.Kind) exit=$($client.ExitCode)"
            break
        }

        switch ($event.Kind) {
            "shot" { Take-Shot -ProcessId $client.Id -AtSeconds $event.At }
            "keys" { Send-ClientKeys -ProcessId $client.Id -Keys $event.Value -Reason $event.Reason -AtSeconds $event.At }
            "click" { Click-Client -ProcessId $client.Id -X $event.X -Y $event.Y -Reason $event.Reason -AtSeconds $event.At }
        }
    }

    if ($ObserveSeconds -gt $previous) {
        Start-Sleep -Seconds ($ObserveSeconds - $previous)
    }

    Log-KeyLines
    if ($prematchAutomation) {
        if (-not $prematchAutomation.HasExited) {
            Log "Waiting for prematch automation pid=$($prematchAutomation.Id)"
            $prematchAutomation.WaitForExit(10000) | Out-Null
        }
        if ($prematchAutomation.HasExited) {
            Log "Prematch automation exit=$($prematchAutomation.ExitCode)"
        } else {
            Log "Prematch automation still running after wait; leaving it to finish/timeout."
        }
    }
    Log "END live Medusa queue direct test"
}
finally {
    if ($ws) { $ws.Dispose() }
}
