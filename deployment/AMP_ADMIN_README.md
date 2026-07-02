# BAPBAP Custom Server — AMP Admin Guide

> This document is for **server operators only**. It covers all admin commands,
> configuration, and operational details for running the BAPBAP Custom Match Server
> via AMP (Application Management Panel) or any HTTP-capable admin console.

---

## Table of Contents

1. [Authentication](#authentication)
2. [Admin Commands Reference](#admin-commands-reference)
3. [Configuration Reference (appsettings.json)](#configuration-reference)
4. [Match Settings](#match-settings)
5. [Queue System](#queue-system)
6. [Economy & Shop](#economy--shop)
7. [Ranked System](#ranked-system)
8. [Common Operations & Examples](#common-operations--examples)
9. [AMP Analytics](#amp-analytics)
10. [Shop Asset IDs](#shop-asset-ids)

---

## Authentication

### Admin Levels

There are **two separate admin tiers**, depending on where the action happens:

| Tier | Scope | How it's checked | What you can do |
|------|-------|-----------------|----------------|
| **WS Admin** (Lobby) | WebSocket lobby control | Account ID match against `AdminAccountIds` | Force-start, change lobby settings, kick players — even when not the lobby leader |
| **HTTP Admin** (Full) | HTTP admin endpoints | Token-based (`ApiToken`) or Loopback trust | Grant/revoke admin, ban/unban, give gold/XP, manage shop items, view server state, read audit logs |

### Why two tiers?

- The game client connects via WebSocket and **cannot send custom HTTP headers** on the upgrade request.
- Therefore, WS admin can only verify the account ID (which the client supplies as `X-BAP-AccountId`). This is sufficient for lobby control, but *not* for economy/server-state changes.
- HTTP admin endpoints (`/admin/commands`, `/admin/state`, etc.) require the full `AdminAuth.IsAuthorized` check — either a valid `X-BAP-Admin-Token` or loopback trust.

### In-Game Dev Panel — separate client-side feature

The game's built-in Dev/Debug UI panels (DevPanel, In-Game Dev Commands, etc.) are **not controlled by the server at all**. The Melon mod (`BapCustomServerMelon.dll`) hides them by default via Harmony patches. To see them in a match, set in `BapCustomServer.ini`:

```ini
[Mod]
AllowDevPanel=true
```

To also have server admin privileges, list your account ID in the server config:

```json
"Admin": {
  "ApiToken": "",
  "AllowLoopbackAdminWithoutToken": true,
  "AdminAccountIds": ["dein-admin-account-id"]
}
```

> **Short version:** Server admin (`AdminAccountIds`) + `AllowDevPanel=true` in ini = full OP in a match. Only one without the other gives you either lobby control without dev UI, or dev UI without admin powers.

### Authentication Methods

---

## Admin Commands Reference

All commands are sent as **HTTP POST** to:

```
POST http://<server>:5183/admin/commands
Content-Type: application/json
```

Request body shape:
```json
{
  "command": "<command-name>",
  "accountId": "<target-account-id>",
  "reason": "<optional-reason>",
  "value": "<optional-value>",
  "settings": { }
}
```

### Player Management

| Command | Description | Required Fields |
|---------|-------------|-----------------|
| `grant-admin` | Give a player admin privileges | `accountId` |
| `revoke-admin` | Remove admin privileges | `accountId` |
| `ban` | Ban an account (kicks from active lobby) | `accountId`, optional `reason`, optional `value` (ISO8601 expiry) |
| `unban` | Unban an account | `accountId` |
| `kick` | Kick a player from their current lobby | `accountId`, optional `reason` |

### Economy

| Command | Description | Required Fields |
|---------|-------------|-----------------|
| `give-gold` | Add gold to a player's balance | `accountId`, `value` (integer amount) |
| `set-gold` | Set a player's gold to exact amount | `accountId`, `value` (integer amount) |
| `grant-asset` | Grant a cosmetic/asset to a player | `accountId`, `value` (asset ID) |
| `revoke-asset` | Remove a cosmetic/asset from a player | `accountId`, `value` (asset ID) |

### Shop Management

| Command | Description | Required Fields |
|---------|-------------|-----------------|
| `add-shop-item` | Add a purchasable item to the shop rotation | `value` (JSON: `{"listingId","assetId","price"}`) |
| `add-shop-freebie` | Add a free item to the shop | `value` (JSON: `{"listingId","assetId"}`) |
| `remove-shop-item` | Remove an item from the shop | `value` (listingId string) |
| `clear-shop` | Remove all items from the shop rotation | — |

### Ranked

| Command | Description | Required Fields |
|---------|-------------|-----------------|
| `ranked-reset` | Reset a player's ranked points to default | `accountId` |
| `ranked-set-points` | Set a player's ranked points | `accountId`, `value` (integer points) |

### Match & Lobby Management

| Command | Description | Required Fields |
|---------|-------------|-----------------|
| `list-lobbies` | Get all active lobbies | — |
| `list-matches` | Get all running game matches | — |
| `stop-match` | Force-stop a running game server match | `value` (gameId) |
| `set-lobby-settings` | Change lobby match settings live | `value` (lobbyId), `settings` (object) |

### Information

| Command | Description | Required Fields |
|---------|-------------|-----------------|
| `match-history` | Get last 20 completed matches | — |
| `queue-status` | Get current matchmaking queue state | — |
| `economy-leaderboard` | Get top 20 players by gold | — |

---

## Read-Only Admin Endpoints

| Endpoint | Method | Description |
|----------|--------|-------------|
| `/admin/state` | GET | Full admin state (admins list, bans list) |
| `/admin/logs/audit` | GET | Admin audit log (last N lines, `?tail=100`) |
| `/admin/lobbies` | GET | All active lobbies snapshot |
| `/admin/matches` | GET | All running matches snapshot |
| `/health` | GET | Server health check |

---

## Configuration Reference

The server is configured via `appsettings.json` (or environment variables with `__` separator).

```jsonc
{
  "CustomServer": {
    // Public URL the game client connects to (set by AMP)
    "PublicBaseUrl": "http://your-server-ip:5183",
    "PublicGameHost": "your-server-ip",

    // Game server process management
    "LaunchGameServers": true,
    "GameExecutablePath": "../Spiel/Battleroyalebuild/bapbap.exe",
    "GameWorkingDirectory": "../Spiel/Battleroyalebuild",
    "GameLogDirectory": "logs/game-servers",
    "HeadlessArguments": "-batchmode -nographics -logFile \"{logFile}\" -httpport={httpPort} -wsport={wsPort} -kcpport={kcpPort} -tcpport={tcpPort}",

    // Port ranges for spawned game servers
    "BaseHttpPort": 7850,
    "BaseWsPort": 7777,
    "BaseKcpPort": 7778,
    "BaseTcpPort": 7779,
    "PortSearchRange": 200,
    "GameServerReadyTimeoutSeconds": 30,

    // Admin settings
    "Admin": {
      "ApiToken": "",
      "AllowLoopbackAdminWithoutToken": true,
      "StateFile": "data/admin-state.json",
      "AuditLogFile": "logs/admin-audit.jsonl",
      "AdminAccountIds": [],
      "BannedAccountIds": []
    },

    // Cosmetic unlocks
    "Unlocks": {
      "UnlockEverything": true,
      "SkinAssetIdStart": 300000,
      "SkinAssetIdEnd": 300026,
      "CurrencyBalance": 999999
    },

    // Economy
    "Economy": {
      "StartingGold": 0,
      "StartingFractals": 1000,
      "StartingCharTokens": 999999
    },

    // Shop
    "Shop": {
      "RotationIntervalHours": 24
    },

    // Ranked
    "Ranked": {
      "StartingPoints": 1000,
      "WinPoints": 25,
      "LossPoints": -15,
      "PageSize": 50
    },

    // Matchmaking Queue
    "MatchmakingQueue": {
      "QueueTimerSeconds": 30,
      "MinPlayersToStart": 1,
      "DefaultBotCount": 4,
      "DefaultBotDifficulty": 1,
      "DefaultMapId": 1,
      "DefaultGameMode": 0,
      "DefaultMaxTeams": 8,
      "DefaultTeamSize": 1
    },

    // Match defaults (used when lobby leader starts a match)
    "MatchDefaults": {
      "RegionId": "custom",
      "UnityGameMode": 0,
      "MapId": 1,
      "TeamSize": 1,
      "MaxTeams": 8,
      "BotTeams": 0,
      "BotDifficulty": 1,
      "CharSelectMillis": 20000,
      "SpawnSelectMillis": 10000,
      "SpawnShowMillis": 3000,
      "AvailableCharacters": [0,1,2,3,4,5,6,7,8,9,10,11,12,13,14],
      "GameModifierIds": [],
      "DimensionData": [],
      "MapMapping": [
        { "UnityGameModeId": 0, "MapIds": [1] },
        { "UnityGameModeId": 1, "MapIds": [1] }
      ]
    }
  }
}
```

### Environment Variable Override Examples

```bash
# Set via environment (double underscore for nesting)
CustomServer__PublicBaseUrl=http://my-server.com:5183
CustomServer__Admin__ApiToken=my-secret-token
CustomServer__MatchDefaults__MaxTeams=16
CustomServer__LaunchGameServers=true
```

---

## Match Settings

When a lobby leader starts a match, the server uses `MatchDefaults` as the base configuration:

| Setting | Description | Default |
|---------|-------------|---------|
| `MapId` | Which map to play on (1 = default) | 1 |
| `TeamSize` | Players per team | 1 (solo) |
| `MaxTeams` | Maximum number of teams in a match | 8 |
| `BotTeams` | Number of AI bot teams to fill | 0 |
| `BotDifficulty` | Bot AI difficulty (1=easy, 2=medium, 3=hard) | 1 |
| `CharSelectMillis` | Character selection time (ms) | 20000 |
| `SpawnSelectMillis` | Spawn location selection time (ms) | 10000 |
| `AvailableCharacters` | Array of character IDs players can pick | All (0-14) |
| `GameModifierIds` | Active game modifiers (mutators) | None |
| `DimensionData` | Custom dimension round configs | None |

### Overriding Match Settings Per-Lobby

Use the `set-lobby-settings` admin command to change settings for a specific lobby:

```json
{
  "command": "set-lobby-settings",
  "value": "LOBBY_ID_HERE",
  "settings": {
    "maxTeams": 16,
    "botTeams": 4,
    "mapId": 2
  }
}
```

---

## Queue System

The matchmaking queue collects players and starts matches automatically when conditions are met.

### How It Works

1. Player calls `POST /api/queue/join` → enters the queue
2. Server waits `QueueTimerSeconds` (default 30s) after first player joins
3. When timer expires OR `MinPlayersToStart` reached, a match is created
4. Remaining slots are filled with bots (`DefaultBotCount`)
5. All queued players are placed into the match lobby

### Queue Configuration

| Setting | Description | Default |
|---------|-------------|---------|
| `QueueTimerSeconds` | Seconds to wait before starting with available players | 30 |
| `MinPlayersToStart` | Minimum human players to launch | 1 |
| `DefaultBotCount` | Bots to fill empty slots | 4 |
| `DefaultBotDifficulty` | Bot difficulty level | 1 |
| `DefaultMapId` | Map for queued matches | 1 |
| `DefaultGameMode` | Game mode for queued matches | 0 |
| `DefaultMaxTeams` | Max teams in queued matches | 8 |
| `DefaultTeamSize` | Team size in queued matches | 1 |

### Monitoring the Queue

```bash
# Via admin command
curl -X POST http://127.0.0.1:5183/admin/commands \
  -H "Content-Type: application/json" \
  -d '{"command":"queue-status"}'

# Via direct endpoint
curl http://127.0.0.1:5183/api/queue/status
```

---

## Economy & Shop

### Economy

Each player has:
- **Gold** — earned currency, used to buy shop items
- **Fractals** — premium currency (starts at 1000)
- **Char Tokens** — character unlock tokens (starts at 999999, everything unlocked)

### Shop

The shop serves a rotation of items purchasable with gold. Managed entirely via admin commands.

---

## Ranked System

Players start at 1000 points. Winning grants points, losing deducts them. The leaderboard is accessible at `/api/ranked/leaderboard`.

---

## Common Operations & Examples

### Ban a cheater

```bash
curl -X POST http://127.0.0.1:5183/admin/commands \
  -H "Content-Type: application/json" \
  -d '{
    "command": "ban",
    "accountId": "steam-12345678",
    "reason": "Cheating detected"
  }'
```

### Temporary ban (24 hours)

```bash
curl -X POST http://127.0.0.1:5183/admin/commands \
  -H "Content-Type: application/json" \
  -d '{
    "command": "ban",
    "accountId": "steam-12345678",
    "reason": "Toxic behavior",
    "value": "2025-01-16T00:00:00Z"
  }'
```

### Give a player 500 gold

```bash
curl -X POST http://127.0.0.1:5183/admin/commands \
  -H "Content-Type: application/json" \
  -d '{
    "command": "give-gold",
    "accountId": "steam-12345678",
    "value": "500"
  }'
```

### Add a skin to the shop for 200 gold

```bash
curl -X POST http://127.0.0.1:5183/admin/commands \
  -H "Content-Type: application/json" \
  -d '{
    "command": "add-shop-item",
    "value": "{\"listingId\":\"skin-ninja-01\",\"assetId\":300005,\"price\":200}"
  }'
```

### Add a free item (freebie) to the shop

```bash
curl -X POST http://127.0.0.1:5183/admin/commands \
  -H "Content-Type: application/json" \
  -d '{
    "command": "add-shop-freebie",
    "value": "{\"listingId\":\"welcome-gift\",\"assetId\":300001}"
  }'
```

### Remove a shop item

```bash
curl -X POST http://127.0.0.1:5183/admin/commands \
  -H "Content-Type: application/json" \
  -d '{
    "command": "remove-shop-item",
    "value": "skin-ninja-01"
  }'
```

### Set a player's ranked points

```bash
curl -X POST http://127.0.0.1:5183/admin/commands \
  -H "Content-Type: application/json" \
  -d '{
    "command": "ranked-set-points",
    "accountId": "steam-12345678",
    "value": "1500"
  }'
```

### Reset a player's rank

```bash
curl -X POST http://127.0.0.1:5183/admin/commands \
  -H "Content-Type: application/json" \
  -d '{
    "command": "ranked-reset",
    "accountId": "steam-12345678"
  }'
```

### View all active lobbies

```bash
curl -X POST http://127.0.0.1:5183/admin/commands \
  -H "Content-Type: application/json" \
  -d '{"command":"list-lobbies"}'
```

### Force-stop a match

```bash
curl -X POST http://127.0.0.1:5183/admin/commands \
  -H "Content-Type: application/json" \
  -d '{
    "command": "stop-match",
    "value": "game-id-here"
  }'
```

### Grant admin to a player

```bash
curl -X POST http://127.0.0.1:5183/admin/commands \
  -H "Content-Type: application/json" \
  -d '{
    "command": "grant-admin",
    "accountId": "steam-12345678"
  }'
```

### View economy leaderboard

```bash
curl -X POST http://127.0.0.1:5183/admin/commands \
  -H "Content-Type: application/json" \
  -d '{"command":"economy-leaderboard"}'
```

### Check audit log

```bash
curl "http://127.0.0.1:5183/admin/logs/audit?tail=50"
```

---

## AMP Console Integration

In AMP, configure a **Generic Module** or **custom application** with:

- **Start command**: `dotnet BapCustomServer.dll`
- **Working directory**: The server installation folder
- **Environment variables**: Set `ASPNETCORE_URLS=http://0.0.0.0:5183`
- **Console input**: AMP can send HTTP POST requests to `http://127.0.0.1:5183/admin/commands`

For AMP's console/scheduler, you can create scheduled tasks that POST to the admin endpoint:

```powershell
# PowerShell example for AMP scheduled task
Invoke-RestMethod -Uri "http://127.0.0.1:5183/admin/commands" `
  -Method Post -ContentType "application/json" `
  -Body '{"command":"clear-shop"}'
```

### Health Monitoring

AMP can poll `/health` to verify the server is running:

```
GET http://127.0.0.1:5183/health
→ {"ok":true}
```

---

## AMP Analytics

The server emits structured log lines that AMP's built-in `AnalyticsPlugin` scrapes directly from the ASP.NET Core console — no extra agent or sidecar process. The Generic-module template (`bapcustomservergithub.kvp`) wires them up via:

```text
GenericModule.App.OnlineRegex=^\[Analytics\] Player joined: (?<Username>[^ ]+) \(accountId=(?<UID>[^)]+)\)$
GenericModule.App.OfflineRegex=^\[Analytics\] Player left: (?<Username>[^ ]+) \(accountId=(?<UID>[^)]+)\)$
GenericModule.App.UserNameMatchGroup=Username
GenericModule.App.UserIDMatchGroup=UID
```

Matching server log lines (emitted by `ILogger` at Information level):

```text
[Analytics] Player joined: <username> (accountId=<id>)
[Analytics] Player left:   <username> (accountId=<id>)
[Analytics] Match started: <gameId> mapId=<n> players=<n>
[Analytics] Match ended:   <gameId>
```

Operator notes:

- **Player count graph**: AMP UI → instance → `Status` tab → live `Active Users` count and the historical `Player count` graph under `Performance & Metrics`. The current player list also shows under `Manage Users`.
- **Match metrics**: AMP records every `Match started` / `Match ended` pair against the instance metrics; visible under the `Analytics` panel if your AMP license includes it.
- **Disable analytics**: set `CustomServer:Analytics:Enabled=false` in the instance config (or unset `OnlineRegex` / `OfflineRegex` in the AMP `kvp`) and restart. The server still functions; AMP just stops counting users.
- **Privacy**: only the chosen `Username` and `accountId` reach AMP. Nothing is sent off-host.

---

## Shop Asset IDs

The four AMP Shop slot fields (`ShopSlot1AssetId`, `ShopSlot2AssetId`, `ShopSlot3AssetId`, `ShopFreebieAssetId`) are **free-form numeric inputs** as of this release — earlier builds shipped a stale enum dropdown.

The authoritative ID list lives at the workspace root in `BAPBAP-Asset-Reference.md`, generated from `data/asset-index.json` via `tools\Generate-AssetReference.ps1`. It groups every shop-eligible asset (skins, banners, emotes, mastery badges, tombstones) by category with both display name and raw asset name. Treat it as the source of truth.

> ⚠️ **Do not** assign AssetIds `300001`, `300004`, or `300006` to any shop slot. Those entries crash the in-game locker UI the moment a player opens it. Any other ID from the reference file is safe.

---

## File Locations

| File | Purpose |
|------|---------|
| `data/admin-state.json` | Persistent admin/ban state |
| `logs/admin-audit.jsonl` | Admin action audit trail |
| `data/economy-state.json` | Player gold/assets |
| `data/shop-state.json` | Current shop rotation |
| `data/ranked-state.json` | Ranked points/leaderboard |
| `data/friends-state.json` | Friends list/requests |
| `logs/match-history.jsonl` | Completed match records |
| `logs/game-servers/` | Individual game server stdout logs |

---

## Troubleshooting

- **Players stuck on loading screen**: Check MelonLoader log for NullRef in `UILobbyCharacterSelectPage`. The mod patches this but some edge cases remain.
- **WebSocket connection error**: Ensure the game client's INI has the correct `Host` and `Port`.
- **Game server won't start**: Verify `GameExecutablePath` points to the correct `bapbap.exe` and `LaunchGameServers` is `true`.
- **Admin commands return 401**: Check that `ApiToken` matches or request is from loopback with `AllowLoopbackAdminWithoutToken=true`.
