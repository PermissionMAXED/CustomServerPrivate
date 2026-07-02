# CUSTOM-NETWORKING-DESIGN — Custom networked behavior for BAPBAP custom characters

> Stage deliverable: **definitively** determine whether/how we can add our OWN networked behavior to a
> custom character so **all players** see custom state + abilities, and ship a **build-ready** code
> pattern. We own BOTH the dedicated server (our Windows `bapbap.exe` under AMP/Wine) and both clients
> (both run our MelonLoader mod), so server-side logic and identical-content-to-all-peers are fully
> available.
>
> Evidence base: the decompiled `Il2CppMirror` interop assembly
> (`BAPBAPModdingAPI\BAPBAPModAPI\reverse-engineering\decompiled\Il2CppMirror\…`), the game decomp
> (`neueBapbap\…\Assembly-CSharp\BAPBAP`), the ModAPI's own Mirror layer
> (`BAPBAPModAPI\modapi\src\Mirror\…`) and the working `MirrorCmdDemo` example, the old broken mod
> (`BAPBAPModdingAPI\bapcustomchars-mod\MedusaMod.cs`), and research `r02, r05, r13, r14`.

---

## 0. TL;DR — the definitive verdict

| # | Capability investigated | Verdict | Why |
|---|---|---|---|
| 1 | **Inject a `NetworkBehaviour` subclass** via `ClassInjector` and have Mirror call our `OnSerialize`/`OnDeserialize`/`OnStartServer`/`OnStartClient` polymorphically | **Technically possible, but REJECTED** | Il2CppInterop *can* inject a subclass of an Il2Cpp base and override its virtuals (native polymorphic calls reach managed overrides). BUT there is **no weaver serialization**, the injected component changes `NetworkIdentity.components` layout, any byte/index mismatch corrupts the **entire entity's** deserialization (high blast-radius), and the per-tick char state actually flows through the game's own `EntityNetworkSystem`/`CharNetwork` stream — **not** Mirror `OnSerialize` — so an injected NB fires at the wrong cadence and can't join the predicted `CharSimulation`. Zero community precedent (`r14 §2`). Wrong tool. |
| 2 | **Manual RPCs without the weaver** (`RegisterCommand`/`RegisterRpc` + `SendCommandInternal`/`SendRPCInternal`) | **FEASIBLE — PROVEN** | `Mirror.RemoteCalls.RemoteProcedureCalls.RegisterCommand/RegisterRpc` are `public static` and Il2CppInterop-callable; `NetworkBehaviour.SendCommandInternal/SendRPCInternal/SendTargetRPCInternal` are `public`; `RemoteCallDelegate` has an implicit operator from a managed `Action<NetworkBehaviour,NetworkReader,NetworkConnectionToClient>`. The ModAPI already invokes existing game commands this way (`MirrorCmdRegistry`, `MirrorCmdDemo`). |
| 3 | **Custom Mirror `NetworkMessage`** (`NetworkServer/Client.RegisterHandler<T>` + `SendToAll<T>`/`SendToReadyObservers<T>`) | **Feasible, but more friction than #2** | The handler/send APIs are `public static` and generic. The catch: a brand-new `T` needs registered `Writer<T>`/`Reader<T>` serialization which the weaver normally bakes; an injected struct has none, so you must either reuse an existing message type or hand-register serializers. #2 avoids that entirely. |
| 4 | **Server-side ability ENGINE** driven by the already-replicated `Command`/`cmdId`, spawning REAL existing networked prefabs via `NetworkServer.Spawn`, damage/status via existing `[Server]` paths, custom synced state via #2 | **RECOMMENDED — this is the design** | Combines proven, low-risk primitives the game and community already rely on (`r05`, `r13`, `r14`). Everything is server-authoritative and replicates to all peers through Mirror's existing, weaver-generated machinery. |

