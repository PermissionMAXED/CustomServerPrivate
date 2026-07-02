# BAPBAP — Korrektes Konzept für networked Custom-Chars + Abilities

> Synthese aus 16 Tiefen-Recherche-Dokumenten (`analysis/research/r01..r18`) am echten dekompilierten Spielcode. Dieses Dokument ersetzt den bisherigen Klon-/Client-Graft-Ansatz vollständig.

## 0. Die eine Wurzel des Problems (von allen Agents bestätigt)

Der alte Ansatz hat **Mirrors server-autoritativen Replikations-Vertrag verletzt**. Er hat eine Kitsu-Kopie **nur lokal auf dem Client** umgebaut, Abilities per Harmony-Seitenkanal gefälscht, und der **dedizierte Server hat weiterhin den Basis-Char gespawnt**. Daraus folgen ALLE vier Symptome als Facetten EINES Fehlers:

| Symptom | Ursache |
|---|---|
| Andere sehen Medusa nicht | Server spawnt Basis-Char; Visual/Attacks existieren nur lokal (`CanSpawnClientFx`-gated `Object.Instantiate`). Remote-Clients bekommen nie die Medusa-`assetId`. |
| Despawn | Client-Klon hat eine `assetId` (`0x4D454455`), die kein anderer Peer kennt → Mirror verwirft/zerstört das nicht-gematchte Objekt; nicht in der Server-AOI. |
| Standbilder | Grafteter Animator/Rig wird nicht vom networked `CharAnimator`/`CharEvents`-Animations-Kanal getrieben; Remote haben gar kein Medusa-Rig. |
| Nur LMB geht, RMB=grüner Punkt, Space buggt, E=Kitsu | Der Klon behält **Kitsus** echte `Ability`-Komponenten. „Neue" Abilities waren Fakes außerhalb der predicted Simulation. Slot 0 funktioniert, weil dort Kitsus echte Ability mit networked `spellPrefab` bleibt. |

**Kernsatz:** Ein Custom-Char muss eine **echte networked Entität** sein, die der **Server spawnt**, mit einer **stabilen `assetId`, die auf Server UND jedem Client identisch registriert ist**. Alles andere ist prinzipiell unsichtbar für andere.

## 1. Wie BAPBAP-Chars + Abilities WIRKLICH funktionieren

**Char-Identität (zwei charId-gekoppelte Systeme):**
- **Gameplay-Aktor** = networked Prefab. `GameNetworkManager.characterPrefabsByCharId[charId]` (Index == charId) + `charBotPrefabsByCharId[charId]` für Bots. Jedes ist ein Mirror-`NetworkIdentity`-Prefab, komponiert aus ~30 `Char*`-Komponenten mit `EntityManager` als Hub. Spawnbare Prefabs liegen in `NetworkPrefabLibrary` (PooledPrefabs/InstantiatedPrefabs).
- **Präsentation** = `UICharactersConfiguration._characters[]` (Rows vom Typ `CharacterConfiguration`, key `charId`): Name, Beschreibung, `enabledInLobby`, Sprites, Farben, `DefaultSkin`, und pro Slot UI-`AbilityData` (Icon + Text-Keys). **Keine Gameplay-Zahlen.**
- **Bindeglied** = `EntityManager.charId` ist ein Mirror-`[SyncVar]`. Server setzt ihn am gespawnten Prefab, repliziert an alle.

**Spawn (server-autoritativ):** Char-Select läuft über `PlayerPreMatch.CmdTrySelectCharacter` → `PreMatchManager` → `PlayerManager.charId` (`[SyncVar]`). Beim Match-Start ruft `GameMode.SpawnPlayerChar()` → wählt `characterPrefabsByCharId[charId]` → `GameMode.SpawnEntity` `[Server]` → `NetworkServer.Spawn`. Die `SpawnMessage` trägt **nur die `assetId`**; jeder Client löst `assetId → Prefab` über `NetworkPrefabPool` auf.

**Abilities (server-autoritativ + client-predicted mit Rollback):** Jede Ability ist eine **C#-Klasse `Ability : NetworkBehaviour`** als **Komponente auf dem Char-Prefab** (~130 existieren: `ArrowAbility`, `KatanaMeleeAbility`, `CatJumpAbility`, …). Slot = `Ability.cmdId` (`CommandId`: Ability1=0=LMB, Ability2=1=RMB/Q, Ability3=2=Space, Ability4=3=E). Eingabe läuft über `Command` (per-Tick-Paket, Tastenbits) → `CharAbilities` → `Ability.Tick(dt, cmd, isResim)` → `SimulationFsm` (Cast→Active→Cooldown) → spawnt server-seitig ein networked `HitboxBase`-Prefab via gepooltem `NetworkServer.Spawn`. Schaden NUR in `[Server]`/`[ServerCallback]`, Kosmetik via `[ClientRpc]`. Identischer Code läuft auf Owner-Client (Prediction) + Server (Autorität) über `CharSimulation`/`CharNetwork`.

