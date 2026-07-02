# BAPBAP Custom Server — Cosmetics & Admin Reference

## Cosmetic Asset ID Ranges

All cosmetic items use an offset-based ID system: `base_offset + index`.

### Skins (Base: 300000)

The SkinData asset contains 27 skin slots (indices 0–26). Default range: `300000`–`300026`.

| Index | Asset ID | Name |
|-------|----------|------|
| 0 | 300000 | Anna Default |
| 1 | 300001 | *(empty slot)* |
| 2 | 300002 | Anna Test BackwardsCap |
| 3 | 300003 | Bishop Default |
| 4 | 300004 | *(empty slot)* |
| 5 | 300005 | Celeste Default |
| 6 | 300006 | *(empty slot)* |
| 7 | 300007 | Chuck Default |
| 8 | 300008 | Chuck Test Gold |
| 9 | 300009 | Chuck Test Grimace |
| 10 | 300010 | Chuck Test Rice |
| 11 | 300011 | Chuck Test Swag |
| 12 | 300012 | Froggy Blinged |
| 13 | 300013 | Froggy Default |
| 14 | 300014 | Froggy Test Round |
| 15 | 300015 | Jiro Default |
| 16 | 300016 | Kate Default |
| 17 | 300017 | Kiddo Default |
| 18 | 300018 | Kitsu Default |
| 19 | 300019 | Rocky Default |
| 20 | 300020 | Sashimi Default |
| 21 | 300021 | Skinny Default |
| 22 | 300022 | Sofia Clownfia |
| 23 | 300023 | Sofia Default |
| 24 | 300024 | Sofia Test Shadow |
| 25 | 300025 | Teevee Default |
| 26 | 300026 | Zook Default |

> **Note:** Empty slots (index 1, 4, 6) have null references in SkinData and should not be sent to clients.

### Banners (Base: 500000)

Player banners use base offset `500000`. There are **89** banner assets in the game data.
Default config range: `500000`–`500088`.

Notable banners include character banners (Anna, Chuck, Froggy, Jiro, Kiddo, Kitsu, Sashimi, Skinny, Sofia, Teevee, Zook), scene banners (BAPBounty, BlazeBandit, DuckLobby, DuckyRun, SupplyDrop), and variants (Gold, Holo) plus 8 default banners.

### Tombstones (Base: 700000)

Tombstone markers use base offset `700000`. There are **11** tombstone assets.
Default config range: `700000`–`700010`.

| Index | Asset ID | Name |
|-------|----------|------|
| 0 | 700000 | Tombstone (Default) |
| 1 | 700001 | Arcade Machine |
| 2 | 700002 | Bao |
| 3 | 700003 | Beta Tombstone |
| 4 | 700004 | Large Tombstone |
| 5 | 700005 | Mini Chuck Statue |
| 6 | 700006 | Street Cone |
| 7 | 700007 | Tire Club Prez |
| 8 | 700008 | Wing Tombstone |
| 9 | 700009 | Wooden Cross |
| 10 | 700010 | Wooden Plank |

### Mastery Badges (Base: 600000)

Mastery badges use base offset `600000`. There are **99** badge assets (9 characters × 3 tiers × 3 divisions + extras).
Default config range: `600000`–`600098`.

Characters with mastery badges: Anna, Chuck, Froggy, Jiro, Kiddo, Kitsu, Sashimi, Skinny, Sofia, Teevee, Zook.

Each character has badges in the format: `{Character}_T{tier}_D{division}` where tier = 1–3, division = 1–3.

### Emotes (Base: 400000)

Emote stickers use base offset `400000`. There are **29** emote entries in EmoteData.
Theoretical range: `400000`–`400028`.

> **⚠️ WARNING:** Emotes are currently **disabled by default** (`EmoteAssetIdStart = -1`). Sending non-existent emote IDs causes a `NullReferenceException` in the client's `EmoteData.GetEmoteByAssetId`. Only enable if you know exactly which IDs exist in your game build.

---

## Currency IDs

| ID | Currency | Description |
|----|----------|-------------|
| 1 | Gold | Primary currency, earned from matches |
| 2 | Fractals | Premium currency |
| 3 | CharTokens | Character unlock tokens |
| 4 | *(Reserved)* | Additional currency slot |
| 5 | *(Reserved)* | Additional currency slot |

Default balance when `UnlockEverything = true`: **999,999** for all currencies.

---

## Admin Commands

Admin commands are sent via `POST /api/admin/command` with JSON body:
```json
{
  "command": "command-name",
  "accountId": "target-account-id",
  "reason": "parameter-or-reason",
  "actor": "admin-account-id"
}
```

### Economy Commands

