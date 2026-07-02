# Medusa — Full Documentation (v1.5.0)

Backports **Medusa** from the upstream *Latest* BAPBAP build into the older
*Battleroyale* build as a native-as-possible custom playable character. Standalone
MelonLoader mod built on the BAPBAP ModAPI. Only the Battleroyale build is modded.

---

## 1. What is native vs placeholder (honest matrix)

| Aspect | Status | Detail |
|---|---|---|
| 3D model + 59-bone rig + skinned mesh | ✅ **native (Medusa's real)** | `MedusaBase` mesh + rig from `medusa.bundle` |
| Animations (22 clips) | ✅ **native, game-driven** | `Medusa.controller` + avatar; the game's `CharAnimator` drives them (param-compatible) |
| Material / shader | ✅ **native** | game's `Custom/Toon/Toon_Character_Amplify` shader applied at runtime, with Medusa's own Albedo + Normal textures |
| Roster registration / selectable | ✅ **native** | registered in `UICharactersConfiguration._characters` + `_lobbyCharacters`, own **CharId 15** |
| Character-select **icon/portrait art** | ⚠️ **placeholder (Kitsu's)** | her own 2D UI sprites are not in the source export — see §3 |
| Name / description / ability names | ✅ native (injected) | Gorgon theme via `Translator.phraseLookup` |
| Venom poison on LMB/Q | ✅ **native `SE_Poisoned`** | applied server-side on hit |
| Petrify on ult | ✅ **native `SE_Petrified`** | applied server-side on hit |
| Ability **mechanics** (movement/projectile logic) | ⚠️ cloned base kit (Kitsu) | no bespoke Medusa ability/FSM exists in this build; see README |
| **XP / mastery / progression path** | ❌ **none, not feasible natively** | backend/account-gated — see §4 |

---

## 2. Character-select presence

Medusa **does** appear natively in the in-game character-select grid: the mod clones a
base `CharacterConfiguration`, overrides identity (name "Medusa", green accent, own CharId
15, lobby + dev-lobby enabled, ability titles/descriptions) and appends it to the roster
(`UICharactersConfiguration`). Live-verified: roster grows 15 → 16, `/medusa status`
reports `registered=True charId=15`.

So in the selection screen she is a real, clickable entry **with an icon** — but the icon
art is currently a **placeholder** (see next section).

---

## 3. The icon question — why it's a placeholder, and how to make it hers

`MedusaMod.CloneConfig()` reuses the base character's sprites:

```csharp
m.smallSprite = b.smallSprite; m.IconSprite = b.IconSprite; m.LobbyBackground = b.LobbyBackground;
m.FullSprite = b.FullSprite;  m.StandingSprite = b.StandingSprite; m.CircleIcon = b.CircleIcon;
m.SquareIcon = b.SquareIcon;  m.SquareSmallIcon = b.SquareSmallIcon; m.DefaultSkin = b.DefaultSkin;
```

These are **Kitsu's** UI sprites, used as a placeholder so the grid entry renders.

**Why not her own icon:** the AssetRipper export we backported from
(`neueBapbap\GameCode\ExportedProject`) contains only Medusa's **3D** assets
(`Medusa_Tex_Albedo_1024`, `Medusa_Tex_Normal_1024`, mesh, rig, anims). It contains
**no Medusa 2D UI sprites** (portrait / circle / square / select-card / splash). Verified:
the only non-3D Medusa asset in the export is `Medusa_Anims_v03Avatar.asset`.

**To give her a native icon (future work):**
1. Locate Medusa's UI portrait/icon sprites in the *Latest* build — they are likely packed
   in a **UI sprite atlas** (not loose files), which AssetRipper did not split out. Re-rip
   the Latest build's UI atlases, or pull the sprite via the AssetRipper API.
2. Add the sprite(s) to `medusa.bundle`, load them at runtime, and assign to
   `m.IconSprite / m.SquareIcon / m.CircleIcon / …` in `CloneConfig`.
   (As a quick stub you could instead render her 3D head to a `RenderTexture` → `Sprite`,
   but that is not "native art".)

---

## 4. The XP / progression question — why there's no native path

**There is no XP/mastery/progression path for Medusa, and a client mod cannot create a
truly native one.** BAPBAP's per-character progression is **server/account-backed**:

- `CharMasteryPreviewResponse` (+ nested `CharPass`, `PassLevel`, `Listing`, `Asset`) are
  **backend response** types — mastery/XP data is fetched from the online service.
- `UILobbyCharacterMasteryRewardEntry`, `UILobbyBattlePassTabPage` only **display** what the
  backend returns.
- `GA_Progression` is GameAnalytics telemetry, not a local progression store.

A mod running on the client has no authority over account mastery/XP — that lives on the
(here-absent) backend. The most a mod could do is a **local cosmetic fake** (a fake mastery
bar that resets each launch), which would not be "native" and is intentionally **not**
included. If the game is run against its real backend, Medusa would need a server-side
mastery listing to gain a genuine XP path — outside the scope of a client mod.

---

## 5. Abilities (v1.5.0)

| Slot | Title | Mechanic | Native status effect on hit |
|---|---|---|---|
| 0 LMB | Serpent Bolt | Kitsu-clone (themed) | **`SE_Poisoned`** (3 s venom DoT) |
| 1 Q | Venom Spit | Kitsu-clone (themed) | **`SE_Poisoned`** (3 s venom DoT) |
| 2 Space | Slither | Kitsu-clone (themed) | — (mobility) |
| 3 Ult/E | Petrifying Gaze | Kitsu-clone (themed) | **`SE_Petrified`** (2.5 s stone-root) |

Implemented as a Harmony postfix on `HitboxBase.OnHitSuccess(EntityManager)` that, for a
CharId-15 entity, applies `SE_Poisoned` (slots 0/1) or `SE_Petrified` (slot 3) via
`CharStatusEffects.ActivateStatusEffect`. Each effect's own `Activate()` drives the game's
native poison/petrify FX + motion handling + replication. Both SO's are shipped in the BR
build and resolved at runtime via `StatusEffectManager.statusEffects[]`.

> Authority: applies on the server (host / dev-lobby = Tier B). On matchmade servers
> (Tier C) the server doesn't know CharId 15 → cosmetic only.

---

## 6. Usage / triggers

- **Auto:** registers ~1 s after the lobby loads (1-Hz poll).
- `/medusa` or **F7** — force registration.
- `/medusa status` — full report (registration, graft, poison + petrify counters).
- `/medusa anim` — animator state dump.

---

## 7. Build & deploy

```
dotnet build medusa-mod/BAPBAP.Medusa.csproj -c Release
```
Auto-deploys `BAPBAP.Medusa.dll` to `Battleroyalebuild/Mods/`. Needs `BAPBAP.ModAPI.dll`
in `Mods/` + `UserLibs/`. The bundle `medusa.bundle` must be at
`Battleroyalebuild/UserData/Medusa/medusa.bundle` (Unity 2022.3.38f1 build of her visual
prefab; see README "Build pipeline").

---

## 8. Live-testing status (IMPORTANT — current limitation)

The mod is **complete and load-verified** (loads, registers CharId 15, grafts the real
model/animator/shader, installs the poison + petrify hooks, **no crash** across many runs).

**However, an actual in-match live test is currently blocked by the offline harness, not by
the mod.** This build has **no online backend**, so:

- The **normal** launch hangs at "Loading…" (cannot reach the login/lobby backend).
- The **offline dev-lobby** harness (`offline-dev-mod`) starts a local host but the game
  **never creates a dev-lobby player object** for the host (`PlayerDeveloperLobby` count
  stays 0; `PlayerManager.LocalInstance` stays null) because the match-entry pipeline
  (login → ClInit → lobby player → char select → match spawn) is gated behind the missing
  backend. Five different server-side entry attempts were tried
  (`HandleDeveloperLobbyButton`, `OnServerDevLobbyClInit`, `AddPlayerDevLobby`,
  `OnServerClInit`+`OnServerAddPlayer`, and `isDevLobbyMode`+`OnServerDevLobbyClInit`); a raw
  player spawn yields a default char (0) stuck on "Loading…".

**Conclusion:** verifying Medusa's model/animations/poison/petrify *in actual gameplay*
requires running the game with its **real backend/login** (where she is already selectable
in the roster), or a substantial reverse-engineering effort to replicate the offline
match-entry networking. This is a harness limitation, independent of the Medusa mod.

---

## 9. Known limits & future work

- **Icon:** placeholder (Kitsu) — see §3 to add her real portrait from the Latest UI atlas.
- **XP/progression:** none; backend-gated — see §4.
- **Ability mechanics:** slots run the cloned base kit (no bespoke Medusa FSM exists in this
  build); native poison + petrify are layered on top via status effects.
- **Live in-match test:** blocked offline (no backend) — see §8.
- **Tier C (matchmade):** cosmetic only (server doesn't know CharId 15).
