# B4 — Skin / Material Binding Fallback (Medusa)

Session: `B4_skin_material_fallback` · READ-ONLY research · 2026-06-01

Scope: how Medusa's material/skin binds; where it reuses the Kitsu DefaultSkin; whether
the wrong/placeholder skin causes the "Kitsu look"; what the server `slot 15 -> 300018`
fallback means. Cross-checked `docs\MEDUSA_SERVER_INTEGRATION.md` + `CustomMatchServer`.

Primary source: `C:\Users\Administrator\Downloads\BAPBAPModdingAPI\medusa-mod\MedusaMod.cs`
(decompiled, IL2CPP). Line numbers are exact from this file unless noted.

---

## 1. How Medusa's MATCH body material/skin binds (the real 3D visual)

Medusa's in-match body is NOT the Kitsu mesh. The mod grafts the real Medusa bundle
visual (`Medusa_Visual`, const at line 1267) onto the cloned base prefab, then binds the
game's `CharMaterial` component to it.

- `BindMedusaVisualToCharMaterial(GameObject root, GameObject visual, string source)`
  — **MedusaMod.cs:3914**. Finds `root.GetComponentInChildren<CharMaterial>(true)`,
  collects all `Renderer`s under `Medusa_Visual`, picks the first `SkinnedMeshRenderer`
  as primary, then rewrites the native skin binding fields:
  ```csharp
  componentInChildren.charRigObj = visual;
  componentInChildren.charAnimatedRoot = visual.transform;   // re-pointed to Animator root
  componentInChildren.charRenderer = val;                    // Medusa SMR
  componentInChildren.extraRenderers = val2;                 // remaining renderers
  componentInChildren.customVisRendererBounds = true; ...
  componentInChildren.ReInitializeMaterialWrappers();        // ~line 4001
  ```
  Idempotency is guarded by `_charMaterialBoundRoots` (instance-id set) +
  `IsCharMaterialBoundToVisual`.
- Comment at ~MedusaMod.cs:4008 explains a concrete failure mode: *"CharMaterial's
  overlay setup moves the custom Medusa SMR to layer 26 on live match spawn. That layer
  is not rendered by the normal gameplay camera"* → it then calls
  `ApplyCharacterRenderLayer` + `ForceMedusaCharMaterialVisible`.
- `ForceMedusaCharMaterialVisible(...)` — **MedusaMod.cs:4026**. Forces
  `rendererIsActive=true, alpha=1, isOpaque=true, isPartialHidden=false`, then
  `SetCharacterVisible(true) / SetCharRendererEnabled(true) / SetRendererEnabled(true) /
  SetRendererMaterialAlpha(1) / ForceAlphaLerpFinish() / RevealHiddenCharacter()`.
  Guarded by `_charMaterialVisibleRoots` + `NeedsCharMaterialVisibilityRepair`.
  → directly relevant to the cross-scope "transparency / visible-only-after-damage"
  symptoms (B-other): these are the exact fields the repair toggles.
- `IsCharMaterialBoundToVisual(...)` — **MedusaMod.cs:4171**. True only when
  `CharMaterial.charRenderer` transform is under `Medusa_Visual` (`IsUnderMedusaVisual`).
- `NeedsCharMaterialVisibilityRepair(...)` — **MedusaMod.cs:4197**. Triggers a re-repair
  when `!rendererIsActive || alpha < 0.99 || !isOpaque || isPartialHidden ||
  !IsCharMaterialBoundToVisual`.

### Body SHADER (toon) is lifted from the base = Kitsu
- `GraftMedusaVisual(GameObject clone)` — ~MedusaMod.cs:4836. Captures the toon template
  material from the cloned base prefab's first SMR:
  ```csharp
  _toonTemplateMaterial = sharedMaterial;            // MedusaMod.cs:4860
  _toonTemplateMaterialName = ((Object)sharedMaterial).name;   // :4861
  // log: "[Medusa] graft: captured native toon template ... shader='...'"
  ```
  Fallback capture also at MedusaMod.cs:5126-5128.
- The material-visibility pass re-shades Medusa's own SMR: it keeps Medusa's own albedo
  texture (reads `_MainTex/_BaseMap/_AlbedoTex/_AlbedoMap`, ~4716-4731) but, if Medusa's
  bundled shader is `Unlit/*` or `Standard`, swaps in the captured native toon material:
  ```csharp
  if (((Object)(object)_toonTemplateMaterial != (Object)null) && flag)   // MedusaMod.cs:4744
  { val3 = new Material(_toonTemplateMaterial); ((Object)val3).name = "Medusa_Material_NativeVisible"; }
  ...
  val.sharedMaterial = val3; val.material = val3;     // ~4796
  ```
  README confirms: *"her material re-shaded with the game's native toon shader
  `Custom/Toon/Toon_Character_Amplify`, lifted at runtime from a live native character's
  material (Kitsu) and re-applied with Medusa's own Albedo and Normal textures preserved"*
  (`medusa-mod\README.md:11-15`).

