# R14 — Community Modding Patterns for BAPBAP

**Scope:** How existing community mods hook BAPBAP (Unity 2022.3.38f1, IL2CPP, Mirror) via
MelonLoader/Harmony, whether/how they register new Il2Cpp types (`ClassInjector`), and any prior
work on characters, abilities, and networked prefabs. Everything below is sourced from real code in
`C:\Users\Administrator\Downloads\neueBapbap\BAPBAPMOD` and
`C:\Users\Administrator\Downloads\neueBapbap\ConfigurateModBYMojo`, cited as `file:line`.

> **Headline conclusion for the synthesis stage:** *No community mod injects a custom
> `NetworkBehaviour`/`MonoBehaviour` into the networked object graph.* Every mod that needs networked
> effects **reuses the game's own server-authoritative entry points** (`PlayerDebug.Cmd*`,
> `GameMode.SpawnEntity`, `NetworkServer.Spawn`). `ClassInjector` is used only for **local, non-networked
> helper components** (a marker and a UI/editor manager). This is the single most important pattern: the
> proven path to "networked custom characters" is **drive the existing Mirror `[Command]` flow
> (`PlayerDebug.SwitchCharacter` / `CmdSwitchCharacter`) and the existing `NetworkServer.Spawn` path**, not
> to graft a client-side clone. The previously failed clone approach failed for exactly the reason these
> mods document and guard against: `Instantiate()` without `NetworkServer.Spawn` produces a **local-only**
> object — invisible to peers, no netId, no synced animation/state (the "frozen poses / despawn / only LMB
> works locally" symptoms).

---

## 1. Toolchain, bootstrap, and project shape

### 1.1 Loader + interop stack
All community mods are **MelonLoader** mods using **Il2CppInterop** + **Harmony 2.x**, targeting
**`net6.0`**. The standard reference set (from `BAPBAPArenaRandomChars.csproj:17-75`):

- `MelonLoader.dll`, `Il2CppInterop.Runtime.dll`, `Il2CppInterop.Common.dll`, `0Harmony.dll`
  (from `Lib\MelonLoader\`)
- Game/Unity Il2Cpp assemblies (from `Lib\Il2CppAssemblies\`): `Assembly-CSharp.dll`,
  `Il2Cppmscorlib.dll`, `Il2CppSystem(.Core).dll`, `UnityEngine.CoreModule.dll`,
  `UnityEngine.UIModule.dll`, **`Il2CppMirror.dll`** (Mirror networking interop)
- Project flags: `<LangVersion>latest`, `<AllowUnsafeBlocks>true`, `<Nullable>enable`,
  `<PlatformTarget>x64`.

`Lib\Il2CppAssemblies\` (directory listing) shows the full networking surface available to mods:
`Il2CppMirror.dll`, `Il2CppMirror.Components.dll`, `Il2CppMirror.Transports.dll`,
`Il2CppTelepathy.dll`, `Il2Cppkcp2k.dll`, `Il2CppFizzySteamworks.dll`, `Il2CppSimpleWebTransport.dll`,
`Il2Cppcom.rlabrecque.steamworks.net.dll`. So Mirror types (`NetworkServer`, `NetworkIdentity`,
`NetworkBehaviour`, `[Command]`/`[ClientRpc]` generated `UserCode_*` methods) are all reachable.

### 1.2 MelonInfo / MelonGame attributes (two valid game tuples in the wild)
- `ConfigurateMain.cs:9-10`:
  `[assembly: MelonInfo(typeof(Configurate.ConfigurateMain), "Configurate", "1.0.0", "Mojo")]`
  `[assembly: MelonGame("gg.bapbap", "BAPBAP")]`
- `ExampleSpeedMod.cs:5-6` uses the same `MelonGame("gg.bapbap", "BAPBAP")`.
- `AGENTS.md` / `MODDER_GUIDE.md` instead document `[assembly: MelonGame("BAPBAP Studios", "BAPBAP")]`.

MelonLoader matches the developer/game strings against the game's app metadata; both tuples appear, so a
new mod should use the one that actually matches the running build (the `gg.bapbap` form is what Mojo's
working mods ship).

### 1.3 Mod entry-point lifecycle (the canonical skeleton)
`BAPBAPArenaRandomChars\Core\ModMain.cs` is the cleanest template:

```csharp
public sealed class ModMain : MelonMod
{
    private HarmonyLib.Harmony? _harmony;

    public override void OnInitializeMelon()           // load config, create Harmony, apply patches
    {
        RandomCharsConfig.Load();
        _harmony = new HarmonyLib.Harmony("com.bapbap.standalone.arena.randomchars");
        RandomCharPatches.Register(_harmony);          // manual, targeted patching
    }

    public override void OnDeinitializeMelon() => _harmony?.UnpatchSelf();  // clean teardown
    public override void OnUpdate() => RandomCharPatches.Tick();            // per-frame driver
}
```

Other lifecycle hooks used across mods:
- `OnSceneWasLoaded(buildIndex, sceneName)` — deferred, scene-gated initialization
  (`BAPBAPMod\Core\BAPBAPMain.cs:64-110`).
- `OnGUI()` — IMGUI debug menus (`BAPBAPMain.cs:331`).
- `OnUpdate()` — hotkeys + per-frame logic (`BAPBAPMain.cs:336`; `ConfigurateMain.cs:24-37` opens UI on F10).

### 1.4 Alternative bootstrap: UnityDoorstop injector
There is a second, non-MelonLoader bootstrap path. `doorstop_config.ini` points Doorstop at
`BAPBAPInjector.dll`, and `BAPBAPInjector\Injector.cs:11-65` spins a background thread that sleeps ~3s,
then retries `BAPBAPMod.Core.ModMain.Initialize()` for up to 30s until Unity/Il2Cpp is alive. This is a
fallback boot mechanism; the mainstream mods all use MelonLoader's `MelonMod` lifecycle instead.

### 1.5 Two registration/patch styles coexist
- **Manual targeted patching (preferred for IL2CPP stability):** `RandomCharPatches.Register` resolves
  methods with `AccessTools.Method(typeof(GameModeArena), "RpcOnRoundEnd")` and calls
  `harmony.Patch(method, postfix: new HarmonyMethod(...))` (`RandomCharPatches.cs:33-58`).
  `MODDER_GUIDE.md` explicitly advises: *"Remove any `[HarmonyPatch]` attributes — use manual patching."*
- **`PatchAll` attribute patching:** Mojo's Configurate uses `harmony.PatchAll()` (`ConfigurateMain.cs:18-21`).
  Works, but the BAPBAPMod guide warns attribute patches can crash on load in IL2CPP if a patch target
  resolves to a property accessor or static-init path (`BAPBAPMain.cs:55-56` comments note removing
  `SpecificSpawnerPatches` because "patching property accessors" crashed the game).

---

## 2. Il2Cpp type registration (`ClassInjector`) — what is and isn't done

`ClassInjector.RegisterTypeInIl2Cpp<T>()` (from `Il2CppInterop.Runtime.Injection`) is used in **exactly two
places**, both for **plain, local, non-networked `MonoBehaviour`s**:

- `BAPBAPMod\Core\BAPBAPMain.cs:32` —
  `ClassInjector.RegisterTypeInIl2Cpp<CustomMapOwnedMarker>();`
  `CustomMapOwnedMarker` is a trivial tag component (`Features\CustomMapOwnedMarker.cs`, 406 bytes) used
  to mark mod-spawned objects so scans can skip them (e.g. `RuntimePrefabLibrary.RegisterPrefabCandidate`
  early-returns if `source.GetComponent<CustomMapOwnedMarker>() != null`, `RuntimePrefabLibrary.cs:188-189`).
- `BAPBAPMain.cs:86` —
  `ClassInjector.RegisterTypeInIl2Cpp<Editor.LevelEditorManager>();` (an in-game editor/UI manager).

**Key facts for the synthesis stage:**
- **No mod registers a `NetworkBehaviour`** (verified by repo-wide grep for `ClassInjector`,
  `RegisterTypeInIl2Cpp`, `RegisterTypeInIl2CppWithInterfaces`, `Il2CppType.Of` — only the two hits above).
- The community has **not** demonstrated injecting a custom Mirror `NetworkBehaviour` with working
  `[SyncVar]`/`[Command]`/`[ClientRpc]` codegen. Mirror's weaver runs at compile time on the game's own
  assembly; an injected runtime type has **no weaver-generated serialization**, so a hand-rolled
  `NetworkBehaviour` will not sync without manually wiring `NetworkServer`/serialization. This is a known
  hard edge and explains why every mod avoids it.
- Practical implication: **prefer composing behavior onto existing game `NetworkBehaviour`s** (PlayerManager,
  CharController, GameMode, entities) and driving them through their existing networked methods, rather than
  injecting new networked types. Injected `MonoBehaviour`s are fine **only for local/visual/UI helpers**.

Registration requirements observed: registration happens once, early, before the type is instantiated
(`OnInitializeMelon` for the marker; lazily on first scene for the editor manager, `BAPBAPMain.cs:78-90`,
guarded by an `_isInitialized` flag and wrapped in try/catch).

---

## 3. Networked spawning — the proven prior art (most relevant to custom characters)

`BAPBAPDebugAdmin\Features\DevToolsBridge.cs` is the richest reference for getting objects to exist **for all
players**. It establishes a clear hierarchy of techniques and, crucially, **distinguishes networked vs
local-only** spawns and records which happened.

### 3.1 Preferred: call the game's own server-authoritative spawn methods
`SpawnEntityForPlayer` (`DevToolsBridge.cs:510-640`) tries, in order:
1. `GameMode.SpawnEntity(prefab, worldPos, Quaternion.identity, Vector3.one)` — **only when
   `isServer`** (`DevToolsBridge.cs:524-548`). Read of authority via
   `TryGetBoolMember(player.playerDebug, "isServer")` (`:519`).
2. `player.playerDebug.DebugSpawnEntity(entityPrefabId, worldPos)` (`:560-585`) — returns the spawned
   GameObject; it goes through the game's networked debug-spawn path.
3. `player.playerDebug.CmdSpawnEntity(entityPrefabId, worldPos)` (`:589-605`) — a Mirror `[Command]`;
   marked `VerificationState.NotVerified` because the result is async/server-side.
4. `DebugGameplayManager.SpawnEntity(entityPrefabId, DebugManager.OperatorLevel.Admin)` (`:609-625`).

The game itself confirms these are the correct primitives: `GameMode.cs` calls `NetworkServer.Spawn(obj)` /
`NetworkServer.Spawn(obj, playerManager.connectionToClient)` in its own spawn routines
(`GEHEIMBUILD\...\BAPBAP\Game\GameMode.cs:822,851,989,1079,1159`).

### 3.2 Fallback: `Instantiate` + reflective `NetworkServer.Spawn` (and the local-only trap)
For arbitrary palette prefabs, `PlaceStaticPalettePrefab` (`DevToolsBridge.cs:705-800`):
1. `UnityEngine.Object.Instantiate(prefab, worldPos, rotation)` (`:726`).
2. Finds a `NetworkIdentity` on the root via `FindNetworkIdentityComponent(root)` (`:754`).
3. **Only if** an identity exists **and** `IsNetworkServerActive()` is true, it reflectively invokes
   `NetworkServer.Spawn(GameObject)` through a cached `MethodInfo`
   (`_networkServerSpawnGameObjectMethod`, `:758-772`) with arg-count-aware dispatch:
   ```csharp
   object?[] args = spawnParams.Length switch { 1 => {root}, 2 => {root, null}, _ => {root} };
   _networkServerSpawnGameObjectMethod.Invoke(null, args);   // => networkSpawned = true; localOnly = false
   ```
4. If identity is missing or server isn't active, it explicitly records `attempted += "local_only"` and
   `localOnly = true` (`:774-792`).

**This is the documented failure mode the previous clone approach hit.** The mod treats "Instantiated but
not `NetworkServer.Spawn`-ed" as a degraded, **local-only** result that peers can't see. A custom character
grafted client-side with `Instantiate` (no `NetworkIdentity` registered as a spawnable prefab, no
server-side `NetworkServer.Spawn`) is invisible to others, has no netId, and won't receive the synced
animation/state RPCs — matching the reported symptoms (not visible to others, frozen poses, despawn).

Companion helpers worth reusing:
- `FindNetworkIdentityComponent(root)` — locates the Mirror identity (`DevToolsBridge.cs:534,569,754`).
- `IsNetworkServerActive()` / `ResolveNetworkInterop()` — reflectively bind to `Mirror.NetworkServer`
  (note: in IL2CPP the type is `Il2CppMirror.NetworkServer`; `RandomCharPatches.IsMirrorServerActive`
  resolves it via `AccessTools.TypeByName("Mirror.NetworkServer") ?? AccessTools.TypeByName("Il2CppMirror.NetworkServer")`
  and reads the static `active` property/field, `RandomCharPatches.cs:601-640`).
- `AssetPaletteEditorService.HasNetworkIdentity(prefab)` flags whether a palette prefab is
  `IsNetworkSpawnable` (`AssetPaletteEditorService.cs:421,666-691`) — i.e. mods pre-classify which prefabs
  can be networked.

### 3.3 Despawn must also go through the network layer
`DespawnNetworkedEntity` (`DevToolsBridge.cs:800+`) resolves the identity root and **blocks despawning
player/bot/character targets** (`IsPlayerLikeTarget`, `:~840`) — a guardrail showing that
character-like networked objects are treated as owned by the server and not freely removable.

---

## 4. Characters — prior art for switching, spawning, and enumerating

### 4.1 The networked character-switch path (the correct, proven mechanism)
Two mods change a player's character and both go through the **same game `NetworkBehaviour` Command on
`PlayerDebug`** (which is a `NetworkBehaviour`, confirmed in
`GameCode\...\BAPBAP\Player\PlayerDebug.cs:16` and `GEHEIMBUILD\...\PlayerDebug.cs:19`):

- `BAPBAPArenaRandomChars` (`RandomCharPatches.TryApplyCharacter`, `RandomCharPatches.cs:530-552`):
  ```csharp
  player.playerDebug.SwitchCharacter(charId, -1);     // primary
  // fallback:
  player.playerDebug.CmdSwitchCharacter(charId, -1);  // Mirror [Command] -> server applies + syncs
  ```
- `BAPBAPDebugAdmin` (`DevToolsBridge.SwitchCharacter`, `DevToolsBridge.cs:1481-1528`): identical pattern —
  `SwitchCharacter` first (marked `Verified`), then `CmdSwitchCharacter` (marked `NotVerified`, since the
  command's effect is server-applied/async). The numeric `skinAssetId` is the second arg
  (`-1` = default skin).

**Takeaway:** characters in BAPBAP are identified by an integer **`charId`** and the supported way to change
the live, networked character is the existing `PlayerDebug.SwitchCharacter(charId, skinId)` /
`CmdSwitchCharacter`. The server runs the real character swap and replicates it. A new-character system
should hook into / mirror this exact flow rather than spawning a separate avatar.

### 4.2 Host/server authority gating
Both mods only act when they hold server authority. `RandomCharPatches.IsLocalHostAuthority`
(`RandomCharPatches.cs:560-600`) checks `playerDebug.isServer`, then `GameManager.isServer`, then
`Mirror NetworkServer.active`. Character assignment is also gated on `GameManager.matchStarted` and
`!matchEnded` (`TryResolveActiveArenaMatch`, `:340-380`). This is essential: character mutations are
server-side; clients must request via Command and let the host apply.

### 4.3 Enumerating the character roster
`CharacterCatalogService.Rebuild` (`CharacterCatalogService.cs:90-150`) and
`RandomCharPatches.ResolveCharacterIds` (`RandomCharPatches.cs:410-470`) both discover characters the same way:
- `UIManager.Instance.characterConfig` — an `Il2CppBAPBAP.UI.UICharactersConfiguration`.
- `Resources.FindObjectsOfTypeAll<UICharactersConfiguration>()` as a fallback scan.
- Read `config.Characters[*].charId` (filtered by `enabledInLobby`) and `config.AvailableCharacterIds`.
- Also harvest live `PlayerManager.charId` values from `GameManager.playersByPlayerId`.

So the canonical character registry lives in **`UICharactersConfiguration`** (`charId`, `enabledInLobby`,
localized name members like `nameLocalized`/`displayName`). A custom-character feature will need to either
extend this config or interoperate with `AvailableCharacterIds` so the lobby/UI accepts the new id.

### 4.4 Reflective char-select path (lower-level, UI-side)
`BAPBAPMod\Features\DevTools.cs:316-330` shows an alternate, non-`PlayerDebug` route:
`ControllerManager -> CharSelect -> SwitchCharacter(id)` invoked reflectively
(`charSelect.GetType().GetMethod("SwitchCharacter")`). This drives the **character-select UI** rather than
the in-match networked swap; useful for lobby/char-select integration but not a substitute for the
server-authoritative `PlayerDebug` command in-match.

### 4.5 Bots / AI-controlled characters
`DebugCommandRouter` exposes `spawn_bot` (`DebugCommandRouter.cs:825`) carrying
`char=<CharId>, count, ai=<EnableAI>, ally=<IsAlly>`, routed into the game's networked spawn path
(§3.1). This is the closest existing prior art to "spawn a fully networked character actor under server
control" — it reuses the game's bot/entity spawning, again never hand-injecting a `NetworkBehaviour`.

---

## 5. Abilities / augments — prior art

There is **no community example of a brand-new networked ability** with new input bindings. What exists:

- **Augment system (passives), client-side framework.** `BAPBAPMod` defines an `ICustomAugment` interface
  (`API/ICustomAugment.cs`; documented in `MODDER_GUIDE.md`) with `OnApply/OnRemove/OnUpdate/OnDamageDealt/
  OnDamageTaken/OnKill`. Custom augments get numeric IDs **≥1000** (native augments 0-299) via
  `CustomAugmentRegistry.Register` (`MODDER_GUIDE.md` "Augment ID Ranges"). The mod injects them into the
  game's augment pool through `GameBridge.InjectAllAugmentsToPool()`, polled on a coroutine
  (`BAPBAPMain.cs:120-160`).
- **Explicitly NOT networked.** `MODDER_GUIDE.md` ("Multiplayer Considerations") states custom augments
  *"only work when all players have the same mods installed and augments are registered with the same IDs"*,
  while *"Native augments (ID 0-299) sync automatically through the game's network code."* A custom-augment
  sync system is listed as a **future/unimplemented feature**. So custom augment logic runs locally per
  client; only native IDs ride the game's replication.
- **Applying native abilities/passives server-side.** `DevToolsBridge.AddPassiveToPlayer` /
  `TryApplySwapPassive(player, passiveId=404)` (`DevToolsBridge.cs:1530-1560`) and
  `TryApplyAbilitySlowFallback` (`:1551-1610`) mutate `charAbilities` (resolved via
  `TryResolveCharAbilities`) and then call refresh methods
  (`OnSilenceLocksChanged/OnDataChanged/RefreshState/RefreshModifiers`) — and they **require host
  authority** (`HasHostAuthority(player.playerDebug)`). Pattern: mutate the existing networked ability
  component on the server, then call its existing "refresh/sync" methods.

**Takeaway for abilities:** the reliable route to networked abilities is to express them in terms the game
already replicates (native augment/passive IDs, existing `CharAbilities`/ability slots), applied on the
server. Purely client-side custom ability logic (the `ICustomAugment` model) does **not** replicate and
produces the desyncs the user observed (only the local input slot reacts; peers see nothing/wrong anims).

---

## 6. Custom-content multiplayer model used by the community

`BAPBAPMod\Features\CustomMapMultiplayer.cs` documents the **only** multiplayer model the community has
working for custom content, and it is deliberately **content-not-networked**:

- Header comment (`CustomMapMultiplayer.cs:7-20`): *"All players must have the same map file locally → Host
  selects map → map ID is synced to all clients → Each client loads the map from their local files →
  Game's existing networking handles position/state sync."*
- `HostSelectMap(mapId)` (`:62-95`) sets the selection and fires `OnMapLoadRequested`; the comment
  (`:84-87`) is explicit that "in a real implementation, this would send the map ID via the game's
  networking system. For now, we just set it locally." I.e. **only a small ID is intended to cross the
  wire; the heavy content is loaded identically on every client from local files.**
- `ValidateMapExists` (`:200-220`) refuses to join if the client lacks the content locally.

**Implication for custom characters:** the realistic networked design is **deterministic, content-by-id**:
ship identical character assets to every client (mod folder / asset bundle), assign a stable `charId`, and
sync only that id through the existing channel (e.g. `PlayerDebug.SwitchCharacter(charId, skinId)` /
`UICharactersConfiguration.AvailableCharacterIds`). Let the game's existing `NetworkBehaviour`s
(`PlayerManager`, `CharController`, `CharHurtbox`, `GameMode`) replicate position/health/animation as they
already do for stock characters. Do **not** try to stream a new prefab over the wire.

---

## 7. Asset acquisition (how mods get prefabs/materials/animators at runtime)

Two complementary techniques, both reusable for staging custom-character assets:

- **Live name-driven prefab cache:** `RuntimePrefabLibrary` (`Features\RuntimePrefabLibrary.cs`) scans the
  active scene (`CaptureScenePrefabs`, `:110-150`) and `Resources.FindObjectsOfTypeAll<GameObject>()`
  (`CaptureResourcePrefabs`, `:152-180`), normalizes names (strips `(Clone)`, collapses identifiers),
  filters out UI/camera/manager/**network**/gamemode objects via an ignore-token set (`:40-95`), and keeps
  only objects with a `Collider`/`Renderer`/`Rigidbody` (`IsGameplayPrefabCandidate`, `:230-290`). It
  explicitly **excludes networked/manager objects** from the cache — reinforcing that this cache is for
  local/visual props, not networked actors.
- **Asset bundles:** `BAPBAPMod\Features\AssetBundleMapLoader.cs` and the `UnityAssetBundleBuilder` Unity
  editor project (per `AGENTS.md`) load externally built bundles — the standard way to bring **new** meshes,
  materials, animator controllers, and prefabs into an IL2CPP game (build in a matching Unity editor, ship
  the bundle, `AssetBundle.LoadFromFile` at runtime). `BAPBAPAssetDumper` (`Dumpers\MeshDumper.cs`,
  `MaterialDumper.cs`, `AnimatorController` handling) is the inverse — extracting the stock character assets
  to use as a baseline/skeleton for new characters.

For custom characters this means: author the character's mesh/animator/prefab against the game's rig in a
matching Unity editor, ship it as an asset bundle present on every client, and attach the game's existing
networked components to it (see §8).

---

## 8. IL2CPP interop rules the community treats as mandatory

From `AGENTS.md` ("Critical Patterns for IL2CPP Interop") and `MODDER_GUIDE.md` ("Best Practices"),
corroborated by the code:

1. **No static initializers that touch game types** — crashes on mod load. Use lazy `??=` init
   (`AGENTS.md` examples; `RuntimePrefabLibrary` uses an `_initialized` flag + `Initialize()`).
2. **Lazy collections** (`private static List<T>? _x; ... _x ??= new()`).
3. **Wrap all interop in try/catch** — pervasive in every file (e.g. `RandomCharPatches`,
   `CharacterCatalogService` swallow reflection errors silently).
4. **Find objects with `FindObjectOfType<T>()` / `Resources.FindObjectsOfTypeAll<T>()`**, not reflection,
   when a typed reference exists (`AGENTS.md`).
5. **Manual Harmony patching** over `[HarmonyPatch]` attributes for stability; never patch property
   accessors (`BAPBAPMain.cs:55-56`).
6. **Mirror type-name duality:** the same type is reachable as `Mirror.X` (managed alias) or
   `Il2CppMirror.X` (IL2CPP) — resolve both (`RandomCharPatches.cs:603-606`).
7. **Hooking Mirror RPCs/Commands:** patch **both** the public stub and the generated `UserCode_*` method.
   `RandomCharPatches.Register` patches `GameModeArena.RpcOnRoundEnd` **and** `UserCode_RpcOnRoundEnd`
   (`RandomCharPatches.cs:33-58`). This is how mods reliably observe networked events regardless of which
   layer fires (the weaver splits `[ClientRpc]`/`[Command]` into a serializer stub + a `UserCode_` body,
   confirmed throughout the decomp, e.g. `GameMode.cs` `[ClientRpc]` blocks at `:956-996`).

---

## 9. A small reusable modder framework exists (Configurate, by Mojo)

`ConfigurateModBYMojo` is a dependency-style framework other mods reference (note
`ExampleSpeedMod.csproj` references `..\Mods\Configurate.dll`). It provides a settings registry + in-game UI
(F10) so feature mods don't each build their own config UI:

- `ConfigurateAPI.RegisterToggle/RegisterSlider/RegisterDropdown(modId, category, key, label, ...)`
  (`ConfigurateAPI.cs:33-120`) build a `ModSettingDefinition` with an `Action<T> OnChanged`.
- `ConfigurateRegistry.Register` stores defs grouped `mod → category → settings`, loads persisted values,
  and fires `OnChanged` (`ConfigurateRegistry.cs:18-60`); `SetValue` persists + re-fires (`:120-135`).
- `ConfigurateMain` opens the UI on F10 (`ConfigurateMain.cs:24-37`).

Relevance: a custom-character/ability framework should expose a similar thin registration API
(`RegisterCharacter(id, assets, abilities…)`) and reuse Configurate for runtime toggles, matching the
ecosystem's conventions and keeping per-device config consistent.

---

## 10. Concrete, reusable techniques (cheat-sheet for the synthesis stage)

| Need | Proven technique (cite) |
|---|---|
| Mod entry/lifecycle | `MelonMod` + `OnInitializeMelon/OnUpdate/OnSceneWasLoaded/OnGUI`; create `new Harmony(id)` and `UnpatchSelf()` on deinit (`ArenaRandomChars\Core\ModMain.cs`) |
| Inject **local** helper component | `ClassInjector.RegisterTypeInIl2Cpp<T>()` once, early (`BAPBAPMain.cs:32,86`) — **MonoBehaviour only**, never relied on for networking |
| Change a player's character (networked) | `player.playerDebug.SwitchCharacter(charId, skinId)` → fallback `CmdSwitchCharacter` (`RandomCharPatches.cs:537,547`; `DevToolsBridge.cs:1493,1511`) |
| Spawn a networked entity | Prefer `GameMode.SpawnEntity(prefab,pos,rot,scale)` (server) / `PlayerDebug.DebugSpawnEntity`/`CmdSpawnEntity` (`DevToolsBridge.cs:535,571,591`) |
| Spawn arbitrary prefab networked | `Instantiate` → require `NetworkIdentity` + `NetworkServer.active` → reflective `NetworkServer.Spawn(go)` (`DevToolsBridge.cs:754-772`) |
| Detect server authority | `playerDebug.isServer` → `GameManager.isServer` → `(Il2Cpp)Mirror.NetworkServer.active` (`RandomCharPatches.cs:560-640`) |
| Observe Mirror RPC/Command | Harmony-patch both `RpcX` and `UserCode_RpcX` (`RandomCharPatches.cs:33-58`) |
| Enumerate characters | `UIManager.Instance.characterConfig` + `Resources.FindObjectsOfTypeAll<UICharactersConfiguration>()`; read `Characters[*].charId`, `AvailableCharacterIds` (`CharacterCatalogService.cs:70-150`) |
| Bring in new art | Asset bundles built in a matching Unity editor (`AssetBundleMapLoader.cs`, `UnityAssetBundleBuilder`); dump baseline rig with `BAPBAPAssetDumper` |
| Multiplayer custom content | Ship identical assets to all clients; sync only a stable **id**; let game replicate state (`CustomMapMultiplayer.cs:7-20`) |
| Resolve live prefabs by name | `RuntimePrefabLibrary.GetPrefab(name)` scene+resources cache (`RuntimePrefabLibrary.cs`) |

---

## 11. Why the previous clone-based approach failed (mapped to community evidence)

- **"Not visible to other players / only local":** the clone was `Instantiate`d client-side without
  `NetworkServer.Spawn` and without a registered spawnable `NetworkIdentity` → the exact `localOnly=true`
  branch the DebugAdmin mod flags as degraded (`DevToolsBridge.cs:774-792`). Peers never receive a spawn
  message.
- **"Despawns":** a non-networked clone isn't tracked by Mirror; the game's match/entity manager
  (which only knows server-spawned, identity-bearing objects) and despawn guards
  (`DespawnNetworkedEntity`/`IsPlayerLikeTarget`) don't manage it, and the game's lifecycle/cleanup removes
  the stray object.
- **"Frozen poses (Standbilder):" / wrong animations:** animation/state on stock characters is driven by
  the game's networked components (`CharController`, `CharHurtbox : NetworkBehaviour`,
  `PlayerDebug : NetworkBehaviour`) via `[SyncVar]`/`[ClientRpc]`. A grafted clone has no netId, so it
  receives none of those updates — it just stands there.
- **"Only LMB works; RMB green dot; Space bugs; E plays base char (Kitsu) anim":** abilities were grafted
  client-side (the non-replicating `ICustomAugment`/local model, §5) while the underlying networked
  `CharAbilities`/animator still belonged to the base `charId`. The community's working path is to either
  switch the real networked `charId` (so the correct ability set + animator are server-applied, §4.1) or
  apply native, already-replicated ability/passive IDs server-side (§5).

**Correct direction (synthesis):** treat a custom character as a **content-by-id** extension of the game's
existing networked character system — register/extend `UICharactersConfiguration` with a new `charId`,
ship the avatar as a client-side asset bundle, attach the game's own networked components, and select it via
the existing `PlayerDebug.SwitchCharacter(charId, skinId)` / Command flow on the server. Express abilities
as server-applied, game-replicated constructs (native augment/passive IDs or the existing `CharAbilities`
slots) rather than client-only logic. Reserve `ClassInjector` for purely local/visual helpers, not for new
`NetworkBehaviour`s.
