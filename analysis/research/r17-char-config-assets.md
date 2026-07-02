# R17 — Character Config Assets & Roster List

**Scope:** Enumerate the character configuration ScriptableObjects and shipped `Char` prefabs in
`neueBapbap\GameCode\ExportedProject\Assets`, document the data each carries, how `charId` is
assigned, where the master roster list lives, and how the lobby / char‑select reads the roster.

**Sources read (real code/assets):**
- Decompiled C#: `...\_DisabledScripts\Assembly-CSharp\BAPBAP\...`
- Assets: `...\ExportedProject\Assets\MonoBehaviour\` (ScriptableObjects) and `...\Assets\GameObject\` (prefabs)
- Failed clone framework: `BAPBAPModdingAPI\bapcustomchars-mod\{CustomCharFramework.cs, MedusaMod.cs}`

All paths below are relative to `C:\Users\Administrator\Downloads\neueBapbap\GameCode\ExportedProject`
unless noted. Line numbers cite the actual files.

---

## 1. TL;DR (key facts for the synthesis stage)

1. **The master roster is a single ScriptableObject: `BAPBAP.UI.UICharactersConfiguration`**
   (`_DisabledScripts\Assembly-CSharp\BAPBAP\UI\UICharactersConfiguration.cs:9`).
   The shipped instance is `Assets\MonoBehaviour\UICharactersConfiguration.asset`
   (script `guid: 83717a04a098e02f51b833ce3818c19f`).
2. **Per‑character data is the nested `[Serializable] class CharacterConfiguration`**
   (`UICharactersConfiguration.cs:27‑109`), stored in the roster's `CharacterConfiguration[] _characters`
   array (`UICharactersConfiguration.cs:130`).
3. **`charId` is an explicit `int` field on each `CharacterConfiguration`**
   (`UICharactersConfiguration.cs:55`). It is *not* derived from array position; it is authored data.
   It is then used as an **array index** into the network manager's prefab tables (see §4).
4. **`charId → spawnable prefab` mapping is `GameNetworkManager.characterPrefabsByCharId` (GameObject[])**
   (`Network\GameNetworkManager.cs:304`), with a parallel bot table
   `charBotPrefabsByCharId` (`:307`). This is the authoritative gameplay/network mapping.
5. **The exported `.asset` is EMPTY of character data.** Because this is an IL2CPP AssetRipper export,
   `UICharactersConfiguration.asset` contains only the YAML header (14 lines, no `_characters`,
   no `_lobbyAvailableCharacterIds`). The roster array is reconstructed at runtime from the
   IL2CPP metadata, so the numeric charIds are **not** readable from the YAML and the SO **cannot**
   be edited by hand in this build. (See §7 — major implication for a from‑scratch design.)
6. **Five base playable characters ship as prefabs:** `Kitsu`, `Eve`, `Zook`, `Sashimi`, `Medusa`
   (each with `_Bot`, `_Bot_Easy/Medium/Hard`, and `_Skin_*` variants). Prefab GUIDs in §3.
7. **The lobby/char‑select pages reference the roster via a serialized `Configuration.CharacterConfiguration`
   field of type `UICharactersConfiguration`** and via `UIManager.characterConfig`
   (`UI\UIManager.cs:365`). The server additionally drives availability/unlocks through
   `CharacterPageModel` / `CharListingResponse` (see §6).
8. The exact method that crashed in the failed approach,
   `UILobbyCharacterSelectPage.GetCharacterListingIndexFromCharId(int charId)`
   (`UI\UILobbyCharacterSelectPage.cs:788`), returns the index of a charId inside the
   server‑supplied listing array — it NREs when a custom charId is not present in that listing.

---

## 2. The master roster ScriptableObject — `UICharactersConfiguration`

File: `_DisabledScripts\Assembly-CSharp\BAPBAP\UI\UICharactersConfiguration.cs`

```csharp
[CreateAssetMenu(fileName = "UICharactersConfiguration",
    menuName = "BAPBAP/Configuration/UI/CharactersConfiguration")]   // :7
