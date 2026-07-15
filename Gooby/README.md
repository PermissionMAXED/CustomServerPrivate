# Gooby

Gooby is an original, iOS-only 3D virtual-pet game about a chubby rabbit with a big
personality. The app is built with native SwiftUI and non-AR RealityKit for iOS 17 and
newer. The current vertical slice persists Gooby’s needs, collection, rewards, preferences,
and care history across launches; renders Gooby, four rooms, and cosmetics entirely from
RealityKit primitives; and supports feeding, washing, petting, playing, and sleeping.

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
a mock. The care journey covers kitchen feed, washroom clean, universal pet, and bedroom
sleep. The collection journey claims a daily gift, previews and buys the Sunshine Bow,
equips it in the wardrobe, relaunches, verifies the equipped save, and stores an
equipped-Gooby screenshot in the Xcode result bundle.

## Feature matrix

| Area | Gate 3 behavior |
| --- | --- |
| Care | Four persistent needs, room-aware care, selectable owned foods, sleep, and offline fixed-step simulation |
| Daily Gift | Ethical seven-day offline cycle, date rollback protection, atomic claims, and Day 7 Moon Crown |
| Shop | Repeatable food inventory purchases plus permanent, idempotent cosmetic purchases and previews |
| Wardrobe | Owned/locked previews and persisted equip/unequip for head, neck, face, body, and legacy paws slots |
| Bond | Levels 1–10, progress and capped states, level celebrations, and a level 3 Friendship Ribbon |
| Journal | Five achievements with live counters, earned dates, and exactly-once carrot rewards |
| Settings | Validated pet rename, persisted sound/haptics/motion preferences, offline privacy copy, and confirmed reset |
| Privacy | Fully offline; no accounts, networking, analytics, ads, or in-app purchases |

## Controls

- Tap Gooby to pet; use the room chips and primary care button to feed, wash, play,
  tuck in, or wake.
- In the kitchen, use **Owned food** to choose a pantry item before feeding.
- Home links directly to **Daily Gift**, **Shop**, **Wardrobe**, **Journal**, and
  **Arcade**; the gear opens Settings.
- Shop rows open item details and cosmetic previews. Wardrobe rows preview even locked
  items, while Equip is available only for owned cosmetics.
- All controls expose VoiceOver labels and support Dynamic Type. Gooby honors the iOS
  Reduce Motion setting and the in-app motion preference.
