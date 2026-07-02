# M1 — Networked Custom-Char Prefab: Composition + Identical Server/Client Registration + Server Spawn

> **Stage M1 of the from-the-ground-up rebuild.** Goal: at load time, on **both** server and client
> (same DLL), build a custom character's networked prefab and register it **identically** so the
> **server spawns it via the native path** and **every client renders it** — with no despawn, no
> frozen pose. This document is the design + a **build-ready C# skeleton for a CLEAN NEW mod**
> (`NetworkedCustomCharMod`), not an extension of the old `MedusaMod.cs`.
>
> Sources: `analysis/NEW-CHAR-SYSTEM-CONCEPT.md`, research `r01,r02,r03,r09,r10,r15,r17`, and the
> decompiled game (full-body tree `…\neueBapbap\GEHEIMBUILD\ExportedProject\Assets\Scripts\Assembly-CSharp\BAPBAP`,
> verified file:line below). The old broken mod is referenced only as a *negative* example.

---

## 0. The contract M1 must satisfy (verified, not inferred)

A character body is an **independent Mirror `NetworkIdentity` entity** the **server** spawns and
replicates by **`assetId`**. For a remote peer to render it, **all** of the following must be true,
**identically on every peer, before the first spawn**:

1. The prefab has **one root `NetworkIdentity`** with a **non-zero, peer-identical `assetId`**, and
   an **identical `NetworkBehaviour` component layout/order** across peers (Mirror serializes the
   spawn/sync payload per-component by index — `r02 §3`, `r15 §4`).
2. The **server** holds the prefab at `characterPrefabsByCharId[charId]` so `GameMode.SpawnPlayerChar`
   can pick it (`GameMode.cs:1064`), and spawns it via `NetworkServer.Spawn(obj, conn)`
   (`GameMode.cs:1079`).
3. **Every client** has the **same `assetId`** registered → prefab, via the game's registration
   loops or an explicit `NetworkClient.RegisterPrefab`.

The crucial registration fact, verified in the full-body source:

```csharp
// GameNetworkManager.cs:244  — CLIENT registration. NOTE: does NOT call base.OnStartClient()
public override void OnStartClient() {
    for (int i = 0; i < networkPrefabLibrary.PooledPrefabs.Length; i++)
        NetworkPrefabPool.ClientCreate(networkPrefabLibrary.PooledPrefabs[i]);     // pooled  -> RegisterPrefab(prefab, SpawnHandler, DespawnHandler)
    for (int j = 0; j < networkPrefabLibrary.InstantiatedPrefabs.Length; j++)
        NetworkClient.RegisterPrefab(networkPrefabLibrary.InstantiatedPrefabs[j]); // 1:1    -> RegisterPrefab(prefab)
}
// GameNetworkManager.cs:335 — SERVER registration
public override void OnStartServer() {
    for (int i = 0; i < networkPrefabLibrary.PooledPrefabs.Length; i++)
        NetworkPrefabPool.ServerCreate(networkPrefabLibrary.PooledPrefabs[i]);
    NetworkServer.RegisterHandler<ClInitMsg>(OnServerClInit);
    systemManager.entityNetworkSystem.OnStartServer();
}
```

> **Correction to a common assumption (incl. r15 §2b):** `OnStartClient` **does not call
> `base.OnStartClient()`**, so Mirror's stock `spawnPrefabs` auto-registration **does not run**.
> Therefore the **only reliable client registration channels are**:
> (a) put our prefab in `networkPrefabLibrary.InstantiatedPrefabs` (→ `NetworkClient.RegisterPrefab`)
> or `PooledPrefabs` (→ `NetworkPrefabPool.ClientCreate`) **before** `OnStartClient` runs, **and/or**
> (b) call `NetworkClient.RegisterPrefab(prefab, assetId)` explicitly before the first `SpawnMessage`.
> We do **both** (library injection is primary; explicit `RegisterPrefab` is belt-and-suspenders).

`NetworkPrefabPool.Create` (verified) keys everything on `NetworkIdentity.assetId` (`uint`) and
throws if the prefab has no `NetworkIdentity`:

```csharp
// NetworkPrefabPool.cs (Create)
if (config.prefab.TryGetComponent<NetworkIdentity>(out var component)) {
    uint assetId = component.assetId;
    if (!poolLookup.TryGetValue(assetId, out var value)) { value = new NetworkPrefabPool(config, assetId, isServer); ... }
    if (!isServer) NetworkClient.RegisterPrefab(config.prefab, value.SpawnHandler, value.DespawnHandler);
    return;
}
throw new Exception("NetworkPrefabPool unable to create prefab pool, missing NetworkIdentity " + config.prefab.name);

// Config shape (verified):
[Serializable] public class Config { public GameObject prefab; public int initialSizeServer = 4; public int initialSizeClient = 2; public ResizeStrategy resizeStrategy; }
public enum ResizeStrategy { Increment = 0, InitialSize = 1, DoubleCount = 2 }
```