**VFX:** Repliziert über den **`CharEvents`-predicted-Event-Buffer** (`AddPredictedVfxEvent`, `vfxId` = **int-Index** in `VfxManager.vfxPrefabConfigs`) ODER `[ClientRpc]` ODER `VFXSpawn` auf einem Mirror-gespawnten Carrier. **Animationen nutzen denselben `CharEvents`-Kanal** (`AddPredictedAnimEvent`). Ein blankes `Object.Instantiate` ist immer nur lokal.

**Status (poison/petrify/…):** `CharStatusEffects.ActivateStatusEffect()` ist `[Server]`-only. Effekte sind `SE_Xxx` + `SE_Xxx_SO`, registriert in `StatusEffectManager.statusEffects[]` — **der Array-Index IST die id**. Anwendung über `StatusEffectInfo` am Hitbox-Prefab.

## 2. Die harte IL2CPP-Einschränkung (entscheidend!)

**Man kann zur Laufzeit KEINE neuen `NetworkBehaviour`-Typen einschleusen.** Mirrors `[SyncVar]/[Command]/[ClientRpc]`-Serialisierung wird **zur Weave-Zeit** auf der Spiel-Assembly generiert; ein per `Il2Cpp ClassInjector` injizierter `NetworkBehaviour` hat **keine Serialisierung**. Die Community nutzt `ClassInjector` ausschließlich für **lokale** Helfer (UI/Visual), **nie** für networked Typen.

**Konsequenz:** Eine „neue Ability" ist **keine** neue C#-Klasse. Sie entsteht durch **Konfiguration/Komposition der ~130 bereits existierenden `Ability`-Klassen** + eigene Hitbox-/VFX-/Status-**Daten/Prefabs**. Genauso ist der Char-Prefab-Root **kein** im Bundle selbst gebauter `NetworkIdentity` — der networked Root muss vom **echten Basis-Char-Prefab des Spiels** kommen.

## 3. Der korrekte Ansatz

**Ein Custom-Char = neuer `charId` + ein zur Laufzeit komponiertes, networked Prefab, das auf Server UND allen Clients IDENTISCH registriert ist und vom Server gespawnt wird.**

Aufbau des Prefabs (auf jedem Peer gleich, vor dem ersten Spawn):
1. **Networked Root vom Basis-Char klonen** (echtes `NetworkIdentity` + voller `Char*`-Komponenten-Graph: `EntityManager`, `CharNetwork`, `CharSimulation`, `CharAnimator`, `CharHurtbox`, `CharAbilities`, …).
2. **Visual-Subtree ersetzen** (Mesh/Material aus dem AssetBundle als Kind unter den Root; das Bundle liefert NUR das Visual, kein `NetworkIdentity`).
3. **Animator über `AnimatorOverrideController`** auf den Original-Controller legen → `CharAnimator`-State-Hashes (`Ability1`..`Ability4`, Locomotion) bleiben gültig, aber die **Clips** sind die des neuen Chars → **kein Standbild**.
4. **`Ability`-Komponenten neu konfigurieren/ersetzen**: pro Slot eine passende existierende `Ability`-Klasse mit eigenem `cmdId`, eigenem networked `spellPrefab` (Hitbox/Projectile), Damage, `statusEffects`, VFX. Keine Harmony-Fakes.
5. **Stabile `assetId` vergeben** (identisch auf allen Peers) und in `characterPrefabsByCharId[charId]` + `NetworkPrefabLibrary` (Server: `ServerCreate`; Client: `ClientCreate`/`RegisterPrefab`) eintragen.
6. **`CharacterConfiguration`-Row** (charId, `enabledInLobby`, Icons, Ability-Texte) in `UICharactersConfiguration` + `AvailableCharacterIds` ergänzen.
7. **Server spawnt** über den nativen Pfad (`SpawnPlayerChar`); FX/SFX strikt hinter `isClient`/`CanSpawnClientFx` (headless-Host bleibt renderer-frei).

**Das muss auf BEIDEN Seiten passieren** — der **dedizierte Server ist Pflicht** (er muss Prefab/`charId`/`assetId`/Pool/Abilities registriert haben und den Custom-Char spawnen). **Lokal-only kann prinzipiell nicht funktionieren.**

## 4. Rezept: neuen Charakter hinzufügen

