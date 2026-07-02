# AMP Linux/Wine Root Cause And Current Fix

Last verified: 2026-06-09

Current target release: `medusa-v1722-lifecycle-fix`

## What Was Broken

The lobby and matchmaking code were not the only failure. The repeated AMP error was:

```text
POST http://127.0.0.1:7850/setup-game
Connection refused
Game server ... did not accept match bootstrap data before timeout
```

That means the ASP.NET lobby server had already decided to start a match, but the Windows Unity match process had not opened its internal bootstrap HTTP listener on the per-match HTTP port. The client therefore sat in queue or was requeued because the server correctly refused to send players into a dead match.

There were several separate causes behind the same symptom:

1. The AMP package runs a Windows Unity build on Linux. That requires Wine, `wineboot`, Xvfb, xauth, and Mesa/software graphics support. Raw Linux execution, raw `wine`, or a package without those dependencies can start partially but not reliably reach the mod bootstrap listener.

2. Unity/Wine graphics startup is noisy and sometimes slow in AMP. Shader, ALSA, video, and analytics warnings can make the real readiness signal hard to see.

3. Bootstrap POSTs must use a fixed `Content-Length`. The mod bootstrap listener is deliberately small and does not parse chunked transfer encoding. The server serializes JSON to bytes and sends explicit `Content-Length` for `/setup-game`, `/add-teams`, and `/queue-matched`.

4. The old queue could reuse the fixed AMP match ports too soon after killing a stale Windows game process. That produced a dead first attempt and then a later successful attempt, which looked like a 3-8 minute queue.

5. The first queue right after deploy can still be slower if startup prewarm is running. That is not the old failed-first-attempt loop; it is prewarm contention/cold start.

## Current Fixed Path

The current fixed path is:

- AMP runs release `medusa-v1722-lifecycle-fix`.
- The full package is `bapcustomserver-amp-full-linux-wine.zip`.
- AMP starts the Linux ASP.NET lobby server.
- The lobby server launches each match with `./start-match.sh`.
- `start-match.sh` runs the Windows build through Wine/Xvfb with the configured Unity graphics args.
- The Melon mod inside that Windows process opens the bootstrap HTTP listener.
- The ASP.NET server posts `/setup-game`, `/add-teams`, and `/queue-matched`.
- Only after bootstrap succeeds does the lobby broadcast `GAME_STARTED`.
- If a stale match is killed, the server waits up to `5000ms` for process exit and then waits `3000ms` before starting the next match on the fixed AMP ports.

The wrapper logs these lines at match startup:

```text
[start-match] deployment.releaseLabel=...
[start-match] wine=...
[start-match] winePath=... winebootPath=...
[start-match] xvfbRunPath=... xauthPath=...
[start-match] graphicsMode=...
[start-match] unityGraphicsArgs=...
```

The AMP start script also logs runtime diagnostics:

```text
[amp-start] releaseLabel=...
[amp-start] dotnetVersion=...
[amp-start] wineVersion=...
[amp-start] winePath=...
[amp-start] xvfbRunPath=...
```

`/health` now reports the important runtime and lifecycle values:

```text
wineAvailable=true
winebootAvailable=true
xvfbRunAvailable=true
xauthAvailable=true
gameServerStopWaitMillis=5000
gameServerPostCleanupStartDelayMillis=3000
gameServerPrewarmOnStartup=true
prewarm.ready=true
prewarm.completed=true
```

## Current Live Proof

Live health on `http://ark.atomi23.de:5055/health` reports:

```text
release=medusa-v1722-lifecycle-fix
runtime.os=Debian GNU/Linux 13 (trixie)
runtime.framework=.NET 10.0.5
wineVersion=wine-10.0 (Debian 10.0~repack-6)
prewarm.state=ready
prewarm.ready=true
prewarm.completed=true
```

Normal queue proof:

- `C:\Users\Administrator\Downloads\CustomServer\logs\live-medusa-direct-20260609-031711.log`
- `QUEUE_MATCHED`/`GAME_STARTED` at `t+52.8s`
- queue payload stayed `charId=1`
- server bootstrap took `20.1s` on attempt `1/2`
- no old requeue loop was observed

Medusa custom proof:

- `C:\Users\Administrator\Downloads\CustomServer\logs\custom-medusa-vfx-v1708-20260609-030830`
- custom match started in about `28.3s`
- Medusa spawned visibly and emitted native VFX

Cleanup proof:

- `/` reports no lobbies after cleanup
- `/api/queue/status` reports `playerCount=0` and `isActive=false`

## What Not To Change Casually

- Do not point `GameLauncherPath` directly at `wine`, `xvfb-run`, or `/usr/bin/env`. Use `./start-match.sh`.
- Do not remove Wine, `wineboot`, `xvfb`, `xauth`, or Mesa support from the AMP package install path.
- Do not add `winetricks` unless a new live AMP proof requires it.
- Do not remove the fixed `Content-Length` bootstrap POST behavior.
- Do not remove stop-wait/post-cleanup lifecycle delays while AMP uses fixed match ports.
- Do not treat an idle closed `7850/tcp` as a failure. The bootstrap port only exists while a match process is starting or running.

## Verification

Health:

```powershell
Invoke-RestMethod -Uri 'http://ark.atomi23.de:5055/health' -TimeoutSec 10 | ConvertTo-Json -Depth 8
```

Normal queue:

```powershell
powershell -NoProfile -ExecutionPolicy Bypass -File .\tools\Test-LiveMedusaQueueDirect.ps1 -BaseUrl 'http://ark.atomi23.de:5055' -GameHost 'ark.atomi23.de' -CharacterId 1 -ObserveSeconds 12 -MatchEventTimeoutMs 180000 -KillFirst
```

Medusa custom:

```powershell
powershell -NoProfile -ExecutionPolicy Bypass -File .\tools\Test-LiveCustomMedusaVfx.ps1 -BaseUrl 'http://ark.atomi23.de:5055' -GameHost 'ark.atomi23.de' -CharacterId 15 -MapId 1 -BotCount 0 -KillFirst
```
