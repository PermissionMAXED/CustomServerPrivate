param([Parameter(Mandatory=$true)][long]$Hwnd)
# Minimal foreground-assist so cua-driver SendInput clicks land. cua still performs the clicks/screenshots.
Add-Type @"
using System;
using System.Runtime.InteropServices;
public static class FgForce {
  [DllImport("user32.dll")] public static extern IntPtr GetForegroundWindow();
  [DllImport("user32.dll")] public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint pid);
  [DllImport("kernel32.dll")] public static extern uint GetCurrentThreadId();
  [DllImport("user32.dll")] public static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);
  [DllImport("user32.dll")] public static extern bool SetForegroundWindow(IntPtr hWnd);
  [DllImport("user32.dll")] public static extern bool BringWindowToTop(IntPtr hWnd);
  [DllImport("user32.dll")] public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
  [DllImport("user32.dll")] public static extern bool SetWindowPos(IntPtr hWnd, IntPtr after, int x, int y, int cx, int cy, uint flags);
  public static void Force(IntPtr h) {
    uint tmp1; uint tmp2;
    uint fgTid = GetWindowThreadProcessId(GetForegroundWindow(), out tmp1);
    uint myTid = GetCurrentThreadId();
    uint tTid  = GetWindowThreadProcessId(h, out tmp2);
    AttachThreadInput(myTid, fgTid, true);
    AttachThreadInput(myTid, tTid, true);
    ShowWindow(h, 9);          // SW_RESTORE
    BringWindowToTop(h);
    SetForegroundWindow(h);
    SetWindowPos(h, (IntPtr)(-1), 0,0,0,0, 0x0001|0x0002); // HWND_TOPMOST, NOSIZE|NOMOVE
    SetWindowPos(h, (IntPtr)(-2), 0,0,0,0, 0x0001|0x0002); // HWND_NOTOPMOST
    AttachThreadInput(myTid, fgTid, false);
    AttachThreadInput(myTid, tTid, false);
  }
}
"@
[FgForce]::Force([IntPtr]$Hwnd)
Start-Sleep -Milliseconds 250
$fg = [FgForce]::GetForegroundWindow()
Write-Output ("foreground now: 0x{0:X} target: 0x{1:X} match={2}" -f $fg.ToInt64(), $Hwnd, ($fg.ToInt64() -eq $Hwnd))
