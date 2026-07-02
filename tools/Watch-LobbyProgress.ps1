param(
    [int]$ServerPort = 5198,
    [int]$WatchSeconds = 90
)

$ErrorActionPreference = "Stop"
$Root = "C:\Users\Administrator\Downloads\CustomServer"
$ServerDll = Join-Path $Root "CustomMatchServer\bin\Release\net10.0\BapCustomServer.dll"
$LogDir = Join-Path $Root "tools\logs"
$ScreenshotPrefix = Join-Path $LogDir "watch-lobby"

Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName System.Drawing

function Take-Screenshot([string]$Path) {
    $screen = [System.Windows.Forms.Screen]::PrimaryScreen.Bounds
    $bmp = [System.Drawing.Bitmap]::new($screen.Width, $screen.Height)
    $g = [System.Drawing.Graphics]::FromImage($bmp)
    $g.CopyFromScreen($screen.Location, [System.Drawing.Point]::Empty, $screen.Size)
    $g.Dispose()
    $bmp.Save($Path, [System.Drawing.Imaging.ImageFormat]::Png)
    $bmp.Dispose()
}

function Get-WindowImage([System.Diagnostics.Process]$Process, [string]$Path) {
    if ($null -eq $Process -or $Process.HasExited -or [IntPtr]::Zero -eq $Process.MainWindowHandle) {
        return $false
    }
    Add-Type @"
using System;
using System.Runtime.InteropServices;
public class W {
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT { public int Left, Top, Right, Bottom; }
    [DllImport("user32.dll")] public static extern bool GetClientRect(IntPtr h, out RECT r);
    [DllImport("user32.dll")] public static extern bool GetWindowRect(IntPtr h, out RECT r);
    [DllImport("user32.dll")] public static extern bool PrintWindow(IntPtr h, IntPtr hdc, uint flags);
}
"@ -ErrorAction SilentlyContinue
    $rect = New-Object W+RECT
    if (-not [W]::GetWindowRect($Process.MainWindowHandle, [ref]$rect)) { return $false }
    $w = $rect.Right - $rect.Left
    $h = $rect.Bottom - $rect.Top
    if ($w -le 0 -or $h -le 0) { return $false }
    $bmp = [System.Drawing.Bitmap]::new($w, $h)
    $g = [System.Drawing.Graphics]::FromImage($bmp)
    $hdc = $g.GetHdc()
    [W]::PrintWindow($Process.MainWindowHandle, $hdc, 2) | Out-Null
    $g.ReleaseHdc($hdc)
    $g.Dispose()
    $bmp.Save($Path, [System.Drawing.Imaging.ImageFormat]::Png)
    $bmp.Dispose()
    return $true
}

