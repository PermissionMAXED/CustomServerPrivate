$ErrorActionPreference = 'SilentlyContinue'
$procs = Get-Process bapbap,cua-driver,dotnet -ErrorAction SilentlyContinue
if ($null -eq $procs) { Write-Output 'NO_STALE_PROCS'; return }
foreach ($p in $procs) {
    try { cmd /c "wmic process where processid=$($p.Id) call terminate" | Out-Null; Write-Output ("KILLED " + $p.ProcessName + " pid=" + $p.Id) } catch {}
}
