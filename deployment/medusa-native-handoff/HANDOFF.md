# Medusa Native Integration — Handoff for another AI

Author: prior AI session. Date: 2026-06-10.
Goal: make **Medusa (charId 15)** a *fully native* selectable character in the BAPBAP custom-server stack — selected → assigned → spawned through the **vanilla** `Select → Assign → Spawn` path exactly like the other 15 chars — by **removing the per-spawn "force" scaffolding**, while **keeping the one-time native registration** (prefab/roster/Mirror/abilities/VFX). Also keep the already-fixed "spawn as Skinny / wrong char" bug fixed.

This is a **code refactor task in one file**: `source/medusa-mod/MedusaMod.cs`. You edit it, return it; the human/orchestrator builds + deploys + live-tests.

---

## 0. TL;DR of the task

In `MedusaMod.cs`:
- **REMOVE / neutralize** the runtime char-id **forcing**: `ForcePlayerMedusaChar`, `ForceSelectedMedusaPlayers`, the qmd char-id override in `NormalizeQueueMatchedMedusaSelections`, the record/restore clobber (`RecordNonMedusaSelection` + `RestoreRecordedNonMedusaPlayerChar` + `ShouldRespectRecordedNonMedusaIntent`), `MaybeAutoSelectMedusa`, and the `PlayerManager.OnCharacterChanged` force.
- **KEEP** all the **native registration**: `TryRegisterMedusa`, `EnsureMedusaPrefabRegistered` / `RegisterPrefab`, `GraftMedusaVisual`, `TryConfigureMirrorPrefab` / `TryAddSpawnPrefab`, roster injection (`_characters` / `_lobbyCharacters` append, `MakeRosterAvailable`, `MoveMedusaIntoVisibleMatchSlot`), the `CharacterIsSelectable/Unlocked/InRotation` + `GetCharacterListingIndexFromCharId` patches, `TuneCharAbilities`, ability-UI patches, native VFX patches, Kitsu-VFX suppression, and visibility repair (`EnsureLiveMedusaEntity`).
- The result: selecting any char (incl. Medusa) flows natively. Net effect of removing the forcing on a player who **selects Medusa**: the vanilla `PreMatchManager.AssignCharacters` sets `player.charId=15` from `_currentSelectedCharacters`, and `GameMode.SpawnPlayerChar` spawns `characterPrefabsByCharId[15]` (= `Char_Medusa`). No mod override needed.

**Risk to watch:** the *only* reason the forcing might be load-bearing is if the game’s networked `PreMatchManager.TrySelectCharacter` / `PlayerPreMatch.UserCode_CmdTrySelectCharacter` **rejects charId 15** server-side (out of the original 0..14 range). If so, do **not** re-introduce charId forcing — instead make the *selection itself* succeed natively (e.g., a tiny prefix/transpiler so `TrySelectCharacter` accepts 15, or ensure the available-id list/range check includes 15). Validate via the live-log signature in §6.

---

## 1. Verified current state (what is already true on the live server)

- Live AMP server: `http://ark.atomi23.de:5055`. The dedicated game server runs the **same** game (`bapbap.exe`) under Wine/Xvfb; the Medusa mod (`BAPBAP.Medusa.dll`) and `BapCustomServerMelon.dll` are loaded in **both** the player client and the dedicated server. **Char assignment + spawn are authoritative on the dedicated server**, so a server-side mod change fixes all clients.
- **The "spawn as Skinny / wrong char" bug is FIXED and verified live (3 real matches).** Root cause was `RestoreRecordedNonMedusaPlayerChar` overwriting the player's in-match selection with the originally-recorded qmd char. The current `MedusaMod.cs` in this package already contains the interim fix (`ShouldRespectRecordedNonMedusaIntent` now respects the live selection; helper `UpdateRecordedNonMedusaSelectionValue`). **Your refactor should remove this whole record/restore subsystem entirely — it then can't clobber anything.**
- Live-log proof of the fixed behavior (per match): `qmd charId=0 → tracked updated non-Medusa selection … charId=N → connected successfully charId=N` (player spawns as the **selected** char). Pre-fix it logged `restored recorded … old=N new=0` (the bug).
- **Medusa is already natively registered & selectable** (verified): dedicated server logs `Char_Medusa` Mirror asset `0x4D454455`, `NetworkPrefabPool serverActive=True`, `made 16 characters available`; and Medusa appears as the **16th selectable card** (bottom-right, green/snake) in the in-match char-select grid (2×8). qmd `available=…,15,…`.
- Character id ↔ name (server `CharacterCatalog`, see `source/server/CustomServerOptions.cs`): `0 Kitsu, 1 Anna, 2 Chuck, 3 Sashimi, 4 Kiddo, 5 Zook, 6 Skinny, 7 Froggy, 8 Teevee, 9 Sofia, 10 Jiro, 11 Bishop, 12 Celeste, 13 Kate, 14 Rocky, 15 Medusa`.
- Current live release label: `medusa-v1728-charsel-time`; live `BAPBAP.Medusa.dll` SHA256 = `AADDB5E8E5452833AED66646EE4516797C504031FDA1A2E21F6056541A0CCC32` (the clobber-fix build). After your refactor this DLL hash will change again.

