# R02 — Mirror Networking & Prefab Registration (BAPBAP)

Stage R02 findings for the "correct, from-scratch networked custom character + ability"
design. This document explains **exactly** how BAPBAP spawns and replicates entities through
Mirror, how spawnable prefabs are registered on the server and on every client, how an entity's
`assetId` is resolved back to a prefab, and **precisely what is required to register a NEW prefab
on both server and all clients so other players actually see it**. It closes with the concrete
reasons the previous clone/client-graft approach failed against this architecture.

All game-specific claims are cited as `file:line` against the decompiled source. Two trees were
used:

- **Stub tree** (signatures only, bodies stripped): `...\GameCode\ExportedProject\_DisabledScripts\Assembly-CSharp\BAPBAP\...`
- **Full-body tree** (real method bodies — the authoritative source for behaviour):
  `...\neueBapbap\GEHEIMBUILD\ExportedProject\Assets\Scripts\Assembly-CSharp\BAPBAP\...`

Unless noted, line numbers refer to the **GEHEIMBUILD full-body tree**, which is byte-for-byte the
same class as the live game and is the only place the method bodies survive decompilation.

Mirror itself ships as a compiled DLL (no decompiled source in either tree), so Mirror-internal
behaviour is described from Mirror's public/documented contract and corroborated by how the game
calls it. Those statements are explicitly flagged as **[Mirror contract]**.

---

## 0. TL;DR — the crux

BAPBAP replicates world entities (player characters, bots, projectiles, hitboxes, drops, zones…)
as **ordinary Mirror spawned objects**: the server calls `NetworkServer.Spawn(go)` /
`NetworkServer.Spawn(go, conn)` and Mirror sends a `SpawnMessage` carrying that object's
`NetworkIdentity.assetId`. Each client looks that `assetId` up in `NetworkClient.prefabs` (or a
registered spawn-handler) to instantiate the matching local copy.

Therefore an object is only visible to a remote player if **all three** of these are true:

1. **Server side:** the instantiated GameObject has a `NetworkIdentity` whose `assetId` is a real,
   non-zero value, and the server actually calls `NetworkServer.Spawn` on it.
2. **Client side (EVERY client):** the **same `assetId`** is registered in that client's
   `NetworkClient.prefabs` dictionary, pointing at a prefab that client can instantiate
   (via `NetworkClient.RegisterPrefab` or a registered `SpawnHandler`).
3. The prefab/registration is **identical content on server and clients** (same `assetId`, same
   prefab graph) — i.e. it ships in the build, not injected at runtime on one machine only.

The previous mod satisfied (1)/(2) **only on the single modded client** and never on the dedicated
server or the other clients. That is the root cause of "only I can see it / it despawns / frozen
poses". Details in §8.

---

## 1. The network stack: `GameNetworkManager : Mirror.NetworkManager`

`GameNetworkManager` is the game's `NetworkManager` subclass.

- Declaration & serialized config:
  `Network\GameNetworkManager.cs:18` (`public class GameNetworkManager : NetworkManager`).
- The prefab-relevant serialized fields (stub tree, identical in both):
  - `public NetworkPrefabLibrary networkPrefabLibrary;` — `Network\GameNetworkManager.cs:289` (stub) / present in GEHEIMBUILD field block.
  - `public GameObject[] characterPrefabsByCharId;` — the per-character entity prefabs, indexed by `charId`.
  - `public CharacterBotPrefabs[] charBotPrefabsByCharId;` — per-difficulty bot variants.
- It is a singleton: `Instance` is set in `PreAwake` (`GameNetworkManager.cs:171` GEHEIMBUILD,
  `Instance = this;`).
- Transports are multiplexed: `MultiplexTransport` over `SimpleWebTransport` (WS), `KcpTransport`
  (UDP), `TelepathyTransport` (TCP) — wired in `PreAwake` (`GameNetworkManager.cs:174-201`).

Two run modes drive everything:

- **Dev/host lobby** (`gameManager.isDevLobbyMode`) → `OnServerDevLobbyClInit`.
- **Matchmaking / dedicated host** → `OnServerMatchmakingClInit`.

Dispatch happens in `OnServerClInit` (`GameNetworkManager.cs` — `OnServerClInit`), which routes the
`ClInitMsg` to one of the two handlers.

### 1.1 Custom messages (NOT how entities are replicated, but used for handshake)

`GameNetworkManager` defines two `NetworkMessage` structs:

- `ClInitMsg { string playerName; string gameAuthId; }` — `GameNetworkManager.cs:39-44`.
- `SvInitMsg { string buildVersion; int teamIdCache; int playerIdCache; int[] teammatePlayerIdsCache; }` — `GameNetworkManager.cs:46-55`.

Handshake: client `OnClientConnect` registers `SvInitMsg` and sends `ClInitMsg`
(`GameNetworkManager.cs:262-279`); server `OnStartServer` registers `ClInitMsg`
(`NetworkServer.RegisterHandler<ClInitMsg>(OnServerClInit)`). These are **plain messages**, not
spawn replication — they do not carry character visuals.

---

## 2. How spawnable prefabs are registered

