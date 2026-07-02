param([int]$ProcId, [int]$MaxSec = 90)
$ErrorActionPreference = "SilentlyContinue"
$Root = "C:\Users\Administrator\Downloads\CustomServer"
$Stamp = (Get-Date -Format "HHmmss")

$best = 0
$bestPath = ""
$shotIdx = 0

for ($i = 0; $i -lt ($MaxSec / 2); $i++) {
    $p = Get-Process -Id $ProcId -ErrorAction SilentlyContinue
    if (-not $p) { Write-Host "Process gone after $($i*2)s. Best shot was $best bytes at $bestPath"; break }

    $shotIdx++
    $path = "$Root\tools\logs\seq-$Stamp-$shotIdx.png"
    & powershell -ExecutionPolicy Bypass -File "$Root\tools\Take-WindowShot.ps1" -ProcId $ProcId -Path $path 2>&1 | Out-Null
    if (Test-Path $path) {
        $size = (Get-Item $path).Length
        if ($size -gt $best) {
            $best = $size
            if ($bestPath) { Remove-Item $bestPath -ErrorAction SilentlyContinue }
            $bestPath = $path
            Write-Host "[+$($i*2)s] new best: $size bytes -> $path"
        } else {
            Remove-Item $path -ErrorAction SilentlyContinue
        }
    }
    Start-Sleep -Seconds 2
}
Write-Host "DONE. best=$best bestPath=$bestPath"
