# C2 — Material / Shader / Alpha Cause of Medusa Transparency

Agent: `C2_material_shader_alpha`  •  Scope: material/shader/alpha root cause of transparency (overlaps C1 render-layer).
Read-only. No source/build/deploy changes. Primary file:
`C:\Users\Administrator\Downloads\BAPBAPModdingAPI\medusa-mod\MedusaMod.cs`
Native evidence:
`...\BAPBAPModAPI\reverse-engineering\decompiled\Assembly-CSharp\Il2CppBAPBAP\Entities\CharMaterial.cs`
`...\BAPBAPModAPI\reverse-engineering\dumps\latest\dump.cs` (CharMaterial @ line 248006)
Bundle material: `...\medusa-mod\backport\MedusaBundleProject\Assets\Material\Medusa_Material.mat`

---

## 1. Map of material/shader/alpha handling (file:line)

| Concern | Location | Notes |
|---|---|---|
| FX fallback material (green lines) | `MedusaMod.cs:2385` `ApplyMaterial(go,color,transparent)` → `2395` `MakeFxMaterial` | Builds primitive colored FX material, NOT char material |
| Toon template capture | `MedusaMod.cs:4860` `_toonTemplateMaterial = sharedMaterial` (in `GraftMedusaVisual` @ `4837`) | Captures a base character's native toon material |
| Toon clone onto Medusa SMRs | `MedusaMod.cs:4929` `val6 = new Material(val)` → `((Renderer)item).sharedMaterial = val6` | Per-renderer **instanced** clone, name `Medusa_Material_Native` |
| Forced material visibility | `MedusaMod.cs:4675` `ForceMedusaVisualMaterialVisibility` | Re-instances toon template @ `4746`; sets `_Color/_BaseColor/_TintColor=1,1,1,1` @ ~`4779`; `_Alpha/_Opacity/_ZWrite=1`, `_Cutoff/_Surface=0` @ ~`4787`; assigns `val.sharedMaterial = val3` **and** `val.material = val3` @ `4795-4801` |
| CharMaterial rebind | `MedusaMod.cs:3914` `BindMedusaVisualToCharMaterial` | Sets `charRenderer`/`extraRenderers`/`customVisBounds`, then `ReInitializeMaterialWrappers()` @ `4000` |
| Forced CharMaterial visibility | `MedusaMod.cs:4026` `ForceMedusaCharMaterialVisible` | `alpha=1`, `isOpaque=true`, `isPartialHidden=false`, `SetCharacterVisible(true)`, `SetCharRendererEnabled(true)`, `SetRendererMaterialAlpha(1f)`, `UpdateCurrentRendererMaterialAlpha()`, `ForceAlphaLerpFinish()`, `RevealHiddenCharacter()` |
| Bound-state check | `MedusaMod.cs:4171` `IsCharMaterialBoundToVisual` | True only if `charRenderer` is under `Medusa_Visual` |
| Visibility-repair predicate | `MedusaMod.cs:4197` `NeedsCharMaterialVisibilityRepair` | Repairs when `!rendererIsActive` OR `alpha<0.99` OR `!isOpaque` OR `isPartialHidden` OR not bound |
| Render layer (C1 overlap) | `MedusaMod.cs:3853` `ResolveCharacterRenderLayer` / `3877` `ApplyCharacterRenderLayer` | Re-syncs Medusa SMRs back to char layer after native overlay setup |

---

## 2. Does a native fade/spawn-in OR a wrong shader/alpha cause transparency? — BOTH, layered

### (a) Wrong shader in the bundle (root, high confidence)
`Medusa_Material.mat` line 10: `m_Shader: {fileID: 46, guid: 0000000000000000f000000000000000, type: 0}` = Unity **built-in Standard** shader, not the game's toon/char shader. It also carries `m_InvalidKeywords: _AA_FWIDTH, _DEPTHMASKOVERLAY, _SIMPLEREFLECTION` (line 17-20) — these are keywords from the *game's* char shader that are invalid on Standard. So the bundled Medusa ships with the wrong shader; the mod must replace it at runtime by cloning a real character's toon material (`GraftMedusaVisual` @ `MedusaMod.cs:4837/4860/4929`). If graft fails ("no base material to clone toon shader from" warning, `MedusaMod.cs` graft path), Medusa keeps the Standard shader — which the native CharMaterial alpha system cannot drive correctly → transparency / wrong look.

