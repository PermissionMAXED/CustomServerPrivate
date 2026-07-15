import GoobyCore
import XCTest

final class MinigameTests: XCTestCase {
    private let now = GameInstant(secondsSinceEpoch: 1_728_000_000)

    func testSplitMix64MatchesReferenceVector() {
        var random = SplitMix64(seed: 0)

        XCTAssertEqual(random.next(), 0xE220_A839_7B1D_CDAF)
        XCTAssertEqual(random.next(), 0x6E78_9E6A_A1B9_65F4)
    }

    func testCarrotCatchIsDeterministicAndScoresValidatedMoves() throws {
        let lanes = CarrotCatch.carrotLanes(seed: 42, count: 20)
        let repeated = CarrotCatch.carrotLanes(seed: 42, count: 20)
        let moves = lanes.map(CarrotCatchMove.init(lane:))

        XCTAssertEqual(lanes, repeated)
        XCTAssertNotEqual(lanes, CarrotCatch.carrotLanes(seed: 43, count: 20))
        XCTAssertEqual(
            try XCTUnwrap(CarrotCatch.play(seed: 42, moves: moves)).score,
            200
        )
        XCTAssertNil(CarrotCatch.play(seed: 42, moves: [CarrotCatchMove(lane: 9)]))
    }

    func testGardenEchoSequencesAndProgressAreDeterministic() throws {
        let rounds = (1 ... GardenEcho.maximumRounds).map {
            GardenEchoRound(symbols: GardenEcho.sequence(seed: 99, round: $0))
        }

        XCTAssertEqual(
            try XCTUnwrap(GardenEcho.play(seed: 99, rounds: rounds)),
            GardenEchoResult(score: 125, completedRounds: 5)
        )
        XCTAssertEqual(
            GardenEcho.sequence(seed: 99, round: 3),
            GardenEcho.sequence(seed: 99, round: 3)
        )
    }

    func testActiveRunValidatesAndRewardsExactlyOnce() throws {
        var state = GameState.new(now: now)
        _ = try GameEngine.apply(.startMinigame(kind: .carrotCatch), to: &state, at: now)
        let run = try XCTUnwrap(state.activeMinigame)
        let moves = CarrotCatch.carrotLanes(seed: run.seed, count: 20)
            .map(CarrotCatchMove.init(lane:))
        let submission = MinigameSubmission.carrotCatch(moves: moves)
        let startingCarrots = state.carrots

        let first = try GameEngine.apply(
            .finishMinigame(runID: run.id, submission: submission),
            to: &state,
            at: now.adding(seconds: 30)
        )
        let afterFirstReward = state.carrots
        let second = try GameEngine.apply(
            .finishMinigame(runID: run.id, submission: submission),
            to: &state,
            at: now.adding(seconds: 30)
        )

        XCTAssertEqual(afterFirstReward, startingCarrots + 20)
        XCTAssertEqual(state.carrots, afterFirstReward)
        XCTAssertNil(state.activeMinigame)
        XCTAssertEqual(state.rewardedMinigameRuns, [run.id])
        XCTAssertTrue(
            first.contains(.minigameFinished(runID: run.id, score: 200, carrots: 20))
        )
        XCTAssertEqual(second.last, .minigameRewardAlreadyGranted(run.id))
    }

    func testRunRejectsWrongIdentifierSubmissionTypeAndExpiry() throws {
        var wrongIDState = GameState.new(now: now)
        _ = try GameEngine.apply(
            .startMinigame(kind: .carrotCatch),
            to: &wrongIDState,
            at: now
        )
        let run = try XCTUnwrap(wrongIDState.activeMinigame)
        let validMoves = [CarrotCatchMove(lane: 0)]

        XCTAssertThrowsError(
            try GameEngine.apply(
                .finishMinigame(
                    runID: MinigameRunID(rawValue: "other"),
                    submission: .carrotCatch(moves: validMoves)
                ),
                to: &wrongIDState,
                at: now
            )
        ) { error in
            XCTAssertEqual(error as? GameRuleError, .invalidMinigameRun)
        }

        XCTAssertThrowsError(
            try GameEngine.apply(
                .finishMinigame(
                    runID: run.id,
                    submission: .gardenEcho(rounds: [GardenEchoRound(symbols: [0, 1, 2])])
                ),
                to: &wrongIDState,
                at: now
            )
        ) { error in
            XCTAssertEqual(error as? GameRuleError, .invalidMinigameSubmission)
        }

        XCTAssertThrowsError(
            try GameEngine.apply(
                .finishMinigame(
                    runID: run.id,
                    submission: .carrotCatch(moves: validMoves)
                ),
                to: &wrongIDState,
                at: now.adding(seconds: GameEngine.minigameDurationSeconds + 1)
            )
        ) { error in
            XCTAssertEqual(error as? GameRuleError, .minigameExpired)
        }
    }

    func testGardenEchoRequiresBondLevelOne() throws {
        var state = GameState.new(now: now)

        XCTAssertThrowsError(
            try GameEngine.apply(.startMinigame(kind: .gardenEcho), to: &state, at: now)
        ) { error in
            XCTAssertEqual(error as? GameRuleError, .featureLocked(requiredBondLevel: 2))
        }

        state.bondPoints = BondProgress.thresholds[1]
        XCTAssertNoThrow(
            try GameEngine.apply(.startMinigame(kind: .gardenEcho), to: &state, at: now)
        )
    }
}
