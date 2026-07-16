import Foundation
import GoobyCore
import XCTest

final class SimulationTests: XCTestCase {
    private let start = GameInstant(secondsSinceEpoch: 1_700_000_000)

    func testNewStateHasStableDefaultsAndBoundedNeeds() {
        let state = GameState.new(now: start)

        XCTAssertEqual(state.petID, .gooby)
        XCTAssertEqual(state.lastSimulatedAt, start)
        XCTAssertEqual(state.currentRoom, .playroom)
        XCTAssertEqual(state.carrots, 30)
        XCTAssertEqual(NeedValue(-1).value, 0)
        XCTAssertEqual(NeedValue(1_001).value, 1_000)
    }

    func testSimulationIsPartitionInvariant() {
        var oneStep = GameState.new(now: start)
        var partitioned = oneStep

        _ = GameSimulation.advance(&oneStep, to: start.adding(seconds: 10 * 60))
        for minute in 1 ... 10 {
            _ = GameSimulation.advance(
                &partitioned,
                to: start.adding(seconds: Int64(minute * 60))
            )
        }

        XCTAssertEqual(oneStep, partitioned)
    }

    func testPartialMinutesAreRetainedAcrossCalls() {
        var state = GameState.new(now: start)

        XCTAssertTrue(
            GameSimulation.advance(&state, to: start.adding(seconds: 59)).isEmpty
        )
        XCTAssertEqual(state.lastSimulatedAt, start)
        XCTAssertEqual(
            GameSimulation.advance(&state, to: start.adding(seconds: 61)),
            [.simulated(minutes: 1)]
        )
        XCTAssertEqual(state.lastSimulatedAt, start.adding(seconds: 60))
    }

    func testOfflineSimulationCapsAtEightHoursAndConsumesExcessTime() {
        var state = GameState.new(now: start)
        let returnTime = start.adding(seconds: 12 * 60 * 60)

        XCTAssertEqual(
            GameSimulation.advance(&state, to: returnTime),
            [.simulated(minutes: 480)]
        )
        XCTAssertEqual(state.lastSimulatedAt, returnTime)
        XCTAssertTrue(GameSimulation.advance(&state, to: returnTime).isEmpty)
    }

    func testOfflineNeedsDecayNaturallyWithoutSafetyFloorHealing() {
        var state = GameState.new(now: start)
        state.needs = Needs(
            fullness: NeedValue(201),
            cleanliness: NeedValue(151),
            energy: NeedValue(101),
            fun: NeedValue(101)
        )

        _ = GameSimulation.advance(
            &state,
            to: start.adding(seconds: GameSimulation.offlineCapSeconds)
        )

        XCTAssertEqual(state.needs.fullness.value, 0)
        XCTAssertEqual(state.needs.cleanliness.value, 0)
        XCTAssertEqual(state.needs.energy.value, 0)
        XCTAssertEqual(state.needs.fun.value, 0)
    }

    func testClockRollbackDoesNotRewindOrSimulate() {
        var state = GameState.new(now: start)
        let future = start.adding(seconds: 120)
        _ = GameSimulation.advance(&state, to: future)
        let snapshot = state

        XCTAssertTrue(GameSimulation.advance(&state, to: start).isEmpty)
        XCTAssertEqual(state, snapshot)
    }

    func testExtremeInstantsClampAndSimulateWithoutOverflowing() {
        XCTAssertEqual(
            GameInstant(secondsSinceEpoch: .max).adding(seconds: 1),
            GameInstant(secondsSinceEpoch: .max)
        )
        XCTAssertEqual(
            GameInstant(secondsSinceEpoch: .min).adding(seconds: -1),
            GameInstant(secondsSinceEpoch: .min)
        )

        var state = GameState.new(now: GameInstant(secondsSinceEpoch: .min))
        XCTAssertEqual(
            GameSimulation.advance(
                &state,
                to: GameInstant(secondsSinceEpoch: .max)
            ),
            [.simulated(minutes: 480)]
        )
        XCTAssertEqual(state.lastSimulatedAt, GameInstant(secondsSinceEpoch: .max))
    }

