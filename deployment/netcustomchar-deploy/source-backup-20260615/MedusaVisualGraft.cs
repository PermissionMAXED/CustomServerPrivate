using System;
using System.IO;
using MelonLoader;
using UnityEngine;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppBAPBAP.Entities;

using UObject = UnityEngine.Object;

namespace NetworkedCustomChar
{
    /// <summary>
    /// M2 — networked Medusa VISUAL.
    ///
    /// This bakes the Medusa model from <c>medusa.bundle</c> INTO the networked prefab template
    /// (Char_Custom15) built in <see cref="CustomCharMod.BuildNetworkedPrefab"/>. Because the SAME
    /// DLL + SAME bundle ship to the dedicated server and every client, every peer instantiates an
    /// identical child layout. The grafted visual subtree carries NO NetworkIdentity / NetworkBehaviour,
    /// so Mirror's component layout on the networked chassis is unchanged — the visual replicates purely
    /// because it is part of the registered prefab.
    ///
    /// The Il2Cpp accessors here are copied verbatim from the PROVEN, known-working graft in the old
    /// client-only mod (bapcustomchars-mod\MedusaMod.cs: TryLoadBundle / GraftMedusaVisual /
    /// DisableBaseCharacterRenderers / CharAnimator wiring / material rebind). The only architectural
    /// change is the TARGET: we apply them to the prefab TEMPLATE instead of a live client-only clone.
    ///
    /// Headless-safe: the SkinnedMeshRenderer graft + animator wiring run on every peer (a static SMR is
    /// fine on the dedicated host). GPU-ish material/shader rebind is gated behind a render-capable check.
    /// </summary>
    internal static class MedusaVisualGraft
    {
        internal static string VisualAssetName = "Medusa_Visual";   // M5: set from active def's VisualPrefabName
        internal static string? ActiveBundleRel = null;             // M5: "<Name>\<BundleFileName>" of the active def

        private static Il2CppAssetBundle? _bundle;
        private static GameObject? _visualPrefab;
        private static bool _attempted;
        private static bool _loaded;

        private static bool IsNull(UObject? o) => (UObject)o! == (UObject?)null;

        /// <summary>Headless / batch-mode guard. The dedicated host must stay renderer-free for VFX.</summary>
        internal static bool CanSpawnClientFx()
        {
            try { if (Application.isBatchMode) return false; } catch { }
            return true;
        }

