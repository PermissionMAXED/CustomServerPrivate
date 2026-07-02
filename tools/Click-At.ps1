param(
    [Parameter(Mandatory=$true)][int]$ProcId,
    [Parameter(Mandatory=$true)][int]$X,
    [Parameter(Mandatory=$true)][int]$Y,
    [int]$Clicks = 1,
    [int]$DelayMs = 50,
    [switch]$RelativeToWindow
)

Add-Type -AssemblyName System.Windows.Forms
Add-Type @"
using System;
using System.Runtime.InteropServices;
public class Ix {
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT { public int Left, Top, Right, Bottom; }
    [DllImport("user32.dll")] public static extern bool GetWindowRect(IntPtr h, out RECT r);
    [DllImport("user32.dll")] public static extern bool SetForegroundWindow(IntPtr h);
    [DllImport("user32.dll")] public static extern bool ShowWindow(IntPtr h, int n);
    [DllImport("user32.dll")] public static extern bool SetCursorPos(int x, int y);
    [DllImport("user32.dll")] public static extern void mouse_event(uint flags, uint dx, uint dy, uint data, UIntPtr extra);
    public const uint LEFTDOWN = 0x0002;
    public const uint LEFTUP = 0x0004;
}
"@

$p = Get-Process -Id $ProcId -ErrorAction Stop
$h = $p.MainWindowHandle
[Ix]::ShowWindow($h, 9) | Out-Null    # SW_RESTORE
[Ix]::SetForegroundWindow($h) | Out-Null
Start-Sleep -Milliseconds 200

$targetX = $X
$targetY = $Y
if ($RelativeToWindow) {
    $r = New-Object Ix+RECT
    [Ix]::GetWindowRect($h, [ref]$r) | Out-Null
    $targetX = $r.Left + $X
    $targetY = $r.Top + $Y
    Write-Host "Window @ ($($r.Left), $($r.Top)) - clicking ($targetX, $targetY) = relative ($X, $Y)"
} else {
    Write-Host "Clicking at absolute ($targetX, $targetY)"
}

[Ix]::SetCursorPos($targetX, $targetY) | Out-Null
Start-Sleep -Milliseconds 100

for ($i = 0; $i -lt $Clicks; $i++) {
    [Ix]::mouse_event([Ix]::LEFTDOWN, 0, 0, 0, [UIntPtr]::Zero)
    Start-Sleep -Milliseconds 30
    [Ix]::mouse_event([Ix]::LEFTUP, 0, 0, 0, [UIntPtr]::Zero)
    if ($i -lt $Clicks - 1) { Start-Sleep -Milliseconds $DelayMs }
}
Write-Host "Clicked $Clicks time(s)"