public class UICharactersConfiguration : ScriptableObject            // :9
{
    [SerializeField] public CharacterConfiguration[] _characters;                 // :130  ← the roster
    [NonSerialized]  public CharacterConfiguration[] _lobbyCharacters;            // :133  (runtime subset)
    [SerializeField][HideInInspector] public int[] _lobbyAvailableCharacterIds;   // :137  (server availability)

    public CharacterConfiguration[] Characters      => null;   // :139 (stubbed in export; real getter at runtime)
    public CharacterConfiguration[] LobbyCharacters  => null;   // :141
    public int[] AvailableCharacterIds               => null;   // :143

    public bool TryGetCharConfigByCharId(int charId, out CharacterConfiguration config); // :145
    public bool TryGetLobbyCharConfigByIndex(int charIndex, out CharacterConfiguration config); // :151
    public int  GetLobbyCharIndexFromCharId(int charId);  // :157
    public void UpdateAvailableCharacterList(int[] newCharacters); // :162  ← rebuilds _lobbyAvailableCharacterIds
    public void Validate();   // :167
    public void OnEnable();   // :171
    public static DropdownList<int> GetCharsDropdown();        // :180  (editor dropdown of charIds)
    public static string CharArrayDrawer(int charId);         // :176
}
```

> NOTE: All method bodies are empty stubs in the export — this is an ILSpy/AssetRipper header dump of the
> IL2CPP assembly. The signatures are accurate; the logic lives in `Assembly-CSharp.dll` (also present at
> `BAPBAPMOD\Lib\Il2CppAssemblies\Assembly-CSharp.dll`, the proxy the mods compile against).

### The shipped asset is empty

`Assets\MonoBehaviour\UICharactersConfiguration.asset` (14 lines total):

```yaml
--- !u!114 &11400000
MonoBehaviour:
  ...
  m_Script: {fileID: 11500000, guid: 83717a04a098e02f51b833ce3818c19f, type: 3}
  m_Name: UICharactersConfiguration
  m_EditorClassIdentifier:
```

There are **no** `_characters`, `_lobbyCharacters`, or `_lobbyAvailableCharacterIds` entries — confirmed by
grepping the file (`charId:`, `name:`, `_characters:`, etc. → no matches). IL2CPP exports do not round‑trip
serialized SO field data, so the roster content is only available in the live game's metadata/heap.

---

## 3. Per‑character data: `CharacterConfiguration` (nested class)

File/lines: `UICharactersConfiguration.cs:27‑109`.

```csharp
[Serializable]
public class CharacterConfiguration
{
    [Serializable]
    public struct AbilityData                  // :30‑43
    {
        [SpriteVisualizer] public Sprite icon; // :33
        public string titleKey;                // :37  (localization key)
        public string shortDescriptionKey;     // :39
        public string descriptionKey;          // :41
    }

    public const int mainAbilityNum = 4;       // :45  ← 4 main abilities per char

    [TextArea(1,1)] public string name;                       // :48  internal roster name (e.g. "Kitsu")
    [TextArea(1,1)] public string descriptionTranslationKey;  // :51
    public CharacterDetailedInfo detailedInfo;                // :53
    public int charId;                                        // :55  ← AUTHORED identity key
    [Tooltip] public bool enabledInLobby;                     // :58  shown in normal lobby?
    [Tooltip] public bool enabledInDevLobby;                  // :61  shown in dev lobby?

    // ---- Sprites / colors (:63‑84) ----
    public Color  Color;                       public Color  UIAccentColor;
    public Sprite LobbyBackground;             public Sprite FullSprite;
    public Sprite MediumSprite;                public Sprite StandingSprite;
    public Sprite IconSprite;                  public Sprite smallSprite;
    public Sprite CircleIcon;                  public Sprite SquareIcon;
    public Sprite SquareSmallIcon;
    public SpriteTransformModifier gameStatsLobbySpriteModifier;
    public SkinSO DefaultSkin;                 // :84  ← default skin SO (carries the network prefab! §5)

