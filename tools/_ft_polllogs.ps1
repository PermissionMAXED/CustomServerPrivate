param(
    [int]$TailLines = 400,
    [string]$OutFile = ''
)
$ErrorActionPreference = 'SilentlyContinue'
$url = "http://ark.atomi23.de:5055/api/diagnostics/game-logs?tailLines=$TailLines&files=1"
try {
    $r = Invoke-WebRequest -UseBasicParsing -TimeoutSec 30 $url
    $body = $r.Content
    if ($OutFile -ne '') {
        $body | Out-File -FilePath $OutFile -Encoding utf8
        Write-Output ("SAVED=" + $OutFile + " LEN=" + $body.Length)
    } else {
        Write-Output $body
    }
} catch {
    Write-Output ('LOGS_ERR: ' + $_.Exception.Message)
}
