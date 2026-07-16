@testable import Gooby
import GoobyCore
import GoobyPersistence
import RealityKit
import XCTest

final class GoobyAppTests: XCTestCase {
    @MainActor
    func testBrandNameIsStable() {
        XCTAssertEqual(GoobyBrand.name, "Gooby")
        XCTAssertFalse(GoobyBrand.subtitle.isEmpty)
    }

    @MainActor
    func testDebugUITestLaunchSettingsRequireExplicitTestingMode() {
        XCTAssertEqual(
            GoobyLaunchSettings.parse(arguments: [
                "Gooby",
                "--reset-save",
                "--skip-welcome",
                "--fixed-time",
                "1728000000",
                "--short-minigames",
                "--recorded-demo",
            ]),
            GoobyLaunchSettings(
                isUITesting: false,
                resetsSave: false,
                skipsWelcome: false,
                fixedTime: nil,
                usesShortMinigameCountdown: false,
                usesCondensedDemoMinigames: false
            )
        )

        #if DEBUG
            XCTAssertEqual(
                GoobyLaunchSettings.parse(arguments: [
                    "Gooby",
                    "--ui-testing",
                    "--reset-save",
                    "--skip-welcome",
                    "--fixed-time",
                    "1728000000",
                    "--short-minigames",
                    "--recorded-demo",
                ]),
                GoobyLaunchSettings(
                    isUITesting: true,
                    resetsSave: true,
                    skipsWelcome: true,
                    fixedTime: GameInstant(secondsSinceEpoch: 1_728_000_000),
                    usesShortMinigameCountdown: true,
                    usesCondensedDemoMinigames: true
                )
            )
        #endif
    }

    @MainActor
    func testLaunchPersistsAndRelaunchRestoresState() async {
        let repository = InMemoryGameRepository()
        let feedback = FeedbackSpy()
        let first = makeStore(repository: repository, feedback: feedback)

        await first.start()
        XCTAssertEqual(first.phase, .ready)
        let moved = await first.dispatch(.move(to: .kitchen))
        let fed = await first.dispatch(.feed)
        XCTAssertTrue(moved)
        XCTAssertTrue(fed)
        let firstState = first.state

        let second = makeStore(repository: repository, feedback: feedback)
        await second.start()
        let saveCount = await repository.saveCount

        XCTAssertEqual(second.state, firstState)
        XCTAssertGreaterThanOrEqual(saveCount, 3)
    }

    @MainActor
    func testDispatchPublishesEventsPersistsAndPlaysFeedback() async {
        let repository = InMemoryGameRepository()
        let feedback = FeedbackSpy()
        let store = makeStore(repository: repository, feedback: feedback)
        await store.start()

        let succeeded = await store.dispatch(.pet)
        let persisted = await repository.snapshot

        XCTAssertTrue(succeeded)
        XCTAssertTrue(store.latestEvents.contains(.petted))
        XCTAssertEqual(store.eventRevision, 1)
        XCTAssertEqual(feedback.audioCues, [.pet])
        XCTAssertEqual(feedback.hapticCues, [.pet])
        XCTAssertEqual(persisted, store.state)
    }

    @MainActor
    func testMoodTracksNeedsAndSleepingState() async {
        let repository = InMemoryGameRepository()
        let store = makeStore(repository: repository, feedback: FeedbackSpy())
        await store.start()
        XCTAssertEqual(store.mood, "Bouncy")

        _ = await store.dispatch(.move(to: .playroom))
        _ = await store.dispatch(.play)
        XCTAssertEqual(store.mood, "Cozy")

        _ = await store.dispatch(.move(to: .bedroom))
        _ = await store.dispatch(.beginSleep)
        XCTAssertEqual(store.mood, "Dreamy")
    }

    @MainActor
    func testLoadAndSaveFailuresAreRecoverableAndDoNotPublishMockState() async {
        let repository = InMemoryGameRepository()
        await repository.setFailure(.load)
        let store = makeStore(repository: repository, feedback: FeedbackSpy())

        await store.start()

        XCTAssertEqual(store.phase, .failed)
        XCTAssertNil(store.state)
        XCTAssertNotNil(store.errorMessage)

        await repository.setFailure(nil)
        await store.start()
        let original = store.state
        await repository.setFailure(.save)

        let succeeded = await store.dispatch(.move(to: .kitchen))
        XCTAssertFalse(succeeded)
        XCTAssertEqual(store.state, original)
        XCTAssertNotNil(store.errorMessage)
    }

