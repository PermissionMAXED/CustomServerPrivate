#!/bin/sh
set -eu
ROOT=$(CDPATH= cd -- "$(dirname -- "$0")" && pwd)
cd "$ROOT"
LISTEN_URL="${1:-${ASPNETCORE_URLS:-http://0.0.0.0:5055}}"
export ASPNETCORE_URLS="${ASPNETCORE_URLS:-$LISTEN_URL}"
export CustomServer__Admin__ApiToken="bapbap-admin-token-2024"
export CustomServer__Admin__AdminAccountIdsCsv="custom-1001,custom-382jfI238ALO"
export CustomServer__Admin__AttestationSecret="$(echo LXsuei95KHgpfyp+cn1zfHpyeXN4fH99fn59f3x4c3kqKikpKCgvLy4uLS17e3p6cnJzc3x8fX1+fn9/eHh5eQ== | base64 -d)"
exec ./BapCustomServer --urls "$LISTEN_URL"
