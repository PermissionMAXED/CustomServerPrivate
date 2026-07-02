# Handoff — 2026-06-30 (exit-softlock / bot-count / stutter session)

## Currently deployed (verified live)

**AMP server** (`ark.atomi23.de:5055`) — `BapCustomServer.dll` md5 `5a3c747149592e1274a4ae76f5e7c9f5`, health `ok:true`:
- Map rotation `[1,2,3,4]` per match — **confirmed working by user**.
- Medusa ability slot-0 damage = **80** (was 120) — in `medusa.json` on host.
- Matchmaking config: `MaxPlayers=32`, `BotCount=20`, `BotDifficulty=3 (Expert)`, `MaxTeams=32`,
  `BotTeams=20`, `MaxBotCount=32`, `DefaultBotCount=0`, `EnabledGameModeIdsCsv="3,4"`. **Config is correct.**
- Post-match auto-requeue suppression (LobbyService.cs): one-shot flag `_suppressNextReadyAfterMatch`
  (armed at both match-start sites, keyed by accountId) + 30s `_postMatchReturnUtc` window +
  `returningFromMatch` checks; consumed in `SwitchReadyAsync` AND via
  `TryConsumePostMatchRequeueSuppression` on the HTTP `/api/queue/join` path (Program.cs). Suppress
  block broadcasts SWITCH_READY_SUCCESS + SWITCH_CUSTOM_READY_SUCCESS + READY_UPDATED +
  MATCHMAKING_EXITED + MATCHMAKING_LEFT + CANCEL_MATCHMAKING_SUCCESS (all unready) to reset the lobby button.

