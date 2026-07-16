import Foundation
import GoobyCore
import GoobyPersistence
import Observation

@MainActor
protocol GameClock: AnyObject {
    func now() -> GameInstant
    func localDay(at instant: GameInstant) -> LocalDayKey
}

extension GameClock {
    func localDay(at instant: GameInstant) -> LocalDayKey {
        DailyRewardSchedule.localDayKey(for: instant, timeZone: .autoupdatingCurrent)
    }
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

struct GameEventBatch: Identifiable, Equatable {
    let id: UInt64
    let events: [GameEvent]
}

enum GameStorePhase: Equatable {
    case idle
    case loading
    case ready
    case failed
    case recoveryRequired
}

enum GameLifecycleState: Equatable {
    case active
    case inactive
    case background
}

@MainActor
@Observable
final class GameStore {
    private(set) var phase: GameStorePhase = .idle
    private(set) var state: GameState?
    private(set) var latestEvents: [GameEvent] = []
    private(set) var eventRevision = 0
    private(set) var eventBatches: [GameEventBatch] = []
    private(set) var loadSource: GameStateLoadSource?
    private(set) var errorMessage: String?
    private(set) var rewardNotices: [RewardNotice] = []
    var showsWelcome = false
    let usesShortMinigameCountdown: Bool

    @ObservationIgnored private let repository: any GameStateRepository
    @ObservationIgnored private let clock: any GameClock
    @ObservationIgnored private let audio: any AudioFeedbackClient
    @ObservationIgnored private let haptics: any HapticFeedbackClient
    @ObservationIgnored private let freshSaveHint: Bool
    @ObservationIgnored private let skipsWelcome: Bool
    @ObservationIgnored private let minuteTickDuration: Duration
    @ObservationIgnored private var operationTail: Task<Void, Never>?
    @ObservationIgnored private var minuteTicker: Task<Void, Never>?
    @ObservationIgnored private var nextEventBatchID: UInt64 = 1
    @ObservationIgnored private var lifecycleState: GameLifecycleState = .active

    init(
        repository: any GameStateRepository,
        clock: any GameClock,
        audio: any AudioFeedbackClient,
        haptics: any HapticFeedbackClient,
        freshSaveHint: Bool = false,
        skipsWelcome: Bool = false,
        usesShortMinigameCountdown: Bool = false,
        minuteTickDuration: Duration = .seconds(60)
    ) {
        self.repository = repository
        self.clock = clock
        self.audio = audio
        self.haptics = haptics
        self.freshSaveHint = freshSaveHint
        self.skipsWelcome = skipsWelcome
        self.usesShortMinigameCountdown = usesShortMinigameCountdown
        self.minuteTickDuration = minuteTickDuration
    }

    func start() async {
        await enqueue { await self.performStart() }
    }

    private func performStart() async {
        guard phase != .loading else { return }
        phase = .loading
        errorMessage = nil

        do {
            let instant = clock.now()
            let result = try await repository.load(now: instant)
            var loaded = result.state
            var events = GameSimulation.advanceAfterAbsence(&loaded, to: instant)
            events.append(
                contentsOf: GameEngine.reconcileProgression(&loaded, at: instant)
            )
            try await repository.save(loaded, at: instant)
            state = loaded
            loadSource = result.source
            publish(events)
            showsWelcome = freshSaveHint && !skipsWelcome
            phase = .ready
            applyFeedbackPreferences(loaded.preferences)
            startMinuteTickerIfNeeded()
        } catch let recovery as SaveRecoveryRequired {
            phase = .recoveryRequired
            errorMessage = Self.recoveryMessage(for: recovery)
        } catch {
            phase = .failed
            errorMessage = Self.message(for: error)
        }
    }

    func advance() async {
        await enqueue { await self.performForegroundAdvance() }
    }

    private func performForegroundAdvance() async {
        guard phase == .ready, var candidate = state else { return }
        let instant = clock.now()
        let events = GameSimulation.advanceForeground(&candidate, to: instant)
        guard !events.isEmpty else { return }

        do {
            try await repository.save(candidate, at: instant)
            state = candidate
            publish(events)
        } catch {
            record(error)
        }
    }

    @discardableResult
    func dispatch(_ command: GameCommand) async -> Bool {
        await enqueue { await self.performDispatch(command) }
    }

    private func performDispatch(_ command: GameCommand) async -> Bool {
        guard phase == .ready, var candidate = state else { return false }
        let instant = clock.now()

        do {
            let events = try GameEngine.apply(
                command,
                to: &candidate,
                at: instant,
                localDay: clock.localDay(at: instant)
            )
            try await repository.save(candidate, at: instant)
            state = candidate
            publish(events)
            applyFeedbackPreferences(candidate.preferences)
            playFeedback(for: events)
            errorMessage = nil
            return true
        } catch {
            record(error)
            return false
        }
    }

    func flush() async {
        await enqueue { await self.performFlush() }
    }

