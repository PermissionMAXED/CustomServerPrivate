# D3 — Why a live-uploaded `Mods/BAPBAP.Medusa.dll` gets reset (AMP persistence)

Session: `D3_why_dll_reset` — READ-ONLY research. No source/build/deploy changes were made.
Scope: confirm exactly why a live-uploaded `Mods/BAPBAP.Medusa.dll` resets on AMP, the real
persistent update path, and the SFTP/web-upload alternative. Distinguish **Update** (re-extract)
vs **Start** (no re-extract) vs **Restart**.

All paths below are under `C:\Users\Administrator\Downloads\CustomServer`.

---

## TL;DR (the answer)

A live-uploaded `BapCustomServer/game/Mods/BAPBAP.Medusa.dll` is **overwritten whenever the operator
presses AMP "Update"**, because the AMP `App.UpdateSources` pipeline re-downloads the GitHub Release
ZIP (`bapcustomserver-amp-full-linux-wine.zip`) — which itself **contains** `game/Mods/BAPBAP.Medusa.dll`
— and unzips it into the instance base directory with `OverwriteExistingFiles: true`.

- **Update = re-extract + overwrite** → resets the DLL. (HIGH confidence)
- **Start = no re-extract** (only rewrites `appsettings.json` from UI values) → DLL **survives**. (HIGH confidence)
- **Restart = Stop + Start = no re-extract** → DLL **survives**. (HIGH confidence)

Only `data/**` and `logs/**` are persistent across Update, and only because they are excluded from the
ZIP payload — **not** because of any per-file protection of `game/Mods/`.

---

## Smoking gun: the overwrite path (file:line)

`deployment\amp-github-autoinstall\bapcustomservergithubupdates.json` — the AMP `App.UpdateSources`
pipeline. The decisive stage:

```json
// lines 52–62
"UpdateStageName": "Download BAPBAP Custom Server full package",
"UpdateSourcePlatform": "Linux",
"UpdateSource": "GithubRelease",
"UpdateSourceArgs": "Sonic0810/BAPBAP-CustomServer-AMPTemplates",
"UpdateSourceData": "bapcustomserver-amp-full-linux-wine.zip",
"UpdateSourceTarget": "{{$FullBaseDir}}",
"UnzipUpdateSource": true,
"OverwriteExistingFiles": true,
"DeleteAfterExtract": true,
"SkipOnFailure": false
```

- **`bapcustomservergithubupdates.json:55`** `"UpdateSource": "GithubRelease"` — Update fetches the Release asset.
- **`:57`** `"UpdateSourceData": "bapcustomserver-amp-full-linux-wine.zip"` — the full bundle (contains game files + Mods).
- **`:58`** `"UpdateSourceTarget": "{{$FullBaseDir}}"` — extraction target is the base dir.
- **`:59`** `"UnzipUpdateSource": true` — it is extracted in place.
- **`:60`** `"OverwriteExistingFiles": true` — existing files are overwritten. **← the reset.**
- **`:62`** `"SkipOnFailure": false` — this stage is mandatory on every Update (cannot be skipped).

`{{$FullBaseDir}}` resolves to the instance's `BapCustomServer/` directory:

- `deployment\amp-github-autoinstall\bapcustomservergithub.kvp:24` `App.BaseDirectory=./BapCustomServer/`
- `...kvp:23` `App.RootDir=./BapCustomServer/`

So the ZIP extracts to `BapCustomServer/`, and any `game/Mods/...` entry lands at
`BapCustomServer/game/Mods/...`, overwriting the live-uploaded file.

### Proof the Medusa DLL is *inside* that ZIP (so it gets re-written, not just left alone)

`deployment\amp-github-autoinstall\verify-amp-instance.sh` asserts the post-extract layout includes
the Medusa DLL under `game/Mods/`:

- **`verify-amp-instance.sh:74`** `require_file "./game/Mods/BAPBAP.Medusa.dll"`
- `:70` `require_file "./game/Mods/BapCustomServerMelon.dll"`
- `:72` `require_file "./game/Mods/BAPBAP.ModAPI.dll"`
- `:71` `require_file "./game/Mods/BapCustomServer.ini"`

`MEDUSA_SERVER_INTEGRATION.md` confirms the packagers ship these files inside the bundle:
"The client and AMP packages must ship all of these files: `Mods/BAPBAP.ModAPI.dll`,
`UserLibs/BAPBAP.ModAPI.dll`, `Mods/BAPBAP.Medusa.dll`, `UserData/Medusa/medusa.bundle`"
(`docs\MEDUSA_SERVER_INTEGRATION.md`, "Client artifacts" section).

### Explicit documentation that `game/Mods/` is refreshed by updates

- **`deployment\amp-github-autoinstall\README.md:74`**: "Dedicated game config under `game/Mods/`
  and `game/UserData/` is refreshed by updates; those files are runtime/mod configuration, not
  player state." (identical text in `package\README-AMP-GITHUB-AUTOINSTALL.md:74`)
