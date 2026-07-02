# BAPCustomChars — reusable custom-character framework (design)

Goal: adding a NEW playable character = (1) build its bundle, (2) drop a small JSON.
No per-char code, no weeks of work. A companion lib/modding-API mod does all the
boilerplate generically. Medusa becomes char #1 proving the framework.

## Two pieces

### 1. Build-time tool: `tools\Build-CharBundle.ps1 -Char <Name>`
Generalizes the proven MedusaBundleBuilder. Runs Unity 2022.3.38f1 headless on the
exported project (neueBapbap\GameCode\ExportedProject) and produces `<name>.bundle`
containing that character's REAL assets:
- a stripped visual-only prefab `<Name>_Visual` (armature + SkinnedMeshRenderer + Animator
  with the REAL controller+avatar; MonoBehaviours removed so it grafts cleanly),
- the real AnimatorController + all AnimationClips + Avatar + Material(s)/textures,
- the character's ability hitbox + VFX prefabs (for real attacks).
Works for ANY character already present in the export (Eve, etc.). One command per char.

### 2. Runtime lib mod: `BAPCustomChars.dll` (loads on client AND dedicated server)
At startup it scans `UserData\CustomChars\*.json` + the matching bundles and, for EACH
definition, performs the full registration generically (this is the proven Medusa logic,
parameterized — no hardcoded char):
- clone a configured BASE char prefab for working CharAbilities/EntityManager/Mirror plumbing,
- graft the REAL visual + bind the real Animator (-> real animations + visibility),
- register charId + Mirror NetworkIdentity assetId + spawn registration,
- append the CharacterConfiguration to the roster + patch selectable/unlocked/in-rotation UI
  + the listing-index null guards,
- headless-safe gating (CanSpawnClientFx) so the dedicated server never chokes on particle VFX,
- optional ability -> real-hitbox wiring per char.

## Character definition: `UserData\CustomChars\<name>.json`
```json
{
  "charId": 15,
  "name": "Medusa",
  "displayName": "MEDUSA",
  "subtitle": "",
  "baseCharId": 0,
  "bundle": "medusa.bundle",
  "visualPrefab": "Medusa_Visual",
  "mirrorAssetId": 1296385109,
  "enabled": true,
  "abilities": []
}
```

## Adding a new character (the payoff)
1. `tools\Build-CharBundle.ps1 -Char Eve`  -> produces `eve.bundle`.
2. Copy `eve.bundle` to client + server `UserData\CustomChars\`.
3. Write `UserData\CustomChars\eve.json` (charId, base, assetId, ...).
4. Done — framework auto-registers Eve next launch. No code changes.

## Build order
1. Generalize MedusaBundleBuilder -> CharBundleBuilder (param: char name) + Build-CharBundle.ps1.
2. Create BAPCustomChars mod project: definition loader + generic registration engine
   (extract/generalize the working pieces from BAPBAP.Medusa MedusaMod.cs; keep the
   headless-safe gating). Backend already accepts arbitrary charIds (Available Character IDs).
3. Ship medusa.json + the real medusa bundle as char #1; verify animations/visibility live.
4. Add ability->hitbox wiring as a per-char optional extension (phase 2).
5. Document "how to add a character" in README.

## Reuses what we already built
- The real Medusa bundle (3.49 MB, real controller verified: 7 params / 3 layers).
- The registration/graft/UI-patch/headless-gating logic in BAPBAP.Medusa (to be generalized).
- Research: all char components exist in BR; charId system = UICharactersConfiguration.Characters[]
  + GameNetworkManager.characterPrefabsByCharId[]; Unity/bundle versions all 2022.3.38f1.