### (b) Native CharMaterial alpha-lerp spawn-in fade (proximate, high confidence)
The native `CharMaterial` owns a per-character alpha/fade system that drives the rendered material every frame, independent of what the SMR's material color says. From `dump.cs` (CharMaterial @ 248006):
- Fields: `private float alpha;`(0x14C), `private bool isOpaque;`(0x150), `private float alphaFadeTimer;`(0x154), `private float alphaFadeDuration;`(0x158), `public bool isPartialHidden;`(0x168), `private float partialHiddenAlpha;`(0x120), `private bool rendererIsActive;`(0x149), `private Shader overrideCharOpaqueShader;`(0x108), `private Shader overrideCharTransparentShader;`(0x110).
- Methods: `private void AnimateAlphaLerp()`, `public void UpdateAlpha()`, `private void SetMaterialAlpha(MaterialWrapper)`, `public void SetRendererMaterialAlpha(float)`, `public void UpdateCurrentRendererMaterialAlpha()`, `public void ForceAlphaLerpFinish()`, `public void RevealHiddenCharacter()`, `public void SetCharRendererPartialHidden(bool)`, called from `ManagedUpdate()`.
- `MaterialWrapper` (`CharMaterial.cs:16-160`, dump 247868) holds `matInstance`, `originalMat`, `overrideTransparentQueue`, `overrideOpaqueQueue`, `maxAlpha`, `tintable`.

So the native code wraps each renderer material into a `matInstance`, then `AnimateAlphaLerp`/`UpdateAlpha` ramps `alpha` toward `maxAlpha` on spawn (a spawn-in fade) and swaps between `overrideCharOpaqueShader`/`overrideCharTransparentShader` + queue. If the lerp never reaches 1, or `maxAlpha`/wrappers are mis-initialized after the mod swaps the renderer/material, the character renders semi/fully transparent.

### (c) The mod's own repair code is the smoking gun
`ForceMedusaCharMaterialVisible` (`MedusaMod.cs:4026`) exists solely to short-circuit (b): it pins `alpha=1`, `isOpaque=true`, `isPartialHidden=false`, calls `SetRendererMaterialAlpha(1f)`, `UpdateCurrentRendererMaterialAlpha()`, and crucially `ForceAlphaLerpFinish()` + `RevealHiddenCharacter()`. `NeedsCharMaterialVisibilityRepair` (`4197`) re-checks `alpha<0.99 / !isOpaque / isPartialHidden / !rendererIsActive` every poll. This proves the team already identified the native fade/alpha-lerp + partial-hidden state as the transparency driver and is fighting it frame-by-frame. The `_charMaterialVisibleRoots` gate means the force runs once then trusts state — so any later native re-fade (re-spawn, teleport via `BeginTeleport`, gigantify, hide-area) re-transparents Medusa until the next repair.

### (d) "Visible only after damage" — consistent with (b)
Native `TriggerHit(Color,float)` / `UpdateHitBlink()` / `SetBaseColor*` (dump 248006 region) push a color/alpha refresh through `UpdateAlpha`→`SetMaterialAlpha` on every hit, momentarily forcing the wrappers opaque. That is exactly why a transparent Medusa "pops" visible when damaged: the hit-blink path re-applies material alpha that the spawn-in path left at <1. (Confidence: medium-high.)

### (e) Layer 26 overlay (C1 overlap, contributes to "invisible")
Code comment at `MedusaMod.cs:~4007`: *"CharMaterial's overlay setup moves the custom Medusa SMR to layer 26 on live match spawn. That layer is not rendered by the normal gameplay camera..."* — native `InitializeOverlayRendererLayers()` (dump) reparents renderers to an overlay layer; `ApplyCharacterRenderLayer` (`3877`) re-syncs them. This is a *layer/culling* invisibility distinct from alpha, but co-occurs.

---

## 3. Is the bound material shared or instanced?