    func testDailyRewardScheduleHandlesInvalidCycleCountWithoutTrapping() {
        let reward = DailyRewardState(lastClaimedDay: 10, streakStep: 7)

        XCTAssertEqual(
            DailyRewardSchedule.eligibility(
                for: reward,
                at: GameInstant(
                    secondsSinceEpoch: 11 * DailyRewardSchedule.secondsPerDay
                ),
                cycleCount: 0
            ),
            .eligible(step: 1)
        )
    }

    func testLocalDayKeyHandlesDSTRepeatedHourAsOneVisitDate() throws {
        let newYork = try XCTUnwrap(TimeZone(identifier: "America/New_York"))
        let firstHour = GameInstant(secondsSinceEpoch: 1_730_611_800)
        let repeatedHour = GameInstant(secondsSinceEpoch: 1_730_615_400)

        XCTAssertEqual(
            DailyRewardSchedule.localDayKey(for: firstHour, timeZone: newYork),
            DailyRewardSchedule.localDayKey(for: repeatedHour, timeZone: newYork)
        )
    }

    func testTimezoneAndClockForwardBackUseLedgerWithoutPermanentLock() throws {
        let utc = try XCTUnwrap(TimeZone(secondsFromGMT: 0))
        let pacific = try XCTUnwrap(TimeZone(identifier: "Pacific/Kiritimati"))
        let instant = GameInstant(secondsSinceEpoch: 1_728_043_200)
        let utcDay = DailyRewardSchedule.localDayKey(for: instant, timeZone: utc)
        let forwardDay = DailyRewardSchedule.localDayKey(for: instant, timeZone: pacific)
        var reward = DailyRewardState(
            streakStep: 1,
            claimedLocalDays: [forwardDay]
        )

        XCTAssertEqual(
            DailyRewardSchedule.eligibility(
                for: reward,
                at: instant,
                localDay: forwardDay
            ),
            .alreadyClaimed(step: 1)
        )
        XCTAssertEqual(
            DailyRewardSchedule.eligibility(
                for: reward,
                at: instant,
                localDay: utcDay
            ),
            .eligible(step: 2)
        )
        reward.claimedLocalDays.append(utcDay)
        XCTAssertEqual(
            DailyRewardSchedule.eligibility(
                for: reward,
                at: instant,
                localDay: forwardDay
            ),
            .alreadyClaimed(step: 1)
        )
    }

    func testSleepRestoresEnergyUsingTheSameFixedTicks() {
        var state = GameState.new(now: start)
        state.currentRoom = .bedroom
        state.needs.energy = NeedValue(500)
        _ = try? GameEngine.apply(.beginSleep, to: &state, at: start)

        _ = GameSimulation.advance(&state, to: start.adding(seconds: 10 * 60))

        XCTAssertEqual(state.needs.energy.value, 540)
        XCTAssertEqual(state.needs.fullness.value, 790)
        XCTAssertTrue(state.isSleeping)
    }

    func testPositiveSleepRecoveryAddsExactlyRequestedAmountBelowOldFloor() {
        var state = GameState.new(now: start)
        state.currentRoom = .bedroom
        state.needs.energy = NeedValue(0)
        _ = try? GameEngine.apply(.beginSleep, to: &state, at: start)

        _ = GameSimulation.advanceForeground(
            &state,
            to: start.adding(seconds: GameSimulation.tickSeconds)
        )

        XCTAssertEqual(state.needs.energy.value, 4)
    }

    func testForegroundProgressIsUncappedAndPartitionInvariantAfterOneAbsence() {
        let returnTime = start.adding(seconds: 12 * 60 * 60)
        var whole = GameState.new(now: start)
        var partitioned = whole

        _ = GameSimulation.advanceAfterAbsence(&whole, to: returnTime)
        _ = GameSimulation.advanceAfterAbsence(&partitioned, to: returnTime)
        for minute in 1 ... 20 {
            _ = GameSimulation.advanceForeground(
                &whole,
                to: returnTime.adding(seconds: Int64(minute * 60))
            )
        }
        _ = GameSimulation.advanceForeground(
            &partitioned,
            to: returnTime.adding(seconds: 20 * 60)
        )

        XCTAssertEqual(whole, partitioned)
        XCTAssertEqual(
            whole.lastSimulatedAt,
            returnTime.adding(seconds: 20 * 60)
        )
    }
}