    // ---- Ability presentation (:87‑102) ----
    public Color abilityIconColor, abilityBGColor, titleTextColor;
    public AbilityData ability1, ability2, ability3, ability4; // 4 ability UI blocks
    public AbilityData GetAbilityData(int abilityIndex);       // :105
}

[Serializable] public class SpriteTransformModifier { Vector2 anchoredPos; float scale; }  // :111‑117
[Serializable] public class CharacterDetailedInfo                                          // :119‑126
{ public string VoiceActorName; [TextArea] public string LorePassageKey; }

[Serializable] public struct CharIdWrapper { public int charId; ... }   // :12‑25 (inspector helper / dropdown)
```

**What the config carries (summary):**
- Identity: `charId` (int), `name` (internal string), localization keys for description.
- Lobby/dev visibility flags: `enabledInLobby`, `enabledInDevLobby`.
- Full UI sprite set (full/medium/standing/icon/circle/square + lobby background) and palette colors.
- A `DefaultSkin` (`SkinSO`) reference — important: the **spawnable character prefab is reached through the skin**, not stored directly on the config (see §5).
- Up to **4** `AbilityData` blocks — these are **UI/presentation only** (icon + localization keys + colors). They do **not** contain ability logic or prefabs; gameplay abilities live on the character prefab (out of R17 scope; see ability‑focused stages).

### Shipped `Char` prefabs (Assets\GameObject\)

The five base playable characters and their families:

| Char    | Base prefab     | Bot prefabs                                              | Skin prefabs (examples)                     | Base prefab GUID |
|---------|-----------------|---------------------------------------------------------|---------------------------------------------|------------------|
| Kitsu   | `Kitsu.prefab`  | `Kitsu_Bot`, `_Bot_Easy/Medium/Hard`                    | `Kitsu_Skin_Kitsus`                         | `54b5c0c60fda8f243a0db4d99bf841e5` |
| Eve     | `Eve.prefab`    | `Eve_Bot`, `_Bot_Easy/Medium/Hard`                      | `Eve_Skin_GothEve`; also `Eve_Visual`, `Eve_Ice_Block` | `9b86c506bc6d95e4ca1e8c97bbc84694` |
| Zook    | `Zook.prefab`   | `Zook_Bot`, `_Bot_Easy/Medium/Hard`                     | `Zook_Skin_BeastTamer`                      | `5ffe91023d3b9a84bad47266c9e75d39` |
| Sashimi | `Sashimi.prefab`| `Sashimi_Bot`, `_Bot_Easy/Medium/Hard`                  | `Sashimi_Skin_Tank`, `Sashimi_Skin_Test_Washimi` | `ea1708baa8fceea4aba8c779c48af91a` |
| Medusa  | `Medusa.prefab` | (no `_Bot_*` variants shipped)                          | `Medusa_Visual`, `MedusaPuddleSpawner`      | `00a97ec2da7ea2f489b0b0dc03855dff` |

Notable: **`Medusa` already ships as a real prefab + `Medusa_Visual`** in the base game files (plus
`VFX_*`/hitbox helpers exist for several chars). The failed mod cloned Kitsu and *re‑used* the name
"Medusa" at a chosen `charId=15` rather than wiring the shipped Medusa prefab into the roster/network tables.

Supporting (non‑playable) prefabs in the same folder: `CharacterEntityShared.prefab` (shared base entity,
`_prefabId: 602`, carries an `entityConfig`/`surfaceConfig` block), `MinimapIcon_Character`, `VFX_Char_*`,
and the UI prefabs `UILobbyCharacterSelectButton(.MatchStart)`, `UILobbyCharacterAbilityIcon`,
`DevLobbyCharButton`, `CharacterSelectBg`.

---

## 4. How `charId` is assigned and used

1. **Authored on the config.** `CharacterConfiguration.charId` (`UICharactersConfiguration.cs:55`) is the
   single source of identity. The companion `CharIdWrapper` struct (`:12`) and `GetCharsDropdown()` (`:180`)
   exist so other inspectors can pick a charId from a dropdown of the roster.

2. **Used as an index into the network prefab tables** in
   `Network\GameNetworkManager.cs`:
   ```csharp
   [SerializeField] public NetworkPrefabLibrary networkPrefabLibrary;   // :299
   [SerializeField] public GameObject[]            characterPrefabsByCharId; // :304  index = charId → player prefab
   [SerializeField] public CharacterBotPrefabs[]   charBotPrefabsByCharId;   // :307  index = charId → bot prefab set
   public GameObject GetCharacterBotPrefab(int charId, BotDifficulty botDifficulty); // :369
   ```
   `CharacterBotPrefabs` (`:20‑35`) bundles `charBotEasy/Medium/Hard/Expert` and
   `GetBotPrefab(BotDifficulty)`. So `charId` is simultaneously: (a) a lookup key for the config and
   (b) the **array slot** for the spawnable prefab — i.e., adding a new char means appending to the roster
   **and** ensuring `characterPrefabsByCharId[charId]` resolves to a network‑registered prefab.

3. **Looked up for UI/name** via `UIManager`:
   ```csharp
   public UICharactersConfiguration characterConfig;                     // UIManager.cs:365 ← holds the SO
   public UICharactersConfiguration.CharacterConfiguration GetCharacterConfiguration(int charId); // :736
   public string GetCharacterName(int charId);                           // :741
   ```

4. **The spawnable prefab is also reachable through the skin.** `Content\Skin.cs`:
   ```csharp
   [Serializable] public class SkinConfig {                          // :11
       public UICharactersConfiguration.CharIdWrapper character;     // :14  ← which char this skin is for
       [Tooltip("The net spawnable character prefab for this skin")]
       public GameObject characterPrefab;                            // :17  ← the actual prefab
   }
   ```
   `SkinSO : ContentSO { public Skin skin; }` (`Content\SkinSO.cs:6‑12`); skins are catalogued in
   `SkinData.skins (SkinSO[])` with `assetSkinOffset = 300000` (`Content\SkinData.cs:24,27`). Each
   `CharacterConfiguration.DefaultSkin` therefore points at the default visual prefab for that char.

**Observed numeric charIds** (from the failed framework's runtime knowledge, since the asset is empty):
- `Kitsu = 0` — used as the clone base (`CustomCharFramework.cs:27‑28`, `KnownBaseNames[0]="Kitsu"` `:131`).
- The failed mod registered its custom char ("Medusa") at **`charId = 15`** (`CustomCharFramework.cs:15‑16`).
  15 is a *chosen free slot* above the shipped roster, not a value read from the asset. The remaining base
  ids (Eve/Zook/Sashimi/Medusa) are 1..N at runtime but are not recorded in the YAML; treat them as
  runtime‑discovered (enumerate `UICharactersConfiguration.Characters` at load) rather than hard‑coding.

---

## 5. Relationship map (config ↔ prefab ↔ network)

```
UICharactersConfiguration (SO, UIManager.characterConfig)
│
├─ _characters : CharacterConfiguration[]          ← master roster
│     ├─ charId (int)                               ← identity + index key
│     ├─ name, localization keys, sprites, colors
│     ├─ ability1..4 : AbilityData (UI only)
│     └─ DefaultSkin : SkinSO ──► Skin.SkinConfig.characterPrefab (GameObject)  ← visual/default prefab
│
├─ _lobbyCharacters : CharacterConfiguration[]      ← runtime lobby subset
└─ _lobbyAvailableCharacterIds : int[]              ← rebuilt by UpdateAvailableCharacterList(int[])

