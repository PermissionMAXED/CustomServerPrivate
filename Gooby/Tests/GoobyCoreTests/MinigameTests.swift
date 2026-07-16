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
        XCTAssertEqual(Set(lanes).subtracting(CarrotCatch.laneRange), [])
        XCTAssertEqual(CarrotCatch.carrotLanes(seed: 42, count: 100).count, 20)
        XCTAssertEqual(CarrotCatch.play(seed: 42, moves: [])?.score, 0)
    }

    func testCarrotCatchGamePausesTracksMissesAndIsTerminallyImmutable() throws {
        var game = CarrotCatchGame(seed: 7)
        let firstTarget = try XCTUnwrap(game.currentLane)

        game.pause()
        XCTAssertFalse(game.catchCarrot(in: firstTarget))
        XCTAssertFalse(game.missCarrot())
        XCTAssertEqual(game.moves, [])

        game.resume()
        XCTAssertTrue(game.catchCarrot(in: firstTarget))
        XCTAssertTrue(game.missCarrot())
        game.finishRemainingAsMisses()
        let terminal = game
        let result = try XCTUnwrap(game.result)

        XCTAssertEqual(result.catches, 1)
        XCTAssertEqual(result.misses, CarrotCatch.maximumMoves - 1)
        XCTAssertEqual(result.bestStreak, 1)
        XCTAssertFalse(game.catchCarrot(in: 0))
        XCTAssertFalse(game.missCarrot())
        game.pause()
        game.resume()
        XCTAssertEqual(game, terminal)
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
        XCTAssertEqual(
            Array(GardenEcho.sequence(seed: 99, round: 5).prefix(3)),
            GardenEcho.sequence(seed: 99, round: 1)
        )
        XCTAssertEqual(GardenEcho.sequence(seed: 99, round: 0), [])
        XCTAssertEqual(GardenEcho.sequence(seed: 99, round: 6), [])
    }

    func testGardenEchoGameRetriesPausesAndCapsAtMaximumRound() {
        var game = GardenEchoGame(seed: 99)
        XCTAssertEqual(game.phase, .sequence)
        XCTAssertEqual(game.submit(symbol: 0), .ignored)

        game.pause()
        XCTAssertFalse(game.beginInput())
        game.resume()
        XCTAssertTrue(game.beginInput())

        let wrong = (game.sequence[0] + 1) % GardenEcho.symbolRange.count
        XCTAssertEqual(game.submit(symbol: wrong), .retry(mistakes: 1))
        XCTAssertEqual(game.round, 1)

        while game.phase != .finished {
            XCTAssertTrue(game.beginInput())
            let current = game.sequence
            for symbol in current {
                _ = game.submit(symbol: symbol)
            }
        }
        let terminal = game
        XCTAssertEqual(game.completedRounds, GardenEcho.maximumRounds)
        XCTAssertEqual(game.result?.score, 125)
        XCTAssertEqual(game.submit(symbol: 0), .ignored)
        game.replaySequence()
        game.pause()
        game.resume()
        XCTAssertEqual(game, terminal)
    }

    func testGardenEchoEndsAfterThreeMistakesWithoutChangingCompletedRounds() {
        var game = GardenEchoGame(seed: 11)

        for expectedMistake in 1 ... GardenEcho.maximumMistakes {
            XCTAssertTrue(game.beginInput())
            let wrong = (game.sequence[0] + 1) % GardenEcho.symbolRange.count
            let outcome = game.submit(symbol: wrong)
            if expectedMistake < GardenEcho.maximumMistakes {
                XCTAssertEqual(outcome, .retry(mistakes: expectedMistake))
            } else {
                XCTAssertEqual(outcome, .gameOver)
            }
        }

        XCTAssertEqual(game.phase, .finished)
        XCTAssertEqual(game.completedRounds, 0)
        XCTAssertEqual(game.result?.score, 0)
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
        XCTAssertEqual(state.bestMinigameScores[.carrotCatch], 200)
        XCTAssertTrue(
            first.contains(.minigameFinished(runID: run.id, score: 200, carrots: 20))
        )
        XCTAssertEqual(second.last, .minigameRewardAlreadyGranted(run.id))
    }

    func testBestScoreOnlyImprovesAcrossSeededRuns() throws {
        var state = GameState.new(now: now)
        _ = try GameEngine.apply(.startMinigame(kind: .carrotCatch), to: &state, at: now)
        let first = try XCTUnwrap(state.activeMinigame)
        let perfect = CarrotCatch.carrotLanes(seed: first.seed, count: 20)
            .map(CarrotCatchMove.init(lane:))
        _ = try GameEngine.apply(
            .finishMinigame(runID: first.id, submission: .carrotCatch(moves: perfect)),
            to: &state,
            at: now.adding(seconds: 30)
        )

        _ = try GameEngine.apply(
            .startMinigame(kind: .carrotCatch),
            to: &state,
            at: now.adding(seconds: 31)
        )
        let second = try XCTUnwrap(state.activeMinigame)
        XCTAssertNotEqual(first.seed, second.seed)
        _ = try GameEngine.apply(
            .finishMinigame(
                runID: second.id,
                submission: .carrotCatch(moves: [CarrotCatchMove()])
            ),
            to: &state,
            at: now.adding(seconds: 32)
        )

        XCTAssertEqual(state.bestMinigameScores[.carrotCatch], 200)
        XCTAssertEqual(state.rewardedMinigameRuns, [first.id, second.id])
    }

    func testPauseResumeExcludesBackgroundTimeFromExpiry() throws {
        var state = GameState.new(now: now)
        _ = try GameEngine.apply(.startMinigame(kind: .carrotCatch), to: &state, at: now)
        let run = try XCTUnwrap(state.activeMinigame)

        let paused = try GameEngine.apply(
            .pauseMinigame(runID: run.id),
            to: &state,
            at: now.adding(seconds: 10)
        )
        XCTAssertTrue(paused.contains(.minigamePauseChanged(runID: run.id, paused: true)))
        XCTAssertTrue(state.activeMinigame?.isPaused == true)

        _ = try GameEngine.apply(
            .resumeMinigame(runID: run.id),
            to: &state,
            at: now.adding(seconds: 10_000)
        )
        let events = try GameEngine.apply(
            .finishMinigame(
                runID: run.id,
                submission: .carrotCatch(moves: [CarrotCatchMove(lane: 0)])
            ),
            to: &state,
            at: now.adding(seconds: 10_010)
        )
        XCTAssertTrue(
            events.contains { event in
                if case .minigameFinished = event { return true }
                return false
            }
        )
    }

    func testCancelRejectsWrongIDAndCannotRewardCancelledRun() throws {
        var state = GameState.new(now: now)
        _ = try GameEngine.apply(.startMinigame(kind: .carrotCatch), to: &state, at: now)
        let run = try XCTUnwrap(state.activeMinigame)
        let unchanged = state

        XCTAssertThrowsError(
            try GameEngine.apply(
                .cancelMinigame(runID: MinigameRunID(rawValue: "wrong")),
                to: &state,
                at: now
            )
        ) { error in
            XCTAssertEqual(error as? GameRuleError, .invalidMinigameRun)
        }
        XCTAssertEqual(state, unchanged)

        let events = try GameEngine.apply(
            .cancelMinigame(runID: run.id),
            to: &state,
            at: now
        )
        XCTAssertEqual(events.last, .minigameCancelled(run.id))
        XCTAssertNil(state.activeMinigame)
        XCTAssertEqual(state.carrots, unchanged.carrots)
        XCTAssertFalse(state.rewardedMinigameRuns.contains(run.id))

        XCTAssertThrowsError(
            try GameEngine.apply(
                .finishMinigame(
                    runID: run.id,
                    submission: .carrotCatch(moves: [CarrotCatchMove(lane: 0)])
                ),
                to: &state,
                at: now
            )
        ) { error in
            XCTAssertEqual(error as? GameRuleError, .noActiveMinigame)
        }
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
