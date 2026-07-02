# BAPBAP Custom Server — Match Dev Settings & Game Configuration

> For AMP server operators. These settings control match behavior.

---

## Match Settings (Configurable per Lobby via Admin Commands)

These are sent to the game server when a match starts:

| Setting | Type | Description | Default |
|---------|------|-------------|---------|
| `mapId` | int | Map to play on | 1 |
| `gamemode` | int | Unity game mode | 0 |
| `teamSize` | int | Players per team (1=solo, 2=duo, 3=trio) | 1 |
| `maxTeams` | int | Maximum teams in match | 8 |
| `botCount` | int | Number of bot teams | 0 |
| `botDifficulty` | int | Bot AI level (0-4) | 1 |
| `charSelectMillis` | int | Character selection time (ms) | 20000 |
| `spawnSelectMillis` | int | Spawn point selection time (ms) | 10000 |
| `spawnShowMillis` | int | Spawn show animation time (ms) | 3000 |
| `gameModifierIds` | int[] | Active game modifiers | [] |
| `matchmakingGameMode` | int | Mode for matchmaking score table | 0 |

---

## Maps

| MapId | Internal Name | Description |
|-------|---------------|-------------|
| 1 | Map2_BazaarCity 3 | BazaarCity (Default) |
| 2 | Map3_Lyceum | Lyceum (Indoor/Medium) |
| 3 | Arena_Map2 | Arena (Small/Fast) |
| 4 | OpenBetaMap#J02_P_Boccato | Open Beta Map |

---

## Game Modes (Unity Internal)

| GameMode ID | Description |
|-------------|-------------|
| 0 | Battle Royale (Default FFA) |
| 1 | Battle Royale (Standard) |
| 2 | Battle Royale (Duos/Trios) |
| 3+ | Variants / Minigames |

---

## Bot Difficulty

| Value | Name | Behavior |
|-------|------|----------|
| 0 | Easy | Slow reactions, poor aim |
| 1 | Normal | Standard AI |
| 2 | Medium | Faster reactions, better positioning |
| 3 | Hard | Aggressive, good aim |
| 4 | Expert | Near-perfect aim, optimal pathing |

---

## Zone (Battle Royale Circle) Settings

These are baked into the game's `GameModeBattleRoyale` class and **not configurable via server settings** (they're hardcoded in Unity prefabs). Key zone parameters:

| Parameter | Description |
|-----------|-------------|
| `secondsUntilZoneStart` | Seconds before zone starts moving |
| `secondsZoneMoveDuration` | How long the zone takes to close |
| `closePercentage` | % the zone shrinks to (0-100) |
| `damagePercentage` | Zone damage per tick (0-100% of base) |
| `zoneDamageRate` | Ticks per second for zone damage |
| `closedZoneWaitTime` | Seconds after zone fully closes before match ends |

Zone rounds progress: `WaitingForFirstZone → WaitingToStartZone → ClosingZone → AllZonesEnded`

The zone scales dynamically based on player count via `untilStartPlayerFactorInfluence` and `moveDurationPlayerFactorInfluence`.

---

## In-Game Dev/Debug Commands

These are Mirror networking commands available to admin-flagged players via the game's built-in debug console. They require `isAdmin=true` in the LoadResponse.

### Match Control
| Command | Description |
|---------|-------------|
| `TryEndMatch()` | Force-end the current match |
| `LobbyForceStartMatch()` | Force-start from dev lobby |
| `ZoneEnabledToggle()` | Enable/disable the zone |
| `ZoneNext()` | Skip to next zone round |
| `ZoneRestart()` | Restart current zone |
| `SlowMotionToggle()` | Toggle slow-motion |
| `Unpause()` | Unpause the game |

### Player/Bot Debug
| Command | Description |
|---------|-------------|
| `SetInvincibilityMode(bool)` | Toggle invincibility for self |
| `SetInvincibilityModeAll(bool)` | Toggle invincibility for all |
| `SetNoCooldownMode(bool)` | No ability cooldowns |
| `SetNoCooldownModeAll(bool)` | No cooldowns for all |
| `SetNoClip(bool)` | Toggle noclip (fly through walls) |
| `SetNoAggro(bool)` | Bots ignore you |
| `SetNoAggroAll(bool)` | Bots ignore everyone |
| `CharKillCurrent()` | Kill your own character |
| `CharKillAll()` | Kill all characters |
| `RespawnCharacter()` | Respawn your character |
| `RespawnDeadCharacterAll()` | Respawn all dead characters |
| `HealMaxHpAll()` | Full heal everyone |
| `SpawnBot4(charId, enableAI, isAlly, isInvincible)` | Spawn a bot |
| `SpawnBotChar(charId, enableAI, isAlly, isInvincible, difficulty)` | Spawn bot with difficulty |

