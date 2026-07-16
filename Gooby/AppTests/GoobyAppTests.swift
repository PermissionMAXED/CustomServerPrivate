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
                usesShortMinigameCountdown: false
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
                    usesShortMinigameCountdown: true
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
            XCTAssertNotNil(root.findEntity(named: "room.light.soft-fill"))
            XCTAssertNotNil(root.findEntity(named: "room.contact-shadow"))
        }

        let specs = RoomID.allCases.map(GoobyRoomFactory.visualSpec)
        XCTAssertEqual(Set(specs.map(\.heroName)).count, RoomID.allCases.count)
        XCTAssertEqual(Set(specs.map(\.backdropName)).count, RoomID.allCases.count)
        XCTAssertEqual(Set(specs.map(\.floorRGB)).count, RoomID.allCases.count)
        XCTAssertEqual(Set(specs.map(\.wallRGB)).count, RoomID.allCases.count)
        XCTAssertEqual(Set(specs.map(\.accentRGB)).count, RoomID.allCases.count)

        for (room, root) in zip(RoomID.allCases, roots) {
            let spec = GoobyRoomFactory.visualSpec(for: room)
            let hero = root.findEntity(named: spec.heroName)
            let backdrop = root.findEntity(named: spec.backdropName)
            XCTAssertNotNil(hero, "Missing foreground hero for \(room)")
            XCTAssertNotNil(backdrop, "Missing palette backdrop for \(room)")
            if let hero {
                let extents = hero.visualBounds(relativeTo: root).extents
                XCTAssertGreaterThan(extents.x, 0.45)
                XCTAssertGreaterThan(extents.y, 0.45)
                XCTAssertGreaterThan(extents.z, 0.10)
                XCTAssertGreaterThan(hero.position(relativeTo: root).z, 0.25)
            }
            XCTAssertLessThanOrEqual(
                entityCount(root),
                40,
                "\(room) exceeded the procedural room entity budget"
            )
        }
    }

    @MainActor
    func testSunshineBowHasVisibleBoundsContrastAndNeckDepth() throws {
        let coordinator = GoobySceneCoordinator()
        coordinator.prepare(room: .playroom, reduceMotion: true, allowsAnimation: false)
        var state = GameState.new(now: GameInstant(secondsSinceEpoch: 1_728_000_000))
        state.equippedCosmetics.neck = GoobyCatalog.sunshineBow

        coordinator.apply(
            state: state,
            events: [],
            eventRevision: 1,
            reduceMotion: true
        )

        let neck = try XCTUnwrap(
            coordinator.gooby.findEntity(named: GoobyRealityNames.neckAnchor)
        )
        let bow = try XCTUnwrap(
            coordinator.gooby.findEntity(named: "cosmetic.sunshine-bow")
        )
        let backing = try XCTUnwrap(
            coordinator.gooby.findEntity(named: "cosmetic.sunshine-bow.backing")
        )
        let extents = bow.visualBounds(relativeTo: neck).extents

        XCTAssertTrue(bow.parent === neck)
        XCTAssertGreaterThan(extents.x, 0.55)
        XCTAssertGreaterThan(extents.y, 0.24)
        XCTAssertGreaterThan(extents.z, 0.12)
        XCTAssertGreaterThan(bow.position.z, 0.12)
        XCTAssertNotNil(backing.components[ModelComponent.self])
    }

    @MainActor
    func testPreviewDisablesIdleAndStaleCareReactions() {
        let coordinator = GoobySceneCoordinator()
        coordinator.prepare(room: .kitchen, reduceMotion: false, allowsAnimation: false)
        let state = GameState.new(now: GameInstant(secondsSinceEpoch: 1_728_000_000))

        coordinator.apply(
            state: state,
            events: [.fed, .petted],
            eventRevision: 1,
            reduceMotion: false
        )

        XCTAssertFalse(coordinator.hasActiveReaction)
        XCTAssertEqual(coordinator.currentRoom, .playroom)
    }

    @MainActor
    func testCareReactionMovesOneAttachedRigAndCancelsCleanly() throws {
        let coordinator = GoobySceneCoordinator()
        coordinator.prepare(room: .playroom, reduceMotion: false)
        let state = GameState.new(now: GameInstant(secondsSinceEpoch: 1_728_000_000))
        let rig = try XCTUnwrap(
            coordinator.gooby.findEntity(named: GoobyRealityNames.rig)
        )

        for name in [
            GoobyRealityNames.head,
            GoobyRealityNames.earLeft,
            GoobyRealityNames.earRight,
            GoobyRealityNames.pawLeft,
            GoobyRealityNames.pawRight,
        ] {
            XCTAssertTrue(
                coordinator.gooby.findEntity(named: name)?.parent === rig,
                "\(name) must remain attached to the shared rig"
            )
        }

        coordinator.apply(
            state: state,
            events: [.played],
            eventRevision: 1,
            reduceMotion: false
        )
        XCTAssertTrue(coordinator.hasActiveReaction)
        coordinator.stop()
        XCTAssertFalse(coordinator.hasActiveReaction)
    }

    @MainActor
    func testSemanticThemeContrastPassesLightAndDarkThresholds() {
        for style in [UIUserInterfaceStyle.light, .dark] {
            let traits = UITraitCollection(userInterfaceStyle: style)
            let ink = GoobyPalette.inkUIColor.resolvedColor(with: traits)
            let surface = GoobyPalette.surfaceUIColor.resolvedColor(with: traits)
            let action = GoobyPalette.actionUIColor.resolvedColor(with: traits)
            let border = GoobyPalette.borderUIColor.resolvedColor(with: traits)
            let white = UIColor.white

            XCTAssertGreaterThanOrEqual(contrast(ink, surface), 4.5)
            XCTAssertGreaterThanOrEqual(contrast(white, action), 4.5)
            XCTAssertGreaterThanOrEqual(contrast(border, surface), 3.0)
            for accent in [
                GoobyPalette.coralUIColor,
                GoobyPalette.mintUIColor,
                GoobyPalette.skyUIColor,
                GoobyPalette.goldUIColor,
            ] {
                XCTAssertGreaterThanOrEqual(
                    contrast(accent.resolvedColor(with: traits), surface),
                    3.0
                )
            }
        }
    }

    @MainActor
    func testVoiceOverChangeMidGameEnablesAndPersistsRelaxedTimingImmediately() {
        let decision = CarrotAccessibilityTimingPolicy.decision(
            voiceOverEnabled: true,
            persistedPreference: false,
            stage: .playing,
            gameFinished: false
        )

        XCTAssertTrue(decision.usesRelaxedTiming)
        XCTAssertTrue(decision.persistsPreference)
        XCTAssertTrue(decision.holdsCorePaused)

        let relaunched = CarrotAccessibilityTimingPolicy.decision(
            voiceOverEnabled: false,
            persistedPreference: decision.persistsPreference,
            stage: .instructions,
            gameFinished: false
        )
        XCTAssertTrue(relaunched.usesRelaxedTiming)
        XCTAssertFalse(relaunched.holdsCorePaused)
    }

    @MainActor
    func testRewardToastDoesNotTimeDismissWhileVoiceOverIsActive() {
        XCTAssertFalse(
            RewardToastDismissalPolicy.shouldAutoDismiss(voiceOverEnabled: true)
        )
        XCTAssertTrue(
            RewardToastDismissalPolicy.shouldAutoDismiss(voiceOverEnabled: false)
        )
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
            let cosmetic = coordinator.gooby.findEntity(
                named: "cosmetic.\(item.id.rawValue)"
            )
            XCTAssertNotNil(cosmetic, "Missing procedural entity for \(item.name)")
            if let cosmetic {
                let extents = cosmetic.visualBounds(relativeTo: coordinator.gooby).extents
                XCTAssertGreaterThan(extents.x, 0.05, "\(item.name) preview has no width")
                XCTAssertGreaterThan(extents.y, 0.05, "\(item.name) preview has no height")
                XCTAssertGreaterThan(extents.z, 0.02, "\(item.name) preview has no depth")
            }
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
        for _ in 0 ..< 3 {
            let advanced = await store.dispatch(
                .advanceCarrotCatchCountdown(runID: run.id)
            )
            XCTAssertTrue(advanced)
        }
        for lane in CarrotCatch.carrotLanes(seed: run.seed, count: CarrotCatch.maximumMoves) {
            let recorded = await store.dispatch(
                .carrotCatchInput(runID: run.id, lane: lane)
            )
            XCTAssertTrue(recorded)
        }
        let command = GameCommand.finishMinigame(runID: run.id)

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
    func testFIFOCommandsFlushAndResetCannotOverwriteNewerState() async throws {
        let repository = SuspendingGameRepository()
        let clock = TestClock()
        let store = GameStore(
            repository: repository,
            clock: clock,
            audio: FeedbackSpy(),
            haptics: FeedbackSpy(),
            skipsWelcome: true
        )
        await store.start()
        await repository.suspendNextSave()

        let move = Task { await store.dispatch(.move(to: .kitchen)) }
        await repository.waitUntilSaveSuspended()
        let feed = Task { await store.dispatch(.feed) }
        let flush = Task { await store.flush() }
        let reset = Task { await store.resetProgress() }
        await repository.resumeSuspendedSave()

        let moved = await move.value
        let fed = await feed.value
        await flush.value
        let didReset = await reset.value
        XCTAssertTrue(moved)
        XCTAssertTrue(fed)
        XCTAssertTrue(didReset)
        let persisted = await repository.snapshot
        XCTAssertEqual(persisted, GameState.new(now: clock.instant))
        XCTAssertEqual(store.state, persisted)
    }

    @MainActor
    func testRapidCommandsPublishMonotonicLosslessEventBatches() async {
        let repository = SuspendingGameRepository()
        let store = GameStore(
            repository: repository,
            clock: TestClock(),
            audio: FeedbackSpy(),
            haptics: FeedbackSpy(),
            skipsWelcome: true
        )
        await store.start()
        await repository.suspendNextSave()

        let kitchen = Task { await store.dispatch(.move(to: .kitchen)) }
        await repository.waitUntilSaveSuspended()
        let bedroom = Task { await store.dispatch(.move(to: .bedroom)) }
        await repository.resumeSuspendedSave()

        let movedToKitchen = await kitchen.value
        let movedToBedroom = await bedroom.value
        XCTAssertTrue(movedToKitchen)
        XCTAssertTrue(movedToBedroom)
        XCTAssertEqual(store.eventBatches.map(\.id), [1, 2])
        XCTAssertEqual(store.eventBatches.flatMap(\.events), [
            .moved(.kitchen),
            .moved(.bedroom),
        ])
    }

    @MainActor
    func testFailedFinalSaveRetriesOnceWithoutPrematureReward() async throws {
        let repository = InMemoryGameRepository()
        let store = makeStore(repository: repository, feedback: FeedbackSpy())
        await store.start()
        let started = await store.dispatch(.startMinigame(kind: .carrotCatch))
        XCTAssertTrue(started)
        let run = try XCTUnwrap(store.state?.activeMinigame)
        for _ in 0 ..< 3 {
            let advanced = await store.dispatch(.advanceCarrotCatchCountdown(runID: run.id))
            XCTAssertTrue(advanced)
        }
        for lane in CarrotCatch.carrotLanes(seed: run.seed, count: CarrotCatch.maximumMoves) {
            let recorded = await store.dispatch(.carrotCatchInput(runID: run.id, lane: lane))
            XCTAssertTrue(recorded)
        }
        let beforeFinish = try XCTUnwrap(store.state)
        await repository.setFailure(.save)

        let failedFinish = await store.dispatch(.finishMinigame(runID: run.id))
        XCTAssertFalse(failedFinish)
        XCTAssertEqual(store.state, beforeFinish)
        XCTAssertFalse(store.state?.rewardedMinigameRuns.contains(run.id) == true)

        await repository.setFailure(nil)
        let finished = await store.dispatch(.finishMinigame(runID: run.id))
        XCTAssertTrue(finished)
        let rewarded = try XCTUnwrap(store.state)
        XCTAssertEqual(rewarded.rewardedMinigameRuns.filter { $0 == run.id }.count, 1)
        let replayed = await store.dispatch(.finishMinigame(runID: run.id))
        XCTAssertTrue(replayed)
        XCTAssertEqual(store.state, rewarded)
    }

    @MainActor
    func testInflightFinishThenCancelKeepsCommittedRewardInFIFOOrder() async throws {
        let repository = SuspendingGameRepository()
        let store = GameStore(
            repository: repository,
            clock: TestClock(),
            audio: FeedbackSpy(),
            haptics: FeedbackSpy(),
            skipsWelcome: true
        )
        await store.start()
        let started = await store.dispatch(.startMinigame(kind: .carrotCatch))
        XCTAssertTrue(started)
        let run = try XCTUnwrap(store.state?.activeMinigame)
        for _ in 0 ..< 3 {
            let advanced = await store.dispatch(.advanceCarrotCatchCountdown(runID: run.id))
            XCTAssertTrue(advanced)
        }
        for lane in CarrotCatch.carrotLanes(seed: run.seed, count: CarrotCatch.maximumMoves) {
            let recorded = await store.dispatch(.carrotCatchInput(runID: run.id, lane: lane))
            XCTAssertTrue(recorded)
        }

        await repository.suspendNextSave()
        let finish = Task { await store.dispatch(.finishMinigame(runID: run.id)) }
        await repository.waitUntilSaveSuspended()
        let cancel = Task { await store.dispatch(.cancelMinigame(runID: run.id)) }
        await repository.resumeSuspendedSave()

        let didFinish = await finish.value
        let didCancel = await cancel.value
        XCTAssertTrue(didFinish)
        XCTAssertFalse(didCancel)
        XCTAssertEqual(store.state?.rewardedMinigameRuns.filter { $0 == run.id }.count, 1)
        XCTAssertNil(store.state?.activeMinigame)
        let persisted = await repository.snapshot
        XCTAssertEqual(persisted, store.state)
    }

    @MainActor
    func testForegroundMinuteTickerUpdatesVisibleNeedsAndStopsInBackground() async throws {
        let repository = InMemoryGameRepository()
        let clock = TestClock()
        let store = GameStore(
            repository: repository,
            clock: clock,
            audio: FeedbackSpy(),
            haptics: FeedbackSpy(),
            skipsWelcome: true,
            minuteTickDuration: .milliseconds(10)
        )
        await store.start()
        clock.instant = clock.instant.adding(seconds: 60)
        let tickerPersistedAdvance = await repository.waitForSaveCount(2)

        XCTAssertTrue(tickerPersistedAdvance)
        XCTAssertEqual(store.state?.needs.fullness.value, 798)
        await store.handleLifecycleTransition(.background)
        let backgroundNeeds = store.state?.needs
        let backgroundSaveCount = await repository.saveCount
        clock.instant = clock.instant.adding(seconds: 60)
        let tickerPersistedInBackground = await repository.waitForSaveCount(
            backgroundSaveCount + 1,
            attempts: 20
        )

        XCTAssertFalse(tickerPersistedInBackground)
        XCTAssertEqual(store.state?.needs, backgroundNeeds)
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

    private func contrast(_ first: UIColor, _ second: UIColor) -> Double {
        let firstLuminance = relativeLuminance(first)
        let secondLuminance = relativeLuminance(second)
        let lighter = max(firstLuminance, secondLuminance)
        let darker = min(firstLuminance, secondLuminance)
        return (lighter + 0.05) / (darker + 0.05)
    }

    private func relativeLuminance(_ color: UIColor) -> Double {
        var red: CGFloat = 0
        var green: CGFloat = 0
        var blue: CGFloat = 0
        var alpha: CGFloat = 0
        XCTAssertTrue(color.getRed(&red, green: &green, blue: &blue, alpha: &alpha))
        return 0.2126 * linearized(Double(red))
            + 0.7152 * linearized(Double(green))
            + 0.0722 * linearized(Double(blue))
    }

    private func linearized(_ component: Double) -> Double {
        component <= 0.04045
            ? component / 12.92
            : pow((component + 0.055) / 1.055, 2.4)
    }

    @MainActor
    private func entityCount(_ root: Entity) -> Int {
        1 + root.children.reduce(0) { $0 + entityCount($1) }
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

    func waitForSaveCount(_ target: Int, attempts: Int = 200) async -> Bool {
        for _ in 0 ..< attempts {
            if saveCount >= target { return true }
            try? await Task.sleep(for: .milliseconds(10))
        }
        return saveCount >= target
    }

    func load(now: GameInstant) async throws -> GameStateLoadResult {
        if failure == .load { throw RepositoryFailure.load }
        return GameStateLoadResult(
            state: snapshot ?? GameState.new(now: now),
            source: snapshot == nil ? .missing : .primary
        )
    }

    func save(_ state: GameState, at _: GameInstant) async throws {
        if failure == .save { throw RepositoryFailure.save }
        snapshot = state
        saveCount += 1
    }

    func reset(
        now: GameInstant,
        discardingDamagedSave _: Bool
    ) async throws -> GameState {
        if failure == .save { throw RepositoryFailure.save }
        let state = GameState.new(now: now)
        snapshot = state
        saveCount += 1
        return state
    }
}

private actor SuspendingGameRepository: GameStateRepository {
    private(set) var snapshot: GameState?
    private var shouldSuspendNextSave = false
    private var isSaveSuspended = false
    private var saveContinuation: CheckedContinuation<Void, Never>?
    private var waiters: [CheckedContinuation<Void, Never>] = []

    func suspendNextSave() {
        shouldSuspendNextSave = true
    }

    func waitUntilSaveSuspended() async {
        if isSaveSuspended { return }
        await withCheckedContinuation { continuation in
            waiters.append(continuation)
        }
    }

    func resumeSuspendedSave() {
        saveContinuation?.resume()
        saveContinuation = nil
    }

    func load(now: GameInstant) async throws -> GameStateLoadResult {
        GameStateLoadResult(
            state: snapshot ?? GameState.new(now: now),
            source: snapshot == nil ? .missing : .primary
        )
    }

    func save(_ state: GameState, at _: GameInstant) async throws {
        if shouldSuspendNextSave {
            shouldSuspendNextSave = false
            isSaveSuspended = true
            await withCheckedContinuation { continuation in
                saveContinuation = continuation
                let pendingWaiters = waiters
                waiters = []
                pendingWaiters.forEach { $0.resume() }
            }
            isSaveSuspended = false
        }
        snapshot = state
    }

    func reset(
        now: GameInstant,
        discardingDamagedSave _: Bool
    ) async throws -> GameState {
        let fresh = GameState.new(now: now)
        snapshot = fresh
        return fresh
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