`NetworkPrefabLibrary` (verified): `public GameObject[] InstantiatedPrefabs;` +
`public NetworkPrefabPool.Config[] PooledPrefabs;`.

### 0.1 The IL2CPP hard limit (decides the whole composition strategy)

You **cannot** inject new `NetworkBehaviour` types at runtime — Mirror's
`[SyncVar]/[Command]/[ClientRpc]` serialization is weaved at build time on the game assembly
(`CONCEPT §2`, `r15 §3`). Consequences for M1:

- The **networked root must come from a real game character prefab** (it already carries the
  weaved `NetworkIdentity` + full `Char*` `NetworkBehaviour` chain). We **clone** it; we never build
  a `NetworkIdentity` in the bundle.
- The AssetBundle supplies the **visual subtree only** (skinned mesh + rig + Animator + materials),
  **no `NetworkIdentity`, no game `MonoBehaviour`s** (`r15 §3`).

### 0.2 Why M1 chooses charId 15 cloned from a base char

charId is positional and the index into `characterPrefabsByCharId` (`r01 §8`, `r17 §4`). 15 is the
first free slot above the shipped roster 0..14. M1 clones base **charId 0 (Kitsu)** networked root
purely as the "networked chassis" — for M1 the visual/abilities stay Kitsu's; M1's success criterion
is *networked existence* (everyone sees the entity, it walks, it doesn't despawn). Visual swap (M2),
animator override (M2), real abilities (M3+) layer on top of the identical-registration spine proven
here.

---

## 1. M1 build + registration plan (ordered)

| # | Action | Where (real hook) | Peer |
|---|---|---|---|
| 1 | Load the AssetBundle (visual prefab `Custom15_Visual`, no NetworkIdentity) | mod init (`OnInitializeMelon`) | both |
| 2 | Find `GameNetworkManager`, clone `characterPrefabsByCharId[baseCharId]` networked root | Harmony postfix on `GameNetworkManager.Awake` (runs before `OnStartServer`/`OnStartClient`) | both |
| 3 | (M2 preview) Graft visual subtree under root; set `CharAnimator.customAnimator=true`, point `animator` at grafted rig, keep base controller (clips overridden via the `AnimatorOverrideController` the game already creates in `CharAnimator.Awake`) | same build step | both |
| 4 | Assign **stable peer-identical `assetId`** to root `NetworkIdentity._assetId`; sanitize runtime spawn state on **every** child `NetworkIdentity` (there is exactly one on the root for a char body) and `InitializeNetworkBehaviours()` | same build step | both |
| 5 | Install prefab at `characterPrefabsByCharId[15]` (grow array); install bot variant at `charBotPrefabsByCharId[15]` | same build step | both |
| 6 | Add prefab to `networkPrefabLibrary.InstantiatedPrefabs` (so native client/server loops register it) | same build step | both |
| 7 | If client/server already active: explicit `NetworkClient.RegisterPrefab(prefab, assetId)` (client) / nothing extra (server spawns by identity) | `OnStartClient`/`OnStartServer` postfix + `SpawnPlayerChar` prefix | both |
| 8 | Add a `CharacterConfiguration` row (charId 15, `enabledInLobby=true`) to `UICharactersConfiguration._characters` and push into `AvailableCharacterIds` | Harmony on `UICharactersConfiguration.OnEnable` + lobby page hooks | both (client UI; harmless on server) |
| 9 | Let the **native** `GameMode.SpawnPlayerChar` resolve `charId 15 → our prefab` and set the SyncVars (`charId`,`isPrimary`,`playerObj`,`charInstanceId`,`entityTeamId`) — we add nothing; we only guarantee the prefab is registered before it runs | `SpawnPlayerChar` prefix = idempotent "ensure registered" guard | server |

**assetId strategy.** Because the **same DLL** runs on every peer and each peer clones from its own
identical game build + identical bundle + identical code, a **fixed constant `assetId` baked in the
DLL** is automatically peer-identical. We must only ensure it does **not collide** with a shipped
prefab's `assetId`. Use a high, fixed sentinel and verify non-collision at build time:

```text
CustomChar15.AssetId = 0xB0B0_0F00 + charId   // deterministic, identical on all peers, high range
// verify: assert poolLookup / NetworkClient.prefabs does not already contain it; if it does, bump.
```

This is the single most important fix over the old mod, which set a constant but the **server kept
spawning the base prefab** (it patched `GetCharacterBotPrefab` to rewrite charId 15 → base), so the
custom `assetId` was *never the id the server actually spawned* (`r03 §5.2`, `r09 §5.2`, `r15 §6`).
M1 **must not** rewrite charId on the server — the server spawns charId 15 → our prefab → our assetId.

---

## 2. Hook points (real methods, file:line)

| Hook | Signature (verified) | Purpose in M1 |
|---|---|---|
| `GameNetworkManager.Awake` (postfix) | `GameNetworkManager.cs` (`Instance` set in `PreAwake`) | Build + register prefab once, before start callbacks |
| `GameNetworkManager.OnStartServer` (postfix) | `GameNetworkManager.cs:335` | Ensure registered when server starts |
| `GameNetworkManager.OnStartClient` (postfix) | `GameNetworkManager.cs:244` | Ensure registered (+ explicit `RegisterPrefab`) when client starts |
| `GameNetworkManager.GetCharacterBotPrefab` | `GameNetworkManager.cs:234` → `charBotPrefabsByCharId[charId].GetBotPrefab(diff)` | Ensure `charBotPrefabsByCharId[15]` exists so bots don't NRE; **do NOT** rewrite charId |
| `GameMode.SpawnPlayerChar` (prefix) | `GameMode.cs:1054` `void SpawnPlayerChar(PlayerManager, Vector3=default)` | Idempotent "ensure registered" guard before native spawn |
| `UICharactersConfiguration.OnEnable` (postfix) | `UICharactersConfiguration.cs:171` | Inject `CharacterConfiguration` row + availability |
| `UILobbyCharacterSelectPage.GetCharacterListingIndexFromCharId` (prefix) | `UILobbyCharacterSelectPage.cs:788` | Return safe index for charId 15 (avoid the known NRE, `r17 §1/§6`) |

Native spawn body we rely on (verified, `GameMode.cs:1054-1079`):

```csharp
public void SpawnPlayerChar(PlayerManager playerManager, Vector3 spawnPos = default) {
    if (playerManager == null || playerManager.charId < 0
        || playerManager.charId >= netManager.characterPrefabsByCharId.Length
        || playerManager.primaryCharManager != null) return;          // :1056
    ...
    GameObject original = netManager.characterPrefabsByCharId[playerManager.charId]; // :1064  <- our prefab @15
    GameObject obj = Object.Instantiate(original, spawnPos, Quaternion.identity);    // :1073
    EntityManager component = obj.GetComponent<EntityManager>();
    component.NetworkisPrimary      = true;                            // SyncVar accessor, EntityManager.cs:310
    component.NetworkplayerObj      = playerManager.gameObject;        // EntityManager.cs:323
    component.NetworkcharInstanceId = component.GetInstanceID();       // EntityManager.cs:349
    component.NetworkcharId         = playerManager.charId;            // EntityManager.cs:336
    NetworkServer.Spawn(obj, playerManager.connectionToClient);       // :1079  REPLICATE
    OnPlayerCharSpawned(component);
}
```

So **M1 sets no SyncVars itself** — the native path sets `charId/isPrimary/playerObj/charInstanceId`
(and `entityTeamId` via team assignment, `NetworkentityTeamId` `EntityManager.cs:362`). Our only job
is guaranteeing `characterPrefabsByCharId[15]` is our correctly-registered prefab before `:1064`.

---

## 3. Animator override — the verified mechanism (M2 preview, wired in M1 build)

`CharAnimator.Awake()` **already** wraps the controller in an `AnimatorOverrideController` and assigns
it back (verified):

```csharp
// CharAnimator.cs (Awake)
if (!customAnimator) animator = GetComponentInChildren<Animator>();
...
if (animator.runtimeAnimatorController != null) {
    animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
    animator.runtimeAnimatorController = animatorOverrideController; // base controller preserved -> state hashes valid
}
...
// clip swap API the game itself uses:
public void SetAnimatorEmoteClip(AnimationClip clip) { animatorOverrideController["EmoteBase"] = clip; }
```

Implication (fixes *Standbilder* without breaking state hashes): keep the **base char's
`RuntimeAnimatorController`** on the grafted rig's `Animator` (so the layers `Fullbody`,
`UpperbodyOverwrite`, `FullbodyOverwrite`, `IdleUpperbodyOverwrite` and the `AnimParams` hashes the
game computes in `CharAnimator.Awake` stay valid), set `CharAnimator.customAnimator = true` and point
`CharAnimator.animator` at the grafted rig's `Animator`, then **override individual clips** through
`animatorOverrideController[originalClip] = customClip`. The networked `EntityNetworkSystem` state
stream then drives the same state machine → the new rig animates on every peer (`r02 §5.1`,
`r09 §5.3`). For M1 we keep Kitsu's controller + clips (no Standbild because it *is* the real rig);
M2 swaps the visual + overrides clips.