    @MainActor
    func testCompleteRoomCareJourneyPersistsEveryCommand() async {
        let repository = InMemoryGameRepository()
        let store = makeStore(repository: repository, feedback: FeedbackSpy())
        await store.start()

        let commands: [GameCommand] = [
            .move(to: .kitchen),
            .feed,
            .move(to: .washroom),
            .wash,
            .pet,
            .move(to: .playroom),
            .play,
            .move(to: .bedroom),
            .beginSleep,
        ]
        for command in commands {
            let succeeded = await store.dispatch(command)
            XCTAssertTrue(succeeded, "Failed command: \(command)")
        }
        await store.flush()

        let persisted = await repository.snapshot
        let saveCount = await repository.saveCount
        XCTAssertEqual(persisted, store.state)
        XCTAssertEqual(persisted?.careStatistics.meals, 1)
        XCTAssertEqual(persisted?.careStatistics.baths, 1)
        XCTAssertEqual(persisted?.careStatistics.playSessions, 1)
        XCTAssertTrue(persisted?.isSleeping == true)
        XCTAssertEqual(saveCount, 11)
    }

    @MainActor
    func testGoobyFactoryContainsRequiredNamedHierarchyAndInputTargets() throws {
        let gooby = GoobyFactory.makeGooby()

        XCTAssertEqual(gooby.name, GoobyRealityNames.root)
        for name in GoobyRealityNames.requiredHierarchy where name != GoobyRealityNames.root {
            XCTAssertNotNil(gooby.findEntity(named: name), "Missing \(name)")
        }

        let torso = try XCTUnwrap(gooby.findEntity(named: GoobyRealityNames.torso))
        let head = try XCTUnwrap(gooby.findEntity(named: GoobyRealityNames.head))
        XCTAssertNotNil(torso.components[CollisionComponent.self])
        XCTAssertNotNil(head.components[CollisionComponent.self])
        if #available(iOS 18.0, *) {
            XCTAssertNotNil(torso.components[InputTargetComponent.self])
            XCTAssertNotNil(head.components[InputTargetComponent.self])
        }
    }

    @MainActor
    func testRoomFactoryBuildsAllDistinctNamedRoomRoots() {
        let roots = RoomID.allCases.map(GoobyRoomFactory.makeRoom)

        XCTAssertEqual(
            Set(roots.map(\.name)),
            Set(RoomID.allCases.map { "room.\($0.rawValue)" })
        )
        for root in roots {
            XCTAssertNotNil(root.findEntity(named: "room.camera"))
            XCTAssertNotNil(root.findEntity(named: "room.floor"))
            XCTAssertNotNil(root.findEntity(named: "room.light.key"))
        }
    }

    @MainActor
    func testStorePurchasesClaimsEquipsAndRestoresOnRelaunch() async {
        let repository = InMemoryGameRepository()
        let clock = TestClock()
        let feedback = FeedbackSpy()
        let first = GameStore(
            repository: repository,
            clock: clock,
            audio: feedback,
            haptics: feedback,
            skipsWelcome: true
        )
        await first.start()

        let claimed = await first.dispatch(.claimDailyReward)
        let purchased = await first.dispatch(.purchase(itemID: GoobyCatalog.sunshineBow))
        let equipped = await first.dispatch(.equip(itemID: GoobyCatalog.sunshineBow))
        XCTAssertTrue(claimed)
        XCTAssertTrue(purchased)
        XCTAssertTrue(equipped)
        XCTAssertEqual(first.state?.equippedCosmetics.neck, GoobyCatalog.sunshineBow)
        XCTAssertEqual(first.state?.carrots, 15)

        let second = GameStore(
            repository: repository,
            clock: clock,
            audio: feedback,
            haptics: feedback,
            skipsWelcome: true
        )
        await second.start()

        XCTAssertTrue(second.state?.ownedItems.contains(GoobyCatalog.sunshineBow) == true)
        XCTAssertEqual(second.state?.equippedCosmetics.neck, GoobyCatalog.sunshineBow)
        XCTAssertEqual(second.state?.dailyReward.lastClaimedDay, 20_000)
    }

    @MainActor
    func testSettingsPersistAndFeedbackClientsFollowToggles() async {
        let repository = InMemoryGameRepository()
        let feedback = FeedbackSpy()
        let first = makeStore(repository: repository, feedback: feedback)
        await first.start()

        let renamed = await first.dispatch(.renamePet("  Clover  "))
        let soundDisabled = await first.dispatch(.setSoundEnabled(false))
        let hapticsDisabled = await first.dispatch(.setHapticsEnabled(false))
        let reducedMotion = await first.dispatch(.setReduceMotionEnabled(true))
        XCTAssertTrue(renamed)
        XCTAssertTrue(soundDisabled)
        XCTAssertTrue(hapticsDisabled)
        XCTAssertTrue(reducedMotion)
        _ = await first.dispatch(.pet)

        XCTAssertEqual(first.state?.preferences.petName, "Clover")
        XCTAssertEqual(feedback.audioEnabled.last, false)
        XCTAssertEqual(feedback.hapticsEnabled.last, false)

        let second = makeStore(repository: repository, feedback: feedback)
        await second.start()
        XCTAssertEqual(second.state?.preferences.petName, "Clover")
        XCTAssertTrue(second.state?.preferences.reduceMotionEnabled == true)
    }

    @MainActor
    func testResetProgressRestoresFreshStateAndFeedbackDefaults() async {
        let repository = InMemoryGameRepository()
        let feedback = FeedbackSpy()
        let store = makeStore(repository: repository, feedback: feedback)
        await store.start()
        _ = await store.dispatch(.renamePet("Clover"))
        _ = await store.dispatch(.setSoundEnabled(false))
        _ = await store.dispatch(.setHapticsEnabled(false))
        _ = await store.dispatch(.purchase(itemID: GoobyCatalog.sunshineBow))

        let reset = await store.resetProgress()

        XCTAssertTrue(reset)
        XCTAssertEqual(
            store.state,
            GameState.new(now: GameInstant(secondsSinceEpoch: 1_728_000_000))
        )
        XCTAssertEqual(feedback.audioEnabled.last, true)
        XCTAssertEqual(feedback.hapticsEnabled.last, true)
    }

    @MainActor
    func testAllPlannedCosmeticsBuildNamedPrimitiveEntities() throws {
        let coordinator = GoobySceneCoordinator()
        coordinator.prepare(room: .playroom, reduceMotion: true)
        var state = GameState.new(now: GameInstant(secondsSinceEpoch: 1_728_000_000))

        for item in GoobyCatalog.cosmetics {
            guard case let .cosmetic(slot) = item.kind else {
                return XCTFail("\(item.name) must be a cosmetic")
            }
            state.equippedCosmetics = EquippedCosmetics()
            state.equippedCosmetics[slot] = item.id
            coordinator.apply(
                state: state,
                events: [],
                eventRevision: 0,
                reduceMotion: true
            )
            XCTAssertNotNil(
                coordinator.gooby.findEntity(named: "cosmetic.\(item.id.rawValue)"),
                "Missing procedural entity for \(item.name)"
            )
        }
    }

    @MainActor
    func testStoreStartsPausesRelaunchesAndCancelsMinigameWithoutReward() async throws {
        let repository = InMemoryGameRepository()
        let clock = TestClock()
        let feedback = FeedbackSpy()
        let first = GameStore(
            repository: repository,
            clock: clock,
            audio: feedback,
            haptics: feedback,
            skipsWelcome: true
        )
        await first.start()

        let started = await first.dispatch(.startMinigame(kind: .carrotCatch))
        XCTAssertTrue(started)
        let run = try XCTUnwrap(first.state?.activeMinigame)
        await first.pauseActiveMinigame()
        XCTAssertTrue(first.state?.activeMinigame?.isPaused == true)

        let relaunched = GameStore(
            repository: repository,
            clock: clock,
            audio: feedback,
            haptics: feedback,
            skipsWelcome: true
        )
        await relaunched.start()
        XCTAssertEqual(relaunched.state?.activeMinigame?.id, run.id)
        XCTAssertTrue(relaunched.state?.activeMinigame?.isPaused == true)
        let carrots = relaunched.state?.carrots

        let cancelled = await relaunched.dispatch(.cancelMinigame(runID: run.id))
        XCTAssertTrue(cancelled)
        XCTAssertNil(relaunched.state?.activeMinigame)
        XCTAssertEqual(relaunched.state?.carrots, carrots)
        XCTAssertFalse(relaunched.state?.rewardedMinigameRuns.contains(run.id) == true)
        XCTAssertEqual(feedback.audioCues.filter { $0 == .play }.count, 1)
        XCTAssertFalse(feedback.audioCues.contains(.reward))
    }

    @MainActor
    func testFailedMinigameResumeKeepsPersistedRunPaused() async throws {
        let repository = InMemoryGameRepository()
        let clock = TestClock()
        let store = GameStore(
            repository: repository,
            clock: clock,
            audio: FeedbackSpy(),
            haptics: FeedbackSpy(),
            skipsWelcome: true
        )
        await store.start()
        let started = await store.dispatch(.startMinigame(kind: .carrotCatch))
        XCTAssertTrue(started)
        await store.pauseActiveMinigame()
        let paused = try XCTUnwrap(store.state?.activeMinigame)
        XCTAssertTrue(paused.isPaused)
        await repository.setFailure(.save)

        let resumed = await store.resumeActiveMinigame()
        XCTAssertFalse(resumed)
        XCTAssertEqual(store.state?.activeMinigame, paused)
    }

    @MainActor
    func testStoreFinishesValidatedMinigameOnceAndPersistsBestScore() async throws {
        let repository = InMemoryGameRepository()
        let clock = TestClock()
        let feedback = FeedbackSpy()
        let store = GameStore(
            repository: repository,
            clock: clock,
            audio: feedback,
            haptics: feedback,
            skipsWelcome: true
        )
        await store.start()
        let started = await store.dispatch(.startMinigame(kind: .carrotCatch))
        XCTAssertTrue(started)
        let run = try XCTUnwrap(store.state?.activeMinigame)
        let moves = CarrotCatch.carrotLanes(seed: run.seed, count: CarrotCatch.maximumMoves)
            .map(CarrotCatchMove.init(lane:))
        let command = GameCommand.finishMinigame(
            runID: run.id,
            submission: .carrotCatch(moves: moves)
        )

        let finished = await store.dispatch(command)
        XCTAssertTrue(finished)
        let rewarded = store.state
        XCTAssertEqual(rewarded?.bestMinigameScores[.carrotCatch], 200)
        XCTAssertEqual(rewarded?.carrots, 50)
        XCTAssertEqual(store.rewardNotices.last?.detail, "200 points • +20 carrots")
        XCTAssertEqual(feedback.audioCues.last, .reward)

        let replayed = await store.dispatch(command)
        XCTAssertTrue(replayed)
        XCTAssertEqual(store.state, rewarded)
        XCTAssertEqual(
            store.latestEvents.last,
            .minigameRewardAlreadyGranted(run.id)
        )

        let relaunched = GameStore(
            repository: repository,
            clock: clock,
            audio: feedback,
            haptics: feedback,
            skipsWelcome: true
        )
        await relaunched.start()
        XCTAssertEqual(relaunched.state?.bestMinigameScores[.carrotCatch], 200)
        XCTAssertEqual(relaunched.state?.carrots, 50)
    }

    @MainActor
    func testMinigameInputFeedbackUsesDistinctProceduralCues() async {
        let repository = InMemoryGameRepository()
        let feedback = FeedbackSpy()
        let store = makeStore(repository: repository, feedback: feedback)
        await store.start()

        store.playMinigameFeedback(.carrotCatch(caught: true))
        store.playMinigameFeedback(.carrotCatch(caught: false))
        for symbol in GardenEcho.symbolRange {
            store.playMinigameFeedback(.gardenEcho(symbol: symbol))
        }

        XCTAssertEqual(Array(feedback.audioCues.suffix(6)), [
            .carrotCatch(caught: true),
            .carrotCatch(caught: false),
            .gardenEcho(symbol: 0),
            .gardenEcho(symbol: 1),
            .gardenEcho(symbol: 2),
            .gardenEcho(symbol: 3),
        ])
        XCTAssertEqual(
            Array(feedback.hapticCues.suffix(6)),
            Array(feedback.audioCues.suffix(6))
        )
    }

    @MainActor
    private func makeStore(
        repository: InMemoryGameRepository,
        feedback: FeedbackSpy
    ) -> GameStore {
        GameStore(
            repository: repository,
            clock: TestClock(),
            audio: feedback,
            haptics: feedback,
            freshSaveHint: true,
            skipsWelcome: true
        )
    }
}

