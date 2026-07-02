param(
    [Parameter(Mandatory=$true)][int]$ProcId,
    [Parameter(Mandatory=$true)][int]$X,
    [Parameter(Mandatory=$true)][int]$Y
)

Add-Type @"
using System;
using System.Runtime.InteropServices;
public static class RightClickInput {
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT { public int Left, Top, Right, Bottom; }
    [DllImport("user32.dll")] public static extern bool GetWindowRect(IntPtr h, out RECT r);
    [DllImport("user32.dll")] public static extern bool SetForegroundWindow(IntPtr h);
    [DllImport("user32.dll")] public static extern bool ShowWindow(IntPtr h, int n);
    [DllImport("user32.dll")] public static extern bool SetCursorPos(int x, int y);
    [DllImport("user32.dll")] public static extern void mouse_event(uint flags, uint dx, uint dy, uint data, UIntPtr extra);
    public const uint LeftDown = 0x0002;
    public const uint LeftUp = 0x0004;
    public const uint RightDown = 0x0008;
    public const uint RightUp = 0x0010;
}
"@

$process = Get-Process -Id $ProcId -ErrorAction Stop
$handle = $process.MainWindowHandle
[RightClickInput]::ShowWindow($handle, 9) | Out-Null
[RightClickInput]::SetForegroundWindow($handle) | Out-Null
$rect = New-Object RightClickInput+RECT
[RightClickInput]::GetWindowRect($handle, [ref]$rect) | Out-Null
[RightClickInput]::SetCursorPos($rect.Left + 500, $rect.Top + 10) | Out-Null
[RightClickInput]::mouse_event([RightClickInput]::LeftDown, 0, 0, 0, [UIntPtr]::Zero)
[RightClickInput]::mouse_event([RightClickInput]::LeftUp, 0, 0, 0, [UIntPtr]::Zero)
Start-Sleep -Milliseconds 180
[RightClickInput]::SetCursorPos($X, $Y) | Out-Null
[RightClickInput]::mouse_event([RightClickInput]::RightDown, 0, 0, 0, [UIntPtr]::Zero)
[RightClickInput]::mouse_event([RightClickInput]::RightUp, 0, 0, 0, [UIntPtr]::Zero)
Write-Host "Right-clicked at absolute ($X, $Y)"