BAPBAP registers spawnables in **three overlapping layers**. Layers A and B are the ones actually
used by the shipping game; layer C (`spawnPrefabs`) is the stock-Mirror inspector list and is what
the failed mod leaned on.

### A. `NetworkPrefabLibrary` — the canonical registry

`NetworkPrefabLibrary` is a `ScriptableObject` with exactly two arrays
(`Pooling\NetworkPrefabLibrary.cs`):

```csharp
public class NetworkPrefabLibrary : ScriptableObject
{
    public GameObject[] InstantiatedPrefabs;            // registered 1:1 via NetworkClient.RegisterPrefab
    public NetworkPrefabPool.Config[] PooledPrefabs;    // registered via NetworkPrefabPool (pooled)
}
```

The live asset is `Assets\MonoBehaviour\NetworkPrefabLibrary.asset` (guid
`c8f59ce1045d22a468f3e246048b70c5`, referenced by the scene at `MainScene.unity:165214`). It
contains roughly **470 `InstantiatedPrefabs`** and **~190 `PooledPrefabs`** (each pooled entry is a
`{prefab, initialSizeServer, initialSizeClient, resizeStrategy}` record). Character prefabs,
projectiles, hitboxes, drops, etc. all live in these two lists.

**Client registration** happens in `GameNetworkManager.OnStartClient`
(`GameNetworkManager.cs:244-254`):

```csharp
public override void OnStartClient()
{
    for (int i = 0; i < networkPrefabLibrary.PooledPrefabs.Length; i++)
        NetworkPrefabPool.ClientCreate(networkPrefabLibrary.PooledPrefabs[i]);   // pooled → RegisterPrefab + handlers
    for (int j = 0; j < networkPrefabLibrary.InstantiatedPrefabs.Length; j++)
        NetworkClient.RegisterPrefab(networkPrefabLibrary.InstantiatedPrefabs[j]); // 1:1 → RegisterPrefab
    ...
}
```

**Server registration** happens in `GameNetworkManager.OnStartServer`
(`GameNetworkManager.cs`, `OnStartServer`):

```csharp
public override void OnStartServer()
{
    for (int i = 0; i < networkPrefabLibrary.PooledPrefabs.Length; i++)
        NetworkPrefabPool.ServerCreate(networkPrefabLibrary.PooledPrefabs[i]);   // pooled (no RegisterPrefab on server)
    NetworkServer.RegisterHandler<ClInitMsg>(OnServerClInit);
    systemManager.entityNetworkSystem.OnStartServer();
    ...
}
```

> Note: `OnStartClient` does **not** call `base.OnStartClient()`. The game does not rely on Mirror's
> stock auto-registration of `spawnPrefabs`/`playerPrefab` to spawn world entities — it registers
> everything explicitly through `networkPrefabLibrary`. `playerPrefab` is still set on the
> `NetworkManager` (used by `AddPlayerForConnection`, see §4), but the *visible character entities*
> are registered via the library. **Implication for us:** to add a networked entity correctly you
> add it to `NetworkPrefabLibrary` (so both `OnStartServer` and `OnStartClient` pick it up), not
> just to `spawnPrefabs`.

### B. `NetworkPrefabPool` — pooled spawnables (most ability/projectile entities)

`Pooling\NetworkPrefabPool.cs` is a custom pooling layer that sits **on top of Mirror's custom
spawn-handler API**. The important method is `Create` (`NetworkPrefabPool.cs:83-107`):

```csharp
public static void Create(Config config, bool isServer)
{
    if (config.prefab.TryGetComponent<NetworkIdentity>(out var component))
    {
        uint assetId = component.assetId;                 // <-- the prefab's Mirror assetId
        if (!poolLookup.TryGetValue(assetId, out var value))
        {
            value = new NetworkPrefabPool(config, assetId, isServer);
            netIdLookup[config.prefab] = assetId;
            poolLookup[component.assetId] = value;         // assetId -> pool
            poolList.Add(value);
        }
        if (!isServer)
            NetworkClient.RegisterPrefab(config.prefab, value.SpawnHandler, value.DespawnHandler); // CLIENT registers handlers
        return;
    }
    throw new Exception("NetworkPrefabPool unable to create prefab pool, missing NetworkIdentity " + config.prefab.name);
}

public static void ServerCreate(Config config) => Create(config, isServer: true);
public static void ClientCreate(Config config) => Create(config, isServer: false);
```

Key facts:

- The pool keys everything off **`NetworkIdentity.assetId`** (lines 86, 90-92). A missing
  `NetworkIdentity` throws (line 105). So **every pooled/spawnable prefab MUST have a
  `NetworkIdentity` with a valid `assetId`.**
- On the **client**, pooled prefabs register a custom spawn/despawn handler with Mirror:
  `NetworkClient.RegisterPrefab(prefab, SpawnHandler, DespawnHandler)` (line 100). The handlers
  pop/push from the pool instead of `Instantiate`/`Destroy` (`SpawnHandler`/`DespawnHandler`,
  `NetworkPrefabPool.cs` near EOF: `Pop(msg.position, msg.rotation, msg.scale)` /
  `Push(instance)`).