- **`deployment\amp-github-autoinstall\bapbap-amp-setup.sh:194-196`**: "Dedicated game config files
  under game/Mods/ and game/UserData/ are mod/runtime configuration and **may be refreshed by updates**
  so Wine/headless server defaults stay correct."

These lines are the authors' own statement that the directory holding `BAPBAP.Medusa.dll` is
intentionally overwritten on Update.

---

## Update vs Start vs Restart (distinguished with file:line)

### Update → RE-EXTRACT (resets the DLL) — HIGH confidence
- Runs all stages in `bapcustomservergithubupdates.json`. Stages 1–5 (`:3`, `:14`, `:25`, `:36`, `:45`)
  re-sync the KVP/configmanifest/ports/updates/metaconfig from GitHub raw into the instance root
  (`UpdateSourceTarget: {{$FullInstanceDir}}`, `OverwriteExistingFiles: true`).
- Stage 6 (`:52-62`) re-downloads + unzips the full package over `{{$FullBaseDir}}`
  (`OverwriteExistingFiles: true`) → overwrites `game/Mods/BAPBAP.Medusa.dll`.
- Stages 7–11 (`SetExecutableFlag`) just re-chmod the Linux launch files.
- Net effect: a live-uploaded Medusa DLL is replaced by the DLL baked into the published Release ZIP.

### Start → NO RE-EXTRACT (DLL survives) — HIGH confidence
- `bapcustomservergithub.kvp:47` `App.PreStartStages=[]` — there are **no** pre-start stages, so Start
  performs no download/unzip.
- `bapcustomservergithub.kvp:49` `App.ForceUpdate=False` — Start does **not** force an Update first.
- `bapcustomservergithub.kvp:51` `App.RapidStartup=False`.
- `bapcustomservergithub.kvp:27` `App.CommandLineArgs=./amp-webpanel-start.sh ...` — Start only runs the
  existing launch script + binary.
- The only thing Start mutates is `appsettings.json`, rewritten from AMP UI values via the metaconfig:
  `bapbap-amp-setup.sh` "GOING FORWARD" notes "AMP rewrites appsettings.json from your UI values on
  every Start (via metaconfig)." This touches config JSON, **not** `game/Mods/`.

### Restart → Stop + Start = NO RE-EXTRACT (DLL survives) — HIGH confidence
- Restart is just Stop then Start; same as Start above. No update stages run, so the live DLL persists.

**Conclusion:** the DLL "reset" is specifically and only triggered by the **Update** button (or any flow
that runs `App.UpdateSources`), never by Start or Restart.

---

## Why `data/`/`logs/` survive but `game/Mods/*.dll` does not

Persistence is achieved by **excluding files from the ZIP payload**, not by per-file protection:

- `README.md` "Preserved runtime data": "The update ZIP must not contain `data/**` or `logs/**`." and
  "Dedicated game config under `game/Mods/` and `game/UserData/` is refreshed by updates."
- The one-shot `bapbap-amp-setup.sh` python extractor only protects `data/`, `logs/`,
  `*.jsonl`, and `*-state.json` (its `protected = (...)` block) — it explicitly does **not** protect
  `game/Mods/*.dll`. (Note: this script is the manual SSH repair path; the live AMP "Update" uses
  `bapcustomservergithubupdates.json` instead, which has no such protection at all — only blanket
  `OverwriteExistingFiles: true`.)

### SmartExclude note (MEDIUM confidence on AMP semantics)
- `bapcustomservergithub.kvp:52` `App.SmartExcludeExemptions=["*.json","*.log","*.jsonl"]`
- `bapcustomservergithub.kvp:53` `App.SmartExcludeSupported=True`
- `.dll` is **not** in the exemption list. Regardless of the exact direction of AMP's SmartExclude
  semantics (which I could not verify from these files alone), the conclusion is unchanged: the
  decisive overwrite is the `OverwriteExistingFiles: true` extraction in stage 6, and the authors
  document `game/Mods/` as refreshed on Update.

---

## The real persistent update path (HIGH confidence)

To change the Medusa DLL durably so Update does **not** revert it, the new DLL must be baked into the
published Release bundle, then Update pulls it down:

1. Rebuild the full bundle with the new DLL: `tools\Build-AmpFullLinuxWinePackage.ps1`
   (`MEDUSA_SERVER_INTEGRATION.md` "Packaging" / "Verification performed" sections).
2. Publish a new GitHub Release on `Sonic0810/BAPBAP-CustomServer-AMPTemplates` using the **same asset
   name** `bapcustomserver-amp-full-linux-wine.zip`.
   - `README.md` (deployment): "For updates later, publish a new GitHub Release with the same asset name
     and press `Update` in AMP. This refreshes server/game/mod files ... while preserving `data/**` and `logs/**`."
3. Press **Update** in AMP → stage 6 fetches the new ZIP and overwrites `game/Mods/BAPBAP.Medusa.dll`
   with the new build.

This is the only path where the DLL change is authoritative and survives subsequent Updates, because the
Release ZIP is the source of truth that every Update re-applies. `AMP_LINUX_WINE_ROOT_CAUSE.md`
("End-to-end proof") shows this exact loop: "AMP BAPBattle was stopped, updated through the web panel,
restarted, and `/health` reported `bapcustomserver-20260531-medusa-v172`."

