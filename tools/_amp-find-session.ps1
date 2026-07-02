param([string]$AmpBaseUrl = "https://ark.atomi23.de")
$ErrorActionPreference = "Continue"
$ud = Join-Path $env:LOCALAPPDATA "Microsoft\Edge\User Data"
$dirs = @(
    (Join-Path $ud "Default\Local Storage\leveldb"),
    (Join-Path $ud "Default\Session Storage"),
    (Join-Path $ud "Default\IndexedDB")
)
$files = @()
foreach ($d in $dirs) {
    if (Test-Path -LiteralPath $d) {
        $files += Get-ChildItem -LiteralPath $d -Recurse -File -ErrorAction SilentlyContinue |
            Where-Object { $_.Extension -in ".ldb",".log",".blob" -or $_.Name -match 'CURRENT|MANIFEST' } |
            ForEach-Object { $_.FullName }
    }
}
Write-Host "Scanning $($files.Count) storage files for GUIDs..."
$guidRx = "[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}"
$all = New-Object System.Collections.Generic.HashSet[string]
foreach ($f in $files) {
    try {
        $t = [System.IO.File]::ReadAllText($f, [System.Text.Encoding]::GetEncoding('ISO-8859-1'))
        foreach ($m in [regex]::Matches($t, $guidRx)) { [void]$all.Add($m.Value) }
    } catch {}
}
Write-Host "Unique GUIDs found: $($all.Count)"

Add-Type -AssemblyName System.Net.Http
$client = [System.Net.Http.HttpClient]::new(); $client.Timeout=[TimeSpan]::FromSeconds(15)
function Post($path,$session) {
    $req=[System.Net.Http.HttpRequestMessage]::new([System.Net.Http.HttpMethod]::Post,"$AmpBaseUrl$path")
    [void]$req.Headers.Accept.ParseAdd("application/json")
    if ($session) { $req.Headers.Authorization=[System.Net.Http.Headers.AuthenticationHeaderValue]::new("Bearer",$session) }
    $body=@{ SESSIONID = $session } | ConvertTo-Json -Compress
    $req.Content=[System.Net.Http.StringContent]::new($body,[System.Text.Encoding]::UTF8,"application/json")
    try { $resp=$client.SendAsync($req).GetAwaiter().GetResult(); return $resp.Content.ReadAsStringAsync().GetAwaiter().GetResult() } catch { return "ERR:"+$_.Exception.Message }
}
$found = $null
foreach ($g in $all) {
    $r = Post "/API/Core/GetStatus" $g
    if ($r -and $r -match '"State"') { Write-Host "VALID SESSION: $g"; $found = $g; break }
}
if (-not $found) {
    Write-Host "No valid live session GUID found. Trying saved tokens as login..."
    foreach ($g in $all) {
        $req=[System.Net.Http.HttpRequestMessage]::new([System.Net.Http.HttpMethod]::Post,"$AmpBaseUrl/API/Core/Login")
        [void]$req.Headers.Accept.ParseAdd("application/json")
        $b=@{ username="Sonic0810"; password=""; token=$g; rememberMe=$true } | ConvertTo-Json -Compress
        $req.Content=[System.Net.Http.StringContent]::new($b,[System.Text.Encoding]::UTF8,"application/json")
        try {
            $resp=$client.SendAsync($req).GetAwaiter().GetResult(); $txt=$resp.Content.ReadAsStringAsync().GetAwaiter().GetResult()
            if ($txt -match '"sessionID"\s*:\s*"([0-9a-fA-F-]{10,})"' -and $txt -notmatch '"sessionID"\s*:\s*"00000000') {
                Write-Host "TOKEN LOGIN OK via $g -> session $($Matches[1])"; $found=$Matches[1]; break
            }
        } catch {}
    }
}
if ($found) { Write-Host "`nUSE_SESSION=$found" } else { Write-Host "`nNO_VALID_AMP_AUTH" }
