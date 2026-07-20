# Starwrought verification

Verified on 2026-07-20 with Java 21, Minecraft 1.21.9, Fabric Loader 0.19.3,
Fabric API 0.134.1+1.21.9, and Fabric Loom 1.17.16.

## Build and tests

Command:

```bash
./gradlew clean build test --no-daemon
```

Result: **PASS**

- 6 JUnit tests passed
- 0 failed, 0 errors, 0 skipped
- Remapped release JAR: `build/libs/starwrought-1.0.0.jar`
- Hollow Stalker and Herald client entity renderers compile and are registered

The build reports only upstream/deprecation notices, including Fabric's
deprecated `EntityRendererRegistry` overload; there are no compilation or test
failures.

## Dedicated-server smoke

Command:

```bash
./gradlew runServer --no-daemon
```

Result: **PASS**

- The EULA was accepted in the ignored Loom `run/` directory.
- Fabric loaded 43 mods, including Starwrought 1.0.0.
- Starwrought common systems initialized.
- Four handbook chapters and 15 entries loaded.
- Minecraft reached `Done (0.234s)!` on port 25565.
- The server accepted `stop`, saved all dimensions, and Gradle exited with
  `BUILD SUCCESSFUL`.

## Remaining CI limitation

The cloud runner verified common code, client compilation, unit tests, resource
remapping, and headless dedicated-server startup. It has not interactively
validated GPU-dependent client presentation such as entity models, particles,
aurora rendering, HUD composition, camera trauma, or shockwave/ribbon effects;
those require a graphical Minecraft client.