---

## 4. Despawn-avoidance checklist (mapped to r09 causes)

| r09 cause | M1 mitigation |
|---|---|
| D1 AOI observer loss | Entity is **server-spawned** via native `NetworkServer.Spawn` → it is in `CustomSpatialHashInterestManagement`. Never client-instantiate a duplicate. |
| D7 unknown-assetId rejection | Same peer-identical `assetId` registered on **all** peers **before** first spawn; server spawns *that* prefab (no charId rewrite). |
| C stale identity state | `SanitizeMirrorIdentities`: zero `sceneId`, `_netId_k__BackingField`, `hasSpawned`, `_SpawnedFromInstantiate_k__BackingField`, `destroyCalled`, `serverOnly`, both connection backing fields, then `InitializeNetworkBehaviours()` (the clone is a *template*, never a live object). |
| D5 secondary reaping (`dieWithPrimary`, `KillPlayerSecondaryCharacters`) | Native path sets `isPrimary=true` on the player body; we must **not** create extra player-owned entities and must leave `dieWithPrimary=false` on the root (inherited from base primary). |
| D3 TTL destroy | Char body has no `CharDestroyTimer.ttl` armed (inherited from base char prefab); we don't add one. |
| D4 death | N/A at spawn. |
| E pool asymmetry | If using `PooledPrefabs`, the same `Config`/`assetId` is present on both peers via the native `ServerCreate`/`ClientCreate` loops. M1 default uses `InstantiatedPrefabs` (1:1 player body) to avoid pool-symmetry edge cases. |