        // ----------------------------------------------------------------------------------------
        // Bundle load (PROVEN: MedusaMod.TryLoadBundle accessors)
        // ----------------------------------------------------------------------------------------
        private static bool EnsureBundle()
        {
            if (_loaded) return true;
            if (_attempted) return _loaded;
            _attempted = true;
            try
            {
                string path = ResolveBundlePath();
                if (string.IsNullOrEmpty(path) || !File.Exists(path))
                {
                    MelonLogger.Warning($"[M2] medusa.bundle not found (looked at '{path}'); GRAFT SKIPPED (prefab keeps Kitsu visual).");
                    return false;
                }
                MelonLogger.Msg($"[M2] loading bundle: '{path}' ({new FileInfo(path).Length} bytes).");
                _bundle = Il2CppAssetBundleManager.LoadFromFile(path);
                if (_bundle == null) { MelonLogger.Warning("[M2] LoadFromFile returned null."); return false; }

                Il2CppSystem.Type goType = Il2CppType.Of<GameObject>();
                _visualPrefab = TryLoadAssetTyped(VisualAssetName, goType)
                             ?? TryLoadAssetTyped("Assets/GameObject/" + VisualAssetName + ".prefab", goType);
                if (IsNull(_visualPrefab))
                {
                    // scan
                    Il2CppStringArray? names = null;
                    try { names = _bundle.GetAllAssetNames(); } catch { }
                    if (names != null)
                    {
                        for (int i = 0; i < ((Il2CppArrayBase<string>)(object)names).Length; i++)
                        {
                            string n = ((Il2CppArrayBase<string>)(object)names)[i];
                            if (n != null && n.IndexOf(VisualAssetName, StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                _visualPrefab = TryLoadAssetTyped(n, goType);
                                if (!IsNull(_visualPrefab)) break;
                            }
                        }
                    }
                }
                if (IsNull(_visualPrefab)) { MelonLogger.Warning("[M2] 'Medusa_Visual' not retrievable from bundle."); return false; }

                _loaded = true;
                MelonLogger.Msg($"[M2] visual prefab '{_visualPrefab!.name}' loaded from bundle.");
                return true;
            }
            catch (Exception e) { MelonLogger.Error($"[M2] EnsureBundle: {e}"); return false; }
        }

        private static GameObject? TryLoadAssetTyped(string name, Il2CppSystem.Type goType)
        {
            try
            {
                UObject? val = _bundle!.LoadAsset(name, goType);
                if ((UObject)val! == (UObject?)null) return null;
                return ((Il2CppObjectBase)val!).Cast<GameObject>();
            }
            catch (Exception ex) { MelonLogger.Warning($"[M2] LoadAsset('{name}') threw: {ex.Message}"); return null; }
        }

        /// <summary>
        /// M3c — load an arbitrary GameObject prefab from the SAME medusa.bundle by short name, trying the
        /// proven name/path variants and finally a contains-scan. Used to pull the authored poison hitbox /
        /// VFX subtrees (Hitbox_MedusaPoison* / VFX_Medusa_Poison_*) for grafting onto a networked chassis.
        /// Reuses the proven <see cref="EnsureBundle"/> + <see cref="TryLoadAssetTyped"/> accessors. Returns
        /// the bundle prefab (NOT instantiated) or null if the bundle/asset is unavailable.
        /// </summary>
        internal static GameObject? LoadBundleGameObject(string assetName)
        {
            try
            {
                if (string.IsNullOrEmpty(assetName)) return null;
                if (!EnsureBundle()) return null;

                Il2CppSystem.Type goType = Il2CppType.Of<GameObject>();
                GameObject? go = TryLoadAssetTyped(assetName, goType)
                              ?? TryLoadAssetTyped("Assets/GameObject/MedusaVfx/" + assetName + ".prefab", goType)
                              ?? TryLoadAssetTyped("Assets/GameObject/" + assetName + ".prefab", goType);
                if (IsNull(go))
                {
                    Il2CppStringArray? names = null;
                    try { names = _bundle!.GetAllAssetNames(); } catch { }
                    if (names != null)
                    {
                        for (int i = 0; i < ((Il2CppArrayBase<string>)(object)names).Length; i++)
                        {
                            string n = ((Il2CppArrayBase<string>)(object)names)[i];
                            if (n != null && n.IndexOf(assetName, StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                go = TryLoadAssetTyped(n, goType);
                                if (!IsNull(go)) break;
                            }
                        }
                    }
                }
                return IsNull(go) ? null : go;
            }
            catch (Exception ex) { MelonLogger.Warning($"[M3c] LoadBundleGameObject('{assetName}'): {ex.Message}"); return null; }
        }

        private static string ResolveBundlePath()
        {
            // 1) explicit override
            try
            {
                string env = Environment.GetEnvironmentVariable("BAPBAP_NETCUSTOM_BUNDLE") ?? "";
                if (!string.IsNullOrEmpty(env) && File.Exists(env)) return env;
            }
            catch { }

            // 2) the standard deploy location relative to the game root + a couple of fallbacks.
            foreach (string root in CandidateRoots())
            {
                if (string.IsNullOrEmpty(root)) continue;
                var rels = new System.Collections.Generic.List<string>();
                if (!string.IsNullOrEmpty(ActiveBundleRel)) rels.Add(Path.Combine("UserData", ActiveBundleRel));
                rels.Add(Path.Combine("UserData", "Medusa", "medusa.bundle"));
                rels.Add(Path.Combine("UserData", "medusa.bundle"));
                rels.Add(Path.Combine("Mods", "medusa.bundle"));
                rels.Add("medusa.bundle");
                foreach (string rel in rels)
                {
                    try { string p = Path.Combine(root, rel); if (File.Exists(p)) return p; } catch { }
                }
            }
            return "";
        }

        private static System.Collections.Generic.List<string> CandidateRoots()
        {
            var roots = new System.Collections.Generic.List<string>();
            try { string r = MelonLoader.Utils.MelonEnvironment.GameRootDirectory; if (!string.IsNullOrEmpty(r)) roots.Add(r); } catch { }
            try { string r = AppDomain.CurrentDomain.BaseDirectory; if (!string.IsNullOrEmpty(r)) roots.Add(r); } catch { }
            try { string r = Directory.GetCurrentDirectory(); if (!string.IsNullOrEmpty(r)) roots.Add(r); } catch { }
            return roots;
        }

        // ----------------------------------------------------------------------------------------
        // GRAFT (PROVEN: MedusaMod.GraftMedusaVisual accessors, applied to the prefab TEMPLATE)
        // ----------------------------------------------------------------------------------------
        internal static bool Graft(GameObject clone, string src)
        {
            try
            {
                if (!EnsureBundle()) return false;

                bool fx = CanSpawnClientFx();

                // Capture a base "toon" material (its shader) to reuse on the Medusa SMRs (render clients only).
                Material? toon = null;
                if (fx)
                {
                    foreach (SkinnedMeshRenderer smr in clone.GetComponentsInChildren<SkinnedMeshRenderer>(true))
                    {
                        if (IsNull(smr)) continue;
                        Material m = ((Renderer)smr).sharedMaterial;
                        if (!IsNull(m) && !IsNull(m.shader)) { toon = m; break; }
                    }
                }

                // Disable the base Kitsu renderers (proven DisableBaseCharacterRenderers).
                int disabled = 0;
                foreach (Renderer r in clone.GetComponentsInChildren<Renderer>(true))
                {
                    if (IsNull(r)) continue;
                    try { if (r.enabled) disabled++; r.enabled = false; try { r.forceRenderingOff = true; } catch { } } catch { }
                }

                // Instantiate the Medusa model under the clone root.
                GameObject vis = UObject.Instantiate(_visualPrefab!, clone.transform, false);
                vis.name = VisualAssetName;
                try { vis.transform.localPosition = Vector3.zero; vis.transform.localRotation = Quaternion.identity; } catch { }

                // Wire CharAnimator -> Medusa's Animator (+customAnimator) and CharFootsteps (proven).
                Animator medAnim = vis.GetComponentInChildren<Animator>(true);
                int caWired = 0, cfWired = 0, disabledAnims = 0;
                if (!IsNull(medAnim))
                {
                    foreach (CharAnimator ca in clone.GetComponentsInChildren<CharAnimator>(true))
                    {
                        if (IsNull(ca)) continue;
                        try { ca.animator = medAnim; try { ca.customAnimator = true; } catch { } caWired++; }
                        catch (Exception ex) { MelonLogger.Warning($"[M2] CharAnimator.animator wire failed: {ex.Message}"); }
                    }
                    foreach (CharFootsteps cf in clone.GetComponentsInChildren<CharFootsteps>(true))
                    {
                        if (IsNull(cf)) continue;
                        try { cf.animator = medAnim; cfWired++; } catch { }
                    }
                    // Disable every non-Medusa Animator on the clone so the base body anim can't fight ours.
                    foreach (Animator a in clone.GetComponentsInChildren<Animator>(true))
                    {
                        if (IsNull(a) || (UObject)a == (UObject)medAnim) continue;
                        try { ((Behaviour)a).enabled = false; disabledAnims++; } catch { }
                    }
                }
                else
                {
                    MelonLogger.Warning("[M2] graft: no Animator under Medusa_Visual; CharAnimator wiring skipped.");
                }

                // Material/shader rebind: clone the base toon shader onto Medusa's SMRs, keeping Medusa's
                // albedo/normal textures (proven). Render-capable clients only.
                int shaded = 0;
                if (fx && !IsNull(toon))
                {
                    string shaderName = toon!.shader.name;
                    foreach (SkinnedMeshRenderer item in vis.GetComponentsInChildren<SkinnedMeshRenderer>(true))
                    {
                        if (IsNull(item)) continue;
                        Material src2 = ((Renderer)item).sharedMaterial;
                        Texture? albedo = FirstTex(src2, "_MainTex", "_BaseMap", "_AlbedoTex", "_AlbedoMap");
                        Texture? normal = FirstTex(src2, "_BumpMap", "_NormalMap", "_NormalTex");
                        Material mat;
                        try { mat = new Material(toon); } catch (Exception ex) { MelonLogger.Warning($"[M2] new Material(toon) threw: {ex.Message}"); break; }
                        mat.name = "Medusa_Material_Native";
                        SetTex(mat, albedo, "_MainTex", "_BaseMap", "_AlbedoTex", "_AlbedoMap");
                        SetTex(mat, normal, "_BumpMap", "_NormalMap", "_NormalTex");
                        ((Renderer)item).sharedMaterial = mat;
                        shaded++;
                    }
                }

                MelonLogger.Msg($"[M2] graft OK via {src}: baseRenderersDisabled={disabled}, charAnimWired={caWired}, " +
                                $"footstepsWired={cfWired}, otherAnimsDisabled={disabledAnims}, shadedSMRs={shaded}, fx={fx}, " +
                                $"controller='{ControllerName(medAnim)}'.");
                return true;
            }
            catch (Exception e) { MelonLogger.Error($"[M2] Graft({src}): {e}"); return false; }
        }

        private static string ControllerName(Animator a)
        {
            try { return (!IsNull(a) && !IsNull(a.runtimeAnimatorController)) ? a.runtimeAnimatorController.name : "?"; } catch { return "?"; }
        }

        private static Texture? FirstTex(Material m, params string[] props)
        {
            if (IsNull(m)) return null;
            foreach (string p in props)
            {
                try { if (m.HasProperty(p)) { Texture t = m.GetTexture(p); if (!IsNull(t)) return t; } } catch { }
            }
            return null;
        }

        private static void SetTex(Material m, Texture? tex, params string[] props)
        {
            if (IsNull(m) || IsNull(tex)) return;
            foreach (string p in props) { try { if (m.HasProperty(p)) m.SetTexture(p, tex); } catch { } }
        }

        // ----------------------------------------------------------------------------------------
        // Live-instance animator rebind (PROVEN: CharAnimatorRebindPatch). CharAnimator.Awake resets
        // .animator to its serialized value, so we re-find Medusa's Animator under the entity and re-wire.
        // ----------------------------------------------------------------------------------------
        internal static Animator? FindMedusaAnimator(Transform? root)
        {
            try
            {
                if ((UObject)root! == (UObject?)null) return null;
                // Prefer the child explicitly named Medusa_Visual.
                Transform? visual = root!.Find(VisualAssetName);
                if ((UObject)visual! != (UObject?)null)
                {
                    Animator a = visual!.GetComponentInChildren<Animator>(true);
                    if (!IsNull(a)) return a;
                }
                // Fallback: any Animator whose controller name looks like Medusa's.
                foreach (Animator a in root.GetComponentsInChildren<Animator>(true))
                {
                    if (IsNull(a)) continue;
                    try
                    {
                        var c = a.runtimeAnimatorController;
                        if (!IsNull(c) && c.name != null && c.name.IndexOf("Medusa", StringComparison.OrdinalIgnoreCase) >= 0)
                            return a;
                    }
                    catch { }
                }
            }
            catch { }
            return null;
        }
    }
}
