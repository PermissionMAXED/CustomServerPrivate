# R12 — Input → Ability / Action Mapping (BAPBAP)

**Scope:** How player input (LMB / RMB / Space / E / Q + movement) is read, bound, and
mapped to ability slots and game actions, fully through the networked simulation. This
is the authoritative reference for *which key triggers which slot* and *how a key press
becomes an ability cast* on a Unity 2022.3 / IL2CPP / Mirror build.

**Primary sources (real code, cited by file:line):**

- Decompiled stubs (signatures, enums, attributes — bodies stripped):
  `…\neueBapbap\GameCode\ExportedProject\_DisabledScripts\Assembly-CSharp\BAPBAP\…`
- **Full-source build (real method bodies)** — `GEHEIMBUILD`:
  `…\neueBapbap\GEHEIMBUILD\ExportedProject\Assets\Scripts\Assembly-CSharp\BAPBAP\…`
- Failed clone mod (for the R12 failure analysis):
  `…\BAPBAPModdingAPI\bapcustomchars-mod\MedusaMod.cs`

Unless noted, line numbers refer to the **GEHEIMBUILD full-source** build, which contains
real method bodies; the `_DisabledScripts` tree has identical type/enum/attribute layout.

---

## 0. TL;DR — the answer

There are **two distinct enums** in play and they are *not* the same numbering:

- `InputTarget` = a **physical binding slot** (what a key/button is bound to). Order also
  drives movement, drops, ping, emote, minimap, etc.
- `CommandId` = the **runtime command index** packed into the networked `Command` bitmask
  that the simulation replays. Each `Ability` carries a `CommandId cmdId`.

**Per-character ability slots are keyed by `CommandId`**, and the engine ships 8 ability
command slots (`Ability1`…`Ability8`). The authored, in-editor default mapping is stated
verbatim in the engine source:

> `Ability.cs:18` tooltip: *"Which command will this ability be casted with?
> (LMB = Ability1, Q = Ability2, Space = Ability3, E = Ability4)"*

So the **canonical 4-ability layout** is:

| Physical input | `CommandId` (Ability slot) | Command bit index | UI element |
|---|---|---|---|
| **LMB** (Mouse0) | `Ability1` (0) | bit 0 | `UIAbilities.ability1` |
| **Q** *(see §3 note: RMB in the live custom build)* | `Ability2` (1) | bit 1 | `UIAbilities.ability2` |
| **Space** | `Ability3` (2) | bit 2 | `UIAbilities.ability3` |
| **E** | `Ability4` (3) | bit 3 | `UIAbilities.ability4` |

`Ability5…Ability8` (bits 4–7) exist for extra/secondary kits (model-swap chars, vehicles,
lootable abilities, second-character setups). Movement, drops, cancel, heal, interact are
*separate* commands (see §2 / §6).

The whole chain is: **key → `InputBinding` → `InputManager` packs a `Command` bitmask →
`Command` is networked/predicted → `CmdBufferSystem` + each `Ability` read
`cmd.GetKeyDown((int)cmdId)`** (see §5). Bypassing this chain is exactly why the previous
clone mod's abilities broke (see §9).

---

## 1. The two enums (verbatim values)

### 1.1 `InputTarget` — binding targets
`_DisabledScripts\…\BAPBAP\Local\InputTarget.cs`

```
MoveUp=0, MoveDown=1, MoveLeft=2, MoveRight=3,
Ability1=4, Ability2=5, Ability3=6, Ability4=7, Ability5=8,
CancelAbility=9, AbilityHeal=10,
Drop1=11, Drop2=12, Drop3=13, DropGold=14,
CamLock=15, ChatKey=16, Ping=17, Emote=18,
MinimapHold=19, MinimapToggle=20, Interact=21,
TooltipExpand=22, MoveAxis=23, AimAxis=24,
Ability6=25, DropConsumable1=26, Ability7=27, DropLootableAbility=28,
VehicleDrift=29, VehicleTurbo=30, Drop4=31, Ability8=32,
DropConsumable2=33, DropJuice=34, VehicleHorn=35
```

`InputMap.inputs[]` is `[NamedArray(typeof(InputTarget),0)]`, i.e. it is **indexed by this
enum order**: `inputMap.inputs[i]._target = (InputTarget)i` — set in `InputSystem.Awake`
(`InputSystem.cs:367-372`).

