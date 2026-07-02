$ErrorActionPreference = 'SilentlyContinue'
try {
    $r = Invoke-WebRequest -UseBasicParsing -TimeoutSec 20 'http://ark.atomi23.de:5055/health'
    Write-Output ('STATUS=' + $r.StatusCode)
    Write-Output $r.Content
} catch {
    Write-Output ('HEALTH_ERR: ' + $_.Exception.Message)
}
