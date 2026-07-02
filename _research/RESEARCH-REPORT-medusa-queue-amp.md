# Research-Report — Medusa, Queue & AMP-Persistenz

**Datum:** 2026-06-01
**Art:** REINE RECHERCHE — keine Code-Änderung, kein Build, kein Deploy.
**Basis:** 23 Subagent-Findings in `_research/findings/` (A1,A2,A4,A6,B2,B4,B6,C2,C3,C6,C7,D1,D2,D3,D5,D6,E1,E2,E3,E4,E5,E6,X1) + eigene Recon.
**Scope:** `C:\Users\Administrator\Downloads\CustomServer` + `C:\Users\Administrator\Downloads\BAPBAPModdingAPI`.

> Pfadkürzel: `MOD` = `BAPBAPModdingAPI\medusa-mod\MedusaMod.cs`; `SRV` = `CustomServer\CustomMatchServer\`; `DEP` = `CustomServer\deployment\`; `LATEST` = `BAPBAPModdingAPI\LatestBuild\latest\depot_2226283`.

---

## 0. TL;DR — die wichtigste Einzel-Ursache (VERSION/BUNDLE-DRIFT)

Der Live-AMP-Server läuft eine **ältere** Medusa-Version als der Quellcode. Das erklärt „läuft lokal, aber nicht live" und die grünen FX live in einem Satz.

| Artefakt | LIVE / AMP-Paket (alt) | QUELLE / lokaler Build (neu) |
|---|---|---|
| `BAPBAP.Medusa.dll` | `4D3050CA` · 162.816 B · **v1.6.27** | `999D4BDF` · 168.448 B · **v1.6.28** |
| `medusa.bundle` | `2F2CCF12` · 1,28 MB (cosmetic-only) | `C4872D6E` · 1,57 MB (enthält 6× `VFX_Medusa_Poison_*`) |
| Deploytes Game-Bundle | `Battleroyalebuild\UserData\Medusa\medusa.bundle` = **stale 1.275.524 B, ohne `.manifest`** | — |

- Beleg: `findings/A6_compiled_vs_source.md`, `findings/A4_bundle_vfx.md`, `findings/D2_package_build.md`.
- `deployment-info.json` schreibt **fälschlich** die NEUEN Hashes (`999D…`/`C4872D…`, releaseLabel „…v173-livepatch"), obwohl Paket UND zip die ALTEN Dateien tragen → die Versionsangaben lügen (D2, D6).
- v1.6.28-Changelog (`MOD:1527`) listet bereits Fixes für genau die gemeldeten Symptome („no repeated material alpha churn", „one-shot live visual repair guards", „stable cheap health checks") — die **live nicht aktiv** sind (X1).

**Konsequenz:** Ein Teil der Beschwerden ist evtl. schon im Quellcode gefixt, aber nie korrekt live gebracht. Vor jeder weiteren Diagnose muss die live laufende Version verifiziert/synchronisiert werden.

---

## 1. Abilities = nur grüne Striche + Kitsu-FX (statt echter Medusa-VFX)

**Status der Beschwerde: bestätigt. Mehrere überlagerte Ursachen.**

### 1.1 Medusa hat in diesem Build KEINE eigene Ability-Logik
- `BAPBAPModAPI\reverse-engineering\dumps\latest\medusa\ABILITY_MANIFEST.md`: im *Latest*-Build existieren **0** Medusa-AbilityBehaviourSO / Ability-Subklassen / FSM-Graphen. Grep über `dumps\latest\dump.cs` (41 MB): `Medusa`=0, `Gorgon/Serpent/Venom/Slither`=0 (A1).
- Folge im Mod: `MOD CloneConfig`/`CharacterConfiguration`-Builder (`MOD:2571-2650`) klont eine **Basis-Figur**, `BasePreference="Kitsu"` (`MOD:1232`, PickBase `MOD:2570-2575`). Abilities werden über `MakeAbility(b.abilityN,…)` (`MOD:2652`) als **Kitsus Kit, nur umbenannt** übernommen (A2, B4, A7).
- `charId 0 == Kitsu` im Latest-Build (`dumps\latest\dump.cs:127585` `KitsuCharId = 0`). `characterPrefabsByCharId` ist direkt per charId indiziert → ein unaufgelöster/abgelehnter charId bleibt 0 → **Kitsu-Body + Kitsus 4 Ability-Child-GOs** = „grüne Striche + Kitsu-FX" (B6, B2).

### 1.2 Die grünen Striche sind ein expliziter Platzhalter
- Pfad: `SpawnMedusaCastFx (MOD:1938)` → `TrySpawnNativeMedusaCastFx (MOD:2126)` gibt **false** zurück, wenn `_medusaNativeVfxPrefabs.Count == 0` → Fallback `switch(slot)` → `SpawnMedusaBeam (MOD:2287)` / `SpawnMedusaOrb (MOD:2332)` / `SpawnMedusaPuddle (MOD:2359)`.
- Farbe: `MedusaVenomFxColor = Color(0.18, 1, 0.32, 0.95)` (hellgrün) — das ist die „grüne Linie". `ApplyMaterial (MOD:2385)`/`Material()` bauen flache `Sprites/Default`/`Unlit`-Quads in Grün (A4, C2, B4).
- Beleg: `findings/A4_bundle_vfx.md` (HIGH confidence).

### 1.3 Die echten VFX existieren — werden aber NICHT ausgeliefert/gespawnt
Zwei verschiedene „echte VFX", nicht verwechseln:
1. **Native Latest-Build-Gameplay-Prefabs** (das, was du mit „im latest build" meinst): `Hitbox_MedusaPoisonProjectile` (GUID `e65875d4…`), `Hitbox_MedusaPoisonPuddle` (`37bc4bd3…`), `Hitbox_MedusaWallPoison` (`a7a4371f…`), `Hitbox_MedusaWallBoxDpsPoison` (`62fd1b7d…`), `MedusaPuddleSpawner` (`db861b62…`) — alle mit `BAPBAP.Local.VFXSpawn`. Quelle: `ABILITY_MANIFEST.md §3`. **Diese sind in KEINEM Bundle** (A4, A1).
2. **Custom-Cosmetic-VFX** des Mods: `VFX_Medusa_Poison_{Escape,Hit,Muzzle,Puddle,Trail,Wall}` — im backport-Unity-Projekt selbst gebaut. Diese sind **nur im NEUEN Bundle** `C4872D6E` (1,57 MB), Beleg `medusa-mod\backport\unity_build.log` „BuildVfxPrefabs: built 6/6". `NativeVfxNames` (`MOD:1269-1290`) matchen genau diese Namen.

- Warum die nativen Hitbox-Prefabs fehlen: `BuildMedusaBundle.cs DisableGameplayComponents()` + `RemoveMonoBehavioursWithMissingScript` strippen alle Hitbox/Spawner/Projectile/Dps/Network-Komponenten → Bundle ist **bewusst cosmetic-only** (A4).
- Warum live trotzdem grün: das **deployte** Game-Bundle ist das alte `1.275.524 B`-Bundle ohne `.manifest` → `ResolveBundlePath (MOD:3566)` lädt zuerst aus `UserData` → 0/6 VFX-Prefabs → `_medusaNativeVfxPrefabs.Count==0` → grüner Fallback (A4, Medium-High).

**Hypothesen (mit Confidence):**
- H1 (HIGH): Grüne Striche = `SpawnMedusaBeam`-Platzhalter, weil keine native VFX-Prefabs geladen sind.
- H2 (HIGH): Kitsu-FX = Abilities sind verbatim Kitsu-Klone (kein bespoke Medusa-Kit im BR-Build).
- H3 (MEDIUM-HIGH): Live zusätzlich verschärft durch stale cosmetic-only Bundle.
- H4 (HIGH): Die echten Latest-Build-Hitbox/VFX-Prefabs müssten erst ins Bundle gebacken + per `AB_SpawnHitbox_Base_SO`/Ability-Subklasse gespawnt werden (sie haben keine eigene Treiber-Logik). Siehe `ABILITY_MANIFEST.md §5/§6` (generische Typen wie `HitboxDps:208007`, `ProjectileMove:208562`, `VFXSpawn:243015`, `AB_SpawnHitbox_Base_SO:184120` sind im BR-Build vorhanden).

**Fix-Richtung (nur Analyse):** Native Hitbox/VFX-Prefabs aus dem Latest-Build in ein neues Bundle aufnehmen (Gameplay-Komponenten NICHT strippen), `LoadNativeMedusaVfxPrefabs`/`TrySpawnNativeMedusaCastFx` darauf zeigen, Ability-Slots von Kitsu-Klon auf `AB_SpawnHitbox_Base_SO`-Instanzen umstellen, Petrify/Poison-Hooks behalten.

---

## 2. Medusa spawnt rein/raus, wird transparent, erst sichtbar nach Schaden, FPS-Drops

### 2.1 Spawn rein/raus + Flackern (Race)
- Basis-Char wird **zuerst nativ** gespawnt (`GameMode.SpawnPlayerChar`, decompiled `GameMode.cs:3792` → `NetworkServer.Spawn`); Basis-Renderer sind sichtbar, bevor Mod-Code läuft.
- Graft passiert erst per Harmony-**Postfix**: `EntityManagerStartPatch (MOD:802)`, `EntityManagerOnStartClientPatch (MOD:812)`, `GameModeSpawnPlayerCharPatch (MOD:711-746)`.
- Im Fresh-Graft-Zweig: `DisableBaseCharacterRenderers (MOD:5138/5228)` läuft **vor** `Instantiate(Medusa_Visual) (MOD:5139)` → ≥1 Frame Lücke = „kurz da, dann weg" (C7, HIGH).
- `LooksLikeMedusaEntity (MOD:6050)` keyed auf `IsMedusaId(charId)` (`MOD:6055`), aber `charId` ist **SyncVar**. Läuft der `Start`-Postfix bevor der SyncVar angekommen ist (typisch bei Remote-Clients), ist charId noch 0 → Graft wird **übersprungen** → Basis sichtbar; spätere `OnStartClient` oder Retries `TimerAPI.Once(0.15/0.45/0.95/1.8s)` (`MOD:7110-7113`) reparieren es → exakt das „erst nach einer Weile / nach Event" (C7, HIGH-MEDIUM).

### 2.2 Transparenz
- Beleg: `findings/C2_material_shader_alpha.md`. Zwei gestapelte Ursachen:
  1. **Falscher Shader im Bundle:** `Medusa_Material.mat` nutzt Unity-`Standard` (fileID 46) mit ungültigen Char-Shader-Keywords. Der Mod muss zur Laufzeit das Toon-Material einer echten Figur klonen (`GraftMedusaVisual MOD:4837`, Capture `MOD:4860`, instanced clone `new Material(val) MOD:4929`). Schlägt der Graft fehl, bleibt Medusa auf `Standard`, das die native Alpha-Pipeline nicht steuern kann.
  2. **Native CharMaterial-Fade/Alpha-Lerp:** native `CharMaterial` wrappt jeden Renderer in `matInstance` und rampt Alpha hoch (Spawn-in-Fade) + tauscht opaque/transparent Shader pro Frame. Der Mod kämpft dagegen in `ForceMedusaCharMaterialVisible (MOD:4026-4135)` (pinnt alpha=1, isOpaque=true, isPartialHidden=false, `RevealHiddenCharacter()`); `NeedsCharMaterialVisibilityRepair (MOD:4197-4246)` prüft jeden Poll erneut (`alpha<0.99 || !isOpaque || isPartialHidden || !rendererIsActive`). Die Existenz dieser Repair-Schleife = Bestätigung, dass der native Fade die Transparenz erzeugt.
- Material ist auf beiden Ebenen **instanced** → SMR-Material-Schreibzugriffe werden pro Frame von der nativen `matInstance`-Alpha überschrieben; nur die `CharMaterial`-API enthüllt sie zuverlässig (C2, HIGH 0.9 / 0.8).

### 2.3 Erst sichtbar nach Schaden
- „Visible-after-damage" = native `TriggerHit`/`UpdateHitBlink` reapplied das Material-Alpha (C2, MEDIUM 0.75). Hook-seitig fackelt `HitboxDoEntityHitPetrifyPatch (MOD:1094-1231)` / Status-/Animator-Rebind das CharMaterial-Repair an, das den Visual erstmals korrekt bindet (C5-Bereich, durch C2/C6/C7 abgedeckt).

### 2.4 FPS-Drops / Standbilder
- Beleg: `findings/C3_fps_drops.md`. Cadence: `PollOnce` 1 Hz, `PollLocalInputCastFx` 20 Hz — laufen das **ganze Match** ohne Stopp.
- PRIMARY (HIGH): `PollOnce (MOD:1539)` ruft jede Sekunde uncached `FindCharConfig()` → `Resources.FindObjectsOfTypeAll<UICharactersConfiguration>` (`MOD:5810`, +UIManager `MOD:5832`) — der teuerste Unity-Scan (scannt ALLE geladenen Objekte inkl. Assets). Plus `LogLiveLocalDiagnostics (MOD:1566)` mit 2× `FindObjectsOfType` (`MOD:1570/1571`) **vor** seinen Guards.
- SECONDARY (MED-HIGH): Wird der Visual nie „stable" (gleiche Bedingung wie Transparenz/Invisible-Bug), läuft `EnsureLiveMedusaVisual (MOD:5066)` jede Sekunde im teuren Zweig (Instantiate + Dutzende `GetComponentsInChildren` + `new Material`); `ScheduleLiveMedusaRefresh (MOD:7071)` 4 schwere Rebuild-Bursts/Root.
- TERTIARY (MED): Ability-Spam → `PollLocalInputCastFx`@20 Hz → `FindLocalMedusaEntity` `FindObjectsOfType<EntityManager>` (`MOD:1839`) wenn local→primary-Binding falsch.
- `IsHighFrequencyVisualDiagnosticSource (MOD:4653)` unterdrückt nur Log-Zeilen, **nicht** die Scans → Scans bleiben auch nach „ready".

**Hypothese (HIGH):** Transparenz-, Spawn- und FPS-Bug sind **gekoppelt** — solange der Visual nicht stabil bindet (Race + falscher Shader + nativer Fade), läuft jede Sekunde der teure Repair-Zweig → FPS + Flackern + Transparenz gleichzeitig.

---

## 3. Kitsu/Skinny-Fallback (warum überhaupt Kitsu/Skinny statt Medusa)

- Beleg: `findings/B4_…`, `B2_…`, `B6_…`, `C7_…`.
- **Dokumentierter Hauptmechanismus:** der geklonte Prefab trug Mirror-`NetworkIdentity` mit `hasSpawned=True` → Mirror lehnt ab („`Char_Medusa(Clone) has already spawned`") → „local primary/auth path fell back into **Skinny/Kitsu** state" (`docs\MEDUSA_SERVER_INTEGRATION.md`).
- **Fix v1.6.24+:** `SanitizeMirrorIdentities (MOD:3210)` + stabile Asset-ID `0x4D454455` = ASCII **„MEDU"** (`MedusaMirrorAssetId=1296385109u`, `MOD:1237`, gesetzt in `TryConfigureMirrorPrefab MOD:3151/3186`), `RegisterPrefab (MOD:3093)`, Basis-Renderer unterdrücken (`DisableBaseCharacterRenderers MOD:5228`).
- **Tiefere Ursache (B6, DECISIVE):** kein expliziter „default character"-Zweig; `charId 0 == Kitsu` (`dumps\latest\dump.cs:127585`). `PlayerManager.charId`/`EntityManager.charId` sind `[SyncVar] int` (default 0). Unaufgelöster/abgelehnter charId bleibt 0 → `characterPrefabsByCharId[0]` = **Kitsu**. `UICharactersConfiguration.TryGetCharConfigByCharId` ist linearer Match ohne Index-0-Substitution (`ida-project\hexrays_bapbap.c:711-718`).
- **Server (B2):** unbekannte ids werden auf charId **1 (Anna)** geclampt (`SRV CustomServerOptions.cs:620/705`, `LobbyService.cs:1163`) — nicht 0. Medusa (15) wird gequeued/bootstrapped (`LobbyService:1291`), aber Skin = Kitsus `300018` (`CustomServerOptions.cs:579`, `GetEquippedSkinForCharacter LobbyService:1527`).
- **Skinny** speziell: unmapped zu einem benannten charId; erscheint vermutlich über Bot-Fill `SpawnBotChar(charId=-1)`-Default oder Index-vs-charId-Roster-Skew (Skinny = Legacy-Slot 6) — MEDIUM, native Body nicht lesbar (B6).

**Hypothese (HIGH):** Solange Medusas Prefab nicht sauber bei charId 15 registriert/akzeptiert ist (Mirror-Sanitize muss greifen UND der Server muss 15 kennen), fällt die Engine implizit auf charId 0 = Kitsu zurück. Die v1.6.24+-Sanitize behebt das meistens — aber nur, wenn die **neue** DLL live läuft (siehe §0).

---

## 4. Persistente Match-Reste nach dem Verlassen (rote Umrandung)

- Beleg: `findings/C6_match_remnants_cleanup.md`.
- **Mod hat KEIN Teardown:** kein `OnDestroy`/Leave/Match-End-Hook in `MOD` (grep-bestätigt). Beide Timer (`MOD:1529-1530`, 1 Hz `PollOnce` + 0,05 s `PollLocalInputCastFx`) laufen ewig ohne Match-Gate.
- **Statischer Prozess-Lebenszeit-State** per Unity-Instance-IDs (`MOD:1347-1357,1455,4362`) wird nur bei >128 Einträgen gelöscht, **nie** bei Match-Ende → Instance-ID-Recycling über Matches hinweg lässt den Mod frische Entities als „already stable" behandeln → Re-Graft/Re-Enable übersprungen → starker Beitrag zu „Gegner unsichtbar / erst nach Schaden sichtbar".
- **Rote Umrandung:** WEDER Mod zeichnet ein Outline/Rot (grep-bestätigt; Mod-Farben sind grün/dunkel). Also **natives Element** (Gegner-Outline/Silhouette-Pass oder Petrify-Overlay), das nicht aufgeräumt wird. Petrify/Poison werden in `MOD:1179/1191` appliziert und nie entfernt; `SE_Petrified` trägt `applyCharColor` + Loop-VFX ohne garantiertes `DisablePetrifyFx` beim Teardown. `DisableBaseCharacterRenderers` toggelt nur `Renderer.enabled`, **nicht** den Outline-Pass (C6, MEDIUM auf exakte native Quelle).
- **Native UI bewusst persistent:** `CustomServerMod.cs` nutzt `DontDestroyOnLoad` (`MOD CustomServerMod:1020-1043,5172`), zerstört UI nur bei `OnApplicationQuit` → Overlays überleben Szenenwechsel by-design.
- **Server-Teardown-Lücke (HIGH):** Leave/Disconnect (`SRV LobbyService.cs:384-405`, `RemoveFromLobbyAsync:1576+`) ruft **nie** `StopMatchServer`. Matches werden nur bei `GAME_ENDED (LobbyService:275)` oder bereits beendetem Prozess (`CleanupStaleMatches:141`, alle 10 s via `ResourceMonitorService.cs:63`) abgeräumt → ein leeres/lebendes Match ohne `GAME_ENDED` bleibt hängen → server-seitiger Rest + stale State bei Wiedereintritt.

**Hypothesen:** (1, MEDIUM) Rote Umrandung = natives Gegner-Outline/Petrify-Overlay, das durch fehlendes Mod-Teardown + Renderer-Toggle ohne Outline-Pass übrig bleibt und via `DontDestroyOnLoad` in die Lobby überlebt. (2, HIGH) Server hält totes/leeres Match nach Leave. (3, MED) Instance-ID-Kollisionen in nicht-gelöschten static guards → unsichtbare Gegner.

---

## 5. AMP-Persistenz (warum die DLL „zurückgesetzt" wird; echter Update-Pfad; SFTP/Webupload)

- Belege: `findings/D1_…`, `D3_…`, `D5_…`, `D2_…`, `D6_…`.

### 5.1 Was wirklich überschreibt
- `DEP\amp-github-autoinstall\bapcustomservergithubupdates.json:52-62` — Stage „Download BAPBAP Custom Server full package": `UpdateSource=GithubRelease`, Asset `bapcustomserver-amp-full-linux-wine.zip`, Target `{{$FullBaseDir}}` (= `./BapCustomServer/`, `bapcustomservergithub.kvp:24`), `UnzipUpdateSource=true`, `OverwriteExistingFiles=true`, `DeleteAfterExtract=true`, `SkipOnFailure=false`.
- Diese zip enthält `game/Mods/BAPBAP.Medusa.dll` (`verify-amp-instance.sh:74` verlangt sie). → **AMP „Update" re-extrahiert die 552 MB-zip über die Live-Dateien und überschreibt jede live hochgeladene DLL.**

### 5.2 Start/Restart setzen NICHTS zurück
- `bapcustomservergithub.kvp`: `App.PreStartStages=[]` (`:47`), `App.ForceUpdate=False` (`:49`), Start läuft nur `amp-webpanel-start.sh` (`:27`) → `chmod` + Diagnostics + optionales Wine-Prewarm + `exec ./BapCustomServer`. **Kein** unzip/cp/download.
- Einziger Start-Write: `metaconfig.json` AutoMapped **nur `appsettings.json`** aus den UI-Werten — d.h. eine SFTP-Edit an `appsettings.json` wird vom Restart revertiert, eine `.dll`-Edit **nicht**.
- **→ Die Nutzer-Aussage „nach Restart kommen alte Dateien zurück" ist eine Fehlzuordnung: der Reset passiert beim UPDATE (oder Neuinstallation), nicht beim Restart.** (D3, D5, HIGH)

### 5.3 SFTP/Webupload-Alternative (deine Frage)
- Eine DLL via AMP-Dateimanager/SFTP nach `…/BapCustomServer/game/Mods/BAPBAP.Medusa.dll` (+ `game/UserData/Medusa/medusa.bundle`) **überlebt Start UND Restart** und wird **erst beim nächsten „Update" überschrieben**. → valider Hotfix-Pfad ohne 10-15 min GitHub-Upload (D4-Bereich, abgedeckt durch D3/D5).
- Caveat (MEDIUM): `SmartExcludeExemptions` schützt nur `*.json/*.log/*.jsonl` (`kvp:52`); `.dll`-Erhalt über Update ist NICHT garantiert (eher: wird überschrieben). Nicht live an AMP verifizierbar.

### 5.4 Echter persistenter Pfad
1. Bundle/DLL neu bauen → `tools\Build-AmpFullLinuxWinePackage.ps1` (regeneriert zip) → `tools\Publish-GitHubAmpRelease.ps1` (`gh release create`, **gleicher Asset-Name** `bapcustomserver-amp-full-linux-wine.zip`) → in AMP „Update" drücken.
2. Achtung (D1): 5 vorgelagerte `FetchURL`-Stages stellen außerdem die kvp/config-Templates aus `raw.githubusercontent` bei jedem Update wieder her (`OverwriteExistingFiles=true`) → live-editierte kvp-Settings reverten ebenfalls.
3. Pinned-Hash-Lücke (HIGH, D2): nur `BapCustomServerMelon.dll` ist SHA-gepinnt; `BAPBAP.Medusa.dll`/`medusa.bundle`/`ModAPI` werden **nur auf Existenz** geprüft (`Build-AmpFullLinuxWinePackage.ps1:686-690`) — kein Hash-Enforcement → genau hier konnte die Drift aus §0 unbemerkt entstehen.

---

## 6. Queue 3-8 min + „erster Versuch fehlerhaft, dann geht's plötzlich"

- Belege: `findings/E1_…`, `E2_…`, `E3_…`, `E4_…`, `E5_…`, `E6_…`.

### 6.1 Die Requeue-Timer-Reset-Schleife (Kern)
- `SRV MatchmakingHostedService.cs`: 1 s `PeriodicTimer` (`:21`); bei Fehlstart `if(!started) RequeuePlayers(players)` (`:35-38`, auch im catch).
- `SRV MatchmakingQueueService.cs RequeuePlayers (:218)`: nach Re-Add setzt es `_queueStartedUtc = DateTimeOffset.UtcNow` (`:238`) → **voller 30 s-Countdown startet neu** (`QueueTimerSeconds=30`, Gate `IsReadyInternal:353`).
- Beleg E1 (HIGH 0.9).

### 6.2 Warum der Start fehlschlägt (cold start)
- `SRV LobbyService.StartMatchmakingGameAsync (:1093)` → `GameServerProcessManager.StartMatchServerAsync (:46)` → `Process.Start (:105)` (auf Linux via `start-match.sh` Wine/Xvfb) → `TryBootstrapServerAsync (:138/184)`.
- `false`/throw wenn: Prozess früh beendet (`:205`); die 3 POSTs `/setup-game`,`/add-teams`,`/queue-matched` erreichen den Mod-HTTP-Listener nicht vor `deadline = startedAt + GameServerReadyTimeoutSeconds` (`:189/264`); oder KCP-UDP-Port nicht binnen 15 s sichtbar (`:229/472`).
- `GameServerReadyTimeoutSeconds`: C#-Default **30** (`CustomServerOptions.cs:43`), aber **120** im deployten `appsettings.json:33` → effektiv 120 s (E2, E4).
- Ursache cold-fail: `docs\AMP_LINUX_WINE_ROOT_CAUSE.md` „`POST 127.0.0.1:7850/setup-game` Connection refused" — Wine/Unity-Bootstrap öffnet den Listener zu spät. `start-match.sh` macht `rm -rf $WINEPREFIX` bei Key-Wechsel → erster Post-Deploy-Match überschreitet 120 s → Fehlschlag; warmer 2. Versuch klappt (E3, D6, HIGH).

### 6.3 Die Zeit-Mathematik (passt zu 3-8 min)
- Ein gescheiterter Cold-Cycle ≈ **120 s** (Bootstrap-Deadline) + **30 s** (frischer Queue-Timer) ≈ **150 s** (E4, E1).
- 1 Fehlschlag + Erfolg ≈ 3,75-5,0 min; 2 Fehlschläge ≈ 6,25-7,5 min → exakt die gemeldeten 3-8 min. Kein Backoff, kein Max-Attempts-Cap (E4 HIGH 0.85).
- Zusätzlich pro Erfolg: ≤15 s KCP-UDP (`GameServerProcessManager.cs:474`) + ≤15 s `/health` (`LobbyService.cs:1216`) + ~33 s In-Match Char-/Spawn-Select.

### 6.4 Warum die Anzeige verwirrt
- `TakeReadyMatch` nullt `_queueStartedUtc` und leert die Queue beim Startversuch (`MatchmakingQueueService.cs:203-204/209-210`); während der bis zu 120 s zeigt `GET /api/queue/status` `PlayerCount=0, IsActive=false, SecondsRemaining=30` (`:324/327`). `RequeuePlayers` snapped den Countdown zurück auf 30 s → die Anzeige „loopt" ohne Spawn-Signal (E5 HIGH).
- Der MelonLoader-Mod pollt die Queue NICHT selbst — er ist ein transparenter HTTP/WS-Reverse-Proxy; der native Client treibt die Queue-UI aus `secondsRemaining`/WS-Events (E5).

### 6.5 Zusätzliche Prozess-Risiken (E6)
- `MaxConcurrentMatches=0` = unbegrenzt → Kapazität ist NICHT der Blocker.
- `PortAllocator.IsFree()` bindet nur TCP-Loopback (`:135`) → ein belegter UDP/KCP-Port oder ein **Zombie-Wine-Prozess** ist bei der Reservierung unsichtbar (MED-HIGH). Der Bootstrap-Fehlerpfad nutzt `ReleaseImmediately` und umgeht den 60 s-UDP-Cooldown (`:142/159`) → Back-to-back-Retry-UDP-Kollisionen (MED).
- Kein Startup-Orphan-Cleanup → Leftover-Wine-Prozess von vorigem Restart/Update kann KCP-Port halten und den ersten Versuch fehlschlagen lassen.

**Hypothese (HIGH):** „Nur die erste Runde dauert lang" stimmt mit der Cold-Start-Theorie überein: erster (kalter) Wine-Start verfehlt das 120 s-Fenster → Requeue (+30 s) → warmer Prozess klappt. Danach bleibt der Prozess/Prefix warm → schnelle Queue.

**Fix-Richtungen (nur Analyse):** `_queueStartedUtc` bei Requeue NICHT zurücksetzen; Retry-Backoff/-Cap; `GameServerReadyTimeoutSeconds` ~150 s; Prozess/Prefix vorwärmen (Prewarm gibt's schon optional); Orphan-/Port-Cleanup vor Reservierung; UDP-Cooldown auch im Fehlerpfad.

---

## 7. „Nicht automatisch Medusa bekommen" / normale Char-Auswahl

- `AutoSelectMedusaEnabled() (MOD:5876-5899)` gibt **nur `true`** zurück, wenn:
  1. Umgebungsvariable `BAPBAP_MEDUSA_AUTOSELECT` = `1`/`true`/`yes`, ODER
  2. Datei `UserData/Medusa/auto-select.txt` existiert.
  Sonst **`false`**. `MaybeAutoSelectMedusa (MOD:6434-6440)` schedulet die Auto-Selektion nur, wenn das true ist.
- Die Packager prüfen, dass `UserData/Medusa/auto-select.txt` **nicht** im AMP-Paket/Client-Bundle ist (Default), und nur `BAPCUSTOM_PACKAGE_MEDUSA_AUTOSELECT=1` würde den Marker einpacken (`docs\MEDUSA_SERVER_INTEGRATION.md`).

**Befund (HIGH):** Auto-Select ist standardmäßig **AUS** — die Char-Auswahl ist also bereits „normal". Wenn live trotzdem auto-selektiert wurde, liegt entweder die Datei `UserData/Medusa/auto-select.txt` im Deployment oder die Env-Var ist gesetzt. Zum Garantieren: beide entfernen/nicht setzen. Medusa erscheint als normaler, klickbarer Grid-Eintrag (DOCUMENTATION.md §2).

---

## 8. Medusa-Artwork (deine 2 Render-Bilder) — wo es rein müsste

- Beleg: `findings/A2_registration_identity.md` (HIGH).
- Aktuell werden **alle** 2D-Sprites von Kitsu kopiert: `smallSprite (MOD:2632)`, `IconSprite (2633)`, `LobbyBackground (2634)`, `FullSprite (2635)`, `StandingSprite (2636)`, `CircleIcon (2637)`, `SquareIcon (2638)`, `SquareSmallIcon (2639)`, `gameStatsLobbySpriteModifier (2640)`, `DefaultSkin (2641)`.
- **Im Mod gibt es KEINEN Custom-Art-Lade-Pfad:** null `Sprite.Create`/`LoadImage`/`Texture2D`-UI/`.png`-Loads (nur 3D-Albedo/Normal in `BuildMedusaBundle.cs:28-29`). XP/Mastery-Art: keine (backend-gated, DOCUMENTATION.md §4).
- **Injektionspunkte für deine Bilder:**
  - Char-Select großes Bild + Lobby großes Bild → `FullSprite`/`StandingSprite`/`LobbyBackground`.
  - Lobby vertikale Karte → `IconSprite`/`SquareIcon`/`CircleIcon`/`smallSprite`.
  - XP-Pfad → existiert nicht client-seitig; müsste neu gebaut/serverseitig ergänzt werden.
- Damit deine PNGs erscheinen, braucht es einen neuen Loader (z.B. ins `medusa.bundle` packen oder `Sprite.Create` aus PNG) + Zuweisung in `CloneConfig` statt der Kitsu-Sprites (A2, HIGH).

---

## 9. Widersprüche / Daten-Hygiene (X1)

- **3-Wege-Versions-Skew:** `medusa-mod/README.md`+`DOCUMENTATION.md` = v1.4/1.5; `docs/MEDUSA_SERVER_INTEGRATION.md`+`AMP_LINUX_WINE_ROOT_CAUSE.md` = v1.6.24-1.6.27; gebauter Code `MOD:1526` = **v1.6.28**. Doc-Leser unterschätzen, was schon gefixt ist.
- **Pinned-Hash-Konflikt:** Top-Level-Handoffs pinnen `035F…`/`…cleanlogs`, `docs/` pinnt `3E79…`/`…v172` → Handoffs sind stale.
- **Bundle-Größe:** on disk 1,57 MB vs. dokumentiert 1,27 MB.
- **`_research/AMPTemplates`** ist nur ein Klon des CubeCoders-AMPTemplates-Repos, kein Projekt-Research.
- **`analysis/diff.txt`:** Bootstrap-Listener wurde von `HttpListener` → `TcpListener` mit festem `Content-Length` umgebaut (relevant für Queue-Bootstrap).

---

## 10. Priorisierte Hypothesen-Matrix

| # | Symptom | Wahrscheinlichste Ursache | Confidence | Schlüssel-Belege |
|---|---|---|---|---|
| 1 | grüne Striche | `SpawnMedusaBeam`-Platzhalter, keine nativen VFX-Prefabs geladen | HIGH | A4 `MOD:1938/2126/2287` |
| 2 | Kitsu-FX/Kit | Abilities sind verbatim Kitsu-Klone; kein Medusa-Kit im Build | HIGH | A2/B4/B6 `MOD:2652`,`dump.cs:127585` |
| 3 | „läuft lokal, nicht live" | Version/Bundle-Drift (live v1.6.27 + stale cosmetic Bundle) | HIGH | A6/A4/D2 |
| 4 | Transparenz | nativer CharMaterial-Fade + falscher Bundle-Shader; Repair-Schleife kämpft dagegen | HIGH | C2 `MOD:4026/4197/4837` |
| 5 | rein/raus, Flackern | Spawn-Race: Base zuerst, Graft im Postfix, charId-SyncVar noch nicht da | HIGH | C7 `MOD:5138/5139/6055` |
| 6 | sichtbar erst nach Schaden | `TriggerHit` reapplied Alpha; Graft zu spät gebunden | MED-HIGH | C2/C5/C7 |
| 7 | FPS-Drops/Standbilder | per-Poll `Resources.FindObjectsOfTypeAll`/`FindObjectsOfType` + heavy `EnsureLiveMedusaVisual` | HIGH | C3 `MOD:1539/5810/1566` |
| 8 | Gegner unsichtbar | nicht-gelöschte static instance-ID-Guards + Renderer-Toggle | MED | C6 `MOD:1347/4362` |
| 9 | rote Umrandung bleibt | natives Outline/Petrify-Overlay, kein Mod-Teardown, `DontDestroyOnLoad` | MED | C6 |
| 10 | DLL „resettet" | AMP **Update** re-extrahiert Release-zip; nicht Restart | HIGH | D1/D3/D5 `updates.json:52-62` |
| 11 | Queue 3-8 min | Requeue resettet 30 s-Timer + 120 s Cold-Bootstrap-Timeout/Zyklus | HIGH | E1/E4 `MatchmakingQueueService:238`,`appsettings:33` |
| 12 | 1. Versuch scheitert, dann ok | kalter Wine/Unity-Start verfehlt 120 s-Fenster; warm klappt | HIGH | E3/D6 `AMP_LINUX_WINE_ROOT_CAUSE.md` |
| 13 | Auto-Select | aus by default; nur via Env/`auto-select.txt` | HIGH | `MOD:5876` |
| 14 | Custom-Artwork fehlt | kein PNG/Sprite-Loader; Kitsu-Sprites kopiert | HIGH | A2 `MOD:2632-2641` |

---

## 11. Einzel-Findings (Index)

Alle Detail-Dateien mit `file:line`, Zitaten und Confidence in `C:\Users\Administrator\Downloads\CustomServer\_research\findings\`:

`A1_latest_assets`, `A2_registration_identity`, `A4_bundle_vfx`, `A6_compiled_vs_source`, `B2_replicated_charid`, `B4_skin_material_fallback`, `B6_native_default_logic`, `C2_material_shader_alpha`, `C3_fps_drops`, `C6_match_remnants_cleanup`, `C7_mirror_spawn_race`, `D1_update_source`, `D2_package_build`, `D3_why_dll_reset`, `D5_restart_vs_update`, `D6_deploy_pipeline_e2e`, `E1_requeue_timer`, `E2_startgame_bootstrap`, `E3_coldstart`, `E4_queue_timing_math`, `E5_queue_endpoints_client`, `E6_process_lifecycle`, `X1_crosscut_synthesis_inputs`.

*(Ohne eigene Datei, aber durch Overlap abgedeckt: A3→B2/B4/D6; A5/A7→A2/A4/B4; B1→B4/B2/C7; B3→§7 (eigene Recon); B5→A2/A4; C1/C4/C5→C2/C6/C7; D4→D3/D5.)*

— Ende des Reports. Reine Recherche; keine Quell-, Build- oder Deploy-Änderung vorgenommen.
