# B6 — Native game fallback logic for unknown/missing character data

Scope: the NATIVE game path that produces Skinny/Kitsu/Char0 when a charId is
unregistered/missing. READ-ONLY research. No code/build/deploy changed.

Primary sources (all under `C:\Users\Administrator\Downloads\BAPBAPModdingAPI\BAPBAPModAPI\reverse-engineering`):
- `dumps\latest\dump.cs` (Latest depot 2226283, the build that ships Medusa assets)
- `dumps\il2cppdumper\dump.cs` (older "Battleroyale" build)
- `decompiled\Assembly-CSharp\Il2CppBAPBAP\...` (Il2CppInterop wrappers — signatures only, no bodies)
- `ida-project\hexrays_bapbap.c` (native decompiled bodies — partial coverage)
- `research\CHARACTERS_RESEARCH.md`, `docs\gamedata\CHARACTERS.md`, `dumps\latest\medusa\ABILITY_MANIFEST.md`

---

## TL;DR (answers to the B6 deliverable questions)

- **file:line of the native default-character path when a charId is unregistered:**
  There is **no explicit "default character" branch**. The default is an
  *implicit consequence of two facts*:
  1. `UICharactersConfiguration.TryGetCharConfigByCharId` is a linear
     `config.charId == charId` match that returns `false`/`null` on miss — it
     does **not** substitute index 0.
     Evidence: `ida-project\hexrays_bapbap.c:711-718`
     (`..._TryGetCharConfigByCharId_b__0` → `return config->fields.charId == this->fields.charId;`).
  2. The spawn path indexes `GameNetworkManager.characterPrefabsByCharId[charId]`
     directly, and `PlayerManager.charId` / `EntityManager.charId` are
     `[SyncVar] int` whose **uninitialised/rejected value is 0**.
- **which index is the default (0? Skinny? Kitsu?):** **Index 0.** In the
  **Latest** build index 0 is **Kitsu** — `GameNetworkManager.KitsuCharId = 0`
  (`dumps\latest\dump.cs:127585`). This is NEW; the older build had no named
  charId 0 (`dumps\il2cppdumper\dump.cs:118993` starts at `AnnaCharId = 1`).
  This single rename is the direct, decisive reason the fallback now renders
  **Kitsu** specifically.
- **how the prefab table is indexed:** `GameObject[] characterPrefabsByCharId`
  indexed **by charId** (not by roster slot). A parallel `CharacterConfiguration[]
  _characters` (UI data) is looked up by charId via linear search. Bots use
  `GameNetworkManager.GetCharacterBotPrefab(charId, BotDifficulty)`.
- **why fallback yields Kitsu/Skinny:** Kitsu = charId 0 in the Latest build, so
  any unresolved/zeroed charId → `characterPrefabsByCharId[0]` = Kitsu. "Skinny"
  is a secondary/older-build artifact (see §5, lower confidence).

---

## 1. The roster registry & lookup (UICharactersConfiguration)

Decompiled wrapper: `decompiled\Assembly-CSharp\Il2CppBAPBAP\UI\UICharactersConfiguration.cs`
Fields (confirmed in that file + `research\CHARACTERS_RESEARCH.md` §2.2):
- `_characters` : `CharacterConfiguration[]` — full roster, keyed by `charId`
- `_lobbyCharacters` : `CharacterConfiguration[]` — public-queue subset, keyed by **index**
- `_lobbyAvailableCharacterIds` : `int[]` — server-pushed eligibility filter
Methods:
- `TryGetCharConfigByCharId(int charId, out CharacterConfiguration config)` (RVA 0x421F70)
- `TryGetLobbyCharConfigByIndex(int charIndex, out CharacterConfiguration config)` (RVA 0x4220B0)
- `UpdateAvailableCharacterList(int[] newCharacters)` (RVA 0x422150)

**Native body of the lookup predicate** (the real fallback evidence):
`ida-project\hexrays_bapbap.c:710-718`
```c
//===== BAPBAP.UI.UICharactersConfiguration.__c__DisplayClass9_0$$_TryGetCharConfigByCharId_b__0 @ 0x103d9020 =====
bool ..._TryGetCharConfigByCharId_b__0(... config, ...) {
    if ( !config ) ...
    return config->fields.charId == this->fields.charId;   // linear charId equality
}
```
=> `TryGetCharConfigByCharId` is a `FirstOrDefault(c => c.charId == charId)`. On a
miss it yields `null` and the bool return is `false`. **No index-0 substitution
happens here.** Whatever "default character" the player sees is decided by the
*caller* using the raw `charId` value, not by this method.