---

## SFTP / web-upload alternative (MEDIUM confidence — derived, not explicitly documented)

Neither the KVP nor the docs describe an SFTP/file-manager workflow, but the Update/Start mechanics
imply the following:

- Uploading a new `BAPBAP.Medusa.dll` directly into the instance's
  `.../instances/<INSTANCE>/BapCustomServer/game/Mods/` (via AMP File Manager, SFTP, or
  `docker cp`/`docker exec`) **will work and persist across Start and Restart**, because those flows do
  not re-extract (see Start/Restart above).
- **It is wiped by the next Update**, because stage 6 re-extracts the Release ZIP over `game/Mods/`.
  So a live SFTP upload is a valid *hotfix for the current session* but is fragile: any future Update
  reverts it.
- Operator guidance implied by the design: use SFTP/upload only for quick iteration; for a durable
  change, also rebuild + republish the Release ZIP (the persistent path above). If using SFTP-only,
  the operator must avoid pressing Update.

Caveat: I could not verify from these files whether AMP exposes SFTP for this Generic-module instance
or whether the container layout matches `.../instances/<INSTANCE>/BapCustomServer/game/Mods/` exactly
(the live container path appears as `/AMP/BapCustomServer` in `verify-amp-instance.sh:3`
`APP_DIR="${APP_DIR:-/AMP/BapCustomServer}"`, and `bapbap-amp-setup.sh` uses
`/home/amp/.ampdata/instances/<INSTANCE>/BapCustomServer`). The persistence logic holds regardless of
the exact mount path.

---

## Hypotheses + confidence summary

| # | Hypothesis | Confidence | Key evidence |
|---|------------|-----------|--------------|
| H1 | Live-uploaded `game/Mods/BAPBAP.Medusa.dll` is reset by **Update**, via re-extract of the Release ZIP with `OverwriteExistingFiles: true` | **HIGH** | `bapcustomservergithubupdates.json:52-62`; ZIP contains the DLL per `verify-amp-instance.sh:74`; docs `README.md:74`, `bapbap-amp-setup.sh:194-196` |
| H2 | **Start** does not re-extract; DLL survives Start | **HIGH** | `kvp:47` `PreStartStages=[]`, `kvp:49` `ForceUpdate=False`, `kvp:27` runs only the launch script |
| H3 | **Restart** = Stop+Start; DLL survives Restart | **HIGH** | Same as H2; Restart adds no update stage |
| H4 | Persistence for `data/`/`logs/` is by ZIP exclusion, not file protection; `game/Mods/` is deliberately not protected | **HIGH** | `README.md` "Preserved runtime data"; `bapbap-amp-setup.sh` python `protected` block omits `game/Mods` |
| H5 | Durable fix = rebuild bundle + republish same-named Release asset, then Update | **HIGH** | `README.md` "For updates later..."; `MEDUSA_SERVER_INTEGRATION.md` Packaging |
| H6 | SFTP/web-upload to `game/Mods/` persists across Start/Restart but is wiped by next Update | **MEDIUM** | Derived from H1/H2/H3; not explicitly documented |
| H7 | Exact AMP SmartExclude direction for non-exempt `.dll` | **LOW/UNVERIFIED** | `kvp:52-53`; AMP-internal semantics not in repo; does not change H1 |

---

## Adjacent evidence found while in-scope (for other agents D1/D2/D4 etc.)

These were observed in D3 files and may help the broader investigation; not part of the D3 deliverable:

- **Kitsu/Skinny fallback cause** (`docs\MEDUSA_SERVER_INTEGRATION.md`, "Root cause and final fix"):
  the runtime Medusa prefab was cloned from a base character whose Mirror `NetworkIdentity` carried
  `hasSpawned=True`; Mirror rejected it with `Char_Medusa(Clone) has already spawned`, and the local
  primary/auth path "fell back into Skinny/Kitsu state." v1.6.24+ sanitizes the NetworkIdentity and
  assigns asset id `0x4D454455` ("MEDU").
- **Green ability lines / Kitsu FX** (`MEDUSA_SERVER_INTEGRATION.md`, "Known limits"): "this server
  integration does not invent native bespoke Medusa ability ScriptableObjects, because this old BAPBAP
  build does not contain them ... the current implementation uses a **Kitsu-based kit plus Medusa
  visuals/status/effect bridges**" and "Medusa-green runtime ability UI". This points to the abilities
  being a Kitsu kit re-skinned green rather than native Medusa VFX.
- **Queue / first-attempt-fails-then-works** (`docs\AMP_LINUX_WINE_ROOT_CAUSE.md`, "What was broken"):
  `POST .../setup-game Connection refused` + "did not accept match bootstrap data before timeout"
  caused the player to "sit in queue or was requeued" until the Wine/Xvfb match process opened its
  bootstrap listener — a plausible mechanism for the "first attempt fails then works" / long-queue
  symptom. (Belongs to the queue-timing agent; flagged here only as a pointer.)
