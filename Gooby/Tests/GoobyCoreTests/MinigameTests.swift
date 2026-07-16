import GoobyCore
import XCTest

final class MinigameTests: XCTestCase {
    private let now = GameInstant(secondsSinceEpoch: 1_728_000_000)

    func testSplitMix64MatchesReferenceVector() {
        var random = SplitMix64(seed: 0)

        XCTAssertEqual(random.next(), 0xE220_A839_7B1D_CDAF)
        XCTAssertEqual(random.next(), 0x6E78_9E6A_A1B9_65F4)
    }

    func testSplitMix64InvalidBoundDoesNotTrapOrAdvanceState() {
        var random = SplitMix64(seed: 42)
        let initial = random

        XCTAssertEqual(random.next(upperBound: 0), 0)
        XCTAssertEqual(random.next(upperBound: -1), 0)
        XCTAssertEqual(random, initial)
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
        while !game.isFinished {
            XCTAssertTrue(game.missCarrot())
        }
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

    func testPartialCarrotCompletionIsRejected() throws {
        var state = GameState.new(now: now)
        let run = try startPlayingCarrot(in: &state)
        _ = try GameEngine.apply(
            .carrotCatchInput(runID: run.id, lane: 0),
            to: &state,
            at: now
        )
        let snapshot = state

        XCTAssertThrowsError(
            try GameEngine.apply(.finishMinigame(runID: run.id), to: &state, at: now)
        ) { error in
            XCTAssertEqual(error as? GameRuleError, .invalidMinigameSubmission)
        }
        XCTAssertEqual(state, snapshot)
    }

    func testCarrotProgressCompletesRewardsAndReplaysExactlyOnce() throws {
        var state = GameState.new(now: now)
        let run = try startPlayingCarrot(in: &state)
        let lanes = CarrotCatch.carrotLanes(seed: run.seed, count: CarrotCatch.maximumMoves)
        for lane in lanes {
            _ = try GameEngine.apply(
                .carrotCatchInput(runID: run.id, lane: lane),
                to: &state,
                at: now
            )
        }
        guard case let .carrotCatch(progress)? = state.activeMinigame?.progress else {
            return XCTFail("Expected persisted Carrot Catch progress")
        }
        XCTAssertEqual(progress.game.moves.count, CarrotCatch.maximumMoves)
        XCTAssertEqual(progress.stage, .terminal)

        let startingCarrots = state.carrots
        let first = try GameEngine.apply(.finishMinigame(runID: run.id), to: &state, at: now)
        let rewarded = state
        let second = try GameEngine.apply(.finishMinigame(runID: run.id), to: &state, at: now)

        XCTAssertEqual(state.carrots, startingCarrots + 20)
        XCTAssertEqual(state, rewarded)
        XCTAssertEqual(state.rewardedMinigameRuns, [run.id])
        XCTAssertEqual(state.bestMinigameScores[.carrotCatch], 200)
        XCTAssertTrue(first.contains(.minigameFinished(runID: run.id, score: 200, carrots: 20)))
        XCTAssertEqual(second.last, .minigameRewardAlreadyGranted(run.id))
    }

    func testStandardCarrotTimeoutRequiresThirtyActiveSeconds() throws {
        var state = GameState.new(now: now)
        let run = try startPlayingCarrot(in: &state)

        XCTAssertThrowsError(
            try GameEngine.apply(
                .carrotCatchTimeout(runID: run.id),
                to: &state,
                at: now.adding(seconds: 29)
            )
        ) { error in
            XCTAssertEqual(error as? GameRuleError, .invalidMinigameSubmission)
        }
        _ = try GameEngine.apply(
            .carrotCatchTimeout(runID: run.id),
            to: &state,
            at: now.adding(seconds: 30)
        )
        XCTAssertNoThrow(
            try GameEngine.apply(
                .finishMinigame(runID: run.id),
                to: &state,
                at: now.adding(seconds: 30)
            )
        )
    }

    func testRelaxedCarrotAndGardenRemainValidBeyondFiveMinutes() throws {
        var carrotState = GameState.new(now: now)
        let carrot = try startPlayingCarrot(in: &carrotState, mode: .relaxed)
        let late = now.adding(seconds: 10 * 60)
        let lanes = CarrotCatch.carrotLanes(seed: carrot.seed, count: CarrotCatch.maximumMoves)
        for lane in lanes {
            _ = try GameEngine.apply(
                .carrotCatchInput(runID: carrot.id, lane: lane),
                to: &carrotState,
                at: late
            )
        }
        XCTAssertNoThrow(
            try GameEngine.apply(.finishMinigame(runID: carrot.id), to: &carrotState, at: late)
        )

        var gardenState = GameState.new(now: now)
        gardenState.bondPoints = BondProgress.thresholds[1]
        _ = try GameEngine.apply(.startMinigame(kind: .gardenEcho), to: &gardenState, at: now)
        let garden = try XCTUnwrap(gardenState.activeMinigame)
        for _ in 1 ... GardenEcho.maximumRounds {
            _ = try GameEngine.apply(
                .gardenEchoBeginInput(runID: garden.id),
                to: &gardenState,
                at: late
            )
            guard case let .gardenEcho(progress)? = gardenState.activeMinigame?.progress else {
                return XCTFail("Expected Garden Echo progress")
            }
            XCTAssertEqual(progress.currentSequence, progress.game.sequence)
            for symbol in progress.game.sequence {
                _ = try GameEngine.apply(
                    .gardenEchoInput(runID: garden.id, symbol: symbol),
                    to: &gardenState,
                    at: late
                )
            }
        }
        XCTAssertNoThrow(
            try GameEngine.apply(.finishMinigame(runID: garden.id), to: &gardenState, at: late)
        )
    }

    func testGardenRequiresFiveRoundsOrThreeRecordedMistakes() throws {
        var state = GameState.new(now: now)
        state.bondPoints = BondProgress.thresholds[1]
        _ = try GameEngine.apply(.startMinigame(kind: .gardenEcho), to: &state, at: now)
        let run = try XCTUnwrap(state.activeMinigame)

        _ = try GameEngine.apply(.gardenEchoBeginInput(runID: run.id), to: &state, at: now)
        XCTAssertThrowsError(
            try GameEngine.apply(.finishMinigame(runID: run.id), to: &state, at: now)
        )
        for _ in 1 ... GardenEcho.maximumMistakes {
            guard case let .gardenEcho(progress)? = state.activeMinigame?.progress else {
                return XCTFail("Expected Garden Echo progress")
            }
            if progress.game.phase != .input {
                _ = try GameEngine.apply(
                    .gardenEchoBeginInput(runID: run.id),
                    to: &state,
                    at: now
                )
            }
            guard case let .gardenEcho(inputProgress)? = state.activeMinigame?.progress else {
                return XCTFail("Expected Garden Echo progress")
            }
            let wrong = (inputProgress.game.sequence[0] + 1) % GardenEcho.symbolRange.count
            _ = try GameEngine.apply(
                .gardenEchoInput(runID: run.id, symbol: wrong),
                to: &state,
                at: now
            )
        }
        XCTAssertNoThrow(
            try GameEngine.apply(.finishMinigame(runID: run.id), to: &state, at: now)
        )
    }

    func testPausePreservesExactProgressAndCancelAloneDestroysIt() throws {
        var state = GameState.new(now: now)
        let run = try startPlayingCarrot(in: &state, mode: .relaxed)
        _ = try GameEngine.apply(
            .carrotCatchInput(runID: run.id, lane: 1),
            to: &state,
            at: now.adding(seconds: 1)
        )
        _ = try GameEngine.apply(
            .pauseMinigame(runID: run.id),
            to: &state,
            at: now.adding(seconds: 2)
        )
        let encoded = try JSONEncoder().encode(state)
        let resumed = try JSONDecoder().decode(GameState.self, from: encoded)
        XCTAssertEqual(resumed, state)
        XCTAssertEqual(resumed.activeMinigame?.isPaused, true)

        let beforeCancel = state.carrots
        _ = try GameEngine.apply(.cancelMinigame(runID: run.id), to: &state, at: now)
        XCTAssertNil(state.activeMinigame)
        XCTAssertEqual(state.carrots, beforeCancel)
        XCTAssertFalse(state.rewardedMinigameRuns.contains(run.id))
    }

    private func startPlayingCarrot(
        in state: inout GameState,
        mode: CarrotCatchTimingMode = .standard
    ) throws -> ActiveMinigameRun {
        _ = try GameEngine.apply(.startMinigame(kind: .carrotCatch), to: &state, at: now)
        let run = try XCTUnwrap(state.activeMinigame)
        if mode != .standard {
            _ = try GameEngine.apply(
                .setCarrotCatchTiming(runID: run.id, mode: mode),
                to: &state,
                at: now
            )
        }
        for _ in 0 ..< 3 {
            _ = try GameEngine.apply(
                .advanceCarrotCatchCountdown(runID: run.id),
                to: &state,
                at: now
            )
        }
        return try XCTUnwrap(state.activeMinigame)
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
