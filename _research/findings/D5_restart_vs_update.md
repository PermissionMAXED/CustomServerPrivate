# D5 — Restart vs Update: which AMP action overwrites files?

Scope: Clarify the user's claim "after RESTART old files come back." Determine
whether a plain AMP Restart / Stop-Start re-extracts the package (resetting a
live-uploaded `BAPBAP.Medusa.dll` etc.) or whether only the explicit **Update**
button does. READ-ONLY. No source/code/build/deploy changes were made.

Files read (canonical live template = `deployment/amp-github-autoinstall/`, which
`bapbap-amp-setup.sh` curls straight into the instance as `GenericModule.kvp`):
- `deployment/amp-github-autoinstall/bapcustomservergithub.kvp`
- `deployment/amp-github-autoinstall/bapcustomservergithubupdates.json`
- `deployment/amp-github-autoinstall/bapcustomservergithubmetaconfig.json`
- `deployment/amp-github-autoinstall/bapbap-amp-setup.sh`
- `deployment/amp-full-linux-wine/package/BapCustomServer/amp-webpanel-start.sh`
- `deployment/amp-full-linux-wine/package/BapCustomServer/start-linux-wine.sh`
- `deployment/amp-full-linux-wine/start-match.sh`
- `deployment/amp-full-linux-wine/package/README-FULL-LINUX-WINE.md`
- root `README.md` (context)

---

## VERDICT (high confidence)

**A plain AMP Restart / Stop-Start does NOT re-extract the package and does NOT
reset `BAPBAP.Medusa.dll` or any game/mod file. Only the AMP "Update" button
re-downloads and overwrites those files.** The user's "old files come back" is
caused by pressing **Update** (or the first-run install), not by Restart.

The single exception at Start time: AMP regenerates **`appsettings.json` only**
from the UI/metaconfig values. No DLLs, no `game/`, no `Mods/` files are touched
on Start/Restart.

---

## Evidence — what STARTS the server (Start / Restart path)

`bapcustomservergithub.kvp`:
- L25 `App.ExecutableLinux=/bin/sh`
- L27 `App.CommandLineArgs=./amp-webpanel-start.sh "http://{{$ApplicationIPBinding}}:{{$ApplicationPort1}}"`
- L47 `App.PreStartStages=[]`  ← **empty: no pre-start extraction/copy stage runs before Start**
- L48 `App.ForceUpdate=False`  ← **Start does NOT auto-run the UpdateSources stages**
- L50 `App.RapidStartup=False`

So Start/Restart only executes `amp-webpanel-start.sh`. That script
(`amp-full-linux-wine/package/BapCustomServer/amp-webpanel-start.sh`) does:
- `chmod +x ./BapCustomServer ...`
- echo release/deployment-info diagnostics
- optional Wine prewarm: `./start-match.sh --prewarm ./game/bapbap.exe -batchmode -nographics`
- `exec ./BapCustomServer --urls "$LISTEN_URL"`

It contains **no `unzip`, no `cp`, no `curl`/download, no GithubRelease/extract**.
Quote (final line): `exec ./BapCustomServer --urls "$LISTEN_URL"`.

`start-match.sh` is launched per-match (and for prewarm). The only deletion it
performs is `rm -rf "$WINEPREFIX"` (default `./wineprefix32`) when the Wine
compat key changes — that wipes the **Wine prefix only**, never `Mods/` or
`game/` game assets. Quote:
`echo "[start-match] wineprefix key changed; resetting prefix"` then
`rm -rf "$WINEPREFIX"`. Irrelevant to the Medusa DLL reset.

## Evidence — what OVERWRITES files (Update path)

`bapcustomservergithub.kvp` L46:
`App.UpdateSources=@IncludeJson[bapcustomservergithubupdates.json]` — these
stages run **only on the Update button** (and on the initial instance install),
because `App.ForceUpdate=False` and `App.PreStartStages=[]`.

`bapcustomservergithubupdates.json`, stage "Download BAPBAP Custom Server full
package" (≈L52–61) is the file-resetting stage:
- L54 `"UpdateSource": "GithubRelease"`
- L56 `"UpdateSourceData": "bapcustomserver-amp-full-linux-wine.zip"`
- L57 `"UpdateSourceTarget": "{{$FullBaseDir}}"`  (= `./BapCustomServer/`)
- L58 `"UnzipUpdateSource": true`
- L59 `"OverwriteExistingFiles": true`  ← **this overwrites the on-disk DLLs/game files**
- L60 `"DeleteAfterExtract": true`
- L61 `"SkipOnFailure": false`

