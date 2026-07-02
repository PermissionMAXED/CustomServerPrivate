# C6 — Persistent Match Remnants & Incomplete Teardown

Read-only research. Scope: persistent match remnants after leaving (red outline / enemy outline / targeting) and incomplete teardown across the Medusa mod, the match server, and the client melon. No code changed.

Files inspected (full or targeted):
- `C:\Users\Administrator\Downloads\BAPBAPModdingAPI\medusa-mod\MedusaMod.cs` (read in full)
- `C:\Users\Administrator\Downloads\CustomServer\CustomMatchServer\LobbyService.cs`
- `C:\Users\Administrator\Downloads\CustomServer\CustomMatchServer\GameServerProcessManager.cs`
- `C:\Users\Administrator\Downloads\CustomServer\CustomMatchServer\ResourceMonitorService.cs`, `MatchmakingHostedService.cs`, `Program.cs`
- `C:\Users\Administrator\Downloads\CustomServer\BapCustomServerMelon\CustomServerMod.cs`
- `C:\Users\Administrator\Downloads\BAPBAPModdingAPI\BAPBAPModAPI\reverse-engineering\dumps\latest\medusa\ABILITY_MANIFEST.md` + `_so_classes.json` (petrify SO data)

---

## 1. MedusaMod.cs has NO teardown / OnDestroy / match-end / leave handler at all

`MedusaMod` (`BAPBAP.Medusa`, derives from `ModBase`) defines `OnRegistered()` but **no `OnDestroy`, `OnDeregister`, `OnUnregister`, scene-unload, match-end, or leave hook anywhere in the file** (confirmed by full read + grep). Nothing is ever undone.

Evidence — two perpetual timers started in `OnRegistered` and never stopped:
```
MedusaMod.cs:1529   TimerAPI.Every(1f, (Action)PollOnce, (ModBase)(object)this);
MedusaMod.cs:1530   TimerAPI.Every(0.05f, (Action)PollLocalInputCastFx, (ModBase)(object)this);
```
- `PollOnce` (1f) keeps running `EnsureLocalMedusaBindingFromWorld` + `LogLiveLocalDiagnostics` forever, including in lobby/menu after a match.
- `PollLocalInputCastFx` (every 50ms) on any LMB/Q/Space/E press scans **all** `EntityManager`s (`FindLocalMedusaEntity` falls back to `Object.FindObjectsOfType<EntityManager>()`) and spawns cast FX whenever a Medusa-looking entity exists — with no match-active gate.

Confidence: HIGH (explicit absence; timers visible at 1529–1530).

---

## 2. Spawned cast FX self-clean; the persistent leak is static state, not GameObjects

The visible FX spawners all use a TTL `Object.Destroy(go, ttl)`, so the green beam/orb/puddle/native VFX are short-lived (not the remnant):
- `SpawnMedusaBeam` / `SpawnMedusaOrb` / `SpawnMedusaPuddle` / `SpawnNativeMedusaVfx` — each `Object.Destroy(..., ttl)` (TTL 0.48–2.4s). These are the **green-line fallback FX** (`MedusaVenomFxColor = (0.18,1,0.32)` green, `MedusaPetrifyFxColor` grey-green) used when the native VFX prefabs are missing — relevant to the "green lines instead of real VFX" symptom but they do clean up.

What does NOT clean up = process-lifetime static collections keyed by Unity instance IDs, cleared **only** when they exceed 128 entries (in `MarkLiveMedusaVisualStable`), never on match end/leave:
```
MedusaMod.cs:1347  _liveRefreshScheduledOnceRoots
MedusaMod.cs:1349  _stableLiveVisualRoots
MedusaMod.cs:1351  _runtimeReboundVisualRoots
MedusaMod.cs:1353  _charMaterialBoundRoots
MedusaMod.cs:1355  _charMaterialVisibleRoots
MedusaMod.cs:1357  _materialPreparedVisuals
MedusaMod.cs:4362  if (_stableLiveVisualRoots.Count > 128) { ...Clear(); }   // only mass-clear path
MedusaMod.cs:1455  private static EntityManager? _lastLiveMedusaEntity;       // held across matches
MedusaMod.cs:1721  EntityManager lastLive = _lastLiveMedusaEntity;            // reused as a binding candidate next match
```
Because Unity reuses instance IDs across scene/match loads, a fresh entity in match #2 can collide with a stale ID still present in `_stableLiveVisualRoots` / `_charMaterialBoundRoots`, so `IsLiveMedusaVisualStable` returns true and the mod **skips re-graft / re-enable** of renderers. `DisableBaseCharacterRenderers` (only toggles `Renderer.enabled = false`, MedusaMod.cs `DisableBaseCharacterRenderers`) may already have hidden the base mesh ⇒ this is a strong contributor to "enemies invisible / visible-only-after-damage" (a damage event triggers `CharMaterial.RevealHiddenCharacter`/alpha refresh which re-shows them). `_lastLiveMedusaEntity` also pins an old `EntityManager` reference into the next match.

