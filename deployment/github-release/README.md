# BAPBAP Custom Server GitHub Release Deployment

Use this when AMP should install/update the complete server/game package itself.

Do not place the game files directly into git history. Upload the full package
as a GitHub Release asset. If AMP must download it without GitHub credentials,
the release asset must be publicly reachable.

Local build:

```powershell
.\tools\Build-AmpFullLinuxWinePackage.ps1
.\tools\Build-AmpGitHubAutoInstallPackage.ps1 -Repository OWNER/REPO
```

Current packaged tag:

```text
bapcustomserver-20260531-medusa-v172
```

Current tested mod DLL SHA256:

```text
3E796F1E22D124F6433DAE5BC67149A4A25D0CB5FD607DAB11FFE6934EA15E8D
```

Release assets to upload:

```text
deployment\amp-full-linux-wine\bapcustomserver-amp-full-linux-wine.zip
deployment\amp-github-autoinstall\bapcustomserver-github-autoinstall-template.zip
```

Optional one-command publish with GitHub CLI:

```powershell
gh auth login
.\tools\Publish-GitHubAmpRelease.ps1 -Repository OWNER/REPO -CreatePrivateRepository
```

AMP web panel flow:

1. Add the AMP configuration repository:
   `https://github.com/Sonic0810/BAPBAP-CustomServer-AMPTemplates.git`
2. Refresh templates.
3. Create a new `BAPBAP Custom Server GitHub AutoInstall` instance.
4. Press `Update`.
5. Wait for the GitHub Release asset to download/extract.
6. Press `Start`.

The live template repository keeps `manifest.json` and the AMP files in the
repo root, matching the custom-template repository flow described by CubeCoders.
The KVP uses:

```text
App.UpdateSources=@IncludeJson[bapcustomservergithubupdates.json]
```

That mirrors the normal CubeCoders AMPTemplates layout more closely than an
inline `App.UpdateSources=[...]` array in the KVP.

Later updates:

1. Build a new full package.
2. Create a new GitHub Release with asset `bapcustomserver-amp-full-linux-wine.zip`.
3. Press `Update` in AMP.

After publishing and pressing `Update`, run:

```powershell
.\tools\Test-AmpLivePublic.ps1 -AsJson
```

Then prove the live AMP filesystem/runtime with `verify-amp-instance.sh` from
the template repository. The live match path is only considered good after a
client reaches a real match and `/api/internal/servers` is empty again after
exit/cleanup.

If the instance still reports that `/AMP/BapCustomServer/BapCustomServer` cannot
start, it is not using this GitHub AutoInstall template. This template starts
`/bin/sh` first and only uses `BapCustomServer` after the AMP update stage has
set the executable flag.
