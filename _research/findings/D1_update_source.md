# D1 — Which source AMP restores on Update/Start

Scope: identify the exact source AMP downloads/extracts on Update, confirm it
re-extracts the full package over live files, and explain why a live-uploaded
`BAPBAP.Medusa.dll` resets. READ-ONLY; no source/build/deploy changes made.

Canonical-source verification: the staged copies under
`deployment\amp-github-autoinstall\` are **byte-identical** to the published
`deployment\github-release\amptemplates-root-repo\` copies that get pushed to
GitHub raw (the source AMP actually fetches):
- `bapcustomservergithubupdates.json` SHA256 `FF1C797A532F7508109B8CBD02151C32ED4371D014157757794C2A57C703E6DA` (both copies match)
- `bapcustomservergithub.kvp` SHA256 `1FD9F1E526ADFE0CBCBDE7367846BA14BCC2C8406C5DDD9A9568CC45533570D8` (both copies match)
So the line citations below represent the live remote source.

---

## 1. The exact GitHub release asset AMP downloads + extraction target

File: `deployment\amp-github-autoinstall\bapcustomservergithubupdates.json`
(stage "Download BAPBAP Custom Server full package", lines 51–66):

```
52:    "UpdateStageName": "Download BAPBAP Custom Server full package",
54:    "UpdateSource": "GithubRelease",
55:    "UpdateSourceArgs": "Sonic0810/BAPBAP-CustomServer-AMPTemplates",
56:    "UpdateSourceData": "bapcustomserver-amp-full-linux-wine.zip",
57:    "UpdateSourceTarget": "{{$FullBaseDir}}",
58:    "UnzipUpdateSource": true,
59:    "OverwriteExistingFiles": true,
60:    "DeleteAfterExtract": true,
61:    "SkipOnFailure": false
```

- Asset downloaded: **`bapcustomserver-amp-full-linux-wine.zip`** from GitHub
  Release of repo `Sonic0810/BAPBAP-CustomServer-AMPTemplates`.
- Extraction target `{{$FullBaseDir}}` resolves to `App.BaseDirectory`, i.e.
  the live game/server dir **`./BapCustomServer/`**.

File: `deployment\amp-github-autoinstall\bapcustomservergithub.kvp`:
```
23:App.RootDir=./BapCustomServer/
24:App.BaseDirectory=./BapCustomServer/      <- {{$FullBaseDir}}
46:App.UpdateSources=@IncludeJson[bapcustomservergithubupdates.json]
49:App.ForceUpdate=False
52:App.SmartExcludeExemptions=["*.json","*.log","*.jsonl"]
53:App.SmartExcludeSupported=True
```

## 2. Confirmation: Update re-extracts the FULL package over live files

CONFIRMED. The GithubRelease stage has `UnzipUpdateSource:true`,
`OverwriteExistingFiles:true`, `SkipOnFailure:false`, target `{{$FullBaseDir}}`
(= `./BapCustomServer/`). Every time the operator presses **Update**, AMP
re-downloads `bapcustomserver-amp-full-linux-wine.zip` and unzips it ON TOP of
the live `BapCustomServer/` directory, overwriting existing files (it does not
wipe-then-extract; it overwrites). The README beside it confirms the intent:
`deployment\amp-github-autoinstall\README.md`:
- "AMP unzips it into the instance base directory (`BapCustomServer/`)."
- "For updates later, publish a new GitHub Release with the same asset name and
  press `Update` in AMP. This refreshes server/game/mod files ... while
  preserving `data/**` and `logs/**`."
- "Current Medusa artifacts: ... `BAPBAP.Medusa.dll 4D3050CAC36C94AA726F575DE2F271A34248EB70CC81D6C55D27F2248CFBA16C`"
  → the Medusa DLL is baked INTO the release ZIP.

The 5 preceding `FetchURL` stages (lines 1–50) also re-sync the AMP UI template
files (kvp/configmanifest/metaconfig/ports/updates) from
`raw.githubusercontent.com/Sonic0810/BAPBAP-CustomServer-AMPTemplates/main/...`
into `{{$FullInstanceDir}}` with `OverwriteExistingFiles:true` — so the template
itself is also restored-from-GitHub on every Update.

Start does NOT re-extract: `App.ForceUpdate=False` (line 49) means pressing
Start alone runs `./amp-webpanel-start.sh` without triggering the update
sequence. Only the **Update** button runs the GithubRelease re-extract.

## 3. Why a live-uploaded `BAPBAP.Medusa.dll` resets

ROOT CAUSE (high confidence): `BAPBAP.Medusa.dll` is shipped inside
`bapcustomserver-amp-full-linux-wine.zip`. When the operator SFTP/web-uploads a
newer DLL into the live `BapCustomServer/` dir and later presses **Update**, the
GithubRelease stage (lines 52–61, `OverwriteExistingFiles:true`) unzips the
release copy over the live copy, reverting the DLL to the version baked into the
last-published release. The live edit is lost because it was never published
into the release asset.

`*.dll` is NOT protected: `App.SmartExcludeExemptions` (line 52) lists only
`*.json`, `*.log`, `*.jsonl`. `data/**` and `logs/**` survive only because the
README states they are excluded from the ZIP, not because of a runtime guard.

## 4. The real persistent update path

To make a Medusa DLL change persist across Update:
1. Rebuild `bapcustomserver-amp-full-linux-wine.zip` with the new
   `BAPBAP.Medusa.dll` inside (see `deployment\github-release\F18_AMP_RELEASE_RUNBOOK.md`).
2. Publish a new GitHub Release on `Sonic0810/BAPBAP-CustomServer-AMPTemplates`
   reusing the SAME asset name `bapcustomserver-amp-full-linux-wine.zip`
   (the manifest matches by `UpdateSourceData` filename, not by tag).
3. Press **Update** in AMP → the new ZIP is the one re-extracted.

This is the only update-safe path. A live SFTP/web-upload is only a temporary
hotfix that survives Start/restart but is wiped on the next Update.

## 5. SFTP / web-upload alternative (persistence caveat)

- A direct SFTP / AMP File Manager upload of `BAPBAP.Medusa.dll` into
  `BapCustomServer/` takes effect immediately and survives a plain Start/Stop
  (because Start does not re-extract; `ForceUpdate=False`).
- It does NOT survive **Update**, because the GithubRelease stage overwrites it.
- There is no per-file exemption that would protect a hand-uploaded `.dll`.

## 6. Hypotheses + confidence

- H1 (CONFIRMED, ~0.97): The asset is `bapcustomserver-amp-full-linux-wine.zip`,
  source `GithubRelease Sonic0810/BAPBAP-CustomServer-AMPTemplates`, extracted
  into `BapCustomServer/` with overwrite=true on every Update. Direct file:line
  evidence above.
- H2 (HIGH, ~0.9): Live-uploaded DLL resets because the release ZIP contains the
  DLL and is re-extracted over it on Update. README + hash evidence support it.
- H3 (MEDIUM, ~0.6): `App.SmartExcludeSupported=True` could in some AMP versions
  preserve user-modified files by hash-tracking; but the observed reset implies
  SmartExclude does not protect a `.dll` that arrives outside AMP's own update
  bookkeeping (e.g. SFTP), and `OverwriteExistingFiles:true` forces overwrite.
  Exact AMP SmartExclude semantics were not verified from source in this repo —
  flagged for the synthesis agent.
- H4 (MEDIUM, ~0.5): Because the FetchURL stages also restore the kvp/config from
  GitHub raw on every Update, any live-edited AMP UI setting baked into the kvp
  is likewise reverted on Update — relevant if Medusa-related config lives in
  the kvp rather than `appsettings.json` (metaconfig maps only `appsettings.json`
  as Importable: `bapcustomservergithubmetaconfig.json`).

## Out-of-scope items (other D-agents)
Items (1)(2)(3)(4)(6) — Medusa native refs, green-line/Kitsu FX fallback, VFX,
spawn/transparency/FPS/invisibility, queue 3–8min — were not investigated under
D1; this agent's scope was the AMP restore source only.
