param(
    [Parameter(Mandatory=$true)][int]$ProcId,
    [Parameter(Mandatory=$true)][string]$Key,
    [int]$HoldMs = 45
)

Add-Type @"
using System;
using System.Runtime.InteropServices;
public static class PhysicalKeyInput {
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT { public int Left, Top, Right, Bottom; }
    [DllImport("user32.dll")] public static extern bool GetWindowRect(IntPtr h, out RECT r);
    [DllImport("user32.dll")] public static extern bool SetForegroundWindow(IntPtr h);
    [DllImport("user32.dll")] public static extern bool ShowWindow(IntPtr h, int n);
    [DllImport("user32.dll")] public static extern bool SetCursorPos(int x, int y);
    [DllImport("user32.dll")] public static extern void mouse_event(uint flags, uint dx, uint dy, uint data, UIntPtr extra);
    [DllImport("user32.dll")] public static extern void keybd_event(byte vk, byte scan, uint flags, UIntPtr extra);
    public const uint LeftDown = 0x0002;
    public const uint LeftUp = 0x0004;
    public const uint KeyUp = 0x0002;
}
"@

$vkMap = @{
    'SPACE' = 0x20
    'W' = 0x57
    'A' = 0x41
    'S' = 0x53
    'D' = 0x44
    'Q' = 0x51
    'E' = 0x45
    'R' = 0x52
    'F' = 0x46
    '1' = 0x31
    '2' = 0x32
    '3' = 0x33
    '4' = 0x34
}
$normalized = $Key.Trim().ToUpperInvariant()
if (-not $vkMap.ContainsKey($normalized)) {
    throw "Unsupported key '$Key'. Supported: $($vkMap.Keys -join ', ')"
}

$process = Get-Process -Id $ProcId -ErrorAction Stop
$handle = $process.MainWindowHandle
[PhysicalKeyInput]::ShowWindow($handle, 9) | Out-Null
[PhysicalKeyInput]::SetForegroundWindow($handle) | Out-Null
$rect = New-Object PhysicalKeyInput+RECT
[PhysicalKeyInput]::GetWindowRect($handle, [ref]$rect) | Out-Null
[PhysicalKeyInput]::SetCursorPos($rect.Left + 500, $rect.Top + 10) | Out-Null
[PhysicalKeyInput]::mouse_event([PhysicalKeyInput]::LeftDown, 0, 0, 0, [UIntPtr]::Zero)
[PhysicalKeyInput]::mouse_event([PhysicalKeyInput]::LeftUp, 0, 0, 0, [UIntPtr]::Zero)
Start-Sleep -Milliseconds 180
$vk = [byte]$vkMap[$normalized]
[PhysicalKeyInput]::keybd_event($vk, 0, 0, [UIntPtr]::Zero)
Start-Sleep -Milliseconds ([Math]::Max(1, $HoldMs))
[PhysicalKeyInput]::keybd_event($vk, 0, [PhysicalKeyInput]::KeyUp, [UIntPtr]::Zero)
Write-Host "Sent physical key $normalized to PID $ProcId holdMs=$HoldMs"
