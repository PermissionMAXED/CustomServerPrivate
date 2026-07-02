#!/bin/sh
# AMP-managed launcher for BAPBAP Custom Server.
# Listen URL is passed as $1 from AMP. All other config (match ports, public host)
# is provided via App.EnvironmentVariables in the kvp -> ASP.NET Core picks them up
# through CustomServer__BaseWsPort etc. (double-underscore = nested IConfiguration key).
set -eu

ROOT=$(CDPATH= cd -- "$(dirname -- "$0")" && pwd)
cd "$ROOT"

LISTEN_URL="${1:-${ASPNETCORE_URLS:-http://0.0.0.0:5055}}"

export ASPNETCORE_URLS="${ASPNETCORE_URLS:-$LISTEN_URL}"
export CustomServer__PublicBaseUrl="${CustomServer__PublicBaseUrl:-http://ark.atomi23.de:5055}"
export CustomServer__PublicGameHost="${CustomServer__PublicGameHost:-ark.atomi23.de}"
export CustomServer__GameExecutablePath="${CustomServer__GameExecutablePath:-./game/bapbap.exe}"
export CustomServer__GameWorkingDirectory="${CustomServer__GameWorkingDirectory:-./game}"
export CustomServer__GameLauncherPath="${GAME_LAUNCHER_PATH:-./start-match.sh}"
if [ -n "${GAME_LAUNCHER_ARGUMENTS:-}" ]; then
  export CustomServer__GameLauncherArguments="${GAME_LAUNCHER_ARGUMENTS}"
else
  export CustomServer__GameLauncherArguments="\"{gameExecutable}\" {gameArguments}"
fi
export CustomServer__GameServerReadyTimeoutSeconds="${GAME_READY_TIMEOUT:-150}"
export CustomServer__RequireGameServerKcpPort="${REQUIRE_GAME_KCP_PORT:-false}"
export CustomServer__GameServerKcpPortReadyTimeoutSeconds="${GAME_KCP_READY_TIMEOUT:-45}"
export CustomServer__GameServerStartAttempts="${GAME_START_ATTEMPTS:-2}"
export CustomServer__GameServerStartRetryDelaySeconds="${GAME_START_RETRY_DELAY:-2}"
export CustomServer__GameServerStartupStallGraceSeconds="${GAME_STARTUP_STALL_GRACE:-20}"
export CustomServer__GameServerStartupStallSeconds="${GAME_STARTUP_STALL:-30}"
export CustomServer__MatchmakingQueue__FailedStartRetryDelaySeconds="${FAILED_START_RETRY_DELAY:-5}"
export CustomServer__AdditionalGameArguments="${ADDITIONAL_GAME_ARGS:---melonloader.agfoffline --bapcustom-use-proxy=false --bapcustom-show-ui=false}"

chmod +x ./BapCustomServer ./createdump ./start-linux-wine.sh ./start-match.sh 2>/dev/null || true

echo "[amp-start] release=${BAPCUSTOM_RELEASE_LABEL:-bapcustomserver-20260602-medusa-queue-hotfix-110702} git=${BAPCUSTOM_GIT_COMMIT:-97d16d4d9fce} branch=${BAPCUSTOM_GIT_BRANCH:-main}"
if [ -f ./deployment-info.json ]; then
  echo "[amp-start] deploymentInfo=$(tr -d '\n' < ./deployment-info.json | cut -c1-700)"
fi
echo "[amp-start] uname=$(uname -a 2>/dev/null || true)"
echo "[amp-start] winePath=$(command -v wine || true)"
echo "[amp-start] wineVersion=$(wine --version 2>&1 || true)"
echo "[amp-start] winebootPath=$(command -v wineboot || true)"
echo "[amp-start] xvfbRunPath=$(command -v xvfb-run || true)"
echo "[amp-start] xauthPath=$(command -v xauth || true)"
echo "[amp-start] glxinfoPath=$(command -v glxinfo || true)"
echo "[amp-start] vulkanInfoPath=$(command -v vulkaninfo || true)"

if [ "${BAPCUSTOM_PREWARM_WINE:-1}" != "0" ]; then
  echo "[amp-start] prewarm begin"
  ./start-match.sh --prewarm ./game/bapbap.exe -batchmode -nographics
  echo "[amp-start] prewarm complete"
else
  echo "[amp-start] prewarm skipped by BAPCUSTOM_PREWARM_WINE=0"
fi

