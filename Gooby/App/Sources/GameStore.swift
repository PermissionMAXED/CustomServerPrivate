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
    case carrotCatch(caught: Bool)
    case gardenEcho(symbol: Int)
}

@MainActor
protocol AudioFeedbackClient: AnyObject {
    func play(_ cue: FeedbackCue)
    func setAmbientEnabled(_ enabled: Bool)
}

@MainActor
protocol HapticFeedbackClient: AnyObject {
    func impact(_ cue: FeedbackCue)
    func setEnabled(_ enabled: Bool)
}

struct RewardNotice: Identifiable, Equatable {
    enum Kind: Equatable {
        case reward
        case achievement
        case level
        case unlock
    }

    let id = UUID()
    let kind: Kind
    let title: String
    let detail: String
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
    private(set) var rewardNotices: [RewardNotice] = []
    var showsWelcome = false
    let usesShortMinigameCountdown: Bool
    let usesCondensedDemoMinigames: Bool

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
        skipsWelcome: Bool = false,
        usesShortMinigameCountdown: Bool = false,
        usesCondensedDemoMinigames: Bool = false
    ) {
        self.repository = repository
        self.clock = clock
        self.audio = audio
        self.haptics = haptics
        self.freshSaveHint = freshSaveHint
        self.skipsWelcome = skipsWelcome
        self.usesShortMinigameCountdown = usesShortMinigameCountdown
        self.usesCondensedDemoMinigames = usesCondensedDemoMinigames
    }

    func start() async {
        guard phase != .loading else { return }
        phase = .loading
        errorMessage = nil

        do {
            let instant = clock.now()
            var loaded = try await repository.load(now: instant)
            var events = GameSimulation.advance(&loaded, to: instant)
            events.append(
                contentsOf: GameEngine.reconcileProgression(&loaded, at: instant)
            )
            try await repository.save(loaded, at: instant)
            state = loaded
            publish(events)
            showsWelcome = freshSaveHint && !skipsWelcome
            phase = .ready
            applyFeedbackPreferences(loaded.preferences)
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
            applyFeedbackPreferences(candidate.preferences)
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

    func dismissFirstRewardNotice() {
        guard !rewardNotices.isEmpty else { return }
        rewardNotices.removeFirst()
    }

    func playMinigameFeedback(_ cue: FeedbackCue) {
        audio.play(cue)
        haptics.impact(cue)
    }

    func pauseActiveMinigame() async {
        guard let run = state?.activeMinigame, !run.isPaused else { return }
        _ = await dispatch(.pauseMinigame(runID: run.id))
    }

    func resumeActiveMinigame() async -> Bool {
        guard let run = state?.activeMinigame, run.isPaused else { return false }
        return await dispatch(.resumeMinigame(runID: run.id))
    }

    func resetProgress() async -> Bool {
        guard phase == .ready else { return false }
        do {
            let reset = try await repository.reset(now: clock.now())
            state = reset
            latestEvents = []
            rewardNotices = []
            eventRevision += 1
            applyFeedbackPreferences(reset.preferences)
            errorMessage = nil
            return true
        } catch {
            errorMessage = Self.message(for: error)
            return false
        }
    }

    var dailyEligibility: DailyRewardEligibility? {
        guard let state else { return nil }
        return DailyRewardSchedule.eligibility(
            for: state.dailyReward,
            at: clock.now(),
            cycleCount: GameEngine.dailyCarrotRewards.count
        )
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
        rewardNotices.append(contentsOf: events.compactMap(Self.notice(for:)))
    }

    private func playFeedback(for events: [GameEvent]) {
        let cue = events.reversed().compactMap(Self.cue(for:)).first
        guard let cue else { return }
        audio.play(cue)
        haptics.impact(cue)
    }

    private func applyFeedbackPreferences(_ preferences: GamePreferences) {
        audio.setAmbientEnabled(preferences.soundEnabled)
        haptics.setEnabled(preferences.hapticsEnabled)
    }

    private static func cue(for event: GameEvent) -> FeedbackCue? {
        switch event {
        case .fed: .feed
        case .washed: .wash
        case .petted: .pet
        case .played: .play
        case let .sleepChanged(sleeping): sleeping ? .sleep : .wake
        case .moved: .room
        case .achievementUnlocked, .dailyRewardClaimed, .itemUnlocked,
             .duplicateItemConverted, .purchased, .bondLevelChanged, .minigameFinished: .reward
        case .minigameStarted: .play
        default: nil
        }
    }

    private static func notice(for event: GameEvent) -> RewardNotice? {
        switch event {
        case let .dailyRewardClaimed(step, carrots):
            return RewardNotice(
                kind: .reward,
                title: "Day \(step) gift claimed",
                detail: "+\(carrots) carrots"
            )
        case let .achievementUnlocked(id, carrots):
            return RewardNotice(
                kind: .achievement,
                title: GoobyAchievements.definition(id: id)?.title ?? "Achievement unlocked",
                detail: "+\(carrots) carrots"
            )
        case let .bondLevelChanged(level):
            return RewardNotice(
                kind: .level,
                title: "Bond level \(level)",
                detail: "Your friendship grew."
            )
        case let .itemUnlocked(id):
            return RewardNotice(
                kind: .unlock,
                title: GoobyCatalog.item(id: id)?.name ?? "Keepsake unlocked",
                detail: "Added to the wardrobe."
            )
        case let .duplicateItemConverted(id, carrots):
            return RewardNotice(
                kind: .reward,
                title: "\(GoobyCatalog.item(id: id)?.name ?? "Keepsake") already owned",
                detail: "Converted to +\(carrots) carrots"
            )
        case let .purchased(id):
            return RewardNotice(
                kind: .reward,
                title: "\(GoobyCatalog.item(id: id)?.name ?? "Item") is yours",
                detail: "Saved offline."
            )
        case let .minigameFinished(_, score, carrots):
            return RewardNotice(
                kind: .reward,
                title: "Arcade run complete",
                detail: "\(score) points • +\(carrots) carrots"
            )
        default:
            return nil
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
        case .unknownItem, .itemNotOwned, .itemNotEquippable, .itemNotPurchasable:
            return "That item is not available."
        case .foodNotOwned:
            return "That snack is out of stock. Visit the shop for more."
        case .invalidPetName:
            return "Enter a name that is not blank."
        case let .petNameTooLong(maximum):
            return "Keep Gooby’s name to \(maximum) characters or fewer."
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
