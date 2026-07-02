#!/usr/bin/env bash
# Executable test harness for deployment/amp-full-linux-wine/start-match.sh (F188-F192).
# Stubs wine/wineboot/xvfb-run/xauth so the script runs every branch WITHOUT a real Wine
# install or game binary. Asserts exit codes, graphics-mode selection, prefix init + the
# B23 ownership-marker guard, prewarm short-circuit, and deployment-info echo.
set -u

SCRIPT="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)/deployment/amp-full-linux-wine/start-match.sh"
PASS=0
FAIL=0

fail() { echo "  FAIL: $1"; FAIL=$((FAIL+1)); }
pass() { PASS=$((PASS+1)); }
check() { # check <desc> <condition-result(0/1)>
  if [[ "$2" -eq 0 ]]; then pass; else fail "$1"; fi
}

make_stubs() { # make_stubs <dir> <include_wine:0/1>
  local dir="$1"; local with_wine="$2"
  mkdir -p "$dir"
  if [[ "$with_wine" -eq 1 ]]; then
    cat > "$dir/wine" <<'EOF'
#!/usr/bin/env bash
if [[ "${1:-}" == "--version" ]]; then echo "wine-9.0-stub"; exit 0; fi
echo "WINE_LAUNCHED:$*" >> "${WINE_INVOKE_LOG:-/dev/null}"
exit 0
EOF
    chmod +x "$dir/wine"
    cat > "$dir/wineboot" <<'EOF'
#!/usr/bin/env bash
echo "WINEBOOT_RAN:$*" >> "${WINEBOOT_INVOKE_LOG:-/dev/null}"
exit 0
EOF
    chmod +x "$dir/wineboot"
  fi
  # xvfb-run: strip its own flags, exec the wrapped command (so wine/wineboot stubs run)
  cat > "$dir/xvfb-run" <<'EOF'
#!/usr/bin/env bash
args=()
while [[ $# -gt 0 ]]; do
  case "$1" in
    -a) shift;;
    --server-args=*) shift;;
    --server-args) shift; shift || true;;
    *) args+=("$1"); shift;;
  esac
done
exec "${args[@]}"
EOF
  chmod +x "$dir/xvfb-run"
  printf '#!/usr/bin/env bash\nexit 0\n' > "$dir/xauth"; chmod +x "$dir/xauth"
}

run() { # run <prefix_dir> <env-assignments...> -- <args...>  => sets OUT, RC
  local stubdir="$1"; shift
  local envs=(); while [[ "$1" != "--" ]]; do envs+=("$1"); shift; done; shift
  OUT="$(env -i PATH="$stubdir:/usr/bin:/bin" HOME="$TMPROOT/home" \
        "${envs[@]}" bash "$SCRIPT" "$@" 2>&1)"
  RC=$?
}

TMPROOT="$(mktemp -d)"
trap 'rm -rf "$TMPROOT"' EXIT
mkdir -p "$TMPROOT/home"
GAME_EXE="$TMPROOT/bapbap.exe"; printf 'stub' > "$GAME_EXE"

echo "=== F188: launch wrapper exit codes + prereq detection ==="

# exit 64: no game executable argument
stub1="$TMPROOT/stub_full"; make_stubs "$stub1" 1
run "$stub1" --
check "no-arg should exit 64 (got $RC)" $([[ $RC -eq 64 ]] && echo 0 || echo 1)

# exit 66: game exe does not exist (tools present)
run "$stub1" -- "$TMPROOT/does-not-exist.exe"
check "missing game exe should exit 66 (got $RC)" $([[ $RC -eq 66 ]] && echo 0 || echo 1)

# exit 127: wine missing (stub dir without wine)
stub_nowine="$TMPROOT/stub_nowine"; make_stubs "$stub_nowine" 0
run "$stub_nowine" -- "$GAME_EXE"
check "missing wine should exit 127 (got $RC)" $([[ $RC -eq 127 ]] && echo 0 || echo 1)
check "missing-wine message present" $(echo "$OUT" | grep -q "wine is not installed" && echo 0 || echo 1)

