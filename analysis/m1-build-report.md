# M1 Build Report — NetworkedCustomChar (networked custom-char spine)

Date: 2026-06-12
Builder: build_m1 (orchestrated session)

## Result: BUILDS TO 0 ERRORS

```
dotnet build NetworkedCustomChar.csproj -c Release  ->  0 Warnung(en)  0 Fehler
```

## Artifact

| Field | Value |
|---|---|
| Path | `C:\Users\Administrator\Downloads\BAPBAPModdingAPI\netcustomchar-mod\bin\Release\NetworkedCustomChar.dll` |
| SHA256 | `75D9F219F5DD128CF5A58CB63E959039D2015C65640DFEF66C330FADA073D6CE` |
| Bytes | `20480` |
| TargetFramework | `net6.0` |
| PlatformTarget | `x86` (see correction #1) |
| MelonInfo | `NetworkedCustomChar 0.1.0 bapcustom` |

## Project layout (clean new mod — old `bapcustomchars-mod` untouched)

- `netcustomchar-mod\NetworkedCustomChar.csproj` — standalone, references MelonLoader / 0Harmony /
  Il2CppInterop.Runtime / Il2CppInterop.Common + Il2Cpp game proxies (Assembly-CSharp, Il2Cppmscorlib,
  Il2CppSystem, Il2CppSystem.Core, Il2CppMirror) + UnityEngine/CoreModule/AnimationModule/PhysicsModule.
  Does NOT reference `BAPBAP.ModAPI` (fully independent, per scope).
- `netcustomchar-mod\CustomCharMod.cs` — the M1 logic.

Reference hint paths resolve to the proven build root
`C:\Users\Administrator\Downloads\BAPBAPModdingAPI\Battleroyalebuild\MelonLoader\{net6,Il2CppAssemblies}`
(the same DLLs the working `bapcustomchars-mod` compiled against).

## What M1 does (matches M1-PREFAB-REGISTRATION-DESIGN.md)

1. Clones `characterPrefabsByCharId[0]` (Kitsu) inert → real networked root with weaved
   `NetworkIdentity` + full `Char*` chain. `GraftVisual=false` (Kitsu visual/abilities kept).
2. Sanitizes every child `NetworkIdentity` (`sceneId`, `_netId_k__BackingField`, `hasSpawned`,
   `_SpawnedFromInstantiate_k__BackingField`, `destroyCalled`, `serverOnly`,
   `_connectionToServer_k__BackingField`, `_connectionToClient`, `InitializeNetworkBehaviours()`).
3. Assigns a stable, peer-identical `_assetId = 0xB0B00F0F`, collision-checked by
   `AssertAssetIdFree` (scans `NetworkPrefabPool.poolLookup` + `NetworkClient.prefabs`; bumps on hit).
4. Installs identically on server AND client (same DLL): `characterPrefabsByCharId[15]`,
   `charBotPrefabsByCharId[15]`, `networkPrefabLibrary.InstantiatedPrefabs`, base
   `NetworkManager.spawnPrefabs`, and explicit `NetworkClient.RegisterPrefab(prefab, assetId)` +
   `NetworkPrefabPool.ClientCreate/ServerCreate` when the respective peer is active.
5. Adds a `UICharactersConfiguration._characters` row (charId 15, `enabledInLobby=true`) cloned from
   Kitsu's row and pushes `UpdateAvailableCharacterList(...)`; guards
   `UILobbyCharacterSelectPage.GetCharacterListingIndexFromCharId` for charId 15.
6. Sets NO SyncVars — the native `GameMode.SpawnPlayerChar` resolves charId 15 → our prefab and
   `NetworkServer.Spawn`s it. Bot hook does NOT rewrite charId (the old mod's fatal mistake).

Manual Harmony patching (per `BAPBAPMOD\AGENTS.md`): each `harmony.Patch(...)` is wrapped in
try/catch; all interop is lazy + guarded.

Hooks: `GameNetworkManager.Awake` (post), `OnStartServer` (post), `OnStartClient` (post),
`GetCharacterBotPrefab` (pre), `GameMode.SpawnPlayerChar` (pre),
`UICharactersConfiguration.OnEnable` (post),
`UILobbyCharacterSelectPage.GetCharacterListingIndexFromCharId` (pre).

## API-name corrections vs the design doc (verified against the REAL reference assemblies)

1. **PlatformTarget is x86, not x64.** The design/task said net6/x64, but the proven working mod
   (`BAPBAP.ModAPI.props`) and the shipped `Battleroyalebuild` run MelonLoader patched for **x86**
   (note `MelonLoader\net6\*.pre-x86support-20260504` backups). Built x86 to match reality.

2. **`charBotPrefabsByCharId` is `GameNetworkManager.CharacterBotPrefabs[]`, NOT `GameObject[]`.**
   The design's "install bot variant at `charBotPrefabsByCharId[15]`" cannot take a GameObject.
   Corrected: construct a `new CharacterBotPrefabs()` and set its `charBotEasy/charBotMedium/
   charBotHard/charBotExpert` to our prefab.

3. **`GameNetworkManager.GetCharacterBotPrefab` signature is `(int charId, BotDifficulty)`**, not the
   single-arg form implied by the doc. The Harmony prefix declares only `int charId` (Harmony injects
   by name), avoiding a dependency on the `BotDifficulty` type/namespace.

4. **`CharacterConfiguration` has NO `MediumSprite` field** in the actual reference assembly. The
   neueBapbap `_DisabledScripts` decomp lists `MediumSprite`, but the live Il2Cpp build does not — it
   exposes `name, descriptionTranslationKey, charId, enabledInLobby, enabledInDevLobby, Color,
   UIAccentColor, smallSprite, IconSprite, LobbyBackground, FullSprite, StandingSprite, CircleIcon,
   SquareIcon, SquareSmallIcon, gameStatsLobbySpriteModifier, DefaultSkin, abilityIconColor,
   abilityBGColor, titleTextColor, ability1..4`. Removed `MediumSprite` from the row clone.
   **Lesson: the `neueBapbap` decomp is a DIFFERENT build than the reference DLLs; the Il2Cpp
   reference assemblies (and the matching `BAPBAPModAPI\reverse-engineering\decompiled`) are the
   source of truth for compilation.**

5. **`GameObject.GetComponentsInChildren<NetworkIdentity>(true)` returns `Il2CppArrayBase<T>`, not
   `Il2CppReferenceArray<T>`.** Declared the local as `Il2CppArrayBase<NetworkIdentity>` (matches the
   proven `MedusaMod.SanitizeMirrorIdentities`).

6. **`UICharactersConfiguration._characters` is the writable field** (the design used it); the public
   `Characters` getter is read-only — write through `_characters` and call
   `UpdateAvailableCharacterList(int[])` (verified).

7. **`NetworkClient.RegisterPrefab(GameObject, uint)` overload confirmed** in `Il2CppMirror`
   (alongside 6 other overloads); `NetworkClient.active` / `NetworkServer.active` and
   `NetworkClient.prefabs` (`Dictionary<uint,GameObject>`) / `NetworkPrefabPool.poolLookup`
   (`Dictionary<uint,NetworkPrefabPool>`) all confirmed.

8. **Non-Unity Il2Cpp classes use plain `== null`, not the Unity fake-null operator.**
   `CharacterConfiguration` and `CharacterBotPrefabs` derive from `Il2CppSystem.Object`, not
   `UnityEngine.Object`; casting them through `UnityEngine.Object` for null checks would throw
   `InvalidCastException` at runtime. The `IsNull(UnityEngine.Object)` helper is used ONLY for
   `GameObject`/`NetworkIdentity`/`GameNetworkManager`/ScriptableObject types.

9. `GameMode.SpawnPlayerChar` is at a different source line than the doc's `:1054` (it's `:920` in the
   neueBapbap decomp) — signature `void SpawnPlayerChar(PlayerManager, Vector3=default)` confirmed; the
   line number does not affect the build.

10. **GameObject identity dedup uses Unity's `==`, not `object.ReferenceEquals`.** Il2CppInterop can
    hand out a new managed wrapper for the same native pointer, so `ReferenceEquals` would report
    "not present" and re-append to `spawnPrefabs` / re-grow the charId table on every hook call.
    Switched to the `UnityEngine.Object ==` operator (pointer-based), matching the proven `MedusaMod`.

Verified-and-unchanged names (design was correct): `GameNetworkManager.Instance`,
`characterPrefabsByCharId`, `networkPrefabLibrary`, `NetworkPrefabLibrary.InstantiatedPrefabs` /
`PooledPrefabs`, `NetworkPrefabPool.Config{prefab,initialSizeServer,initialSizeClient,resizeStrategy}`,
`ResizeStrategy.Increment`, `NetworkIdentity._assetId/sceneId/hasSpawned/_netId_k__BackingField/
_SpawnedFromInstantiate_k__BackingField/destroyCalled/serverOnly/_connectionToServer_k__BackingField/
_connectionToClient/InitializeNetworkBehaviours()`.

## Scope honored

- M1 only. No abilities, no visual graft (`GraftVisual=false`, AssetBundle load deferred to M2).
- Old `bapcustomchars-mod` NOT modified; only mined for proven accessor names.
- Not deployed to server/client (orchestrator handles deploy + the live 2-client test).

## Blockers / caveats

- **Cannot be validated end-to-end here** (M1 acceptance needs the modded DLL running on the dedicated
  server + 2 clients). The orchestrator owns that test.
- **assetId collision** is handled at runtime by `AssertAssetIdFree`, but the chosen sentinel
  `0xB0B00F0F` is only verified non-colliding once a `GameNetworkManager` exists; if a shipped prefab
  baked that exact id, the runtime scan bumps it (logged).
- **`GameNetworkManager.Awake` timing**: build runs in the `Awake` postfix (before
  `OnStartServer/OnStartClient`); the `OnStart*` postfixes and `SpawnPlayerChar` prefix are idempotent
  backstops if `Instance` is not ready at `Awake` in some load order.
- Component-layout parity holds only because every peer clones from its own identical build + identical
  DLL (no AssetBundle divergence in M1).



---

# M2 / M3 Build Report — NetworkedCustomChar (networked Medusa: visual + abilities)

Date: 2026-06-12
Builder: build_m2_m3 (orchestrated session)

## Result: BUILDS TO 0 ERRORS / 0 WARNINGS

```
dotnet build NetworkedCustomChar.csproj -c Release  ->  0 Warnung(en)  0 Fehler
```

## Artifact

| Field | Value |
|---|---|
| Path | `C:\Users\Administrator\Downloads\BAPBAPModdingAPI\netcustomchar-mod\bin\Release\NetworkedCustomChar.dll` |
| SHA256 | `C7E4D6E59BA38AA56C8BEE9D87064154DC5B1E62AF2D5210606C55A2225391D7` |
| Bytes | `43520` |
| TargetFramework / Platform | `net6.0` / `x86` |
| MelonInfo | `NetworkedCustomChar 0.1.0 bapcustom` |

## Files the SERVER (and every client) needs

1. The DLL above → game `Mods\NetworkedCustomChar.dll` (SAME DLL on dedicated server + both clients).
2. The Medusa bundle → `UserData\Medusa\medusa.bundle` relative to the game root
   (source: `CustomServer\Spiel\Battleroyalebuild\UserData\Medusa\medusa.bundle`;
   asset `Medusa_Visual`, controller `Medusa`). Override with env `BAPBAP_NETCUSTOM_BUNDLE=<full path>`.
   Fallback search order: `UserData\Medusa\medusa.bundle`, `UserData\medusa.bundle`, `Mods\medusa.bundle`,
   `medusa.bundle`.
3. Optional test env: `BAPBAP_NETCUSTOM_AUTOSELECT=1` to auto-pick charId 15.

## New source files (added to the M1 project, M1 logic preserved)

- `MedusaVisualGraft.cs` — Part B. Bundle load + graft, baked into the prefab TEMPLATE.
- `MirrorInterop.cs` — Part C #1. Manual `RegisterRpc` + ushort-hash recovery via `remoteCallDelegates` scan.
- `CustomNetChannel.cs` — Part C #2. One manual `[ClientRpc]` on `EntityManager` + render-gated VFX presenter.
- `CustomAbilityEngine.cs` — Part C #3. Server-authoritative ability engine.
- `CustomCharMod.cs` — extended for Part A (reliable UI + autoselect), Part B wiring, Part C patches/registration.
- `NetworkedCustomChar.csproj` — added `UnityEngine.AssetBundleModule` + MelonLoader
  `UnityEngine.Il2CppAssetBundleManager` references.

## PART A — selectability (WORKS, compiles)

- Kept the `UICharactersConfiguration.OnEnable` postfix, and ADDED a reliable polled path: `OnUpdate`
  (~2×/sec) calls `Resources.FindObjectsOfTypeAll<UICharactersConfiguration>()` and re-injects the
  charId-15 row + `UpdateAvailableCharacterList(int[])`. The row clone uses ONLY fields confirmed present
  on the real `CharacterConfiguration` (no `MediumSprite`, per M1 correction #4).
- Env-gated autoselect (`BAPBAP_NETCUSTOM_AUTOSELECT=1`): finds a live `PlayerDebug` and calls the REAL
  server-authoritative method `PlayerDebug.SwitchCharacter(int charToSwitchId, int skinAssetId = -1)`
  (`Il2CppBAPBAP.Player`), falling back to `PlayerDebug.CmdSwitchCharacter(int)`. Both verified in the
  decompiled `Assembly-CSharp`.

## PART B — networked Medusa visual (WORKS, compiles)

- `GraftVisual = true`. `BuildNetworkedPrefab` now calls `MedusaVisualGraft.Graft(clone, …)` so the Medusa
  model is baked INTO the prefab template `Char_Custom15`. Same DLL + same bundle on every peer ⇒ identical
  child layout; the grafted subtree has NO `NetworkIdentity`/`NetworkBehaviour`, so the Mirror component
  layout of the networked chassis is unchanged and the visual replicates with the prefab.
- Reused the PROVEN, known-working Il2Cpp graft accessors from the old `bapcustomchars-mod\MedusaMod.cs`
  (verbatim): `Il2CppAssetBundleManager.LoadFromFile` → `Il2CppAssetBundle.LoadAsset(name, Il2CppType)`,
  disable base `Renderer`s (`enabled=false`, `forceRenderingOff=true`), `Object.Instantiate(prefab, parent,
  false)`, wire `CharAnimator.animator = medusaAnimator` + `CharAnimator.customAnimator = true`, wire
  `CharFootsteps.animator`, disable non-Medusa `Animator`s, and clone the base toon shader onto Medusa's
  `SkinnedMeshRenderer`s preserving Medusa's albedo/normal textures.
- Live re-wire: `CharAnimator.Awake` + `CharFootsteps.Awake` postfixes re-find Medusa's Animator under the
  spawned instance and re-apply (Awake resets `.animator`), gated to charId 15.
- Anti-frozen-pose guards: `Animator.SetLayerWeight(int,float)` and
  `Animator.CrossFadeInFixedTime(int,float,int,float)` prefixes suppress out-of-range layer calls from the
  swapped Medusa controller (ported from the proven guards).
- Headless-safe: the SkinnedMeshRenderer graft + animator wiring run on every peer; GPU-ish material/shader
  rebind is gated behind `CanSpawnClientFx()` (`!Application.isBatchMode`).

## PART C — abilities (server-authoritative; compiles; one layer stubbed)

- `MirrorInterop` + `CustomNetChannel`: FULLY IMPLEMENTED and compiling. Registered identically on server +
  clients at init via `RemoteProcedureCalls.RegisterRpc(Il2CppType.Of<EntityManager>(), RpcName, handler)`;
  the exact stored ushort hash is recovered by scanning the public `remoteCallDelegates` dictionary and
  matching `GetFunctionMethodName`. Server `Broadcast` uses `NetworkWriterPool.Get()` +
  `NetworkWriterExtensions.WriteInt/WriteVector3` + `NetworkBehaviour.SendRPCInternal(name, hash, writer, 0,
  includeOwner:true)`; client receiver reads with `NetworkReaderExtensions` and presents render-gated.
- `CustomAbilityEngine`: server-authoritative. On a custom-char (charId 15) cast-start it applies REAL
  networked damage + status through the proven `[Server]` funnel
  `CharHurtbox.ApplyHit(dmg, StatusEffectInfo[], ownerPid, srcGO, …, dir, …)` with poison/petrify
  `StatusEffectSO`s resolved by name (`SE_Poisoned_SO` / `SE_Petrified_SO`) from `StatusEffectManager`.
  Damage/poison/petrify replicate to all peers via the game's own HP+status networking, so every player
  sees the result. A cosmetic VFX cue is broadcast to all observers over `CustomNetChannel`.

## API CORRECTIONS vs the design (verified against the REAL reference assemblies + decomp)

1. **`CharAbilities.SvOnAbilityTriggered(CommandId)` DOES NOT EXIST.** The real public `CharAbilities`
   surface is `OnTick(float,Command,bool)`, `SetCastAbility(CastFlags)`, `ResetCastAbility(CastFlags)`,
   `RpcAbilityReady(int)`, `RpcCastResult(bool)`, `IsCasting()`, `GetModifiedDamage(...)`, etc. — there is
   no `SvOnAbilityTriggered`. **Replaced** the hook with the PROVEN per-ability `Ability.SetState(AbilityStates)`
   postfix (the exact hook the old working mod used), gated to `((NetworkBehaviour)entity).isServer` so it
   only runs on the dedicated host. Slot 0..3 is resolved as the ability's index in `CharAbilities.abilities`.
2. **`AbilityStates` is `{Ready=0, Aiming=1, Casting=2, Active=3, Cooldown=4, Disabled=5}`** (byte enum,
   `Il2CppBAPBAP.Entities`). Cast-start = old∈{Ready,Aiming} → new∈{Casting,Active}.
3. **`StatusEffectManager` is in `Il2CppBAPBAP.Local`**, not `.Entities`. `StatusEffectInfo` / `StatusEffectSO`
   / `Ability` / `AbilityStates` / `CastFlags` / `CharFootsteps` are in `Il2CppBAPBAP.Entities`. `CommandId` /
   `Command` are in `Il2CppBAPBAP.Local`.
4. **`StatusEffectInfo` ctor is `(StatusEffectSO, float duration, float strength)`**; managed
   `StatusEffectInfo[]` implicitly marshals to the Il2Cpp array param of `ApplyHit`.
5. **`CharHurtbox.ApplyHit` is the 13-arg form** `(int dmg, StatusEffectInfo[], int ownerPlayerId,
   GameObject src, bool, bool, bool, bool, bool, Vector3 dir, bool, bool, Collider)` (proven).
6. **`CharAnimator` exposes `animator` (Animator) + `customAnimator` (bool)** and ALSO an
   `animatorOverrideController` field. The task suggested keeping the base controller and overriding only
   individual clips via `AnimatorOverrideController` (citing "research r08"). **The proven graft code does
   NOT do that** — it swaps the whole `CharAnimator.animator` to Medusa's own Animator (which carries the
   bundle's `Medusa` controller) and sets `customAnimator=true`. Since the priority is to reuse the
   known-working code and there is no `r08` in the research set, this build follows the PROVEN whole-animator
   approach plus the layer-count guards for robustness. (The `animatorOverrideController`-clip-swap path
   remains available for a future iteration if state-hash drift is observed.)
7. **Mirror RPC interop is exactly as the design predicted** (verified): `RegisterRpc(Il2CppSystem.Type,
   string, RemoteCallDelegate)`, `RemoteCallDelegate` implicit operator from
   `Action<NetworkBehaviour,NetworkReader,NetworkConnectionToClient>`, `remoteCallDelegates :
   Dictionary<ushort,Invoker>`, `GetFunctionMethodName(ushort,out string)`, `SendRPCInternal(string,int,
   NetworkWriter,int,bool)`, `NetworkWriterPooled : NetworkWriter`, `NetworkServer.Spawn(GameObject,
   NetworkConnection=null)`. `EntityManager : NetworkBehaviour` confirmed.
8. **`PlayerPreMatch.CmdTrySelectCharacter` takes `(PlayerManager, int)`** and `PreMatchManager.TrySelectCharacter`
   takes `(PlayerManager, int)`; the simplest verified autoselect is `PlayerDebug.SwitchCharacter(int,int=-1)`,
   which is what we use.

## STUBBED / DEFERRED (clearly flagged in code)

- **`CustomAbilityEngine.EnableNetworkPrefabSpawn = false`** (M3b). The `NetworkServer.Spawn` of an EXISTING
  `NetworkPrefabLibrary` hitbox/projectile prefab is scaffolded (`TrySpawnNetworkedPrefab`) but disabled by
  default, because configuring each prefab's `HitboxBase` `[SyncVar]` fields (ownerPlayerId/teamId/damage)
  needs per-prefab verification before it can ship enabled. The shipped, ENABLED path
  (`CharHurtbox.ApplyHit` + status) already produces an all-players-see-it networked gameplay result, so
  this is an additive cosmetic/extra layer, not a gap in "abilities everyone sees."
- **`CustomVfxPresenter`** logs the per-cast VFX cue and is the data hook for instantiating Medusa-specific
  bundle VFX on render-capable clients (M3b TODO marked in code). The cue itself replicates to all observers
  over the real ClientRpc today.

## NOT done here (by scope)

- No deploy and no live 2-client test (orchestrator owns server+client deploy + the live test).
- Old `bapcustomchars-mod` not modified; only mined for proven accessors.



---

# M3b / M3c Build Report — visible, all-players-see-it spawning attacks

Date: 2026-06-12
Builder: impl_visible_attacks (orchestrated session)

## Result: BUILDS TO 0 ERRORS / 0 WARNINGS

```
dotnet build NetworkedCustomChar.csproj -c Release  ->  0 Warnung(en)  0 Fehler
```

## Artifact (new DLL)

| Field | Value |
|---|---|
| Path | `C:\Users\Administrator\Downloads\BAPBAPModdingAPI\netcustomchar-mod\bin\Release\NetworkedCustomChar.dll` |
| SHA256 | `49B0FB5560CA3FC5F1F0328D6843086D57A55C23850439E61B3A8E0F447CA966` |
| Bytes | `49152` |
| TargetFramework / Platform | `net6.0` / `x86` |
| MelonInfo | `NetworkedCustomChar 0.1.0 bapcustom` |

(Previous M2/M3 DLL was `C7E4D6E5…391D7`, 43520 bytes.)

## What changed

Only `CustomAbilityEngine.cs` was extended (plus two `using`s for
`Il2CppBAPBAP.Network` / `Il2CppBAPBAP.Pooling`). M1/M2/M3 logic, the
`CharHurtbox.ApplyHit` funnel, `BuildStatusEffects`, the targeting cone, and the
`CustomNetChannel` cue are all preserved.

## M3b — PRIORITY, IMPLEMENTED + ENABLED (`EnableNetworkPrefabSpawn = true`)

On a charId-15 server cast (`FireServer`, gated `((NetworkBehaviour)caster).isServer`,
headless-safe), the engine now spawns a REAL, already-registered, already-replicated
networked hitbox/projectile prefab pulled from
`GameNetworkManager.Instance.networkPrefabLibrary` and configures it exactly like the
engine's own `AB_SpawnHitbox_Base.DoUse`, then `NetworkServer.Spawn`s it. The game's
server-only `OnTrigger*` → `CharHurtbox.ApplyHit` → `OnNetSerialize` pipeline does the
damage + poison/petrify replication, so every peer sees the projectile/AoE and its effect.

### Prefab discovery + per-slot choice (logged)

`EnsurePrefabCatalog()` runs lazily on the first server cast (once
`networkPrefabLibrary` is populated). It enumerates BOTH
`NetworkPrefabLibrary.InstantiatedPrefabs[]` and `PooledPrefabs[].prefab`, and for every
prefab whose root carries a `HitboxBase` it LOGs the name and whether it also carries a
`ProjectileMove`:

```
[M3] [M3b] hitbox prefab: '<name>' projectile=<true|false>.
[M3] [M3b] prefab catalog built=<bool>: scanned=N withHitbox=N projectiles=N aoes=N
           slot0='<name>'(proj=..) slot1..3='<name>'(proj=..).
```

Selection (data-driven, not hard-coded — the live names are whatever the running build
registers, hence the logging):

- **slot 0 (LMB)** → first **projectile-type** hitbox (root has `ProjectileMove`); falls
  back to an AoE prefab if none.
- **slots 1, 2, 3** → first **AoE/ground** hitbox (`HitboxBase`, no `ProjectileMove`);
  falls back to the projectile prefab if no AoE exists.

Per-slot prefab NAMES are therefore emitted at runtime by the log lines above (the
dedicated/headless server's `networkPrefabLibrary` is the source of truth); they are not
fixed strings in the mod.

### Exact HitboxBase / ProjectileMove members used (verified vs decompiled GEHEIMBUILD)

On the spawned `HitboxBase`:
- `NetworkownerPlayerId` (SyncVar setter, dirty bit 1) ← `caster.ownerPlayerId`
- `NetworkteamId` (SyncVar setter, dirty bit 2) ← `caster.entityTeamId`
- `otherChar` (`GameObject`) ← `caster.gameObject`
- `damage` (`int`) ← slot map `{0:120, 1:85, 2:70, 3:160}`
- `directional` (`bool`) ← true for the projectile slot
- `doTtl` (`bool`) = true, `ttl` (`float`) = 3.0 (projectile) / 2.5 (AoE)
- `destroyOnCharHit` / `destroyOnStaticCollision` (`bool`) ← true for projectile
- `statusEffects` (`List<StatusEffectInfo>` getter) — cleared then `.Add()`ed from
  `BuildStatusEffects(slot)` (poison slots 0/1/2, petrify slot 3), so the engine's
  `ApplyHit` applies + replicates them via the `CharStatusEffects` serialized list.

On `ProjectileMove` (if present):
- `speed` (field, read) / `Networkspeed` (SyncVar setter, dirty bit 1) = existing speed
  or 18.0 if 0
- `ttl` (field) = same TTL as the hitbox

Spawn call: `NetworkServer.Spawn(GameObject, NetworkConnection)` — the verified 2-arg
overload (dump.cs confirms overloads `(GO,GO)`, `(GO,NetworkConnection)`,
`(GO,uint,NetworkConnection)`; there is **no** single-arg `Spawn(GameObject)`).

### Double-damage model chosen

**The spawned hitbox is the SOLE damage source; the `ApplyServerHit` cone is a FALLBACK
only when no prefab resolves for that slot.** In `FireServer`:

```
spawnedHitbox = TrySpawnNetworkedPrefab(...)   // true iff a real hitbox was spawned
if (!spawnedHitbox)                            // only then run the authoritative cone
    foreach target: ApplyServerHit(...)
```

So exactly one damage path runs per cast → no double damage. When a prefab is available,
the real networked hitbox's own server-side `OnTrigger*`/`CharHurtbox.ApplyHit` does the
damage (and is what every client sees); the legacy cone is preserved purely as a safety
net for environments where the library has no usable hitbox prefab.

### Owner connection

Spawned with **no owner connection** (`NetworkServer.Spawn(obj, null)`), matching the
engine's own ability-hitbox spawns (`AB_SpawnHitbox_Base.DoUse` calls
`NetworkServer.Spawn(gameObject)` with no owner). This keeps the hitbox fully
server-authoritative (server-only trigger detection drives damage; transform stays
server-owned) and avoids handing NetworkTransform authority to a client. The task's
"ownerConn from connectionToClient" option was evaluated; null (no owner) was chosen for
proven parity with the real engine.

## M3c — BEST-EFFORT, STUBBED (`EnableMedusaBundleHitboxes = false`)

Authentic Medusa bundle poison hitboxes
(`Hitbox_MedusaPoisonProjectile` / `Hitbox_MedusaPoisonPuddle` / `Hitbox_MedusaWallPoison`)
are NOT registered as networked prefabs in this build. The full plan is documented in
`TryRegisterMedusaBundleHitboxes` (clone a shipped networked hitbox root for the real
`NetworkIdentity` + `HitboxBase`, graft the bundle hitbox visual subtree as a
NetworkIdentity-less child, assign a stable per-hitbox assetId, register identically
server+client, then point the slot catalog at the clones — the same proven pattern M1
uses for the char).

**Status: stubbed. Why:** guaranteeing a 0-error M3b build takes priority, and the
clone-base-root + bundle-graft + per-hitbox-assetId registration is a multi-step
networked-asset flow that needs its own live 2-client verification (component-layout
parity, assetId non-collision, pooled-despawn behaviour) and must not risk the shipped
M3b path. It is left behind the clearly-marked `EnableMedusaBundleHitboxes` flag and a
compiling no-op so the flag can be flipped later without reintroducing build breakage.

## Honesty / caveats

- Compiles to 0 errors; **not validated live** (needs the modded DLL on the dedicated
  server + 2 clients — the orchestrator owns that test).
- The chosen per-slot prefab names depend on what the running build's
  `networkPrefabLibrary` contains; they are logged at runtime rather than hard-coded.
- If `networkPrefabLibrary` exposes no `HitboxBase`-bearing prefab at cast time, the
  catalog stays empty and the engine cleanly falls back to the proven `ApplyServerHit`
  cone (still all-players-see-it via HP/status replication), so abilities never silently
  no-op.
- NOT deployed.



---

# M3c Build Report — AUTHENTIC Medusa poison attacks (networked, all-players-see-it)

Date: 2026-06-12
Builder: impl_m3c (orchestrated session)

## Result: BUILDS TO 0 ERRORS / 0 WARNINGS

```
dotnet build NetworkedCustomChar.csproj -c Release  ->  0 Warnung(en)  0 Fehler
```

## Artifact (new DLL)

| Field | Value |
|---|---|
| Path | `C:\Users\Administrator\Downloads\BAPBAPModdingAPI\netcustomchar-mod\bin\Release\NetworkedCustomChar.dll` |
| SHA256 | `17A624F77833590BEAB52912AC7F2D068CA2BE2C33EE8F505A3DB6B71FA5D5EB` |
| Bytes | `57856` |
| TargetFramework / Platform | `net6.0` / `x86` |
| MelonInfo | `NetworkedCustomChar 0.1.0 bapcustom` |

(Previous M3b DLL was `49B0FB5560CA3FC5F1F0328D6843086D57A55C23850439E61B3A8E0F447CA966`, 49152 bytes.)

## What changed (files)

- `CustomAbilityEngine.cs` — `EnableMedusaBundleHitboxes` flipped to `true`; the M3c stub replaced with a
  full build+register implementation (`EnsureMedusaHitboxesRegistered`, `ScanMedusaBaseProtos`,
  `BuildMedusaNetworkedHitbox`, `GraftMedusaPoisonVisual`, `NeutralizeGraftedSubtree`,
  `SanitizeAndAssignAssetId`, `RegisterNetworkedPrefab`, `ResolveFreeAssetId`/`AssetIdInUse`/`TrySet`);
  `TrySpawnNetworkedPrefab` now prefers the per-slot authentic Medusa clone and cleanly falls back to the
  M3b shipped prefab when a slot's clone is absent.
- `MedusaVisualGraft.cs` — added `LoadBundleGameObject(string)` (reuses the proven `EnsureBundle` +
  `TryLoadAssetTyped` name/path/scan accessors) to pull authored poison subtrees from the same bundle.
- `CustomCharMod.cs` — `EnsureRegistered` now calls `CustomAbilityEngine.EnsureMedusaHitboxesRegistered(gnm)`
  on BOTH peers (server reaches it via `GNM.Awake`/`OnStartServer`, client via `OnStartClient`), so the
  per-slot assetIds are registered identically on server+client. `EnsureUiRow` themes the charId-15 ability
  HUD with Medusa's green palette (UI-icon note below).

## Approach (reuses the PROVEN M1 clone+register and M2 graft patterns)

For each ability slot a NETWORKED Medusa hitbox prefab is built once and registered identically on both
peers, then pointed at by the spawn catalog:

1. **Clone a shipped networked hitbox chassis** from `networkPrefabLibrary` (scanned via
   `ScanMedusaBaseProtos` over `InstantiatedPrefabs[]` + `PooledPrefabs[].prefab`): the first
   `ProjectileMove`-bearing `HitboxBase` prefab for slot 0, the first non-projectile `HitboxBase` prefab for
   slots 1-3. This keeps the real weaved `NetworkIdentity` + `HitboxBase` (+ `ProjectileMove`) chassis. Our
   own clones (named `Hitbox_Medusa_NetSlot*`) are skipped during the scan.
2. **Graft the authored Medusa poison visual** (`GraftMedusaPoisonVisual`, M2 pattern): disable the donor
   chassis's own `Renderer`s (`enabled=false`, `forceRenderingOff=true`) so we never see the donor char's
   hitbox mesh, then `Instantiate` the bundle's authored poison subtree as a `NetworkIdentity`-less CHILD.
   `NeutralizeGraftedSubtree` strips any stray `NetworkBehaviour`/`NetworkIdentity` (so the chassis Mirror
   layout is unchanged) and disables colliders / inerts rigidbodies (so the visual can never add a stray
   trigger hit). Renderers/particles are left enabled so the poison VFX renders on render-capable peers.
3. **Sanitize + stable assetId** (`SanitizeAndAssignAssetId`, verbatim M1 `ConfigureMirrorIdentity`): reset
   every child `NetworkIdentity` runtime spawn-state (`sceneId`, `_netId_k__BackingField`, `hasSpawned`,
   `_SpawnedFromInstantiate_k__BackingField`, `destroyCalled`, `serverOnly`, conn backing fields,
   `InitializeNetworkBehaviours()`) and set the root `_assetId` to a stable per-slot sentinel.
4. **Register identically server+client** (`RegisterNetworkedPrefab`, M1 `EnsureMirrorRegistration`): append
   to `networkPrefabLibrary.InstantiatedPrefabs` + base `NetworkManager.spawnPrefabs`, and when the peer is
   active call `NetworkClient.RegisterPrefab(clone, assetId)` + `NetworkPrefabPool.ClientCreate`/`ServerCreate`.
5. **Spawn path unchanged from M3b**: `TrySpawnNetworkedPrefab` instantiates the Medusa clone and configures
   the live `HitboxBase` exactly as M3b (`NetworkownerPlayerId`/`NetworkteamId`/`otherChar`/`damage`/
   friendly-fire flags/`directional`/`doTtl`/`ttl`/`destroyOn*` + `statusEffects` list +
   `ProjectileMove.Networkspeed`), then `NetworkServer.Spawn(obj, null)`. The game's server-only
   `OnTrigger*` → `CharHurtbox.ApplyHit` → `OnNetSerialize` pipeline does the damage + poison/petrify
   replication, so every peer sees the Medusa-skinned hitbox AND its effect.

**Headless-safe:** `GraftMedusaPoisonVisual` runs only when `MedusaVisualGraft.CanSpawnClientFx()` is true.
A dedicated `-batchmode -nographics` host therefore registers the BARE networked chassis (no bundle
instantiate, renders nothing); render-capable peers register chassis+grafted-visual. Because the graft adds
NO `NetworkBehaviour`/`NetworkIdentity`, the chassis Mirror component layout — and thus the Mirror
spawn-payload layout — is identical on both peers with the same assetId, preserving replication parity (the
exact M2 invariant). When a server spawns the hitbox, each peer instantiates its own registered template.

## Per-slot result

| Slot | Input | Base chassis cloned | Medusa visual grafted | Damage/status (kept from M3b) | assetId |
|---|---|---|---|---|---|
| 0 (LMB) | projectile | first `ProjectileMove`+`HitboxBase` prefab in library (fallback: AoE) | `Hitbox_MedusaPoisonProjectile` (fallback `VFX_Medusa_Poison_Trail`) | 120 dmg + poison 3s; `directional`, `ttl=3`, destroy on hit | `0xB0B0F010` |
| 1 (Q/RMB) | AoE | first non-projectile `HitboxBase` prefab (fallback: projectile) | `Hitbox_MedusaPoisonPuddle` (fallback `VFX_Medusa_Poison_Puddle`) | 85 dmg + poison 4s; `ttl=2.5` | `0xB0B0F011` |
| 2 (Space) | AoE | first non-projectile `HitboxBase` prefab | `Hitbox_MedusaWallPoison` (fallback `VFX_Medusa_Poison_Wall`) | 70 dmg + poison 3s; `ttl=2.5` | `0xB0B0F012` |
| 3 (E/ult) | AoE | first non-projectile `HitboxBase` prefab | `Hitbox_MedusaWallBoxDpsPoison` (fallback `VFX_Medusa_Poison_Wall`) | 160 dmg + petrify 2.5s; `ttl=2.5` | `0xB0B0F013` |

The donor chassis NAMES are whatever the running build's `networkPrefabLibrary` exposes (logged at runtime,
not hard-coded). Per-slot Medusa visual names verified against the proven old mod
(`CustomCharFramework.cs` `AbilityHitboxes` + `MedusaMod.cs` `NativeVfxNames`).

### Runtime fallback to M3b (honest)

Each slot is independent. If `ScanMedusaBaseProtos` finds no suitable donor chassis yet, that slot is
retried on the next GNM hook. If a slot's clone build/registration throws, the slot is marked done and the
spawn path uses the **proven M3b shipped prefab** for it (logged `[M3c] slot N ... FALLING BACK to M3b`).
If the bundle has no authored poison visual for a slot, the clone is still built+registered (base renderers
disabled) and used — it will look like a plain/empty hitbox rather than the donor char's mesh, logged. The
build never breaks and abilities never no-op.

## API verification (against the REAL reference assemblies + decompiled GEHEIMBUILD)

- `HitboxBase`: `NetworkownerPlayerId`, `NetworkteamId`, `otherChar`, `damage`, `directional`, `doTtl`,
  `ttl`, `destroyOnCharHit`, `destroyOnStaticCollision`, `onlyHitAllies`, `allowHitToTeam`,
  `allowHitToOwnerPlayer`, `statusEffects` — all confirmed at
  `reverse-engineering\decompiled\...\Entities\HitboxBase.cs` (already used by M3b).
- `ProjectileMove`: `speed`, `ttl`, `Networkspeed` — confirmed at `...\Entities\ProjectileMove.cs`.
- `NetworkIdentity` sanitize members + `_assetId` + `InitializeNetworkBehaviours()` — reused verbatim from
  the proven M1 `ConfigureMirrorIdentity`.
- `NetworkPrefabLibrary.InstantiatedPrefabs`/`PooledPrefabs`, `NetworkPrefabPool.Config{prefab,
  initialSizeServer,initialSizeClient,resizeStrategy}` / `ResizeStrategy.Increment` /
  `ClientCreate`/`ServerCreate` / `poolLookup`, `NetworkClient.RegisterPrefab(GameObject,uint)` /
  `prefabs` / `active`, `NetworkServer.active`, `NetworkManager.spawnPrefabs`, `gnm.Cast<NetworkManager>()` —
  reused verbatim from the proven M1 registration (`InjectIntoPrefabLibrary` / `EnsureMirrorRegistration`).
- Bundle access (`Il2CppAssetBundleManager.LoadFromFile` → `Il2CppAssetBundle.LoadAsset(name, Il2CppType)`,
  `GetAllAssetNames`) — reused from the proven M2 `MedusaVisualGraft`.
- `UICharactersConfiguration.CharacterConfiguration.AbilityData` is a STRUCT with fields `icon` (Sprite),
  `titleKey`, `shortDescriptionKey`, `descriptionKey` (dump.cs TypeDefIndex 4419). `abilityIconColor`/
  `abilityBGColor`/`titleTextColor` are `Color` fields on `CharacterConfiguration` — set for the green theme.

## UI ability-icon status: SKIPPED (sprite swap) + DONE (palette theme) — documented

Authentic distinct per-ability Medusa ICON SPRITES do **not** exist to swap in:
- The proven old mod itself copied the base char's ability icon (`MedusaMod.MakeAbility`: `val.icon =
  src.icon`) — it never had distinct Medusa ability icons either.
- Medusa portrait/card imagery in the old mod comes from **external PNG files** next to the bundle
  (`medusa-portrait.png`, …) loaded via `ImageConversion.LoadImage` + `Sprite.Create`, NOT from bundle
  `Sprite` assets — that needs an `UnityEngine.ImageConversionModule` reference + deployed PNGs and yields a
  single portrait, not four ability icons.

So the icon-sprite swap was judged not straightforward and was skipped. What WAS done (low-risk, asset-free):
the charId-15 row's `abilityIconColor`/`abilityBGColor`/`titleTextColor` are set to Medusa's green palette,
so the ability HUD reads as Medusa's while retaining the base ability icon shapes. Flagged in code.

## Honesty / caveats

- Compiles to **0 errors / 0 warnings**; **not validated live** (needs the modded DLL on the dedicated
  server + 2 clients — the orchestrator owns that test). NOT deployed.
- Replication parity rests on the M2 invariant (graft adds no `NetworkBehaviour`/`NetworkIdentity`, so the
  chassis Mirror layout + assetId are peer-identical). This is the same invariant M1/M2 already ship; M3c's
  live 2-client check should confirm the Medusa hitbox spawns + replicates + damages without assetId
  collision or pooled-despawn issues, identical to the M1 char acceptance.
- Headless particles: the grafted poison `ParticleSystem`s are only instantiated on render-capable peers
  (graft gated by `CanSpawnClientFx()`); the `-nographics` host never instantiates them.
- assetIds `0xB0B0F010..0xB0B0F013` are collision-checked (`ResolveFreeAssetId`) and bump on conflict; given
  the same build on every peer the resolved ids are identical (same assumption M1 makes for the char id).
