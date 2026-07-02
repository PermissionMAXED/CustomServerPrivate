$ErrorActionPreference = 'Stop'
$out = 'C:\Users\Administrator\Downloads\CustomServer\analysis\_ft_test1_stdout.log'
$err = 'C:\Users\Administrator\Downloads\CustomServer\analysis\_ft_test1_stderr.log'
if (Test-Path $out) { Remove-Item $out -Force }
if (Test-Path $err) { Remove-Item $err -Force }
$p = Start-Process powershell -ArgumentList @(
    '-NoProfile','-ExecutionPolicy','Bypass','-File',
    'C:\Users\Administrator\Downloads\CustomServer\tools\Test-TwoClientMedusa.ps1'
) -RedirectStandardOutput $out -RedirectStandardError $err -PassThru -WindowStyle Hidden
$p.Id | Out-File 'C:\Users\Administrator\Downloads\CustomServer\analysis\_ft_test1_pid.txt' -Encoding ascii
Write-Output ('TEST1_PID=' + $p.Id)
