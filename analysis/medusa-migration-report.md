# Medusa -> Generic Config-Driven Migration Report

Status: COMPLETE — builds with 0 errors, DLL deployed.

## Summary
BAPCustomChars is now fully config-driven. Every character-specific VALUE is read from the
active `CustomCharDefinition` (loaded from `UserData\CustomChars\*.json`). Medusa is now just
`medusa.json`. All `CustomCharDefinition` field defaults remain the proven Medusa values, so a
minimal/old config (or no JSON at all) still behaves exactly like Medusa.

The proven pipeline — Mirror registration, visual graft (`GraftMedusaVisual` etc.),
camera/visibility repair, despawn guards, and the headless-safe `CanSpawnClientFx()` gating —
was left byte-for-byte intact. Only char-specific values and name-string matching were
parameterized. `MirrorAssetId` handling (charId 15 / 0x4D454455 custom-slot rule) is unchanged.

## Build / Deploy
- Build: `dotnet build BAPCustomChars.csproj -c Release` -> 0 errors (only pre-existing
  nullable CS86xx warnings).
- Deployed: `bin\Release\BAPCustomChars.dll` ->
  `C:\Users\Administrator\Downloads\CustomServer\Spiel\Battleroyalebuild\Mods\BAPCustomChars.dll`
- DLL SHA256: `7749EE3EF58DBA7FD383D78BBD62D850C6BE09382E27BBE1A56631418AD27C8D`
- DLL size: 242,176 bytes
- Running `bapbap` client processes were terminated before copy.

## New CustomCharDefinition schema (CustomCharFramework.cs)
Existing identity fields (unchanged defaults, already config-driven):
`charId(15)`, `name("Medusa")`, `displayName("MEDUSA")`, `subtitle`, `baseCharId(0)`,
`baseCharName("Kitsu")`, `bundleFileName("medusa.bundle")`, `visualPrefabName("Medusa_Visual")`,
`mirrorAssetId(1296385109)`, `enabled`, `abilities`.

New fields (all optional; defaults = proven Medusa values):
| JSON key | Type | Default (Medusa) | Purpose |
|---|---|---|---|
| `abilityHitboxes` | string[] | 4 Medusa poison hitboxes (slots 0-3) | Phase-2 ability->hitbox wiring. Empty `[]` => auto-discover `Hitbox_<Name>*` from the bundle. |
| `extraSpawnerHitboxes` | string[] | `["MedusaPuddleSpawner"]` | Extra presentation prefab(s) spawned alongside slot 1. |
| `statusOnHit` | string[] | `["poison","petrify"]` | Phase-3 on-hit statuses applied by `HitboxBase.OnHitSuccess`. |
| `charDescription` | string | Medusa lore string | `MEDUSA_DESC` phrase value. |
| `abilityTitles` | string[] | `["Serpent Bolt","Venom Spit","Slither","Petrifying Gaze"]` | Ability titles by slot. |
| `abilityDescriptionsShort` | string[] | Medusa short descs | Short tooltip text by slot. |
| `abilityDescriptions` | string[] | Medusa long descs | Long tooltip text by slot. |
| `abilityPaletteHex` | string[] | 7 Medusa colours (`#RRGGBB`/`#RRGGBBAA`) | UI/FX palette: [0]icon [1]title [2]bg [3]char-tint [4]venom-fx [5]venom-puddle [6]petrify-fx. |

Derived: `HasAbilityContent => AbilityTitles?.Length > 0`. Used to gate cosmetic overrides so
Medusa's text/colours are NOT applied to a char that does not declare its own.

Loader (`ParseFile`) parses each new key with case-insensitive lookup. `GetStrArray` semantics:
key absent => Medusa default; explicit `[]` => empty (skip). This reconciles the hard constraint
("defaults = Medusa for minimal/old config") with item-4's "omit => skip for another char"
(another char declares `[]` explicitly, as blitz.json/eve.json now do).

## Changes by area (MedusaMod.cs)

