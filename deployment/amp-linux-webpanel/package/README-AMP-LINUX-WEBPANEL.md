# BAPBAP Custom Server Linux Web Panel AMP Template

Use this template when you only have AMP Web Panel access and cannot run SSH
commands like `chmod`.

This template is Linux-only and deliberately starts the host's `/bin/sh`
executable instead of starting `BapCustomServer` directly:

```text
App.ExecutableLinux=/bin/sh
App.CommandLineArgs=./amp-webpanel-start.sh "http://{{$ApplicationIPBinding}}:{{$ApplicationPort1}}"
```

`amp-webpanel-start.sh` is included in the full server/game package. It is read
by `/bin/sh`, so the script itself does not need an executable bit. The script
marks `BapCustomServer` executable and then starts the server.

Build this template package from the workspace root:

```powershell
.\tools\Build-AmpLinuxWebPanelPackage.ps1
```

Generated archive:

```text
deployment\amp-linux-webpanel\bapcustomserver-linux-webpanel-template.zip
```

Web-panel-only install order:

1. Import `bapcustomserver-linux-webpanel-template.zip` into AMP.
2. Create a new instance from `BAPBAP Custom Server Linux Web Panel`.
3. Upload and extract `bapcustomserver-amp-full-linux-wine.tar.gz` or `.zip` into the instance root.
4. Confirm the File Manager shows `/BapCustomServer/amp-webpanel-start.sh` and `/BapCustomServer/BapCustomServer`.
5. Press Start.

If the server later fails on `wine` or `xvfb-run`, the AMP host/container is
missing OS packages. File upload cannot install those without host/provider
support.
