param([string]$Key = "ENTER")
Add-Type @"
using System;
using System.Text;
using System.Runtime.InteropServices;
public class K {
 [DllImport("user32.dll")] public static extern IntPtr FindWindow(string c, string n);
 [DllImport("user32.dll")] public static extern bool SetForegroundWindow(IntPtr h);
 [DllImport("user32.dll")] public static extern bool ShowWindow(IntPtr h, int n);
 [DllImport("user32.dll")] public static extern void keybd_event(byte vk, byte scan, uint flags, int extra);
}
"@
$h = [K]::FindWindow($null, "BAPBAP")
if ($h -ne [IntPtr]::Zero) { [K]::ShowWindow($h, 9) | Out-Null; [K]::SetForegroundWindow($h) | Out-Null }
Start-Sleep -Milliseconds 500
$vk = switch ($Key.ToUpper()) { "ENTER" {0x0D} "SPACE" {0x20} "TAB" {0x09} "P" {0x50} "R" {0x52} default {0x0D} }
[K]::keybd_event([byte]$vk, 0, 0, 0)
Start-Sleep -Milliseconds 60
[K]::keybd_event([byte]$vk, 0, 2, 0)
Write-Host "sent key $Key (vk=$vk)"