- On the **server**, `ServerCreate` pre-instantiates the pool but does NOT call `RegisterPrefab`
  (the server doesn't need a client-instantiation handler).
- Runtime spawn of a pooled object: `NetworkPrefabPool.Spawn(prefab, pos, rot)` looks up
  `netIdLookup[prefab] -> assetId -> poolLookup[assetId] -> Pop()` (`NetworkPrefabPool.cs:109-119`).

### C. Mirror's stock `spawnPrefabs` list **[Mirror contract]**

`NetworkManager.spawnPrefabs` is the inspector "Registered Spawnable Prefabs" `List<GameObject>`.
In stock Mirror these are auto-registered with `NetworkClient.RegisterPrefab` when the client
starts. BAPBAP **does have this list on the component** (the failed mod appends to it via
`((NetworkManager)gnm).spawnPrefabs.Add(prefab)` — see MedusaMod `TryAddSpawnPrefab`,
`MedusaMod.cs`), but the game's own world entities are registered through layer A/B above, so
relying on `spawnPrefabs` alone is unreliable here (and is part of why the mod's registration was
inconsistent across machines).

---

## 3. `assetId` and `sceneId` — what they are and how they are assigned

**[Mirror contract]** Every `NetworkIdentity` carries two identifiers:

- **`assetId` (`uint`)** — identifies the *prefab* an object was instantiated from. In modern
  Mirror it is a stable hash derived from the prefab asset's GUID, baked into the prefab at
  import/build time and serialized on the `NetworkIdentity`. It is used for **runtime-spawned**
  objects (anything created via `NetworkServer.Spawn(prefab-instance)`).
- **`sceneId` (`ulong`/`uint`)** — identifies a `NetworkIdentity` that is **already placed in a
  scene** at build time (assigned in `OnPostProcessScene`). Used for scene objects that exist on
  every peer before any spawn, so they're matched by `sceneId` instead of `assetId`.
- **`netId` (`uint`)** — the per-spawn runtime instance id, assigned by the server at spawn time
  and unique per live object. This is what `SpawnMessage` and all subsequent state sync key off.

Corroboration in-repo:

- The pool reads `component.assetId` as a `uint` and keys its dictionaries on it
  (`NetworkPrefabPool.cs:31` `Dictionary<GameObject, uint> netIdLookup;`, `:33`
  `Dictionary<uint, NetworkPrefabPool> poolLookup;`, `:86` `uint assetId = component.assetId;`).
- The failed mod manipulates the very same fields by reflection/IL2CPP backing fields:
  it sets `NetworkIdentity._assetId` to a hardcoded constant and zeroes `sceneId`, `_netId`,
  `hasSpawned`, `_SpawnedFromInstantiate` (MedusaMod `TryConfigureMirrorPrefab` and
  `SanitizeMirrorIdentities` — `MedusaMod.cs`). The hardcoded id is
  `MirrorAssetId = 0x4D454455 = 1296385109` (`CustomCharFramework.cs:41`,
  `CustomCharDefinition.MirrorAssetId`).

**Why this matters for us:** an `assetId` is meaningful only if the **same value maps to the same
prefab on every peer**. If you fabricate an `assetId` at runtime on one client, the server (and the
other clients) have no prefab registered under that id, so:
- the server will never *produce* that id (it spawns from *its* `characterPrefabsByCharId`), and
- a client receiving an unknown id logs `Failed to spawn server object, assetId=… netId=…` and
  shows nothing (Mirror contract; see Unity/Mirror error string in the wild).

A prefab built once in the Unity editor and shipped in both the server and client builds gets a
**single, identical baked `assetId`** automatically — which is exactly the property we need.

---

## 4. How a player/character entity is spawned and replicated

There are two distinct GameObjects per player:

### 4.1 The "player" object (controller, owned by the connection)

In `OnServerDevLobbyClInit` and `OnServerMatchmakingClInit` the server does
`Object.Instantiate(playerPrefab)` and then `GameManager.AddPlayer*` calls
`NetworkServer.AddPlayerForConnection(conn, player)`:

- `GameManager.cs:623` (`AddPlayerForConnection` in dev-lobby path).
- `GameManager.cs:1027` (`AddPlayerForConnection` in matchmaking path).

`AddPlayerForConnection` **[Mirror contract]** spawns the player object for that connection and
marks it owned by `conn`. This object holds `PlayerManager`/`PlayerNetwork`/input — it is **not**
the visible character mesh.

### 4.2 The character entity (the visible body) — `GameMode.SpawnPlayerChar`

This is the function that actually puts the visible, networked character into the world. From
`Game\GameMode.cs:1054-1090`:

```csharp
public void SpawnPlayerChar(PlayerManager playerManager, Vector3 spawnPos = default)
{
    if (playerManager == null || playerManager.charId < 0
        || playerManager.charId >= netManager.characterPrefabsByCharId.Length
        || playerManager.primaryCharManager != null) return;                 // :1056 bounds/null guard

    if (spawnPos == default) spawnPos = SelectSpawnPoint(playerManager.teamId);

    GameObject original = netManager.characterPrefabsByCharId[playerManager.charId];   // :1064  pick prefab by charId
    if (playerManager.skinAssetId != -1) {                                              // optional skin prefab swap
        Skin skin = LocalManager.Instance.contentManager.skinData.GetSkinByAssetId(playerManager.skinAssetId);
        if (skin?.config.characterPrefab != null) original = skin.config.characterPrefab;
    }

    GameObject obj = Object.Instantiate(original, spawnPos, Quaternion.identity);
    EntityManager component = obj.GetComponent<EntityManager>();
    component.NetworkisPrimary       = true;                  // SyncVar
    component.NetworkplayerObj       = playerManager.gameObject; // SyncVar (links body -> player obj)
    component.NetworkcharInstanceId  = component.GetInstanceID();// SyncVar
    component.NetworkcharId          = playerManager.charId;     // SyncVar (drives client visual/abilities)
    NetworkServer.Spawn(obj, playerManager.connectionToClient);  // :1079  REPLICATE to all clients, owner=conn
    OnPlayerCharSpawned(component);
    if (base.isServerOnly) component.OnPlayerObjChanged(null, playerManager.gameObject);
    ...
}
```

Critical observations:

- The **server** picks the prefab from `netManager.characterPrefabsByCharId[charId]`
  (`GameMode.cs:1064`). The client's selected `charId` only tells the server *which index*; the
  actual prefab is the **server's** array entry. A client cannot make the server spawn a prefab the
  server doesn't have at that index.
- `NetworkServer.Spawn(obj, conn)` (`GameMode.cs:1079`) replicates the entity to **every** client
  and assigns ownership to the player's connection. **[Mirror contract]** Mirror reads
  `obj.GetComponent<NetworkIdentity>().assetId`, allocates a `netId`, and broadcasts a
  `SpawnMessage { netId, assetId, position, rotation, scale, isOwner, payload }` to all observers.
- The character's identity-relevant data (`charId`, `isPrimary`, `playerObj`, `charInstanceId`)
  are **SyncVars** set *before* `Spawn`, so they are serialized in the initial spawn payload and
  arrive on every client. `NetworkcharId` is what each client uses to build the correct visual rig
  and ability set for that body.

### 4.3 Bots — `GameMode.SpawnBotChar`

Bots use the same mechanism (`GameMode.cs:1140-1165`): instantiate
`GameNetworkManager.GetCharacterBotPrefab(charId, difficulty)` (which indexes
`charBotPrefabsByCharId[charId].GetBotPrefab(difficulty)` — `GameNetworkManager.cs:222-230` /
`CharacterBotPrefabs.GetBotPrefab` `:36-45`), set the same SyncVars, then `NetworkServer.Spawn(obj)`
(no owner connection — server-authoritative). `GetCharacterBotPrefab` bounds-checks `charId` and
returns `null` if out of range (`GameNetworkManager.cs:222-228`); a `null` prefab makes
`SpawnBotChar` early-return (`GameMode.cs:1152-1156`).

### 4.4 Ability / projectile / hitbox entities

Abilities spawn their own networked entities the same way — `NetworkServer.Spawn` from server-side
ability code. Examples (server-authoritative spawns):

- `RageAbility.cs:358-373` — instantiates `GameNetworkManager.Instance.characterPrefabsByCharId[charId]`
  and `NetworkServer.Spawn(obj, connectionToClient)` (a clone entity).
- `CatShotAbility.cs:300`, `CelesteShardAbility.cs:302/342`, `MechSlashAbility.cs:473/496`,
  `SpriestTetherAbility.cs:250/292`, `RockyRuptureAbility.cs:259-280`,
  `EntityActivateHitbox.cs:198`, `AB_Chains.cs:382/396`, etc. — all `NetworkServer.Spawn(...)`.
- Destruction is via `NetworkServer.Destroy(...)` (e.g. `ChainTether.cs:139/153/167`,
  `EntitySpawner.cs:182/210`).

**The pattern is uniform:** *server spawns, Mirror replicates by `assetId`, clients instantiate from
their registered prefab.* Any new ability entity must follow the identical pattern with a prefab
present in `NetworkPrefabLibrary` on both sides.

---

## 5. How the client resolves a spawned object back to a prefab

**[Mirror contract]** When a client receives a `SpawnMessage`:

1. If `sceneId != 0`, Mirror matches an existing **scene** object by `sceneId`.
2. Otherwise it looks up `assetId` in `NetworkClient.prefabs` (populated by
   `NetworkClient.RegisterPrefab(prefab)`), or in `NetworkClient.spawnHandlers` (populated by
   `NetworkClient.RegisterPrefab(prefab, spawnHandler, unspawnHandler)`).
3. It instantiates (or, for BAPBAP pooled prefabs, **pops from the pool** via the registered
   `SpawnHandler`), assigns the incoming `netId`, applies the serialized SyncVar payload, and calls
   the new object's `OnStartClient`.
4. If no prefab/handler is found for that `assetId`, the client logs
   `Failed to spawn server object, assetId=… netId=…` and the object **does not appear**.

In BAPBAP the registration that makes step 2 succeed is precisely
`GameNetworkManager.OnStartClient` (§2.A, `GameNetworkManager.cs:244-254`) plus
`NetworkPrefabPool.Create` (§2.B, `NetworkPrefabPool.cs:100`). For pooled entities the client's
`SpawnHandler`/`DespawnHandler` are the pool's `Pop`/`Push`
(`NetworkPrefabPool.SpawnHandler`/`DespawnHandler`).

### 5.1 The game's second, custom replication channel (state & events)

Beyond Mirror's initial spawn + SyncVars, BAPBAP runs its **own per-frame delta-compressed state
sync** for live entities, layered on top of Mirror. This is `EntityNetworkSystem`
(`Systems\EntityNetworkSystem.cs`):

- Each live character body's `CharNetwork` registers itself into `EntityNetworkSystem` on the
  client in `CharNetwork.OnStartClient` (`Entities\CharNetwork.cs:116-126`):

  ```csharp
  public override void OnStartClient()
  {
      if (base.isClientOnly && base.isOwned && isPredicted && enableServerView)
          clServerViewObj = Object.Instantiate(serverViewPrefab, transform.position, transform.rotation);
      if (base.isClientOnly)
          systemManager.entityNetworkSystem.Register(this);     // <-- joins the custom state-sync set
  }
  ```

- `EntityNetworkSystem.Register` adds the `CharNetwork` to `components` and caches it by
  **Mirror `netId`**: `charNetCache.Add(charNetwork.netId, charNetwork)`
  (`EntityNetworkSystem.cs:39-43`).
- The server serializes per-connection state into a `StateSyncMessage { svState, svEvents }` and
  sends it each frame (`EntityNetworkSystem.Update`, `:84-129`). The client decodes it in
  `OnTargetStateSync` (`:154-228`) and dispatches per-entity by reading the leading `netId`, then
  `charNetCache.TryGetValue(netId, …)`; on a miss it falls back to
  `NetworkClient.spawned.TryGetValue(netId, out var ni)` and `ni.GetComponent<CharNetwork>()`
  (`:170-205`). Position/animation/aim/events all flow through here, NOT through Mirror SyncVars.

**Consequence for "frozen poses / Standbilder":** a remote character's *movement and animation* are
driven by this custom state stream keyed on the real Mirror `netId`. If a client builds a body that
isn't a properly Mirror-spawned entity registered in `charNetCache`/`NetworkClient.spawned` (e.g. a
locally instantiated graft), it receives **no state stream**, so it stands frozen. The decompiled
code even logs this exact situation:
`"[EntityNetworkSystem] State - No Char Network found for netId=…"` (`EntityNetworkSystem.cs:172`).