Net: when binding succeeds, the body = real Medusa mesh + Medusa textures + Kitsu's toon
shader. The body looks like Medusa, not Kitsu.

---

## 2. Where it reuses the Kitsu DefaultSkin (the "Kitsu look" source)

The base character is hard-preferenced to **Kitsu**, and the lobby/2D skin identity is
copied wholesale from it.

- `private const string BasePreference = "Kitsu";` — **MedusaMod.cs:1235**.
- `PickBase(...)` returns the roster entry named `"Kitsu"` first — **MedusaMod.cs:2570**
  (match check at :2575), else first non-null entry.
- `CloneConfig(b, charId)` builds the Medusa `CharacterConfiguration` from base `b` (Kitsu)
  — method at **MedusaMod.cs:2590**, called at **:2549**. It copies every 2D/UI asset and
  the skin:
  ```csharp
  smallSprite = b.smallSprite, IconSprite = b.IconSprite, LobbyBackground = b.LobbyBackground,
  FullSprite = b.FullSprite, StandingSprite = b.StandingSprite, CircleIcon = b.CircleIcon,
  SquareIcon = b.SquareIcon, SquareSmallIcon = b.SquareSmallIcon,
  DefaultSkin = b.DefaultSkin,                 // MedusaMod.cs:2641  <-- Kitsu's skin reused
  ability1..4 = MakeAbility(b.ability1..4, ...) // :2645-2648  <-- Kitsu kit, re-titled only
  ```
  Only colors/title keys are overridden (`MedusaColor`, `MEDUSA_AB_*`). The skin object,
  portraits, icons and ability prefabs remain Kitsu's.
- `DOCUMENTATION.md:46-49` states plainly: *"These are Kitsu's UI sprites, used as a
  placeholder so the grid entry renders."* and `DOCUMENTATION.md:17` marks the portrait as
  *"placeholder (Kitsu's)"*.

→ So the **lobby / character-select / locker** skin & portrait identity IS Kitsu by
construction. This is the "Kitsu look" in menus.

---

## 3. Does the wrong/placeholder skin cause the in-match Kitsu look?

Two distinct surfaces, two answers:

- **Menus/lobby/locker:** YES — by design (see §2). `DefaultSkin = b.DefaultSkin`
  (MedusaMod.cs:2641) + server slot-15 fallback (§4) mean the skin identity reads as
  Kitsu. This is cosmetic placeholder behaviour, not a bug.
- **In-match body:** The placeholder skin does NOT by itself force a Kitsu body — the
  bundle visual graft + `BindMedusaVisualToCharMaterial` override it. A Kitsu/Skinny body
  in-match appears only when that bind/graft FAILS and the base clone's own renderers stay
  visible. `docs\MEDUSA_SERVER_INTEGRATION.md` ("Root cause and final fix") documents the
  exact failure: the cloned prefab's Mirror `NetworkIdentity` carried `hasSpawned=True`,
  Mirror rejected it (`Char_Medusa(Clone) has already spawned`), and *"the local
  primary/auth character path fell back into Skinny/Kitsu state."* v1.6.24+ sanitizes the
  NetworkIdentity, assigns asset id `0x4D454455` ("MEDU"), and *"suppresses the base skin
  renderers after spawn"* (see `DisableBaseCharacterRenderers`, referenced ~MedusaMod.cs:5120).

→ The "Kitsu/Skinny" in-match body is a **fallback caused by spawn/bind failure**, not by
the skin id. The "Kitsu look" in menus is the **placeholder skin/sprite reuse**.

---

## 4. Meaning of server `skin slot 15 -> asset 300018`

- `CustomMatchServer\CustomServerOptions.cs:558-580` `DefaultSkinAssetIds[]`:
  ```csharp
  300018, // 0: Kitsu              (CustomServerOptions.cs:564)
  ...
  300021, // 6: Skinny             (:570)
  300018  // 15: Medusa fallback skin   (CustomServerOptions.cs:579)
  ```
  XML doc above the array (:558-561): *"Medusa currently reuses Kitsu's default skin id
  because the upstream Medusa asset drop contains no native 2D/skin asset entry for this
  older build."* Served via `GetDefaultSkinAssetId(charId)` (~:583).
- `docs\MEDUSA_SERVER_INTEGRATION.md`: *"Loadout skin slot 15 uses fallback skin asset
  300018 because this ripped BR build has no native Medusa skin UI asset."* Verified there
  via `/api/load` -> `loadout.skins[15]=300018`.

Meaning: **300018 is literally Kitsu's default skin id (slot 0).** Slot 15 returns it as a
placeholder so loadout/owned-skin/locker logic has a valid asset id for Medusa. It is NOT
a Medusa skin and provides no Medusa visual; the real Medusa look comes only from the
client bundle graft, not from this id.

