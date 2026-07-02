# R03 — Player-Character Spawn Flow (Server-Authoritative)

Stage R03 of the BAPBAP custom-character / custom-ability research.
Goal: trace, from real decompiled code, how the match host turns a player's
**selected character (`charId`)** from char-select into an **in-world,
networked entity** that is **replicated to every client** — and pinpoint exactly
where a wrong/missing prefab registration silently breaks that replication
(the root cause of "invisible to other players / frozen poses / despawn").

> Source of truth: decompiled `Assembly-CSharp` under
> `C:\Users\Administrator\Downloads\neueBapbap\GameCode\ExportedProject\_DisabledScripts\Assembly-CSharp\BAPBAP`.
> These are ILSpy **signature stubs** (method bodies stripped to `return null;` / `{}`),
> so behavior is reconstructed from: real field/SyncVar declarations, real method
> signatures + `[Server]`/`[Command]`/`[ClientRpc]` attributes, the Mirror pooling
> types, and **confirmed by** the community `MedusaMod.cs` Harmony patches in
> `C:\Users\Administrator\Downloads\BAPBAPModdingAPI\bapcustomchars-mod\`, which
> patch the exact same methods at runtime and read/write the exact same fields.
> Every claim below is cited `file:line`. Where a fact is inferred from
> signatures rather than a readable body, it is marked **(inferred from signature)**.

---

## 0. TL;DR — the one-paragraph answer

The server picks the character prefab by indexing
`GameNetworkManager.characterPrefabsByCharId[playerManager.charId]`
(`Network\GameNetworkManager.cs:304`), where `charId` is a **`[SyncVar]`** on the
player (`Player\PlayerManager.cs:95-96`) that was set during char-select on the
server. `GameMode.SpawnPlayerChar(PlayerManager, Vector3)`
(`Game\GameMode.cs:920`) runs **only on the host** (it is invoked from the
server-authoritative match flow; the bot variant `SpawnEntity` is explicitly
`[Server]` at `Game\GameMode.cs:858`), instantiates that prefab, wires it to the
player, and replicates it via Mirror's `NetworkServer.Spawn` carrying the
prefab's **NetworkIdentity `assetId`**. Replication only works if **every client**
has a prefab registered under that **same `assetId`** — in this game that
registration is driven by `NetworkPrefabLibrary` (`Pooling\NetworkPrefabLibrary.cs`)
and the `NetworkPrefabPool` spawn handlers (`Pooling\NetworkPrefabPool.cs`). A
custom character whose prefab/`assetId` exists only on the host (the failed
clone-graft approach) produces a `SpawnMessage` that **remote clients cannot
resolve**, so Mirror drops it → the character is invisible to others, never
animates from network state (frozen "Standbilder"), and is torn down/despawned.

---

## 1. Char-select: how `charId` becomes server-authoritative

Character selection is a server-authoritative state machine, not a client decision.

### 1.1 The selection authority chain

1. **Client request (Command → server):**
   `PlayerPreMatch.CmdTrySelectCharacter(PlayerManager player, int charId)` is a
   Mirror `[Command]` (`Game\PlayerPreMatch.cs`, method `CmdTrySelectCharacter`,
   with weaver stub `UserCode_CmdTrySelectCharacter__PlayerManager__Int32`).
   A `[Command]` runs **on the server**, so the client only *requests* a charId.
   There is also `CmdTryLockCharacter` and `CmdTrySelectSpawnLocation` in the
   same file.

2. **Server validation / assignment:**
   `PreMatchManager.TrySelectCharacter(PlayerManager player, int requestedCharId)`
   (`Game\PreMatchManager.cs`, declared alongside `TryLockCharacter` /
   `TrySelectSpawnLocation`). The server keeps the authoritative map
   `PreMatchManager._currentSelectedCharacters : Dictionary<int,int>`
   (`Game\PreMatchManager.cs:30`) of `playerId → charId`, and assigns defaults via
   `AssignCharacters()` / `AssignCharacter(PlayerManager)`
   (`Game\PreMatchManager.cs:91` and the following method). **(inferred from signature)**

3. **Authoritative write to the SyncVar:**
   `PlayerPreMatch.SetPlayerCharacter(int charId)` and
   `SetTeammateCharacter(PlayerManager, int)` push the validated value onto the
   player. The persisted, replicated result is:
   ```csharp
   // Player\PlayerManager.cs:95-96
   [SyncVar(hook = "OnCharacterChanged")]
   public int charId;
   ```
   Because `charId` is a `[SyncVar]`, the chosen character id is automatically
   serialized to **all** clients (`SerializeSyncVars`/`DeserializeSyncVars` at the
   bottom of `PlayerManager.cs`), and `OnCharacterChanged(int old,int new)`
   (`Player\PlayerManager.cs`, `OnCharacterChanged`) fires on every client to
   update local UI/state.

### 1.2 Pre-match state gating

`PreMatchManager` is a `NetworkBehaviour` whose lifecycle is the
`[SyncVar(hook="OnStateChange")] PreMatchState CurrentState`
(`Game\PreMatchManager.cs:33`) with states
`WaitingForPlayers → CharSelect → SpawnSelect → SpawnLock → InGame`
(`Game\PreMatchManager.cs`, enum `PreMatchState`). Spawn into the world happens
on the transition into `InGame` (driven by `OnFinishedGameLoading()` /
`OnBeginGameLoading()` and the `GameManager` pre-match cycle, see §3).
`PlayerPreMatch` also carries `[SyncVar] SelectedSpawnPoint` and
`[SyncVar] LockedCharacter` (`Game\PlayerPreMatch.cs`), so both the **character**
and the **spawn point** are locked server-side before the world entity is created.

**Takeaway for custom chars:** by the time spawn happens, the server already holds
an authoritative integer `charId`. A custom character must therefore be a **real
`charId` slot the server recognizes**, not a client-only reskin — otherwise the
server will index a prefab array with that id and either crash or fall back to the
wrong character (this is exactly why the failed Medusa approach needed a
`GameNetworkManager.GetCharacterBotPrefab` fallback patch, see §6).

---

## 2. The charId → prefab map (where the prefab is chosen)

The single most important data structure for this stage:

```csharp
// Network\GameNetworkManager.cs
[SerializeField] public NetworkPrefabLibrary networkPrefabLibrary;          // :301
[SerializeField] public GameObject[] characterPrefabsByCharId;              // :304
[SerializeField] public CharacterBotPrefabs[] charBotPrefabsByCharId;       // :307
```

- `characterPrefabsByCharId` is a **flat array indexed by `charId`**. Index 0 =
  Kitsu, etc. The canonical charIds are baked in as constants:
  ```csharp
  // Network\GameNetworkManager.cs:233-243
  public const int KitsuCharId   = 0;
  public const int AnnaCharId    = 1;
  public const int ZookCharId    = 5;
  public const int TeeveeCharId  = 8;
  public const int SpriestCharId = 11;
  public const int EveCharId     = 12;
  ```
- `charBotPrefabsByCharId` is the bot equivalent; `CharacterBotPrefabs`
  (`Network\GameNetworkManager.cs:18-34`) holds one prefab per difficulty
  (`charBotEasy/Medium/Hard/Expert`) and resolves via
  `GetBotPrefab(BotDifficulty)` (`:31`).
- The bot resolver entry point is
  `GameNetworkManager.GetCharacterBotPrefab(int charId, BotDifficulty)`
  (`Network\GameNetworkManager.cs:374`).

**This is the chooser.** Player-character spawn = "take `playerManager.charId`,
index `characterPrefabsByCharId`, instantiate that prefab." This is directly
confirmed by `MedusaMod.cs` which reads the same field to register/clone:
```csharp
// MedusaMod.cs:5047-5053  (community runtime patch, real body)
Il2CppReferenceArray<GameObject> characterPrefabsByCharId = val.characterPrefabsByCharId;
if (... charId >= characterPrefabsByCharId.Length || characterPrefabsByCharId[charId] == null) ...
GameObject val2 = characterPrefabsByCharId[charId];
```

### 2.1 The Mirror registration library

```csharp
// Pooling\NetworkPrefabLibrary.cs:5-9
public class NetworkPrefabLibrary : ScriptableObject
{
    public GameObject[] InstantiatedPrefabs;          // :7  direct-spawn prefabs
    public NetworkPrefabPool.Config[] PooledPrefabs;  // :9  pooled-spawn prefabs
}
```

`NetworkPrefabLibrary` is referenced by `GameNetworkManager` (`:301`),
`EntityAssetsManager` (`Local\EntityAssetsManager.cs:150`) and `AssetPalette`
(`Maps\AssetPalette.cs:290`). It is the registry that feeds Mirror's spawnable
set. Character prefabs are network objects, so their prefab (with its
`NetworkIdentity`) must be present here (directly or via the pool) **on every
peer** for `NetworkServer.Spawn` to be resolvable on clients. See §4 for the
mechanism and §5 for why this is the breakpoint.

---

## 3. The spawn call site (server only)

### 3.1 `GameMode.SpawnPlayerChar`

```csharp
// Game\GameMode.cs:920
public void SpawnPlayerChar(PlayerManager playerManager, Vector3 spawnPos = default(Vector3))
```

This is the player-character spawn entry point. Reconstructed behavior
**(inferred from signature + surrounding API + confirmed by MedusaMod patch)**:

1. Choose spawn position. `SelectSpawnPoint(int teamId)` (`Game\GameMode.cs:915`,
   `virtual`, overridden by `GameModeBattleRoyale`) or the
   `PlayerPreMatch.SelectedSpawnPoint` `[SyncVar]` provides `spawnPos`.
2. Resolve the prefab: `gameNetManager.characterPrefabsByCharId[playerManager.charId]`
   (the chooser from §2; `PlayerManager.gameNetManager` is the cached
   `GameNetworkManager`, `Player\PlayerManager.cs:31`).
3. Instantiate + register the networked object and wire ownership (see §4).
4. Wire the entity back to the player:
   - `PlayerManager.AddCharObj(EntityManager, bool isPrimary)`
     (`Player\PlayerManager.cs:273`) sets `playerManager.primaryCharManager`
     (`:117`).
   - `EntityManager` SyncVars get set: `charId` (`Entities\EntityManager.cs:207`),
     `isPrimary` (`:199`), `playerObj` (`[SyncVar(hook="OnPlayerObjChanged")]`,
     `:202-203`), `charInstanceId` (`:211`), `entityTeamId`.
5. Fire the gamemode hook `OnPlayerCharSpawned(EntityManager)`
   (`Game\GameMode.cs:819`, `virtual`; overridden in
   `GameModeBattleRoyale.OnPlayerCharSpawned`).

That `SpawnPlayerChar` runs server-side is confirmed by the community patch that
wraps it and only does server work in it:
```csharp
// MedusaMod.cs:721-727
[HarmonyPatch(typeof(GameMode), "SpawnPlayerChar")]
public static class GameModeSpawnPlayerCharPatch {
    [HarmonyPrefix] public static void Prefix(PlayerManager playerManager, Vector3 spawnPos) {
        _instance?.EnsureMedusaPrefabRegistered(CurrentMedusaId(), "GameMode.SpawnPlayerChar.prefix");
    }
    [HarmonyPostfix] public static void Postfix(PlayerManager playerManager) {
        if (IsMedusaId(playerManager.charId))
            EnsureLiveMedusaEntity(playerManager.primaryCharManager, ...);  // reads primaryCharManager
    }
}
```
Note the postfix reads `playerManager.charId` and `playerManager.primaryCharManager`
— exactly the fields populated by the native body.

### 3.2 The explicit `[Server]` spawn primitive

The lowest-level networked spawn primitive in `GameMode` is explicitly
server-only:
```csharp
// Game\GameMode.cs:858
[Server]
public GameObject SpawnEntity(GameObject prefabObj, Vector3 worldPos,
                              Quaternion rot = default, Vector3 scale = default)
