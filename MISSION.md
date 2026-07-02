# MISSION — BAPBAP Networked Custom Characters

## Objective
Build a **fully-networked, server-authoritative** custom-character system for BAPBAP where
**any new character = an AssetBundle + a small JSON config**, with **no per-character hardcoding**.
**Medusa is character #1** and must work flawlessly for **all players**:
- selectable in the lobby (charId 15),
- spawns as a real networked entity (no despawn / no frozen "Standbild"),
- **other players see her model** and can hit/kill her,
- abilities **spawn real networked attacks** that deal damage + apply authentic status (poison / petrify).

We own **both** the dedicated server and the clients — the **same** `NetworkedCustomChar.dll` +
`medusa.bundle` + `UserData\CustomChars\*.json` ship to every peer.

Live server: `http://ark.atomi23.de:5055` (game/ASP.NET). AMP panel: `https://ark.atomi23.de`.

## Why a ground-up rebuild
The earlier approach (clone + **client-side** visual graft) FAILED: invisible to other players,
despawns, frozen poses, broken abilities. Root cause: it violated **Mirror's server-authoritative
replication**. This project rebuilds from scratch respecting Mirror — clone a real networked char
root, register it **identically** on server + every client (peer-identical assetId), let the native
`GameMode.SpawnPlayerChar` spawn it, and drive abilities **server-side** over existing networked
primitives (IL2CPP has no Mirror weaver, so no new `NetworkBehaviour` can be injected).

## Success criteria — STATUS: ACHIEVED (Medusa) + GENERALIZED
- [x] charId 15 selectable + auto-selectable for tests
- [x] Networked spawn via native path, **no despawn** (played full live matches)
- [x] **Others see + can kill her** — proven live (real player "slashflash" killed CodexMedusa8) and
      by 2-client registration parity (identical assetId on both peers)
- [x] Real Medusa **visual + animations** grafted into the networked prefab (headless-safe)
- [x] Abilities: **server-authoritative** damage + **authentic** `SE_Poisoned` / `SE_Petrified` SOs,
      spawning **authentic Medusa poison hitboxes**, with **correct owner/team** (owner=1, not -1)
- [x] **Config-driven** (M5): add/define a character by dropping a bundle + JSON, no recompile
- [x] End-to-end tested (see `analysis\full-test-report.md`): parity PASS, live-cast PASS, config PASS

## Out of scope / hard limits
- **Authentic Medusa ability ICONS do not exist** in the game (Medusa ships as a visual+animation
  asset drop only — zero ability classes/SOs/icon sprites; see the reverse-engineering
  `ABILITY_MANIFEST.md`). Abilities reuse the base-clone (Kitsu) icons; HUD palette is Medusa-green.
- A second, visually-distinct character needs its **own** bundle (content work), not just config.