### 1.2 `CommandId` — runtime command bits
`_DisabledScripts\…\BAPBAP\Local\CommandId.cs`

```
Ability1=0, Ability2=1, Ability3=2, Ability4=3,
Ability5=4, Ability6=5, Ability7=6, Ability8=7,
CancelAbility=8, AbilityHeal=9,
Drop1=10, Drop2=11, Drop3=12, Drop4=13,
DropConsumable1=14, DropConsumable2=15, DropConsumable3=16,
DropGold=17, DropAbility=18, Interact=19,
VehicleDrift=20, VehicleTurbo=21
```

These integers are the **bit positions** in the `Command` bitmask (see §4) and the index
used by `Ability.cmdId` and `cmd.GetKeyDown((int)cmdId)`.

### 1.3 The bridge between the two
`InputManager.GetInputTargetByAbilityCmd(CommandId)` (`InputManager.cs:355-369`) maps each
ability command to its binding target 1:1:

```csharp
CommandId.Ability1 => InputTarget.Ability1, … Ability8 => InputTarget.Ability8,
_ => InputTarget.Ability1
```

`UIAbilities.GetInputTargetByAbilityId(int)` does the same for the HUD key icons.

---

## 2. `InputManager.Awake` — the definitive bit-index table

`InputManager.cs:108-150` builds `cmdInputBindings[]` in a **fixed order**. The array index
`i` is the bit set in the `Command` (`cmd.SetKeyDown(i)`), so this array *is* the
authoritative key→bit map. The order is chosen to line up with `CommandId`:

```csharp
InputTarget[] array = new InputTarget[22] {
  Ability1, Ability2, Ability3, Ability4, Ability5, Ability6, Ability7, Ability8, // 0..7
  CancelAbility,        // 8   == CommandId.CancelAbility
  AbilityHeal,          // 9   == CommandId.AbilityHeal
  Drop1, Drop2, Drop3, Drop4,          // 10..13
  DropConsumable1, DropConsumable2,    // 14,15
  DropJuice,            // 16  (== CommandId.DropConsumable3 slot)
  DropGold,             // 17
  DropLootableAbility,  // 18  (== CommandId.DropAbility slot)
  Interact,             // 19
  VehicleDrift,         // 20
  VehicleTurbo          // 21
};
cmdLength = 22;
for (i…) cmdInputBindings[i] = inputSystem.inputMap.GetInputByTarget(array[i]);
…
cachedCmdLmbId = 0;   // bit 0 (Ability1 / LMB) is the "is mouse over UI?" guarded slot
```

Resulting **bit-index ↔ command** table (use this whenever reading a `Command`):

| Bit | `CommandId` | Bound `InputTarget` | Default action |
|----:|---|---|---|
| 0 | Ability1 | Ability1 | **LMB** — primary ability/attack |
| 1 | Ability2 | Ability2 | **Q / RMB** — ability 2 |
| 2 | Ability3 | Ability3 | **Space** — ability 3 |
| 3 | Ability4 | Ability4 | **E** — ability 4 (ult) |
| 4 | Ability5 | Ability5 | secondary kit / model-swap |
| 5 | Ability6 | Ability6 | secondary kit |
| 6 | Ability7 | Ability7 | secondary kit |
| 7 | Ability8 | Ability8 | secondary kit |
| 8 | CancelAbility | CancelAbility | cancel/interrupt current cast |
| 9 | AbilityHeal | AbilityHeal | heal consumable |
| 10 | Drop1 | Drop1 | drop hat gear |
| 11 | Drop2 | Drop2 | drop torso gear |
| 12 | Drop3 | Drop3 | drop boots gear |
| 13 | Drop4 | Drop4 | drop pin gear |
| 14 | DropConsumable1 | DropConsumable1 | drop consumable 1 |
| 15 | DropConsumable2 | DropConsumable2 | drop consumable 2 |
| 16 | DropConsumable3 | DropJuice | drop consumable 3 ("juice") |
| 17 | DropGold | DropGold | drop gold |
| 18 | DropAbility | DropLootableAbility | drop the lootable ability |
| 19 | Interact | Interact | interact / pick up |
| 20 | VehicleDrift | VehicleDrift | vehicle drift |
| 21 | VehicleTurbo | VehicleTurbo | vehicle turbo |

Note the two **name-vs-slot mismatches** (bits 16 and 18): the `cmdInputBindings` array
binds `InputTarget.DropJuice`/`DropLootableAbility`, while the *command* slot is
`CommandId.DropConsumable3`/`DropAbility`. They are the same physical slot; only the enum
names differ. Everything else is a clean 1:1.

