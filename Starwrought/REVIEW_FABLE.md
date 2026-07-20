# Starwrought — "Wow Factor" Review (Fable)

Reviewed against `DESIGN.md` (Starwrought + PRISMBREAK VFX + Codex handbook) on Fabric 1.21.9.
Scope: full source/resource inventory, Gradle build + JUnit run, dedicated-server log inspection.

## Verification performed

- `./gradlew clean build` — **PASS** (compileJava, compileClientJava, remapJar; only one benign
  deprecation note in `ModEntityRenderers`).
- JUnit suite (`StarwroughtLogicTest`, 6 tests) — **PASS**.
- `run/logs/latest.log` shows a real dedicated-server boot reaching `Done (0.234s)` with
  1,487 recipes, 1,578 advancements, and **4 handbook chapters / 15 entries** loaded cleanly.

## 1. Inventory — exists vs. missing

### Present and functional

| Design pillar | State |
|---|---|
| **Aurora / Starfall** | Server-side: seeded night scheduler (`SkyEventSchedule`, ~every 4 nights) persisted via `PersistentState`; aurora nights place meteorite clusters (`meteoric_stone` + glowing `meteorite_core`) near players. Client-side: `AuroraSkyRenderer` particle ribbons. |
| **Umbral Night** | Scheduled (~every 12 nights, collision-avoided with aurora), broadcasts, periodic Hollow Stalker spawns near players, handbook unlock push. |
| **Attunements Wolf/Lyra/Anvil** | Charts ×3 + `ResonanceAltarBlock` attune flow; per-player synced+persistent attachment; levels 1–5 with shared thresholds (0/8/24/48/80); progression hooks (Wolf: night kills; Lyra: distance traveled; Anvil: forging/meteoric mining); server-authoritative abilities on **R** with cooldowns (Wolf: Pack Howl AoE Strength+Speed, 60s; Lyra: Comet Dash blink, 25s); Anvil passively accelerates the Star Forge. |
| **Starsteel gear** | Full tool set + 4 armor pieces with proper 1.21.9 `ToolMaterial`/`ArmorMaterial`, repair tag, equipment asset JSON + humanoid/leggings layer textures; produced in the `StarForgeBlockEntity` (shard + iron, aurora doubles speed). Comet Bow, Phase Flare (position swap), Wayband (Lumen Spire recall), Astrolabe (forecast + meteorite bearing). |
| **Hollow Stalker** | Teleporting zombie-based mob, event + Herald-phase-3 spawned, drops Hollow Residue (loot table). |
| **Herald boss** | Summoned at Hollow Beacon (4 residue + voidglass); 240 HP, boss bar with sky darkening, 3 HP-gated phases (color shift, teleport-to-target, stalker reinforcements), orbiting prisma-shard shell + shard-barrage telegraph particles, `ImpactFx` shockwave broadcasts to tracking clients, guaranteed Zenith Core drop, death burst. |
| **Handbook UI (H)** | Data-driven: 4 chapter + 15 entry JSONs under `data/starwrought/handbook/` with `has_item`/`advancement`/`manual` unlock conditions, reload-listener loader, pipe-encoded S2C sync. Client screen: category tabs, live search, scrollable list, lock states, page-fold reveal animation, drifting UI motes, page-turn sound; opens via **H**, Codex item, or S2C packet; offline fallback catalog. |
| **PRISMBREAK VFX** | 3 custom full-bright translucent billboard particles (spark/shard/mote) with palette, rotation, ease curves; ribbon trails (player + up to 24 projectiles); midpoint-displacement lightning arcs; expanding shockwave rings; `SpectacleDirector` composing trauma + FOV kick + HUD flash + arcs + debris; `TraumaCamera` with decaying noise shake via `Camera.setRotation` mixin and `GameRenderer.getFov` mixin. |
| **HUD** | Attunement/charge/cooldown panel, low-health pulsing vignette, damage flash, spectacle white-flash. |
| **DE/EN lang** | Both files fully parallel (items, blocks, messages, advancements, handbook bodies). ~12 UI keys were missing — fixed in this review, see below. |
| **Recipes / advancements** | 24 recipes (gear, blocks, charts, codex, refining smelt); 4-step advancement chain (first_shard → altar → attune → herald) with correct triggers. |
| **Gradle build** | Loom 1.17, MC 1.21.9, Yarn build.1, Fabric API 0.134.1 — clean build, remapped JAR produced. |

All textures are real 16×16 (+ GUI/equipment) RGBA pixel art, not placeholders.

### Missing / not wired (vs. design intent)

- **`SkyEvent` S2C payload is registered on both sides but never sent by the server.**
  The client aurora falls back to a "every clear night" heuristic, so aurora ribbons render
  on nights when no starfall/meteorites exist (and forecasting via Astrolabe contradicts the sky).
- **No starfall spectacle** — meteorites silently appear in `SkyEvents.placeMeteorite`; there is no
  falling-comet VFX, sound, or `ImpactFx` shockwave at the landing site despite the payload existing.
- **Herald/Stalker use vanilla `ZombieEntityRenderer`** (vanilla zombie model *and* texture).
  DESIGN.md's "shard-shell renderer" is absent; only server-spawned particles differentiate the boss.