---

## 5. Build-ready C# skeleton (clean new mod)

Target: **MelonLoader + Il2CppInterop + HarmonyLib, net6**, referencing `Il2CppAssembly-CSharp`,
`Il2CppMirror`, `Il2CppInterop.Runtime`. This is a **new** mod (`NetworkedCustomCharMod`), independent
of the old `BAPBAP.ModAPI`/`MedusaMod`. Bodies that are M2+/best-effort are marked `// TODO(Mx)`.
Method names/types reflect the **real verified API**.

```csharp
// File: NetworkedCustomCharMod/CustomCharMod.cs
using System;
using System.Collections.Generic;
using System.IO;
using HarmonyLib;
using MelonLoader;
using UnityEngine;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes.Arrays;

// --- Il2Cpp game/Mirror aliases (verified namespaces) ---
using Mirror = Il2CppMirror;
using NetworkIdentity      = Il2CppMirror.NetworkIdentity;
using NetworkServer        = Il2CppMirror.NetworkServer;
using NetworkClient        = Il2CppMirror.NetworkClient;
using GameNetworkManager   = Il2CppBAPBAP.Network.GameNetworkManager;
using GameMode             = Il2CppBAPBAP.Game.GameMode;
using PlayerManager        = Il2CppBAPBAP.Player.PlayerManager;
using EntityManager        = Il2CppBAPBAP.Entities.EntityManager;
using CharAnimator         = Il2CppBAPBAP.Entities.CharAnimator;
using CharMaterial         = Il2CppBAPBAP.Entities.CharMaterial;
using NetworkPrefabLibrary = Il2CppBAPBAP.Pooling.NetworkPrefabLibrary;
using NetworkPrefabPool    = Il2CppBAPBAP.Pooling.NetworkPrefabPool;
using PoolConfig           = Il2CppBAPBAP.Pooling.NetworkPrefabPool.Config;
using ResizeStrategy       = Il2CppBAPBAP.Pooling.NetworkPrefabPool.ResizeStrategy;
using UICharactersConfiguration = Il2CppBAPBAP.UI.UICharactersConfiguration;
using CharacterConfiguration    = Il2CppBAPBAP.UI.UICharactersConfiguration.CharacterConfiguration;
using AbilityData               = Il2CppBAPBAP.UI.UICharactersConfiguration.CharacterConfiguration.AbilityData;
using Il2CppAssetBundle         = Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray<UnityEngine.Object>; // see note in LoadBundle

[assembly: MelonInfo(typeof(NetworkedCustomCharMod.CustomCharMod), "NetworkedCustomChar", "0.1.0", "bapcustom")]
[assembly: MelonGame(null, null)]

namespace NetworkedCustomCharMod
{
    // ---------------------------------------------------------------------------------------------
    // Data-driven character definition (M5 expands this to JSON; M1 hardcodes one entry).
    // ---------------------------------------------------------------------------------------------
    public sealed class CustomCharDef
    {
        public int    CharId       = 15;            // free slot above shipped 0..14 (r01 §8, r17 §4)
        public int    BaseCharId   = 0;             // Kitsu networked chassis (r10 §2)
        public string Name         = "Custom15";
        public string BundleRel    = "CustomChars/custom15.bundle";   // under UserData\
        public string VisualName   = "Custom15_Visual";               // visual-only prefab in bundle (r15 §3)
        public uint   AssetId      = 0xB0B00F00u + 15u;               // peer-identical, high, collision-checked
        public bool   GraftVisual  = false;          // M1=false (Kitsu chassis); M2=true
    }

    public sealed class CustomCharMod : MelonMod
    {
        internal static CustomCharMod Instance = null!;
        private readonly CustomCharDef _def = new CustomCharDef();

        private Il2CppAssetBundleHandle? _bundle;       // see LoadBundle note
        private GameObject? _visualPrefab;              // bundle visual subtree (no NetworkIdentity)
        private GameObject? _networkedPrefab;           // our composed, registered char body prefab
        private bool _built;
        private bool _libraryInjected;

        public override void OnInitializeMelon()
        {
            Instance = this;
            LoadBundle();                                // step 1
            // Harmony auto-patches the [HarmonyPatch] classes below.
            LoggerInstance.Msg($"[M1] loaded. charId={_def.CharId} baseCharId={_def.BaseCharId} assetId=0x{_def.AssetId:X8}");
        }

        // -----------------------------------------------------------------------------------------
        // STEP 1 — bundle load (Il2CppInterop-safe). Visual subtree only; no NetworkIdentity.
        // Pattern verified against r15 §5 (Il2CppAssetBundleManager.LoadFromFile + typed LoadAsset).
        // -----------------------------------------------------------------------------------------
        private void LoadBundle()
        {
            try
            {
                string path = ResolveBundlePath(_def.BundleRel);
                if (!File.Exists(path)) { LoggerInstance.Warning($"[M1] bundle missing: {path}"); return; }

                // Il2CppAssetBundleManager.LoadFromFile(path) -> Il2CppAssetBundle
                _bundle = Il2CppAssetBundleHandle.LoadFromFile(path);
                var goType = Il2CppType.Of<GameObject>();
                _visualPrefab = _bundle.LoadAsset(_def.VisualName, goType)?.Cast<GameObject>()
                              ?? _bundle.LoadAsset($"Assets/GameObject/{_def.VisualName}.prefab", goType)?.Cast<GameObject>();
                LoggerInstance.Msg($"[M1] visual prefab loaded: {(_visualPrefab != null)}");
            }
            catch (Exception e) { LoggerInstance.Error($"[M1] LoadBundle: {e}"); }
        }

        // -----------------------------------------------------------------------------------------
        // STEP 2-7 — build + register. Idempotent; safe to call from every hook.
        // -----------------------------------------------------------------------------------------
        internal bool EnsureRegistered(string src)
        {
            try
            {
                var gnm = GameNetworkManager.Instance;
                if (gnm == null) return false;

                if (!_built && !BuildNetworkedPrefab(gnm, src)) return false;
                InstallIntoCharIdTables(gnm, src);          // step 5
                InjectIntoPrefabLibrary(gnm, src);          // step 6
                EnsureMirrorClientRegistration(src);        // step 7 (client only, when active)
                return true;
            }
            catch (Exception e) { LoggerInstance.Error($"[M1] EnsureRegistered({src}): {e}"); return false; }
        }

        private bool BuildNetworkedPrefab(GameNetworkManager gnm, string src)
        {
            Il2CppReferenceArray<GameObject> table = gnm.characterPrefabsByCharId;     // GameNetworkManager.cs:129
            if (table == null || _def.BaseCharId < 0 || _def.BaseCharId >= table.Length) return false;
            GameObject baseRoot = table[_def.BaseCharId];
            if (baseRoot == null) return false;

            // Clone the REAL networked root (carries the weaved NetworkIdentity + full Char* chain).
            bool wasActive = baseRoot.activeSelf;
            if (wasActive) baseRoot.SetActive(false);                 // clone inert
            GameObject clone;
            try { clone = UnityEngine.Object.Instantiate(baseRoot); }
            finally { if (wasActive) baseRoot.SetActive(true); }

            clone.name = $"Char_{_def.Name}";
            clone.SetActive(false);
            UnityEngine.Object.DontDestroyOnLoad(clone);

            if (_def.GraftVisual && _visualPrefab != null)            // M2 path
                GraftVisualSubtree(clone, src);

            ConfigureMirrorIdentity(clone, src);                      // step 4: assetId + sanitize
            _networkedPrefab = clone;
            _built = true;
            LoggerInstance.Msg($"[M1] built networked prefab '{clone.name}' via {src}.");
            return true;
        }

        // STEP 3 (M2 preview) — graft bundle visual + animator override; clips swapped, base controller kept.
        private void GraftVisualSubtree(GameObject root, string src)
        {
            // TODO(M2): instantiate _visualPrefab under root, disable base visual, rebind:
            //   var ca = root.GetComponentInChildren<CharAnimator>(true);
            //   ca.customAnimator = true;                          // CharAnimator.cs (verified field)
            //   ca.animator       = graftedRig.GetComponentInChildren<Animator>(true);
            //   // keep base RuntimeAnimatorController on ca.animator so state hashes/layers stay valid;
            //   // CharAnimator.Awake wraps it in AnimatorOverrideController automatically.
            //   // override clips: ca.animatorOverrideController[origClip] = customClip;  (post-Awake)
            //   var cm = root.GetComponentInChildren<CharMaterial>(true);  // rebind charRenderer/extraRenderers
        }

        // STEP 4 — stable assetId + runtime-state sanitize (clone is a TEMPLATE, never a live object).
        private void ConfigureMirrorIdentity(GameObject prefab, string src)
        {
            // exactly one NetworkIdentity on a char-body root; sanitize all just in case.
            Il2CppArrayBase<NetworkIdentity> ids = prefab.GetComponentsInChildren<NetworkIdentity>(true);
            for (int i = 0; i < ids.Length; i++)
            {
                var id = ids[i];
                if (id == null) continue;
                TrySet(() => id.sceneId = 0uL);
                TrySet(() => id._netId_k__BackingField = 0u);
                TrySet(() => id.hasSpawned = false);
                TrySet(() => id._SpawnedFromInstantiate_k__BackingField = false);
                TrySet(() => id.destroyCalled = false);
                TrySet(() => id.serverOnly = false);
                TrySet(() => id._connectionToServer_k__BackingField = null);
                TrySet(() => id._connectionToClient = null);
                TrySet(() => id.InitializeNetworkBehaviours());
            }
            var root = prefab.GetComponent<NetworkIdentity>() ?? prefab.GetComponentInChildren<NetworkIdentity>(true);
            if (root != null)
            {
                AssertAssetIdFree(_def.AssetId, src);          // collision check (§1 assetId strategy)
                root._assetId = _def.AssetId;                  // peer-identical because same DLL on all peers
            }
        }

        // STEP 5 — install at charId index (player + bot tables).
        private void InstallIntoCharIdTables(GameNetworkManager gnm, string src)
        {
            if (_networkedPrefab == null) return;
            // player table
            var table = gnm.characterPrefabsByCharId;
            if (table == null) return;
            if (_def.CharId >= table.Length || table[_def.CharId] == null || table[_def.CharId] != _networkedPrefab)
            {
                int len = Math.Max(table.Length, _def.CharId + 1);
                var grown = new Il2CppReferenceArray<GameObject>(len);
                for (int i = 0; i < table.Length; i++) grown[i] = table[i];
                grown[_def.CharId] = _networkedPrefab;
                gnm.characterPrefabsByCharId = grown;
            }
            // bot table: ensure charBotPrefabsByCharId[15] resolves (GetCharacterBotPrefab, GameNetworkManager.cs:234)
            EnsureBotPrefabEntry(gnm, src);                    // TODO(M6): proper bot prefab; M1 reuses our prefab/base
        }

        // STEP 6 — add to NetworkPrefabLibrary.InstantiatedPrefabs so native loops register it on both peers.
        private void InjectIntoPrefabLibrary(GameNetworkManager gnm, string src)
        {
            if (_networkedPrefab == null || _libraryInjected) return;
            NetworkPrefabLibrary lib = gnm.networkPrefabLibrary;        // GameNetworkManager.cs:126
            if (lib == null) return;

            var arr = lib.InstantiatedPrefabs;                          // NetworkPrefabLibrary (verified)
            for (int i = 0; i < (arr?.Length ?? 0); i++) if (arr[i] == _networkedPrefab) { _libraryInjected = true; return; }
            int len = arr?.Length ?? 0;
            var grown = new Il2CppReferenceArray<GameObject>(len + 1);
            for (int i = 0; i < len; i++) grown[i] = arr[i];
            grown[len] = _networkedPrefab;
            lib.InstantiatedPrefabs = grown;
            _libraryInjected = true;
            LoggerInstance.Msg($"[M1] added to InstantiatedPrefabs via {src} (len {len}->{len + 1}).");
            // Alternative pooled path (if 1:1 ever proves unstable):
            //   var cfg = new PoolConfig { prefab = _networkedPrefab, initialSizeServer = 1, initialSizeClient = 1, resizeStrategy = ResizeStrategy.Increment };
            //   append to lib.PooledPrefabs  -> native ServerCreate/ClientCreate loops handle both sides.
        }

        // STEP 7 — explicit client registration if the client is already connected (race guard).
        private void EnsureMirrorClientRegistration(string src)
        {
            if (_networkedPrefab == null) return;
            try
            {
                if (NetworkClient.active)
                    NetworkClient.RegisterPrefab(_networkedPrefab, _def.AssetId);   // overload (prefab, assetId)
            }
            catch (Exception e) { LoggerInstance.Warning($"[M1] client RegisterPrefab via {src}: {e.Message}"); }
            // Server needs no extra step: NetworkServer.Spawn reads assetId from the identity (GameMode.cs:1079).
        }

        // ---- helpers ----
        private void EnsureBotPrefabEntry(GameNetworkManager gnm, string src) { /* TODO(M6) */ }
        private static void AssertAssetIdFree(uint id, string src) { /* TODO: scan NetworkPrefabPool.poolLookup / NetworkClient.prefabs; bump on collision */ }
        private static void TrySet(Action a) { try { a(); } catch { } }
        private static string ResolveBundlePath(string rel) => Path.Combine(MelonEnvironment.UserDataDirectory, rel);

        // =========================================================================================
        // HARMONY HOOKS
        // =========================================================================================
        [HarmonyPatch(typeof(GameNetworkManager), nameof(GameNetworkManager.Awake))]
        static class P_GNM_Awake { static void Postfix() => Instance?.EnsureRegistered("GNM.Awake"); }

        [HarmonyPatch(typeof(GameNetworkManager), "OnStartServer")]
        static class P_GNM_StartServer { static void Postfix() => Instance?.EnsureRegistered("GNM.OnStartServer"); }

        [HarmonyPatch(typeof(GameNetworkManager), "OnStartClient")]
        static class P_GNM_StartClient { static void Postfix() => Instance?.EnsureRegistered("GNM.OnStartClient"); }

        // Guard: ensure registered before native spawn resolves characterPrefabsByCharId[charId] (GameMode.cs:1064).
        [HarmonyPatch(typeof(GameMode), "SpawnPlayerChar")]
        static class P_GM_SpawnPlayerChar { static void Prefix(PlayerManager playerManager) => Instance?.EnsureRegistered("GM.SpawnPlayerChar"); }

        // Bots: DO NOT rewrite charId (the old mod's fatal mistake). Only ensure the slot exists.
        [HarmonyPatch(typeof(GameNetworkManager), nameof(GameNetworkManager.GetCharacterBotPrefab))]
        static class P_GNM_BotPrefab
        {
            static void Prefix(int charId) { if (charId == Instance?._def.CharId) Instance.EnsureRegistered("GNM.GetCharacterBotPrefab"); }
        }

        // UI row + availability (charId 15). Harmless on headless server.
        [HarmonyPatch(typeof(UICharactersConfiguration), "OnEnable")]
        static class P_UICfg_OnEnable { static void Postfix(UICharactersConfiguration __instance) => Instance?.EnsureUiRow(__instance, "UICfg.OnEnable"); }

        // Avoid the known listing-index NRE for unknown charId (r17 §1/§6).
        [HarmonyPatch(typeof(Il2CppBAPBAP.UI.UILobbyCharacterSelectPage), "GetCharacterListingIndexFromCharId")]
        static class P_LobbyListingIndex
        {
            static bool Prefix(int charId, ref int __result)
            {
                if (charId != Instance?._def.CharId) return true;  // run original
                __result = Instance.ResolveSafeListingIndex(charId);
                return false;
            }
        }

        // =========================================================================================
        // STEP 8 — UI CharacterConfiguration row + AvailableCharacterIds
        // =========================================================================================
        internal void EnsureUiRow(UICharactersConfiguration cfg, string src)
        {
            try
            {
                if (cfg == null) return;
                var chars = cfg._characters;                       // UICharactersConfiguration.cs:130
                if (chars == null) return;

                // already present?
                for (int i = 0; i < chars.Length; i++) if (chars[i] != null && chars[i].charId == _def.CharId) { PushAvailability(cfg); return; }

                // clone presentation from base row, override identity. (UI-only; gameplay is the prefab.)
                CharacterConfiguration baseRow = FindRowByCharId(chars, _def.BaseCharId) ?? chars[0];
                var row = new CharacterConfiguration
                {
                    name = _def.Name,
                    charId = _def.CharId,                          // UICharactersConfiguration.cs:55
                    enabledInLobby = true,                         // :58
                    enabledInDevLobby = true,                      // :61
                    descriptionTranslationKey = baseRow.descriptionTranslationKey,
                    Color = baseRow.Color, UIAccentColor = baseRow.UIAccentColor,
                    LobbyBackground = baseRow.LobbyBackground, FullSprite = baseRow.FullSprite,
                    MediumSprite = baseRow.MediumSprite, StandingSprite = baseRow.StandingSprite,
                    IconSprite = baseRow.IconSprite, smallSprite = baseRow.smallSprite,
                    CircleIcon = baseRow.CircleIcon, SquareIcon = baseRow.SquareIcon, SquareSmallIcon = baseRow.SquareSmallIcon,
                    DefaultSkin = baseRow.DefaultSkin,
                    abilityIconColor = baseRow.abilityIconColor, abilityBGColor = baseRow.abilityBGColor, titleTextColor = baseRow.titleTextColor,
                    ability1 = baseRow.ability1, ability2 = baseRow.ability2, ability3 = baseRow.ability3, ability4 = baseRow.ability4, // M1: clone UI; M3+ override
                };

                var grown = new Il2CppReferenceArray<CharacterConfiguration>(chars.Length + 1);
                for (int i = 0; i < chars.Length; i++) grown[i] = chars[i];
                grown[chars.Length] = row;
                cfg._characters = grown;
                PushAvailability(cfg);
                LoggerInstance.Msg($"[M1] UI row added (charId={_def.CharId}) via {src}; roster {chars.Length}->{grown.Length}.");
            }
            catch (Exception e) { LoggerInstance.Error($"[M1] EnsureUiRow({src}): {e}"); }
        }

        private void PushAvailability(UICharactersConfiguration cfg)
        {
            var chars = cfg._characters;
            var ids = new Il2CppStructArray<int>(chars.Length);
            for (int i = 0; i < chars.Length; i++) ids[i] = chars[i] != null ? chars[i].charId : -1;
            cfg.UpdateAvailableCharacterList(ids);                 // UICharactersConfiguration.cs:162 (rebuilds _lobbyAvailableCharacterIds)
        }

        internal int ResolveSafeListingIndex(int charId)
        {
            // M1: keep it selectable without a server listing entry. M6/server: add to CharListingResponse.
            return 0; // TODO: return real index once availability/listing for 15 is server-driven (r17 §6)
        }

        private static CharacterConfiguration? FindRowByCharId(Il2CppReferenceArray<CharacterConfiguration> rows, int charId)
        {
            for (int i = 0; i < rows.Length; i++) if (rows[i] != null && rows[i].charId == charId) return rows[i];
            return null;
        }
    }
}
```

