# R15 — Bundle Runtime Loading + Mirror Registration

**Scope:** Determine exactly what is required to (a) load a custom prefab from an
AssetBundle at runtime and (b) register it with Mirror so it **replicates to every
peer**. Focus areas: `assetId` consistency across server + clients, `NetworkIdentity`
requirements, and whether a bundle-authored prefab can carry a stable `assetId`.

**Cross-reference:** R02 (entity/player spawn architecture). This stage confirms R02's
core finding from the networking side: the playable character is a **separate networked
`EntityManager` GameObject**, spawned by the server via `NetworkServer.Spawn`, *not* the
`PlayerManager`/`playerPrefab` object. Everything below builds on that.

**Engine/stack confirmed:** Unity 2022.3.38f1, IL2CPP, Mirror networking
(`Il2CppMirror`, `Il2CppMirror.Transports`, `Il2CppMirror.Components`, all version
`0.0.0.0`) — see
`C:\Users\Administrator\Downloads\neueBapbap\ConfigurateModBYMojo\Configurate\Configurate\bin\Debug\net6.0\Configurate.deps.json:439,463,503`
and `C:\Users\Administrator\Downloads\neueBapbap\BAPBAPMOD\BAPBAPMod\buildlog.txt:1973,3493,3528`.

> **Source note.** Most of `…\_DisabledScripts\Assembly-CSharp\BAPBAP` is decompiled with
> **stubbed method bodies** (e.g.
> `…\Network\GameNetworkManager.cs` returns `null`/empty). The **full method bodies** live
> in the secondary export
> `C:\Users\Administrator\Downloads\neueBapbap\GEHEIMBUILD\ExportedProject\Assets\Scripts\Assembly-CSharp\BAPBAP`.
> All game-logic citations below use the GEHEIMBUILD copy. Mirror itself ships as a
> compiled assembly (no `.cs`), so Mirror internals are corroborated through the game's
> own usage and the failed mod's reflection into Mirror fields.

---

## 1. How the stock game spawns a networked character (the contract we must satisfy)

`BAPBAP.Game.GameMode.SpawnPlayerChar` is the authoritative spawn path
(`…\GEHEIMBUILD\…\BAPBAP\Game\GameMode.cs`):

```csharp
// GameMode.cs:1054
public void SpawnPlayerChar(PlayerManager playerManager, Vector3 spawnPos = default)
{
    if (playerManager == null || playerManager.charId < 0
        || playerManager.charId >= netManager.characterPrefabsByCharId.Length
        || playerManager.primaryCharManager != null)            // GameMode.cs:1056
        return;
    ...
    GameObject original = netManager.characterPrefabsByCharId[playerManager.charId]; // :1064
    // (skin override may swap `original` for skinByAssetId.config.characterPrefab)
    GameObject obj = UnityEngine.Object.Instantiate(original, spawnPos, Quaternion.identity); // :1073
    EntityManager component = obj.GetComponent<EntityManager>();
    component.NetworkisPrimary    = true;
    component.NetworkplayerObj    = playerManager.gameObject;
    component.NetworkcharInstanceId = component.GetInstanceID();
    component.NetworkcharId       = playerManager.charId;
    NetworkServer.Spawn(obj, playerManager.connectionToClient); // :1079  <-- replicates
    ...
}
```

Bots use the identical pattern — `SpawnBotChar` instantiates
`GameNetworkManager.GetCharacterBotPrefab(charId, difficulty)` then
`NetworkServer.Spawn(obj)` (`GameMode.cs:1151,1159`).

**Key facts established here:**

1. The character body is an **independent networked object** keyed by `charId` into
   `GameNetworkManager.characterPrefabsByCharId` (declared
   `[SerializeField] public GameObject[] characterPrefabsByCharId;` in
   `…\GEHEIMBUILD\…\BAPBAP\Network\GameNetworkManager.cs`).
2. It carries a root `EntityManager`, which is a Mirror `NetworkBehaviour` (the
   `Network<field>` accessors are Mirror `[SyncVar]` setters). Therefore the prefab
   **must** have a `NetworkIdentity`.