`CamLock`, `ChatKey`, `Ping`, `Emote`, `MinimapHold/Toggle`, `TooltipExpand`,
`VehicleHorn`, `MoveAxis`, `AimAxis` are **not** in `cmdInputBindings` — they are handled
outside the per-tick command (UI/camera/aim systems), not in the gameplay bitmask.

---

## 3. Binding layer — `InputBinding` / `InputMap` / defaults / rebinding

### 3.1 `InputBinding`
`GEHEIMBUILD\…\Local\InputBinding.cs`

```csharp
public KeyCode keybind;          // legacy keyboard/mouse bind (Mouse0, Mouse1, Space, E…)
public InputAction action;       // new Input System action (gamepad + rebinds)
public Sprite actionIcon;
public string translationKey;
public bool rebindable = true;

public bool GetPressed()  => Input.GetKeyDown(keybind) || action.WasPressedThisFrame();
public bool GetHeld()     => Input.GetKey(keybind)     || action.IsPressed();
public bool GetReleased() => Input.GetKeyUp(keybind)   || action.WasReleasedThisFrame();
```

So every binding fires from **either** a legacy `KeyCode` **or** an `InputAction` (gamepad
/ remapped). Mouse buttons are first-class `KeyCode`s here: `KeyCode.Mouse0` = LMB,
`KeyCode.Mouse1` = RMB.

`GetKeyCodeName` (`InputSystem.cs:374+`) confirms the sprite mapping:
`Mouse0 → LMB`, `Mouse1 → RMB`, `Mouse2 → MMB`, `Space → Spacebar`, `Alpha1..9 → "1".."9"`,
`JoystickButton0..3 → Face A/B/X/Y`, `JoystickButton4 → LB`, etc.

### 3.2 `InputMap`
`_DisabledScripts\…\Local\InputMap.cs` + `GEHEIMBUILD` bodies

- `GetInputByTarget(InputTarget)` / `GetInputByKey(KeyCode,GamepadKeyCode)` — lookups.
- `GetRebindResult` → `Available / AlreadyInUse / Invalid`.
- `RebindAction(toRebind, newKey, gamepadKeyCode)`, `SaveBind`, `SaveAllBinds`,
  `LoadAllBinds`, `LoadBind` — user remaps persisted to local saved data.
- `inputs[]` is indexed by `InputTarget` (NamedArray).

### 3.3 Defaults
`InputSystem.Awake` (`InputSystem.cs:365-373`) snapshots the *serialized* default per
target before user binds are loaded:

```csharp
defaultKeyBinds = new Dictionary<InputTarget, KeyCode>();
for (i…) { inputMap.inputs[i]._target = (InputTarget)i;
           defaultKeyBinds.Add(target, inputMap.inputs[i].keybind); }
inputMap.LoadAllBinds();   // overlay user remaps
```

The actual serialized `KeyCode` per slot lives in the `InputSystem` component's
`inputMap.inputs[]` (authored in-scene; the `MainScene.unity` `InputActionAsset`/component
holds them). `GetDefaultInputKey(InputBinding)` (`InputSystem.cs:374+`) reads this dict for
"reset to default" in `UIRebindKeyController`.

> **Note on Ability2 (Q vs RMB):** the engine tooltip names **Q** as the default Ability2
> keyboard bind (`Ability.cs:18`). The live custom-server build the user is running treats
> **RMB** as Ability2 — consistent with the user's "RMB shows a green dot" symptom and with
> the failed mod's fallback, which polled **both** `Mouse1` *and* `Q` for slot 1
> (`MedusaMod.cs` `PollLocalInputCastFx`, see §9). Both are valid because Ability2's
> `InputBinding` can carry a mouse `KeyCode` and/or an `InputAction`, and the slot is
> user-rebindable. Treat the *slot* (`CommandId.Ability2`) as canonical; the exact default
> physical key is build/config data, not hard-coded in the cast logic.

### 3.4 Gamepad
`GamepadKeyCode` enum (`Local\GamepadKeyCode.cs`): `FaceA..FaceY, Select, Start,
LeftShoulder, RightShoulder, LeftTrigger, RightTrigger, LeftStick(Press), RightStick(Press),
DPadLeft/Right/Up/Down`. `InputSystem` exposes `FaceAAction`, `RightTriggerAction`, etc., and
`gamepadActions[]`. On gamepad, abilities aim via the right stick / aim-assist (see §7).