Confidence: HIGH that the static state is never torn down; MEDIUM that ID-recycling is the live trigger for the invisibility cluster (needs a runtime repro to confirm ID collision).

---

## 3. The "rote Umrandung" (red outline) — neither mod draws it; it is a native element left un-cleaned

Grepped both mods: **no outline/red-selection/highlight drawing code exists** in `MedusaMod.cs` or `CustomServerMod.cs`. The only mod-drawn colors are green (Medusa FX/ability palette) and dark-grey/orange UI panels (`CustomServerMod.cs:660,1069,1480` — orange `(1,0.58,0.42)` text, not a red border). So the red outline is a **native BAPBAP element** (enemy silhouette / through-wall enemy outline / targeting highlight), not something a mod paints.

Two native candidates that the mod manipulates but never disables/undoes:
1. **Enemy outline / silhouette pass.** `DisableBaseCharacterRenderers` disables only `Renderer.enabled` on the base mesh; an outline that is a separate highlight pass / command-buffer / material property is NOT toggled, so a hidden Medusa-grafted entity can leave an outline-only silhouette. (Mod-side, Medusa entities only.)
2. **Petrify FX / char-color.** `HitboxDoEntityHitPetrifyPatch.Postfix` applies the native petrify and poison status effects and never removes them on teardown:
```
MedusaMod.cs:1179  charStatusEffects.ActivateStatusEffect(new StatusEffectInfo(_petrifySO, 2.5f, 1f), num, val2, false);
MedusaMod.cs:1191  charStatusEffects.ActivateStatusEffect(new StatusEffectInfo(_poisonSO, 3f, 1f), num, val2, false);
```
   The dumped `SE_Petrified` SO (`...\dumps\latest\medusa\ABILITY_MANIFEST.md:315`) has `applyCharColor:1`, `charColor rgba(0.83,0.83,0.83,1)`, `color rgba(0.679,0.659,0.625,1)`, plus `vfxLoopPrefab/vfxEndPrefab` and `CharFX.EnablePetrifyFx()/DisablePetrifyFx()` + `VfxManager.petrifyMaterial`. If a petrified victim's entity is destroyed (leave/match-end) while the loop FX is active, `DisablePetrifyFx`/end-VFX may not fire ⇒ orphaned overlay. Note: petrify tint is grey-stone, so it explains a lingering shader-overlay better than a *red* border.

