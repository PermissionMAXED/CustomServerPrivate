# R01 — Character Definition & Roster

BAPBAP, Unity 2022.3.38f1, IL2CPP, Mirror networking.

Source of truth for this stage: the decompiled game C# under
`C:\Users\Administrator\Downloads\neueBapbap\GameCode\ExportedProject\_DisabledScripts\Assembly-CSharp\BAPBAP`
(referred to below as `…\BAPBAP\…`), plus the exported assets and the failed clone-based
mod under `BAPBAPModdingAPI\bapcustomchars-mod`.

> **Decompilation caveat (read first).** The `_DisabledScripts` tree is an ILSpy/AssetRipper
> export. **Field declarations, attributes, enum values, base classes and method signatures are
> real**, but **method bodies are stripped** (every method returns `null`/`0`/`false` or is empty).
> So I can state with certainty *what data defines a character and how it is wired structurally*,
> and I cite line numbers for fields. I infer runtime behaviour from signatures + attributes +
> the asset graph, and flag any such inference explicitly. The corresponding `.asset` for the
> character config is also empty in the export (see §7), so character *values* (per-char HP, etc.)
> are not recoverable from this dump — only the schema.

---

## 0. TL;DR for the synthesis stage

A "character" in BAPBAP is **not a single class or a single data row**. It is split across two
parallel, charId-keyed systems:

1. **Gameplay actor = a networked prefab.** `GameNetworkManager.characterPrefabsByCharId[charId]`
   is a serialized `GameObject[]` indexed directly by `charId`. Each element is a Mirror
   `NetworkIdentity` prefab built by *composition* of ~30 `Char*` components hubbed by
   `EntityManager`. HP lives on `CharHurtbox.baseHp`; offensive stats on `CharAbilities`; movement
   on `EntityMovement`; **abilities are literal `Ability` NetworkBehaviour components placed on the
   prefab**, collected into `CharAbilities.abilities` and dispatched by `Ability.cmdId`
   (LMB/Q/Space/E…). There is **no ability database keyed by charId** — abilities are prefab
   composition.

2. **Presentation/metadata = a ScriptableObject row.**
   `UICharactersConfiguration._characters[]` (`CharacterConfiguration`, keyed by `charId`) holds
   the display name, localization keys, lobby sprites, accent colors, default skin and the *UI*
   ability icon/title/description text. It does **not** carry gameplay numbers.

`charId` is the single integer that ties these together. It is a Mirror **`[SyncVar] int charId`
on `EntityManager`** (so the server tells every client which character an entity is), and it is the
**array index** into `characterPrefabsByCharId`, `charBotPrefabsByCharId`, and the UI lookups.

The shipped roster is **15 characters, charId `0…14`** (confirmed by named id constants in
`GameNetworkManager` and the CustomServer default `AvailableCharacterIds = 0..14`). Named ids:
Kitsu=0, Anna=1, Zook=5, Teevee=8, Spriest=11, Eve=12; the rest are unnamed indices.

**Why a new charId is hard but possible:** adding charId 15 requires the *same* prefab to exist,
with the *same* Mirror `assetId`, in the spawnable-prefab registry **on the dedicated server and on
every client**, plus a matching `characterPrefabsByCharId[15]` entry and a UI
`CharacterConfiguration` row. The failed Medusa mod only grafted things **client-side**, which is
structurally why it was invisible to others, despawned, and froze — see §8.

---

## 1. The two-layer character model

| Layer | Type | File | Keyed by | Carries |
|---|---|---|---|---|
| Gameplay actor | `GameObject` prefab (NetworkIdentity) | registered in `GameNetworkManager` | array index = `charId` | EntityManager + all `Char*` components + `Ability[]`; HP, stats, abilities, animator, model |
| Presentation | `UICharactersConfiguration.CharacterConfiguration` (ScriptableObject row) | field `charId` | UI lookup | display/localized name, sprites, colors, default skin, ability icon/text |
| Per-entity runtime | `EntityManager` (on the prefab) | `[SyncVar] int charId` | — | the live, networked identity of a spawned actor |
| Economy/unlock | `CharListingResponse` / `CharacterPageModel` | field `charId` | server JSON | unlock cost, level req, rotation, owned set |

---

## 2. Gameplay roster: `GameNetworkManager`