### UI/Visual Debug
| Command | Description |
|---------|-------------|
| `UIAllToggle()` | Toggle all UI on/off |
| `UIToggleMinimap()` | Toggle minimap |
| `UIHpBarsToggle()` | Toggle HP bars |
| `UIToggleRecordingMode()` | Clean screen for recording |
| `HitboxDebug()` | Show hitboxes |
| `CharacterMeshToggle()` | Toggle character visibility |
| `ToggleNavmeshVisibility()` | Show AI navigation mesh |
| `SetFoWToggle()` | Toggle fog of war |

### Game Modifiers (Mutators)
| Command | Description |
|---------|-------------|
| `AddGameModifier(int id)` | Activate a game modifier |
| `RemoveGameModifier(int id)` | Deactivate a game modifier |
| `AddAugmentSelection()` | Give augment selection |

### Items/World
| Command | Description |
|---------|-------------|
| `ClearWorldItems()` | Remove all items from the world |
| `ClearWorldTombstones()` | Remove all tombstones |
| `ResetAllEntities()` | Reset all entities to initial state |
| `SpawnBrEvent(int id)` | Spawn a Battle Royale event (supply drops etc.) |

---

## Server-Side appsettings.json Match Config

```json
{
  "CustomServer": {
    "MatchDefaults": {
      "RegionId": "custom",
      "UnityGameMode": 0,
      "MatchmakingGameMode": 0,
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
        {"UnityGameModeId": 0, "MapIds": [1]},
        {"UnityGameModeId": 1, "MapIds": [1,2,3]}
      ]
    },
    "MatchmakingQueue": {
      "QueueTimerSeconds": 30,
      "MinPlayersToStart": 1,
      "DefaultBotCount": 4,
      "DefaultBotDifficulty": 1,
      "DefaultMapId": 1,
      "DefaultGameMode": 0,
      "DefaultMaxTeams": 8,
      "DefaultTeamSize": 1
    }
  }
}
```

---

## Ranked Score Table (Post-Match Points)

The server calculates ranked points after each match:

```
Points = PlacementPoints[placement-1] + (kills × KillPoints) + LossPoints (if eliminated early)
```

Default configuration:
```json
{
  "Ranked": {
    "StartingPoints": 1000,
    "PlacementPoints": [100, 70, 50, 40, 30, 20, 15, 10],
    "KillPoints": 15,
    "MinPointsFloor": 0,
    "LossPoints": -20
  }
}
```

| Placement | Points Awarded |
|-----------|---------------|
| 1st | +100 |
| 2nd | +70 |
| 3rd | +50 |
| 4th | +40 |
| 5th | +30 |
| 6th | +20 |
| 7th | +15 |
| 8th | +10 |
| 9th+ | -20 (LossPoints) |

Plus: **+15 per kill**

---

## Economy (Match Gold Rewards)

```json
{
  "Economy": {
    "StartingGold": 1000,
    "WinGold": 500,
    "KillGold": 50,
    "PlacementGold": [500, 350, 250, 200, 150, 100, 75, 50],
    "ParticipationGold": 25
  }
}
```

| Placement | Gold Earned |
|-----------|-------------|
| 1st | 500 + (kills×50) + 25 |
| 2nd | 350 + (kills×50) + 25 |
| 3rd | 250 + (kills×50) + 25 |
| 8th | 50 + (kills×50) + 25 |

---

## Changing Settings via Admin Command (AMP Console)

### Change default match settings:
```bash
# Set map to Lyceum for all new matches
curl -X POST http://127.0.0.1:5183/admin/commands \
  -H "Content-Type: application/json" \
  -d '{"command":"set-lobby-settings","lobbyId":"LOBBY_ID","settings":{"mapId":2,"botCount":4,"botDifficulty":2}}'
```

### Set economy rewards:
Edit `appsettings.json` and restart, or use environment variables:
```bash
CustomServer__Economy__WinGold=1000
CustomServer__Economy__KillGold=100
CustomServer__Economy__ParticipationGold=50
```

### Set ranked rewards:
```bash
CustomServer__Ranked__KillPoints=25
CustomServer__Ranked__PlacementPoints__0=200  # 1st place
CustomServer__Ranked__PlacementPoints__1=150  # 2nd place
```

---

## Characters (IDs)

| CharId | Character Name |
|--------|---------------|
| 0 | (Reserved) |
| 1 | Anna |
| 2 | Bishop |
| 3 | Celeste |
| 4 | Chuck |
| 5 | Froggy/Zook |
| 6 | Jiro |
| 7 | Kate |
| 8 | Kiddo/Teevee |
| 9 | Kitsu |
| 10 | Rocky |
| 11 | Sashimi/Spriest |
| 12 | Skinny/IceMage |
| 13 | Sofia |
| 14 | Tombstone |

Known internal char ID constants:
- `AnnaCharId = 1`
- `ZookCharId = 5`
- `TeeveeCharId = 8`
- `SpriestCharId = 11`
- `IceMageCharId = 12`