---

## 6. EXACTLY what is required to register a NEW prefab on BOTH server and clients

This is the heart of "other players see it." To add a brand-new networked entity (custom character
body, custom ability projectile/hitbox, etc.) so the server can `NetworkServer.Spawn` it and every
client resolves it:

### 6.1 The prefab itself (built once, shipped to all peers)

1. Author the prefab in the Unity editor **inside the game project** (or an editor that produces a
   real Unity prefab with a stable GUID). The root MUST have a `NetworkIdentity`. (Mirror forbids
   `NetworkIdentity` on nested children of a spawned root — keep exactly one on the root.)
2. Add the gameplay components the architecture expects on a character body: `EntityManager`
   (with the SyncVars `isPrimary`/`playerObj`/`charInstanceId`/`charId` that `SpawnPlayerChar`
   sets — `GameMode.cs:1066-1078`), `CharNetwork`, `CharSim`, `CharAnimator`, `CharMaterial`,
   `CharAbilities`, etc., mirroring the structure of an existing `characterPrefabsByCharId` entry.
   (Ability/projectile prefabs just need `NetworkIdentity` + their hitbox/ability components.)
3. Because the prefab is built once and included in **both** the server and client builds, Unity/
   Mirror bake **one identical `assetId`** into it on every peer. **Do not fabricate `assetId` at
   runtime** — that only desyncs server vs. client (see §3 and §8).