File: `…\BAPBAP\Network\GameNetworkManager.cs` (class `GameNetworkManager : NetworkManager`).

### 2.1 charId constants (named subset)
```csharp
public const int KitsuCharId   = 0;   // line 233
public const int AnnaCharId    = 1;   // line 235
public const int ZookCharId    = 5;   // line 237
public const int TeeveeCharId  = 8;   // line 239
public const int SpriestCharId = 11;  // line 241
public const int EveCharId     = 12;  // line 243
```
Only six ids are named as constants; the remaining slots (2,3,4,6,7,9,10,13,14) exist as array
indices without a named constant. The highest named id is 12 (Eve); with the CustomServer default
roster `0..14` this gives **15 characters**.

### 2.2 The prefab roster (the canonical charId → prefab map)
```csharp
[Header("Game Config")]
[SerializeField] public string[] names;                           // line ~299 (player display names pool, NOT characters)
[SerializeField] public NetworkPrefabLibrary networkPrefabLibrary; // line 301
[SerializeField] public GameObject[] characterPrefabsByCharId;     // line 304  <-- charId → prefab
[SerializeField] public CharacterBotPrefabs[] charBotPrefabsByCharId; // line 307 charId → bot prefabs
```
- `characterPrefabsByCharId[charId]` is the authoritative **charId → character prefab** mapping.
  The index *is* the charId. The server instantiates/spawns this prefab for a player who picked
  that charId.
