param([string]$Path)
$h = Get-FileHash $Path -Algorithm SHA256
Write-Output ("SHA256 = " + $h.Hash)
Write-Output ("SHA256-first8 = " + $h.Hash.Substring(0,8))
$bytes = [System.IO.File]::ReadAllBytes($Path)
# CRC32 via simple table
$table = @()
for ($i = 0; $i -lt 256; $i++) {
  $c = [uint32]$i
  for ($j = 0; $j -lt 8; $j++) {
    if (($c -band 1) -ne 0) { $c = (0xEDB88320 -bxor ($c -shr 1)) }
    else { $c = ($c -shr 1) }
  }
  $table += [uint32]$c
}
$crc = [uint32]0xFFFFFFFF
foreach ($b in $bytes) {
  $crc = ($table[($crc -bxor $b) -band 0xFF]) -bxor ($crc -shr 8)
}
$crc = $crc -bxor 0xFFFFFFFF
Write-Output ("CRC32 = " + ('{0:X8}' -f $crc))
