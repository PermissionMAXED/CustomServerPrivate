# A2 — MedusaMod Registration & Identity (READ-ONLY findings)

Scope: How `MedusaMod` registers identity (charId, MEDU asset id, roster, portrait/icon
sprites, where custom artwork + XP would inject). No code changed. Single source file:
`C:\Users\Administrator\Downloads\BAPBAPModdingAPI\medusa-mod\MedusaMod.cs` (+ README.md,
DOCUMENTATION.md in the same folder).

---

## 1. charId = 15 — every reference (file:line)

`MedusaMod.cs`:

- **1387** `private const int ExpectedMedusaCharId = 15;` — the hard-coded expected id.
- **1497** `public int MedusaCharId { get; private set; } = -1;` — runtime field, default **-1**
  (i.e. unknown until discovered/assigned at lobby load).
- **2531** `MedusaCharId = ((...)characters)[i].charId;` — inside `TryRegisterMedusa`, when a
  roster entry literally named `"Medusa"` already exists, the mod **adopts that entry's
  charId** rather than forcing 15.
- **2548** `int medusaCharId = MedusaCharId;` then **2550-2551** append using it.
- **2940 / 2963** `MedusaCharId = num;` / `MedusaCharId = num3;` — set inside
  `EnsureMedusaPrefabRegistered` / `RegisterPrefab` from the chosen prefab slot.
- **6122-6130** `private static int CurrentMedusaId()` → `_instance?.MedusaCharId ?? -1`; **if
  `< 0` it returns the literal `15`** as fallback. This is the de-facto "15" used by every
  spawn/prefab call (lines 717, 726, 754, 764, 774, 785, 6013, etc.).

Evidence quote (CurrentMedusaId, 6122):
```csharp
private static int CurrentMedusaId()
{
    int num = _instance?.MedusaCharId ?? (-1);
    if (num < 0) { return 15; }
    return num;
}
```
DOCUMENTATION.md §2: "own CharId 15 … roster grows 15 → 16, `/medusa status` reports
`registered=True charId=15`."

> Note: charId 15 is NOT written into `CloneConfig` as a constant — `CloneConfig(b, charId)`
> takes `charId` as a parameter (2590) and sets `charId = charId` (2627). The value flows from
> `MedusaCharId` / `CurrentMedusaId()`. So if the live roster's actual next free slot differs
> from 15, identity can drift (see Hypotheses).

## 2. MEDU asset id 0x4D454455 — every reference

- **1237** `private const uint MedusaMirrorAssetId = 1296385109u;`
  `1296385109 == 0x4D454455 == ASCII "MEDU"` (0x4D='M',0x45='E',0x44='D',0x55='U'). Confirmed.
- **3151** `private bool TryConfigureMirrorPrefab(GameObject? prefab, string source, GameNetworkManager? gnm)`.
- **3186** `val._assetId = 1296385109u;` — overwrites the Mirror NetworkIdentity asset id.
- **3189** `NetworkClient.RegisterPrefab(prefab, 1296385109u);`
- **3210** `private void SanitizeMirrorIdentities(GameObject prefab, string source)` — zeroes
  `sceneId/_netId/hasSpawned/_SpawnedFromInstantiate/destroyCalled/serverOnly/conn*` then
  `InitializeNetworkBehaviours()` before the asset-id is applied (called at 3185).
- **3093** `private int RegisterPrefab(int baseCharId)` → clones a base network prefab, then
  calls `TryConfigureMirrorPrefab` (3131) + `TryAddSpawnPrefab` (3140).
- **1752 / 3193 / 3199** log lines render it as `0x{1296385109u:X8}` (= `0x4D454455`).

The const literal `1296385109u` is used directly everywhere; there is no `0x4D454455` token in
source (it only appears as the formatted log output).

## 3. Roster append (scope 5747-5804) — every roster call

- **2550** `val._characters = Append(val._characters, item);`
- **2551** `val._lobbyCharacters = AppendLobby(val, item);`
- **5747** `private static Il2CppReferenceArray<CharacterConfiguration> Append(arr, item)` —
  allocates `len+1`, copies, appends `item` at the end.
