param(
    [string]$BaseUrl = "http://ark.atomi23.de:5055",
    [string]$GameHost = "ark.atomi23.de",
    [int]$CharacterId = 15,
    [int]$MapId = 1,
    [int]$BotCount = 0,
    [switch]$KillFirst
)

$ErrorActionPreference = "Stop"

$Root = Resolve-Path (Join-Path $PSScriptRoot "..")
$GameDir = Join-Path $Root "Spiel\Battleroyalebuild"
$GameExe = Join-Path $GameDir "bapbap.exe"
$LogDir = Join-Path $Root "logs"
$RunStamp = Get-Date -Format "yyyyMMdd-HHmmss"
$RunName = "custom-medusa-vfx-v1708-$RunStamp"
$RunDir = Join-Path $LogDir $RunName
$RunLog = Join-Path $RunDir "run.log"
$ClientOut = Join-Path $RunDir "client.log"
$ClientErr = Join-Path $RunDir "client.err.log"
$ServerUri = [Uri]$BaseUrl
$ServerHost = $ServerUri.Host
$ServerPort = $ServerUri.Port
if ($ServerPort -le 0) {
    $ServerPort = if ($BaseUrl.StartsWith("https:", [StringComparison]::OrdinalIgnoreCase)) { 443 } else { 80 }
}

New-Item -ItemType Directory -Force -Path $RunDir | Out-Null
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

function Send-WsJson([System.Net.WebSockets.ClientWebSocket]$Socket, [object]$Object) {
    $json = $Object | ConvertTo-Json -Compress -Depth 20
    $bytes = [System.Text.Encoding]::UTF8.GetBytes($json)
    $send = $Socket.SendAsync([ArraySegment[byte]]::new($bytes), "Text", $true, [Threading.CancellationToken]::None)
    if (-not $send.Wait(10000)) { throw "WebSocket send timeout: $json" }
    if ($send.IsFaulted) { throw $send.Exception }
}

