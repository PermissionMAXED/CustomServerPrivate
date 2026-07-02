# X1 — Cross-Cutting Synthesis of Handoffs / Status Docs / Prior Research

Agent: `X1_crosscut_synthesis_inputs` (READ-ONLY).
Scope: surface already-known open issues/TODOs and **contradictions between docs and
code** that the per-topic agents (working from a single area) are most likely to miss.
No source/build/deploy changes were made. Evidence is quoted with `file:line`.

Roots scanned: `C:\Users\Administrator\Downloads\CustomServer` and
`C:\Users\Administrator\Downloads\BAPBAPModdingAPI`.

---

## 0. The single most important cross-cutting finding (version skew)

The Medusa docs and the Medusa **code** are three different versions, and each layer
documents a *different* set of fixes. An agent reading only one layer gets a wrong
picture.

| Layer | Version it claims | Where |
|---|---|---|
| `medusa-mod/README.md`, `medusa-mod/DOCUMENTATION.md` | **v1.4.0 / v1.5.0** | README title "v1.5.0"; DOCUMENTATION.md:1 "Full Documentation (v1.5.0)" |
| `docs/MEDUSA_SERVER_INTEGRATION.md`, `docs/AMP_LINUX_WINE_ROOT_CAUSE.md`, handoffs | **v1.6.24 – v1.6.27** | MEDUSA_SERVER_INTEGRATION.md "Medusa v1.6.27 keeps the v1.6.24/v1.6.25 behavior…" |
| **Actual built code** `medusa-mod/MedusaMod.cs` | **v1.6.28** | MedusaMod.cs:1526 `"[Medusa] Loaded (v1.6.28)."` |

**v1.6.28 changelog line is the key one no markdown mentions** —
`MedusaMod.cs:1527`:

> `"[Medusa] v1.6.28: normal prematch selection by default + one-shot live visual
> repair guards + stable visual cheap health checks + no repeated
> CharMaterial/material alpha churn after graft."`

That single line maps directly onto investigation items (2) transparency/FPS and (4)
visible-only-after-damage / invisible — **the code already contains guards for them,
but none of the README/DOCUMENTATION/handoff/MEDUSA_SERVER_INTEGRATION docs describe
those symptoms or fixes.** Any agent reading only the docs will conclude these issues
are untouched; they are not. **Confidence: HIGH.**

---

## 1. Medusa abilities / VFX (green lines + Kitsu FX instead of real Medusa VFX)

Already-known facts (consistent across docs):

- **No native Medusa ability content exists in this BR build.** `medusa-mod/README.md`
  ("Why slots 0–2 stay on the Kitsu scaffold (verified evidence, not assumption)"):
  three-way verification — IL2CPP dump *"0 Medusa hits"*, raw binary scan *"0 hits
  each"*, SO inventory *"22 AbilityBehaviourSO instances … none named Medusa-anything."*
  → *"Medusa is a visual+animation asset drop in the upstream depot. Her runtime
  gameplay scripts simply do not exist yet, anywhere."*
- Therefore all 4 slots are **Kitsu-clone mechanically** (README kit table: slots 0–3
  = "Kitsu-clone (themed)"). The cast FX you see are **Kitsu's** because the ability
  objects *are* Kitsu's. The "green lines" are the mod's own injected
  **"Medusa-green runtime ability UI"** (`docs/MEDUSA_SERVER_INTEGRATION.md`, Live AMP
  proof: *"runtime Medusa-green ability UI, direct tooltip 'Serpent Bolt'"*).
- `docs/MEDUSA_SERVER_INTEGRATION.md` "Known limits": *"This server integration does not
  invent native bespoke Medusa ability ScriptableObjects, because this old BAPBAP build
  does not contain them … the current implementation uses a Kitsu-based kit plus Medusa
  visuals/status/effect bridges."*

