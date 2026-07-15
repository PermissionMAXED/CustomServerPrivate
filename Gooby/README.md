# Gooby

Gooby is an original, iOS-only 3D virtual-pet game about a chubby rabbit with a big
personality. The app is built with native SwiftUI and non-AR RealityKit for iOS 17 and
newer. The current vertical slice persists Gooby’s needs and care history across launches,
renders Gooby and four rooms entirely from RealityKit primitives, and supports feeding,
washing, petting, playing, and sleeping.

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

The UI test uses `--ui-testing --reset-save --skip-welcome --fixed-time <epoch-seconds>`
to exercise a deterministic, still-persistent save without replacing production state with
a mock. Its care journey covers kitchen feed, washroom clean, universal pet, and bedroom
sleep, and stores a Gooby home screenshot in the Xcode result bundle.
