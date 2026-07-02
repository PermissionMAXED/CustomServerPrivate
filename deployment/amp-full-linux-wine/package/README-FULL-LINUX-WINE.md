# BAPBAP Custom Server - AMP Full Linux/Wine Package

This package contains the complete `BapCustomServer/` folder for an AMP Generic instance:

- Linux ASP.NET CustomMatchServer.
- Windows Unity game build under `game/`.
- MelonLoader files.
- `Mods/BapCustomServerMelon.dll`.
- `Mods/BapCustomServer.ini`.
- Medusa ModAPI files: `Mods/BAPBAP.ModAPI.dll`, `UserLibs/BAPBAP.ModAPI.dll`, `Mods/BAPBAP.Medusa.dll`, `UserData/Medusa/medusa.bundle`.

Upload/extract this package into the AMP instance root so the final path is:

`<instance>/BapCustomServer/BapCustomServer`
`<instance>/BapCustomServer/game/bapbap.exe`

Web-panel-only deployment order:

1. Import the Linux web-panel AMP template package `deployment\amp-linux-webpanel\bapcustomserver-linux-webpanel-template.zip`.
2. Create a new instance from the `BAPBAP Custom Server Linux Web Panel` template.
3. Upload this full package in the instance File Manager.
4. Extract it into the instance root so the `BapCustomServer/` folder is visible at `/BapCustomServer`.
5. Press `Start`.

The Linux web-panel template starts the system `/bin/sh` executable and passes it
`BapCustomServer/amp-webpanel-start.sh`. That script does not need its own
executable flag because `/bin/sh` reads it as text, then the script marks
`BapCustomServer` executable and starts the server. Do not use an older
instance/template that starts `BapCustomServer` directly, because web-panel ZIP
extraction can lose the Linux executable flag.

Required Linux packages on the AMP host:

```bash
sudo dpkg --add-architecture i386
sudo apt update
sudo apt install -y wine wine32 wine64 xvfb xauth libgl1 libgl1:i386 libgl1-mesa-dri libgl1-mesa-dri:i386 libglx-mesa0 libglx-mesa0:i386 libvulkan1 libvulkan1:i386 mesa-vulkan-drivers mesa-vulkan-drivers:i386 mesa-utils x11-utils
```

If you only have web-panel access, your AMP host/container image must already
provide Wine and Xvfb, or the host provider/admin must add them. File upload alone
cannot install host OS packages.

The matching AMP template starts `/bin/sh` on Linux and runs
`amp-webpanel-start.sh`. This is required for web-panel-only deployments where
SSH/terminal `chmod` is not available.

Recommended AMP settings:

- Public Base URL: `http://YOUR_PUBLIC_IP_OR_DOMAIN:5055`
- Public Game Host: `YOUR_PUBLIC_IP_OR_DOMAIN`
- Game Executable Path: `./game/bapbap.exe`
- Game Working Directory: `./game`
- Game Launcher Path: `./start-match.sh`
- Game Launcher Arguments: `"{gameExecutable}" {gameArguments}`
- Additional Game Arguments: `--melonloader.agfoffline --bapcustom-use-proxy=false --bapcustom-show-ui=false`
- Game Ready Timeout: `300`
- Launch Match Processes: `true`
- Require Bootstrap: `true`

The `start-match.sh` wrapper is required. It logs the active release, Wine/Xvfb
paths, Mesa state, graphics strategy, and per-match Unity/Melon logs. Do not set
the launcher directly to `xvfb-run` or `wine` unless you intentionally bypass the
diagnostic wrapper.

Open firewall/NAT:

- `5055/tcp` for lobby/API/WebSocket.
- `7777/tcp` for match WebSocket.
- `7778/udp` for match KCP.
- `7779/tcp` for match TCP fallback.

Players only need `BapCustomServerMelon.dll` and `BapCustomServer.ini` in their local game `Mods` folder. In their ini:

```ini
[Server]
Host=YOUR_PUBLIC_IP_OR_DOMAIN
Port=5055
UseHttps=false
UseLocalProxy=true
LocalProxyPort=5055
```
