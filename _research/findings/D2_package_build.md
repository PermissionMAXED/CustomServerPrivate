# D2 — AMP Release Package Build & Medusa Source Mapping

Scope: What goes into the AMP release package, where the Medusa DLL/bundle come
from, how the 552 MB zip is built and uploaded, the pinned-hash verification, and
why a live-uploaded `BAPBAP.Medusa.dll` won't persist. READ-ONLY research.

Date: 2026-06-01. No source/build/deploy changes were made. The only write is this
file. Read-only `Get-FileHash`/`python zipfile` inspection was used to compare
artifacts; nothing was rebuilt or run as a server/game.

---

## 0. TL;DR / Headline finding (HIGH confidence)

The shipped release zip and the staged package tree contain an **OLDER Medusa
build** than the current rebuilt source, and the package's `deployment-info.json`
**falsely records the newer hashes**. The pinned-hash verification only covers
`BapCustomServerMelon.dll` — the **Medusa DLL/bundle are existence-checked only**,
so this staleness/divergence passes silently.

Measured SHA256 (read-only):

| Artifact | Current SOURCE / dev-game | Staged in `package\...\game` | Inside shipped 552 MB zip | `deployment-info.json` claims |
|---|---|---|---|---|
| `BAPBAP.Medusa.dll` | `999D4BDF…B9C2BFC0` (168,448 B) | `4D3050CA…48CFBA16C` (162,816 B) | `4D3050CA…48CFBA16C` (162,816 B) | `999D4BDF…B9C2BFC0` |
| `medusa.bundle` | `C4872D6E…023B1D70` (1,567,424 B) | `2F2CCF12…1BA8A2A02` (1,283,507 B) | `2F2CCF12…1BA8A2A02` (1,283,507 B) | `C4872D6E…023B1D70` |
| `BapCustomServerMelon.dll` | `3E796F1E…4EA15E8D` (210,432 B) | `3E796F1E…` (210,432 B) | `3E796F1E…` (210,432 B) | `3E796F1E…` (pinned ✓) |

So: AMP "Update" (which re-downloads the GitHub-release zip) installs Medusa
`4D3050CA` + bundle `2F2CCF12` — NOT the latest `999D4BDF` / `C4872D6E` source
build that sits in the dev game folder and `medusa-mod\bin\Release`. The Melon mod
DLL is the only artifact that is hash-pinned and it matches; Medusa is not pinned
and is stale. This is the strongest packaging-side candidate for "wrong/old Medusa
ships even though the right VFX exist in the LatestBuild/source."

Evidence of non-atomic "livepatch":
- `deployment-info.json` `releaseLabel = "bapcustomserver-20260531-medusa-v173-livepatch"`, `packageBuildUtc = 2026-05-31T18:35:16Z`, `gitDirty = true`.
- Staged `game\Mods\BAPBAP.Medusa.dll` mtime **16:09**; `game\UserData\Medusa\medusa.bundle` mtime **13:01**; zip mtime **16:21**; but `deployment-info.json` mtime **18:35** and source DLL/bundle mtime **18:21**.
- A real full `Build-AmpFullLinuxWinePackage.ps1` run would have re-copied Medusa from source into `GameRoot\Mods` (L103/L106) and re-zipped — both would carry an ~18:35 mtime and the `999D4BDF`/`C4872D6E` bytes. They don't. Only `deployment-info.json` was refreshed, recording hashes that match neither the staged files nor the zip.

---

## 1. Package map — every Medusa-relevant file copied into `package\BapCustomServer`

Builder: `tools\Build-AmpFullLinuxWinePackage.ps1`.

Path constants:
- `Build-AmpFullLinuxWinePackage.ps1:17` `$OutRoot = deployment\amp-full-linux-wine`
- `:18` `$PackageRoot = $OutRoot\package`
- `:20` `$GameSource = <CustomServer>\Spiel\Battleroyalebuild`
- `:21-22` `$ModDll/$ModIni = BapCustomServerMelon\dist\BapCustomServerMelon.dll|BapCustomServer.ini`
- `:24` `$ZipPath = deployment\amp-full-linux-wine\bapcustomserver-amp-full-linux-wine.zip`
- `:26` `$ModdingRoot = <Downloads>\BAPBAPModdingAPI`
- `:27` `$MedusaModRoot = BAPBAPModdingAPI\medusa-mod`
- `:28` `$MedusaDll = medusa-mod\bin\Release\BAPBAP.Medusa.dll`  ← Medusa DLL source
- `:29` `$MedusaBundle = medusa-mod\medusa.bundle`               ← bundle source
- `:30-34` `$ModApiDllCandidates = modapi\bin\$Configuration\BAPBAP.ModAPI.dll, modapi\bin\Release\…, dist\UserLibs\…`

