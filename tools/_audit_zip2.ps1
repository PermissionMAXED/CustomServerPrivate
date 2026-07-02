param([string]$Zip)
Add-Type -AssemblyName System.IO.Compression.FileSystem
$a = [System.IO.Compression.ZipFile]::OpenRead($Zip)
foreach ($e in $a.Entries) {
  if ($e.Name -like 'BapCustom*') {
    $bytes = [System.Text.Encoding]::UTF8.GetBytes($e.FullName)
    $hex = ($bytes | ForEach-Object { $_.ToString('X2') }) -join ' '
    Write-Output ("entry='" + $e.FullName + "' hex=" + $hex + " len=" + $e.Length)
  }
}
$a.Dispose()