That GitHub Release zip is documented (`README-FULL-LINUX-WINE.md`) to contain
`Mods/BAPBAP.Medusa.dll`, `Mods/BAPBAP.ModAPI.dll`, `UserLibs/BAPBAP.ModAPI.dll`,
`UserData/Medusa/medusa.bundle`, the Unity `game/` build, and MelonLoader. So an
Update **replaces the live Medusa DLL with whatever version is baked into the
published release asset** = "old files come back."

Update is explicitly the documented file-refresh action:
- kvp L2 `Meta.Description=... Click Update to refresh game files; user data and stats are preserved.`
- `bapbap-amp-setup.sh` (setup-complete banner): "Server code update → AMP UI Update button (downloads new bundle, refreshes ONLY the game/server files...)"; "Daily start/stop → AMP UI Start/Stop buttons" (no file change mentioned).
- root `README.md`: create instance → "press `Update`, then press `Start`."

## Evidence — Start-time `appsettings.json` regeneration (the one Start-time write)

`bapcustomservergithubmetaconfig.json`:
```json
[ { "ConfigFile": "appsettings.json", "ConfigType": "json", "AutoMap": true, "Importable": true } ]
```
`bapbap-amp-setup.sh` confirms: "AMP rewrites appsettings.json from your UI values
on every Start (via metaconfig). Your UI changes survive every Update." → On every
Start/Restart, `appsettings.json` is rewritten from the AMP UI fields. A manual
SFTP edit to `appsettings.json` IS reverted by a plain Restart; a manual edit to a
`.dll` is NOT.

## SmartExclude nuance (medium confidence)

kvp L51 `App.SmartExcludeExemptions=["*.json","*.log","*.jsonl"]`,
L52 `App.SmartExcludeSupported=True`. SmartExclude can preserve user-modified
files across an Update, but the exemption list (always-overwrite) is only
`*.json/*.log/*.jsonl`; a `.dll` is not exempt. In AMP, SmartExclude normally
*protects* user-changed files it has a recorded baseline for — but an SFTP upload
done outside AMP may not have a trusted baseline, and the stage's
`OverwriteExistingFiles:true` + the explicit "Click Update to refresh game files"
intent mean the **designed behavior is that Update overwrites `BAPBAP.Medusa.dll`**.
I could not execute AMP to confirm the exact SmartExclude/GithubRelease interaction;
treat the precise preservation behavior as a hypothesis, but the dominant outcome
(Update reverts the DLL) is well supported.

---

## Reconciling the user's claim + persistent-update path (AMP persistence sub-question)

- "After RESTART old files come back" → **misattribution**. Restart/Stop-Start
  does not re-extract. The reset happens on **Update** (or first install). Likely
  the user pressed Update (the UI/Docs literally tell them to "Click Update"),
  or conflates Start-after-Update with a bare Restart.
- **Why a live-uploaded `BAPBAP.Medusa.dll` resets:** the next Update re-extracts
  `bapcustomserver-amp-full-linux-wine.zip` over `./BapCustomServer/` with
  `OverwriteExistingFiles:true`, restoring the DLL shipped inside the release
  asset (current `deployment-info.json` records `medusaDllSha256:999D4BDF...`,
  `releaseLabel: bapcustomserver-20260531-medusa-v173-livepatch`).
- **Real persistent update path:** rebuild the package, publish a NEW GitHub
  Release asset named `bapcustomserver-amp-full-linux-wine.zip` in repo
  `Sonic0810/BAPBAP-CustomServer-AMPTemplates`, then press Update. The new DLL is
  then the one that "comes back" every Update.
- **SFTP / web-upload alternative:** dropping a DLL into
  `<instance>/BapCustomServer/Mods/` via SFTP or the AMP File Manager **survives
  Restart/Stop-Start indefinitely**, but is overwritten by the next Update unless
  SmartExclude protects it (uncertain — see nuance). For a durable hand-patch
  without republishing: upload via SFTP and then only ever use Start/Stop, never
  Update. To make it truly permanent, the change must go into the published
  Release zip.

## Confidence
- Restart/Stop-Start does NOT re-extract game/mod files: **HIGH** (PreStartStages
  empty, ForceUpdate False, start script has no extract/copy).
- Update re-extracts + overwrites the Medusa DLL: **HIGH** (explicit GithubRelease
  + UnzipUpdateSource:true + OverwriteExistingFiles:true + Meta.Description).
- `appsettings.json` (only) is rewritten on every Start: **HIGH** (metaconfig AutoMap).
- Exact SmartExclude preservation behavior for an SFTP-uploaded DLL on Update:
  **MEDIUM/LOW** (could not run AMP).