---

## 2. Architecture of the char flow (where things happen)

Client (player) and the dedicated game server both run the Medusa mod via MelonLoader. The authoritative pipeline (server side):

1. **Lobby**: client picks a char → `BapCustomServerMelon` relays it to the ASP.NET custom server (`SWITCH_CHAR`). On ready/queue it becomes the queue/qmd `charId`.
2. **Match start**: custom server builds `QueueMatchedData` (qmd) with each player's `charId`, bootstraps the dedicated server (`/setup-game`, `/queue-matched`).
3. **In-match char-select (~20s)**: client sends `PlayerPreMatch.CmdTrySelectCharacter(player, charId)` → server stores it in `PreMatchManager._currentSelectedCharacters[playerId]`.
4. **Assign**: `PreMatchManager.AssignCharacters()` reads `_currentSelectedCharacters` → writes `player.charId` (+ `NetworkcharId`).
5. **Spawn**: `GameMode.SpawnPlayerChar(playerManager, pos)` spawns `GameNetworkManager.characterPrefabsByCharId[player.charId]` via Mirror.

The Medusa mod **registers** `characterPrefabsByCharId[15] = Char_Medusa` (Mirror asset `0x4D454455`) + adds a `CharacterConfiguration` (charId 15) to `UICharactersConfiguration._characters/_lobbyCharacters`. Once registered, charId 15 is just another value flowing through steps 3–5.

See `source-mapping/` for the decompiled native classes (`PreMatchManager`, `PlayerPreMatch`, `GameMode`, `GameNetworkManager`, `PlayerManager`, `EntityManager`, `CharAbilities`, `UICharactersConfiguration`, `CharacterConfiguration`, `UILobbyCharacterSelectPage`, `UILobbyMatchCharacterSelectPage`, `CharSelectController`).

---

## 3. EXACT refactor spec (in `source/medusa-mod/MedusaMod.cs`)

All symbols below are in the single `MedusaMod` class. Reference by **name** (line numbers drift; use them only as a hint). Keep everything compiling for net8.0 / MelonLoader / Il2CppInterop (see csproj). Preserve `try/catch` defensive style and logging.