---

## 4. `Command` — the networked input packet

`GEHEIMBUILD\…\Local\Command.cs`

```csharp
public int keyDowns, keyHolds, keyUps;     // bitmasks indexed by CommandId bit
public Vector3 directionals;               // movement (x,0,z) normalized
public Vector3 worldMousePos;              // aim point on ground plane
public byte inputSource;                   // 1=KBM, 2=Gamepad, 3=Screen
public bool quickCastAbilities;

public bool GetKeyDown(int cmdId) => (keyDowns & (1 << cmdId)) != 0;
public bool GetKeyHold(int cmdId) => (keyHolds & (1 << cmdId)) != 0;
public bool GetKeyUp  (int cmdId) => (keyUps   & (1 << cmdId)) != 0;
public void SetKeyDown(int cmdId) => keyDowns |= 1 << cmdId;   // (Hold/Up analogous)
public static Command Duplicate(int tick, Command c) { … }     // for resim/rollback
```

One `Command` per simulation tick is built on the client, sent to the server, and
**replayed during prediction/reconciliation** (`Duplicate`). This is the *only* sanctioned
channel for an ability to learn that its key was pressed.

---

## 5. `InputManager` — per-frame buffering and per-tick packing

`GEHEIMBUILD\…\Local\InputManager.cs`

### 5.1 `Update()` — frame-rate buffering (`:212-235`)
Because sim ticks are slower than render frames, presses/releases are buffered so a tap
between ticks isn't lost (only in KBM mode):

```csharp
if (bufferInputsForTick && inputSystem.InputMode == KBM)
  for (i…) if (i != cachedCmdLmbId || !uiManager.IsMousePressedOverUI()) {
      if (!bufferedKeyDowns[i]) bufferedKeyDowns[i] = cmdInputBindings[i].GetPressed();
      if (!bufferedKeyUps[i])   bufferedKeyUps[i]   = cmdInputBindings[i].GetReleased();
  }
```

`cachedCmdLmbId == 0` (Ability1/LMB) is suppressed while the cursor is pressed over UI, so
clicking HUD buttons doesn't fire the primary ability.

### 5.2 `ConsumeCommand` / `ConsumeButtons` — pack the tick (`:259-309`)
```csharp
ConsumeCursor(cmd);            // aim + inputSource
if (keysDisabled) return cmd;  // ToggleEnabled(false) blanks all buttons
ConsumeButtons(cmd);
```

`ConsumeButtons` (`:281-308`):
```csharp
for (i…) if (i != cachedCmdLmbId || !uiManager.IsMousePressedOverUI()) {
    if (bufferedKeyDowns[i] || cmdInputBindings[i].GetPressed())  { cmd.SetKeyDown(i); … }
    if (bufferedKeyUps[i]   || cmdInputBindings[i].GetReleased()) { cmd.SetKeyUp(i);  … }
    if (cmdInputBindings[i].GetHeld())                            cmd.SetKeyHold(i);
}
Vector2 m = inputSystem.MoveAxis;
cmd.directionals = new Vector3(m.x, 0f, m.y).normalized;   // MOVEMENT
```

### 5.3 `ConsumeCursor` — aim (`:310-322`)
```csharp
cmd.inputSource = KBM?1 : Gamepad?2 : Screen?3;
mouseRay = mainCamera.ScreenPointToRay(inputSystem.VirtualCursor);
if (Physics.Raycast(mouseRay, out hit, ∞, groundMask))
    cmd.worldMousePos = new Vector3(hit.point.x, 0, hit.point.z);   // AIM POINT
```

### 5.4 UI/event-driven commands (`Start()`, `:155-205`)
Drops can also be issued by **clicking inventory slots** (not just keys):
`PopulateCommand(CommandId)` sets `bufferedKeyDowns[(int)cmdId]=true`. Wired to gear/gold/
consumable/lootable slots, e.g. `gearHatSlots → Drop1`, `consumableSlots[2] → DropConsumable3`,
`lootableAbilitySlot → DropAbility`. So a `Command` bit can originate from a key **or** a HUD click.

---

## 6. Movement and aim (the non-ability inputs)

