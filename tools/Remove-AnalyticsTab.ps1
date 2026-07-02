$ErrorActionPreference = 'Stop'
$cfg = Join-Path $PSScriptRoot '..\deployment\amp-github-autoinstall\bapcustomservergithubconfig.json'
$entries = Get-Content $cfg -Raw -Encoding UTF8 | ConvertFrom-Json
$before = $entries.Count
$filtered = $entries | Where-Object { $_.Category -ne 'BAPBAP - Analytics' }
$after = ($filtered | Measure-Object).Count
$json = $filtered | ConvertTo-Json -Depth 10
[System.IO.File]::WriteAllText($cfg, $json, [System.Text.UTF8Encoding]::new($false))
"Removed $($before - $after) BAPBAP - Analytics fields. $after entries remain."

# Also remove from package/templates
$pkg = Join-Path $PSScriptRoot '..\deployment\amp-github-autoinstall\package\templates\bapcustomservergithubconfig.json'
Copy-Item $cfg $pkg -Force
"Synced to package/templates"

# Remove the matching CustomServer.Analytics.* lines from kvp templates (keep GenericModule.App.* keys for AMP's built-in analytics)
$kvpFiles = @(
    (Join-Path $PSScriptRoot '..\deployment\amp-github-autoinstall\bapcustomservergithub.kvp.template'),
    (Join-Path $PSScriptRoot '..\deployment\amp-github-autoinstall\package\templates\bapcustomservergithub.kvp'),
    (Join-Path $PSScriptRoot '..\deployment\github-release\amptemplates-root-repo\bapcustomservergithub.kvp')
)
foreach ($k in $kvpFiles) {
    if (-not (Test-Path $k)) { continue }
    $lines = Get-Content $k
    $kept = $lines | Where-Object { $_ -notmatch '^CustomServer\.Analytics\.' }
    [System.IO.File]::WriteAllText($k, ($kept -join "`n"), [System.Text.UTF8Encoding]::new($false))
    "Cleaned: $k"
}
