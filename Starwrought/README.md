# Starwrought

**Celestial tech-magic for Minecraft Fabric 1.21.9** — chase aurora starfalls, attune to constellations, forge Starsteel, and defeat the Herald of the Hollow Star.

Visual identity: **PRISMBREAK** (indigo → cyan → white-gold shattered light).

## Requirements

- Minecraft **1.21.9**
- Fabric Loader **≥0.17** (tested with 0.19.3)
- Fabric API **0.134.x+1.21.9**
- Java **21**

## Build

```bash
cd Starwrought
./gradlew build test
# JAR: build/libs/starwrought-1.0.0.jar
```

```bash
./gradlew runClient   # graphical client (needs display)
./gradlew runServer   # dedicated server smoke
```

## Feature overview

| Pillar | Content |
|--------|---------|
| Sky events | Aurora nights (~every 4), Umbral nights (~every 12), meteorite impacts |
| Materials | Star Shards, Glimmer Dust/Petals, Hollow Residue, Zenith Core |
| Crafting | Resonance Altar, Star Forge, Lumen Lantern/Spire, Voidglass, Hollow Beacon |
| Gear | Full Starsteel tools + armor, Comet Bow, Phase Flare, Wayband, Astrolabe |
| Attunements | Wolf / Lyra / Anvil — levels 1–5; Wolf/Lyra ultimate on **R**, Anvil forge bonuses |
| Threats | Hollow Stalkers, Herald of the Hollow Star (3 phases + PRISMBREAK FX) |
| Codex | In-game handbook (**H** or Codex item) with unlock progression, DE/EN |
| VFX | Prisma particles, trails, lightning, shockwaves, trauma camera, aurora sky, HUD |

Full player guide: [`HANDBUCH.md`](HANDBUCH.md)

## Design docs

- [`DESIGN.md`](DESIGN.md) — locked feature set
- [`COMMON_STATUS.md`](COMMON_STATUS.md) / [`CLIENT_STATUS.md`](CLIENT_STATUS.md) — implementation notes

## License

MIT — see `LICENSE`.
