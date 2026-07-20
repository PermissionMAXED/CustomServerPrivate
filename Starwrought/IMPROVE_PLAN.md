# Starwrought — Improvement Plan (Fable advisory, 2026-07-20)

Target: Fabric **1.21.9**, Loom 1.17, Yarn build.1, Fabric API 0.134.1, Java 21.
Branch: `cursor/fabric-spectacle-mod-05c3`. Implementer: one focused session, file-level patches below.

## 0. Baseline (verified this session)

- `./gradlew test --no-daemon` → **BUILD SUCCESSFUL**, `StarwroughtLogicTest`: **6 tests, 0 failures, 0 errors, 0 skipped** (re-verified with `--rerun-tasks`; compile + client compile clean, one known benign deprecation note in `ModEntityRenderers`).
- The five fixes from `REVIEW_FABLE.md` **have landed**: SkyEvent broadcast + join sync, meteor arrival sound/particles/ImpactFx, Herald/Stalker texture-override renderers (1.35× Herald), `RequestHandbookC2S` on H-key, attachment-driven HUD.

### Scores (1–10)

| Axis | Score | Justification |
|---|---|---|
| Feature | **7** | Every DESIGN.md pillar exists and runs, but: **survival progression is hard-locked** (see P0-1 — charts/Astrolabe/Wayband/Flare/Bow are uncraftable because Glimmer Dust has no obtainable source), the Herald telegraphs attacks that deal **zero damage**, abilities are invisible/inaudible to other players, Umbral Night has no client presence, Zenith Core is a dead-end trophy. |
| Visual | **7** | Impressive particles-only pipeline (trauma cam, FOV kick, shockwaves, arcs, animated handbook), but the aurora is a ~16-block personal halo (21 particles/2 ticks), abilities have no world-visible beat, Umbral is chat-text-only, and the boss fight's spectacle is decorative rather than communicative. |
| Test | **3** | 6 pure-logic tests. Zero coverage of: data assets (the P0-1 progression bug would have been caught by a recipe-reachability test), the pipe-encoded handbook wire format, ability cooldown gating, boss phase logic, lang-file parity. |

## 1. Constraints for the implementer

- **No artist-heavy 3D modeling.** The Herald/Stalker stay on the zombie model base with texture overrides + procedural scale/particles. All visual work below is code, particles, palette math, or 16×16-style texture tints (the existing `tools/generate_assets.py` pipeline may be reused for any new flat texture).
- The mod ships as **one JAR for client+server**, so the `SkyEvent` payload change in P0-4 is not a compat problem — but change codec field order deliberately and in one commit.
- Keep everything **server-authoritative**: damage, cooldowns, unlocks, teleports stay in `src/main`; `src/client` only presents.
- German + English lang files must stay in **exact key parity** (enforced by a new test, P0-7).

---

## 2. P0 — must ship (7 items)

### P0-1 — Fix the survival progression hard-lock (Glimmer chain)

