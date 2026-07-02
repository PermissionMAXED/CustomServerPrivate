#!/bin/sh
set -eu
SCRIPT_DIR=$(CDPATH= cd -- "$(dirname -- "$0")" && pwd)
cd "$SCRIPT_DIR"
LISTEN_URL="${1:-http://0.0.0.0:5055}"
export ASPNETCORE_URLS="$LISTEN_URL"
export CustomServer__PublicBaseUrl="${CustomServer__PublicBaseUrl:-http://ark.atomi23.de:5055}"
export CustomServer__PublicGameHost="${CustomServer__PublicGameHost:-ark.atomi23.de}"
chmod +x ./BapCustomServer 2>/dev/null || true
exec ./BapCustomServer --urls "$LISTEN_URL"