```
vs. the non-networked local helper:
```csharp
// Game\GameMode.cs:852
public GameObject InstantiateEntity(GameObject prefabObj, Vector3 worldPos, ...)
```
The `[Server]` attribute means Mirror's weaver guards this method to no-op (and
warn) if called on a client. **This is the function that ultimately calls
`NetworkServer.Spawn`** for entities, and it is the model the player-char and bot
spawns follow. Bots: `SpawnBotChar(...)` overloads (`Game\GameMode.cs:932/937/942`),
`SpawnBotSquad`, `SpawnAllBotsFill`; revive: `RevivePlayer` (`:947`), `ReviveBot`.

### 3.3 Who calls `SpawnPlayerChar` (the match host flow)

`GameMode.SpawnPlayerChar` is invoked from the server-driven match start. The
relevant orchestration objects:
- `GameManager` (`Game\GameManager.cs`) runs the pre-match cycle coroutine
  `NewPreMatchCycle` (state machine class `_003CNewPreMatchCycle_003Ed__72`,
  `Game\GameManager.cs`) which advances `PreMatchManager` to `InGame` and
  triggers per-player spawn. `GameManager` also tracks `BotPlayer { primaryChar,
  teamId, charId }` (`Game\GameManager.cs`, nested class) for bot fills.
- `GameModeBattleRoyale.OnMatchBegin()` / `OnMatchStarted()`
  (`Game\GameModeBattleRoyale.cs`) and `OnPlayerAdded(PlayerManager, int botTeamId)`
  (override) are the BR-specific hooks where players/bots are introduced.
- Connection-level: `GameNetworkManager.OnServerAddPlayer(NetworkConnectionToClient)`
  (`Network\GameNetworkManager.cs:421`) creates the **`PlayerManager`** network
  object for a connection (the *player*, not yet the *character*). The
  **character** entity is a separate `EntityManager` spawned later by
  `SpawnPlayerChar`. This player/character split matters: ownership/authority of
  the character is assigned through the player's connection during the
  `NetworkServer.Spawn(charObj, conn)` call.

---

## 4. How the spawn is replicated to clients (Mirror mechanism)

The character is a `NetworkBehaviour`/`NetworkIdentity` object:
```csharp
// Entities\EntityManager.cs:11-13
[DisallowMultipleComponent]
public class EntityManager : NetworkBehaviour
```
with networked state (`charId`, `isPrimary`, `playerObj`, `entityTeamId`,
`charInstanceId`, ... all `[SyncVar]`, `Entities\EntityManager.cs:195-215`) and
networked subcomponents (`charNetwork`, `charAbilities`, `charAnim`,
`charModelSwap`, `charSim`, etc., `Entities\EntityManager.cs:30-150`).

Replication path:

1. **Server** instantiates the prefab and calls (inside `SpawnEntity` /
   `SpawnPlayerChar`) Mirror's `NetworkServer.Spawn(go, ownerConnection)`.
2. Mirror reads the prefab's **`NetworkIdentity.assetId`** and emits a
   `SpawnMessage` to all observers carrying that `assetId` + the SyncVar payload.
3. **Each client** receives `SpawnMessage` and must map `assetId → prefab` to
   instantiate the matching object. In this game that mapping is **pooled**:

```csharp
// Pooling\NetworkPrefabPool.cs
public static Dictionary<GameObject, uint> netIdLookup;             // :86 (prefab → assetId)
public static Dictionary<uint, NetworkPrefabPool> poolLookup;       // :92 (assetId → pool)
public static List<NetworkPrefabPool> poolList;                     // :94
public static void ServerCreate(Config config) { }                  // server-side pool
public static void ClientCreate(Config config) { }                  // client-side pool
public GameObject SpawnHandler(SpawnMessage msg) { ... }            // :~199 Mirror spawn handler
```

`NetworkPrefabPool.SpawnHandler(SpawnMessage)` is the registered Mirror **spawn
handler**: when a `SpawnMessage` for a given `assetId` arrives, Mirror calls the
handler keyed to that `assetId`, which `Pop`s a pooled instance of the prefab.
The pools are built from `NetworkPrefabLibrary.PooledPrefabs`
(`NetworkPrefabPool.Config[]`, `Pooling\NetworkPrefabLibrary.cs:9`) and direct
prefabs from `InstantiatedPrefabs` (`:7`).

**Therefore the contract for replication is:**
> The prefab's `NetworkIdentity.assetId` **must be registered to a spawn
> handler / spawnable prefab on every peer** (host *and* every remote client),
> with the **same `assetId`** the server stamped onto the prefab it spawned.

This is what `MedusaMod.cs` tries to satisfy manually:
```csharp
// MedusaMod.cs — TryConfigureMirrorPrefab (real body)
NetworkIdentity val = prefab.GetComponent<NetworkIdentity>() ?? prefab.GetComponentInChildren<NetworkIdentity>(true);
val._assetId = MedusaMirrorAssetId;                  // stamp assetId 0x4D454455
...
TryRegisterNetworkPrefabPool(gnm, prefab, source);   // append Config to networkPrefabLibrary.PooledPrefabs
```
and the pool append:
```csharp
// MedusaMod.cs — TryRegisterNetworkPrefabPool (real body)
NetworkPrefabLibrary val2 = gnm.networkPrefabLibrary;
Il2CppReferenceArray<Config> val3 = val2.PooledPrefabs;
... // search for existing, else grow array by 1 and append new Config{prefab,...}
val2.PooledPrefabs = val7;
```

---

## 5. WHERE A WRONG/MISSING PREFAB REGISTRATION BREAKS REPLICATION

This section is the deliverable: the precise failure points that produce the
reported symptoms (invisible to others / frozen poses / despawn).

### 5.1 Failure A — assetId not registered on remote clients ⇒ invisible to others
- **Mechanism:** Server `NetworkServer.Spawn` sends a `SpawnMessage` with the
  custom prefab's `assetId`. Remote clients look up `assetId → spawn handler` in
  `NetworkPrefabPool.poolLookup` (`Pooling\NetworkPrefabPool.cs:92`) /
  Mirror's prefab dict. If the custom `assetId` was only registered on the host
  (because the clone+`PooledPrefabs` append ran only in the host process — exactly
  the MedusaMod model in §4), the remote client has **no handler for that
  assetId**, Mirror logs "no prefab/handler for assetId" and **drops the spawn**.
- **Symptom produced:** the custom character is **not visible to other players**;
  its attacks/abilities (which spawn further networked hitbox objects with their
  own assetIds) are likewise invisible — "visuals/attacks were only local."
- **This is the primary root cause of the failed approach.** Client-side grafting
  cannot retroactively make all *other* players' clients aware of a new assetId;
  the registration must happen identically on every peer **before** the spawn.

### 5.2 Failure B — `charId` indexes a prefab the server doesn't have ⇒ crash / wrong char
- **Mechanism:** `SpawnPlayerChar` indexes `characterPrefabsByCharId[charId]`
  (`Network\GameNetworkManager.cs:304`). If a custom `charId` (e.g. 15) is set on
  `PlayerManager.charId` but `characterPrefabsByCharId` has no element 15 (or it's
  null), the server either throws (IndexOutOfRange/Null) or, with guards, picks
  nothing. MedusaMod had to **grow the array** and also patch the **bot** path so
  a Medusa charId never reaches an unindexed bot lookup:
  ```csharp
  // MedusaMod.cs:806-822
  [HarmonyPatch(typeof(GameNetworkManager), "GetCharacterBotPrefab")]
  [HarmonyPrefix] public static void Prefix(ref int charId, BotDifficulty botDifficulty) {
      if (!IsMedusaId(charId)) return;
      charId = _instance?.ResolveBotFallbackCharId(...) ?? 0;   // fall back to a base charId
  }
  ```
- **Symptom produced:** despawn / fallback to Kitsu animations on E (the base
  char "Kitsu" leaks through because the fallback resolves to base charId 0).

### 5.3 Failure C — stale/duplicate `NetworkIdentity` state on a cloned prefab ⇒ spawn rejected / despawn
- **Mechanism:** A character prefab cloned at runtime carries a `NetworkIdentity`
  whose `sceneId`, `netId`, `hasSpawned`, `_SpawnedFromInstantiate` may be
  non-zero/inconsistent. Mirror will refuse to spawn or immediately destroy an
  identity it considers already-spawned or scene-bound. MedusaMod had to scrub all
  of these by hand:
  ```csharp
  // MedusaMod.cs — SanitizeMirrorIdentities (real body)
  foreach NetworkIdentity in prefab children:
      val.sceneId = 0; val._netId_k__BackingField = 0; val.hasSpawned = false;
      val._SpawnedFromInstantiate_k__BackingField = false; val.destroyCalled = false;
      val.serverOnly = false; val._connectionToServer = null; val._connectionToClient = null;
      val.InitializeNetworkBehaviours();
  ```
- **Symptom produced:** the entity "despawns" or never fully registers; on clients
  it may appear for a frame then vanish.

### 5.4 Failure D — SyncVars/RPCs not wired (no weaver) ⇒ frozen poses ("Standbilder")
- **Mechanism:** Animation/state on the character is driven by networked
  components: `CharAnimator charAnim`, `CharNetwork charNetwork`,
  `CharSimulation charSim`, `CharModelSwap charModelSwap`
  (`Entities\EntityManager.cs:30-150`). These rely on Mirror **weaved** SyncVars
  and RPCs. A runtime-cloned/hand-grafted prefab does **not** get new weaver code
  for new behaviours; only the *base* char's already-weaved components replicate.
  Grafted visuals/abilities have no network serialization path, so remote clients
  receive position but not the new animation/ability state → the model stands in a
  default/frozen pose.
- **Symptom produced:** "frozen poses (Standbilder)" and abilities that only work
  locally (LMB visible because it reuses the base char's weaved ability path; RMB
  "green dot" = the spawned hitbox object's assetId isn't registered on clients,
  same as Failure A; E = falls back to base Kitsu animation per Failure B).

### 5.5 Failure E — pool created on one side only ⇒ asymmetric spawn
- **Mechanism:** `NetworkPrefabPool.ServerCreate` vs `ClientCreate`
  (`Pooling\NetworkPrefabPool.cs`) build the server and client pools separately.
  If the registration only runs when `NetworkServer.active` (as MedusaMod gates it:
  `flag3 = Application.isBatchMode || NetworkServer.active;`), the **client-only**
  peers never create the pool entry → Failure A again.

### Summary table

| # | Break point (file:line) | What's wrong | Symptom |
|---|---|---|---|
| A | `NetworkPrefabPool.poolLookup` `Pooling\NetworkPrefabPool.cs:92`; registration from `NetworkPrefabLibrary.PooledPrefabs` `Pooling\NetworkPrefabLibrary.cs:9` | custom `assetId` not registered on remote clients | invisible to others; attacks local-only |
| B | `characterPrefabsByCharId[charId]` `Network\GameNetworkManager.cs:304`; `GetCharacterBotPrefab` `:374` | custom `charId` not in array / no bot prefab | despawn; E plays base Kitsu anim |
| C | `NetworkIdentity` fields on cloned prefab (scrubbed in `SanitizeMirrorIdentities`) | stale `sceneId/netId/hasSpawned` | spawn rejected / immediate despawn |
| D | weaved SyncVars/RPCs on `CharAnimator/CharNetwork/CharAbilities` `Entities\EntityManager.cs:30-150` | grafted content has no network serialization | frozen poses; abilities local-only |
| E | `ServerCreate` vs `ClientCreate` `Pooling\NetworkPrefabPool.cs` | pool built host-side only | asymmetric/missing client spawn |

---

## 6. What the FAILED approach did (and why it can't be correct)

From `BAPBAPModdingAPI\bapcustomchars-mod\` (`CustomCharFramework.cs`,
`MedusaMod.cs`):
- Clone base char prefab (Kitsu, `BaseCharId=0`), name it `Char_Medusa`, assign
  `CharId=15`, stamp `NetworkIdentity._assetId = 0x4D454455`
  (`CustomCharFramework.cs` defaults; `MedusaMod.cs` RegisterPrefab/TryConfigureMirrorPrefab).
- Append the clone to `characterPrefabsByCharId` and a `Config` to
  `networkPrefabLibrary.PooledPrefabs`, then sanitize NetworkIdentity state.
- Graft a visual prefab from an AssetBundle; patch all char-select UI methods so
  the slot is selectable (`MedusaMod.cs:76-373`).

Why it fails (ties to §5): all of this executes **inside one game process via
Harmony**. The host can spawn and *see* its own clone, but:
- Remote clients run their own process and **never executed the registration** for
  `assetId 0x4D454455` unless the mod is *also* loaded and *deterministically*
  registers the identical prefab+assetId **before** any spawn (Failures A/E).
- New abilities/animations grafted onto the clone are **not Mirror-weaved**, so
  they don't replicate (Failure D).
- Runtime cloning fights Mirror's identity bookkeeping (Failure C), needing manual
  scrubbing that is fragile across the player/char lifecycle.

The MedusaMod even admits it delegates client registration to
`NetworkManager.spawnPrefabs` and "skipped direct NetworkClient.RegisterPrefab"
(`MedusaMod.cs` log near `_mirrorClientPrefabRegistered`), which only works if the
prefab is in the shared library on the client too — i.e. it cannot be a host-only
runtime clone.

---

## 7. Implications for a correct, from-scratch integration

(These are direct consequences of the spawn flow above; the synthesis stage will
expand them.)

1. **A custom character must be a first-class `charId` slot known to every peer.**
   Extend `characterPrefabsByCharId` (and `charBotPrefabsByCharId`) **identically
   and deterministically on host and all clients** during
   `GameNetworkManager.Awake/OnStartServer/OnStartClient`, *before* any
   `SpawnPlayerChar`. The char-select SyncVar (`PlayerManager.charId`,
   `Player\PlayerManager.cs:95-96`) then "just works" because it's only an int.

2. **The prefab must be a real, pre-built Mirror prefab with a fixed `assetId`**
   registered into `NetworkPrefabLibrary.InstantiatedPrefabs` or `.PooledPrefabs`
   (`Pooling\NetworkPrefabLibrary.cs:7,9`) on every peer — never a host-only
   runtime `Instantiate` clone. Same `assetId` on all peers is mandatory
   (§4 contract, Failures A/E).

3. **Don't graft visuals/abilities onto a base clone at runtime.** Build the
   character prefab with its own already-weaved networked components
   (mirror the base `EntityManager` component set: `CharNetwork`, `CharAbilities`,
   `CharAnimator`, `CharModelSwap`, `CharSimulation`, ...,
   `Entities\EntityManager.cs:30-150`). New abilities must use the game's existing
   weaved ability/hitbox networking (ability research is R04+), not bespoke
   client-side logic, to avoid Failure D.

4. **Spawn stays server-authoritative.** Let the native server path
   (`GameMode.SpawnPlayerChar` `Game\GameMode.cs:920` →
   `SpawnEntity [Server]` `:858` → `NetworkServer.Spawn`) own creation; the custom
   system only supplies a correctly-registered prefab for the chosen `charId`.

5. **Bots need the same treatment.** `GetCharacterBotPrefab(charId, difficulty)`
   (`Network\GameNetworkManager.cs:374`) and `charBotPrefabsByCharId` (`:307`) must
   contain valid entries for the custom charId, or bot spawns fall back/throw
   (Failure B).

---

## 8. Method/flow index (quick reference, all server-side unless noted)

| Step | Symbol | Location |
|---|---|---|
| Client requests char | `PlayerPreMatch.CmdTrySelectCharacter` `[Command]` | `Game\PlayerPreMatch.cs` |
| Server validates | `PreMatchManager.TrySelectCharacter` / `AssignCharacter` | `Game\PreMatchManager.cs:91` |
| Server records selection | `PreMatchManager._currentSelectedCharacters` | `Game\PreMatchManager.cs:30` |
| Authoritative char id | `PlayerManager.charId` `[SyncVar(OnCharacterChanged)]` | `Player\PlayerManager.cs:95-96` |
| Pre-match state → InGame | `PreMatchManager.CurrentState` `[SyncVar]` / `OnFinishedGameLoading` | `Game\PreMatchManager.cs:33` |
| Player network object | `GameNetworkManager.OnServerAddPlayer` | `Network\GameNetworkManager.cs:421` |
| Prefab chooser (player) | `GameNetworkManager.characterPrefabsByCharId[charId]` | `Network\GameNetworkManager.cs:304` |
| Prefab chooser (bot) | `GameNetworkManager.GetCharacterBotPrefab` / `charBotPrefabsByCharId` | `:374` / `:307` |
| Char id constants | `KitsuCharId..EveCharId` | `Network\GameNetworkManager.cs:233-243` |
| **Spawn player char** | `GameMode.SpawnPlayerChar(PlayerManager, Vector3)` | `Game\GameMode.cs:920` |
| Spawn bot char | `GameMode.SpawnBotChar(...)` (3 overloads) | `Game\GameMode.cs:932/937/942` |
| Networked spawn primitive | `GameMode.SpawnEntity(...)` `[Server]` | `Game\GameMode.cs:858` |
| Local (non-net) instantiate | `GameMode.InstantiateEntity(...)` | `Game\GameMode.cs:852` |
| Spawn point selection | `GameMode.SelectSpawnPoint(int teamId)` `virtual` | `Game\GameMode.cs:915` |
| Wire char → player | `PlayerManager.AddCharObj(EntityManager, bool)` → `primaryCharManager` | `Player\PlayerManager.cs:273 / :117` |
| In-world entity | `EntityManager : NetworkBehaviour` (`charId/isPrimary/playerObj` SyncVars) | `Entities\EntityManager.cs:11 / :199-211` |
| Post-spawn hook | `GameMode.OnPlayerCharSpawned(EntityManager)` `virtual` (BR override) | `Game\GameMode.cs:819` |
| Mirror registry | `NetworkPrefabLibrary { InstantiatedPrefabs, PooledPrefabs }` | `Pooling\NetworkPrefabLibrary.cs:7,9` |
| Mirror spawn handler | `NetworkPrefabPool.SpawnHandler(SpawnMessage)` / `poolLookup` (assetId→pool) | `Pooling\NetworkPrefabPool.cs:~199 / :92` |

---

## 9. Caveats / confidence

- The `_DisabledScripts` decompile provides **real signatures, attributes, fields,
  and SyncVar/Command/Rpc declarations**, but **not method bodies**. The control
  flow inside `SpawnPlayerChar`/`SpawnEntity` (exact order of
  `Instantiate`→SyncVar set→`NetworkServer.Spawn`) is **(inferred from signature)**
  and corroborated by: (a) the `[Server]` attribute on `SpawnEntity`
  (`Game\GameMode.cs:858`), (b) the SyncVar set on `EntityManager`
  (`Entities\EntityManager.cs:199-211`), and (c) the community `MedusaMod.cs`
  patches that hook these exact methods and read `playerManager.charId` /
  `playerManager.primaryCharManager` / `characterPrefabsByCharId[charId]` with real
  bodies.
- The Mirror `assetId`→prefab registration is **confirmed** via the concrete
  `NetworkPrefabPool` static lookups (`poolLookup`, `netIdLookup`) and the
  `NetworkPrefabLibrary` fields; the precise Mirror API call
  (`NetworkClient.RegisterPrefab` vs `RegisterSpawnHandler` vs
  `NetworkManager.spawnPrefabs`) used during startup is inside stripped bodies, but
  the failed mod's notes (delegating to `NetworkManager.spawnPrefabs`) indicate the
  library is consumed into Mirror's `spawnPrefabs` list at init.
- Line numbers are from the files as read on 2026-06-12; if the decompile is
  regenerated they may shift, but symbol names are stable.