---

## 5. Separate but related: the "green lines" FX path (cross-scope note)

Not the body skin, but found in B4's material code and explains part of the "green lines"
report:
- `ApplyMaterial(GameObject, Color, bool transparent)` — **MedusaMod.cs:2385**;
  `component.material = MakeFxMaterial(color, transparent)` — **:2391**. `MakeFxMaterial`
  (:2395-2470) builds a primitive material on `Sprites/Default` → `Unlit/Color` → `Standard`
  → `Hidden/InternalErrorShader`, tinted with the passed color and alpha-blended.
- The color passed for Medusa FX is the green `MedusaColor = (0.45, 0.85, 0.35)`
  (**MedusaMod.cs:1239**) / `MedusaVenomFxColor (0.18,1,0.32)` (:1247). These are
  flat-shaded quads/cylinders → the "green line/quad" look.
- Abilities themselves are Kitsu clones (`MakeAbility(b.abilityN, ...)`, §2;
  `README.md:35-38`, `DOCUMENTATION.md:21`), so the actual cast FX are Kitsu's prefab FX +
  the mod's green primitive overlays — i.e. "green lines + Kitsu FX". The real bundle VFX
  (`VFX_Medusa_Poison_*`, consts MedusaMod.cs:1271-1290) are only used when the mod resolves
  them; otherwise it falls back to these green primitives. (Full FX-resolution path is
  another agent's scope.)

---

## Hypotheses + confidence (B4)

| # | Hypothesis | Confidence |
|---|---|---|
| H1 | Lobby/locker/portrait "Kitsu look" is intentional placeholder reuse: `CloneConfig` copies all Kitsu sprites + `DefaultSkin = b.DefaultSkin` (MedusaMod.cs:2641) and server slot-15 -> 300018 = Kitsu's id (CustomServerOptions.cs:564,579). | **HIGH** — code + 2 docs agree |
| H2 | In-match Kitsu/**Skinny** body is a FALLBACK from spawn/bind failure (Mirror `already spawned` → base renderers not suppressed), NOT from the skin id. Real Medusa body comes from bundle graft + `BindMedusaVisualToCharMaterial` (3914) + toon-shader lift from Kitsu (4860). | **HIGH** — MEDUSA_SERVER_INTEGRATION root-cause + bind code |
| H3 | 300018 is a non-Medusa placeholder skin id (== Kitsu slot 0) to satisfy loadout/owned logic; it contributes the menu Kitsu identity but does not drive the in-match model. | **HIGH** |
| H4 | Transparency / visible-only-after-damage stems from `CharMaterial` alpha/opaque/layer state that `ForceMedusaCharMaterialVisible`(4026)+`NeedsCharMaterialVisibilityRepair`(4197) exist to repair; if repair misses a frame the body stays hidden/transparent until a state change (e.g. damage) re-evaluates it. Layer-26 comment (4008) is corroborating evidence. | **MEDIUM** (B4 sees the repair surface; full runtime trigger is another scope) |
| H5 | "Green lines" = mod's own `MakeFxMaterial` green primitives (2385-2470, color 1239/1247) layered on Kitsu-clone ability FX, used when native `VFX_Medusa_Poison_*` aren't resolved. | **MEDIUM-HIGH** (color/material path confirmed here; FX-resolution gating is cross-scope) |

## Key file:line index
- MedusaMod.cs:1235 `BasePreference="Kitsu"` · :1239 `MedusaColor` green · :1267 `Medusa_Visual`
- MedusaMod.cs:2385 `ApplyMaterial` · :2391 `.material=MakeFxMaterial` · :2395-2470 `MakeFxMaterial`
- MedusaMod.cs:2549 CloneConfig call · :2570/:2575 `PickBase`→Kitsu · :2590 CloneConfig · :2641 `DefaultSkin=b.DefaultSkin`
- MedusaMod.cs:3914 BindMedusaVisualToCharMaterial · :4008 layer-26 comment · :4026 ForceMedusaCharMaterialVisible
- MedusaMod.cs:4171 IsCharMaterialBoundToVisual · :4197 NeedsCharMaterialVisibilityRepair
- MedusaMod.cs:4744 toon-template swap · :4836 GraftMedusaVisual · :4860-4861 capture toon template · :5126-5128 fallback capture
- CustomServerOptions.cs:558-583 DefaultSkinAssetIds (564 Kitsu=300018, 579 Medusa=300018), GetDefaultSkinAssetId
- docs\MEDUSA_SERVER_INTEGRATION.md: slot15->300018 fallback; root cause `already spawned`→"Skinny/Kitsu state"
- README.md:11-15 toon re-shade from Kitsu; :35-38 Kitsu-clone abilities · DOCUMENTATION.md:17,21,46-49 placeholder Kitsu sprites
