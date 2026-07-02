# BAPCustomChars Framework Mod — Build Report

Track B: generalize the proven Medusa mod into a reusable, config-driven custom-character
framework (`BAPCustomChars`) with MINIMAL, TARGETED parameterization of the hardcoded inputs
plus a JSON definition loader. The ~14k lines of proven clone/graft/register/UI/headless
logic are left intact and remain functionally equivalent for Medusa.

## Status: COMPLETE — compiles cleanly (0 errors)

## Project location
`C:\Users\Administrator\Downloads\BAPBAPModdingAPI\bapcustomchars-mod`
(copied from `medusa-mod`; the original medusa-mod is untouched.)

## Files changed / added
- `BAPCustomChars.csproj` — new (renamed from `BAPBAP.Medusa.csproj`; `AssemblyName=BAPCustomChars`,
  same ModAPI/MelonLoader/IL2CPP references and output/deploy pattern; old csproj removed).
- `MedusaMelonAttributes.cs` — MelonInfo renamed to `BAPCustomChars` 1.0.0 (type ref unchanged).
- `MedusaMelon.cs` — loads the active definition at init (`CustomCharFramework.LoadActive`) and
  assigns `MedusaMod.ActiveDef` before registration.
- `CustomCharFramework.cs` — NEW: `CustomCharDefinition` data class + JSON loader.
- `MedusaMod.cs` — TARGETED parameterization (see below). Logic preserved.
- Removed: stale `MedusaMod.cs.*.pre-native.bak`.

## CustomCharDefinition (data class)
Fields: `CharId, Name, DisplayName, Subtitle, BaseCharId, BundleFileName, VisualPrefabName,
MirrorAssetId, Enabled, Abilities[]` + derived `BaseCharName` and `BundleRel` (= `Name\BundleFileName`).
Defaults equal the proven Medusa values, so a missing/partial JSON still reproduces Medusa exactly.

## Loader
`CustomCharFramework.LoadAll` scans `<game>\UserData\CustomChars\*.json` (also CWD and assembly-relative
fallbacks), parses each via Newtonsoft `JObject` with case-insensitive keys, and `LoadActive` picks the
first `enabled` definition (else first, else built-in Medusa default).

## Parameterized constants (were hardcoded) — now read from the active definition
| Was (literal/const) | Now |
|---|---|
| `MedusaName = "Medusa"` | `ActiveDef.Name` |
| `BasePreference = "Kitsu"` | `ActiveDef.BaseCharName` |
| `MedusaMirrorAssetId = 1296385109u` | `ActiveDef.MirrorAssetId` |
| `MedusaVisualName = "Medusa_Visual"` | `ActiveDef.VisualPrefabName` |
| `MedusaControllerName = "Medusa"` | `ActiveDef.Name` |
| `ExpectedMedusaCharId = 15` | `ActiveDef.CharId` |
| `BundleRel = "Medusa\medusa.bundle"` | `ActiveDef.BundleRel` |
| `BundleFileNameProp` (new) | `ActiveDef.BundleFileName` |

## Literal call-sites parameterized in MedusaMod.cs
- charId `15`: `FindMedusaPrefabIndex`, `RegisterPrefab` slot calc, `IsMedusaId`, `CurrentMedusaId`,
  env-var selected-id check → `ExpectedMedusaCharId`.
- name `"Medusa"`: existing-roster match, cloned `CharacterConfiguration.name`, `IsMedusaPrefab`
  name detect, registration log → `MedusaName`.
- base `"Kitsu"`: `PickBase` (now prefers `BaseCharId`, then `BasePreference` name), fallback
  base-prefab detect → `BasePreference`.
- mirror assetId `1296385109u` (all 4 sites incl. logs) → `MedusaMirrorAssetId`.
- visual `"Medusa_Visual"` (14 sites: load by-name/by-path/scan, graft name checks, runtime
  identity) → `MedusaVisualName`.
- bundle paths (`ResolveBundlePath` candidates + `UserData\<char>` folder + fallback) → `BundleRel`
  / `BundleFileNameProp` / `MedusaName`.
- cloned prefab GameObject name `"Char_Medusa"` → `"Char_" + MedusaName`.
- runtime name/VFX matchers (`LooksLikeMedusaName`, inherited-VFX detect) → `MedusaName` /
  `"Char_" + MedusaName` (kept `MedusaBase` alias literal — see TODO).
- `DisplayName` override → `MedusaName`.

## Headless safety
`CanSpawnClientFx()` gating and all proven headless paths are unchanged.

## JSON definition created (step 5)
`C:\Users\Administrator\Downloads\CustomServer\Spiel\Battleroyalebuild\UserData\CustomChars\medusa.json`
matches the proven Medusa values (charId 15, base 0/Kitsu, medusa.bundle, Medusa_Visual,
assetId 1296385109).

## Build (FINAL)
- Command: `dotnet build BAPCustomChars.csproj -c Release`
- Result: **0 errors** (1022 pre-existing CS8600 nullable warnings, identical class to the proven mod).
- Output DLL: `C:\Users\Administrator\Downloads\BAPBAPModdingAPI\bapcustomchars-mod\bin\Release\BAPCustomChars.dll` (235,520 bytes)
- SHA256: `42717381FCFDC184EE5DF186159B7F90A6E323ABA6C6416DA68642C1058DCDFE`
- Auto-deployed to: `...\Battleroyalebuild\Mods\BAPCustomChars.dll`

## Runtime readiness (verified in workspace game copy)
- Definition: `...\Battleroyalebuild\UserData\CustomChars\medusa.json` (present).
- Bundle: `...\Battleroyalebuild\UserData\Medusa\medusa.bundle` (3,494,760 bytes — the new real-asset
  bundle) already in place, matching `BundleRel` = `Medusa\medusa.bundle`.

## TODOs for full multi-char
- Ability text/keys (`MEDUSA_*` phrases, `descriptionTranslationKey`) and native ability behaviour
  (petrify/poison, VFX prefab names `VFX_Medusa_*`) remain Medusa-specific. A second char needs its
  own ability wiring; the `Abilities[]` field is reserved for this.
- `MedusaBase` / `(Clone)` alias literals kept as secondary robustness matchers; primary identity is
  now name-driven.
- `KnownBaseNames` map currently knows base charId 0 = Kitsu; add entries (or set `baseCharName` in
  JSON) for non-Kitsu bases. `PickBase` already prefers `BaseCharId` directly.
- The per-char AssetBundle build tool (Track A) is a separate deliverable.
