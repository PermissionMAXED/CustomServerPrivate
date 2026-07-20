# iOS prerequisites

Real iOS builds require a macOS host. Linux can run detection, policy checks,
scanning, planning, dry runs, and all unit tests, but cannot run Xcode.

## Required on macOS

1. Install the exact Unity Editor version reported in
   `ProjectSettings/ProjectVersion.txt`.
2. In Unity Hub, add **iOS Build Support** for that Editor version.
3. Install a compatible Xcode and accept its license/first-launch components.
4. Select the intended Xcode with `xcode-select` when multiple versions exist.
5. Install or access the Apple signing certificate and provisioning setup for
   the configured team and bundle identifier.
6. Verify every package and native plugin supports iOS and the project's Unity
   version.

Run:

```text
python3 UnityIosPorter/porter.py doctor \
  --project /path/to/OwnedProject \
  --unity-path /Applications/Unity/Hub/Editor/VERSION/Unity.app/Contents/MacOS/Unity
```

`PASS` means a prerequisite was observed, `FAIL` means it is absent or the host
cannot provide it, and `UNKNOWN` means the tool lacks enough local information.
Unknown Unity or iOS-module status is not build readiness.

## Technical pipeline

The porter CLI launches Unity in batch mode with `-buildTarget iOS`, which is
what actually selects the build target for the run. The injected Editor bridge
does not switch targets in batch mode — `SwitchActiveBuildTarget` is unreliable
there because the required domain reload never happens — it instead asserts
that the active target is already iOS and fails clearly if it is not. The
bridge then applies these settings to the staged project:

- Scripting backend: IL2CPP
- Architecture: ARM64
- Device SDK
- Valid bundle identifier
- Configured managed stripping level and optional Apple team

Unity's `BuildPipeline.BuildPlayer` exports `Unity-iPhone.xcodeproj`. Then
`xcodebuild archive` compiles/signs the device app, and
`xcodebuild -exportArchive` creates the selected distribution export.

Mono is useful for some Unity editor and desktop workflows, but is not a
shipping scripting backend for iOS. Changing that setting can reveal AOT,
generic-sharing, reflection, serialization, plugin, linker, and performance
issues that require source-level fixes.

## Production validation

After a successful export, test at minimum:

- A clean install and launch on supported physical ARM64 devices.
- Every scene and key gameplay flow.
- AOT-sensitive generics, reflection, serialization, and networking.
- Native plugins on device, including callbacks and background behavior.
- Code signing, entitlements, privacy manifests, permissions, and receipt/IAP
  behavior as applicable.
- Release optimization, managed stripping, crash symbols, memory, startup, and
  thermal performance.

An unsigned simulator build is not equivalent to a signed device archive.