- **Movement** is NOT in the command bitmask; it is `cmd.directionals` (§5.2), derived from
  `InputSystem.MoveAxis`. In KBM, `InputSystem.Update` (`:421-426`) rebuilds it from the four
  bound directionals:
  ```csharp
  moveAxis = new Vector2((right.GetHeld()?1:0)-(left.GetHeld()?1:0),
                         (up.GetHeld()?1:0)-(down.GetHeld()?1:0));
  ```
  `up/down/left/right` are `InputMap.GetInputByTarget(MoveUp/Down/Left/Right)` (default WASD),
  resolved in `InputSystem.Awake` (`:375-378`). On gamepad, `moveAxis = moveAction.ReadValue`.
- **Aim** = `cmd.worldMousePos`. KBM uses the real mouse (`VirtualCursor → Input.mousePosition`,
  `InputSystem.cs` `GetVirtualCursor`); gamepad/screen synthesize a virtual cursor from the
  right stick + aim-assist scoring (`GetAimAssistTarget`, `combinedAxis`, `cardinalOffset`).
- `InputMode` enum: `KBM=0, KBMButtonUp=1, Gamepad=2, Screen=3` (`Local\InputMode.cs`).
  `KBMButtonUp` is the **release-to-cast** variant.

---

## 7. Ability consumption — how a bit becomes a cast

### 7.1 The slot tag
`GEHEIMBUILD\…\Entities\Ability.cs:18-20`
```csharp
[Tooltip("Which command will this ability be casted with? (LMB = Ability1, Q = Ability2,
          Space = Ability3, E = Ability4)")]
public CommandId cmdId;
```
Every ability component on a character prefab carries this `cmdId`. It is the single field
that binds an ability to an input slot. Other knobs on `Ability`: `priority` (input-buffer
contention), `inputBufferDuration`, `autoCancel`, `cancelable`, `silenceable`,
`useCustomUIData` + `customUIData` (HUD icon/title), `maxTimeDilation`.

### 7.2 Input buffering — `CmdBufferSystem`
`GEHEIMBUILD\…\Entities\CmdBufferSystem.cs:18-36` (driven from `CharAbilities.OnTick`):
```csharp
foreach (ability in abilities) {
    if (cmd.GetKeyDown((int)ability.cmdId))                                   // <-- key→slot
        ability.isInputBuffered = true;
    if (ability.isInputBuffered && !cmd.GetKeyHold((int)ability.cmdId)
        && ability.inputBufferTimeLeft <= 0f)
        ability.inputBufferTimeLeft = ability.inputBufferDuration;            // 250ms default
    if (ability.inputBufferTimeLeft > 0f) {
        ability.inputBufferTimeLeft -= fixedDt;
        if (ability.inputBufferTimeLeft <= 0f) ability.isInputBuffered = false;
    }
}
```
This lets a press land slightly before the ability is off-cooldown and still cast.
`CharAbilities.IsAbilityBeingCanceled` (`CharAbilities.cs:350-360`) uses `priority` +
`isInputBuffered` to decide which queued ability wins.

### 7.3 Per-ability cast styles (all read the same `cmd` by `cmdId`)
Abilities read their own slot in `Tick(fixedDt, cmd, isResim)` via `(int)ability.cmdId`:

- **Tap / instant:** `if (cmd.GetKeyDown((int)ability.cmdId) || ability.isInputBuffered)`
  e.g. `FireyEmpoweredDashAbility.cs:61,286`.
- **Hold → release (charge):** `AimSubroutine.cs:43-58`, `ChargeImpulseAbility.cs:139`
  (`cmd.GetKeyUp((int)cmdId) || !cmd.GetKeyHold((int)cmdId)` ends the charge),
  `AB_BrainFreeze.cs:86-94`.
- **Cancel:** `cmd.GetKeyDown(8)` = `CommandId.CancelAbility`
  (`AimSubroutine.cs:43`, `MechJetpackAbility.cs:169`, `CelesteBlockAbility.cs:118`).
- **Move-cancels-aim:** abilities check `cmd.keyDowns != 0` / movement to break aim states.

### 7.4 Item/drop/interact commands — `CharItems`
`GEHEIMBUILD\…\Entities\CharItems.cs:156-188` reads the same bitmask by bit index:
```csharp
if (cmd.GetKeyDown(10)) … Drop1;  if (cmd.GetKeyDown(11)) … Drop2;
if (cmd.GetKeyDown(12)) … Drop3;  if (cmd.GetKeyDown(13)) … Drop4;
if (cmd.GetKeyDown(17)) … DropGold;
if (cmd.GetKeyDown(14)) … DropConsumable1; …(15)… ;(16)… ;
if (cmd.GetKeyDown(18)) … DropAbility;
```
This confirms abilities own bits 0–9 (plus cancel/heal) and items own 10–21.