# happy path: launches via wine stub (WINE_LAUNCHED marker)
wlog="$TMPROOT/wine_invoke.log"; : > "$wlog"
run "$stub1" "WINE_INVOKE_LOG=$wlog" -- "$GAME_EXE"
check "happy path exits 0 (got $RC)" $([[ $RC -eq 0 ]] && echo 0 || echo 1)
check "game was launched via wine" $(grep -q "WINE_LAUNCHED:" "$wlog" && echo 0 || echo 1)
check "launched game exe path" $(grep -q "bapbap.exe" "$wlog" && echo 0 || echo 1)

echo "=== F189: software-GL graphics-mode strategy selection ==="

# default mode = none (Xvfb still provides a display; avoids AppUI PlayerLoop stalls under -nographics)
run "$stub1" "WINE_INVOKE_LOG=$TMPROOT/w2.log" -- "$GAME_EXE"
check "default graphics mode is none" $(echo "$OUT" | grep -q "graphicsMode=none" && echo 0 || echo 1)
check "default injects no graphics override" $(echo "$OUT" | grep -q "unityGraphicsArgs=<none>" && echo 0 || echo 1)

# glcore33 mode → -force-glcore33 + Mesa overrides
run "$stub1" "WINE_INVOKE_LOG=$TMPROOT/w3.log" "BAPCUSTOM_UNITY_GRAPHICS_MODE=glcore33" -- "$GAME_EXE"
check "glcore33 selects -force-glcore33" $(echo "$OUT" | grep -q "unityGraphicsArgs=-force-glcore33" && echo 0 || echo 1)
check "glcore33 sets MESA_GL_VERSION_OVERRIDE=3.3" $(echo "$OUT" | grep -q "MESA_GL_VERSION_OVERRIDE=3.3" && echo 0 || echo 1)

# d3d11 mode → -force-d3d11
run "$stub1" "WINE_INVOKE_LOG=$TMPROOT/w4.log" "BAPCUSTOM_UNITY_GRAPHICS_MODE=d3d11" -- "$GAME_EXE"
check "d3d11 selects -force-d3d11" $(echo "$OUT" | grep -q "unityGraphicsArgs=-force-d3d11" && echo 0 || echo 1)

# unknown mode → warning + none fallback
run "$stub1" "WINE_INVOKE_LOG=$TMPROOT/w5.log" "BAPCUSTOM_UNITY_GRAPHICS_MODE=bogus" -- "$GAME_EXE"
check "unknown mode warns" $(echo "$OUT" | grep -q "unknown BAPCUSTOM_UNITY_GRAPHICS_MODE=bogus" && echo 0 || echo 1)
check "unknown mode falls back to none" $(echo "$OUT" | grep -q "graphicsMode=none" && echo 0 || echo 1)

# caller-supplied -force-* flag is NOT overridden (HAS_GRAPHICS_OVERRIDE)
run "$stub1" "WINE_INVOKE_LOG=$TMPROOT/w6.log" "BAPCUSTOM_UNITY_GRAPHICS_MODE=glcore33" -- "$GAME_EXE" -force-vulkan
check "caller -force flag suppresses injected graphics arg" $(echo "$OUT" | grep -q "unityGraphicsArgs=<none>" && echo 0 || echo 1)

echo "=== F190: wineprefix init + compatibility-key invalidation + B23 ownership guard ==="

prefix="$TMPROOT/wp"
blog="$TMPROOT/wineboot.log"; : > "$blog"
run "$stub1" "BAPCUSTOM_WINEPREFIX=$prefix" "WINEBOOT_INVOKE_LOG=$blog" "WINE_INVOKE_LOG=$TMPROOT/w7.log" -- "$GAME_EXE"
check "wineboot ran on first init" $(grep -q "WINEBOOT_RAN:" "$blog" && echo 0 || echo 1)
check "owned marker created" $([[ -f "$prefix/.bapcustom-owned" ]] && echo 0 || echo 1)
check "wineboot-ok marker created" $([[ -f "$prefix/.bapcustom-wineboot-ok" ]] && echo 0 || echo 1)
check "key file created" $([[ -f "$prefix/.bapcustom-wineboot-key" ]] && echo 0 || echo 1)

