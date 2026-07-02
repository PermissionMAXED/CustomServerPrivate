#!/usr/bin/env bash
set -euo pipefail

ROOT="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
PUBLIC_HOST="${PUBLIC_HOST:-ark.atomi23.de}"
LOBBY_PORT="${LOBBY_PORT:-5055}"

export ASPNETCORE_URLS="http://0.0.0.0:${LOBBY_PORT}"
export CustomServer__PublicBaseUrl="http://${PUBLIC_HOST}:${LOBBY_PORT}"
export CustomServer__PublicGameHost="${PUBLIC_HOST}"
export CustomServer__GameExecutablePath="./game/bapbap.exe"
export CustomServer__GameWorkingDirectory="./game"
if [[ "${BAPCUSTOM_ALLOW_LAUNCHER_OVERRIDE:-0}" == "1" ]]; then
  export CustomServer__GameLauncherPath="${GAME_LAUNCHER_PATH:-./start-match.sh}"
  if [[ -n "${GAME_LAUNCHER_ARGUMENTS:-}" ]]; then
    export CustomServer__GameLauncherArguments="${GAME_LAUNCHER_ARGUMENTS}"
  else
    export CustomServer__GameLauncherArguments="\"{gameExecutable}\" {gameArguments}"
  fi
else
  export CustomServer__GameLauncherPath="./start-match.sh"
  export CustomServer__GameLauncherArguments="\"{gameExecutable}\" {gameArguments}"
fi
export CustomServer__GameServerReadyTimeoutSeconds="${GAME_READY_TIMEOUT:-150}"
export CustomServer__RequireGameServerKcpPort="${REQUIRE_GAME_KCP_PORT:-false}"
export CustomServer__GameServerTcpPortReadyTimeoutSeconds="${GAME_TCP_READY_TIMEOUT:-75}"
export CustomServer__GameServerKcpPortReadyTimeoutSeconds="${GAME_KCP_READY_TIMEOUT:-45}"
export CustomServer__GameServerStartAttempts="${GAME_START_ATTEMPTS:-2}"
export CustomServer__GameServerStartRetryDelaySeconds="${GAME_START_RETRY_DELAY:-2}"
export CustomServer__GameServerStartupStallGraceSeconds="${GAME_STARTUP_STALL_GRACE:-45}"
export CustomServer__GameServerStartupStallSeconds="${GAME_STARTUP_STALL:-25}"
export CustomServer__AdditionalGameArguments="${ADDITIONAL_GAME_ARGS:---melonloader.agfoffline --melonloader.captureplayerlogs --bapcustom-use-proxy=false --bapcustom-show-ui=false}"
GRAPHICS_MODE="${BAPCUSTOM_UNITY_GRAPHICS_MODE:-${BAPCUSTOM_UNITY_GRAPHICS:-nographics}}"
export BAPCUSTOM_RELEASE_LABEL="${BAPCUSTOM_RELEASE_LABEL:-medusa-v1659-masterypreview-quiet}"
export BAPCUSTOM_GIT_COMMIT="${BAPCUSTOM_GIT_COMMIT:-97d16d4d9fce}"
export BAPCUSTOM_GIT_BRANCH="${BAPCUSTOM_GIT_BRANCH:-main}"

echo "[start-linux-wine] release=${BAPCUSTOM_RELEASE_LABEL} git=${BAPCUSTOM_GIT_COMMIT} branch=${BAPCUSTOM_GIT_BRANCH}"
if [[ -f "${ROOT}/deployment-info.json" ]]; then
  echo "[start-linux-wine] deploymentInfo=$(tr -d '\n' < "${ROOT}/deployment-info.json" | cut -c1-700)"
fi
echo "[start-linux-wine] winePath=$(command -v wine || true) wineVersion=$(wine --version 2>&1 || true)"
echo "[start-linux-wine] xvfbRunPath=$(command -v xvfb-run || true) xauthPath=$(command -v xauth || true) glxinfoPath=$(command -v glxinfo || true)"
echo "[start-linux-wine] gameLauncherPath=${CustomServer__GameLauncherPath} gameLauncherArguments=${CustomServer__GameLauncherArguments} graphicsMode=${GRAPHICS_MODE}"

if [[ -n "${ADMIN_TOKEN:-}" ]]; then
  export CustomServer__Admin__ApiToken="${ADMIN_TOKEN}"
fi