- `networkPrefabLibrary` (`BAPBAP.Pooling.NetworkPrefabLibrary`) is the Mirror spawnable-prefab
  registry/pool. For a prefab to be spawnable across the network it must be registered here (and in
  Mirror's `NetworkManager` spawn list) with a stable `assetId` shared by server + clients.

### 2.3 Bot prefabs (per difficulty, per charId)
```csharp
[Serializable] public class CharacterBotPrefabs   // line 21
{
    public GameObject charBotEasy;     // 23
    public GameObject charBotMedium;   // 25
    public GameObject charBotHard;     // 27
    public GameObject charBotExpert;   // 29
    public GameObject GetBotPrefab(BotDifficulty botDifficulty); // 31
}
public GameObject GetCharacterBotPrefab(int charId, BotDifficulty botDifficulty); // line 374
```
So bots resolve as `charBotPrefabsByCharId[charId].GetBotPrefab(difficulty)`. A complete new
character that should also be playable as a bot needs four bot prefab variants too (or this array
must be made tolerant of missing entries).

---

## 3. The character prefab is composed, not subclassed: `EntityManager`

File: `…\BAPBAP\Entities\EntityManager.cs` (class `EntityManager : NetworkBehaviour`).

`EntityManager` is the per-actor hub. It holds `[NonSerialized]` references to every sibling
component and the networked identity fields. There is no `Character` class — the "character" is the
GameObject carrying `EntityManager` + the components below.

### 3.1 Entity type + networked identity
```csharp
public enum EntityType { Char = 0, Npc = 1, Loot = 2, Interactable = 3 }  // lines 14-21
...
[SerializeField] public EntityType entityType;     // ~line 175
[NonSerialized][SyncVar] public string customEntityName;  // ~193
[NonSerialized][SyncVar] public bool isPrimary;
[NonSerialized][SyncVar(hook="OnPlayerObjChanged")] public GameObject playerObj;
[NonSerialized][SyncVar] public int charId;        // line 207  <-- networked charId
[NonSerialized][SyncVar] public int charInstanceId;// line 211
[NonSerialized] public int ownerPlayerId;          // 214
[SerializeField][SyncVar(hook="OnEntityTeamIdChanged")] public int entityTeamId; // 221
[NonSerialized][SyncVar] public int botPlayerId;   // 225
public PrefabConfig prefabConfig;                  // line 139
```
**Key fact for networking:** `charId` is a Mirror `[SyncVar]`. The server sets it on the spawned
prefab and Mirror replicates it to all clients (`NetworkcharId` is the generated accessor at line
310). This is the supported channel by which "which character is this" is made known to every
player — a custom char must flow through this same SyncVar + a prefab the clients can spawn.

### 3.2 Component composition (the anatomy of a character)
`EntityManager` references (each is a separate component on the prefab), incl.:
`CharNetwork, CharEvents, CharSimulation, EntityMovement (charMove), CharAim, CharHurtbox,
CharTriggerbox, CharAbilities, CharItems, CharPassives, CharStatusEffects, CharHpRegen,
CharDestroyTimer, NpcBehaviour, TargetDetection, CharEmotes, CharInteract, CharLabelNear,
CharDowned, CharHpBar, CharModelSwap, CharAnimator (charAnim), CharMaterial, CharFX, CharHidden,
CharHideArea, CharWorldPosition, CharBushInteract, CharMinimap, CharMoveAudio, CharFogOfWar,
CharFootsteps, CharInterpolator, CharVoicelines` (EntityManager.cs lines ~25-130).

Implication: a new character prefab must reproduce this component set (most are charId-agnostic and
can be copied from a base char). The charId-specific differences are: the model/visual
(`CharModelSwap`, `CharAnimator`/AnimatorController, `CharMaterial`), the HP (`CharHurtbox.baseHp`),
the offensive stats (`CharAbilities`), the movement (`EntityMovement`), and the **set of `Ability`
components** present on the prefab.

---

## 4. What numbers define a character (stats)

### 4.1 HP & survivability — `CharHurtbox`
File: `…\BAPBAP\Entities\CharHurtbox.cs` (`CharHurtbox : NetworkBehaviour, INetworkPredicted`).
Serialized config (set per prefab):
```csharp
[Header("Configs")][Min(0)][SerializeField] public int baseHp;   // base health
[SerializeField] public bool onlyTake1Damage, nonDamagable, ignoredByTargeting, min1Hp;
[SerializeField] public float damageTakenFromNpcsMultiplier, zoneDamageMultiplier;
[SerializeField] public float outOfCombatDuration, inPlayerCombatDuration, lastPlayersHitDuration;
[Header("Effects")][Range(0,1)] public float hpDangerEffectPercentage, maxCamShakeTraumaHpPerc;
[SerializeField] public bool showKillPopup, showDmgPoints;
```
Runtime (NonSerialized): `int maxHp, hp, maxShield, shield;` with `MaxHp`/`Hp` properties and
server setters `SvSetMaxHp(int)`, `SvSetHp(int)`, `SvSetShield(int)` plus `ApplyHit(...)`,
`Kill(...)`. So **per-character HP = `CharHurtbox.baseHp` on the prefab**; it is authoritative on
the server and replicated.

### 4.2 Offensive/ability stats — `CharAbilities`
File: `…\BAPBAP\Entities\CharAbilities.cs` (`CharAbilities : NetworkBehaviour, INetworkPredicted`).
```csharp
public const int CONSTANT_ITEM_OFFSET = 4;          // ability slots 0-3 are char abilities; 4+ are item/consumable slots
[NonSerialized] public Ability[] abilities;          // the character's abilities (collected from prefab components)
[NonSerialized] public Ability[] abilitiesByPriority;
[NonSerialized] public Ability[] abilitiesWithAutoCancel;
[SerializeField] public Transform[] attachables;
[Header("Stats")][SerializeField] public float baseCritDmg, baseCritChance, baseLifeSteal;
[Header("Caps")][SerializeField] public float maxAttackSpeed;
```
`CONSTANT_ITEM_OFFSET = 4` confirms the **4 native ability slots** convention (LMB, Q, Space, E),
with item/consumable abilities living at slot index ≥ 4.

### 4.3 Movement — `EntityMovement`
File: `…\BAPBAP\Entities\EntityMovement.cs`. Serialized speeds incl.
`moveAccel, moveDecel, baseRunSpeed, baseWalkSpeed, constantWalkSpeed, constantGhostSpeed,
maxRunSpeed, maxOutOfCombatRunSpeed, slipperyAccel/Decel/Speed/MaxSpeed, …` (lines 38-113). So
movement feel is per-prefab here.

### 4.4 Summary: fields that define a character

| Field / data | Where | Notes |
|---|---|---|
| `charId` | `EntityManager.charId` (`[SyncVar]`) line 207; array index in `GameNetworkManager` | the identity integer |
| prefab reference | `GameNetworkManager.characterPrefabsByCharId[charId]` line 304 | the spawnable actor |
| bot prefabs | `GameNetworkManager.charBotPrefabsByCharId[charId]` line 307 | 4 difficulties |
| base HP | `CharHurtbox.baseHp` | + shield/dmg modifiers |
| crit / lifesteal / atk-speed cap | `CharAbilities.baseCritDmg/baseCritChance/baseLifeSteal/maxAttackSpeed` | offensive base stats |
| movement speeds | `EntityMovement.baseRunSpeed/baseWalkSpeed/…` | feel |
| abilities (gameplay) | `Ability` components on prefab → `CharAbilities.abilities`, keyed by `Ability.cmdId` | see §5 |
| visual model / anim | `CharModelSwap`, `CharAnimator` (+AnimatorController/Avatar), `CharMaterial` | per-char art |
| default skin | `UICharactersConfiguration.CharacterConfiguration.DefaultSkin` (`SkinSO`) | art only |
| display name / loc keys | `UICharactersConfiguration.CharacterConfiguration.name`, `descriptionTranslationKey` | UI only |
| ability UI (icon/title/desc) | `CharacterConfiguration.ability1..ability4` (`AbilityData`) | UI only |
| lobby visibility | `CharacterConfiguration.enabledInLobby` / `enabledInDevLobby` | gating |
| unlock economy | `CharListingResponse.CharListing` / `CharacterPageModel` | cost/level/rotation |

---

## 5. How charId maps to abilities (and the input slots)

There is **no `charId → ability` table**. The mapping is *physical prefab composition*:

1. `charId` → prefab (`characterPrefabsByCharId[charId]`).
2. That prefab carries one or more `Ability` components.
3. `CharAbilities` (on the same prefab) gathers them into `Ability[] abilities`
   (`CharAbilities.SortAbilitiesByPriority()`, `SortAbilitiesAutoCancel()`).
4. Each ability declares which input slot it answers to via `Ability.cmdId`.

### 5.1 `Ability` base — `…\BAPBAP\Entities\Ability.cs` (`Ability : NetworkBehaviour`)
```csharp
[Header("General")]
[Tooltip("Which command will this ability be casted with? (LMB = Ability1, Q = Ability2, Space = Ability3, E = Ability4)")]
[SerializeField] public CommandId cmdId;
[SerializeField] public bool useCustomUIData;
[ConditionalHide("useCustomUIData",true)][SerializeField]
public UICharactersConfiguration.CharacterConfiguration.AbilityData customUIData;  // per-ability UI override
[SerializeField] public Color customUIIconColor, customUITitleColor;
[Header("Mechanics")]
[SerializeField] public bool autoCancel;
[SerializeField] public int priority;          // input-buffer priority 1..4
[SerializeField] public float inputBufferDuration, canceledTime, maxTimeDilation;
[SerializeField] public bool silenceable, cancelable, usableOnDowned, enableCritDmg;
// virtual lifecycle (bodies stripped): PreAwake/Start/Tick(fixedDt,cmd,isResim)/ForceInterrupt/...
// server combat hooks: [Server] OnTargetHit / OnTargetKill / OnWallHit / OnOtherHitboxHit / OnHitboxDestroy
// net (de)serialize: OnNetSerialize / OnNetDeserialize (prediction state)
```
Each concrete ability is a subclass of `Ability` (e.g. `ShotgunAbility`, `ChargeImpulseAbility`,
`RockyPunchAbility`, `FireMeteoriteAbility`, `ChargedArrowsAbility`, `HeavyDigitalBeamAbility`, …
all under `…\BAPBAP\Entities\`). Because `Ability : NetworkBehaviour` with `Tick(... isResim)` and
`OnNetSerialize/Deserialize`, abilities are **server-authoritative and client-predicted** — the
correct way to add a custom ability is a real `Ability` NetworkBehaviour on the networked prefab,
not a client-side input hook.

### 5.2 Input slot enum — `…\BAPBAP\Local\CommandId.cs`
```csharp
public enum CommandId {
  Ability1=0, Ability2=1, Ability3=2, Ability4=3,   // LMB, Q, Space, E
  Ability5=4, Ability6=5, Ability7=6, Ability8=7,
  CancelAbility=8, AbilityHeal=9,
  Drop1=10, Drop2=11, Drop3=12, Drop4=13,
  DropConsumable1=14, DropConsumable2=15, DropConsumable3=16,
  DropGold=17, DropAbility=18, Interact=19,
  VehicleDrift=20, VehicleTurbo=21
}
```
So the 4 main slots map LMB→`Ability1(0)`, Q→`Ability2(1)`, Space→`Ability3(2)`, E→`Ability4(3)`;
matches `CharAbilities.CONSTANT_ITEM_OFFSET = 4`.

> Relevance to the failed mod's symptoms ("only LMB worked, RMB green dot, Space bugged, E played
> Kitsu's anim"): if a clone keeps Kitsu's `Ability` components but only intercepts one input
> client-side, the other slots still run the base char's abilities/animations — exactly the
> observed behaviour. The fix is to put real `Ability` components for each `cmdId` on the prefab.

### 5.3 UI ability metadata — `UICharactersConfiguration.CharacterConfiguration`
The *visual* ability data (icon + localization keys) is separate from the gameplay ability:
```csharp
public const int mainAbilityNum = 4;
[Serializable] public struct AbilityData {
    [SpriteVisualizer] public Sprite icon;
    [Header("Localization Keys")] public string titleKey, shortDescriptionKey, descriptionKey;
}
public AbilityData ability1, ability2, ability3, ability4;          // one per main slot
public AbilityData GetAbilityData(int abilityIndex);
```
An ability can either pull UI from here (by slot) or override with `Ability.useCustomUIData +
customUIData`.

---

## 6. Presentation roster: `UICharactersConfiguration`

File: `…\BAPBAP\UI\UICharactersConfiguration.cs`
(`[CreateAssetMenu(menuName="BAPBAP/Configuration/UI/CharactersConfiguration")] : ScriptableObject`).

### 6.1 The row type `CharacterConfiguration`
```csharp
[TextArea] public string name;                       // internal/roster name (e.g. "Kitsu")
[TextArea] public string descriptionTranslationKey;
public CharacterDetailedInfo detailedInfo;           // VoiceActorName, LorePassageKey
public int charId;                                   // ties to the prefab roster
public bool enabledInLobby;                          // shown in normal lobby?
public bool enabledInDevLobby;                        // shown in dev lobby?
[Header("Sprites")] public Color Color, UIAccentColor;
public Sprite LobbyBackground, FullSprite, MediumSprite, StandingSprite, IconSprite,
              smallSprite, CircleIcon, SquareIcon, SquareSmallIcon;
public SpriteTransformModifier gameStatsLobbySpriteModifier;
public SkinSO DefaultSkin;                           // default skin asset
[Header("Abilities Color")] public Color abilityIconColor, abilityBGColor, titleTextColor;
[Header("Abilities Data")] public AbilityData ability1, ability2, ability3, ability4;
```

### 6.2 The container + lookups
```csharp
[SerializeField] public CharacterConfiguration[] _characters;        // full roster
[NonSerialized] public CharacterConfiguration[] _lobbyCharacters;     // filtered (enabledInLobby)
[SerializeField][HideInInspector] public int[] _lobbyAvailableCharacterIds;
public CharacterConfiguration[] Characters { get; }
public CharacterConfiguration[] LobbyCharacters { get; }
public int[] AvailableCharacterIds { get; }
public bool TryGetCharConfigByCharId(int charId, out CharacterConfiguration config);
public bool TryGetLobbyCharConfigByIndex(int charIndex, out CharacterConfiguration config);
public int GetLobbyCharIndexFromCharId(int charId);
public void UpdateAvailableCharacterList(int[] newCharacters);
```
The lobby/select UI resolves characters through `LobbyCharacters` / `AvailableCharacterIds` and
`TryGetCharConfigByCharId` / `GetLobbyCharIndexFromCharId`. (Per the CustomServer README, an
unhandled `UILobbyCharacterSelectPage.GetCharacterListingIndexFromCharId` `NullReferenceException`
is logged when a charId isn't found in the listing — a concrete example of UI code assuming every
selectable charId has a config/listing row. A new charId must be present in *all* of these or the
select page throws.)

---

## 7. The exported config asset is empty (data values not recoverable here)

`…\Assets\MonoBehaviour\UICharactersConfiguration.asset` contains only the YAML header + script
reference (`guid: 83717a04a098e02f51b833ce3818c19f`) and **no serialized `_characters` array**
(13 lines total, no `charId:`/`name:` entries). This is the usual AssetRipper result for IL2CPP
+ SaintsField custom serialization: the schema (the C# class) is intact but the per-character
*values* (HP numbers, which abilities, sprite refs) were not rehydrated into the export. The same
applies to the `GameNetworkManager` prefab's `characterPrefabsByCharId` contents.

**Consequence for later stages:** exact per-character HP/stat values and the concrete `Ability`
component layout per shipped char must be read at runtime from the live game (IL2CPP) — e.g. via
the mod API reflecting `GameNetworkManager.Instance.characterPrefabsByCharId` and each prefab's
`CharHurtbox.baseHp` / `CharAbilities.abilities` — not from this static dump.

---

## 8. The shipped roster: count & indexing

- Indexing is **positional**: `charId` is the array index into `characterPrefabsByCharId`,
  `charBotPrefabsByCharId`, and (logically) the UI `_characters`/`AvailableCharacterIds`.
- Count = **15** (charId `0..14`). Evidence: named id constants up to Eve=12 in `GameNetworkManager`
  (§2.1), and the CustomServer config default documented in the project README
  ("`Available Character IDs` … Defaults to `0,1,2,3,4,5,6,7,8,9,10,11,12,13,14` (all 15 chars)").
- Server-side selectability/economy is expressed separately and also by charId:
  - `CharListingResponse.CharListing { string listingId; int levelRequirement; Asset[] costs;
    Asset[] rewards; int charId; int purchases; }`
    (`…\BAPBAP\Network\CharListingResponse.cs`).
  - `CharacterPageModel { CharListings charListings; int[] availableCharacters;
    int[] charIdsInRotation; HashSet<int> unlockedCharacters; … }`
    (`…\BAPBAP\UI\CharacterPageModel.cs`).
  These drive which charIds are owned/buyable/rotating; for a private custom server these are the
  knobs to force a new charId "unlocked/available".

---

## 9. Can the roster be extended with a new charId? (limits & assumptions)

**Yes, but it is a multi-point, both-sides change — not a client graft.** To make charId 15 a
real, networked character, all of the following must line up identically on the **dedicated server
and every client**:

1. **A spawnable prefab with a fixed Mirror `assetId`.** The character prefab is a
   `NetworkIdentity` registered in Mirror's spawnable prefab set (`NetworkManager.spawnPrefabs` /
   `GameNetworkManager.networkPrefabLibrary`). Server and clients resolve a spawn by `assetId`; if
   a client doesn't have a prefab with that `assetId` registered, it cannot spawn/visualize the
   actor at all. This is the crux of why a client-only clone is invisible to others.
2. **`characterPrefabsByCharId` must contain the prefab at index 15** (array grown) so the server
   knows which prefab to spawn for that charId. (And `charBotPrefabsByCharId[15]` if bots are
   wanted.)
3. **A `UICharactersConfiguration.CharacterConfiguration` row with `charId = 15`,
   `enabledInLobby = true`,** added to `_characters` and to `AvailableCharacterIds` — otherwise
   `TryGetCharConfigByCharId`/`GetLobbyCharIndexFromCharId` fail and the select UI NRE's (§6.2).
4. **Server roster/unlock data** (`availableCharacters` / `charIdsInRotation` /
   `unlockedCharacters` / char listings) must include 15 so it is selectable and considered owned.
5. The prefab itself must be a complete character: `EntityManager` + the full `Char*` component
   set (§3.2), a valid `CharHurtbox.baseHp`, `CharAbilities` with the desired `Ability` components
   (one per `cmdId` slot, §5), a model/animator, and a `PrefabConfig`.

**UI assumptions / limits to respect:**
- The select page assumes every selectable `charId` resolves to a `CharacterConfiguration` *and* a
  char listing; missing rows throw (NRE noted in README).
- `CharAbilities.CONSTANT_ITEM_OFFSET = 4` and `CharacterConfiguration.mainAbilityNum = 4` bake in
  the **4 main ability slots** assumption; a custom char should provide exactly 4 main abilities
  mapped to `Ability1..Ability4`.
- charId is positional. Reusing/duplicating an existing index, or a sparse/oversized array that
  isn't matched on all peers, breaks spawning. The safest scheme is: pick the next free contiguous
  index (15) and apply it everywhere.
- No hard upper bound on charId was found in code (it's an `int`), but `[SyncVar] int charId` plus
  array-index lookups mean the only real "limit" is that **all peers must agree** on the
  charId→prefab/assetId/config mapping.

---

## 10. Why the previous clone-based approach failed (grounding for synthesis)

Failed framework: `BAPBAPModdingAPI\bapcustomchars-mod\CustomCharFramework.cs` +
`MedusaMod.cs` (MelonLoader + HarmonyX, IL2CPP via Il2CppInterop).

- `CustomCharDefinition` registers Medusa as **`CharId = 15`, cloned from `BaseCharId = 0` (Kitsu)**,
  loading a visual from an **AssetBundle** (`medusa.bundle`, `VisualPrefabName="Medusa_Visual"`),
  with a hand-picked **Mirror `assetId = 0x4D454455 (1296385109)`**, and grafting 4 poison hitbox
  prefabs onto ability slots 0..3 plus status-on-hit (`poison`,`petrify`).
- `MedusaMod` is almost entirely **Harmony patches on UI/lobby methods** (e.g.
  `UILobbyCharacterSelectPage.Build/Initialise/UpdateData/UpdateAvailableCharactersData`) that
  force the char into the *local* lobby/select UI and force it "unlocked" locally.

Structural reasons this produces exactly the reported symptoms:
- **Not visible to others / only local:** the clone's prefab + `assetId` and the charId→prefab
  mapping exist only in the modded *client's* process. Other clients (and the authoritative server,
  unless modded identically) have no prefab for that `assetId` and no `characterPrefabsByCharId[15]`,
  so they can't spawn or render it — visuals/attacks appear only locally. The supported path
  (`EntityManager.[SyncVar] charId` + a server-spawned, commonly-registered NetworkIdentity prefab)
  was bypassed.
- **Despawns:** an object the server didn't authoritatively spawn (or can't reconcile) gets
  destroyed by Mirror's spawn/visibility handling.
- **Frozen poses (Standbilder):** the grafted visual lacks a properly driven `CharAnimator`/server-
  replicated animation state; with no networked simulation behind it, it can't animate.
- **Abilities broken (only LMB; RMB green dot; Space bug; E plays Kitsu's anim):** the clone still
  carries Kitsu's `Ability` components for the other `cmdId` slots while only one slot is grafted
  client-side, so the untouched slots run the base char (Kitsu) logic/animations. Real abilities
  must be `Ability` NetworkBehaviours on the networked prefab, one per `cmdId` (§5).

**R01 conclusion feeding synthesis:** the correct, extensible design must treat a character as
*(a)* a fully-formed, server-authoritative Mirror NetworkIdentity prefab registered with a stable
`assetId` on **both** server and clients, *(b)* slotted into `characterPrefabsByCharId[charId]` and
the Mirror spawnable set, *(c)* mirrored by a `UICharactersConfiguration.CharacterConfiguration`
row + server roster/unlock entries for the same `charId`, with *(d)* its abilities authored as real
`Ability` NetworkBehaviours mapped to `CommandId.Ability1..Ability4`. Anything client-only is
structurally incapable of being networked.

---

## 11. Primary file references

| Concern | File |
|---|---|
| charId constants, prefab roster, bot prefabs, NetworkPrefabLibrary | `…\BAPBAP\Network\GameNetworkManager.cs` |
| per-actor hub, `[SyncVar] charId`, component composition, EntityType | `…\BAPBAP\Entities\EntityManager.cs` |
| base HP / damage / shield / kill | `…\BAPBAP\Entities\CharHurtbox.cs` |
| ability list + offensive base stats + slot offset | `…\BAPBAP\Entities\CharAbilities.cs` |
| ability base class (cmdId, mechanics, net (de)serialize, server hooks) | `…\BAPBAP\Entities\Ability.cs` |
| input/ability slot enum | `…\BAPBAP\Local\CommandId.cs` |
| movement speeds | `…\BAPBAP\Entities\EntityMovement.cs` |
| presentation roster + lookups (name, sprites, ability UI, default skin) | `…\BAPBAP\UI\UICharactersConfiguration.cs` |
| (empty) config asset | `…\Assets\MonoBehaviour\UICharactersConfiguration.asset` |
| server unlock/economy roster | `…\BAPBAP\Network\CharListingResponse.cs`, `…\BAPBAP\UI\CharacterPageModel.cs` |
| lobby select page (roster UI assumptions) | `…\BAPBAP\UI\UILobbyCharacterSelectPage.cs` |
| failed clone framework (for contrast) | `BAPBAPModdingAPI\bapcustomchars-mod\CustomCharFramework.cs`, `MedusaMod.cs` |
