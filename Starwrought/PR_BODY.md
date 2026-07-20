# Title: Starwrought — Celestial Tech-Magic Mod für Minecraft Fabric 1.21.9 (Sky Events, Attunements, Herald-Boss, PRISMBREAK VFX, Codex DE/EN)

## Zusammenfassung

Dieser PR fügt **Starwrought** hinzu — eine eigenständige Celestial-Tech-Magic-Mod für **Minecraft Fabric 1.21.9** (Java 21, Fabric Loader ≥ 0.17, Fabric API 0.134.x). Spieler jagen Aurora-Sternenfälle, ernten Star Shards, stimmen sich am Resonance Altar auf die Konstellationen Wolf/Lyra/Anvil ein, schmieden Starsteel-Ausrüstung in der Star Forge und stellen sich am Hollow Beacon dem dreiphasigen Boss **Herald of the Hollow Star**. Die visuelle Identität ist **PRISMBREAK**: zersplittertes Licht in Indigo → Cyan → Weißgold.

Die Mod ist vollständig lauffähig: sauberer Gradle-Build, grüne JUnit-Suite und ein verifizierter Dedicated-Server-Start (1.487 Rezepte, 1.578 Advancements, 4 Codex-Kapitel mit 15 Einträgen fehlerfrei geladen).

## Arbeitsweise (Subagent-Flow)

Die Entwicklung lief in einem zweistufigen Subagent-Flow: **Ideen, Design-Lock und Review** über **Fable-5-max-thinking**, die **Implementierung** über **GPT-5.6-sol-max-fast**. Die Ergebnisse der Review-Runde sind in `REVIEW_FABLE.md` dokumentiert; das festgeschriebene Feature-Set steht in `DESIGN.md`.

## Features

- **Sky Events** — Seeded, persistenter Nacht-Scheduler: **Aurora-Nächte** (~jede 4. Nacht) mit Meteoriten-Einschlägen (Meteoric Stone + leuchtender Meteorite Core) nahe der Spieler; **Umbral Nights** (~jede 12. Nacht, kollisionfrei zur Aurora) mit Hollow-Stalker-Spawns. Das **Astrolabe** zeigt die nächste Himmelsnacht und peilt nahe Cores an.
- **Attunements** — Wolf / Lyra / Anvil über Constellation Charts am **Resonance Altar**; Stufen 1–5 mit thematischer Progression (Nachtkämpfe, Reisen, Schmieden). Server-autoritative Ultimates auf **R**: Wolf **Pack Howl** (AoE Strength+Speed), Lyra **Comet Dash** (Blink); Anvil beschleunigt passiv die Star Forge.
- **Ausrüstung** — Vollständiges **Starsteel**-Set (Tools + 4 Rüstungsteile mit korrekten 1.21.9 `ToolMaterial`/`ArmorMaterial`), gefertigt in der `StarForgeBlockEntity` (Aurora verdoppelt das Tempo); dazu **Comet Bow**, **Phase Flare** (Positionstausch), **Wayband** (Recall zur Lumen Spire) und **Astrolabe**. 24 Rezepte, 4-stufige Advancement-Kette.
- **Boss & Gegner** — **Herald of the Hollow Star**: Beschwörung am Hollow Beacon, 240 HP, Bossbar mit Himmelverdunkelung, drei HP-gesteuerte Phasen (Farbwechsel, Teleport-Jagden, Stalker-Verstärkung), Prisma-Shard-Orbit, Shockwave-Broadcasts und garantierter **Zenith Core**-Drop. Dazu teleportierende **Hollow Stalkers** mit Hollow-Residue-Loot; beide mit eigenen Client-Entity-Renderern.
- **PRISMBREAK VFX** — Drei eigene Full-Bright-Billboard-Partikel (Spark/Shard/Mote) mit Palette und Ease-Kurven, Ribbon-Trails, prozedurale Blitze (Midpoint Displacement), expandierende Shockwave-Ringe, `SpectacleDirector` mit Trauma-Kamera + FOV-Kick über Mixins, Aurora-Himmelsbänder sowie Attunement-HUD mit Vignette und Damage-Flash.
- **Codex-Handbuch (DE/EN)** — Datengetriebenes Ingame-Handbuch (**H** oder Codex-Item): 4 Kapitel / 15 Einträge als JSON mit `has_item`/`advancement`/`manual`-Unlocks, S2C-Sync, Kategorie-Tabs, Live-Suche, Page-Fold-Animation. Sprachdateien vollständig parallel in **Deutsch und Englisch**; Spielerhandbuch zusätzlich als `HANDBUCH.md`.

## Build & Test

```bash
cd Starwrought && ./gradlew build test
```

- Ergebnis-JAR: `Starwrought/build/libs/starwrought-1.0.0.jar`
- Optional: `./gradlew runServer` für den Dedicated-Server-Smoke (headless), `./gradlew runClient` für den grafischen Client (benötigt Display).

Verifikationsdetails (Build, 6 grüne JUnit-Tests, Server-Boot bis `Done`) stehen in `STARWROUGHT_VERIFY.md`.

## Bekannte CI-Einschränkung

Der Cloud-Runner hat Common-Code, Client-Kompilierung, Unit-Tests, Resource-Remapping und den headless Dedicated-Server-Start verifiziert — **aber keinen grafischen Client-Smoke**: GPU-abhängige Darstellung (Entity-Modelle, Partikel, Aurora-Rendering, HUD-Komposition, Kamera-Trauma, Shockwave-/Ribbon-Effekte) wurde nicht interaktiv geprüft. Dafür ist ein grafischer Minecraft-Client mit Display erforderlich.