# Start server
Write-Host "[step 1] Starting server on $ServerPort"
$serverPsi = [System.Diagnostics.ProcessStartInfo]::new()
$serverPsi.FileName = "dotnet"
$serverPsi.Arguments = "`"$ServerDll`""
$serverPsi.WorkingDirectory = $Root
$serverPsi.UseShellExecute = $false
$serverPsi.RedirectStandardOutput = $true
$serverPsi.RedirectStandardError = $true
$serverPsi.CreateNoWindow = $true
$serverPsi.EnvironmentVariables["ASPNETCORE_URLS"] = "http://127.0.0.1:$ServerPort"
$serverPsi.EnvironmentVariables["CustomServer__PublicBaseUrl"] = "http://127.0.0.1:$ServerPort"
# We DO NOT need a dedicated game-server for this test - we just want to see if the visible
# client gets past loading; the server-launched headless game-server confused things last time.
$serverPsi.EnvironmentVariables["CustomServer__LaunchGameServers"] = "false"
$serverPsi.EnvironmentVariables["CustomServer__RequireGameServerBootstrap"] = "false"
$server = [System.Diagnostics.Process]::Start($serverPsi)
Write-Host "  server PID $($server.Id)"

# Capture stdout/stderr to file for debugging
$serverLog = Join-Path $LogDir "watch-lobby-server.log"
"" | Set-Content $serverLog
$serverPid = $server.Id
Start-Job -Name "watch-server-stdout" -ScriptBlock { param($p, $f) Get-Content -Path $f -ErrorAction SilentlyContinue } -ArgumentList $serverPid, $serverLog | Out-Null
$null = Register-ObjectEvent -InputObject $server -EventName "OutputDataReceived" -Action { if ($EventArgs.Data) { Add-Content -Path $using:serverLog -Value $EventArgs.Data } }
$null = Register-ObjectEvent -InputObject $server -EventName "ErrorDataReceived" -Action { if ($EventArgs.Data) { Add-Content -Path $using:serverLog -Value "ERR: $($EventArgs.Data)" } }
$server.BeginOutputReadLine()
$server.BeginErrorReadLine()

# Wait health
$deadline = [DateTime]::UtcNow.AddSeconds(15)
do {
    try { $h = Invoke-RestMethod "http://127.0.0.1:$ServerPort/health"; if ($h.ok) { break } } catch { Start-Sleep -Milliseconds 250 }
} while ([DateTime]::UtcNow -lt $deadline)
Write-Host "  server healthy"

# Start the game client
Write-Host "[step 2] Starting visible game client (no auto-join, just lobby)"
$gameExe = Join-Path $Root "Spiel\Battleroyalebuild\bapbap.exe"
$gameDir = Join-Path $Root "Spiel\Battleroyalebuild"
# Use NO bapcustom-show-ui=false flag, so we can see the UI; also no auto-end
$clientArgs = "--melonloader.agfoffline --bapcustom-host=127.0.0.1 --bapcustom-server-port=$ServerPort --bapcustom-use-proxy=false --bapcustom-account-id=test-visible-client --bapcustom-username=VisibleTester"
$client = Start-Process -FilePath $gameExe -WorkingDirectory $gameDir -ArgumentList $clientArgs -PassThru
Write-Host "  client PID $($client.Id)"
Write-Host ""

# Watch loop
$startTime = [DateTime]::UtcNow
$nextScreenshot = 0
$scenes = @{}
while (([DateTime]::UtcNow - $startTime).TotalSeconds -lt $WatchSeconds) {
    $elapsed = [int]([DateTime]::UtcNow - $startTime).TotalSeconds
    if ($elapsed -ge $nextScreenshot) {
        $screenshotPath = "${ScreenshotPrefix}-${elapsed}s.png"
        $client.Refresh()
        if (-not $client.HasExited -and [IntPtr]::Zero -ne $client.MainWindowHandle) {
            $ok = Get-WindowImage -Process $client -Path $screenshotPath
            if (-not $ok) {
                Take-Screenshot -Path $screenshotPath
            }
            Write-Host "[t+${elapsed}s] screenshot: $([IO.Path]::GetFileName($screenshotPath)) - window: '$($client.MainWindowTitle)' size:$($client.MainWindowHandle)"
        } else {
            Write-Host "[t+${elapsed}s] client window not yet visible (handle=$($client.MainWindowHandle))"
            Take-Screenshot -Path $screenshotPath
        }
        $nextScreenshot = $elapsed + 10
    }
    Start-Sleep -Seconds 1
}

# Final cleanup
Write-Host ""
Write-Host "[cleanup] Stopping client and server"
try { $client.Kill($true) } catch { try { $client.Kill() } catch {} }
$client.WaitForExit(5000) | Out-Null
try { $server.Kill($true) } catch { try { $server.Kill() } catch {} }
$server.WaitForExit(5000) | Out-Null

Write-Host ""
Write-Host "Screenshots saved to: $LogDir"
Get-ChildItem $LogDir -Filter "watch-lobby-*.png" | Sort-Object Name | Select-Object Name, @{N='KB';E={[Math]::Round($_.Length/1KB,1)}} | Format-Table -AutoSize
