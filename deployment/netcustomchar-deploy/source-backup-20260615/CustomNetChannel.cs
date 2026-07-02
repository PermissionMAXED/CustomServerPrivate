using System;
using MelonLoader;
using UnityEngine;
using Il2CppInterop.Runtime;
using Il2CppMirror;
using Il2CppBAPBAP.Entities;

using UObject = UnityEngine.Object;

namespace NetworkedCustomChar
{
    /// <summary>
    /// M3 #2 — a single hand-rolled ClientRpc registered against the game's EntityManager type
    /// (EntityManager : NetworkBehaviour, verified). The server calls <see cref="Broadcast"/> on a live,
    /// already-Mirror-spawned EntityManager; Mirror routes the RPC to every observer of that entity, where
    /// <see cref="OnClientReceive"/> fires with the SAME EntityManager instance. Payload is hand-serialized
    /// with primitive Write*/Read* — no weaver, no new message type.
    ///
    /// Verified Il2CppMirror signatures:
    ///   NetworkWriterPool.Get() : NetworkWriterPooled ; NetworkWriterPool.Return(NetworkWriterPooled)
    ///   NetworkWriterPooled : NetworkWriter            (so it passes directly where NetworkWriter is expected)
    ///   NetworkWriterExtensions.WriteInt/WriteVector3(this NetworkWriter, ...)
    ///   NetworkReaderExtensions.ReadInt/ReadVector3(this NetworkReader)
    ///   NetworkBehaviour.SendRPCInternal(string, int, NetworkWriter, int channelId, bool includeOwner)
    /// </summary>
    internal static class CustomNetChannel
    {
        // A unique, stable function signature (mimics the weaver's full method name for registry uniqueness).
        public const string RpcName =
            "System.Void NetworkedCustomChar.CustomNetChannel::RpcCustomState(System.Int32,System.Int32,UnityEngine.Vector3)";

        // Custom state ids broadcast to all observers (cosmetic only; gameplay is server-authoritative).
        public const int StateAbilityCast = 1;   // intArg = slot 0..3, vec = aim/cast dir

        private static bool _registered;

        private static bool IsNull(UObject? o) => (UObject)o! == (UObject?)null;

        /// <summary>Call once at mod init on BOTH server and client (parity is mandatory).</summary>
        public static void Register()
        {
            if (_registered) return;
            try
            {
                Action<NetworkBehaviour, NetworkReader, NetworkConnectionToClient> handler = OnClientReceive;
                MirrorInterop.RegisterClientRpc(Il2CppType.Of<EntityManager>(), RpcName, handler);
                _registered = true;
                MelonLogger.Msg($"[M3] CustomNetChannel registered on EntityManager (hash={MirrorInterop.HashFor(RpcName)}).");
            }
            catch (Exception ex) { MelonLogger.Warning($"[M3] CustomNetChannel.Register failed: {ex.Message}"); }
        }

        /// <summary>SERVER: broadcast a custom cosmetic event for <paramref name="entity"/> to all observers.</summary>
        public static void Broadcast(EntityManager entity, int stateId, int intArg, Vector3 vecArg)
        {
            try
            {
                if (!_registered || IsNull(entity)) return;
                NetworkBehaviour nb = (NetworkBehaviour)entity;               // EntityManager : NetworkBehaviour
                if (!nb.isServer) return;                                     // server-authoritative only

                NetworkWriterPooled writer = NetworkWriterPool.Get();
                try
                {
                    NetworkWriterExtensions.WriteInt(writer, stateId);
                    NetworkWriterExtensions.WriteInt(writer, intArg);
                    NetworkWriterExtensions.WriteVector3(writer, vecArg);
                    // includeOwner:true so the casting player also receives it; channel 0 = reliable.
                    nb.SendRPCInternal(RpcName, MirrorInterop.HashFor(RpcName), writer, 0, true);
                }
                finally { NetworkWriterPool.Return(writer); }
            }
            catch (Exception ex) { MelonLogger.Warning($"[M3] Broadcast failed: {ex.Message}"); }
        }

        /// <summary>CLIENT + host: runs on every observer; deserialize + present locally (render-gated).</summary>
        private static void OnClientReceive(NetworkBehaviour comp, NetworkReader reader, NetworkConnectionToClient sender)
        {
            try
            {
                int stateId = NetworkReaderExtensions.ReadInt(reader);
                int intArg  = NetworkReaderExtensions.ReadInt(reader);
                Vector3 v   = NetworkReaderExtensions.ReadVector3(reader);

                // Gate all visual presentation behind a render-capable client; the headless host stays renderer-free.
                if (!MedusaVisualGraft.CanSpawnClientFx()) return;

                EntityManager? entity = comp.TryCast<EntityManager>();
                CustomVfxPresenter.Apply(entity, stateId, intArg, v);
            }
            catch (Exception ex) { MelonLogger.Warning($"[M3] RpcCustomState read failed: {ex.Message}"); }
        }
    }

