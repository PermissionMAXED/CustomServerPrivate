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

    func play(_ cue: FeedbackCue) {
        audioCues.append(cue)
    }

    func setAmbientEnabled(_: Bool) {}

    func impact(_ cue: FeedbackCue) {
        hapticCues.append(cue)
    }
}