**Contradiction with the task premise ("real Medusa VFX exist in the LatestBuild"):**
The real Medusa VFX/hitbox prefabs **do** exist in the *upstream export* but were
**deliberately NOT bundled**. `medusa-mod/README.md` ("What was *checked* … intentionally
NOT bundled") lists five inert prefabs that exist in
`…\neueBapbap\GameCode\ExportedProject\Assets\GameObject\`:
`Hitbox_MedusaPoisonProjectile`, `Hitbox_MedusaPoisonPuddle`, `Hitbox_MedusaWallPoison`,
`Hitbox_MedusaWallBoxDpsPoison`, `MedusaPuddleSpawner`. They were excluded because the
bundle build pipeline needs guid-matched stub scripts and there is no driving
`AbilityBehaviourSO`. **So the "real Medusa VFX" the user expects are in the LatestBuild
export, just not shipped in `medusa.bundle`.** This is the documented root of "green
lines + Kitsu FX instead of real Medusa VFX," and README "Future paths A/B" is the
already-written TODO for fixing it. **Confidence: HIGH.**

For the abilities/VFX agent: the build only ships `medusa.bundle` with **30 visual
assets** (README "What's in `medusa.bundle`") — no ability SOs, no Medusa hitbox/VFX
prefabs. Compare `medusa-mod/medusa.bundle` (1,567,424 bytes, May 31 18:21) vs the
documented "1,275,524 bytes" in README — **the bundle on disk is larger than the
documented v1.3.0/v1.4.0 bundle**, another doc/code skew worth checking (the bundle was
regenerated after the docs were written). **Confidence: MEDIUM** (size mismatch is
factual; meaning needs the bundle agent).

---

## 2. Spawn in/out + transparency + FPS + invisible/visible-after-damage + red-outline remnants

- **Documented part (spawn + Kitsu fallback only):** `docs/MEDUSA_SERVER_INTEGRATION.md`
  "Root cause and final fix":
  > *"the real match prefab was cloned from a base character, and its Mirror
  > `NetworkIdentity` could carry runtime spawn state (`hasSpawned=True`) … Mirror then
  > rejected the prefab with `Char_Medusa(Clone) has already spawned` and the local
  > primary/auth character path fell back into Skinny/Kitsu state. Medusa v1.6.24+
  > sanitizes the scene/runtime `NetworkIdentity` fields before registering the prefab,
  > assigns stable asset id `0x4D454455` (`MEDU`), repairs local primary/auth binding by
  > Medusa visual identity, and suppresses the base skin renderers after spawn."*
- **UNDOCUMENTED part (transparency / FPS / invisible / red outline):** No markdown
  mentions these symptoms. Evidence they are handled **only in code**:
  - `MedusaMod.cs:1527` (v1.6.28): *"no repeated CharMaterial/material alpha churn after
    graft"* → directly about **transparency** (alpha) churn.
  - `MedusaMod.cs:1527`: *"one-shot live visual repair guards + stable visual cheap
    health checks"* → directly about **invisible / visible-only-after-damage** (a repair
    that re-binds the renderer when the mesh goes missing) and about **FPS** (making the
    health checks "cheap" / "one-shot" implies an earlier version ran an expensive
    per-frame repair).
  - Per-frame cost candidates: `MedusaMod.cs:1530` `TimerAPI.Every(0.05f, …
    PollLocalInputCastFx …)` (20 Hz) and `MedusaMod.cs:1529` `TimerAPI.Every(1f, …
    PollOnce …)`. The "visual fit via" diagnostic block (`MedusaMod.cs:3756`, `:3764`,
    `:3769`, `:3777`) was throttled in v1.6.27 (`MEDUSA_SERVER_INTEGRATION.md`: *"the
    v1.6.27 log throttle reduced `visual fit via` to three lines"*) — i.e. high-frequency
    visual diagnostics were a known noise/cost source.
- **"Persistent match remnants (red outline)"** is **not mentioned in any doc or in the
  obvious code strings** I searched (grep for `red`/`outline`/`remnant` in `MedusaMod.cs`
  returned no match). This is a genuinely undocumented symptom — likely a leftover
  enemy/visual object after match-end. Flag to the spawn agent as **open / unverified**.

**Hypothesis (MEDIUM):** transparency + FPS + invisible-until-damage are all
manifestations of the graft/repair loop fighting the engine's renderer/material state
each frame; v1.6.28 tries to make the repair one-shot. The spawn/transparency agent
should diff the v1.6.27→v1.6.28 graft/repair code paths (`GraftMedusaVisual`,
`EnsureLiveMedusaEntity` @ `MedusaMod.cs:739,1633,6827`, and the `CharMaterial rebound`
path @ `MedusaMod.cs:4017`) rather than trusting the docs, which stop at v1.6.27.

---

## 3. Kitsu / Skinny / default fallback cause

Fully explained by §2's Mirror "already spawned" finding, plus two more documented
roots the fallback agent should not re-derive:

- **Clone base is Kitsu.** `MedusaMod.cs:1235` `private const string BasePreference =
  "Kitsu";` and README pipeline step 4 "Clone Kitsu's `CharacterConfiguration`". So
  "default/Kitsu" appearance is the *expected* base before the graft succeeds.
- **Portrait/icon is Kitsu by design.** `DOCUMENTATION.md` §3: *"`MedusaMod.CloneConfig()`
  reuses the base character's sprites … These are **Kitsu's** UI sprites, used as a
  placeholder."* So the Kitsu **icon** is not a bug, it is an unfixed TODO (DOCUMENTATION
  §3 "To give her a native icon (future work)").
- The fallback into Skinny/Kitsu **in-match** (not the icon) is the Mirror identity
  collision from §2, fixed v1.6.24+ via sanitization + stable assetId `MEDU` +
  primary/auth rebind. **Confidence: HIGH.**

---

## 4. AMP persistence (why a live-uploaded `BAPBAP.Medusa.dll` resets)

- **Documented persistent update path:** AMP GitHub AutoInstall template → press
  **Update** → AMP pulls `bapcustomserver-amp-full-linux-wine.zip` from the GitHub
  Release and re-extracts it. `README.md` ("AMP GitHub AutoInstall"): *"create a new
  instance … press `Update`, then press `Start`. … The update stage downloads the full
  package from the public GitHub Release `bapcustomserver-amp-full-linux-wine.zip`. That
  package contains … the mod DLL, and `Mods\BapCustomServer.ini`."* The Medusa artifacts
  ship **inside** that zip (`docs/MEDUSA_SERVER_INTEGRATION.md` "Client artifacts" +
  "Packaging": *"Both packagers install the Medusa artifacts and verify they exist in the
  zip"*).
- **Therefore why a hand-uploaded DLL resets (HIGH):** any AMP **Update** re-extracts the
  release package over the instance, overwriting a manually-uploaded
  `BAPBAP.Medusa.dll`. The *only* documented persistent path is **rebuild package →
  publish GitHub release → AMP Update** (`ARTIFACT_MANIFEST.md` "Rebuild Scripts";
  `tools/Build-AmpFullLinuxWinePackage.ps1`, `tools/Publish-GitHubAmpRelease.ps1`).
- **OPEN / undocumented — SFTP / webupload alternative:** No doc describes an
  SFTP/web-file-manager path that *survives* an Update, nor whether AMP wipes the
  instance dir on Update vs only overwriting package files. There is clear evidence
  someone was already probing the AMP file manager for exactly this: workspace-root
  artifacts `tmp-filemanager.html`, `tmp-amp-filemanager-current.png`,
  `tmp-amp-filemanager-after-click.png` (all May 31). The AMP-persistence agent should
  treat "does a non-package file uploaded via SFTP/web survive Update?" as an
  unanswered question — **not covered by any doc.** **Confidence: HIGH that Update
  overwrites; MEDIUM/UNKNOWN on the SFTP survival path.**
- **Hard rule repeated in 3 places (do not casually break):**
  `docs/AMP_LINUX_WINE_ROOT_CAUSE.md` "What not to change casually" + `HANDOFF_FOR_NEXT_AI.md`
  + `BapCustomServerMelon/README.md`: *"Do not change the pinned mod DLL hash unless a
  live AMP match proves the new binary from queue to real match to cleanup."*

### Contradiction to flag: the "pinned mod DLL hash" disagrees between layers
- `HANDOFF_FOR_NEXT_AI.md`, `AI_HANDOFF.md`, `AI_HANDOFF_NEXT.md`,
  `AI_CURRENT_STATUS_AND_TODO.md`, `README.md` all pin
  **`035F05098CD3A413B79A51530099D5C68754A28256C5AA09C50994CE0DEF40A5`** /
  release **`bapcustomserver-20260530-cleanlogs`**.
- `docs/AMP_LINUX_WINE_ROOT_CAUSE.md` + `BapCustomServerMelon/README.md` pin
  **`3E796F1E22D124F6433DAE5BC67149A4A25D0CB5FD607DAB11FFE6934EA15E8D`** /
  release **`bapcustomserver-20260531-medusa-v172`**.
- `docs/MEDUSA_SERVER_INTEGRATION.md` agrees with the v172/`3E79…` set and adds
  `BAPBAP.Medusa.dll 4D3050CAC36C94AA726F575DE2F271A34248EB70CC81D6C55D27F2248CFBA16C`.
An agent that obeys the top-level handoffs ("do not change the pinned hash") would pin
the **older** `035F…`/cleanlogs DLL, which the later `docs/` say is superseded by
`3E79…`/v172. **The top-level handoffs are stale; `docs/` is newer.** **Confidence:
HIGH.** (And the *code* is newer still — v1.6.28 — so even `3E79…`/v172 is behind the
current source; see §0.)

---

## 5. Queue timing (3–8 min) + first-attempt-fails-then-works

Confirmed config + control flow (this maps cleanly onto the symptom):

- `CustomMatchServer/appsettings.json:33` `"GameServerReadyTimeoutSeconds": 120`
  (overrides the code default of 30 at `CustomServerOptions.cs:43`).
- `appsettings.json:134` `"QueueTimerSeconds": 30`; `:135` `"MinPlayersToStart": 1`;
  `:20` `"RequireGameServerBootstrap": true`.
- `GameServerProcessManager.cs:139-144`: if `!bootstrapped && RequireGameServerBootstrap`
  → `throw … "Game server {GameId} did not accept match bootstrap data."`
- `MatchmakingHostedService.cs:35-39`: `started = await StartMatchmakingGameAsync(...)`;
  `if (!started) _queueService.RequeuePlayers(players);` and the `catch` also requeues.
- README: *"the server takes ~60s to spawn and bootstrap a fresh dedicated process"* and
  `tools/Force-StartMatch.ps1` *"Wait up to 180s for GAME_STARTED."*
- `docs/AMP_LINUX_WINE_ROOT_CAUSE.md` "What was broken":
  > *"POST http://127.0.0.1:7850/setup-game Connection refused … did not accept match
  > bootstrap data before timeout … The client therefore sat in queue or was requeued
  > because the server correctly refused to send players into a dead match."*

**Hypothesis (HIGH):** the first attempt fails because the Wine/Unity Windows match
process is cold-starting (32-bit Wine prefix, Xvfb, Mesa software GL, shader cache cold —
`AMP_LINUX_WINE_ROOT_CAUSE.md` cause #1/#2) and does not open its bootstrap listener on
`127.0.0.1:7850` (or the KCP UDP port, `GameServerProcessManager.cs:223-239`) within the
120 s ready-timeout. The server throws → `RequeuePlayers` → the player waits another 30 s
queue cycle, by which time the Wine prefix / process is warm and the second spawn
bootstraps within budget. Summed: ~30 s queue + up to ~120 s failed wait + ~30 s requeue
+ ~60–120 s successful spawn ≈ **3–5+ min**, consistent with the observed 3–8 min and the
"first-attempt-fails-then-works" pattern. The lobby/custom path has its own short polls
(`LobbyService.cs:1039` and `:1220` use `HttpClient { Timeout = 2s }` loops) that can add
to perceived delay. **Confidence: HIGH** on mechanism; exact minute count needs the queue
agent to read live logs under `CustomMatchServer/logs/` and `logs/game-servers/`.

Open question for the queue agent: there is **no requeue back-off or "warm pre-launch"**;
every requeue re-pays the cold-start cost until one launch happens to beat the timeout.
That is the obvious lever but it is **not documented as a known TODO anywhere**.

---

## 6. Misc. cross-cutting items the single-topic agents may miss

- `_research/` contains **only a clone of the CubeCoders `AMPTemplates` repo** (1,394
  entries) — it is *not* prior project research. Do not waste time mining it for Medusa
  notes; the real prior research is `analysis/diff.txt` + the `docs/` set + the mod
  READMEs.
- `analysis/diff.txt` (UTF-16) is a decompiled diff of `BapCustomServerMelon` showing the
  bootstrap listener was **migrated from `HttpListener` to a raw `TcpListener`** with
  manual `Content-Length` parsing, plus new `DumpAndForcePortFields` /
  `ForcePatchStaticServerConfig` reflection that brute-forces `ws/kcp/tcp/listen` port
  fields and `BAPBAP…NetworkConfig.Server.ListenPort`/`MatchmakingHost`. This corroborates
  `AMP_LINUX_WINE_ROOT_CAUSE.md` cause #3 (*"Bootstrap POSTs must use a fixed
  Content-Length … does not parse chunked transfer encoding"*) and is relevant to the
  queue/bootstrap agent: the in-process mod bootstrap listener is deliberately minimal.
- `AI_HANDOFF.md`, `AI_HANDOFF_NEXT.md`, `AI_CURRENT_STATUS_AND_TODO.md` are all reduced
  to **pointers** and explicitly say their old bodies referenced *"stale ports, stale
  hashes, and intermediate failed AMP states"* — but they still pin the older
  `035F…`/cleanlogs hash (see §4 contradiction). Treat them as low-authority.
- `DOCUMENTATION.md` §8 / README "Live-test status" claim the mod was **never tested
  in-match** ("blocked offline, no backend"), while the *later*
  `docs/MEDUSA_SERVER_INTEGRATION.md` reports a **completed real in-match test**
  (`tmp-bapbap-v125b-inmatch.png`, client log `26-5-31_17-32-13.log`, live AMP v172).
  **The mod-local docs are stale; an in-match test did happen.** **Confidence: HIGH.**

---

## Confidence summary

| Item | Finding | Confidence |
|---|---|---|
| §0 version skew (docs v1.5/v1.6.27 vs code v1.6.28) | HIGH |
| §1 abilities are Kitsu-clone; real Medusa VFX prefabs exist in export but unbundled | HIGH |
| §1 bundle on disk (1.57 MB) ≠ documented (1.27 MB) | MEDIUM (fact), needs bundle agent |
| §2 spawn/Skinny fallback = Mirror "already spawned" | HIGH (documented) |
| §2 transparency/FPS/invisible handled only in v1.6.28 code, undocumented | MEDIUM-HIGH |
| §2 red-outline remnants — undocumented, no code string found | UNVERIFIED (open) |
| §3 Kitsu base/icon placeholder by design | HIGH |
| §4 hand-uploaded Medusa DLL resets because AMP Update re-extracts release zip | HIGH |
| §4 SFTP/webupload-survives-Update path | UNKNOWN (no doc) |
| §4 pinned-DLL-hash contradiction (handoffs 035F… vs docs 3E79…) | HIGH |
| §5 first-attempt-fails-then-works = Wine cold start > 120s ready-timeout → requeue | HIGH (mechanism) |
