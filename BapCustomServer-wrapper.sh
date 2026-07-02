#!/bin/sh
set -eu
SCRIPT_DIR=$(CDPATH= cd -- "$(dirname -- "$0")" && pwd)
cd "$SCRIPT_DIR"
PATH="/usr/share/dotnet:$PATH"
export PATH
exec dotnet "$SCRIPT_DIR/BapCustomServer.dll" "$@"