> **Skeleton notes / honesty about the IL2CPP surface**
> - `Il2CppAssetBundleHandle` is a stand-in for the interop bundle wrapper (`Il2CppAssetBundleManager.LoadFromFile` →
>   `Il2CppAssetBundle.LoadAsset(name, Il2CppType.Of<GameObject>())`, then `.Cast<GameObject>()` — the exact path
>   the old mod proved working, `r15 §5`). Replace with the real `Il2CppInterop`/MelonLoader bundle type at build.
> - SyncVar backing-field names (`_netId_k__BackingField`, `_SpawnedFromInstantiate_k__BackingField`,
>   `_connectionToServer_k__BackingField`, `_connectionToClient`) and `_assetId`, `sceneId`, `hasSpawned`,
>   `destroyCalled`, `serverOnly`, `InitializeNetworkBehaviours()` are the **exact** members the old mod read/wrote
>   on `NetworkIdentity` and are the correct Il2Cpp accessors. Keep the `TrySet` guards (some are version-sensitive).
> - `UICharactersConfiguration._characters`, `.UpdateAvailableCharacterList(int[])`, and the
>   `CharacterConfiguration` field set are verified (`UICharactersConfiguration.cs:55/58/61/130/162`).
> - `NetworkClient.RegisterPrefab(GameObject, uint)` is the explicit-assetId overload (`r15 §3`).

