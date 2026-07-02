param(
    [Parameter(Mandatory=$true)][int]$ProcId,
    [Parameter(Mandatory=$true)][string]$Path,
    [int]$Width = 120
)

Add-Type @"
using System;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
public static class ConsoleBufferCapture {
    [StructLayout(LayoutKind.Sequential)]
    public struct COORD {
        public short X, Y;
        public COORD(short x, short y) { X = x; Y = y; }
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct SMALL_RECT { public short Left, Top, Right, Bottom; }
    [StructLayout(LayoutKind.Sequential)]
    public struct INFO {
        public COORD dwSize, dwCursorPosition;
        public short wAttributes;
        public SMALL_RECT srWindow;
        public COORD dwMaximumWindowSize;
    }
    [DllImport("kernel32.dll", SetLastError=true)] public static extern bool AttachConsole(uint pid);
    [DllImport("kernel32.dll")] public static extern bool FreeConsole();
    [DllImport("kernel32.dll", CharSet=CharSet.Unicode)] public static extern SafeFileHandle CreateFile(string n, uint a, uint s, IntPtr p, uint c, uint f, IntPtr t);
    [DllImport("kernel32.dll")] public static extern bool GetConsoleScreenBufferInfo(SafeFileHandle h, out INFO i);
    [DllImport("kernel32.dll", CharSet=CharSet.Unicode)] public static extern bool ReadConsoleOutputCharacter(SafeFileHandle h, StringBuilder b, uint l, COORD c, out uint r);
}
"@

[ConsoleBufferCapture]::FreeConsole() | Out-Null
if (-not [ConsoleBufferCapture]::AttachConsole([uint32]$ProcId)) {
    throw "Could not attach to console for PID $ProcId."
}
$handle = [ConsoleBufferCapture]::CreateFile('CONOUT$', [uint32]2147483648, 3, [IntPtr]::Zero, 3, 0, [IntPtr]::Zero)
try {
    $info = New-Object ConsoleBufferCapture+INFO
    if (-not [ConsoleBufferCapture]::GetConsoleScreenBufferInfo($handle, [ref]$info)) {
        throw 'GetConsoleScreenBufferInfo failed.'
    }
    $count = [uint32]($info.dwSize.X * $info.dwSize.Y)
    $buffer = [Text.StringBuilder]::new([int]$count)
    [uint32]$read = 0
    if (-not [ConsoleBufferCapture]::ReadConsoleOutputCharacter($handle, $buffer, $count, [ConsoleBufferCapture+COORD]::new(0, 0), [ref]$read)) {
        throw 'ReadConsoleOutputCharacter failed.'
    }
    $raw = $buffer.ToString()
    $lines = for ($offset = 0; $offset -lt $raw.Length; $offset += $Width) {
        $raw.Substring($offset, [Math]::Min($Width, $raw.Length - $offset)).TrimEnd()
    }
    $directory = Split-Path -Parent $Path
    if ($directory) {
        New-Item -ItemType Directory -Path $directory -Force | Out-Null
    }
    [IO.File]::WriteAllLines($Path, $lines, [Text.Encoding]::UTF8)
    Write-Host "Captured console buffer to $Path"
}
finally {
    $handle.Dispose()
    [ConsoleBufferCapture]::FreeConsole() | Out-Null
}
