# Local Artifact Manifest

Last refreshed: 2026-05-30.

This file records important local artifacts that are not committed to Git because they are generated, duplicated, proprietary game content, or too large for normal GitHub storage.

## Excluded Large Folders

| Path | Approx size | Reason |
| --- | ---: | --- |
| `AssetRip\` | 2.27 GB | AssetRipper exported project and very large prefabs/assets. |
| `Spiel\` | 2.05 GB | Full copied Windows game build, MelonLoader runtime, generated IL2CPP assemblies, local logs. |
| `deployment\amp-full-linux-wine\package-build-*` | multiple GB | Generated AMP full package staging with duplicated game files. |
| `tools\generated\` | large | Generated IL2CPP interop assemblies and caches. |
| `tools\downloads\` | large | Downloaded MelonLoader runtime archives/extracts. |
| `tools\src\` | large | Local tool/dependency source and build output. |

## Important Package Artifacts

These exist in the local workspace and can be regenerated from scripts:

| Artifact | Purpose | Current note |
| --- | --- | --- |
| `deployment\client-mod-package\bapcustomserver-client-mod.zip` | Player-facing client mod ZIP. | Superseded by the GitHub Release client bundle for `bapcustomserver-20260530-cleanlogs`; current live-tested mod hash is `035F05098CD3A413B79A51530099D5C68754A28256C5AA09C50994CE0DEF40A5`. |
| `deployment\server-packages\bapcustomserver-windows-server.zip` | Windows server package. | Generated package artifact, below GitHub 100 MB but binary. |
| `deployment\server-packages\bapcustomserver-linux-server.zip` | Linux ASP.NET server package. | Generated package artifact, below GitHub 100 MB but binary. |
| `deployment\amp-full-linux-wine\bapcustomserver-amp-full-linux-wine.zip` | Full AMP Linux/Wine package with game files. | Generated artifact; current published release asset for `bapcustomserver-20260530-cleanlogs` has SHA256 `5f6c99eeb69092c15d9873fe85de58f2181067135ebdedcdd5571d95f1e515b3`. |
| `deployment\amp-full-linux-wine\bapcustomserver-amp-full-linux-wine.tar.gz` | Full AMP package TAR.GZ variant. | Very large; older generated variant remains local. |

## Key Proof Artifacts

The root `logs\` folder is small enough to retain locally and may be committed if useful. Most useful files:

| File | Meaning |
| --- | --- |
| `logs\runtime-first-start-relaunch-final-setup-printwindow.png` | First-start setup panel proof. |
| `logs\runtime-first-start-relaunch-final-lobby-printwindow.png` | Lobby reached after automatic relaunch. |
| `logs\runtime-appdata-secondstart-player.log` | AppData identity second-start lobby proof. |
| `logs\runtime-final-lobby-player.log` | Earlier final lobby proof. |
| `logs\our-client-27568-cleanlogs-current-match.png` | Live AMP cleanlogs proof of a real match after the final update. |
| `logs\our-client-27568-cleanlogs-finalrun-24.png` | Live AMP cleanlogs result-screen proof. |
| `logs\our-client-27568-cleanlogs-after-cleanup.png` | Live AMP cleanlogs return-to-lobby/cleanup proof. |

## Rebuild Scripts

Use these scripts from the workspace root:

```powershell
.\tools\Install-BapCustomServerMelon.ps1 -Configuration Release
.\tools\Build-ServerPackages.ps1 -Configuration Release
.\tools\Build-AmpPackage.ps1 -Configuration Release
.\tools\Build-AmpFullLinuxWinePackage.ps1 -Configuration Release
.\tools\Build-AmpGitHubAutoInstallPackage.ps1
```

Before publishing to AMP, inspect the ZIP contents for the expected INI:

```powershell
Add-Type -AssemblyName System.IO.Compression
Add-Type -AssemblyName System.IO.Compression.FileSystem
$zip = [System.IO.Compression.ZipFile]::OpenRead("deployment\amp-full-linux-wine\bapcustomserver-amp-full-linux-wine.zip")
$entry = $zip.Entries | Where-Object { $_.FullName -eq "BapCustomServer/game/Mods/BapCustomServer.ini" }
$reader = [System.IO.StreamReader]::new($entry.Open())
$reader.ReadToEnd()
$reader.Dispose()
$zip.Dispose()
```