Server publish + game copy:
- `:~219` `dotnet publish $ServerProject -c $Configuration -r linux-x64` → `package\BapCustomServer\` (the Linux ASP.NET server; `.dll/.so` dated Mar 03 in staging).
- `:~234` `Copy-Item $GameSource -Destination $GameRoot -Recurse` → Windows Unity build into `package\BapCustomServer\game\` (`bapbap.exe`, `bapbap_Data\*`, `UnityPlayer.dll`, `MelonLoader\*`).
- `:~245-250` copies Melon mod `$ModDll` → `game\Mods\BapCustomServerMelon.dll`, `$ModIni` → `game\Mods\BapCustomServer.ini` (then ini patched Host=127.0.0.1, Port=5055, UseLocalProxy=false, UI off).

Medusa staging (function `Install-MedusaArtifacts`, `:90`):
- `:99` `Copy-Item $ModApiDll → game\Mods\BAPBAP.ModAPI.dll`
- `:100` `Copy-Item $ModApiDll → game\UserLibs\BAPBAP.ModAPI.dll`
- `:103` `Copy-Item $MedusaDll → game\Mods\BAPBAP.Medusa.dll`
- `:106` `Copy-Item $MedusaBundle → game\UserData\Medusa\medusa.bundle`
- `:~108-122` REQUIRED existence assertions for those 4 files (throws if missing) — **no hash check**.
- `:293` `Install-MedusaArtifacts -TargetGameRoot $GameRoot` (invocation).
- `:295` `auto-select.txt` is removed unless `BAPCUSTOM_PACKAGE_MEDUSA_AUTOSELECT=1` (so Medusa is NOT force-auto-selected in the AMP bundle by default).

Roster/charId wiring written into `appsettings.json`:
- `MatchDefaults.AvailableCharacters = @(0..15)` (includes **15 = Medusa**).
- `:~350` `Set-JsonProperty $settings.CustomServer.Roster 'EnableMedusa' $true`.
- `deployment-info.json` records `"medusaCharId": 15`.

Confirmed staged contents (`package\BapCustomServer`):
- `game\Mods\BAPBAP.Medusa.dll` 162,816 B `4D3050CA…` (16:09)
- `game\Mods\BAPBAP.ModAPI.dll` 1,653,248 B (+ `.pdb`)
- `game\UserLibs\BAPBAP.ModAPI.dll` 1,653,248 B (+ `.pdb`)
- `game\UserData\Medusa\medusa.bundle` 1,283,507 B `2F2CCF12…` (13:01)
- `game\Mods\BapCustomServerMelon.dll` 210,432 B `3E796F1E…`
- `game\Mods\BapCustomServer.ini`, `game\UserData\MelonPreferences.cfg` (NetTune off, identity blank)

Source artifact on-disk state (BAPBAPModdingAPI):
- `medusa-mod\bin\Release\BAPBAP.Medusa.dll` 168,448 B `999D4BDF…` (18:21) — also matches dev game `Battleroyalebuild\Mods\BAPBAP.Medusa.dll` (168,448 B `999D4BDF…`, 18:21).
- `medusa-mod\medusa.bundle` 1,567,424 B `C4872D6E…` (18:21).
- `BAPBAPModAPI\modapi\bin\Release\BAPBAP.ModAPI.dll` 1,653,248 B (30 May 21:02).

Note: ModAPI `BAPBAP.ModAPI.dll` is shipped to BOTH `game\Mods` and `game\UserLibs`
(MelonLoader resolves shared lib deps from `UserLibs`); the `.pdb` is shipped too.

State dirs intentionally stripped before zipping (`:~600`): `BapCustomServer\data`
and `BapCustomServer\logs` removed so AMP Update never clobbers player/economy/
ranked/admin state. The pre-zip verifier (`:670-680`) re-throws if any `data/`,
`logs/`, `*-state.json`, `match-history.jsonl`, or `admin-audit.jsonl` entry leaks
into the zip.

---

## 2. How the 552 MB zip is produced and uploaded to GitHub

Zip build (`Build-AmpFullLinuxWinePackage.ps1`):
- `:~625-655` Manual `System.IO.Compression.ZipArchive` build with forward-slash
  entry names; the leading `BapCustomServer/` segment is stripped so entries are
  e.g. `game/Mods/BAPBAP.Medusa.dll`. (Avoids Windows-backslash entries that Linux
  unzip rejects.)
- Output: `deployment\amp-full-linux-wine\bapcustomserver-amp-full-linux-wine.zip`
  — on disk **552,545,661 B**, mtime **2026-05-31 16:21**.
- `:~735-745` `Set-ZipUnixExecutableAttribute` marks `BapCustomServer`,
  `amp-webpanel-start.sh`, `start-linux-wine.sh`, `start-match.sh`, `createdump`
  as Unix-executable (0755) inside the zip.

Upload (`tools\Publish-GitHubAmpRelease.ps1`):
- `:16` `$FullZip = deployment\amp-full-linux-wine\bapcustomserver-amp-full-linux-wine.zip`
- `:17` `$TemplateZip = deployment\amp-github-autoinstall\bapcustomserver-github-autoinstall-template.zip`
- `:18` `$ClientZip = deployment\client-bundle\BAPBAP-CustomServer-Client.zip`
- `:25-29` Unless `-SkipRebuild`, it rebuilds all three via
  `Build-AmpFullLinuxWinePackage.ps1`, `Build-AmpGitHubAutoInstallPackage.ps1`,
  `Build-ClientBundle.ps1`.
- `:68` `gh release create $Tag $FullZip $TemplateZip $ClientZip --repo $Repository --title $Tag --notes …`
- `$Tag` defaults to `bapcustomserver-<yyyyMMdd-HHmmss>` → **a NEW release/tag each run**.

AutoInstall template (`tools\Build-AmpGitHubAutoInstallPackage.ps1`): builds only
the small template zip (`manifest.json`, `bapcustomservergithub.kvp`,
`bapcustomservergithubupdates.json`, config/metaconfig/ports JSON, README). It does
**not** contain any game/Medusa binaries — those travel only in the full zip via
the GithubRelease update stage. `$AssetName` default =
`bapcustomserver-amp-full-linux-wine.zip` (wired into the updates manifest as
`__PACKAGE_ASSET__`).

---

## 3. Pinned-hash verification (what IS and ISN'T enforced)

`Build-AmpFullLinuxWinePackage.ps1`:
- `:661` `$ExpectedModDllSha256 = '3E796F1E…4EA15E8D'`
- `:662` `$ModDllZipEntryName = 'game/Mods/BapCustomServerMelon.dll'`
- `:686-690` `foreach ($requiredEntry in @('game/Mods/BAPBAP.ModAPI.dll',
  'game/UserLibs/BAPBAP.ModAPI.dll','game/Mods/BAPBAP.Medusa.dll',
  'game/UserData/Medusa/medusa.bundle')) { … throw if not found }` —
  **EXISTENCE ONLY, no SHA.**
- `:~728-732` throws only if the **Melon** DLL SHA ≠ `3E796F1E…`.
- `:733-734` prints "Verified mod DLL SHA256 …" + "Verified Medusa artifacts inside
  AMP zip." — the Medusa line means *present*, not *hash-verified*.

`Build-ClientBundle.ps1`: same pattern — `:12` pins Melon `3E796F1E…` (source check
`:~25-30` and post-zip check), Medusa entries (`Mods/BAPBAP.ModAPI.dll`,
`UserLibs/BAPBAP.ModAPI.dll`, `Mods/BAPBAP.Medusa.dll`,
`UserData/Medusa/medusa.bundle`) **existence-checked only**.

Also `Build-AmpFullLinuxWinePackage.ps1:21-30` (and the early guard `~:150`) hard-
require the Melon dist DLL to be `3E796F1E…` / 210,432 B and **refuse to auto-
rebuild** it — but there is no equivalent pin/refusal for Medusa. `deployment-info.json:507-508`
records `medusaDllSha256`/`medusaBundleSha256` purely for traceability; nothing
enforces them, and here they are demonstrably wrong vs the staged/zip bytes.

GAP: a stale, mismatched, or even hand-swapped Medusa DLL/bundle ships without
tripping any guard. Confidence: HIGH.

(Cross-ref: `tools\Test-AmpLivePublic.ps1:11,120` pins an *expected full-zip*
SHA256 `5f6c99…` for a live published asset — a separate post-publish check, not
part of the package builders.)

---

## 4. AMP persistence — why a live-uploaded `BAPBAP.Medusa.dll` resets

Mechanism (`deployment\amp-github-autoinstall\bapcustomservergithubupdates.json`,
synced to the instance as `bapcustomservergithubupdates.json` and referenced by
`bapcustomservergithub.kvp` → `App.UpdateSources=@IncludeJson[…]`):

The "Download BAPBAP Custom Server full package" stage:
```json
{ "UpdateSource":"GithubRelease",
  "UpdateSourceArgs":"Sonic0810/BAPBAP-CustomServer-AMPTemplates",
  "UpdateSourceData":"bapcustomserver-amp-full-linux-wine.zip",
  "UpdateSourceTarget":"{{$FullBaseDir}}",
  "UnzipUpdateSource":true, "OverwriteExistingFiles":true,
  "DeleteAfterExtract":true, "SkipOnFailure":false }
