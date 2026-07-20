# Starwrought Client Status

## Implemented

- `StarwroughtClient` registers PRISMBREAK particles, H/R keybinds, S2C receivers, HUD layers, client ticks, and disconnect cleanup.
- Full-bright translucent `prisma_spark`, `prisma_shard`, and `hollow_mote` billboard particles with animated sprites, palette shifts, rotation, and size/fade curves.
- Particle-strip player/projectile trails, midpoint-displacement lightning, expanding impact shockwaves, predicted/synced aurora ribbons, and a spectacle director composing camera trauma, FOV kick, HUD flash, arcs, and shards.
- Camera/FOV mixins consume the decaying trauma state.
- Attunement charge/cooldown HUD, low-health vignette, damage flash, and cinematic ability flash.
- Searchable bilingual Codex Arcana screen with category tabs, lock state, page-fold reveal, UI motes, H-key/server-packet opening, unlock feedback, and an offline fallback catalog.
- Shared particle registration and small typed payload contracts integrated with the common initializer/networking code.
- English and German translations plus particle sprite definitions using vanilla atlas sprites.

## 1.21.9 compatibility notes

- Minecraft 1.21.9 replaced `SpriteBillboardParticle` with sprite-backed `BillboardParticle`; the custom particles use that current equivalent.
- Fabric 0.134.1 no longer exposes the legacy `WorldRenderEvents.AFTER_ENTITIES` API after world render-state extraction. Trails, arcs, rings, and aurora therefore use dense full-bright particle ribbons driven by client ticks, as allowed by the implementation brief.

## Verification

- `./gradlew compileClientJava compileJava --no-daemon` — **PASS**
- `./gradlew build --no-daemon` — **PASS**

The build produces the remapped mod JAR successfully. A live visual smoke test still requires launching a graphical Minecraft client.