    private func performFlush() async {
        guard let state else { return }
        do {
            try await repository.save(state, at: clock.now())
        } catch {
            record(error)
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
        await enqueue {
            guard let run = self.state?.activeMinigame, !run.isPaused else { return }
            _ = await self.performDispatch(.pauseMinigame(runID: run.id))
        }
    }

    func resumeActiveMinigame() async -> Bool {
        await enqueue {
            guard let run = self.state?.activeMinigame, run.isPaused else { return false }
            return await self.performDispatch(.resumeMinigame(runID: run.id))
        }
    }

    func resetProgress() async -> Bool {
        await enqueue { await self.performReset(discardingDamagedSave: false) }
    }

    func resetDamagedSave() async -> Bool {
        await enqueue { await self.performReset(discardingDamagedSave: true) }
    }

    private func performReset(discardingDamagedSave: Bool) async -> Bool {
        guard phase == .ready || (discardingDamagedSave && phase == .recoveryRequired) else {
            return false
        }
        do {
            let reset = try await repository.reset(
                now: clock.now(),
                discardingDamagedSave: discardingDamagedSave
            )
            state = reset
            loadSource = .primary
            latestEvents = []
            eventBatches = []
            rewardNotices = []
            let resetRevision = nextEventBatchID
            nextEventBatchID = resetRevision == UInt64.max
                ? resetRevision
                : resetRevision + 1
            eventRevision = resetRevision > UInt64(Int.max)
                ? Int.max
                : Int(resetRevision)
            applyFeedbackPreferences(reset.preferences)
            errorMessage = nil
            phase = .ready
            startMinuteTickerIfNeeded()
            return true
        } catch {
            record(error)
            return false
        }
    }

    func handleLifecycleTransition(_ transition: GameLifecycleState) async {
        await enqueue { await self.performLifecycleTransition(transition) }
    }

    private func performLifecycleTransition(_ transition: GameLifecycleState) async {
        guard lifecycleState != transition else { return }
        lifecycleState = transition
        switch transition {
        case .active:
            guard phase == .ready, var candidate = state else { return }
            let instant = clock.now()
            let events = GameSimulation.advanceAfterAbsence(&candidate, to: instant)
            do {
                if !events.isEmpty {
                    try await repository.save(candidate, at: instant)
                    state = candidate
                    publish(events)
                }
                errorMessage = nil
                startMinuteTickerIfNeeded()
            } catch {
                record(error)
            }
        case .inactive, .background:
            stopMinuteTicker()
            guard phase == .ready else { return }
            if let run = state?.activeMinigame, !run.isPaused {
                _ = await performDispatch(.pauseMinigame(runID: run.id))
            } else {
                await performFlush()
            }
        }
    }

    private func enqueue<T>(
        _ operation: @escaping @MainActor () async -> T
    ) async -> T {
        let predecessor = operationTail
        let task = Task { @MainActor in
            await predecessor?.value
            return await operation()
        }
        operationTail = Task { @MainActor in
            _ = await task.value
        }
        return await task.value
    }

    private func startMinuteTickerIfNeeded() {
        guard minuteTicker == nil, phase == .ready, lifecycleState == .active else { return }
        let tickDuration = minuteTickDuration
        minuteTicker = Task { @MainActor [weak self] in
            while !Task.isCancelled {
                do {
                    try await Task.sleep(for: tickDuration)
                } catch {
                    return
                }
                guard !Task.isCancelled, let self else { return }
                await self.advance()
            }
        }
    }

    private func stopMinuteTicker() {
        minuteTicker?.cancel()
        minuteTicker = nil
    }

    private func record(_ error: Error) {
        if let recovery = error as? SaveRecoveryRequired {
            stopMinuteTicker()
            phase = .recoveryRequired
            errorMessage = Self.recoveryMessage(for: recovery)
        } else {
            errorMessage = Self.message(for: error)
        }
    }

    var dailyEligibility: DailyRewardEligibility? {
        guard let state else { return nil }
        let instant = clock.now()
        return DailyRewardSchedule.eligibility(
            for: state.dailyReward,
            at: instant,
            localDay: clock.localDay(at: instant),
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

    func remainingCarrotCatchSeconds(for run: ActiveMinigameRun) -> Int {
        guard case let .carrotCatch(progress) = run.progress else { return 0 }
        var elapsed = max(0, progress.accumulatedPlayingSeconds)
        if let playingAt = progress.lastPlayingAt {
            let now = clock.now().secondsSinceEpoch
            let (additional, overflowed) = now.subtractingReportingOverflow(
                playingAt.secondsSinceEpoch
            )
            if !overflowed, additional > 0 {
                let (total, totalOverflowed) = elapsed.addingReportingOverflow(additional)
                elapsed = totalOverflowed ? .max : total
            }
        }
        return max(
            0,
            CarrotCatch.standardDurationSeconds - Int(min(elapsed, Int64(Int.max)))
        )
    }

    private func publish(_ events: [GameEvent]) {
        latestEvents = events
        if !events.isEmpty {
            let identifier = nextEventBatchID
            nextEventBatchID = identifier == UInt64.max ? identifier : identifier + 1
            eventBatches.append(GameEventBatch(id: identifier, events: events))
            eventRevision = identifier > UInt64(Int.max) ? Int.max : Int(identifier)
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
                title: "Visit \(step) gift claimed",
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
        case .invalidSleepTransition:
            return "Gooby is already in that sleep state."
        case .inventoryFull:
            return "That pantry item cannot hold any more."
        }
    }

    private static func recoveryMessage(for _: SaveRecoveryRequired) -> String {
        "Gooby found an existing save that cannot be read safely. "
            + "Your files were preserved; reset only if you want to discard that save."
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
