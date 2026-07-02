# BAPBAP Custom Server AMP Template

This folder contains a shareable CubeCoders AMP Generic-module template for the BAPBAP custom server stack.

Files expected by AMP:

- `bapcustomserver.kvp`
- `bapcustomserverconfig.json`
- `bapcustomservermetaconfig.json`
- `bapcustomserverports.json`

The template expects the published server files to live in a `BapCustomServer` folder inside the AMP instance. Build the shareable package from the workspace root with:

```powershell
.\tools\Build-AmpPackage.ps1
```

The generated archive is:

```text
deployment\amp\bapcustomserver-amp-instance.zip
```

## Web-panel-only Linux deployment

If you do not have SSH/terminal access to the AMP host, import the refreshed template ZIP first and create/start the instance from that refreshed template. The Linux template uses:

```text
App.ExecutableLinux=/bin/bash
App.LinuxCommandLineArgs=-lc "chmod +x ./BapCustomServer ./start-linux-wine.sh ./createdump 2>/dev/null || true; exec ./BapCustomServer --urls 'http://{{$ApplicationIPBinding}}:{{$ApplicationPort1}}'"
```

That means AMP starts `/bin/bash`, and bash fixes the executable flag before launching the server binary. This is the web-panel-safe path.

On Linux, the template starts `/bin/bash` and lets bash mark `BapCustomServer` executable before it runs the server. This avoids the common web-panel-only failure where ZIP upload/extract loses the Linux executable bit and AMP refuses to start `/AMP/BapCustomServer/BapCustomServer` directly.

The template also includes a Linux `SetExecutableFlag` update stage for `BapCustomServer`; after importing the refreshed template, AMP's `Update` action can apply that flag before `Start`.

Linux match hosting still needs a real Linux Unity dedicated/headless game binary or a Wine-compatible Windows match host. The ASP.NET lobby/matchmaker is published for both `win-x64` and `linux-x64`.