`CharacterConfiguration.charId` lives at field offset 0x10
(`research\CHARACTERS_RESEARCH.md` §2.1; `decompiled\...\UICharactersConfiguration.cs`
`CharacterConfiguration` nested class). Confidence: **High**.

## 2. The prefab table is charId-indexed; default value is 0

`GameNetworkManager` (Latest `dumps\latest\dump.cs:127580+`, TypeDefIndex 3346;
older `dumps\il2cppdumper\dump.cs:118990+`, TypeDefIndex 3100):
- `public GameObject[] characterPrefabsByCharId;` (master spawn table, indexed by charId)
- `private CharacterBotPrefabs[] charBotPrefabsByCharId;`
- `public GameObject GetCharacterBotPrefab(int charId, BotDifficulty)` (RVA 0x809E90)
(Field list cross-documented in `research\CHARACTERS_RESEARCH.md` §3.1.)

`PlayerManager.charId` is `[SyncVar(hook="OnCharacterChanged")] int` @ 0xAC and
`EntityManager.charId` is `[SyncVar] int` @ 0x118
(`research\CHARACTERS_RESEARCH.md` §4.3 / §4.4). A C# `int` SyncVar defaults to
**0**. So if the server never assigns a valid charId for the "Medusa" player
(because charId 15 is not registered / is rejected — see §4), the value stays 0
and `characterPrefabsByCharId[0]` is spawned. Confidence: **High** (mechanism),
**Med-High** (that this is the exact trigger in the live AMP repro).

## 3. THE decisive datum: charId 0 = Kitsu in the Latest build

`dumps\latest\dump.cs:127585-127590`
```csharp
public const int KitsuCharId   = 0;   // <-- index 0 == Kitsu (NEW in Latest)
public const int AnnaCharId    = 1;
public const int ZookCharId    = 5;
public const int TeeveeCharId  = 8;
public const int SpriestCharId = 11;
public const int EveCharId     = 12;  // (was IceMageCharId in older build)
```
Older build for contrast — `dumps\il2cppdumper\dump.cs:118993-118997`:
```csharp
public const int AnnaCharId    = 1;
public const int ZookCharId    = 5;
public const int TeeveeCharId  = 8;
public const int SpriestCharId = 11;
public const int IceMageCharId = 12;   // NO KitsuCharId / no named charId 0
```
=> The Latest build explicitly pins **Kitsu to charId 0**. Because 0 is also the
default int value of the `charId` SyncVar and the natural `[0]` index of
`characterPrefabsByCharId`, **any unresolved character collapses to Kitsu**.
This is the precise, exact-line reason "abilities render as Kitsu FX" and the
body appears as Kitsu. Confidence: **High**.

Note: `docs\gamedata\CHARACTERS.md` §4 documents the *older* build's
`_characters` array order as slot0=Chuck, slot1=Anna, slot2=Zook, slot3=Kitsu,
slot4=Sashimi, slot5=Kiddo, slot6=Skinny... and §5 lists trailing **placeholder**
codenames `Spriest, Icemage, Kate, Rocky, The Stoner` with no ability keys. That
roster-slot ordering is NOT the same axis as charId; do not conflate them
(the doc warns this explicitly). The authoritative spawn axis is charId, and
charId 0 = Kitsu in Latest.

## 4. Pre-match assignment / selection path (why charId 15 never "sticks")

`decompiled\Assembly-CSharp\Il2CppBAPBAP\Game\PreMatchManager.cs`:
- `_currentSelectedCharacters` : `Dictionary<int,int>` (playerId → charId)
- `AssignCharacters()` (RVA token 100672711)
- `TrySelectCharacter(PlayerManager player, int requestedCharId)` (token 100672719)
- `TryLockCharacter(PlayerManager)`, `AssignSpawnLocations()`

Native predicate bodies present in IDA:
- `ida-project\hexrays_bapbap.c:4583-4593` `..._AssignCharacters_b__10_0`:
  `return !playerPreMatch->fields.LockedCharacter;` (selects players who have NOT
  locked a character — those get an auto-assigned one).
- The lobby selection command `PlayerDeveloperLobby.CmdSelectCharacter(int)` is a
  Mirror `[Command]` validated server-side against `_lobbyAvailableCharacterIds`
  (`research\CHARACTERS_RESEARCH.md` §4.1 / §7). A charId (15/Medusa) not present
  in that list is rejected server-side; the SyncVar is never written, so charId
  stays at its default **0** → Kitsu.