```
- Pressing **Update** re-downloads the GitHub-release zip and extracts over
  `{{$FullBaseDir}}` with `OverwriteExistingFiles=true`. That **overwrites
  `game/Mods/BAPBAP.Medusa.dll` and `game/UserData/Medusa/medusa.bundle`** with the
  release's bytes.
- `bapcustomservergithub.kvp`: `App.SmartExcludeExemptions=["*.json","*.log","*.jsonl"]`
  + `App.SmartExcludeSupported=True`. Only json/log/jsonl are preserved across
  updates; the Medusa **binaries are not exempt → always replaced**. (This is why
  `data/`/`logs/` are stripped from the zip but Medusa is not preserved.)
- `App.ForceUpdate=False` ⇒ AMP does **not** auto-update on every Start. A hand-
  uploaded DLL therefore *survives plain restarts* but is reverted the next time
  the operator presses **Update** (or "Update & Start", or recreates the instance).

Hypotheses for "live-uploaded DLL resets" (confidence in parentheses):
1. Operator pressed **Update**, which re-extracted the release zip over the
   SFTP/File-Manager-uploaded DLL. (HIGH)
2. The GitHub release asset still contains the **stale** Medusa (`4D3050CA`/
   `2F2CCF12` per §0), so even a "correct" Update reverts to old VFX, making the
   hand-upload look like it "reset" to broken. (HIGH — proven by zip-entry hashing)
3. `GithubRelease` source pulls the **latest** release; since Publish creates a new
   tag each run, an SFTP DLL is unrelated to any release and can never win an
   Update. (HIGH)

Real persistent update path (the supported one):
1. Rebuild Medusa in `BAPBAPModdingAPI\medusa-mod` (DLL + `medusa.bundle`).
2. Run `tools\Build-AmpFullLinuxWinePackage.ps1` → regenerates the 552 MB zip with
   the new DLL/bundle copied via L103/L106 (verify `deployment-info.json` hashes
   actually change and zip mtime advances).
3. Run `tools\Publish-GitHubAmpRelease.ps1 -Repository Sonic0810/BAPBAP-CustomServer-AMPTemplates`
   → `gh release create` a new tag and uploads the zip as the release asset.
4. In AMP press **Update** then **Start** (GithubRelease pulls the new latest asset).

SFTP / File-Manager (web upload) alternative — valid but fragile:
- Replace `<instance>/BapCustomServer/game/Mods/BAPBAP.Medusa.dll` **and**
  `…/game/UserData/Medusa/medusa.bundle` directly; effective on next **Start**.
- Survives restarts (ForceUpdate=False) but is wiped by the next **Update**. To make
  it durable you must also publish a matching release (steps 2-3). For a quick
  durable-ish workaround without GitHub, an operator could neutralize the
  GithubRelease stage (it is `SkipOnFailure:false`, so it can't simply be skipped) —
  not recommended; publishing the release is the correct fix.

---

## 5. Note for sibling agents (out of D2 scope, packaging-side only)

The "green lines + Kitsu FX instead of real Medusa VFX" symptom is consistent, on
the packaging side, with **shipping an older Medusa DLL + smaller `medusa.bundle`**
(1.28 MB `2F2CCF12` vs current 1.57 MB `C4872D6E`). A ~284 KB smaller bundle is a
plausible "missing/old VFX assets" signature. Whether the green-line fallback is
caused by the older bundle's contents vs runtime asset-load failure is for the
VFX/runtime agents; D2 confirms only that the **wrong (older) Medusa bytes are what
the release actually delivers.**

---

## 6. Confidence summary

- Package file map + sources (file:line): **HIGH** (read directly from scripts; staged tree matches the copy logic).
- 552 MB zip production + GitHub upload path: **HIGH** (scripts + on-disk zip 552,545,661 B / mtime 16:21).
- Pinned-hash verification covers only Melon, Medusa existence-only: **HIGH** (L661-690, L728-734; Client bundle mirror).
- Shipped zip contains STALE Medusa vs source, deployment-info mislabels it: **HIGH** (SHA256 measured in source, staged tree, and inside the zip).
- AMP Update overwrites live-uploaded Medusa (persistence cause + fix): **HIGH** for the GithubRelease/Overwrite mechanism; **MEDIUM** on the exact operator action that triggered the user's observed reset (Update vs recreate vs Update&Start) — not directly observable from files.