- **H-key handbook never requests server state** — sync happens only when using the Codex/Astrolabe
  items, so pressing H before that shows the 9-entry fallback catalog with mostly-unlocked state
  instead of the server's 15 gated entries. No C2S request or on-join push exists.
- **HUD shows fabricated defaults** — `ClientHudState` hardcodes `WOLF` / charge 0.72; the server
  sends `AbilityState` only on successful activation, never on join/attune, and the HUD ignores the
  already-synced attunement attachment. Anvil/unattuned players see a misleading Wolf panel.
- **Umbral Night has no client visual** (no fog/sky treatment) — it is chat text + spawns only.
- Minor: Herald entity loot table is an empty stub (drop is code-side, fine); `AbilityState.charge`
  is always 1.0 (no charge mechanic); Comet Bow is a light vanilla-bow reskin (acknowledged in
  `COMMON_STATUS.md`).

## 2. Scores

- **Feature completeness: 8 / 10.** Every "must have" from the brief exists and runs — events,
  three attunements with distinct progression and two ultimates, full gear chain, both mobs, a
  genuinely data-driven handbook, bilingual lang, recipes/advancements, green build with tests and
  a verified dedicated-server boot. Deductions for the unsent sky-event sync (client/server aurora
  desync), the handbook H-path not pulling real state, and the HUD not reflecting real attunement.
- **Visual ambition: 7 / 10.** For a particles-only pipeline (justified: 1.21.9 removed the legacy
  world-render hooks) the layering is impressive — trauma camera + FOV kick via mixins, shockwaves,
  procedural lightning, emissive palette particles, an animated handbook with page-fold and motes,
  damage vignette. Deductions: the boss reads as a plain zombie at first glance, meteor arrival has
  zero spectacle, aurora is a local particle halo (~16 blocks above the player) rather than a true
  sky band, and Umbral Night is visually mute.

## 3. Blocker fixed in this review

**Missing/incorrect translation keys (always-visible raw keys on screen).** The HUD renders
`hud.starwrought.attunement.wolf` / `hud.starwrought.cooldown` and the handbook renders
`handbook.starwrought.title|subtitle|search|no_results|locked` — none were in the lang files, and
the keybind category used `key.category.starwrought` while 1.21.9's
`KeyBinding.Category.create(Identifier)` resolves `key.category.starwrought.starwrought`
(verified against mapped bytecode). `key.starwrought.ability` was also missing.
**Fix:** added the 14 missing keys to both `assets/starwrought/lang/en_us.json` and `de_de.json`
(no code changes). Build + tests re-run: PASS. No compile-breaking bugs found.

## 4. TOP 5 highest-impact gaps that still fit this PR

1. **Broadcast the `SkyEvent` payload (client/server aurora desync).**
   In `src/main/java/de/atomi/starwrought/system/SkyEvents.java`, send
   `ClientboundPayloads.SkyEvent(active, remainingTicks)` to all overworld players inside
   `startAurora(...)` and when the event window closes (the `dayTime < 1_000L` branch), plus once in
   a `ServerPlayConnectionEvents.JOIN` handler so late joiners sync. ~20 lines; instantly makes the
   Astrolabe forecast, meteorites, and the sky agree.

2. **Give starfall an arrival moment.**
   In `SkyEvents.placeMeteorite(...)`, after placing the core: play
   `SoundEvents.ENTITY_GENERIC_EXPLODE`-class audio, spawn a vertical `PRISMA_SHARD` column
   (`world.spawnParticles`), and send `ClientboundPayloads.ImpactFx(x, y, z, ~1.6F)` to nearby
   players — the client already turns that into shockwave + trauma + lightning for free. This is
   the single cheapest "wow" win because the whole client stack already exists.

3. **Visually de-zombie the Herald.**
   Smallest credible step in `src/client/java/de/atomi/starwrought/client/render/ModEntityRenderers.java`:
   register a `ZombieEntityRenderer` subclass overriding the texture with
   `assets/starwrought/textures/entity/herald.png` (+ one for the stalker), optionally scaling the
   model up ~1.4× for the Herald. Two small classes + two textures; no new model needed to stop the
   boss reading as a vanilla zombie.

4. **Make H-key handbook fetch real server state.**
   Add a `RequestHandbookC2S` (empty payload) to `ModNetworking`; server receiver calls the existing
   `ModNetworking.openHandbook(player)` minus the `OpenHandbook` echo (or simply sends
   `HandbookSync`). Client: in `StarwroughtClient` send it before `setScreen(...)` when connected.
   Alternatively (even smaller): send `HandbookSync` in a `ServerPlayConnectionEvents.JOIN` handler.
   Restores the entire unlock-progression fantasy for keyboard users.

5. **Drive the HUD from real attunement state.**
   The attunement attachment is already synced (`PlayerAttachments.ATTUNEMENT` uses
   `AttachmentSyncPredicate.all()`); in `ClientHudState.tick(...)` read
   `client.player.getAttached(...)` to set the label/charge (charge = counter/80 progress toward
   level 5) instead of the hardcoded `WOLF`/0.72, and hide the panel when unattuned. One file plus a
   small accessor; removes the most misleading always-on-screen element.

## Not in scope for this PR (noted for later)

Umbral-night fog/sky tint, a true sky-layer aurora band renderer, a charge/resource mechanic
behind `AbilityState.charge`, a Herald shard-shell feature renderer, and an Anvil active ability.
