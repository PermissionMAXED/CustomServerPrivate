# BAPBAP — Characters & Skins (Systems-Level Reverse-Engineering)

> Subsystem: **Characters / Skins**.
> Sources: `reverse-engineering/dumps/il2cppdumper/dump.cs` (canonical, with RVAs/offsets/SyncVar attributes) and the IL2Cpp-decompiled C# under `reverse-engineering/decompiled/Assembly-CSharp/Il2CppBAPBAP/`.
> All RVAs are taken from the dumped `GameAssembly.dll` and are stable for the dumped build (gg.bapbap, dev branch ~0.1.1758-38212).
> Goal: document *exactly* how a modder can ship a custom skin (achievable, client-side) and how far one can push a custom character (mostly blocked by server authority — explained below).

---

## 1. Class Map

| Type | TypeDefIndex | Namespace | Role |
| --- | --- | --- | --- |
| `UICharactersConfiguration` | 4006 | `BAPBAP.UI` | `ScriptableObject`. The character roster asset. Holds `_characters[]`, `_lobbyCharacters[]`, `_lobbyAvailableCharacterIds[]`. Lookup by charId via `TryGetCharConfigByCharId`. |
| `UICharactersConfiguration.CharacterConfiguration` | 4001 | nested | The per-character data row: `name`, `charId`, sprites, `Color`, `UIAccentColor`, **`SkinSO DefaultSkin`**, four `AbilityData` entries. |
| `UICharactersConfiguration.CharacterConfiguration.AbilityData` | 4000 | nested | UI-level ability metadata: `Sprite icon`, `string titleKey`, `shortDescriptionKey`, `descriptionKey` (localisation keys, NOT the ability behaviour). |
| `UICharactersConfiguration.SpriteTransformModifier` | 4002 | nested | `Vector2 anchoredPos`, `float scale` for sprite layout per-character. |
| `UICharactersConfiguration.CharIdWrapper` | 3999 | global | Inspector helper struct (`int charId`) with `GetCharsDropdown()`. Only used by editor tooling. |
| `Skin` | 6144 | `BAPBAP.Content` | `Content` subclass: `customDisplayScale`, `isVaulted`, `Rarity rarity`, `GameObject visualizerPrefab`, **`Skin.SkinConfig config`**. |
| `Skin.SkinConfig` | 6143 | nested | The critical map: **`int charId`** + **`GameObject characterPrefab`** — the actual networked character prefab to spawn for this skin. |
| `SkinSO` | 6146 | `BAPBAP.Content` | `ContentSO` wrapper around a `Skin` (`[CreateAssetMenu]`-friendly). |
| `SkinData` | 6145 | `BAPBAP.Content` | `ScriptableObject` registry: `SkinSO[] skins`, `assetSkinOffset = 300000`. APIs: `GetSkinBySkinId(int)`, `GetSkinByAssetId(int)`, `GetSkinIdBySkinAssetId(int)`, `GetSkinAssetIdBySkin(Skin)`. |
| `Content` | 6116 | `BAPBAP.Content` | Abstract base: `int contentId`, `string contentName`, sprites, `Rarity`, etc. Items, skins, tombstones, emotes all derive from this. |
| `ContentSO` | 6117 | `BAPBAP.Content` | `ScriptableObject` wrapper with `Content content`. |
| `ContentManager` | 6447 | `BAPBAP.Local` | The runtime hub. Holds `SkinData skinData`, `TombstoneData`, `EmoteData`, etc. `assetOffsetSize = 100000`. Static helpers `GetContentFromAssetId(int)`, `GetAssetIdFromContent(Content)`. |
| `AssetContainer<T>` | 6153 | `BAPBAP.AssetContainer` | Generic editor-time `ScriptableObject` container of imported assets (`MeshAssetContainer`, `TextureAssetContainer`). NOT a runtime registry; a build-time pipeline. |
| `PlayerManager` | 3074 | `BAPBAP.Player` | `NetworkBehaviour`. The player avatar. Carries the `[SyncVar] charId`, the (NON-SyncVar) `skinAssetId`, and references the spawned `EntityManager`. |
| `PlayerDeveloperLobby` | 3070 | `BAPBAP.Player` | `NetworkBehaviour`. Pre-match lobby selection: `[SyncVar(hook="OnLobbyCharIdChanged")] lobbyCharId`, `CmdSelectCharacter(int)`. |
| `PlayerDebug` | 3067 | `BAPBAP.Player` | `NetworkBehaviour`. Mid-match dev-only switching: `CmdSwitchCharacter(int)`, `[Server] SwitchCharacter(int charToSwitchId, int skinAssetId = -1)`, `CmdSetSelectedSkinId(int)`. |
| `GameNetworkManager` | 3100 | `BAPBAP.Network` | `Mirror.NetworkManager`. Holds the master prefab table **`GameObject[] characterPrefabsByCharId`** and `CharacterBotPrefabs[] charBotPrefabsByCharId`. Owns `NetworkPrefabLibrary`. |
| `NetworkPrefabLibrary` | 3060 | `BAPBAP.Pooling` | `ScriptableObject`: `GameObject[] InstantiatedPrefabs`, `NetworkPrefabPool.Config[] PooledPrefabs` — the universe of net-spawnable prefabs (must match server). |
| `NetworkPrefabPool` | 3064 | `BAPBAP.Pooling` | Static dictionary-based pool. `ServerCreate(Config)`, `ClientCreate(Config)`, `Spawn(prefab, pos, rot)`, `Despawn(go)`. Mirror swaps `SpawnHandler` so `NetworkServer.Spawn` instantiates from the pool. |
| `EntityManager` | 6012 | `BAPBAP.Entities` | `NetworkBehaviour`. Per-character runtime aggregate. Holds `CharNetwork`, `CharSimulation`, `EntityMovement`, `CharAim`, `CharHurtbox`, `CharAbilities`, `CharItems`, `CharPassives`, `CharStatusEffects`, `CharModelSwap`, `CharAnimator`, `CharMaterial`, etc. Has its own `[SyncVar] int charId` (0x118) AND `[SyncVar] GameObject playerObj` back-reference (0x114). |
| `CharAbilities` | 5043 | `BAPBAP.Entities` | `NetworkBehaviour, INetworkPredicted`. Holds **`Ability[] abilities`** (0x6C) — **indexed by `CommandId` 0..3 for the four player ability slots**. |
| `Ability` | (subclasses in `Il2CppBAPBAP.Entities.*Ability.cs`) | `BAPBAP.Entities` | Base type for ability behaviours. Each character has 4 concrete `Ability` MonoBehaviours on its prefab, configured by id. |
| `CharModelSwap` | 5066 | `BAPBAP.Entities` | `NetworkBehaviour, INetworkPredicted`. Server-driven *cosmetic* model swap: replaces visual model under `modelSwapContainer` with one keyed by `currentModelSwapId` (e.g. cat polymorph). |
| `CharMaterial` | 5750 | `BAPBAP.Entities` | `MonoBehaviour`. `charRenderer`, `extraRenderers`, runtime material wrappers (`MaterialWrapper`). Tinting, hit flash, base color, hidden state. The right hook for material/texture-only skin replacement. |
| `CharAnimator` | 5727 | `BAPBAP.Entities` | `MonoBehaviour`. Animator wrapping & param hashes. |
| `CommandId` | 6416 | `BAPBAP.Local` | enum. **`Ability1=0, Ability2=1, Ability3=2, Ability4=3`**, plus consumables/drops up to 21. **Note: this is 0-indexed — the existing `docs/CHARACTERS.md` claim that `Ability1=1` is incorrect; it should be 0.** |

> **Where the canonical asset lives.** `UICharactersConfiguration` is a `[CreateAssetMenu(fileName = "UICharactersConfiguration", menuName = "BAPBAP/Configuration/UI/CharactersConfiguration")]` ScriptableObject baked into `sharedassets0.assets`. `SkinData` and `ContentManager` are similarly baked. They are NOT loaded from disk at runtime — they live in the build.