**Instanced at every level** (high confidence):
- Mod creates per-renderer copies: `new Material(val)` @ `MedusaMod.cs:4929` (graft) and `new Material(_toonTemplateMaterial)` @ `4746` (force-visible), naming them `Medusa_Material_Native` / `Medusa_Material_NativeVisible`. Each SMR gets its own instance; `val.sharedMaterial`/`val.material` both set to the same instance (`4795-4801`).
- Native `SetupMaterialWrappers`/`ReInitializeMaterialWrappers` then wrap those into `MaterialWrapper.matInstance` keeping `originalMat` — i.e. the *actually rendered* material is a further native instance whose alpha the mod cannot set directly except via the CharMaterial API. Implication: setting `_Color`/`_Alpha` on the SMR material (`ForceMedusaVisualMaterialVisibility`) does NOT guarantee visibility, because native re-applies `alpha`→`matInstance` each frame. Visibility must go through `SetRendererMaterialAlpha`/`ForceAlphaLerpFinish` (which the mod does). The toon template captured at `4860` is a *shared reference* to a live base-char material, but it is only used as a clone source, never assigned directly.

---

## 4. Green-lines / Kitsu-FX note (question 2, partial — C2 angle)
`ApplyMaterial`(`2385`)+`MakeFxMaterial`(`2395`) build a `Sprites/Default`→`Unlit/Color`→`Standard` fallback colored material (transparent path sets `_SrcBlend=5`, `_DstBlend=10`, `_ZWrite=0`, `_ALPHABLEND_ON`, `renderQueue=3000`). This is the mod drawing its **own primitive/line FX** with a flat color instead of instantiating the real bundled `VFX_Medusa_Poison_*` prefabs (present under `...\MedusaBundleProject\Assets\GameObject\MedusaVfx\`). The colored-primitive fallback = the "green lines"; real Medusa VFX existing in LatestBuild are not being spawned. (Deeper ability-VFX routing is C1/other agents.)

---

## 5. Hypotheses + confidence (C2)

- **H1 (90%)** — Transparency is primarily the native `CharMaterial` alpha-lerp / spawn-in fade + `isPartialHidden` state acting on instanced `MaterialWrapper.matInstance`; the mod must force `alpha=1`/`isOpaque`/`ForceAlphaLerpFinish` and re-runs only on the repair predicate, so any native re-fade event (respawn/teleport/gigantify/hide-area) re-transparents Medusa until repaired. Evidence: `MedusaMod.cs:4026-4135`, `4197-4246`; `CharMaterial` fields/methods @ dump 248006.
- **H2 (80%)** — Bundle ships the WRONG shader (built-in Standard, `Medusa_Material.mat:10` + invalid char-shader keywords). When toon-template graft fails, Medusa is left on Standard which the native opaque/transparent-shader swap + queue cannot drive → persistent transparency/wrong rendering.
- **H3 (80%)** — Bound material is instanced at both mod and native layers; SMR-material color writes are overridden each frame by native `matInstance` alpha, so only the CharMaterial-API path reliably reveals her.
- **H4 (75%)** — "Visible only after damage" = native hit-blink (`TriggerHit`/`UpdateHitBlink`→`UpdateAlpha`) momentarily reapplying material alpha the spawn-in left below 1.
- **H5 (60%, C1 overlap)** — Some "invisible" cases are layer-26 overlay culling, not alpha (`MedusaMod.cs:~4007` comment + `ApplyCharacterRenderLayer` `3877`).
- **H6 (40%, adjacent)** — Per-frame `GetComponentsInChildren<Renderer/SkinnedMeshRenderer>` scans in the repair/visibility pollers (`ForceMedusaVisualMaterialVisibility`, `EnsureStableLiveMedusaVisualCheap`, diagnostics) are a plausible contributor to FPS drops; not confirmed by profiling.

## Caveats
- I did not run/profile the game; native method bodies (`AnimateAlphaLerp`, `SetMaterialAlpha`) are stubs in the decompile (`RVA` only), so the exact lerp target (`maxAlpha` default) and fade duration are inferred from field names, not read values. Confidence reflects that.