GameNetworkManager
├─ characterPrefabsByCharId : GameObject[]          ← index = charId → SPAWNABLE player prefab (Mirror)
├─ charBotPrefabsByCharId  : CharacterBotPrefabs[]  ← index = charId → bot prefab set
└─ networkPrefabLibrary : NetworkPrefabLibrary      ← Mirror spawn registration (Pooling\NetworkPrefabLibrary.cs)
```

So a fully‑functional new char needs **three** linked pieces, all keyed by the same `charId`:
the roster `CharacterConfiguration`, the lobby availability id, and the
`characterPrefabsByCharId[charId]` network‑registered prefab (plus a bot entry if bots may pick it).

---

## 6. How the lobby / char‑select reads the roster

### 6a. Direct SO reference (client UI)

`UI\UILobbyCharacterSelectPage.cs` holds a serialized config block whose first field is the roster SO:

```csharp
[Serializable] public class Configuration {
    public UICharactersConfiguration CharacterConfiguration;   // ← the roster SO
    public string CharacterSelectButtonTranslationKey; ...     // many localization keys
}
```
(Class `Configuration` begins around `UILobbyCharacterSelectPage.cs:158`; the field is the first member.)
The match flow page `UI\UILobbyMatchCharacterSelectPage.cs` exposes the same `Configuration.CharacterConfiguration`
(this is the alias `Configuration = ...UILobbyMatchCharacterSelectPage.Configuration` used by `MedusaMod.cs:6`).

Selection / gating helpers on `UILobbyCharacterSelectPage` (all keyed by `charId`):
```csharp
bool CharacterIsSelectable(int charId);                 // :771
bool CharacterIsUnlocked(int charId);                   // :778
bool CharacterIsInRotation(int charId);                 // :783
int  GetCharacterListingIndexFromCharId(int charId);    // :788  ← index into the server listing array
bool TryGetCharacterIdFromListing(string listingId, out int charId); // :766
```
`GetCharacterListingIndexFromCharId` is the call that NRE'd for the failed custom char: a charId absent from
the server‑provided listing produces an invalid index/lookup. The failed mod had to prefix‑patch it to
return a safe index/`-1` (`MedusaMod.cs:215‑249`).

The page also nests presentation containers `CharacterAbilityPanel` (`:30`), `CharacterUnlockPanel` (`:60`),
`CharacterTokensProgress` (`:92`), `CharacterAbilityPosAnimation` (`:146`), and an `Actions` block with
`characterSelectAction`, `openCharacterCustomizationAction`, `characterUnlockAction` (`:21‑25`).

### 6b. Server‑driven availability / unlocks

The roster *content* comes from the SO, but **which chars are available/unlocked/in rotation** is driven by
the server and merged in via models:

`UI\CharacterPageModel.cs` (`class CharacterPageModel : Model`):
```csharp
public CharListings charListings;            // server char listings
public int[]   availableCharacters;          // available charIds
public int[]   charIdsInRotation;            // rotation charIds
public HashSet<int> unlockedCharacters;      // unlocked charIds
public CharTokenPass tokenPass; ...          // mastery/token progression
// nested:
class CharListing { string listingId; int charId; int levelRequirement; AssetModel[] costs; int purchases; }
```

`Network\CharListingResponse.cs` (wire payload):
```csharp
class CharListingResponse {
  class CharListing { string listingId; int levelRequirement; Asset[] costs; Asset[] rewards;
                      int charId; int purchases; }   // :10‑27
  class Asset { int assetId; int amount; }           // :29‑35
  CharListing[] charListings;                         // :38
}
```

So the full read path is:
1. Game loads the SO (`UIManager.characterConfig`) → static roster (`_characters`, sprites, abilities, names).
2. Server sends `CharListingResponse` → mapped to `CharacterPageModel` (`charListings`, `availableCharacters`,
   `charIdsInRotation`, `unlockedCharacters`).
3. The char‑select page joins them by `charId`: it iterates the roster for display data, and uses the model's
   arrays + `CharacterIsSelectable/Unlocked/InRotation` + `GetCharacterListingIndexFromCharId` for gating.
4. `UpdateAvailableCharacterList(int[])` on the SO rebuilds `_lobbyAvailableCharacterIds`/`_lobbyCharacters`
   for the lobby view.

This is exactly why the previous mod had to touch **all four**: append to `_characters`,
rebuild availability via `UpdateAvailableCharacterList`, force `CharacterIsUnlocked/InRotation/Selectable`,
and guard `GetCharacterListingIndexFromCharId`.

---

## 7. What the failed clone approach did to the roster (learn‑from)

From `BAPBAPModdingAPI\bapcustomchars-mod\MedusaMod.cs` (Il2Cpp aliases at `:1‑16`):

- **Find the SO at runtime:** `UIAPI.Manager.characterConfig`, else
  `Resources.FindObjectsOfTypeAll<UICharactersConfiguration>()[0]` (`MedusaMod.cs:10336‑…`, method `FindCharConfig`).
  (Confirms the asset cannot be authored statically; injection is runtime‑only.)
- **Clone a base config & append to the roster** (`TryRegisterMedusa`, `MedusaMod.cs:4739‑4825`):
  ```csharp
  CharacterConfiguration val4 = PickBase(characters);     // base = BaseCharId(0)=Kitsu, or by name
  CharacterConfiguration item = CloneConfig(val4, medusaCharId);
  val2._characters      = Append(val2._characters, item);       // :4803
  val2._lobbyCharacters = AppendLobby(val2, item);              // :4804
  MakeRosterAvailable(val2);                                    // :4806
  ```
- **Rebuild availability** (`MakeRosterAvailable`, `MedusaMod.cs:10314‑10334`):
  ```csharp
  var ids = new int[characters.Length];
  for (i..) ids[i] = characters[i].charId;
  cfg.UpdateAvailableCharacterList(ids);   // pushes every charId (incl. custom) into _lobbyAvailableCharacterIds
  ```
- **Force gating open** via prefixes on `CharacterIsSelectable/IsUnlocked/IsInRotation`
  (`MedusaMod.cs:152‑184`) and guard `GetCharacterListingIndexFromCharId` (`:215‑249`).
- **Config‑driven schema** in `CustomCharFramework.cs`: one JSON per char under `UserData\CustomChars\*.json`,
  fields incl. `CharId(=15)`, `Name`, `DisplayName`, `BaseCharId(=0 Kitsu)`, `BundleFileName`,
  `VisualPrefabName(=Medusa_Visual)`, `MirrorAssetId(=0x4D454455)`, and ability‑content arrays
  (`CustomCharFramework.cs:13‑115`).

**Why this is fragile (relevant to "do it correctly"):**
- It clones Kitsu's `CharacterConfiguration` and *grafts* visuals client‑side, so the
  `characterPrefabsByCharId[charId]` network table is **never** correctly populated for the custom id →
  other clients can't spawn/replicate it (matches the "only local / despawns / Standbilder" symptoms).
- Ability blocks on the config are **UI‑only**; cloning them does not give working abilities — hence
  "E plays Kitsu's animation" (the cloned prefab still drives Kitsu's ability components/animator).
- Roster membership is patched at runtime per‑UI‑callback (Build/Initialise/UpdateData/OpenCharSelectPanel),
  which is why availability flickers and the listing‑index NRE recurs.

---

## 8. Implications for a correct from‑scratch design (roster layer only)

1. **Treat `UICharactersConfiguration._characters` as the canonical roster.** A new char must have a real
   `CharacterConfiguration` entry (charId, name, sprites, ability UI blocks, `DefaultSkin`) — ideally created
   in a real Unity authoring project, not hand‑edited in this IL2CPP export (the YAML is empty by design).
2. **Reserve `charId` as a stable, server‑agreed integer** above the shipped range (the failed mod used 15).
   Enumerate the live roster at load to discover the highest existing id rather than hard‑coding base ids.
3. **Populate the network table, not just the roster:** ensure `GameNetworkManager.characterPrefabsByCharId`
   has an entry at `[charId]` pointing to a Mirror‑registered prefab (and `charBotPrefabsByCharId[charId]` if
   bots may select it). This is the piece the clone approach skipped — it is the root of the
   "not visible to other players" bug (cross‑reference the network/spawn research stages).
4. **Drive availability/unlock through the server payload** (`CharListingResponse` →
   `CharacterPageModel.availableCharacters/charIdsInRotation/unlockedCharacters`) so
   `GetCharacterListingIndexFromCharId` finds the id naturally, instead of force‑patching client gating.
5. **Keep ability *content* (config) separate from ability *logic* (prefab components).** The config's
   `AbilityData` is presentation only; real abilities are components on the character prefab/animator and
   belong to the ability stages, not the roster.

---

## 9. File/line index (quick reference)

| Item | File | Line(s) |
|---|---|---|
| Roster SO class | `UI\UICharactersConfiguration.cs` | 9 |
| `[CreateAssetMenu]` menu path | same | 7 |
| `CharacterConfiguration` class | same | 27‑109 |
| `AbilityData` struct | same | 30‑43 |
| `mainAbilityNum = 4` | same | 45 |
| `name` / `charId` | same | 48 / 55 |
| `enabledInLobby` / `enabledInDevLobby` | same | 58 / 61 |
| `DefaultSkin` (SkinSO) | same | 84 |
| `ability1..4` | same | 99‑102 |
| `_characters[]` | same | 130 |
| `_lobbyCharacters[]` / `_lobbyAvailableCharacterIds[]` | same | 133 / 137 |
| `TryGetCharConfigByCharId` / `GetLobbyCharIndexFromCharId` | same | 145 / 157 |
| `UpdateAvailableCharacterList(int[])` | same | 162 |
| `CharIdWrapper` struct | same | 12‑25 |
| `CharacterDetailedInfo` | same | 119‑126 |
| Roster asset (empty) | `Assets\MonoBehaviour\UICharactersConfiguration.asset` | 1‑14 |
| `UIManager.characterConfig` | `UI\UIManager.cs` | 365 |
| `UIManager.GetCharacterConfiguration` / `GetCharacterName` | same | 736 / 741 |
| `characterPrefabsByCharId` | `Network\GameNetworkManager.cs` | 304 |
| `charBotPrefabsByCharId` / `networkPrefabLibrary` | same | 307 / 299 |
| `CharacterBotPrefabs` class | same | 20‑35 |
| `GetCharacterBotPrefab` | same | 369 |
| `Skin.SkinConfig.character / characterPrefab` | `Content\Skin.cs` | 14 / 17 |
| `SkinSO` | `Content\SkinSO.cs` | 6‑12 |
| `SkinData.skins` / `assetSkinOffset` | `Content\SkinData.cs` | 24 / 27 |
| Char‑select gating methods | `UI\UILobbyCharacterSelectPage.cs` | 766‑788 |
| `CharacterPageModel` | `UI\CharacterPageModel.cs` | 7‑80 |
| `CharListingResponse` | `Network\CharListingResponse.cs` | 7‑38 |
| Shipped char prefabs | `Assets\GameObject\{Kitsu,Eve,Zook,Sashimi,Medusa}.prefab` | — |
| Failed framework schema | `BAPBAPModdingAPI\bapcustomchars-mod\CustomCharFramework.cs` | 13‑115 |
| Failed roster injection | `BAPBAPModdingAPI\bapcustomchars-mod\MedusaMod.cs` | 4739‑4825, 10314‑10334 |

> Line numbers for `UILobbyCharacterSelectPage.cs` gating methods are from the document‑symbol scan
> (`CharacterIsUnlocked` 778, `CharacterIsInRotation` 783, plus `CharacterIsSelectable` and
> `GetCharacterListingIndexFromCharId` immediately adjacent); the `Configuration.CharacterConfiguration`
> field is the first member of the nested `Configuration` class. All other lines were read directly.
