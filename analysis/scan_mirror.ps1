$m = 'C:\Users\Administrator\Downloads\BAPBAPModdingAPI\Battleroyalebuild\MelonLoader\Il2CppAssemblies\Il2CppMirror.dll'
$b = [System.IO.File]::ReadAllBytes($m)
$s = [System.Text.Encoding]::ASCII.GetString($b)
$terms = @('connectionToClient','get_connectionToClient','NetworkConnectionToClient','NetworkConnection','Spawn','identity','netIdentity')
Write-Output '--- Il2CppMirror.dll ---'
foreach ($t in $terms) { Write-Output ($t + ' = ' + $s.Contains($t)) }