# second run: prefix already initialized → wineboot should NOT re-run
: > "$blog"
run "$stub1" "BAPCUSTOM_WINEPREFIX=$prefix" "WINEBOOT_INVOKE_LOG=$blog" "WINE_INVOKE_LOG=$TMPROOT/w8.log" -- "$GAME_EXE"
check "wineboot does NOT re-run when already initialized" $([[ ! -s "$blog" ]] && echo 0 || echo 1)

# B23: a prefix with markers but NO ownership marker must NOT be rm -rf'd (key change triggered)
unowned="$TMPROOT/unowned"
mkdir -p "$unowned"
touch "$unowned/.bapcustom-wineboot-ok"
printf 'OLD-DIFFERENT-KEY' > "$unowned/.bapcustom-wineboot-key"
printf 'precious-user-data' > "$unowned/important.txt"
run "$stub1" "BAPCUSTOM_WINEPREFIX=$unowned" "WINEBOOT_INVOKE_LOG=$TMPROOT/b.log" "WINE_INVOKE_LOG=$TMPROOT/w9.log" -- "$GAME_EXE"
check "B23: unowned prefix is NOT wiped" $([[ -f "$unowned/important.txt" ]] && echo 0 || echo 1)
check "B23: skip-reset warning emitted" $(echo "$OUT" | grep -q "skipping destructive reset" && echo 0 || echo 1)

echo "=== F191: prewarm-only mode ==="

pwprefix="$TMPROOT/wp_pre"
pwwine="$TMPROOT/prewarm_wine.log"; : > "$pwwine"
run "$stub1" "BAPCUSTOM_WINEPREFIX=$pwprefix" "WINE_INVOKE_LOG=$pwwine" "WINEBOOT_INVOKE_LOG=$TMPROOT/pb.log" -- --prewarm "$GAME_EXE"
check "prewarm exits 0 (got $RC)" $([[ $RC -eq 0 ]] && echo 0 || echo 1)
check "prewarm prints completion message" $(echo "$OUT" | grep -q "prewarm complete; exiting before Unity match launch" && echo 0 || echo 1)
check "prewarm does NOT launch the game" $([[ ! -s "$pwwine" ]] && echo 0 || echo 1)
check "prewarm still initialized the prefix" $([[ -f "$pwprefix/.bapcustom-wineboot-ok" ]] && echo 0 || echo 1)

echo "=== F192: wrapper logging + deployment-info echo ==="

# deployment-info.json is read relative to the script's own ROOT; create one there, restore after.
DEP="$(dirname "$SCRIPT")/deployment-info.json"
DEP_EXISTED=0; [[ -f "$DEP" ]] && { DEP_EXISTED=1; cp "$DEP" "$TMPROOT/dep.bak"; }
cat > "$DEP" <<'EOF'
{
  "releaseLabel": "test-release-1.2.3",
  "gitCommit": "abc1234",
  "gitBranch": "main",
  "modDllSha256": "deadbeef"
}
EOF
run "$stub1" "WINE_INVOKE_LOG=$TMPROOT/w10.log" -- "$GAME_EXE"
check "deployment releaseLabel echoed" $(echo "$OUT" | grep -q "deployment.releaseLabel=test-release-1.2.3" && echo 0 || echo 1)
check "deployment gitCommit echoed" $(echo "$OUT" | grep -q "deployment.gitCommit=abc1234" && echo 0 || echo 1)
check "wrapper logs utc + game + args" $(echo "$OUT" | grep -q "\[start-match\] game=" && echo 0 || echo 1)
check "wrapper version logged" $(echo "$OUT" | grep -q "wrapperVersion=" && echo 0 || echo 1)
# restore original deployment-info.json state
if [[ "$DEP_EXISTED" -eq 1 ]]; then cp "$TMPROOT/dep.bak" "$DEP"; else rm -f "$DEP"; fi

echo ""
echo "=== RESULT: $PASS passed, $FAIL failed ==="
[[ $FAIL -eq 0 ]] && exit 0 || exit 1