### 3.1 KEEP (do not touch — this is the legitimate native integration)
- `TryRegisterMedusa` (~line 4600): clones Kitsu `CharacterConfiguration` → "Medusa" charId 15, appends to `_characters`/`_lobbyCharacters`, calls `EnsureMedusaPrefabRegistered`, `MakeRosterAvailable`, `MoveMedusaIntoVisibleMatchSlot`, `TuneCharAbilities`, `TryInjectPhrases`.
- `EnsureMedusaPrefabRegistered` (~5390) + `RegisterPrefab` (~5650): clone Kitsu prefab → `Char_Medusa`, `GraftMedusaVisual`, `TryConfigureMirrorPrefab`, write `characterPrefabsByCharId[15]`, `TryAddSpawnPrefab`.
- `GraftMedusaVisual`, `TryConfigureMirrorPrefab`, `TryAddSpawnPrefab`, `MakeRosterAvailable`, `MoveMedusaIntoVisibleMatchSlot`, `CloneConfig`, `PickBase`, `Append`, `AppendLobby`.
- All `UILobbyCharacterSelectPage` / `UILobbyMatchCharacterSelectPage` patches that make Medusa **selectable/visible**: `CharacterIsSelectable`, `CharacterIsUnlocked`, `CharacterIsInRotation`, `GetCharacterListingIndexFromCharId`, `UpdateAvailableCharactersData`, `Build/Initialise/UpdateData` population.
- Ability/VFX: `CharAbilities.PreAwake`/`SetCastAbility` patches, `ApplyMedusaAbilityRuntimeUi`, the `*Ability.Shoot` `TrySuppressInheritedKitsuShoot` patches, native FX loading from `UserData/Medusa/medusa.bundle`.
- Visibility: `EnsureLiveMedusaEntity` and the `EntityManager.Start`/`OnStartClient` patches that call it. (Keep — it repairs renderers/animator; it does NOT set charId.)
- Mirror registration patches: `GameNetworkManager.Awake/OnStartServer/OnServerQueueMatched/OnServerMatchAddTeams` calling `EnsureMedusaPrefabRegistered(...)`. Keep the `EnsureMedusaPrefabRegistered` calls. (In `OnServerQueueMatched` you only remove the charId-forcing call, see 3.2.)
- `GameNetworkManager.GetCharacterBotPrefab` prefix (bot Medusa→base fallback): keep (bots can't be Medusa; harmless).

### 3.2 REMOVE / NEUTRALIZE (the "force/spam" + clobber scaffolding)

Make these no-ops (delete bodies / early-return) and remove their call-sites in the Harmony patches:

1. **`ForcePlayerMedusaChar(player, charId, source)`** (~12288): the central charId-overwriter (sets `player.charId`, `NetworkcharId`, `skinAssetId`, `primaryCharManager.charId`, calls `OnCharacterChanged`). Remove it and **all call sites**:
   - `PlayerPreMatch.CmdTrySelectCharacter` prefix / `UserCode_CmdTrySelectCharacter` postfix
   - `PlayerPreMatch.UserCode_CmdTryLockCharacter` postfix, `SetPlayerCharacter` postfix, `SetTeammateCharacter` postfix
   - `PreMatchManager.TrySelectCharacter` postfix
   - `GameMode.SpawnPlayerChar` prefix & postfix (keep the `EnsureMedusaPrefabRegistered(...)` + `EnsureLiveMedusaEntity(...)` calls there; drop the force/restore)
   - `PlayerManager.OnCharacterChanged` postfix (remove the whole force)
2. **`ForceSelectedMedusaPlayers(manager, source)`** (~12237) + the `PreMatchManager.AssignCharacters` prefix/postfix that call it → remove (let vanilla AssignCharacters run unmodified).
3. **`NormalizeQueueMatchedMedusaSelections(qmd, source)`** (~11186): remove the parts that **write** `playerData.charId` (the `playerData.charId = requestedCharId` / `= CurrentMedusaId()` branches) and the `RecordNonMedusaSelection` calls. If anything in `OnServerQueueMatched` still needs to run, keep ONLY `EnsureMedusaPrefabRegistered` + (optionally) `ForceQueueMatchedDataAvailable`'s *available-id list* expansion (do **not** change any player's charId).
4. **Record/restore clobber** — remove entirely: `RecordNonMedusaSelection` (~11353), `TryGetRecordedNonMedusaSelection`, `ShouldRespectRecordedNonMedusaIntent`, `ClearRecordedNonMedusaSelection`, `RestoreRecordedNonMedusaPlayerChar` (~11489), `UpdateRecordedNonMedusaSelectionValue`, and the dicts `_originalNonMedusaCharByPlayerId` / `_originalNonMedusaCharByAccountId` (~1827). Remove their call-sites (they're inside the functions removed above and in `UpdatePreMatchSelectionState`).
5. **`MaybeAutoSelectMedusa(source)`** (~11986) + `PlayerPreMatch.Initialize` postfix calling it → no-op (no auto-selecting Medusa).
6. `UpdatePreMatchSelectionState` (used only by `ForcePlayerMedusaChar`): remove with it, or keep but it becomes dead — delete to avoid warnings.

### 3.3 If native selection of 15 is rejected (only if §6 testing shows it)
Keep forcing OUT. Instead make the **selection accept 15**:
- Check `PreMatchManager.TrySelectCharacter` / `PlayerPreMatch.UserCode_CmdTrySelectCharacter__PlayerManager__Int32` (decompiled in `source-mapping/`) for a range/available check. Add a minimal Harmony prefix or transpiler so charId 15 passes the validity check (e.g., temporarily treat 15 as valid). This is "make it selectable", not "force it onto the player".
- The available-id list already includes 15 (qmd `available=…,15`), and the UI lets you click Medusa, so this is likely unnecessary — verify first.

---

## 4. Native game API reference (key fields/methods — confirm against `source-mapping/`)
- `GameNetworkManager.characterPrefabsByCharId : GameObject[]` — index = charId. (decompiled: `source-mapping/decompiled/.../Network/GameNetworkManager.cs`)
- `PreMatchManager._currentSelectedCharacters : Dictionary<int playerId, int charId>`; `PreMatchManager.AssignCharacters()`, `TrySelectCharacter(PlayerManager, int requestedCharId)`.
- `PlayerPreMatch.CmdTrySelectCharacter(PlayerManager, int)`, `UserCode_CmdTrySelectCharacter__PlayerManager__Int32(PlayerManager, int)`, `SetPlayerCharacter(int)`, `SetTeammateCharacter(PlayerManager,int)`, `CmdTryLockCharacter(PlayerManager)`.
- `PlayerManager.charId`, `PlayerManager.NetworkcharId`, `PlayerManager.skinAssetId`, `PlayerManager.playerId`, `PlayerManager.accountId`, `PlayerManager.primaryCharManager : EntityManager`, `OnCharacterChanged(int old,int new)`. `KitsuCharId = 0`.
- `GameMode.SpawnPlayerChar(PlayerManager, Vector3)`.
- `EntityManager.charId`, `NetworkcharId`.
- `UICharactersConfiguration.Characters / _characters / _lobbyCharacters : CharacterConfiguration[]`; `CharacterConfiguration.charId`, `.name`.
- `QueueMatchedData.players : List<MatchmakingPlayerData>`; `MatchmakingPlayerData.charId`, `.skinAssetId`, `.playerId`, `.accountId`.
- Medusa identity: charId `15`, Mirror asset id `0x4D454455`, `skinAssetId=-1`, base clone = Kitsu (charId 0).

---

## 5. Build instructions
- Project: `source/medusa-mod/BAPBAP.Medusa.csproj` (net references to the game/Il2Cpp interop assemblies). In the real workspace it builds with:
  `dotnet build C:\Users\Administrator\Downloads\BAPBAPModdingAPI\medusa-mod\BAPBAP.Medusa.csproj -c Release`
  → output `bin/Release/BAPBAP.Medusa.dll`.
- The csproj references Il2Cpp interop / game assemblies by HintPath into the local game install — those DLLs are NOT in this zip (huge). The other AI should produce the **edited `MedusaMod.cs`**; the orchestrator compiles it in the real environment. (If you want to self-check, you only need it to be syntactically valid C# against the API in §4 / source-mapping.)
- Expect ~1000 pre-existing `CS8600` nullable warnings from Il2Cpp interop — that's normal; target **0 errors**.

## 6. Deploy + live verification (orchestrator does this; cua = trycua/cua)
- Build full/minimal package + deploy: `tools/Build-MedusaHotfixZip.ps1` (86KB Medusa-only hotfix) then `tools/Invoke-AmpHotfixDeploy.ps1` (stops AMP app, uploads, MD5-verify, extracts to `/AMP/BapCustomServer/`, restarts). Confirm `/health` shows new release + new `medusaDllSha256`.
- Diagnostics: `tools/Get-LiveDiag.ps1` tails the dedicated-server + game logs (filtered for charId/Medusa/spawn).
- **Pass criteria (per real match, from the dedicated-server game log):**
  - Selecting a **normal** char N: log shows the player ends at `charId=N` (`connected successfully … charId=N`), NOT Skinny/0. (Already true with the clobber fix; must stay true.)
  - Selecting **Medusa**: `PlayerPreMatch … CmdTrySelectCharacter … charId=15` is accepted, `PreMatchManager.AssignCharacters` leaves `player.charId=15`, `GameMode.SpawnPlayerChar` spawns `Char_Medusa(Clone)`, client shows `[CodexVfx] Medusa` / `Medusa_Material_Native`. No `[Medusa] forced …` / `restored recorded …` lines should appear anymore.
  - Non-Medusa players are NEVER converted to Medusa; Medusa is NEVER auto-selected.
- **cua note (environment):** `cua-driver` (trycua/cua) drives the game via `launch_app` / `get_window_state --screenshot-out-file` / `click dispatch:"foreground"`. On this headless box it can only inject input when the game window holds the foreground (its UIAccess worker is ad-hoc-signed → denied). In-match the game holds foreground, so char-select clicks land; the 20s char-select + foreground intermittency make it flaky. Medusa is the bottom-right card in the 2×8 grid (≈(0.76·W, 0.88·H) in a 640×510 window). JSON args must be piped via stdin in PowerShell 5.1.

## 7. Manifest (what's in this zip)
- `HANDOFF.md` (this file), `ANALYSIS.md` (deeper analysis), `CONTEXT.md`/`MISSION.md`/`AI_HANDOFF.md` (prior project context).
- `source/medusa-mod/` — the mod to edit (incl. current `MedusaMod.cs` with the clobber fix).
- `source/server/` — `LobbyService.cs`, `CustomServerOptions.cs`, `Contracts.cs`, `Program.cs` (char flow on the ASP.NET side; context).
- `source/client-mod/` — `CustomServerMod.cs` (lobby char relay; context).
- `source-mapping/decompiled/` — relevant decompiled native game classes.
- `source-mapping/research/CHARACTERS_RESEARCH.md` — RE notes on characters.
- `tools/` — build/deploy/diagnostics/cua scripts.
- `STATE.md` + `deployment-info.json` + `health.json` — current live state/hashes.

Deliver back: the edited `source/medusa-mod/MedusaMod.cs` (and any new helper files). The orchestrator builds, deploys, and live-verifies per §6.
