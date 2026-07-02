param([string]$Zip, [string]$EntryPath, [string]$OutPath)
Add-Type -AssemblyName System.IO.Compression.FileSystem
$a = [System.IO.Compression.ZipFile]::OpenRead($Zip)
foreach ($e in $a.Entries) {
  if ($e.FullName -eq $EntryPath) {
    [System.IO.Compression.ZipFileExtensions]::ExtractToFile($e, $OutPath, $true)
    break
  }
}
$a.Dispose()
Write-Output ("Extracted: " + $OutPath)
