# C3 — FPS Drops & Freezes (Standbilder) Caused by the Medusa Mod

Scope: READ-ONLY. Focus = client-side FPS hitches/freezes produced by the mod's
per-poll/per-frame work. No source/build/deploy changes made.

Primary file analyzed (source, 8098 lines):
`C:\Users\Administrator\Downloads\BAPBAPModdingAPI\medusa-mod\MedusaMod.cs`
Shipped binary: `...\BAPBAPModdingAPI\Battleroyalebuild\Mods\BAPBAP.Medusa.dll`
(Source is decompiled-style IL2Cpp C#; method line numbers match the task brief.)

> Note: investigation items (1) native refs, (2)/(3) green-line/Kitsu VFX fallback,
> (4) spawn/transparency/invisible/remnants, (5) AMP persistence, (6) queue timing are
> owned by sibling agents (B*/C6/D*/E*). This file = C3 (FPS/freezes) only, with the
> one cross-link where the visual bug directly amplifies the FPS bug (Hypothesis 2).

---

## 1. Timer / loop topology (poll frequency)

Only TWO recurring timers exist; there is **no `Update`, `OnUpdate`, `OnLateUpdate`,
`OnGUI`, or `GUILayout`** anywhere in the file (verified: 0 matches).

| Line | Code | Frequency |
|---|---|---|
| 1529 | `TimerAPI.Every(1f, (Action)PollOnce, ...)` | **1 Hz** |
| 1530 | `TimerAPI.Every(0.05f, (Action)PollLocalInputCastFx, ...)` | **20 Hz** |
| 1531 | `TimerAPI.Once(5f, (Action)LogAnimatorState, ...)` | one-shot |

These run for the **entire mod lifetime (lobby + live match)**; nothing stops them
when a match begins. So all per-poll costs below are paid continuously in-match.

---

## 2. Expensive scans per poll (file:line + frequency)

### 2a. `PollOnce()` — 1 Hz (def line 1534)
```
1539:  UICharactersConfiguration val = FindCharConfig();   // EVERY second, unconditional
1558:  LogLiveLocalDiagnostics();                          // EVERY second
       EnsureLocalMedusaBindingFromWorld("PollOnce");      // EVERY second (line 1556)
```

`FindCharConfig()` (def 5805) is **NOT cached** and runs the single most expensive
Unity call available, every second:
```
5810:  Il2CppArrayBase<UICharactersConfiguration> val =
           Resources.FindObjectsOfTypeAll<UICharactersConfiguration>();
5832:  Il2CppArrayBase<UIManager> val2 = Resources.FindObjectsOfTypeAll<UIManager>(); // fallback path
```
`Resources.FindObjectsOfTypeAll<T>` scans **every loaded object in memory incl.
assets, inactive and hidden objects** — far heavier than `FindObjectsOfType`. Called
1×/s forever (and a 2nd time via the UIManager fallback when the first array is empty).

### 2b. `LogLiveLocalDiagnostics()` — 1 Hz (def line 1566)
Two full-scene scans run **before any guard / throttle**, so they execute every
single poll even after everything is "ready":
```
1570:  Il2CppArrayBase<PlayerManager> players = Object.FindObjectsOfType<PlayerManager>();
1571:  Il2CppArrayBase<EntityManager> entities = Object.FindObjectsOfType<EntityManager>();
```
The `_liveLocalDiagnosticsSuccessLogged` early-return and `_pollTicks % 5` throttle
only suppress the *log line build*, not the two scans above them.

### 2c. `EnsureLocalMedusaBindingFromWorld()` — 1 Hz (def ~1620)
When the local→primary binding is not already Medusa it scans all entities:
```
1681:  Il2CppArrayBase<EntityManager> entities = Object.FindObjectsOfType<EntityManager>();   // FindBestLocalMedusaEntity
1645:  ...Object.FindObjectsOfType<EntityManager>()...   // inside no-candidate WARN string (guarded logcount<4)
```
If primary is good it instead calls `EnsureLiveMedusaEntity(...)` → see 2d.

### 2d. `EnsureLiveMedusaVisual()` — up to 1 Hz (def line 5066)
Reached every poll while local primary is Medusa (PollOnce→EnsureLocalMedusaBinding
FromWorld→EnsureLiveMedusaEntity, lines 7037/7053). Even the **"stable/cheap" fast
path** traverses the character hierarchy multiple times per second:
```
4145:  root.GetComponentsInChildren<Transform>(true)      // FindMedusaVisualObject (def 4137)
4258:  visual.GetComponentsInChildren<Renderer>(true)     // IsLiveMedusaVisualStable (def 4248)
5294:  GetComponentsInChildren<Animator>(true)            // FindMedusaAnimatorUnder (def 5286)
3923/4035/4179/4205/4380: GetComponentInChildren<CharMaterial>(true)  // IsCharMaterialBoundToVisual etc.
4323:  visual.GetComponentsInChildren<Renderer>(true)     // EnsureStableLiveMedusaVisualCheap (def 4296, self-throttled to 1s)
3861/4485: GetComponentsInChildren<Renderer>(true)        // ApplyCharacterRenderLayer / DisableBaseCharacterRenderers
```
If the visual is **NOT** stable, the heavy branch runs every second instead:
```
5118:  root.GetComponentsInChildren<SkinnedMeshRenderer>(true)
5066+: Object.Instantiate<GameObject>(_medusaVisualPrefab, ...)  // new clone
5147/5237/5394/5474/5490/5504: more GetComponentsInChildren<...> + new Material(...) per renderer
```

### 2e. `ScheduleLiveMedusaRefresh()` — burst (def line 7071)
Guarded once-per-root by `_liveRefreshScheduledOnceRoots` (7086) and a 1.4s re-arm
window (7104), but each fire schedules **4 delayed heavy refreshes**:
```
7117-7120:  Once(0.15f); Once(0.45f); Once(0.95f); Once(1.8f);
7129:       inst.EnsureLiveMedusaVisual(gameObject2, ...)   // each callback re-runs 2d
            + ApplyMedusaAbilityRuntimeUi + ApplyLiveAbilityUiPalette
```
So every newly-detected Medusa root triggers a burst of 4 full visual rebuilds; the
1.8s/re-arm path can keep re-issuing bursts if the entity keeps being re-detected.

### 2f. `IsHighFrequencyVisualDiagnosticSource()` (line 4653)
Only suppresses the *diagnostic log line* for `PollOnce*` sources after success — it
does **not** gate any of the scans in 2a–2d. Confirms logging is throttled but scans
are not.

### 2g. `PollLocalInputCastFx()` — 20 Hz (def line 1779)
Per-tick body is cheap (only `Input.GetMouseButtonDown`/`GetKeyDown`). BUT on each
ability press it calls `FindLocalMedusaEntity()` which can run a full-scene scan:
```
1839:  Il2CppArrayBase<EntityManager> val = Object.FindObjectsOfType<EntityManager>();
```
During ability spam with a broken local→primary binding this fires repeated
full-scene `FindObjectsOfType` at up to 20 Hz → input-correlated micro-stutter in fights.

### Other periodic-context scans (not in the steady 1 Hz loop but match-relevant)
`6241 PlayerPreMatch`, `6462/6552 PreMatchManager`, `6619 GameManager`,
`6714/7556 PlayerManager`, `7585 EntityManager`, `7619 UIAbilityElement`,
`7945 Resources.FindObjectsOfTypeAll<StatusEffectManager>`, `5569 FindObjectsOfType<Animator>`.

---

## 3. What causes GC / hitches

Per **every 1 s** (steady state, Medusa alive, visual stable):
- 1× `Resources.FindObjectsOfTypeAll<UICharactersConfiguration>` (5810) — **dominant**, allocates an array of ALL loaded objects.
- 2× `Object.FindObjectsOfType<PlayerManager/EntityManager>` (1570/1571) — full active-scene scans + arrays.
- ≥4× `GetComponentsInChildren<...>` over the character hierarchy (4145/4258/5294/4323 + layer/base-hide helpers) — each allocates a managed array.
- Many `Il2CppArrayBase`/`Il2CppReferenceArray` wrapper allocations.
- `SafeIntValue(() => ...)` / `SafeBool(() => ...)` allocate a **delegate/closure each call**; the diag line at 1591 contains ~20 of them (only when the throttled log actually fires).

These per-second allocations churn the IL2CPP/Mono GC; periodic GC collections are the
visible "Standbilder" (frame freezes). The 1 Hz cadence matches a ~once-per-second
hitch pattern.

Logging spam (OnGUI): **not the cause.** There is no `OnGUI` in the mod, and all
`Log.Info`/`Log.Warn` calls are bounded by counters (`_visualDiagnosticsLogCount<24`,
`_castFxLogCount<20`, `_liveLocalDiagnosticsLogCount<12`) and the high-freq source
suppressor (4653). The cost is the **scene scans**, not the log writes.

---

## 4. Root-cause hypotheses (with confidence)

**H1 (PRIMARY, HIGH ~0.85):** `PollOnce` runs an **uncached
`Resources.FindObjectsOfTypeAll` (via `FindCharConfig`, 1539→5810) plus 2×
`FindObjectsOfType` (1570/1571) every second for the whole match.** This alone
produces a recurring ~1/sec hitch independent of any visual state. `FindObjectsOfTypeAll`
is the textbook Unity perf killer and is the single strongest suspect for periodic freezes.

**H2 (SECONDARY, MED-HIGH ~0.7):** When the Medusa visual never reaches "stable"
(the same condition behind the transparency/invisible/green-line bugs owned by B*/C2),
`EnsureLiveMedusaVisual` takes the **heavy branch every second** (Instantiate + dozens
of `GetComponentsInChildren` + `new Material` per renderer, 5066/5118/5147/5237+),
and `ScheduleLiveMedusaRefresh` adds 4 extra heavy rebuild bursts per root (7117-7129).
This turns the 1 Hz hitch into sustained large stalls and explains why FPS is worst
exactly when Medusa visuals misbehave — the visual bug and the FPS bug are coupled.

**H3 (TERTIARY, MED ~0.5):** Ability spam drives `PollLocalInputCastFx`@20Hz →
`FindLocalMedusaEntity` full-scene `FindObjectsOfType<EntityManager>` (1839) bursts
when the local→primary binding is wrong → stutter correlated with casting during fights.

**H4 (CONTRIBUTING, MED ~0.5):** Continuous per-poll `Il2CppArrayBase` + `SafeIntValue`
closure allocations raise GC frequency, converting the above scans' work into visible
GC freeze frames rather than smooth cost.

### Cheapest high-impact fixes (suggestions only — NOT applied)
- Cache `FindCharConfig()` result (it changes rarely); stop calling `Resources.FindObjectsOfTypeAll` every second.
- Move the two `FindObjectsOfType` in `LogLiveLocalDiagnostics` **below** the success/throttle guards (or behind `_pollTicks % N`).
- Lower `PollOnce` cadence (e.g. 1 Hz → 0.2–0.5 Hz) and back off once `_liveLocalDiagnosticsSuccessLogged` is set.
- Cache the per-root `GetComponentsInChildren` results / mark stable once and skip re-traversal.

---

## 5. Evidence index (quick lookup)
- Timers: MedusaMod.cs:1529-1531
- PollOnce: 1534-1564 (FindCharConfig 1539, LogLiveLocalDiagnostics 1558)
- LogLiveLocalDiagnostics scans: 1566 / 1570 / 1571
- EnsureLocalMedusaBindingFromWorld scan: 1681 (+1645 logged)
- PollLocalInputCastFx: 1779; FindLocalMedusaEntity scan: 1839
- EnsureLiveMedusaVisual: 5066 (stable helpers 4137/4248/4296/5286; heavy 5118+)
- LogMedusaVisualDiagnostics: 4533 (GetComponentsInChildren 4562/4594)
- IsHighFrequencyVisualDiagnosticSource: 4653 (gates logs, not scans)
- ScheduleLiveMedusaRefresh: 7071 (4-burst 7117-7129)
- FindCharConfig (uncached): 5805 (Resources.FindObjectsOfTypeAll 5810/5832)
- No OnGUI/Update/OnUpdate: 0 matches in file