**Client package** `artifacts\BAPBAP-CustomClient.zip` (full playable client, cleaned configs, ~474MB):
- `Mods/BapCustomServerMelon.dll` md5 `eaf325cf3fa61bae392abdb05a534724`
- `Mods/NetworkedCustomChar.dll` md5 `ad4fad5c211fd16dec4e1854811124c7`
- Mod fixes: overlay gated off in production mode; char-select dismiss targets ONLY
  `View_PreMatch_CharSelect` (never `UIPreMatch`) gated on `mirrorConnected`; AugmentDiag + HudProbe
  removed; cast-anim log capped; **HTTP per-poll body logging removed (this session's stutter fix)**.

## OPEN — not fixed / unverified

1. **Bot count = 8, not 20** (HIGH priority, NOT fixed). Server requests 20 correctly; the **dedicated
   game host caps bot-fill to the map's ~8 spawn points**. Server config CANNOT override this. Needs a
   Harmony patch INSIDE bapbap.exe (NetworkedCustomChar mod): raise `GameMode.SpawnAllBotsFill`
   `maxBotsToFill` cap + `GameManager.currentMaxBotTeams` to 20, AND pad `GameMode.spawnPoints` to >=32
   (prefer `GetSpawnPointsOnNavMesh()` over jitter to avoid stacking/invalid spawns). Gate behind
   `_dedicatedProcess` + an INI flag. **Risk: bot stacking / invalid geometry — needs a postfix count
   log + one single-client test before declaring done. User must greenlight (asked, awaiting answer).**

2. **Char-pick UI reappears on Exit-to-Lobby** (server fix deployed + passing xUnit test
   `WebSocket_AutoReadyAfterMatch_SuppressedAndStaysInLobby`, but USER STILL SEES IT). Root cause proven:
   the BAPBAP client auto-readies after a match → server re-queues. Suppression should now block it.
   **Need a FRESH client `MelonLoader/Latest.log` + AMP server log from an exit AFTER the `53f65cdd`
   deploy** — look for `Suppressed post-match auto-requeue for {AccountId} (flag=.. returning=.. window=..)`.
   If absent, the requeue is taking an un-guarded path. (User's prior failing logs PREDATE the fix.)

3. **Stutter / mini-standbild** — fixed THIS session (removed multi-KB HTTP body logging in
   `LocalReverseProxy.LogAllHttpTraffic`), client md5 `d2b0f9f2`. **NOT user-tested yet** — needs new
   client install.

4. **Augment UI "vanish→reappear→can't select"** (task #33). Only mod lever was the
   `augmentSelectWaitDuration` timer (reduced 30s→10s). NOT confident that's the root cause; not resolved.

5. **Medusa shown as Kitsu to other players/bots** (task #35). Not investigated. Likely a networked
   prefab/assetId resolution issue on the OBSERVING client (graft is local-player only).

## How to verify / deploy (per project memory)
- Server fixes: `dotnet publish CustomMatchServer -c Release -r linux-x64 --self-contained true`, zip the
  DLL, deploy via `tools/_amp-deploy-childapi.ps1 -Sid <AMP session> -ZipPath <zip>`, verify with
  `tools/_amp-checkfile.ps1`. AMP session token expires; user supplies a fresh one.
- Prefer DLL-only AMP hotfixes over full ZIPs.
- Verify headlessly via xUnit (`tests/BapCustomServer.Tests`, WebApplicationFactory + LaunchGameServers=false).
  **Do NOT spam the live match harness** (opens real game windows). Visual/HUD success = user's eyes only.
- NEVER hotfix the package `appsettings.json` without reconciling vs base `CustomMatchServer/appsettings.json`
  (stale copy reverted Warmup mode + bot count twice this session).

## Session note

## Continuation - 2026-07-01 (Codex local-client verification)

**Char-pick UI reappears on Exit-to-Lobby: FIXED locally and visually verified.**

- Client fix is in `BapCustomServerMelon/CustomServerMod.cs`:
  - `OnUpdate` now calls `MonitorMatchDisconnectAndCleanPreMatchUi()` every frame.
  - The monitor arms an 18s cleanup window when the Mirror/GameNetworkManager match connection drops.
  - During that short post-match window it runs `TryDismissStalePreMatchCharSelectUi()`.
  - Cleanup now also calls `ForceCloseStalePreMatchParents()` for stale `UIPreMatch` parents, then removes stale child `View_PreMatch_CharSelect` objects.
- Built with `dotnet build BapCustomServerMelon/BapCustomServerMelon.csproj -c Release`.
- Final installed DLL md5:
  - `Spiel/Battleroyalebuild/Mods/BapCustomServerMelon.dll` = `D8054E4E6A0E7A8B53D32F570C3B5779`
  - `BapCustomServerMelon/bin/Release/net6.0/BapCustomServerMelon.dll` = `D8054E4E6A0E7A8B53D32F570C3B5779`
  - `BapCustomServerMelon/dist/BapCustomServerMelon.dll` = `D8054E4E6A0E7A8B53D32F570C3B5779`
- Correct client launch was verified by WMI before testing:
  `C:\Users\Administrator\Downloads\CustomServer\Spiel\Battleroyalebuild\bapbap.exe`
  (NOT Steam).
- Live repro/proof:
  - Final `D8054E4E6A0E7A8B53D32F570C3B5779` client joined lobby `WLKQHC`.
  - Matchmaking produced real `QUEUE_MATCHED` and `GAME_STARTED` events for game
    `matchmaking-20260701095707-6763` on `ark.atomi23.de`.
  - Character select appeared only for the match-found phase, then the client loaded into the match.
  - Used the normal in-game menu path `Exit Match` and confirmed `EXIT`.
  - Final Computer Use screenshot showed normal lobby with `READY` button and no char-select overlay.
  - Client log markers after exit:
    - `[PreMatchCleanup-DIAG] Armed stale PreMatch cleanup for 18s (GameNetworkManager client disconnect).`
    - `[PreMatchCleanup-DIAG] Armed stale PreMatch cleanup for 18s (Mirror match connection dropped).`
    - `[PreMatchCleanup] Dismissed post-match UI on 'MainScene': lobbyMatch=7 uiPreMatchClosed=0 charViews=0 parents=0.`
- Server health during the test: `http://ark.atomi23.de:5055/health` returned `ok:true`, release
  `medusa-bugfix-20260630`, prewarm `ready:true`.
- xUnit verification after the code change:
  `dotnet test tests/BapCustomServer.Tests/BapCustomServer.Tests.csproj -c Release --no-restore`
  passed `375/375`.

Remaining unrelated open items from above (bot count cap, augment UI, Medusa seen as Kitsu by observers)
were not changed in this continuation.

## Continuation - 2026-07-01 (Codex follow-up: lobby top UI/FPS + UI patch stats)

**Follow-up fix installed locally.** The previous `D8054...` client proved the char-select overlay could be removed,
but the proof log also showed the cleanup was too broad:

- Bad marker from the previous proof:
  `[PreMatchCleanup] ... lobbyMatch=7 uiPreMatchClosed=0 charViews=0 parents=0`
- That meant the cleanup deactivated/closed `UILobbyMatchCharacterSelectPage` objects even when no real
  `View_PreMatch_CharSelect` was visible. The user then saw the normal lobby top UI missing and low FPS.

Changes now in `BapCustomServerMelon/CustomServerMod.cs`:

- Removed the repeating 15s stats log:
  `UI patch stats: EnsureLobbyCharIdsPrefix called=50 filled=0`
- Throttled stale lobby queue recovery from every 2s to every 5s.
- Reworked post-match UI cleanup:
  - Real in-match PreMatch UI is still force-closed through `UIPreMatch`/`View_PreMatch_CharSelect` cleanup.
  - Lobby-owned match character-select pages are closed only through their own close methods.
  - The destructive `pageGo.SetActive(false)` on `UILobbyMatchCharacterSelectPage` was removed because it can
    remove normal lobby layout/top UI state.
  - New cleanup log uses `lobbyPageCloseCalls=...`; the old `lobbyMatch=...` marker is gone.

Installed final local client DLL md5:

- `BapCustomServerMelon/bin/Release/net6.0/BapCustomServerMelon.dll` =
  `2A687ACA71B89626598F4B6C574D73C0`
- `Spiel/Battleroyalebuild/Mods/BapCustomServerMelon.dll` =
  `2A687ACA71B89626598F4B6C574D73C0`
- `BapCustomServerMelon/dist/BapCustomServerMelon.dll` =
  `2A687ACA71B89626598F4B6C574D73C0`

Verification performed:

- `dotnet build BapCustomServerMelon/BapCustomServerMelon.csproj -c Release` passed.
- `dotnet test tests/BapCustomServer.Tests/BapCustomServer.Tests.csproj -c Release --no-restore` passed
  `375/375` after the final DLL change.
- Live local-client verification used only:
  `C:\Users\Administrator\Downloads\CustomServer\Spiel\Battleroyalebuild\bapbap.exe`
  and WMI confirmed that exact `ExecutablePath` (not Steam).
- On a fresh visible lobby run, the top lobby navigation was visible again and there was no char-select overlay.
- After waiting beyond the old 15s spam interval, client log counts were:
  `UI_PATCH_STATS_COUNT=0`, `LOBBYMATCH_CLEANUP_COUNT=0`.
- A 5174 local-server visible test reached a real matchmaking match:
  `GAME_STARTED` for `matchmaking-20260701103122-1036`, then server-side `Game ended`.
  The visible client stayed in the match scene after server-side end/manual exit in that WARMUP test, so this
  specific 5174 run did not produce a final return-to-lobby screenshot. Treat that as a separate match-exit
  return issue if it reproduces outside WARMUP. It did confirm the new spam removal and that no old
  `lobbyMatch=` cleanup marker is emitted.

Important next-test note:

- Do **not** start via Steam. Use `Start-Process -FilePath
  C:\Users\Administrator\Downloads\CustomServer\Spiel\Battleroyalebuild\bapbap.exe -WorkingDirectory
  C:\Users\Administrator\Downloads\CustomServer\Spiel\Battleroyalebuild` and verify the WMI `ExecutablePath`.