---

## 2. How a Character is DEFINED

### 2.1 `UICharactersConfiguration.CharacterConfiguration` (TypeDefIndex 4001)

Field layout (offsets in bytes from object base; from `dump.cs` lines ~147457):

```csharp
public const int mainAbilityNum = 4;                // static - exactly 4 ability slots
[TextArea] public string name;                      // 0x08  - internal/display name
[TextArea] public string descriptionTranslationKey; // 0x0C  - localisation key
public int charId;                                  // 0x10  - the canonical id
public bool enabledInLobby;                         // 0x14
public bool enabledInDevLobby;                      // 0x15
public Color Color;                                 // 0x18  (16 bytes)
public Color UIAccentColor;                         // 0x28
public Sprite smallSprite;                          // 0x38
public Sprite IconSprite;                           // 0x3C
public Sprite LobbyBackground;                      // 0x40
public Sprite FullSprite;                           // 0x44
public Sprite StandingSprite;                       // 0x48
public Sprite CircleIcon;                           // 0x4C
public Sprite SquareIcon;                           // 0x50
public Sprite SquareSmallIcon;                      // 0x54
public UICharactersConfiguration.SpriteTransformModifier gameStatsLobbySpriteModifier; // 0x58
public SkinSO DefaultSkin;                          // 0x5C  ← THE link to the spawnable prefab
public Color abilityIconColor;                      // 0x60
public Color abilityBGColor;                        // 0x70
public Color titleTextColor;                        // 0x80
public AbilityData ability1;                        // 0x90  - LMB UI metadata
public AbilityData ability2;                        // 0xA0  - Q   UI metadata
public AbilityData ability3;                        // 0xB0  - SPACE UI metadata
public AbilityData ability4;                        // 0xC0  - E   UI metadata

// RVA: 0x419A10
public AbilityData GetAbilityData(int abilityIndex) { }
```

`AbilityData` (TypeDefIndex 4000) is **only UI metadata**:

```csharp
public Sprite icon;                  // 0x00
public string titleKey;              // 0x04 - localisation key
public string shortDescriptionKey;   // 0x08
public string descriptionKey;        // 0x0C
```

It does NOT contain the ability *behaviour*. The behaviour lives on the **character prefab** as four concrete `Ability` MonoBehaviours, picked up at `Awake` by `CharAbilities`. The UI ability slot index (0..3) corresponds 1:1 with `CommandId.Ability1..Ability4` (i.e. cmdId 0..3).

### 2.2 `UICharactersConfiguration` (TypeDefIndex 4006)

```csharp
[SerializeField] private CharacterConfiguration[] _characters;            // 0x0C
                  private CharacterConfiguration[] _lobbyCharacters;      // 0x10
[HideInInspector][SerializeField] private int[] _lobbyAvailableCharacterIds; // 0x14

public CharacterConfiguration[] Characters         { get; }  // RVA 0x354C30
public CharacterConfiguration[] LobbyCharacters    { get; }  // RVA 0x368240
public int[]                    AvailableCharacterIds { get; } // RVA 0x384250

// RVA 0x421F70
public bool TryGetCharConfigByCharId(int charId, out CharacterConfiguration config) { }

// RVA 0x4220B0
public bool TryGetLobbyCharConfigByIndex(int charIndex, out CharacterConfiguration config) { }

// RVA 0x422150
public void UpdateAvailableCharacterList(int[] newCharacters) { }

// RVA 0x4222A0
public void Validate() { }
```

So the roster is: `_characters[]` is the full list (every charId the build knows about), `_lobbyCharacters[]` is the filtered set actually offered in the public matchmaking lobby, and `_lobbyAvailableCharacterIds[]` is a server-pushed override of which char IDs are currently eligible.

### 2.3 The other half: spawnable prefab via `SkinSO`

`CharacterConfiguration.DefaultSkin` is a `SkinSO`. `SkinSO.skin` is a `Skin`. Crucially:

```csharp
// dump.cs ~229069
public class Skin.SkinConfig {
    public int charId;                  // 0x08
    [Tooltip("The net spawnable character prefab for this skin")]
    public GameObject characterPrefab;  // 0x0C
}

public class Skin : Content {           // dump.cs ~229084
    public float        customDisplayScale; // 0x20
    public bool         isVaulted;          // 0x24
    public Rarity       rarity;             // 0x28
    public GameObject   visualizerPrefab;   // 0x2C  - lobby/UI 3D preview
    public Skin.SkinConfig config;          // 0x30  - ← contains the in-match networkable prefab
}
```

So a *character* in the design sense is the union of:

* a `CharacterConfiguration` row (UI metadata, ability icons, default skin pointer) in `UICharactersConfiguration._characters`, AND
* the corresponding `GameNetworkManager.characterPrefabsByCharId[charId]` slot, which is the actual networked prefab the server `NetworkServer.Spawn`s.

`Skin.SkinConfig.characterPrefab` lets a non-default skin override this prefab on a per-charId basis.



---

## 3. Roster Storage and charId Indexing

There are TWO parallel tables, both indexed by `charId`, and both must agree:

| Table | Purpose | Type | Where |
| --- | --- | --- | --- |
| `UICharactersConfiguration._characters` | UI metadata + default skin reference | `CharacterConfiguration[]` | ScriptableObject in `sharedassets0.assets` |
| `GameNetworkManager.characterPrefabsByCharId` | The actual networked prefab to instantiate | `GameObject[]` | A field on the `GameNetworkManager` MonoBehaviour in scene 0 |
| `GameNetworkManager.charBotPrefabsByCharId` | Bot variants (4 difficulties per id) | `CharacterBotPrefabs[]` | same |

### 3.1 `GameNetworkManager` (TypeDefIndex 3100, dump.cs ~118990)

```csharp
public const int AnnaCharId    = 1;
public const int ZookCharId    = 5;
public const int TeeveeCharId  = 8;
public const int SpriestCharId = 11;
public const int IceMageCharId = 12;

[SerializeField] public string[]                 names;                    // 0xB4
[SerializeField] public NetworkPrefabLibrary     networkPrefabLibrary;     // 0xB8
[SerializeField] public GameObject[]             characterPrefabsByCharId; // 0xBC ← MASTER
[SerializeField] private CharacterBotPrefabs[]   charBotPrefabsByCharId;   // 0xC0

// RVA 0x809E90
public GameObject GetCharacterBotPrefab(int charId, BotDifficulty botDifficulty) { }
```

`CharacterBotPrefabs` (3094):

```csharp
public GameObject charBotEasy;    // 0x08
public GameObject charBotMedium;  // 0x0C
public GameObject charBotHard;    // 0x10
public GameObject charBotExpert;  // 0x14
// RVA 0x809400
public GameObject GetBotPrefab(BotDifficulty botDifficulty) { }
```

### 3.2 `NetworkPrefabLibrary` (TypeDefIndex 3060)

```csharp
public GameObject[]               InstantiatedPrefabs; // 0x0C  - non-pooled spawns
public NetworkPrefabPool.Config[] PooledPrefabs;       // 0x10  - pooled (player chars use this)
```