### 1. Identity / spawn-detection (the "worldMedusa=<null>" bug)
Detection was already largely charId/clone-name driven via `ActiveDef`:
- `IsMedusaId` -> `charId == ActiveDef.CharId` (`ExpectedMedusaCharId`).
- `ObjectRootNameLooksLikeMedusa` matches `ActiveDef.Name`, `Char_<Name>`, `<Name>(Clone)`,
  `Char_<Name>(Clone)`, and `ActiveDef.VisualPrefabName`.
- `LooksLikeMedusaEntity`, `LooksLikeMedusaObject`, `HasMedusaVisualUnder`,
  `IsLikelyForeignBotProxyMedusaEntity`, `LocalPlayerIsMedusa`, `CurrentMedusaId`,
  `EnsureLiveMedusaEntity`, and the delayed live-refresh all key off `IsMedusaId` /
  `ActiveDef.Name`.
- The `LogLiveLocalDiagnostics` "live local diag ready" marker fires when local/localPrimary/
  auth charId all equal `ActiveDef.CharId`, and `worldMedusa` is set from any entity whose
  charId matches the active def. With the active def now being whatever is enabled (e.g. Blitz
  charId 15), the SAME `live local diag ready` marker text fires for ANY active char. The marker
  string is preserved exactly for external scripts.
- Remaining literal cleaned up: the bundle SkinnedMeshRenderer/transform name probe `"MedusaBase"`
  is now `(MedusaName + "Base")` (Medusa default => `"MedusaBase"`, identical behaviour).

### 2. Ability -> hitbox wiring (Phase 2)
- Removed hardcoded consts `HitboxProjectileName/PuddleName/WallName/WallBoxDpsName/PuddleSpawnerName`
  and the `NativeHitboxNames` literal array.
- They are now properties: `HitboxForSlot(n)` reads `ActiveDef.AbilityHitboxes[n]`,
  `PuddleSpawnerName` reads `ActiveDef.ExtraSpawnerHitboxes[0]`, and `NativeHitboxNames`
  is the deduped union of both arrays.
- The slot cast switch in `TrySpawnNativeMedusaCastFx` is unchanged in structure; it just reads
  the new properties (slot 0 projectile, slot 1 puddle + spawner, slot 2 wall, slot 3 DPS field).
- `SpawnNativeMedusaHitbox` skips quietly when a slot name is empty (so content-less chars cause
  no warnings).
- `LoadNativeMedusaVfxPrefabs`: when `AbilityHitboxes` is empty, it calls new
  `AutoDiscoverHitboxNames(assetNames)` which scans the loaded bundle for `Hitbox_<Name>*`
  prefab asset names. medusa.json declares her exact 4 hitboxes + puddle spawner, so her load
  list is identical to before.

### 3. On-hit status (Phase 3)
- `HitboxDoEntityHitPetrifyPatch.Postfix`: petrify branch now gated by `DefWantsStatus("petrify")`,
  poison branch by `DefWantsStatus("poison")`. `DefWantsStatus` reads `ActiveDef.StatusOnHit`.
- medusa.json declares `["poison","petrify"]` => identical petrify-on-ult / poison-on-slots-0/1
  behaviour. A char with `[]` applies no statuses. Slot-detection (`GetMedusaAbilitySlot`) and the
  petrify/poison SO resolution + durations (2.5s / 3s) are unchanged.

### 4. Ability content (titles/descriptions/palette/phrases)
- The static `MedusaPhrases` dictionary is replaced by a per-active-def cache built by
  `BuildPhrases(def)` from `ActiveDef.Name`, `CharDescription`, `AbilityTitles`,
  `AbilityDescriptionsShort`, `AbilityDescriptions`. The internal phrase KEYS (`MEDUSA_AB_*`,
  via the existing `K_*` consts) are kept as an internal key namespace.
- The palette `Color` fields (`MedusaColor`, `MedusaAbilityIconColor`, `MedusaAbilityBgColor`,
  `MedusaTitleTextColor`, `MedusaVenomFxColor`, `MedusaVenomPuddleColor`, `MedusaPetrifyFxColor`)
  are now properties reading `ActiveDef.AbilityPaletteHex` via `PaletteColor(index, fallback)` +
  new `TryParseHexColor`. Fallbacks equal the original Medusa RGBA, so Medusa is identical.
