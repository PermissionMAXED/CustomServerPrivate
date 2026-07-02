# Matchmaking & Character Selection Fixes — Walkthrough

We have implemented solutions for both the Matchmaking Startup failure and the Character Selection issues.

---

## 1. Matchmaking Startup Fix (Stall & WINEPREFIX Contention)

### Problem
1. **Attempt 1 Stalled**: The server was using a short `8-second` grace timeout. Wine/Xvfb on cold boot regularly exceeded this limit, causing the server to abort the startup before Unity could write anything to the log file.
2. **Attempt 2 Crashed**: Since `WINEPREFIX` was shared across all attempts/matches, starting a retry attempt just 2 seconds after killing Attempt 1 caused conflicts. The background process cleanup killed the shared `wineserver`, causing Attempt 2's Wine process to crash with `X connection to :100 broken` (Exit Code 2).

### Changes Made

#### Configuration Adjustments in [appsettings.json](file:///c:/Users/Administrator/Downloads/CustomServer/CustomMatchServer/appsettings.json)
* Relaxed the timeouts to allow cold boots of Wine/Xvfb:
  * `"GameServerStartRetryDelaySeconds": 10` (was `2`s) — gives the OS enough time to fully release locks and shut down previous processes.
  * `"GameServerWrapperOnlyStartupStallGraceSeconds": 60` (was `8`s) — allows up to 60s for Wine to boot up before checking for fresh logs.
  * `"GameServerWrapperOnlyStartupStallSeconds": 25` (was `5`s).

#### Code Changes in [GameServerProcessManager.cs](file:///c:/Users/Administrator/Downloads/CustomServer/CustomMatchServer/GameServerProcessManager.cs)
* **Isolated WINEPREFIX per attempt**:
  Added a unique `BAPCUSTOM_WINEPREFIX` directory using the Game ID and Attempt number to prevent any file system or lock conflicts:
  ```csharp
  string isolatedPrefix = Path.Combine(workingDirectory, "wineprefixes", $"wineprefix_{bootstrap.GameId}_attempt{attempt}");
  startInfo.Environment["BAPCUSTOM_WINEPREFIX"] = isolatedPrefix;
  ```
* **Cleaned up temporary prefixes**:
  Added a helper method `TryCleanupWinePrefixes` that recursively deletes all directories matching `wineprefix_{gameId}_attempt*` upon successful match completion, match termination, or failed startup attempts.

---

## 2. Character Selection & Unlock Fixes

### Problem
1. **Client Hook Skipped**: MelonLoader compiles and unhollows game code into `Il2CppAssembly-CSharp.dll`. The client mod assembly scanner `couldContainGameCode` checked only for `Assembly-CSharp` and skipped the game's actual unhollowed assembly. As a result, the force-unlock patches were never applied on the client.
2. **Lobby Selector Locking**: Under default configurations (where `UnlockEverything` or individual unlock flags are `false`), the server early-returned Default Skins in `/api/load` before the loop appending raw `charId` values was reached. Without both `100000 + charId` (unlock flag) and raw `charId` (selectability asset) in `/api/load` owned assets list, the client lobby displayed characters as locked.
3. **Master Configuration Overrides**: Option flags in `BuildOwnedAssets` resolved directly to properties instead of leveraging `EffectiveUnlock*` helpers which respect the `UnlockEverything` master-override flag.

### Changes Made

#### Client-Side Mod [CustomServerMod.cs](file:///c:/Users/Administrator/Downloads/CustomServer/BapCustomServerMelon/CustomServerMod.cs)
* Added `Il2CppAssembly-CSharp` to the scanned assembly list `couldContainGameCode` inside `TryInstallCharacterUnlockPatches` to ensure character force-unlock hooks are correctly installed.

#### Server-Side API [Program.cs](file:///c:/Users/Administrator/Downloads/CustomServer/CustomMatchServer/Program.cs)
* Cleaned up `BuildOwnedAssets` to resolve options using the `options.EffectiveUnlock*` helper properties (or player overrides) to consistently honor the `UnlockEverything` master toggle.
* Modified `AppendCharacterUnlockAssets` to append both `100000 + charId` and the raw `charId` asset to the owned assets array.
* Since `AppendCharacterUnlockAssets` runs at the very beginning of `BuildOwnedAssets` (before early returns), both character asset forms are now correctly returned to the client under all configuration modes.

#### Integration Tests [EndpointIntegrationTests.cs](file:///c:/Users/Administrator/Downloads/CustomServer/tests/BapCustomServer.Tests/EndpointIntegrationTests.cs)
* Added a new test `ApiLoad_ContainsCharacterUnlockAssetsEvenWhenAllFlagsAreFalse` that overrides options to disable all unlock flags, invokes `/api/load`, and asserts that both raw `charId` and `100000 + charId` are present for all characters (ids 0 to 15).

---

## 3. Verification

### Automated Tests
* Verified all 359 tests compile and pass successfully:
  ```bash
  dotnet test tests/BapCustomServer.Tests/BapCustomServer.Tests.csproj
  # Passed!   : Fehler:     0, erfolgreich:   359, übersprungen:     0, gesamt:   359, Dauer: 1 m 19 s
  ```

### Builds & Packaging
* Compiled client mod:
  ```bash
  dotnet build BapCustomServerMelon/BapCustomServerMelon.csproj -c Release
  ```
* Ran installer script to package and copy DLLs to the game's folder:
  ```bash
  powershell -File tools/Install-BapCustomServerMelon.ps1
  # Deployed pinned BapCustomServerMelon.dll.
  #   Dist : ...\BapCustomServerMelon\dist\BapCustomServerMelon.dll
  #   Mods : ...\Spiel\Battleroyalebuild\Mods\BapCustomServerMelon.dll
  #   SHA  : DB3E5AB39E5D2B9D785CC2DEAE7C1F4886D262E4C6EDBAA9AE3BC76A4840CE2C
  ```
* Compiled CustomMatchServer:
  ```bash
  dotnet build CustomMatchServer/BapCustomServer.csproj -c Release
  ```
