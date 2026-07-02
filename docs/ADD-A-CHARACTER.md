# Adding a Custom Character (BAPCustomChars framework)

Adding a new playable character to the BAPBAP custom server takes **3 data steps and zero per-character code**:

1. Build the character's asset bundle.
2. Write a small JSON definition.
3. Drop both into `UserData\` and launch.

The `BAPCustomChars` mod (one shared library, installed once) discovers the JSON at
startup, clones a working base character for the networked plumbing, grafts the real
visual + animator from the bundle, registers the character in the lobby roster, and keeps
everything headless-safe. **Medusa** is the reference character built with this pipeline.

---

## Prerequisites (one-time)

- **Unity 2022.3.38f1** (must match the game build so bundles load natively).
- The **AssetRipper export** of the game at
  `C:\Users\Administrator\Downloads\neueBapbap\GameCode\ExportedProject`, with
  `Assets\Scripts` moved aside to `_DisabledScripts` (so the project compiles for bundling).
  This export already contains the assets for every shipped character (Medusa, Eve, ...).
- The `BAPCustomChars.dll` library installed once in the game `Mods\` folder
  (client and, for live play, server). It is built from
  `BAPBAPModdingAPI\bapcustomchars-mod\BAPCustomChars.csproj`.

---

## Step 1 — Build the bundle

```powershell
C:\Users\Administrator\Downloads\CustomServer\tools\Build-CharBundle.ps1 -Char <Name>
```

- Runs Unity headless against the ExportedProject via
  `ExportedProject\Assets\Editor\CharBundleBuilder.cs` (param `-charName`).
- Glob-discovers the character's assets (`<Name>.prefab`, `<Name>.controller`,
  `<Name>_*.anim`, material, avatar, hitboxes, VFX) by name.
- Emits the AssetBundle plus a stripped **`<Name>_Visual`** prefab (armature +
  SkinnedMeshRenderer + Animator bound to the real controller, MonoBehaviours removed)
  so the mod can graft it without component conflicts.
- Output: `artifacts\<name>-bundle\<name>`.

Verify the controller imported (e.g. Medusa has 7 animator params, 3 layers) with the
builder's `Inspect` method. See `analysis\char-bundle-tool-report.md`.

## Step 2 — Place the bundle

Copy the built bundle to **`<game>\UserData\<Name>\<bundleFileName>`** on every machine
that runs it (client, and server for live play):

```
<game>\UserData\Medusa\medusa.bundle
```

> The resolver path is `UserData\<Name>\<BundleFileName>` (the `Name` field is the folder).

## Step 3 — Write the definition JSON

Create one file per character in **`<game>\UserData\CustomChars\<name>.json`**.
The mod scans that folder at startup. Reference (`medusa.json`):

```json
{
  "charId": 15,
  "name": "Medusa",
  "displayName": "MEDUSA",
  "subtitle": "",
  "baseCharId": 0,
  "bundleFileName": "medusa.bundle",
  "visualPrefabName": "Medusa_Visual",
  "mirrorAssetId": 1296385109,
  "enabled": true,
  "abilities": []
}
```

### Field reference

| Field | Type | Required | Meaning |
|---|---|---|---|
| `charId` | int | yes | Roster slot the character registers as. **Must be unique and > 14** (shipped chars are 0–14). |
| `name` | string | yes | Internal roster name + the `UserData\<Name>\` bundle folder. |
| `displayName` | string | no | Upper-case lobby label. Defaults to `name.ToUpper()`. |
| `subtitle` | string | no | Optional tagline. |
| `baseCharId` | int | yes | A shipped character to clone for the networked plumbing (abilities, Mirror identity, movement). `0` = Kitsu. |
| `baseCharName` | string | no | Override the base roster name. Auto-resolved from `baseCharId` (currently `0 → Kitsu`; extend `KnownBaseNames` for other bases). |
| `bundleFileName` | string | yes | The AssetBundle file name inside `UserData\<Name>\`. |
| `visualPrefabName` | string | yes | The visual root prefab inside the bundle (`<Name>_Visual`). |
| `mirrorAssetId` | uint | yes | Mirror `NetworkIdentity` assetId for the clone. **Must be unique** per character. Medusa uses `0x4D454455` = `1296385109`. |
| `enabled` | bool | no | Active flag (default `true`). The mod uses the first enabled definition as the primary. |
| `abilities` | string[] | no | Reserved for full data-driven ability wiring (see Phase 2 below). |

Any omitted field falls back to the Medusa default, so a partial file still produces a
valid character.

## Step 4 — Deploy & launch

- **Client:** `BAPCustomChars.dll` in `<game>\Mods\`, bundle in `UserData\<Name>\`,
  JSON in `UserData\CustomChars\`. Launch the game; the character appears in the lobby
  roster and spawns with its real model + animations.
- **Server (live play):** same three files server-side. The framework keeps all
  client-only VFX/hitbox instantiation gated behind `CanSpawnClientFx()` (false under
  `-batchmode -nographics`), and the bundle is only `LoadAsset`-ed, never instantiated on
  the server — so the dedicated match-host is structurally safe.

On startup the mod logs the active definition, e.g.:

```
[BAPCustomChars] active definition: name='Medusa' display='MEDUSA' charId=15 base=0('Kitsu')
                 bundle='Medusa\medusa.bundle' visual='Medusa_Visual' assetId=0x4D454455 (loaded 1).
[BAPCustomChars] [Medusa] registered Char_Medusa, made 16 characters available in lobby (incl. Medusa).
```

---

## Real attacks (Phase 2)

The bundle also carries the character's real ability prefabs (e.g.
`Hitbox_MedusaPoisonProjectile`, `Hitbox_MedusaPoisonPuddle`, `Hitbox_MedusaWallPoison`,
`Hitbox_MedusaWallBoxDpsPoison`, the `VFX_Medusa_Poison_*` set). The mod loads these by
name and spawns the matching hitbox per ability slot on cast, plus a status-on-hit hook
(Medusa: poison + petrify). All spawning is **client-side, `CanSpawnClientFx`-gated**; the
server-side damage path is unchanged, so the match-host stays safe.

Per-slot mapping (Medusa reference):

| Slot | Input | Hitbox |
|---|---|---|
| 0 | LMB | `Hitbox_MedusaPoisonProjectile` |
| 1 | RMB | `Hitbox_MedusaPoisonPuddle` (+ `MedusaPuddleSpawner`) |
| 2 | Space | `Hitbox_MedusaWallPoison` |
| 3 | E / Ult | `Hitbox_MedusaWallBoxDpsPoison` |

> Current limitation: ability behaviour/VFX selection and the on-hit status are still
> Medusa-tuned. Generalizing the per-character ability table (driven by the `abilities[]`
> field) is the next framework increment. The visual/animator graft, registration, lobby
> roster, and headless gating are already fully generic.

---

## Checklist for a new character

- [ ] Assets exist in the ExportedProject under the character's name.
- [ ] `Build-CharBundle.ps1 -Char <Name>` produced `artifacts\<name>-bundle\<name>`.
- [ ] Bundle copied to `UserData\<Name>\<bundleFileName>` (client + server).
- [ ] `UserData\CustomChars\<name>.json` written with a **unique `charId` (>14)** and a
      **unique `mirrorAssetId`**.
- [ ] `BAPCustomChars.dll` present in `Mods\`.
- [ ] Startup log shows `active definition: name='<Name>'` and the character in the roster.
