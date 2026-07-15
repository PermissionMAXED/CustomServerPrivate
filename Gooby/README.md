# Gooby

Gooby is an original, iOS-only 3D virtual-pet game about a chubby rabbit with a big
personality. The app is built with native SwiftUI and non-AR RealityKit for iOS 17 and
newer. Gate 1 establishes the deterministic game rules and persistence boundary; the
current app screen is intentionally a branded placeholder, not simulated gameplay.

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
- `App`: minimal SwiftUI iOS shell. `project.yml` is the XcodeGen source of truth.

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
```

Open the generated `Gooby.xcodeproj` for local app development. Do not hand-edit that
project: update `project.yml`, regenerate, and commit only the declarative source.