| Command | AccountId | Reason | Description |
|---------|-----------|--------|-------------|
| `give-gold` | Required | Amount (e.g. `"500"`) | Add gold to player's balance |
| `set-gold` | Required | Amount (e.g. `"10000"`) | Set player's gold to exact amount |
| `grant-asset` | Required | Asset ID (e.g. `"300005"`) | Grant ownership of a cosmetic asset |
| `revoke-asset` | Required | Asset ID (e.g. `"300005"`) | Remove ownership of a cosmetic asset |
| `economy-leaderboard` | — | — | View top 20 players by gold |

**Examples:**
```json
{"command": "give-gold", "accountId": "steam_12345", "reason": "1000"}
{"command": "set-gold", "accountId": "steam_12345", "reason": "50000"}
{"command": "grant-asset", "accountId": "steam_12345", "reason": "300012"}
{"command": "revoke-asset", "accountId": "steam_12345", "reason": "700005"}
```

### Shop Commands

| Command | Reason | Description |
|---------|--------|-------------|
| `add-shop-item` | `"assetId:price"` (e.g. `"300005:500"`) | Add a priced item to the shop rotation |
| `add-shop-freebie` | Asset ID (e.g. `"300005"`) | Add a free item to the shop |
| `remove-shop-item` | Listing ID (e.g. `"shop-rotation-300005"`) | Remove an item from the shop |
| `clear-shop` | — | Remove all items from the shop |

**Examples:**
```json
{"command": "add-shop-item", "reason": "300012:750"}
{"command": "add-shop-item", "reason": "700003:200"}
{"command": "add-shop-freebie", "reason": "300000"}
{"command": "remove-shop-item", "reason": "shop-rotation-300012"}
{"command": "clear-shop"}
```

### Ranked Commands

| Command | AccountId | Reason | Description |
|---------|-----------|--------|-------------|
| `ranked-reset` | Required | — | Reset a player's ranked state to starting points |
| `ranked-set-points` | Required | Points value (e.g. `"2500"`) | Set a player's ranked points directly |

**Examples:**
```json
{"command": "ranked-reset", "accountId": "steam_12345"}
{"command": "ranked-set-points", "accountId": "steam_12345", "reason": "3000"}
```

### Other Admin Commands

| Command | Description |
|---------|-------------|
| `list-lobbies` | Snapshot of all active lobbies |
| `list-matches` | Snapshot of all running game server instances |
| `match-history` | View last 20 recorded matches |
| `queue-status` | View matchmaking queue status |

---

## Ranked System

The ranked system awards or deducts points after each match based on placement and kills.

### Rank Tiers

Every 500 points = a new tier (capped at Master):

| Tier | Name | Points Range |
|------|------|-------------|
| 0 | Unranked | 0–499 |
| 1 | Bronze | 500–999 |
| 2 | Silver | 1000–1499 |
| 3 | Gold | 1500–1999 |
| 4 | Platinum | 2000–2499 |
| 5 | Diamond | 2500–2999 |
| 6 | Master | 3000+ |

### How Points Are Calculated

After each match, the server calls `RankedService.ProcessMatchResult(accountId, username, placement, kills, totalPlayers)`:

- **Placement bonus/penalty:** Based on where you finished relative to total players. Higher placements earn more points; lower placements lose points.
- **Kill bonus:** Additional points per kill.
- **Promotion/Demotion:** Crossing a 500-point tier boundary triggers a promotion (upward) or demotion (downward) flag in the result.

### Match Rewards (Economy)

When a game ends, `EconomyService.CalculateMatchReward` determines gold earned:
- Factors in placement, kills, and total players.
- Rewards are applied automatically via `ApplyMatchRewards`.

### Integration Flow

1. Game server sends `game-ended` event with `GameId`
2. Custom server stops the match process
3. `ApplyMatchEndRewards` is called:
   - Records a `MatchHistoryEntry` with all player stats
   - Calculates and applies gold rewards per player via `EconomyService`
   - Calculates and applies ranked point changes via `RankedService`

---

## Configuration (appsettings.json)

Key cosmetic settings in `CustomServerOptions.Cosmetics`:

```json
{
  "Cosmetics": {
    "UnlockEverything": true,
    "SkinAssetIdStart": 300000,
    "SkinAssetIdEnd": 300026,
    "EmoteAssetIdStart": -1,
    "EmoteAssetIdEnd": -1,
    "BannerAssetIdStart": 500000,
    "BannerAssetIdEnd": 500088,
    "MasteryBadgeAssetIdStart": 600000,
    "MasteryBadgeAssetIdEnd": 600098,
    "TombstoneAssetIdStart": 700000,
    "TombstoneAssetIdEnd": 700010,
    "CurrencyAssetIds": [1, 2, 3, 4, 5],
    "CurrencyBalance": 999999
  }
}
```

Set `UnlockEverything: false` to use the economy system for unlocking items through the shop. When `true`, all items in the configured ranges are reported as owned with max balance.
