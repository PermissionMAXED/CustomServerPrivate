# BAPBAP Custom Server Packages

Build platform-specific server bundles with:

```powershell
.\tools\Build-ServerPackages.ps1
```

Generated archives:

- `deployment\server-packages\bapcustomserver-windows-server.zip`
- `deployment\server-packages\bapcustomserver-linux-server.zip`

By default the packages are self-contained ASP.NET publishes and include the client mod DLL plus start scripts. They do not include the 2GB Windows game folder unless the script is run with `-IncludeGameFiles`.

The Linux package is Linux-native for the lobby/matchmaker server only. For the
currently proven Linux match-hosting setup, use the AMP full Linux/Wine package
instead; it runs the Windows Unity build through Wine/Xvfb with `start-match.sh`.