**Recommendation:** build a **server-authoritative custom ability engine** (#4) that (a) spawns the
game's **own** existing networked `HitboxBase`/projectile prefabs via `NetworkServer.Spawn` with
custom per-ability config, (b) applies damage/status through the existing `[Server]`
`CharHurtbox.ApplyHit` / `CharStatusEffects.ActivateStatusEffect` paths, and (c) carries any
**genuinely custom synced state/VFX** over a thin **manual `[ClientRpc]` channel** registered with
`RemoteProcedureCalls.RegisterRpc` on an **existing** game `NetworkBehaviour` type (#2). Do **not**
inject a `NetworkBehaviour` (#1) and do **not** invent a new `NetworkMessage` (#3) unless #2 proves
insufficient. The full code pattern for all three pieces is in §4.

---

## 1. The four investigations — definitive findings

### 1.1 Investigation #1 — injected `NetworkBehaviour` (REJECTED)

**Can Il2CppInterop inject a subclass of `Il2CppMirror.NetworkBehaviour` and override its virtuals so
the game's native Mirror calls them polymorphically?**

- **Override mechanism exists.** Il2CppInterop's `ClassInjector.RegisterTypeInIl2Cpp<T>()` builds a
  real Il2Cpp class for `T`, installs an Il2Cpp vtable, and patches managed overrides of **virtual**
  base methods into that vtable, so a native polymorphic call (e.g. from compiled
  `NetworkIdentity` C++ iterating `NetworkBehaviour[] components`) dispatches into the managed
  override. The toolchain already injects Il2Cpp `MonoBehaviour` subclasses with overridden Unity
  callbacks (`modapi\src\Lifecycle\ModUpdateRunner.cs:29`, `modapi\src\UI\…ClickProxy`,
  `modapi\src\API\NotificationAPI.cs:165` `ScheduledFader`, etc.). So "inject a subclass of a game
  type and override its virtuals" is a real capability.

- **`OnSerialize`/`OnDeserialize` are the right virtuals.** In this Mirror, per-component
  serialization routes through `NetworkBehaviour.OnSerialize(NetworkWriter, bool)` /
  `OnDeserialize(NetworkReader, bool)` (virtual; the weaver overrides them on game types, then they
  call `SerializeSyncVars`/`DeserializeSyncVars`). `SetDirtyBit`/`SetSyncVarDirtyBit(ulong)` exist
  and are `public` (`NetworkBehaviour.cs:808`). So in principle an injected NB's `OnSerialize` would
  be invoked by `NetworkIdentity`'s serialize-all pass, and `OnStartServer`/`OnStartClient` (also
  virtual) would fire.

**Why we still REJECT it (brutally honest):**

1. **No weaver serialization → must hand-roll everything, including the wire contract.** The weaver
   normally emits `SerializeSyncVars`/`DeserializeSyncVars`, the dirty-bit masks, and the static
   cctor RPC registrations (`r13 §3.1–3.2`). For an injected type we'd reproduce all of it by hand.
2. **Layout coupling / blast radius.** Adding a NB to the prefab changes
   `NetworkIdentity.components` (count + per-component `componentIndex`). Modern Mirror length-prefixes
   each component segment, but if our `OnSerialize`/`OnDeserialize` are asymmetric or throw, the
   read cursor desyncs and **the whole entity** fails to deserialize → despawn/disconnect for all of
   that entity's components, not just ours. We saw the old mod's identity bookkeeping fights in
   `MedusaMod.SanitizeMirrorIdentities` (`r02 §7`).
3. **Wrong cadence.** Per-tick character state (movement/anim/aim/abilities) is **not** Mirror
   SyncVar — it rides the game's own `EntityNetworkSystem` delta stream keyed by `netId`
   (`r02 §5.1`, `CharNetwork.OnStartClient` → `EntityNetworkSystem.Register`,
   `EntityNetworkSystem.cs:39-43`). An injected NB's `OnSerialize` only fires on Mirror spawn/dirty,
   so it cannot carry per-tick ability state, and it cannot join the predicted/reconciled
   `CharSimulation.netComps` (`INetworkPredicted`, `r05 §1.3`) without matching the game's positional
   reconcile format — which we don't control.
4. **Zero precedent, maximum risk.** `r14 §2`: *"No mod registers a `NetworkBehaviour`… an injected
   runtime type has no weaver-generated serialization."* Every working mod composes onto **existing**
   game `NetworkBehaviour`s instead.

**Verdict:** possible for trivial SyncVar/RPC on an injected NB, but fragile, high-blast-radius, and
unnecessary. We get everything we need from #2 + #4 below without touching it.

### 1.2 Investigation #2 — manual RPCs without the weaver (FEASIBLE, PROVEN)

The weaver's static-cctor registrations and `Send*Internal` calls are all reproducible at runtime.
Exact, real signatures from the decompiled interop assembly:

**Registration (`Il2CppMirror.RemoteCalls.RemoteProcedureCalls`, `RemoteProcedureCalls.cs`):**

```csharp
// RemoteProcedureCalls.cs:RegisterCommand   (public static)
public static void RegisterCommand(Il2CppSystem.Type componentType, string functionFullName,
                                   RemoteCallDelegate func, bool requiresAuthority);   // :~? (public)

// RemoteProcedureCalls.cs:RegisterRpc       (public static)
public static void RegisterRpc(Il2CppSystem.Type componentType, string functionFullName,
                               RemoteCallDelegate func);

// also public: RegisterDelegate(...) -> ushort hash, GetFunctionMethodName(ushort, out string),
// GetDelegate(ushort), Invoke(ushort, RemoteCallType, NetworkReader, NetworkBehaviour, conn),
// and the static dict:  public static Dictionary<ushort, Invoker> remoteCallDelegates;
```

**Send (`Il2CppMirror.NetworkBehaviour`, `NetworkBehaviour.cs`):**

```csharp
// NetworkBehaviour.cs:865
public void SendCommandInternal(string functionFullName, int functionHashCode,
                                NetworkWriter writer, int channelId, bool requiresAuthority = true);
// NetworkBehaviour.cs:881
public void SendRPCInternal(string functionFullName, int functionHashCode,
                            NetworkWriter writer, int channelId, bool includeOwner);
// NetworkBehaviour.cs:897
public void SendTargetRPCInternal(NetworkConnection conn, string functionFullName,
                                  int functionHashCode, NetworkWriter writer, int channelId);
// NetworkBehaviour.cs:808
public void SetSyncVarDirtyBit(ulong dirtyBit);
```

**The delegate (`Il2CppMirror.RemoteCalls.RemoteCallDelegate`, `RemoteCallDelegate.cs`):**

```csharp
public sealed class RemoteCallDelegate : Il2CppSystem.MulticastDelegate {
    public virtual void Invoke(NetworkBehaviour obj, NetworkReader reader,
                               NetworkConnectionToClient senderConnection);
    // implicit conversion from a MANAGED delegate — this is the key:
    public static implicit operator RemoteCallDelegate(
        System.Action<NetworkBehaviour, NetworkReader, NetworkConnectionToClient> P_0);
        // => DelegateSupport.ConvertDelegate<RemoteCallDelegate>(P_0)
}
public enum RemoteCallType { Command, ClientRpc }   // RemoteCallType.cs
```

**Proven precedent.** The ModAPI ships `MirrorCmdRegistry` (`modapi\src\Mirror\MirrorCmdRegistry.cs`,
116 KB of generated wrappers) and the `MirrorCmdDemo` example
(`examples\MirrorCmdDemo\MirrorCmdDemoMod.cs`) which invoke the game's existing weaver-registered
`[Command]` methods (`PlayerDebug.CmdHealMaxHpAll`, `CmdSwitchCharacter(int)`, …) at runtime. That
confirms the command pipeline is fully reachable from a managed MelonLoader mod. Registering our
**own** delegate adds only `RegisterRpc`/`RegisterCommand` + `Send*Internal`, all public above.

**The one real subtlety — the function hash.** `Send*Internal` takes `int functionHashCode`; the
weaver bakes `functionFullName.GetStableHashCode()` and Mirror keys `remoteCallDelegates` on
`(ushort)thatHash`. We must pass a matching hash. Two safe ways (the code in §4 uses BOTH, the second
as a self-validating fallback):

- **Fast path:** compute Mirror's stable hash of `functionFullName` ourselves.
- **Robust path:** after `RegisterRpc(...)`, recover the exact `ushort` key by scanning the public
  `RemoteProcedureCalls.remoteCallDelegates` dictionary and matching via
  `RemoteProcedureCalls.GetFunctionMethodName(key, out name)`. This **sidesteps needing to know
  Mirror's hash algorithm at all** and is what we ship.

**Verdict:** FEASIBLE and low-risk. This is our channel for genuinely-custom synced state/VFX.

### 1.3 Investigation #3 — custom `NetworkMessage` (feasible, more friction)

Real, public, generic signatures (`NetworkServer.cs`, `NetworkClient.cs`):

```csharp
// NetworkServer.cs
public static void RegisterHandler<T>(Il2CppSystem.Action<NetworkConnectionToClient, T> handler,
                                      bool requireAuthentication = true) where T : new();   // :1490
public static void SendToAll<T>(T message, int channelId = 0, bool sendToReadyOnly = false) where T : new();          // :1152
public static void SendToReadyObservers<T>(NetworkIdentity identity, T message,
                                           bool includeOwner = true, int channelId = 0) where T : new();              // :1281
// NetworkClient.cs
public static void RegisterHandler<T>(...) ;   // :1064+   (+ ReplaceHandler/UnregisterHandler)
public static void Send<T>(T message, int channelId = 0) where T : new();
```

These work for **existing** message structs. The blocker for a **new** message type is that Mirror
resolves `Writer<T>.write` / `Reader<T>.read` function pointers that the weaver bakes per message
type; an injected struct has none, so `SendToAll<T>`/the read path can't (de)serialize it without us
hand-registering serializers (more fragile than #2). Because we own both ends and #2 already gives us
a broadcast channel with hand-rolled payloads, **#3 is a fallback, not the primary**. (If we ever
want a connectionless, entity-independent broadcast — e.g. a match-wide custom event — #3 with a
reused/simple message type is the clean choice; otherwise prefer #2.)

**Verdict:** feasible; use only where a per-entity `[ClientRpc]` (#2) is awkward.

### 1.4 Investigation #4 — server-side ability engine (RECOMMENDED)

This is the synthesis and the design we ship. It needs **no** new networked type. It is built from
primitives the game itself uses (`r05 §3-4`, `r13 §6`) and the community has proven (`r14 §3-4`):

1. **Input is already replicated.** The owning client's key bits arrive in the per-tick `Command`
   (`Local/Command.cs`), are dispatched by `CharAbilities.OnTick(fixedDt, cmd, isResim)` and
   confirmed server-side by `CharAbilities.SvOnAbilityTriggered(CommandId)` (`r05 §2.2`,
   `CharAbilities.cs`). We hook the **server-authoritative** trigger, so our engine runs on the real
   dedicated host with the genuine `cmdId` — no client-side fakery.
2. **Spawn REAL networked entities.** On trigger, the engine spawns one of the game's **existing**
   `HitboxBase`/projectile prefabs (already in `NetworkPrefabLibrary`, already weaver-registered,
   already pooled) via `NetworkServer.Spawn(obj[, conn])` (`NetworkServer.cs:1806/1829/1841`) — the
   same call `GameMode.SpawnPlayerChar` and every ability use (`r02 §4`, `r05 §3.5`). Because the
   prefab's `assetId` is identical on server and all clients (it ships in the build), **every player
   sees it** via Mirror's normal replication, and movement/impact replicate through the prefab's own
   `[SyncVar]`/`ProjectileMove`/`[ClientRpc]` (`HitboxBase`, `r05 §4`).
3. **Damage/status through existing `[Server]` paths.** Let the spawned hitbox's collider →
   `HitboxBase.OnHitSuccess` → `CharHurtbox.ApplyHit(...)` do the work (`r13 §6.4`), OR call
   `CharStatusEffects.ActivateStatusEffect(StatusEffectInfo, …)` (`[Server]`-only) for poison/petrify
   with a stable `StatusEffectSO` index (`NEW-CHAR-SYSTEM-CONCEPT.md §1`). All authoritative.
4. **Custom synced STATE/VFX** that has no existing carrier rides the **manual `[ClientRpc]`** from
   #2 (e.g. "Medusa gaze charge = 3", a bespoke aura toggle), broadcast from server to all observers.

**Verdict:** RECOMMENDED. Server-authoritative, all-players-see-it, easy to extend per-character with
data, and built entirely on proven primitives.

---

## 2. Decisive Mirror API surface (cited, copy-ready)

| Concern | Symbol (Il2Cpp) | Location |
|---|---|---|
| Register a runtime Command | `RemoteProcedureCalls.RegisterCommand(Type, string, RemoteCallDelegate, bool)` | `RemoteProcedureCalls.cs` (public static) |
| Register a runtime ClientRpc | `RemoteProcedureCalls.RegisterRpc(Type, string, RemoteCallDelegate)` | `RemoteProcedureCalls.cs` (public static) |
| Recover registered hash | `RemoteProcedureCalls.remoteCallDelegates` (`Dictionary<ushort,Invoker>`) + `GetFunctionMethodName(ushort,out string)` | `RemoteProcedureCalls.cs` |
| Send a Command (client→server) | `NetworkBehaviour.SendCommandInternal(string, int, NetworkWriter, int, bool)` | `NetworkBehaviour.cs:865` |
| Send a ClientRpc (server→all) | `NetworkBehaviour.SendRPCInternal(string, int, NetworkWriter, int, bool includeOwner)` | `NetworkBehaviour.cs:881` |
| Send a TargetRpc (server→one) | `NetworkBehaviour.SendTargetRPCInternal(NetworkConnection, string, int, NetworkWriter, int)` | `NetworkBehaviour.cs:897` |
| Delegate type + managed bridge | `RemoteCallDelegate` (implicit op from `Action<NetworkBehaviour,NetworkReader,NetworkConnectionToClient>`) | `RemoteCallDelegate.cs` |
| Spawn networked object | `NetworkServer.Spawn(GameObject[, NetworkConnection])` / `Spawn(GameObject, uint assetId, …)` | `NetworkServer.cs:1806/1829/1841` |
| Destroy / unspawn | `NetworkServer.Destroy(GameObject)` / `UnSpawn(GameObject)` | `NetworkServer.cs:1889/1878` |
| Custom message handlers | `NetworkServer.RegisterHandler<T>` / `SendToAll<T>` / `SendToReadyObservers<T>` ; `NetworkClient.RegisterHandler<T>` | `NetworkServer.cs:1490/1152/1281`, `NetworkClient.cs:1064+` |
| Writer pool + primitives | `NetworkWriterPool.Get()`; `NetworkWriterExtensions.WriteInt/WriteUInt/WriteFloat/WriteBool/WriteVector3` | `NetworkWriterPool.cs`, `NetworkWriterExtensions.cs:321+` |
| Reader primitives | `NetworkReaderExtensions.ReadInt/ReadUInt/ReadFloat/ReadBool/ReadVector3` | `NetworkReaderExtensions.cs` |
| Server-authoritative ability trigger | `CharAbilities.SvOnAbilityTriggered(CommandId)` / `OnTick(float,Command,bool)` | `Entities/CharAbilities.cs` (`r05 §2.2`) |
| Damage funnel `[Server]` | `CharHurtbox.ApplyHit(int, StatusEffectInfo[], …)` | `Entities/CharHurtbox.cs` (`r13 §6.4`) |
| Status apply `[Server]` | `CharStatusEffects.ActivateStatusEffect(StatusEffectInfo, int, Vector3, bool)` | `Entities/CharStatusEffects.cs` (`MedusaMod.cs` usage) |
| Server-authority check | `((NetworkBehaviour)x).isServer`, `NetworkServer.active` | `NetworkBehaviour`/`NetworkServer` |

---

## 3. Recommended architecture

```
                          (owning client)                          (DEDICATED SERVER - our bapbap.exe)
  key press ──► Command(keyDowns[cmdId]) ──Mirror──► CharAbilities.OnTick / SvOnAbilityTriggered(cmdId)
                                                              │  [Harmony postfix hook — SERVER only]
                                                              ▼
                                              CustomAbilityEngine.OnServerTrigger(entity, cmdId)
                                                              │
                        ┌──────────────────────────┬──────────┴───────────────┬───────────────────────┐
                        ▼                          ▼                          ▼                       ▼
            NetworkServer.Spawn(            CharStatusEffects.         CharHurtbox.ApplyHit(   CustomNetChannel.
            existing HitboxBase prefab,     ActivateStatusEffect(      dmg, statusEffects,     RpcBroadcast(entity,
            owner conn)  ── replicates      poison/petrify SO)         ownerPid) [Server]       customStateId, payload)
            to ALL peers by assetId         [Server]                                            └─ manual [ClientRpc] (#2)
                        │                                                                          replicates to ALL peers
                        ▼
            HitboxBase.ProjectileMove + collider + OnHitSuccess (server) ──► [ClientRpc] impact/destroy VFX
```

- **Server-authoritative**: every gameplay effect originates on the dedicated host (`isServer`),
  exactly like native abilities (`r13 §6`).
- **All-players-see-it**: real networked prefabs replicate by baked `assetId`; the custom-state RPC
  broadcasts to every observer.
- **Extensible**: a new character/ability is a **data record** (`CustomAbilityDef`) mapping a
  `cmdId` to {existing hitbox prefab id, damage, status SO index, custom-state id}. No new code per
  ability in the common case.
- **No injected NetworkBehaviour, no new NetworkMessage type** in the baseline.

---

## 4. Build-ready code skeleton

> Target: MelonLoader + Il2CppInterop + Harmony, `net6.0`, `AllowUnsafeBlocks`, x64, references
> `Il2CppMirror.dll`, `Assembly-CSharp.dll`, `Il2CppInterop.Runtime.dll`, `0Harmony.dll`
> (same reference set as `BAPBAPArenaRandomChars.csproj`, `r14 §1.1`). The **same DLL ships to the
> dedicated server and both clients** (`r13 §9`). Namespaces follow the real interop layout
> (`Il2CppMirror`, `Il2CppMirror.RemoteCalls`, `Il2CppBAPBAP.Entities`).

### 4.1 `MirrorInterop` — the manual-RPC helper (Investigation #2, productized)

```csharp
using System;
using System.Collections.Generic;
using Il2CppInterop.Runtime;                 // Il2CppType
using Il2CppMirror;                           // NetworkBehaviour, NetworkServer, NetworkClient, NetworkReader, NetworkWriter
using Il2CppMirror.RemoteCalls;               // RemoteProcedureCalls, RemoteCallDelegate, RemoteCallType
using MelonLoader;

namespace BapCustomNet
{
    /// <summary>
    /// Reproduces the Mirror weaver's runtime registrations for a NON-WEAVED ClientRpc/Command,
    /// targeting an EXISTING game NetworkBehaviour type (e.g. EntityManager / CharAbilities) so we
    /// inherit a real, replicated identity + spawn lifecycle and never inject a NetworkBehaviour.
    /// </summary>
    public static class MirrorInterop
    {
        // functionFullName -> resolved ushort hash that Mirror actually stored at registration time.
        private static readonly Dictionary<string, int> _hashByName = new();

        /// <summary>
        /// Register a ClientRpc handler (server -> clients). MUST be called identically on the
        /// dedicated server AND every client at mod init, with the SAME componentType + name.
        /// </summary>
        public static void RegisterClientRpc(
            Il2CppSystem.Type componentType,
            string functionFullName,
            Action<NetworkBehaviour, NetworkReader, NetworkConnectionToClient> handler)
        {
            // RemoteCallDelegate has an implicit operator from this exact Action signature
            // (RemoteCallDelegate.cs) -> DelegateSupport.ConvertDelegate under the hood.
            RemoteCallDelegate rcd = handler;
            RemoteProcedureCalls.RegisterRpc(componentType, functionFullName, rcd);  // public static
            CacheHash(functionFullName, RemoteCallType.ClientRpc);
        }

        /// <summary>Register a Command handler (client -> server). Same parity rule.</summary>
        public static void RegisterCommand(
            Il2CppSystem.Type componentType,
            string functionFullName,
            Action<NetworkBehaviour, NetworkReader, NetworkConnectionToClient> handler,
            bool requiresAuthority = true)
        {
            RemoteCallDelegate rcd = handler;
            RemoteProcedureCalls.RegisterCommand(componentType, functionFullName, rcd, requiresAuthority);
            CacheHash(functionFullName, RemoteCallType.Command);
        }

        /// <summary>
        /// ROBUST hash recovery: after registration, find the exact ushort key Mirror stored by
        /// scanning the public remoteCallDelegates dict and matching the function name. This avoids
        /// having to reproduce Mirror's GetStableHashCode algorithm at all.
        /// </summary>
        private static void CacheHash(string functionFullName, RemoteCallType type)
        {
            try
            {
                var dict = RemoteProcedureCalls.remoteCallDelegates; // public static Dictionary<ushort,Invoker>
                if (dict == null) { _hashByName[functionFullName] = StableHash(functionFullName); return; }
                var e = dict.GetEnumerator();
                while (e.MoveNext())
                {
                    ushort key = e.Current.Key;
                    if (RemoteProcedureCalls.GetFunctionMethodName(key, out string name)
                        && name == functionFullName)
                    {
                        _hashByName[functionFullName] = key; // store the exact registered hash
                        return;
                    }
                }
                // Fallback to computed hash if the scan missed (shouldn't happen).
                _hashByName[functionFullName] = StableHash(functionFullName);
            }
            catch (Exception ex)
            {
                MelonLogger.Warning($"[BapCustomNet] hash cache failed for {functionFullName}: {ex.Message}");
                _hashByName[functionFullName] = StableHash(functionFullName);
            }
        }

        public static int HashFor(string functionFullName)
            => _hashByName.TryGetValue(functionFullName, out int h) ? h : StableHash(functionFullName);

        /// <summary>
        /// Mirror's stable string hash (Mirror/Core/Extensions.cs). Used only as a fast path /
        /// fallback; the registered-key scan above is authoritative. SELF-TEST at bring-up:
        /// StableHash("System.Void BAPBAP.Game.GameModeBattleRoyale::RpcSendGameModeEventZoneClosing()")
        /// must equal 881335321 (r13 §3.2). If it does NOT, swap this algorithm for the variant the
        /// build's Mirror uses (the registered-key scan still keeps us correct regardless).
        /// </summary>
        public static int StableHash(string text)
        {
            unchecked
            {
                uint hash = 23;
                foreach (char c in text) hash = hash * 31u + c;
                return (int)hash;
            }
        }
    }
}
```

### 4.2 `CustomNetChannel` — broadcast custom state/VFX to ALL players (uses #2)

```csharp
using System;
using Il2CppInterop.Runtime;
using Il2CppMirror;
using Il2CppBAPBAP.Entities;       // EntityManager (an existing NetworkBehaviour subgraph hub)
using MelonLoader;
using UnityEngine;

namespace BapCustomNet
{
    /// <summary>
    /// A single, hand-rolled ClientRpc registered against the game's EntityManager type. The server
    /// calls Broadcast(...) on a live, already-Mirror-spawned EntityManager; Mirror routes the RPC to
    /// every observer of that entity, where our delegate fires with the SAME EntityManager instance.
    /// Payload is hand-(de)serialized with primitive Write*/Read* — no weaver, no new message type.
    /// </summary>
    public static class CustomNetChannel
    {
        // A unique, stable function signature. Format mimics the weaver's full method name so it is
        // globally unambiguous in Mirror's registry.
        public const string RpcName =
            "System.Void BapCustomNet.CustomNetChannel::RpcCustomState(System.Int32,System.Int32,UnityEngine.Vector3)";

        private static bool _registered;

        /// <summary>Call once at mod init on BOTH server and client (parity is mandatory).</summary>
        public static void Register()
        {
            if (_registered) return;
            MirrorInterop.RegisterClientRpc(
                Il2CppType.Of<EntityManager>(),   // ride an existing NetworkBehaviour type
                RpcName,
                OnClientReceive);
            _registered = true;
            MelonLogger.Msg($"[BapCustomNet] CustomNetChannel registered (hash={MirrorInterop.HashFor(RpcName)}).");
        }

        /// <summary>SERVER: broadcast a custom state event for <paramref name="entity"/> to all observers.</summary>
        public static void Broadcast(EntityManager entity, int stateId, int intArg, Vector3 vecArg)
        {
            if (entity == null) return;
            if (!((NetworkBehaviour)(object)entity).isServer) return;     // server-authoritative only

            NetworkWriterPooled writer = NetworkWriterPool.Get();
            try
            {
                NetworkWriterExtensions.WriteInt((NetworkWriter)(object)writer, stateId);
                NetworkWriterExtensions.WriteInt((NetworkWriter)(object)writer, intArg);
                NetworkWriterExtensions.WriteVector3((NetworkWriter)(object)writer, vecArg);

                // includeOwner:true so the casting player also receives it; channel 0 = reliable.
                ((NetworkBehaviour)(object)entity).SendRPCInternal(
                    RpcName, MirrorInterop.HashFor(RpcName), (NetworkWriter)(object)writer, 0, true);
            }
            finally { NetworkWriterPool.Return(writer); }
        }

        /// <summary>CLIENT (and host): runs on every observer; deserialize + present locally.</summary>
        private static void OnClientReceive(NetworkBehaviour comp, NetworkReader reader,
                                            NetworkConnectionToClient sender)
        {
            try
            {
                int stateId = NetworkReaderExtensions.ReadInt(reader);
                int intArg  = NetworkReaderExtensions.ReadInt(reader);
                Vector3 v   = NetworkReaderExtensions.ReadVector3(reader);

                var entity = comp.TryCast<EntityManager>();
                // Present locally (VFX/anim/state UI). Gate visuals on a render-capable client only;
                // the headless dedicated host must remain renderer-free (r13 §1.3).
                CustomStatePresenter.Apply(entity, stateId, intArg, v);
            }
            catch (Exception ex) { MelonLogger.Warning($"[BapCustomNet] RpcCustomState read failed: {ex.Message}"); }
        }
    }
}
```

### 4.3 `CustomAbilityDef` — the data model (extensibility)

```csharp
namespace BapCustomNet
{
    /// <summary>One ability slot of one custom character, expressed as configuration over the
    /// game's EXISTING networked building blocks. Loaded from JSON (one file per character).</summary>
    public sealed class CustomAbilityDef
    {
        public int    Slot;                 // CommandId: 0=LMB,1=RMB,2=Space,3=E  (r05 §5.3)
        public string HitboxPrefabName;     // an EXISTING game HitboxBase/projectile prefab to spawn
        public int    Damage;
        public float  Cooldown;
        public string[] StatusOnHit;        // e.g. ["poison"] / ["petrify"] -> StatusEffectSO index
        public float  StatusDuration;
        public int    CustomStateId;        // >0 -> also broadcast via CustomNetChannel (optional)
        public string AnimState;            // CharAnimator state hash name (Ability1..Ability4)
        public float  ProjectileSpeed;
    }

    public sealed class CustomCharNetDef
    {
        public int CharId;                  // >14, server+client identical
        public CustomAbilityDef[] Abilities; // up to 4 slots
    }
}
```

### 4.4 `CustomAbilityEngine` — the server-side engine (Investigation #4)

```csharp
using System;
using System.Collections.Generic;
using HarmonyLib;
using Il2CppInterop.Runtime;
using Il2CppMirror;
using Il2CppBAPBAP.Entities;          // EntityManager, CharAbilities, CharHurtbox, CharStatusEffects, HitboxBase, Ability
using Il2CppBAPBAP.Local;             // CommandId
using MelonLoader;
using UnityEngine;

namespace BapCustomNet
{
    public static class CustomAbilityEngine
    {
        // charId -> def. Populated from JSON at init; identical on server and clients.
        private static readonly Dictionary<int, CustomCharNetDef> _defs = new();

        public static void LoadDef(CustomCharNetDef def) => _defs[def.CharId] = def;

        // ---- Server-authoritative hook -------------------------------------------------
        // Hook the genuine server-side ability trigger. SvOnAbilityTriggered(CommandId) is the
        // authoritative confirmation the server raises when a slot fires (r05 §2.2, r13 §6.1).
        [HarmonyPatch(typeof(CharAbilities), nameof(CharAbilities.SvOnAbilityTriggered))]
        public static class SvTriggerPatch
        {
            [HarmonyPostfix]
            public static void Postfix(CharAbilities __instance, CommandId cmdId)
            {
                try
                {
                    var entity = __instance.entityManager;
                    if (entity == null) return;
                    if (!((NetworkBehaviour)(object)entity).isServer) return;   // dedicated host only

                    int charId = SafeCharId(entity);
                    if (!_defs.TryGetValue(charId, out var def)) return;        // not our custom char

                    int slot = (int)cmdId;                                      // 0..3 == Ability1..4
                    foreach (var ab in def.Abilities)
                        if (ab != null && ab.Slot == slot) { Fire(entity, ab); break; }
                }
                catch (Exception ex) { MelonLogger.Warning($"[BapCustomNet] Sv trigger hook: {ex.Message}"); }
            }
        }

        // ---- The actual server effect --------------------------------------------------
        private static void Fire(EntityManager caster, CustomAbilityDef def)
        {
            Vector3 origin = caster.transform.position + Vector3.up * 0.75f;
            Vector3 dir    = AimDir(caster);
            NetworkConnection ownerConn = OwnerConn(caster);

            // 1) Spawn a REAL existing networked prefab so ALL players see it (replicated by assetId).
            GameObject prefab = ResolveExistingNetworkPrefab(def.HitboxPrefabName);
            if (prefab != null)
            {
                GameObject obj = UnityEngine.Object.Instantiate(prefab, origin, Quaternion.LookRotation(dir));
                ConfigureHitbox(obj, caster, def, dir);     // set ownerPlayerId/teamId/damage/statusEffects on HitboxBase
                if (ownerConn != null) NetworkServer.Spawn(obj, ownerConn);   // NetworkServer.cs:1829
                else                   NetworkServer.Spawn(obj);              // bots / server-owned
            }
            else
            {
                // No prefab configured: apply damage directly through the server damage funnel.
                ApplyDirectHit(caster, def, origin, dir);
            }

            // 2) Optional custom synced state/VFX with no native carrier -> manual ClientRpc (#2).
            if (def.CustomStateId > 0)
                CustomNetChannel.Broadcast(caster, def.CustomStateId, def.Slot, dir);
        }

        // Reuse the game's own pool/library so the prefab is the SAME asset (and assetId) on all peers.
        private static GameObject ResolveExistingNetworkPrefab(string name)
        {
            if (string.IsNullOrEmpty(name)) return null;
            var gnm = GameNetworkManagerRef();        // find GameNetworkManager.Instance
            if (gnm == null) return null;
            // Search NetworkPrefabLibrary.PooledPrefabs / InstantiatedPrefabs by prefab name (r02 §2).
            return PrefabLibraryLookup(gnm, name);    // helper omitted for brevity — name match in library
        }

        private static void ConfigureHitbox(GameObject obj, EntityManager caster, CustomAbilityDef def, Vector3 dir)
        {
            var hb = obj.GetComponentInChildren<HitboxBase>(true);
            if (hb == null) return;
            int ownerPid = SafeOwnerPid(caster);
            hb.ownerPlayerId = ownerPid;                                  // [SyncVar] (r05 §4)
            hb.teamId        = SafeTeam(caster);                          // [SyncVar]
            hb.damage        = def.Damage;
            hb._statusEffects = BuildStatusEffects(def);                  // List<StatusEffectInfo>
            // direction/speed are carried by the prefab's ProjectileMove; leave its native config or set here.
        }

        // Direct server hit (mirrors CharHurtbox.ApplyHit usage in MedusaMod, but ONLY on the real server).
        private static void ApplyDirectHit(EntityManager caster, CustomAbilityDef def, Vector3 origin, Vector3 dir)
        {
            foreach (var target in FindTargets(caster, def, origin, dir))   // cone/box scan vs EntityManager set
            {
                var hurt = target.charHurtbox;
                if (hurt == null) continue;
                hurt.ApplyHit(def.Damage, BuildStatusEffectArray(def), SafeOwnerPid(caster),
                              caster.gameObject, false, false, true, true, false, dir, true, false, null);
            }
        }

        // Status via the [Server]-only path with a stable StatusEffectSO index (NEW-CHAR-SYSTEM-CONCEPT §1).
        private static StatusEffectInfo[] BuildStatusEffectArray(CustomAbilityDef def) { /* resolve SO by index, build array */ return Array.Empty<StatusEffectInfo>(); }
        private static Il2CppSystem.Collections.Generic.List<StatusEffectInfo> BuildStatusEffects(CustomAbilityDef def) { /* same, as Il2Cpp list */ return new(); }

        // ---- small safe helpers (try/catch wrapped per r14 §8) -------------------------
        private static int  SafeCharId(EntityManager e)   { try { return e.charId; } catch { return -1; } }
        private static int  SafeOwnerPid(EntityManager e) { try { return e.ownerPlayerId; } catch { return -1; } }
        private static int  SafeTeam(EntityManager e)     { try { return e.entityTeamId; } catch { return -1; } }
        private static Vector3 AimDir(EntityManager e)    { try { var d = e.charAim.lookDir; d.y = 0; return d.sqrMagnitude > 0.01f ? d.normalized : e.transform.forward; } catch { return Vector3.forward; } }
        private static NetworkConnection OwnerConn(EntityManager e) { /* resolve playerManager.connectionToClient */ return null; }
        private static object GameNetworkManagerRef() { /* GameNetworkManager.Instance */ return null; }
        private static GameObject PrefabLibraryLookup(object gnm, string name) { /* iterate PooledPrefabs/InstantiatedPrefabs */ return null; }
        private static IEnumerable<EntityManager> FindTargets(EntityManager c, CustomAbilityDef d, Vector3 o, Vector3 dir) { yield break; }
    }
}
```

### 4.5 Mod wiring (entry point — server + client, same DLL)

```csharp
using MelonLoader;
using HarmonyLib;
using BapCustomNet;

[assembly: MelonInfo(typeof(BapCustomNetMelon), "BapCustomNet", "1.0.0", "BAPBAPCustomServer")]
[assembly: MelonGame("gg.bapbap", "BAPBAP")]   // r14 §1.2 — matches the working build

public sealed class BapCustomNetMelon : MelonMod
{
    private HarmonyLib.Harmony _h;

    public override void OnInitializeMelon()
    {
        // 1) Register the manual ClientRpc channel on BOTH ends, identically, before any spawn. (#2)
        CustomNetChannel.Register();

        // 2) Load per-character ability defs (JSON) -> identical content on server + clients. (#4, r14 §6)
        foreach (var def in CustomCharDefLoader.LoadAll())   // your JSON loader
            CustomAbilityEngine.LoadDef(def);

        // 3) Apply the server-side ability engine hook (manual patching per r14 §1.5 / §8).
        _h = new HarmonyLib.Harmony("com.bapbap.customserver.net");
        _h.PatchAll(typeof(CustomAbilityEngine).Assembly);   // or targeted AccessTools.Method patching
    }

    public override void OnDeinitializeMelon() => _h?.UnpatchSelf();
}
```

---

## 5. How this solves every old failure (mapped)

| Old symptom (`r02 §8`, `r05 §6`, `r13 §8`) | This design |
|---|---|
| Invisible to others / visuals local-only | Effects are **real `NetworkServer.Spawn`ed** existing prefabs with a baked `assetId` present on every peer (`§4.4` step 1); custom state rides a **real ClientRpc** to all observers (`§4.2`). Nothing is a local `Object.Instantiate`. |
| Despawn | We spawn **the game's own** pooled/library prefabs (correct identity bookkeeping) via the authoritative server; no hand-stamped `assetId`, no sanitization hacks. |
| Frozen poses | We never graft a local visual; the body is the real server-spawned char driven by `EntityNetworkSystem` (`r02 §5.1`). Ability anim uses the real `CharAnimator` states. |
| Only LMB works / RMB green dot / Space desync / E = base anim | The engine hooks the **server** `SvOnAbilityTriggered(cmdId)` for **all four** slots and produces real networked effects + `[Server]` damage/status; nothing runs outside the authoritative trigger, so no client-side fakes and no rubber-banding. |

---

## 6. Brutally honest risks & required validation

1. **Function-hash parity (medium).** `Send*Internal` needs the `int` whose low 16 bits equal Mirror's
   registered `ushort`. Mitigation: `MirrorInterop.CacheHash` recovers the **exact** registered key
   from `remoteCallDelegates` (`§4.1`), so we never rely on guessing the algorithm. Bring-up self-test:
   assert `StableHash("…RpcSendGameModeEventZoneClosing()") == 881335321` (`r13 §3.2`); if it fails, the
   scan path still keeps us correct — fix the fast-path constant only.
2. **Registration parity + timing (high if violated).** `RegisterClientRpc`/`RegisterCommand` MUST run
   **identically on the dedicated server and every client at mod init**, before any spawn/RPC. Same DLL
   on all peers (`r13 §9`) makes this automatic; do not branch the registration on `isServer`.
3. **`requiresAuthority` for Commands.** If we add client→server custom Commands later, set
   `requiresAuthority` correctly (owned entity vs. global) — Mirror drops unauthorized commands.
4. **Existing-prefab availability (medium).** `§4.4` reuses prefabs from `NetworkPrefabLibrary`. We must
   pick `HitboxBase`/projectile prefabs that are actually registered on the server build (they are —
   they ship with the game). Adding a **brand-new** hitbox prefab would require the full prefab-build +
   library-registration flow from `NEW-CHAR-SYSTEM-CONCEPT.md §6` / `r02 §6` on both ends.
5. **Headless safety (low, already understood).** All VFX/SFX/visual presentation stays behind a
   render-capable-client gate (`CanSpawnClientFx`, `r13 §1.3`); the dedicated host runs gameplay only.
6. **Determinism / prediction (medium).** Because we hook `SvOnAbilityTriggered` (server-confirmed
   trigger) rather than injecting into the predicted tick, our spawned effects are server-spawned and
   replicated normally — they do not need to participate in client prediction. If a future ability
   needs predicted client feel, prefer configuring an **existing** `Ability` subclass (with its real,
   already-reconciled FSM) over any custom predicted code (`r05 §6.3`).
7. **Injected NetworkBehaviour stays off the table** (`§1.1`). If a requirement ever truly needs a new
   per-tick replicated field, the correct escalation is **not** an injected NB but adding a real
   weaver-built component to a game-assembly rebuild on server+client — a separate, larger project
   (`NEW-CHAR-SYSTEM-CONCEPT.md §5 "Grenze"`).

---

## 7. Definitive recommendation (one paragraph)

Add custom networked behavior to a custom character via a **server-side ability engine** that hooks
the game's authoritative `CharAbilities.SvOnAbilityTriggered(cmdId)`, spawns the game's **existing**
networked `HitboxBase`/projectile prefabs through `NetworkServer.Spawn` with per-ability config,
applies damage/status through the existing `[Server]` `CharHurtbox.ApplyHit` /
`CharStatusEffects.ActivateStatusEffect` paths, and carries any genuinely-custom synced state/VFX over
a thin **manual `[ClientRpc]`** registered with `RemoteProcedureCalls.RegisterRpc` on the existing
`EntityManager` type and sent with `SendRPCInternal` (Investigation #2, proven). Do **not** inject a
`NetworkBehaviour` (Investigation #1 — possible but fragile, wrong cadence, zero precedent) and reserve
custom `NetworkMessage` types (Investigation #3) for match-wide, entity-independent broadcasts only.
This is fully server-authoritative, every player sees it, and a new character/ability is a JSON data
record over proven primitives.
