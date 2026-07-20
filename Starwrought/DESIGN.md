# Starwrought — Design Lock (Fabric 1.21.9)

**Pitch:** Celestial tech-magic expansion. Chase aurora starfalls, harvest star shards, attune to Wolf/Lyra/Anvil, forge Starsteel → Voidglass, defeat the Herald of the Hollow Star. Visual identity: **Prismbreak** (shattered light on voidglass — indigo/cyan/gold).

## Systems to ship

### Common / Server
- Items: Star Shard, Astrolabe, Constellation Charts×3, Starsteel set, Phase Flare, Comet Bow, Wayband, Codex, Hollow Residue, Zenith Core, Glimmer Dust/Petals
- Blocks: Meteoric Stone/Core, Resonance Altar, Star Forge, Lumen Lantern, Lumen Spire, Voidglass, Hollow Beacon, Astral Bloom crop
- Events: Aurora Night + Starfall meteors; Umbral Night + Hollow Stalkers
- Attunements: Wolf / Lyra / Anvil (levels 1–5, cooldowns server-auth)
- Boss: Herald of the Hollow Star (3 phases, shard-shell renderer)
- Handbook data + unlock attachments + networking
- Advancements + recipes

### Client
- Prisma particle core, ribbon trails, lightning arcs, shockwaves, fake bloom
- Trauma camera + FOV kick
- Ability HUD + damage vignette
- Aurora sky ribbons + lumen beams
- Codex Arcana screen (tabs, search, page turn FX, unlocks)
- German + English lang

### Tests
- JUnit for attunement math, unlock evaluation, event scheduling, palette helpers
