# B2 — How charId 15 replicates client↔server, and what happens when the native game doesn't know charId 15

Session: `B2_replicated_charid` — READ-ONLY research. No source/build/deploy changes were made.
Scope: charId 15 (Medusa) client↔server replication; where an unknown charId defaults to a base char; whether the Tier C (matchmade) server treats Medusa as cosmetic-only.

Roots inspected:
- `C:\Users\Administrator\Downloads\BAPBAPModdingAPI\medusa-mod\MedusaMod.cs` (the live mod logic; PreMatch patches)
- `C:\Users\Administrator\Downloads\BAPBAPModdingAPI\BAPBAPModAPI\reverse-engineering\decompiled\Assembly-CSharp\...` (Il2CppInterop proxy assemblies)
- `C:\Users\Administrator\Downloads\CustomServer\CustomMatchServer\...` (Tier C lobby/match server)
- `C:\Users\Administrator\Downloads\CustomServer\docs\MEDUSA_SERVER_INTEGRATION.md`, `deployment\...\verify-amp-instance.sh`

> Caveat on the decompiled tree: the `reverse-engineering/decompiled/Assembly-CSharp` files are **Il2CppInterop proxy stubs** (native `il2cpp_runtime_invoke` thunks). They expose field/method **shapes and SyncVar wiring**, but the native method **bodies** (e.g. the real `GameMode.SpawnPlayerChar` logic) are not present. Statements about native default behavior are therefore inferred from the proxy shape + the mod's own workaround code + `MEDUSA_SERVER_INTEGRATION.md`, and are flagged with confidence.

---

## 1. The charId replication mechanism (file:line trace)

### 1a. `charId` is a Mirror SyncVar on `PlayerManager`
Decompiled `...\Il2CppBAPBAP\Player\PlayerManager.cs`:
- L710 `public unsafe int charId { get; set; }` — backing field.
- L232 `NativeFieldInfoPtr__Mirror_SyncVarHookDelegate_charId` — `charId` is a **SyncVar with a hook**.
- L308 `OnCharacterChanged_Public_Void_Int32_Int32` — hook `OnCharacterChanged(int old, int new)`.
- L334/L336 `get_NetworkcharId` / `set_NetworkcharId` — the **`NetworkcharId` setter is the authoritative replicated write** (server→clients).

So character identity is replicated server-authoritatively: whoever owns the object writes `NetworkcharId`, Mirror serializes it, and remote clients run `OnCharacterChanged`.

### 1b. The mod forces charId 15 onto every replication surface
`MedusaMod.cs` → `ForcePlayerMedusaChar(PlayerManager, int charId, string source)` (def **L6757**) writes ALL of:
- `player.charId = charId;` (L6786)
- `player.skinAssetId = -1;` (L6793) — drops the skin so it doesn't fight the grafted visual
- `player.NetworkcharId = charId;` (L6800) — **the SyncVar write that replicates to server/clients**
- `player.OnCharacterChanged(old, charId)` (L6810) — fires the hook locally
- `primaryCharManager.charId` / `primaryCharManager.NetworkcharId = charId` (L6818–6824) then `EnsureLiveMedusaEntity(...)`

The replicated value is `CurrentMedusaId()` (def **L6123**): returns `MedusaCharId` if `>= 0`, else **falls back to literal `15`**. `IsMedusaId(int)` (def **L6036**) = `charId == 15 || charId == MedusaCharId`. `ExpectedMedusaCharId` const = 15 (L1387); `MedusaCharId` runtime field starts at `-1` (L1497).

### 1c. PreMatch patches (the requested anchors)
All in `MedusaMod.cs`. The native PreMatch methods are wrapped by Harmony; the mod re-asserts charId 15 on every callback:

