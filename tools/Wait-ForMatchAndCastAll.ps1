param(
    [Parameter(Mandatory=$true)][int]$ProcId,
    [Parameter(Mandatory=$true)][long]$Hwnd,
    [Parameter(Mandatory=$true)][string]$OutputDirectory,
    [int]$TimeoutSeconds = 180,
    [int]$CaptureDelayMs = 110
)

Add-Type -AssemblyName System.Drawing
Add-Type @"
using System;
using System.Runtime.InteropServices;
public static class MedusaPhysicalTest {
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT { public int Left, Top, Right, Bottom; }
    [DllImport("user32.dll")] public static extern bool GetWindowRect(IntPtr h, out RECT r);
    [DllImport("user32.dll")] public static extern bool PrintWindow(IntPtr h, IntPtr hdc, uint flags);
    [DllImport("user32.dll")] public static extern bool SetForegroundWindow(IntPtr h);
    [DllImport("user32.dll")] public static extern bool ShowWindow(IntPtr h, int n);
    [DllImport("user32.dll")] public static extern bool SetCursorPos(int x, int y);
    [DllImport("user32.dll")] public static extern void mouse_event(uint flags, uint dx, uint dy, uint data, UIntPtr extra);
    [DllImport("user32.dll")] public static extern void keybd_event(byte vk, byte scan, uint flags, UIntPtr extra);
    public const uint LeftDown = 0x0002;
    public const uint LeftUp = 0x0004;
    public const uint RightDown = 0x0008;
    public const uint RightUp = 0x0010;
    public const uint KeyUp = 0x0002;
}
"@

$handle = [IntPtr]$Hwnd
$rect = New-Object MedusaPhysicalTest+RECT
[MedusaPhysicalTest]::GetWindowRect($handle, [ref]$rect) | Out-Null
$width = $rect.Right - $rect.Left
$height = $rect.Bottom - $rect.Top
New-Item -ItemType Directory -Path $OutputDirectory -Force | Out-Null

function Capture-Window([string]$path) {
    $bitmap = [Drawing.Bitmap]::new($width, $height)
    $graphics = [Drawing.Graphics]::FromImage($bitmap)
    $dc = $graphics.GetHdc()
    [MedusaPhysicalTest]::PrintWindow($handle, $dc, 2) | Out-Null
    $graphics.ReleaseHdc($dc)
    $graphics.Dispose()
    $bitmap.Save($path, [Drawing.Imaging.ImageFormat]::Png)
    return $bitmap
}

function Focus-Game {
    [MedusaPhysicalTest]::ShowWindow($handle, 9) | Out-Null
    [MedusaPhysicalTest]::SetForegroundWindow($handle) | Out-Null
    [MedusaPhysicalTest]::SetCursorPos($rect.Left + 500, $rect.Top + 10) | Out-Null
    [MedusaPhysicalTest]::mouse_event([MedusaPhysicalTest]::LeftDown, 0, 0, 0, [UIntPtr]::Zero)
    [MedusaPhysicalTest]::mouse_event([MedusaPhysicalTest]::LeftUp, 0, 0, 0, [UIntPtr]::Zero)
    Start-Sleep -Milliseconds 140
}

function Capture-AfterInput([string]$name) {
    Start-Sleep -Milliseconds $CaptureDelayMs
    $bitmap = Capture-Window (Join-Path $OutputDirectory "$name.png")
    $bitmap.Dispose()
}

function Send-Mouse([bool]$right) {
    [MedusaPhysicalTest]::SetCursorPos($rect.Left + 1370, $rect.Top + 440) | Out-Null
    if ($right) {
        [MedusaPhysicalTest]::mouse_event([MedusaPhysicalTest]::RightDown, 0, 0, 0, [UIntPtr]::Zero)
        [MedusaPhysicalTest]::mouse_event([MedusaPhysicalTest]::RightUp, 0, 0, 0, [UIntPtr]::Zero)
    } else {
        [MedusaPhysicalTest]::mouse_event([MedusaPhysicalTest]::LeftDown, 0, 0, 0, [UIntPtr]::Zero)
        [MedusaPhysicalTest]::mouse_event([MedusaPhysicalTest]::LeftUp, 0, 0, 0, [UIntPtr]::Zero)
    }
}

function Send-Key([byte]$vk) {
    [MedusaPhysicalTest]::keybd_event($vk, 0, 0, [UIntPtr]::Zero)
    Start-Sleep -Milliseconds 45
    [MedusaPhysicalTest]::keybd_event($vk, 0, [MedusaPhysicalTest]::KeyUp, [UIntPtr]::Zero)
}

$deadline = (Get-Date).AddSeconds($TimeoutSeconds)
$detectedFrames = 0
while ((Get-Date) -lt $deadline) {
    if (-not (Get-Process -Id $ProcId -ErrorAction SilentlyContinue)) {
        throw "Process $ProcId exited before gameplay was detected."
    }
    $bitmap = Capture-Window (Join-Path $OutputDirectory 'watch-current.png')
    $greenSamples = 0
    for ($y = [Math]::Max(0, $height - 165); $y -lt [Math]::Min($height, $height - 55); $y += 5) {
        for ($x = 780; $x -lt [Math]::Min($width, 1160); $x += 5) {
            $color = $bitmap.GetPixel($x, $y)
            if ($color.G -gt 170 -and $color.G -gt ($color.R + 55) -and $color.G -gt ($color.B + 25)) {
                $greenSamples++
            }
        }
    }
    $bitmap.Dispose()
    if ($greenSamples -ge 18) {
        $detectedFrames++
        if ($detectedFrames -ge 2) {
            break
        }
    } else {
        $detectedFrames = 0
    }
    Start-Sleep -Milliseconds 250
}
if ($detectedFrames -lt 2) {
    throw "Gameplay HUD was not detected within $TimeoutSeconds seconds."
}

Focus-Game
$baseline = Capture-Window (Join-Path $OutputDirectory 'baseline.png')
$baseline.Dispose()

Send-Mouse $false
Capture-AfterInput 'slot0-110ms'
Start-Sleep -Milliseconds 650

Send-Mouse $true
Capture-AfterInput 'slot1-110ms'
Start-Sleep -Milliseconds 650

Send-Key 0x20
Capture-AfterInput 'slot2-110ms'
Start-Sleep -Milliseconds 650

Send-Key 0x45
Capture-AfterInput 'slot3-110ms'

Write-Host "Captured all four Medusa inputs in $OutputDirectory"
