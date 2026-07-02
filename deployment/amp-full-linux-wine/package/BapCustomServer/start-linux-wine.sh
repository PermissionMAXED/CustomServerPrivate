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
export CustomServer__GameServerReadyTimeoutSeconds="${GAME_READY_TIMEOUT:-300}"
export CustomServer__RequireGameServerKcpPort="${REQUIRE_GAME_KCP_PORT:-true}"
export CustomServer__GameServerManagedBootstrapStatusTimeoutSeconds="${GAME_MANAGED_BOOTSTRAP_TIMEOUT:-180}"
export CustomServer__GameServerManagedBootstrapListenerOnlyTimeoutSeconds="${GAME_MANAGED_BOOTSTRAP_LISTENER_ONLY_TIMEOUT:-0}"
export CustomServer__EmptyLobbyMatchCleanupGraceSeconds="${EMPTY_LOBBY_MATCH_CLEANUP_GRACE:-15}"
export CustomServer__EmptyLobbyMatchConnectedCleanupGraceSeconds="${EMPTY_LOBBY_MATCH_CONNECTED_CLEANUP_GRACE:-45}"
export CustomServer__GameServerTcpPortReadyTimeoutSeconds="${GAME_TCP_READY_TIMEOUT:-30}"
export CustomServer__GameServerKcpPortReadyTimeoutSeconds="${GAME_KCP_READY_TIMEOUT:-45}"
export CustomServer__GameServerStartAttempts="${GAME_START_ATTEMPTS:-2}"
export CustomServer__GameServerStartRetryDelaySeconds="${GAME_START_RETRY_DELAY:-10}"
export CustomServer__GameServerStopWaitMillis="${GAME_STOP_WAIT_MS:-5000}"
export CustomServer__GameServerPostCleanupStartDelayMillis="${GAME_POST_CLEANUP_START_DELAY_MS:-3000}"
export CustomServer__GameServerStartupStallGraceSeconds="${GAME_STARTUP_STALL_GRACE:-45}"
export CustomServer__GameServerStartupStallSeconds="${GAME_STARTUP_STALL:-25}"
export CustomServer__GameServerWrapperOnlyStartupStallGraceSeconds="${GAME_WRAPPER_ONLY_STALL_GRACE:-60}"
export CustomServer__GameServerWrapperOnlyStartupStallSeconds="${GAME_WRAPPER_ONLY_STALL:-25}"
export CustomServer__GameServerPrewarmOnStartup="${GAME_PREWARM_ON_STARTUP:-true}"
export CustomServer__GameServerPrewarmTimeoutSeconds="${GAME_PREWARM_TIMEOUT:-180}"
export CustomServer__GameServerPrewarmMatchWaitSeconds="${GAME_PREWARM_MATCH_WAIT:-35}"
export CustomServer__GameServerPrewarmPortOffset="${GAME_PREWARM_PORT_OFFSET:-150}"
export CustomServer__GameServerPrewarmSettleSeconds="${GAME_PREWARM_SETTLE:-3}"
export CustomServer__AdditionalGameArguments="${ADDITIONAL_GAME_ARGS:---melonloader.agfoffline --bapcustom-use-proxy=false --bapcustom-show-ui=false}"
GRAPHICS_MODE="${BAPCUSTOM_UNITY_GRAPHICS_MODE:-${BAPCUSTOM_UNITY_GRAPHICS:-nographics}}"
export BAPCUSTOM_RELEASE_LABEL="${BAPCUSTOM_RELEASE_LABEL:-backup-pre-amp-refactor-20260527-174239-46-g1ed6721-dirty}"
export BAPCUSTOM_GIT_COMMIT="${BAPCUSTOM_GIT_COMMIT:-1ed67211e039}"
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

chmod +x "${ROOT}/BapCustomServer" "${ROOT}/amp-webpanel-start.sh" 2>/dev/null || true
exec "${ROOT}/amp-webpanel-start.sh" "${ASPNETCORE_URLS}"
