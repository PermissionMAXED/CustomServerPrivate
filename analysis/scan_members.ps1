$p = 'C:\Users\Administrator\Downloads\BAPBAPModdingAPI\Battleroyalebuild\MelonLoader\Il2CppAssemblies\Assembly-CSharp.dll'
$b = [System.IO.File]::ReadAllBytes($p)
$s = [System.Text.Encoding]::ASCII.GetString($b)
$terms = @('onlyHitAllies','allowHitToEnemies','allowHitToTeam','allowHitToOwnerPlayer','NetworkownerPlayerId','NetworkteamId','GetPlayerId','GetTeamId','otherChar','CanHitEntity','ownerPlayerId','entityTeamId','playerManager','playerObj')
foreach ($t in $terms) { Write-Output ($t + ' = ' + $s.Contains($t)) }
