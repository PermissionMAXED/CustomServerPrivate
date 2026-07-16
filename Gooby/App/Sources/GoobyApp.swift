import Foundation
import GoobyCore
import GoobyPersistence
import SwiftUI

@main
struct GoobyApp: SwiftUI.App {
    @Environment(\.scenePhase) private var scenePhase
    @State private var store: GameStore

    init() {
        let launch = GoobyLaunchSettings.current
        let fileManager = FileManager.default
        let baseDirectory = fileManager.urls(
            for: .applicationSupportDirectory,
            in: .userDomainMask
        ).first ?? fileManager.temporaryDirectory
        let directory = baseDirectory.appendingPathComponent("Gooby", isDirectory: true)
        let fileName = launch.isUITesting ? "gooby-ui-test-save.json" : "gooby-save.json"
        let repository = JSONSaveStore(directoryURL: directory, fileName: fileName)

        if launch.resetsSave {
            try? fileManager.removeItem(at: repository.primaryURL)
            try? fileManager.removeItem(at: repository.backupURL)
        }

        let isFresh = !fileManager.fileExists(atPath: repository.primaryURL.path)
            && !fileManager.fileExists(atPath: repository.backupURL.path)
        let clock: any GameClock
        if let fixedTime = launch.fixedTime {
            clock = FixedGameClock(instant: fixedTime)
        } else {
            clock = SystemGameClock()
        }

        _store = State(
            initialValue: GameStore(
                repository: repository,
                clock: clock,
                audio: ProceduralAudioClient(),
                haptics: SystemHapticClient(),
                freshSaveHint: isFresh,
                skipsWelcome: launch.skipsWelcome,
                usesShortMinigameCountdown: launch.usesShortMinigameCountdown
            )
        )
    }

    var body: some SwiftUI.Scene {
        WindowGroup {
            AppRootView(store: store)
                .task {
                    await store.start()
                }
                .onChange(of: scenePhase) { _, phase in
                    Task {
                        switch phase {
                        case .active:
                            await store.advance()
                        case .inactive, .background:
                            await store.pauseActiveMinigame()
                            await store.flush()
                        @unknown default:
                            await store.flush()
                        }
                    }
                }
        }
    }
}

@MainActor
private final class FixedGameClock: GameClock {
    let instant: GameInstant

    init(instant: GameInstant) {
        self.instant = instant
    }

    func now() -> GameInstant {
        instant
    }
}

struct GoobyLaunchSettings: Equatable {
    let isUITesting: Bool
    let resetsSave: Bool
    let skipsWelcome: Bool
    let fixedTime: GameInstant?
    let usesShortMinigameCountdown: Bool

    static var current: GoobyLaunchSettings {
        parse(arguments: ProcessInfo.processInfo.arguments)
    }

    static func parse(arguments: [String]) -> GoobyLaunchSettings {
        #if DEBUG
        let isUITesting = arguments.contains("--ui-testing")
        guard isUITesting else {
            return production
        }

        let fixedTime: GameInstant?
        if let index = arguments.firstIndex(of: "--fixed-time"),
           arguments.indices.contains(index + 1),
           let seconds = Int64(arguments[index + 1]) {
            fixedTime = GameInstant(secondsSinceEpoch: seconds)
        } else {
            fixedTime = nil
        }

        return GoobyLaunchSettings(
            isUITesting: true,
            resetsSave: arguments.contains("--reset-save"),
            skipsWelcome: arguments.contains("--skip-welcome"),
            fixedTime: fixedTime,
            usesShortMinigameCountdown: arguments.contains("--short-minigames")
        )
        #else
        _ = arguments
        return production
        #endif
    }

    private static let production = GoobyLaunchSettings(
        isUITesting: false,
        resetsSave: false,
        skipsWelcome: false,
        fixedTime: nil,
        usesShortMinigameCountdown: false
    )
}
