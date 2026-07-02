$f = 'C:\Users\Administrator\Downloads\BAPBAPModdingAPI\medusa-mod\MedusaMelon.cs'
$c = [System.IO.File]::ReadAllText($f)
$names = @(
  'UIPreMatchOpenCharacterSelectPatch',
  'PlayerPreMatchInitializePatch',
  'PlayerPreMatchUserCodeTryLockCharacterPatch',
  'PlayerPreMatchSetTeammateCharacterPatch',
  'PreMatchManagerAssignCharactersPatch',
  'PlayerManagerCharacterChangedPatch'
)
$done = 0
foreach($n in $names){
  $pat = 'PatchUi(typeof(MedusaMod.' + $n + '), "' + $n + '");'
  $rep = 'SkipUi("' + $n + '");'
  if($c.Contains($pat)){ $c = $c.Replace($pat,$rep); $done++; Write-Host "  -> SkipUi $n" }
  else { Write-Host "  NOT FOUND: $n" }
}
[System.IO.File]::WriteAllText($f,$c)
Write-Host "Converted $done of $($names.Count) dangling patch references to SkipUi."