3. The server calls `NetworkServer.Spawn(obj, conn)`. Mirror then sends a `SpawnMessage`
   to every observer. **That message identifies the prefab solely by its
   `NetworkIdentity.assetId`.** Each client instantiates whatever prefab it has
   registered under that `assetId`.

Any custom-character solution must produce a prefab that the **server** spawns through
this exact path and that **every client** can resolve from the same `assetId`.

---

## 2. How prefabs get registered with Mirror in this game

Two mechanisms, both real code:

### 2a. Pooled + instantiated library prefabs (`OnStartServer` / `OnStartClient`)

`…\GEHEIMBUILD\…\BAPBAP\Network\GameNetworkManager.cs`:

```csharp
public override void OnStartServer()
{
    for (int i = 0; i < networkPrefabLibrary.PooledPrefabs.Length; i++)
        NetworkPrefabPool.ServerCreate(networkPrefabLibrary.PooledPrefabs[i]);
    ...
}

public override void OnStartClient()
{
    for (int i = 0; i < networkPrefabLibrary.PooledPrefabs.Length; i++)
        NetworkPrefabPool.ClientCreate(networkPrefabLibrary.PooledPrefabs[i]);
    for (int j = 0; j < networkPrefabLibrary.InstantiatedPrefabs.Length; j++)
        NetworkClient.RegisterPrefab(networkPrefabLibrary.InstantiatedPrefabs[j]);
    ...
}
```

`NetworkPrefabPool.Create` is the canonical demonstration of how `assetId` drives Mirror
registration (`…\GEHEIMBUILD\…\BAPBAP\Pooling\NetworkPrefabPool.cs`):

```csharp
public static void Create(Config config, bool isServer)
{
    if (config.prefab.TryGetComponent<NetworkIdentity>(out var component))
    {
        uint assetId = component.assetId;                 // <-- assetId is the key
        if (!poolLookup.TryGetValue(assetId, out var value))
        {
            value = new NetworkPrefabPool(config, assetId, isServer);
            netIdLookup[config.prefab] = assetId;
            poolLookup[component.assetId] = value;
            poolList.Add(value);
        }
        if (!isServer)
            NetworkClient.RegisterPrefab(config.prefab, value.SpawnHandler, value.DespawnHandler);
        return;
    }
    throw new Exception("NetworkPrefabPool unable to create prefab pool, missing NetworkIdentity " + config.prefab.name);
}
```

This proves three things that hold for **all** Mirror prefabs in this build:
- `assetId` is a **`uint`** read off the prefab's `NetworkIdentity`.
- A prefab **without** a `NetworkIdentity` throws and cannot be pooled/registered.
- Clients map `assetId → prefab` via `NetworkClient.RegisterPrefab(...)` (with optional
  spawn/despawn handlers for pooled types).

### 2b. Character prefabs are registered via `NetworkManager.spawnPrefabs`

`characterPrefabsByCharId` is **not** iterated in `OnStartClient`. The character bodies
replicate because Mirror's base `NetworkManager` auto-registers `playerPrefab` and the
`spawnPrefabs` list on the client during connection setup. The failed mod relies on
exactly this and documents it (`…\BAPBAPModdingAPI\bapcustomchars-mod\MedusaMod.cs`,
`TryConfigureMirrorPrefab`):

> "Mirror client registration delegated to `NetworkManager.spawnPrefabs` for
> `assetId=0x{MedusaMirrorAssetId:X8}`; skipped direct `NetworkClient.RegisterPrefab`."

and its `TryAddSpawnPrefab` appends to `((NetworkManager)gnm).spawnPrefabs`
(`MedusaMod.cs`, method `TryAddSpawnPrefab`). So the supported registration channel for a
**character body** prefab is:

- **Server:** the prefab is in `characterPrefabsByCharId` (so `SpawnPlayerChar` can
  instantiate it) **and** in `spawnPrefabs` (so Mirror knows its `assetId`).
- **Client:** the prefab is in `spawnPrefabs` (auto-registered) **or** explicitly
  `NetworkClient.RegisterPrefab(prefab, assetId)`'d before the first `SpawnMessage`.

---

## 3. `assetId` semantics in this Mirror version

