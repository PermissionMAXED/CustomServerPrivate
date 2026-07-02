param([string]$Zip)
Add-Type -AssemblyName System.IO.Compression.FileSystem
$tmp = "C:\Users\Administrator\AppData\Local\Temp\bapaudit"
if (-not (Test-Path $tmp)) { New-Item -ItemType Directory -Path $tmp -Force | Out-Null }
$dllPath = Join-Path $tmp "dist.dll"
$iniPath = Join-Path $tmp "dist.ini"
$a = [System.IO.Compression.ZipFile]::OpenRead($Zip)
foreach ($e in $a.Entries) {
  if ($e.FullName -eq 'Mods/BapCustomServerMelon.dll') { [System.IO.Compression.ZipFileExtensions]::ExtractToFile($e, $dllPath, $true) }
  if ($e.FullName -eq 'Mods/BapCustomServer.ini') { [System.IO.Compression.ZipFileExtensions]::ExtractToFile($e, $iniPath, $true) }
}
$a.Dispose()

Write-Output "=== INI ==="
Get-Content $iniPath
Write-Output ""

Write-Output "=== DLL strings of interest ==="
$bytes = [System.IO.File]::ReadAllBytes($dllPath)
# Extract ASCII strings >= 6 chars and look for keywords
$keywords = @('Custom Server Setup','SetupBody','SetupTitle','SetupContinue','identitySetupRequired','identity setup required','first-start','Player name','custom-','Choose your player name','Created first-start')
$ascii = [System.Text.Encoding]::ASCII.GetString($bytes)
$utf16 = [System.Text.Encoding]::Unicode.GetString($bytes)
foreach ($k in $keywords) {
  $a1 = $ascii.IndexOf($k)
  $u1 = $utf16.IndexOf($k)
  $found = ($a1 -ge 0) -or ($u1 -ge 0)
  Write-Output ("  '" + $k + "' found=" + $found + " ascii_at=" + $a1 + " utf16_at=" + $u1)
}

Write-Output ""
Write-Output "=== Hash ==="
$h = Get-FileHash $dllPath -Algorithm SHA256
Write-Output ("SHA256 = " + $h.Hash)