Best assessment of "whether mod or queue leaves it": the **mod** leaves it (zero teardown + renderer toggling that doesn't cover the outline/petrify FX pass), compounded by the **server match-teardown gap** in §4. The queue is NOT the leaver — disconnect/leave paths defensively clear the queue (LobbyService.cs:391, 719, 756, 1584).

Confidence: MEDIUM. Strong that no mod *creates* a red outline and that teardown is absent; the exact native source (enemy-outline pass vs petrify overlay) is unconfirmed without an in-engine repro / the LatestBuild outline shader name.

---

## 4. Server-side match teardown gap — leaving a match does NOT stop the dedicated process

The dedicated game-server process is killed only on three paths:
```
LobbyService.cs:275  RecordGameEnded(...)  -> _gameServers.StopMatchServer(session)   // requires GAME_ENDED from the dedicated server
LobbyService.cs:141  CleanupStaleMatches() -> only removes matches where session.Process.HasExited == true
LobbyService.cs:1441 StopMatch / StopAllMatches (admin / shutdown only)
GameServerProcessManager.cs:166 StopMatchServer -> TryKill(process) (Kill entireProcessTree:true) + port release
```
The client disconnect/leave cleanup runs `_clients.TryRemove`, `_queueService.LeaveQueue`, `RemoveFromLobbyAsync`, `_friendsService.RegisterOffline` — but **never calls `StopMatchServer`**:
```
LobbyService.cs:384-405  finally { _clients.TryRemove; _queueService.LeaveQueue; await RemoveFromLobbyAsync; _friendsService.RegisterOffline; }
LobbyService.cs:1576+    RemoveFromLobbyAsync(...)  // queue + lobby cleanup only, no match stop
```
Consequence: if every player leaves a live match but the dedicated server never emits `GAME_ENDED` and the process does not exit, the match lingers in `_matches` and the `bapbap.exe` keeps running (only reaped by `CleanupStaleMatches` once/if it self-exits, polled every 10s via `ResourceMonitorService.cs:63`). This is the literal "persistent match remnant" on the server; it can also keep the player's prior match/outline state authoritative when they re-enter.

Confidence: HIGH (explicit code paths).

---

## 5. Client melon overlay persistence is deliberate (DontDestroyOnLoad), with no scene-unload teardown

`CustomServerMod.cs` has `OnSceneWasLoaded` (line 325) but **no `OnSceneWasUnloaded`**; native UI is destroyed only in `OnApplicationQuit` (`DestroyNativeGameUi`, line 316). It also actively *prevents* destruction of UI roots/canvases across scene loads:
```
CustomServerMod.cs:1020-1043  Object.DontDestroyOnLoad(rootCanvasGo) + protect sibling roots
CustomServerMod.cs:5172       TryProtectLobbyUiFromDestruction()  // UIManager + GameNetworkManager kept alive
```
`OnSceneWasLoaded` only re-arms boolean match flags on lobby/menu scenes (325–347); it does **not** destroy spawned visuals, FX, or reset the Medusa static guard sets (those live in the separate `BAPBAP.Medusa` assembly). So mod-owned UI/canvas objects are intentionally carried across the match→lobby boundary, which is consistent with "overlay/remnants that persist after leaving."

Confidence: HIGH that persistence is by design; MEDIUM that it contributes to the specific red-outline remnant.

---

## 6. Queue 3–8 min + first-attempt-fails-then-works (brief, adjacent to C6)

Adjacent note (other agents own this fully): `MatchmakingHostedService` polls every 1s and calls `StartMatchmakingGameAsync`; a failed start triggers `RequeuePlayers`. Comments document a historical "phantom player" jam: `LobbyService.cs:1576-1581` — *"Leaving a lobby while still queued caused the queue timer to fire on a phantom player, then StartMatchmakingGameAsync would find no live websocket and abort - which left the queue jammed for everyone."* Combined with the §4 gap (a lingering prior match) and the ~60s dedicated-process spawn/bootstrap (`GameServerReadyTimeoutSeconds`, see `GameServerProcessManager.TryBootstrapServerAsync`), a first attempt can fail/abort then succeed on requeue — plausibly explaining the long/variable queue and "first attempt fails then works." Confidence: LOW-MEDIUM (inferred; not the C6 focus).

---

## Summary of spawn-without-cleanup / teardown gaps (file:line)
- MedusaMod.cs:1529-1530 — perpetual timers, never stopped; no match gate.
- MedusaMod.cs:1347-1357,1455,4362 — static guard sets + `_lastLiveMedusaEntity` only cleared at >128, never on leave/match-end (instance-ID recycling → skipped re-graft → invisible enemies).
- MedusaMod.cs:1179,1191 — petrify/poison status effects applied; never removed; petrify SO carries char-color + loop VFX (`DisablePetrifyFx` not guaranteed on teardown).
- MedusaMod.cs `DisableBaseCharacterRenderers` — toggles only `Renderer.enabled`, not outline/highlight pass.
- LobbyService.cs:384-405 & 1576+ — leave/disconnect never calls `StopMatchServer`; match process lingers.
- LobbyService.cs:141 & 275; ResourceMonitorService.cs:63 — match reaped only on GAME_ENDED or already-exited process (10s poll).
- CustomServerMod.cs:316,325,1020-1043,5172 — overlay teardown only on app quit; DontDestroyOnLoad keeps UI alive across scenes; no scene-unload cleanup.

## Top hypotheses (ranked)
1. (MEDIUM-HIGH) Red outline = native enemy outline/petrify overlay left behind because MedusaMod has zero teardown and disables base mesh renderers without disabling the outline/petrify FX pass; persists into lobby because mod UI/objects use DontDestroyOnLoad. Mod-side, not queue.
2. (HIGH) Server keeps a dead/empty match alive after leave (no `StopMatchServer` on disconnect) → persistent server-side match remnant and stale authoritative state on re-entry.
3. (MEDIUM) Cross-match instance-ID collisions in the un-cleared static guard sets cause skipped visual repair ⇒ invisible-until-damaged enemies (overlaps the visibility-cluster scope).
