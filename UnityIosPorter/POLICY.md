# Owned-source policy

UnityIosPorter is solely for a project owner or an explicitly authorized
developer migrating complete Unity project source.

## Accepted input

An accepted project has Unity's normal source layout:

- `Assets/`
- `ProjectSettings/`
- `ProjectSettings/ProjectVersion.txt`
- `Packages/manifest.json`

The user must have the rights needed to build, modify, sign, and distribute the
project and all included code, assets, packages, and native plugins.
Write/build commands require `--attest-owned-source`; the attestation is a
clear user statement, not a license check.

## Refused input

The tool refuses input when a file or directory name matches a denylist of
markers that indicate a reconstructed, decompiled, dumped, extracted, or
shipped application. Refused markers include:

- Asset extraction, IL2CPP dump, dummy assembly, and decompilation directories.
- `GameAssembly`, `global-metadata.dat`, `DummyDll`, and `dump.cs`-style output.
- `.ipa` files and `.app` bundles.
- Symbolic links, because a staged Unity process could write through them
  outside the staging copy.

This filename denylist is advisory. It is a best-effort screen for common
markers, not proof of anything: passing it does not establish ownership,
authorization, or provenance, and renamed artifacts can evade it. Ownership
is asserted separately and explicitly by the user through
`--attest-owned-source`; the tool cannot verify that assertion. The `detect`
output field `suspicious_markers_absent` reports only that no denylist
marker was found.

Renaming an artifact does not make its use authorized. UnityIosPorter does not
recover source from binaries, bypass platform protection, reconstruct third
party projects, or download game content. If only a built application exists,
obtain the original Unity project from its owner instead.

## Scope and limitations

Static findings are migration guidance, not proof that a project is safe,
complete, or App Store compliant. The owner remains responsible for:

- Source and asset rights.
- Third-party package and plugin licenses.
- Apple certificates, provisioning, entitlements, privacy declarations, and
  review requirements.
- Runtime, device, networking, performance, and content testing.

This project is independent and is not affiliated with Unity Technologies,
Apple Inc., or any game publisher.