### 6.2 Register it on the server

- Add the prefab to the server's `NetworkPrefabLibrary` (either `InstantiatedPrefabs` for a 1:1
  entity, or `PooledPrefabs` for a pooled entity). `OnStartServer` will call
  `NetworkPrefabPool.ServerCreate` for pooled entries (`GameNetworkManager.cs` OnStartServer loop).
  For a 1:1 entity the server needs the prefab known so `NetworkServer.Spawn` accepts it.
- For a **character**: also place the prefab at the correct index in
  `characterPrefabsByCharId[newCharId]` so `GameMode.SpawnPlayerChar` can pick it
  (`GameMode.cs:1064`) and, for bots, in `charBotPrefabsByCharId[newCharId]`.
- Spawn it server-side exactly like the game does: set SyncVars, then
  `NetworkServer.Spawn(obj, ownerConn)` (owned characters) or `NetworkServer.Spawn(obj)`
  (server-authoritative bots/abilities). Mirror broadcasts the `SpawnMessage` with the prefab's
  `assetId`.

### 6.3 Register it on EVERY client (same `assetId`)

- Add the **same prefab** to the client `NetworkPrefabLibrary` so
  `GameNetworkManager.OnStartClient` registers it:
  - 1:1 entity → it appears in `InstantiatedPrefabs` → `NetworkClient.RegisterPrefab(prefab)`
    (`GameNetworkManager.cs:252`).
  - Pooled entity → it appears in `PooledPrefabs` → `NetworkPrefabPool.ClientCreate(cfg)` →
    `NetworkClient.RegisterPrefab(prefab, SpawnHandler, DespawnHandler)`
    (`NetworkPrefabPool.cs:100`).
