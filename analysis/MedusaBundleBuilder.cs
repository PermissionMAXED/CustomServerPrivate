// DRAFT — investigation artifact. DO NOT yet copy into the Unity project.
// Target location when ready: <ExportedProject>\Assets\Editor\MedusaBundleBuilder.cs
// Editor: Unity 2022.3.38f1 (matches exported project and live BR build).
//
// Headless invocation:
//   "C:\Program Files\Unity\Hub\Editor\2022.3.38f1\Editor\Unity.exe" ^
//     -batchmode -nographics -quit ^
//     -projectPath "C:\Users\Administrator\Downloads\neueBapbap\GameCode\ExportedProject" ^
//     -executeMethod MedusaBundleBuilder.Build ^
//     -buildOut "C:\Users\Administrator\Downloads\CustomServer\artifacts\medusa-bundle" ^
//     -logFile  "C:\Users\Administrator\Downloads\CustomServer\logs\medusa-bundle-build.log"
//
// IMPORTANT (see report section 5.5): the most reliable flow deletes the 2,715 decompiled
// scripts in Assets\Scripts\Assembly-CSharp ON DISK in a project COPY *before* launching
// Unity, so -executeMethod is guaranteed to run (a project with compile errors enters Safe
// Mode and never reaches this method). The on-import deletion below is a best-effort
// fallback only.

#if UNITY_EDITOR
using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public static class MedusaBundleBuilder
{
    private const string BundleName = "medusa";

    // Assets to tag for the bundle. The dependency walker pulls in meshes, materials,
    // shaders, avatar, clips, textures referenced by these, so listing the prefab +
    // controller is usually sufficient. Extras are listed for robustness.
    private static readonly string[] MedusaAssetPaths = new[]
    {
        "Assets/GameObject/Medusa.prefab",
        "Assets/AnimatorController/Medusa.controller",
        "Assets/Avatar/Medusa_Anims_v03Avatar.asset",
        "Assets/Material/Medusa_Material.mat",
        // VFX / ability prefabs:
        "Assets/GameObject/VFX_Medusa_Poison_Wall.prefab",
        "Assets/GameObject/VFX_Medusa_Poison_Escape.prefab",
        "Assets/GameObject/VFX_Medusa_Poison_Hit.prefab",
        "Assets/GameObject/VFX_Medusa_Poison_Muzzle.prefab",
        "Assets/GameObject/VFX_Medusa_Poison_Puddle.prefab",
        "Assets/GameObject/VFX_Medusa_Poison_Trail.prefab",
        "Assets/GameObject/MedusaPuddleSpawner.prefab",
        "Assets/GameObject/Hitbox_MedusaPoisonProjectile.prefab",
        "Assets/GameObject/Hitbox_MedusaPoisonPuddle.prefab",
        "Assets/GameObject/Hitbox_MedusaWallPoison.prefab",
        "Assets/GameObject/Hitbox_MedusaWallBoxDpsPoison.prefab",
    };

    // Optional: also sweep every Assets/AnimationClip/Medusa_*.anim by glob.
    private static string[] MedusaAnimClips()
    {
        var dir = Path.Combine(Application.dataPath, "AnimationClip");
        if (!Directory.Exists(dir)) return Array.Empty<string>();
        return Directory.GetFiles(dir, "Medusa_*.anim", SearchOption.TopDirectoryOnly)
            .Select(p => "Assets/AnimationClip/" + Path.GetFileName(p))
            .ToArray();
    }

    public static void Build()
    {
        try
        {
            string outDir = GetArg("-buildOut")
                ?? Path.Combine(Directory.GetCurrentDirectory(), "MedusaBundleOut");
            Directory.CreateDirectory(outDir);

            Log($"Output dir: {outDir}");

            // Best-effort fallback: drop decompiled scripts so missing-script components
            // don't error. Prefer doing this on disk BEFORE launch (report 5.5).
            // (Left commented; deleting Assets in -executeMethod after import is risky.)
            // TryNeutralizeDecompiledScripts();

            int tagged = 0;
            var paths = MedusaAssetPaths.Concat(MedusaAnimClips()).Distinct();
            foreach (var path in paths)
            {
                if (string.IsNullOrEmpty(AssetDatabase.AssetPathToGUID(path)))
                {
                    Log($"  (skip, not found) {path}");
                    continue;
                }
                var importer = AssetImporter.GetAtPath(path);
                if (importer == null)
                {
                    Log($"  (skip, no importer) {path}");
                    continue;
                }
                importer.assetBundleName = BundleName;
                importer.assetBundleVariant = string.Empty;
                tagged++;
                Log($"  tagged -> {BundleName}: {path}");
            }
            Log($"Tagged {tagged} asset(s) into bundle '{BundleName}'.");

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            var manifest = BuildPipeline.BuildAssetBundles(
                outDir,
                BuildAssetBundleOptions.ChunkBasedCompression,
                BuildTarget.StandaloneWindows);

            if (manifest == null)
            {
                Console.Error.WriteLine("[MedusaBundleBuilder] BuildAssetBundles returned null (build failed).");
                EditorApplication.Exit(2);
                return;
            }

            foreach (var b in manifest.GetAllAssetBundles())
                Log($"Built bundle: {b}");

            var produced = Path.Combine(outDir, BundleName);
            Log(File.Exists(produced)
                ? $"SUCCESS: {produced} ({new FileInfo(produced).Length} bytes)"
                : $"WARNING: expected bundle file not found at {produced}");

            EditorApplication.Exit(0);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("[MedusaBundleBuilder] EXCEPTION: " + ex);
            EditorApplication.Exit(3);
        }
    }

    // Fallback helper (see caveat above). Safer to delete on disk pre-launch.
    private static void TryNeutralizeDecompiledScripts()
    {
        string scripts = Path.Combine(Application.dataPath, "Scripts", "Assembly-CSharp");
        if (Directory.Exists(scripts))
        {
            Log($"Deleting decompiled scripts: {scripts}");
            FileUtil.DeleteFileOrDirectory(scripts);
            FileUtil.DeleteFileOrDirectory(scripts + ".meta");
            AssetDatabase.Refresh();
        }
    }

    private static string GetArg(string name)
    {
        var args = Environment.GetCommandLineArgs();
        for (int i = 0; i < args.Length - 1; i++)
            if (string.Equals(args[i], name, StringComparison.OrdinalIgnoreCase))
                return args[i + 1];
        return null;
    }

    private static void Log(string msg) => Debug.Log("[MedusaBundleBuilder] " + msg);
}
#endif