function Receive-WsJson([System.Net.WebSockets.ClientWebSocket]$Socket, [int]$TimeoutMs) {
    $buffer = New-Object byte[] 65536
    $stream = [System.IO.MemoryStream]::new()
    try {
        do {
            $task = $Socket.ReceiveAsync([ArraySegment[byte]]::new($buffer), [Threading.CancellationToken]::None)
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

function Wait-Event([System.Net.WebSockets.ClientWebSocket]$Socket, [string[]]$Events, [int]$TimeoutMs, [int]$MaxMessages = 80) {
    for ($i = 0; $i -lt $MaxMessages; $i++) {
        $message = Receive-WsJson -Socket $Socket -TimeoutMs $TimeoutMs
        Log "WS -> $($message.event)"
        if ($Events -contains $message.event) {
            return $message
        }
    }
    throw "Did not receive any of: $($Events -join ', ')"
}

function Wait-MainWindowHandle([int]$ProcessId, [int]$TimeoutSeconds = 60) {
    $deadline = (Get-Date).AddSeconds($TimeoutSeconds)
    while ((Get-Date) -lt $deadline) {
        $proc = Get-Process -Id $ProcessId -ErrorAction SilentlyContinue
        if (-not $proc) { throw "Process $ProcessId exited while waiting for a window handle." }
        if ($proc.MainWindowHandle -ne [IntPtr]::Zero) {
            return $proc.MainWindowHandle
        }
        Start-Sleep -Milliseconds 250
    }
    throw "Timed out waiting for main window handle."
}

function Take-Shot([int]$ProcessId, [string]$Name) {
    $path = Join-Path $RunDir "$Name.png"
    try {
        $oldErrorActionPreference = $ErrorActionPreference
        $ErrorActionPreference = "Continue"
        & powershell -ExecutionPolicy Bypass -File (Join-Path $Root "tools\Take-WindowShot.ps1") -ProcId $ProcessId -Path $path 2>&1 |
            ForEach-Object { Log "  shot: $_" }
    }
    finally {
        $ErrorActionPreference = $oldErrorActionPreference
    }
    $size = if (Test-Path -LiteralPath $path) { (Get-Item -LiteralPath $path).Length } else { 0 }
    Log "Screenshot $Name path=$path size=$size"
}

function Send-KeysToClient([int]$ProcessId, [string]$Keys, [string]$Name, [int]$DelayMs = 180) {
    Log "Input keys='$Keys' name=$Name"
    & powershell -ExecutionPolicy Bypass -File (Join-Path $Root "tools\Send-Keys.ps1") -ProcId $ProcessId -Keys $Keys 2>&1 |
        ForEach-Object { Log "  input: $_" }
    Start-Sleep -Milliseconds $DelayMs
    Take-Shot -ProcessId $ProcessId -Name $Name
}

function Click-Client([int]$ProcessId, [string]$Name, [switch]$Right, [int]$DelayMs = 180) {
    $script = if ($Right) { "tools\Right-Click-At.ps1" } else { "tools\Click-At.ps1" }
    $button = if ($Right) { "right" } else { "left" }
    Log "Input $button-click name=$Name"
    if ($Right) {
        & powershell -ExecutionPolicy Bypass -File (Join-Path $Root $script) -ProcId $ProcessId -X 2140 -Y 520 2>&1 |
            ForEach-Object { Log "  input: $_" }
    }
    else {
        & powershell -ExecutionPolicy Bypass -File (Join-Path $Root $script) -ProcId $ProcessId -X 2140 -Y 520 -RelativeToWindow 2>&1 |
            ForEach-Object { Log "  input: $_" }
    }
    Start-Sleep -Milliseconds $DelayMs
    Take-Shot -ProcessId $ProcessId -Name $Name
}

function Start-VisibleClient([object]$Payload, [string]$AccountId, [string]$Username) {
    $args = @(
        "--melonloader.agfoffline",
        "--melonloader.captureplayerlogs",
        "--bapcustom-use-proxy=false",
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
    $oldMedusaAutoSelect = [Environment]::GetEnvironmentVariable("BAPBAP_MEDUSA_AUTOSELECT", "Process")
    try {
        [Environment]::SetEnvironmentVariable("BAPBAP_MEDUSA_AUTOSELECT", "1", "Process")
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

if ($KillFirst) {
    Log "Killing existing bapbap processes"
    Get-Process bapbap -ErrorAction SilentlyContinue | Stop-Process -Force -ErrorAction SilentlyContinue
    Start-Sleep -Seconds 2
}

if (-not (Test-Path -LiteralPath $GameExe)) { throw "Game exe not found: $GameExe" }

$account = "codex-custom-vfx-$RunStamp"
$username = "CodexVfx"
$lobbyId = "V" + (Get-Random -Minimum 10000 -Maximum 99999)
$headers = @{ "X-BAP-Admin-Token" = "" }
$client = $null
$socket = $null

try {
    $health = Invoke-RestMethod -Uri "$BaseUrl/health" -TimeoutSec 10
    Log "Health release=$($health.release) medusaDll=$($health.medusa.medusaDllSha256)"

    try {
        $adminBody = @{ command = "grant-admin"; accountId = $account } | ConvertTo-Json -Compress
        $admin = Invoke-RestMethod -Uri "$BaseUrl/admin/commands" -Method POST -Headers $headers -ContentType "application/json" -Body $adminBody -TimeoutSec 10
        Log "Admin grant: $($admin.message)"
    }
    catch {
        Log "WARN admin grant failed: $_"
    }

    $socket = New-Ws -AccountId $account -Username $username
    Wait-Event -Socket $socket -Events @("SOCKET_READY") -TimeoutMs 30000 | Out-Null

    Log "JOIN_LOBBY lobby=$lobbyId charId=$CharacterId"
    Send-WsJson -Socket $socket -Object @{ event = "JOIN_LOBBY"; payload = @{ lobbyId = $lobbyId; charId = $CharacterId; regionId = "custom"; gameModeId = 1; isAutoFill = $true } }
    Wait-Event -Socket $socket -Events @("JOIN_LOBBY_SUCCESS") -TimeoutMs 30000 | Out-Null

    Log "UPDATE_CUSTOM_SETTINGS map=$MapId botCount=$BotCount"
    Send-WsJson -Socket $socket -Object @{ event = "UPDATE_CUSTOM_SETTINGS"; payload = @{ settings = @{ gamemode = 1; mapId = $MapId; teamSize = 1; maxTeams = 2; botCount = $BotCount; botDifficulty = 1 } } }
    Wait-Event -Socket $socket -Events @("UPDATE_CUSTOM_SETTINGS_SUCCESS") -TimeoutMs 30000 | Out-Null

    Log "START_CUSTOM_GAME forceStart=true"
    Send-WsJson -Socket $socket -Object @{ event = "START_CUSTOM_GAME"; payload = @{ forceStart = $true } }
    $started = Wait-Event -Socket $socket -Events @("GAME_STARTED", "START_CUSTOM_GAME_FAIL") -TimeoutMs 240000
    if ($started.event -eq "START_CUSTOM_GAME_FAIL") {
        throw "START_CUSTOM_GAME_FAIL payload=$($started.payload | ConvertTo-Json -Compress -Depth 12)"
    }
    Log "Game started payload=$($started.payload | ConvertTo-Json -Compress -Depth 12)"

    $client = Start-VisibleClient -Payload $started.payload -AccountId $account -Username $username
    $hwnd = Wait-MainWindowHandle -ProcessId $client.Id
    Log "Window handle=$($hwnd.ToInt64())"

    Start-Sleep -Seconds 12
    Take-Shot -ProcessId $client.Id -Name "t12-loading"
    Start-Sleep -Seconds 22
    Take-Shot -ProcessId $client.Id -Name "t34-before-augment"

    Send-KeysToClient -ProcessId $client.Id -Keys "{ENTER}" -Name "after-enter" -DelayMs 250
    Send-KeysToClient -ProcessId $client.Id -Keys "1" -Name "after-hotkey-1" -DelayMs 250
    Click-Client -ProcessId $client.Id -Name "after-augment-click" -DelayMs 250
    Start-Sleep -Seconds 32

    Take-Shot -ProcessId $client.Id -Name "baseline-before-casts"
    Send-KeysToClient -ProcessId $client.Id -Keys "ww" -Name "after-move" -DelayMs 250

    Click-Client -ProcessId $client.Id -Name "slot0-left-180ms" -DelayMs 180
    Start-Sleep -Milliseconds 850
    Take-Shot -ProcessId $client.Id -Name "slot0-left-1030ms"

    Click-Client -ProcessId $client.Id -Name "slot1-right-180ms" -Right -DelayMs 180
    Start-Sleep -Milliseconds 850
    Take-Shot -ProcessId $client.Id -Name "slot1-right-1030ms"

    Send-KeysToClient -ProcessId $client.Id -Keys " " -Name "slot2-space-180ms" -DelayMs 180
    Start-Sleep -Milliseconds 850
    Take-Shot -ProcessId $client.Id -Name "slot2-space-1030ms"

    Send-KeysToClient -ProcessId $client.Id -Keys "e" -Name "slot3-e-180ms" -DelayMs 180
    Start-Sleep -Milliseconds 850
    Take-Shot -ProcessId $client.Id -Name "slot3-e-1030ms"

    $meta = [pscustomobject]@{
        stamp = $RunStamp
        runDir = $RunDir
        account = $account
        username = $username
        lobbyId = $lobbyId
        pid = $client.Id
        payload = $started.payload
        release = $health.release
        medusaDllSha256 = $health.medusa.medusaDllSha256
    }
    $meta | ConvertTo-Json -Depth 12 | Set-Content -LiteralPath (Join-Path $RunDir "meta.json") -Encoding UTF8

    Log "Key Medusa lines"
    Select-String -LiteralPath $ClientOut -Pattern "native FX spawned|native cast FX emitted|runtime ability UI applied|localChar=15|visualActive=True|controller='Medusa'|suppressed .*Kitsu|Skinny|Invalid Layer Index|NullReferenceException|Curl error 7|Cannot connect|green primitive" -ErrorAction SilentlyContinue |
        Select-Object -Last 160 |
        ForEach-Object { Log "  $($_.Line)" }

    Log "END custom Medusa VFX test runDir=$RunDir"
}
finally {
    if ($socket) { $socket.Dispose() }
}
