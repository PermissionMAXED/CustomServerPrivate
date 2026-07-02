# BAPBAP Custom Map Editor (Unity project)

A real, shareable map editor for **BAPBAP Battle Royale** custom maps. You place
entities and spawn points as objects in a 3D scene, move/rotate them with Unity's
normal tools, and export the exact JSON the game's custom-map loader reads.

## What you need

- **Unity 2022.3.38f1** (install via Unity Hub — it's free). Any 2022.3.x will open it.
- That's it. No game install required to author maps, though you'll want the game
  to test the result.

## Open it

1. Open Unity Hub -> **Add** -> pick this `MapEditorUnity` folder.
2. Open the project (first import takes a minute).
3. In the menu bar: **BAPBAP -> Map Editor**.

## Make a map

1. In the editor window, click **Create New Map**. This drops a `BAP Map` object,
   a reference ground plane, and two starter spawn points into the scene.
2. Set the **Identity** (Map Id must be >= 5; shipped customs use 30-33), name, and
   in-match display name.
3. **Place things in the 3D scene:**
   - Pick an NPC from the dropdown and click **Add Entity**. It appears at the map
     center — drag it with the Move tool (W) and rotate with the Rotate tool (E).
   - Click **Add Spawn Point** for each team spawn, then position them.
   - To edit ground tiles, tick **Enable Tile Edits**, pick a tile id, **Add Tile**,
     and drag it onto a grid cell. Tiles snap to the grid on export.
4. Add **Zone Rounds** with the `+` button (the shrinking play-zone timing).
5. Click **Validate** to catch loader gotchas, then **Export to Game** (writes into
   the game's `UserData/CustomMaps/`) or **Export JSON...** to pick a location.

The **Move** tool gizmo, **Rotate** tool, scene grid, and per-object gizmos give you
true 3D placement. Entity/spawn world positions are read straight from their
transforms (relative to the `BAP Map` root, which sits at world origin = grid center).

## Edit an existing map

Click **Load Map JSON...** and pick any map file (e.g. one of the shipped
`customgauntlet.json`). It rebuilds the whole map as scene objects you can move
around, then re-export.

## Coordinate system (how the editor maps to the game)

- **Entities & spawns:** world units, centered on the `BAP Map` root. `y` is up.
  The root sits at world origin, which is grid cell center `(mapSize/2, mapSize/2)`.
- **Tiles:** integer grid cells `0..mapSize-1`. Cell `(24,24)` on a 48x48 map = world
  origin. Tile markers snap to the nearest cell on export.

## What the exported JSON contains

Matches the shipped maps exactly (field order and formatting). Top-level keys:
`mapId, name, displayName, bundleFileName, svPrefabName, clPrefabName,
baseSvResource, baseClResource, mapSettingsDisplayName, mapType, customZoneRounds,
excludeNavMeshFloor, excludeWaterPerimeter, mapSize, zoneRounds, enableTileEdits,
useLevelDataTileMutations, tileEdits, enableEntities, entities, spawnPoints, enabled`.

## Sharing maps

A finished map is a single `.json` file. Send it to anyone; they drop it into their
`UserData/CustomMaps/` folder. (If a map uses tile edits referencing custom prefab
ids beyond the safe Ground set, it relies on the base holder providing them.)

## Known-good content

- **NPCs:** `Npc_Boss_Chad`, `Npc_SlimeBoss_A`, `Npc_SlimeBoss_C`, `Npc_SlimeBoss_Ba`,
  `Npc_SlimeBoss_Bb`, `Npc_Roaming_Wolf`. Other names work only if present in the
  live game's entity palette.
- **Safe Ground tile ids:** 242-249 (grass/ground/floor in the base holder).

## Project layout

```
MapEditorUnity/
  Assets/BapMapEditor/
    Runtime/   BapMapData, BapJson, BapMapJson, BapMapPalette, BapMapValidator, BapMapMarkers
    Editor/    BapMapEditorWindow, BapMapSceneIO, BapMapSelfTest
```

The `Runtime` C# core has no UnityEngine dependency (except the marker
MonoBehaviours), so the JSON format is also verifiable outside Unity.

## Self-test

Headless verification (used during development):

```
Unity.exe -batchmode -nographics -quit -projectPath <this folder> \
  -executeMethod BapMapEditor.BapMapSelfTest.Run -logFile selftest.log
```

Exits 0 on success. It builds a map, round-trips it through JSON and scene IO,
loads a shipped map, and writes a sample.
