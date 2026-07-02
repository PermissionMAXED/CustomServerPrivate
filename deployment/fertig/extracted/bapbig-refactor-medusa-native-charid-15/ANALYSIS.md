# Medusa Integration — Code Analysis

## A) Native part (KEEP) — `MedusaMod.cs`
- `TryRegisterMedusa`: clones Kitsu `CharacterConfiguration` → "Medusa" charId 15, appends to `UICharactersConfiguration._characters` + `_lobbyCharacters` (the roster), then `EnsureMedusaPrefabRegistered`, `MakeRosterAvailable`, `MoveMedusaIntoVisibleMatchSlot`, `TuneCharAbilities`, `TryInjectPhrases`.
- `EnsureMedusaPrefabRegistered` / `RegisterPrefab`: `Instantiate(Kitsu prefab)` → `Char_Medusa`, `GraftMedusaVisual` (bundle visuals/material/animator), `TryConfigureMirrorPrefab` (Mirror NetworkIdentity asset `0x4D454455`), writes `GameNetworkManager.characterPrefabsByCharId[15]`, `TryAddSpawnPrefab` (NetworkManager.spawnPrefabs).
- Selectability patches (`CharacterIsSelectable/Unlocked/InRotation`, `GetCharacterListingIndexFromCharId`, available-id population), ability-UI, native VFX + Kitsu-VFX suppression, visibility repair (`EnsureLiveMedusaEntity`).
→ This is exactly how you add a runtime-native modded character to an IL2CPP Unity game. **Verified live:** `Char_Medusa` Mirror-registered, `serverActive=True`, 16th selectable card in the in-match grid.

## B) Force scaffolding (REMOVE) — the "spam" + the Skinny bug
- `ForcePlayerMedusaChar` / `ForceSelectedMedusaPlayers` — overwrite `player.charId`.
- `NormalizeQueueMatchedMedusaSelections` — overwrites `playerData.charId` in the qmd.
- `RecordNonMedusaSelection` + `RestoreRecordedNonMedusaPlayerChar` (+ `ShouldRespectRecordedNonMedusaIntent`) — **this was the root cause of "spawn as Skinny/wrong char"**: it overwrote the player's in-match selection with the originally-recorded qmd char.
- `MaybeAutoSelectMedusa` — auto-selects Medusa via launch flag.
- `PlayerManager.OnCharacterChanged` force.

## C) Why the forcing existed
Insurance that `charId=15` survives the Client→Server→Assign→Spawn pipeline, plus auto-select for automated tests. Side effect: it overwrote non-Medusa selections → the Skinny bug, which then needed the record/restore band-aid (more forcing).

## D) Does the native flow work without forcing? — YES (proven)
Live dedicated-server logs show non-Medusa selections (Chuck=2, Anna=1, Rocky=14) flow **natively** through `PreMatchManager.AssignCharacters` → `GameMode.SpawnPlayerChar` to spawn (`tracked updated non-Medusa selection charId=N` → `connected successfully charId=N`). Medusa (15) is just another registered charId on the same path. So the forcing is **redundant** (and was harmful). Removing it = "komplett nativ".

## Refactor = remove B, keep A. See HANDOFF.md §3 for the exact symbol-by-symbol spec.
Edge case: if the networked `TrySelectCharacter`/`CmdTrySelectCharacter` rejects 15 server-side, make the *selection* accept 15 (small prefix/transpiler) instead of re-introducing charId forcing. Verify with the live-log signature in HANDOFF.md §6.