| Anchor (req.) | Patch | Action |
|---|---|---|
| L587 | `PlayerPreMatchCmdTrySelectCharacterPatch` (Prefix `CmdTrySelectCharacter`) | **log only** (counter ≤8). Real write is in the `UserCode_` postfix L605→`ForcePlayerMedusaChar` (L614). |
| L619 | `PlayerPreMatchCmdTryLockCharacterPatch` (Prefix `CmdTryLockCharacter`) | log only; `UserCode_CmdTryLockCharacter` postfix (L644) calls `TryGetPreMatchSelectedChar`→`ForcePlayerMedusaChar` (L649–651). |
| L656 | `PlayerPreMatchSetPlayerCharacterPatch` (Postfix `SetPlayerCharacter`) | `ForcePlayerMedusaChar(__instance._playerManager, charId)` (L662–664). |
| L669 | `PlayerPreMatchSetTeammateCharacterPatch` (Postfix `SetTeammateCharacter`) | `ForcePlayerMedusaChar(teammate, charId)` (L675–677) — pushes Medusa to teammates' view. |
| L695 | `PreMatchManagerAssignCharactersPatch` (Prefix **and** Postfix) | `ForceSelectedMedusaPlayers(__instance,...)` (L701, L707) — re-stamps selection right around native `AssignCharacters`. |
| L711–746 | `GameModeSpawnPlayerCharPatch` | **Prefix**: `EnsureMedusaPrefabRegistered(CurrentMedusaId())` (L717); if `TryGetPreMatchSelectedChar` is Medusa → `ForcePlayerMedusaChar(...prefix.selected)` (L720–722), else if `player.charId` is Medusa → `ForcePlayerMedusaChar(...prefix.player)` (L726). **Postfix**: `ForcePlayerMedusaChar(...postfix)` (L738) + `EnsureLiveMedusaEntity(primaryCharManager)` (L739). |

Supporting helpers:
- `UpdatePreMatchSelectionState` (def **L6442**): finds every `PreMatchManager`, writes `item._currentSelectedCharacters[playerId] = charId` (the **server-side selection dictionary** the native `AssignCharacters` reads). `_currentSelectedCharacters` is confirmed as `Dictionary<int,int>` in decompiled `PreMatchManager.cs`.
- `TryGetPreMatchSelectedChar` (def **L6538**): reads `_currentSelectedCharacters[playerId]` back out.
- `UpdateMatchmakingPlayerDataForPlayer` (def **L6595**): walks `GameManager.qmd.players` (`List<MatchmakingPlayerData>`), matches by `playerId`/`accountId`, sets `val3.charId = 15` and `val3.skinAssetId = -1` (L6655-6660) — i.e. it rewrites the **QueueMatchedData payload** that the server distributes for prematch.
- `ForceQueueMatchedDataAvailable` (def **L6168**): sets `qmd.availableCharacters` to `CurrentCharacterIds()` so the prematch UI offers 15.

### 1d. Server-side registration hooks
`MedusaMod.cs` also patches server entry points so a headless/dedicated process registers the prefab before spawning:
`GameNetworkManager.Awake`, `OnStartServer`, `OnServerQueueMatched` (also `ForceQueueMatchedDataAvailable`), `OnServerMatchAddTeams` → each calls `_instance.EnsureMedusaPrefabRegistered(CurrentMedusaId(), ...)` (patches immediately after the `GameModeSpawnPlayerCharPatch` block, ~L750–800).

---

## 2. Where an unknown charId falls back to a base/char-0 — two distinct layers

### 2a. The native indexed prefab table (`characterPrefabsByCharId`)
Decompiled `...\Network\GameNetworkManager.cs`:
- L698 field ptr `characterPrefabsByCharId`; L1128 `public unsafe Il2CppReferenceArray<GameObject> characterPrefabsByCharId`; L1392 field bind.

This is a **fixed array indexed directly by charId**. The stock ripped build ships 15 entries (indices 0–14, Kitsu…Rocky — see Tier C `Names` list in §3). **There is no native index 15.** `GameMode.SpawnPlayerChar(PlayerManager, Vector3)` (decompiled `GameMode.cs` L3792, native stub token `100672189`) indexes this array by the player's replicated `charId`.

What the mod does about it — `RegisterPrefab(int baseCharId)` (def **L3093**):
1. `Instantiate` a **clone of a base prefab** (`val2`), `name = "Char_Medusa"`, graft Medusa visual, configure Mirror prefab.
2. Compute target index: `num = (15 >= len || arr[15]==null) ? 15 : len` (L3129) — i.e. it **grows `characterPrefabsByCharId` to length 16 and puts the clone at index 15** (L3130–3138), then `val.characterPrefabsByCharId = val4`.
3. `MedusaCharId = num` (so `CurrentMedusaId()` returns 15).

Which base is cloned: `EnsureMedusaPrefabRegistered` (def **L2919**) passes `preferredBaseCharId = CurrentMedusaId()` (=15). 15 is out of range of the original 0–14 array, so it falls to `FindFallbackBasePrefabIndex` (def ~L3060) = **the first prefab that has a `CharAbilities` component (effectively char 0 / Kitsu‑class)**. So Medusa is literally "char-0/base + grafted visual".

> Inference (confidence: high): if the mod is NOT loaded on the dedicated server, or its registration loses the race with native `SpawnPlayerChar`, indexing `characterPrefabsByCharId[15]` is out-of-bounds → either a hard exception or (if the native code clamps) a fall back to a base prefab. Either way the player does not get a real Medusa. The mod's entire existence of `EnsureMedusaPrefabRegistered` server hooks is the tell that the native server has no charId 15.