- The registration must run **before** the first `SpawnMessage` for that `assetId` arrives — i.e.
  it must be in the `OnStartClient`/library path, not deferred. If you register late, early spawns
  fail with `Failed to spawn server object`.

### 6.4 The minimal correctness checklist

| Requirement | Server | Every client | Citation |
|---|---|---|---|
| Prefab has root `NetworkIdentity` with a real baked `assetId` | ✔ | ✔ (same id) | `NetworkPrefabPool.cs:84-105` |
| Prefab registered before any spawn | `ServerCreate` in `OnStartServer` | `RegisterPrefab`/`ClientCreate` in `OnStartClient` | `GameNetworkManager.cs:244-254` + OnStartServer |
| Character prefab indexed by `charId` | `characterPrefabsByCharId[charId]` | (client uses SyncVar `charId`, not the array, to build visual) | `GameMode.cs:1064`, `:1077` |
| Replicated by server | `NetworkServer.Spawn(obj[,conn])` | (Mirror instantiates by `assetId`) | `GameMode.cs:1079` |
| Live state/anim flows | `EntityNetworkSystem.Update` sends `StateSyncMessage` | `CharNetwork.OnStartClient` → `EntityNetworkSystem.Register` (keyed by `netId`) | `EntityNetworkSystem.cs:39-43`, `CharNetwork.cs:116-126` |

If any cell is missing on any peer, that peer either never spawns the object or spawns a frozen,
state-less husk.

---

## 7. Identity & lifecycle gotchas that cause "despawn" / disconnect

- **`assetId` mismatch ⇒ despawn / failed spawn.** A client that doesn't have the spawned
  `assetId` registered drops the object (Mirror contract; `EntityNetworkSystem.cs:172` logs the
  downstream "No Char Network found for netId").
- **Server-driven cleanup.** On match teardown the server destroys characters
  (`GameMode.cs:1990` `NetworkServer.Destroy(value.primaryCharManager.gameObject)`) and the pool
  un-spawns pooled objects (`NetworkPrefabPool.Dispose` → `NetworkServer.UnSpawn`). A runtime-grafted
  body that the server doesn't own/track can be torn down or left dangling.
- **Connection validation in matchmaking.** `OnServerMatchmakingClInit` will `conn.Disconnect()`
  for a duplicate/late/invalid `gameAuthId` (`GameNetworkManager.cs` matchmaking handler:
  `alreadyConnected`/`isLateJoinable`/`gameAuthIdToPlayer` checks). Anything that perturbs the
  spawn handshake (e.g. exceptions during a runtime prefab graft) can cascade into a disconnect,
  which looks like "it despawned."
- **`NetworkIdentity` re-use.** The failed mod has to zero `sceneId`, `_netId`, `hasSpawned`,
  `_SpawnedFromInstantiate`, `destroyCalled` and re-init behaviours after cloning a prefab at
  runtime (`MedusaMod.SanitizeMirrorIdentities`). This is a strong signal that runtime cloning of a
  spawnable prefab is fighting Mirror's identity bookkeeping — a built-once prefab needs none of it.

---

## 8. Why the previous clone / client-graft approach FAILED (mapped to symptoms)

The prior framework (`BAPBAPModdingAPI\bapcustomchars-mod\MedusaMod.cs` +
`CustomCharFramework.cs`) registers a custom character by **cloning Kitsu (base charId 0) at runtime
and grafting a visual**, with these moves:

- `RegisterPrefab(baseCharId)` clones `characterPrefabsByCharId[baseCharId]` at runtime, names it
  `Char_Medusa`, `DontDestroyOnLoad`, grafts a bundle visual, then appends it to
  `characterPrefabsByCharId` (`MedusaMod.cs` `RegisterPrefab`).
- `TryConfigureMirrorPrefab` sets `NetworkIdentity._assetId = MedusaMirrorAssetId` (the hardcoded
  `0x4D454455` from `CustomCharDefinition.MirrorAssetId`, `CustomCharFramework.cs:41`).
- `SanitizeMirrorIdentities` zeroes `sceneId`/`_netId`/`hasSpawned`/`_SpawnedFromInstantiate`.
- `TryAddSpawnPrefab` appends to `NetworkManager.spawnPrefabs`; `TryRegisterNetworkPrefabPool`
  appends to `NetworkPrefabLibrary.PooledPrefabs` and/or calls `NetworkPrefabPool.ClientCreate/
  ServerCreate`.
