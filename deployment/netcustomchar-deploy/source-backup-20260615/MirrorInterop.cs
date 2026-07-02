using System;
using System.Collections.Generic;
using MelonLoader;
using Il2CppMirror;
using Il2CppMirror.RemoteCalls;

namespace NetworkedCustomChar
{
    /// <summary>
    /// M3 #1 — manual Mirror RPC registration WITHOUT the weaver, targeting an EXISTING game
    /// NetworkBehaviour type (we use EntityManager). Reproduces the weaver's runtime registration via
    /// RemoteProcedureCalls.RegisterRpc and recovers the exact ushort hash Mirror stored by scanning
    /// the public remoteCallDelegates dictionary (so we never depend on guessing Mirror's hash algorithm).
    ///
    /// All signatures verified against the decompiled Il2CppMirror:
    ///   RemoteProcedureCalls.RegisterRpc(Il2CppSystem.Type, string, RemoteCallDelegate)          (public static)
    ///   RemoteProcedureCalls.GetFunctionMethodName(ushort, out string)                           (public static)
    ///   RemoteProcedureCalls.remoteCallDelegates : Dictionary&lt;ushort, Invoker&gt;             (public static field)
    ///   RemoteCallDelegate.op_Implicit(System.Action&lt;NetworkBehaviour,NetworkReader,NetworkConnectionToClient&gt;)
    /// </summary>
    internal static class MirrorInterop
    {
        private static readonly Dictionary<string, int> _hashByName = new();

        /// <summary>Register a ClientRpc handler (server -&gt; clients). MUST run identically on the
        /// dedicated server AND every client at mod init (same DLL guarantees this).</summary>
        public static void RegisterClientRpc(
            Il2CppSystem.Type componentType,
            string functionFullName,
            Action<NetworkBehaviour, NetworkReader, NetworkConnectionToClient> handler)
        {
            RemoteCallDelegate rcd = handler;                                  // implicit operator (verified)
            RemoteProcedureCalls.RegisterRpc(componentType, functionFullName, rcd);
            CacheHash(functionFullName);
        }

        // Robust hash recovery: find the exact ushort key Mirror stored at registration time.
        private static void CacheHash(string functionFullName)
        {
            try
            {
                var dict = RemoteProcedureCalls.remoteCallDelegates;          // Dictionary<ushort, Invoker>
                if (dict != null)
                {
                    var e = dict.GetEnumerator();
                    while (e.MoveNext())
                    {
                        ushort key = e.Current.Key;
                        if (RemoteProcedureCalls.GetFunctionMethodName(key, out string name) && name == functionFullName)
                        {
                            _hashByName[functionFullName] = key;
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MelonLogger.Warning($"[M3] hash recovery scan failed for {functionFullName}: {ex.Message}");
            }
            // Fast-path / fallback (the scan above is authoritative when it succeeds).
            _hashByName[functionFullName] = StableHash(functionFullName);
        }

        public static int HashFor(string functionFullName)
            => _hashByName.TryGetValue(functionFullName, out int h) ? h : StableHash(functionFullName);

        /// <summary>Mirror's stable string hash (Mirror/Core/Extensions.cs) — fast-path/fallback only.</summary>
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