---

## 6. M1 acceptance test (2 clients + dedicated server, same DLL)

1. Server + both clients run `NetworkedCustomCharMod`. Confirm in logs (every peer):
   `built networked prefab 'Char_Custom15'`, `added to InstantiatedPrefabs`, and on clients
   `client RegisterPrefab` for `assetId=0xB0B00F0F`.
2. Both players select charId 15 in lobby (UI row present, no listing-index NRE).
3. Match start → server `GameMode.SpawnPlayerChar` resolves `characterPrefabsByCharId[15]` → our
   prefab → `NetworkServer.Spawn(obj, conn)` (`GameMode.cs:1079`).
4. **Pass criteria:** each client sees **both** charId-15 entities (self + other), the bodies
   **walk/move** (driven by `EntityNetworkSystem`, `r02 §5.1`), and **no despawn** over ≥60s
   (no `Failed to spawn server object` / `No Char Network found for netId` in any client log).
   Visual is Kitsu's chassis (expected for M1); abilities are Kitsu's (expected; replaced in M3+).

If (4) holds, the identical-registration + server-spawn spine is proven and M2 (visual + animator
override) builds directly on `BuildNetworkedPrefab` → `GraftVisualSubtree`.

---

## 7. Brutally honest feasibility notes

- **Server deploy is mandatory** and is the real-world blocker (CONCEPT M0). M1 logic is correct
  regardless, but cannot be validated end-to-end until the modded DLL runs on the AMP/Wine server.
- **assetId collision** is the one silent failure mode left: if `0xB0B00F0F` happens to equal a
  shipped prefab's baked `assetId`, clients resolve the wrong prefab. `AssertAssetIdFree` must be
  implemented (scan `NetworkPrefabPool.poolLookup` keys + `NetworkClient.prefabs`) before M1 ships.
- **Component-layout parity** is guaranteed *only because* every peer clones from its **own**
  identical game build + identical bundle + identical DLL. Any per-peer divergence (different game
  patch, different bundle) breaks per-component SyncVar deserialization → desync/despawn.
- **`GameNetworkManager.Awake` timing**: the build must complete before `OnStartServer`/`OnStartClient`
  iterate the library. `Awake` runs before both (Mirror lifecycle), and the `OnStart*` postfixes +
  `SpawnPlayerChar` prefix are idempotent backstops. If `Instance` (the GNM singleton) isn't ready at
  `Awake` in some load order, the `OnStart*` hooks still register before the first spawn.
- M1 deliberately keeps Kitsu's visual + abilities. This is *not* a regression — it isolates the
  networking spine so M2/M3 don't debug registration and animation simultaneously.
```