### 2b. The Tier C lobby server clamps unknown ids to **1** (not 0)
`CustomMatchServer\LobbyService.cs`:
- L620 `connection.CharId = CharacterCatalog.IsKnownId(payload.CharId) ? payload.CharId : 1;`
- L705 `int charId = CharacterCatalog.IsKnownId(lobbyPlayer.Player.CharId) ? lobbyPlayer.Player.CharId : 1;`
- L929 `... ? payload.CharId : lobbyPlayer.Player.CharId;` (switch keeps prior)
- L1163 `client.CharId = entry is not null && CharacterCatalog.IsKnownId(entry.CharId) ? entry.CharId : 1;`

`IsKnownId(charId) => charId >= 0 && charId < Names.Length` (CustomServerOptions.cs L582) and `Names.Length == 16` (0–15), so the Tier C server treats **15 as known** and only clamps genuinely unknown ids (e.g. 999) to **charId 1 (Anna)** — confirmed by the integration doc's `POST /api/queue/join ... rejects an unknown charId=999`.

---

## 3. Does Tier C (matchmade) server treat Medusa as cosmetic-only? — No, but it can't make abilities real either

The Tier C ASP.NET server is **Medusa-aware as a first-class charId**, not cosmetic-only:
- `CustomServerOptions.cs` L532 `MedusaCharId = 15`; L535-551 `Names[15] = "Medusa" // 15 - custom ModAPI character`; L556 `AllIds = 0..15`.
- It persists Medusa **character mastery XP** (`EconomyService.RecordCharacterXp`, charId 15 accepted; `Program.cs` L530-533) and advertises it in `/api/load`, `/api/chars/listing`, `/health` (`Program.cs` L167/184/221).
- It seeds `charId=15` into the bootstrap payload sent to the dedicated game server: `LobbyService.cs` L1288-1295 `MatchmakingPlayerData { CharId = player.Player.CharId, SkinAssetId = GetEquippedSkinForCharacter(player.Player) }`, logged L1304 `charId={CharId}`.

So the Tier C server faithfully carries `charId=15` end-to-end (queue → `QueueMatchedData.Players[].charId` → `/queue-matched` bootstrap). It is **the dedicated native game process** (bapbap.exe under Wine, with the mod in `game/Mods/`) that actually performs `SpawnPlayerChar` and decides ability/visual behavior. The Tier C server cannot inject ability ScriptableObjects; it only labels/queues/persists. In that narrow sense the **gameplay identity of Medusa is decided entirely by the in-process mod on the match host, not by Tier C**.

The dedicated server DOES carry the mod: `deployment\amp-github-autoinstall\verify-amp-instance.sh` L70-74 requires `game/Mods/BapCustomServerMelon.dll`, `game/Mods/BAPBAP.ModAPI.dll`, `game/UserLibs/BAPBAP.ModAPI.dll`, and **`game/Mods/BAPBAP.Medusa.dll`**. So charId 15 CAN be known server-side — conditional on the mod loading and winning the registration race in headless Wine startup.

---

## 4. Kitsu / Skinny / default fallback cause (cross-scope, directly evidenced)

Two independent causes, both documented:

1. **Skin → Kitsu, by data design.** Tier C `CustomServerOptions.cs` L558-577 `DefaultSkinAssetIds[15] = 300018` with comment *"Medusa fallback skin"* / *"Medusa currently reuses Kitsu's default skin id because the upstream Medusa asset drop contains no native 2D/skin asset entry for this older build."* `GetEquippedSkinForCharacter` (LobbyService.cs L1527-1537): Medusa's `player.Skins` has no index 15 (skins array is shorter), so it returns `CharacterCatalog.GetDefaultSkinAssetId(15)` = **300018 = Kitsu's skin id**. So the server literally ships Medusa to the match with Kitsu's skin asset.

2. **Abilities → Kitsu/green, by clone design.** `MEDUSA_SERVER_INTEGRATION.md` "Known limits": *"Medusa's mod supplies the visual prefab, rig, animator, localization, **Kitsu-based kit**, poison, and petrify hooks. … the current implementation uses a **Kitsu-based kit plus Medusa visuals/status/effect bridges**."* Because `RegisterPrefab` clones the base (Kitsu-class) prefab and only grafts the visual mesh, the `CharAbilities` / VFX remain the base character's (the "green lines" / `Serpent Bolt` are reused/recolored base projectiles + a runtime tooltip override), NOT the LatestBuild's real Medusa VFX (which this old ripped build does not contain natively).

