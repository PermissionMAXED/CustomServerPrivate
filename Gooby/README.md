# Gooby

Gooby is an original, iOS-only 3D virtual-pet game about a chubby rabbit with a big
personality. The app is built with native SwiftUI and non-AR RealityKit for iOS 17 and
newer. The current vertical slice persists Gooby’s needs, collection, rewards, preferences,
and care history across launches; renders Gooby, four rooms, and cosmetics entirely from
RealityKit primitives; supports feeding, washing, petting, playing, and sleeping; and
includes two complete deterministic pocket-arcade games.

All characters, names, rules, code, and procedural art in this directory are original to
Gooby. The product has no advertising, tracking, in-app purchases, networking,
third-party runtime dependencies, or downloaded assets. It is designed to work fully
offline. `App/Resources/PrivacyInfo.xcprivacy` declares that no data is tracked or
collected.

## Architecture

- `GoobyCore`: deterministic state, fixed-step simulation, care/economy rules, rewards,
  achievements, seeded RNG, and pure minigames.
- `GoobyPersistence`: versioned JSON envelopes and an actor-isolated primary/backup save
  repository.
- `App`: an observable persistent game store, SwiftUI care shell, procedural audio/haptics,
  and non-AR RealityKit factories/coordinator. `project.yml` is the XcodeGen source of
  truth.

The pure libraries and their tests run on Linux through Swift Package Manager. XcodeGen
and iOS app builds run on macOS in CI.

## Commands

```sh
swift package --package-path Gooby dump-package
swift build --package-path Gooby -Xswiftc -warnings-as-errors
swift test --package-path Gooby --parallel -Xswiftc -warnings-as-errors
python3 Gooby/Scripts/generate_app_icon.py
```

On macOS with Xcode 16 or newer:

```sh
brew install xcodegen
cd Gooby
xcodegen generate
xcodebuild -project Gooby.xcodeproj -scheme Gooby \
  -sdk iphonesimulator -destination 'generic/platform=iOS Simulator' \
  CODE_SIGNING_ALLOWED=NO build

# Unit + UI tests on an available iPhone simulator
xcodebuild -project Gooby.xcodeproj -scheme Gooby \
  -destination 'platform=iOS Simulator,id=<simulator-udid>' \
  -resultBundlePath TestResults/Gooby.xcresult \
  CODE_SIGNING_ALLOWED=NO test
```

Open the generated `Gooby.xcodeproj` for local app development. Do not hand-edit that
project: update `project.yml`, regenerate, and commit only the declarative source.

The UI tests use `--ui-testing --reset-save --skip-welcome --fixed-time <epoch-seconds>`
to exercise a deterministic, still-persistent save without replacing production state with
a mock. Debug UI tests may also pass `--short-minigames`; this shortens only presentation
delays/countdowns while preserving every seeded target, score, and reward. The care journey
covers kitchen feed, washroom clean, universal pet, and bedroom sleep. The collection
journey claims a daily gift, previews and buys the Sunshine Bow, equips it, and verifies it
after relaunch. Arcade journeys finish both games and attach their result screens. These
arguments are ignored by Release builds.

## Feature matrix

| Area | Gate 4 behavior |
| --- | --- |
| Care | Four persistent needs, room-aware care, selectable owned foods, sleep, and offline fixed-step simulation |
| Daily Gift | Ethical seven-day offline cycle, date rollback protection, atomic claims, and Day 7 Moon Crown |
| Shop | Repeatable food inventory purchases plus permanent, idempotent cosmetic purchases and previews |
| Wardrobe | Owned/locked previews and persisted equip/unequip for head, neck, face, body, and legacy paws slots |
| Bond | Levels 1–10, progress and capped states, level celebrations, and a level 3 Friendship Ribbon |
| Journal | Five achievements with live counters, earned dates, and exactly-once carrot rewards |
| Settings | Validated pet rename, persisted sound/haptics/motion preferences, offline privacy copy, and confirmed reset |
| Carrot Catch | 30-second, three-lane, 20-target seeded game with core-owned scoring, pause/background safety, relaxed timing, results, best score, and exactly-once rewards |
| Garden Echo | Seeded four-pad sequence through five capped rounds, distinct symbols/numbers/pitches/haptics, replay, three-mistake retry model, no input timer, results, and exactly-once rewards |
| Arcade | Rules and best scores for both games, validated start/finish/cancel commands, persisted active runs, restart, Playroom link, and procedural feedback |
| Privacy | Fully offline; no accounts, networking, analytics, ads, or in-app purchases |

## Controls

- Tap Gooby to pet; use the room chips and primary care button to feed, wash, play,
  tuck in, or wake.
- In the kitchen, use **Owned food** to choose a pantry item before feeding.
- Home links directly to **Daily Gift**, **Shop**, **Wardrobe**, **Journal**, and
  **Arcade**; the gear opens Settings.
- **Carrot Catch:** press the large **Left**, **Center**, or **Right** button matching
  the displayed lane. Pause at any time or enable Relaxed Timing; both keep the same
  targets and rewards.
- **Garden Echo:** listen to the numbered **Leaf**, **Moon**, **Star**, and **Berry**
  pads, then repeat them. Use **Replay Sequence** as often as needed; input has no timer.
- Shop rows open item details and cosmetic previews. Wardrobe rows preview even locked
  items, while Equip is available only for owned cosmetics.

## Accessibility

- Every game action has a button-only path with at least a 44-point target. The decorative
  RealityKit/2.5D scenes expose concise status while equivalent care/lane/pad controls
  remain available.
- VoiceOver receives labels, values, hints, ordered status announcements, and a spoken
  Garden Echo sequence with manual replay. Carrot Catch automatically offers relaxed
  timing under VoiceOver without reducing score or rewards.
- Symbols, names, lane positions, numbers, pitches, visible status, and haptics make
  gameplay independent of color and audio. Sound and haptics respect persisted toggles.
- Scrollable layouts, adaptive grids, and stacked controls support accessibility Dynamic
  Type. The app honors Differentiate Without Color, Reduce Motion, Reduce Transparency,
  and Button Shapes while avoiding mandatory input timers.
- UI coverage runs targeted hit-region, element-description, text-clipping, and Dynamic
  Type accessibility audits on supported iOS/Xcode versions; tests avoid pixel matching.
