#!/usr/bin/env bash
set -euo pipefail

ROOT="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
PREWARM_ONLY=0
if [[ "${1:-}" == "--prewarm" ]]; then
  PREWARM_ONLY=1
  shift
fi
if [[ $# -lt 1 ]]; then
  echo "[start-match] missing game executable argument" >&2
  exit 64
fi

GAME_EXE="$1"
shift

UNITY_LOG=""
prev=""
for arg in "$@"; do
  if [[ "$prev" == "-logFile" || "$prev" == "--logFile" ]]; then
    UNITY_LOG="$arg"
    break
  fi
  case "$arg" in
    -logFile=*|--logFile=*)
      UNITY_LOG="${arg#*=}"
      break
      ;;
  esac
  prev="$arg"
done

if [[ -n "$UNITY_LOG" ]]; then
  WRAPPER_LOG="${UNITY_LOG%.*}.wrapper.log"
else
  mkdir -p "$ROOT/logs/game-servers"
  WRAPPER_LOG="$ROOT/logs/game-servers/start-match-$(date -u +%Y%m%dT%H%M%SZ)-$$.wrapper.log"
fi
mkdir -p "$(dirname "$WRAPPER_LOG")"
exec > >(tee -a "$WRAPPER_LOG") 2>&1

echo "[start-match] utc=$(date -u +%Y-%m-%dT%H:%M:%SZ)"
echo "[start-match] prewarmOnly=$PREWARM_ONLY"
echo "[start-match] game=$GAME_EXE"
echo "[start-match] args=$*"
echo "[start-match] wrapperLog=$WRAPPER_LOG"
if [[ -f "$ROOT/deployment-info.json" ]]; then
  echo "[start-match] deploymentInfo=$ROOT/deployment-info.json"
  sed -n 's/^[[:space:]]*"\(releaseLabel\|packageBuildUtc\|gitCommit\|gitBranch\|modDllSha256\|gameExeSha256\|startMatchSha256\)"[[:space:]]*:[[:space:]]*"\([^"]*\)".*/[start-match] deployment.\1=\2/p' "$ROOT/deployment-info.json" | head -n 20 || true
else
  echo "[start-match] deploymentInfo=<missing>"
fi

WINE_BIN="$(command -v wine || true)"
WINEBOOT_BIN="$(command -v wineboot || true)"
XVFB_BIN="$(command -v Xvfb || true)"
XVFB_RUN_BIN="$(command -v xvfb-run || true)"
XAUTH_BIN="$(command -v xauth || true)"
GLXINFO_BIN="$(command -v glxinfo || true)"
VULKANINFO_BIN="$(command -v vulkaninfo || true)"

if [[ -z "$WINE_BIN" ]]; then
  echo "[start-match] ERROR: wine is not installed or not in PATH" >&2
  exit 127
fi
if [[ -z "$XVFB_BIN" ]]; then
  echo "[start-match] ERROR: Xvfb is not installed or not in PATH" >&2
  echo "[start-match] ERROR: Install with: sudo apt install xvfb" >&2
  exit 127
fi
if [[ -z "$XAUTH_BIN" ]]; then
  echo "[start-match] ERROR: xauth is not installed or not in PATH" >&2
  exit 127
fi
if [[ ! -f "$GAME_EXE" ]]; then
  echo "[start-match] ERROR: game executable not found: $GAME_EXE" >&2
  exit 66
fi

START_MATCH_WRAPPER_VERSION="20260530-graphics-modes-v3"
export WINEPREFIX="${BAPCUSTOM_WINEPREFIX:-$ROOT/wineprefix32}"
export WINEARCH=win32
export WINEDEBUG="${WINEDEBUG:--all}"
export WINESERVER_TIMEOUT=0
export WINEDLLOVERRIDES="${WINEDLLOVERRIDES:-version=n,b}"
export WINEESYNC="${WINEESYNC:-0}"
export WINEFSYNC="${WINEFSYNC:-0}"

GRAPHICS_MODE="${BAPCUSTOM_UNITY_GRAPHICS_MODE:-${BAPCUSTOM_UNITY_GRAPHICS:-nographics}}"
case "$GRAPHICS_MODE" in
  glcore33)
    # Mesa software GL for OpenGL rendering under Wine/Xvfb
    export LIBGL_ALWAYS_SOFTWARE="${LIBGL_ALWAYS_SOFTWARE:-1}"
    export GALLIUM_DRIVER="${GALLIUM_DRIVER:-llvmpipe}"
    export MESA_LOADER_DRIVER_OVERRIDE="${MESA_LOADER_DRIVER_OVERRIDE:-swrast}"
    export MESA_GL_VERSION_OVERRIDE="${MESA_GL_VERSION_OVERRIDE:-3.3}"
    export MESA_GLSL_VERSION_OVERRIDE="${MESA_GLSL_VERSION_OVERRIDE:-330}"
    ;;
  glcore)
    # Mesa software GL for OpenGL rendering under Wine/Xvfb
    export LIBGL_ALWAYS_SOFTWARE="${LIBGL_ALWAYS_SOFTWARE:-1}"
    export GALLIUM_DRIVER="${GALLIUM_DRIVER:-llvmpipe}"
    export MESA_LOADER_DRIVER_OVERRIDE="${MESA_LOADER_DRIVER_OVERRIDE:-swrast}"
    export MESA_GL_VERSION_OVERRIDE="${MESA_GL_VERSION_OVERRIDE:-4.5}"
    export MESA_GLSL_VERSION_OVERRIDE="${MESA_GLSL_VERSION_OVERRIDE:-450}"
    ;;
  nographics|none|d3d11|d3d12|vulkan)
    # No Mesa env vars - they cause Unity AppUI freeze under Wine/Xvfb.
    # Without them Unity "crashes" on D3D init but background threads
    # (bootstrap listener, quit guard) keep running.
    ;;
  *)
    echo "[start-match] WARNING: unknown BAPCUSTOM_UNITY_GRAPHICS_MODE=$GRAPHICS_MODE; falling back to nographics"
    GRAPHICS_MODE="nographics"
    ;;