- A telling comment: *"Mirror client registration delegated to NetworkManager.spawnPrefabs … skipped
  direct NetworkClient.RegisterPrefab"* (`MedusaMod.cs`).
- Abilities are faked **client-side**: `RunAuthoredMedusaAbilityDriver` / `ApplyAuthoredMedusaGameplay`
  apply damage only when `IsAuthoritativeServer(caster)` and otherwise spawn **local-only**
  presentation VFX/hitboxes via `SpawnMedusaCastFx` / `SpawnNativeMedusaHitbox`, all gated by
  `CanSpawnClientFx()` (no-op on the headless server).

Against the architecture above, each failure is explained:

1. **"Custom char invisible to others; visuals/attacks only local."**
   The registration runs **only on the modded client**. The dedicated headless server (no mod, or
   a server that never had the prefab built into its `NetworkPrefabLibrary`) spawns the player body
   from **its** `characterPrefabsByCharId[charId]` (`GameMode.cs:1064`, `:1079`) — i.e. the base
   Kitsu prefab, not Medusa — and broadcasts **Kitsu's `assetId`**. Other clients resolve that to
   Kitsu. The Medusa mesh/attacks the local player sees are local-only grafts and local-only FX
   (`SpawnMedusaCastFx` is gated to render-capable clients), so no other peer ever receives them.
   The fabricated `assetId 0x4D454455` exists in **no** peer's registry except the modder's, so it
   could never be the id the server actually spawns.

2. **"It despawns."**
   A runtime-cloned `NetworkIdentity` with a hand-set `assetId` and zeroed bookkeeping is not a
   server-tracked spawn on the authoritative host; server-side cleanup
   (`NetworkServer.Destroy`/`UnSpawn`, `GameMode.cs:1990`, pool `Dispose`) and the matchmaking
   connection validation (§7) tear it down or never keep it alive.

3. **"Frozen poses (Standbilder)."**
   Remote bodies are animated by the **custom `EntityNetworkSystem` state stream keyed by Mirror
   `netId`** (`EntityNetworkSystem.cs:39-43`, `:154-228`; `CharNetwork.OnStartClient` registration
   `CharNetwork.cs:116-126`). A locally grafted/duplicated visual is not a properly spawned entity
   in `charNetCache`/`NetworkClient.spawned`, so it gets no state updates and freezes. The mod's own
   code fights this with repeated re-anchor/rebind passes (and a comment explicitly blaming the
   Standbild on re-anchoring every frame), confirming the visual was never being driven by the real
   network state.

4. **"Only LMB works; RMB = green dot; Space bugs out; E plays Kitsu's animation."**
   The body is still mechanically **Kitsu** (the cloned base). Real abilities are the inherited
   Kitsu `CharAbilities`/`Ability` graph that the *server* drives and replicates; the mod merely
   intercepts client-side. LMB (the base auto-attack) survives because it's the genuine networked
   ability. RMB's "green dot" is the mod's primitive/FX fallback (`SpawnMedusaCastFx`/green
   placeholder) rather than a real spawned ability entity. Space (movement/slither) is applied only
   via a client-side `charMove.PostMove` on the authoritative entity, so it desyncs. "E plays Kitsu"
   because `ability4` is literally a clone of Kitsu's ability (`CloneConfig` copies `b.ability4`),
   so the real, networked ult is still Kitsu's.

**Root cause in one sentence:** the approach tried to *graft* a character onto one client after the
fact, but BAPBAP's visibility, animation, and abilities are all **server-authoritative and
replicated by a baked `assetId` + custom `netId`-keyed state stream**, none of which a single-client
runtime graft can satisfy.

---

## 9. Design implications for the correct, from-scratch integration

1. **Ship the prefab in the build, identically on server and clients.** Build each custom character
   body and each custom ability/projectile/hitbox as a real Unity prefab with a root
   `NetworkIdentity` and a **baked `assetId`**. The server and all clients must load the *same*
   asset (same id). This is the only way `NetworkServer.Spawn` → `SpawnMessage(assetId)` →
   `NetworkClient.prefabs[assetId]` round-trips on every peer.

2. **Register through `NetworkPrefabLibrary`, not just `spawnPrefabs`.** Add new entities to
   `InstantiatedPrefabs` (1:1) or `PooledPrefabs` (pooled). Then `OnStartServer`
   (`ServerCreate`) and `OnStartClient` (`RegisterPrefab`/`ClientCreate`) wire them up on both
   sides automatically (`GameNetworkManager.cs:244-254`, `NetworkPrefabPool.cs:83-107`).

3. **Make the server authoritative.** New characters must be spawned by the server in
   `GameMode.SpawnPlayerChar`-equivalent flow: index `characterPrefabsByCharId[charId]`, set the
   `EntityManager` SyncVars (`charId`, `isPrimary`, `playerObj`, `charInstanceId`), then
   `NetworkServer.Spawn(obj, conn)` (`GameMode.cs:1064-1079`). New abilities must spawn their
   entities server-side via `NetworkServer.Spawn` (pattern: `CatShotAbility.cs:300`,
   `RockyRuptureAbility.cs:259`, etc.) and be cleaned up via `NetworkServer.Destroy`/pool despawn.

