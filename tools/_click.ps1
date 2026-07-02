param(
    [int]$X,
    [int]$Y,
    [switch]$FocusGame,
    [switch]$MoveOnly
)
Add-Type @"
using System;
using System.Runtime.InteropServices;
public static class Win {
    [DllImport("user32.dll")] public static extern bool SetCursorPos(int x, int y);
    [DllImport("user32.dll")] public static extern void mouse_event(uint f, uint dx, uint dy, uint d, int e);
    [DllImport("user32.dll")] public static extern IntPtr FindWindow(string c, string n);
    [DllImport("user32.dll")] public static extern bool SetForegroundWindow(IntPtr h);
    [DllImport("user32.dll")] public static extern bool ShowWindow(IntPtr h, int n);
    [DllImport("user32.dll")] public static extern IntPtr GetForegroundWindow();
    public const uint LEFTDOWN = 0x0002, LEFTUP = 0x0004;
}
"@
if ($FocusGame) {
    # BAPBAP main window title
    foreach ($title in @("BAPBAP","bapbap")) {
        $h = [Win]::FindWindow($null, $title)
        if ($h -ne [IntPtr]::Zero) { [Win]::ShowWindow($h, 9) | Out-Null; [Win]::SetForegroundWindow($h) | Out-Null; Write-Host "focused '$title'"; break }
    }
    Start-Sleep -Milliseconds 400
}
if ($PSBoundParameters.ContainsKey('X')) {
    [Win]::SetCursorPos($X, $Y) | Out-Null
    Start-Sleep -Milliseconds 200
    if (-not $MoveOnly) {
        [Win]::mouse_event([Win]::LEFTDOWN, 0, 0, 0, 0)
        Start-Sleep -Milliseconds 60
        [Win]::mouse_event([Win]::LEFTUP, 0, 0, 0, 0)
        Write-Host "clicked $X,$Y"
    } else {
        Write-Host "moved $X,$Y"
    }
}
