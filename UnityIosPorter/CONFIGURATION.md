# Configuration

CLI values override JSON configuration. Project settings are used only when a
value is not supplied; UnityIosPorter does not edit the original project.

Example `porter.json`:

```json
{
  "bundleId": "com.example.game",
  "teamId": "ABCDE12345",
  "exportMethod": "development",
  "configuration": "Release",
  "scheme": "Unity-iPhone",
  "unityPath": "/Applications/Unity/Hub/Editor/2022.3.41f1/Unity.app/Contents/MacOS/Unity",
  "managedStrippingLevel": "Low"
}
```

| JSON field | CLI override | Meaning |
|---|---|---|
| `bundleId` | `--bundle-id` | Required reverse-DNS identifier. It may be inferred from valid iPhone PlayerSettings. |
| `teamId` | `--team-id` | Apple Developer team used by Unity and Xcode automatic signing. |
| `exportMethod` | `--export-method` | `development`, `ad-hoc`, `app-store`, `enterprise`, `debugging`, or `release-testing`. |
| `configuration` | none in v1 | Xcode build configuration; defaults to `Release`. |
| `scheme` | none in v1 | Xcode scheme; defaults to `Unity-iPhone`. |
| `unityPath` | `--unity-path` | Matching Unity executable. |
| `managedStrippingLevel` | none in v1 | `Disabled`, `Minimal`, `Low`, `Medium`, or `High`. |

When stripping is not configured, plans recommend `Low` if reflection/AOT
signals exist and `Medium` otherwise. Review that recommendation; preservation
requirements are project-specific.

## Common arguments

- `--project PATH`: complete owned Unity source root.
- `--work-dir PATH`: a new path outside the project. Required by build steps.
- `--config PATH`: JSON configuration.
- `--attest-owned-source`: required for commands that write or invoke builds.
- `--dry-run`: show paths and argument-vector commands without writes or
  external process execution.

Arguments are passed directly to subprocesses without a shell. Unity and
`xcodebuild` runs have wall-clock timeouts (defaults: 7200 s and 3600 s) and
return exit code `124` when exceeded; override them with the
`UNITY_IOS_PORTER_UNITY_TIMEOUT` and `UNITY_IOS_PORTER_XCODEBUILD_TIMEOUT`
environment variables (positive integer seconds). Subprocess stdout/stderr is
captured to files under the work directory's `logs/` so the CLI's JSON stdout
stays parseable. Subprocesses inherit the calling environment; the tool does
not isolate or filter secrets from them.

## Export options

`export` writes a standard XML `ExportOptions.plist` with automatic signing,
the configured export method, optional team ID, Swift symbol stripping, and
bitcode upload disabled. Projects needing manual signing, provisioning-profile
maps, managed App Store upload, or custom entitlements should review and extend
the generated plist before production distribution.

## Scene source

Enabled scenes come from
`ProjectSettings/EditorBuildSettings.asset`. Scene entries must be canonical
relative paths under `Assets/` using forward slashes; absolute paths,
backslashes, and `..`/`.` segments are rejected. A missing settings file, no
valid enabled scenes, or an enabled scene absent from `Assets/` makes the
build plan blocking: `plan` reports it under `riskSummary.sceneErrors` and
`build-xcode`/`all` stop with exit `2` before staging.