4. **Let the body participate in `EntityNetworkSystem`.** Include `CharNetwork` (+ `CharSim`,
   `CharEvents`, `CharAnimator`, `CharMaterial`) so the body registers in `EntityNetworkSystem`
   (`CharNetwork.cs:116-126`) and is driven by the `netId`-keyed `StateSyncMessage` stream
   (`EntityNetworkSystem.cs`). That is what makes remote movement/animation/aim/abilities replicate
   instead of freezing.

5. **Extend the `charId` roster cleanly.** Add a new `charId` slot and ensure
   `characterPrefabsByCharId`, `charBotPrefabsByCharId`, the UI `UICharactersConfiguration`, and the
   ability/animation tables are all sized and populated for it — on **both** server and client
   builds. (The ability/animation wiring per-`charId` is the subject of the sibling research
   stages; R02's mandate is the networking/registration spine documented here.)

---

## 10. Primary source index (file:line)

- `Network\GameNetworkManager.cs:18` — `GameNetworkManager : NetworkManager`.
- `Network\GameNetworkManager.cs:39-55` — `ClInitMsg` / `SvInitMsg` message structs.
- `Network\GameNetworkManager.cs:244-254` — **client prefab registration** (`PooledPrefabs` →
  `NetworkPrefabPool.ClientCreate`; `InstantiatedPrefabs` → `NetworkClient.RegisterPrefab`).
- `Network\GameNetworkManager.cs` `OnStartServer` — **server prefab registration**
  (`NetworkPrefabPool.ServerCreate` loop; `NetworkServer.RegisterHandler<ClInitMsg>`;
  `entityNetworkSystem.OnStartServer`).
- `Network\GameNetworkManager.cs:262-279` — client handshake (`RegisterHandler<SvInitMsg>`, send
  `ClInitMsg`).
- `Network\GameNetworkManager.cs` `OnServerDevLobbyClInit` / `OnServerMatchmakingClInit` —
  `Instantiate(playerPrefab)`, validation, `SvInitMsg` reply.
- `Network\GameNetworkManager.cs:222-230` + `:36-45` — bot prefab selection
  (`GetCharacterBotPrefab` / `CharacterBotPrefabs.GetBotPrefab`).
- `Pooling\NetworkPrefabLibrary.cs` — `InstantiatedPrefabs[]`, `PooledPrefabs[]`.
- `Pooling\NetworkPrefabPool.cs:31-33` — `netIdLookup` (GameObject→assetId), `poolLookup`
  (assetId→pool).
- `Pooling\NetworkPrefabPool.cs:83-107` — `Create`: requires `NetworkIdentity`, keys on `assetId`,
  client-side `NetworkClient.RegisterPrefab(prefab, SpawnHandler, DespawnHandler)`.
- `Pooling\NetworkPrefabPool.cs:109-119` — `Spawn` (prefab→assetId→pool→`Pop`).
- `Game\GameMode.cs:1054-1090` — `SpawnPlayerChar`: prefab by `charId`, set SyncVars,
  `NetworkServer.Spawn(obj, conn)` at `:1079`.
- `Game\GameMode.cs:1140-1165` — `SpawnBotChar`: `NetworkServer.Spawn(obj)`.
- `Game\GameMode.cs:1990` — `NetworkServer.Destroy(primaryCharManager.gameObject)` (teardown).
- `Game\GameManager.cs:623`, `:1027` — `NetworkServer.AddPlayerForConnection(conn, player)`.
- `Systems\EntityNetworkSystem.cs:39-43` — `Register` (caches by `netId`).
- `Systems\EntityNetworkSystem.cs:84-129` — server `StateSyncMessage` send.
- `Systems\EntityNetworkSystem.cs:154-228` — client `OnTargetStateSync`; `netId` dispatch +
  `NetworkClient.spawned` fallback; `:172` "No Char Network found for netId=" log.
- `Entities\CharNetwork.cs:116-126` — `OnStartClient` registers into `EntityNetworkSystem`.
- `Assets\MonoBehaviour\NetworkPrefabLibrary.asset` — live registry (~470 `InstantiatedPrefabs`,
  ~190 `PooledPrefabs`).
- `Assets\MainScene.unity:139293` — `GameNetworkManager` component (script guid
  `566b40619a546af9d532326d07708085`). *Note:* the exporter stripped its serialized arrays
  (`characterPrefabsByCharId`/`spawnPrefabs` are not recoverable from the ripped scene YAML), so
  those values were read from code paths and the failed mod's reflective access instead.
- **Failed approach:** `BAPBAPModdingAPI\bapcustomchars-mod\MedusaMod.cs` — `RegisterPrefab`,
  `TryConfigureMirrorPrefab` (sets `_assetId`), `SanitizeMirrorIdentities`, `TryAddSpawnPrefab`,
  `TryRegisterNetworkPrefabPool`, `RunAuthoredMedusaAbilityDriver`, `SpawnMedusaCastFx`,
  `CanSpawnClientFx`. `CustomCharFramework.cs:41` — hardcoded `MirrorAssetId = 1296385109`
  (`0x4D454455`).
```