### What `assetId` is
- A serialized **`uint`** on `NetworkIdentity` (backing field `_assetId`; the failed mod
  writes it directly: `val._assetId = MedusaMirrorAssetId;` in
  `MedusaMod.TryConfigureMirrorPrefab`).
- In the editor, Mirror assigns it from the prefab's asset GUID at import/validate time.
  It is **baked into the serialized prefab**. For an asset (project/bundle) prefab,
  `sceneId == 0` and `assetId != 0`; for a scene-placed object it is the reverse. The mod
  enforces this invariant for its runtime prefab by zeroing `sceneId`
  (`SanitizeMirrorIdentities`: `val.sceneId = 0uL;`).

### The hard consistency rule (this is the crux of replication)
`NetworkServer.Spawn` writes the prefab's `assetId` into the `SpawnMessage`; the client
looks it up in `NetworkClient.prefabs[assetId]`. Therefore:

> **The server and every client must register the same `assetId` mapped to a prefab whose
> `NetworkBehaviour` component set and ordering are identical.** If the client has no
> prefab for that `assetId`, the spawn is dropped (the object never appears / disappears).
> If the prefab differs in `NetworkBehaviour` layout, Mirror's per-component SyncVar
> payload deserializes against the wrong component and the object desyncs or errors.

This single rule explains the previous failure's symptoms (see §6).

### Can a bundle-authored prefab carry a stable `assetId`? — **Yes, with caveats**
- If the custom prefab is authored in a Unity project **that has Mirror's
  `NetworkIdentity`**, the `_assetId` value is serialized into the prefab and survives
  into the AssetBundle. Loading it at runtime yields a `NetworkIdentity` whose `assetId`
  is whatever was baked.
- **Caveat 1 — uniqueness/agreement:** A bundle built independently has no guarantee its
  baked `assetId` matches anything, and could even collide with a stock prefab's
  `assetId`. The robust pattern is to **force a deterministic `assetId` at runtime on
  every peer** rather than trust the bake. Mirror exposes this two ways:
  - the writable field (`identity._assetId = X`) as the mod does, and/or
  - `NetworkClient.RegisterPrefab(GameObject prefab, uint assetId)` (the explicit-assetId
    overload) on clients.
  The server must set the same `X` on its copy **before** `NetworkServer.Spawn`.
- **Caveat 2 — IL2CPP serialization fidelity:** custom `MonoBehaviour`/`NetworkBehaviour`
  scripts cannot be added by a bundle in an IL2CPP build (no JIT; types must exist in the
  game assembly). A bundle can safely carry **art/animation/meshes/materials/prefab
  structure**, but any `NetworkBehaviour` on the networked root must be a **type that
  already exists in the game** (`EntityManager`, `CharAbilities`, `CharMaterial`, …). This
  is why the working asset-bundle tool builds a **stripped, visual-only** prefab
  (`<Name>_Visual` with `Animator` + renderers only, all MonoBehaviours removed) — see
  `C:\Users\Administrator\Downloads\CustomServer\analysis\char-bundle-tool-report.md`
  ("Builds a stripped visual-only `<Name>_Visual` prefab … keeping `Animator` +
  renderers"). That visual prefab has **no `NetworkIdentity`** and therefore **cannot be
  the networked object** — it can only be parented under one.

**Conclusion for R15:** A bundle prefab *can* carry a stable `assetId` only if it was
authored with the game's real `NetworkIdentity`/`NetworkBehaviour` types present. In the
mod-from-bundle workflow that is not the case (IL2CPP). Therefore the **networked root
prefab must be constructed from the game's own character prefab template** (which already
has the correct `NetworkIdentity` + `NetworkBehaviour` chain), and the **bundle supplies
only the visual subtree**. The `assetId` for the new character must be **assigned
explicitly and identically on server and all clients at runtime.**

---

## 4. `NetworkIdentity` requirements for a replicating custom character

From the code in §1–§2, a custom-character networked prefab must satisfy all of:

1. **Exactly one `NetworkIdentity` on the root** (the object passed to
   `NetworkServer.Spawn`). `NetworkPrefabPool.Create` and `SpawnPlayerChar`'s
   `GetComponent<EntityManager>()` both assume the root identity.