esac
XVFB_SERVER_ARGS="${XVFB_SERVER_ARGS:--screen 0 1280x720x24 -ac +extension GLX +render -noreset -nolisten tcp}"

# Pre-flight: check for critical 32-bit libraries that Wine/Unity need
if command -v dpkg &>/dev/null; then
  for _lib in libgl1-mesa-dri:i386 libgl1:i386; do
    if ! dpkg -l "$_lib" &>/dev/null 2>&1; then
      echo "[start-match] WARNING: 32-bit library '$_lib' is NOT installed. This WILL cause Wine/Unity graphics failures."
      echo "[start-match] WARNING: Install with: sudo dpkg --add-architecture i386 && sudo apt install libgl1-mesa-dri:i386 libgl1:i386"
    fi
  done
fi

# Start a persistent Xvfb daemon for the full match lifecycle.
# xvfb-run is NOT used because it kills the X server when its child exits,
# which terminates Wine background processes (wineserver, services.exe, etc.)
# that are still connected to the display.
XVFB_DISPLAY="${BAPCUSTOM_XVFB_DISPLAY:-99}"
XVFB_PID=""
cleanup_xvfb() {
  if [[ -n "$XVFB_PID" ]]; then
    kill "$XVFB_PID" 2>/dev/null || true
    XVFB_PID=""
  fi
  # Remove X lock files for the display we used
  rm -f "/tmp/.X${XVFB_DISPLAY}-lock" "/tmp/.X11-unix/X${XVFB_DISPLAY}" 2>/dev/null || true
}
Xvfb ":$XVFB_DISPLAY" $XVFB_SERVER_ARGS &
XVFB_PID=$!
trap cleanup_xvfb EXIT
export DISPLAY=":$XVFB_DISPLAY"
echo "[start-match] xvfb daemon started on display :$XVFB_DISPLAY pid=$XVFB_PID"

mkdir -p "$WINEPREFIX"
WINE_VERSION="$("$WINE_BIN" --version 2>/dev/null || true)"
echo "[start-match] wrapperVersion=$START_MATCH_WRAPPER_VERSION"
echo "[start-match] wine=$WINE_VERSION"
echo "[start-match] winePath=$WINE_BIN winebootPath=${WINEBOOT_BIN:-<missing>}"
echo "[start-match] xvfbPath=$XVFB_BIN xauthPath=$XAUTH_BIN glxinfoPath=${GLXINFO_BIN:-<missing>} vulkanInfoPath=${VULKANINFO_BIN:-<missing>}"
echo "[start-match] wineprefix=$WINEPREFIX"
echo "[start-match] xvfbServerArgs=$XVFB_SERVER_ARGS"
echo "[start-match] graphicsMode=$GRAPHICS_MODE"
echo "[start-match] mesa=software LIBGL_ALWAYS_SOFTWARE=${LIBGL_ALWAYS_SOFTWARE:-<unset>} GALLIUM_DRIVER=${GALLIUM_DRIVER:-<unset>} MESA_LOADER_DRIVER_OVERRIDE=${MESA_LOADER_DRIVER_OVERRIDE:-<unset>} MESA_GL_VERSION_OVERRIDE=${MESA_GL_VERSION_OVERRIDE:-<unset>} MESA_GLSL_VERSION_OVERRIDE=${MESA_GLSL_VERSION_OVERRIDE:-<unset>}"

UNITY_GRAPHICS_ARGS=()
HAS_GRAPHICS_OVERRIDE=0
for arg in "$@"; do
  case "$arg" in
    -force-d3d*|-force-glcore*|-force-gles*|-force-vulkan|-force-metal|-nographics)
      HAS_GRAPHICS_OVERRIDE=1
      ;;
  esac