This is the universal table Mirror uses to identify net-spawnable prefabs by `assetId` (Mirror's `NetworkIdentity.assetId` GUID). **Every prefab a server can spawn must appear here on both sides.** That's the first big roadblock for custom characters: the client and server must share an identical prefab list (with matching GUIDs) at game start, before any RPC is exchanged.

### 3.3 `NetworkPrefabPool` (TypeDefIndex 3064)

```csharp
private static Dictionary<GameObject, uint>          netIdLookup;
private static Dictionary<uint, NetworkPrefabPool>   poolLookup;
private static List<NetworkPrefabPool>               poolList;

public static void       ServerCreate(NetworkPrefabPool.Config config); // RVA 0x7040B0
public static void       ClientCreate(NetworkPrefabPool.Config config); // RVA 0x702B10
public static GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation); // 0x704150
public static void       Despawn(GameObject instance);                  // 0x703370
public static void       DespawnAfter(GameObject instance, float seconds); // 0x703290
private  GameObject SpawnHandler(SpawnMessage msg);                    // 0x704100
```

`Mirror.NetworkClient.RegisterPrefab(prefab, SpawnHandler, DespawnHandler)` is hooked from inside `ClientCreate`/`ServerCreate`, so when the server `Spawn`s a character, the client doesn't `Instantiate` blindly — it calls the registered handler which pops a recycled instance from the pool. **This is why naive prefab replacement at runtime won't make a custom character spawn**: the pool's `_inactive` stack is filled with copies of the *original* prefab and Mirror's identity is keyed off the original.

---

## 4. Character SPAWN Data Flow

```
            [LOBBY]                                 [MATCH]
 ┌───────────────────────────────────┐    ┌──────────────────────────────────┐
 │ UI button → CmdSelectCharacter(n) │    │  Match start. Server iterates   │
 │   on PlayerDeveloperLobby (3070)  │    │  PlayerManagers, reads          │
 │   - server validates              │    │  PlayerDeveloperLobby.lobbyChar │
 │   - sets [SyncVar] lobbyCharId    │    │  Id, copies to                  │
 └─────────────────┬─────────────────┘    │  PlayerManager.charId           │
                   │ syncs                │  (the [SyncVar] on PM, RVA      │
                   ▼                      │  setter set_NetworkcharId       │
 ┌───────────────────────────────────┐    │  0x719E40).                     │
 │ Hook OnLobbyCharIdChanged fires   │    │  Server then:                    │
 │ on every client → UI updates.     │    │   1. Looks up                   │
 └───────────────────────────────────┘    │      GameNetworkManager         │
                                          │      .characterPrefabsByCharId  │
                                          │      [charId]                   │
                                          │   2. NetworkPrefabPool.Spawn    │
                                          │      (prefab, spawnPos, rot)    │
                                          │      [Mirror server-only]      │
                                          │   3. Pool ServerSpawn'd ⇒ Mirror│
                                          │      assigns netId; broadcasts. │
                                          │   4. Server sets the spawned   │
                                          │      EntityManager's:           │
                                          │        playerObj  (SyncVar)     │
                                          │        charId     (SyncVar)     │
                                          │        charInstanceId           │
                                          │        entityTeamId             │
                                          │   5. Calls                      │
                                          │      PlayerManager.AddCharObj   │
                                          │      (em, isPrimary=true)       │
                                          │      RVA 0x715E40, which sets   │
                                          │      primaryCharManager (0xC4). │
                                          │   6. Clients receive            │
                                          │      EntityManager spawn +      │
                                          │      OnPlayerObjChanged hook    │
                                          │      (RVA 0x74BEA0) wires       │
                                          │      the EntityManager back to │
                                          │      its PlayerManager and     │
                                          │      calls AddCharObj on the    │
                                          │      client side.               │
                                          └──────────────────────────────────┘
```

### 4.1 Pre-match path

`PlayerDeveloperLobby` (TypeDefIndex 3070, dump.cs ~116773) is the lobby's network avatar:

```csharp
[SyncVar(hook = "OnIsReadyChanged")]      public bool isReady;     // 0x60
[SyncVar(hook = "OnLobbyTeamIdChanged")]  public int lobbyTeamId;  // 0x64
[SyncVar(hook = "OnLobbyCharIdChanged")]  public int lobbyCharId;  // 0x68

[Command]  // RVA 0x713000
private void CmdSelectCharacter(int newCharId) { }

[Command]  // RVA 0x7136C0
private void CmdSetSpectator() { }

[Command]  // RVA 0x713480
public void CmdSetLobbyTeam(int team) { }

[ClientRpc] // RVA 0x7147E0
public void RpcSetLobbyValues(int teamId, int charId) { }
```

`CmdSelectCharacter` is a **`[Command]`** (Mirror RPC, client-→-server). The server validates the request (e.g. against `_lobbyAvailableCharacterIds`) and only then writes to `lobbyCharId`. There is no client-side bypass of this validation — the SyncVar setter is server-authoritative.

### 4.2 Mid-match switch (dev only)

`PlayerDebug` (TypeDefIndex 3067, dump.cs ~115878 onward):

```csharp
[Command]  // RVA 0x708840
public void CmdSwitchCharacter(int charToSwitchId) { }

[Server]   // RVA 0x710170
public void SwitchCharacter(int charToSwitchId, int skinAssetId = -1) { }

[Command]  // RVA 0x707FC0
public void CmdSetSelectedSkinId(int skinAssetId) { }
```

`CmdSwitchCharacter` reaches `[Server]` `SwitchCharacter(int, int)`, which:
1. Updates `PlayerManager.charId` (SyncVar).
2. Optionally records `skinAssetId` (-1 = default skin).
3. Despawns the old `EntityManager`.
4. Spawns the new prefab from `characterPrefabsByCharId[charToSwitchId]` (or, if `skinAssetId != -1` and the skin's `SkinConfig.characterPrefab` is set, that prefab instead).
5. Re-attaches the new `EntityManager` to the same `PlayerManager` via `AddCharObj`.

The `[Command]` is gated server-side. On a public matchmaking server, `gameManager.isDevLobby` is false and the call is silently dropped (see the existing `examples/SkinSwapper/SkinSwapperMod.cs` warning *"On official servers this is silently rejected"*). On a developer lobby it works.

### 4.3 `PlayerManager` field layout (TypeDefIndex 3074, dump.cs ~117041)

```csharp
[SyncVar]                              public int    playerId;             // 0xA0
[SyncVar]                              public string playerName;           // 0xA4
[SyncVar(hook="OnIsAnonymousChanged")] public bool   isAnonymous;          // 0xA8
[SyncVar(hook="OnCharacterChanged")]   public int    charId;               // 0xAC ← KEY
[SyncVar(hook="OnTeamIdChanged")]      public int    teamId;               // 0xB0
[SyncVar(hook="OnDownedStateChanged")] public DownedState downedState;     // 0xB4
[SyncVar(hook="OnIsDeadChanged")]      public bool   isDead;               // 0xB8
                                       public int    selectedTombstoneAssetId; // 0xBC (NOT a SyncVar)
                                       public int    skinAssetId;          // 0xC0 (NOT a SyncVar)
                                       public EntityManager       primaryCharManager;   // 0xC4
                                       public List<EntityManager> secondaryCharManagers;// 0xC8
                                       public Transform           followTargetOverride; // 0xCC
                                       public Action               OnCharacterChangeEvent;//0xD0
public static PlayerManager LocalInstance;       // static

// RVA 0x715E40
public void AddCharObj(EntityManager _entityManager, bool isPrimary) { }

// RVA 0x7188D0
public void OnCharacterChanged(int oldValue, int newValue) { }

// RVA 0x718B90 — Mirror lifecycle
public override void OnStartClient() { }
public override void OnStartServer() { }       // 0x718C20
public override void OnStartLocalPlayer() { }  // 0x718BD0
```

> **Important:** `skinAssetId` is **not** a SyncVar on `PlayerManager`. It is only updated when the server runs `PlayerDebug.SwitchCharacter(charId, skinAssetId)` and is broadcast via the *re-spawned EntityManager* (which has its own `[SyncVar] int charId`) and via the existing skin-asset propagation embedded in the spawn flow. In effect: if you want every other client to see your custom-skin model swap, you cannot fake it from the local client — the server must send a new prefab (gated by `[Server]`/`isDevLobby`).

### 4.4 `EntityManager` (TypeDefIndex 6012, dump.cs ~223272) — the *body*

```csharp
[SyncVar] public string customEntityName; // 0x10C
[SyncVar] public bool   isPrimary;        // 0x110
[SyncVar(hook="OnPlayerObjChanged")] public GameObject playerObj; // 0x114 — back-ref to PlayerManager.gameObject
[SyncVar] public int    charId;           // 0x118 — entity-side char id
[SyncVar] public int    charInstanceId;   // 0x11C
            public int  ownerPlayerId;    // 0x120
            public bool dieWithPrimary;   // 0x124
[SyncVar(hook="OnEntityTeamIdChanged")] public int entityTeamId; // 0x128
[SyncVar] public int    botPlayerId;      // 0x12C

// Aggregate components (all populated on Awake from the prefab):
public CharNetwork      charNetwork;      // 0x54
public CharSimulation   charSim;          // 0x5C
public EntityMovement   charMove;         // 0x60
public CharAim          charAim;          // 0x64
public CharHurtbox      charHurtbox;      // 0x68
public CharTriggerbox   charTriggerbox;   // 0x6C
public CharAbilities    charAbilities;    // 0x70 ← the 4 abilities
public CharItems        charItems;        // 0x74
public CharPassives     charPassives;     // 0x78
public CharStatusEffects charStatusEffects;// 0x7C
public CharHpRegen      charHpRegen;      // 0x80
public CharDestroyTimer charDestroyTimer; // 0x84
public NpcBehaviour     npcBehaviour;     // 0x88
public TargetDetection  targetDetection;  // 0x8C
public CharEmotes       charEmotes;       // 0x90
public CharInteract     charInteract;     // 0x94
public CharLabelNear    charLabelNear;    // 0x98
public CharDowned       charDowned;       // 0x9C
public CharHpBar        charHpBar;        // 0xA0
public CharModelSwap    charModelSwap;    // 0xA4 ← cosmetic model swap (server-driven)
public CharAnimator     charAnim;         // 0xA8
public CharMaterial     charMaterial;     // 0xAC ← runtime renderer/material wrapper
public CharFX           charFx;           // 0xB0
public CharHidden       charHidden;       // 0xB4
public CharHideArea     charHideArea;     // 0xB8
public CharWorldPosition charWorldPosition;// 0xBC
public CharBushInteract charBushInteract; // 0xC0
public CharMinimap      charMinimap;      // 0xC4
public CharMoveAudio    charMoveAudio;    // 0xC8
public CharFogOfWar     charFogOfWar;     // 0xCC
public CharFootsteps    charFootsteps;    // 0xD0
public CharInterpolator charInterpolator; // 0xD4
public CharVoicelines   CharVoicelines;   // 0xD8
public EntityEventAnimator entityEventAnim;// 0xDC
public NavMeshAgent     agent;            // 0xE0
public CapsuleCollider  capsuleCollider;  // 0xE4
public PrefabConfig     prefabConfig;     // 0xE8
public EntityAnimComponents entityAnimComponents; // 0xEC
public EntityBehaviour  entityBehaviour;  // 0xF0
public EntityTriggerAreaBehaviour entityTriggerAreaBehaviour; // 0xF4
```

The `OnPlayerObjChanged` hook (RVA 0x74BEA0) is the moment a freshly spawned `EntityManager` is bound to its owning `PlayerManager` on the client. This is the prime hook target for client-side body-swapping logic.



---

## 5. Skin / Model Swap Mechanics

There are **three distinct meanings of "skin/model swap"** in the codebase. They are different systems, easily confused.

### 5.1 The whole-character "skin" (asset-level)

This is what `PlayerManager.skinAssetId`, `Skin.SkinConfig.characterPrefab`, and `PlayerDebug.CmdSetSelectedSkinId` refer to. A "skin" is essentially an alternate **networkable character prefab** for a given charId. The server picks `characterPrefabsByCharId[charId]` if `skinAssetId == -1`, otherwise it resolves the skin via `ContentManager.skinData.GetSkinByAssetId(skinAssetId)` (RVA 0x78D020) and uses `skin.config.characterPrefab` if non-null.

#### Asset id arithmetic (`SkinData`, dump.cs ~229128)

```csharp
public const int assetSkinOffset = 300000;

public static int GetSkinAssetIdBySkin(Skin skin);            // RVA 0x78D000
public static int GetSkinIdBySkinAssetId(int skinAssetId);    // RVA 0x78D170
public Skin       GetSkinByAssetId(int assetId);              // RVA 0x78D020
public Skin       GetSkinBySkinId(int skinId);                // RVA 0x78D0D0
public int        GetSkinIdBySkin(Skin skin);                 // RVA 0x359860
```

The pattern (consistent across `SkinData`, `TombstoneData`, `EmoteData`, `ItemData`, etc.) is:

```
assetId  =  contentTypeOffset + index_within_array
skinAssetId = 300000 + skinIndex
```

`ContentManager.assetOffsetSize = 100000`, and each content type's offset is a multiple of it (Items 100000, Passives/Augments 200000, **Skins 300000**, Emotes 400000, Tombstones 700000, …). Static `ContentManager.GetContentFromAssetId(int)` (RVA 0x7B90D0) resolves any asset id to a `Content`.

> **This means new skins added after-the-fact have to take a free slot.** All clients and the server must ship the *same* `SkinData.skins[]` ordering, because `assetId` is a positional index. Adding a skin client-side that the server doesn't know about will resolve to `null` everywhere except the modded client.

### 5.2 The runtime model swap (`CharModelSwap`, server-driven, in-match transform)

This is the in-game transform — e.g. **cat polymorph** (`CatPolymorphAbility`), **mech form**, **slime split**. The character's body model is replaced *temporarily* without changing the parent prefab.

`CharModelSwap` (TypeDefIndex 5066, dump.cs ~188977):

```csharp
private EntityManager  entityManager;       // 0x50
private CharAbilities  charAbilities;       // 0x54
private CharMaterial   charMaterial;        // 0x58
private UIManager      uiManager;           // 0x5C
private ItemManager    itemManager;         // 0x60
[SerializeField] private GameObject modelSwapHolder;     // 0x64 - root that gets disabled
[SerializeField] private Transform  modelSwapContainer;  // 0x68 - parent for the swap-in model
[SerializeField] private ItemObjectVisualizer itemObjectVisualizer; // 0x6C
[SerializeField] private Transform  vfxHolder;           // 0x70
[SerializeField] private float      slowAmount;          // 0x74
[SerializeField] private GameObject transformFxPrefab;   // 0x78
private GameObject     itemThemeVfx;                     // 0x7C
private GameObject     currentModel;                     // 0x80
private TransformScaleAnimation modelStartAnim;          // 0x84
private Animator       modelAnimator;                    // 0x88
private int            isMovingParamHash;                // 0x8C
// timers …
private Animator       currentAnimator;                  // 0xA0
private short          currentModelSwapId;               // 0xA4 - networked via OnNetSerialize

public bool ModelSwapped { get; }                                 // RVA 0x609EC0

[ServerCallback] public void ActivateSwap(int modelSwapId);       // RVA 0x608C70
[ServerCallback] public void DeactivateSwap();                    // RVA 0x609470
[ClientRpc]     private void RpcOnModelSwap();                    // RVA 0x609BA0
                private void ClApplySwapModel(int modelSwapId);   // RVA 0x608DE0
                private void ClSetModelSwapState(bool isSwapped); // RVA 0x6091C0
                public  void ClPlayTransformFx();                 // RVA 0x6090D0

// INetworkPredicted serialisation of currentModelSwapId:
public void OnNetSerialize(NetworkWriter w);   // RVA 0x6098E0
public void OnNetDeserialize(NetworkReader r); // RVA 0x609890
```

`ActivateSwap` is `[ServerCallback]` — the only legitimate trigger is server. The `currentModelSwapId` short is then deserialised by every client and `ClApplySwapModel` instantiates the model under `modelSwapContainer`. **For modders this means full model-swap is server-authoritative**; you cannot RPC yourself into a polymorph form. But you *can* observe `RpcOnModelSwap` / `OnNetDeserialize` and decorate the result client-side (custom material, custom child mesh, etc.).

### 5.3 The renderer/material layer (`CharMaterial`, fully client-side)

`CharMaterial` (TypeDefIndex 5750, dump.cs ~206275):

```csharp
public  GameObject       charRootHolder;     // 0x18
public  GameObject       charRigObj;         // 0x1C
private Transform        charAnimatedRoot;   // 0x20
private Transform        charAnimatedChest;  // 0x24
public  Renderer         charRenderer;       // 0x28 ← the main mesh renderer
public  Renderer[]       extraRenderers;     // 0x2C ← extra meshes (weapons, hair, …)
public  GameObject       hiddenObj;          // 0x30
private List<GameObject> extraObjs;          // 0x34
private List<CanvasGroup> attachedUIElements;// 0x38
private ParticleSystem[] detachableParticleSystems; // 0x3C
[SerializeField] private float       baseIndicatorRadius;    // 0x40
[SerializeField] private GameObject  baseIndicatorPrefab;    // 0x44
[SerializeField] private GameObject  baseIndicatorChild;     // 0x48
[SerializeField] public  IndicatorBaseMaterial indicatorMaterial; // 0x4C
// + many more
```

Internally it owns `MaterialWrapper` instances (TypeDefIndex 5741) so each `Renderer.sharedMaterial` is replaced by a per-char `Material` instance which can be tinted, alpha'd, hit-flashed, hidden, etc. without affecting other characters using the same shared material.

```csharp
public class CharMaterial.MaterialWrapper {
    public Material matInstance;            // 0x08 ← what is actually rendered
    public Material originalMat;            // 0x0C ← the asset-shared material
    public int      overrideTransparentQueue; // 0x10
    public int      overrideOpaqueQueue;      // 0x14
    public float    maxAlpha;                 // 0x18
    public bool     tintable;                 // 0x1C
}
```

**This is where a client-side custom skin lives**: replace `matInstance.mainTexture`, swap `charRenderer.sharedMesh`, or attach extra child renderers under `charRootHolder`. Nothing here is network-validated — the server doesn't know what mesh/texture you're showing. Other players will still see the *original* mesh on your character because their `CharMaterial` is built from their own loaded prefab.

### 5.4 Asset lookup chain summary

```
PlayerManager.skinAssetId  (300000+i)
    └──► ContentManager.skinData.GetSkinByAssetId(skinAssetId)   // RVA 0x78D020
            └──► Skin                                             // .config
                    └──► Skin.SkinConfig.characterPrefab          // ← prefab the server spawns
                    └──► Skin.visualizerPrefab                    // ← lobby/UI 3D preview
```

For default-skin spawning (no skin asset selected):

```
GameNetworkManager.characterPrefabsByCharId[charId]   // ← prefab the server spawns
UICharactersConfiguration.TryGetCharConfigByCharId(charId, out cfg)  // UI metadata
cfg.DefaultSkin.skin.visualizerPrefab                 // 3D lobby preview
```

---

## 6. Ability Slot Binding (4 slots: LMB / Q / Space / E)

### 6.1 `CommandId` (TypeDefIndex 6416, dump.cs ~236857)

```csharp
public enum CommandId {
    Ability1   = 0,   // LMB
    Ability2   = 1,   // Q
    Ability3   = 2,   // Space
    Ability4   = 3,   // E
    Ability5   = 4,   Ability6 = 5,   Ability7 = 6,   Ability8 = 7,
    CancelAbility = 8,
    AbilityHeal   = 9,
    Drop1 = 10,  Drop2 = 11,  Drop3 = 12,  Drop4 = 13,
    DropConsumable1 = 14, DropConsumable2 = 15, DropConsumable3 = 16,
    DropGold = 17, DropAbility = 18, Interact = 19,
    VehicleDrift = 20, VehicleTurbo = 21,
}
```

> **Correction to existing `docs/CHARACTERS.md`**: that file claims `Ability1 = 1, Ability2 = 2, …` and `slotId = (int)cmdId - 1`. The dump (TypeDefIndex 6416) shows the enum is **0-based**. The slotId IS the cmdId for slots 0..3. Mods using the existing `AbilityEvents.CastStarted/Completed/Cancelled.SlotId` should treat it as 0..3 == cmdId, no offset.

### 6.2 `CharAbilities` (TypeDefIndex 5043, dump.cs ~186811)

```csharp
private const int CONSTANT_ITEM_OFFSET = 4;
private EntityManager entityManager;     // 0x50
private CharHidden    charHidden;        // 0x54
private CharAnimator  charAnim;          // 0x58
private UIManager     uiManager;         // 0x5C
private UIAbilities   uiAbilities;       // 0x60
private UIPopUp       uIPopUp;           // 0x64
private RngManager    rngManager;        // 0x68
public  Ability[]     abilities;            // 0x6C ← indexed by cmdId 0..3
private Ability[]     abilitiesByPriority;  // 0x70
private Ability[]     abilitiesWithAutoCancel; // 0x74
private CmdBufferSystem cmdBufferSystem; // 0x78
[SerializeField] public Transform[] attachables; // 0x7C
// ... stats
public  CastFlags  castFlags;     // 0x90
public  byte       silenceLocks;  // 0x94
public  byte       teleportLocks; // 0x95
public  float      damage;        // 0x98
public  float      attackSpeed;   // 0x9C
public  float      cooldown;      // 0xA0
public  float      critChance;    // 0xA4
public  float      critDmg;       // 0xA8
public  float      lifesteal;     // 0xAC
public  float      shred;         // 0xB0
public  float      luck;          // 0xB4
// ...
```

The `abilities[]` array is populated at `Awake`/`Start` from the prefab — every ability slot 0..3 corresponds to an `Ability`-derived MonoBehaviour attached somewhere on the character prefab hierarchy. Add slot 4 (`AbilityHeal = 9` — heal consumable) and consumable / drop slots are handled separately via `cmdBufferSystem`.

The 30+ concrete ability subclasses (full list in `Il2CppBAPBAP.Entities/*Ability.cs`):

```
KatanaMeleeAbility, WidePunchAbility, JumpDropAbility, ChargeImpulseAbility,
RocketJumpAbility, MechJetpackAbility, MechSlashAbility, MechShieldAbility,
FireyChargedProjectileAbility, FireyEmpoweredDashAbility,
RockyPunchAbility, RockySmashAbility, RockyBoulderAbility, RockyRuptureAbility,
SpriestSnareAbility, SpriestTetherAbility, SpriestExpungeAbility, SpriestDisperseAbility,
CatJumpAbility, CatPolymorphAbility, FroggyMeleeAbility, FroggyLeapAbility,
HeavyPunchAbility, HeavyDigitalBeamAbility, MineFieldAbility, RageAbility,
RocketAbility, FollowRocketAbility, JumpPoundAbility, StunClapAbility, ParryAbility,
DownedDashAbility, DownedProjectileAbility, MechDashAttackAbility, PunchSequenceAbility,
ArrowAbility, ArrowMissileAbility, AssassinMeleeAbility, AssassinScytheHeavyAbility,
BlitzBuffAbility, BlitzHookAbility, BlitzTimedAbility, BossChadSequenceAbility,
BossChadTeleportAbility, CatMissileAbility, CatShotAbility, CatThrowAbility,
CelesteBlockAbility, CelesteFreezeAbility, CelesteShardAbility, CelesteSteadyShot,
ChargedArrowsAbility, DashAbility, DigitalCloneAbility, DigitalCloneUpgradeAbility,
DigitalDashCloneAbility, DigitalProjectileAbility, DigitalProjectileCloneAbility,
FatalBlowAbility, FireAttackAbility, FireMeteoriteAbility, FireShieldAbility,
FireStormAbility, HeavyDigitalBeamCloneAbility, InvisibleEscapeAbility,
JiroDashKickAbility, JiroJumpKickAbility, JiroPunchAbility, JiroPushKickAbility,
LootableBehaviourAbility, NpcArrowMissileAbility, NpcBigSlashMeleeAbility, ...
RecoilArrowAbility, RunNGunAbility, ShotgunAbility, SlimeBossDashAbility, ...
StabBlinkAbility, TeleportTestAbility, TongueJumpAbility, TornadoAbility
```

All are subclasses of `BAPBAP.Entities.Ability` (TypeDefIndex in dump.cs around the abilities namespace, base class file ~`Ability.cs`, 87KB). Each exposes `cmdId`, `cooldownTime`, `canceledTime`, etc., and overrides lifecycle methods.

### 6.3 Server-authoritative ability execution

Ability *casting* is not a SyncVar — it's tick-based:
* The local client builds a `Command` per fixed tick (in `PlayerNetwork.ClTick`), bundling `cmdId`, aim, predicted pos.
* The client predicts locally via `INetworkPredicted.OnTick(fixedDt, cmd, isResim=false)`.
* The client `Cmd`s the command up to the server via `PlayerNetwork.CmdPlayerCmds(Command)` (RVA 0x71A930).
* The server replays it on the authoritative simulation, broadcasts state via the `INetworkPredicted` `OnNetSerialize` hooks.
* Other clients receive the resulting state, plus side-effects (hitbox spawns, status effect applications) as separate net-spawned objects or `[ClientRpc]`s.

So an ability with no server-side counterpart is **purely cosmetic** — it cannot deal damage, apply CC, spawn hitboxes that hit other players, or score kills. The server does not run ability bytecode it doesn't have.

---

## 7. Server Authority Boundary

This is the section every aspiring "custom character" modder needs to read carefully.

| What you want to do | Where it's gated | Modder reach on official servers | Modder reach on private/dev lobby |
| --- | --- | --- | --- |
| Pick a stock charId pre-match | `PlayerDeveloperLobby.CmdSelectCharacter` is `[Command]`, server validates against `_lobbyAvailableCharacterIds` | ✓ (normal UI) | ✓ |
| Switch to another stock charId mid-match | `PlayerDebug.CmdSwitchCharacter` is `[Command]` and `[Server] SwitchCharacter` checks `gameManager.isDevLobby` | ✗ (silently dropped) | ✓ |
| Set `skinAssetId` to a stock skin | `PlayerDebug.CmdSetSelectedSkinId` is `[Command]`, similar dev-lobby gate | ✗ | ✓ |
| Spawn an entirely new charId not in `characterPrefabsByCharId` | Server does `characterPrefabsByCharId[charId]` lookup; out-of-range = no-op or error | ✗ | ✗ (server doesn't have the prefab unless it's modded) |
| Use a custom `Ability` subclass (new behaviour) | Ability MonoBehaviours are part of the prefab; server runs the *server's* copy | ✗ | ✗ (server has no .NET assembly with your subclass; CIL ↔ IL2Cpp wall too) |
| Re-skin your own character locally (mesh/texture/material) | `CharMaterial` is `MonoBehaviour`, fully client-side rendering | ✓ | ✓ |
| Re-skin OTHER players locally | Same — every player's `EntityManager` has its own client-side `CharMaterial` | ✓ | ✓ |
| Add a new `CharacterConfiguration` to the local UI list | `_characters` is a serialized array; mods can append at runtime | ✓ (UI only) | ✓ |
| Make the server actually spawn a custom prefab | `NetworkPrefabPool` requires both sides registered the same `NetworkIdentity.assetId` BEFORE connect | ✗ | ✗ unless you mod the server too |

### 7.1 Why custom prefab spawning fails on a stock server

Mirror identifies networked prefabs by a stable GUID (`NetworkIdentity.assetId`, packed into `SpawnMessage`). The set of valid IDs is loaded once on `OnStartClient`/`OnStartServer` from `NetworkPrefabLibrary.PooledPrefabs[]` & `InstantiatedPrefabs[]`. If the server tries to spawn an asset id the client doesn't know, the client logs an error and ignores the message (and vice-versa).

You can `NetworkClient.RegisterPrefab(myCustomPrefab)` from a client mod, but the **server** also has to know that GUID, generate a `SpawnMessage` with it, and call `NetworkServer.Spawn(myCustomPrefab)`. The server will not do any of those things unless it's running the same mod. BAPBAP's official servers are headless builds; only Mirror dev/host lobbies (where the *local* player is also the server) bypass this constraint.

### 7.2 Why custom abilities additionally fail

Even if you `Spawn` a custom prefab on a dev lobby:
1. Stat-affecting code (damage, hitbox HitOnce, etc.) is gated behind `[Server]` / `[ServerCallback]` methods. The server's IL2Cpp build does not contain your `Ability` subclass — your subclass only exists as managed CIL inside MelonLoader's domain. The server replays inputs only against types it has loaded.
2. The hitbox/projectile spawn helpers (`AB_SpawnHitbox_Base`, `AB_SpawnEntity_Base`, etc.) require a `NetworkPrefabLibrary` entry, same problem as 7.1.
3. The `INetworkPredicted` interface has slots reserved for the build's known component set; runtime registration of new predicted components is not exposed.

In practice "custom character with new gameplay" is **not feasible** without a modded dedicated server. Custom characters that *re-use* existing abilities in a new combination *are* feasible if you have a dev/host lobby (you can attach the existing `Ability` MonoBehaviours to a new prefab, register it in `NetworkPrefabLibrary`, and add the entry to `characterPrefabsByCharId`).

---



## 8. How To: Custom Client-Side SKIN (Achievable)

The achievable, official-server-friendly path is to **leave the networked character alone** and only re-paint the local rendering. This preserves Mirror authority and works for both your own character and other players' characters.

### 8.1 Strategy

1. Detect when an `EntityManager` finishes spawning on the client (via `OnPlayerObjChanged` hook or BAPBAP.ModAPI's `PlayerHooks` postfix on `PlayerManager.OnCharacterChanged`).
2. Filter to the charId you care about (e.g. only re-skin charId 1 / Anna).
3. Walk the `EntityManager.charMaterial.charRenderer` + `extraRenderers` and replace the texture / material / mesh on the client only.
4. Re-apply on every model swap (`CharModelSwap.RpcOnModelSwap` or `OnNetDeserialize`) because polymorph re-instantiates the visual root.

### 8.2 Reference: `BAPBAP.ModAPI.API.PlayerAPI` already exposes

```csharp
// modapi/src/API/PlayerAPI.cs
public static int LocalCharId       => Local?.charId ?? -1;
public static void SwitchCharacter(int charId)
{
    var p = Local; if (p == null) return;
    if (p.playerDebug != null) p.playerDebug.CmdSwitchCharacter(charId);  // dev-lobby only
}
```

and `PlayerEvents.CharacterChanged` (modapi/src/Events/PlayerEvents.cs):

```csharp
public sealed class CharacterChanged
{
    public PlayerManager Player;
    public int OldCharId;
    public int NewCharId;
}
```

This event is published by the existing `PlayerHooks.Patch_OnCharacterChanged` Harmony postfix (modapi/src/Hooks/PlayerHooks.cs around line 102) — i.e. it fires on `PlayerManager.OnCharacterChanged` for every player.

### 8.3 Concrete recipe

```csharp
using System;
using System.Collections.Generic;
using BAPBAP.ModAPI;
using BAPBAP.ModAPI.API;
using BAPBAP.ModAPI.Events;
using Bap = global::Il2CppBAPBAP;
using UnityEngine;

public sealed class MyCustomSkinMod : ModBase
{
    public override string Id          => "com.you.customskin";
    public override string DisplayName => "Custom Skin: Anna → Galaxy";

    // The charId we want to re-skin; could be a config option.
    private const int kTargetCharId = 1;   // GameNetworkManager.AnnaCharId

    private Texture2D? _customAlbedo;     // your replacement texture
    private Material?  _customMatTemplate;// optional - a whole material override

    // We track every EntityManager we've already re-skinned so we don't keep re-allocating.
    private readonly HashSet<int> _skinned = new();

    public override void OnRegistered()
    {
        // 1. Load your asset(s). AssetAPI is provided by BAPBAP.ModAPI.
        _customAlbedo = AssetAPI.LoadTexture("CustomSkin/anna_galaxy_albedo.png");

        // 2. Listen for character (re)spawns.
        Subscribe<PlayerEvents.CharacterChanged>(OnCharacterChanged);

        // 3. Sweep existing players when we register mid-match.
        foreach (var p in PlayerAPI.AllPlayers)
            TryReskin(p);
    }

    private void OnCharacterChanged(PlayerEvents.CharacterChanged e)
    {
        // PlayerManager.OnCharacterChanged fires AFTER the new EntityManager is set on the
        // PlayerManager.  But if the new char hasn't actually spawned yet (dev-lobby switch),
        // primaryCharManager may still be the old one. Defer one frame via a coroutine.
        Coroutines.Start(DeferReskin(e.Player));
    }

    private System.Collections.IEnumerator DeferReskin(Bap.Player.PlayerManager p)
    {
        yield return null; // one frame
        TryReskin(p);
    }

    private void TryReskin(Bap.Player.PlayerManager p)
    {
        if (p == null || p.charId != kTargetCharId) return;
        var em = p.primaryCharManager;
        if (em == null) return;
        var charMat = em.charMaterial;
        if (charMat == null || charMat.charRenderer == null) return;

        // Replace the main renderer's material's main texture.
        var matInst = charMat.charRenderer.material; // Unity instance-clones on first access
        if (_customAlbedo != null) matInst.mainTexture = _customAlbedo;

        // Optional: also walk extras (weapons, hair, etc.).
        if (charMat.extraRenderers != null)
        {
            foreach (var r in charMat.extraRenderers)
            {
                if (r == null) continue;
                if (_customAlbedo != null) r.material.mainTexture = _customAlbedo;
            }
        }

        _skinned.Add(em.GetInstanceID());
        BapModApiCore.Log.Info($"[CustomSkin] Reskinned {p.playerName} (charId={p.charId})");
    }
}
```

### 8.4 Re-skinning *the model* (not just texture)

If you want a custom mesh, replace `charRenderer.sharedMesh` (for `MeshRenderer`/`SkinnedMeshRenderer.sharedMesh`). For a skinned mesh, you must keep the same skeleton — the simplest path is to load a custom `Mesh` whose bind pose matches the original (i.e. you authored it against the BAPBAP rig in your DCC). If you want a *completely* new rig you must instantiate a separate child GameObject, position it at `charMaterial.charAnimatedRoot`, and hide the original via `charMaterial.charRenderer.enabled = false`.

For an asset-bundle-based custom mesh:

```csharp
var bundle  = AssetAPI.LoadAssetBundle("CustomSkin/anna_galaxy.assetbundle");
var newMesh = bundle.LoadAsset<Mesh>("Anna_Galaxy_Body");
var smr     = charMat.charRenderer as SkinnedMeshRenderer;
if (smr != null && newMesh != null) smr.sharedMesh = newMesh;
```

### 8.5 Surviving model swaps (cat polymorph etc.)

Every time `CharModelSwap.ClApplySwapModel` runs, `currentModel` is re-instantiated from a polymorph prefab and your texture override is gone for that swapped form. Re-apply on:

```csharp
HookManager.PatchPostfix(
    typeof(Bap.Entities.CharModelSwap),
    nameof(Bap.Entities.CharModelSwap.OnNetDeserialize),
    (Bap.Entities.CharModelSwap __instance) => TryReskinModelSwap(__instance));
```

Walk `__instance.modelSwapContainer` for renderers and reapply your textures.

### 8.6 Existing example to crib from

`examples/SkinSwapper/SkinSwapperMod.cs` already demonstrates the *char-id cycling* path (dev-lobby only). Your new mod is the *visual override* counterpart that works on official servers without server cooperation.

---

## 9. How To: Custom CHARACTER with New Abilities (Mostly Blocked)

This is provided for completeness — it is **NOT achievable on official servers**. It can be made to mostly-work in a Mirror **host** mode (you are running both client and server in your local process, e.g. a "Create Custom Lobby" host).

### 9.1 What is achievable in a host lobby

* Compose a brand-new character prefab from existing `Ability` subclasses (re-using stock ability behaviour).
* Add it to `GameNetworkManager.characterPrefabsByCharId` and `NetworkPrefabLibrary.PooledPrefabs`.
* Add a `CharacterConfiguration` row to `UICharactersConfiguration._characters`.
* Switch to it via `PlayerDebug.SwitchCharacter` (since you are the server, the dev-lobby check passes).

### 9.2 What is NOT achievable, even on host

* **A genuinely new `Ability` subclass with custom server logic.** The `Ability` base class is IL2Cpp; your subclass would be CIL inside MelonLoader. The server-side simulation (`INetworkPredicted.OnTick`, `OnNetSerialize`) only iterates types known to the IL2Cpp metadata. Even with `Il2CppInterop.Runtime.Injection.ClassInjector.RegisterTypeInIl2Cpp<MyAbility>()`, you cannot extend `Ability`'s server-tick contract because the contract is hard-coded against the existing TypeDefIndices — `CmdBufferSystem`, the `[Command]` cast pipeline, and `INetworkPredicted` registration tables don't accept arbitrary new entries at runtime.
* **A new `Hitbox` / `Projectile` type with custom damage rules.** Same reason; the server enumerates hitbox types from `EntityManager.charPassives`/`charItems` `OnHitTrigger`/`OnAbilityTriggered` etc.
* **Persistence / matchmaking integration** — server-side game state (mastery, leaderboards) is keyed off the stock charIds. Custom chars will be filtered out.

### 9.3 Recipe (host-only, prefab composed of existing parts)

```csharp
using System.Linq;
using Bap = global::Il2CppBAPBAP;
using UnityEngine;

public sealed class MyCustomCharacterMod : ModBase
{
    public override string Id          => "com.you.customchar";
    public override string DisplayName => "Custom Character: Frosty (host-only)";

    private const int kCustomCharId = 99;

    public override void OnReady()
    {
        // Only proceed if we are actually the host (server + client in one process).
        if (!Mirror.NetworkServer.active) return;

        var gnm  = UnityEngine.Object.FindObjectOfType<Bap.Network.GameNetworkManager>();
        var ucfg = UnityEngine.Object.FindObjectOfType<Bap.UI.UICharactersConfiguration>();
        if (gnm == null || ucfg == null) return;

        // 1. Build a new character prefab by cloning an existing one (e.g. IceMage @ charId 12).
        var src = gnm.characterPrefabsByCharId[Bap.Network.GameNetworkManager.IceMageCharId];
        if (src == null) return;
        var clone = UnityEngine.Object.Instantiate(src);
        clone.name = "Char_Custom_Frosty";
        UnityEngine.Object.DontDestroyOnLoad(clone);

        // 2. Patch the clone:
        //    - swap mesh/material for unique looks (CharMaterial)
        //    - reorder/replace ability slots if desired by manipulating
        //      clone.GetComponentInChildren<CharAbilities>().abilities
        //      (you can only replace with EXISTING Ability subclasses;
        //       see allowed list in §6.2)
        //    - tweak stats by editing the EntityManager.entityBehaviour fields

        // 3. Append to the master prefab table at index 99.
        var newArray = new Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray
                       <UnityEngine.GameObject>(kCustomCharId + 1);
        for (int i = 0; i < gnm.characterPrefabsByCharId.Length; i++)
            newArray[i] = gnm.characterPrefabsByCharId[i];
        newArray[kCustomCharId] = clone;
        gnm.characterPrefabsByCharId = newArray;

        // 4. Register with Mirror so both client and server can spawn it. We are host so
        //    both pools are ours — register on both.
        var cfg = new Bap.Pooling.NetworkPrefabPool.Config
        {
            prefab = clone,
            initialSizeServer = 1,
            initialSizeClient = 1,
            resizeStrategy = Bap.Pooling.NetworkPrefabPool.ResizeStrategy.Increment,
        };
        Bap.Pooling.NetworkPrefabPool.ServerCreate(cfg);
        Bap.Pooling.NetworkPrefabPool.ClientCreate(cfg);

        // 5. Add a UI row.
        var row = new Bap.UI.UICharactersConfiguration.CharacterConfiguration
        {
            name              = "Frosty",
            charId            = kCustomCharId,
            enabledInLobby    = false,
            enabledInDevLobby = true,
            // copy cosmetics from the cloned source so the UI doesn't crash
            // ...
        };
        // Append row to ucfg._characters (private; use Il2Cpp reflection or Harmony).

        // 6. Switch the local player to it.
        var pm = Bap.Player.PlayerManager.LocalInstance;
        pm?.playerDebug?.CmdSwitchCharacter(kCustomCharId);
    }
}
```

### 9.4 Where this falls over

* On a non-host (matchmade) game, `Mirror.NetworkServer.active` is `false` and the registration above is a no-op. Worse, even if you skip the guard, your `characterPrefabsByCharId` mutation only changes your *client's* copy; the server is still running the stock array, so its `Spawn(prefab, …)` call will still produce one of the stock charIds and your row is ignored.
* The localisation table on the server has no entry for your `descriptionTranslationKey`; UI labels show the raw key.
* Anything that hits the server's input queue (`PlayerNetwork.CmdPlayerCmds`) for `cmdId Ability1..4` will be processed by the server using *its* prefab's `Ability` MonoBehaviours, not your clone's. That is, even if you locally see your clone, ability behaviour will follow the stock IceMage on the server.

### 9.5 Honest summary

A modder's *useful* reach is:

1. **Skin/mesh/texture overrides at the renderer level** — works everywhere, scales to other players.
2. **UI/visual additions** — custom ability icons, custom name colours, custom particle effects.
3. **Char-id swapping in dev/host lobbies** — pick existing chars freely, including never-shown bot ones.
4. **Composing new prefabs from stock parts in host lobbies** — playable as long as you don't try to add new server-side logic.

Genuine "custom champion with new abilities playable on real servers" requires a modded dedicated server, which is out of scope for client-only modding.

---

## 10. Cross-references / Useful RVAs

| Symbol | RVA | Notes |
| --- | --- | --- |
| `PlayerManager.AddCharObj(EntityManager, bool)` | `0x715E40` | populates `primaryCharManager` / `secondaryCharManagers` |
| `PlayerManager.RemoveCharObj(GameObject)` | `0x718C50` |  |
| `PlayerManager.OnCharacterChanged` | `0x7188D0` | SyncVar hook on `charId` |
| `PlayerManager.OnStartLocalPlayer` | `0x718BD0` | sets `LocalInstance` |
| `PlayerDeveloperLobby.CmdSelectCharacter` | `0x713000` | `[Command]` for normal lobby selection |
| `PlayerDeveloperLobby.OnLobbyCharIdChanged` | `0x714730` |  |
| `PlayerDebug.CmdSwitchCharacter` | `0x708840` | dev-lobby only |
| `PlayerDebug.SwitchCharacter` | `0x710170` | `[Server]`, accepts `(charId, skinAssetId=-1)` |
| `PlayerDebug.CmdSetSelectedSkinId` | `0x707FC0` | dev-lobby only |
| `UICharactersConfiguration.TryGetCharConfigByCharId` | `0x421F70` |  |
| `UICharactersConfiguration.UpdateAvailableCharacterList` | `0x422150` | server pushes new list |
| `UICharactersConfiguration.Validate` | `0x4222A0` |  |
| `CharacterConfiguration.GetAbilityData(int)` | `0x419A10` |  |
| `Skin.SkinConfig` ctor / fields | dump.cs ~229069 | `int charId; GameObject characterPrefab;` |
| `SkinData.GetSkinByAssetId(int)` | `0x78D020` |  |
| `SkinData.GetSkinIdBySkinAssetId(int)` | `0x78D170` |  |
| `SkinData.GetSkinAssetIdBySkin(Skin)` | `0x78D000` |  |
| `ContentManager.GetContentFromAssetId` | `0x7B90D0` | static, generic asset id resolver |
| `ContentManager.GetAssetIdFromContent` | `0x7B8DB0` |  |
| `CharModelSwap.ActivateSwap(int)` | `0x608C70` | `[ServerCallback]` |
| `CharModelSwap.RpcOnModelSwap` | `0x609BA0` | `[ClientRpc]` |
| `CharModelSwap.ClApplySwapModel(int)` | `0x608DE0` | client-side instantiation |
| `CharModelSwap.OnNetSerialize/Deserialize` | `0x6098E0` / `0x609890` | sync `currentModelSwapId` |
| `EntityManager.OnPlayerObjChanged` | `0x74BEA0` | binds entity to PlayerManager |
| `NetworkPrefabPool.ServerCreate` | `0x7040B0` |  |
| `NetworkPrefabPool.ClientCreate` | `0x702B10` |  |
| `NetworkPrefabPool.Spawn` | `0x704150` |  |
| `GameNetworkManager.GetCharacterBotPrefab` | `0x809E90` |  |
| `PlayerNetwork.CmdPlayerCmds` | `0x71A930` | client→server tick command |

### 10.1 Existing ModAPI surface relevant to this subsystem

* `BAPBAP.ModAPI.API.PlayerAPI.LocalCharId` (`modapi/src/API/PlayerAPI.cs:135`)
* `BAPBAP.ModAPI.API.PlayerAPI.SwitchCharacter(int)` (`modapi/src/API/PlayerAPI.cs:138`) — wraps `CmdSwitchCharacter`, dev-lobby only.
* `BAPBAP.ModAPI.API.DevConsole.SwitchCharacter(int)` (`modapi/src/API/DevConsole.cs:49`)
* `BAPBAP.ModAPI.API.CharacterAPI` (`modapi/src/API/AdvancedAPIs.cs:100`) — `Config` (UICharactersConfiguration) and `AllCharIds`.
* `BAPBAP.ModAPI.Events.PlayerEvents.CharacterChanged` (`modapi/src/Events/PlayerEvents.cs:52`).
* `BAPBAP.ModAPI.Hooks.PlayerHooks.Patch_OnCharacterChanged` (`modapi/src/Hooks/PlayerHooks.cs:102`).
* `BAPBAP.ModAPI.Mirror.MirrorCmdRegistry.Cmd_PlayerDebug_CmdSetSelectedSkinId` (`modapi/src/Mirror/MirrorCmdRegistry.cs:499`).
* `BAPBAP.ModAPI.Mirror.MirrorSyncVarObserver.OnLocalPlayerCharacterChanged` (`modapi/src/Mirror/MirrorSyncVarObserver.cs:167`).

---

## 11. Honest Boundary Statement

For a typical BAPBAP mod author the practical capabilities are:

* **Client-side custom skins (texture/material/mesh-overlay):** ✅ fully supported, see §8.
* **Cycling between stock characters / skins in dev or host lobbies:** ✅, see `examples/SkinSwapper`.
* **Adding a UI-visible custom char to host lobbies, composed of stock ability components:** ⚠️ partial — local presentation works, but server-authoritative behaviour stays equal to the cloned source.
* **Adding a *real* custom champion (new abilities, new hitboxes, new server logic) playable on official matchmaking servers:** ❌ not achievable from the client. Requires a modded dedicated server, which is outside the scope of this codebase.

The current `BAPBAP.ModAPI` exposes the right primitives for (1) and (2). Anything beyond that should be built as a separate "host-side" companion mod and clearly disclaim that it does not work on official servers.