2. **A non-zero, peer-agreed `assetId`** and `sceneId == 0` (asset prefab, not scene
   object). The mod zeroes `sceneId`, `_netId`, `hasSpawned`,
   `_SpawnedFromInstantiate`, `destroyCalled`, `serverOnly`, both connection backing
   fields, then calls `InitializeNetworkBehaviours()` (`MedusaMod.SanitizeMirrorIdentities`).
   These resets are mandatory when a prefab is produced at runtime (cloned/instantiated),
   because a live identity carries spawn state that must not leak into a prefab template.
3. **Identical `NetworkBehaviour` component set and order on server and clients.** Mirror
   serializes spawn/sync payloads per `NetworkBehaviour` **by component index**. The new
   character must keep the stock chain (`EntityManager` + `CharAbilities` +
   `CharMaterial` + `CharAnimator` + movement/aim/hurtbox + any transform sync) in the
   same order as the base prefab. Adding/removing/reordering these between peers breaks
   deserialization.
4. **Registration on both sides before the first spawn:** server-side presence in
   `characterPrefabsByCharId` (instantiation) and `spawnPrefabs` (assetId knowledge);
   client-side presence in `spawnPrefabs` or an explicit
   `NetworkClient.RegisterPrefab(prefab, assetId)`. Registration must complete **before**
   `NetworkServer.Spawn` is observed by that client (i.e. during
   `OnStartClient`/lobby, not mid-match).

---

## 5. Loading the prefab from an AssetBundle at runtime (IL2CPP)

The failed mod already demonstrates the working IL2CPP load path
(`MedusaMod.TryLoadBundle` / `TryLoadAssetTyped`):

```csharp
_bundle = Il2CppAssetBundleManager.LoadFromFile(text);          // load the bundle
Il2CppStringArray names = _bundle.GetAllAssetNames();           // enumerate
Il2CppSystem.Type goType = Il2CppType.Of<GameObject>();
Object val = _bundle.LoadAsset(name, goType);                   // typed load
GameObject go = ((Il2CppObjectBase)val).Cast<GameObject>();     // interop cast
```

Notes that matter for R15:
- Use **`Il2CppAssetBundleManager.LoadFromFile`** + **`Il2CppAssetBundle.LoadAsset(name,
  Il2CppType.Of<T>())`**; cast results with `((Il2CppObjectBase)o).Cast<T>()`. Plain
  `AssetBundle.LoadFromFile` is not the interop-safe entry point here.
- The bundle is **self-contained** (the bundle tool reports `Dependencies: []`,
  `char-bundle-tool-report.md`), so a single `LoadFromFile` is sufficient; no shared
  shader/dependency bundle must be pre-loaded. Shaders, however, must resolve at runtime
  (the mod re-creates URP/particle materials via `Shader.Find` because authored shader
  variants may be stripped on the target — relevant to visuals, not to replication).
- `LoadAsset` alone (no `Instantiate`) is cheap and headless-safe; the dedicated Linux
  match-host runs `-batchmode -nographics`, and the mod gates all *instantiation* of
  visual assets behind `CanSpawnClientFx()` (false in batch mode). For the **networked
  root**, instantiation happens on the server regardless (it must spawn the entity), so
  the networked root must be loadable/instantiable headlessly — i.e. it cannot depend on
  graphics-only components to exist.

**Bundle → networked prefab assembly (the correct shape):**
1. Server and clients all load the same bundle and obtain the `<Name>_Visual` GameObject
   (art + `Animator` only, no `NetworkIdentity`).
2. Build the networked character prefab from the **game's base character prefab template**
   (which has the real `NetworkIdentity` + `NetworkBehaviour` chain), parent/replace the
   visual subtree with the bundle's `<Name>_Visual`, and rebind `CharAnimator`/
   `CharMaterial`/`CharFootsteps` to the new visual's `Animator`/renderers.
3. Assign the agreed `assetId`, sanitize identity state (§4.2), register into
   `characterPrefabsByCharId` + `spawnPrefabs` (server) and `spawnPrefabs`/`RegisterPrefab`
   (client).