done

if [[ "$HAS_GRAPHICS_OVERRIDE" -eq 0 ]]; then
  case "$GRAPHICS_MODE" in
    glcore33)      UNITY_GRAPHICS_ARGS=(-force-glcore33) ;;
    glcore)        UNITY_GRAPHICS_ARGS=(-force-glcore) ;;
    d3d11)         UNITY_GRAPHICS_ARGS=(-force-d3d11) ;;
    d3d12)         UNITY_GRAPHICS_ARGS=(-force-d3d12) ;;
    vulkan)        UNITY_GRAPHICS_ARGS=(-force-vulkan) ;;
    nographics)    UNITY_GRAPHICS_ARGS=(-nographics) ;;
    none)          UNITY_GRAPHICS_ARGS=() ;;
  esac
fi
echo "[start-match] unityGraphicsArgs=${UNITY_GRAPHICS_ARGS[*]:-<none>}"

if [[ -n "$GLXINFO_BIN" ]]; then
  echo "[start-match] glxinfo probe begin"
  "$GLXINFO_BIN" -B 2>&1 | sed 's/^/[start-match] glxinfo /' | head -n 18 || echo "[start-match] glxinfo probe failed"
  echo "[start-match] glxinfo probe end"
else
  echo "[start-match] glxinfo probe skipped: glxinfo missing"
fi

PREFIX_KEY="$START_MATCH_WRAPPER_VERSION|$WINE_VERSION|$GRAPHICS_MODE|$WINEARCH|${LIBGL_ALWAYS_SOFTWARE:-}|${GALLIUM_DRIVER:-}|${MESA_LOADER_DRIVER_OVERRIDE:-}|${MESA_GL_VERSION_OVERRIDE:-}|${MESA_GLSL_VERSION_OVERRIDE:-}"
PREFIX_KEY_FILE="$WINEPREFIX/.bapcustom-wineboot-key"
OWNED_MARKER="$WINEPREFIX/.bapcustom-owned"
if [[ ! -f "$OWNED_MARKER" && ( -f "$WINEPREFIX/.bapcustom-wineboot-ok" || -f "$PREFIX_KEY_FILE" ) ]]; then
  echo "[start-match] WARNING: wineprefix '$WINEPREFIX' has bapcustom markers but no ownership marker; skipping destructive reset"
elif [[ -f "$WINEPREFIX/.bapcustom-wineboot-ok" && ! -f "$PREFIX_KEY_FILE" ]]; then
  echo "[start-match] wineprefix has no compatibility key; resetting prefix"
  rm -rf "$WINEPREFIX"
  mkdir -p "$WINEPREFIX"
elif [[ -f "$PREFIX_KEY_FILE" && "$(cat "$PREFIX_KEY_FILE" 2>/dev/null || true)" != "$PREFIX_KEY" ]]; then
  echo "[start-match] wineprefix key changed; resetting prefix"
  rm -rf "$WINEPREFIX"
  mkdir -p "$WINEPREFIX"
fi

if [[ -n "$WINEBOOT_BIN" && ! -f "$WINEPREFIX/.bapcustom-wineboot-ok" ]]; then
  echo "[start-match] initializing wineprefix"
  # NOT wrapped in xvfb-run: Xvfb is already running as a persistent daemon
  # (started above). wineboot spawns background Wine daemons that MUST stay
  # alive after wineboot exits — xvfb-run would kill them by killing Xvfb.
  WINEBOOT_RC=0
  "$WINEBOOT_BIN" -u || WINEBOOT_RC=$?
  if [[ "$WINEBOOT_RC" -ne 0 ]]; then
    echo "[start-match] ERROR: wineboot failed (exit code $WINEBOOT_RC). Check 32-bit library availability."
    echo "[start-match] ERROR: Missing libgl1:i386/libgl1-mesa-dri:i386 is a common cause."
    echo "[start-match] ERROR: The Wine prefix may be corrupt. Continuing but match will likely fail."
  fi
  printf '%s' "$PREFIX_KEY" > "$PREFIX_KEY_FILE"
  touch "$OWNED_MARKER"
  touch "$WINEPREFIX/.bapcustom-wineboot-ok"
  echo "[start-match] wineprefix ready"
fi

if [[ "$PREWARM_ONLY" -eq 1 ]]; then
  echo "[start-match] prewarm complete; exiting before Unity match launch"
  exit 0
fi

# Launch the game against the persistent Xvfb daemon (same display as wineboot used).
# NOT wrapped in xvfb-run — the daemon started above stays alive for the entire
# match lifecycle and is cleaned up via the EXIT trap.
echo "[start-match] launching game on display $DISPLAY via $WINE_BIN"
"$WINE_BIN" "$GAME_EXE" "${UNITY_GRAPHICS_ARGS[@]}" "$@"
EXIT_CODE=$?
echo "[start-match] game exited with code $EXIT_CODE"
exit $EXIT_CODE