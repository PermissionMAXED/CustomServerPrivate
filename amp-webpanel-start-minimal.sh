#!/bin/sh
set -eu
SCRIPT_DIR=$(CDPATH= cd -- "$(dirname -- "$0")" && pwd)
cd "$SCRIPT_DIR"
LISTEN_URL="${1:-http://0.0.0.0:5055}"
export ASPNETCORE_URLS="$LISTEN_URL"
export PATH="/usr/share/dotnet:${PATH}"
exec dotnet "$SCRIPT_DIR/BapCustomServer.dll" --urls "$LISTEN_URL"