- Cosmetic overrides are gated on `ActiveDef.HasAbilityContent` so they are skipped for a char
  that declares no content (do NOT apply Medusa's text/colours to another char):
  `IsMedusaAbilityText`, both `ApplyMedusaAbilityRuntimeUi` overloads,
  `OverrideMedusaAbilityTooltipText`, `ApplyMedusaAbilityElementPalette`, and the
  `UIAbilityElement.LoadIcon(CharacterConfiguration)` palette patch (now also requires
  `ActiveDef.HasAbilityContent`).
- medusa.json carries Medusa's exact strings and the 7 palette colours.

### 5. Log prefix
- Added `internal static string LogTag => "[" + ActiveDef.Name + "]";`.
- All 281 `[Medusa]` log tags in MedusaMod.cs were rewritten to `{LogTag}` (interpolated).
  MedusaMelon.cs (7) and PrematchMedusaClickProxy.cs (5) now use `{MedusaMod.LogTag}`.
  Medusa default => `[Medusa]`; any other active char => `[<Name>]`.

## How Medusa behaviour is preserved exactly
- Every new `CustomCharDefinition` field defaults to the proven Medusa value, and medusa.json
  re-declares them explicitly. So with Medusa active: same charId, assetId, bundle, visual,
  same 5 poison hitbox prefabs mapped to the same slots, same poison+petrify on-hit, same
  ability titles/descriptions/tooltips, same green palette, same `[Medusa]` logs.
- No proven structural code (Mirror prefab registration, visual graft, camera/visibility repair,
  despawn guards, headless `CanSpawnClientFx()` gating, MirrorAssetId/custom-slot rule) was
  changed — only the values those code paths consume.

## What is now generic
- Identity/detection (by CharId + `Char_<Name>(Clone)` + Name), ability->hitbox map (config or
  auto-discovered), on-hit statuses, ability cosmetic content + palette, and the log tag.
- A new character = one JSON file. Set `enabled: true` on exactly one definition.

## Config files
- `medusa.json`: `enabled: true`, full content (charId 15, assetId 1296385109, hitbox map,
  statuses, ability content, palette).
- `blitz.json`: `enabled: false`, `abilityHitboxes: []` (auto-discover later) + all cosmetic
  arrays `[]` (so Blitz never inherits Medusa text/colours when enabled).
- `eve.json`: `enabled: false`, same empty generic arrays.

## Remaining Medusa-specific code (not fully generalised) and reasons
1. `CleanMedusaTooltipText` slot `{1}`/`{2}` word substitutions ("poison damage", "knock-up",
   "2.5s petrify", ...) and the hardcoded fallback strings in `MedusaAbilityTooltipForSlot`.
   These are only reached when `ActiveDef.HasAbilityContent` is true (i.e. the active char
   declares its own ability text), so they never leak onto a content-less char. Fully
   table-izing the `{1}`/`{2}` token vocabulary into config was out of scope for a
   behaviour-preserving pass; left as a documented Medusa-flavoured fallback.
2. Internal phrase-key namespace `MEDUSA_*` (the `K_*` consts) and method names like
   `GraftMedusaVisual`, `EnsureLiveMedusaEntity`, `MedusaAbility*`, etc. are cosmetic
   identifiers only; they carry no char-specific runtime VALUE and were intentionally left
   (renaming 1000+ identifiers adds risk with no behavioural benefit, per the task note that
   method names "may stay").
3. The bundle VFX prefab name list `NativeVfxNames` (`VFX_Medusa_Poison_*`) and the per-slot VFX
   placement offsets in `TrySpawnNativeMedusaCastFx` remain Medusa-authored. These are pure
   client presentation for Medusa's poison casts; generalising them needs per-char VFX metadata
   that only matters once a second char ships its own VFX. Gated by `CanSpawnClientFx()` and only
   meaningful for the Medusa bundle, so they do not affect other chars' core spawn/animate path.