**The bug:** `glimmer_dust` gates `chart_wolf/lyra/anvil`, `astrolabe`, `lumen_lantern`, `phase_flare`, `wayband`, `comet_bow`. Its only source is `glimmer_petal` ← breaking an age-3 `astral_bloom` (`ModBlocks.AstralBloomBlock.afterBreak`). But **no recipe, no worldgen, no loot table, and no code path ever produces an Astral Bloom**. In survival, the entire attunement/artifact tier is unreachable. (This also makes the Astrolabe — the tool that's supposed to teach the sky-event loop — uncraftable.)

**Fix (thematic, code + data only):** meteor craters sprout Astral Blooms.

- `src/main/java/de/atomi/starwrought/logic/CraterBlooms.java` (**new**, pure): given a seed and the crater center, return 2–4 deterministic `(dx, dz)` offsets in ring radius 2–4 (no duplicates, never the center). Pure so it is unit-testable.
- `src/main/java/de/atomi/starwrought/system/SkyEvents.java`: in `placeMeteorite(...)` after the core is set, for each `CraterBlooms` offset find the surface (`Heightmap.Type.MOTION_BLOCKING_NO_LEAVES`), and if the ground below is dirt/grass/meteoric stone and the spot is air, place `ModBlocks.ASTRAL_BLOOM` with `AGE` 1–2 (so a night of random ticks can finish them).
- `src/main/java/de/atomi/starwrought/content/ModBlocks.java` (`AstralBloomBlock`): add `canPlaceAt` (grass/dirt/meteoric stone below) and break-when-support-lost behavior so placed blooms behave like plants; keep age-3 petal bonus. Also drop **1 petal guaranteed at age 3** plus the existing random extra (current code drops 1–2 only at age 3 — keep, just verify).
- `src/main/resources/data/starwrought/loot_table/blocks/meteorite_core.json`: add a second pool: 1–2 `starwrought:glimmer_dust` (so the very first crater unlocks a chart even if the player tramples blooms).
- `HANDBUCH.md` + handbook lang: document the source ("Meteorkrater treiben Astralblüten").

**Acceptance criteria**

- Fresh survival world, trigger an aurora (`/time set` across 4 nights or temporary schedule tweak): every meteorite crater has ≥2 Astral Blooms; mining the core yields glimmer dust; a chart is craftable without creative mode.
- New `RecipeReachabilityTest` (below) fails on current `main` code and passes after the fix.

**Test idea (JUnit, pure):** `CraterBloomsTest` — determinism per seed, offset count 2–4, offsets within ring, no duplicate positions. Plus the P0-7 `RecipeReachabilityTest` covers the economy graph forever.

---

### P0-2 — Abilities must be visible and audible to everyone (multiplayer feel + resync)

**The gap:** `ModNetworking.activateAbility` applies effects/teleports but spawns **no server particles and no sounds**; only the caster's own client runs `SpectacleDirector.abilityUse()` (via its own `AbilityState` packet). In multiplayer, a Pack Howl or Comet Dash is completely invisible to everyone else. Additionally, cooldowns live in `ABILITY_COOLDOWNS` (UUID-keyed, survives relog within a server run) but the HUD only learns cooldown on activation — after a relog the HUD claims "ready" while the server rejects.

**Files**

- `src/main/java/de/atomi/starwrought/logic/AbilityCooldowns.java` (**new**, pure): wraps the `Map<UUID, Long>`; API `long remaining(UUID, long now)`, `boolean tryActivate(UUID, long now, long cooldownTicks)`. `ModNetworking` delegates to one static instance.
- `src/main/java/de/atomi/starwrought/network/ModNetworking.java`:
  - Wolf (Pack Howl): `world.spawnParticles(ModParticles.PRISMA_SPARK, ...)` expanding ring (2 pulses, ~48 particles) at the caster + `world.playSound(null, ..., SoundEvents.ENTITY_WOLF_HOWL, SoundCategory.PLAYERS, 1.4F, 0.7F)`; send `ClientboundPayloads.ImpactFx(x, y, z, 0.9F)` to every player within 48 blocks (not just the caster) so allies get the shockwave/trauma beat.
  - Lyra (Comet Dash): spawn a `PRISMA_SHARD` line from origin to destination (~10 samples, reuse the Herald barrage-telegraph loop shape), `SoundEvents.ENTITY_ENDERMAN_TELEPORT` at both ends pitched 1.3F, `ImpactFx(dest, 0.6F)` to nearby players.
  - Register a `ServerPlayConnectionEvents.JOIN` handler that sends `AbilityState(attunement, charge, remainingCooldown, maxCooldown, activated=false)` so the HUD is correct after relog (mirror the pattern already used in `SkyEvents.initialize`).
- No client changes required — `ImpactFx` and `AbilityState` receivers already exist in `StarwroughtClient`.

**Acceptance criteria**

- Two-player test (or one player + spectating a fake second client): observer within 32 blocks sees the howl ring/dash streak and hears the sound; the caster still gets the full SpectacleDirector beat.
- Relog while Pack Howl is on cooldown → HUD shows the correct remaining cooldown bar, and `R` shows the action-bar cooldown message.

**Test idea (JUnit, pure):** `AbilityCooldownsTest` — activation blocks re-activation until expiry; `remaining()` counts down; two UUIDs are independent; `tryActivate` at exactly `readyAt` succeeds.

---

### P0-3 — Give the Herald real attacks behind its telegraphs

**The gap:** `HeraldEntity` is 240 HP of vanilla zombie melee. The phase-2 "shard barrage" (`age % 45`) is particles only — **no damage**. `blastImpact` is visual only. Phase changes are a color swap + broadcast. A player in Starsteel armor can face-tank the entire fight.

**Files**

- `src/main/java/de/atomi/starwrought/logic/HeraldLogic.java` (**new**, pure): `int phaseFor(float healthRatio)` (move the `0.66/0.33` gating out of the entity), `float barrageDamage(int phase)` (e.g. 5.0F phase 2, 8.0F phase 3), `float novaDamage(double distance, int phase)` (full ≤2 blocks, linear falloff to 0 at 6), `boolean isStarfallTick(int age)` (every 160 ticks in phase 3), `int barrageResolveDelay()` (= 15).
- `src/main/java/de/atomi/starwrought/entity/HeraldEntity.java`:
  - **Barrage payoff:** when the existing `phase >= 2 && age % 45 == 0` telegraph fires, record `barrageTarget` + `barrageResolveAt = age + 15`. At resolve time, if the target is alive and within 20 blocks and has line of sight, apply `target.damage(world.getDamageSources().indirectMagic(this, this), HeraldLogic.barrageDamage(phase))`, spawn a `PRISMA_SHARD` burst at the target, and send `ImpactFx(target, 0.8F)` to tracking players. Dodging behind cover in the 0.75 s telegraph window avoids it — that is the intended counterplay.
  - **Phase nova:** on phase transition (existing `nextPhase != phase` branch), damage + knock back every player within 6 blocks using `HeraldLogic.novaDamage` (`player.takeKnockback(1.2, dx, dz)`); visuals already exist via `blastImpact`.
  - **Phase-3 starfall:** every 160 ticks pick a random tracked player within 24 blocks; telegraph a vertical `PRISMA_SHARD` column at their feet for 40 ticks (3 spawns), then deal 8.0F AoE damage in radius 3 + `ImpactFx(pos, 1.4F)`. No block damage, no fire (multiplayer-safe).
  - Play `SoundEvents.ENTITY_WITHER_AMBIENT` (pitch 0.6) on phase change and `SoundEvents.ENTITY_SHULKER_SHOOT` on barrage launch — the fight currently has zero audio identity.
- `src/main/resources/data/starwrought/loot_table/entities/herald.json`: replace the empty stub with 2–4 `hollow_residue` + 3–5 `glimmer_dust` (Zenith Core stays code-side/guaranteed).

**Acceptance criteria**

- A stationary armored player in phase 2 takes barrage damage at least every ~3 s; breaking line of sight during the telegraph avoids it.
- Phase transitions visibly shove players out of melee.
- In phase 3 a marked player who does not move takes starfall damage; one who runs does not.
- Boss fight emits audible cues for each mechanic.

**Test idea (JUnit, pure):** `HeraldLogicTest` — phase boundaries (`1.0→1`, `0.66→2`, `0.33→3`, clamps), barrage damage per phase, nova falloff (0 at ≥6 blocks, max at ≤2), starfall cadence tick math.

---

### P0-4 — Umbral Night needs a wire signal and a client presence

**The gap:** `ClientboundPayloads.SkyEvent` only carries `auroraActive` — the client cannot even know an Umbral Night is happening (join sync during umbral sends `active=false`). Umbral is chat text + spawns; DESIGN.md promises a darkened, threatening night.

**Files**

- `src/main/java/de/atomi/starwrought/network/ClientboundPayloads.java`: change `SkyEvent(boolean auroraActive, int remainingTicks)` → `SkyEvent(String eventType, int remainingTicks)` with `eventType ∈ {"none","aurora","umbral"}` (reuse `SkyEventSchedule.Event` names; `PacketCodecs.string(16)`). One commit, both sides.
- `src/main/java/de/atomi/starwrought/system/SkyEvents.java`: `broadcastSkyEvent`/`syncSkyEvent`/`sendSkyEvent` carry the actual `state.activeEvent`; broadcast on **umbral start** (in the `UMBRAL` branch of `tick`) and on **any** event end (drop the `auroraEnded` guard — currently umbral end is never broadcast). Move `remainingEventTicks` math into `SkyEventSchedule.remainingNightTicks(long dayTime)` (pure) and call it from here.
- `src/client/java/de/atomi/starwrought/client/StarwroughtClient.java`: route the payload — `"aurora"` → `AuroraSkyRenderer.setSyncedState(true, ticks)`, `"umbral"` → new `UmbralAmbience.setActive(ticks)`, `"none"` → clear both. Add `UmbralAmbience.tick(client)` to the END_CLIENT_TICK block and `UmbralAmbience.reset()` to DISCONNECT.
- `src/client/java/de/atomi/starwrought/client/fx/UmbralAmbience.java` (**new**): every 3 ticks spawn 4–6 `HOLLOW_MOTE` drifting at radius 6–14 around the player (slow inward drift, y 0–3); every ~400 ticks play a local `SoundEvents.AMBIENT_CAVE` at low volume; expose `static boolean active()`.
- `src/client/java/de/atomi/starwrought/client/hud/StarwroughtHud.java`: while `UmbralAmbience.active()`, render a faint indigo edge vignette (reuse the existing `renderVignette` gradient helpers with `PrismPalette.INDIGO` at ~0.18 alpha, additive with the health vignette).
- `AuroraSkyRenderer.isActive` clear-night **heuristic stays** as offline/vanilla-server fallback only (unchanged semantics once a payload arrives).

**Acceptance criteria**

- Start an umbral night (`/time add` across nights or temp schedule): all connected clients show motes + vignette within 1 s; a player joining mid-umbral gets it immediately; at dawn (`dayTime < 1000`) both aurora and umbral ambience stop because the end-broadcast now fires for both.
- Aurora behavior is unchanged (ribbons only on true aurora nights).

**Test idea (JUnit, pure):** extend `StarwroughtLogicTest` (or new `SkyEventScheduleTest`): `remainingNightTicks(13_000) == 12_000`, `remainingNightTicks(500) == 500`, `remainingNightTicks(24_000-1) == 1_001`… lock the dawn boundary contract.

---

### P0-5 — Aurora: from personal halo to sky-scale band

**The gap:** `AuroraSkyRenderer.spawnRibbons` spawns 21 particles per 2 ticks at `origin.y + 16..24`, span ±12 blocks — it reads as a glow above your head, not a sky. (True sky-layer rendering is blocked by 1.21.9's world-render extraction; stay on particles but change the composition.)

**Files**

- `src/main/java/de/atomi/starwrought/logic/AuroraBandMath.java` (**new**, pure — in `main` so tests can reach it): `Vec-free` sample function `double[] sample(int ribbon, int sampleIndex, long time)` returning `{dx, dy, dz}` offsets: 4 ribbons, samples 0–12 spaced 8.0 apart (span ±48), altitude 38 + ribbon·4 + 3.5·sin(slow phase), lateral curtain sweep amplitude 10–18. Deterministic in `time`.
- `src/client/java/de/atomi/starwrought/client/fx/AuroraSkyRenderer.java`:
  - `spawnRibbons` iterates `AuroraBandMath`, anchored at the **camera position snapped to a 16-block grid on X/Z** (so two nearby players see approximately the same band instead of each carrying their own halo).
  - Particle mix: `PRISMA_SPARK` / `HOLLOW_MOTE` / every 6th `PRISMA_SHARD`; gentle `+0.004` y-velocity.
  - Respect the particles video option: on `ParticlesMode.DECREASED` spawn every 3rd sample, on `MINIMAL` every 6th.
  - Budget: ≤ ~110 spawns per 2-tick pulse (4×13 ≈ 52 base ×2 layers max). Verify no fps collapse with particles=All.

**Acceptance criteria**

- During an aurora, looking up at ~40–60° pitch shows a wide multi-ribbon band (≥90 blocks apparent span, 38+ blocks up) with indigo/cyan/gold variation; walking 20 blocks does not visibly "drag" the aurora with you (grid snapping).
- Frame time impact ≤ ~1 ms versus baseline on the dev machine (subjective check in F3).

**Test idea (JUnit, pure):** `AuroraBandMathTest` — dy always within [36, 60]; dx symmetric around 0 across the sample range; deterministic for equal `(ribbon, sample, time)`; adjacent time steps move a sample less than 1.5 blocks (smoothness → no strobing).

---

### P0-6 — Handbook depth pass + real advancement context

**The gap:** all 15 entry bodies are single sentences of ~46–73 characters ("Night kills deepen Wolf attunement. Level 5 unlocks Pack Howl."). Numbers the game actually runs on (thresholds 0/8/24/48/80, 60 s/25 s cooldowns, forge 160-progress ticks, aurora ×2 forge speed, Anvil speed `1 + level/2`, Herald 240 HP with 66%/33% gates, stalker 0–2 residue) appear nowhere in-game. Also `ModNetworking.openHandbook` passes `Set.of()` as the advancement set — **`UnlockCondition.Advancement` can never fire**, making that whole condition type (and its JUnit test) dead code.

**Files**

- `src/main/java/de/atomi/starwrought/network/ModNetworking.java` (`openHandbook`): build the real advancement id set — iterate `player.getServer().getAdvancementLoader().getAdvancements()` (`Collection<AdvancementEntry>`) and collect `entry.id().toString()` where `player.getAdvancementTracker().getProgress(entry).isDone()`. These yarn names are **verified against the mapped 1.21.9 bytecode** (`ServerPlayerEntity.getAdvancementTracker/getAdvancementLoader`, `PlayerAdvancementTracker.getProgress(AdvancementEntry)`, `AdvancementProgress.isDone`). Only starwrought-namespace ids are needed; filter to keep the set small.
- `assets/starwrought/lang/en_us.json` + `de_de.json`: rewrite all 15 `handbook.starwrought.entry.*.body` values to 2–4 sentences (target 200–420 chars) including the real mechanics above; keep both langs parallel.
- **Three new entries** (JSON + 2×2 lang keys each):
  - `data/starwrought/handbook/entries/origins/astral_blooms.json` — category `getting_started`, unlock `advancement: starwrought:first_shard` (this proves the advancement path end-to-end), documents the P0-1 crater blooms → petals → dust chain.
  - `data/starwrought/handbook/entries/artifice/starsteel.json` — unlock `has_item: starwrought:starsteel_ingot`; documents forge inputs (shard+iron), 160 ticks, aurora/Anvil speed bonuses, gear tier position.
  - `data/starwrought/handbook/entries/hollow/hollow_stalker.json` — unlock `manual: starwrought:umbral_night` (pushed by the existing umbral unlock hook); documents teleport behavior + residue drops.
- `HANDBUCH.md`: sync section 2 (materials) with the bloom source and section 6 with the new Herald mechanics from P0-3.

**Acceptance criteria**

- Dedicated server log reads `Loaded 4 handbook chapters and 18 entries`.
- Earning `starwrought:first_shard` then pressing **H** shows the Astral Blooms entry unlocked (advancement path proven live).
- Every body ≥120 chars in **both** langs (enforced by `LangParityTest`, P0-7); EN and DE key sets identical.

**Test idea (JUnit):** covered by P0-7's `LangParityTest` + `HandbookWireTest`; no MC bootstrap needed (JSON read from `src/main/resources` via `Path`).

---

### P0-7 — Test hardening: data validation + shared wire codec

**The gap:** the suite tests 4 pure classes and nothing else. The P0-1 progression bug is exactly the class of regression a data test catches. The handbook wire format is implemented twice (encode in `HandbookLoader.encodeFor`, parse in client `HandbookState.applyWire`) with no shared contract.

**Files**

- `src/main/java/de/atomi/starwrought/handbook/HandbookWire.java` (**new**, common): `record Row(String id, String category, String titleKey, String bodyKey, boolean unlocked)`; `static String encode(List<Row>)` (with the existing `|`/newline sanitization) and `static List<Row> decode(String)`. `HandbookLoader.encodeFor` builds Rows and calls `encode`; client `HandbookState.applyWire` calls `decode` then maps to its `Entry`/`Category` (the category keyword mapping stays client-side).
- `src/test/java/de/atomi/starwrought/HandbookWireTest.java` (**new**): round-trip N rows; hostile values (`"a|b"`, `"line\nbreak"`, empty strings) survive encode→decode without row corruption; malformed rows are skipped not thrown.
- `src/test/java/de/atomi/starwrought/RecipeReachabilityTest.java` (**new**): read every JSON under `src/main/resources/data/starwrought/recipe/` (plain `java.nio.file.Files`, Gson — test working dir is the project dir). Build the ingredient→result graph. Assert every `starwrought:` ingredient is reachable from the obtainable roots: `{meteoric_stone (event), star_shard (smelt), glimmer_petal (astral bloom — P0-1), hollow_residue (stalker loot), zenith_core (boss), astral_bloom (crater), any minecraft:* item}` plus recipe outputs, iterated to fixpoint. **This test must fail if P0-1 is reverted.**
- `src/test/java/de/atomi/starwrought/LangParityTest.java` (**new**): parse both lang files; assert identical key sets; assert every `handbook/entries/**/*.json` `title`/`body` key exists in both; assert every `handbook.starwrought.entry.*.body` length ≥120 chars; assert every `message./hud./key./handbook.` key referenced… (keep to: key parity + entry coverage + body length).
- `src/test/java/de/atomi/starwrought/AbilityCooldownsTest.java`, `CraterBloomsTest.java`, `HeraldLogicTest.java`, `AuroraBandMathTest.java` — per P0-1/2/3/5 above; extend `StarwroughtLogicTest` with `remainingNightTicks` cases (P0-4).

**Acceptance criteria**

- `./gradlew test --no-daemon` green with **≥ 25 tests** total.
- Deleting the P0-1 bloom placement or renaming a DE lang key makes the suite fail.

---

## 3. P1 — should ship (if session time remains)

1. **Zenith Core endgame perk** — `ModNetworking.activateAbility`: if the caster's inventory contains `ZENITH_CORE`, cooldowns ×0.66 (pure helper `AbilityCooldowns.modifiedCooldown(base, hasZenith)` + test); `StarForgeBlockEntity.tick`: +2 speed if an ANVIL player within 8 blocks carries it. Handbook `zenith` body documents it. Turns the trophy into a build-around item with ~20 lines.
2. **Comet Bow identity** — `CometBowItem.shoot`: `projectile.addCommandTag("starwrought_comet")`; a `ServerTickEvents.END_WORLD_TICK` sweep spawns 2 `PRISMA_SPARK` on tagged arrows in flight and one `ImpactFx(0.5F)` + burst when `isInGround()` flips (then strip the tag). Everyone sees comet arrows, not just clients that happen to trail projectiles.
3. **Hollow Stalker teleport readability** — in `HollowStalkerEntity.tick` before/after `requestTeleport`: `HOLLOW_MOTE` burst at both positions + `SoundEvents.ENTITY_ENDERMAN_TELEPORT` (0.7 pitch). Also **cap spawns**: in `SkyEvents.spawnUmbralStalkers`, skip a player if >4 stalkers already within 32 blocks (multiplayer server-load + fairness guard).
4. **HUD attunement level pips** — `StarwroughtHud`: render `level()` as 5 diamond pips + `pointsToNextLevel()` tooltipish text; data already synced via the attachment (`AttunementProgress` exposes both). Removes the "what does this bar even mean" confusion.
5. **Astrolabe glyph compass** — replace the numeric bearing action bar with an 8-glyph arrow (`↑↗→…`) computed from bearing minus player yaw (server-side, it already sends action-bar text every 20 ticks). Pure helper `int octant(double bearingDeg, float yawDeg)` + JUnit.
6. **Dawn cleanup** — at event end in `SkyEvents.tick`, discard event-spawned stalkers (tag them with a command tag at spawn) so umbral packs don't linger into day.

## 4. P2 — nice to have

- **Sky-color tint mixin** — target verified in mapped 1.21.9 bytecode: `ClientWorld.getSkyColor(Vec3d, float)` returns `int` (there is also `getCloudsColor(float)`); an `@Inject` at RETURN modifying the packed color toward indigo during umbral / green-cyan during aurora is the single biggest remaining "true sky" step. Add to `starwrought.client.mixins.json` alongside the existing camera/FOV mixins.
- **Anvil active ability** (R): 20 s of Haste II + auto-pickup-smelt of mined meteoric stone; completes the "every constellation has an R" fantasy.
- **Reduce-motion toggle** — clamp `TraumaCamera` trauma/FOV kick behind a client-side boolean (simple properties file in the config dir); accessibility win for the screenshake-heavy identity.
- **Meteor anti-grief heuristic** — `placeMeteorite` aborts if any block in the 5×3×5 crater volume is *not* in the natural-replaceable set (currently it silently skips only those blocks; a base wall of stone bricks nearby still gets a crater butted against it). Cheap conservative version: require all 75 candidate positions to be replaceable-or-air.
- **Fix the deprecated `EntityRendererRegistry` overload** in `ModEntityRenderers` (build-log hygiene; the only warning left).
- **Rate-limit `RequestHandbookC2S`** to 1/second per player (trivial guard in the receiver; the 262 KB `HandbookSync` string is the heaviest packet the server sends).

## 5. Explicitly out of scope

- Custom entity **models/geometry/animations** (Herald stays scaled+retextured zombie + particle shell), bespoke GUI art beyond programmatic fills, any shader/core-render pipeline work, new sound *assets* (vanilla `SoundEvents` only), worldgen features beyond the code-placed crater blooms.

## 6. Done when (implementer checklist)

- [ ] All P0 items implemented; each as its own commit on `cursor/fabric-spectacle-mod-05c3` (no PR creation).
- [ ] `cd /workspace/Starwrought && ./gradlew clean build test --no-daemon` → BUILD SUCCESSFUL, **0 warnings beyond the known `ModEntityRenderers` deprecation note**, ≥25 tests, 0 failures/errors/skipped.
- [ ] `cd /workspace/Starwrought && ./gradlew runServer --no-daemon` (EULA already accepted in `run/`) reaches `Done`, logs `Loaded 4 handbook chapters and 18 entries`, zero data-pack errors, accepts `stop` cleanly.
- [ ] `RecipeReachabilityTest` demonstrably guards P0-1 (revert the bloom placement locally → red; restore → green).
- [ ] `LangParityTest` green: EN/DE identical key sets, every handbook entry body ≥120 chars in both.
- [ ] Wire-format commits (P0-4 SkyEvent) touch server sender + client receiver + join sync **in the same commit**.
- [ ] `HANDBUCH.md` + `README.md` feature table updated for: crater blooms, Herald attack mechanics, umbral ambience, and (if P1-1 lands) the Zenith perk.
- [ ] `STARWROUGHT_VERIFY.md` re-run and updated with the new test count and server-boot line.
- [ ] Client-visual items (P0-4/5, ability FX) that cannot be GPU-verified headlessly are listed in the verify doc as "requires graphical client" — do **not** claim visual verification the runner can't perform.