3. **Hard fallback into Skinny/Kitsu state on Mirror failure.** Same doc, "Root cause and final fix": the cloned prefab's Mirror `NetworkIdentity` could carry `hasSpawned=True`; Mirror then rejected it with `Char_Medusa(Clone) has already spawned` and *"the local primary/auth character path fell back into Skinny/Kitsu state."* Fixed in Medusa v1.6.24+ by `SanitizeMirrorIdentities` (MedusaMod.cs ~L3210) + stable assetId `0x4D454455` ("MEDU") in `TryConfigureMirrorPrefab` (note: code uses `1296385109u` = 0x4D454455).

---

## 5. Notes on other scope items (lower-depth, for the synthesis agent)

- **Bots can't be Medusa**: `GameNetworkManager.charBotPrefabsByCharId` is a separate `Il2CppReferenceArray<CharacterBotPrefabs>` (decompiled GameNetworkManager.cs) that the mod does **not** extend — only `characterPrefabsByCharId` is grown. Confidence: high that bot-filled Medusa is unsupported.
- **Transparency / visible-only-after-damage / invisible enemies / red-outline remnants / FPS**: not in B2's code path; most plausibly the renderer-suppression + visual-fit/binding logic (`EnsureLiveMedusaEntity` L7037, "suppress the base skin renderers after spawn", high-frequency `PollOnce` visual-fit diagnostics throttled in v1.6.27). Belongs to a visuals-focused agent.
- **AMP persistence / first-attempt-fails-then-works / queue 3–8min**: out of B2 scope; siblings `D3_why_dll_reset.md`, `E3_coldstart.md`, `E2_startgame_bootstrap.md` already exist in `_research\findings`.

---

## 6. Hypotheses + confidence (B2-focused)

- **H1 (high):** charId 15 replicates correctly client-side via the Mirror `NetworkcharId` SyncVar; the mod re-stamps it on every PreMatch/Spawn callback and into `_currentSelectedCharacters` + `QueueMatchedData`. The replication value is 15 in the normal case (`RegisterPrefab` places the clone at index 15). Evidence: MedusaMod.cs L6757-6824, L6442, L6538, L6595, L3093-3138; PlayerManager.cs SyncVar wiring.
- **H2 (high):** The native dedicated game has **no charId 15** in `characterPrefabsByCharId` (15 entries, 0–14). Medusa only exists if the mod clones a base (Kitsu‑class) prefab into a grown index 15 **before** native `SpawnPlayerChar` reads it. A lost race or unloaded mod → OOB/base fallback (no real Medusa). Evidence: GameNetworkManager.cs L1128; MedusaMod.cs `EnsureMedusaPrefabRegistered`/`RegisterPrefab`; MEDUSA_SERVER_INTEGRATION.md three-place requirement.
- **H3 (high):** Tier C server is **not cosmetic-only**: it tracks, queues, bootstraps (`charId=15` in `MatchmakingPlayerData`), and persists Medusa mastery XP. But it sends **Kitsu's skin (300018)** and cannot supply abilities — gameplay identity is decided by the match-host mod. Evidence: CustomServerOptions.cs L532/551/577; LobbyService.cs L1291/1527; Program.cs L167-221.
- **H4 (high):** The "Kitsu FX / green lines" is **by design**, not a replication bug — the kit is Kitsu's, only the visual mesh is Medusa. Evidence: MEDUSA_SERVER_INTEGRATION.md "Known limits".
- **H5 (medium):** Unknown/unsupported charIds clamp differently per layer — Tier C → **1 (Anna)** (LobbyService.cs L620/705/1163); native game → base/char-0 via the cloned-prefab path (inferred, native body not visible).

### Key file:line index
- MedusaMod.cs: 587, 605-616, 619, 644-653, 656-664, 669-677, 695-707, 711-746 (+ GNM server hooks ~750-800), 1387, 1497, 2919, 3093-3138, 3168(SanitizeMirror), 6036, 6123, 6168, 6442, 6538, 6595, 6757-6824, 7037
- Decompiled: GameNetworkManager.cs 698/1128/1392 (`characterPrefabsByCharId`), GameMode.cs 3792 (`SpawnPlayerChar`), PlayerManager.cs 232/308/334/336/710 (charId SyncVar)
- Tier C: CustomServerOptions.cs 532/535-577/582/584; LobbyService.cs 620/705/1163/1288-1304/1527-1537; Program.cs 167/184/221/530-533
- Deploy: deployment\amp-github-autoinstall\verify-amp-instance.sh 70-74; docs\MEDUSA_SERVER_INTEGRATION.md (match-selection path + Known limits)
