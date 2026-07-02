# BAP Admin Tools

`BapAdminMelon.dll` is deliberately independent from `BapCustomServerMelon.dll`.
Install both DLLs in the client `Mods` directory. The custom-server mod routes
network traffic; this mod alone performs admin authentication and exposes debug tooling.

The shared `%APPDATA%\BAPBAPBATTLEROYALE\BapCustomServer.ini` needs:

```ini
[Identity]
AccountId=custom-example
Username=Admin

[Admin]
Enabled=true
Token=your-admin-token
```

The account ID must also be present in AMP's `BAPBAP - Access Control` setting
`Admin Account IDs (CSV)`.

- `F8`: authenticated admin overlay for items, entities, bots, modifiers, abilities, match controls, and arbitrary native debug commands.
- `F9`: built-in Unity developer console.

Build and install locally:

```powershell
tools\Install-BapAdminMelon.ps1
```