- **5759** `private Il2CppReferenceArray<CharacterConfiguration> AppendLobby(cfg, item)` →
  `Append(cfg._lobbyCharacters, item)`.
- **~5778** `MakeRosterAvailable(cfg)` — builds an `int[]` of every entry's `charId` and calls
  `cfg.UpdateAvailableCharacterList(val)`, logging `made N characters available in lobby
  (incl. Medusa)`. Called from `TryRegisterMedusa` at 2552 and the already-present path 2535.

So registration = clone Kitsu config (2548-2549) → append to `_characters` + `_lobbyCharacters`
(2550-2551) → `UpdateAvailableCharacterList` (MakeRosterAvailable) → register network prefab in
`characterPrefabsByCharId[charId]`.

## 4. Portrait / icon sprites — every assignment (CloneConfig, 2590-2649)

All ten UI fields are copied verbatim from the base char `b` (no custom art):

| Field | line | source |
|---|---|---|
| `smallSprite` | **2632** | `b.smallSprite` |
| `IconSprite` | **2633** | `b.IconSprite` |
| `LobbyBackground` | **2634** | `b.LobbyBackground` |
| `FullSprite` | **2635** | `b.FullSprite` |
| `StandingSprite` | **2636** | `b.StandingSprite` |
| `CircleIcon` | **2637** | `b.CircleIcon` |
| `SquareIcon` | **2638** | `b.SquareIcon` |
| `SquareSmallIcon` | **2639** | `b.SquareSmallIcon` |
| `gameStatsLobbySpriteModifier` | **2640** | `b.gameStatsLobbySpriteModifier` |
| `DefaultSkin` | **2641** | `b.DefaultSkin` |

Which base char's sprites are reused → **Kitsu**:
- **2571** `PickBase(roster)` returns the entry named `"Kitsu"` first (2575-2578), else first
  non-null, else `[0]`.
- **~1232** `private const string BasePreference = "Kitsu";`
- Only color/text identity is overridden: `Color/UIAccentColor = MedusaColor` (green RGBA
  `0.45,0.85,0.35`, line 1239), `abilityIconColor = MedusaAbilityIconColor` (`0.3,0.95,0.42`,
  1241), `abilityBGColor` (1243), `titleTextColor` (1245). Name="Medusa" (2625),
  `descriptionTranslationKey="MEDUSA_DESC"` (2626).

DOCUMENTATION.md §3 quote: "`MedusaMod.CloneConfig()` reuses the base character's sprites …
These are **Kitsu's** UI sprites, used as a placeholder so the grid entry renders." and "the
AssetRipper export … contains only Medusa's **3D** assets … **no Medusa 2D UI sprites**."

## 5. Where the user's 2 Medusa artwork images inject — ANSWER: NOWHERE

There is **no image/sprite-loading code path anywhere in the mod** for UI portraits. Verified:
- A folder-wide search of `medusa-mod\**\*.cs` for `Sprite.Create | LoadImage | ImageConversion
  | LoadRawTextureData | new Texture2D | .png | .jpg | artwork | portrait` returns **0** hits in
  `MedusaMod.cs` and the only hits anywhere are **3D model textures** in
  `medusa-mod\backport\MedusaBundleProject\Assets\Editor\BuildMedusaBundle.cs:28-29`
  (`Medusa_Tex_Albedo_1024.png`, `Medusa_Tex_Normal_1024.png`) — these feed the **3D mesh
  material**, not any UI sprite.
- In `MedusaMod.cs` the only sprite-field writes are the ten `= b.*` copies above (2632-2641).
  No `IconSprite =`/`FullSprite =`/etc. is ever set from a loaded `Sprite`/`Texture2D`.

Therefore:
- **Lobby vertical card** → renders Kitsu's `FullSprite` / `StandingSprite` / `LobbyBackground`
  (2634-2636). No injection point for a custom card image exists.
- **Char-select large image** → Kitsu's `FullSprite`/`StandingSprite` (2635-2636) +
  `IconSprite`/`SquareIcon`/`CircleIcon` (2633,2637,2638) for the grid tile. No custom path.