    /// <summary>
    /// Render-gated client presenter for custom Medusa VFX driven over <see cref="CustomNetChannel"/>.
    /// M6: instantiates the active def's per-slot cosmetic VFX prefab(s) from the bundle (TTL-destroyed)
    /// and plays the slot's cast animation on the casting entity, on every observer in lockstep.
    /// </summary>
    internal static class CustomVfxPresenter
    {
        private static int _logCount;

        // Per-slot VFX prefab names (';'-separated lists). Defaults match the proven Medusa VFX set; the
        // active config def's AbilityVfx overrides per slot when present.
        private static readonly string[] _defaultVfx =
        {
            "VFX_Medusa_Poison_Muzzle;VFX_Medusa_Poison_Trail;VFX_Medusa_Poison_Hit",
            "VFX_Medusa_Poison_Muzzle;VFX_Medusa_Poison_Trail;VFX_Medusa_Poison_Puddle",
            "VFX_Medusa_Poison_Escape;VFX_Medusa_Poison_Trail;VFX_Medusa_Poison_Puddle",
            "VFX_Medusa_Poison_Muzzle;VFX_Medusa_Poison_Wall;VFX_Medusa_Poison_Hit"
        };

        private static bool IsNull(UObject? o) => (UObject)o! == (UObject?)null;

        private static string SlotVfx(int slot)
        {
            try
            {
                CustomCharDef? def = null;
                var loaded = CustomCharConfig.Loaded;
                if (loaded != null) foreach (var d in loaded) { if (d.Enabled) { def = d; break; } }
                if (def == null && loaded != null && loaded.Count > 0) def = loaded[0];
                var a = def?.AbilityVfx;
                if (a != null && slot >= 0 && slot < a.Length && !string.IsNullOrWhiteSpace(a[slot])) return a[slot];
            }
            catch { }
            return (slot >= 0 && slot < 4) ? _defaultVfx[slot] : "";
        }

        public static void Apply(EntityManager? entity, int stateId, int intArg, Vector3 dir)
        {
            try
            {
                if (stateId != CustomNetChannel.StateAbilityCast) return;
                int slot = intArg;

                // 1) cast animation on the casting entity (render-gated inside PlayCastAnim).
                try { CustomAbilityEngine.PlayCastAnim(entity, slot); } catch { }

                // 2) cosmetic VFX from the bundle, oriented along the cast dir, TTL-destroyed.
                Vector3 pos = Vector3.zero;
                try { if (!IsNull(entity)) pos = ((UnityEngine.Component)entity!).transform.position; } catch { }
                Vector3 fwd = dir; fwd.y = 0f;
                Quaternion rot = (fwd.sqrMagnitude > 0.01f) ? Quaternion.LookRotation(fwd.normalized, Vector3.up) : Quaternion.identity;
                float ttl = (slot == 1 || slot == 2) ? 2.4f : 2.0f;   // puddle/ground lingers a touch longer

                int spawned = 0;
                string names = SlotVfx(slot);
                foreach (string raw in names.Split(';'))
                {
                    string name = raw.Trim();
                    if (name.Length == 0) continue;
                    GameObject? prefab = MedusaVisualGraft.LoadBundleGameObject(name);
                    if (IsNull(prefab)) continue;
                    try
                    {
                        GameObject go = UObject.Instantiate(prefab!, pos + Vector3.up * 0.9f, rot);
                        if (!IsNull(go)) { UObject.Destroy(go, ttl); spawned++; }
                    }
                    catch { }
                }

                if (_logCount < 32)
                {
                    _logCount++;
                    string who = "?";
                    try { if (!IsNull(entity)) who = ((UnityEngine.Component)entity!).gameObject.name; } catch { }
                    MelonLogger.Msg($"[M6] client VFX presented: entity='{who}' slot={slot} vfxSpawned={spawned} ttl={ttl} dir=({dir.x:F1},{dir.y:F1},{dir.z:F1}).");
                }
            }
            catch (Exception ex) { MelonLogger.Warning($"[M6] CustomVfxPresenter.Apply: {ex.Message}"); }
        }
    }
}