if [[ "${BAPCUSTOM_PREWARM_UNITY:-1}" != "0" ]]; then
  PREWARM_KEY="$(grep -E '"(releaseLabel|modDllSha256|medusaDllSha256|medusaBundleSha256)"' "${ROOT}/deployment-info.json" 2>/dev/null | tr -d ' ",:' | tr -d '\r' | tr '\n' '_' | tr -cd '[:alnum:]_.-' | cut -c1-180 || true)"
  [[ -n "$PREWARM_KEY" ]] || PREWARM_KEY="unknown"
  PREWARM_MARKER="${ROOT}/wineprefix32/.bapcustom-unity-prewarm-${PREWARM_KEY}.ok"
  if [[ -f "$PREWARM_MARKER" ]]; then
    echo "[start-linux-wine] unity prewarm skipped marker=$PREWARM_MARKER"
  else
    mkdir -p "${ROOT}/logs/game-servers" "${ROOT}/wineprefix32"
    PREWARM_TIMEOUT="${BAPCUSTOM_PREWARM_UNITY_TIMEOUT:-180}"
    PREWARM_HTTP="${CustomServer__BaseHttpPort:-7850}"
    PREWARM_WS="${CustomServer__BaseWsPort:-7777}"
    PREWARM_KCP="${CustomServer__BaseKcpPort:-7778}"
    PREWARM_TCP="${CustomServer__BaseTcpPort:-7779}"
    PREWARM_LOG="${ROOT}/logs/game-servers/prewarm-unity-$(date -u +%Y%m%dT%H%M%SZ).log"
    PREWARM_SENTINEL="${ROOT}/logs/game-servers/.prewarm-sentinel-$(date -u +%Y%m%dT%H%M%SZ)-$$"
    : > "$PREWARM_SENTINEL" 2>/dev/null || true
    echo "[start-linux-wine] unity prewarm begin timeout=${PREWARM_TIMEOUT}s http=$PREWARM_HTTP ws=$PREWARM_WS kcp=$PREWARM_KCP tcp=$PREWARM_TCP log=$PREWARM_LOG"
    set +e
    if command -v timeout >/dev/null 2>&1; then
      timeout -k 15s "${PREWARM_TIMEOUT}s" "${ROOT}/start-match.sh" "${ROOT}/game/bapbap.exe" -batchmode -logFile "$PREWARM_LOG" -httpport="$PREWARM_HTTP" -wsport="$PREWARM_WS" -kcpport="$PREWARM_KCP" -tcpport="$PREWARM_TCP" --melonloader.agfoffline --melonloader.captureplayerlogs --bapcustom-use-proxy=false --bapcustom-show-ui=false --bapcustom-host=127.0.0.1 --bapcustom-server-port="${LOBBY_PORT}" &
    else
      "${ROOT}/start-match.sh" "${ROOT}/game/bapbap.exe" -batchmode -logFile "$PREWARM_LOG" -httpport="$PREWARM_HTTP" -wsport="$PREWARM_WS" -kcpport="$PREWARM_KCP" -tcpport="$PREWARM_TCP" --melonloader.agfoffline --melonloader.captureplayerlogs --bapcustom-use-proxy=false --bapcustom-show-ui=false --bapcustom-host=127.0.0.1 --bapcustom-server-port="${LOBBY_PORT}" &
    fi
    PREWARM_PID=$!
    PREWARM_READY=0
    PREWARM_READY_SOURCE="none"
    PREWARM_ELAPSED=0
    PREWARM_STARTED="$(date +%s)"
    while kill -0 "$PREWARM_PID" 2>/dev/null; do
      PREWARM_ELAPSED=$(($(date +%s) - PREWARM_STARTED))
      [[ "$PREWARM_ELAPSED" -lt "$PREWARM_TIMEOUT" ]] || break
      if command -v curl >/dev/null 2>&1 && curl -sS -o /dev/null --connect-timeout 1 --max-time 2 "http://127.0.0.1:$PREWARM_HTTP/" 2>/dev/null; then
        PREWARM_READY=1
        PREWARM_READY_SOURCE="http-listener"
        break
      fi
      MELON_LOG="${ROOT}/game/MelonLoader/Latest.log"
      if [[ -f "$MELON_LOG" && "$MELON_LOG" -nt "$PREWARM_SENTINEL" ]] && grep -E 'Managed match bootstrap listener is active|Game bootstrap HTTP listener is active|Started game bootstrap WebServer on 127\.0\.0\.1:' "$MELON_LOG" >/dev/null 2>&1; then
        PREWARM_READY=1
        PREWARM_READY_SOURCE="managed-listener-log"
        break
      fi
      sleep 1
    done
    if [[ "$PREWARM_READY" == "1" ]]; then
      PREWARM_SETTLE="${BAPCUSTOM_PREWARM_UNITY_SETTLE_SECONDS:-3}"
      echo "[start-linux-wine] unity prewarm listener ready source=$PREWARM_READY_SOURCE elapsed=${PREWARM_ELAPSED}s settle=${PREWARM_SETTLE}s"
      sleep "$PREWARM_SETTLE"
    fi
    kill "$PREWARM_PID" 2>/dev/null || true
    wait "$PREWARM_PID" 2>/dev/null
    PREWARM_RC=$?
    set -e
    UNITY_SIZE=0
    [[ -f "$PREWARM_LOG" ]] && UNITY_SIZE="$(wc -c < "$PREWARM_LOG" 2>/dev/null | tr -d ' ' || echo 0)"
    MELON_LOG="${ROOT}/game/MelonLoader/Latest.log"
    MELON_SIZE=0
    [[ -f "$MELON_LOG" ]] && MELON_SIZE="$(wc -c < "$MELON_LOG" 2>/dev/null | tr -d ' ' || echo 0)"
    echo "[start-linux-wine] unity prewarm finished rc=$PREWARM_RC ready=$PREWARM_READY source=$PREWARM_READY_SOURCE elapsed=${PREWARM_ELAPSED}s unityLogBytes=$UNITY_SIZE melonLogBytes=$MELON_SIZE"
    if [[ -f "$MELON_LOG" ]]; then
      tail -n 14 "$MELON_LOG" 2>/dev/null | sed 's/^/[start-linux-wine] melon-tail /' || true
    fi
    if [[ "$PREWARM_READY" == "1" ]]; then
      touch "$PREWARM_MARKER" 2>/dev/null || true
      echo "[start-linux-wine] unity prewarm marker written $PREWARM_MARKER"
    else
      echo "[start-linux-wine] WARNING: unity prewarm did not expose its bootstrap HTTP listener; no readiness marker written"
    fi
    rm -f "$PREWARM_SENTINEL" 2>/dev/null || true
  fi
else
  echo "[start-linux-wine] unity prewarm skipped by BAPCUSTOM_PREWARM_UNITY=0"
fi

chmod +x "${ROOT}/BapCustomServer" 2>/dev/null || true
exec "${ROOT}/BapCustomServer"