4. The server's `SpawnPlayerChar` then instantiates and `NetworkServer.Spawn`s it; clients
   resolve the identical `assetId` and instantiate their copy with the same visual.

This must be done **identically and deterministically on every peer** — the same `assetId`,
the same component chain, the same charId slot — which is precisely what the previous
implementation did **not** guarantee (§6).

---

## 6. Why the previous (failed) approach broke — mapped to R15 mechanics

The prior framework
(`…\BAPBAPModdingAPI\bapcustomchars-mod\MedusaMod.cs` +
`CustomCharFramework.cs`) used a hardcoded `assetId`
(`MirrorAssetId = 1296385109u` = `0x4D454455` "MEDU", in
`CustomCharFramework.cs`) and, at runtime, **cloned the base Kitsu character prefab**
(`RegisterPrefab` → `Object.Instantiate(baseKitsuPrefab)` → `GraftMedusaVisual`), set
`_assetId`, and appended it to `spawnPrefabs`. Cross-referenced to §1–§4:

| Reported symptom | R15 root cause |
|---|---|
| **Not visible to other players; visuals/attacks only local** | The visual graft (`GraftMedusaVisual`, bundle `Medusa_Visual`) is **client-side presentation** only. The networked body the **server** spawned was still the base prefab/`charId`; other clients instantiated *their* registered prefab for that `assetId` (base Kitsu), so they saw Kitsu, not the custom visual. The custom mesh never travelled through `SpawnMessage`. |
| **Despawns** | `assetId` disagreement. If a client lacked a prefab registered under the forced `assetId` (registration race vs. first `SpawnMessage`, or server spawning a different prefab than the client registered), Mirror drops/destroys the object. The mod itself fights this with `SanitizeMirrorIdentities` resets — a symptom of feeding live/duplicated identities into the spawn path. |
| **Frozen poses (Standbilder)** | The replicated `CharAnimator` drove the **base rig**, while the grafted bundle `Animator` was an unmanaged extra; repeated re-anchoring/rebind (`CharAnimatorRebindPatch`, `FitMedusaVisualToBaseBounds`) re-parented/re-scaled the visual every pass. The visual was never the network-authoritative animated object, so it stalled. |
| **Abilities broken (only LMB; RMB green dot; Space bugs; E plays Kitsu)** | The entity ran **Kitsu's** ability components (`CatShotAbility`, `ArrowAbility`, …). The mod tried to suppress/redirect them client-side (`TrySuppressInheritedKitsuShoot`, authored driver in `ApplyAuthoredMedusaGameplay`) and spawn presentation-only hitboxes. Because abilities are real `NetworkBehaviour`/server gameplay, client-side grafting yields exactly this: LMB's local FX fires, other slots map to mismatched Kitsu abilities. Real custom abilities require server-authoritative ability components in the spawned prefab's chain (out of R15's scope, but the registration constraint in §4.3 is the gating reason a client-only graft can never fix it). |

**The structural mistake (R15 lens):** the custom character was assembled and registered
**client-side and inconsistently**, while the server kept spawning a stock prefab/charId.
Replication requires the *server* to spawn the custom prefab and *all* peers to share one
`assetId → identical-NetworkBehaviour-prefab` mapping. None of those invariants held.

---

## 7. Requirements checklist for a correct, replicating bundle-loaded character

1. **One bundle, loaded identically on every peer** via
   `Il2CppAssetBundleManager.LoadFromFile` → `LoadAsset` (typed) — server included
   (headless-safe; networked root must instantiate without graphics).
2. **Networked root built from the game's base character prefab template** (keeps the real
   `NetworkIdentity` + ordered `NetworkBehaviour` chain). The bundle supplies the **visual
   subtree only** (no `NetworkIdentity`, no game `MonoBehaviours` — IL2CPP cannot add new
   ones from a bundle).
3. **A single deterministic `uint assetId` per custom character**, assigned identically on
   server and clients (`identity._assetId = X` and/or
   `NetworkClient.RegisterPrefab(prefab, X)`), with `sceneId = 0` and spawn-state fields
   sanitized (`_netId`, `hasSpawned`, `_SpawnedFromInstantiate`, connections) +
   `InitializeNetworkBehaviours()`.
