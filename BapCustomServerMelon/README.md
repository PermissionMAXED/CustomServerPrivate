# BAP Custom Server MelonLoader Mod

This is the in-game MelonLoader mod for selecting a custom server by host/IP and port.

## What it does

- Adds a native Unity config panel on `F7`.
- Reads and writes `%APPDATA%\BAPBAPBATTLEROYALE\BapCustomServer.ini` by default so identity is per device instead of per mod install.
- Stores host, port, HTTPS, and local proxy settings through the ini file and MelonPreferences.
- Stores optional account ID and username, then sends them as custom headers so the server can apply per-user admin and ban rules.
- Can auto-generate a local `custom-...` guest identity and prime the original BAPBAP `SESSION_ID`/`AUTO_LOGIN` keys so players do not need Steam/Discord/Google/Facebook just to enter the custom-server flow.
- Patches loaded `BAPBAP.Network.NetworkConfig` client entries so `ApiHost` points at the selected custom server route.
- Starts a managed bootstrap listener for launched match hosts.
- Starts an in-process local reverse proxy on `http://127.0.0.1:5055` by default.
- Proxies HTTP and WebSocket traffic to the configured upstream server.
- Rewrites socket discovery responses so the game connects its WebSocket back through the local proxy.

## Install

1. Install MelonLoader 0.7.x into the game folder:
   `C:\Users\Administrator\Downloads\CustomServer\Spiel\Battleroyalebuild`
2. Put this DLL into the game's `Mods` folder:
   `C:\Users\Administrator\Downloads\CustomServer\BapCustomServerMelon\dist\BapCustomServerMelon.dll`
3. Edit or let the mod create the per-device ini:
   `%APPDATA%\BAPBAPBATTLEROYALE\BapCustomServer.ini`
4. This workspace already copied the built DLL here:
   `C:\Users\Administrator\Downloads\CustomServer\Spiel\Battleroyalebuild\Mods\BapCustomServerMelon.dll`
5. Edit the ini:

```ini
[Server]
Host=YOUR_SERVER_IP_OR_DNS
Port=5055
UseHttps=false
UseLocalProxy=true
LocalProxyPort=5055

[Identity]
AccountId=
Username=
AutoGuestLogin=true
```

6. Start the game. With `AutoGuestLogin=true`, blank `AccountId`/`Username` are okay; the mod creates and saves a local guest identity on first launch in `%APPDATA%\BAPBAPBATTLEROYALE\BapCustomServer.ini`.
7. Optional: press `F7` to inspect or change the same settings in-game, then press `Apply + Save`.

## Mod Settings (BapCustomServer.ini)

The mod stores its settings in `%APPDATA%\BAPBAPBATTLEROYALE\BapCustomServer.ini`.
Below are the supported sections and notable settings.

### Separate Admin Mod

```ini
[Admin]
Enabled=true
Token=your-admin-token
```

`BapAdminMelon.dll` is a separate MelonLoader mod. It owns the admin handshake,
operator level, Unity developer console, and F8 debug overlay. The networking mod
does not hide or control developer UI.

### Server Admin Identity

To become admin on the server, your account ID must be listed in the server config under `AdminAccountIds`. The mod sends `X-BAP-AccountId` and `X-BAP-Username` headers so the server recognises you. Set them in:

```ini
[Identity]
AccountId=mein-admin-account
Username=MeinAdminName
```

> **Important distinction:** Server admin (`AdminAccountIds`) grants the account
> `isAdmin=true`. `BapAdminMelon.dll` separately uses that account plus the token
> from `[Admin]` to enable operator tools, the Unity developer console (`F9`), and
> the debug overlay (`F8`).

### Optional account identity launch args

```powershell
--bapcustom-account-id=<accountId> --bapcustom-username=<username>
```

Optional custom config path:

```powershell
--bapcustom-config="C:\Path\To\BapCustomServer.ini"
```

Automation/testing first-start setup:

```powershell
--bapcustom-setup-username=<name>
```

That argument uses the same first-start setup path as the UI: it normalizes the name, generates a local `custom-...` account ID, writes `%APPDATA%\BAPBAPBATTLEROYALE\BapCustomServer.ini`, and primes the original login session.

## Build

```powershell
dotnet build C:\Users\Administrator\Downloads\CustomServer\BapCustomServerMelon\BapCustomServerMelon.csproj -c Release
```

Or use the helper:

```powershell
C:\Users\Administrator\Downloads\CustomServer\tools\Install-BapCustomServerMelon.ps1
```

## AMP/Linux status

The mod routes the game client's API and WebSocket traffic to the custom server and can bootstrap the supplied Windows `bapbap.exe` as a match host. The current proven Linux AMP path does not use a native Linux Unity dedicated binary; it runs the Windows Unity build through Wine and Xvfb via `start-match.sh`.

Live-tested AMP/client mod DLL SHA256:

```text
3E796F1E22D124F6433DAE5BC67149A4A25D0CB5FD607DAB11FFE6934EA15E8D
```

See `../docs/AMP_LINUX_WINE_ROOT_CAUSE.md` for the root cause, Wine/Xvfb requirements, and verification commands.
