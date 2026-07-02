$ErrorActionPreference = 'Stop'
$cfg = Join-Path $PSScriptRoot '..\deployment\amp-github-autoinstall\bapcustomservergithubconfig.json'
$entries = Get-Content $cfg -Raw -Encoding UTF8 | ConvertFrom-Json -AsHashtable
$count = 0
foreach ($entry in $entries) {
    if ($entry.ContainsKey('EnumValues') -and $entry['EnumValues'] -is [hashtable]) {
        $reversed = [ordered]@{}
        foreach ($pair in $entry['EnumValues'].GetEnumerator()) {
            $label = $pair.Key
            $value = [string]$pair.Value
            if (-not $reversed.Contains($value)) {
                $reversed[$value] = $label
            }
        }
        $entry['EnumValues'] = $reversed
        $count++
    }
}
$out = $entries | ConvertTo-Json -Depth 10
[System.IO.File]::WriteAllText($cfg, $out, [System.Text.UTF8Encoding]::new($false))
"Reversed EnumValues in $count entries"
