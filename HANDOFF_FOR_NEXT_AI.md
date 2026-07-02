# Final handoff

The final fix is documented in:

- `docs/AMP_LINUX_WINE_ROOT_CAUSE.md`
- `docs/MEDUSA_SERVER_INTEGRATION.md`
- `deployment/amp-github-autoinstall/README.md`
- `deployment/github-release/README.md`

Short version:

- The lobby/game logic was not the main failure.
- AMP was repeatedly failing because the Wine-launched Windows Unity match
  process did not reliably open the bootstrap listener on `127.0.0.1:7850`.
- The proven path is the GitHub AutoInstall AMP template, the full Linux/Wine
  package, `./start-match.sh`, Wine with 32-bit support, Xvfb, xauth, Mesa
  software graphics, and explicit `Content-Length` bootstrap POSTs.
- `winetricks` is not part of the proven setup.
- Do not change the pinned mod DLL hash without a fresh live AMP match proof.

Current proven release:

```text
bapcustomserver-20260530-cleanlogs
```

Current tested mod DLL SHA256:

```text
035F05098CD3A413B79A51530099D5C68754A28256C5AA09C50994CE0DEF40A5
```

Medusa integration status:

- Medusa is `charId=15`.
- The server advertises `0..15`, returns a 16-slot skin loadout, and persists
  Medusa character mastery XP.
- Client and AMP packages include `BAPBAP.ModAPI.dll`, `BAPBAP.Medusa.dll`, and
  `UserData/Medusa/medusa.bundle`.
- Keep the pinned `BapCustomServerMelon.dll` unless a fresh live AMP match proof
  validates a replacement.