if [ "${BAPCUSTOM_PREWARM_UNITY:-1}" != "0" ]; then
  PREWARM_KEY=$(grep -E '"(releaseLabel|modDllSha256|medusaDllSha256|medusaBundleSha256)"' ./deployment-info.json 2>/dev/null | tr -d ' ",:' | tr -d '\r' | tr '\n' '_' | tr -cd '[:alnum:]_.-' | cut -c1-180 || true)
  [ -n "$PREWARM_KEY" ] || PREWARM_KEY="unknown"
  PREWARM_MARKER="./wineprefix32/.bapcustom-unity-prewarm-$PREWARM_KEY.ok"
  if [ -f "$PREWARM_MARKER" ]; then
    echo "[amp-start] unity prewarm skipped marker=$PREWARM_MARKER"
  else
    mkdir -p ./logs/game-servers ./wineprefix32
    PREWARM_TIMEOUT="${BAPCUSTOM_PREWARM_UNITY_TIMEOUT:-150}"
    PREWARM_HTTP="${CustomServer__BaseHttpPort:-7850}"
    PREWARM_WS="${CustomServer__BaseWsPort:-7777}"
    PREWARM_KCP="${CustomServer__BaseKcpPort:-7778}"
    PREWARM_TCP="${CustomServer__BaseTcpPort:-7779}"
    PREWARM_LOG="./logs/game-servers/prewarm-unity-$(date -u +%Y%m%dT%H%M%SZ).log"
    PREWARM_SENTINEL="./logs/game-servers/.prewarm-sentinel-$(date -u +%Y%m%dT%H%M%SZ)-$$"
    : > "$PREWARM_SENTINEL" 2>/dev/null || true
    echo "[amp-start] unity prewarm begin timeout=${PREWARM_TIMEOUT}s http=$PREWARM_HTTP ws=$PREWARM_WS kcp=$PREWARM_KCP tcp=$PREWARM_TCP log=$PREWARM_LOG"
    set +e
    if command -v timeout >/dev/null 2>&1; then
      timeout -k 15s "${PREWARM_TIMEOUT}s" ./start-match.sh ./game/bapbap.exe -batchmode -logFile "$PREWARM_LOG" -httpport="$PREWARM_HTTP" -wsport="$PREWARM_WS" -kcpport="$PREWARM_KCP" -tcpport="$PREWARM_TCP" --melonloader.agfoffline --bapcustom-use-proxy=false --bapcustom-show-ui=false --bapcustom-host=127.0.0.1 --bapcustom-server-port="5055"
      PREWARM_RC=$?
    else
      ./start-match.sh ./game/bapbap.exe -batchmode -logFile "$PREWARM_LOG" -httpport="$PREWARM_HTTP" -wsport="$PREWARM_WS" -kcpport="$PREWARM_KCP" -tcpport="$PREWARM_TCP" --melonloader.agfoffline --bapcustom-use-proxy=false --bapcustom-show-ui=false --bapcustom-host=127.0.0.1 --bapcustom-server-port="5055" &
      PREWARM_PID=$!
      sleep "$PREWARM_TIMEOUT"
      kill "$PREWARM_PID" 2>/dev/null || true
      wait "$PREWARM_PID" 2>/dev/null
      PREWARM_RC=$?
    fi
    set -e
    UNITY_SIZE=0
    [ -f "$PREWARM_LOG" ] && UNITY_SIZE=$(wc -c < "$PREWARM_LOG" 2>/dev/null | tr -d ' ' || echo 0)
    MELON_LOG="./game/MelonLoader/Latest.log"
    MELON_SIZE=0
    [ -f "$MELON_LOG" ] && MELON_SIZE=$(wc -c < "$MELON_LOG" 2>/dev/null | tr -d ' ' || echo 0)
    PREWARM_READY=0
    if grep -E '\[PREAWAKE\]|\[BAP_Custom_Server\]|\[BAPBAP_ModAPI\]|\[NETMANAGER\]|Mirror.ThreadLog' "$PREWARM_LOG" >/dev/null 2>&1; then
      PREWARM_READY=1
    fi
    if [ -f "$MELON_LOG" ] && [ "$MELON_LOG" -nt "$PREWARM_SENTINEL" ] && grep -E '\[PREAWAKE\]|\[BAP_Custom_Server\]|\[BAPBAP_ModAPI\]|\[NETMANAGER\]|Mirror.ThreadLog' "$MELON_LOG" >/dev/null 2>&1; then
      PREWARM_READY=1
    fi
    echo "[amp-start] unity prewarm finished rc=$PREWARM_RC ready=$PREWARM_READY unityLogBytes=$UNITY_SIZE melonLogBytes=$MELON_SIZE"
    if [ -f "$MELON_LOG" ]; then
      tail -n 14 "$MELON_LOG" 2>/dev/null | sed 's/^/[amp-start] melon-tail /' || true
    fi
    if [ "$PREWARM_READY" = "1" ]; then
      touch "$PREWARM_MARKER" 2>/dev/null || true
      echo "[amp-start] unity prewarm marker written $PREWARM_MARKER"
    else
      echo "[amp-start] WARNING: unity prewarm did not reach mod/bootstrap markers; first match may still cold-start slowly"
    fi
    rm -f "$PREWARM_SENTINEL" 2>/dev/null || true
  fi
else
  echo "[amp-start] unity prewarm skipped by BAPCUSTOM_PREWARM_UNITY=0"
fi

exec ./BapCustomServer --urls "$LISTEN_URL"
