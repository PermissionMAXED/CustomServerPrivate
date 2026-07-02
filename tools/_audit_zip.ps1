param([string]$Zip)
Add-Type -AssemblyName System.IO.Compression.FileSystem
$a = [System.IO.Compression.ZipFile]::OpenRead($Zip)
foreach ($e in $a.Entries) {
  if ($e.Name -eq 'BapCustomServerMelon.dll' -or $e.Name -eq 'BapCustomServer.ini') {
    Write-Output ($e.FullName + " | " + $e.Length)
  }
}
$a.Dispose()