### 7.5 CastFlags
Casting state is also mirrored into `CharAbilities.castFlags` via
`CastFlagsHelper.GetCastFlagByAbility(cmdId)` (e.g. `DigitalCloneUpgradeAbility.cs:49`,
`MechJetpackAbility.cs:369`). `CastFlags.Ability1/2/8` etc. are a parallel bitset used for
"is this slot currently casting / cancel masks". `CharAbilities.SetCastAbility/ResetCastAbility`
toggle these (this is the hook the failed mod abused — see §9).

### 7.6 Quick-cast
`Command.quickCastAbilities` (set from `InputManager.quickCastAbilities`, `:269`) flips
behavior between aim-then-confirm vs immediate cast on key-down.

---

## 8. UI / HUD mapping

`GEHEIMBUILD\…\UI\UIAbilities.cs` + `UIAbilityElement.cs`:

- `UIAbilities` holds `ability1..ability4` `UIAbilityElement`s, plus `abilityConsumable[]`,
  `abilityLootable`, and a runtime `abilityElementsByCmdId[]` array. `SetMainAbilityCount(4)`
  is the default 4-slot HUD.
- `UIAbilityElement.target` (`InputTarget`) + `_cmdId` (`int`) tie a HUD slot to its input.
  `SetInputIcon(InputBinding, isGamepad)` + `UIInputIcon.SetInput` render the key glyph
  (LMB/RMB/Space/E or gamepad sprite) using `GetKeyCodeName` (§3.1).
- `UIAbilities.GetInputTargetByAbilityId(int)` and `InputManager.GetInputTargetByAbilityCmd`
  resolve `CommandId → InputTarget` so the icon shows the correct (possibly rebound) key.
- Cooldown/ready/active/silenced visuals are addressed by `cmdId`
  (`Ability.cs:233-241,515-523` call `uiAbilities.LoadIcon/SetReadyState/.../((int)cmdId)`).

---

## 9. Why the previous clone mod's input/abilities broke (R12 lens)

From `…\BAPBAPModdingAPI\bapcustomchars-mod\MedusaMod.cs`:

1. **It bypassed the `Command` pipeline.** Instead of letting `cmdInputBindings` →
   `ConsumeButtons` → `cmd` → `CmdBufferSystem` drive casts, it polled raw input on a 0.05s
   timer in `PollLocalInputCastFx`:
   ```csharp
   if (Input.GetMouseButtonDown(0) || GetKeyDown(Alpha1))          slot=0; // LMB
   else if (Input.GetMouseButtonDown(1) || GetKeyDown(Q) || Alpha2) slot=1; // RMB OR Q
   else if (GetKeyDown(Space) || F || Alpha3)                       slot=2; // Space
   else if (GetKeyDown(E) || R || Alpha4)                           slot=3; // E
   ```
   This is **client-local only** and **not networked/predicted** → other players never see
   the cast (matches "visuals/attacks were only local"), and the `slot` was a hard-coded
   guess rather than the ability's real `cmdId`.

2. **It hooked `CharAbilities.SetCastAbility(CastFlags)`** and translated the flag back to a
   slot (`slot0→CastFlags 1, 1→2, 2→4, 3→8` in `TryRunMedusaAbilityDriverFromCastFlag`),
   then ran its own ad-hoc damage/FX driver. Because the real abilities were Kitsu clones,
   their `cmdId`s and behaviors were still Kitsu's — so RMB/Space/E either no-op'd
   ("green dot", "Space bugs out") or fell through to the inherited Kitsu ability.

3. **Animation states are named by `cmdId`.** Ability subroutines play
   `new AnimSubroutine(this, AnimAction.Play, cmdId.ToString(), animLayer)` — i.e. the
   Animator state is literally `"Ability1"`, `"Ability2"`, `"Ability4"`, etc.
   (`FireyChargedProjectileAbility.cs:279`, `MechJetpackAbility.cs:400`,
   `DigitalCloneAbility.cs:465`, `CelesteBlockAbility.cs:281`; the mod's own
   `PlayMedusaAbilityAnimation` mirrors this with `"Ability1".."Ability4"`). A cloned
   character whose Animator controller only contains **Kitsu's** clips under those state
   names will *play Kitsu's animation* for "E" — exactly the reported `Ability4` symptom.