private enum RepositoryFailure: Error, Equatable {
    case load
    case save
}

private actor InMemoryGameRepository: GameStateRepository {
    private(set) var snapshot: GameState?
    private(set) var saveCount = 0
    private var failure: RepositoryFailure?

    func setFailure(_ failure: RepositoryFailure?) {
        self.failure = failure
    }

    func load(now: GameInstant) async throws -> GameState {
        if failure == .load { throw RepositoryFailure.load }
        return snapshot ?? GameState.new(now: now)
    }

    func save(_ state: GameState, at _: GameInstant) async throws {
        if failure == .save { throw RepositoryFailure.save }
        snapshot = state
        saveCount += 1
    }

    func reset(now: GameInstant) async throws -> GameState {
        if failure == .save { throw RepositoryFailure.save }
        let state = GameState.new(now: now)
        snapshot = state
        saveCount += 1
        return state
    }
}

@MainActor
private final class TestClock: GameClock {
    var instant = GameInstant(secondsSinceEpoch: 1_728_000_000)

    func now() -> GameInstant {
        instant
    }
}

@MainActor
private final class FeedbackSpy: AudioFeedbackClient, HapticFeedbackClient {
    private(set) var audioCues: [FeedbackCue] = []
    private(set) var hapticCues: [FeedbackCue] = []
    private(set) var audioEnabled: [Bool] = []
    private(set) var hapticsEnabled: [Bool] = []

    func play(_ cue: FeedbackCue) {
        audioCues.append(cue)
    }

    func setAmbientEnabled(_ enabled: Bool) {
        audioEnabled.append(enabled)
    }

    func setEnabled(_ enabled: Bool) {
        hapticsEnabled.append(enabled)
    }

    func impact(_ cue: FeedbackCue) {
        hapticCues.append(cue)
    }
}
