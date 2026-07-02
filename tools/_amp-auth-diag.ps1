param(
    [string]$AmpBaseUrl = "https://ark.atomi23.de"
)
$ErrorActionPreference = "Continue"
$levelDb = Join-Path $env:LOCALAPPDATA "Microsoft\Edge\User Data\Default\Local Storage\leveldb"
Write-Host "LevelDB path: $levelDb  exists=$(Test-Path -LiteralPath $levelDb)"
$files = @()
if (Test-Path -LiteralPath $levelDb) {
    $files = Get-ChildItem -LiteralPath $levelDb -File | Where-Object { $_.Extension -in ".ldb", ".log" } | ForEach-Object { $_.FullName }
}
Write-Host "LevelDB .ldb/.log files: $($files.Count)"

$rawAll = ($files | ForEach-Object { try { [System.IO.File]::ReadAllText($_, [System.Text.Encoding]::GetEncoding('ISO-8859-1')) } catch { '' } }) -join "`n"
$hasLast = ([regex]::Matches($rawAll, 'LastSessionID')).Count
$hasSaved = ([regex]::Matches($rawAll, 'SavedToken')).Count
Write-Host "Occurrences: LastSessionID=$hasLast SavedToken=$hasSaved"
$guidRx = "[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}"
$lines = ($files | ForEach-Object { try { $t=[System.IO.File]::ReadAllText($_, [System.Text.Encoding]::GetEncoding('ISO-8859-1')); ($t -split "`n") | Where-Object { $_ -match 'LastSessionID|SavedToken' } } catch {} })
$cands = [regex]::Matches(($lines -join "`n"), $guidRx) | ForEach-Object { $_.Value } | Select-Object -Unique
Write-Host "Unique GUID candidates near keywords: $($cands.Count)"

# Other Edge profiles?
$udRoot = Join-Path $env:LOCALAPPDATA "Microsoft\Edge\User Data"
Write-Host "`nOther Edge profiles with leveldb:"
Get-ChildItem -LiteralPath $udRoot -Directory -ErrorAction SilentlyContinue | ForEach-Object {
    $p = Join-Path $_.FullName "Local Storage\leveldb"
    if (Test-Path -LiteralPath $p) { "  $($_.Name): $((Get-ChildItem -LiteralPath $p -File -ErrorAction SilentlyContinue | Where-Object {$_.Extension -in '.ldb','.log'}).Count) files" }
}

Add-Type -AssemblyName System.Net.Http
$client = [System.Net.Http.HttpClient]::new(); $client.Timeout=[TimeSpan]::FromSeconds(20)
function Post($base,$path,$session) {
    $req=[System.Net.Http.HttpRequestMessage]::new([System.Net.Http.HttpMethod]::Post,"$base$path")
    [void]$req.Headers.Accept.ParseAdd("application/json")
    if ($session) { $req.Headers.Authorization=[System.Net.Http.Headers.AuthenticationHeaderValue]::new("Bearer",$session) }
    $sid = if ($session) { $session } else { "" }
    $body=@{ SESSIONID = $sid } | ConvertTo-Json -Compress
    $req.Content=[System.Net.Http.StringContent]::new($body,[System.Text.Encoding]::UTF8,"application/json")
    try { $resp=$client.SendAsync($req).GetAwaiter().GetResult(); $txt=$resp.Content.ReadAsStringAsync().GetAwaiter().GetResult(); return @{ code=[int]$resp.StatusCode; body=$txt } }
    catch { return @{ code=-1; body=$_.Exception.Message } }
}
foreach ($base in @("https://ark.atomi23.de","http://ark.atomi23.de:8080","https://ark.atomi23.de:8443")) {
    $r = Post $base "/API/Core/GetStatus" ""
    $snip = if ($r.body) { $r.body.Substring(0,[Math]::Min(120,$r.body.Length)) } else { "" }
    Write-Host ("Reach {0}/API/Core/GetStatus -> code={1} body={2}" -f $base,$r.code,$snip)
}
Write-Host "`nValidating candidates against $AmpBaseUrl ..."
$ok=0
foreach ($c in $cands) {
    $r = Post $AmpBaseUrl "/API/Core/GetStatus" $c
    if ($r.code -eq 200 -and $r.body -and $r.body -match '"State"') { Write-Host "  VALID session candidate: $c"; $ok++ }
}
Write-Host "Valid session candidates: $ok"
