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

$logDir = "C:\Users\Administrator\Downloads\CustomServer\tools\logs"
New-Item -ItemType Directory -Force -Path $logDir | Out-Null

$times = @(15, 25, 35, 45, 55, 65, 75)

foreach ($t in $times) {
    $path = "$logDir\visual-test-${t}s.png"
    try {
        Take-Screenshot -Path $path
        $size = (Get-Item $path).Length
        Write-Output "Screenshot at ${t}s: (${size} bytes)"
    } catch {
        Write-Output "Screenshot at ${t}s FAILED: $_"
    }
    Start-Sleep -Seconds 10
}

Write-Output "DONE"