- The user's 2 artwork PNGs are **not referenced, not bundled, and not loaded**. To use them a
  new path would have to (a) ship them in `medusa.bundle` or load via `ImageConversion.LoadImage`
  into a `Texture2D`→`Sprite.Create`, then (b) assign into those CloneConfig fields. None of that
  exists today (DOCUMENTATION.md §3 "To give her a native icon (future work)" confirms it is
  unimplemented).

## 6. XP / mastery / progression path — ANSWER: none in code

- No charId-15 mastery listing, XP store, or progression write exists in `MedusaMod.cs`.
- DOCUMENTATION.md §4 (quote): "There is no XP/mastery/progression path for Medusa, and a client
  mod cannot create a truly native one. … `CharMasteryPreviewResponse` (+ `CharPass`,`PassLevel`,
  `Listing`,`Asset`) are backend response types … `UILobbyCharacterMasteryRewardEntry`,
  `UILobbyBattlePassTabPage` only display what the backend returns." README FAQ: "No, and a
  client mod can't add a native one."
- Consequence: with no backend listing for charId 15, the mastery/XP UI for Medusa has nothing
  to display (or falls back to base/empty). There is no "XP path" location to inject artwork into.

## 7. Identity-adjacent note on green-line / Kitsu-FX abilities (cross-ref to A3/A4 scope)

Within identity cloning: `CloneConfig` (2645-2648) sets `ability1..4 = MakeAbility(b.abilityN,
…keys…)`. `MakeAbility` (2652-2658) only rewrites the three localization keys and **returns the
same `src` AbilityData** — i.e. abilities are **Kitsu's data verbatim**, retitled. There is no
Medusa ability SO/FSM/VFX in code. The green tint comes from `MedusaColor` / `MedusaAbilityIconColor`
(green) applied to UI accent + the ability-element palette (`_abilityElementPaletteLogCount`, log
at 1752). DOCUMENTATION.md §5 / README confirm slots 0-2 = "Kitsu-clone (themed)". This is the
registration-side root of "green lines + Kitsu FX". (Real Medusa VFX existence in LatestBuild is
A3's scope.)

---

## Hypotheses + confidence

1. **Kitsu placeholder identity is by-design, not a bug.** `PickBase` prefers "Kitsu" (2571,
   BasePreference 1232) and `CloneConfig` copies all 10 sprite fields + all 4 abilities from it.
   This is the single root cause of "abilities/FX/icon look like Kitsu". **Confidence: HIGH**
   (direct code + matching DOCUMENTATION/README).
2. **User's 2 artwork images cannot appear** under the current build — there is literally no
   loader or assignment that consumes them. **Confidence: HIGH** (folder-wide search = 0 UI image
   loads; only 3D-texture PNGs in BuildMedusaBundle.cs).
3. **charId is not pinned to 15 in the clone path.** It flows from `MedusaCharId` (default -1) →
   `CurrentMedusaId()` fallback 15. If a live roster already differs or a different free slot is
   used at 2940/2963, the effective id can diverge from 15, which could mis-key server-side
   recognition (Tier C "server doesn't know CharId 15", DOCUMENTATION §5). **Confidence: MEDIUM**
   (logic is clear; whether it actually drifts live is unverified here).
4. **No mastery/XP injection point exists**, so any XP feature request is backend work, not a
   mod-side edit. **Confidence: HIGH** (code absence + explicit DOCUMENTATION §4).
5. **MEDU (0x4D454455) network asset-id is correct and unique** for the mirror prefab; identity
   sanitize+re-register (3151/3210/3186/3189) is sound for spawn registration. Any spawn-side
   transparency/invisibility issues are unlikely to originate in this identity code (defer to A4).
   **Confidence: MEDIUM** (registration looks correct; runtime spawn behavior not validated here).

## Out-of-scope items (other agents)
Items (2) real Medusa VFX in LatestBuild, (4) spawn/transparency/FPS/invisible-enemy/red-outline
remnants, (5) AMP DLL persistence, (6) queue timing — not investigated under A2; only the
registration-identity touch-points above were examined.