1. AssetBundle bauen (Visual: Mesh, Material, Anim-Clips, `AnimatorOverrideController`-Quelle) — Tool existiert (`Build-CharBundle.ps1`).
2. JSON-Definition: `charId` (frei, >14), Name, `baseCharId` (welcher Basis-Prefab als networked Root), Visual-Prefab, `assetId`, Slot→Ability-Mapping (siehe §5).
3. Mod (Server + Client, dieselbe DLL) baut beim Laden das komponierte Prefab + registriert es identisch + ergänzt die UI-Row.
4. Server spawnt; alle sehen den Char.

## 5. Rezept: neue Ability bauen (ehrlich über die Grenze)

Eine Ability-Definition = { Slot (cmdId), **existierende `Ability`-Klasse** die die Mechanik liefert (z.B. `ArrowAbility` für Projektil, `KatanaMeleeAbility` für Nahkampf-Hitbox, `CatJumpAbility` für Dash/AoE), Hitbox-Prefab, Damage, Cooldown, `statusEffects` (StatusEffectSO-Index), VFX-Id, Anim-State }. „Neue" Abilities entstehen durch **Auswahl + Konfiguration** dieser Bausteine + eigene Prefabs/Daten.

- **Möglich (einfach, data-driven):** alles, dessen Mechanik in einer existierenden `Ability`-Klasse vorkommt (Projektile, Melee-Hitboxen, AoE, Dashes, Buffs, DoT/Status, Wände, Beschwörungen …). Das deckt sehr viel ab.
- **Grenze:** eine **völlig neue Mechanik**, die keine existierende Klasse hat, kann **nicht** als neuer networked Code injiziert werden — sie muss aus vorhandenen Bausteinen kombiniert oder durch die nächstliegende ersetzt werden. (Genuin neuer Ability-Code bräuchte einen modifizierten Game-Assembly-Build auf Server+Client — separates, größeres Projekt.)

## 6. Wie jeder alte Fehler dadurch gelöst wird

- Sichtbar für alle → Server spawnt das echte Prefab; `assetId` auf allen Peers registriert.
- Kein Despawn → korrekte SyncVar-Init (`charId`, `isPrimary=true`, `charInstanceId`, `entityTeamId`, `ownerPlayerId`), echte Mirror-Spawn-Registrierung, AOI-Mitgliedschaft.
- Keine Standbilder → `AnimatorOverrideController` (State-Hashes gültig) + networked `CharEvents`-Anim-Kanal treibt die States.
- Alle Abilities → echte `Ability`-Komponenten mit korrektem `cmdId`, eigenem networked `spellPrefab`, über die predicted Sim ausgeführt; Status via `[Server] ActivateStatusEffect` mit stabiler SO-Id.

## 7. Phasenplan (Meilensteine + Tests)

- **M0 – Server-Zugang:** Custom-Char nur möglich, wenn wir Server + Client mit derselben Mod ausstatten. Voraussetzung: Server-Deploy (AMP). **Blocker bis Login/Token vorhanden.**
- **M1 – Networked Bring-up (kein Visual/Ability):** Custom `charId` 15 als komponiertes Prefab (Basis-Root) auf Server+Client identisch registrieren, Server spawnt. **Test (2 Clients):** beide sehen die Entität, kein Despawn, läuft/bewegt sich.
- **M2 – Visual + Animation:** Visual-Subtree + `AnimatorOverrideController`. **Test:** anderer Client sieht das echte Modell + flüssige Animation (kein Standbild).
- **M3 – Eine echte Ability:** Slot 0 als echte konfigurierte `Ability` mit networked Hitbox. **Test:** anderer Client sieht Attack + Schaden serverseitig.
- **M4 – 4 Abilities + Status + VFX:** alle Slots, Status (poison/petrify als StatusEffectSO-Index), VFX über `CharEvents`/`vfxId`. **Test:** voller Kampf, alle Slots, alle sehen alles.
- **M5 – Data-Driven-Authoring:** JSON-Format + Mod-Engine, sodass neuer Char/neue Ability = nur Bundle + JSON. **Test:** 2. Char (z.B. Blitz) rein per Daten.
- **M6 – Lobby/UI + Bots:** `CharacterConfiguration`-Row, Icons, optional Bot-Prefab.

## 8. Ehrliche Risiken/Constraints

- **Server-seitiger Deploy ist zwingend** (sonst sehen andere nichts). Aktuell durch AMP-Login/v20 blockiert.
- **Keine beliebig neuen Ability-Mechaniken** ohne Game-Assembly-Build (IL2CPP). Wir arbeiten mit dem (großen) Baukasten existierender `Ability`-Klassen.
- **`assetId`- und Komponenten-Layout-Parität** zwischen allen Peers ist strikt (sonst Despawn/Desync).
- **Determinismus** in Ability-Ticks (Prediction/Resim) muss gewahrt bleiben.
- Custom-Chars funktionieren nur auf **unserem** Server (nicht auf offiziellen).
