param(
    [Parameter(Mandatory=$true)][int]$ProcId,
    [Parameter(Mandatory=$true)][long]$Hwnd,
    [Parameter(Mandatory=$true)][string]$LogPath,
    [Parameter(Mandatory=$true)][string]$OutputDirectory,
    [int]$TimeoutSeconds = 240,
    [int]$OpenX = 1450,
    [int]$OpenY = 650,
    [int]$MedusaX = 1630,
    [int]$MedusaY = 1085,
    [int]$LockInX = 1275,
    [int]$LockInY = 755
)

$ErrorActionPreference = "Stop"
Add-Type -AssemblyName System.Drawing
Add-Type @"
using System;
using System.Runtime.InteropServices;
public static class PrematchMedusaClick {
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT { public int Left, Top, Right, Bottom; }
    [DllImport("user32.dll")] public static extern bool GetWindowRect(IntPtr h, out RECT r);
    [DllImport("user32.dll")] public static extern bool PrintWindow(IntPtr h, IntPtr hdc, uint flags);
    [DllImport("user32.dll")] public static extern bool ShowWindow(IntPtr h, int n);
    [DllImport("user32.dll")] public static extern bool SetForegroundWindow(IntPtr h);
    [DllImport("user32.dll")] public static extern bool SetCursorPos(int x, int y);
    [DllImport("user32.dll")] public static extern void mouse_event(uint flags, uint dx, uint dy, uint data, UIntPtr extra);
    public const uint LeftDown = 0x0002;
    public const uint LeftUp = 0x0004;
}
"@

New-Item -ItemType Directory -Force -Path $OutputDirectory | Out-Null
$handle = [IntPtr]$Hwnd
$rect = New-Object PrematchMedusaClick+RECT
[PrematchMedusaClick]::GetWindowRect($handle, [ref]$rect) | Out-Null
$width = $rect.Right - $rect.Left
$height = $rect.Bottom - $rect.Top

function Capture-Window([string]$name) {
    $path = Join-Path $OutputDirectory $name
    $bitmap = [Drawing.Bitmap]::new($width, $height)
    $graphics = [Drawing.Graphics]::FromImage($bitmap)
    $dc = $graphics.GetHdc()
    [PrematchMedusaClick]::PrintWindow($handle, $dc, 2) | Out-Null
    $graphics.ReleaseHdc($dc)
    $graphics.Dispose()
    $bitmap.Save($path, [Drawing.Imaging.ImageFormat]::Png)
    $bitmap.Dispose()
    return $path
}

function Click-Window([int]$x, [int]$y, [string]$label) {
    [PrematchMedusaClick]::ShowWindow($handle, 9) | Out-Null
    [PrematchMedusaClick]::SetForegroundWindow($handle) | Out-Null
    Start-Sleep -Milliseconds 80
    [PrematchMedusaClick]::SetCursorPos($rect.Left + $x, $rect.Top + $y) | Out-Null
    Start-Sleep -Milliseconds 70
    [PrematchMedusaClick]::mouse_event([PrematchMedusaClick]::LeftDown, 0, 0, 0, [UIntPtr]::Zero)
    Start-Sleep -Milliseconds 35
    [PrematchMedusaClick]::mouse_event([PrematchMedusaClick]::LeftUp, 0, 0, 0, [UIntPtr]::Zero)
    Add-Content -LiteralPath (Join-Path $OutputDirectory "actions.log") -Value ("{0:HH:mm:ss.fff} click {1} x={2} y={3}" -f (Get-Date), $label, $x, $y)
}

function Read-SharedText([string]$path) {
    $stream = [IO.File]::Open($path, [IO.FileMode]::Open, [IO.FileAccess]::Read, [IO.FileShare]::ReadWrite)
    try {
        $reader = [IO.StreamReader]::new($stream)
        try { return $reader.ReadToEnd() }
        finally { $reader.Dispose() }
    }
    finally {
        if ($stream) { $stream.Dispose() }
    }
}

$startTime = Get-Date
$initialLength = if (Test-Path -LiteralPath $LogPath) { (Get-Item -LiteralPath $LogPath).Length } else { 0L }
$deadline = $startTime.AddSeconds($TimeoutSeconds)
$triggered = $false
$triggerLine = ""
$triggerPattern = "View_PreMatch_CharSelect populated|View_PreMatch_CharSelect displayed Medusa|View_PreMatch_CharSelect\.Initialize|UIPreMatch\.PopulatePreMatchUI|CmdTrySelectCharacter"

while ((Get-Date) -lt $deadline) {
    if (-not (Get-Process -Id $ProcId -ErrorAction SilentlyContinue)) {
        throw "Process $ProcId exited before prematch selection."
    }

    if (Test-Path -LiteralPath $LogPath) {
        $text = Read-SharedText $LogPath
        if ($text.Length -gt $initialLength) {
            $tail = $text.Substring([int][Math]::Min($initialLength, $text.Length))
            $match = [regex]::Match($tail, $triggerPattern, [Text.RegularExpressions.RegexOptions]::IgnoreCase)
            if ($match.Success) {
                $triggered = $true
                $triggerLine = $match.Value
                break
            }
        }
    }

    Start-Sleep -Milliseconds 120
}

if (-not $triggered) {
    Capture-Window "timeout.png" | Out-Null
    throw "Prematch character select trigger not seen within $TimeoutSeconds seconds."
}

Add-Content -LiteralPath (Join-Path $OutputDirectory "actions.log") -Value ("{0:HH:mm:ss.fff} trigger {1}" -f (Get-Date), $triggerLine)
Start-Sleep -Milliseconds 250
Capture-Window "trigger.png" | Out-Null

Click-Window $LockInX $LockInY "lock-in-visible-1"
Start-Sleep -Milliseconds 280
Capture-Window "after-lock-in-visible-1.png" | Out-Null

Click-Window $LockInX $LockInY "lock-in-visible-2"
Start-Sleep -Milliseconds 500
Capture-Window "after-lock-in-visible-2.png" | Out-Null

Click-Window $OpenX $OpenY "open-select"
Start-Sleep -Milliseconds 220
Capture-Window "after-open.png" | Out-Null

Click-Window $MedusaX $MedusaY "medusa-tile-1"
Start-Sleep -Milliseconds 260
Capture-Window "after-medusa-1.png" | Out-Null

Click-Window $MedusaX $MedusaY "medusa-tile-2"
Start-Sleep -Milliseconds 650
Capture-Window "after-medusa-2.png" | Out-Null

Click-Window $LockInX $LockInY "lock-in"
Start-Sleep -Milliseconds 500
Capture-Window "after-lock-in.png" | Out-Null

Write-Host "Triggered on '$triggerLine', clicked Medusa, and clicked Lock In. Output: $OutputDirectory"
