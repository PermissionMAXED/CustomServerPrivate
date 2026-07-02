# CONTEXT — Current Architecture & State

_Last updated: 2026-06-14. Authoritative snapshot of the networked custom-character system._

## The mod (single DLL, ships to server + all clients)
Project: `C:\Users\Administrator\Downloads\BAPBAPModdingAPI\netcustomchar-mod`
Output: `NetworkedCustomChar.dll` — MelonLoader + Il2CppInterop + Harmony, **net6 / x86**.
Current built+deployed SHA256 prefix: **`38301BE1`** (live on `ark.atomi23.de` and the local workspace game).

### Source files
- `CustomCharMod.cs` — M1 spine + M5 wiring. Builds the networked prefab by cloning the base Kitsu
  char root (keeps the weaver-built NetworkIdentity + full `Char*` chain), assigns a stable
  peer-identical assetId, registers it IDENTICALLY on server + client, hooks
  `GameNetworkManager.Awake/OnStartServer/OnStartClient`, `SpawnPlayerChar`, the UI roster row,
  `Ability.SetState`, `CharAnimator.Awake`, etc. Loads the active `CustomCharDef` from config at init.
- `CustomCharConfig.cs` — **M5 loader**. Scans `UserData\CustomChars\*.json`, parses via Newtonsoft.Json,
  **stable ordinal sort by filename** (peer-deterministic), selects the first `enabled` def, falls back
  to a built-in Medusa default. Keys: `charId,name,displayName,baseCharId,assetId,graftVisual,bundleFileName,visualPrefabName,enabled`.
- `MedusaVisualGraft.cs` — M2 visual. Grafts the real Medusa model from the bundle INTO the prefab
  template (base renderers disabled, CharAnimator wired to Medusa animator). Headless-safe (no shader
  rebind on the dedicated host). Bundle path + visual name come from the active def (`ActiveBundleRel`,
  `VisualAssetName`). Also pulls the real `Hitbox_MedusaPoison*` / `VFX_Medusa_Poison_*` subtrees for grafting.
- `CustomAbilityEngine.cs` — M3/M3b/M3c. Server-only (`isServer`) hook of `Ability.SetState`. Spawns
  authentic Medusa poison networked hitboxes (`Hitbox_Medusa_NetSlot0..3`) via `NetworkServer.Spawn`,
  applies real `SE_Poisoned_SO`/`SE_Petrified_SO` via `CharHurtbox.ApplyHit`. `CustomCharId` set from config.
- `CustomNetChannel.cs` — manual ClientRpc channel (registered identically on every peer).
- `MirrorInterop.cs` — Mirror helpers.

## Key technical constraints / decisions
- **IL2CPP has no Mirror weaver** → cannot inject new `NetworkBehaviour` types. Abilities are a
  **server-side engine** over EXISTING networked primitives + a manual RPC channel. No injected NB.
- **Peer-identical registration** is the core correctness rule: same DLL + same config on all peers
  ⇒ same charId/assetId/prefab name ⇒ Mirror spawns instantiate the same (Medusa-grafted) template on
  every client ⇒ others see her. Runtime collision-bump of the assetId is deterministic (same on all peers).
- **owner/team**: `EntityManager.ownerPlayerId` is a non-SyncVar plain int that stays **-1** on a player
  char. Real ids live on `PlayerManager.playerId` / `.teamId` — the engine resolves owner/team from there
  (`ResolveOwnerPid`/`ResolveTeamId`), so spawned hitboxes hit enemies + attribute kills correctly.
- **Medusa asset reality** (reverse-engineering `ABILITY_MANIFEST.md`): Medusa is visual+animation only;
  no ability classes/SOs/icon sprites exist. The kit is authentically authored using the game's real
  poison hitbox prefabs/VFX + real status SOs. The 4 shipped `Hitbox_Medusa*` prefabs are visual/collision
  only (no damage logic), so the mod grafts their visuals onto a damage-capable networked chassis.

## Milestones (all complete)
- **M1** networked spine — proven (no despawn, killed by others).
- **M2** Medusa visual graft — proven (server-side graft logs; in-match model).
- **M3 / M3b / M3c** server abilities + visible authentic poison hitbox spawns — proven (owner=1 team=1).
- **owner/team fix** + **F1 audit fix** (cone-fallback friendly-fire) — applied + verified.
- **M5 config-driven generalization** — proven live (`[M5] active definition: name='Medusa' … 0xB0B00F0F`).

## Config state (`Spiel\Battleroyalebuild\UserData\CustomChars\`)
- `medusa.json` — charId 15, **enabled=true** (active). `eve.json`, `blitz.json` — charId 15, disabled
  (templates; Eve/Blitz have no bundle yet, so they'd fall back to the Medusa visual if enabled).

## Latest test results (`analysis\full-test-report.md`, 2026-06-14)
- **TEST1 2-client parity = PASS** — both clients register `Char_Medusa` with identical assetId `2964328207`.
- **TEST2 live cast = PASS** — `[M3c] spawned … 'Hitbox_Medusa_NetSlot3' … owner=1 team=1 dmg=160`.
- **TEST3 config-driven = PASS** — `[M5] active definition: name='Medusa' … assetId=0xB0B00F0F`.

## Live server health (HTTP, no AMP needed)
`/health` → ok, prewarm ready, `medusa.charId=15 available=true`. Mod loads + builds `Char_Medusa`.
