param(
    [string]$ZipPath = "",
    [int]$Port = 5066,
    [switch]$KeepExtracted
)

$ErrorActionPreference = "Stop"

$Root = Resolve-Path (Join-Path $PSScriptRoot "..")
if ([string]::IsNullOrWhiteSpace($ZipPath)) {
    $ZipPath = Join-Path $Root "deployment\amp-full-linux-wine\bapcustomserver-amp-full-linux-wine.zip"
}

$resolvedZip = Resolve-Path -LiteralPath $ZipPath
if (-not (Get-Command wsl.exe -ErrorAction SilentlyContinue)) {
    throw "wsl.exe is required for this Linux package smoke test."
}

if ($resolvedZip.Path -notmatch '^([A-Za-z]):\\(.*)$') {
    throw "Expected a local Windows drive path, got: $($resolvedZip.Path)"
}

$drive = $matches[1].ToLowerInvariant()
$rest = $matches[2] -replace '\\','/'
$zipWsl = "/mnt/$drive/$rest"
$keep = if ($KeepExtracted.IsPresent) { "1" } else { "0" }

$bash = @'
set -euo pipefail

ZIP_WSL='__ZIP_WSL__'
PORT='__PORT__'
KEEP_EXTRACTED='__KEEP_EXTRACTED__'
EXPECTED_DLL='A3B0F0CDDEEE518D025D13AD7DDD4EA090633F5327DAE1395E73538A6A97C826'

TMPROOT="/tmp/bapcustom-amp-proof-$(date +%Y%m%d%H%M%S)"
BASE="${TMPROOT}/BapCustomServer"
mkdir -p "$BASE"

cleanup_root() {
  if [ "$KEEP_EXTRACTED" != "1" ]; then
    rm -rf "$TMPROOT" >/dev/null 2>&1 || true
  fi
}
trap cleanup_root EXIT

python3 -m zipfile -e "$ZIP_WSL" "$BASE"
cd "$BASE"

for f in BapCustomServer amp-webpanel-start.sh start-linux-wine.sh start-match.sh createdump; do
  test -f "$f" || { echo "MISSING:$f"; exit 10; }
  chmod +x "$f" || true
done

python3 - <<'PY'
import hashlib
import json
import pathlib

settings = json.load(open("appsettings.json", encoding="utf-8-sig"))
custom = settings["CustomServer"]
expected = {
    "PublicBaseUrl": "http://ark.atomi23.de:5055",
    "PublicGameHost": "ark.atomi23.de",
    "BaseWsPort": 7777,
    "BaseKcpPort": 7778,
    "BaseTcpPort": 7779,
    "BaseHttpPort": 7850,
    "PortSearchRange": 1,
    "MaxConcurrentMatches": 1,
    "RequireGameServerKcpPort": True,
}

for key, expected_value in expected.items():
    actual = custom.get(key)
    if actual != expected_value:
        raise SystemExit(f"BAD_APPSETTING:{key}={actual!r} expected {expected_value!r}")

ini = pathlib.Path("game/Mods/BapCustomServer.ini").read_text(encoding="utf-8-sig")
prefs = pathlib.Path("game/UserData/MelonPreferences.cfg").read_text(encoding="utf-8-sig")

for needle in ["Host=127.0.0.1", "Port=5055", "AutoGuestLogin=false", "UseNativeGameUi=false"]:
    if needle not in ini:
        raise SystemExit(f"BAD_INI_MISSING:{needle}")

for needle in ['Host = "127.0.0.1"', "ServerPort = 5055", "AutoGuestLogin = false", "NetTuneEnabled = false"]:
    if needle not in prefs:
        raise SystemExit(f"BAD_PREF_MISSING:{needle}")

dll_hash = hashlib.sha256(pathlib.Path("game/Mods/BapCustomServerMelon.dll").read_bytes()).hexdigest().upper()
print("MOD_DLL_SHA256=" + dll_hash)
if dll_hash != "A3B0F0CDDEEE518D025D13AD7DDD4EA090633F5327DAE1395E73538A6A97C826":
    raise SystemExit("BAD_DLL_HASH:" + dll_hash)

print("APPSETTINGS_OK")
print("GAME_CONFIG_OK")
PY

LOG="${TMPROOT}/server.log"
ERR="${TMPROOT}/server.err"
ASPNETCORE_URLS="http://127.0.0.1:${PORT}" \
CustomServer__LaunchGameServers=false \
CustomServer__RequireGameServerBootstrap=false \
./amp-webpanel-start.sh "http://127.0.0.1:${PORT}" >"$LOG" 2>"$ERR" &
PID=$!

cleanup_process() {
  kill "$PID" >/dev/null 2>&1 || true
  wait "$PID" >/dev/null 2>&1 || true
}
trap 'cleanup_process; cleanup_root' EXIT

for _ in $(seq 1 40); do
  if curl -fsS "http://127.0.0.1:${PORT}/health" >/tmp/bapcustom-health.json 2>/dev/null; then
    echo "HEALTH_OK=$(cat /tmp/bapcustom-health.json)"
    echo "SERVER_LOG=$LOG"
    grep -E "Now listening on|Application started|Hosting environment" "$LOG" || true
    if [ "$KEEP_EXTRACTED" = "1" ]; then
      echo "EXTRACTED_DIR=$BASE"
    fi
    exit 0
  fi
  sleep 0.5
done

echo "SERVER_LOG_TAIL:"
tail -80 "$LOG" || true
echo "SERVER_ERR_TAIL:"
tail -80 "$ERR" || true
exit 20
'@

$script = $bash.Replace("__ZIP_WSL__", $zipWsl).
    Replace("__PORT__", $Port.ToString([Globalization.CultureInfo]::InvariantCulture)).
    Replace("__KEEP_EXTRACTED__", $keep)
$script = $script -replace "`r`n", "`n"
$encoded = [Convert]::ToBase64String([Text.Encoding]::UTF8.GetBytes($script))

wsl.exe bash -lc "echo $encoded | base64 -d > /tmp/bapcustom_amp_package_smoke.sh && bash /tmp/bapcustom_amp_package_smoke.sh"
if ($LASTEXITCODE -ne 0) {
    throw "WSL AMP package smoke test failed with exit code $LASTEXITCODE."
}