Hypothesis (Med confidence): on the custom server, the Medusa charId is pushed
to clients that lack a `characterPrefabsByCharId[15]` / `_characters[charId==15]`
entry, so either (a) the select is validated away and charId stays 0, or (b) the
EntityManager spawns with charId defaulting to 0. Either way → Kitsu (charId 0).
The visible "green lines + Kitsu FX" are then Kitsu's real ability VFX, because
the spawned body literally *is* Kitsu (charId 0), not a half-built Medusa.

## 5. Why "Skinny" specifically appears (secondary, lower confidence)

Medusa research confirms Medusa is asset-only with **zero** ability components
and **no** `_characters`/`characterPrefabsByCharId` entry referencing
`Medusa.prefab` (`dumps\latest\medusa\ABILITY_MANIFEST.md` §1.3:
"Medusa's `CharAbilities.abilities` populates to a zero-length array";
"no `UICharactersConfiguration` entry references `Medusa.prefab`'s GUID").

"Skinny" is **unmapped** to any named charId constant in either dump (grep of
both dump.cs for `*CharId = N` returns only 0/Kitsu,1,5,8,11,12). In the older
build's `_characters` roster, Skinny sits at slot 6 (`docs\gamedata\CHARACTERS.md`
§4). Plausible causes for a Skinny rather than Kitsu appearance:
- **Bot-fill path:** `GameMode.SpawnBotChar(... int charId = -1 ...)`
  (`decompiled\...\Game\GameMode.cs`, tokens 100672192-194). A `charId = -1`
  default routed through a clamp/modulo into the bot prefab table could land on a
  non-zero slot.
- **Build/roster skew:** if a client's `_characters` ordering differs from the
  server's charId map (mod injected an entry, shifting indices), an index-vs-charId
  mismatch can resolve to whichever character occupies the collided slot (Skinny
  at slot 6 in the legacy ordering).
Confidence: **Low** for the exact Skinny cause; **High** that it is the same
"unresolved charId → table-indexed default" family of bug as the Kitsu case.

## 6. How the prefab table is indexed (summary)

```
PlayerManager.charId (SyncVar, default 0)
        │  (server-authoritative; rejected/unknown → stays 0)
        ▼
GameNetworkManager.characterPrefabsByCharId[charId]   // direct array index, charId axis
        │   charId 0  ==  Kitsu   (Latest: KitsuCharId = 0)
        ▼
NetworkPrefabPool.Spawn(prefab, …)  → EntityManager(charId)  → CharAbilities builds
        from the *spawned prefab's* 4 Ability child-GOs (= Kitsu's abilities/VFX)

UI side (parallel): UICharactersConfiguration.TryGetCharConfigByCharId(charId)
        = linear c.charId==charId; miss → null (NO index-0 fallback here)
Lobby side: TryGetLobbyCharConfigByIndex(charIndex)  = by INDEX into _lobbyCharacters
```

## 7. Confidence table

| Claim | Confidence | Key evidence |
|---|---|---|
| Default index is 0 | High | SyncVar int default 0; `characterPrefabsByCharId[charId]` direct index |
| charId 0 == Kitsu (Latest) | High | `dumps\latest\dump.cs:127585` `KitsuCharId = 0` |
| Older build had no named charId 0 | High | `dumps\il2cppdumper\dump.cs:118993` starts at Anna=1 |
| TryGetCharConfigByCharId has no index-0 fallback | High | `hexrays_bapbap.c:711-718` linear `charId==charId` |
| Medusa/charId 15 not registered → collapses to 0 | Med-High | `medusa\ABILITY_MANIFEST.md` §1.3; SyncVar default |
| "Skinny" exact cause | Low | bot `charId=-1` default / index-vs-charId skew |
| No MedusaCharId / no explicit "default char" const anywhere | High | grep both dumps: 0 hits for `Medusa`/`defaultCharId`/`fallbackChar` |

## 8. Notes / caveats
- The `decompiled\Assembly-CSharp\...` tree is Il2CppInterop **wrappers**: only
  signatures + `il2cpp_runtime_invoke` thunks, no method bodies. Real bodies are
  in `ida-project\hexrays_bapbap.c` (partial) and behaviour is cross-referenced
  from `research\CHARACTERS_RESEARCH.md`. The `dump.cs` files are Il2CppDumper
  output: fields/consts/RVAs/attributes but no bodies.
- I could NOT find the literal native body of `SpawnPlayerChar` or the exact
  `characterPrefabsByCharId[charId]` indexing instruction in the supplied
  hexrays subset (those functions are not in the partial IDA export), so the
  "index 0 default" mechanism for the *spawn* step is inferred from the SyncVar
  default + array-index design documented in CHARACTERS_RESEARCH.md, not read
  from a decompiled body. Flagged as inference, not direct observation.
