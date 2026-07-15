import Foundation
import GoobyCore
import GoobyPersistence
import Observation

@MainActor
protocol GameClock: AnyObject {
    func now() -> GameInstant
}

@MainActor
final class SystemGameClock: GameClock {
    func now() -> GameInstant {
        GameInstant(date: Date())
    }
}

enum FeedbackCue: Equatable {
    case feed
    case wash
    case pet
    case play
    case sleep
    case wake
    case room
    case reward
}

@MainActor
protocol AudioFeedbackClient: AnyObject {
    func play(_ cue: FeedbackCue)
    func setAmbientEnabled(_ enabled: Bool)
}

@MainActor
protocol HapticFeedbackClient: AnyObject {
    func impact(_ cue: FeedbackCue)
}

enum GameStorePhase: Equatable {
    case idle
    case loading
    case ready
    case failed
}

@MainActor
@Observable
final class GameStore {
    private(set) var phase: GameStorePhase = .idle
    private(set) var state: GameState?
    private(set) var latestEvents: [GameEvent] = []
    private(set) var eventRevision = 0
    private(set) var errorMessage: String?
    var showsWelcome = false

    @ObservationIgnored private let repository: any GameStateRepository
    @ObservationIgnored private let clock: any GameClock
    @ObservationIgnored private let audio: any AudioFeedbackClient
    @ObservationIgnored private let haptics: any HapticFeedbackClient
    @ObservationIgnored private let freshSaveHint: Bool
    @ObservationIgnored private let skipsWelcome: Bool

    init(
        repository: any GameStateRepository,
        clock: any GameClock,
        audio: any AudioFeedbackClient,
        haptics: any HapticFeedbackClient,
        freshSaveHint: Bool = false,
        skipsWelcome: Bool = false
    ) {
        self.repository = repository
        self.clock = clock
        self.audio = audio
        self.haptics = haptics
        self.freshSaveHint = freshSaveHint
        self.skipsWelcome = skipsWelcome
    }

    func start() async {
        guard phase != .loading else { return }
        phase = .loading
        errorMessage = nil

        do {
            let instant = clock.now()
            var loaded = try await repository.load(now: instant)
            let events = GameSimulation.advance(&loaded, to: instant)
            try await repository.save(loaded, at: instant)
            state = loaded
            publish(events)
            showsWelcome = freshSaveHint && !skipsWelcome
            phase = .ready
            audio.setAmbientEnabled(true)
        } catch {
            phase = .failed
            errorMessage = Self.message(for: error)
        }
    }

    func advance() async {
        guard phase == .ready, var candidate = state else { return }
        let instant = clock.now()
        let events = GameSimulation.advance(&candidate, to: instant)
        guard !events.isEmpty else { return }

        do {
            try await repository.save(candidate, at: instant)
            state = candidate
            publish(events)
        } catch {
            errorMessage = Self.message(for: error)
        }
    }

    @discardableResult
    func dispatch(_ command: GameCommand) async -> Bool {
        guard phase == .ready, var candidate = state else { return false }
        let instant = clock.now()

        do {
            let events = try GameEngine.apply(command, to: &candidate, at: instant)
            try await repository.save(candidate, at: instant)
            state = candidate
            publish(events)
            playFeedback(for: events)
            errorMessage = nil
            return true
        } catch {
            errorMessage = Self.message(for: error)
            return false
        }
    }

    func flush() async {
        guard let state else { return }
        do {
            try await repository.save(state, at: clock.now())
        } catch {
            errorMessage = Self.message(for: error)
        }
    }

    func dismissWelcome() {
        showsWelcome = false
    }

    func clearError() {
        errorMessage = nil
    }

    var mood: String {
        guard let state else { return "Settling in" }
        if state.isSleeping { return "Dreamy" }
        let lowest = [
            state.needs.fullness.value,
            state.needs.cleanliness.value,
            state.needs.energy.value,
            state.needs.fun.value,
        ].min() ?? 0
        switch lowest {
        case 750 ... 1_000: return "Bouncy"
        case 500 ..< 750: return "Cozy"
        case 300 ..< 500: return "Needs a little care"
        default: return "Needs you"
        }
    }

    private func publish(_ events: [GameEvent]) {
        latestEvents = events
        if !events.isEmpty {
            eventRevision += 1
        }
    }

    private func playFeedback(for events: [GameEvent]) {
        let cue = events.reversed().compactMap(Self.cue(for:)).first
        guard let cue else { return }
        audio.play(cue)
        haptics.impact(cue)
    }

    private static func cue(for event: GameEvent) -> FeedbackCue? {
        switch event {
        case .fed: .feed
        case .washed: .wash
        case .petted: .pet
        case .played: .play
        case let .sleepChanged(sleeping): sleeping ? .sleep : .wake
        case .moved: .room
        case .achievementUnlocked, .dailyRewardClaimed, .purchased: .reward
        default: nil
        }
    }

    private static func message(for error: Error) -> String {
        guard let rule = error as? GameRuleError else {
            return "Gooby’s save could not be updated. Please try again."
        }

        switch rule {
        case let .wrongRoom(room):
            return "Visit the \(room.displayName.lowercased()) for that care action."
        case .petIsSleeping:
            return "Gooby is sleeping. Wake Gooby before petting."
        case let .insufficientCarrots(required, available):
            return "That needs \(required) carrots; you have \(available)."
        case let .insufficientEnergy(required, available):
            return "Gooby needs \(required)% energy to play; energy is \(available / 10)%."
        case .dailyRewardAlreadyClaimed:
            return "Today’s cozy carrot reward is already claimed."
        case .clockRollback:
            return "The device clock moved backward. Try again later."
        case .minigameAlreadyActive:
            return "Finish the current arcade game first."
        case .noActiveMinigame, .invalidMinigameRun, .invalidMinigameSubmission, .minigameExpired:
            return "That arcade run is no longer available."
        case .unknownItem, .itemNotOwned, .itemNotEquippable:
            return "That item is not available."
        case .itemLocked, .featureLocked:
            return "Grow your bond with Gooby to unlock that."
        }
    }
}

extension RoomID {
    var displayName: String {
        switch self {
        case .kitchen: "Kitchen"
        case .washroom: "Washroom"
        case .bedroom: "Bedroom"
        case .playroom: "Playroom"
        }
    }

    var symbolName: String {
        switch self {
        case .kitchen: "carrot.fill"
        case .washroom: "drop.fill"
        case .bedroom: "moon.fill"
        case .playroom: "figure.play"
        }
    }
}