**R12 takeaway for a correct from-scratch integration:**
- Author real `Ability` components on the character prefab, each with the correct
  `CommandId cmdId` (LMB=Ability1, slot2=Ability2, Space=Ability3, E=Ability4, +Ability5…8
  as needed). Do **not** poll `Input.*` directly.
- Let the native chain drive casting: the engine already maps key → `cmdInputBindings[bit]`
  → `Command` (networked) → `CmdBufferSystem`/`Ability.Tick` via `cmd.GetKeyDown((int)cmdId)`.
  This is what makes casts authoritative, predicted, and visible to all clients.
- Provide an Animator controller that actually contains states named after the `cmdId`s the
  abilities use (`"Ability1"`, `"Ability2"`, …) so each slot plays the intended clip instead
  of the base char's.
- HUD/keys come for free: set `UIAbilityElement.target`/`cmdId` (or supply `customUIData`)
  and the icon/keybind glyph resolves through `GetInputTargetByAbilityCmd`/`GetKeyCodeName`.

---

## 10. Citation index

| Fact | File:line (build) |
|---|---|
| `InputTarget` enum values | `_DisabledScripts\…\Local\InputTarget.cs` |
| `CommandId` enum values | `_DisabledScripts\…\Local\CommandId.cs` |
| Ability slot tooltip (LMB/Q/Space/E) | `…\Entities\Ability.cs:18-20` (both builds) |
| `cmdInputBindings` order / bit table | GEHEIMBUILD `…\Local\InputManager.cs:108-150` |
| `cachedCmdLmbId = 0` (LMB/UI guard) | GEHEIMBUILD `InputManager.cs:150,216,283` |
| Frame buffering | GEHEIMBUILD `InputManager.cs:212-235` |
| Pack buttons + movement | GEHEIMBUILD `InputManager.cs:281-308` |
| Aim raycast `worldMousePos` | GEHEIMBUILD `InputManager.cs:310-322` |
| HUD-click → command | GEHEIMBUILD `InputManager.cs:155-205` |
| `GetInputTargetByAbilityCmd` | GEHEIMBUILD `InputManager.cs:355-369` |
| `Command` bitmask + GetKeyDown | GEHEIMBUILD `…\Local\Command.cs` |
| `InputBinding.GetPressed/Held/Released` | GEHEIMBUILD `…\Local\InputBinding.cs` |
| defaults dict + `GetDefaultInputKey` | GEHEIMBUILD `…\Local\InputSystem.cs:365-373,374+` |
| KBM movement axis from up/down/left/right | GEHEIMBUILD `InputSystem.cs:375-378,421-426` |
| `GetKeyCodeName` (Mouse0→LMB, Mouse1→RMB…) | GEHEIMBUILD `InputSystem.cs:374+` |
| `InputMode` enum (incl. KBMButtonUp) | `_DisabledScripts\…\Local\InputMode.cs` |
| `GamepadKeyCode` enum | `_DisabledScripts\…\Local\GamepadKeyCode.cs` |
| Input buffering loop | GEHEIMBUILD `…\Entities\CmdBufferSystem.cs:18-36` |
| Ability `cmdId` field + buffer fields | GEHEIMBUILD `…\Entities\Ability.cs:20,165-168` |
| Cancel = bit 8; hold/release casts | GEHEIMBUILD `AimSubroutine.cs:43-58`, `ChargeImpulseAbility.cs:139`, `MechJetpackAbility.cs:169-173`, `AB_BrainFreeze.cs:86-94` |
| Drops/interact bit indices | GEHEIMBUILD `…\Entities\CharItems.cs:156-188` |
| Animator state named by `cmdId.ToString()` | GEHEIMBUILD `FireyChargedProjectileAbility.cs:279`, `MechJetpackAbility.cs:400`, `DigitalCloneAbility.cs:465`, `CelesteBlockAbility.cs:281` |
| HUD slots / icon-by-cmdId | GEHEIMBUILD `…\UI\UIAbilities.cs`, `UIAbilityElement.cs`, `UIInputIcon.cs` |
| Failed mod manual input poll | `…\bapcustomchars-mod\MedusaMod.cs` `PollLocalInputCastFx`, `TryRunMedusaAbilityDriverFromCastFlag`, `PlayMedusaAbilityAnimation` |