4. **Server registration:** insert into `characterPrefabsByCharId[charId]` (so
   `GameMode.SpawnPlayerChar` instantiates it) **and** `NetworkManager.spawnPrefabs`.
5. **Client registration:** the prefab present in `spawnPrefabs` (auto-registered) or an
   explicit `NetworkClient.RegisterPrefab(prefab, assetId)` — completed in
   `OnStartClient`/lobby, **before** the first `SpawnMessage`.
6. **Component-layout parity** across peers (same chain, same order) so per-component
   SyncVar payloads deserialize correctly.
7. The server (not the client) drives `NetworkServer.Spawn(obj, conn)` for the player's
   character (`GameMode.cs:1079`) — i.e. the custom char must be selectable as the real
   `charId` the server spawns, not a client-side overlay.

Satisfying 1–7 is the difference between a real networked character and the previous
"local visual graft." Ability replication (slots, server gameplay, animations) layers on
top of this and depends on the same component-parity + server-spawn guarantees.

---

## 8. Primary sources (file:line)

- `…\GEHEIMBUILD\…\BAPBAP\Game\GameMode.cs:1054` `SpawnPlayerChar`; `:1064` prefab lookup;
  `:1073` `Instantiate`; `:1079` `NetworkServer.Spawn(obj, conn)`; `:1151,1159`
  `SpawnBotChar` spawn; `:822,851,989,1952` other `NetworkServer.Spawn`; `:828` pooled
  spawn.
- `…\GEHEIMBUILD\…\BAPBAP\Network\GameNetworkManager.cs`: `characterPrefabsByCharId`,
  `networkPrefabLibrary` fields; `OnStartServer` (`NetworkPrefabPool.ServerCreate` loop);
  `OnStartClient` (`NetworkPrefabPool.ClientCreate` + `NetworkClient.RegisterPrefab` loops);
  `GetCharacterBotPrefab`.
- `…\GEHEIMBUILD\…\BAPBAP\Pooling\NetworkPrefabPool.cs`: `Create` reads
  `component.assetId`, keys `poolLookup`/`netIdLookup` by `assetId`, calls
  `NetworkClient.RegisterPrefab(...)`; `ServerCreate`/`ClientCreate`; throws on missing
  `NetworkIdentity`.
- `…\_DisabledScripts\…\BAPBAP\Pooling\NetworkPrefabLibrary.cs`: `InstantiatedPrefabs`,
  `PooledPrefabs` shape.
- `…\BAPBAPModdingAPI\bapcustomchars-mod\MedusaMod.cs`: `TryLoadBundle` /
  `TryLoadAssetTyped` (`Il2CppAssetBundleManager.LoadFromFile`, `LoadAsset`);
  `TryConfigureMirrorPrefab` (`val._assetId = MedusaMirrorAssetId`);
  `SanitizeMirrorIdentities` (zeroes `sceneId`/`_netId`/`hasSpawned`/
  `_SpawnedFromInstantiate`, `InitializeNetworkBehaviours()`); `TryAddSpawnPrefab`
  (`NetworkManager.spawnPrefabs`); `RegisterPrefab` (clones base Kitsu prefab);
  `GraftMedusaVisual`, `TrySuppressInheritedKitsuShoot`, `ApplyAuthoredMedusaGameplay`.
- `…\BAPBAPModdingAPI\bapcustomchars-mod\CustomCharFramework.cs`:
  `MirrorAssetId = 1296385109u` (0x4D454455), `VisualPrefabName = "Medusa_Visual"`,
  `BaseCharId = 0` (Kitsu).
- `C:\Users\Administrator\Downloads\CustomServer\analysis\char-bundle-tool-report.md`:
  stripped visual-only `<Name>_Visual` prefab (Animator + renderers, MonoBehaviours
  removed), self-contained bundle (`Dependencies: []`).
- Mirror version: `…\ConfigurateModBYMojo\…\Configurate.deps.json:439,463,503`;
  `…\BAPBAPMOD\BAPBAPMod\buildlog.txt:1973,3493,3528` (`Il2CppMirror` 0.0.0.0).
