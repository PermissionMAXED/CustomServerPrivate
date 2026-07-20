# UnityIosPorter v1

UnityIosPorter is a dependency-free Python CLI for owners of complete Unity
project source. It audits Mono assumptions, creates a separate staging copy
(a plain directory, not a sandbox), configures the staged project for the
technically required iOS toolchain (IL2CPP + ARM64), launches Unity in batch
mode with `-buildTarget iOS` to export Xcode, then can archive and export with
`xcodebuild`.

It is not a decompiler, binary converter, or game extraction tool. It refuses
inputs whose file or directory names match a denylist of reconstruction and
shipped-artifact markers such as extraction-tool folders, `GameAssembly`,
`global-metadata.dat`, `DummyDll`, `dump.cs`, `.app`, and `.ipa`. That
filename denylist is advisory: it catches common cases and cannot prove
ownership or authorization. See [POLICY.md](POLICY.md).

UnityIosPorter is not affiliated with or endorsed by Unity Technologies or
Apple Inc.

## Requirements

- Python 3.11 or newer; Python standard library only.
- A complete, owned Unity source project containing `Assets/`,
  `ProjectSettings/`, `ProjectSettings/ProjectVersion.txt`, and
  `Packages/manifest.json`.
- For a real iOS build: macOS, the matching Unity Editor with iOS Build
  Support, and Xcode. See [IOS_PREREQUISITES.md](IOS_PREREQUISITES.md).

An iOS shipping build cannot use Unity's Mono scripting backend. Unity exports
IL2CPP-generated native code for ARM64 into an Xcode project, and Xcode signs
and packages the app.

## Quick start

Run from the repository that contains this directory:

```text
python3 UnityIosPorter/porter.py detect --project /path/to/OwnedUnityProject
python3 UnityIosPorter/porter.py doctor --project /path/to/OwnedUnityProject
python3 UnityIosPorter/porter.py scan --project /path/to/OwnedUnityProject
python3 UnityIosPorter/porter.py plan --project /path/to/OwnedUnityProject --bundle-id com.example.game
```

Preview the entire write/build flow:

```text
python3 UnityIosPorter/porter.py all \
  --project /path/to/OwnedUnityProject \
  --work-dir /path/to/new/porter-work \
  --bundle-id com.example.game \
  --attest-owned-source \
  --dry-run
```

Remove `--dry-run` on a prepared macOS builder. The work directory must not
already exist and must be outside the source project. UnityIosPorter copies the
source to `staged-project/`, injects its Editor bridge there, and never applies
PlayerSettings changes to the original.

## Commands

| Command | Purpose |
|---|---|
| `detect` | Validate the Unity source layout, version, manifest, and input policy. |
| `doctor` | Check the project, Unity Editor, iOS module, macOS, and Xcode. |
| `scan` | Find AOT, stripping, platform API, and native plugin risks across `Assets/` and embedded/local `Packages/`. |
| `plan` | Emit the versioned `build-plan.json` shape without staging. |
| `build-xcode` | Stage source, inject `BatchEntry.cs`, and run Unity `-executeMethod`. |
| `archive` | Build an Xcode archive for generic iOS ARM64 device output. |
| `export` | Generate `ExportOptions.plist` and export the archive. |
| `all` | Run build, archive, and export in order. |
| `ci init` | Copy the included owned-project preflight workflow template. |

Write/build commands require the explicit `--attest-owned-source` flag.
Configuration options and JSON fields are documented in
[CONFIGURATION.md](CONFIGURATION.md).

## Contracts and outputs

The work directory contains:

- `staged-project/`: disposable Unity source copy with the injected bridge.
- `build-plan.json`: schema version 1 settings, scenes, paths, and scan report.
- `result.json`: schema version 1 Unity build result, including success,
  errors, warnings, output, size, duration, and Unity version. `build-xcode`
  validates this contract strictly (schema version, phase, `success`, and an
  output path that contains a real `*.xcodeproj`/`*.xcworkspace`); a Unity
  process that exits 0 without a valid contract still fails with exit `4`.
- `workspace-manifest.json`: written by `build-xcode` after validation. It
  binds the workspace to the source project path, the plan digest, the staged
  source digest, and the Xcode output directory. `archive` and `export`
  refuse to operate on a workspace without a matching manifest.
- `xcode/`: Unity's Xcode export.
- `archives/UnityIosPorter.xcarchive`: Xcode archive. `archive` verifies the
  archive contains `Info.plist` and a `Products/Applications/*.app`.
- `ExportOptions.plist` and `export/`: export configuration and result.
  `export` verifies an `.ipa` was produced.
- `unity.log`: Unity batch-mode log.
- `logs/`: captured stdout/stderr of Unity and `xcodebuild` subprocesses, so
  command output never mixes into the CLI's JSON stdout.

Treat these as build artifacts, not source. Use a fresh work directory for
every run.

## Exit codes

| Code | Meaning |
|---:|---|
| `0` | Successful command or clean scan/plan. |
| `2` | Compatibility risks found or a blocking migration plan. |
| `3` | Doctor found missing or unknown prerequisites. |
| `4` | Unity Xcode build failed. |
| `5` | Xcode archive failed. |
| `6` | Xcode export failed. |
| `64` | Usage, project validation, ownership, or suspicious-input refusal. |

## Tests

Linux needs no Unity or Xcode:

```text
python3 -m unittest discover -s UnityIosPorter/tests -v
```

See [CI.md](CI.md) for CI behavior and [RISK_RULES.md](RISK_RULES.md) for
scanner interpretation.
