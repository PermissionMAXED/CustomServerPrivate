using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace NetworkedCustomChar
{
    /// <summary>
    /// M5 — config-driven character definitions. One JSON file per character lives in
    /// <c>&lt;game&gt;\UserData\CustomChars\*.json</c>. This generalizes the proven Medusa
    /// registration pipeline so any character is described purely by data; field defaults equal
    /// the proven Medusa values, so a missing/partial definition still produces Medusa.
    ///
    /// JSON keys (all optional, case-insensitive):
    ///   charId, name, displayName, baseCharId, assetId, graftVisual,
    ///   bundleFileName, visualPrefabName, enabled
    /// </summary>
    public static class CustomCharConfig
    {
        public static List<CustomCharDef> Loaded = new List<CustomCharDef>();

        /// <summary>Loads all defs; returns the active one (first Enabled, else first, else Medusa default).</summary>
        public static CustomCharDef LoadActive(Action<string>? log = null)
        {
            List<CustomCharDef> list = LoadAll(log);
            Loaded = list;
            CustomCharDef? active = null;
            foreach (CustomCharDef d in list) { if (d.Enabled) { active = d; break; } }
            if (active == null && list.Count > 0) active = list[0];
            if (active == null)
            {
                active = new CustomCharDef();
                log?.Invoke("[M5] no JSON definitions found; using built-in default (Medusa, charId 15).");
            }
            log?.Invoke($"[M5] active definition: name='{active.Name}' display='{active.DisplayName}' charId={active.CharId} " +
                        $"base={active.BaseCharId} bundle='{active.BundleRel}' visual='{active.VisualPrefabName}' " +
                        $"assetId=0x{active.AssetId:X8} graft={active.GraftVisual} (loaded {list.Count}).");
            return active;
        }

        public static List<CustomCharDef> LoadAll(Action<string>? log = null)
        {
            var result = new List<CustomCharDef>();
            var scanned = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (string dir in CandidateDirs())
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(dir) || !Directory.Exists(dir) || !scanned.Add(Path.GetFullPath(dir))) continue;
                    // Deterministic, peer-identical enumeration: Directory.GetFiles order is filesystem-
                    // dependent (differs between the Linux/Wine server and Windows clients). Sort by file
                    // name (ordinal) so the "first enabled" (and no-enabled first) selection is identical on
                    // every peer => Mirror registration parity is preserved even if >1 def is enabled.
                    string[] files = Directory.GetFiles(dir, "*.json");
                    Array.Sort(files, (a, b) => string.CompareOrdinal(Path.GetFileName(a), Path.GetFileName(b)));
                    foreach (string file in files)
                    {
                        try
                        {
                            CustomCharDef? def = ParseFile(file);
                            if (def != null)
                            {
                                result.Add(def);
                                log?.Invoke($"[M5] loaded definition '{def.Name}' (charId={def.CharId}, enabled={def.Enabled}) from {file}.");
                            }
                        }
                        catch (Exception ex) { log?.Invoke($"[M5] failed to parse {file}: {ex.Message}"); }
                    }
                    if (result.Count > 0) break;
                }
                catch (Exception ex) { log?.Invoke($"[M5] scan failed for {dir}: {ex.Message}"); }
            }
            return result;
        }

        private static IEnumerable<string> CandidateDirs()
        {
            yield return Path.Combine(AppContext.BaseDirectory, "UserData", "CustomChars");
            string cwd = SafeCwd();
            if (!string.IsNullOrWhiteSpace(cwd)) yield return Path.Combine(cwd, "UserData", "CustomChars");
            string? asmDir = SafeAsmDir();
            if (!string.IsNullOrWhiteSpace(asmDir))
                yield return Path.Combine(Path.GetFullPath(Path.Combine(asmDir!, "..")), "UserData", "CustomChars");
        }

        private static string SafeCwd() { try { return Directory.GetCurrentDirectory(); } catch { return string.Empty; } }
        private static string? SafeAsmDir() { try { return Path.GetDirectoryName(typeof(CustomCharConfig).Assembly.Location); } catch { return null; } }

        private static CustomCharDef? ParseFile(string path)
        {
            string text = File.ReadAllText(path);
            if (string.IsNullOrWhiteSpace(text)) return null;
            JObject jo = JObject.Parse(text);
            var map = new Dictionary<string, JToken>(StringComparer.OrdinalIgnoreCase);
            foreach (JProperty p in jo.Properties()) map[p.Name] = p.Value;

            var d = new CustomCharDef();
            d.CharId           = GetInt(map, "charId", d.CharId);
            d.Name             = GetStr(map, "name", d.Name);
            d.DisplayName      = GetStr(map, "displayName", string.IsNullOrEmpty(d.Name) ? d.DisplayName : d.Name.ToUpperInvariant());
            d.BaseCharId       = GetInt(map, "baseCharId", d.BaseCharId);
            // assetId: explicit "assetId" wins, else the new-mod deterministic scheme (0xB0B00F00 + charId).
            // The old "mirrorAssetId" key is intentionally ignored so the proven peer-identical id is kept.
            d.AssetId          = GetUInt(map, "assetId", 0xB0B00F00u + (uint)d.CharId);
            d.GraftVisual      = GetBool(map, "graftVisual", d.GraftVisual);
            d.BundleFileName   = GetStr(map, "bundleFileName", d.BundleFileName);
            d.VisualPrefabName = GetStr(map, "visualPrefabName", d.VisualPrefabName);
            d.Enabled          = GetBool(map, "enabled", d.Enabled);

            // M6 — config-driven ability kit. All optional; defaults are the proven Medusa values, so an
            // omitted key keeps the prior hardcoded behavior. "abilityVfx" accepts either a JSON array of
            // strings (each entry may itself be a ';'-separated list of prefab names) or per-slot arrays.
            d.AbilityHitboxes  = GetStrArray(map, "abilityHitboxes", d.AbilityHitboxes);
            d.AbilityDamage    = GetIntArray(map, "abilityDamage", d.AbilityDamage);
            d.StatusOnHit      = GetStrArray(map, "abilityStatusOnHit", GetStrArray(map, "statusPerSlot", d.StatusOnHit));
            d.StatusDuration   = GetFloatArray(map, "abilityStatusDuration", d.StatusDuration);
            d.AbilityVfx       = GetStrArray(map, "abilityVfx", d.AbilityVfx);
            d.AbilityAnimState = GetStrArray(map, "abilityAnimState", d.AbilityAnimState);
            return d;
        }

        private static int GetInt(Dictionary<string, JToken> m, string key, int def)
            => m.TryGetValue(key, out JToken? t) && t != null && t.Type != JTokenType.Null ? t.Value<int>() : def;

        private static uint GetUInt(Dictionary<string, JToken> m, string key, uint def)
        {
            if (m.TryGetValue(key, out JToken? t) && t != null && t.Type != JTokenType.Null)
            { try { return t.Value<uint>(); } catch { return def; } }
            return def;
        }

        private static bool GetBool(Dictionary<string, JToken> m, string key, bool def)
            => m.TryGetValue(key, out JToken? t) && t != null && t.Type != JTokenType.Null ? t.Value<bool>() : def;

        private static string GetStr(Dictionary<string, JToken> m, string key, string def)
        {
            if (m.TryGetValue(key, out JToken? t) && t != null && t.Type != JTokenType.Null)
            { string? v = t.Value<string>(); return v ?? def; }
            return def;
        }

        private static string[] GetStrArray(Dictionary<string, JToken> m, string key, string[] def)
        {
            if (m.TryGetValue(key, out JToken? t) && t is JArray arr && arr.Count > 0)
            {
                var list = new List<string>(arr.Count);
                foreach (JToken e in arr)
                {
                    if (e == null || e.Type == JTokenType.Null) { list.Add(""); continue; }
                    list.Add(e.Value<string>() ?? "");
                }
                return list.ToArray();
            }
            return def;
        }

        private static int[] GetIntArray(Dictionary<string, JToken> m, string key, int[] def)
        {
            if (m.TryGetValue(key, out JToken? t) && t is JArray arr && arr.Count > 0)
            {
                var list = new List<int>(arr.Count);
                foreach (JToken e in arr)
                { try { list.Add(e == null || e.Type == JTokenType.Null ? 0 : e.Value<int>()); } catch { list.Add(0); } }
                return list.ToArray();
            }
            return def;
        }

        private static float[] GetFloatArray(Dictionary<string, JToken> m, string key, float[] def)
        {
            if (m.TryGetValue(key, out JToken? t) && t is JArray arr && arr.Count > 0)
            {
                var list = new List<float>(arr.Count);
                foreach (JToken e in arr)
                { try { list.Add(e == null || e.Type == JTokenType.Null ? 0f : e.Value<float>()); } catch { list.Add(0f); } }
                return list.ToArray();
            }
            return def;
        }
    }
}
